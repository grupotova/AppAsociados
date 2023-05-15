using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Views;
using TOVA_API.Models.AppAsociados.V1;
using TOVA_APP_ASOCIADOS.Helpers;
using TOVA_APP_ASOCIADOS.Models.Marcaciones;
using TOVA_APP_ASOCIADOS.Services.Marcaciones;

namespace TOVA_APP_ASOCIADOS.Views.Marcaciones;

public partial class MarcacionesPage : ContentPage
{

	private string ViewName = "GESTION DE MARCAS";
	ObservableCollection<TimelineCollection> TimeLineItem = new ObservableCollection<TimelineCollection>();
	public ObservableCollection<TimelineCollection> _TimeLineItem { get { return TimeLineItem; } }
	readonly IGestionMarcas _IGestionMarcas = new GestionMarcas();

	public MarcacionesPage()
	{
		InitializeComponent();
	}


	// INFO: Obtener datos del Header
	private void ObtenerDatosHeader()
	{
		string GUCNumeroAsociado = Preferences.Default.Get("guc_numero_asociado", "Desconocido");

		// Linea de Header
		HeaderLinea1.Text = "Hola, ";
		HeaderLinea3.Text = "No. Asociado: " + GUCNumeroAsociado;

		// Version del APP
		string TipoDispositivo = Preferences.Default.Get("dispositivo_tipo", "D");
		HeaderControlVersion.Text = "Versión: v" + VersionTracking.CurrentVersion + TipoDispositivo;
	}

	// INFO: Historial de Marcaciones
	private async void HistoralGestionMarcacion()
	{
		string NumeroAsociado = Preferences.Default.Get("guc_numero_asociado", "0");
		Utilidades.PrintLogStatic(ViewName, "Obteniendo marcaciones del asociado = " + NumeroAsociado);
		var response = await _IGestionMarcas.GetMarcacionesAllAsync(NumeroAsociado);
		int _StatusCode = response.Item1;
		var _items = response.Item2;

		// Validando respuesta de status code
		if (_StatusCode == 200)
		{

			// Si el arreglo tiene objetos, mostrar el collectionview
			if (_items.Count > 0)
			{
				_TimeLineItem.Clear();
				TimelineListView.IsVisible = true;
				NoHayListado.IsVisible = false;

				foreach (var item in _items)
				{
					_TimeLineItem.Add(new TimelineCollection()
					{
						TipoMarcacion = item.tipoMarcacion == 1 ? "Entrada – " : "Salida – ",
						Descripcion = "Lugar: " + item.baseNombre,
						GeoReferencia = "Georeferencia: " + item.coordenadas_GPS,
						CoordenadasGPS = item.coordenadas_GPS,
						Hora = item.fechaCompleta.ToString()
					});
				}

				// Agregar al ListView
				TimelineListView.ItemsSource = TimeLineItem;

				// Validar en que tipo de marcacion se quedo para desactivar el otro boton
				if (_items[0].tipoMarcacion == 1)
				{
					SwitchBotones(2);
				}
				else if (_items[0].tipoMarcacion == 2)
				{
					SwitchBotones(1);
				}


			}
			else
			{
				TimelineListView.IsVisible = false;
				NoHayListado.IsVisible = true;

				// No tiene marcacaciones, activar solo el boton de entrada.
				SwitchBotones(1);
			}
		}
		else
		{
			string Msg = "Al intentar conectar con el servidor. Por favor intente de nuevo. STATUS CODE = #" + _StatusCode.ToString();
			Utilidades.PrintLogStatic(ViewName, "Error: " + Msg);
			await Navigation.PushAsync(new Shared.ErrorConexionPage(_StatusCode));
		}
	}

