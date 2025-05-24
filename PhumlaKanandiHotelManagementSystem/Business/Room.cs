using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhumlaKanandiHotelManagementSystem.Business
{
    internal class Room
    {
        #region Properties
        public int RoomID { get; set; }
        public int RoomNumber { get; set; }
        public string RoomType { get; set; }
        public decimal PricePerNight { get; set; }
        public bool AvailabilityStatus { get; set; }
        #endregion

        #region Constructors
        public Room(int roomID, int roomNumber, string roomType, decimal pricePerNight, bool isAvailable)
        {
            RoomID = roomID;
            RoomNumber = roomNumber;
            RoomType = roomType;
            PricePerNight = pricePerNight;
            AvailabilityStatus = isAvailable;
        }
        #endregion

        #region Methods
        public void UpdateAvailability(bool isAvailable)
        {
            AvailabilityStatus = isAvailable;
        }

        public override string ToString()
        {
            return $"Room {RoomNumber} ({RoomType}), Price: {PricePerNight:C}, Available: {AvailabilityStatus}";
        }
        #endregion



    }
}
