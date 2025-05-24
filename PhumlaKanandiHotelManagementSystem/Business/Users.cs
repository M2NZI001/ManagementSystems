using PhumlaKanandiHotelManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace PhumlaKanandiHotelManagementSystem.Business
{
    internal class Users
    {
        public int UserID { get; set; }
        public int StaffID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Users(int userID, int staffID, string username, string password)
        {
            UserID = userID;
            StaffID = staffID;
            Username = username;
            Password = password;
        }

        public override string ToString()
        {
            return $"User ID: {UserID}, Staff ID: {StaffID}, Username: {Username}";
        }
    }
}
