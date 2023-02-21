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
        public static string GetConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "N-NO-01-01-3937\\SQLEXPRESS";
            builder.IntegratedSecurity = true;
            builder.InitialCatalog = "Chinook";
            builder.TrustServerCertificate = true;

            return builder.ConnectionString;
        }
    }
}
