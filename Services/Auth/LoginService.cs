using System.Text;
using System.Text.Json;
using TOVA_APP_ASOCIADOS.Helpers;
using TOVA_APP_ASOCIADOS.Models.Auth;

namespace TOVA_APP_ASOCIADOS.Services.Auth
{
    public class LoginService : ILoginService
	{
        public string ViewName = "AUTH - HTTP CLIENT";


        // INFO: Obtener los datos de accesos
        public async Task<LoginModel> GetLogin(string Usuario, string Contrasena)
        {
            var _client = new HttpClient();
            var _model = new LoginModel();
            string url = Constants.AuthRestUrl + "/login?Usuario=" + Usuario + "&Contrasena=" + Contrasena + "&AplicacionCodigo=" + Constants.GUCAplicacionCodigo;

            Utilidades.PrintLogStatic(ViewName, "Abriendo URL: " + url);
            try
            {
                _client.BaseAddress = new Uri(url);
                HttpResponseMessage response = await _client.GetAsync("");
                if (response.IsSuccessStatusCode)
                {
                    Utilidades.PrintLogStatic(ViewName, "httpCode: " + response.StatusCode);
                    string content = await response.Content.ReadAsStringAsync();
                    Utilidades.PrintLogStatic(ViewName, "httpResponse: " + content);
                    _model = JsonSerializer.Deserialize<LoginModel>(content);
                } else
                {
                    Utilidades.PrintLogStatic(ViewName, "httpCode: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Utilidades.PrintLogStatic(ViewName, "Error METHOD = GET, URL = " + url + ", MENSAJE = " + ex.Message);
            }

            return _model;
        }


		// INFO: Obtener los datos de accesos
		public async Task<LoginModel> PostLogin(Login_In _InModel)
		{
			var _client = new HttpClient();
			var _model = new LoginModel();
			string url = Constants.AuthRestUrl + "/login";

			Utilidades.PrintLogStatic(ViewName, "Abriendo URL: " + url);
			try
			{
				Uri uri = new Uri(url);
				string json = JsonSerializer.Serialize(_InModel);
				StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
				var requestMessage = new HttpRequestMessage(HttpMethod.Post, uri);
				requestMessage.Content = content;
				HttpResponseMessage response = await _client.SendAsync(requestMessage);
				if (response.IsSuccessStatusCode)
				{
					Utilidades.PrintLogStatic(ViewName, "httpCode: " + response.StatusCode);
					string contentResponse = await response.Content.ReadAsStringAsync();
					Utilidades.PrintLogStatic(ViewName, "httpResponse: " + contentResponse);
					_model = JsonSerializer.Deserialize<LoginModel>(contentResponse);
				}
				else
				{
					Utilidades.PrintLogStatic(ViewName, "httpCode: " + response.StatusCode);
					string contentResponse = await response.Content.ReadAsStringAsync();
					Utilidades.PrintLogStatic(ViewName, "httpResponse: " + contentResponse);
				}
			}
			catch (Exception ex)
			{
				Utilidades.PrintLogStatic(ViewName, "Error METHOD = POST, URL = " + url + ", MENSAJE = " + ex.Message);
			}

			return _model;
		}

	}
}
