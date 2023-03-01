using TOVA_APP_ASOCIADOS.Models.Marcaciones;

namespace TOVA_APP_ASOCIADOS.Services.Marcaciones
{
    interface IGestionMarcas
    {
        Task<List<BasesAll_Out>> GetBasesAllAsync();

        Task<List<GestionMarcasAll_Out>> GetMarcacionesAllAsync(int UsuarioId);
    }
}
