using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Classes;
using System.Collections;

/*
 * This class creates a database connection to an Access database and has various methods 
 * to retrieve information or manipulate the database.
 *
 * author: Group 7 (Stephen Bailey, Omar Garcia, Craig Wyse, Matthew Harris)
 * course: SEII
 * assignment: InRealLife (Group Project Spring 2018)
 * date: 03/20/2018
 * file name: DBComm.cs
 * version: 1.0
 */
namespace InRealLife_2
{
    public class DBComm
    {
        // CONSTANT storing the connection string
        public const string connectionString = @"Server=tcp:irl-data-server.database.windows.net,1433;Initial Catalog=Azure_SQL_IRL_ScenarioData;Persist Security Info=False;User ID=IRL_admin;Password=1RLdatA2;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        // create new connection
        SqlConnection conn = new SqlConnection(connectionString);

        // method to grab all data from scenario table on the database
        public DataTable DisplayAllScenarios()
        {
            // create new data table
            DataTable scenarioDataTable = new DataTable();

            // query string to display scenarios
            String displayScenariosQuery = "SELECT * FROM Scenario";

            using (conn)
            using (SqlCommand sqlCommand = new SqlCommand(displayScenariosQuery, conn))
            {
                // reinitialize connection string
                conn.ConnectionString = connectionString;

                // open connection
                conn.Open();

                // load data table
                scenarioDataTable.Load(sqlCommand.ExecuteReader());

                return scenarioDataTable;
            }
        }

        // method to delete a scenario from scenario table on the database
        public int DeleteSelectedScenario(int scenarioID)
        {
            // create return variable
            int scenarioRowsDeleted = 0;

            // set DELETE query string
            String deleteQuery = "DELETE * FROM Scenario WHERE ID =" + scenarioID;
            
            using (conn)
            using (SqlCommand DeleteCmd = new SqlCommand(deleteQuery, conn))
            {
                // reinitialize connection string
                conn.ConnectionString = connectionString;

                // open connection
                conn.Open();

                // execute deletion
                scenarioRowsDeleted = DeleteCmd.ExecuteNonQuery();

                // return number of rows deleted
                return scenarioRowsDeleted;
            }
        }
    }
}