using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhumlaKanandiHotelManagementSystem.Data
{
    public static class DatabaseHelper
    {
        public static string ConnectionString { get; } =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Hotel.mdf;Integrated Security=True";
    }

}
