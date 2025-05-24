using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareManagementSystem.Data
{
    internal class UsersDB : DB
    {
        public UsersDB(string connStr) : base(connStr) { }

        public bool AuthenticateUser(string username, string password)
        {
            string selectQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";
            using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                connection.Open();
                int count = (int)cmd.ExecuteScalar();
                connection.Close();

                return count > 0;
            }
        }
    }
}
