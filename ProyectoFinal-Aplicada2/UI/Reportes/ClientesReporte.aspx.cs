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
    public partial class ClientesUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
                var lista = repositorio.GetList(x => true);

                MyReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                MyReportViewer.Reset();


                MyReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\UI\Reportes\ListadoClientes.rdlc");

                MyReportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", lista));

                MyReportViewer.LocalReport.Refresh();
            }
        }
    }
}