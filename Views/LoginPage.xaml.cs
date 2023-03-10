using CommunityToolkit.Maui.Views;
using TOVA_APP_ASOCIADOS.Helpers;
using TOVA_APP_ASOCIADOS.Services.Auth;
using TOVA_APP_ASOCIADOS.Services.ControlVersion;

namespace TOVA_APP_ASOCIADOS.Views;

public partial class LoginPage : ContentPage
{
    private readonly IControlDeVersion iControlDeVersion = new ControlDeVersion();
    private readonly ILoginService iloginService = new LoginService();
    private string MensajeAutentificacion = "";
    private string ViewName = "LOGIN";
    private PermissionStatus permissionStatus;

    public LoginPage()
    {
        InitializeComponent();

        // Iniciar el APP desactivar el boton por default
        CambiarEstadoBotonIngresar(false);

        // App Version
        AppVersion.Text = Constants.VersionApp;

        // Solicitar Permisos
        // SolicitarPermisosApp();

        // Verificar version App
        ControlVersionApp();

    }

    // INFO: Evento al hacer boton ingresar
    private async void BotonIngresar_Clicked(object sender, EventArgs args)
    {
        // INFO: Abrir loading y redireccion a dashboard
        var loadingPopup = new Widgets.LoadingPopup();
        this.ShowPopup(loadingPopup);

        // INFO: Desactivar boton para evitar doble click
        CambiarEstadoBotonIngresar(false);

        // INFO: Validar autentificacion de usuario
        bool respAutentificacion = await Autenticacion(Usuario.Text, Contrasena.Text, Constants.GUCApllicacionCodigo);
        if (respAutentificacion)
        {
            // Limpiar 
            Usuario.Text = "";
            Contrasena.Text = "";

            // Redireccionar
            Utilidades.PrintLogStatic(ViewName, "Redireccion a Marcacion.");
            await Navigation.PushAsync(new Marcaciones.MarcacionesPage());
        } else
        {
            await DisplayAlert("Acceso", MensajeAutentificacion, "Ok");
        }

        // INFO: Activar boton nuevamente
        CambiarEstadoBotonIngresar(true);
        loadingPopup.Close();
    }

