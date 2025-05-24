using PhumlaKanandiHotelManagementSystem.Business;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace PhumlaKanandiHotelManagementSystem.Data
{
    internal class StaffDB : DB
     
    {
        #region Constructors
        public StaffDB(string connectionString) : base(connectionString) { }
        public StaffDB() : base() { }
        #endregion

        #region Methods
        public DataTable GetAllStaff()
        {
            string selectQuery = "SELECT * FROM Staff";
            using (SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, connection))
            {
                DataTable staffTable = new DataTable();
                adapter.Fill(staffTable);
                return staffTable;
            }
        }

        public DataTable GetStaffByRole(string role)
        {
            string selectQuery = "SELECT * FROM Staff WHERE Role = @Role";
            using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
            {
                cmd.Parameters.AddWithValue("@Role", role);
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable staffByRoleTable = new DataTable();
                    adapter.Fill(staffByRoleTable);
                    return staffByRoleTable;
                }
            }
        }

        public Staff GetStaffByID(int staffID)
        {
            string selectQuery = "SELECT * FROM Staff WHERE StaffID = @StaffID";
            using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
            {
                cmd.Parameters.AddWithValue("@StaffID", staffID);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Staff staff = new Staff(
                            reader.GetInt32(reader.GetOrdinal("StaffID")),
                            reader.GetString(reader.GetOrdinal("FirstName")),
                            reader.GetString(reader.GetOrdinal("LastName")),
                            reader.GetString(reader.GetOrdinal("Email")),
                            reader.GetString(reader.GetOrdinal("Phone")),
                            reader.GetString(reader.GetOrdinal("Address")),
                            reader.GetString(reader.GetOrdinal("Role"))
                        );
                        connection.Close();
                        return staff;
                    }
                }
                connection.Close();
                return null;
            }
        }

        public void UpdateStaff(Staff staff)
        {
            string updateQuery = "UPDATE Staff SET FirstName = @FirstName, LastName = @LastName, Email = @Email, Phone = @Phone, Address = @Address, Role = @Role WHERE StaffID = @StaffID";
            using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
            {
                cmd.Parameters.AddWithValue("@StaffID", staff.StaffID);
                cmd.Parameters.AddWithValue("@FirstName", staff.FirstName);
                cmd.Parameters.AddWithValue("@LastName", staff.LastName);
                cmd.Parameters.AddWithValue("@Email", staff.Email);
                cmd.Parameters.AddWithValue("@Phone", staff.Phone);
                cmd.Parameters.AddWithValue("@Address", staff.Address);
                cmd.Parameters.AddWithValue("@Role", staff.Role);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
        #endregion
    }
}

