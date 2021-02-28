﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CrudXMLService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CrudXMLService.svc or CrudXMLService.svc.cs at the Solution Explorer and start debugging.
    public class CrudXMLService : ICrudXMLService
    {
        public void InsertUserDetails()
        {
            string filePath = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath + "XML\\Customers.XML"; ;

            string xml = File.ReadAllText(filePath);
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("InsertXML"))
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@xml", xml);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        ///
    }
}
