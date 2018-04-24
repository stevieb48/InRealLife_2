using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/*
 * This ...
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
        public static bool ValInputString(string inputString)
        {
            // is valid flag set to true
            bool IsItValid = true;

            // temp character
            char tempChar;

            // counter
            int charCounter = 0;

            //
            while (IsItValid == true && charCounter < inputString.Length)
            {
                //
                tempChar = inputString[charCounter];

                if (char.IsDigit(tempChar))
                {
                    // change counter
                    charCounter++;
                }
                else if (char.IsLetter(tempChar))
                {
                    // change counter
                    charCounter++;
                }
                else
                {
                    // INPUT NO GOOD
                    IsItValid = false;
                }
            }

            //
            return IsItValid;
        }
    }
}