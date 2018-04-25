using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/*
 * This class has some utility methods used by the forms. a method to check the validity of input 
 * string from the user. A method to check if AudioInputFiles are valid. A method to check if 
 * ImageInputFiles are valid.
 *
 * author: Group 7 (Stephen Bailey, Omar Garcia, Craig Wyse, Matthew Harris)
 * course: SEII
 * assignment: InRealLife (Group Project Spring 2018)
 * date: 4/23/2018
 * file name: UtilityMethods.cs
 * version: 1.0
 */
namespace Utilities
{
    public class UtilityMethods
    {
        // checks the validatity of an input string
        public static bool ValInputString(string inputString)
        {
            // IsItValid flag set to true
            bool IsItValid = true;

            // temp character
            char tempChar;

            // counter
            int charCounter = 0;

            // while IsItValid flag is true
            while (IsItValid == true && charCounter < inputString.Length)
            {
                // put character in string at counter position
                tempChar = inputString[charCounter];

                // if char is a digit
                if (char.IsDigit(tempChar))
                {
                    // just change counter
                    charCounter++;
                }
                // if char is a letter
                else if (char.IsLetter(tempChar))
                {
                    // just change counter
                    charCounter++;
                }
                // if char is whitespace
                else if (char.IsWhiteSpace(tempChar))
                {
                    // just change counter
                    charCounter++;
                }
                // if char is an underscore
                else if (tempChar == '_')
                {
                    // just change counter
                    charCounter++;
                }
                // else char an invalid character
                else
                {
                    // INPUT NO GOOD
                    IsItValid = false;
                }
            }

            // return flag
            return IsItValid;
        }

        // checks the validity of image file input from user
        public static bool ValImageInputPath(string inputString)
        {
            // CONSTANTS
            const string CORRECT_IMAGE_FILE_FORMAT = ".jpg";
            const string PERIOD = ".";
            const int INDEX_OFFSET_FOR_LENGTH = 1;

            // is valid flag set to true
            bool IsItValid;

            // input string length
            int inputStringLength = inputString.Length - INDEX_OFFSET_FOR_LENGTH;

            // grab char after the period
            string lastFourOfInputString = PERIOD + inputString.ToString().Split('.')[1];

            // if input string is in correct format
            if (lastFourOfInputString.ToLower() == CORRECT_IMAGE_FILE_FORMAT)
            {
                //get the rest of the string to check before the period
                string restOfInputString = inputString.ToString().Split('.')[0];

                // call local method
                if (ValInputString(restOfInputString))
                {
                    // set flag to valid true
                    IsItValid = true;
                }
                // rest of string was not valid
                else
                {
                    // set flag to valid false
                    IsItValid = false;
                }               
            }
            // file not in correct format
            else
            {
                // set flag to valid false
                IsItValid = false;
            }

            // return flag
            return IsItValid;
        }

        // checks the validity of audio file input from user
        public static bool ValAudioInputPath(string inputString)
        {
            // CONSTANTS
            const string CORRECT_AUDIO_FILE_FORMAT = ".wav";
            const string PERIOD = ".";
            const int INDEX_OFFSET_FOR_LENGTH = 1;

            // is valid flag set to true
            bool IsItValid;

            // input string length
            int inputStringLength = inputString.Length - INDEX_OFFSET_FOR_LENGTH;

            // grab char after the period
            string lastFourOfInputString = PERIOD + inputString.ToString().Split('.')[1];

            // if input string is in correct format
            if (lastFourOfInputString.ToLower() == CORRECT_AUDIO_FILE_FORMAT)
            {
                //get the rest of the string to check before the period
                string restOfInputString = inputString.ToString().Split('.')[0];

                // call local method
                if (ValInputString(restOfInputString))
                {
                    // set flag to valid true
                    IsItValid = true;
                }
                // rest of string was not valid
                else
                {
                    // set flag to valid false
                    IsItValid = false;
                }
            }
            // file not in correct format
            else
            {
                // set flag to valid false
                IsItValid = false;
            }

            // return flag
            return IsItValid;
        }
    }
}