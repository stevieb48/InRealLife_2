using ClassInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * This class Stage implements an interface IScenarioPiece. It has 2 constructors for object creation 
 * and 5 properties for handling instance variables.
 *
 * author: Group 7 (Stephen Bailey, Omar Garcia, Craig Wyse, Matthew Harris)
 * course: SEII
 * assignment: InRealLife (Group Project Spring 2018)
 * date: 03/22/2018
 * file name: Answer.cs
 * version: 1.0
 */
namespace Classes
{
    public class Answer : IScenarioPiece
    {
        // instance variables
        private int iD;
        private string name;
        private string description;
        private int stageID;
        private int nextStageID;
        
        // Auto Implemented Properties Answer
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StageID { get; set; }
        public int NextStageID { get; set; }

        // default constructor Answer
        public Answer()
        {
            this.iD = 0;
            this.Name = string.Empty;
            this.description = string.Empty;
            this.stageID = 0;
            this.nextStageID = 0;
        }

        // parameter constructor Answer
        public Answer(int iD, string name, string description, int stageID, int nextStageID)
        {
            this.iD = iD;
            this.name = name;
            this.description = description;
            this.stageID = stageID;
            this.nextStageID = nextStageID;
        }
    }
}