using ClassInterfaces;
using DataLayer;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class Repository : IRepository
    {
        // instance
        private DataBaseCommunication newDBComm;

        // properties
        public DataBaseCommunication NewDBComm { get; set; }

        public Repository()
        {
            this.newDBComm = new DataBaseCommunication();
        }

        //
        public DataTable GetAll(IScenarioPiece piece)
        {
            string query = string.Empty;

            if (piece.GetType().ToString() == "Classes.Scenario")
            {
                query = "SELECT * FROM Scenario";
            }
            else if (piece.GetType().ToString() == "Classes.Stage")
            {
                query = "SELECT * FROM Stage";
            }
            else if (piece.GetType().ToString() == "Classes.Answer")
            {
                query = "SELECT * FROM Answer";
            }

            DataTable dataTable = null;

            dataTable = this.newDBComm.Select(query);

            return dataTable;
        }

        //
        public int DeletePiece(IScenarioPiece piece)
        {
            int rowsAffected = 0;

            rowsAffected = NewDBComm.Delete("DELETE * "
                                        + "FROM " + piece.GetType()
                                        + "WHERE ID =" + piece.ID);

            return rowsAffected;
        }
    }
}