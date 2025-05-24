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
    public partial class GenerateReportForm : Form
    {
        private string connectionString;
        public GenerateReportForm()
        {
            InitializeComponent();
        }

        private void GenerateReportForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Instantiate the OccupancyReport form, passing the connection string
            OccupancyReport occupancyReport = new OccupancyReport(connectionString);

            // Show the OccupancyReport form
            occupancyReport.ShowDialog();

        }
    }
}
