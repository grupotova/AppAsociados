using CommunityToolkit.Maui.Views;

namespace TOVA_APP_ASOCIADOS.Views.Widgets;

public partial class LoadingPopup : Popup
{

    public LoadingPopup()
	{
        InitializeComponent();

        // INFO: Desactivar cerrar popup desde fuera del componente, al activarlo crea un error NoResponse en el APP
        CanBeDismissedByTappingOutsideOfPopup = false;
    }
}