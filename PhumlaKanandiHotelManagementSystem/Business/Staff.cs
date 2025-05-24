using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhumlaKanandiHotelManagementSystem.Business
{
    internal class Staff : Person
    {
        public int StaffID { get; set; }
        public string Role { get; set; }

        public Staff(int staffID, string firstName, string lastName, string email, string phone, string address, string role)
            : base(firstName, lastName, email, phone, address)
        {
            StaffID = staffID;
            Role = role;
        }



        public override string ToString()
        {
            return $"Staff ID: {StaffID}, Name: {FirstName} {LastName}, Role: {Role}, Contact: {Phone}, Email: {Email}";
        }
    }
}
