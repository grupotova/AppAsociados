using System.Text;
using System.Text.Json;
using TOVA_API.Models.AppAsociados.V1;
using TOVA_APP_ASOCIADOS.Helpers;
using TOVA_APP_ASOCIADOS.Models.Marcaciones;

namespace TOVA_APP_ASOCIADOS.Services.Marcaciones
{
    public class GestionMarcas : IGestionMarcas
    {
        public string ViewName = "GESTION DE MARCAS - HTTP CLIENT";

        // INFO: Obtener las bases georreferenciadas
        public async Task<(int StatusCode, List<BasesAll_Out>)> GetBasesAllAsync()
        {
			int _StatusCode = 0;
			var _client = new HttpClient();
            var _model = new List<BasesAll_Out>();
            string url = Constants.AsociadosRestUrl + "/v1/bases";

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
                    _model = JsonSerializer.Deserialize<List<BasesAll_Out>>(content);
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



        // INFO: Obtener las marcaciones por Usuario Id
        public async Task<(int StatusCode, List<GestionMarcasAll_Out>)> GetMarcacionesAllAsync(int UsuarioId)
        {
			int _StatusCode = 0;
			var _client = new HttpClient();
            var _model = new List<GestionMarcasAll_Out>();
            string url = Constants.AsociadosRestUrl + "/v1/gestion_marcas?UsuarioId=" + UsuarioId;

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
                    _model = JsonSerializer.Deserialize<List<GestionMarcasAll_Out>>(content);
                }
                else
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



        // INFO: Insertar nueva marcacion
        public async Task<(int StatusCpde, GestionMarcas_Out)> PostMarcacionesAsync(GestionMarcas_In _InModel)
        {
			int _StatusCode = 0;
			var _client = new HttpClient();
            var _model = new GestionMarcas_Out();
            string url = Constants.AsociadosRestUrl + "/v1/gestion_marcas";
            Utilidades.PrintLogStatic(ViewName, "Abriendo URL: " + url);

            try
            {
                // TOVA Key
                _client.DefaultRequestHeaders.Add("TOVA-Key", Constants.TovaKey);

                Uri uri = new Uri(url);
                string json = JsonSerializer.Serialize(_InModel);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, uri);
                requestMessage.Content = content;
                HttpResponseMessage response = await _client.SendAsync(requestMessage);

				// Status Code 
				_StatusCode = (int)response.StatusCode;
				Utilidades.PrintLogStatic(ViewName, "Status Code: " + _StatusCode);

				if (response.IsSuccessStatusCode)
                {
                    Utilidades.PrintLogStatic(ViewName, "httpCode: " + response.StatusCode);
                    string contentResponse = await response.Content.ReadAsStringAsync();
                    Utilidades.PrintLogStatic(ViewName, "httpResponse: " + contentResponse);
                    _model = JsonSerializer.Deserialize<GestionMarcas_Out>(contentResponse);
                }
                else
                {
                    Utilidades.PrintLogStatic(ViewName, "httpCode: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
				_StatusCode = 0;
				Utilidades.PrintLogStatic(ViewName, "Error METHOD = POST, URL = " + url + ", MENSAJE = " + ex.Message);
            }

			return (_StatusCode, _model);
		}

    }
}
