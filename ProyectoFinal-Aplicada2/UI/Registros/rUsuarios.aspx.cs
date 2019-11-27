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
    public partial class rUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Limpiar();
                UsuarioIdTextBox.Text = "0";

                int ID = Utilitarios.Utils.ToInt(Request.QueryString["id"]);

                if (ID > 0)
                {
                    BLL.RepositorioBase<Usuarios> repositorio = new BLL.RepositorioBase<Usuarios>();
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
            UsuarioIdTextBox.Text = "0";
            NombreTextBox.Text = string.Empty;
            UsuarioIdTextBox.Text = string.Empty;
            CorreoTextBox.Text = string.Empty;
            ConfirmarClaveTextBox.Text = string.Empty;
        
            ClaveTextBox.Text = string.Empty;
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
         

        }

        public Usuarios LlenaClase()
        {
            Usuarios usuario = new Usuarios();
            usuario.UsuarioId = Convert.ToInt32(UsuarioIdTextBox.Text);
            usuario.Nombre = NombreTextBox.Text.Trim();
            usuario.Email = CorreoTextBox.Text;
            usuario.Clave = Eramake.eCryptography.Encrypt(ClaveTextBox.Text.Trim());
            usuario.Usuario = UsuarioTextBox.Text;
            usuario.FechaIngreso = DateTime.Now;
            usuario.NivelUsuario = NivelUsuarioComboBox.Text;
            usuario.UsuarioId = 0;


            return usuario;
        }

        private void LlenaCampo(Usuarios usuario)
        {
             UsuarioIdTextBox.Text = usuario.Usuario.ToString();
            UsuarioTextBox.Text = usuario.Usuario;
            ClaveTextBox.Text = Eramake.eCryptography.Decrypt(usuario.Clave);
            CorreoTextBox.Text = usuario.Email;
            NivelUsuarioComboBox.Text = usuario.NivelUsuario;
            UsuarioTextBox.Text = usuario.Usuario;
            fechaTextBox.Text = usuario.FechaIngreso.ToString("yyyy-MM-dd");
            NombreTextBox.Text = usuario.Nombre;
            ConfirmarClaveTextBox.Text = Eramake.eCryptography.Decrypt(usuario.Clave);

        }

        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Usuarios> db = new RepositorioBase<Usuarios>();
            Usuarios Usuarios = db.Buscar(Convert.ToInt32(UsuarioIdTextBox.Text));
            return (Usuarios != null);

        }



        private bool ValidarCampos()
        {
            bool paso = true;


            string Clave = ClaveTextBox.Text;
            string Confirmar = ConfirmarClaveTextBox.Text;

            int Resultado = 0;

            Resultado = string.Compare(Clave, Confirmar);

            if (string.IsNullOrWhiteSpace(NombreTextBox.Text))
            {
                Utilitarios.Utils.ShowToastr(this.Page, "Campo Invalido", "Error", "error");

                paso = false;
            }

    
            if (string.IsNullOrWhiteSpace(UsuarioTextBox.Text))
            {
                Utilitarios.Utils.ShowToastr(this.Page, "Campo Invalido", "Error", "error");

                paso = false;
            }



            if (ValidarEmail(CorreoTextBox.Text) == false)
            {
                Utilitarios.Utils.ShowToastr(this.Page, "Correo invalido", "Error", "error");

                paso = false;
            }


            if (Resultado != 0)
            {
                Utilitarios.Utils.ShowToastr(this.Page, "Las Claves no coinciden", "Error", "error");

                paso = false;
            }



            return paso;
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






        protected void BuscarButton_Click(object sender, EventArgs e)
        {

            int id;

            RepositorioBase<Usuarios> db = new RepositorioBase<Usuarios>();
            Usuarios tipoAnalisis = new Usuarios();
            int.TryParse(UsuarioIdTextBox.Text, out id);
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

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();

        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {

            if (Utilitarios.Utils.ToInt(UsuarioIdTextBox.Text) > 0)
            {
                int id = Convert.ToInt32(UsuarioIdTextBox.Text);
                RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
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

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> db = new RepositorioBase<Usuarios>();
            Usuarios cliente;
            bool paso = false;


            if (!ValidarCampos())
                return;

            cliente = LlenaClase();


            if (UsuarioIdTextBox.Text == Convert.ToString(0))
            {
                paso = db.Guardar(cliente);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    Utilitarios.Utils.ShowToastr(this.Page, "No se puede modicicar un Usuario que no existe", "Error", "error");
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
    }
}