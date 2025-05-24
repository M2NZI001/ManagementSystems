using HardwareManagementSystem.Business;
using HardwareManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HardwareManagementSystem.Presentation
{
    public partial class AdminBilling : UserControl
    {
        private ItemDB itemDB;
        private ClientBillingDB clientBillingDB;

        public AdminBilling()
        {
            InitializeComponent();
            itemDB = new ItemDB(DatabaseConnector.ConnectionString);
            clientBillingDB = new ClientBillingDB(DatabaseConnector.ConnectionString);

            LoadAllItems();
            LoadAllBill();
        }


        private void LoadAllItems()
        {
            try
            {
                ItemsDataGridView.DataSource = itemDB.GetItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Items data: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAllBill()
        {
            try
            {
                ClientBillDataGridView.DataSource = clientBillingDB.GetClientBills();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading ClientBill data: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddToBill_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve item details
                string itemName = txtItemName.Text;
                int quantity = Convert.ToInt32(txtQty.Text);

                // Fetch price for the item from the database
                decimal price = itemDB.GetItemPrice(itemName); // Assume this method exists in ItemDB
                decimal totalAmount = price * quantity;

                // Assign price to the txtPrice textbox
                txtPrice.Text = price.ToString("F2");

                // Create a new bill entry
                ClientBilling newBill = new ClientBilling
                {
                    Item = itemName,
                    Price = price,
                    Qty = quantity,
                    TotalAmount = totalAmount
                };

                // Add bill and update stock
                clientBillingDB.AddBillAndUpdateStock(newBill);
                MessageBox.Show("Bill added and stock updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reload data
                LoadAllItems();
                LoadAllBill();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numeric values for quantity.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
