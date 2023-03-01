namespace TOVA_APP_ASOCIADOS.Models.Marcaciones
{
    public class GestionMarcasAll_Out
    {
        public int marcacion_ID { get; set; }
        public int usuario_ID { get; set; }
        public int tipoMarcacion { get; set; }
        public string descripcion { get; set; }
        public string coordenadas_GPS { get; set; }
        public DateTime fecha { get; set; }
    }
}
