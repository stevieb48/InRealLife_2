using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections;

/*
 * This class creates a database connection to a SQL database hosted on Azure. It has various methods 
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
        public const string CONNECTION_STRING = @"Server=tcp:irl-data-server.database.windows.net,1433;Initial Catalog=Azure_SQL_IRL_ScenarioData;Persist Security Info=False;User ID=IRL_admin;Password=1RLdatA2;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        // Auto Implemented Property
        public SqlConnection Conn { get; set; }

        //
        public DBComm()
        {
            this.Conn = new SqlConnection(CONNECTION_STRING);
        }

        public SqlConnection OpenConnection()
        {
            if (Conn.State == ConnectionState.Closed || Conn.State == ConnectionState.Broken)
            {
                Conn.Open();
            }
            return Conn;
        }

        // method to grab all data from scenario table on the database
        public DataTable DisplayAllScenarios()
        {
            // create new data table
            DataTable scenarioDataTable = new DataTable();

            // query string to display scenarios
            String displayScenariosQuery = "SELECT * " 
                                           + "FROM Scenario";

            using (Conn)
            using (SqlCommand sqlCommand = new SqlCommand(displayScenariosQuery, Conn))
            {
                // reinitialize connection string
                Conn.ConnectionString = CONNECTION_STRING;

                // open connection
                Conn.Open();

                // load data table
                scenarioDataTable.Load(sqlCommand.ExecuteReader());

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

            using (Conn)
            using (SqlCommand DeleteCmd = new SqlCommand(deleteScenarioQuery, Conn))
            {
                // reinitialize connection string
                Conn.ConnectionString = CONNECTION_STRING;

                // open connection
                Conn.Open();

                // execute deletion
                scenarioRowsDeleted = DeleteCmd.ExecuteNonQuery();

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

            using (Conn)
            using (SqlCommand sqlCommand = new SqlCommand(displayStageQuery, Conn))
            {
                // reinitialize connection string
                Conn.ConnectionString = CONNECTION_STRING;

                // open connection
                Conn.Open();

                // load data table
                stageDataTable.Load(sqlCommand.ExecuteReader());

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

            using (Conn)
            using (SqlCommand DeleteCmd = new SqlCommand(deleteStageQuery, Conn))
            {
                // reinitialize connection string
                Conn.ConnectionString = CONNECTION_STRING;

                // open connection
                Conn.Open();

                // execute deletion
                stageRowsDeleted = DeleteCmd.ExecuteNonQuery();

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

            using (Conn)
            using (SqlCommand UpdateCmd = new SqlCommand(updateStageQuery, Conn))
            {
                // reinitialize connection string
                Conn.ConnectionString = CONNECTION_STRING;

                // open connection
                Conn.Open();

                // execute UPDATE
                stageRowsUpdated = UpdateCmd.ExecuteNonQuery();

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

            using (Conn)
            using (SqlCommand sqlCommand = new SqlCommand(displayAnswerQuery, Conn))
            {
                // reinitialize connection string
                Conn.ConnectionString = CONNECTION_STRING;

                // open connection
                Conn.Open();

                // load data table
                answerDataTable.Load(sqlCommand.ExecuteReader());

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

            using (Conn)
            using (SqlCommand DeleteCmd = new SqlCommand(deleteAnswerQuery, Conn))
            {
                // reinitialize connection string
                Conn.ConnectionString = CONNECTION_STRING;

                // open connection
                Conn.Open();

                // execute deletion
                answerRowsDeleted = DeleteCmd.ExecuteNonQuery();

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

            using (Conn)
            using (SqlCommand UpdateCmd = new SqlCommand(updateAnswerQuery, Conn))
            {
                // reinitialize connection string
                Conn.ConnectionString = CONNECTION_STRING;

                // open connection
                Conn.Open();

                // execute UPDATE
                answersRowsUpdated = UpdateCmd.ExecuteNonQuery();

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

            using (Conn)
            using (SqlCommand executeReaderCommand = new SqlCommand(selectQuery, Conn))
            {
                // reinitialize connection string
                Conn.ConnectionString = CONNECTION_STRING;

                // open connection
                Conn.Open();

                // load data table
                resultDataTable.Load(executeReaderCommand.ExecuteReader());

                // return resultsDataTable
                return resultDataTable;
            }
        }

        // private method to ExecuteNonQueryOnDB on the database
        private int ExecuteNonQueryOnDB(String nonQuery)
        {
            // create return variable
            int rowsAffected = 0;

            using (Conn)
            using (SqlCommand ExecuteNonQueryCmd = new SqlCommand(nonQuery, Conn))
            {
                // reinitialize connection string
                Conn.ConnectionString = CONNECTION_STRING;

                // open connection
                Conn.Open();

                // ExecuteNonQuery
                rowsAffected = ExecuteNonQueryCmd.ExecuteNonQuery();

                // return number of rows affected
                return rowsAffected;
            }
        }
    }
}