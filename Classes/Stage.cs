using ClassInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * This class Stage implements an interface IScenarioPiece. It has 2 constructors for object creation, 
 * 6 instance variables and 6 properties for handling instance variables.
 * 
 * author: Group 7 (Stephen Bailey, Omar Garcia, Craig Wyse, Matthew Harris)
 * course: SEII
 * assignment: InRealLife (Group Project Spring 2018)
 * date: 03/22/2018
 * file name: Stage.cs
 * version: 1.0
 */
namespace Classes
{
    public class Stage : ClassInterfaces.IScenarioPiece
    {
        // instance variables
        private int iD;
        private string name;
        private string description;
        private int scenarioID;
        private string audioFilePath;
        private string imageFilePath;

        // Auto Implemented Properties Stage
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ScenarioID { get; set; }
        public string AudioFilePath { get; set; }
        public string ImageFilePath { get; set; }

        // default constructor Stage
        public Stage()
        {
            this.iD = 0;
            this.name = string.Empty;
            this.description = string.Empty;
            this.scenarioID = 0;
            this.audioFilePath = string.Empty;
            this.imageFilePath = string.Empty;
        }

        // parameter constructor Stage
        public Stage(int iD, string name, string description, int scenarioID, string audioFilePath, string imageFilePath)
        {
            this.iD = iD;
            this.name = name;
            this.description = description;
            this.scenarioID = scenarioID;
            this.audioFilePath = audioFilePath;
            this.imageFilePath = imageFilePath;
        }
    }
}