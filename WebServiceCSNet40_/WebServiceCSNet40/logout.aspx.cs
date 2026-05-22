using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebServiceCSNet40
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    lblUsuario.Text = login.NomeUsuario;

                    hlkPerfil.Text = Default.strStatusUsuario;

                    lblSaudacao.Text = Default.mtdSaudacao();

                    //sign out from form authentication

                    System.Web.Security.FormsAuthentication.SignOut();

                    //abandon session

                    Session.Abandon();

                    //Response.Redirect("~/login.aspx");
                }
            }
            catch
            {
            }
        }
    }
}