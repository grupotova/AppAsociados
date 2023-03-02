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

        // Obtener Header
        ObtenerHeader();
    }


    // INFO: Obtener Header
    private void ObtenerHeader()
    {
        string GUCNombreUsuario = Preferences.Default.Get("guc_login", "Desconocido");
        string GUCNombre = Preferences.Default.Get("guc_nombre", "Desconocido");

        HeaderLinea1.Text = "Hola, " + GUCNombre;
        HeaderLinea2.Text = "Usuario: " + GUCNombreUsuario;

        /*
        double Distancia = GPSHelper.CalculateDistance(8.979578576274397, -79.52451240499491, 8.979436836775932, -79.52436488350538);
        Utilidades.PrintLogStatic(ViewName, $"La distancia entre punto es {Distancia}");
        */
    }

    // INFO: Historial de Marcaciones
    private async void InitialGestionMarcacion()
    {
        string _usuarioId = Preferences.Default.Get("guc_login_id", "-1");
        int UsuarioId = int.Parse(_usuarioId);
        Utilidades.PrintLogStatic(ViewName, "Obteniendo marcaciones del usuario id = " + UsuarioId.ToString());
        var _items = await _IGestionMarcas.GetMarcacionesAllAsync(UsuarioId);

        // Si el arreglo tiene objetos, mostrar el collectionview
        if (_items.Count > 0)
        {
            _TimeLineItem.Clear();
            TimelineListView.IsVisible = true;

            foreach (var item in _items)
            {
                _TimeLineItem.Add(new TimelineCollection()
                {
                    TipoMarcacion = item.tipoMarcacion == 1 ? "Entrada – " : "Salida – ",
                    Descripcion = item.descripcion,
                    GeoReferencia = item.coordenadas_GPS,
                    Hora = item.fecha.ToString()
                });
            }

            // Agregar al ListView
            TimelineListView.ItemsSource = TimeLineItem;

            // Validar en que tipo de marcacion se quedo para desactivar el otro boton
            if (_items[0].tipoMarcacion == 1)
            {
                SwitchBotones(2);
            } else if (_items[0].tipoMarcacion == 2)
            {
                SwitchBotones(1);
            }


        } else
        {
            TimelineListView.IsVisible = false;
        }
    }

    // Marcacion
    private async void PostMarcacion(int TipoMarcacion)
    {
        bool ok = await SolicitarPermisos();
        if (ok) {

            var loadingPopup = new Widgets.LoadingPopup();
            this.ShowPopup(loadingPopup);
            string ObtenerUbicacionActual = await ObtenerUbicacion();
            string MarcacionDescripcion = "Desconocido";

            // Obtener listado de las Bases Georreferenciadas
            Utilidades.PrintLogStatic(ViewName, "Obteniendo Georreferencias.");
            var _itemsBasesAll = await _IGestionMarcas.GetBasesAllAsync();
            foreach (var itemBase in _itemsBasesAll)
            {
                // Base
                string CoordenadasBase = itemBase.coordenadasGPS.Trim();
                string[] CoordenadasBaseSplit = CoordenadasBase.Split(',');
                double lat1 = double.Parse(CoordenadasBaseSplit[0]);
                double lon1 = double.Parse(CoordenadasBaseSplit[1]);

                // GPS Actual
                string[] CoordenadasGPSSplit = ObtenerUbicacionActual.Trim().Split(',');
                double lat2 = double.Parse(CoordenadasGPSSplit[0]);
                double lon2 = double.Parse(CoordenadasGPSSplit[1]);

                double DistanciaActual = GPSHelper.CalculateDistance(lat1, lon1, lat2, lon2);
                if (DistanciaActual < 1000.00)
                {
                    MarcacionDescripcion = itemBase.nombre;
                    Utilidades.PrintLogStatic(ViewName, $"Esta en base {itemBase.nombre}");
                    break;
                }
            }

            // Registrar marcacion
            string _usuarioId = Preferences.Default.Get("guc_login_id", "-1");
            int UsuarioId = int.Parse(_usuarioId);
            Utilidades.PrintLogStatic(ViewName, "Registrando marcacion del usuario id = " + UsuarioId.ToString());
            var _model = new GestionMarcas_In()
            {
                UsuarioId = UsuarioId,
                Descripcion = "Lugar: " + MarcacionDescripcion,
                TipoMarcacion = TipoMarcacion,
                CoordenadasGPS = "Georeferencia: " + ObtenerUbicacionActual
            };
            var _items = await _IGestionMarcas.PostMarcacionesAsync(_model);

            // Si el arreglo tiene objetos, mostrar el collectionview
            if (_items.Count > 0)
            {
                if (_items[0].ok)
                {
                    await DisplayAlert("Marcación", "La nueva marcación ha sido registrado exitosamente.", "Cerrar");  
                } else
                {
                    await DisplayAlert("Error", "Al intentar registrar esta marcación. Por favor intente nuevamente", "Cerrar");
                }
            } else
            {
                await DisplayAlert("Error", "Al intentar registrar esta marcación. Por favor intente nuevamente", "Cerrar");
            }

            // Inicializar el listview
            InitialGestionMarcacion();

            // Cerrar widget loading
            loadingPopup.Close();
        }
    }

    // INFO: Activar o desactivar los botones de marcaciones
    private void SwitchBotones(int TipoMarcacion)
    {
        switch (TipoMarcacion)
        {
            case 1:
                BotonMarcacionEntrada.IsEnabled = true;
                BotonMarcacionEntrada.Background = Colors.Green;
                BotonMarcacionSalida.IsEnabled = false;
                BotonMarcacionSalida.Background = Colors.DarkGray;
                break;

            case 2:
                BotonMarcacionSalida.IsEnabled = true;
                BotonMarcacionSalida.Background = Colors.Red;
                BotonMarcacionEntrada.IsEnabled = false;
                BotonMarcacionEntrada.Background = Colors.DarkGray;
                break;
        }
    }

    // INFO: Solicitar el permiso
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
        
        string GPS = latitude.ToString() + "," +longitude.ToString();
        return GPS;
    }

    // OnAppearing
    protected async override void OnAppearing()
    {
        base.OnAppearing();
        bool resultadoPermisosGPS = await SolicitarPermisos();
        InitialGestionMarcacion();
    }

    // INFO: Boton de marcacion entrada
    private async void BotonMarcacionEntrada_Clicked(object sender, EventArgs e)
    {
        bool resultadoPermisosGPS = await SolicitarPermisos();
        if(resultadoPermisosGPS)
        {
            PostMarcacion(1);
        } else
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
        } else
        {
            await DisplayAlert("Error", "Es necesario el permiso GPS para realizar esta operación.", "Cerrar");
        }
    }
}