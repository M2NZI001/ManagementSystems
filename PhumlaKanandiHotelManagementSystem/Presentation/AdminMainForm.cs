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
    public partial class AdminMainForm : Form
    {
        // Control declarations
        private AdminRooms adminRoomsControl;
        private AdminDashboard adminDashboardControl;
        private AdminReservations adminReservationsControl;
        private AdminPayment adminPaymentControl;
        private AdminCustomers adminCustomersControl;
        private UpdateBookingForm updateBookingControl;

        // Current guest identifier
        public int CurrentGuestID { get; set; }

        #region Constructors
        public AdminMainForm()
        {
            InitializeComponent();
            InitializeControls();
        }
        #endregion

        #region Control Initialization
        private void InitializeControls()
        {
            // Initialize Admin Rooms Control
            adminRoomsControl = new AdminRooms();
            adminRoomsControl.Dock = DockStyle.Fill;
            adminRoomsControl.Visible = false;
            panelDisplay.Controls.Add(adminRoomsControl);

            // Initialize Admin Dashboard Control
            if (adminDashboardControl == null)
            {
                adminDashboardControl = new AdminDashboard(this);
                adminDashboardControl.Dock = DockStyle.Fill;
                adminDashboardControl.Name = "adminDashboard1";
                panelDisplay.Controls.Add(adminDashboardControl);
            }

            // Initialize Admin Reservations Control
            adminReservationsControl = new AdminReservations();
            adminReservationsControl.Dock = DockStyle.Fill;
            adminReservationsControl.Visible = false;
            panelDisplay.Controls.Add(adminReservationsControl);

            // Initialize Admin Payment Control
            adminPaymentControl = new AdminPayment();
            adminPaymentControl.Dock = DockStyle.Fill;
            adminPaymentControl.Visible = false;
            panelDisplay.Controls.Add(adminPaymentControl);

            // Initialize Admin Customers Control
            adminCustomersControl = new AdminCustomers(this);
            adminCustomersControl.Dock = DockStyle.Fill;
            adminCustomersControl.Visible = false;
            panelDisplay.Controls.Add(adminCustomersControl);

            // Initialize UpdateBooking Control
            updateBookingControl = new UpdateBookingForm(this);
            updateBookingControl.Dock = DockStyle.Fill;
            updateBookingControl.Visible = false;
            panelDisplay.Controls.Add(updateBookingControl);

            // Show the dashboard by default
            ShowControl(adminDashboardControl);
        }
        #endregion

        #region Control Management
        private void ShowControl(Control controlToShow)
        {
            foreach (Control control in panelDisplay.Controls)
            {
                control.Visible = (control == controlToShow);
            }
            controlToShow.BringToFront();
        }

        public void ShowDashboard()
        {
            ShowControl(adminDashboardControl); // Show the dashboard control
        }


        public void ShowRoomsControl(int guestID)
        {
            CurrentGuestID = guestID;
            ShowControl(adminRoomsControl);
            adminRoomsControl.SetCurrentGuestID(guestID);
        }

        public void ShowReservationsControl(int guestID, int roomID)
        {
            ShowControl(adminReservationsControl);
            adminReservationsControl.SetReservationDetails(guestID, roomID);
        }

        public void ShowReservationsControl()
        {
            ShowControl(adminReservationsControl);
        }

        public void ShowUpdateBookingControl()
        {
          // Create an instance of UpdateBookingForm and pass the current instance
            updateBookingControl = new UpdateBookingForm(this);
            updateBookingControl.Dock = DockStyle.Fill;
            updateBookingControl.Visible = false;
            panelDisplay.Controls.Add(updateBookingControl);

            ShowControl(updateBookingControl);
        }

        public void OpenGuestForm()
        {
            GuestForm guestForm = new GuestForm(this);
            guestForm.Show();
        }

        public void ShowPaymentControl(int bookingID, int roomID, DateTime checkInDate, DateTime checkOutDate)
        {
            ShowControl(adminPaymentControl);
            adminPaymentControl.SetPaymentDetails(bookingID, roomID, checkInDate, checkOutDate);
        }

        public void ShowCustomersControl()
        {
            ShowControl(adminCustomersControl);
        }
        #endregion

        #region Event Handlers
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Confirmation Message",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Form1 loginForm = new Form1();
                loginForm.Show();
                this.Hide();
            }
        }

        public void btnDashboard_Click(object sender, EventArgs e)
        {
            ShowControl(adminDashboardControl);
        }

        private void btnRooms_Click(object sender, EventArgs e)
        {
            ShowControl(adminRoomsControl);
        }

        private void btnReservations_Click(object sender, EventArgs e)
        {
            ShowControl(adminReservationsControl);
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            ShowControl(adminPaymentControl);
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            ShowControl(adminCustomersControl);
        }
        #endregion

        


        private void panelDisplay_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        public void ShowRoom()
        {
            ShowControl(adminRoomsControl);
        }

    }
}



