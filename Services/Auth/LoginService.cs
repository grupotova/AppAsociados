using System.Text;
using System.Text.Json;
using TOVA_APP_ASOCIADOS.Helpers;
using TOVA_APP_ASOCIADOS.Models.Auth;

namespace TOVA_APP_ASOCIADOS.Services.Auth
{
    public class LoginService : ILoginService
	{
        public string ViewName = "AUTH - HTTP CLIENT";


		// INFO: POST - Obtener los datos de accesos
		public async Task<(int StatusCode, LoginModel)> PostLogin(Login_In _InModel)
		{
			int _StatusCode = 0;
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

				// Status Code 
				_StatusCode = (int)response.StatusCode;
				Utilidades.PrintLogStatic(ViewName, "Status Code: " + _StatusCode);

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
				_StatusCode = 0;
				Utilidades.PrintLogStatic(ViewName, "Error METHOD = POST, URL = " + url + ", MENSAJE = " + ex.Message);
			}

			return (_StatusCode, _model);
		}

	}
}
