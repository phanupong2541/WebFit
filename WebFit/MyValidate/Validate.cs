using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebFit.Models
{
    public partial class V_User
    {

        [Display(Name = "อีเมลล์")]
        [Required(ErrorMessage = "กรุณากรอกอีเมลล์")]
        [EmailAddress(ErrorMessage = "Enter Email")]
        public int ID_User { get; set; }


        [Display(Name = "ชื่อ-สกุล")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        public string User_Name { get; set; }



        [Display(Name = "รหัสผ่าน")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        public string User_Pass { get; set; }


        [Display(Name = "ประเภทผู้ใช้งาน")]
        public Nullable<bool> User_Type { get; set; }


        [Display(Name = "ส่วนสูง")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        public Nullable<double> User_Height { get; set; }


        [Display(Name = "น้ำหนัก")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        public Nullable<double> User_Weight { get; set; }


        [Display(Name = "เบอร์ติดต่อ")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        public string User_Tell { get; set; }


    }

    [MetadataType(typeof(V_User))]
    public partial class Table_User { }

    public partial class V_Buy
    {
        [Display(Name = "รหัสซื้อ")]
        public int ID_Buy { get; set; }

        [Display(Name = "ผู้ซื้อ")]
        public Nullable<int> Buy_User { get; set; }

        [Display(Name = "คอร์ส")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        public Nullable<int> Buy_Cost { get; set; }

        [Display(Name = "โปรโมชั่น")]
        public Nullable<int> Buy_Pro { get; set; }

        [Display(Name = "ราคารวม")]
        public Nullable<double> TotlePrice { get; set; }

        [Display(Name = "วันที่เริ่มต้น")]

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> Buy_Start { get; set; }

        [Display(Name = "วันหมดอายุ")]

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> Buy_Stop { get; set; }

        [Display(Name = "สถานะ")]
        public Nullable<bool> Buy_Status { get; set; }

        [Display(Name = "สลีป")]
        public string Buy_Pic { get; set; }
    }

    [MetadataType(typeof(V_Buy))]
    public partial class Table_Buy { }


    public partial class V_Cost
    {

        [Display(Name = "รหัสคอร์ส")]
        public int ID_Cost { get; set; }

        [Display(Name = "ชื่อคอร์ส")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        public string Cost_Name { get; set; }

        [Display(Name = "ราคาคอร์ส")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        public string Cost_Price { get; set; }
    }

    [MetadataType(typeof(V_Cost))]
    public partial class Table_Cost { }


    public partial class V_Dis
    {
        [Display(Name = "รหัสจำหน่าย")]
        public int DIS_ATNO { get; set; }

        [Display(Name = "อุปกรณ์")]
        public Nullable<int> CE_ATNO { get; set; }

        [Display(Name = "วันที่จำหน่าย")]

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
       
        public Nullable<System.DateTime> DIS_DateOUT { get; set; }

        [Display(Name = "สถานะ")]
        public Nullable<int> DIS_Status { get; set; }
    }

    [MetadataType(typeof(V_Dis))]
    public partial class Table_Dispose { }


    public partial class V_EQ
    {
        [Display(Name = "ที่")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        public int CE_ATNO { get; set; }

        [Display(Name = "รหัสสั่งซื้อ")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        public string CE_NO { get; set; }

        [Display(Name = "ชื่ออุปกรณ์")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        public string CE_Name { get; set; }

        [Display(Name = "จำนวน")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        public int CE_Piece { get; set; }

        [Display(Name = "ราคาต่อชิ้น")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        public Nullable<double> CE_Price { get; set; }

        [Display(Name = "ราคารวม")]

        public Nullable<double> CE_PriceTotal { get; set; }

        [Display(Name = "สถานะ")]

        public Nullable<int> CE_Status { get; set; }

        [Display(Name = "วันที่")]

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> CE_DateIn { get; set; }

    }

    [MetadataType(typeof(V_EQ))]
    public partial class Table_EQ { }



    public partial class V_Programe
    {
        [Display(Name = "รหัสโปรแกรม")]

        public int ID_Programe { get; set; }

        [Display(Name = "ชื่อโปรแกรม")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        public string PG_Name { get; set; }

        [Display(Name = "ประเภท")]
        public Nullable<int> PG_Type { get; set; }

        [Display(Name = "รายละเอียดการฝึก")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        public string PG_Detail { get; set; }

        [Display(Name = "รูปภาพ")]

        public string PG_Pic { get; set; }

        [Display(Name = "วิดีโอ")]
        public string PG_Video { get; set; }

    }

    [MetadataType(typeof(V_Programe))]
    public partial class Table_ProGrame { }

    public partial class V_ProMo
    {
        [Display(Name = "รหัสโปรโมชั่น")]
        public int ID_ProMo { get; set; }

        [Display(Name = "ชื่อโปรโมชั่น")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        public string Pro_Name { get; set; }

        [Display(Name = "รายละเอียดโปรโมชั่น")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        public string Pro_Detail { get; set; }


        [Display(Name = "ราคาโปรโมชั่น")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        public Nullable<double> Pro_Price { get; set; }

        [Display(Name = "ภาพโปรโมชั่น")]
        public string Pro_Pic { get; set; }
    }
    [MetadataType(typeof(V_ProMo))]
    public partial class Table_ProMoTion { }



    public partial class V_TypePG
    {
        [Display(Name = "รหัสประเภท")]
        public int ID_TypePG { get; set; }

        [Display(Name = "ชื่อประเภท")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        public string TypePG_Name { get; set; }

    }

    [MetadataType(typeof(V_TypePG))]
    public partial class Table_TypePG { }


    public partial class V_Daily
    {
        [Display(Name = "รหัส")]
        public int ID_Daily { get; set; }

        [Display(Name = "ชื่อผู้เข้าใช้")]
        public string ID_UserDaily { get; set; }

        [Display(Name = "ชื่อคอร์ส")]
        public Nullable<int> ID_Cost { get; set; }

        [Display(Name = "วันที่")]

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> Date_Daily { get; set; }

    }

    [MetadataType(typeof(V_Daily))]
    public partial class Table_Daily { }
}

