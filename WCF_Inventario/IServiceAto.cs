using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Inventario
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceAto" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceAto
    {
        [OperationContract]
        AtoBE ConsultarAto(Int16 id);

        [OperationContract]
        AtoBE ConsultarAto2(Int16 id);

        [OperationContract]
        List<AtoBE> ListarAto();

        [OperationContract]
        List<AtoBE> ListarAto2();

        [OperationContract]
        Boolean InsertarAto(AtoBE objAtoBE);

        [OperationContract]
        Boolean ActualizarAto(AtoBE objAtoBE);

        [OperationContract]
        Boolean EliminarAto(Int16 id);
    }
    [DataContract]
    [Serializable]
    public class AtoBE
    {
        private Int16 mvarid;
        private Int16 mvarpiso;
        private String mvararea;
        private Int16 mvarequipo;
        private String mvarmarca;
        private String mvarmodelo;
        private String mvartipo;
        private String mvarestado;
        private String mvarobs;
        private String mvarimagen;
        private String mvarusu_registro;
        private DateTime mvarfec_registro;
        private String mvarusu_ult_modificacion;
        private DateTime mvarfec_ult_modificacion;
        private Int16 mvaractivo;
        private String mvarnom_activo;


        [DataMember]
        public Int16 id
        {
            get { return mvarid; }
            set { mvarid = value; }
        }

        [DataMember]
        public Int16 piso
        {
            get { return mvarpiso; }
            set { mvarpiso = value; }
        }

        [DataMember]
        public String area
        {
            get { return mvararea; }
            set { mvararea = value; }
        }

        [DataMember]
        public Int16 equipo
        {
            get { return mvarequipo; }
            set { mvarequipo = value; }
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
        public String estado
        {
            get { return mvarestado; }
            set { mvarestado = value; }
        }

        [DataMember]
        public String obs
        {
            get { return mvarobs; }
            set { mvarobs = value; }
        }

        [DataMember]
        public String imagen
        {
            get { return mvarimagen; }
            set { mvarimagen = value; }
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


        [DataMember]
        public Int16 activo
        {
            get { return mvaractivo; }
            set { mvaractivo = value; }
        }

        [DataMember]
        public String nom_activo
        {
            get { return mvarnom_activo; }
            set { mvarnom_activo = value; }
        }
    }

}
