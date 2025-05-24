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
    internal class BookingDB : DB
    {

        #region Constructors
        public BookingDB(string connectionString) : base(connectionString) { }
        public BookingDB() : base() { }
        #endregion

        #region Methods
        public bool AddBooking(Booking booking)
        {
            if (IsRoomAvailable(booking.RoomID, booking.CheckInDate, booking.CheckOutDate))
            {
                RoomDB roomDB = new RoomDB(connectionString);  // Assuming RoomDB is another class that handles room data
                Room room = roomDB.GetRoomByID(booking.RoomID);  // Fetch the room details using roomID

                if (room == null)
                {
                    Console.WriteLine("Room details could not be found.");
                    return false;
                }

                decimal totalCost = booking.CalculateSeasonalRate(room);

                // Check if deposit is due at least 14 days before CheckInDate
                if (!booking.IsDepositDue(DateTime.Now))
                {
                    Console.WriteLine("Booking cannot be completed. Deposit must be paid 14 days before arrival.");
                    return false;
                }

                string insertQuery = "INSERT INTO Booking (GuestID, RoomID, CheckInDate, CheckOutDate) VALUES (@GuestID, @RoomID, @CheckInDate, @CheckOutDate)";
                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@GuestID", booking.GuestID);
                    cmd.Parameters.AddWithValue("@RoomID", booking.RoomID);
                    cmd.Parameters.AddWithValue("@CheckInDate", booking.CheckInDate);
                    cmd.Parameters.AddWithValue("@CheckOutDate", booking.CheckOutDate);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }
            }
            return false; // Room is not available
        }

        // Check room availability for the given dates
        public bool IsRoomAvailable(int roomID, DateTime checkIn, DateTime checkOut)
        {
            string selectQuery = "SELECT COUNT(*) FROM Booking WHERE RoomID = @RoomID AND ((CheckInDate < @CheckOut AND CheckOutDate > @CheckIn))";
            using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
            {
                cmd.Parameters.AddWithValue("@RoomID", roomID);
                cmd.Parameters.AddWithValue("@CheckIn", checkIn);
                cmd.Parameters.AddWithValue("@CheckOut", checkOut);

                connection.Open();
                int count = (int)cmd.ExecuteScalar();
                connection.Close();

                return count == 0; // If no conflicting bookings, room is available
            }
        }

        public decimal CalculateTotalCost(Booking booking, Room room)
        {
            return booking.CalculateSeasonalRate(room);  // Using seasonal rates
        }

        public Booking GetBookingByID(int bookingID)
        {
            string selectQuery = "SELECT * FROM Booking WHERE BookingID = @BookingID";
            using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
            {
                cmd.Parameters.AddWithValue("@BookingID", bookingID);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Booking booking = new Booking(
                            reader.GetInt32(reader.GetOrdinal("BookingID")),
                            reader.GetInt32(reader.GetOrdinal("GuestID")),
                            reader.GetInt32(reader.GetOrdinal("RoomID")),
                            reader.GetDateTime(reader.GetOrdinal("CheckInDate")),
                            reader.GetDateTime(reader.GetOrdinal("CheckOutDate"))
                        );
                        connection.Close();
                        return booking;
                    }
                }
                connection.Close();
                return null;
            }
        }



        public List<Booking> GetAllBookings()
        {
            List<Booking> bookings = new List<Booking>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Booking", connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Booking booking = new Booking(
                        reader.GetInt32(reader.GetOrdinal("BookingID")),
                        reader.GetInt32(reader.GetOrdinal("GuestID")),
                        reader.GetInt32(reader.GetOrdinal("RoomID")),
                        reader.GetDateTime(reader.GetOrdinal("CheckInDate")),
                        reader.GetDateTime(reader.GetOrdinal("CheckOutDate"))
                    );

                    bookings.Add(booking);
                }
            }
            return bookings;
        }

        public void DeleteBooking(int bookingID)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // First, delete any payments associated with the booking
                using (var deletePaymentsCommand = new SqlCommand("DELETE FROM Payment WHERE BookingID = @BookingID", connection))
                {
                    deletePaymentsCommand.Parameters.AddWithValue("@BookingID", bookingID);
                    deletePaymentsCommand.ExecuteNonQuery();
                }

                // Then, delete the booking
                using (var command = new SqlCommand("DELETE FROM Booking WHERE BookingID = @BookingID", connection))
                {
                    command.Parameters.AddWithValue("@BookingID", bookingID);
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool UpdateBooking(Booking booking)
        {
            // First check if the room is available for the new dates (excluding current booking)
            string availabilityQuery = "SELECT COUNT(*) FROM Booking " +
                                     "WHERE RoomID = @RoomID " +
                                     "AND BookingID != @BookingID " +
                                     "AND ((CheckInDate < @CheckOut AND CheckOutDate > @CheckIn))";

            using (SqlCommand cmd = new SqlCommand(availabilityQuery, connection))
            {
                cmd.Parameters.AddWithValue("@RoomID", booking.RoomID);
                cmd.Parameters.AddWithValue("@BookingID", booking.BookingID);
                cmd.Parameters.AddWithValue("@CheckIn", booking.CheckInDate);
                cmd.Parameters.AddWithValue("@CheckOut", booking.CheckOutDate);

                connection.Open();
                int count = (int)cmd.ExecuteScalar();
                connection.Close();

                if (count > 0)
                {
                    // Room is not available for these dates
                    return false;
                }
            }

            // If we get here, the room is available for the new dates
            string updateQuery = "UPDATE Booking " +
                                "SET CheckInDate = @CheckInDate, " +
                                "CheckOutDate = @CheckOutDate " +
                                "WHERE BookingID = @BookingID";

            using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
            {
                cmd.Parameters.AddWithValue("@BookingID", booking.BookingID);
                cmd.Parameters.AddWithValue("@CheckInDate", booking.CheckInDate);
                cmd.Parameters.AddWithValue("@CheckOutDate", booking.CheckOutDate);

                try
                {
                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    connection.Close();
                    return rowsAffected > 0;
                }
                catch (SqlException)
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                    return false;
                }
            }
        }

    }
    #endregion
}
