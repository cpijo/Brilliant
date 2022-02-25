using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NetcarePortal.Models.Data
{
    public class DataBaseConnectorString
    {
        public static string urlHost = ConfigurationManager.AppSettings["urlHost"];
        //private static string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        //public static readonly string connectionStringAzure = ConfigurationManager.ConnectionStrings["connectionStringAzure"].ConnectionString;
        public static string ConnectionString
        {
            get
            {
                if (urlHost == "isLocalHost")
                {
                    return ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
                }
                else
                {
                    // spijoserversql' requested by the login. Client with IP address '197.229.140.120'  use the Windows Azure Management Portal or run sp_set_firewall_rule 
                     return ConfigurationManager.ConnectionStrings["connectionStringAzure"].ConnectionString;
                }
            }
        }
    }
}