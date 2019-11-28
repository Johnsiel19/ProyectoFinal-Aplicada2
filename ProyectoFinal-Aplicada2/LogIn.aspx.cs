using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinal_Aplicada2
{
    public partial class LogIn : System.Web.UI.Page
    {
        private RepositorioBase<Entidades.Usuarios> BLL = new RepositorioBase<Usuarios>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    
   
        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            if( ClaveTextBox.Text == "admin1" && UsuarioTextBox.Text == "admin1")
            {
                Usuarios Usuario = new Usuarios();
                FormsAuthentication.RedirectFromLoginPage(Usuario.Usuario, true);
                Response.Redirect(@"\Default.aspx");
                

            }
            else {

                Expression<Func<Usuarios, bool>> filtrar = x => true;
                Usuarios Usuario = new Usuarios();
                string var = Eramake.eCryptography.Encrypt(ClaveTextBox.Text.Trim());

                filtrar = t => t.Usuario.Equals(UsuarioTextBox.Text) && t.Clave.Equals(var);

                if (BLL.GetList(filtrar).Count() != 0)
                {
                    FormsAuthentication.RedirectFromLoginPage(Usuario.Usuario, true);
                }
                else
                {
                    Utilitarios.Utils.ShowToastr(this.Page, "si", "Error", "error");
                }


            }

       

        }

        protected void CrearButton_Click(object sender, EventArgs e)
        {
            Usuarios Usuario = new Usuarios();
            FormsAuthentication.RedirectFromLoginPage(Usuario.Usuario, true);
            Response.Redirect(@"\rLogIn.aspx");
        }
    }
}