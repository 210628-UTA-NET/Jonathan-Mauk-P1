using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace StoreAppData
{
    class DatabaseConnection
    {
        public static DbContextOptions<StoreAppDBContext> GetDatabaseOptions() 
        {
            //Get the configuration from our appsetting.json file
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            //Grabs our connectionString from our appsetting.json
            string connectionString = configuration.GetConnectionString("Reference2DB");

            DbContextOptions<StoreAppDBContext> options = new DbContextOptionsBuilder<StoreAppDBContext>()
                .UseSqlServer(connectionString)
                .Options;

            return options;
        }
    }
}