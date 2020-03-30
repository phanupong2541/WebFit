using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFit.Models;

namespace WebFit.Report
{
    public partial class EQ1 : System.Web.UI.Page
    {
        private KruFitNesEntities db = new KruFitNesEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<View_EQ> view = null;
                using (KruFitNesEntities dc = new KruFitNesEntities())
                {
                    view = dc.View_EQ.OrderBy(a => a.CE_ATNO).ToList();
                    ReportViewer2.LocalReport.ReportPath = Server.MapPath("~/Report/EQ.rdlc");
                    ReportViewer2.LocalReport.DataSources.Clear();
                    ReportDataSource rdc = new ReportDataSource("EQ1", view);
                    ReportViewer2.LocalReport.DataSources.Add(rdc);
                    ReportViewer2.LocalReport.Refresh();


                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (CheckBoxList1.SelectedValue == "01")
            {

                List<View_EQ> view = null;
                using (KruFitNesEntities dc = new KruFitNesEntities())
                {
                    string da = TextBox1.Text.ToString();
                    view = dc.View_EQ.Where(a => a.CE_Name == da).ToList();
                    ReportViewer2.LocalReport.ReportPath = Server.MapPath("~/Report/EQ.rdlc");
                    ReportViewer2.LocalReport.DataSources.Clear();
                    ReportDataSource rdc = new ReportDataSource("EQ1", view);
                    ReportViewer2.LocalReport.DataSources.Add(rdc);
                    ReportViewer2.LocalReport.Refresh();


                }
            }

           

            if (CheckBoxList1.SelectedValue == "02")
            {

                List<View_EQ> view = null;
                using (KruFitNesEntities dc = new KruFitNesEntities())
                {
                    var da = Convert.ToDateTime(TextBox1.Text);
                    var doo = Convert.ToDateTime(TextBox2.Text);

                    view = dc.View_EQ.Where(a => DbFunctions.TruncateTime(a.CE_DateIn) >= DbFunctions.TruncateTime(da) &&
                                                   DbFunctions.TruncateTime(a.CE_DateIn) <= DbFunctions.TruncateTime(doo))
                      .ToList();
                    ReportViewer2.LocalReport.ReportPath = Server.MapPath("~/Report/EQ.rdlc");
                    ReportViewer2.LocalReport.DataSources.Clear();
                    ReportDataSource rdc = new ReportDataSource("EQ1", view);
                    ReportViewer2.LocalReport.DataSources.Add(rdc);
                    ReportViewer2.LocalReport.Refresh();





                }
            }

        }
    }
}
