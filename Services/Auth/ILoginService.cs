using TOVA_APP_ASOCIADOS.Models.Auth;

namespace TOVA_APP_ASOCIADOS.Services.Auth
{
    interface ILoginService
    {
		Task<(int StatusCode, LoginModel)> PostLogin(Login_In _ModelIn);
	}
}
