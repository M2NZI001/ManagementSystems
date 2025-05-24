using PhumlaKanandiHotelManagementSystem.Business;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace PhumlaKanandiHotelManagementSystem.Data
{
    internal class PaymentDB : DB
    {
        public PaymentDB(string connectionString) : base(connectionString) { }
        public PaymentDB() : base() { }

        #region Methods
        public void AddPayment(Payment payment)
        {
            string insertQuery = "INSERT INTO Payment (BookingID, AmountPaid, PaymentDate) VALUES (@BookingID, @AmountPaid, @PaymentDate)";
            using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
            {
                cmd.Parameters.AddWithValue("@BookingID", payment.BookingID);
                cmd.Parameters.AddWithValue("@AmountPaid", payment.AmountPaid);
                cmd.Parameters.AddWithValue("@PaymentDate", payment.PaymentDate);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public Payment GetPaymentByID(int paymentID)
        {
            string selectQuery = "SELECT * FROM Payment WHERE PaymentID = @PaymentID";
            using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
            {
                cmd.Parameters.AddWithValue("@PaymentID", paymentID);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Payment payment = new Payment(
                            reader.GetInt32(reader.GetOrdinal("PaymentID")),
                            reader.GetInt32(reader.GetOrdinal("BookingID")),
                            reader.GetDecimal(reader.GetOrdinal("AmountPaid")),
                            reader.GetDateTime(reader.GetOrdinal("PaymentDate"))
                        );
                        connection.Close();
                        return payment;
                    }
                }
                connection.Close();
                return null;
            }
        }

        public List<Payment> GetAllPayments()
        {
            List<Payment> payments = new List<Payment>();
            string selectQuery = "SELECT * FROM Payment";
            using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Payment payment = new Payment(
                            reader.GetInt32(reader.GetOrdinal("PaymentID")),
                            reader.GetInt32(reader.GetOrdinal("BookingID")),
                            reader.GetDecimal(reader.GetOrdinal("AmountPaid")),
                            reader.GetDateTime(reader.GetOrdinal("PaymentDate"))
                        );
                        payments.Add(payment);
                    }
                }
                connection.Close();
            }
            return payments;
        }
        #endregion
    }
}
