using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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