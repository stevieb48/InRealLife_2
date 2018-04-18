using System;
using System.Data.SqlClient;
using System.Data;
using DataLayerInterfaces;

/*
 * This class implements an interface and creates a database connection to a SQL database hosted on Azure. 
 * It has methods inherited from the IDatabase that uses 2 generic methods to either retrieve information
 * or manipulate the database.
 *
 * author: Group 7 (Stephen Bailey, Omar Garcia, Craig Wyse, Matthew Harris)
 * course: SEII
 * assignment: InRealLife (Group Project Spring 2018)
 * date: 03/20/2018
 * file name: DataBaseCommunication.cs
 * version: 1.0
 */
namespace DataLayer
{
    //
    public class DataBaseCommunication : IDatabase
    {
        // CONSTANT for storing the connection string
        private const string CONNECTION_STRING = @"Server=tcp:irl-data-server.database.windows.net,1433;Initial Catalog=Azure_SQL_IRL_ScenarioData;Persist Security Info=False;User ID=IRL_admin;Password=1RLdatA2;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        // instance variables
        private SqlConnection conn = new SqlConnection(CONNECTION_STRING);
        private SqlCommand cmd = null;

        // Auto Implemented Property
        //public SqlConnection Conn { get; set; }
        //public SqlConnection Cmd { get; set; }

        // method to open the connection
        private SqlConnection OpenConnection()
        {
            if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
            {
                conn.Open();
            }
            return conn;
        }       

        // inherited interface method to SELECT from the database
        public DataTable Select(string selectQuery)
        {
            DataTable resultsDT = ExecuteReaderOnDB(selectQuery);

            return resultsDT;
        }

        // inherited interface method to UPDATE a table in the database
        public int Update(string updateQuery)
        {
            int rowsAffected = ExecuteNonQueryOnDB(updateQuery);

            return rowsAffected;
        }

        // inherited interface method to INSERT into a table in the database
        public int Insert(string insertQuery)
        {
            int rowsAffected = ExecuteNonQueryOnDB(insertQuery);

            return rowsAffected;
        }

        // inherited interface method to DELETE from a table in the database
        public int Delete(string deleteQuery)
        {
            int rowsAffected = ExecuteNonQueryOnDB(deleteQuery);

            return rowsAffected;
        }

        // private method to ExecuteReaderOnDB on the database used by the interface methods above
        private DataTable ExecuteReaderOnDB(String selectQuery)
        {
            // create new data table
            DataTable resultDataTable = new DataTable();

            using (cmd = new SqlCommand(selectQuery, conn))
            {
                // reinitialize connection string
                //conn.ConnectionString = CONNECTION_STRING;

                // open connection
                conn = OpenConnection();

                // load data table
                resultDataTable.Load(cmd.ExecuteReader());

                // return resultsDataTable
                return resultDataTable;
            }
        }

        // private method to ExecuteNonQueryOnDB on the database used by the interface methods above
        private int ExecuteNonQueryOnDB(String nonQuery)
        {
            // create return variable
            int rowsAffected = 0;

            using (cmd = new SqlCommand(nonQuery, conn))
            {
                // reinitialize connection string
                //conn.ConnectionString = CONNECTION_STRING;

                // open connection
                conn = OpenConnection();

                // ExecuteNonQuery
                rowsAffected = cmd.ExecuteNonQuery();

                // return number of rows affected
                return rowsAffected;
            }
        }
    }
}