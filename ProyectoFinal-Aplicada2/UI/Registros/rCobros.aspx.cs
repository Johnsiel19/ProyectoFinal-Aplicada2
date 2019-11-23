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
    public partial class rPagos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarVentas();
            VentaIdTextbox_SelectedIndexChanged(sender, e);
            if (!Page.IsPostBack)
            {
                Limpiar();
         

                int ID = Utilitarios.Utils.ToInt(Request.QueryString["id"]);

                if (ID > 0)
                {
                    BLL.RepositorioBase<Cobros> repositorio = new BLL.RepositorioBase<Cobros>();
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

        private void CargarVentas()
        {
            if (!Page.IsPostBack)
            {
                RepositorioBase<Ventas> db = new RepositorioBase<Ventas>();


                VentaIdTextbox.DataSource = db.GetList(t => true);
                VentaIdTextbox.DataValueField = "VentaId";
                VentaIdTextbox.DataTextField = "VentaId";
                VentaIdTextbox.DataBind();

                ViewState["Venta"] = new Ventas();
            }

        }

        private void Limpiar()
        {
            CobroIdTextBox.Text = "0";
            ClienteTextBox.Text = string.Empty;
            MontoPagadoTextBox.Text = "0.00";
            MontoPagadoTextBox.Text = "0.00";

            NombreClienteTextBox.Text = string.Empty;
            ObservacionTextBox.Text = string.Empty;
            fechaTextBox.Text = DateTime.Now.ToString("dd/MM/yyyy");



        }

        public Cobros LlenaClase()
        {
            Cobros crobro = new Cobros();
            crobro.CobroId = Convert.ToInt32(VentaIdTextbox.Text);
            crobro.ClienteId = Convert.ToInt32( ClienteTextBox.Text);
            crobro.MontoPagado = Convert.ToDecimal(MontoPagadoTextBox.Text);
        
            crobro.Fecha = Convert.ToDateTime(DateTime.Now);
            crobro.UsuarioId = 0;




            return crobro;
        }

        private void LlenaCampo(Cobros Cobros)
        {
            CobroIdTextBox.Text = Cobros.CobroId.ToString();
            VentaIdTextbox.Text = Cobros.VentaId.ToString();
            ClienteTextBox.Text = Cobros.ClienteId.ToString();
            MontoPagadoTextBox.Text = Cobros.MontoPagado.ToString();
            ObservacionTextBox.Text = Cobros.Observacion;
   



        }

        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Cobros> db = new RepositorioBase<Cobros>();
            Cobros Cobros = db.Buscar(Convert.ToInt32(CobroIdTextBox.Text));
            return (Cobros != null);

        }



        private bool ValidarCampos()
        {
            bool paso = true;
            if (CobroIdTextBox.Text == string.Empty)
            {
                Utilitarios.Utils.ShowToastr(this.Page, "El campo descripcion no puede estar vacio", "Error", "error");

                CobroIdTextBox.Focus();
                paso = false;
            }


            return paso;
        }




        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            int id;

            RepositorioBase<Cobros> db = new RepositorioBase<Cobros>();
            Cobros tipoAnalisis = new Cobros();
            int.TryParse(CobroIdTextBox.Text, out id);
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
            RepositorioBase<Cobros> db = new RepositorioBase<Cobros>();
            Cobros cliente;
            bool paso = false;


            if (!ValidarCampos())
                return;

            cliente = LlenaClase();


            if (CobroIdTextBox.Text == Convert.ToString(0))
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
            if (Utilitarios.Utils.ToInt(CobroIdTextBox.Text) > 0)
            {
                int id = Convert.ToInt32(CobroIdTextBox.Text);
                RepositorioBase<Cobros> repositorio = new RepositorioBase<Cobros>();
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

        protected void VentaIdTextbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id;
            RepositorioBase<Ventas> db = new RepositorioBase<Ventas>();
            Ventas venta = new Ventas();
            int.TryParse(VentaIdTextbox.Text, out id);

            if(db.Buscar(id) != null)
            {
                venta = db.Buscar(id);

                MontoPendienteTextBox.Text = Convert.ToString(venta.Balance);
                ClienteTextBox.Text = Convert.ToString(venta.ClienteId);

            }

            RepositorioBase<Clientes> client = new RepositorioBase<Clientes>();
            Clientes cliente = new Clientes();
            int.TryParse(ClienteTextBox.Text, out id);

            if (client.Buscar(id) != null)
            {
                cliente = client.Buscar(id);

                NombreClienteTextBox.Text = Convert.ToString(cliente.Nombre);
             

            }

        }
    }
}