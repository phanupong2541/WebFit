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
    
    public partial class Table_Daily
    {
        public int ID_Daily { get; set; }
        public string ID_UserDaily { get; set; }
        public Nullable<int> ID_Cost { get; set; }
        public Nullable<System.DateTime> Date_Daily { get; set; }
    
        public virtual Table_Cost Table_Cost { get; set; }
        public virtual Table_User Table_User { get; set; }
    }
}
