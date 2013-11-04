using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Collections;
using System.Configuration.Install;

using System.IO;
using System.Reflection;
using System.ServiceProcess;


using ZXing;
using ZXing.Common;

namespace WcfService2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "insert")]
        public UserTable InsertUser(UserTable usr)
        {

            /*
                UserTable newp =
                    new UserTable()
                    {
                        username= usr.username,
                        password = usr.password,
                        userType= usr.userType
                    };
                //return newp;
            */
            //}

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbString"].ConnectionString);

            conn.Open();

            SqlCommand cmd = new SqlCommand("Insert into UserTable(username, password, userType)values('" + usr.username+ "','" + usr.password+ "', '" + usr.userType + "')", conn);

            cmd.ExecuteNonQuery();
            cmd.Dispose();

            conn.Close();
            //SqlCommand cmd1 = new SqlCommand("Insert into ProductTable(name, price, image)values('" + product.name + "','" + product.price + "', '" + product. + "')", conn);
            UserTable np =
                    new UserTable()
                    {
                        username = usr.username,
                        password = usr.password,
                        userType = usr.userType
                    };
            return np;
        }


        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "addProduct" )]
        public newProduct add(newProduct product)
        {
            var noPrice = "0";
            if (product.price.Length == 0)
                noPrice = "0";
            else
                noPrice = product.price;

            if (product.name.Length == 0)
            {
                newProduct newp =
                    new newProduct()
                    {
                        name = product.name,
                        price = product.price,
                        boughtStatus = product.boughtStatus,
                        lastName = product.lastName,
                        registryType = product.registryType


                    };
                return newp;
            }

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbString"].ConnectionString);

            conn.Open();

            SqlCommand cmd = new SqlCommand("Insert into ProductTable(name, price, boughtStatus, lastName, registryType)values('" + product.name + "','" + noPrice+ "', '" + product.boughtStatus + "','" + product.lastName + "','"
                                            +product.registryType + "')", conn);
          
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            conn.Close();
            //SqlCommand cmd1 = new SqlCommand("Insert into ProductTable(name, price, image)values('" + product.name + "','" + product.price + "', '" + product. + "')", conn);
            newProduct np=
                new newProduct()
                {
                    name= product.name,
                    price = product.price,
                    boughtStatus= product.boughtStatus,
                    lastName = product.lastName,
                    registryType = product.registryType
                };
            return np;
        }
    

        [WebInvoke(Method="GET", RequestFormat=WebMessageFormat.Json, ResponseFormat=WebMessageFormat.Json, UriTemplate="barcode")]
        public string GetData()
        {
            var upc = "";
            var another = " ";
            // create a barcode reader instance

            //another = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath;
            //another += "images\\barcode.jpg"; // jpg part will be changed
            another = "http://vhost0221.dc1.on.ca.compute.ihost.com/aspnet_client/WcfService2/WcfService2/images/barcode.jpg";
            var localPath = new Uri(another).AbsolutePath;
            //var barcodeImageFile = another;
            var barcodeImageFile = localPath;

            //var bitmap1 = (Bitmap)Bitmap.FromFile(barcodeImageFile);
            IBarcodeReader barcodeReader;



            barcodeReader = new BarcodeReader
            {
                AutoRotate = true,
                Options = new DecodingOptions
                {
                    TryHarder = true
                }
            };
            try
            {

                //BarcodeReader reader = new BarcodeReader();
                //another = "http://vhost0221.dc1.on.ca.compute.ihost.com/aspnet_client/WcfService2/WcfService2/images/barcode.jpg";
                //using (var bitmap = (Bitmap)Bitmap.FromFile(barcodeImageFile))
                using (var bitmap = (Bitmap)Bitmap.FromFile(barcodeImageFile))
                {

                    //another += "dsdsdsd ";
                    try
                    {
                        var result = barcodeReader.Decode(bitmap);
                        upc= result.ToString(); // THIS IS THE UPC NUMBER :)
                        //upc += result.ToString();
                        //another += "kkkkkk";
                        //return result.ToString();

                    }
                    catch (Exception innerExc)
                    {
                        upc += "first";
                        Console.WriteLine("Exception: {0}", innerExc.Message);

                    }
                }
            }
            catch (Exception exc)
            {
                upc += "second ";
                upc += barcodeImageFile;
                another += " exccc " + exc.Message;
                Console.WriteLine("Exception: {0}", exc.Message);
            }
//            Result result = reader.Decode((Bitmap)Bitmap.FromFile("http://vhost0221.dc1.on.ca.compute.ihost.com/aspnet_client/WcfService2/WcfService2/barcode.jpg"));

            // load a bitmap

            //var barcodeBitmap = (Bitmap)Bitmap.FromFile("http://vhost0221.dc1.on.ca.compute.ihost.com/aspnet_client/WcfService2/WcfService2/barcode.jpg");
            // detect and decode the barcode inside the bitmap

            //return upc+" "+another;
            //return upc + another;
            return upc;
        }

        
    }
}
