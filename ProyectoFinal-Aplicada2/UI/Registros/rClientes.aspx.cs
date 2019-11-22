using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entidades;

namespace ProyectoFinal_Aplicada2.UI.Registros
{
    public partial class rClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Limpiar();
                ClienteIdTextBox.Text = "0";

                int ID = Utilitarios.Utils.ToInt(Request.QueryString["id"]);

                if (ID > 0)
                {
                    BLL.RepositorioBase<Clientes> repositorio = new BLL.RepositorioBase<Clientes>();
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
            ClienteIdTextBox.Text = string.Empty;
            NombreTextBox.Text = string.Empty;
            BalanceTextBox.Text = 0.ToString();
            CorreoTextBox.Text = string.Empty;
            CedulaTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            CedulaTextBox.Text = string.Empty;
                                 

        }

        public Clientes LlenaClase()
        {
            Clientes cliente = new Clientes();
            cliente.ClienteId = Convert.ToInt32(ClienteIdTextBox.Text);
            cliente.Nombre = NombreTextBox.Text;
            cliente.Email = CorreoTextBox.Text;
            cliente.Cedula = CedulaTextBox.Text;
            cliente.Celular = CelularTextBox.Text;
            cliente.Telefono = TelefonoTextBox.Text;
            cliente.Direccion = DireccionTextBox.Text;
            cliente.Fecha = DateTime.Now;
            cliente.UsuarioId = 0;

         


            return cliente;
        }

        private void LlenaCampo(Clientes cliente)
        {
            ClienteIdTextBox.Text = cliente.ClienteId.ToString();
            NombreTextBox.Text = cliente.Nombre;
            BalanceTextBox.Text = cliente.Balance.ToString();
            CedulaTextBox.Text = cliente.Cedula;
            CelularTextBox.Text = cliente.Celular;
            fechaTextBox.Text = cliente.Fecha.ToString("yyyy-MM-dd");
            DireccionTextBox.Text = cliente.Direccion;
            CorreoTextBox.Text = cliente.Email;
            TelefonoTextBox.Text = cliente.Telefono;


        }

        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Clientes> db = new RepositorioBase<Clientes>();
            Clientes Clientes = db.Buscar(Convert.ToInt32(ClienteIdTextBox.Text));
            return (Clientes != null);

        }



        private bool ValidarCampos()
        {
            bool paso = true;
            if (NombreTextBox.Text == string.Empty)
            {
                Utilitarios.Utils.ShowToastr(this.Page, "El campo descripcion no puede estar vacio", "Error", "error");

                NombreTextBox.Focus();
                paso = false;
            }


            return paso;
        }




     
 

        protected void BuscarButton_Click1(object sender, EventArgs e)
        {
            int id;

            RepositorioBase<Clientes> db = new RepositorioBase<Clientes>();
            Clientes tipoAnalisis = new Clientes();
            int.TryParse(ClienteIdTextBox.Text, out id);
            Limpiar();

            tipoAnalisis = db.Buscar(id);

            if (tipoAnalisis != null)
            {

                LlenaCampo(tipoAnalisis);

            }
            else
            {
                Utilitarios.Utils.ShowToastr(this.Page, "No se encontro ese Cliente", "Error", "error");

            }
        }

        protected void EliminarButton_Click1(object sender, EventArgs e)
        {
            if (Utilitarios.Utils.ToInt(ClienteIdTextBox.Text) > 0)
            {
                int id = Convert.ToInt32(ClienteIdTextBox.Text);
                RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
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

        protected void GuardarButton_Click1(object sender, EventArgs e)
        {
            RepositorioBase<Clientes> db = new RepositorioBase<Clientes>();
            Clientes cliente;
            bool paso = false;


            if (!ValidarCampos())
                return;

            cliente = LlenaClase();


            if (ClienteIdTextBox.Text == Convert.ToString(0))
            {
                paso = db.Guardar(cliente);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    Utilitarios.Utils.ShowToastr(this.Page, "No se puede modicicar un cliente que no existe", "Error", "error");
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

        protected void NuevoButton_Click1(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}