    // INFO: Validar boton de ingresar
    private void ValidarEntryUsuarioYContrasena()
    {
        if (Usuario.Text is not null && Contrasena.Text is not null)
        {
            if (Usuario.Text.Length > 0 && Contrasena.Text.Length > 0)
            {
                Utilidades.PrintLogStatic(ViewName, "Activar boton de ingreso.");
                CambiarEstadoBotonIngresar(true);
            }
            else
            {
                Utilidades.PrintLogStatic(ViewName, "Desactivar boton de ingreso.");
                CambiarEstadoBotonIngresar(false);
            }
        } else
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

	// INFO: Autentifcacion de usuario (GUCService)
	/*
    private async Task<bool> Autenticacion(string login, string pass, string aplicacion)
    {
        string respService = null;
        bool respStatus = false;
        MensajeAutentificacion = null;

        try
        {
            using (ServiceGUCDev.ServiceClient a = new(ServiceGUCDev.ServiceClient.EndpointConfiguration.BasicHttpBinding_IService))
            {
                var u = await a.AuthenticateAsync(login, pass, aplicacion);
                var centrosCostosAlias = "";
                var PermisosVistas = "";
                respService = u.Message;

                if (respService == "OK")
                {

                    foreach (var app in u.Applications)
                    {
                        var centros = await a.GetCentroCostoUsuarioAsync(app.Usuario_ID, 0, 1);
                        var permisos = await a.GetMenusAsync(app.App_ID.ToString(), app.ID_Role);
                        var cont = 0;

                        // Obtener las vistas de acceso a GUC
                        Utilidades.PrintLogStatic(ViewName, "Cantidad permisos obtenidos = " + permisos.Length.ToString());
                        foreach (var permiso in permisos)
                        {
                            string NombreDeVista = permiso.Nombre.Replace(' ', '_');
                            PermisosVistas = PermisosVistas + NombreDeVista.Trim().ToUpper() + ",";
                            Utilidades.PrintLogStatic(ViewName, "Permisos a Vistas = "+ PermisosVistas);
                        }

                        // Bases asociadas al usuario
                        foreach (var centro in centros.CentrosCostos)
                        {
                            centrosCostosAlias = centrosCostosAlias + centro.AliasCentro.ToString() + ",";

                            // Logs
                            Utilidades.PrintLogStatic(ViewName, "Bases asociadas = " + centrosCostosAlias);
                            cont++;
                        }

                        // Creaando preferencia
                        if (cont > 0)
                        {
                            respStatus = true;
                            centrosCostosAlias = centrosCostosAlias.Substring(0, centrosCostosAlias.Length - 1);

                            Preferences.Default.Set("guc_configurado", true);
                            Preferences.Default.Set("guc_login_id", app.Usuario_ID.ToString());
                            Preferences.Default.Set("guc_login", login.ToLower());
                            Preferences.Default.Set("guc_nombre", app.Nombre);
                            Preferences.Default.Set("guc_apellido", app.Apellido);
                            Preferences.Default.Set("guc_numero_asociado", app.NumAsociado);
                            Preferences.Default.Set("guc_email", app.Email);
                            Preferences.Default.Set("guc_rol", app.Role_Name);
                            Preferences.Default.Set("guc_rol_id", app.ID_Role);
                            Preferences.Default.Set("guc_rol_codigo", app.RolCodigo);
                            Preferences.Default.Set("guc_bases_alias", centrosCostosAlias);
                            Preferences.Default.Set("guc_permisos_vistas", PermisosVistas);

                            // Logs
                            Utilidades.PrintLogStatic(ViewName, "App Id = " + app.App_ID.ToString());
                            Utilidades.PrintLogStatic(ViewName, "Acceso Login Id = " + app.Usuario_ID.ToString());
                            Utilidades.PrintLogStatic(ViewName, "Acceso Login = " + login.ToLower());
                            Utilidades.PrintLogStatic(ViewName, "Acceso Nombre completo = " + app.Nombre + " " + app.Apellido);
                            Utilidades.PrintLogStatic(ViewName, "Acceso Rol = " + app.Role_Name);
                        }
                        else
                        {
                            respService = "No tiene una Base Asociada, por favor asociarla en la Gestion de Usuario Centralizado.";
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            respService = "Error: " + ex.Message;
        }

        // respStatus = true;
        MensajeAutentificacion = respService;

        // Logs
        Utilidades.PrintLogStatic(ViewName, "Repuesta - " + MensajeAutentificacion);
        return respStatus;
    }
    */

    // INFO: Autentificacion temporal por TOVA API
	private async Task<bool> Autenticacion(string Usuario, string Contrasena, string AplicacionCodigo)
	{
		Utilidades.PrintLogStatic(ViewName, "Validando version del app = " + VersionTracking.CurrentVersion);

		// Ejecutar API
		var _items = await iloginService.GetLogin(Usuario, Contrasena);

		// Respuesta del Auth
		if (_items.status == true)
		{
			var centrosCostosAlias = _items.basesRelacionadas.Substring(0, _items.basesRelacionadas.Length - 1);
			Preferences.Default.Set("guc_configurado", true);
			Preferences.Default.Set("guc_login_id", _items.usuarioId);
			Preferences.Default.Set("guc_login", _items.usuario);
			Preferences.Default.Set("guc_nombre", _items.nombre);
			Preferences.Default.Set("guc_apellido", _items.apellido);
			Preferences.Default.Set("guc_numero_asociado",_items.numeroAsociado);
			Preferences.Default.Set("guc_email", _items.email);
			Preferences.Default.Set("guc_rol", _items.rol);
			Preferences.Default.Set("guc_rol_id", _items.rolId);
			Preferences.Default.Set("guc_rol_codigo", _items.rolCodigo);
			Preferences.Default.Set("guc_bases_alias", centrosCostosAlias);
			Preferences.Default.Set("guc_permisos_vistas", _items.vistasPermisos);

			return true;
		}
		else
		{
            MensajeAutentificacion = _items.mensajeError;
			Utilidades.PrintLogStatic(ViewName, "Error: " + _items.mensajeError);
            return false;
		}
	}


	// INFO: Validar cambio de textos en los Entry (Usario o contrasena) para habilitar o desactivar el boton de ingresar
	private void Usuario_TextChanged(object sender, TextChangedEventArgs e)
    {
        ValidarEntryUsuarioYContrasena();
    }

    // INFO: Cambio en el textos de contrasena
    private void Contrasena_TextChanged(object sender, TextChangedEventArgs e)
    {
        ValidarEntryUsuarioYContrasena();
    }

    // INFO: Verificar control de versiones del APP
    private async void ControlVersionApp()
    {

        Utilidades.PrintLogStatic(ViewName, "Validando version del app = " + VersionTracking.CurrentVersion);

        // Longitud maxima
        var _items = await iControlDeVersion.GetControlVersionAsync(Constants.APPNombre, VersionTracking.CurrentVersion);

        // Obtener respuesta de arreglo
        if (_items.status == false && _items.appExiste == true)
        {
            Utilidades.PrintLogStatic(ViewName, "Existe una nueva version del APP v" + _items.ultimaVersion + ", redirecionando...");

            // Redireccionar
            await Navigation.PushAsync(new ControlVersion.ActualizacionPage(_items.androidUrlDownload));
        } else
        {
            Utilidades.PrintLogStatic(ViewName, "El APP esta actualizado a la última version.");
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

    // Verificar si esta configurado el tipo de dispositivo
    private async void VerificarGUCSesion()
    {
        bool GucConfigurado = Preferences.Default.Get("guc_configurado", false);
        if (GucConfigurado)
        {
            Utilidades.PrintLogStatic(ViewName, "GUC Configurado, forzar redireccion.");
            await Navigation.PushAsync(new Marcaciones.MarcacionesPage());
        }
    }


    // Verificar esta configurado
    protected override void OnAppearing()
    {
		VerificarGUCSesion();
        base.OnAppearing();
    }
}