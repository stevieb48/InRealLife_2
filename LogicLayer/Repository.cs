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

        // public method to get all pieces by type
        public DataTable GetAllPiecesByType(IScenarioPiece piece)
        {
            // determine the piece
            string pieceType = WhatTypeOfPiece(piece);

            // create query based on the piece type
            string query = "SELECT * FROM " + pieceType;

            // new datatable and store results from call to the database
            DataTable dataTable = this.newDBComm.Select(query);

            // return the results
            return dataTable;
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
    }
}