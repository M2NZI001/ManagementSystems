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
    public partial class AdminDashboard : UserControl
    {
        #region Fields
        private AdminMainForm parentForm;
        #endregion

        #region Constructor
        public AdminDashboard(AdminMainForm adminMainForm)
        {
            InitializeComponent();
            this.parentForm = adminMainForm;
        }
        #endregion

        #region Event Handlers
        private void btnMakeReservation_dashboard_Click_1(object sender, EventArgs e)
        {
            parentForm.OpenGuestForm();
        }

        private void btnSearchCustomers_Click(object sender, EventArgs e)
        {
            parentForm.ShowCustomersControl();
        }

        private void btnSearchReservation_Search_Click(object sender, EventArgs e)
        {
            parentForm.ShowUpdateBookingControl();
        }

        private void generateReportButton_Click(object sender, EventArgs e)
        {
            GenerateReportForm generateReportForm = new GenerateReportForm();
            generateReportForm.ShowDialog();
        }
        #endregion
    }
}

