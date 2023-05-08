using CommunityToolkit.Maui.Views;
using TOVA_APP_ASOCIADOS.Helpers;

namespace TOVA_APP_ASOCIADOS.Views.Shared;

public partial class ErrorConexionPage : ContentPage
{
    private string ViewName = "ERROR DE CONEXION";

    public ErrorConexionPage(int statusCode)
	{
		InitializeComponent();

        // Initial subtitulo
        string strSubtitulo = "Upps, hemos tenido un error innesperado. HTTP Status Code #" + statusCode + ". Por favor intente nuevamente.";
        Utilidades.PrintLogStatic(ViewName, strSubtitulo);
        Subtitulo.Text = strSubtitulo;
    }


    // INFO: Boton de regresar en pantalla
    private void BtnRegresar_Clicked(object sender, EventArgs e)
    {
        this.IsEnabled = false;
        ExecRegresar();
        this.IsEnabled = true;

	}

    // INFO: Acción de botón regresar en teclado
    protected override bool OnBackButtonPressed()
    {
        ExecRegresar();
		return true;
    }

    // INFO: Ejecutar Regresar
    private async void ExecRegresar()
    {
        // Abrir LoadingPage
		Utilidades.PrintLogStatic(ViewName, "Abriendo Widget LoadingPage y regresar a la pagina anterior.");
		var loadingPopup = new Widgets.LoadingPopup(); // Widget de loading
		this.ShowPopup(loadingPopup);

        // Regresar a la pagina del error
        await Navigation.PopAsync();

        // Cerrar
        loadingPopup.Close();
    }
}