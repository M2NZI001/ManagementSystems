using PhumlaKanandiHotelManagementSystem.Presentation;
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

namespace PhumlaKanandiHotelManagementSystem
{
    public partial class Form1 : Form
    {
        #region Fields
        private readonly UsersDB _usersDB;
        #endregion

        #region Constructors
        public Form1()
        {
            InitializeComponent();
            //string connectionString = Properties.Settings.Default.HotelDatabaseConnectionString;
            //_usersDB = new UsersDB(connectionString);
            _usersDB = new UsersDB();
        }
        #endregion

        #region Event Handlers

        // Exit button click event to close the application
        private void bntExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Register button click event to open the Registration form
        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.Show();
            this.Hide();
        }

        // Checkbox for showing/hiding the password in the login form
        private void chbLoginShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtLoginPassword.PasswordChar = chbLoginShowPassword.Checked ? '\0' : '*';
        }

        // Login button click event to authenticate the user
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtLoginUsername.Text.Trim();
            string password = txtLoginPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Use the UsersDB class to authenticate the user
                bool isAuthenticated = _usersDB.AuthenticateUser(username, password);

                if (isAuthenticated)
                {
                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Proceed to the next form after successful login
                    AdminMainForm mainForm = new AdminMainForm(); // Assuming you have a main form
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
