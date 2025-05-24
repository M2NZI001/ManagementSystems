using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhumlaKanandiHotelManagementSystem.Business
{
    internal class Payment
    {
        public int PaymentID { get; set; }
        public int BookingID { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; }

        public Payment(int paymentID, int bookingID, decimal amountPaid, DateTime paymentDate)
        {
            PaymentID = paymentID;
            BookingID = bookingID;
            AmountPaid = amountPaid;
            PaymentDate = paymentDate;
        }

        public bool ValidatePayment(decimal totalAmount)
        {
            return AmountPaid >= totalAmount;
        }

        public override string ToString()
        {
            return $"Payment ID: {PaymentID}, Booking: {BookingID}, Amount: {AmountPaid:C}, Date: {PaymentDate}";
        }
    }
}

