using HardwareManagementSystem.Business;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareManagementSystem.Data
{
    internal class CustomerDB : DB
    {
        public CustomerDB(string connStr) : base(connStr) { }

        public void AddCustomer(Customers customer)
        {
            string query = "INSERT INTO Customer(CustomerName, Gender, Phone) " +
                           "VALUES(@CustomerName, @Gender, @Phone)";

            try
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
                    command.Parameters.AddWithValue("@Gender", customer.Gender);
                    command.Parameters.AddWithValue("@Phone", customer.Phone);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the customer.", ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public List<Customers> GetCustomers()
        {
            List<Customers> list = new List<Customers>();
            string query = "SELECT * FROM Customer";

            try
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Customers customer = new Customers
                            {
                                CustomerID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                                CustomerName = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                                Gender = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                                Phone = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                            };
                            list.Add(customer);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching the customers.", ex);
            }
            finally
            {
                connection.Close();
            }

            return list;
        }

        public void DeleteCustomer(int customerID)
        {
            string query = "DELETE FROM Customer WHERE CustomerID = @CustomerID";

            try
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerID", customerID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the customer.", ex);
            }
            finally
            {
                connection.Close();
            }
        }

    }
}

