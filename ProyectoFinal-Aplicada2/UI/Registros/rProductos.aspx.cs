using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using BLL;
using System.Web.UI.WebControls;

namespace ProyectoFinal_Aplicada2.UI.Registros
{
    public partial class rProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarProveedores();
            if (!Page.IsPostBack)
            {
                Limpiar();
                ProductoIdTextBox.Text = "0";

                int ID = Utilitarios.Utils.ToInt(Request.QueryString["id"]);

                if (ID > 0)
                {
                    BLL.RepositorioBase<Productos> repositorio = new BLL.RepositorioBase<Productos>();
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

        private void CargarProveedores()
        {
            if (!Page.IsPostBack)
            {
                RepositorioBase<Proveedores> db = new RepositorioBase<Proveedores>();


                ProveedorIdTextbox.DataSource = db.GetList(t => true);
                ProveedorIdTextbox.DataValueField = "ProveedorId";
                ProveedorIdTextbox.DataTextField = "Nombre";
                ProveedorIdTextbox.DataBind();

                ViewState["Productos"] = new Productos();
            }

        }

        private void Limpiar()
        {
            ProductoIdTextBox.Text = "0";
            DescripcionTextBox.Text = string.Empty;
            PrecioTextBox.Text = "0.00";
            CostoTextBox.Text = "0.00";
            ItbisTextBox.Text = "0.00";
            ExistenciaTextBox.Text =" 0.00";
            ProveedorIdTextbox.Text = null;
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
           


        }

        public Productos LlenaClase()
        {
            Productos producto = new Productos();
            producto.ProductoId = Convert.ToInt32(ProductoIdTextBox.Text);
            producto.Descripcion = DescripcionTextBox.Text.Trim();
            producto.Precio = Convert.ToDecimal(PrecioTextBox.Text);
            producto.Costo = Convert.ToDecimal(CostoTextBox.Text);
            producto.ProveedorId = Convert.ToInt32(ProveedorIdTextbox.SelectedValue);
            producto.ProductoItbis = Convert.ToInt32(ItbisTextBox.Text);
            producto.Fecha = Convert.ToDateTime(DateTime.Now);
            producto.UsuarioId = 0;




            return producto;
        }

        private void LlenaCampo(Productos Productos)
        {
            ProductoIdTextBox.Text = Productos.ProductoId.ToString();
            DescripcionTextBox.Text = Productos.Descripcion;
            PrecioTextBox.Text = Productos.Precio.ToString();
            CostoTextBox.Text =  Productos.Costo.ToString();
            ProveedorIdTextbox.SelectedValue = Productos.ProveedorId.ToString();
            fechaTextBox.Text = Productos.Fecha.ToString();
            ItbisTextBox.Text = Productos.ProductoItbis.ToString();
            ExistenciaTextBox.Text = Productos.Existencia.ToString();
           


        }

        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Productos> db = new RepositorioBase<Productos>();
            Productos Productos = db.Buscar(Convert.ToInt32(ProductoIdTextBox.Text));
            return (Productos != null);

        }



        private bool ValidarCampos()
        {
            RepositorioBase<Productos> db = new RepositorioBase<Productos>();

            bool paso = true;

         
            if (DescripcionTextBox.Text == string.Empty)
            {
                Utilitarios.Utils.ShowToastr(this.Page, "Complete el compo Descripcion", "Error", "error");
               
                paso = false;
            }

            if (ProveedorIdTextbox.Text == string.Empty)
            {
                Utilitarios.Utils.ShowToastr(this.Page, "Complete el compo proveedor", "Error", "error");

                paso = false;
            }

 
            if (Convert.ToDecimal( ItbisTextBox.Text) < 0)
            {
                Utilitarios.Utils.ShowToastr(this.Page, "El ITBIS debe ser correcto", "Error", "error");

                paso = false;

            }

            if (Convert.ToDecimal(ItbisTextBox.Text) > 18)
            {
                Utilitarios.Utils.ShowToastr(this.Page, "El ITBIS debe ser correcto. Menor a 19", "Error", "error");

                paso = false;

            }

            if (Convert.ToDecimal( CostoTextBox.Text ) < 1)
            {
                Utilitarios.Utils.ShowToastr(this.Page, "El costo debe ser valido", "Error", "error");

                paso = false;

            }

            if (Convert.ToDecimal(PrecioTextBox.Text)  < 1)
            {
                Utilitarios.Utils.ShowToastr(this.Page, "El precio debe ser valido", "Error", "error");

                paso = false;

            }
            if (Convert.ToDecimal( PrecioTextBox.Text) < Convert.ToDecimal( CostoTextBox.Text))
            {
                Utilitarios.Utils.ShowToastr(this.Page, "El precio debe ser mayor al costo", "Error", "error");

                paso = false;

            }
            return paso;
        }



        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            int id;

            RepositorioBase<Productos> db = new RepositorioBase<Productos>();
            Productos tipoAnalisis = new Productos();
            int.TryParse(ProductoIdTextBox.Text, out id);
            Limpiar();

            tipoAnalisis = db.Buscar(id);

            if (tipoAnalisis != null)
            {

                LlenaCampo(tipoAnalisis);

            }
            else
            {
                Utilitarios.Utils.ShowToastr(this.Page, "No se encontro ese Clienre", "Error", "error");

            }

        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();

        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Productos> db = new RepositorioBase<Productos>();
            Productos cliente;
            bool paso = false;


            if (!ValidarCampos())
                return;

            cliente = LlenaClase();


            if (ProductoIdTextBox.Text == Convert.ToString(0))
            {
                paso = db.Guardar(cliente);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    Utilitarios.Utils.ShowToastr(this.Page, "No se puede modicicar algo que no existe", "Error", "error");
                    return;
                }
                paso = db.Modificar(cliente);
            }

            if (paso)
                Utilitarios.Utils.ShowToastr(this.Page, "Se ha Guardado correctamente", "Exito", "success");
            else
                Utilitarios.Utils.ShowToastr(this.Page, "Se profujo un error al guardar", "Error", "error");
            Limpiar();
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            if (Utilitarios.Utils.ToInt(ProductoIdTextBox.Text) > 0)
            {
                int id = Convert.ToInt32(ProductoIdTextBox.Text);
                RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>();
                if (repositorio.Eliminar(id))
                {

                    Utilitarios.Utils.ShowToastr(this.Page, "Eliminado con exito!!", "Eliminado", "info");
                }
                else
                    Utilitarios.Utils.ShowToastr(this.Page, "Fallo al Eliminar :(", "Error", "error");
                Limpiar();
            }
            else
            {
                Utilitarios.Utils.ShowToastr(this.Page, "No se pudo eliminar, Cliete no existe", "error", "error");
            }

        }
    }

}