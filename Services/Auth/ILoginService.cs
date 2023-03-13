using TOVA_APP_ASOCIADOS.Models.Auth;

namespace TOVA_APP_ASOCIADOS.Services.Auth
{
    interface ILoginService
    {
        Task<LoginModel> GetLogin(string Usuario, string Contrasena);
		Task<LoginModel> PostLogin(Login_In _ModelIn);
	}
}
