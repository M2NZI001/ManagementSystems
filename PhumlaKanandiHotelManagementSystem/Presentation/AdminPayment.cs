using PhumlaKanandiHotelManagementSystem.Business;
using PhumlaKanandiHotelManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhumlaKanandiHotelManagementSystem.Presentation
{
    public partial class AdminPayment : UserControl
    {
        #region Fields and Properties

        private PaymentDB paymentDB;
        private List<Payment> allPayments;
        public int BookingID { get; set; }
        private int RoomID { get; set; }
        private DateTime CheckInDate { get; set; }
        private DateTime CheckOutDate { get; set; }

        private decimal totalRoomCharge;

        #endregion

        #region Constructor

        public AdminPayment()
        {
            InitializeComponent();
            //string connectionString = Properties.Settings.Default.HotelDatabaseConnectionString;
            //paymentDB = new PaymentDB(connectionString);
            paymentDB = new PaymentDB();
            LoadPaymentData();
        }

        #endregion

        #region Data Loading and Customization

        private void LoadPaymentData()
        {
            try
            {
                allPayments = paymentDB.GetAllPayments();
                dataGridView_payment.DataSource = allPayments;
                CustomizeDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading payment data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CustomizeDataGridView()
        {
            dataGridView_payment.AutoGenerateColumns = false;
            dataGridView_payment.Columns.Clear();
            dataGridView_payment.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PaymentID", HeaderText = "Payment ID" });
            dataGridView_payment.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "BookingID", HeaderText = "Booking ID" });
            dataGridView_payment.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "AmountPaid", HeaderText = "Amount Paid", DefaultCellStyle = { Format = "C" } });
            dataGridView_payment.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PaymentDate", HeaderText = "Payment Date", DefaultCellStyle = { Format = "d" } });
        }

        #endregion

        #region Payment Details Management

        public void SetPaymentDetails(int bookingID, int roomID, DateTime checkInDate, DateTime checkOutDate)
        {
            BookingID = bookingID;
            RoomID = roomID;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            txtBookingID_payment.Text = bookingID.ToString();
            UpdatePaymentDetails();
        }

        private void UpdatePaymentDetails()
        {
            // Calculate the total price based on the number of days and seasonal rates
            totalRoomCharge = CalculateTotalPrice(CheckInDate, CheckOutDate);
            txtPriceOfStay.Text = totalRoomCharge.ToString("C");

            /// Calculate the deposit amount (10% of total room charge)
            decimal depositAmount = totalRoomCharge * 0.10m;
            this.depositAmount.Text = depositAmount.ToString("C");

            // Leave txtTotalAmountToBePayed_payment blank for user to enter manually
            txtTotalAmountToBePayed_payment.Clear(); // Ensure it's blank initially
        }

        private decimal CalculateTotalPrice(DateTime checkIn, DateTime checkOut)
        {
            decimal totalPrice = 0m;
            // Loop through each day in the date range and apply the seasonal rate
            for (DateTime currentDay = checkIn; currentDay <= checkOut.AddDays(-1); currentDay = currentDay.AddDays(1))
            {
                string currentSeason = SeasonHelper.GetCurrentSeason(currentDay); // Get season for the current day

                // Apply the seasonal rate for each day
                decimal pricePerNight = GetSeasonalRate(currentSeason);
                totalPrice += pricePerNight; // Sum up the price per day
            }

            return totalPrice;


        }

        private decimal GetSeasonalRate(string season)
        {
            // Define seasonal rates
            var seasonalRates = new Dictionary<string, decimal>
            {
                { "Low Season", 550m }, // December 1-7
                { "Mid Season", 750m },// December 8-15
                { "High Season", 995m }// December 16-31
            };

            if (seasonalRates.TryGetValue(season, out decimal rate))
            {
                return rate;
            }

            // Default rate if season is not defined
            return 550m;
        }
        private decimal GetTotalAmountDue(int bookingID)
        {
            // Implement logic to calculate the total amount due based on bookingID
            // For now, return a placeholder value
            return 100.00m;
        }

        #endregion


        #region Payment Processing

        private void btnMakePayment_payment_Click(object sender, EventArgs e)
        {
            if (BookingID <= 0)
            {
                MessageBox.Show("Please ensure Booking ID is properly set.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                if (!decimal.TryParse(txtTotalAmountToBePayed_payment.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal amountPaid))
                {
                    MessageBox.Show("Please enter a valid amount to be paid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal totalAmountDue = GetTotalAmountDue(BookingID);

                // Ensure that the amount paid is at least the deposit amount
                decimal depositAmount = totalRoomCharge * 0.10m;
                if (amountPaid < depositAmount)
                {
                    MessageBox.Show($"You must pay at least the deposit amount of {depositAmount.ToString("C")}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Ensure that the amount paid does not exceed the total booking amount
                if (amountPaid > totalAmountDue)
                {
                    MessageBox.Show($"You cannot pay more than the total amount due of {totalAmountDue.ToString("C")}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Payment newPayment = new Payment(0, BookingID, amountPaid, DateTime.Now);

                if (newPayment.ValidatePayment(amountPaid))
                {
                    paymentDB.AddPayment(newPayment);
                    MessageBox.Show("Payment processed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPaymentData();
                    UpdateDisplayAmountPaid(amountPaid);
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Payment amount is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing payment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDisplayAmountPaid(decimal amountPaid)
        {
            depositAmount.Text = amountPaid.ToString("C");
        }

        private void ClearForm()
        {
            txtBookingID_payment.Clear();
            txtTotalAmountToBePayed_payment.Clear();
            depositAmount.Clear();
            BookingID = 0;
        }

        private void PrintConfirmation()
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);

            PrintPreviewDialog previewDialog = new PrintPreviewDialog
            {
                Document = printDocument,
                WindowState = FormWindowState.Maximized // Optional: Maximize the preview dialog
            };

            // Show the print preview dialog instead of the print dialog directly
            if (previewDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font titleFont = new Font("Arial", 24, FontStyle.Bold);
            Font font = new Font("Arial", 12);
            float lineHeight = font.GetHeight();
            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;

            // Content to print
            string confirmationTitle = "Payment Confirmation";
            string bookingID = $"Booking ID: {BookingID}";
            string roomID = $"Room ID: {RoomID}";
            string checkInDate = $"Check-In Date: {CheckInDate.ToShortDateString()}";
            string checkOutDate = $"Check-Out Date: {CheckOutDate.ToShortDateString()}";
            string totalCharge = $"Total Room Charge: {totalRoomCharge.ToString("C")}";
            

            // Print the content line by line with added spacing
            e.Graphics.DrawString(confirmationTitle, titleFont, Brushes.Black, x, y);
            y += lineHeight + 20; // Increased space
            e.Graphics.DrawString(bookingID, font, Brushes.Black, x, y);
            y += lineHeight + 10; // Additional space
            e.Graphics.DrawString(roomID, font, Brushes.Black, x, y);
            y += lineHeight + 10; // Additional space
            e.Graphics.DrawString(checkInDate, font, Brushes.Black, x, y);
            y += lineHeight + 10; // Additional space
            e.Graphics.DrawString(checkOutDate, font, Brushes.Black, x, y);
            y += lineHeight + 10; // Additional space
            e.Graphics.DrawString(totalCharge, font, Brushes.Black, x, y);
            y += lineHeight + 10; // Additional space
            
        }

        #endregion

        #region Search Functionality

        private void btnSearch_payment_Click(object sender, EventArgs e)
        {
            string bookingIDSearch = txtSearchByBookingID_payment.Text;
            string guestIDSearch = txtSearchByGuestID_payment.Text;

            IEnumerable<Payment> filteredPayments = allPayments;

            if (!string.IsNullOrEmpty(bookingIDSearch) && int.TryParse(bookingIDSearch, out int bookingID))
            {
                filteredPayments = filteredPayments.Where(p => p.BookingID == bookingID);
            }

            if (!string.IsNullOrEmpty(guestIDSearch) && int.TryParse(guestIDSearch, out int guestID))
            {
                
                MessageBox.Show("Filtering by Guest ID is not implemented yet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            dataGridView_payment.DataSource = filteredPayments.ToList();
        }

        private void dataGridView_payment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_payment.Rows[e.RowIndex];
                BookingID = Convert.ToInt32(row.Cells["BookingID"].Value);
                txtBookingID_payment.Text = BookingID.ToString();
                depositAmount.Text = Convert.ToDecimal(row.Cells["AmountPaid"].Value).ToString("C");
            }
        }

        #endregion

        #region Event Handlers

        private void txtBookingID_payment_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtBookingID_payment.Text, out int bookingID))
            {
                decimal totalAmountDue = GetTotalAmountDue(bookingID);
                txtTotalAmountToBePayed_payment.Text = totalAmountDue.ToString("C");
            }
        }

        private void txtPriceOfStay_payment_TextChanged(object sender, EventArgs e)
        {
            // This method can be implemented if you need to perform any actions
            // when the price per night changes
        }

        private void txtTotalAmountToBePayed_payment_TextChanged(object sender, EventArgs e)
        {
            // This method can be implemented if you need to perform any actions
            // when the total amount to be paid changes
        }

        private void depositAmount_TextChanged(object sender, EventArgs e)
        {
            // This method can be implemented if you need to perform any actions
            // when the displayed amount paid changes
        }

        private void txtSearchByBookingID_payment_TextChanged(object sender, EventArgs e)
        {
            // This method can be implemented if you want to perform live search
            // as the user types in the booking ID search box
        }

        private void txtSearchByGuestID_payment_TextChanged(object sender, EventArgs e)
        {
            // This method can be implemented if you want to perform live search
            // as the user types in the guest ID search box
        }

        #endregion

        private void backButtonAdminPayments_Click(object sender, EventArgs e)
        {
            this.Hide();

            
            AdminReservations adminReservations = new AdminReservations();

            
            if (this.Parent != null)
            {
                this.Parent.Controls.Add(adminReservations);
                adminReservations.Dock = DockStyle.Fill;
                adminReservations.BringToFront();
            }
        }

        private void printConfirmationButton_Click(object sender, EventArgs e)
        {
            PrintConfirmation();

        }
    }
}


