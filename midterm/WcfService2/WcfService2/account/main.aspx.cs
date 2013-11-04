using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WcfService2.account
{
    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["Username"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                lblName.Text = Session["Username"].ToString();

            }
        }

        protected void lnkbtnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();

            Response.Redirect("~/account/login.aspx");
        }
    }
}