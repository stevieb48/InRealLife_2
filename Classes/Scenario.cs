using ClassInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * This class Scenario implements an interface IScenarioPiece. It has 2 constructors for object creation, 
 * 3 instance variables and 3 properties for handling instance variables.
 *
 * author: Group 7 (Stephen Bailey, Omar Garcia, Craig Wyse, Matthew Harris)
 * course: SEII
 * assignment: InRealLife (Group Project Spring 2018)
 * date: 03/22/2018
 * file name: Scenario.cs
 * version: 1.0
 */
namespace Classes
{
    public class Scenario : IScenarioPiece
    {
        // Auto Implemented Properties Scenario
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // default constructor Scenario
        public Scenario()
        {
            this.ID = 0;
            this.Name = string.Empty;
            this.Description = string.Empty;
        }

        public Scenario(int ID)
        {
            this.ID = ID;
            this.Name = string.Empty;
            this.Description = string.Empty;
        }

        // parameter constructor Scenario
        public Scenario(int iD, string name, string description)
        {
            this.ID = iD;
            this.Name = name;
            this.Description = description;
        }
    }
}