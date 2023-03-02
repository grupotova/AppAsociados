namespace TOVA_APP_ASOCIADOS.Models.Marcaciones
{
    public class GestionMarcasAll_Out
    {
        public int marcacion_ID { get; set; }
        public int usuario_ID { get; set; }
        public int tipoMarcacion { get; set; }
        public string baseNombre { get; set; }
        public string coordenadas_GPS { get; set; }
        public DateTime fechaCompleta { get; set; }
    }
}
