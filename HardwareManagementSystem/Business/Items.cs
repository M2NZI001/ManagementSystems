using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareManagementSystem.Business
{
    internal class Items
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string ItemCategory { get; set; }
        public decimal ItemPrice { get; set; }
        public int ItemStock { get; set; }
        public string Manufacture { get; set; }
    }
}
