using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ventanas
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = Session["error"].ToString();
            if (Request.QueryString["code"] != null)
            {
                int code = int.Parse(Request.QueryString["code"].ToString());
                if (code == 01)
                {
                    hlkRedirect.Visible = true;
                    hlkRedirect.Text = "Iniciar sesión";
                    hlkRedirect.NavigateUrl = "Login.aspx";

                }
                else if (code == 02)
                {
                    hlkRedirect.Visible = true;
                    hlkRedirect.Text = "Volver al inicio";
                    hlkRedirect.NavigateUrl = "Default.aspx";
                }
                else
                {
                    hlkRedirect.Visible = false;
                }
            }
        }
    }
}