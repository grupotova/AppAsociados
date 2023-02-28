using Plugin.Maui.AppInstallHelper;
using TOVA_APP_ASOCIADOS.Helpers;

namespace TOVA_APP_ASOCIADOS.Views.ControlVersion;

public partial class ActualizacionPage : ContentPage
{
    private string ViewName = "ACTUALIZACI�N APP";
    private string UrlDownload = null;

    public ActualizacionPage(string _UrlDownload)
	{
		InitializeComponent();

        // URL APK
        UrlDownload = _UrlDownload;

        // Initial de actualizacion
        Subtitulo.Text = "Existe una nueva versi�n disponible, haga clic en el bot�n 'Comenzar Actualizaci�n' para iniciar el proceso.";
    }

    // INFO: Ejecutar proceso de actualizacion
    private async void EjecutarActualizacion()
    {
        Utilidades.PrintLogStatic(ViewName, "Verificando permisos del APP.");
        bool status = await InstallationHelper.AskForRequiredPermission();
        if(status) {

            Utilidades.PrintLogStatic(ViewName, "El APP cuenta los permisos necesarios.");

            // Cambiar informacion del actualizacion
            Titulo.Text = "Actualizando...";
            Subtitulo.Text = "Por favor no cierre la aplicaci�n hasta terminar el proceso de actualizaci�n.";
            BtnActualizacion.Text = "Procesando...";
            BtnActualizacion.Background = Colors.Black;
            BtnActualizacion.TextColor = Colors.White;
            BtnActualizacion.IsEnabled = false;
            BtnActualizacion.InputTransparent = true;
            await InstalarNuevaVersion();

        }
        else
        {
            Utilidades.PrintLogStatic(ViewName, "Error, el APP no cuenta los permisos necesarios.");
        }
    }

    // INFO: Descargar e instalar actualizaci�n del app.
    private async Task InstalarNuevaVersion()
    {
        // Descarga
        Utilidades.PrintLogStatic(ViewName, "Descargando APK = " + UrlDownload);
        string installPath = string.Empty;
        installPath = System.IO.Path.Combine(InstallationHelper.GetPublicDownloadPath(), "APP_BASES.APK");
        using (HttpClient hc = new HttpClient())
        {
            var response = await hc.GetAsync(UrlDownload);
            var byteArray = await response.Content.ReadAsByteArrayAsync();
            System.IO.File.WriteAllBytes(installPath, byteArray);
        }

        // Instalacion
        Utilidades.PrintLogStatic(ViewName, "Instalando APK...");
        bool ResultadoInstalacion = await InstallationHelper.InstallApp(installPath, InstallMode.OutOfAppStore);
        if (ResultadoInstalacion) {

            // Cambiar la preferencia
            Preferences.Set("app_nueva_version", false);

            // Finalizar
            BtnActualizacion.Text = "Reiniciar";
            BtnActualizacion.Background = Colors.DarkSlateBlue;
            BtnActualizacion.TextColor = Colors.White;
            BtnActualizacion.IsEnabled = true;
            BtnActualizacion.InputTransparent = false;
            Utilidades.PrintLogStatic(ViewName, "Se ha instalado correctamente la nueva versi�n del App.");

        }
        else
        {
            Titulo.Text = "Actualizaci�n disponible";
            Subtitulo.Text = "Hemos detenido el proceso al presentar un error durante la actualizac��n. Haga clic en el bot�n Comenzar Actualizaci�n' para iniciar el proceso.";
            BtnActualizacion.Text = "Comenzar actualizaci�n";
            BtnActualizacion.Background = Colors.DarkSlateBlue;
            BtnActualizacion.TextColor = Colors.White;
            BtnActualizacion.IsEnabled = true;
            BtnActualizacion.InputTransparent = false;
            Utilidades.PrintLogStatic(ViewName, "Error al intentar instalar nueva versi�n del App.");
        }
    }

    // INFO: Boton de ejecutar actualizacion
    private void BtnActualizacion_Clicked(object sender, EventArgs e)
    {
        EjecutarActualizacion();
    }

    // INFO: Bloqueo y mensaje para no salir de la pantalla de actualizaci�n APK
    protected override bool OnBackButtonPressed()
    {
        DisplayAlert("Actualizaci�n", "Por favor complete la actualizaci�n primero para seguir utilizando el APP.", "Entendido");
        return true;
    }
}