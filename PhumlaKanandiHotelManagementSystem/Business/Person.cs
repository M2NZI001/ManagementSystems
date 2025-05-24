using PhumlaKanandiHotelManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace PhumlaKanandiHotelManagementSystem.Business
{
    internal class Person
    {
        #region Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        #endregion

        #region Constructors
        public Person()
        {
            FirstName = "";
            LastName = "";
            Email = "";
            Phone = "";
            Address = "";
        }

        public Person(string firstName, string lastName, string email, string phone, string address)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Address = address;
        }
        #endregion

        #region ToStringMethod
        public override string ToString()
        {
            return $"{FirstName} {LastName}, Contact: {Phone}";
        }
        #endregion
    }
}
