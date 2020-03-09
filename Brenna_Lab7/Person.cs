using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brenna_Lab5
{
        public class Person
    {
        private String fName;
        private String mName;
        private String lName;
        private String street1;
        private String street2;
        private String city;
        private String state;
        private String zip;
        private String phone;
        private String email;

        protected string feedback;  //NEW --Protected..Children see this but others do not
        public string FName
        {
            get { return fName; }
            set
            {
                if (ValidationLibrary.IsItFilledIn(value))
                { fName = value; }
                else
                { feedback += "\nINVALID: Enter a First Name"; }
            }

        }
        public string MName
        {
            get { return mName; }
            set
            {
                if (ValidationLibrary.IsItFilledIn(value))
                { mName += value; }
                else
                { feedback += "\nINVALID: Enter a Middle Name"; }
            }
        }
        public string LName
        {
            get { return lName; }
            set
            {
                if (ValidationLibrary.IsItFilledIn(value))
                { lName = value; }
                else
                { feedback += "\nINVALID: Enter a Last Name"; }
            }
        }
        public string Street1
        {
            get { return street1; }
            set
            {
                if (ValidationLibrary.IsItFilledIn(value))
                { street1 = value; }
                else
                { feedback += "\nINVALID: Enter a Street"; }
            }
        }

        public string Street2
        {
            get { return street2; }
            set { street2 = value; }
        }

        public string City
        {
            get { return city; }
            set
            {
                if (ValidationLibrary.IsItFilledIn(value))
                { city = value; }
                else
                { feedback += "\nINVALID: City"; }
            }
        }

        public string State
        {
            get { return state; }
            set
            {
                if (ValidationLibrary.IsValidState(value))
                { state = value; }
                else
                { feedback += "\nINVALID: State"; }

            }
        }//End of public string state

        public string Zip
        {
            get { return zip; }
            set
            {
                if (ValidationLibrary.IsValidZip(value))
                { zip = value; }
                else
                { feedback += "\nINVALID: Zip Code"; }

            }
        }//End of public string zip}

        public string Phone
        {
            get { return phone; }
            set
            {
                if (ValidationLibrary.IsValidPhone(value))
                { phone = value; }
                else
                { feedback += "\nINVALID: Phone Number"; }
            }
        } //End of public string Phone
        public string Email
        {
            get { return email; }
            set
            {   //if valid email address, store it
                //ValidationLibrary = another class, holding validation functions
                if (ValidationLibrary.IsValidEmail(value))
                { email = value; }
                else
                { feedback += "\nINVALID: E-Mail"; }
            }
        } //End of public string Email

        //Default Constructor - Runs automatically when object instance created
        public Person()
        {
            //Initialize so that there are no nulls, especially feedback
            fName = "";
            mName = "";
            lName = "";
            street1 = "";
            street2 = "";
            city = "";
            state = "";
            zip = "";
            phone = "";
            email = "";
        }
    }
}


