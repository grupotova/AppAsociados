﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceGUCDev
{
    using System.Runtime.Serialization;


    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "UserData", Namespace = "http://schemas.datacontract.org/2004/07/SecurityService")]
    public partial class UserData : object
    {

        private ServiceGUCDev.Application[] ApplicationsField;

        private bool AuthenticatedField;

        private ServiceGUCDev.ApplicationCentroCosto[] CentrosCostosField;

        private string ForeNameField;

        private string LastNameField;

        private ServiceGUCDev.ApplicationMenu[] MenusField;

        private string MessageField;

        private string UserIDField;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceGUCDev.Application[] Applications
        {
            get
            {
                return this.ApplicationsField;
            }
            set
            {
                this.ApplicationsField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Authenticated
        {
            get
            {
                return this.AuthenticatedField;
            }
            set
            {
                this.AuthenticatedField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceGUCDev.ApplicationCentroCosto[] CentrosCostos
        {
            get
            {
                return this.CentrosCostosField;
            }
            set
            {
                this.CentrosCostosField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ForeName
        {
            get
            {
                return this.ForeNameField;
            }
            set
            {
                this.ForeNameField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LastName
        {
            get
            {
                return this.LastNameField;
            }
            set
            {
                this.LastNameField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceGUCDev.ApplicationMenu[] Menus
        {
            get
            {
                return this.MenusField;
            }
            set
            {
                this.MenusField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message
        {
            get
            {
                return this.MessageField;
            }
            set
            {
                this.MessageField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserID
        {
            get
            {
                return this.UserIDField;
            }
            set
            {
                this.UserIDField = value;
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "Application", Namespace = "http://schemas.datacontract.org/2004/07/SecurityService")]
    public partial class Application : object
    {

        private string ApellidoField;

        private string App_DescripcionField;

        private int App_IDField;

        private string App_NameField;

        private string CargoField;

        private int Cargo_IDField;

        private string Cargo_JefeField;

        private string EmailField;

        private string ID_RoleField;

        private string MenuField;

        private string NombreField;

        private string NumAsociadoField;

        private string RolCodigoField;

        private string Role_NameField;

        private int Usuario_IDField;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Apellido
        {
            get
            {
                return this.ApellidoField;
            }
            set
            {
                this.ApellidoField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string App_Descripcion
        {
            get
            {
                return this.App_DescripcionField;
            }
            set
            {
                this.App_DescripcionField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int App_ID
        {
            get
            {
                return this.App_IDField;
            }
            set
            {
                this.App_IDField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string App_Name
        {
            get
            {
                return this.App_NameField;
            }
            set
            {
                this.App_NameField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Cargo
        {
            get
            {
                return this.CargoField;
            }
            set
            {
                this.CargoField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Cargo_ID
        {
            get
            {
                return this.Cargo_IDField;
            }
            set
            {
                this.Cargo_IDField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Cargo_Jefe
        {
            get
            {
                return this.Cargo_JefeField;
            }
            set
            {
                this.Cargo_JefeField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email
        {
            get
            {
                return this.EmailField;
            }
            set
            {
                this.EmailField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ID_Role
        {
            get
            {
                return this.ID_RoleField;
            }
            set
            {
                this.ID_RoleField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Menu
        {
            get
            {
                return this.MenuField;
            }
            set
            {
                this.MenuField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nombre
        {
            get
            {
                return this.NombreField;
            }
            set
            {
                this.NombreField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NumAsociado
        {
            get
            {
                return this.NumAsociadoField;
            }
            set
            {
                this.NumAsociadoField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string RolCodigo
        {
            get
            {
                return this.RolCodigoField;
            }
            set
            {
                this.RolCodigoField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Role_Name
        {
            get
            {
                return this.Role_NameField;
            }
            set
            {
                this.Role_NameField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Usuario_ID
        {
            get
            {
                return this.Usuario_IDField;
            }
            set
            {
                this.Usuario_IDField = value;
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "ApplicationCentroCosto", Namespace = "http://schemas.datacontract.org/2004/07/SecurityService")]
    public partial class ApplicationCentroCosto : object
    {

        private int ActivoField;

        private string AliasCentroField;

        private int BaseField;

        private int CentroCosto_IDField;

        private string CodigoField;

        private int NivelField;

        private string NombreField;

        private int OrdenField;

        private string PadreField;

        private int ReembolsoField;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Activo
        {
            get
            {
                return this.ActivoField;
            }
            set
            {
                this.ActivoField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AliasCentro
        {
            get
            {
                return this.AliasCentroField;
            }
            set
            {
                this.AliasCentroField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Base
        {
            get
            {
                return this.BaseField;
            }
            set
            {
                this.BaseField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CentroCosto_ID
        {
            get
            {
                return this.CentroCosto_IDField;
            }
            set
            {
                this.CentroCosto_IDField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Codigo
        {
            get
            {
                return this.CodigoField;
            }
            set
            {
                this.CodigoField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Nivel
        {
            get
            {
                return this.NivelField;
            }
            set
            {
                this.NivelField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nombre
        {
            get
            {
                return this.NombreField;
            }
            set
            {
                this.NombreField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Orden
        {
            get
            {
                return this.OrdenField;
            }
            set
            {
                this.OrdenField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Padre
        {
            get
            {
                return this.PadreField;
            }
            set
            {
                this.PadreField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Reembolso
        {
            get
            {
                return this.ReembolsoField;
            }
            set
            {
                this.ReembolsoField = value;
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "ApplicationMenu", Namespace = "http://schemas.datacontract.org/2004/07/SecurityService")]
    public partial class ApplicationMenu : object
    {

        private string ControladorField;

        private int Menu_IDField;

        private string NombreField;

        private int PadreField;

        private int PosicionField;

        private string VistaField;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Controlador
        {
            get
            {
                return this.ControladorField;
            }
            set
            {
                this.ControladorField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Menu_ID
        {
            get
            {
                return this.Menu_IDField;
            }
            set
            {
                this.Menu_IDField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nombre
        {
            get
            {
                return this.NombreField;
            }
            set
            {
                this.NombreField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Padre
        {
            get
            {
                return this.PadreField;
            }
            set
            {
                this.PadreField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Posicion
        {
            get
            {
                return this.PosicionField;
            }
            set
            {
                this.PosicionField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Vista
        {
            get
            {
                return this.VistaField;
            }
            set
            {
                this.VistaField = value;
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "CentroCostosData", Namespace = "http://schemas.datacontract.org/2004/07/SecurityService")]
    public partial class CentroCostosData : object
    {

        private ServiceGUCDev.ApplicationCentroCosto[] CentrosCostosField;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceGUCDev.ApplicationCentroCosto[] CentrosCostos
        {
            get
            {
                return this.CentrosCostosField;
            }
            set
            {
                this.CentrosCostosField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName = "ServiceGUC.IService")]
    public interface IService
    {

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IService/Authenticate", ReplyAction = "http://tempuri.org/IService/AuthenticateResponse")]
        ServiceGUCDev.UserData Authenticate(string username, string password, string codAplicacion);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IService/Authenticate", ReplyAction = "http://tempuri.org/IService/AuthenticateResponse")]
        System.Threading.Tasks.Task<ServiceGUCDev.UserData> AuthenticateAsync(string username, string password, string codAplicacion);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IService/AccesoModulo", ReplyAction = "http://tempuri.org/IService/AccesoModuloResponse")]
        bool AccesoModulo(int AplicacionID, string Controlador, string Vista, string Roles);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IService/AccesoModulo", ReplyAction = "http://tempuri.org/IService/AccesoModuloResponse")]
        System.Threading.Tasks.Task<bool> AccesoModuloAsync(int AplicacionID, string Controlador, string Vista, string Roles);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IService/GetMenuCompletoSB", ReplyAction = "http://tempuri.org/IService/GetMenuCompletoSBResponse")]
        ServiceGUCDev.UserData GetMenuCompletoSB(int aplicacionID, string roles, string ruta);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IService/GetMenuCompletoSB", ReplyAction = "http://tempuri.org/IService/GetMenuCompletoSBResponse")]
        System.Threading.Tasks.Task<ServiceGUCDev.UserData> GetMenuCompletoSBAsync(int aplicacionID, string roles, string ruta);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IService/GetMenuCompletoSUM", ReplyAction = "http://tempuri.org/IService/GetMenuCompletoSUMResponse")]
        ServiceGUCDev.UserData GetMenuCompletoSUM(int aplicacionID, string roles, string ruta);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IService/GetMenuCompletoSUM", ReplyAction = "http://tempuri.org/IService/GetMenuCompletoSUMResponse")]
        System.Threading.Tasks.Task<ServiceGUCDev.UserData> GetMenuCompletoSUMAsync(int aplicacionID, string roles, string ruta);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IService/GetCentroCostoUsuario", ReplyAction = "http://tempuri.org/IService/GetCentroCostoUsuarioResponse")]
        ServiceGUCDev.CentroCostosData GetCentroCostoUsuario(int UsuarioID, int CajaMenuda, int Base);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IService/GetCentroCostoUsuario", ReplyAction = "http://tempuri.org/IService/GetCentroCostoUsuarioResponse")]
        System.Threading.Tasks.Task<ServiceGUCDev.CentroCostosData> GetCentroCostoUsuarioAsync(int UsuarioID, int CajaMenuda, int Base);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IService/GetCentrosCosto", ReplyAction = "http://tempuri.org/IService/GetCentrosCostoResponse")]
        ServiceGUCDev.CentroCostosData GetCentrosCosto(int CajaMenuda, int Base, int Todos);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IService/GetCentrosCosto", ReplyAction = "http://tempuri.org/IService/GetCentrosCostoResponse")]
        System.Threading.Tasks.Task<ServiceGUCDev.CentroCostosData> GetCentrosCostoAsync(int CajaMenuda, int Base, int Todos);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IService/GetMenus", ReplyAction = "http://tempuri.org/IService/GetMenusResponse")]
        ServiceGUCDev.ApplicationMenu[] GetMenus(string aplicacionID, string rolesID);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IService/GetMenus", ReplyAction = "http://tempuri.org/IService/GetMenusResponse")]
        System.Threading.Tasks.Task<ServiceGUCDev.ApplicationMenu[]> GetMenusAsync(string aplicacionID, string rolesID);
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public interface IServiceChannel : ServiceGUCDev.IService, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<ServiceGUCDev.IService>, ServiceGUCDev.IService
    {

        /// <summary>
        /// Implemente este método parcial para configurar el punto de conexión de servicio.
        /// </summary>
        /// <param name="serviceEndpoint">El punto de conexión para configurar</param>
        /// <param name="clientCredentials">Credenciales de cliente</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);

        public ServiceClient() :
                base(ServiceClient.GetDefaultBinding(), ServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }

        public ServiceClient(EndpointConfiguration endpointConfiguration) :
                base(ServiceClient.GetBindingForEndpoint(endpointConfiguration), ServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }

        public ServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) :
                base(ServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }

        public ServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) :
                base(ServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }

        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
        }

        public ServiceGUCDev.UserData Authenticate(string username, string password, string codAplicacion)
        {
            return base.Channel.Authenticate(username, password, codAplicacion);
        }

        public System.Threading.Tasks.Task<ServiceGUCDev.UserData> AuthenticateAsync(string username, string password, string codAplicacion)
        {
            return base.Channel.AuthenticateAsync(username, password, codAplicacion);
        }

        public bool AccesoModulo(int AplicacionID, string Controlador, string Vista, string Roles)
        {
            return base.Channel.AccesoModulo(AplicacionID, Controlador, Vista, Roles);
        }

        public System.Threading.Tasks.Task<bool> AccesoModuloAsync(int AplicacionID, string Controlador, string Vista, string Roles)
        {
            return base.Channel.AccesoModuloAsync(AplicacionID, Controlador, Vista, Roles);
        }

        public ServiceGUCDev.UserData GetMenuCompletoSB(int aplicacionID, string roles, string ruta)
        {
            return base.Channel.GetMenuCompletoSB(aplicacionID, roles, ruta);
        }

        public System.Threading.Tasks.Task<ServiceGUCDev.UserData> GetMenuCompletoSBAsync(int aplicacionID, string roles, string ruta)
        {
            return base.Channel.GetMenuCompletoSBAsync(aplicacionID, roles, ruta);
        }

        public ServiceGUCDev.UserData GetMenuCompletoSUM(int aplicacionID, string roles, string ruta)
        {
            return base.Channel.GetMenuCompletoSUM(aplicacionID, roles, ruta);
        }

        public System.Threading.Tasks.Task<ServiceGUCDev.UserData> GetMenuCompletoSUMAsync(int aplicacionID, string roles, string ruta)
        {
            return base.Channel.GetMenuCompletoSUMAsync(aplicacionID, roles, ruta);
        }

        public ServiceGUCDev.CentroCostosData GetCentroCostoUsuario(int UsuarioID, int CajaMenuda, int Base)
        {
            return base.Channel.GetCentroCostoUsuario(UsuarioID, CajaMenuda, Base);
        }

        public System.Threading.Tasks.Task<ServiceGUCDev.CentroCostosData> GetCentroCostoUsuarioAsync(int UsuarioID, int CajaMenuda, int Base)
        {
            return base.Channel.GetCentroCostoUsuarioAsync(UsuarioID, CajaMenuda, Base);
        }

        public ServiceGUCDev.CentroCostosData GetCentrosCosto(int CajaMenuda, int Base, int Todos)
        {
            return base.Channel.GetCentrosCosto(CajaMenuda, Base, Todos);
        }

        public System.Threading.Tasks.Task<ServiceGUCDev.CentroCostosData> GetCentrosCostoAsync(int CajaMenuda, int Base, int Todos)
        {
            return base.Channel.GetCentrosCostoAsync(CajaMenuda, Base, Todos);
        }

        public ServiceGUCDev.ApplicationMenu[] GetMenus(string aplicacionID, string rolesID)
        {
            return base.Channel.GetMenus(aplicacionID, rolesID);
        }

        public System.Threading.Tasks.Task<ServiceGUCDev.ApplicationMenu[]> GetMenusAsync(string aplicacionID, string rolesID)
        {
            return base.Channel.GetMenusAsync(aplicacionID, rolesID);
        }

        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }

        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IService))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }

        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IService))
            {
                return new System.ServiceModel.EndpointAddress("http://tovawebapp01dev.grupotova.local/ss/Main.svc");
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }

        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return ServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IService);
        }

        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return ServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IService);
        }

        public enum EndpointConfiguration
        {

            BasicHttpBinding_IService,
        }
    }
}