using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Views;
using TOVA_APP_ASOCIADOS.Helpers;

namespace TOVA_APP_ASOCIADOS.Views.Widgets;

public partial class MarcacionGMapsPopup : Popup
{


    private string ViewName = "MARCACION - GOOGLE MAPS";
    void closePopup(object? sender, EventArgs e) => Close();

    public MarcacionGMapsPopup(string CoordenadasGPS)
    {
        InitializeComponent();

        // Actualizar coordenadas GPS
        webView.Source = "https://maps.google.com?q=" + CoordenadasGPS;

	}
}
