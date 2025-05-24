using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using PhumlaKanandiHotelManagementSystem.Properties;

namespace PhumlaKanandiHotelManagementSystem.Presentation
{
    public partial class RegistrationForm : Form
    {
        #region Fields
        private string constr = Settings.Default.HotelDatabaseConnectionString;
        #endregion

        #region Constructors
        public RegistrationForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Handlers

        // Handle the SignIn button click event
        private void btnSignIn_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();
            this.Hide();
        }

        // Handle the checkbox for showing/hiding password
        private void chbRegisterShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtRegisterPassword.PasswordChar = chbRegisterShowPassword.Checked ? '\0' : '*';
            txtRegisterConfirmPassword.PasswordChar = chbRegisterShowPassword.Checked ? '\0' : '*';
        }

        // Handle the Register button click event
        private void btnRegisterSignUp_Click(object sender, EventArgs e)
        {
            if (AreFieldsValid())
            {
                RegisterUser();
            }
        }

        #endregion

        #region Helper Methods

        // Validate form fields before registration
        private bool AreFieldsValid()
        {
            if (string.IsNullOrEmpty(txtRegisterUsername.Text) || string.IsNullOrEmpty(txtRegisterPassword.Text) || string.IsNullOrEmpty(txtRegisterConfirmPassword.Text))
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtRegisterConfirmPassword.Text.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters long", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtRegisterPassword.Text != txtRegisterConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        // Register the user if validation passes
        private void RegisterUser()
        {
            using (SqlConnection connect = new SqlConnection(constr))
            {
                connect.Open();

                string checkUsernameQuery = "SELECT Username FROM Users WHERE Username = @usern";
                using (SqlCommand checkCmd = new SqlCommand(checkUsernameQuery, connect))
                {
                    checkCmd.Parameters.AddWithValue("@usern", txtRegisterUsername.Text.Trim());
                    SqlDataAdapter adapter = new SqlDataAdapter(checkCmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    if (table.Rows.Count != 0)
                    {
                        string tempUsername = txtRegisterUsername.Text.Substring(0, 1).ToUpper() + txtRegisterUsername.Text.Substring(1);
                        MessageBox.Show($"{tempUsername} already exists", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        InsertNewUser(connect);
                    }
                }

                connect.Close();
            }
        }

        // Insert new user into the database
        private void InsertNewUser(SqlConnection connect)
        {
            string insertQuery = "INSERT INTO Users (Username, Password, Role, Status, Date_registered) " +
                                 "VALUES(@usern, @pass, @role, @status, @regDate)";

            using (SqlCommand cmd = new SqlCommand(insertQuery, connect))
            {
                cmd.Parameters.AddWithValue("@usern", txtRegisterUsername.Text.Trim());
                cmd.Parameters.AddWithValue("@pass", txtRegisterPassword.Text.Trim());
                cmd.Parameters.AddWithValue("@role", "Staff");
                cmd.Parameters.AddWithValue("@status", "Active");

                DateTime today = DateTime.Today;
                cmd.Parameters.AddWithValue("@regDate", today);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Registered Successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form1 loginForm = new Form1();
                loginForm.Show();
                this.Hide();
            }
        }

        #endregion

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

