//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCF_Inventario
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tb_Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tb_Usuario()
        {
            this.TB_ATO = new HashSet<TB_ATO>();
            this.TB_ATO1 = new HashSet<TB_ATO>();
            this.TB_Hangar = new HashSet<TB_Hangar>();
            this.TB_Hangar1 = new HashSet<TB_Hangar>();
            this.Tb_modelosLucesE = new HashSet<Tb_modelosLucesE>();
            this.Tb_modelosLucesE1 = new HashSet<Tb_modelosLucesE>();
            this.TB_PlazaLat = new HashSet<TB_PlazaLat>();
            this.TB_PlazaLat1 = new HashSet<TB_PlazaLat>();
            this.Tb_Usuario1 = new HashSet<Tb_Usuario>();
        }
    
        public string login_usuario { get; set; }
        public string pass_usuario { get; set; }
        public Nullable<int> niv_usuario { get; set; }
        public Nullable<int> est_usuario { get; set; }
        public Nullable<System.DateTime> fec_registro { get; set; }
        public string usuario_registro { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_ATO> TB_ATO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_ATO> TB_ATO1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_Hangar> TB_Hangar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_Hangar> TB_Hangar1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tb_modelosLucesE> Tb_modelosLucesE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tb_modelosLucesE> Tb_modelosLucesE1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_PlazaLat> TB_PlazaLat { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_PlazaLat> TB_PlazaLat1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tb_Usuario> Tb_Usuario1 { get; set; }
        public virtual Tb_Usuario Tb_Usuario2 { get; set; }
    }
}
