using PhumlaKanandiHotelManagementSystem.Business;
using PhumlaKanandiHotelManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhumlaKanandiHotelManagementSystem.Presentation
{
    public partial class GuestForm : Form
    {
        private GuestDB guestDB;
        private AdminMainForm adminMainForm;
        public int GuestID { get; private set; }

        public GuestForm(AdminMainForm adminMainForm)
        {
            InitializeComponent();
            guestDB = new GuestDB(); // Initialize GuestDB without connection string
            this.adminMainForm = adminMainForm;
        }

        // Button click event for adding guest
        private void btnNext_guestInfo_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) // Validate input before proceeding
            {
                return;
            }

            try
            {
                // Create new Guest object based on user input
                Guest guest = new Guest(0, txtFName_guestInfo.Text, txtLName_guestInfo.Text,
                                        txtEmail_guestInfo.Text, txtPhone_guestInfo.Text, txtAddress_guestInfo.Text);

                // Check if guest with the same details already exists in the database
                if (guestDB.IsDuplicateGuest(guest))
                {
                    MessageBox.Show("A guest with the same details already exists.", "Duplicate Guest", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Add guest to the database
                guestDB.AddGuest(guest);
                GuestID = guest.GuestID; // The AddGuest method now sets the GuestID

                MessageBox.Show("Guest added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                adminMainForm.ShowRoomsControl(GuestID); // Navigate to the rooms control
                this.Close(); // Close the form after successful addition
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the guest: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Validate user input
        private bool ValidateInput()
        {
            // Ensure all required fields are filled in
            if (string.IsNullOrWhiteSpace(txtFName_guestInfo.Text) ||
                string.IsNullOrWhiteSpace(txtLName_guestInfo.Text) ||
                string.IsNullOrWhiteSpace(txtEmail_guestInfo.Text) ||
                string.IsNullOrWhiteSpace(txtPhone_guestInfo.Text) ||
                string.IsNullOrWhiteSpace(txtAddress_guestInfo.Text))
            {
                MessageBox.Show("All fields must be filled in.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validate first name and last name (letters and spaces only)
            if (!IsValidName(txtFName_guestInfo.Text) || !IsValidName(txtLName_guestInfo.Text))
            {
                MessageBox.Show("First name and last name can only contain letters and spaces.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validate address (letters and spaces only)
            if (!IsValidName(txtAddress_guestInfo.Text))
            {
                MessageBox.Show("Address can only contain letters and spaces.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validate phone number (exactly 10 digits, no letters or symbols)
            if (!IsValidPhoneNumber(txtPhone_guestInfo.Text))
            {
                MessageBox.Show("Phone number must be exactly 10 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        // Helper method to validate names (letters and spaces only)
        private bool IsValidName(string name)
        {
            return Regex.IsMatch(name, @"^[a-zA-Z\s]+$");
        }

        // Helper method to validate phone numbers (exactly 10 digits, no letters or symbols)
        private bool IsValidPhoneNumber(string phone)
        {
            return Regex.IsMatch(phone, @"^\d{10}$");
        }

        private void txtFName_guestInfo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

