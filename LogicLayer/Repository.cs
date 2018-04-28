using Classes;
using ClassInterfaces;
using DataLayer;
using LogicLayerInterfaces;
using System;
using System.Data;

/*
 * This class ...
 *
 * author: Group 7 (Stephen Bailey, Omar Garcia, Craig Wyse, Matthew Harris)
 * course: SEII
 * assignment: InRealLife (Group Project Spring 2018)
 * date: 4/08/2018
 * file name: Repository.cs
 * version: 1.0
 */
namespace LogicLayer
{
    public class Repository : IRepository
    {
        // CONSTANTS
        private const string SCENARIO = "Scenario";
        private const string STAGE = "Stage";
        private const string ADMIN = "Admin";
        private const string CHILD = "Child";
        private const int EMPTY = 0;

        private const string INVALIDLOGIN = "INVALID LOGIN";
        private const string NOT_FOUND = "NOT FOUND";


        // database instance
        private DataBaseCommunication newDBComm = new DataBaseCommunication();

        // default constructor
        public Repository()
        {

        }

        //
        public IScenarioPiece GetPieceByID(IScenarioPiece piece)
        {
            // create query based on the piece type
            string query = "SELECT * "
                        + "FROM " + piece.GetType().ToString().Split('.')[1]
                        + " WHERE ID = " + piece.ID;

            // new datatable and store results from call to the database
            DataTable dataTable = this.newDBComm.Select(query);

            //
            IScenarioPiece resultingPiece = PutDataTableIntoPiece(piece.GetType().ToString().Split('.')[1], dataTable);

            // return the results
            return resultingPiece;
        }

        //
        private IScenarioPiece PutDataTableIntoPiece(string pieceType, DataTable dataTable)
        {
            if (pieceType == SCENARIO)
            {
                //
                IScenarioPiece scenario = new Scenario(int.Parse(dataTable.Rows[0][0].ToString()), dataTable.Rows[0][1].ToString(), dataTable.Rows[0][2].ToString());

                //
                return scenario;
            }
            else
            {
                //
                IScenarioPiece stage = new Stage(int.Parse(dataTable.Rows[0][0].ToString()), dataTable.Rows[0][1].ToString(), dataTable.Rows[0][2].ToString(), int.Parse(dataTable.Rows[0][3].ToString()), dataTable.Rows[0][4].ToString(), dataTable.Rows[0][5].ToString(), dataTable.Rows[0][6].ToString(), int.Parse(dataTable.Rows[0][7].ToString()), dataTable.Rows[0][8].ToString(), int.Parse(dataTable.Rows[0][9].ToString()));

                //
                return stage;
            }
        }

        // public method to get all pieces by type
        public IScenarioPiece[] GetAllPiecesByType(IScenarioPiece piece)
        {
            // create query based on the piece type
            string query = "SELECT * "
                        + "FROM " + piece.GetType().ToString().Split('.')[1];

            // new datatable and store results from call to the database
            DataTable dataTable = this.newDBComm.Select(query);

            //
            IScenarioPiece[] pieceList = PutDataTableIntoPieceList(piece.GetType().ToString().Split('.')[1], dataTable);

            // return the results
            return pieceList;
        }

        public IScenarioPiece[] GetAllPiecesByType(IScenarioPiece piece, int ID)
        {
            // create query based on the piece type
            string query = "SELECT * "
                           + "FROM " + piece.GetType().ToString().Split('.')[1] +
                " WHERE ScenarioID = " + ID;

            // new datatable and store results from call to the database
            DataTable dataTable = this.newDBComm.Select(query);

            //
            IScenarioPiece[] pieceList = PutDataTableIntoPieceList(piece.GetType().ToString().Split('.')[1], dataTable);

            // return the results
            return pieceList;
        }

        //
        private IScenarioPiece[] PutDataTableIntoPieceList(string pieceType, DataTable dataTable)
        {
            if (pieceType == SCENARIO)
            {
                Scenario[] pieceList = new Scenario[dataTable.Rows.Count];

                // loop to put pieces from data table put into array
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Scenario tempScenario = new Scenario(int.Parse(dataTable.Rows[i][0].ToString()), dataTable.Rows[i][1].ToString(), dataTable.Rows[i][2].ToString());

                    pieceList[i] = tempScenario;
                }

                //
                IScenarioPiece[] tempArray = pieceList;

                //
                return tempArray;
            }
            else
            {
                Stage[] pieceList = new Stage[dataTable.Rows.Count];

                // loop to put pieces from data table put into array
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Stage tempStage = new Stage(int.Parse(dataTable.Rows[i][0].ToString()), dataTable.Rows[i][1].ToString(), dataTable.Rows[i][2].ToString());

                    pieceList[i] = tempStage;
                }

