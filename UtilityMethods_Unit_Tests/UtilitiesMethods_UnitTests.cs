using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;

namespace UtilityMethods_Unit_Tests
{
    [TestClass]
    public class UtilitiesMethods_UnitTests
    {
        [TestMethod]
        public void ValInput_TestIfValidNumber()
        {
            // Arrange
            bool trueTest = true;
            bool testBool;
            var test = 10654785;

            // Act
            testBool = UtilityMethods.ValInputString(test.ToString());

            //Assert
            Assert.AreEqual(trueTest, testBool, "This true test number converted to true");
        }

        [TestMethod]
        public void ValInput_TestIfValidLetter()
        {
            // Arrange
            bool trueTest = true;
            bool testBool;
            var test = "iuywgvfiugfdf";

            // Act
            testBool = UtilityMethods.ValInputString(test.ToString());

            //Assert
            Assert.AreEqual(trueTest, testBool, "This true test String converted to true");
        }

        [TestMethod]
        public void ValInput_TestIfNotValid()
        {
            // Arrange
            bool trueTest = true;
            bool testBool = false;
            var test = "iuywg(^%#&&(*%^vfiugfdf98769";

            // Act
            testBool = UtilityMethods.ValInputString(test.ToString());

            //Assert
            Assert.AreNotEqual(trueTest, testBool, "This false test String is false");
        }

        [TestMethod]
        public void ValInput_TestIfValidSingleNumber()
        {
            // Arrange
            bool trueTest = true;
            bool testBool;
            var test = 5;

            // Act
            testBool = UtilityMethods.ValInputString(test.ToString());

            //Assert
            Assert.AreEqual(trueTest, testBool, "This true test number converted to true");
        }

        [TestMethod]
        public void ValInput_TestIfValidSingleLetter()
        {
            // Arrange
            bool trueTest = true;
            bool testBool;
            var test = "i";

            // Act
            testBool = UtilityMethods.ValInputString(test.ToString());

            //Assert
            Assert.AreEqual(trueTest, testBool, "This true test String converted to true");
        }

        [TestMethod]
        public void ValInput_TestIfNotValidSingle()
        {
            // Arrange
            bool trueTest = true;
            bool testBool = false;
            var test = "(";

            // Act
            testBool = UtilityMethods.ValInputString(test.ToString());

            //Assert
            Assert.AreNotEqual(trueTest, testBool, "This false test String is false");
        }

        [TestMethod]
        public void ValInput_TestIfValidSingleNumberInFront()
        {
            // Arrange
            bool trueTest = true;
            bool testBool;
            var test = "5/";

            // Act
            testBool = UtilityMethods.ValInputString(test.ToString());

            //Assert
            Assert.AreNotEqual(trueTest, testBool, "This true test number converted to true");
        }

        [TestMethod]
        public void ValInput_TestIfValidSingleLetterInFront()
        {
            // Arrange
            bool trueTest = true;
            bool testBool;
            var test = "i*";

            // Act
            testBool = UtilityMethods.ValInputString(test.ToString());

            //Assert
            Assert.AreNotEqual(trueTest, testBool, "This true test String converted to true");
        }

        [TestMethod]
        public void ValInput_TestIfNotValidSingleInvalidInFrontOfNumber()
        {
            // Arrange
            bool trueTest = true;
            bool testBool = false;
            var test = "(4";

            // Act
            testBool = UtilityMethods.ValInputString(test.ToString());

            //Assert
            Assert.AreNotEqual(trueTest, testBool, "This false test String is false");
        }

        [TestMethod]
        public void ValInput_TestIfNotValidSingleInvalidInFrontOfLetter()
        {
            // Arrange
            bool trueTest = true;
            bool testBool = false;
            var test = "{T";

            // Act
            testBool = UtilityMethods.ValInputString(test.ToString());

            //Assert
            Assert.AreNotEqual(trueTest, testBool, "This false test String is false");
        }

        [TestMethod]
        public void ValInput_TestIfValidSingleLetterInBack()
        {
            // Arrange
            bool trueTest = true;
            bool testBool;
            var test = "*i";

            // Act
            testBool = UtilityMethods.ValInputString(test.ToString());

            //Assert
            Assert.AreNotEqual(trueTest, testBool, "This true test String converted to true");
        }

        [TestMethod]
        public void ValInput_TestIfNotValidSingleInvalidInBackOfNumber()
        {
            // Arrange
            bool trueTest = true;
            bool testBool = false;
            var test = "4)";

            // Act
            testBool = UtilityMethods.ValInputString(test.ToString());

            //Assert
            Assert.AreNotEqual(trueTest, testBool, "This false test String is false");
        }

        [TestMethod]
        public void ValInput_TestIfNotValidSingleInvalidInBackOfLetter()
        {
            // Arrange
            bool trueTest = true;
            bool testBool = false;
            var test = "T'";

            // Act
            testBool = UtilityMethods.ValInputString(test.ToString());

            //Assert
            Assert.AreNotEqual(trueTest, testBool, "This false test String is false");
        }
    }
}