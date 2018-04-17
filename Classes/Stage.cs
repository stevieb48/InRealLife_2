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
    public class Stage : IScenarioPiece
    {        
        // Auto Implemented Properties Stage
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ScenarioID { get; set; }
        public string AudioFilePath { get; set; }
        public string ImageFilePath { get; set; }
        public int Answer1ID { get; set; }
        public int Ans1NextStagID { get; set; }
        public int Answer2ID { get; set; }
        public int Ans2NextStagID { get; set; }
        public bool Start { get; set; }

        // default constructor Stage
        public Stage()
        {
            this.ID = 0;
            this.Name = string.Empty;
            this.Description = string.Empty;
            this.ScenarioID = 0;
            this.AudioFilePath = string.Empty;
            this.ImageFilePath = string.Empty;
            this.Answer1ID = 0;
            this.Ans1NextStagID = 0;
            this.Answer2ID = 0;
            this.Ans2NextStagID = 0;
            this.Start = false;
        }

        //
        public Stage(int ID)
        {
            this.ID = ID;
            this.Name = string.Empty;
            this.Description = string.Empty;
            this.ScenarioID = 0;
            this.AudioFilePath = string.Empty;
            this.ImageFilePath = string.Empty;
            this.Answer1ID = 0;
            this.Ans1NextStagID = 0;
            this.Answer2ID = 0;
            this.Ans2NextStagID = 0;
            this.Start = false;
        }


        // parameter constructor Stage
        public Stage(int iD, string name, string description, int scenarioID, string audioFilePath, string imageFilePath, int answer1ID, int ans1NextStagID, int answer2ID, int ans2NextStagID, bool start)
        {
            this.ID = iD;
            this.Name = name;
            this.Description = description;
            this.ScenarioID = scenarioID;
            this.AudioFilePath = audioFilePath;
            this.ImageFilePath = imageFilePath;
            this.Answer1ID = 0;
            this.Ans1NextStagID = 0;
            this.Answer2ID = 0;
            this.Ans2NextStagID = 0;
            this.Start = false;
        }
    }
}