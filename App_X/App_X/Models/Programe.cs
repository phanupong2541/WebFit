using System;
using System.Collections.Generic;
using System.Text;

namespace App_X.Models
{
    public partial class Programe
    {
        public int ID_Programe { get; set; }
        public string PG_Name { get; set; }
        public Nullable<int> PG_Type { get; set; }
        public string PG_Detail { get; set; }
        public string PG_Pic { get; set; }
        public string PG_Video { get; set; }
    }
}
