﻿using System;
using Classes;
using ClassInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*
 * This test class tests the IScenarioPiece interface and its properties.
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
        public void IScenarioPieceInterface_SetToScenarioObject_DefaultConstructor_IsNotNull()
        {
            // Arrange
            IScenarioPiece sut;

            // Act
            sut = new Scenario();

            //Assert
            Assert.IsNotNull(sut, "The IScenarioPiece Set To Scenario Default Constructor is NOT null");
        }

        [TestMethod]
        public void IScenarioPieceInterface_SetToStageObject_DefaultConstructor_IsNotNull()
        {
            // Arrange
            IScenarioPiece sut;

            // Act
            sut = new Stage();

            //Assert
            Assert.IsNotNull(sut, "The IScenarioPiece Set To Stage Default Constructor is NOT null");
        }

        [TestMethod]
        public void IScenarioPieceInterface_SetToScenario_IsItInstanceOfType_Scenario_Test()
        {
            // Arrange
            IScenarioPiece sut;

            // Act
            sut = new Scenario();

            //Assert
            Assert.IsInstanceOfType(sut, typeof(Scenario), "IScenarioPiece set to a Scenario is an instance of a Scenario.");
        }

        [TestMethod]
        public void IScenarioPieceInterface_SetToStage_IsItInstanceOfType_Stage_Test()
        {
            // Arrange
            IScenarioPiece sut;

            // Act
            sut = new Stage();

            //Assert
            Assert.IsInstanceOfType(sut, typeof(Stage), "IScenarioPiece set to a Stage is an instance of a Stage.");
        }

        [TestMethod]
        public void IScenarioPieceInterface_SetToScenarioObject_AccessorMethods_Test()
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
        public void IScenarioPieceInterface_SetToStageObject_AccessorMethods_Test()
        {
            // Arrange
            IScenarioPiece sut;
            Stage stage = new Stage(3, "name", "description", 1, "C:\\Users\\parent\\audio\\audiofile1", "C:\\Users\\parent\\image\\imagefile1", "test answe1", 5, "test answe2", 7);

            // Act
            sut = stage;

            //Assert
            Assert.AreEqual(sut.ID, stage.ID, "IScenarioPiece public ID Accessor method is working properly.");
            Assert.AreEqual(sut.Name, stage.Name, "IScenarioPiece public Name Accessor method is working properly.");
            Assert.AreEqual(sut.Description, stage.Description, "IScenarioPiece public Description Accessor method is working properly.");
        }
    }
}