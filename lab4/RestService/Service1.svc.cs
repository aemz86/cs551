using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Lab4_test
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class Service1 : IService1
    {


        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "queryInfo/{add1}/{add2}")]

        public bool queryInfo(string add1, string add2)
        {
            //Declare Connection by passing the connection string from the web config file
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbString"].ConnectionString);

            //Open the connection
            conn.Open();

            string add1a = "0";
            string add2a = "0";

            //Declare the sql command
            SqlCommand cmd = new SqlCommand("Select * From AddTable where add1='" + add1+ "'", conn);
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


        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Add/{add1}/{add2}")]
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

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Subtract/{minus1}/{minus2}")]
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

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Divide/{divide1}/{divide2}")]
        public float divide(string divide1, string divide2)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbString"].ConnectionString);

            conn.Open();

            SqlCommand cmd = new SqlCommand("Insert into DivideTable(divide1, divide2)values('" + divide1+ "','" + divide2+ "')", conn);

            cmd.ExecuteNonQuery();
            cmd.Dispose();

            conn.Close();

            return (float.Parse(divide1) / float.Parse(divide2));
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Multiply/{num1}/{num2}")]
        public float multiply(string num1, string num2)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbString"].ConnectionString);

            conn.Open();

            SqlCommand cmd = new SqlCommand("Insert into MultiplyTable(times1, times2)values('" + num1+ "','" + num2+ "')", conn);

            cmd.ExecuteNonQuery();
            cmd.Dispose();

            conn.Close();

            return (float.Parse(num1) / float.Parse(num2));
        }


        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
