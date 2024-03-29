﻿using Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*
 * This test class tests the Stage class and its methods.
 *
 * author: Group 7 (Stephen Bailey, Omar Garcia, Craig Wyse, Matthew Harris)
 * course: SEII
 * assignment: InRealLife (Group Project Spring 2018)
 * date: 04/10/2018
 * file name: Stage_Unit_Tests.cs
 * version: 1.0
 */
namespace Classes_Tests
{
    [TestClass]
    public class Stage_Unit_Tests
    {
        [TestMethod]
        public void Stage_DefaultConstructor_IsNotNull()
        {
            // Arrange
            Stage sut;

            // Act
            sut = new Stage();

            //Assert
            Assert.IsNotNull(sut, "The Stage Default Constructor is NOT null");
        }

        [TestMethod]
        public void Stage_DefaultConstructor_IsInstanceOfType_Stage_Test()
        {
            // Arrange
            Stage sut;

            // Act
            sut = new Stage();

            //Assert
            Assert.IsInstanceOfType(sut, typeof(Stage), "Stage default constructor is a valid Stage.");
        }

        [TestMethod]
        public void Stage_ParameterConstructor_IsNotNull()
        {
            // Arrange
            int iD = 0;
            string name = string.Empty;
            string description = string.Empty;
            int scenarioID = 0;
            string audioFilePath = string.Empty;
            string imageFilePath = string.Empty;
            string answer1 = string.Empty;
            int ans1NextStagID = 0;
            string answer2 = string.Empty;
            int ans2NextStagID = 0;

            Stage sut;

            // Act
            sut = new Stage(iD, name, description, scenarioID, audioFilePath, imageFilePath, answer1, ans1NextStagID, answer2, ans2NextStagID);

            //Assert
            Assert.IsNotNull(sut, "The Stage Parameter Constructor is NOT null");
        }

        [TestMethod]
        public void Stage_ParameterConstructor_IsInstanceOfType_Stage_Test()
        {
            // Arrange
            int iD = 5;
            string name = "Pull over or keep driving";
            string description = "Do your pull over or do you keep driving";
            int scenarioID = 1;
            string audioFilePath = "C:\\Users\\parent\\audio\\audiofile1";
            string imageFilePath = "C:\\Users\\parent\\image\\imagefile1";
            string answer1 = "test answe1";
            int Ans1NextStagID = 4;
            string answer2 = "test answe2";
            int Ans2NextStagID = 5;

            Stage sut;

            // Act
            sut = new Stage(iD, name, description, scenarioID, audioFilePath, imageFilePath, answer1, Ans1NextStagID, answer2, Ans2NextStagID);

            //Assert
            Assert.IsInstanceOfType(sut, typeof(Stage), "Stage Parameter constructor is a Stage.");
        }

        [TestMethod]
        public void Stage_DefaultConstructor_AccessorMethods_Test()
        {
            // Arrange
            int iD = 0;
            string name = string.Empty;
            string description = string.Empty;
            int scenarioID = 0;
            string audioFilePath = string.Empty;
            string imageFilePath = string.Empty;
            string answer1 = string.Empty;
            int ans1NextStagID = 0;
            string answer2 = string.Empty;
            int ans2NextStagID = 0;

            Stage sut;

            // Act
            sut = new Stage();

            //Assert
            Assert.AreEqual(iD, sut.ID, "Stage public ID Accessor method is working properly.");
            Assert.AreEqual(name, sut.Name, "Stage public Name Accessor method is working properly.");
            Assert.AreEqual(description, sut.Description, "Stage public Description Accessor method is working properly.");
            Assert.AreEqual(scenarioID, sut.ScenarioID, "Stage public ScenarioID Accessor method is working properly.");
            Assert.AreEqual(audioFilePath, sut.AudioFilePath, "Stage public AudioFilePath Accessor method is working properly.");
            Assert.AreEqual(imageFilePath, sut.ImageFilePath, "Stage public ImageFilePath Accessor method is working properly.");
            Assert.AreEqual(answer1, sut.Answer1, "Stage public Answer1ID Accessor method is working properly.");
            Assert.AreEqual(ans1NextStagID, sut.Ans1NextStagID, "Stage public Ans1NextStagID Accessor method is working properly.");
            Assert.AreEqual(answer2, sut.Answer2, "Stage public Answer2ID Accessor method is working properly.");
            Assert.AreEqual(ans2NextStagID, sut.Ans2NextStagID, "Stage public Ans2NextStagID Accessor method is working properly.");
        }

