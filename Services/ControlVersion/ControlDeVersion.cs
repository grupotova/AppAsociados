using System.Text.Json;
using TOVA_APP_ASOCIADOS.Helpers;
using TOVA_APP_ASOCIADOS.Models.ControlVersion;

namespace TOVA_APP_ASOCIADOS.Services.ControlVersion
{
    public class ControlDeVersion : IControlDeVersion
    {
        public string ViewName = "CONTROL DE VERSION - HTTP CLIENT";


        // INFO: Obtener los parametros por codigo
        public async Task<VerificarVersion_Out> GetControlVersionAsync(string AppNombre, string VersionActual)
        {
            var _client = new HttpClient();
            var _model = new VerificarVersion_Out();
            string url = Constants.ControlVersionRestUrl + "/verificar?App="+ AppNombre + "&VersionActual=" + VersionActual;

            Utilidades.PrintLogStatic(ViewName, "Abriendo URL: " + url);
            try
            {
                _client.BaseAddress = new Uri(url);
                HttpResponseMessage response = await _client.GetAsync("");
                if (response.IsSuccessStatusCode)
                {
                    Utilidades.PrintLogStatic(ViewName, "httpCode: " + response.IsSuccessStatusCode.ToString());
                    string content = await response.Content.ReadAsStringAsync();
                    Utilidades.PrintLogStatic(ViewName, "httpResponse: " + content);
                    _model = JsonSerializer.Deserialize<VerificarVersion_Out>(content);
                } else
                {
                    Utilidades.PrintLogStatic(ViewName, "httpCode: " + response.StatusCode.ToString());
                }
            }
            catch (Exception ex)
            {
                Utilidades.PrintLogStatic(ViewName, "Error METHOD = GET, URL = " + url + ", MENSAJE = " + ex.Message);
            }

            return _model;
        }

    }
}
