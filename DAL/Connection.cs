using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;


using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Connection
    {
        public static SqlConnection Con { get; set; }
        public SqlCommand Command { get; set; }
        public SqlDataReader Reader { get; set; }
        public string Query { get; set; }

        public static string? ConString { get; set; }

        //private string connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public Connection()
        {
            var configurationBuilder = new ConfigurationBuilder();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.Development.json");
            configurationBuilder.AddJsonFile(path, false);

            ConString = configurationBuilder.Build().GetSection("ConnectionStrings:DefaultConnection").Value;

            Con = new SqlConnection(ConString);
        }
    }
}
