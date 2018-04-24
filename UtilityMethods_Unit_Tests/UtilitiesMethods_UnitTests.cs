using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;

/*
 * This test class tests the Utilities and its method.
 *
 * author: Group 7 (Stephen Bailey, Omar Garcia, Craig Wyse, Matthew Harris)
 * course: SEII
 * assignment: InRealLife (Group Project Spring 2018)
 * date: 04/23/2018
 * file name:     public class UtilitiesMethods_UnitTests
.cs
 * version: 1.0
 */
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
        public void ValInput_TestIfInValidSingleCharacter()
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
        public void ValInput_TestIfNotValidSingleCharacterInFrontOfNumber()
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
        public void ValInput_TestIfNotValidSingleCharacterInFrontOfLetter()
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

        [TestMethod]
        public void ValImageInputPath_Test_ValidCharacters()
        {
            // Arrange
            bool trueTest = true;
            bool testBool = false;
            var test = "steve.jpg";

            // Act
            testBool = UtilityMethods.ValImageInputPath(test.ToString());

            //Assert
            Assert.AreEqual(trueTest, testBool, "This test of valid character using the ValImageInputPath true test String is true");
        }

        [TestMethod]
        public void ValAudioInputPath_Test_ValidCharacters()
        {
            // Arrange
            bool trueTest = true;
            bool testBool = false;
            var test = "steve.wav";

            // Act
            testBool = UtilityMethods.ValAudioInputPath(test.ToString());

            //Assert
            Assert.AreEqual(trueTest, testBool, "This test of valid character using the ValAudioInputPath true test String is true");
        }

        [TestMethod]
        public void ValAudioInputPath_Test_InValidCharactersAtTheEnd()
        {
            // Arrange
            bool trueTest = true;
            bool testBool = false;
            var test = "steve.wave";

            // Act
            testBool = UtilityMethods.ValAudioInputPath(test.ToString());

            //Assert
            Assert.AreNotEqual(trueTest, testBool, "This test of invalid character using the ValAudioInputPath test String is true");
        }

        [TestMethod]
        public void ValAudioInputPath_Test_InValidCharactersAtFront()
        {
            // Arrange
            bool trueTest = true;
            bool testBool = false;
            var test = "steve..wav";

            // Act
            testBool = UtilityMethods.ValAudioInputPath(test.ToString());

            //Assert
            Assert.AreNotEqual(trueTest, testBool, "This test of invalid character using the ValAudioInputPath test String is true");
        }

        [TestMethod]
        public void ValAudioInputPath_Test_InValidEscapeCharactersAtFront()
        {
            // Arrange
            bool trueTest = true;
            bool testBool = false;
            var test = "steve/.wav";

            // Act
            testBool = UtilityMethods.ValAudioInputPath(test.ToString());

            //Assert
            Assert.AreNotEqual(trueTest, testBool, "This test of invalid character using the ValAudioInputPath test String is true");
        }

        [TestMethod]
        public void ValAudioInputPath_Test_InValidEscapeCharactersAtBack()
        {
            // Arrange
            bool trueTest = true;
            bool testBool = false;
            var test = "steve./av";

            // Act
            testBool = UtilityMethods.ValAudioInputPath(test.ToString());

            //Assert
            Assert.AreNotEqual(trueTest, testBool, "This test of invalid character using the ValAudioInputPath test String is true");
        }

        [TestMethod]
        public void ValImageInputPath_Test_InValidCharactersAtTheEnd()
        {
            // Arrange
            bool trueTest = true;
            bool testBool = false;
            var test = "steve.jppg";

            // Act
            testBool = UtilityMethods.ValImageInputPath(test.ToString());

            //Assert
            Assert.AreNotEqual(trueTest, testBool, "This test of invalid character using the ValImageInputPath test String is true");
        }

        [TestMethod]
        public void ValImageInputPath_Test_InValidCharactersAtFront()
        {
            // Arrange
            bool trueTest = true;
            bool testBool = false;
            var test = "steve..jpg";

            // Act
            testBool = UtilityMethods.ValImageInputPath(test.ToString());

            //Assert
            Assert.AreNotEqual(trueTest, testBool, "This test of invalid character using the ValImageInputPath test String is true");
        }

        [TestMethod]
        public void ValImageInputPath_Test_InValidEscapeCharactersAtFront()
        {
            // Arrange
            bool trueTest = true;
            bool testBool = false;
            var test = "steve/.jpg";

            // Act
            testBool = UtilityMethods.ValImageInputPath(test.ToString());

            //Assert
            Assert.AreNotEqual(trueTest, testBool, "This test of invalid character using the ValImageInputPath test String is true");
        }

        [TestMethod]
        public void ValImageInputPath_Test_InValidEscapeCharactersAtBack()
        {
            // Arrange
            bool trueTest = true;
            bool testBool = false;
            var test = "steve./pg";

            // Act
            testBool = UtilityMethods.ValImageInputPath(test.ToString());

            //Assert
            Assert.AreNotEqual(trueTest, testBool, "This test of invalid character using the ValImageInputPath test String is true");
        }

        [TestMethod]
        public void ValImageInputPath_Test_TestUnderScoreIsValid()
        {
            // Arrange
            bool trueTest = true;
            bool testBool = false;
            var test = "stev_e.jpg";

            // Act
            testBool = UtilityMethods.ValImageInputPath(test.ToString());

            //Assert
            Assert.AreEqual(trueTest, testBool, "This test of underscore character using the ValImageInputPath test String is true");
        }

        [TestMethod]
        public void ValAudioInputPath_Test_TestUnderScoreIsValid()
        {
            // Arrange
            bool trueTest = true;
            bool testBool = false;
            var test = "stev_e.wav";

            // Act
            testBool = UtilityMethods.ValAudioInputPath(test.ToString());

            //Assert
            Assert.AreEqual(trueTest, testBool, "This test of underscore character using the ValAudioInputPath test String is true");
        }
    }
}