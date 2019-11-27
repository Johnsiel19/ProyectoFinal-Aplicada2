using BLL;
using Entidades;
using ProyectoFinal_Aplicada2.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinal_Aplicada2.UI.Consultas
{
    public partial class rEntradas : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            RepositorioBase<Entradas> repositorio = new RepositorioBase<Entradas>();
            if (!Page.IsPostBack)
            {
                DesdeFecha.Text = DateTime.Today.ToString("yyyy-MM-dd");
                HastaFecha.Text = DateTime.Today.ToString("yyyy-MM-dd");
            }

        }




        protected void ConsultarButton_Click(object sender, EventArgs e)
        {
            Expression<Func<Entradas, bool>> filtros = x => true;
            RepositorioBase<Entradas> repositorio = new RepositorioBase<Entradas>();
            List<Entradas> lista = new List<Entradas>();

            DateTime Desde = Utils.ToDateTime(DesdeFecha.Text);
            DateTime Hasta = Utils.ToDateTime(HastaFecha.Text);

            int criterio = Utils.ToInt(CriterioTextBox.Text);
            switch (FiltroDropDown.SelectedIndex)
            {
                case 0:
                    filtros = x => true;
                    break; //todo
                case 1:
                    filtros = c => c.EntradaId == criterio;
                    break; //ID

            }
            if (FechaCheckBox1.Checked == true)
            {
                lista = repositorio.GetList(filtros).Where(x => x.Fecha.Date >= Desde && x.Fecha.Date <= Hasta).ToList();
            }
            else
            {
                lista = repositorio.GetList(filtros);
            }
            Grid.DataSource = lista;
            Grid.DataBind();

        }


        protected void ImprimirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~\UI\Reportes\EntradaReporte.aspx");
        }

      
    }
}