using System;
using Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Classes_Tests
{
    [TestClass]
    public class Child_Unit_Test
    {
        [TestMethod]
        public void Child_DefaultConstructor_IsNotNull()
        {
            // Arrange
            Child sut;

            // Act
            sut = new Child();

            //Assert
            Assert.IsNotNull(sut, "The Child Default Constructor is NOT null");
        }

        [TestMethod]
        public void Child_DefaultConstructor_IsInstanceOfType_Child_Test()
        {
            // Arrange
            Child sut;

            // Act
            sut = new Child();

            //Assert
            Assert.IsInstanceOfType(sut, typeof(Child), "Child default constructor is a Child.");
        }

        [TestMethod]
        public void Child_ParameterConstructor_IsNotNull()
        {
            // Arrange
            int iD = 0;
            string name = string.Empty;
            string login = string.Empty;
            string password = string.Empty;
            bool globalAccess = false;
            string scenarios = string.Empty;

            Child sut;

            // Act
            sut = new Child(iD, name, login, password, globalAccess, scenarios);

            //Assert
            Assert.IsNotNull(sut, "The Child Parameter Constructor is NOT null");
        }

        [TestMethod]
        public void Child_ParameterConstructor_IsInstanceOfType_Child_Test()
        {
            // Arrange
            int iD = 1;
            string name = "fred";
            string login = "fr345";
            string password = "abcdefg";
            bool globalAccess = false;
            string scenarios = "1,2,3,4";

            Child sut;

            // Act
            sut = new Child(iD, name, login, password, globalAccess, scenarios);

            //Assert
            Assert.IsInstanceOfType(sut, typeof(Child), "Child Parameter constructor is a Child.");
        }

        [TestMethod]
        public void Child_DefaultConstructor_AccessorMethods_Test()
        {
            // Arrange
            int iD = 0;
            string name = string.Empty;
            string login = string.Empty;
            string password = string.Empty;
            bool globalAccess = false;
            string scenarios = string.Empty;

            Child sut;

            // Act
            sut = new Child();

            //Assert
            Assert.AreEqual(iD, sut.ID, "Child public ID Accessor method is working properly.");
            Assert.AreEqual(name, sut.Name, "Child public Name Accessor method is working properly.");
            Assert.AreEqual(login, sut.Login, "Child public login Accessor method is working properly.");
            Assert.AreEqual(password, sut.Password, "Child public password Accessor method is working properly.");
            Assert.AreEqual(globalAccess, sut.GlobalAccess, "Child public globalAccess Accessor method is working properly.");
            Assert.AreEqual(scenarios, sut.Scenarios, "Child public scenarios Accessor method is working properly.");
        }

        [TestMethod]
        public void Child_ParameterConstructor_AccessorMethods_Test()
        {
            // Arrange
            int iD = 1;
            string name = "fred";
            string login = "fr345";
            string password = "abcdefg";
            bool globalAccess = false;
            string scenarios = "1,2,3,4";

            Child sut;

            // Act
            sut = new Child(iD, name, login, password, globalAccess, scenarios);

            //Assert
            Assert.AreEqual(1, sut.ID, "Child public ID Accessor method is working properly.");
            Assert.AreEqual("fred", sut.Name, "Child public Name Accessor method is working properly.");
            Assert.AreEqual("fr345", sut.Login, "Child public login Accessor method is working properly.");
            Assert.AreEqual("abcdefg", sut.Password, "Child public Password Accessor method is working properly.");
            Assert.AreEqual(false, sut.GlobalAccess, "Child public GlobalAccess Accessor method is working properly.");
            Assert.AreEqual("1,2,3,4", sut.Scenarios, "Child public Scenarios Accessor method is working properly.");
        }

        [TestMethod]
        public void Child_DefaultConstructor_MutatorMethods_Test()
        {
            // Arrange
            int iD = 1;
            string name = "fred";
            string login = "fr345";
            string password = "abcdefg";
            bool globalAccess = false;
            string scenarios = "1,2,3,4";

            Child sut;

            // Act
            sut = new Child();
            sut.ID = iD;
            sut.Name = name;
            sut.Login = login;
            sut.Password = password;
            sut.GlobalAccess = globalAccess;
            sut.Scenarios = scenarios;

            //Assert
            Assert.AreEqual(1, sut.ID, "Child public ID Accessor method is working properly.");
            Assert.AreEqual("fred", sut.Name, "Child public Name Accessor method is working properly.");
            Assert.AreEqual("fr345", sut.Login, "Child public login Accessor method is working properly.");
            Assert.AreEqual("abcdefg", sut.Password, "Child public Password Accessor method is working properly.");
            Assert.AreEqual(false, sut.GlobalAccess, "Child public GlobalAccess Accessor method is working properly.");
            Assert.AreEqual("1,2,3,4", sut.Scenarios, "Child public Scenarios Accessor method is working properly.");
        }

        [TestMethod]
        public void Child_ParameterConstructor_MutatorMethods_Test()
        {
            // Arrange
            int iD = 1;
            string name = "fred";
            string login = "fr345";
            string password = "abcdefg";
            bool globalAccess = false;
            string scenarios = "1,2,3,4";

            Child sut;

            // Act
            sut = new Child(iD, name, login, password, globalAccess, scenarios);
            sut = new Child();
            sut.ID = 2;
            sut.Name = "joe";
            sut.Login = "j678";
            sut.Password = "1234abdcg";
            sut.GlobalAccess = true;
            sut.Scenarios = "3,4";

            //Assert
            Assert.AreEqual(2, sut.ID, "Child public ID Accessor method is working properly.");
            Assert.AreEqual("joe", sut.Name, "Child public Name Accessor method is working properly.");
            Assert.AreEqual("j678", sut.Login, "Child public login Accessor method is working properly.");
            Assert.AreEqual("1234abdcg", sut.Password, "Child public Password Accessor method is working properly.");
            Assert.AreEqual(true, sut.GlobalAccess, "Child public GlobalAccess Accessor method is working properly.");
            Assert.AreEqual("3,4", sut.Scenarios, "Child public Scenarios Accessor method is working properly.");
        }
    }
}
