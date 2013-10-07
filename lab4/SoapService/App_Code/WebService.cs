using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {

    public WebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public bool  queryTable(string add1, string add2) {
        //Declare Connection by passing the connection string from the web config file
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbString"].ConnectionString);

        //Open the connection
        conn.Open();

        string add1a = "0";
        string add2a = "0";

        //Declare the sql command
        SqlCommand cmd = new SqlCommand("Select * From AddTable where add1='" + add1 + "'", conn);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            add1a = reader["add1"].ToString();
            add2a = reader["add2"].ToString();
        }
        reader.Close();
        //close the connection
        conn.Close();


        //Open the connection
        // lookup person with the requested id 
        if (add1a == "0" && add2a == "0")
            return false;
        else
            return true;

    }

    [WebMethod]
    public float add(string add1, string add2)
    {
        
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbString"].ConnectionString);

        conn.Open();

        SqlCommand cmd = new SqlCommand("Insert into AddTable(add1, add2)values('" + add1 + "','" + add2 + "')", conn);

        cmd.ExecuteNonQuery();
        cmd.Dispose();

        conn.Close();
        
        return (float.Parse(add1) + float.Parse(add2));
    }

    [WebMethod]
    public float subtract(string minus1, string minus2)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbString"].ConnectionString);

        conn.Open();

        SqlCommand cmd = new SqlCommand("Insert into SubtractTable(minus1, minus2)values('" + minus1 + "','" + minus2 + "')", conn);

        cmd.ExecuteNonQuery();
        cmd.Dispose();

        conn.Close();


        return (float.Parse(minus1) - float.Parse(minus2));
    }

    [WebMethod]
    public float divide(string divide1, string divide2)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbString"].ConnectionString);

        conn.Open();

        SqlCommand cmd = new SqlCommand("Insert into DivideTable(divide1, divide2)values('" + divide1 + "','" + divide2 + "')", conn);

        cmd.ExecuteNonQuery();
        cmd.Dispose();

        conn.Close();

        return (float.Parse(divide1) / float.Parse(divide2));
    }

    [WebMethod]
    public float multiply(string num1, string num2)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbString"].ConnectionString);

        conn.Open();

        SqlCommand cmd = new SqlCommand("Insert into MultiplyTable(times1, times2)values('" + num1 + "','" + num2 + "')", conn);

        cmd.ExecuteNonQuery();
        cmd.Dispose();

        conn.Close();

        return (float.Parse(num1) / float.Parse(num2));
    }
}
