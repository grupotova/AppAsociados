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
                await Navigation.PushModalAsync(new LoginPage(), false);
                break;

            case "Celular Corporativo":
                TipoDispositivo = "C";
                Preferences.Default.Set("dispositivo_tipo", TipoDispositivo);
                Preferences.Default.Set("dispositivo_configurado", true);
                Utilidades.PrintLogStatic(ViewName, "Guardando preferencia - dispositivo_tipo = " + selectedValue);
                await Navigation.PushModalAsync(new LoginPage(), false);
                break;

        }
    }


}