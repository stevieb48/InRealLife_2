using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * This Interface ...
 *
 * author: Group 7 (Stephen Bailey, Omar Garcia, Craig Wyse, Matthew Harris)
 * course: SEII
 * assignment: InRealLife (Group Project Spring 2018)
 * date: 04/25/2018
 * file name: IAccount.cs
 * version: 1.0
 */
namespace ClassInterfaces
{
    public interface IAccount
    {
        int ID { get; }
        string Name { get; }
        string Login { get; }
        string Password { get; }
        bool GlobalAccess { get; }
        string Scenarios { get; }
    }
}