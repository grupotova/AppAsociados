﻿namespace TOVA_APP_ASOCIADOS
{
    public static class Constants
    {
        // WebService - Desarrollo 
        public static string HostUrl = "192.168.58.50:8006";
        // WebService - Produccion
        // public static string HostUrl = "192.168.10.213:8081";

        public static string APPNombre = "TOVA_APP_ASOCIADOS";
        public static string GUCApllicacionCodigo = "ACI";
        public static string Scheme = "http"; // https or http
        public static string RestUrl = $"{Scheme}://{HostUrl}/api/appconteos";
        public static string ProxyRestUrl = $"{Scheme}://{HostUrl}/api/proxy";
        public static string VPreciosRestUrl = $"{Scheme}://{HostUrl}/api/appvprecios";
        public static string ControlVersionRestUrl = $"{Scheme}://{HostUrl}/api/control_versiones";

    }
}
