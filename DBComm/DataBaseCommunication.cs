using System;
using System.Data.SqlClient;
using System.Data;
using DataLayerInterfaces;

/*
 * This class implements an interface and creates a database connection to a SQL database hosted on Azure. 
 * It has methods inherited from the IDatabase that uses an open connection method, 2 generic methods 
 * to either retrieve information or manipulate the database.
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
    public class DataBaseCommunication : IDatabase, IDisposable
    {
        // CONSTANT for storing the connection string
        private const string CONNECTION_STRING = @"Server=tcp:irl-data-server.database.windows.net,1433;Initial Catalog=Azure_SQL_IRL_ScenarioData;Persist Security Info=False;User ID=IRL_admin;Password=1RLdatA2;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        // instance variables
        private SqlConnection conn = new SqlConnection(CONNECTION_STRING);
        private SqlCommand cmd = null;

        // method to open the connection
        private SqlConnection OpenConnection()
        {
            // check it the state of the connection is closed or broken
            if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
            {
                // if it is reopen it
                conn.Open();
            }

            // return the connection
            return conn;
        }

        // inherited interface method to SELECT data from the database
        public DataTable Select(string selectQuery)
        {
            // make a call to DB and store the resulting datatable in datatable variable
            DataTable resultsDT = ExecuteReaderOnDB(selectQuery);

            // return resulting datatable
            return resultsDT;
        }

        // inherited interface method to UPDATE a table in the database
        public int Update(string updateQuery)
        {
            // make a call to DB and store the the number of rows affected
            int rowsAffected = ExecuteNonQueryOnDB(updateQuery);

            // return resulting number of rows affected
            return rowsAffected;
        }

        // inherited interface method to INSERT into a table in the database
        public int Insert(string insertQuery)
        {
            // make a call to DB and store the the number of rows affected
            int rowsAffected = ExecuteNonQueryOnDB(insertQuery);

            // return resulting number of rows affected
            return rowsAffected;
        }

        // inherited interface method to DELETE from a table in the database
        public int Delete(string deleteQuery)
        {
            // make a call to DB and store the the number of rows affected
            int rowsAffected = ExecuteNonQueryOnDB(deleteQuery);

            // return resulting number of rows affected
            return rowsAffected;
        }

        // private method to ExecuteReaderOnDB on the database used by the interface methods above
        private DataTable ExecuteReaderOnDB(String selectQuery)
        {
            // create new data table
            DataTable resultDataTable = new DataTable();

            // using the command variable create a new SQL command using the query passed in and the connection
            using (cmd = new SqlCommand(selectQuery, conn))
            {
                // open connection
                conn = OpenConnection();

                // load data table
                resultDataTable.Load(cmd.ExecuteReader());
            }

            // return DataTable results
            return resultDataTable;
        }

        // private method to ExecuteNonQueryOnDB on the database used by the interface methods above
        private int ExecuteNonQueryOnDB(String nonQuery)
        {
            // create return variable
            int rowsAffected = 0;

            // using the command variable create a new SQL command using the query passed in and the connection
            using (cmd = new SqlCommand(nonQuery, conn))
            {
                // open connection
                conn = OpenConnection();

                // ExecuteNonQuery
                rowsAffected = cmd.ExecuteNonQuery();
            }

            // return number of rows affected
            return rowsAffected;
        }

        public void Dispose()
        {
            conn.Close();
        }
    }
}