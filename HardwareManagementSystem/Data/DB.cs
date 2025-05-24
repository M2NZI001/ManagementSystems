using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace HardwareManagementSystem.Data
{
    internal class DB
    {
        #region fields
        protected string ConnectionString;
        protected SqlConnection connection;
        protected SqlDataAdapter adapter;
        protected SqlCommandBuilder commandBuilder;
        #endregion

        #region constructor
        public DB(string connectionString) 
        { 
            this.ConnectionString = connectionString;
            connection = new SqlConnection(connectionString);
        }

        public DB() 
        {
            this.ConnectionString = DatabaseConnector.ConnectionString;
            connection = new SqlConnection(ConnectionString);
        }
        #endregion
    }
}
