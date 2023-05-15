using CommunityToolkit.Maui.Views;
using TOVA_APP_ASOCIADOS.Helpers;
using TOVA_APP_ASOCIADOS.Services.ControlVersion;

namespace TOVA_APP_ASOCIADOS.Views;

public partial class LoginPage : ContentPage
{
	private readonly IControlDeVersion iControlDeVersion = new ControlDeVersion();
	private string ViewName = "LOGIN";
	private PermissionStatus permissionStatus;

	public LoginPage()
	{
		InitializeComponent();


	}

	// INFO: Evento al hacer boton ingresar
	private async void BotonIngresar_Clicked(object sender, EventArgs args)
	{
		// INFO: Abrir loading y redireccion a dashboard
		var loadingPopup = new Widgets.LoadingPopup();
		this.ShowPopup(loadingPopup);

		// INFO: Desactivar boton para evitar doble click
		CambiarEstadoBotonIngresar(false);

		// INFO: Validación de numero de asociado
		bool respuesta = await DisplayAlert("Confirmación", "Esta seguro que número de asociado es: " + NumeroAsociado.Text + ".", "SÍ", "NO"); ;
		if (respuesta)
		{
			Preferences.Default.Set("guc_configurado", true);
			Preferences.Default.Set("guc_numero_asociado", NumeroAsociado.Text);

			// Limpiar 
			NumeroAsociado.Text = "";

			// Redireccionar
			Utilidades.PrintLogStatic(ViewName, "Redireccion a Gestión de marcacion.");
			await Navigation.PushAsync(new Marcaciones.MarcacionesPage());
		}

		// INFO: Activar boton nuevamente
		CambiarEstadoBotonIngresar(true);
		loadingPopup.Close();
	}

	// INFO: Validar boton de ingresar
	private void ValidarEntryUsuarioYContrasena()
	{
		if (NumeroAsociado.Text is not null)
		{
			if (NumeroAsociado.Text.Length > 0)
			{
				Utilidades.PrintLogStatic(ViewName, "Activar boton de ingreso.");
				CambiarEstadoBotonIngresar(true);
			}
			else
			{
				Utilidades.PrintLogStatic(ViewName, "Desactivar boton de ingreso.");
				CambiarEstadoBotonIngresar(false);
			}
		}
		else
		{
			Utilidades.PrintLogStatic(ViewName, "Desactivar boton de ingresar.");
			CambiarEstadoBotonIngresar(false);
		}
	}

	// INFO: Cambiar estado de boton de Ingresar
	private void CambiarEstadoBotonIngresar(bool status)
	{
		if (status)
		{
			BotonIngresar.IsEnabled = true;
			BotonIngresar.Background = Color.FromArgb("#001B33");
		}
		else
		{
			BotonIngresar.IsEnabled = false;
			BotonIngresar.Background = Colors.DarkGray;
		}
	}


	// INFO: Validar cambio de textos en los Entry (Usario o contrasena) para habilitar o desactivar el boton de ingresar
	private void Usuario_TextChanged(object sender, TextChangedEventArgs e)
	{
		ValidarEntryUsuarioYContrasena();
	}


	// INFO: Verificar control de versiones del APP
	private async void ControlVersionApp()
	{

		Utilidades.PrintLogStatic(ViewName, "Validando version del app = " + VersionTracking.CurrentVersion);

		// Longitud maxima
		var response = await iControlDeVersion.GetControlVersionAsync(Constants.APPNombre, VersionTracking.CurrentVersion);
		int _StatusCode = response.Item1;
		var _items = response.Item2;

		// Validando respuesta de status code
		if (_StatusCode == 200)
		{
			// Obtener respuesta de arreglo
			if (_items.status == false && _items.appExiste == true)
			{
				Utilidades.PrintLogStatic(ViewName, "Existe una nueva version del APP v" + _items.ultimaVersion + ", redirecionando...");

				// Redireccionar
				await Navigation.PushAsync(new ControlVersion.ActualizacionPage(_items.androidUrlDownload));
			}
			else
			{
				Utilidades.PrintLogStatic(ViewName, "El APP esta actualizado a la última version.");
			}
		}
		else
		{
			string Msg = "Al intentar conectar con el servidor. Por favor intente de nuevo. STATUS CODE = #" + _StatusCode.ToString();
			Utilidades.PrintLogStatic(ViewName, "Error: " + Msg);
			await Navigation.PushAsync(new Shared.ErrorConexionPage(_StatusCode));
		}
	}

	// INFO: Solicitar los permisos
	private async void SolicitarPermisosApp()
	{
		permissionStatus = await Permissions.RequestAsync<Permissions.Phone>();
		permissionStatus = await Permissions.RequestAsync<Permissions.Battery>();
		permissionStatus = await Permissions.RequestAsync<Permissions.StorageRead>();
		permissionStatus = await Permissions.RequestAsync<Permissions.StorageWrite>();
	}

	// Verificar si esta configurado el numero de asociado
	private async void ValidarConfiguracion()
	{
		bool NumeroAsociadoConfigurado = Preferences.Default.Get("guc_configurado", false);
		if (NumeroAsociadoConfigurado)
		{
			//Utilidades.PrintLogStatic(ViewName, "Numero de Asociado Configurado, forzar redireccion.");
			//await Navigation.PushAsync(new Marcaciones.MarcacionesPage());
		} else
		{
			/*
			// Iniciar el APP desactivar el boton por default
			CambiarEstadoBotonIngresar(false);

			// App Version
			AppVersion.Text = Constants.VersionApp;

			// Solicitar Permisos
			// SolicitarPermisosApp();

			// Verificar version App
			ControlVersionApp();
			*/
		}
	}


	// Verificar esta configurado
	protected override void OnAppearing()
	{
		base.OnAppearing();
		ValidarConfiguracion();
	}
}