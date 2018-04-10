using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections;
using DBComm;

/*
 * This class implements an interface and creates a database connection to a SQL database hosted on Azure. It has various methods 
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
    public class DBComm : IDatabase
    {
        // CONSTANT storing the connection string
        private const string CONNECTION_STRING = @"Server=tcp:irl-data-server.database.windows.net,1433;Initial Catalog=Azure_SQL_IRL_ScenarioData;Persist Security Info=False;User ID=IRL_admin;Password=1RLdatA2;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        // instance variables
        public SqlConnection conn = new SqlConnection(CONNECTION_STRING);
        public SqlCommand cmd = null;

        // Auto Implemented Property
        public SqlConnection Conn { get; set; }
        public SqlConnection Cmd { get; set; }

        public SqlConnection OpenConnection()
        {
            if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
            {
                conn.Open();
            }
            return conn;
        }

        // method to grab all data from scenario table on the database
        public DataTable DisplayAllScenarios()
        {
            // create new data table
            DataTable scenarioDataTable = new DataTable();

            // query string to display scenarios
            String displayScenariosQuery = "SELECT * " 
                                           + "FROM Scenario";

            using (conn)
            using (cmd = new SqlCommand(displayScenariosQuery, conn))
            {
                // reinitialize connection string
                conn.ConnectionString = CONNECTION_STRING;

                // open connection
                conn = OpenConnection();

                // load data table
                scenarioDataTable.Load(cmd.ExecuteReader());

                return scenarioDataTable;
            }
        }

        // method to delete a scenario from scenario table on the database
        public int DeleteSelectedScenario(int ID)
        {
            // create return variable
            int scenarioRowsDeleted = 0;

            // set DELETE query string
            String deleteScenarioQuery = "DELETE * " 
                                        + "FROM Scenario " 
                                        + "WHERE ID =" + ID;

            using (conn)
            using (cmd = new SqlCommand(deleteScenarioQuery, conn))
            {
                // reinitialize connection string
                conn.ConnectionString = CONNECTION_STRING;

                // open connection
                conn = OpenConnection();

                // execute deletion
                scenarioRowsDeleted = cmd.ExecuteNonQuery();

                // return number of rows deleted
                return scenarioRowsDeleted;
            }
        }

        // method to grab all data from stage table on the database
        public DataTable DisplayAllStages()
        {
            // create new data table
            DataTable stageDataTable = new DataTable();

            // query string to display stages
            String displayStageQuery = "SELECT * " 
                                       + "FROM Stage";

            using (conn)
            using (cmd = new SqlCommand(displayStageQuery, conn))
            {
                // reinitialize connection string
                conn.ConnectionString = CONNECTION_STRING;

                // open connection
                conn = OpenConnection();

                // load data table
                stageDataTable.Load(cmd.ExecuteReader());

                return stageDataTable;
            }
        }

        // method to delete a stage from stage table on the database
        public int DeleteSelectedStage(int ID)
        {
            // create return variable
            int stageRowsDeleted = 0;

            // set DELETE query string
            String deleteStageQuery = "DELETE * " 
                                    + "FROM Stage " 
                                    + "WHERE ID =" + ID;

            using (conn)
            using (cmd = new SqlCommand(deleteStageQuery, conn))
            {
                // reinitialize connection string
                conn.ConnectionString = CONNECTION_STRING;

                // open connection
                conn = OpenConnection();

                // execute deletion
                stageRowsDeleted = cmd.ExecuteNonQuery();

                // return number of rows deleted
                return stageRowsDeleted;
            }
        }

        // UPDATE Stage table with new scenarioID
        public int UpdateStageTableNewScenarioID(int newScenarioID, int ID)
        {
            // create return variable
            int stageRowsUpdated = 0;

            // set UPDATE query string
            String updateStageQuery = "UPDATE Stage" 
                                    + "SET ScenarioID = " + newScenarioID 
                                    + "WHERE ID = " + ID;

            using (conn)
            using (cmd = new SqlCommand(updateStageQuery, conn))
            {
                // reinitialize connection string
                conn.ConnectionString = CONNECTION_STRING;

                // open connection
                conn = OpenConnection();

                // execute UPDATE
                stageRowsUpdated = cmd.ExecuteNonQuery();

                // return number of rows updated
                return stageRowsUpdated;
            }
        }

        // method to grab all data from answer table on the database
        public DataTable DisplayAllAnswers()
        {
            // create new data table
            DataTable answerDataTable = new DataTable();

            // query string to display answer
            String displayAnswerQuery = "SELECT * " 
                                        + "FROM Answer";

            using (conn)
            using (cmd = new SqlCommand(displayAnswerQuery, conn))
            {
                // reinitialize connection string
                conn.ConnectionString = CONNECTION_STRING;

                // open connection
                conn = OpenConnection();

                // load data table
                answerDataTable.Load(cmd.ExecuteReader());

                return answerDataTable;
            }
        }

        // method to delete a answer from answer table on the database
        public int DeleteSelectedAnswer(int ID)
        {
            // create return variable
            int answerRowsDeleted = 0;

            // set DELETE query string
            String deleteAnswerQuery = "DELETE * " 
                                        + "FROM Answer " 
                                        + "WHERE ID =" + ID;

            using (conn)
            using (cmd = new SqlCommand(deleteAnswerQuery, conn))
            {
                // reinitialize connection string
                conn.ConnectionString = CONNECTION_STRING;

                // open connection
                conn = OpenConnection();

                // execute deletion
                answerRowsDeleted = cmd.ExecuteNonQuery();

                // return number of rows deleted
                return answerRowsDeleted;
            }
        }

        // UPDATE Answer table with new stageID
        public int UpdateAnswerTableNewStageID(int newStageID, int ID)
        {
            // create return variable
            int answersRowsUpdated = 0;

            // set UPDATE query string
            String updateAnswerQuery = "UPDATE Answer"
                                    + "SET StageID = " + newStageID
                                    + "WHERE ID = " + ID;

            using (conn)
            using (cmd = new SqlCommand(updateAnswerQuery, conn))
            {
                // reinitialize connection string
                conn.ConnectionString = CONNECTION_STRING;

                // open connection
                conn = OpenConnection();

                // execute UPDATE
                answersRowsUpdated = cmd.ExecuteNonQuery();

                // return number of rows updated
                return answersRowsUpdated;
            }
        }


//************************ UNDER CONSTRUCTION ****************************

        public DataTable Select(string selectQuery)
        {
            DataTable resultsDT = null;

            ExecuteReaderOnDB(selectQuery);

            return resultsDT;
        }

        public int Update(string updateQuery)
        {
            int resultsRowsAffected = 0;

            ExecuteNonQueryOnDB(updateQuery);

            return resultsRowsAffected;
        }

        public int Insert(string insertQuery)
        {
            int resultsRowsAffected = 0;

            ExecuteNonQueryOnDB(insertQuery);

            return resultsRowsAffected;

        }

        public int Delete(string deleteQuery)
        {
            int resultsRowsAffected = 0;

            ExecuteNonQueryOnDB(deleteQuery);

            return resultsRowsAffected;

        }

        // private method to ExecuteReaderOnDB on the database
        private DataTable ExecuteReaderOnDB(String selectQuery)
        {
            // create new data table
            DataTable resultDataTable = new DataTable();

            using (conn)
            using (cmd = new SqlCommand(selectQuery, conn))
            {
                // reinitialize connection string
                conn.ConnectionString = CONNECTION_STRING;

                // open connection
                conn = OpenConnection();

                // load data table
                resultDataTable.Load(cmd.ExecuteReader());

                // return resultsDataTable
                return resultDataTable;
            }
        }

        // private method to ExecuteNonQueryOnDB on the database
        private int ExecuteNonQueryOnDB(String nonQuery)
        {
            // create return variable
            int rowsAffected = 0;

            using (conn)
            using (cmd = new SqlCommand(nonQuery, conn))
            {
                // reinitialize connection string
                conn.ConnectionString = CONNECTION_STRING;

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