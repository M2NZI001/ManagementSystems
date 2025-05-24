using HardwareManagementSystem.Data;
using HardwareManagementSystem.Presentation;
using System;
using System.Windows.Forms;

namespace HardwareManagementSystem
{
    public partial class Login : Form
    {
        private readonly UsersDB usersDB;

        public Login()
        {
            InitializeComponent();
            usersDB = new UsersDB(DatabaseConnector.ConnectionString);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //read user input
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                bool isAuthenticatedStream =  usersDB.AuthenticateUser(username, password);

                if (isAuthenticatedStream)
                {
                    //proceed to the next form
                    AdminDashboard mainForm = new AdminDashboard();
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show($"Error processing login Check if your password/ username is correct.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing login details: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                        
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
