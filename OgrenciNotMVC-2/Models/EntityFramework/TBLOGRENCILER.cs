//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OgrenciNotMVC_2.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBLOGRENCILER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLOGRENCILER()
        {
            this.TBLNOTLAR = new HashSet<TBLNOTLAR>();
        }
    
        public int OGRENCIID { get; set; }
        public string OGRAD { get; set; }
        public string OGRSOYAD { get; set; }
        public string OGRFOTOGRAF { get; set; }
        public string OGRCINSIYET { get; set; }
        public Nullable<byte> OGRKULUP { get; set; }
    
        public virtual TBLKULUPLER TBLKULUPLER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLNOTLAR> TBLNOTLAR { get; set; }
    }
}
