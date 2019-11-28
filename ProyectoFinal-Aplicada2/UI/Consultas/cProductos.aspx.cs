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
using Microsoft.Reporting.WebForms;

namespace ProyectoFinal_Aplicada2.UI.Consultas
{
    public partial class cProductos : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>();
            if (!Page.IsPostBack)
            {
                DesdeFecha.Text = DateTime.Today.ToString("yyyy-MM-dd");
                HastaFecha.Text = DateTime.Today.ToString("yyyy-MM-dd");


            }

        }




        protected void ConsultarButton_Click(object sender, EventArgs e)
        {
            Expression<Func<Productos, bool>> filtros = x => true;
            RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>();
            List<Productos> lista = new List<Productos>();

            DateTime Desde = Utils.ToDateTime(DesdeFecha.Text);
            DateTime Hasta = Utils.ToDateTime(HastaFecha.Text);

            int criterio = Utils.ToInt(CriterioTextBox.Text);
            switch (FiltroDropDown.SelectedIndex)
            {
                case 0:
                    filtros = x => true;
                    break; //todo
                case 1:
                    filtros = c => c.ProductoId == criterio;
                    break; //ID
          

                case 2:
                    filtros = c => c.Descripcion.Contains(CriterioTextBox.Text);
                    break; //Descripcion
                case 3:
                    filtros = c => c.ProveedorId == criterio;
                    break; //Balance
                case 4:
                    filtros = c => c.Existencia == criterio;
                    break; //Balance
                case 5:
                    filtros = c => c.Costo == criterio;
                    break; //Balance
                case 6:
                    filtros = c => c.Precio == criterio;
                    break; //Balance
                case 7:
                    filtros = c => c.ProductoItbis == criterio;
                    break; //Balance



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
            Response.Redirect(@"~\UI\Reportes\ProductoReporte.aspx");
        }
    }
}