                //
                IScenarioPiece[] tempArray = pieceList;

                //
                return tempArray;
            }
        }

        // public method to DELETE existing piece by type
        public int DeleteExistingPiece(IScenarioPiece piece)
        {
            // create rows affected by call to DELETE from the database
            int rowsAffected = newDBComm.Delete("DELETE "
                                        + "FROM " + piece.GetType().ToString().Split('.')[1]
                                        + " WHERE ID = " + piece.ID);

            // return rows affected by nonquery
            return rowsAffected;
        }

        // public method to UPDATE existing piece by type
        public int UpdateExisingPiece(IScenarioPiece piece)
        {
            // create rows affected by call to UPDATE from the database
            int rowsAffected = newDBComm.Delete("UPDATE " + piece.GetType().ToString().Split('.')[1]
                                        + " SET Name = '" + piece.Name + "', Description = '" + piece.Description
                                        + "' WHERE ID = " + piece.ID);

            // return rows affected by nonquery
            return rowsAffected;
        }

        // public method to INSERT new piece by type
        public int InsertNewPiece(IScenarioPiece piece)
        {
            // create rows affected by call to INSERT into the database
            int rowsAffected = newDBComm.Insert("INSERT INTO " + piece.GetType().ToString().Split('.')[1]
                                        + " (Name, Description) "
                                        + "VALUES ('" + piece.Name + "', '" + piece.Description + "')");

            // return rows affected by nonquery
            return rowsAffected;
        }

        //
        public Stage GetFirstStage(int scenarioID)
        {
            // create query based on the piece type
            string query = "SELECT * "
                        + "FROM Stage "
                        + "WHERE ScenarioID = " + scenarioID
                        + " AND Start = 1";

            // new datatable and store results from call to the database
            DataTable dataTable = this.newDBComm.Select(query);

            //
            Stage stage = PutDataTableIntoStage(dataTable);

            //
            return stage;
        }

        //
        private Stage PutDataTableIntoStage(DataTable dataTable)
        {
            //
            Stage tempStage = new Stage(int.Parse(dataTable.Rows[0][0].ToString()), dataTable.Rows[0][1].ToString(), dataTable.Rows[0][2].ToString(), int.Parse(dataTable.Rows[0][3].ToString()), dataTable.Rows[0][4].ToString(), dataTable.Rows[0][5].ToString(), dataTable.Rows[0][6].ToString(), int.Parse(dataTable.Rows[0][7].ToString()), dataTable.Rows[0][8].ToString(), int.Parse(dataTable.Rows[0][9].ToString()));

            //
            return tempStage;
        }

        //
        public Stage GetNextStage(int NextStageID)
        {
            // create query based on the piece type
            string query = "SELECT * "
                        + "FROM Stage "
                        + "WHERE ID = " + NextStageID;

            // new datatable and store results from call to the database
            DataTable dataTable = this.newDBComm.Select(query);

            //
            Stage stage = PutDataTableIntoStage(dataTable);

            //
            return stage;
        }

        //
        public int SaveStageData(Stage stage, bool starterFlag)
        {
            char starter = '1';

            //
            int rowsAffected = 0;

            if (starterFlag == false)
            {
                starter = '0';
            }

            //
            if (stage.ID != 0)
            {
                // update existing
                string query = "UPDATE Stage SET "
                                + "Name = '" + stage.Name + "', "
                                + "Description = '" + stage.Description + "', "
                                + "ScenarioID = " + stage.ScenarioID + ", "
                                + "AudioFilePath = '" + stage.AudioFilePath + "', "
                                + "ImageFilePath = '" + stage.ImageFilePath + "', "
                                + "Answer1 = '" + stage.Answer1 + "', "
                                + "Ans1NextStagID = " + stage.Ans1NextStagID + ", "
                                + "Answer2 = '" + stage.Answer2 + "', "
                                + "Ans2NextStagID = " + stage.Ans2NextStagID + ", "
                                + "Start = " + starter
                                + " WHERE ID = " + stage.ID;

                rowsAffected = newDBComm.Update(query);
            }
            else
            {
                // insert new
                string query = "INSERT INTO Stage (Name, Description, ScenarioID, AudioFilePath, ImageFilePath, Answer1, Ans1NextStagID, Answer2, Ans2NextStagID, Start)"
                                + " VALUES "
                                + "('" + stage.Name + "', "
                                + "'" + stage.Description + "', "
                                + stage.ScenarioID + ", "
                                + "'" + stage.AudioFilePath + "', "
                                + "'" + stage.ImageFilePath + "', '"
                                + stage.Answer1 + "', "
                                + stage.Ans1NextStagID + ", '"
                                + stage.Answer2 + "', "
                                + stage.Ans2NextStagID + ", "
                                + starter + ")";

                rowsAffected = newDBComm.Insert(query);
            }

            // 
            return rowsAffected;
        }

        //
        public void CleanUp()
        {
            newDBComm.Dispose();
        }

        //
        public IAccount LogIntoAccount(string login, string password)
        {
            //
            IAccount newLogin = null;

            // create query based on the account type
            string query = "SELECT * "
                        + "FROM " + "Accounts"
                        + " WHERE Login = '" + login
                        + "' AND Password = '" + password + "'";

            // new datatable and store results from call to the database
            DataTable dataTable = this.newDBComm.Select(query);

            // empty set
            if (dataTable == null)
            {
                newLogin = new Child(NOT_FOUND);
            }
            // check login
            else if ((login == dataTable.Rows[0][2].ToString()) && (password == dataTable.Rows[0][3].ToString()))
            {
                // if GlobalStatus = true
                if (Convert.ToBoolean(dataTable.Rows[0][4].ToString()) == true)
                {
                    newLogin = PutDataTableIntoAccountPiece(ADMIN, dataTable);
                }
                // global status = false
                else
                {
                    newLogin = PutDataTableIntoAccountPiece(CHILD, dataTable);
                }
            }
            // login failed
            else
            {
                newLogin = new Child(INVALIDLOGIN);
            }

            // return the results
            return newLogin;
        }

        //
        private IAccount PutDataTableIntoAccountPiece(string pieceType, DataTable dataTable)
        {
            //
            if (pieceType == ADMIN)
            {
                // put data into admin account
                IAccount admin = new Admin(int.Parse(dataTable.Rows[0][0].ToString()), dataTable.Rows[0][1].ToString(), dataTable.Rows[0][2].ToString(), dataTable.Rows[0][3].ToString(), Convert.ToBoolean(dataTable.Rows[0][4].ToString()), dataTable.Rows[0][5].ToString());

                // return admin
                return admin;
            }
            //
            else
            {
                // put data into child account
                IAccount child = new Child(int.Parse(dataTable.Rows[0][0].ToString()), dataTable.Rows[0][1].ToString(), dataTable.Rows[0][2].ToString(), dataTable.Rows[0][3].ToString(), Convert.ToBoolean(dataTable.Rows[0][4].ToString()), dataTable.Rows[0][5].ToString());

                // child
                return child;
            }
        }

        //
        public bool CreateNewAccount(IAccount account)
        {
            // is valid flag set to false
            bool IsValid = false;

            // create query based on the account type
            string query = "SELECT * "
                        + "FROM " + account.GetType().ToString().Split('.')[1]
                        + " WHERE Name = " + account.Name;

            // new datatable and store results from call to the database
            DataTable dataTable = this.newDBComm.Select(query);

            //
            IAccount existingAccount = PutDataTableIntoAccountPiece(account.GetType().ToString().Split('.')[1], dataTable);

            if (account.Name == existingAccount.Name && account.Password == existingAccount.Password)
            {
                IsValid = true;
            }

            // return the results
            return IsValid;
        }

        public bool IsItStarter(int stageID)
        {
            bool IsItStarter = false;

            // create query based on the account type
            string query = "SELECT Start "
                        + "FROM Stage "
                        + "WHERE ID = " + stageID;

            // new datatable and store results from call to the database
            DataTable dataTable = this.newDBComm.Select(query);

            string starterFlag = (dataTable.Rows[0][0].ToString());

            if (starterFlag == "True")
            {
                IsItStarter = true;
            }
            else
            {
                IsItStarter = false;
            }

            return IsItStarter;
        }
    }
}