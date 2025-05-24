using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HardwareManagementSystem.Data
{
    public static class DatabaseConnector
    {
        public static string ConnectionString { get; }

        static DatabaseConnector()
        {
            // Use a relative path to the database file
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string dbPath = Path.Combine(basePath, "Database", "HardwareDB.mdf");
            ConnectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True;Connect Timeout=30";
        }
    }
}

