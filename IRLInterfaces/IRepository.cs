using ClassInterfaces;
using System.Data;

/*
 * This interface ...
 *
 * author: Group 7 (Stephen Bailey, Omar Garcia, Craig Wyse, Matthew Harris)
 * course: SEII
 * assignment: InRealLife (Group Project Spring 2018)
 * date: 4/08/2018
 * file name: IRepository.cs
 * version: 1.0
 */
namespace LogicLayerInterfaces
{
    public interface IRepository
    {
        DataTable GetAllPiecesByType(IScenarioPiece piece);
        int DeleteExistingPiece(IScenarioPiece piece);
        int UpdateExisingPiece(IScenarioPiece piece);
        int InsertNewPiece(IScenarioPiece piece);
    }
}