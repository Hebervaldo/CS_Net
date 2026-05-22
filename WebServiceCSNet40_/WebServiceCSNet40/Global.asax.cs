using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace WebServiceCSNet40
{
    public class Global : System.Web.HttpApplication
    {
        
        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            if (HttpContext.Current.User != null)
            {
                // Usando as classes de identidade, vamos obter o perfil e carregar na aplicação   
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    if (HttpContext.Current.User.Identity is FormsIdentity)
                    {
                        FormsIdentity objFormsIdentity = (FormsIdentity)HttpContext.Current.User.Identity;
                        FormsAuthenticationTicket objFormsAuthenticationTicket = objFormsIdentity.Ticket;
                        string[] astrPerfis = objFormsAuthenticationTicket.UserData.Split('|');
                        HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(objFormsIdentity, astrPerfis);
                    }
                }
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}