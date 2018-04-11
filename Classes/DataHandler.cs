using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class DataHandler
    {
        public Scenario scenario = new Scenario();
        public Stage stage = new Stage();
        public Answer answer1 = new Answer();
        public Answer answer2 = new Answer();

        public void Intetialize(int scenarioNum)
        {
            DataBaseHandler Dbase = new DataBaseHandler();
            scenario.ID = scenarioNum;
            scenario.Name = Dbase.getScenarioName(scenario.ID);

            stage.ScenarioID = scenario.ID;
            stage.ID = Dbase.getStageID(stage.ScenarioID, 1);
            stage.AudioFilePath = Dbase.getAudioFilePath(stage.ID);
            stage.Description = Dbase.getStageDescription(stage.ID);
            stage.ImageFilePath = Dbase.getImageFilePath(stage.ID);


            answer1.StageID = stage.ID;
            answer1.ID = Dbase.getAnswerID(answer1.StageID, 1);
            answer1.Description = Dbase.getAnswerDescription(answer1.ID);
            answer1.NextStageID = Dbase.getNextStageID(answer1.ID);

            answer2.StageID = stage.ID;
            answer2.ID = Dbase.getAnswerID(answer2.StageID, 2);
            answer2.Description = Dbase.getAnswerDescription(answer2.ID);
            answer2.NextStageID = Dbase.getNextStageID(answer2.ID);
        }

        public void Update(int AnswerNumber)
        {
            DataBaseHandler Dbase = new DataBaseHandler();
            if (AnswerNumber == 1)
            {
                stage.ID = Dbase.getStageID(scenario.ID, answer1.NextStageID);
                stage.AudioFilePath = Dbase.getAudioFilePath(stage.ID);
                stage.Description = Dbase.getStageDescription(stage.ID);
                stage.ImageFilePath = Dbase.getImageFilePath(stage.ID);


                answer1.StageID = stage.ID;
                answer1.ID = Dbase.getAnswerID(answer1.StageID, 1);
                answer1.Description = Dbase.getAnswerDescription(answer1.ID);
                answer1.NextStageID = Dbase.getNextStageID(answer1.ID);

                answer2.StageID = stage.ID;
                answer2.ID = Dbase.getAnswerID(answer2.StageID, 2);
                answer2.Description = Dbase.getAnswerDescription(answer2.ID);
                answer2.NextStageID = Dbase.getNextStageID(answer2.ID);

            }
            else if (AnswerNumber == 2)
            {

                stage.ID = Dbase.getStageID(stage.ScenarioID, answer2.NextStageID);
                stage.AudioFilePath = Dbase.getAudioFilePath(stage.ID);
                stage.Description = Dbase.getStageDescription(stage.ID);
                stage.ImageFilePath = Dbase.getImageFilePath(stage.ID);


                answer1.StageID = stage.ID;
                answer1.ID = Dbase.getAnswerID(answer1.StageID, 1);
                answer1.Description = Dbase.getAnswerDescription(answer1.ID);
                answer1.NextStageID = Dbase.getNextStageID(answer1.ID);

                answer2.StageID = stage.ID;
                answer2.ID = Dbase.getAnswerID(answer2.StageID, 2);
                answer2.Description = Dbase.getAnswerDescription(answer2.ID);
                answer2.NextStageID = Dbase.getNextStageID(answer2.ID);
            }
        }
    }
}
