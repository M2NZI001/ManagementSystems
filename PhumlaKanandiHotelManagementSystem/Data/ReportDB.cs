using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhumlaKanandiHotelManagementSystem.Data
{
    internal class ReportDB : DB
    {
        #region Constructors
        public ReportDB(string connectionString) : base(connectionString) { }
        public ReportDB() : base() { }
        #endregion

        #region Methods
        public DataSet GenerateOccupancyReport(DateTime startDate, DateTime endDate)
        {
            string reportQuery = @"
    SELECT 
        r.RoomNumber, 
        r.RoomType,  -- Include RoomType in the query results
        CASE 
            WHEN b.BookingID IS NOT NULL AND b.CheckInDate <= @EndDate AND b.CheckOutDate >= @StartDate THEN 'Occupied' 
            ELSE 'Available' 
        END AS OccupancyStatus,
        b.CheckInDate, 
        b.CheckOutDate
    FROM Room r
    LEFT JOIN Booking b ON r.RoomID = b.RoomID
    WHERE (b.CheckInDate BETWEEN @StartDate AND @EndDate 
           OR b.CheckOutDate BETWEEN @StartDate AND @EndDate
           OR (b.CheckInDate < @StartDate AND b.CheckOutDate > @EndDate))
    ORDER BY r.RoomNumber";

            using (SqlCommand cmd = new SqlCommand(reportQuery, connection))
            {
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataSet occupancyReport = new DataSet();

                    // Add RoomType to the DataTable schema
                    DataTable table = new DataTable("OccupancyReport");
                    table.Columns.Add("RoomNumber", typeof(string));
                    table.Columns.Add("RoomType", typeof(string));  // Ensure RoomType is included here
                    table.Columns.Add("OccupancyStatus", typeof(string));
                    table.Columns.Add("CheckInDate", typeof(DateTime));
                    table.Columns.Add("CheckOutDate", typeof(DateTime));

                    // Fill the DataTable with data from the query
                    adapter.Fill(occupancyReport, "OccupancyReport");

                    return occupancyReport;
                }

            }
        }

        public DataSet GenerateRevenueReport(DateTime startDate, DateTime endDate)
        {
            string reportQuery = @"
            SELECT r.RoomType, 
                   COUNT(b.RoomID) AS TotalOccupiedRooms
            FROM Room r
            LEFT JOIN Booking b ON r.RoomID = b.RoomID
            WHERE (b.CheckInDate BETWEEN @StartDate AND @EndDate 
                   OR b.CheckOutDate BETWEEN @StartDate AND @EndDate)
            GROUP BY r.RoomType
            ORDER BY r.RoomType";

            using (SqlCommand cmd = new SqlCommand(reportQuery, connection))
            {
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataSet occupancyReport = new DataSet();
                    adapter.Fill(occupancyReport, "OccupancyReport");
                    return occupancyReport;
                }
            }
        }
        #endregion
    }
}
