using PhumlaKanandiHotelManagementSystem.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;


namespace PhumlaKanandiHotelManagementSystem.Data
{
    internal class GuestDB : DB
    {
        private const string TABLE_NAME = "Guest"; // Define the table name as a constant

        public GuestDB(string connectionString) : base(connectionString) { }
        public GuestDB() : base() { }


        public void AddGuest(Guest guest)
        {
            string insertQuery = $"INSERT INTO {TABLE_NAME} (FirstName, LastName, Email, Phone, Address) VALUES (@FirstName, @LastName, @Email, @Phone, @Address); SELECT SCOPE_IDENTITY();";
            using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
            {
                cmd.Parameters.AddWithValue("@FirstName", guest.FirstName);
                cmd.Parameters.AddWithValue("@LastName", guest.LastName);
                cmd.Parameters.AddWithValue("@Email", guest.Email);
                cmd.Parameters.AddWithValue("@Phone", guest.Phone);
                cmd.Parameters.AddWithValue("@Address", guest.Address);

                try
                {
                    connection.Open();
                    guest.GuestID = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (SqlException ex)
                {
                    throw new Exception($"Database error: {ex.Message}", ex);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public Guest GetGuestByID(int guestID)
        {
            string selectQuery = $"SELECT * FROM {TABLE_NAME} WHERE GuestID = @GuestID";
            using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
            {
                cmd.Parameters.AddWithValue("@GuestID", guestID);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Guest(
                                reader.GetInt32(reader.GetOrdinal("GuestID")),
                                reader.GetString(reader.GetOrdinal("FirstName")),
                                reader.GetString(reader.GetOrdinal("LastName")),
                                reader.GetString(reader.GetOrdinal("Email")),
                                reader.GetString(reader.GetOrdinal("Phone")),
                                reader.GetString(reader.GetOrdinal("Address"))
                            );
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception($"Database error: {ex.Message}", ex);
                }
                finally
                {
                    connection.Close();
                }
                return null;
            }
        }

        public int GetLastInsertedGuestID()
        {
            string query = $"SELECT TOP 1 GuestID FROM {TABLE_NAME} ORDER BY GuestID DESC";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
                catch (SqlException ex)
                {
                    throw new Exception($"Database error: {ex.Message}", ex);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public List<Guest> SearchGuests(string firstName, string lastName)
        {
            List<Guest> guests = new List<Guest>();
            string selectQuery = $"SELECT * FROM {TABLE_NAME} WHERE 1=1";

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = connection;

                // Build the query based on provided search criteria
                if (!string.IsNullOrEmpty(firstName))
                {
                    selectQuery += " AND FirstName LIKE @FirstName";
                    cmd.Parameters.AddWithValue("@FirstName", $"%{firstName}%");
                }

                if (!string.IsNullOrEmpty(lastName))
                {
                    selectQuery += " AND LastName LIKE @LastName";
                    cmd.Parameters.AddWithValue("@LastName", $"%{lastName}%");
                }

                cmd.CommandText = selectQuery;

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            guests.Add(new Guest(
                                reader.GetInt32(reader.GetOrdinal("GuestID")),
                                reader.GetString(reader.GetOrdinal("FirstName")),
                                reader.GetString(reader.GetOrdinal("LastName")),
                                reader.GetString(reader.GetOrdinal("Email")),
                                reader.GetString(reader.GetOrdinal("Phone")),
                                reader.GetString(reader.GetOrdinal("Address"))
                            ));
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception($"Database error: {ex.Message}", ex);
                }
                finally
                {
                    connection.Close();
                }
                return guests;
            }
        }

        // method to check if the guest already exists in the database
        public bool IsDuplicateGuest(Guest guest)
        {
            string selectQuery = $"SELECT COUNT(*) FROM {TABLE_NAME} WHERE FirstName = @FirstName AND LastName = @LastName AND Phone = @Phone";
            using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
            {
                cmd.Parameters.AddWithValue("@FirstName", guest.FirstName);
                cmd.Parameters.AddWithValue("@LastName", guest.LastName);
                cmd.Parameters.AddWithValue("@Phone", guest.Phone);

                try
                {
                    connection.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0; // If count > 0, a duplicate guest exists
                }
                catch (SqlException ex)
                {
                    throw new Exception($"Database error: {ex.Message}", ex);
                }
                finally
                {
                    connection.Close();
                }
            }

        }

    }
}