	// INFO: Post de nueva marcacion
	private async void PostMarcacion(int TipoMarcacion)
	{
		bool ok = await SolicitarPermisos();
		if (ok)
		{

			var loadingPopup = new Widgets.LoadingPopup();
			this.ShowPopup(loadingPopup);
			string UbicacionActualGPS = await ObtenerUbicacion();
			string MarcacionBase = "DESCONOCIDO";

			// Obtener listado de las Bases Georreferenciadas
			Utilidades.PrintLogStatic(ViewName, "Obteniendo Georreferencias.");
			var response = await _IGestionMarcas.GetBasesAllAsync();
			int _StatusCode = response.Item1;
			var _itemsBasesAll = response.Item2;
			// Validando respuesta de status code
			if (_StatusCode == 200)
			{
				foreach (var itemBase in _itemsBasesAll)
				{
					// Base
					string CoordenadasBase = itemBase.coordenadas_GPS.Trim();
					string[] CoordenadasBaseSplit = CoordenadasBase.Split(',');
					double lat1 = double.Parse(CoordenadasBaseSplit[0]);
					double lon1 = double.Parse(CoordenadasBaseSplit[1]);

					// GPS Actual
					string[] CoordenadasGPSSplit = UbicacionActualGPS.Trim().Split(',');
					double lat2 = double.Parse(CoordenadasGPSSplit[0]);
					double lon2 = double.Parse(CoordenadasGPSSplit[1]);

					double DistanciaActual = GPSHelper.CalculateDistance(lat1, lon1, lat2, lon2);
					if (DistanciaActual < 1000.00)
					{
						MarcacionBase = itemBase.@base;
						Utilidades.PrintLogStatic(ViewName, $"Esta en base: {itemBase.@base} con el nombre: {itemBase.nombre}");
						break;
					}
				}
			}

			// Registrar marcacion
			string NumeroAsociado = Preferences.Default.Get("guc_numero_asociado", "0");
			Utilidades.PrintLogStatic(ViewName, "Registrando marcacion del asociado = " + NumeroAsociado);
			var _model = new GestionMarcas_In()
			{
				NumeroAsociado = NumeroAsociado,
				Base = MarcacionBase,
				TipoMarcacion = TipoMarcacion,
				CoordenadasGPS = UbicacionActualGPS
			};
			var response2 = await _IGestionMarcas.PostMarcacionesAsync(_model);
			_StatusCode = response2.Item1;
			var _items = response2.Item2;

			// Validando respuesta de status code
			if (_StatusCode == 200)
			{
				// Si el arreglo tiene objetos, mostrar el collectionview
				if (_items.ok)
				{
					await DisplayAlert("Marcación", "La nueva marcación ha sido registrado exitosamente.", "Cerrar");
				}
				else
				{
					if (_items.errorDuplicaTipoMarca == true)
					{
						await DisplayAlert("Error", "El tipo de marcación ya se encuentra registrado. Por favor intente nuevamente.", "Cerrar");
					}
					else
					{
						await DisplayAlert("Error", "Al intentar registrar esta marcación. Por favor intente nuevamente.", "Cerrar");
					}
				}
			}
			else
			{
				string Msg = "Al intentar conectar con el servidor. Por favor intente de nuevo. STATUS CODE = #" + _StatusCode.ToString();
				Utilidades.PrintLogStatic(ViewName, "Error: " + Msg);
				await Navigation.PushAsync(new Shared.ErrorConexionPage(_StatusCode));
			}


			// Historial de gestion de marcacion
			HistoralGestionMarcacion();

			// Cerrar widget loading
			loadingPopup.Close();
		}
	}

	// INFO: Activar o desactivar los botones de marcaciones
	private void SwitchBotones(int TipoMarcacion)
	{
		switch (TipoMarcacion)
		{
			// Activar solo boton de entrada
			case 1:
				BotonMarcacionEntrada.IsEnabled = true;
				BotonMarcacionEntrada.Background = Colors.Green;
				BotonMarcacionSalida.IsEnabled = false;
				BotonMarcacionSalida.Background = Colors.DarkGray;
				break;

			// Activar solo boton de salida
			case 2:
				BotonMarcacionSalida.IsEnabled = true;
				BotonMarcacionSalida.Background = Colors.Red;
				BotonMarcacionEntrada.IsEnabled = false;
				BotonMarcacionEntrada.Background = Colors.DarkGray;
				break;

			// Desactivar todos los botones
			case 3:
				BotonMarcacionSalida.IsEnabled = false;
				BotonMarcacionSalida.Background = Colors.DarkGray;
				BotonMarcacionEntrada.IsEnabled = false;
				BotonMarcacionEntrada.Background = Colors.DarkGray;
				break;
		}
	}

	// INFO: Solicitar el permiso para registrar el GPS
	private async Task<bool> SolicitarPermisos()
	{
		bool statusPermission = true;
		var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
		if (status != PermissionStatus.Granted)
		{
			status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
			if (status != PermissionStatus.Granted)
			{
				statusPermission = false;
			}
		}

		return statusPermission;
	}

	// INFO: Obtener Ubicacion GPS
	private async Task<string> ObtenerUbicacion()
	{
		double latitude = 0;
		double longitude = 0;
		var location = await Geolocation.GetLocationAsync();
		if (location != null)
		{
			latitude = location.Latitude;
			longitude = location.Longitude;
		}

		string GPS = latitude.ToString() + "," + longitude.ToString();
		return GPS;
	}


	// INFO: Boton de marcacion entrada
	private async void BotonMarcacionEntrada_Clicked(object sender, EventArgs e)
	{
		bool resultadoPermisosGPS = await SolicitarPermisos();
		if (resultadoPermisosGPS)
		{
			PostMarcacion(1);
		}
		else
		{
			await DisplayAlert("Error", "Es necesario el permiso GPS para realizar esta operación.", "Cerrar");
		}
	}

	// INFO: Boton de marcacion salida
	private async void BotonMarcacionSalida_Clicked(object sender, EventArgs e)
	{
		bool resultadoPermisosGPS = await SolicitarPermisos();
		if (resultadoPermisosGPS)
		{
			PostMarcacion(2);
		}
		else
		{
			await DisplayAlert("Error", "Es necesario el permiso GPS para realizar esta operación.", "Cerrar");
		}
	}

	// INFO: Abrir Popup de Google Maps
	private void Grid_Tapped(object sender, EventArgs e)
	{
		var CoordenadasGPS = ((TappedEventArgs)e).Parameter;
		var MarcacionGMaps = new Widgets.MarcacionGMapsPopup(CoordenadasGPS.ToString());
		this.ShowPopup(MarcacionGMaps);
	}

	// OnAppearing
	protected override void OnAppearing()
	{

		base.OnAppearing();

		// Obtener Header
		SwitchBotones(3); 
		ObtenerDatosHeader();

		// Historial
		HistoralGestionMarcacion();
	}
}