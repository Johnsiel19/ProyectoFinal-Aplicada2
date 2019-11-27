using BLL;
using Entidades;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinal_Aplicada2.UI.Reportes
{
    public partial class EntradaReporte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                RepositorioBase<Entradas> repositorio = new RepositorioBase<Entradas>();
                var lista = repositorio.GetList(x => true);

                MyReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                MyReportViewer.Reset();


                MyReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\UI\Reportes\ListadoEntradas.rdlc");

                MyReportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", lista));

                MyReportViewer.LocalReport.Refresh();
            }
        }
    }
}