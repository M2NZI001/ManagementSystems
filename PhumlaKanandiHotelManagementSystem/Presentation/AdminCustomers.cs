using PhumlaKanandiHotelManagementSystem.Business;
using PhumlaKanandiHotelManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhumlaKanandiHotelManagementSystem.Presentation
{
    public partial class AdminCustomers : UserControl
    {
        private AdminMainForm parentForm;
        private GuestDB guestDB;
        private List<Guest> searchResults;

        #region Constructors
        public AdminCustomers(AdminMainForm parentForm)
        {
            InitializeComponent();
            //string connectionString = Properties.Settings.Default.HotelDatabaseConnectionString;
            //guestDB = new GuestDB(connectionString);
            guestDB = new GuestDB();
            this.parentForm = parentForm;


            CustomizeDataGridView();
            LoadAllGuests(); // Add this line to load initial data
        }
        #endregion

        #region Data Loading
        private void LoadAllGuests()
        {
            try
            {
                // Load all guests by calling SearchGuests with empty parameters
                searchResults = guestDB.SearchGuests("", "");
                dataGridView_customers.DataSource = searchResults;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading guest data: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CustomizeDataGridView()
        {
            dataGridView_customers.AutoGenerateColumns = false;
            dataGridView_customers.Columns.Clear();

            // Add columns to DataGridView
            dataGridView_customers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "GuestID",
                HeaderText = "Guest ID",
                Name = "GuestID",
                ReadOnly = true
            });

            dataGridView_customers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FirstName",
                HeaderText = "First Name",
                Name = "FirstName",
                ReadOnly = true
            });

            dataGridView_customers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LastName",
                HeaderText = "Last Name",
                Name = "LastName",
                ReadOnly = true
            });

            dataGridView_customers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Email",
                HeaderText = "Email",
                Name = "Email",
                ReadOnly = true
            });

            dataGridView_customers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Phone",
                HeaderText = "Phone",
                Name = "Phone",
                ReadOnly = true
            });

            dataGridView_customers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Address",
                HeaderText = "Address",
                Name = "Address",
                ReadOnly = true
            });
        }
        #endregion

        #region Search Functionality
        private void btnSearch_customers_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName_customers.Text.Trim();
            string lastName = txtLastName_customers.Text.Trim();

            // Check if both fields are empty
            if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
            {
                MessageBox.Show("Please enter at least a first name or last name to search.",
                    "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit the method if no input
            }

            try
            {
                // Search guests based on the entered first name and/or last name
                searchResults = guestDB.SearchGuests(firstName, lastName);
                dataGridView_customers.DataSource = searchResults;

                if (searchResults.Count == 0)
                {
                    MessageBox.Show("No guests found matching the search criteria.",
                        "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching for guests: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Optional: Clear search criteria (but don't clear the grid)
        private void txtFirstName_customers_TextChanged(object sender, EventArgs e)
        {
            // Removed the DataSource clearing to maintain data visibility
        }

        private void txtLastName_customers_TextChanged(object sender, EventArgs e)
        {
            // Removed the DataSource clearing to maintain data visibility
        }
        #endregion

        private void backButtonAdminCustomer_Click(object sender, EventArgs e)
        {
            this.ParentForm.Controls.Remove(this);
        }

        private void clearButtonGuestData_Click(object sender, EventArgs e)
        {
            txtFirstName_customers.Clear();
            txtLastName_customers.Clear();
            LoadAllGuests(); // Refresh the DataGridView to show all guests

        }

        private void btnBook_customers_Click(object sender, EventArgs e)
        {
            if (parentForm != null)
            {
                parentForm.ShowRoom();
            }
        }
    }
}
