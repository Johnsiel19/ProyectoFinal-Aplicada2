using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinal_Aplicada2.UI.Registros
{
    public partial class rEntradas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarProductos();
            if (!Page.IsPostBack)
            {
                Limpiar();
                EntradaIdTextBox.Text = "0";

                int ID = Utilitarios.Utils.ToInt(Request.QueryString["id"]);

                if (ID > 0)
                {
                    BLL.RepositorioBase<Entradas> repositorio = new BLL.RepositorioBase<Entradas>();
                    var us = repositorio.Buscar(ID);

                    if (us == null)
                    {
                        Utilitarios.Utils.ShowToastr(this.Page, "Registro No encontrado", "Error", "error");
                    }
                    else
                    {
                        LlenaCampo(us);
                    }
                }
            }



        }

        private void CargarProductos()
        {
            if (!Page.IsPostBack)
            {
                RepositorioBase<Productos> db = new RepositorioBase<Productos>();


                ProductoIdComboBox.DataSource = db.GetList(t => true);
                ProductoIdComboBox.DataValueField = "ProductoId";
                ProductoIdComboBox.DataTextField = "Descripcion";
                ProductoIdComboBox.DataBind();

                ViewState["Entradas"] = new Entradas();
            }

        }

        private void Limpiar()
        {
            EntradaIdTextBox.Text = "0";
            ProductoIdComboBox.Text = null;
            EntradaTextBox.Text = 0.ToString();
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");

        }

        public Entradas LlenaClase()
        {
            Entradas producto = new Entradas();
            producto.EntradaId = Convert.ToInt32(EntradaIdTextBox.Text);
            producto.ProductoId = Convert.ToInt32( ProductoIdComboBox.SelectedValue);
            producto.Entrada = Convert.ToDecimal(EntradaTextBox.Text);
  
           
            producto.Fecha = DateTime.Now;
            producto.UsuarioId = 0;




            return producto;
        }

        private void LlenaCampo(Entradas entrada)
        {
            EntradaIdTextBox.Text = entrada.ProductoId.ToString();
            EntradaTextBox.Text =  entrada.Entrada.ToString();
            ProductoIdComboBox.Text = entrada.ProductoId.ToString();
            fechaTextBox.Text = entrada.Fecha.ToString("yyyy-MM-dd");
           



        }

        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Entradas> db = new RepositorioBase<Entradas>();
            Entradas Entradas = db.Buscar(Convert.ToInt32(EntradaIdTextBox.Text));
            return (Entradas != null);

        }



        private bool ValidarCampos()
        {
            bool paso = true;
            if (ProductoIdComboBox.Text == string.Empty)
            {
                Utilitarios.Utils.ShowToastr(this.Page, "El campo Producto no puede estar vacio", "Error", "error");

                ProductoIdComboBox.Focus();
                paso = false;
            }


            return paso;
        }









        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            int id;

            RepositorioBase<Entradas> db = new RepositorioBase<Entradas>();
            Entradas tipoAnalisis = new Entradas();
            int.TryParse(EntradaIdTextBox.Text, out id);
            Limpiar();

            tipoAnalisis = db.Buscar(id);

            if (tipoAnalisis != null)
            {

                LlenaCampo(tipoAnalisis);

            }
            else
            {
                Utilitarios.Utils.ShowToastr(this.Page, "No se encontro la entrada", "Error", "error");

            }

        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();

        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {

            Entradas cliente;
            bool paso = false;


            if (!ValidarCampos())
                return;

            cliente = LlenaClase();


            if (EntradaIdTextBox.Text == Convert.ToString(0))
            {
                paso = EntradaBLL.Guardar(cliente);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    Utilitarios.Utils.ShowToastr(this.Page, "No se puede modicicar algo que no existe", "Error", "error");
                    return;
                }
                paso = EntradaBLL.Modificar(cliente);
            }

            if (paso)
                Utilitarios.Utils.ShowToastr(this.Page, "Se ha Guardado correctamente", "Exito", "success");
            else
                Utilitarios.Utils.ShowToastr(this.Page, "Se profujo un error al guardar", "Error", "error");
            Limpiar();
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            if (Utilitarios.Utils.ToInt(EntradaIdTextBox.Text) > 0)
            {
                int id = Convert.ToInt32(EntradaIdTextBox.Text);
               
                if (EntradaBLL.Eliminar(id))
                {

                    Utilitarios.Utils.ShowToastr(this.Page, "Eliminado con exito!!", "Eliminado", "info");
                }
                else
                    Utilitarios.Utils.ShowToastr(this.Page, "Fallo al Eliminar :(", "Error", "error");
                Limpiar();
            }
            else
            {
                Utilitarios.Utils.ShowToastr(this.Page, "No se pudo eliminar, Entrada no existe", "error", "error");
            }

        }

    }
}