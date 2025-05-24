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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace PhumlaKanandiHotelManagementSystem.Presentation
{
    public partial class UpdateBookingForm : UserControl  // Changed from Form to UserControl
    {
        private BookingDB bookingDB;
        private AdminMainForm parentForm;
        private List<Booking> allBookings;

        public UpdateBookingForm(AdminMainForm parent)
        {
            InitializeComponent();
            bookingDB = new BookingDB();
            parentForm = parent;
            LoadBookingData();
        }

        private void LoadBookingData()
        {
            try
            {
                allBookings = bookingDB.GetAllBookings();
                dataGridView_Reservations.DataSource = allBookings;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading booking data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_Reservations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Implement cell click handling if needed
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Implement search functionality
            string searchTerm = txtBookingID.Text.Trim();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                var filteredBookings = allBookings.Where(b =>
                    b.BookingID.ToString().Contains(searchTerm) ||
                    b.GuestID.ToString().Contains(searchTerm)).ToList();

                dataGridView_Reservations.DataSource = filteredBookings;
            }
            else
            {
                dataGridView_Reservations.DataSource = allBookings;
            }
        }

        private void txtBookingID_TextChanged(object sender, EventArgs e)
        {
            // Implement search-as-you-type if needed
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView_Reservations.CurrentRow != null)
                {
                    var selectedBooking = dataGridView_Reservations.CurrentRow.DataBoundItem as Booking;
                    if (selectedBooking != null)
                    {
                        // Get the updated values from the DataGridView
                        DateTime newCheckInDate = Convert.ToDateTime(dataGridView_Reservations.CurrentRow.Cells["CheckInDate"].Value);
                        DateTime newCheckOutDate = Convert.ToDateTime(dataGridView_Reservations.CurrentRow.Cells["CheckOutDate"].Value);

                        // Validate dates
                        if (newCheckInDate >= newCheckOutDate)
                        {
                            MessageBox.Show("Check-in date must be before check-out date.", "Invalid Dates",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (newCheckInDate < DateTime.Today)
                        {
                            MessageBox.Show("Check-in date cannot be in the past.", "Invalid Date",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Create updated booking object
                        var updatedBooking = new Booking(
                            selectedBooking.BookingID,
                            selectedBooking.GuestID,
                            selectedBooking.RoomID,
                            newCheckInDate,
                            newCheckOutDate
                        );

                        // Attempt to update the booking
                        bool updateSuccess = bookingDB.UpdateBooking(updatedBooking);

                        if (updateSuccess)
                        {
                            MessageBox.Show("Booking updated successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadBookingData();
                        }
                        else
                        {
                            MessageBox.Show("Unable to update booking. The room might be unavailable for these dates.",
                                "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            LoadBookingData();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a booking to update.", "No Selection",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating booking: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (dataGridView_Reservations.SelectedRows.Count > 0)
            {
                // Get the selected booking
                var selectedBooking = (Booking)dataGridView_Reservations.SelectedRows[0].DataBoundItem;
                // Confirm deletion
                var confirmResult = MessageBox.Show($"Are you sure you want to delete booking ID: {selectedBooking.BookingID}?",
                    "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    // Call delete method from BookingDB
                    bookingDB.DeleteBooking(selectedBooking.BookingID);
                    LoadBookingData(); // Refresh the data grid
                    MessageBox.Show("Booking deleted successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // Show an error message if no booking is selected
                MessageBox.Show("Please select a booking to delete.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Switch back to the AdminDashboardForm
            this.Parent.Controls.Remove(this); // Remove the current UserControl
            parentForm.ShowDashboard();
        }

      
        private void clearButton_Click(object sender, EventArgs e)
        {
            LoadBookingData();

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
