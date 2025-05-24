using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace PhumlaKanandiHotelManagementSystem.Business
{
    internal class Guest : Person
    {
        public int GuestID { get; set; }

        public Guest(int guestID, string firstName, string lastName, string email, string phone, string address)
            : base(firstName, lastName, email, phone, address)
        {
            GuestID = guestID;
        }

        public void UpdateContactDetails(string phone, string email)
        {
            Phone = phone;
            Email = email;
        }

        public override string ToString()
        {
            return $"Guest ID: {GuestID}, Name: {FirstName} {LastName}, Contact: {Phone}, Email: {Email}";
        }
    }
}
