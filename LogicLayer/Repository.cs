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
        //
        private const string SCENARIO = "Scenario";
        private const string STAGE = "Stage";
        private const string ANSWER = "Answer";

        // database instance
        private DataBaseCommunication newDBComm = new DataBaseCommunication();

        // default constructor
        public Repository()
        {

        }

        //
        public IScenarioPiece GetPieceByID(IScenarioPiece piece)
        {
            // determine the piece
            //string pieceType = WhatTypeOfPiece(piece);

            // create query based on the piece type
            string query = "SELECT * FROM " + piece.GetType().ToString().Split('.')[1] + " WHERE ID = " + piece.ID;

            // new datatable and store results from call to the database
            DataTable dataTable = this.newDBComm.Select(query);

            IScenarioPiece resultingPiece = PutDataTableIntoPiece(piece.GetType().ToString().Split('.')[1], dataTable);

            // return the results
            return resultingPiece;
        }

        //
        private IScenarioPiece PutDataTableIntoPiece(string pieceType, DataTable dataTable)
        {
            if (pieceType == SCENARIO)
            {
                IScenarioPiece scenario = new Scenario(int.Parse(dataTable.Rows[0][0].ToString()), dataTable.Rows[0][1].ToString(), dataTable.Rows[0][2].ToString());

                return scenario;
            }
            else if (pieceType == STAGE)
            {
                IScenarioPiece stage = new Stage(int.Parse(dataTable.Rows[0][0].ToString()), dataTable.Rows[0][1].ToString(), dataTable.Rows[0][2].ToString(), int.Parse(dataTable.Rows[0][3].ToString()), dataTable.Rows[0][4].ToString(), dataTable.Rows[0][5].ToString(), int.Parse(dataTable.Rows[0][6].ToString()), int.Parse(dataTable.Rows[0][7].ToString()), int.Parse(dataTable.Rows[0][8].ToString()), int.Parse(dataTable.Rows[0][9].ToString()));

                return stage;
            }
            else
            {
                IScenarioPiece answer = new Answer(int.Parse(dataTable.Rows[0][0].ToString()), dataTable.Rows[0][1].ToString(), dataTable.Rows[0][2].ToString());

                return answer;
            }
        }

        // public method to get all pieces by type
        public IScenarioPiece[] GetAllPiecesByType(IScenarioPiece piece)
        {
            // determine the piece
            //string pieceType = WhatTypeOfPiece(piece);

            // create query based on the piece type
            string query = "SELECT * FROM " + piece.GetType().ToString().Split('.')[1];

            // new datatable and store results from call to the database
            DataTable dataTable = this.newDBComm.Select(query);

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

                IScenarioPiece[] tempArray = pieceList;

                return tempArray;
            }
            else if (pieceType == STAGE)
            {
                Stage[] pieceList = new Stage[dataTable.Rows.Count];

                // loop to put pieces from data table put into array
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Stage tempStage = new Stage(int.Parse(dataTable.Rows[i][0].ToString()), dataTable.Rows[i][1].ToString(), dataTable.Rows[i][2].ToString());

                    pieceList[i] = tempStage;
                }

                IScenarioPiece[] tempArray = pieceList;

                return tempArray;
            }
            else
            {
                Answer[] pieceList = new Answer[dataTable.Rows.Count];

                // loop to put pieces from data table put into array
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Answer tempAnswer = new Answer(int.Parse(dataTable.Rows[i][0].ToString()), dataTable.Rows[i][1].ToString(), dataTable.Rows[i][2].ToString());

                    pieceList[i] = tempAnswer;
                }

                IScenarioPiece[] tempArray = pieceList;

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
                                        + "SET Name = " + piece.Name + " Description = " + piece.Description
                                        + "WHERE ID =" + piece.ID);

            // return rows affected by nonquery
            return rowsAffected;
        }

        // public method to INSERT new piece by type
        public int InsertNewPiece(IScenarioPiece piece)
        {
            // create rows affected by call to INSERT into the database
            int rowsAffected = newDBComm.Delete("INSERT INTO " + piece.GetType().ToString().Split('.')[1]
                                        + " (Name, Description) VALUES (" + piece.Name + ", " + piece.Description);

            // return rows affected by nonquery
            return rowsAffected;
        }

        /*
        // private method to determine what piece type is passed in
        private string WhatTypeOfPiece(IScenarioPiece piece)
        {
            // create variable with empty string
            string pieceType = string.Empty;

            //
            if (piece.GetType().ToString().Split('.')[1] == SCENARIO)
            {
                pieceType = "Scenario";
            }
            else if (piece.GetType().ToString().Split('.')[1] == STAGE)
            {
                pieceType = "Stage";
            }
            else if (piece.GetType().ToString().Split('.')[1] == ANSWER)
            {
                pieceType = "Answer";
            }

            // return type of piece
            return pieceType;
        }
        */

        //
        public Stage GetFirstStage(int scenarioID)
        {
            // create query based on the piece type
            string query = "SELECT * FROM Stage WHERE ScenarioID = " + scenarioID + " AND Start = 1";

            // new datatable and store results from call to the database
            DataTable dataTable = this.newDBComm.Select(query);

            Stage stage = PutDataTableIntoStage(dataTable);

            return stage;
        }

        //
        private Stage PutDataTableIntoStage(DataTable dataTable)
        {
            Stage tempStage = new Stage(int.Parse(dataTable.Rows[0][0].ToString()), dataTable.Rows[0][1].ToString(), dataTable.Rows[0][2].ToString(), int.Parse(dataTable.Rows[0][3].ToString()), dataTable.Rows[0][4].ToString(), dataTable.Rows[0][5].ToString(), int.Parse(dataTable.Rows[0][6].ToString()), int.Parse(dataTable.Rows[0][7].ToString()), int.Parse(dataTable.Rows[0][8].ToString()), int.Parse(dataTable.Rows[0][9].ToString()));

            return tempStage;
        }

        //
        public Stage GetNextStage(int NextStageID)
        {
            // create query based on the piece type
            string query = "SELECT * FROM Stage WHERE ID = " + NextStageID;

            // new datatable and store results from call to the database
            DataTable dataTable = this.newDBComm.Select(query);

            Stage stage = PutDataTableIntoStage(dataTable);

            return stage;
        }

        public int SaveStageData(Stage stage, bool starterFlag)
        {
            int rowsAffected = 0;
                
            if (stage.ID != 0)
            {
                // update existing
                string query = "UPDATE Stage SET "
                                + "Name = '" + stage.Name + "', "
                                + "Description = '" + stage.Description + "', "
                                + "ScenarioID = " + stage.ScenarioID + ", "
                                + "AudioFilePath = '" + stage.AudioFilePath + "', "
                                + "ImageFilePath = '" + stage.ImageFilePath + "', "
                                + "Answer1ID = " + stage.Answer1ID + ", "
                                + "Ans1NextStagID = " + stage.Ans1NextStagID + ", "
                                + "Answer2ID = " + stage.Answer2ID + ", "
                                + "Ans2NextStagID = " + stage.Ans2NextStagID + ", "
                                + "Start = " + starterFlag
                                + " WHERE ID = " + stage.ID;

                rowsAffected = newDBComm.Update(query);
            }
            else
            {
                // insert new
                string query = "INSERT INTO Stage (Name, Description, ScenarioID, AudioFilePath, ImageFilePath, Answer1ID, Ans1NextStagID, Answer2ID, Ans2NextStagID, Start)" 
                                + " VALUES "
                                + "('" + stage.Name + "', "
                                + "'" + stage.Description + "', "
                                + stage.ScenarioID + ", "
                                + "'" + stage.AudioFilePath + "', "
                                + "'" + stage.ImageFilePath + "', "
                                + stage.Answer1ID + ", "
                                + stage.Ans1NextStagID + ", "
                                + stage.Answer2ID + ", "
                                + stage.Ans2NextStagID + ", "
                                + starterFlag
                                + " WHERE ID = " + stage.ID;

                rowsAffected = newDBComm.Insert(query);
            }

            // 
            return rowsAffected;
        }
    }
}