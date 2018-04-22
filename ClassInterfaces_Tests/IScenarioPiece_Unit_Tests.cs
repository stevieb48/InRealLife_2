using System;
using Classes;
using ClassInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*
 * This test class ...
 *
 * author: Group 7 (Stephen Bailey, Omar Garcia, Craig Wyse, Matthew Harris)
 * course: SEII
 * assignment: InRealLife (Group Project Spring 2018)
 * date: 04/10/2018
 * file name: IScenarioPiece_Unit_Tests.cs
 * version: 1.0
 */
namespace ClassInterfaces_Tests
{
    [TestClass]
    public class IScenarioPiece_Unit_Tests
    {
        [TestMethod]
        public void IScenarioPieceInterface_SetToScenarioObject_DefaultConstructor_IsNotNull_Instance_Test()
        {
            // Arrange
            IScenarioPiece sut;

            // Act
            sut = new Scenario();

            //Assert
            Assert.IsNotNull(sut, "The IScenarioPiece Set To Scenario Default Constructor is NOT null");
        }

        [TestMethod]
        public void IScenarioPieceInterface_SetToStageObject_DefaultConstructor_IsNotNull_Instance_Test()
        {
            // Arrange
            IScenarioPiece sut;

            // Act
            sut = new Stage();

            //Assert
            Assert.IsNotNull(sut, "The IScenarioPiece Set To Stage Default Constructor is NOT null");
        }

        [TestMethod]
        public void IScenarioPieceInterface_SetToAnswerObject_DefaultConstructor_IsNotNull_Instance_Test()
        {
            // Arrange
            IScenarioPiece sut;

            // Act
            sut = new Answer();

            //Assert
            Assert.IsNotNull(sut, "The IScenarioPiece Set To Answer Default Constructor is NOT null");
        }

        [TestMethod]
        public void IScenarioPiece_SetToScenario_IsItInstanceOfType_Scenario_Test()
        {
            // Arrange
            IScenarioPiece sut;

            // Act
            sut = new Scenario();

            //Assert
            Assert.IsInstanceOfType(sut, typeof(Scenario), "IScenarioPiece set to a Scenario is an instance of a Scenario.");
        }

        [TestMethod]
        public void IScenarioPiece_SetToStage_IsItInstanceOfType_Stage_Test()
        {
            // Arrange
            IScenarioPiece sut;

            // Act
            sut = new Stage();

            //Assert
            Assert.IsInstanceOfType(sut, typeof(Stage), "IScenarioPiece set to a Stage is an instance of a Stage.");
        }

        [TestMethod]
        public void IScenarioPiece_SetToAnswer_IsItInstanceOfType_Answer_Test()
        {
            // Arrange
            IScenarioPiece sut;

            // Act
            sut = new Answer();

            //Assert
            Assert.IsInstanceOfType(sut, typeof(Answer), "IScenarioPiece set to a Answer is an instance of a Answer.");
        }

        [TestMethod]
        public void IScenarioPiece_SetToScenarioObject_AccessorMethods_Test()
        {
            // Arrange
            IScenarioPiece sut;
            Scenario scenario = new Scenario(3, "name", "description");

            // Act
            sut = scenario;

            //Assert
            Assert.AreEqual(sut.ID, scenario.ID, "IScenarioPiece public ID Accessor method is working properly.");
            Assert.AreEqual(sut.Name, scenario.Name, "IScenarioPiece public Name Accessor method is working properly.");
            Assert.AreEqual(sut.Description, scenario.Description, "IScenarioPiece public Description Accessor method is working properly.");
        }

        [TestMethod]
        public void IScenarioPiece_SetToStageObject_AccessorMethods_Test()
        {
            // Arrange
            IScenarioPiece sut;
            Stage stage = new Stage(3, "name", "description", 1, "C:\\Users\\parent\\audio\\audiofile1", "C:\\Users\\parent\\image\\imagefile1", "test answe1",5, "test answe2",7);

            // Act
            sut = stage;

            //Assert
            Assert.AreEqual(sut.ID, stage.ID, "IScenarioPiece public ID Accessor method is working properly.");
            Assert.AreEqual(sut.Name, stage.Name, "IScenarioPiece public Name Accessor method is working properly.");
            Assert.AreEqual(sut.Description, stage.Description, "IScenarioPiece public Description Accessor method is working properly.");
        }

        [TestMethod]
        public void IScenarioPiece_SetToAnswerObject_AccessorMethods_Test()
        {
            // Arrange
            IScenarioPiece sut;
            Answer answer = new Answer(3, "name", "description");

            // Act
            sut = answer;

            //Assert
            Assert.AreEqual(sut.ID, answer.ID, "IScenarioPiece public ID Accessor method is working properly.");
            Assert.AreEqual(sut.Name, answer.Name, "IScenarioPiece public Name Accessor method is working properly.");
            Assert.AreEqual(sut.Description, answer.Description, "IScenarioPiece public Description Accessor method is working properly.");
        }
    }
}