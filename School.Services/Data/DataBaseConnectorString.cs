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
        public static string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        public static readonly string connectionStringAzure = ConfigurationManager.ConnectionStrings["connectionStringAzure"].ConnectionString;
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
                    return ConfigurationManager.ConnectionStrings["connectionStringAzure"].ConnectionString;
                }
            }
        }
    }
}