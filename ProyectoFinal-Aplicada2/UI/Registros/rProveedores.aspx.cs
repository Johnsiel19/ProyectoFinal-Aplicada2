using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinal_Aplicada2.UI.Registros
{
    public partial class rProveedores : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Limpiar();
                ProveedorIdTextBox.Text = "0";

                int ID = Utilitarios.Utils.ToInt(Request.QueryString["id"]);

                if (ID > 0)
                {
                    BLL.RepositorioBase<Proveedores> repositorio = new BLL.RepositorioBase<Proveedores>();
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
   

        private void Limpiar()
        {
            ProveedorIdTextBox.Text = "0";
            NombreTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            CelularTextBox.Text = string.Empty;
            CorreoTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
           


        }

        public Proveedores LlenaClase()
        {
            Proveedores proveedor = new Proveedores();
            proveedor.ProveedorId= Convert.ToInt32(ProveedorIdTextBox.Text);
            proveedor.Nombre = NombreTextBox.Text;
            proveedor.Email = CorreoTextBox.Text;
     
            proveedor.Celular = CelularTextBox.Text;
            proveedor.Telefono = TelefonoTextBox.Text;

            proveedor.UsuarioId = 1;
            proveedor.Fecha = DateTime.Now;
            proveedor.UsuarioId = 0;




            return proveedor;
        }

        private void LlenaCampo(Proveedores proveedor)
        {
            ProveedorIdTextBox.Text = proveedor.ProveedorId.ToString();
            NombreTextBox.Text = proveedor.Nombre.Trim();
            TelefonoTextBox.Text = proveedor.Telefono;
            CelularTextBox.Text = proveedor.Celular;
            fechaTextBox.Text = proveedor.Fecha.ToString("yyyy-MM-dd");
     
            CorreoTextBox.Text = proveedor.Email;
           


        }

        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Proveedores> db = new RepositorioBase<Proveedores>();
            Proveedores Proveedores = db.Buscar(Convert.ToInt32(ProveedorIdTextBox.Text));
            return (Proveedores != null);

        }

        private Boolean ValidarEmail(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        private bool ValidarCampos()
        {
            bool paso = true;
            if (CelularTextBox.Text.Length < 11)
            {
                Utilitarios.Utils.ShowToastr(this.Page, "Celular invalido", "Error", "error");
                paso = false;

            }
            if (NombreTextBox.Text == "")
            {
                Utilitarios.Utils.ShowToastr(this.Page, "Llene el comapo nombre", "Error", "error");
                paso = false;

            }
            if (TelefonoTextBox.Text.Length < 11)
            {
                Utilitarios.Utils.ShowToastr(this.Page, "Telefono Invalido", "Error", "error");
                paso = false;

            }


            if (ValidarEmail(CorreoTextBox.Text) == false)
            {
                Utilitarios.Utils.ShowToastr(this.Page, "Correo Invalido", "Error", "error");

                paso = false;
            }

     

            return paso;
        }






        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            int id;

            RepositorioBase<Proveedores> db = new RepositorioBase<Proveedores>();
            Proveedores tipoAnalisis = new Proveedores();
            int.TryParse(ProveedorIdTextBox.Text, out id);
            Limpiar();

            tipoAnalisis = db.Buscar(id);

            if (tipoAnalisis != null)
            {

                LlenaCampo(tipoAnalisis);

            }
            else
            {
                Utilitarios.Utils.ShowToastr(this.Page, "No se encontro ese Proveedor", "Error", "error");

            }

        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Proveedores> db = new RepositorioBase<Proveedores>();
            Proveedores cliente;
            bool paso = false;


            if (!ValidarCampos())
                return;

            cliente = LlenaClase();


            if (ProveedorIdTextBox.Text == Convert.ToString(0))
            {
                paso = db.Guardar(cliente);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    Utilitarios.Utils.ShowToastr(this.Page, "No se puede modicicar un proveedor que no existe", "Error", "error");
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
            if (Utilitarios.Utils.ToInt(ProveedorIdTextBox.Text) > 0)
            {
                int id = Convert.ToInt32(ProveedorIdTextBox.Text);
                RepositorioBase<Proveedores> repositorio = new RepositorioBase<Proveedores>();
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
                Utilitarios.Utils.ShowToastr(this.Page, "No se pudo eliminar,Pooveedor no existe", "error", "error");
            }

        }
    }
}