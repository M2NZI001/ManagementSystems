using PhumlaKanandiHotelManagementSystem.Data;
using PhumlaKanandiHotelManagementSystem.Business;
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
    public partial class AdminRooms : UserControl
    {
        private RoomDB roomDB;
        private List<Room> allRooms;
        private int currentGuestID;

        #region Constructors
        // Constructor
        public AdminRooms()
        {
            InitializeComponent();
            //string connectionString = Properties.Settings.Default.HotelDatabaseConnectionString;
            //roomDB = new RoomDB(connectionString);
            roomDB = new RoomDB();


            LoadRoomData(); // Load room data upon initialization
        }
        #endregion

        #region Control Initialization
        // Method to set the current guest ID
        public void SetCurrentGuestID(int guestID)
        {
            currentGuestID = guestID; // Store current guest ID
        }
        #endregion

        #region Data Loading
        // Load room data from the database
        private void LoadRoomData()
        {
            try
            {
                allRooms = roomDB.GetAllRooms(); // Retrieve all rooms

                // Define seasonal rates
                var seasonalRates = new Dictionary<string, decimal>
                {
                    { "Low Season", 550m },
                    { "Mid Season", 750m },
                    { "High Season", 995m }
                };

                // Get the current season
                string currentSeason = GetCurrentSeason();
                decimal currentSeasonPrice;

                // Check if the current season exists in the seasonal rates
                if (!seasonalRates.TryGetValue(currentSeason, out currentSeasonPrice))
                {
                    MessageBox.Show($"Season '{currentSeason}' is not defined in seasonal rates.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Exit or handle the situation accordingly
                }

                // Update the DataGridView with rooms and their prices based on the current season
                dataGridView_Rooms.DataSource = allRooms.Select(room => new
                {
                    room.RoomID,
                    room.RoomNumber,
                    room.RoomType,
                    PricePerNight = currentSeasonPrice, // Set based on dynamic current season price
                    room.AvailabilityStatus
                }).ToList();

                CustomizeDataGridView(); // Customize DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading room data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // Customize DataGridView columns
        private void CustomizeDataGridView()
        {
            dataGridView_Rooms.AutoGenerateColumns = false; // Disable auto-generate
            dataGridView_Rooms.Columns.Clear(); // Clear existing columns

            // Add columns to DataGridView
            dataGridView_Rooms.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "RoomID",
                HeaderText = "Room ID",
                Name = "RoomID",
                ReadOnly = true
            });

            dataGridView_Rooms.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "RoomNumber",
                HeaderText = "Room Number",
                Name = "RoomNumber"
            });

            dataGridView_Rooms.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "RoomType",
                HeaderText = "Room Type",
                Name = "RoomType"
            });

            dataGridView_Rooms.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PricePerNight",
                HeaderText = "Price Per Night",
                Name = "PricePerNight",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            dataGridView_Rooms.Columns.Add(new DataGridViewCheckBoxColumn
            {
                DataPropertyName = "AvailabilityStatus",
                HeaderText = "Available",
                Name = "AvailabilityStatus"
            });
        }
        #endregion

        #region Room Management
        // Update room information in the database
        private void UpdateRoom(Room room)
        {
            try
            {
                roomDB.UpdateRoom(room); // Update room
                MessageBox.Show("Room updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRoomData(); // Reload room data
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating room: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Handle cell edit completion in DataGridView
        private void dataGridView_Rooms_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_Rooms.Rows[e.RowIndex];
                Room updatedRoom = new Room(
                    Convert.ToInt32(row.Cells["RoomID"].Value),
                    Convert.ToInt32(row.Cells["RoomNumber"].Value),
                    row.Cells["RoomType"].Value.ToString(),
                    Convert.ToDecimal(row.Cells["PricePerNight"].Value),
                    Convert.ToBoolean(row.Cells["AvailabilityStatus"].Value)
                );
                UpdateRoom(updatedRoom); // Update the room
            }
        }

        // Filter rooms based on selected criteria
        private void btnAdd_rooms_Click(object sender, EventArgs e)
        {
            if (allRooms == null)
            {
                MessageBox.Show("No room data available. Please try reloading the data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectedRoomType = roomType_rooms.SelectedItem?.ToString();
            string selectedAvailability = roomStatus_rooms.SelectedItem?.ToString();
            string roomIdInput = txtRoomID_rooms.Text.Trim(); 

            List<Room> filteredRooms = new List<Room>(allRooms);

            // Filter by Room ID if provided
            if (!string.IsNullOrEmpty(roomIdInput) && int.TryParse(roomIdInput, out int roomID))
            {
                filteredRooms = filteredRooms.Where(r => r.RoomID == roomID).ToList();
            }

            // Filter by Room Type if selected
            if (!string.IsNullOrEmpty(selectedRoomType))
            {
                filteredRooms = filteredRooms.Where(r => r.RoomType == selectedRoomType).ToList();
            }

            // Filter by Availability if selected
            if (!string.IsNullOrEmpty(selectedAvailability))
            {
                bool isAvailable = selectedAvailability == "Available";
                filteredRooms = filteredRooms.Where(r => r.AvailabilityStatus == isAvailable).ToList();
            }

            // Get the current season price again
            string currentSeason = GetCurrentSeason();
            decimal currentSeasonPrice;

            // Define seasonal rates
            var seasonalRates = new Dictionary<string, decimal>
    {
        { "Low Season", 550m },
        { "Mid Season", 750m },
        { "High Season", 995m }
    };

            // Check if the current season exists in the seasonal rates
            if (!seasonalRates.TryGetValue(currentSeason, out currentSeasonPrice))
            {
                MessageBox.Show($"Season '{currentSeason}' is not defined in seasonal rates.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit or handle the situation accordingly
            }

            // Update the DataGridView with filtered rooms and their prices based on the current season
            dataGridView_Rooms.DataSource = filteredRooms.Select(room => new
            {
                room.RoomID,
                room.RoomNumber,
                room.RoomType,
                PricePerNight = currentSeasonPrice, // Set based on dynamic current season price
                room.AvailabilityStatus
            }).ToList();

            CustomizeDataGridView(); // Customize DataGridView

            // Check if filtered rooms is empty and show a message
            if (!filteredRooms.Any())
            {
                MessageBox.Show("No matching rooms found. Please adjust your search criteria.", "No Matches", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        // Handle room booking
        private void btnBook_rooms_Click(object sender, EventArgs e)
        {
            if (dataGridView_Rooms.SelectedRows.Count > 0)
            {
                int selectedRoomID = Convert.ToInt32(dataGridView_Rooms.SelectedRows[0].Cells["RoomID"].Value);

                // Check if the selected room is available for booking
                Room selectedRoom = allRooms.FirstOrDefault(r => r.RoomID == selectedRoomID);
                if (selectedRoom != null)
                {
                    if (!selectedRoom.AvailabilityStatus)
                    {
                        MessageBox.Show("This room is currently occupied and cannot be booked.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Exit or handle the situation accordingly
                    }

                    // Proceed with booking if the room is available
                    AdminMainForm adminMainForm = this.ParentForm as AdminMainForm;
                    if (adminMainForm != null)
                    {
                        adminMainForm.ShowReservationsControl(currentGuestID, selectedRoomID); // Show reservations control
                    }
                }
                else
                {
                    MessageBox.Show("The selected room could not be found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select a room to proceed with the booking.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion



        // Handle cell content click event
        private void dataGridView_Rooms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Retrieve data from the clicked cell
                int roomID = Convert.ToInt32(dataGridView_Rooms.Rows[e.RowIndex].Cells["RoomID"].Value);
                string roomNumber = dataGridView_Rooms.Rows[e.RowIndex].Cells["RoomNumber"].Value.ToString();
                decimal roomPrice = Convert.ToDecimal(dataGridView_Rooms.Rows[e.RowIndex].Cells["PricePerNight"].Value); // Retrieve room price

              
                // Display or process room details as needed
                MessageBox.Show($"You clicked on Room ID: {roomID} - Room Number: {roomNumber}", "Room Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void clearButton_Click(object sender, EventArgs e)
        {
            // Clear all text boxes
            txtRoomID_rooms.Clear();
            txtRoomNum_rooms.Clear();

            // Reset the room type dropdown to its original default value (first item or empty)
            roomType_rooms.SelectedIndex = -1; // Reset

            // Reset the room status dropdown to its original default value (first item or empty)
            roomStatus_rooms.SelectedIndex = -1; // Reset

            // Clear DataGridView selection
            dataGridView_Rooms.ClearSelection();

            // Reload room data to show all rooms without filtering
            LoadRoomData();
        }

        private string GetCurrentSeason()
        {
            // Get today's date
            DateTime today = DateTime.Today;

            // Define the start and end dates for each season
            DateTime lowSeasonStart = new DateTime(today.Year, 12, 1);
            DateTime lowSeasonEnd = new DateTime(today.Year, 12, 7);

            DateTime midSeasonStart = new DateTime(today.Year, 12, 8);
            DateTime midSeasonEnd = new DateTime(today.Year, 12, 15);

            DateTime highSeasonStart = new DateTime(today.Year, 12, 16);
            DateTime highSeasonEnd = new DateTime(today.Year, 12, 31);

            // Check the current date against the defined seasons
            if (today >= lowSeasonStart && today <= lowSeasonEnd)
            {
                return "Low Season"; // December 1 - 7
            }
            else if (today >= midSeasonStart && today <= midSeasonEnd)
            {
                return "Mid Season"; // December 8 - 15
            }
            else if (today >= highSeasonStart && today <= highSeasonEnd)
            {
                return "High Season"; // December 16 - 31
            }

            // If none of the conditions are met, return a default value
            return "Low Season"; // Fallback to a defined season
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void backButtonAdminReservations_Click(object sender, EventArgs e)
        {
            
        }
    }
}


