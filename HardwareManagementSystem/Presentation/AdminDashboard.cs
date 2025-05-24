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
    public partial class AdminDashboard : Form
    {
        // Control declarations
        private AdminItems itemsControl;
        private AdminBilling billingControl;
        private Categories categoriesControl;
        private AdminCustomers customersControl;

        // Constructor
        public AdminDashboard()
        {
            InitializeComponent();
            InitializeControls();
        }

        #region Control Initialization

        private void InitializeControls()
        {
            // Initialize itemsControl
            if (itemsControl == null)
            {
                itemsControl = new AdminItems();
                itemsControl.Dock = DockStyle.Fill;
                itemsControl.Visible = false;
                panelDisplay.Controls.Add(itemsControl);
            }

            // Initialize billingControl
            if (billingControl == null)
            {
                billingControl = new AdminBilling();
                billingControl.Dock = DockStyle.Fill;
                billingControl.Visible = false;
                panelDisplay.Controls.Add(billingControl);
            }

            // Initialize categoriesControl
            if (categoriesControl == null)
            {
                categoriesControl = new Categories();
                categoriesControl.Dock = DockStyle.Fill;
                categoriesControl.Visible = false;
                panelDisplay.Controls.Add(categoriesControl);
            }

            // Initialize customersControl
            if (customersControl == null)
            {
                customersControl = new AdminCustomers();
                customersControl.Dock = DockStyle.Fill;
                customersControl.Visible = false;
                panelDisplay.Controls.Add(customersControl);
            }
        }

        private void HideAllControls()
        {
            if (billingControl != null) billingControl.Visible = false;
            if (categoriesControl != null) categoriesControl.Visible = false;
            if (customersControl != null) customersControl.Visible = false;
            if (itemsControl != null) itemsControl.Visible = false;
        }

        #endregion

        #region Controls
        private void lblItems_Click_1(object sender, EventArgs e)
        {
            HideAllControls();
            itemsControl.Visible = true;
        }

        private void lblCategories_Click(object sender, EventArgs e)
        {
            HideAllControls();
            categoriesControl.Visible = true;
        }

        private void lblBilling_Click(object sender, EventArgs e)
        {
            HideAllControls();
            billingControl.Visible = true;
        }

        private void lblCustomers_Click(object sender, EventArgs e)
        {
            HideAllControls();
            customersControl.Visible = true;
        }

        #endregion

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            //back to the login page
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}


