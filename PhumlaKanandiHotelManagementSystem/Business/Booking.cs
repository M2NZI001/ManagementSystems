using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhumlaKanandiHotelManagementSystem.Business
{
    internal class Booking
    {
        public int BookingID { get; set; }
        public int GuestID { get; set; }
        public int RoomID { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public Booking(int bookingID, int guestID, int roomID, DateTime checkInDate, DateTime checkOutDate)
        {
            BookingID = bookingID;
            GuestID = guestID;
            RoomID = roomID;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
        }
        public Booking() { }

        public int CalculateTotalStay()
        {
            return (CheckOutDate - CheckInDate).Days;
        }

        public decimal CalculateSeasonalRate(Room room)
        {
            decimal roomPrice = 0;
            for (DateTime date = CheckInDate; date < CheckOutDate; date = date.AddDays(1)) // Use CheckInDate and CheckOutDate from the current instance
            {
                if (date.Month == 12)
                {
                    if (date.Day >= 1 && date.Day <= 7)
                    {
                        roomPrice += 550;  // Low Season
                    }
                    else if (date.Day >= 8 && date.Day <= 15)
                    {
                        roomPrice += 750;  // Mid Season
                    }
                    else if (date.Day >= 16 && date.Day <= 31)
                    {
                        roomPrice += 995;  // High Season
                    }
                }
                else
                {
                    roomPrice += room.PricePerNight;  // Default price for non-seasonal periods
                }
            }
            return roomPrice;

        }

        // Check if the deposit has been paid 14 days before arrival
        public bool IsDepositDue(DateTime currentDate)
        {
            return (CheckInDate - currentDate).Days >= 14;
        }

        public override string ToString()
        {
            return $"Booking ID: {BookingID}, Guest: {GuestID}, Room: {RoomID}, Check-In: {CheckInDate}, Check-Out: {CheckOutDate}";
        }
    }
}
