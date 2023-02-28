using System.Diagnostics;

namespace TOVA_APP_ASOCIADOS.Helpers
{
    public class Utilidades
    {
        private static string ViewName = "UTILIDADES";

        public bool VerificarConexion()
        {
            bool resultadoConexion = false;
            NetworkAccess accessType = Connectivity.Current.NetworkAccess;

            if (accessType == NetworkAccess.Internet)
            {
                resultadoConexion = true;
            }

            return resultadoConexion;
        }

        // PrintLog
        public void PrintLog(string titulo, string mensaje)
        {
            Debug.WriteLine(titulo + " | " + mensaje);
        }

        // PrintLog Static
        public static void PrintLogStatic(string titulo, string mensaje)
        {
            Debug.WriteLine(titulo + " | " + mensaje);
        }
    }
}
