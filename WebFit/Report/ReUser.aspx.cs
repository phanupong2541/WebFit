using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFit.Models;

namespace WebFit.Report
{
    public partial class ReUser1 : System.Web.UI.Page
    {
        private KruFitNesEntities db = new KruFitNesEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<View_User> view = null;
                using (KruFitNesEntities dc = new KruFitNesEntities())
                {
                    view = dc.View_User.OrderBy(a => a.ID_User).ToList();
                    ReportViewer3.LocalReport.ReportPath = Server.MapPath("~/Report/ReUser.rdlc");
                    ReportViewer3.LocalReport.DataSources.Clear();
                    ReportDataSource rdc = new ReportDataSource("User1", view);
                    ReportViewer3.LocalReport.DataSources.Add(rdc);
                    ReportViewer3.LocalReport.Refresh();


                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (CheckBoxList1.SelectedValue == "01")
            {

                List<View_User> view = null;
                using (KruFitNesEntities dc = new KruFitNesEntities())
                {
                    string da = TextBox1.Text.ToString();
                    view = dc.View_User.Where(a => a.User_Name == da).ToList();
                    ReportViewer3.LocalReport.ReportPath = Server.MapPath("~/Report/ReUser.rdlc");
                    ReportViewer3.LocalReport.DataSources.Clear();
                    ReportDataSource rdc = new ReportDataSource("User1", view);
                    ReportViewer3.LocalReport.DataSources.Add(rdc);
                    ReportViewer3.LocalReport.Refresh();


                }
            }



            if (CheckBoxList1.SelectedValue == "02")
            {

                List<View_User> view = null;
                using (KruFitNesEntities dc = new KruFitNesEntities())
                {
                    string da = TextBox1.Text.ToString();
                    view = dc.View_User.Where(a => a.ID_User == da).ToList();
                    ReportViewer3.LocalReport.ReportPath = Server.MapPath("~/Report/ReUser.rdlc");
                    ReportViewer3.LocalReport.DataSources.Clear();
                    ReportDataSource rdc = new ReportDataSource("User1", view);
                    ReportViewer3.LocalReport.DataSources.Add(rdc);
                    ReportViewer3.LocalReport.Refresh();


                }




            }
            

        }
    }
}
