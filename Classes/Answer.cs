using ClassInterfaces;

/*
 * This class Answer implements an interface IScenarioPiece. It has 2 constructors for object creation, 
 * 3 instance variables and 5 properties for handling instance variables.
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

        // default constructor Answer
        public Answer()
        {
            this.ID = 0;
            this.Name = string.Empty;
            this.Description = string.Empty;
        }

        public Answer(int ID)
        {
            this.ID = ID;
            this.Name = string.Empty;
            this.Description = string.Empty;
        }

        // parameter constructor Answer
        public Answer(int iD, string name, string description)
        {
            this.ID = iD;
            this.Name = name;
            this.Description = description;
        }
    }
}