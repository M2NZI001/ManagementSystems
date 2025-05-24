using HardwareManagementSystem.Business;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HardwareManagementSystem.Data
{
    internal class ClientBillingDB : DB
    {
        private readonly string connectionString;
      

        public ClientBillingDB(string connStr)
        {
            connectionString = connStr;
        }

        public void AddClientBill(ClientBilling itemBill)
        {
            // Logic to add client bill to the database
            string query = "INSERT INTO ClientBill (Item,Price,Qty,TotalAmount)" +
                           "VALUES (@Item,@Price,Qty,@TotalAmount)";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, connection)) 
                {
                    cmd.Parameters.AddWithValue("@Item", itemBill.Item);
                    cmd.Parameters.AddWithValue("@Price", itemBill.Price);                   
                    cmd.Parameters.AddWithValue("@Qty", itemBill.Qty);                   
                    cmd.Parameters.AddWithValue("@TotalAmount", itemBill.TotalAmount);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while processing the bill.",ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public List<ClientBilling> GetClientBills()
        {
            // Logic to fetch client bills from the database
            List<ClientBilling> bill = new List<ClientBilling>();

            string query = "SELECT * FROM ClientBill";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ClientBilling itembill = new ClientBilling
                            {
                                BillID = reader.GetInt32(0),
                                Item = reader.GetString(1),
                                Price = reader.GetDecimal(2),
                                Qty = reader.GetInt32(3),
                                TotalAmount = reader.GetDecimal(4),
                            };

                            bill.Add(itembill);
                        }
                    }
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while fetching the bill.", ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return bill;
        }

        public void AddBillAndUpdateStock(ClientBilling itemBill)
        {
            string checkStockQuery = "SELECT ItemStock FROM Item WHERE ItemName = @ItemName";
            string updateStockQuery = "UPDATE Item SET ItemStock = ItemStock - @Qty WHERE ItemName = @ItemName";
            string addBillQuery = "INSERT INTO ClientBill (Item, Price, Qty, TotalAmount) VALUES (@Item, @Price, @Qty, @TotalAmount)";

            SqlTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                // Check stock availability
                using (SqlCommand checkStockCmd = new SqlCommand(checkStockQuery, connection, transaction))
                {
                    checkStockCmd.Parameters.AddWithValue("@ItemName", itemBill.Item);

                    int stockLevel = Convert.ToInt32(checkStockCmd.ExecuteScalar());
                    if (stockLevel < itemBill.Qty)
                    {
                        throw new Exception($"Insufficient stock for item {itemBill.Item}. Available stock: {stockLevel}");
                    }
                }

                // Update stock
                using (SqlCommand updateStockCmd = new SqlCommand(updateStockQuery, connection, transaction))
                {
                    updateStockCmd.Parameters.AddWithValue("@ItemName", itemBill.Item);
                    updateStockCmd.Parameters.AddWithValue("@Qty", itemBill.Qty);
                    updateStockCmd.ExecuteNonQuery();
                }

                // Add bill
                using (SqlCommand addBillCmd = new SqlCommand(addBillQuery, connection, transaction))
                {
                    addBillCmd.Parameters.AddWithValue("@Item", itemBill.Item);
                    addBillCmd.Parameters.AddWithValue("@Price", itemBill.Price);
                    addBillCmd.Parameters.AddWithValue("@Qty", itemBill.Qty);
                    addBillCmd.Parameters.AddWithValue("@TotalAmount", itemBill.TotalAmount);
                    addBillCmd.ExecuteNonQuery();
                }

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                throw new Exception($"Error: {ex.Message}\nStackTrace: {ex.StackTrace}", ex);
            }

            finally
            {
                connection.Close();
            }
        }

    }
}
