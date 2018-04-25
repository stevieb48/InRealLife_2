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
    }
}
