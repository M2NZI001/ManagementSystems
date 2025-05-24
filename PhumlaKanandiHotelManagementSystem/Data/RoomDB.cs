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
    internal class RoomDB : DB
    {
        #region Constructors
        public RoomDB(string connectionString) : base(connectionString) { }
        public RoomDB() : base() { }
        #endregion

        #region Methods
        // Method to get a Room by its RoomID
        public Room GetRoomByID(int roomID)
        {
            string selectQuery = "SELECT * FROM Room WHERE RoomID = @RoomID";
            using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
            {
                cmd.Parameters.AddWithValue("@RoomID", roomID);
                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Room room = new Room(
                            reader.GetInt32(reader.GetOrdinal("RoomID")),
                            reader.GetInt32(reader.GetOrdinal("RoomNumber")),
                            reader.GetString(reader.GetOrdinal("RoomType")),
                            reader.GetDecimal(reader.GetOrdinal("PricePerNight")),
                            reader.GetBoolean(reader.GetOrdinal("AvailabilityStatus"))
                        );
                        connection.Close();
                        return room;
                    }
                }
                connection.Close();
            }
            return null; // Return null if room is not found
        }

        public List<Room> GetAllRooms()
        {
            List<Room> allRooms = new List<Room>();
            string selectQuery = "SELECT * FROM Room";  // Query to get all rooms

            using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Room room = new Room(
                            reader.GetInt32(reader.GetOrdinal("RoomID")),
                            reader.GetInt32(reader.GetOrdinal("RoomNumber")),
                            reader.GetString(reader.GetOrdinal("RoomType")),
                            reader.GetDecimal(reader.GetOrdinal("PricePerNight")),
                            reader.GetBoolean(reader.GetOrdinal("AvailabilityStatus")) // Fetch as bool
                        );
                        allRooms.Add(room);
                    }
                }
                connection.Close();
            }
            return allRooms;
        }

        public List<Room> GetAvailableRooms()
        {
            List<Room> availableRooms = new List<Room>();
            string selectQuery = "SELECT * FROM Room WHERE IsAvailable = 1";
            using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Room room = new Room(
                            reader.GetInt32(reader.GetOrdinal("RoomID")),
                            reader.GetInt32(reader.GetOrdinal("RoomNumber")),
                            reader.GetString(reader.GetOrdinal("RoomType")),
                            reader.GetDecimal(reader.GetOrdinal("PricePerNight")),
                            reader.GetBoolean(reader.GetOrdinal("AvailabilityStatus"))
                        );
                        availableRooms.Add(room);
                    }
                }
                connection.Close();
            }
            return availableRooms;
        }

        public void UpdateRoom(Room room)
        {
            string updateQuery = "UPDATE Room SET RoomNumber = @RoomNumber, RoomType = @RoomType, PricePerNight = @PricePerNight, AvailabilityStatus = @AvailabilityStatus WHERE RoomID = @RoomID";
            using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
            {
                cmd.Parameters.AddWithValue("@RoomID", room.RoomID);
                cmd.Parameters.AddWithValue("@RoomNumber", room.RoomNumber);
                cmd.Parameters.AddWithValue("@RoomType", room.RoomType);
                cmd.Parameters.AddWithValue("@PricePerNight", room.PricePerNight);
                cmd.Parameters.AddWithValue("@AvailabilityStatus", room.AvailabilityStatus); // Now should be a bool

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }



        #endregion
    }
}
