using HardwareManagementSystem.Business;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace HardwareManagementSystem.Data
{
    internal class ItemDB : DB
    {
        public ItemDB(string connStr) : base(connStr) { }

        public void AddItem(Items item)
        {
            string query = "INSERT INTO Item (ItemName, itemCategory, ItemPrice, ItemStock, Manufacture) " +
                           "VALUES (@ItemName, @itemCategory, @ItemPrice, @ItemStock, @Manufacture)";

            try
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ItemName", item.ItemName);
                    command.Parameters.AddWithValue("@itemCategory", item.ItemCategory);
                    command.Parameters.AddWithValue("@ItemPrice", item.ItemPrice);
                    command.Parameters.AddWithValue("@ItemStock", item.ItemStock);
                    command.Parameters.AddWithValue("@Manufacture", item.Manufacture);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the item.", ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public List<Items> GetItems()
        {
            List<Items> items = new List<Items>();
            string query = "SELECT * FROM Item";

            try
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Items item = new Items
                            {
                                ItemID = reader.GetInt32(0),
                                ItemName = reader.GetString(1),
                                ItemCategory = reader.GetString(2),
                                ItemPrice = reader.GetDecimal(3),
                                ItemStock = reader.GetInt32(4),
                                Manufacture = reader.GetString(5)
                            };
                            items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching the items.", ex);
            }
            finally
            {
                connection.Close();
            }
            return items;
        }

        public void DeleteItem(int itemId)
        {
            string query = "DELETE FROM Item WHERE ItemId = @ItemId";

            try
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ItemId", itemId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the item.", ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public decimal GetItemPrice(string itemName)
        {
            string query = "SELECT ItemPrice FROM Item WHERE ItemName = @ItemName";

            try
            {
                using(SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ItemName", itemName);
                    connection.Open();
                    return Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching the item price.", ex);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}

