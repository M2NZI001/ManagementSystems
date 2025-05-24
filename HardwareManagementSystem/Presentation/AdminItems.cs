using HardwareManagementSystem.Business;
using HardwareManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HardwareManagementSystem.Presentation
{
    public partial class AdminItems : UserControl
    {
        private ItemDB itemDB;
        
        public AdminItems()
        {
            InitializeComponent();
            // Initialize ItemDB with the connection string
            itemDB = new ItemDB(DatabaseConnector.ConnectionString);

            LoadAllItems();
        }


        private void ItemsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadAllItems()
        {
            try
            {
                // Load all Items by calling the getItems

                ItemsDataGridView.DataSource = itemDB.GetItems();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Items data: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                //gather inputs from the txt boxes
                string name = txtItemName.Text.Trim();
                string category = cmboxCategory.SelectedItem?.ToString();
                decimal price = Convert.ToDecimal(txtItemPrice.Text);
                int stock = Convert.ToInt32(txtItemStock.Text);
                string manufacture = txtManufacture.Text.Trim();

                // Validate input
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(category) || string.IsNullOrEmpty(manufacture))
                {
                    MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create a Item object
                Items newitem = new Items
                {
                    ItemName = name,
                    ItemCategory = category,
                    ItemPrice = price,
                    ItemStock = stock,
                    Manufacture = manufacture
                };

                // Add the customer to the database
                itemDB.AddItem(newitem);

                // Notify success
                MessageBox.Show("Item added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearText();
                LoadAllItems();

            }
            catch (Exception ex)
            {
                // Handle exceptions and notify the user
                MessageBox.Show($"An error occurred while adding the Item: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearText()
        {
            txtItemName.Clear();
            txtItemPrice.Clear();
            txtManufacture.Clear();
            txtItemStock.Clear();
            cmboxCategory.SelectedIndex = -1;
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if a row is selected
                if (ItemsDataGridView.SelectedRows.Count > 0)
                {
                    // Get the CustomerCode from the selected row
                    int ItemID = Convert.ToInt32(ItemsDataGridView.SelectedRows[0].Cells["ItemID"].Value);

                    // Confirm deletion
                    var confirmResult = MessageBox.Show(
                        "Are you sure you want to delete this customer?",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (confirmResult == DialogResult.Yes)
                    {
                        // Delete the customer from the database
                        itemDB.DeleteItem(ItemID);

                        // Notify success
                        MessageBox.Show("Customer deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refresh the DataGridView
                        LoadAllItems();
                    }
                }
                else
                {
                    MessageBox.Show("Please select a customer to delete.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                MessageBox.Show($"An error occurred while deleting the customer: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
