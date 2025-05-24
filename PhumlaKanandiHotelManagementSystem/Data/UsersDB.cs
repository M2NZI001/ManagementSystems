using PhumlaKanandiHotelManagementSystem.Business;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhumlaKanandiHotelManagementSystem.Data
{
    internal class UsersDB : DB
    {
        #region Constructors
        public UsersDB() : base() { }
        public UsersDB(string connectionString) : base(connectionString) { }
        #endregion

        #region Methods
        public void AddUser(Users user)
        {
            string insertQuery = "INSERT INTO Users (StaffID, Username, Password) VALUES (@StaffID, @Username, @Password)";
            using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
            {
                cmd.Parameters.AddWithValue("@StaffID", user.StaffID);
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw new Exception($"Error adding user: {ex.Message}");
                }
                finally
                {
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }

        public Users GetUserByID(int userID)
        {
            return GetUserDetails(userID);
        }

        public Users GetUserByUsername(string username)
        {
            string selectQuery = "SELECT UserID, StaffID, Username, Password FROM Users WHERE Username = @Username";
            using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Users user = new Users(
                                reader.GetInt32(reader.GetOrdinal("UserID")),
                                reader.GetInt32(reader.GetOrdinal("StaffID")),
                                reader.GetString(reader.GetOrdinal("Username")),
                                reader.GetString(reader.GetOrdinal("Password"))
                            );
                            return user;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    // Log the exception or handle it as appropriate for your application
                    throw new Exception($"Error retrieving user: {ex.Message}");
                }
                finally
                {
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
                return null;
            }
        }

        public void UpdateUser(Users user)
        {
            string updateQuery = "UPDATE Users SET StaffID = @StaffID, Username = @Username, Password = @Password WHERE UserID = @UserID";
            using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
            {
                cmd.Parameters.AddWithValue("@UserID", user.UserID);
                cmd.Parameters.AddWithValue("@StaffID", user.StaffID);
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Password", user.Password);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void DeleteUser(int userID)
        {
            string deleteQuery = "DELETE FROM Users WHERE UserID = @UserID";
            using (SqlCommand cmd = new SqlCommand(deleteQuery, connection))
            {
                cmd.Parameters.AddWithValue("@UserID", userID);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw new Exception($"Error deleting user: {ex.Message}");
                }
                finally
                {
                    connection.Close();
                }
            }
        }

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

        public Users GetUserDetails(int userID)
        {
            string selectQuery = "SELECT u.UserID, u.StaffID, s.FirstName, s.LastName, s.Email, s.Phone, s.Address, s.Role, u.Username, u.Password FROM Users u INNER JOIN Staff s ON u.StaffID = s.StaffID WHERE u.UserID = @UserID";
            using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
            {
                cmd.Parameters.AddWithValue("@UserID", userID);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Users user = new Users(
                            reader.GetInt32(reader.GetOrdinal("UserID")),
                            reader.GetInt32(reader.GetOrdinal("StaffID")),
                            reader.GetString(reader.GetOrdinal("Username")),
                            reader.GetString(reader.GetOrdinal("Password"))
                        );
                        connection.Close();
                        return user;
                    }
                }
                connection.Close();
                return null;
            }
        }

        public void AddUser(int staffID, string username, string password)
        {
            string insertQuery = "INSERT INTO Users (StaffID, Username, Password) VALUES (@StaffID, @Username, @Password)";
            using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
            {
                cmd.Parameters.AddWithValue("@StaffID", staffID);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw new Exception($"Error adding user: {ex.Message}");
                }
                finally
                {
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }

        public List<Users> GetAllUsers()
        {
            List<Users> users = new List<Users>();
            string selectQuery = "SELECT UserID, StaffID, Username, Password FROM Users";

            using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
            {
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Users user = new Users(
                                reader.GetInt32(reader.GetOrdinal("UserID")),
                                reader.GetInt32(reader.GetOrdinal("StaffID")),
                                reader.GetString(reader.GetOrdinal("Username")),
                                reader.GetString(reader.GetOrdinal("Password"))
                            );
                            users.Add(user);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    // Log the exception or handle it as appropriate for your application
                    throw new Exception($"Error retrieving users: {ex.Message}");
                }
                finally
                {
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
            return users;
        }
        #endregion

    }
}
