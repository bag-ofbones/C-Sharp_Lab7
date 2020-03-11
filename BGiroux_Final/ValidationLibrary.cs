using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGiroux_Final
{
    class ValidationLibrary
    {// LIBRARY OF VALIDATION FUNCTIONS-----------------------------------------------

        //Receives a string and can let user know if it is filled in
        public static bool IsItFilledIn(string temp)
        {
            bool result = false;

            if (temp.Length > 0)
            {
                result = true;
            }
            return result;
        }

        //Recieves a string and let user know if valid Zip format (5)
        public static bool IsValidNumber(string temp)
        { 
            if (temp.Length <1)
            {
                return false;
            }
            //Then TryParse
            int x;
            if (Int32.TryParse(temp, out x))
            {
                return true;
            }

            return false;
        }

        public static bool IsValidWeight(string temp)
        {
            if (temp.Length < 1)
            {
                return false;
            }
            //Then TryParse
            float x;
            if (float.TryParse(temp, out x))
            {
                return true;
            }

            return false;
        }

        //-----Get the string from, convert to ints, set their values
        //Recieves a string and let user know if valid phone number format
        public static bool IsValidRabies(string temp)
        {
            bool blnResult = true;
            //String Replace first, remove dashes so not put into DB
            temp = temp.Replace("-", string.Empty);
            //First check length;
            if (temp.Length <= 1)
            {
                return false;
            }
            //Then TryParse
            int x;
            if (Int32.TryParse(temp, out x))
            {
                blnResult = true;
            }
            return blnResult;
        }

        public static bool IsADate(DateTime temp)
        {
            bool blnResult;

            if (temp >= DateTime.Now)
            { blnResult = false; }
            else
            { blnResult = true;  }

            return blnResult;
        }

    }
}
