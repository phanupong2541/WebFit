﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace WAB_API.Models
{
    public partial class TableTitleName
    {
        public TableTitleName()
        {
            TableTrainner = new HashSet<TableTrainner>();
            TableUser = new HashSet<TableUser>();
        }

        public int IdTitleName { get; set; }
        public string TitleName { get; set; }

        public virtual ICollection<TableTrainner> TableTrainner { get; set; }
        public virtual ICollection<TableUser> TableUser { get; set; }
    }
}