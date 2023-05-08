using System.Text.Json;
using TOVA_APP_ASOCIADOS.Helpers;
using TOVA_APP_ASOCIADOS.Models.ControlVersion;

namespace TOVA_APP_ASOCIADOS.Services.ControlVersion
{
    public class ControlDeVersion : IControlDeVersion
    {
        public string ViewName = "CONTROL DE VERSION - HTTP CLIENT";


        // INFO: Obtener los parametros por codigo
        public async Task<(int StatusCode, VerificarVersion_Out)> GetControlVersionAsync(string AppNombre, string VersionActual)
        {
			int _StatusCode = 0;
			var _client = new HttpClient();
            var _model = new VerificarVersion_Out();
            string url = Constants.ControlVersionRestUrl + "/verificar?App="+ AppNombre + "&VersionActual=" + VersionActual;

            Utilidades.PrintLogStatic(ViewName, "Abriendo URL: " + url);
            try
            {
                _client.BaseAddress = new Uri(url);
                HttpResponseMessage response = await _client.GetAsync("");

				// Status Code 
				_StatusCode = (int)response.StatusCode;
				Utilidades.PrintLogStatic(ViewName, "Status Code: " + _StatusCode);

				if (response.IsSuccessStatusCode)
                {
                    Utilidades.PrintLogStatic(ViewName, "httpCode: " + response.StatusCode);
                    string content = await response.Content.ReadAsStringAsync();
                    Utilidades.PrintLogStatic(ViewName, "httpResponse: " + content);
                    _model = JsonSerializer.Deserialize<VerificarVersion_Out>(content);
                } else
                {
                    Utilidades.PrintLogStatic(ViewName, "httpCode: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
				_StatusCode = 0;
				Utilidades.PrintLogStatic(ViewName, "Error METHOD = GET, URL = " + url + ", MENSAJE = " + ex.Message);
            }

			return (_StatusCode, _model);
		}

    }
}
