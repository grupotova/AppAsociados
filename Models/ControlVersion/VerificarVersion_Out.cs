namespace TOVA_APP_ASOCIADOS.Models.ControlVersion
{
    public class VerificarVersion_Out
    {
        public string app { get; set; }
        public string versionActual { get; set; }
        public string ultimaVersion { get; set; }
        public bool status { get; set; }
        public string androidUrlDownload { get; set; }
        public bool appExiste { get; set; }

    }
}
