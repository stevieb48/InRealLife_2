using IRLInterfaces;
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
        // Auto Implemented Properties Answer
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StageID { get; set; }
        public int NextStageID { get; set; }

        // default constructor Answer
        public Answer()
        {
            this.ID = 0;
            this.Name = string.Empty;
            this.Description = string.Empty;
            this.StageID = 0;
            this.NextStageID = 0;
        }

        // parameter constructor Answer
        public Answer(int ID, int StageID, string Name, string Description, int NextStageID)
        {
            this.ID = ID;
            this.Name = Name;
            this.Description = Description;
            this.StageID = StageID;
            this.NextStageID = NextStageID;
        }
    }
}