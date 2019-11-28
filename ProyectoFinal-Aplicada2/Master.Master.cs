using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinal_Aplicada2
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

        }

     

        protected void Inicio_Click(object sender, EventArgs e)
        {

            Response.Redirect(@"~\Default.aspx");

        }

        protected void Informacion_Click(object sender, EventArgs e)
        {

            Response.Redirect(@"~\Informacion.aspx");

        }

        protected void LogOut_Click1(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}