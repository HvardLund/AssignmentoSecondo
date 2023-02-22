using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentoSecondo.Repositories
{
    internal class ConnectionStringHelper
    {
        /// <summary>
        /// Builds the string which is used to connect to the database
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "N-NO-01-01-3937\\SQLEXPRESS"; //Replace N-NO-01-01-3937 with your own server name
            builder.IntegratedSecurity = true;
            builder.InitialCatalog = "Chinook";
            builder.TrustServerCertificate = true;

            return builder.ConnectionString;
        }
    }
}
