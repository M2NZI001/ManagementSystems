using Microsoft.Reporting.WinForms;
using PhumlaKanandiHotelManagementSystem.Data;
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
    public partial class OccupancyReport : Form
    {
        private string connectionString;
        public OccupancyReport(string connString)
        {
            InitializeComponent();
            connectionString = connString;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;

            ReportDB reportDB = new ReportDB(connectionString);
            DataSet reportData = reportDB.GenerateOccupancyReport(startDate, endDate);

            // Check if there is data to bind
            if (reportData != null && reportData.Tables.Count > 0 && reportData.Tables["OccupancyReport"].Rows.Count > 0)
            {
                // Bind data to DataGridView
                dataGridView1.DataSource = reportData.Tables["OccupancyReport"];

                // Create a new report viewer and set its processing mode
                ReportViewer reportViewer = new ReportViewer();
                reportViewer.ProcessingMode = ProcessingMode.Local;

                // Load the RDLC report
                reportViewer.LocalReport.ReportPath = "Path/To/Your/OccupancyReport.rdlc";

                // Create a ReportDataSource
                ReportDataSource reportDataSource = new ReportDataSource("OccupancyDataSet", reportData.Tables["OccupancyReport"]);

                // Clear any existing data sources and add the new one
                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.LocalReport.DataSources.Add(reportDataSource);

                // Refresh the report
                reportViewer.RefreshReport();

                // Display the ReportViewer in your form
                Form reportForm = new Form();
                reportForm.Controls.Add(reportViewer);
                reportViewer.Dock = DockStyle.Fill; // Fill the form with the report
                reportForm.ShowDialog(); // Show the form modally
            }
            else
            {
                MessageBox.Show("No data available for the selected dates.");
            }
        }

        private void OccupancyReport_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
