using ClassInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * This class Scenario implements an interface IScenarioPiece. It has 2 constructors for object creation 
 * and 3 properties for handling instance variables.
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
        // instance variables
        private int iD;
        private string name;
        private string description;

        // Auto Implemented Properties Scenario
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // default constructor Scenario
        public Scenario()
        {
            this.iD = 0;
            this.name = string.Empty;
            this.description = string.Empty;
        }

        // parameter constructor Scenario
        public Scenario(int iD, string name, string description)
        {
            this.iD = iD;
            this.name = name;
            this.description = description;
        }
    }
}