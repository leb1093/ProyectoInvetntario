using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Inventario
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceUsuario" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceUsuario
    {
        [OperationContract]
        Boolean InsertarUsuario(UsuarioBE objUsuarioBE);

        [OperationContract]
        Boolean ActualizarUsuario(UsuarioBE objUsuarioBE);

        [OperationContract]
        Boolean EliminarUsuario(String login_usuario);

        [OperationContract]
        UsuarioBE ConsultarUsuario(String login_usuario);
    }

    [DataContract]
    [Serializable]
    public class UsuarioBE
    {
        private String mvarlogin_usuario;
        private String mvarpass_usuario;
        private Int16 mvarniv_usuario;
        private Int16 mvarest_usuario;
        private String mvarusu_registro;
        private DateTime mvarfec_registro;


        [DataMember]
        public String login_usuario
        {
            get { return mvarlogin_usuario; }
            set { mvarlogin_usuario = value; }
        }

        [DataMember]
        public String pass_usuario
        {
            get { return mvarpass_usuario; }
            set { mvarpass_usuario = value; }
        }

        [DataMember]
        public Int16 niv_usuario
        {
            get { return mvarniv_usuario; }
            set { mvarniv_usuario = value; }
        }

        [DataMember]
        public Int16 est_usuario
        {
            get { return mvarest_usuario; }
            set { mvarest_usuario = value; }
        }

        [DataMember]
        public String usu_registro
        {
            get { return mvarusu_registro; }
            set { mvarusu_registro = value; }
        }

        [DataMember]
        public DateTime Fec_Registro
        {
            get { return mvarfec_registro; }
            set { mvarfec_registro = value; }
        }




    }
}
