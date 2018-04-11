using System.Data;

/*
 * This interface ...
 *
 * author: Group 7 (Stephen Bailey, Omar Garcia, Craig Wyse, Matthew Harris)
 * course: SEII
 * assignment: InRealLife (Group Project Spring 2018)
 * date: 4/08/2018
 * file name: IDatabase.cs
 * version: 1.0
 */
namespace DataLayerInterfaces
{
    public interface IDatabase
    {
        DataTable Select(string query);
        int Update(string query);
        int Insert(string query);
        int Delete(string query);
    }
}