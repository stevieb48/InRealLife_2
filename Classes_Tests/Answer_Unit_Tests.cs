using System;
using Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Classes_Tests
{
    [TestClass]
    public class Answer_Unit_Tests
    {
        [TestMethod]
        public void Answer_DefaultConstructor_IsNotNull_Instance_Test()
        {
            // Arrange
            Answer sut;

            // Act
            sut = new Answer();

            //Assert
            Assert.IsNotNull(sut, "The Answer Default Constructor is NOT null");
        }

        [TestMethod]
        public void Answer_DefaultConstructor_IsInstanceOfType_Answer_Test()
        {
            // Arrange
            Answer sut;

            // Act
            sut = new Answer();

            //Assert
            Assert.IsInstanceOfType(sut, Answer, "Answer default constructor is a valid Answer.");
        }

        [TestMethod]
        public void Answer_ParameterConstructor_IsNotNull_Instance_Test()
        {
            // Arrange
            int iD = 0;
            string name = string.Empty;
            string description = string.Empty;
            int stageID = 0;
            int nextStageID = 0;

            Answer sut;

            // Act
            sut = new Answer(iD, name, description, stageID, nextStageID);

            //Assert
            Assert.IsNotNull(sut, "The Answer Parameter Constructor is NOT null");
        }

        [TestMethod]
        public void Answer_ParameterConstructor_IsInstanceOfType_Answer_Test()
        {
            // Arrange
            int iD = 0;
            string name = string.Empty;
            string description = string.Empty;
            int stageID = 0;
            int nextStageID = 0;

            Answer sut;

            // Act
            sut = new Answer(iD, name, description, stageID, nextStageID);

            //Assert
            Assert.IsInstanceOfType(sut, Answer, "Answer Parameter constructor is a Answer.");
        }

        [TestMethod]
        public void Answer_DefaultConstructor_AccessorMethods_Test()
        {
            // Arrange
            int iD = 0;
            string name = string.Empty;
            string description = string.Empty;
            int stageID = 0;
            int nextStageID = 0;

            Answer sut;

            // Act
            sut = new Answer();

            //Assert
            Assert.AreEqual(iD, sut.ID, "Answer public ID Accessor method is working properly.");
            Assert.AreEqual(name, sut.Name, "Answer public Name Accessor method is working properly.");
            Assert.AreEqual(description, sut.Description, "Answer public Description Accessor method is working properly.");
            Assert.AreEqual(stageID, sut.StageID, "Answer public ScenarioID Accessor method is working properly.");
            Assert.AreEqual(nextStageID, sut.NextStageID, "Answer public AudioFilePath Accessor method is working properly.");
        }

        [TestMethod]
        public void Answer_ParameterConstructor_AccessorMethods_Test()
        {
            // Arrange
            int iD = 8;
            string name = "Keep Driving";
            string description = "Keep driving and ignore the issue";
            int stageID = 4;
            int nextStageID = 9;

            Answer sut;

            // Act
            sut = new Answer(iD, name, description, stageID, nextStageID);

            //Assert
            Assert.AreEqual(8, sut.ID, "Answer public ID Accessor method is working properly.");
            Assert.AreEqual("Keep Driving", sut.Name, "Answer public Name Accessor method is working properly.");
            Assert.AreEqual("Keep driving and ignore the issue", sut.Description, "Answer public Description Accessor method is working properly.");
            Assert.AreEqual(4, sut.StageID, "Answer public ScenarioID Accessor method is working properly.");
            Assert.AreEqual(9, sut.NextStageID, "Answer public AudioFilePath Accessor method is working properly.");
        }




        [TestMethod]
        public void Answer_DefaultConstructor_MutatorMethods_Test()
        {
            // Arrange
            int iD = 8;
            string name = "Keep Driving";
            string description = "Keep driving and ignore the issue";
            int stageID = 4;
            int nextStageID = 9;

            Answer sut;

            // Act
            sut = new Answer();
            sut.ID = iD;
            sut.Name = name;
            sut.Description = description;
            sut.StageID = stageID;
            sut.NextStageID = nextStageID;

            //Assert
            Assert.AreEqual(8, sut.ID, "Answer public ID Accessor method is working properly.");
            Assert.AreEqual("Keep Driving", sut.Name, "Answer public Name Accessor method is working properly.");
            Assert.AreEqual("Keep driving and ignore the issue", sut.Description, "Answer public Description Accessor method is working properly.");
            Assert.AreEqual(4, sut.StageID, "Answer public ScenarioID Accessor method is working properly.");
            Assert.AreEqual(9, sut.NextStageID, "Answer public AudioFilePath Accessor method is working properly.");
        }

        [TestMethod]
        public void Answer_ParameterConstructor_MutatorMethods_Test()
        {
            // Arrange
            int iD = 8;
            string name = "Keep Driving";
            string description = "Keep driving and ignore the issue";
            int stageID = 4;
            int nextStageID = 9;

            Answer sut;

            // Act
            sut = new Answer(iD, name, description, stageID, nextStageID);
            sut.ID = 9;
            sut.Name = "Slow Down";
            sut.Description = "Slow down and listen for sounds from vehicle";
            sut.StageID = 5;
            sut.NextStageID = 12;

            //Assert
            Assert.AreEqual(9, sut.ID, "Answer public ID Accessor method is working properly.");
            Assert.AreEqual("Slow Down", sut.Name, "Answer public Name Accessor method is working properly.");
            Assert.AreEqual("Slow down and listen for sounds from vehicle", sut.Description, "Answer public Description Accessor method is working properly.");
            Assert.AreEqual(5, sut.StageID, "Answer public ScenarioID Accessor method is working properly.");
            Assert.AreEqual(12, sut.NextStageID, "Answer public AudioFilePath Accessor method is working properly.");
        }
    }
}