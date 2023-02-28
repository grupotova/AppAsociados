using Microsoft.Maui.Controls;
namespace TOVA_APP_ASOCIADOS.Views.Marcaciones;

public partial class MarcacionesPage : ContentPage
{
	public MarcacionesPage()
	{
		InitializeComponent();

        // Crear una lista de elementos de línea de tiempo
        var timelineItems = new List<TimelineItem> {
            new TimelineItem {
                TipoMarcacion = "Entrada ",
                Hora = " - 8:00 AM",
                Descripcion = "Campeon B50",
                GeoReferencia = "GeoReferencia: 8.97740, -79.51167.",
            },
            new TimelineItem {
                TipoMarcacion = "Salida ",
                Hora = " - 9:17 AM",
                Descripcion = "Campeon B50",
                GeoReferencia = "GeoReferencia: 8.97740, -79.51167.",
            },
            new TimelineItem {
                TipoMarcacion = "Entrada ",
                Hora = " - 10:12 AM",
                Descripcion = "Campeon B50",
                GeoReferencia = "GeoReferencia: 8.97740, -79.51167.",
            },
            new TimelineItem {
                TipoMarcacion = "Salida ",
                Hora = " - 1:32 PM",
                Descripcion = "Campeon B50",
                GeoReferencia = "GeoReferencia: 8.97740, -79.51167.",
            },
            new TimelineItem { 
                TipoMarcacion = "Entrada ",
                Hora = " - 4:11 PM",
                Descripcion = "Campeon B50",
                GeoReferencia = "GeoReferencia: 8.97740, -79.51167.",
            }
          };

        // Asignar la lista de elementos a la ListView
        timelineListView.ItemsSource = timelineItems;
    }

    // Clase de modelo de línea de tiempo
    public class TimelineItem
    {
        public string TipoMarcacion { get; set; }
        public string Hora { get; set; }
        public string Descripcion { get; set; }
        public string GeoReferencia { get; set; }
    }
}