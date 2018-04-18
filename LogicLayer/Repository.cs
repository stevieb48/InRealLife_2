using Classes;
using ClassInterfaces;
using DataLayer;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        // database instance
        private DataBaseCommunication newDBComm = new DataBaseCommunication();

        // default constructor
        public Repository()
        {

        }

        public IScenarioPiece GetPieceByID(IScenarioPiece piece)
        {
            // determine the piece
            string pieceType = WhatTypeOfPiece(piece);

            // create query based on the piece type
            string query = "SELECT * FROM " + pieceType + " WHERE ID = " + piece.ID;

            // new datatable and store results from call to the database
            DataTable dataTable = this.newDBComm.Select(query);

            IScenarioPiece resultingPiece = PutDataTableIntoPiece(pieceType, dataTable);

            // return the results
            return resultingPiece;
        }

        //
        private IScenarioPiece PutDataTableIntoPiece(string pieceType, DataTable dataTable)
        {
            if (pieceType == "Scenario")
            {
                IScenarioPiece scenario = new Scenario(int.Parse(dataTable.Rows[0][0].ToString()), dataTable.Rows[0][1].ToString(), dataTable.Rows[0][2].ToString());

                return scenario;
            }
            else if (pieceType == "Stage")
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
            string pieceType = WhatTypeOfPiece(piece);

            // create query based on the piece type
            string query = "SELECT * FROM " + pieceType;

            // new datatable and store results from call to the database
            DataTable dataTable = this.newDBComm.Select(query);

            IScenarioPiece[] pieceList = PutDataTableIntoPieceList(pieceType, dataTable);

            // return the results
            return pieceList;
        }

        private IScenarioPiece[] PutDataTableIntoPieceList(string pieceType, DataTable dataTable)
        {
            if (pieceType == "Scenario")
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
            else if (pieceType == "Stage")
            {
                Stage[] pieceList = new Stage[dataTable.Rows.Count];

                // loop to put pieces from data table put into array
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Stage tempStage = new Stage(int.Parse(dataTable.Rows[i][0].ToString()), dataTable.Rows[i][1].ToString(), dataTable.Rows[i][2].ToString(), int.Parse(dataTable.Rows[i][3].ToString()), dataTable.Rows[i][4].ToString(), dataTable.Rows[i][5].ToString(), int.Parse(dataTable.Rows[i][6].ToString()), int.Parse(dataTable.Rows[i][7].ToString()), int.Parse(dataTable.Rows[i][8].ToString()), int.Parse(dataTable.Rows[i][9].ToString()));

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
            int rowsAffected = newDBComm.Delete("DELETE * "
                                        + "FROM " + piece.GetType()
                                        + "WHERE ID =" + piece.ID);

            // return rows affected by nonquery
            return rowsAffected;
        }

        // public method to UPDATE existing piece by type
        public int UpdateExisingPiece(IScenarioPiece piece)
        {
            // create rows affected by call to UPDATE from the database
            int rowsAffected = newDBComm.Delete("DELETE * "
                                        + "FROM " + piece.GetType()
                                        + "WHERE ID =" + piece.ID);

            // return rows affected by nonquery
            return rowsAffected;
        }

        // public method to INSERT new piece by type
        public int InsertNewPiece(IScenarioPiece piece)
        {
            // create rows affected by call to INSERT into the database
            int rowsAffected = newDBComm.Delete("DELETE * "
                                        + "FROM " + piece.GetType()
                                        + "WHERE ID =" + piece.ID);

            // return rows affected by nonquery
            return rowsAffected;
        }

        // private method to determine what piece type is passed in
        private string WhatTypeOfPiece(IScenarioPiece piece)
        {
            // create variable with empty string
            string pieceType = string.Empty;

            //
            if (piece.GetType().ToString() == "Classes.Scenario")
            {
                pieceType = "Scenario";
            }
            else if (piece.GetType().ToString() == "Classes.Stage")
            {
                pieceType = "Stage";
            }
            else if (piece.GetType().ToString() == "Classes.Answer")
            {
                pieceType = "Answer";
            }

            // return type of piece
            return pieceType;
        }

        public Stage GetFirstStage(int scenarioID)
        {
            // create query based on the piece type
            string query = "SELECT * FROM Stage WHERE ScenarioID = " + scenarioID + " AND Start = 1";

            // new datatable and store results from call to the database
            DataTable dataTable = this.newDBComm.Select(query);

            Stage stage = PutDataTableIntoStage("Stage", dataTable);

            return stage;
        }

        private Stage PutDataTableIntoStage(string stage, DataTable dataTable)
        {
            Stage tempStage = new Stage(int.Parse(dataTable.Rows[0][0].ToString()), dataTable.Rows[0][1].ToString(), dataTable.Rows[0][2].ToString(), int.Parse(dataTable.Rows[0][3].ToString()), dataTable.Rows[0][4].ToString(), dataTable.Rows[0][5].ToString(), int.Parse(dataTable.Rows[0][6].ToString()), int.Parse(dataTable.Rows[0][7].ToString()), int.Parse(dataTable.Rows[0][8].ToString()), int.Parse(dataTable.Rows[0][9].ToString()));

            return tempStage;
        }

        public Stage GetNextStage(int NextStageID)
        {
            // create query based on the piece type
            string query = "SELECT * FROM Stage WHERE ID = " + NextStageID;

            // new datatable and store results from call to the database
            DataTable dataTable = this.newDBComm.Select(query);

            Stage stage = PutDataTableIntoStage("Stage", dataTable);

            return stage;
        }
    }
}