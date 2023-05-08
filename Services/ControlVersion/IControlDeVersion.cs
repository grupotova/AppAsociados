using TOVA_APP_ASOCIADOS.Models.ControlVersion;

namespace TOVA_APP_ASOCIADOS.Services.ControlVersion
{
    interface IControlDeVersion
    {
        Task<(int StatusCode, VerificarVersion_Out)> GetControlVersionAsync(string AppNombre, string VersionActual);
    }
}
