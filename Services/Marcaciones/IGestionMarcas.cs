using TOVA_API.Models.AppAsociados.V1;
using TOVA_APP_ASOCIADOS.Models.Marcaciones;

namespace TOVA_APP_ASOCIADOS.Services.Marcaciones
{
    interface IGestionMarcas
    {
        Task<(int StatusCode, List<BasesAll_Out>)> GetBasesAllAsync();

        Task<(int StatusCode, List<GestionMarcasAll_Out>)> GetMarcacionesAllAsync(int UsuarioId);

        Task<(int StatusCode, GestionMarcas_Out)> PostMarcacionesAsync(GestionMarcas_In _model_In);
    }
}
