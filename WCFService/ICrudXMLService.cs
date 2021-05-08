using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICrudXMLService" in both code and config file together.
    [ServiceContract]
    public interface ICrudXMLService
    {
        [OperationContract]
        void InsertUserDetails();

        [OperationContract]
        CustomerData GetUserDetails();

        [OperationContract]
        void Update(int customerId, string name, string country);
 
        [OperationContract]
        void Delete(int customerId);
    }

    [DataContract]
    public class CustomerData
    {
        public CustomerData()
        {
            this.CustomersTable = new DataTable("CustomersData");
        }

        [DataMember]
        public DataTable CustomersTable { get; set; }
    }
}
