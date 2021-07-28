using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace StoreAppData
{
    public class DatabaseConnection
    {
        public DbContextOptions<StoreAppDBContext> Options { get; set; }

        public static DatabaseConnection DatabaseConnectionOption { get; set; }

        public DatabaseConnection(DbContextOptions<StoreAppDBContext> option)
        {
            Options = option;
        }
        public static DbContextOptions<StoreAppDBContext> GetDatabaseOptions() 
        {

            DbContextOptions<StoreAppDBContext> options = new DbContextOptions<StoreAppDBContext>();

            return options;
        }
    }
}