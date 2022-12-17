using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Inventario
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceModelo" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceModelo
    {
        [OperationContract]
        ModeloBE ConsultarModelo(Int16 id);

        [OperationContract]
        List<ModeloBE> ListarModelos();

        [OperationContract]
        List<ModeloBE> ListarModelos2();

        [OperationContract]
        Boolean InsertarModelo(ModeloBE objModeloBE);

        [OperationContract]
        Boolean ActualizarModelo(ModeloBE objModeloBE);

        [OperationContract]
        Boolean EliminarModelo(Int16 id);
    }

    [DataContract]
    [Serializable]
    public class ModeloBE
    {
        private Int16 mvarid;
        private String mvarmarca;
        private String mvarmodelo;
        private String mvartipo;
        private String mvarnom_equipo;
        private String mvarusu_registro;
        private DateTime mvarfec_registro;
        private String mvarusu_ult_modificacion;
        private DateTime mvarfec_ult_modificacion;


        [DataMember]
        public Int16 id
        {
            get { return mvarid; }
            set { mvarid = value; }
        }

        [DataMember]
        public String marca
        {
            get { return mvarmarca; }
            set { mvarmarca = value; }
        }

        [DataMember]
        public String modelo
        {
            get { return mvarmodelo; }
            set { mvarmodelo = value; }
        }

        [DataMember]
        public String tipo
        {
            get { return mvartipo; }
            set { mvartipo = value; }
        }

        [DataMember]
        public String nom_equipo
        {
            get { return mvarnom_equipo; }
            set { mvarnom_equipo = value; }
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

        [DataMember]
        public String usu_ult_modificacion
        {
            get { return mvarusu_ult_modificacion; }
            set { mvarusu_ult_modificacion = value; }
        }

        [DataMember]
        public DateTime fec_ult_modificacion
        {
            get { return mvarfec_ult_modificacion; }
            set { mvarfec_ult_modificacion = value; }
        }


    }
}
