﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace WAB_API.Models
{
    public partial class TableDispose
    {
        public int DisAtno { get; set; }
        public int? CeAtno { get; set; }
        public DateTime? DisDateOut { get; set; }
        public int? DisStatus { get; set; }

        public virtual TableEq CeAtnoNavigation { get; set; }
    }
}