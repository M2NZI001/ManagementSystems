using PhumlaKanandiHotelManagementSystem.Business;
using PhumlaKanandiHotelManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhumlaKanandiHotelManagementSystem.Presentation
{
    public partial class AdminReservations : UserControl
    {
        #region Fields
        private BookingDB bookingDB;
        private List<Booking> allBookings;
        public int GuestID { get; set; }
        public int RoomID { get; set; }
        #endregion

        #region Constructor
        public AdminReservations()
        {
            InitializeComponent();
            //string connectionString = Properties.Settings.Default.HotelDatabaseConnectionString;
            //bookingDB = new BookingDB(connectionString);
            bookingDB = new BookingDB();
            LoadBookingData();
        }
        #endregion

        #region Public Methods
        public void SetReservationDetails(int guestID, int roomID)
        {
            GuestID = guestID;
            RoomID = roomID;
            txtGuestID_reservation.Text = guestID.ToString();
            txtRoomID_reservation.Text = roomID.ToString();
        }
        #endregion

        #region Private Methods
        private void LoadBookingData()
        {
            try
            {
                allBookings = bookingDB.GetAllBookings();
                dataGridView_Reservations.DataSource = allBookings;
                CustomizeDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading booking data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CustomizeDataGridView()
        {
            // Existing CustomizeDataGridView code...
        }

        private void btnConfirmReservation_reservation_Click(object sender, EventArgs e)
        {
            if (RoomID <= 0)
            {
                MessageBox.Show("Please ensure Guest ID and Room ID are properly set.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Validate that the CheckInDate is not before today
            DateTime today = DateTime.Today;
            DateTime checkInDate = dateCheckIn_reservation.Value.Date;

            if (checkInDate < today)
            {
                MessageBox.Show("Check-in date cannot be in the past. Please select today or a future date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            try
            {
                Booking newBooking = new Booking
                {
                    GuestID = GuestID,
                    RoomID = RoomID,
                    CheckInDate = dateCheckIn_reservation.Value,
                    CheckOutDate = dateCheckOut_reservation.Value
                };

                bookingDB.AddBooking(newBooking);
                MessageBox.Show("Reservation confirmed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadBookingData();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error confirming reservation: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtGuestID_reservation.Clear();
            txtRoomID_reservation.Clear();
            dateCheckIn_reservation.Value = DateTime.Now;
            dateCheckOut_reservation.Value = DateTime.Now.AddDays(1);
            GuestID = 0;
            RoomID = 0;
        }

        private void dataGridView_Reservations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_Reservations.Rows[e.RowIndex];
                GuestID = Convert.ToInt32(row.Cells["GuestID"].Value);
                RoomID = Convert.ToInt32(row.Cells["RoomID"].Value);
                txtGuestID_reservation.Text = GuestID.ToString();
                txtRoomID_reservation.Text = RoomID.ToString();
                // You may want to populate other fields as well
            }
        }

        private void btnMakePayment_reservation_Click(object sender, EventArgs e)
        {
            // Check if a booking is selected
            if (dataGridView_Reservations.SelectedRows.Count > 0)
            {
                // Get the selected booking
                DataGridViewRow selectedRow = dataGridView_Reservations.SelectedRows[0];
                int bookingID = Convert.ToInt32(selectedRow.Cells["BookingID"].Value);
                int roomID = Convert.ToInt32(selectedRow.Cells["RoomID"].Value);
                DateTime checkInDate = Convert.ToDateTime(selectedRow.Cells["CheckInDate"].Value);
                DateTime checkOutDate = Convert.ToDateTime(selectedRow.Cells["CheckOutDate"].Value);

                // Get the parent form (assuming it's AdminMainForm)
                AdminMainForm mainForm = this.ParentForm as AdminMainForm;
                if (mainForm != null)
                {
                    // Call the method to show the AdminPayment control and pass all required parameters
                    mainForm.ShowPaymentControl(bookingID, roomID, checkInDate, checkOutDate);
                }
                else
                {
                    MessageBox.Show("Unable to access the main form. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a booking to make a payment.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        private void dateCheckIn_reservation_ValueChanged(object sender, EventArgs e)
        {

        }

        private void backButtonAdminReservations_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Create a new instance of AdminRooms
            AdminRooms adminRooms = new AdminRooms();

            // Add AdminRooms to the parent container (e.g., a panel) and display it
            if (this.Parent != null)
            {
                this.Parent.Controls.Add(adminRooms);
                adminRooms.Dock = DockStyle.Fill;
                adminRooms.BringToFront();
            }
        }
    }
}

