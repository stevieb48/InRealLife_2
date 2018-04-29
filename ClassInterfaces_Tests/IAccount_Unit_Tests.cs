using System;
using Classes;
using ClassInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassInterfaces_Tests
{
    [TestClass]
    public class IAccount_Unit_Tests
    {
        [TestMethod]
        public void IAccountInterface_SetToAdminObject_DefaultConstructor_IsNotNull()
        {
            // Arrange
            IAccount sut;

            // Act
            sut = new Admin();

            //Assert
            Assert.IsNotNull(sut, "The IAccount Set To Admin Default Constructor is NOT null");
        }

        [TestMethod]
        public void IAccountInterface_SetToChildObject_DefaultConstructor_IsNotNull()
        {
            // Arrange
            IAccount sut;

            // Act
            sut = new Child();

            //Assert
            Assert.IsNotNull(sut, "The IAccount Set To Child Default Constructor is NOT null");
        }

        [TestMethod]
        public void IAccountInterface_SetToAdmin_IsItInstanceOfType_Admin_Test()
        {
            // Arrange
            IAccount sut;

            // Act
            sut = new Admin();

            //Assert
            Assert.IsInstanceOfType(sut, typeof(Admin), "IAccount set to a Admin is an instance of a Admin.");
        }

        [TestMethod]
        public void IAccountInterface_SetToChild_IsItInstanceOfType_Child_Test()
        {
            // Arrange
            IAccount sut;

            // Act
            sut = new Child();

            //Assert
            Assert.IsInstanceOfType(sut, typeof(Child), "IAccount set to a Child is an instance of a Child.");
        }

        [TestMethod]
        public void IAccountInterface_SetToAdminObject_AccessorMethods_Test()
        {
            // Arrange
            IAccount sut;
            Admin admin = new Admin(3, "name", "login", "password", true, "1,2,3");

            // Act
            sut = admin;

            //Assert
            Assert.AreEqual(sut.ID, admin.ID, "IAccount public ID Accessor method is working properly.");
            Assert.AreEqual(sut.Name, admin.Name, "IAccount public Name Accessor method is working properly.");
            Assert.AreEqual(sut.Login, admin.Login, "IAccount public Login Accessor method is working properly.");
            Assert.AreEqual(sut.Password, admin.Password, "IAccount public Password Accessor method is working properly.");
            Assert.AreEqual(sut.GlobalAccess, admin.GlobalAccess, "IAccount public GlobalAccess Accessor method is working properly.");
            Assert.AreEqual(sut.Scenarios, admin.Scenarios, "IAccount public Scenarios Accessor method is working properly.");
        }

        [TestMethod]
        public void IAccountInterface_SetToChildObject_AccessorMethods_Test()
        {
            // Arrange
            IAccount sut;
            Child child = new Child(3, "name", "login", "password", true, "1,2,3");

            // Act
            sut = child;

            //Assert
            Assert.AreEqual(sut.ID, child.ID, "IAccount public ID Accessor method is working properly.");
            Assert.AreEqual(sut.Name, child.Name, "IAccount public Name Accessor method is working properly.");
            Assert.AreEqual(sut.Login, child.Login, "IAccount public Login Accessor method is working properly.");
            Assert.AreEqual(sut.Password, child.Password, "IAccount public Password Accessor method is working properly.");
            Assert.AreEqual(sut.GlobalAccess, child.GlobalAccess, "IAccount public GlobalAccess Accessor method is working properly.");
            Assert.AreEqual(sut.Scenarios, child.Scenarios, "IAccount public Scenarios Accessor method is working properly.");
        }
    }
}