        [TestMethod]
        public void Stage_ParameterConstructor_AccessorMethods_Test()
        {
            // Arrange
            int iD = 5;
            string name = "Pull over or keep driving";
            string description = "Do your pull over or do you keep driving";
            int scenarioID = 1;
            string audioFilePath = "C:\\Users\\parent\\audio\\audiofile1";
            string imageFilePath = "C:\\Users\\parent\\image\\imagefile1";
            string answer1 = "test answe1";
            int Ans1NextStagID = 4;
            string answer2 = "test answe2";
            int Ans2NextStagID = 5;

            Stage sut;

            // Act
            sut = new Stage(iD, name, description, scenarioID, audioFilePath, imageFilePath, answer1, Ans1NextStagID, answer2, Ans2NextStagID);

            //Assert
            Assert.AreEqual(5, sut.ID, "Stage public ID Accessor method is working properly.");
            Assert.AreEqual("Pull over or keep driving", sut.Name, "Stage public Name Accessor method is working properly.");
            Assert.AreEqual("Do your pull over or do you keep driving", sut.Description, "Stage public Description Accessor method is working properly.");
            Assert.AreEqual(1, sut.ScenarioID, "Stage public ScenarioID Accessor method is working properly.");
            Assert.AreEqual("C:\\Users\\parent\\audio\\audiofile1", sut.AudioFilePath, "Stage public AudioFilePath Accessor method is working properly.");
            Assert.AreEqual("C:\\Users\\parent\\image\\imagefile1", sut.ImageFilePath, "Stage public ImageFilePath Accessor method is working properly.");
            Assert.AreEqual("test answe1", sut.Answer1, "Stage public Answer1ID Accessor method is working properly.");
            Assert.AreEqual(4, sut.Ans1NextStagID, "Stage public Ans1NextStagID Accessor method is working properly.");
            Assert.AreEqual("test answe2", sut.Answer2, "Stage public Answer2ID Accessor method is working properly.");
            Assert.AreEqual(5, sut.Ans2NextStagID, "Stage public Ans2NextStagID Accessor method is working properly.");
        }

