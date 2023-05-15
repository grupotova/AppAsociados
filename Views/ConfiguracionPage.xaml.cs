using TOVA_APP_ASOCIADOS.Helpers;

namespace TOVA_APP_ASOCIADOS.Views;

public partial class ConfiguracionPage : ContentPage
{

    private string ViewName = "CONFIGURACION";
    private string selectedValue = null;

    public ConfiguracionPage()
    {
        InitializeComponent();
    }


    // Info: Obtener seleccion en Picker
    private void picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var _selectedItem = picker.SelectedItem; // Obtener el elemento seleccionado

        if (_selectedItem != null)
        {
            selectedValue = _selectedItem.ToString(); // Convertir el elemento seleccionado a una cadena
            BotonGuardar.Background = Colors.DarkBlue;
            BotonGuardar.IsEnabled = true;
        }
    }


    // Info: Guardar preferencia
    private async void BotonGuardarPreferencias(object sender, EventArgs e)
    {
        // PREFERENCIA
        string TipoDispositivo = null;

        switch (selectedValue)
        {
            case "Celular Personal":
                TipoDispositivo = "P";
                Preferences.Default.Set("dispositivo_tipo", TipoDispositivo);
                Preferences.Default.Set("dispositivo_configurado", true);
                Utilidades.PrintLogStatic(ViewName, "Guardando preferencia - dispositivo_tipo = " + selectedValue);
                await Navigation.PushAsync(new LoginPage());
                break;

            case "Celular Corporativo":
                TipoDispositivo = "C";
                Preferences.Default.Set("dispositivo_tipo", TipoDispositivo);
                Preferences.Default.Set("dispositivo_configurado", true);
                Utilidades.PrintLogStatic(ViewName, "Guardando preferencia - dispositivo_tipo = " + selectedValue);
                await Navigation.PushAsync(new LoginPage());
                break;

            default:
				Utilidades.PrintLogStatic(ViewName, "Guardando preferencia - valor no obtenido");
				break;

        }
    }

    // Verificar si esta configurado el tipo de dispositivo
    private async void ValidarConfiguracion()
    {
        bool DispositivoConfigurado = Preferences.Default.Get("dispositivo_configurado", false);
		bool NumeroAsociadoConfigurado = Preferences.Default.Get("guc_configurado", false);

        // Si esta configurado dispositivo y no numero de asociado
		if (DispositivoConfigurado && NumeroAsociadoConfigurado == false)
        {
            Utilidades.PrintLogStatic(ViewName, "Dispositivo configurado, forzar redireccion.");
            await Navigation.PushAsync(new LoginPage());
        } 
        // Si esta configurado depositivo y tambien numero de asociado.
        else if (DispositivoConfigurado && NumeroAsociadoConfigurado)
        {
			Utilidades.PrintLogStatic(ViewName, "Numero de Asociado Configurado, forzar redireccion.");
			await Navigation.PushAsync(new Marcaciones.MarcacionesPage());
		}

	}


    // Verificar esta configurado
    protected override void OnAppearing()
    {
        base.OnAppearing();
		ValidarConfiguracion();
	}

}