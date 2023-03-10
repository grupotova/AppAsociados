namespace TOVA_APP_ASOCIADOS.Models.Auth
{
	public class LoginModel
	{
		public bool status { get; set; }
		public string? mensajeError { get; set; }
		public string? usuarioId { get; set; }
		public string? usuario { get; set; }
		public string? nombre { get; set; }
		public string? apellido { get; set; }
		public string? numeroAsociado { get; set; }
		public string? email { get; set; }
		public string? rol { get; set; }
		public string? rolId { get; set; }
		public string? rolCodigo { get; set; }
		public string? basesRelacionadas { get; set; }
		public string? vistasPermisos { get; set; }
	}
}
