﻿using ClassInterfaces;

/*
 * This class Scenario implements an interface IScenarioPiece. It has 4 constructors for object creation
 *  and 3 properties for handling instance variables.
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

        public Scenario(string name, string description)
        {
            this.ID = 0;
            this.Name = name;
            this.Description = description;
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