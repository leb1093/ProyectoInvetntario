﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApliciacionInventario.ProxyAto {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AtoBE", Namespace="http://schemas.datacontract.org/2004/07/WCF_Inventario")]
    [System.SerializableAttribute()]
    public partial class AtoBE : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime Fec_RegistroField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private short activoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string areaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private short equipoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string estadoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime fec_ult_modificacionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private short idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string imagenField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string marcaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string modeloField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nom_activoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string obsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private short pisoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string tipoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string usu_registroField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string usu_ult_modificacionField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Fec_Registro {
            get {
                return this.Fec_RegistroField;
            }
            set {
                if ((this.Fec_RegistroField.Equals(value) != true)) {
                    this.Fec_RegistroField = value;
                    this.RaisePropertyChanged("Fec_Registro");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public short activo {
            get {
                return this.activoField;
            }
            set {
                if ((this.activoField.Equals(value) != true)) {
                    this.activoField = value;
                    this.RaisePropertyChanged("activo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string area {
            get {
                return this.areaField;
            }
            set {
                if ((object.ReferenceEquals(this.areaField, value) != true)) {
                    this.areaField = value;
                    this.RaisePropertyChanged("area");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public short equipo {
            get {
                return this.equipoField;
            }
            set {
                if ((this.equipoField.Equals(value) != true)) {
                    this.equipoField = value;
                    this.RaisePropertyChanged("equipo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string estado {
            get {
                return this.estadoField;
            }
            set {
                if ((object.ReferenceEquals(this.estadoField, value) != true)) {
                    this.estadoField = value;
                    this.RaisePropertyChanged("estado");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime fec_ult_modificacion {
            get {
                return this.fec_ult_modificacionField;
            }
            set {
                if ((this.fec_ult_modificacionField.Equals(value) != true)) {
                    this.fec_ult_modificacionField = value;
                    this.RaisePropertyChanged("fec_ult_modificacion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public short id {
            get {
                return this.idField;
            }
            set {
                if ((this.idField.Equals(value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string imagen {
            get {
                return this.imagenField;
            }
            set {
                if ((object.ReferenceEquals(this.imagenField, value) != true)) {
                    this.imagenField = value;
                    this.RaisePropertyChanged("imagen");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string marca {
            get {
                return this.marcaField;
            }
            set {
                if ((object.ReferenceEquals(this.marcaField, value) != true)) {
                    this.marcaField = value;
                    this.RaisePropertyChanged("marca");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string modelo {
            get {
                return this.modeloField;
            }
            set {
                if ((object.ReferenceEquals(this.modeloField, value) != true)) {
                    this.modeloField = value;
                    this.RaisePropertyChanged("modelo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string nom_activo {
            get {
                return this.nom_activoField;
            }
            set {
                if ((object.ReferenceEquals(this.nom_activoField, value) != true)) {
                    this.nom_activoField = value;
                    this.RaisePropertyChanged("nom_activo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string obs {
            get {
                return this.obsField;
            }
            set {
                if ((object.ReferenceEquals(this.obsField, value) != true)) {
                    this.obsField = value;
                    this.RaisePropertyChanged("obs");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public short piso {
            get {
                return this.pisoField;
            }
            set {
                if ((this.pisoField.Equals(value) != true)) {
                    this.pisoField = value;
                    this.RaisePropertyChanged("piso");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string tipo {
            get {
                return this.tipoField;
            }
            set {
                if ((object.ReferenceEquals(this.tipoField, value) != true)) {
                    this.tipoField = value;
                    this.RaisePropertyChanged("tipo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string usu_registro {
            get {
                return this.usu_registroField;
            }
            set {
                if ((object.ReferenceEquals(this.usu_registroField, value) != true)) {
                    this.usu_registroField = value;
                    this.RaisePropertyChanged("usu_registro");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string usu_ult_modificacion {
            get {
                return this.usu_ult_modificacionField;
            }
            set {
                if ((object.ReferenceEquals(this.usu_ult_modificacionField, value) != true)) {
                    this.usu_ult_modificacionField = value;
                    this.RaisePropertyChanged("usu_ult_modificacion");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ProxyAto.IServiceAto")]
    public interface IServiceAto {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceAto/ConsultarAto", ReplyAction="http://tempuri.org/IServiceAto/ConsultarAtoResponse")]
        ApliciacionInventario.ProxyAto.AtoBE ConsultarAto(short id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceAto/ConsultarAto", ReplyAction="http://tempuri.org/IServiceAto/ConsultarAtoResponse")]
        System.Threading.Tasks.Task<ApliciacionInventario.ProxyAto.AtoBE> ConsultarAtoAsync(short id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceAto/ConsultarAto2", ReplyAction="http://tempuri.org/IServiceAto/ConsultarAto2Response")]
        ApliciacionInventario.ProxyAto.AtoBE ConsultarAto2(short id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceAto/ConsultarAto2", ReplyAction="http://tempuri.org/IServiceAto/ConsultarAto2Response")]
        System.Threading.Tasks.Task<ApliciacionInventario.ProxyAto.AtoBE> ConsultarAto2Async(short id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceAto/ListarAto", ReplyAction="http://tempuri.org/IServiceAto/ListarAtoResponse")]
        ApliciacionInventario.ProxyAto.AtoBE[] ListarAto();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceAto/ListarAto", ReplyAction="http://tempuri.org/IServiceAto/ListarAtoResponse")]
        System.Threading.Tasks.Task<ApliciacionInventario.ProxyAto.AtoBE[]> ListarAtoAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceAto/ListarAto2", ReplyAction="http://tempuri.org/IServiceAto/ListarAto2Response")]
        ApliciacionInventario.ProxyAto.AtoBE[] ListarAto2();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceAto/ListarAto2", ReplyAction="http://tempuri.org/IServiceAto/ListarAto2Response")]
        System.Threading.Tasks.Task<ApliciacionInventario.ProxyAto.AtoBE[]> ListarAto2Async();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceAto/InsertarAto", ReplyAction="http://tempuri.org/IServiceAto/InsertarAtoResponse")]
        bool InsertarAto(ApliciacionInventario.ProxyAto.AtoBE objAtoBE);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceAto/InsertarAto", ReplyAction="http://tempuri.org/IServiceAto/InsertarAtoResponse")]
        System.Threading.Tasks.Task<bool> InsertarAtoAsync(ApliciacionInventario.ProxyAto.AtoBE objAtoBE);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceAto/ActualizarAto", ReplyAction="http://tempuri.org/IServiceAto/ActualizarAtoResponse")]
        bool ActualizarAto(ApliciacionInventario.ProxyAto.AtoBE objAtoBE);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceAto/ActualizarAto", ReplyAction="http://tempuri.org/IServiceAto/ActualizarAtoResponse")]
        System.Threading.Tasks.Task<bool> ActualizarAtoAsync(ApliciacionInventario.ProxyAto.AtoBE objAtoBE);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceAto/EliminarAto", ReplyAction="http://tempuri.org/IServiceAto/EliminarAtoResponse")]
        bool EliminarAto(short id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceAto/EliminarAto", ReplyAction="http://tempuri.org/IServiceAto/EliminarAtoResponse")]
        System.Threading.Tasks.Task<bool> EliminarAtoAsync(short id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceAtoChannel : ApliciacionInventario.ProxyAto.IServiceAto, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceAtoClient : System.ServiceModel.ClientBase<ApliciacionInventario.ProxyAto.IServiceAto>, ApliciacionInventario.ProxyAto.IServiceAto {
        
        public ServiceAtoClient() {
        }
        
        public ServiceAtoClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceAtoClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceAtoClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceAtoClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ApliciacionInventario.ProxyAto.AtoBE ConsultarAto(short id) {
            return base.Channel.ConsultarAto(id);
        }
        
        public System.Threading.Tasks.Task<ApliciacionInventario.ProxyAto.AtoBE> ConsultarAtoAsync(short id) {
            return base.Channel.ConsultarAtoAsync(id);
        }
        
        public ApliciacionInventario.ProxyAto.AtoBE ConsultarAto2(short id) {
            return base.Channel.ConsultarAto2(id);
        }
        
        public System.Threading.Tasks.Task<ApliciacionInventario.ProxyAto.AtoBE> ConsultarAto2Async(short id) {
            return base.Channel.ConsultarAto2Async(id);
        }
        
        public ApliciacionInventario.ProxyAto.AtoBE[] ListarAto() {
            return base.Channel.ListarAto();
        }
        
        public System.Threading.Tasks.Task<ApliciacionInventario.ProxyAto.AtoBE[]> ListarAtoAsync() {
            return base.Channel.ListarAtoAsync();
        }
        
        public ApliciacionInventario.ProxyAto.AtoBE[] ListarAto2() {
            return base.Channel.ListarAto2();
        }
        
        public System.Threading.Tasks.Task<ApliciacionInventario.ProxyAto.AtoBE[]> ListarAto2Async() {
            return base.Channel.ListarAto2Async();
        }
        
        public bool InsertarAto(ApliciacionInventario.ProxyAto.AtoBE objAtoBE) {
            return base.Channel.InsertarAto(objAtoBE);
        }
        
        public System.Threading.Tasks.Task<bool> InsertarAtoAsync(ApliciacionInventario.ProxyAto.AtoBE objAtoBE) {
            return base.Channel.InsertarAtoAsync(objAtoBE);
        }
        
        public bool ActualizarAto(ApliciacionInventario.ProxyAto.AtoBE objAtoBE) {
            return base.Channel.ActualizarAto(objAtoBE);
        }
        
        public System.Threading.Tasks.Task<bool> ActualizarAtoAsync(ApliciacionInventario.ProxyAto.AtoBE objAtoBE) {
            return base.Channel.ActualizarAtoAsync(objAtoBE);
        }
        
        public bool EliminarAto(short id) {
            return base.Channel.EliminarAto(id);
        }
        
        public System.Threading.Tasks.Task<bool> EliminarAtoAsync(short id) {
            return base.Channel.EliminarAtoAsync(id);
        }
    }
}