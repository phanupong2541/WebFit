//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebFit.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Table_EQ
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Table_EQ()
        {
            this.Table_Dispose = new HashSet<Table_Dispose>();
        }
    
        public int CE_ATNO { get; set; }
        public string CE_NO { get; set; }
        public string CE_Name { get; set; }
        public int CE_Piece { get; set; }
        public Nullable<double> CE_Price { get; set; }
        public Nullable<double> CE_PriceTotal { get; set; }
        public Nullable<int> CE_Status { get; set; }
        public Nullable<System.DateTime> CE_DateIn { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Table_Dispose> Table_Dispose { get; set; }
    }
}