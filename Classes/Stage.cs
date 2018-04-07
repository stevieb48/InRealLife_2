using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * This class Stage has 2 constructors and 5 properties for handling instance variables.
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
    public class Stage
    {
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
            this.ID = 0;
            this.Name = "";
            this.Description = "";
            this.ScenarioID = 0;
            this.AudioFilePath = "";
            this.ImageFilePath = "";
        }

        // parameter constructor Stage
        public Stage(int ID, int ScenarioID, string Name, string Description, string AudioFilePath, string ImageFilePath)
        {
            this.ID = ID;
            this.Name = Name;
            this.Description = Description;
            this.ScenarioID = ScenarioID;
            this.AudioFilePath = AudioFilePath;
            this.ImageFilePath = ImageFilePath;
        }
    }
}