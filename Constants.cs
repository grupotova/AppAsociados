namespace TOVA_APP_ASOCIADOS
{
    public static class Constants
    {
        // WebService - Desarrollo 
        public static string HostUrl = "192.168.58.50:8006";
        // WebService - Produccion
        // public static string HostUrl = "192.168.10.213:8081";

        public static string VersionAppLetra = HostUrl == "192.168.10.213:8081" ? "P" : "D";
        public static string VersionApp = "v" + VersionTracking.CurrentVersion + VersionAppLetra;
        public static string APPNombre = "TOVA_APP_ASOCIADOS";
        public static string GUCAplicacionCodigo = "AMA";
        public static string Scheme = "http"; // https or http
        public static string RestUrl = $"{Scheme}://{HostUrl}/api/appconteos";
        public static string ProxyRestUrl = $"{Scheme}://{HostUrl}/api/proxy";
        public static string VPreciosRestUrl = $"{Scheme}://{HostUrl}/api/appvprecios";
        public static string ControlVersionRestUrl = $"{Scheme}://{HostUrl}/api/control_versiones";
        public static string AsociadosRestUrl = $"{Scheme}://{HostUrl}/api/appasociados";
        public static string AuthRestUrl = $"{Scheme}://{HostUrl}/api/auth";

		// TOVA Key
		public static string TovaKey = "TOVA-f1950ed3f1dc96ffed6c6efb5a8a6e315113959a";

		// Firebase RealtimeDatabase
		public static string FirebaseUrl = "https://tova-5daf5-default-rtdb.firebaseio.com/";
        public static string FirebaseAuthKey = "hOvrSzPdSRQFJK2GuPUs0ifMSgRnNriZnUyf0dk6";

    }
}
