﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApliciacionInventario.ProxyModelo {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ModeloBE", Namespace="http://schemas.datacontract.org/2004/07/WCF_Inventario")]
    [System.SerializableAttribute()]
    public partial class ModeloBE : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime Fec_RegistroField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime fec_ult_modificacionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private short idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string marcaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string modeloField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nom_equipoField;
        
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
        public string nom_equipo {
            get {
                return this.nom_equipoField;
            }
            set {
                if ((object.ReferenceEquals(this.nom_equipoField, value) != true)) {
                    this.nom_equipoField = value;
                    this.RaisePropertyChanged("nom_equipo");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ProxyModelo.IServiceModelo")]
    public interface IServiceModelo {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceModelo/ConsultarModelo", ReplyAction="http://tempuri.org/IServiceModelo/ConsultarModeloResponse")]
        ApliciacionInventario.ProxyModelo.ModeloBE ConsultarModelo(short id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceModelo/ConsultarModelo", ReplyAction="http://tempuri.org/IServiceModelo/ConsultarModeloResponse")]
        System.Threading.Tasks.Task<ApliciacionInventario.ProxyModelo.ModeloBE> ConsultarModeloAsync(short id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceModelo/ListarModelos", ReplyAction="http://tempuri.org/IServiceModelo/ListarModelosResponse")]
        ApliciacionInventario.ProxyModelo.ModeloBE[] ListarModelos();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceModelo/ListarModelos", ReplyAction="http://tempuri.org/IServiceModelo/ListarModelosResponse")]
        System.Threading.Tasks.Task<ApliciacionInventario.ProxyModelo.ModeloBE[]> ListarModelosAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceModelo/ListarModelos2", ReplyAction="http://tempuri.org/IServiceModelo/ListarModelos2Response")]
        ApliciacionInventario.ProxyModelo.ModeloBE[] ListarModelos2();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceModelo/ListarModelos2", ReplyAction="http://tempuri.org/IServiceModelo/ListarModelos2Response")]
        System.Threading.Tasks.Task<ApliciacionInventario.ProxyModelo.ModeloBE[]> ListarModelos2Async();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceModelo/InsertarModelo", ReplyAction="http://tempuri.org/IServiceModelo/InsertarModeloResponse")]
        bool InsertarModelo(ApliciacionInventario.ProxyModelo.ModeloBE objModeloBE);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceModelo/InsertarModelo", ReplyAction="http://tempuri.org/IServiceModelo/InsertarModeloResponse")]
        System.Threading.Tasks.Task<bool> InsertarModeloAsync(ApliciacionInventario.ProxyModelo.ModeloBE objModeloBE);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceModelo/ActualizarModelo", ReplyAction="http://tempuri.org/IServiceModelo/ActualizarModeloResponse")]
        bool ActualizarModelo(ApliciacionInventario.ProxyModelo.ModeloBE objModeloBE);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceModelo/ActualizarModelo", ReplyAction="http://tempuri.org/IServiceModelo/ActualizarModeloResponse")]
        System.Threading.Tasks.Task<bool> ActualizarModeloAsync(ApliciacionInventario.ProxyModelo.ModeloBE objModeloBE);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceModelo/EliminarModelo", ReplyAction="http://tempuri.org/IServiceModelo/EliminarModeloResponse")]
        bool EliminarModelo(short id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceModelo/EliminarModelo", ReplyAction="http://tempuri.org/IServiceModelo/EliminarModeloResponse")]
        System.Threading.Tasks.Task<bool> EliminarModeloAsync(short id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceModeloChannel : ApliciacionInventario.ProxyModelo.IServiceModelo, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceModeloClient : System.ServiceModel.ClientBase<ApliciacionInventario.ProxyModelo.IServiceModelo>, ApliciacionInventario.ProxyModelo.IServiceModelo {
        
        public ServiceModeloClient() {
        }
        
        public ServiceModeloClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceModeloClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceModeloClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceModeloClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ApliciacionInventario.ProxyModelo.ModeloBE ConsultarModelo(short id) {
            return base.Channel.ConsultarModelo(id);
        }
        
        public System.Threading.Tasks.Task<ApliciacionInventario.ProxyModelo.ModeloBE> ConsultarModeloAsync(short id) {
            return base.Channel.ConsultarModeloAsync(id);
        }
        
        public ApliciacionInventario.ProxyModelo.ModeloBE[] ListarModelos() {
            return base.Channel.ListarModelos();
        }
        
        public System.Threading.Tasks.Task<ApliciacionInventario.ProxyModelo.ModeloBE[]> ListarModelosAsync() {
            return base.Channel.ListarModelosAsync();
        }
        
        public ApliciacionInventario.ProxyModelo.ModeloBE[] ListarModelos2() {
            return base.Channel.ListarModelos2();
        }
        
        public System.Threading.Tasks.Task<ApliciacionInventario.ProxyModelo.ModeloBE[]> ListarModelos2Async() {
            return base.Channel.ListarModelos2Async();
        }
        
        public bool InsertarModelo(ApliciacionInventario.ProxyModelo.ModeloBE objModeloBE) {
            return base.Channel.InsertarModelo(objModeloBE);
        }
        
        public System.Threading.Tasks.Task<bool> InsertarModeloAsync(ApliciacionInventario.ProxyModelo.ModeloBE objModeloBE) {
            return base.Channel.InsertarModeloAsync(objModeloBE);
        }
        
        public bool ActualizarModelo(ApliciacionInventario.ProxyModelo.ModeloBE objModeloBE) {
            return base.Channel.ActualizarModelo(objModeloBE);
        }
        
        public System.Threading.Tasks.Task<bool> ActualizarModeloAsync(ApliciacionInventario.ProxyModelo.ModeloBE objModeloBE) {
            return base.Channel.ActualizarModeloAsync(objModeloBE);
        }
        
        public bool EliminarModelo(short id) {
            return base.Channel.EliminarModelo(id);
        }
        
        public System.Threading.Tasks.Task<bool> EliminarModeloAsync(short id) {
            return base.Channel.EliminarModeloAsync(id);
        }
    }
}
