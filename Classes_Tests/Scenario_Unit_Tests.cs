using Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*
 * This test class tests the Scenario class and its methods.
 *
 * author: Group 7 (Stephen Bailey, Omar Garcia, Craig Wyse, Matthew Harris)
 * course: SEII
 * assignment: InRealLife (Group Project Spring 2018)
 * date: 04/10/2018
 * file name: Scenario_Unit_Tests.cs
 * version: 1.0
 */
namespace Classes_Tests
{
    [TestClass]
    public class Scenario_Unit_Tests
    {
        [TestMethod]
        public void Scenario_DefaultConstructor_IsNotNull()
        {
            // Arrange
            Scenario sut;

            // Act
            sut = new Scenario();

            //Assert
            Assert.IsNotNull(sut, "The Scenario Default Constructor is NOT null");
        }

        [TestMethod]
        public void Scenario_DefaultConstructor_IsInstanceOfType_Scenario_Test()
        {
            // Arrange
            Scenario sut;

            // Act
            sut = new Scenario();

            //Assert
            Assert.IsInstanceOfType(sut, typeof(Scenario), "Scenario default constructor is a Scenario.");
        }

        [TestMethod]
        public void Scenario_ParameterConstructor_IsNotNull_Instance_Test()
        {
            // Arrange
            int iD = 19;
            string name = "Flat tire";
            string description = "The tire on your vehicle goes flat ...";

            Scenario sut;

            // Act
            sut = new Scenario(iD, name, description);

            //Assert
            Assert.IsNotNull(sut, "The Scenario Parameter Constructor is NOT null");
        }

        [TestMethod]
        public void Scenario_ParameterConstructor_IsInstanceOfType_Scenario_Test()
        {
            // Arrange
            int iD = 19;
            string name = "Flat tire";
            string description = "The tire on your vehicle goes flat ...";

            Scenario sut;

            // Act
            sut = new Scenario(iD, name, description);

            //Assert
            Assert.IsInstanceOfType(sut, typeof(Scenario), "Scenario Parameter constructor is a Scenario.");
        }

        [TestMethod]
        public void Scenario_DefaultConstructor_AccessorMethods_Test()
        {
            // Arrange
            int iD = 0;
            string name = string.Empty;
            string description = string.Empty;

            Scenario sut;

            // Act
            sut = new Scenario();

            //Assert
            Assert.AreEqual(iD, sut.ID, "Scenario public ID Accessor method is working properly.");
            Assert.AreEqual(name, sut.Name, "Scenario public Name Accessor method is working properly.");
            Assert.AreEqual(description, sut.Description, "Scenario public Description Accessor method is working properly.");
        }

        [TestMethod]
        public void Scenario_ParameterConstructor_AccessorMethods_Test()
        {
            // Arrange
            int iD = 19;
            string name = "Flat tire";
            string description = "The tire on your vehicle goes flat ...";

            Scenario sut;

            // Act
            sut = new Scenario(iD, name, description);

            //Assert
            Assert.AreEqual(19, sut.ID, "Scenario public ID Accessor method is working properly.");
            Assert.AreEqual("Flat tire", sut.Name, "Scenario public Name Accessor method is working properly.");
            Assert.AreEqual("The tire on your vehicle goes flat ...", sut.Description, "Scenario public Description Accessor method is working properly.");
        }

        [TestMethod]
        public void Scenario_DefaultConstructor_MutatorMethods_Test()
        {
            // Arrange
            int iD = 3;
            string name = "Dirty Laundry";
            string description = "You see clothes piling up in the corner of your room";

            Scenario sut;

            // Act
            sut = new Scenario();
            sut.ID = iD;
            sut.Name = name;
            sut.Description = description;

            //Assert
            Assert.AreEqual(3, sut.ID, "Scenario public ID Accessor method is working properly.");
            Assert.AreEqual("Dirty Laundry", sut.Name, "Scenario public Name Accessor method is working properly.");
            Assert.AreEqual("You see clothes piling up in the corner of your room", sut.Description, "Scenario public Description Accessor method is working properly.");
        }

        [TestMethod]
        public void Scenario_ParameterConstructor_MutatorMethods_Test()
        {
            // Arrange
            int iD = 19;
            string name = "Flat tire";
            string description = "The tire on your vehicle goes flat ...";

            Scenario sut;

            // Act
            sut = new Scenario(iD, name, description);
            sut.ID = 5;
            sut.Name = "Engine noise";
            sut.Description = "You are driving down the road and you here a funny sound coming from your vehicle";

            //Assert
            Assert.AreEqual(5, sut.ID, "Scenario public ID Accessor method is working properly.");
            Assert.AreEqual("Engine noise", sut.Name, "Scenario public Name Accessor method is working properly.");
            Assert.AreEqual("You are driving down the road and you here a funny sound coming from your vehicle", sut.Description, "Scenario public Description Accessor method is working properly.");
        }
    }
}