        [TestMethod]
        public void Stage_DefaultConstructor_MutatorMethods_Test()
        {
            // Arrange
            int iD = 5;
            string name = "Pull over or keep driving";
            string description = "Do your pull over or do you keep driving";
            int scenarioID = 1;
            string audioFilePath = "C:\\Users\\parent\\audio\\audiofile1";
            string imageFilePath = "C:\\Users\\parent\\image\\imagefile1";
            string answer1 = "test answe1";
            int ans1NextStagID = 4;
            string answer2 = "test answe2";
            int ans2NextStagID = 5;

            Stage sut;

            // Act
            sut = new Stage();
            sut.ID = iD;
            sut.Name = name;
            sut.Description = description;
            sut.ScenarioID = scenarioID;
            sut.AudioFilePath = audioFilePath;
            sut.ImageFilePath = imageFilePath;
            sut.Answer1 = answer1;
            sut.Ans1NextStagID = ans1NextStagID;
            sut.Answer2 = answer2;
            sut.Ans2NextStagID = ans2NextStagID;

            //Assert
            Assert.AreEqual(5, sut.ID, "Stage public ID Accessor method is working properly.");
            Assert.AreEqual("Pull over or keep driving", sut.Name, "Stage public Name Accessor method is working properly.");
            Assert.AreEqual("Do your pull over or do you keep driving", sut.Description, "Stage public Description Accessor method is working properly.");
            Assert.AreEqual(1, sut.ScenarioID, "Stage public ScenarioID Accessor method is working properly.");
            Assert.AreEqual("C:\\Users\\parent\\audio\\audiofile1", sut.AudioFilePath, "Stage public AudioFilePath Accessor method is working properly.");
            Assert.AreEqual("C:\\Users\\parent\\image\\imagefile1", sut.ImageFilePath, "Stage public ImageFilePath Accessor method is working properly.");
            Assert.AreEqual("test answe1", sut.Answer1, "Stage public Answer1ID Accessor method is working properly.");
            Assert.AreEqual(4, sut.Ans1NextStagID, "Stage public Ans1NextStagID Accessor method is working properly.");
            Assert.AreEqual("test answe2", sut.Answer2, "Stage public Answer2ID Accessor method is working properly.");
            Assert.AreEqual(5, sut.Ans2NextStagID, "Stage public Ans2NextStagID Accessor method is working properly.");
        }

        [TestMethod]
        public void Stage_ParameterConstructor_MutatorMethods_Test()
        {
            // Arrange
            int iD = 5;
            string name = "Pull over or keep driving";
            string description = "Do your pull over or do you keep driving";
            int scenarioID = 1;
            string audioFilePath = "C:\\Users\\parent\\audio\\audiofile1";
            string imageFilePath = "C:\\Users\\parent\\image\\imagefile1";
            string answer1 = "test answe1";
            int Ans1NextStagID = 4;
            string answer2 = "test answe2";
            int Ans2NextStagID = 5;

            Stage sut;

            // Act
            sut = new Stage(iD, name, description, scenarioID, audioFilePath, imageFilePath, answer1, Ans1NextStagID, answer2, Ans2NextStagID);
            sut.ID = 9;
            sut.Name = "Turn Up radio or turn down radio";
            sut.Description = "Turn up radio and ignor or turn down radio and listen to vehicle";
            sut.ScenarioID = 2;
            sut.AudioFilePath = "C:\\Users\\parent\\audio\\audiofile2";
            sut.ImageFilePath = "C:\\Users\\parent\\image\\imagefile3";
            sut.Answer1 = "test answe1";
            sut.Ans1NextStagID = 15;
            sut.Answer2 = "test answe2";
            sut.Ans2NextStagID = 25;

            //Assert
            Assert.AreEqual(9, sut.ID, "Stage public ID Mutator method is working properly.");
            Assert.AreEqual("Turn Up radio or turn down radio", sut.Name, "Stage public Name Mutator method is working properly.");
            Assert.AreEqual("Turn up radio and ignor or turn down radio and listen to vehicle", sut.Description, "Stage public Description Mutator method is working properly.");
            Assert.AreEqual(2, sut.ScenarioID, "Stage public ScenarioID Mutator method is working properly.");
            Assert.AreEqual("C:\\Users\\parent\\audio\\audiofile2", sut.AudioFilePath, "Stage public AudioFilePath Mutator method is working properly.");
            Assert.AreEqual("C:\\Users\\parent\\image\\imagefile3", sut.ImageFilePath, "Stage public ImageFilePath Mutator method is working properly.");
            Assert.AreEqual("test answe1", sut.Answer1, "Stage public Answer1ID Mutator method is working properly.");
            Assert.AreEqual(15, sut.Ans1NextStagID, "Stage public Ans1NextStagID Mutator method is working properly.");
            Assert.AreEqual("test answe2", sut.Answer2, "Stage public Answer2ID Mutator method is working properly.");
            Assert.AreEqual(25, sut.Ans2NextStagID, "Stage public Ans2NextStagID Mutator method is working properly.");
        }
    }
}