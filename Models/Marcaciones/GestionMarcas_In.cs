using System.ComponentModel.DataAnnotations;

namespace TOVA_API.Models.AppAsociados.V1
{
    public class GestionMarcas_In
    {
        public string NumeroAsociado { get; set; }
        public int TipoMarcacion { get; set; }
        public string Base { get; set; }
        public string CoordenadasGPS { get; set; }
    }
}
