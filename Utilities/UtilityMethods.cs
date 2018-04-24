using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
                    // NO GOOD
                    IsItValid = false;
                }
            }

            //
            return IsItValid;
        }
    }
}
