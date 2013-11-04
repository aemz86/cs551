using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.IO;
namespace WcfService2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData();

        [OperationContract]
        [return: MessageParameter(Name = "NewUser")]
        UserTable InsertUser(UserTable user);


        [OperationContract]
        [return: MessageParameter(Name = "NewProduct")]
        newProduct add(newProduct product);
        
        //[OperationContract]
        //CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }


    [DataContract]
    public class UserTable
    {
        [DataMember]
        public string username { get; set; }

        [DataMember]
        public string password { get; set; }

        [DataMember]
        public string userType { get; set; }

    }


    [DataContract]
    public class newProduct
    {
        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string price { get; set; }

        [DataMember]
        public string boughtStatus { get; set; }

        [DataMember]
        public string lastName { get; set; }

        [DataMember]
        public string registryType { get; set; }

    }
}
