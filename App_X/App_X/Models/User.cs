using System;
using System.Collections.Generic;
using System.Text;

namespace App_X.Models
{
    public partial class  User
    {
        public string ID_User { get; set; }
        public string User_Name { get; set; }
        public string User_Pass { get; set; }
        public Nullable<int> User_Type { get; set; }
        public Nullable<double> User_Height { get; set; }
        public Nullable<double> User_Weight { get; set; }
        public string User_Tell { get; set; }
    }
}
