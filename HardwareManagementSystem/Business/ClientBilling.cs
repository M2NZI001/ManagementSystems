using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareManagementSystem.Business
{
    internal class ClientBilling
    {
        public int BillID { get; set; }
        public string Item {  get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public decimal TotalAmount {  get; set; }

    }
}
