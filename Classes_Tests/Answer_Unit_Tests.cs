using System;
using Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*
 * This test class ...
 *
 * author: Group 7 (Stephen Bailey, Omar Garcia, Craig Wyse, Matthew Harris)
 * course: SEII
 * assignment: InRealLife (Group Project Spring 2018)
 * date: 04/10/2018
 * file name: Answer_Unit_Tests.cs
 * version: 1.0
 */
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
            Assert.IsInstanceOfType(sut, typeof(Answer), "Answer default constructor is a valid Answer.");
        }

        [TestMethod]
        public void Answer_ParameterConstructor_IsNotNull_Instance_Test()
        {
            // Arrange
            int iD = 0;
            string name = string.Empty;
            string description = string.Empty;

            Answer sut;

            // Act
            sut = new Answer(iD, name, description);

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

            Answer sut;

            // Act
            sut = new Answer(iD, name, description);

            //Assert
            Assert.IsInstanceOfType(sut, typeof(Answer), "Answer Parameter constructor is a Answer.");
        }

        [TestMethod]
        public void Answer_DefaultConstructor_AccessorMethods_Test()
        {
            // Arrange
            int iD = 0;
            string name = string.Empty;
            string description = string.Empty;

            Answer sut;

            // Act
            sut = new Answer();

            //Assert
            Assert.AreEqual(iD, sut.ID, "Answer public ID Accessor method is working properly.");
            Assert.AreEqual(name, sut.Name, "Answer public Name Accessor method is working properly.");
            Assert.AreEqual(description, sut.Description, "Answer public Description Accessor method is working properly.");
        }

        [TestMethod]
        public void Answer_ParameterConstructor_AccessorMethods_Test()
        {
            // Arrange
            int iD = 8;
            string name = "Keep Driving";
            string description = "Keep driving and ignore the issue";

            Answer sut;

            // Act
            sut = new Answer(iD, name, description);

            //Assert
            Assert.AreEqual(8, sut.ID, "Answer public ID Accessor method is working properly.");
            Assert.AreEqual("Keep Driving", sut.Name, "Answer public Name Accessor method is working properly.");
            Assert.AreEqual("Keep driving and ignore the issue", sut.Description, "Answer public Description Accessor method is working properly.");
        }




        [TestMethod]
        public void Answer_DefaultConstructor_MutatorMethods_Test()
        {
            // Arrange
            int iD = 8;
            string name = "Keep Driving";
            string description = "Keep driving and ignore the issue";

            Answer sut;

            // Act
            sut = new Answer();
            sut.ID = iD;
            sut.Name = name;
            sut.Description = description;

            //Assert
            Assert.AreEqual(8, sut.ID, "Answer public ID Accessor method is working properly.");
            Assert.AreEqual("Keep Driving", sut.Name, "Answer public Name Accessor method is working properly.");
            Assert.AreEqual("Keep driving and ignore the issue", sut.Description, "Answer public Description Accessor method is working properly.");
        }

        [TestMethod]
        public void Answer_ParameterConstructor_MutatorMethods_Test()
        {
            // Arrange
            int iD = 8;
            string name = "Keep Driving";
            string description = "Keep driving and ignore the issue";

            Answer sut;

            // Act
            sut = new Answer(iD, name, description);
            sut.ID = 9;
            sut.Name = "Slow Down";
            sut.Description = "Slow down and listen for sounds from vehicle";

            //Assert
            Assert.AreEqual(9, sut.ID, "Answer public ID Accessor method is working properly.");
            Assert.AreEqual("Slow Down", sut.Name, "Answer public Name Accessor method is working properly.");
            Assert.AreEqual("Slow down and listen for sounds from vehicle", sut.Description, "Answer public Description Accessor method is working properly.");
        }
    }
}