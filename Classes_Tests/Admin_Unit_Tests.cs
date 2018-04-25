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
    }
}
