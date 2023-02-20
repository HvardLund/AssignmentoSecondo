// See https://aka.ms/new-console-template for more information
using AssignmentoSecondo.Modules;
using Microsoft.Data.SqlClient;

List<Customer> customers = new List<Customer>();
SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
builder.DataSource = "N-NO-01-01-3937\\SQLEXPRESS";
builder.IntegratedSecurity = true;
builder.InitialCatalog = "Chinook";
builder.TrustServerCertificate = true;

using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
{
    conn.Open();
    string sql = "SELECT CustomerId,FirstName, LastName , Country, PostalCode,Phone, Email FROM dbo.Customer";
    using(SqlCommand cmd = new SqlCommand(sql, conn))
    {
        using(SqlDataReader reader = cmd.ExecuteReader())
        {
            while(reader.Read()) 
            {
                customers.Add(new Customer()
                {
                    CustomerId = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Country= reader.GetString(3),
                    PostalCode= reader.GetString(4),
                    Phone= reader.GetString(5),
                    Email= reader.GetString(6)

                });
            }
        }
    }
}

