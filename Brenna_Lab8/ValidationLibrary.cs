using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brenna_Lab5
{
    public class ValidationLibrary
    { // LIBRARY OF VALIDATION FUNCTIONS-----------------------------------------------

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
        public static bool IsValidZip(string temp)
        { //temp is brought in as a string 
            //Convert temp String to int.TryParse
            //First check length;
            if (temp.Length != 5)
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

        //Recieves a string and let user know if valid State format (2)
        public static bool IsValidState(string temp)
        {
            bool blnResult = true;
            //check for minimum length 2
            if (temp.Length < 2)
            {
                blnResult = false;
            }
            else if (temp.Length > 2)
            {
                blnResult = false;
            }
            return blnResult;
        }



        //-----Get the string from, convert to ints, set their values
        //Recieves a string and let user know if valid phone number format
        public static bool IsValidPhone(string temp)
        {
            bool blnResult = true;
            //String Replace first, remove dashes so not put into DB
            temp = temp.Replace("-", string.Empty);
            //First check length;
            if (temp.Length != 10)
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

        //Is cell number valid
        public static bool IsValidCell(string temp)
        {
            bool blnResult = true;
            temp = temp.Replace("-", string.Empty);
            if (temp.Length != 10)
            {
                blnResult = false;
            }
            //Then TryParse
            int x;
            if (Int32.TryParse(temp, out x))
            {
                blnResult = true;
            }
            return blnResult;

        }

        //Recieves a string and can let user know if it is a sem-valid E-mail format, implement (8) length
        public static bool IsValidEmail(string temp)
        {
            //assume true but look for bad stuff to make it false
            bool blnResult = false;

            //Check for minimum length
            if (temp.Length < 8)
            {
                return blnResult;
            }

            //check length of string without the @; this ensures only 1 @ sign
            int at_count = temp.Length - temp.Replace("@", string.Empty).Length;
            if (at_count != 1)
            {
                return blnResult;
            }

            //check length of string without the period (.); this ensures at least 1
            int period_count = temp.Length - temp.Replace(".", string.Empty).Length;
            if (at_count == 0)
            {
                return blnResult;
            }

            //Look for position of last period "."
            int at_location = temp.IndexOf("@");
            if (at_location <= 1)
            {
                return blnResult;
            }

            //Look for position of last period "."
            int period_location = temp.LastIndexOf(".");

            // check for last period after @ sign and at least 1 char between
            if (period_location - at_location < 2)
            {
                return blnResult;
            }

            // make sure the period is not the last or 2nd to last character
            if (temp.Length - period_location <= 2)
            {
                return blnResult;
            }

            return true;
        }

        //Is valid Facebook
        public static bool IsValidFb(string temp)
        {
            bool blnresult = true;
            if (temp.Length < 1)
            {
                blnresult = false;
            }
            return blnresult;
        }
        //Is valid Customer Since (DateTime)
        public static bool IsValidCustSince(string temp)
        {
            bool blnresult = false;
            DateTime dateValue;
            if (DateTime.TryParse(temp, out dateValue))
            //if (temp.Length < 1)
            {
                blnresult = true;
            }
            return blnresult;
        }

        //Is valid Total Purchses Double
        public static bool IsValidTotalPurch(string temp)
        {
            bool blnresult = false;
            double OutVal;
            if (double.TryParse(temp, out OutVal))
            //if (double.IsNaN(OutVal) || double.IsInfinity(OutVal))
            {//if num (OutVal) >= 0
                if (OutVal >= 0)
                { blnresult = true; }
            }
            return blnresult;
        }

        //Is valid Discount Member
        public static bool IsValidDiscountMbr(string temp)
        {
            bool blnresult = false;
            if (temp.ToUpper().Equals("Y") || temp.ToUpper().Equals("N"))
            {
                blnresult = true;
            }
            return blnresult;
        }
        //Is valid Rewards int
        public static bool IsValidRewards(string temp)
        {
            bool blnresult = false;
            int OutVal;
            if (int.TryParse(temp, out OutVal))
            {
                if (OutVal >= 0)
                { blnresult = true; }
            }
            return blnresult;
        }
    }
}
