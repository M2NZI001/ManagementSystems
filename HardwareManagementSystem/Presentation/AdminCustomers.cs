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

namespace HardwareManagementSystem.Presentation
{
    public partial class AdminCustomers : UserControl
    {
        private CustomerDB customerDB;

        public AdminCustomers()
        {
            InitializeComponent();
            customerDB = new CustomerDB(DatabaseConnector.ConnectionString);

            LoadAllCustomers();
        }

        private void customerDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // You can implement any necessary logic when a cell is clicked here
        }

        private void LoadAllCustomers()
        {
            try
            {
                // Load all Customers by calling GetCustomers
                customerDataGridView.DataSource = customerDB.GetCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Customer data: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                // Gather input from form controls
                string name = txtName.Text.Trim();
                string gender = cmboxGender.SelectedItem?.ToString(); 
                string phone = txtPhone.Text.Trim();

                // Validate input
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(phone))
                {
                    MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create a customer object
                Customers newCustomer = new Customers
                {
                    CustomerName = name,
                    Gender = gender,
                    Phone = phone
                };

                // Add the customer to the database
                customerDB.AddCustomer(newCustomer);

                // Notify success
                MessageBox.Show("Customer added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Optionally clear the input fields
                ClearText();

                // Refresh the DataGridView by reloading the customer list
                LoadAllCustomers();
            }
            catch (Exception ex)
            {
                // Handle exceptions and notify the user
                MessageBox.Show($"An error occurred while adding the customer: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearText()
        {
            txtName.Clear();
            cmboxGender.SelectedIndex = -1;
            txtPhone.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if a row is selected
                if (customerDataGridView.SelectedRows.Count > 0)
                {
                    // Get the CustomerCode from the selected row
                    int customerID = Convert.ToInt32(customerDataGridView.SelectedRows[0].Cells["CustomerID"].Value);

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
                        customerDB.DeleteCustomer(customerID);

                        // Notify success
                        MessageBox.Show("Customer deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refresh the DataGridView
                        LoadAllCustomers();
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

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }
    }
}

