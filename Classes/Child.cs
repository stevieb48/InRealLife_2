using ClassInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * This class Child ...
 *
 * author: Group 7 (Stephen Bailey, Omar Garcia, Craig Wyse, Matthew Harris)
 * course: SEII
 * assignment: InRealLife (Group Project Spring 2018)
 * date: 4/23/2018
 * file name: Child.cs
 * version: 1.0
 */
namespace Classes
{
    public class Child : IAccount
    {
        //
        public int ID { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool GlobalAccess { get; set; }
        public string Scenarios { get; set; }

        //
        public Child()
        {
            this.ID = 0;
            this.Name = string.Empty;
            this.Login = string.Empty;
            this.Password = string.Empty;
            this.GlobalAccess = false;
            this.Scenarios = string.Empty;
        }

        //
        public Child(string failure)
        {
            this.ID = 0;
            this.Name = string.Empty;
            this.Login = failure;
            this.Password = string.Empty;
            this.GlobalAccess = false;
            this.Scenarios = string.Empty;
        }

        //
        public Child(int iD, string name, string login, string password, bool globalAccess, string scenarios)
        {
            this.ID = iD;
            this.Name = name;
            this.Login = login;
            this.Password = password;
            this.GlobalAccess = globalAccess;
            this.Scenarios = scenarios;
        }
    }
}