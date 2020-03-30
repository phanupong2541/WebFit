using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.Reporting.WebForms;
using WebFit.Models;

namespace WebFit.Report
{
    public partial class BuyCost1 : System.Web.UI.Page
    {
        private KruFitNesEntities db = new KruFitNesEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<View_BuyCost> view = null;
                using (KruFitNesEntities dc = new KruFitNesEntities())
                {
                    view = dc.View_BuyCost.OrderBy(a => a.ID_User).ToList();
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/BuyCost.rdlc");
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportDataSource rdc = new ReportDataSource("BuyCost1", view);
                    ReportViewer1.LocalReport.DataSources.Add(rdc);
                    ReportViewer1.LocalReport.Refresh();


                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (CheckBoxList1.SelectedValue == "01")
            {

                List<View_BuyCost> view = null;
                using (KruFitNesEntities dc = new KruFitNesEntities())
                {
                    string da = TextBox1.Text.ToString();
                    view = dc.View_BuyCost.Where(a => a.ID_User == da).ToList();
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/BuyCost.rdlc");
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportDataSource rdc = new ReportDataSource("BuyCost1", view);
                    ReportViewer1.LocalReport.DataSources.Add(rdc);
                    ReportViewer1.LocalReport.Refresh();


                }
            }

           
                    if (CheckBoxList1.SelectedValue == "02")
                    {

                        List<View_BuyCost> view = null;
                        using (KruFitNesEntities dc = new KruFitNesEntities())
                        {
                            string da = TextBox1.Text.ToString();
                            view = dc.View_BuyCost.Where(a => a.Cost_Name == da).ToList();
                            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/BuyCost.rdlc");
                            ReportViewer1.LocalReport.DataSources.Clear();
                            ReportDataSource rdc = new ReportDataSource("BuyCost1", view);
                            ReportViewer1.LocalReport.DataSources.Add(rdc);
                            ReportViewer1.LocalReport.Refresh();


                        }

                    }

            if (CheckBoxList1.SelectedValue == "03")
            {

                List<View_BuyCost> view = null;
                using (KruFitNesEntities dc = new KruFitNesEntities())
                {
                    var da = Convert.ToDateTime(TextBox1.Text);
                    var doo = Convert.ToDateTime(TextBox2.Text);
                   
                    view = dc.View_BuyCost.Where(a => DbFunctions.TruncateTime(a.Buy_Start) >= DbFunctions.TruncateTime(da) &&
                                                   DbFunctions.TruncateTime(a.Buy_Start) <= DbFunctions.TruncateTime(doo))
                      .ToList();
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/BuyCost.rdlc");
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportDataSource rdc = new ReportDataSource("BuyCost1", view);
                    ReportViewer1.LocalReport.DataSources.Add(rdc);
                    ReportViewer1.LocalReport.Refresh();





                }
            }

        }
    }
}










