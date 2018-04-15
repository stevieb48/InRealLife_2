using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class DataBaseHandler
    {
        // CONSTANT storing the connection string
        public const string connectionString = @"Server=tcp:irl-data-server.database.windows.net,1433;Initial Catalog=Azure_SQL_IRL_ScenarioData;Persist Security Info=False;User ID=IRL_admin;Password=1RLdatA2;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        // create new connection
        SqlConnection conn = new SqlConnection(connectionString);

        public String getScenarioName(int ScenarioId)
        {
            String query = @"SELECT Name FROM Scenario Where ID =" + ScenarioId;

            using (conn)
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                // reinitialize connection string
                conn.ConnectionString = connectionString;

                conn.Open();

                var result = command.ExecuteScalar();
                return "" + result;
            }
        }

        public String getAnswer(int AnswerId, int StageID)
        {
            String query = "SELECT Description FROM Answer WHERE StageID = " + StageID + " AND ID = " + AnswerId;
            using (conn)
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                // reinitialize connection string
                conn.ConnectionString = connectionString;

                conn.Open();

                var result = command.ExecuteScalar();
                return "" + result;
            }
        }

        public int getNextStageID(int AnswerId, int StageID)
        {
            String query = "SELECT nextStageID FROM Answer WHERE StageID = " + StageID + " AND ID = " + AnswerId;
            using (conn)
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                // reinitialize connection string
                conn.ConnectionString = connectionString;

                conn.Open();

                var result = command.ExecuteScalar();
                if (result != null)
                {
                    return (int)result;
                }
            }
            return 0;
        }

        public int getStageID(int ScenarioID, int stage)
        {
            String query = "SELECT ID FROM Stage WHERE ScenarioID = " + ScenarioID + " and ID = " + stage;
            using (conn)
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                // reinitialize connection string
                conn.ConnectionString = connectionString;

                conn.Open();

                var result = command.ExecuteScalar();
                if (result != null)
                {
                    return (int)result;
                }
            }
            return 0;
        }

        public String getAudioFilePath(int StageID)
        {
            String query = "SELECT AudioFilePath FROM Stage WHERE ID = " + StageID;
            using (conn)
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                // reinitialize connection string
                conn.ConnectionString = connectionString;

                conn.Open();

                var result = command.ExecuteScalar();
                if (result != null)
                {
                    return (String)result;
                }
            }
            return "";
        }

        public String getStageDescription(int StageID)
        {
            String query = "SELECT Description FROM Stage WHERE ID = " + StageID;
            using (conn)
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                // reinitialize connection string
                conn.ConnectionString = connectionString;

                conn.Open();

                var result = command.ExecuteScalar();
                if (result != null)
                {
                    return (String)result;
                }
            }
            return "";
        }

        public String getImageFilePath(int StageID)
        {
            String query = "SELECT ImageFilePath FROM Stage WHERE ID = " + StageID;
            using (conn)
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                // reinitialize connection string
                conn.ConnectionString = connectionString;

                conn.Open();

                var result = command.ExecuteScalar();
                if (result != null)
                {
                    return (String)result;
                }
            }
            return "";
        }

        public int getAnswerID(int StageID, int answerNum)
        {
            String query = "SELECT ID FROM Answer WHERE StageID = " + StageID + " AND ID = " + answerNum;
            using (conn)
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                // reinitialize connection string
                conn.ConnectionString = connectionString;

                conn.Open();

                var result = command.ExecuteScalar();
                if (result != null)
                {
                    return (int)result;
                }
            }
            return 0;
        }

        public String getAnswerDescription(int AnswerID)
        {
            String query = "SELECT Description FROM Answer WHERE ID = " + AnswerID;
            using (conn)
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                // reinitialize connection string
                conn.ConnectionString = connectionString;

                conn.Open();

                var result = command.ExecuteScalar();
                if (result != null)
                {
                    return (String)result;
                }
            }
            return "";
        }

        public int getNextStageID(int AnswerID)
        {
            String query = "SELECT nextStageID FROM Answer WHERE ID = " + AnswerID;
            using (conn)
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                // reinitialize connection string
                conn.ConnectionString = connectionString;

                conn.Open();

                var result = command.ExecuteScalar();
                if (result != null)
                {
                    return (int)result;
                }
            }
            return 0;
        }
    }
}