using ClassInterfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerInterfaces
{
    public interface IRepository
    {
        DataTable GetAll(IScenarioPiece piece);

        int DeletePiece(IScenarioPiece piece);
    }
}