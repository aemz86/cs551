using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using System.Xml.Linq;


namespace WcfService2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["Username"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {

                TextBox4.Text = Session["Username"].ToString();


            }
        }
        SqlConnection connect = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Gift;Integrated Security=True");
        static SqlDataReader dataread;
        SqlCommand cmd;
        protected void Button1_Click(object sender, EventArgs e)
        {
            connect.Open();
            cmd = new SqlCommand("select * from ProductTable", connect);
            dataread = cmd.ExecuteReader();
            if (dataread.Read())
            {
                TextBox1.Text = dataread[0].ToString();
                TextBox2.Text = dataread[1].ToString();
                TextBox3.Text = dataread[2].ToString();

                TextBox5.Text = dataread[4].ToString();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            dataread.Read();
            
                TextBox1.Text = dataread[0].ToString();
                TextBox2.Text = dataread[1].ToString();
                TextBox3.Text = dataread[2].ToString();
                TextBox4.Text = dataread[3].ToString();
                TextBox5.Text = dataread[4].ToString();
            

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            connect.Open();
            cmd = new SqlCommand("UPDATE ProductTable set boughtStatus='"+TextBox3.Text+"' WHERE lastName='"+TextBox4.Text+"' AND WHERE name='"+TextBox1.Text+"'", connect);
            cmd.ExecuteNonQuery();
        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {
            //TextBox4.Text = dataread[3].ToString();
            //TextBox5.Text = dataread[4].ToString();
        }


    }
}