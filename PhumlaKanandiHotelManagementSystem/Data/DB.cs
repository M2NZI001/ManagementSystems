using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using PhumlaKanandiHotelManagementSystem.Properties; // Ensure you add the correct namespace for Settings

namespace PhumlaKanandiHotelManagementSystem.Data
{
    internal class DB
    {
        #region Fields
        protected string connectionString;
        protected SqlConnection connection;
        protected SqlDataAdapter adapter;
        protected SqlCommandBuilder commandBuilder;
        #endregion

        #region Constructors
        public DB(string connectionString)
        {
            this.connectionString = connectionString;
            connection = new SqlConnection(connectionString);
        }

        //connect to the static string
        public DB()
        {
            this.connectionString = DatabaseHelper.ConnectionString;
            connection = new SqlConnection(connectionString);
        }
        #endregion

        #region Methods
        public DataSet ExecuteQuery(string sqlQuery)
        {
            using (adapter = new SqlDataAdapter(sqlQuery, connection))
            {
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                return dataSet;
            }
        }

        public int ExecuteNonQuery(string sqlCommand)
        {
            using (SqlCommand command = new SqlCommand(sqlCommand, connection))
            {
                connection.Open();
                int result = command.ExecuteNonQuery();
                connection.Close();
                return result;
            }
        }
        #endregion
    }
}
