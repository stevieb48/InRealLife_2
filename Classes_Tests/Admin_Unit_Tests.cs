using System;
using Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Classes_Tests
{
    [TestClass]
    public class Admin_Unit_Tests
    {
        [TestMethod]
        public void Admin_DefaultConstructor_IsNotNull()
        {
            // Arrange
            Admin sut;

            // Act
            sut = new Admin();

            //Assert
            Assert.IsNotNull(sut, "The Admin Default Constructor is NOT null");
        }

        [TestMethod]
        public void Admin_DefaultConstructor_IsInstanceOfType_Admin_Test()
        {
            // Arrange
            Admin sut;

            // Act
            sut = new Admin();

            //Assert
            Assert.IsInstanceOfType(sut, typeof(Admin), "Admin default constructor is a Admin.");
        }

        [TestMethod]
        public void Admin_ParameterConstructor_IsNotNull()
        {
            // Arrange
            int iD = 0;
            string name = string.Empty;
            string login = string.Empty;
            string password = string.Empty;
            bool globalAccess = false;
            string scenarios = string.Empty;

            Admin sut;

            // Act
            sut = new Admin(iD, name, login, password, globalAccess, scenarios);

            //Assert
            Assert.IsNotNull(sut, "The Admin Parameter Constructor is NOT null");
        }

        [TestMethod]
        public void Admin_ParameterConstructor_IsInstanceOfType_Admin_Test()
        {
            // Arrange
            int iD = 1;
            string name = "fred";
            string login = "fr345";
            string password = "abcdefg";
            bool globalAccess = false;
            string scenarios = "1,2,3,4";

            Admin sut;

            // Act
            sut = new Admin(iD, name, login, password, globalAccess, scenarios);

            //Assert
            Assert.IsInstanceOfType(sut, typeof(Admin), "Admin Parameter constructor is a Admin.");
        }

        [TestMethod]
        public void Admin_DefaultConstructor_AccessorMethods_Test()
        {
            // Arrange
            int iD = 0;
            string name = string.Empty;
            string login = string.Empty;
            string password = string.Empty;
            bool globalAccess = false;
            string scenarios = string.Empty;

            Admin sut;

            // Act
            sut = new Admin();

            //Assert
            Assert.AreEqual(iD, sut.ID, "Admin public ID Accessor method is working properly.");
            Assert.AreEqual(name, sut.Name, "Admin public Name Accessor method is working properly.");
            Assert.AreEqual(login, sut.Login, "Admin public login Accessor method is working properly.");
            Assert.AreEqual(password, sut.Password, "Admin public password Accessor method is working properly.");
            Assert.AreEqual(globalAccess, sut.GlobalAccess, "Admin public globalAccess Accessor method is working properly.");
            Assert.AreEqual(scenarios, sut.Scenarios, "Admin public scenarios Accessor method is working properly.");
        }

        [TestMethod]
        public void Admin_ParameterConstructor_AccessorMethods_Test()
        {
            // Arrange
            int iD = 1;
            string name = "fred";
            string login = "fr345";
            string password = "abcdefg";
            bool globalAccess = false;
            string scenarios = "1,2,3,4";

            Admin sut;

            // Act
            sut = new Admin(iD, name, login, password, globalAccess, scenarios);

            //Assert
            Assert.AreEqual(1, sut.ID, "Admin public ID Accessor method is working properly.");
            Assert.AreEqual("fred", sut.Name, "Admin public Name Accessor method is working properly.");
            Assert.AreEqual("fr345", sut.Login, "Admin public login Accessor method is working properly.");
			Assert.AreEqual("abcdefg", sut.Password, "Admin public Password Accessor method is working properly.");
            Assert.AreEqual(false, sut.GlobalAccess, "Admin public GlobalAccess Accessor method is working properly.");
            Assert.AreEqual("1,2,3,4", sut.Scenarios, "Admin public Scenarios Accessor method is working properly.");
        }

        [TestMethod]
        public void Admin_DefaultConstructor_MutatorMethods_Test()
        {
            // Arrange
            int iD = 1;
            string name = "fred";
            string login = "fr345";
            string password = "abcdefg";
            bool globalAccess = false;
            string scenarios = "1,2,3,4";

            Admin sut;

            // Act
            sut = new Admin();
            sut.ID = iD;
            sut.Name = name;
            sut.Login = login;
            sut.Password = password;
            sut.GlobalAccess = globalAccess;
            sut.Scenarios = scenarios;

            //Assert
            Assert.AreEqual(1, sut.ID, "Admin public ID Accessor method is working properly.");
            Assert.AreEqual("fred", sut.Name, "Admin public Name Accessor method is working properly.");
            Assert.AreEqual("fr345", sut.Login, "Admin public login Accessor method is working properly.");
			Assert.AreEqual("abcdefg", sut.Password, "Admin public Password Accessor method is working properly.");
            Assert.AreEqual(false, sut.GlobalAccess, "Admin public GlobalAccess Accessor method is working properly.");
            Assert.AreEqual("1,2,3,4", sut.Scenarios, "Admin public Scenarios Accessor method is working properly.");
        }

        [TestMethod]
        public void Admin_ParameterConstructor_MutatorMethods_Test()
        {
            // Arrange
            int iD = 1;
            string name = "fred";
            string login = "fr345";
            string password = "abcdefg";
            bool globalAccess = false;
            string scenarios = "1,2,3,4";

            Admin sut;

            // Act
            sut = new Admin(iD, name, login, password, globalAccess, scenarios);
            sut = new Admin();
            sut.ID = 2;
            sut.Name = "joe";
            sut.Login = "j678";
            sut.Password = "1234abdcg";
            sut.GlobalAccess = true;
            sut.Scenarios = "3,4";

            //Assert
            Assert.AreEqual(2, sut.ID, "Admin public ID Accessor method is working properly.");
            Assert.AreEqual("joe", sut.Name, "Admin public Name Accessor method is working properly.");
            Assert.AreEqual("j678", sut.Login, "Admin public login Accessor method is working properly.");
			Assert.AreEqual("1234abdcg", sut.Password, "Admin public Password Accessor method is working properly.");
            Assert.AreEqual(true, sut.GlobalAccess, "Admin public GlobalAccess Accessor method is working properly.");
            Assert.AreEqual("3,4", sut.Scenarios, "Admin public Scenarios Accessor method is working properly.");
        }
    }
}
