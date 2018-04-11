using System;
using Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            Assert.IsInstanceOfType(sut, Answer, "Answer default constructor is a valid Answer.");
        }
    }
}
