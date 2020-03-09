using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Use these namespaces to include DB capabilities for generic components and SQL Server
using System.Data.SqlClient;


namespace Brenna_Lab5
{
    /// <summary>
    /// //Default Constructor (Add)
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //-----Add Constructor that Receives a Person ID...this means need to look up the data and populate fields (View/Edit/Delete) <param name="intPerson_ID"></parma>
        public Form1(int intPerson_ID)
        {
            InitializeComponent();   //Creates and initalizes all for objects

            //Display/Gather information from Class PersonV2.cs which is also inherites Person
            //Gather information about this one person and store it in a DataReader
            PersonV2 temp = new PersonV2();   //Change from Customer temp --> PersonV2 temp NOT Person
            SqlDataReader dr = temp.FindOnePerson(intPerson_ID);

            //Use that info to fill out the form
            //Loop thru the records stored in the reader one record at a time
            //Note that since this is basone on one person's ID, then we should only have one record
            while (dr.Read())
            {
                //Take the Name(s) from the DataReader and copy them into the appropriate text fields in SQL DB
                txtFName.Text = dr["FirstName"].ToString();
                txtMName.Text = dr["MiddleName"].ToString(); //or is mName
                txtLName.Text = dr["LastName"].ToString();
                txtStreet1.Text = dr["st1"].ToString(); //or Street1
                txtStreet2.Text = dr["st2"].ToString();
                txtCity.Text = dr["City"].ToString();
                txtState.Text = dr["State"].ToString();
                txtZip.Text = dr["Zip"].ToString();
                txtPhone.Text = dr["Phone"].ToString();
                txtCell.Text = dr["Cell"].ToString();
                txtEmail.Text = dr["Email"].ToString();
                txtFb.Text = dr["Fb"].ToString();
                lblPerson_ID.Text = dr["Person_ID"].ToString(); //!!!could be wrong "name" here

            }

        } //End of public Form1(int intPerson_ID)

        //don't need double of this?? 
        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Hello There....Annoyed Yet??!!!"); //When form loads, pops up this
            this.BackColor = Color.WhiteSmoke;
        }

        private void btnSubmit_Click(object sender, EventArgs e) //change to insert now
        {   //Gather information stored in var temp, store                     
            PersonV2 temp = new PersonV2();   //Change from Customer temp --> PersonV2 temp

            //Getting the strings from the for of PersonV2 and setting them now in an Object
            temp.FName = txtFName.Text;
            temp.MName = txtMName.Text;
            temp.LName = txtLName.Text;
            temp.Street1 = txtStreet1.Text;
            temp.Street2 = txtStreet2.Text;
            temp.City = txtCity.Text;
            temp.State = txtState.Text;
            temp.Zip = txtZip.Text;
            temp.Phone = txtPhone.Text;
            temp.Cell = txtCell.Text;
            temp.Email = txtEmail.Text;
            temp.Fb = txtFb.Text;

            /* temp.CustSince = txtCustSince.Text;
            temp.TotalPurch = txtTotalPurch.Text;
            temp.DiscountMbr = txtDiscountMbr.Text;
            temp.Rewards = txtRewards.Text;
            */

            //If needing to get dates from teh datetime picks
            //temp.DatePublished = dtpDatePublished.Value;
            //temp.DateRentalExpires = dtpDateRentalExpires.Value;



            //-----Output what was stored take from txt box put in variable,print
            lblFeedback.Text = temp.FName + " " + temp.MName + " " + temp.LName + "\n" + temp.Street1 + " " + temp.Street2 + "\n" + temp.City + "   " + temp.State + ", " + temp.Zip + "\n" + temp.Phone + "\n" + temp.Cell + "\n" + temp.Email + "\n" + temp.Fb;

            //  + "\n \n" + temp.CustSince + "\n" + temp.TotalPurch + "\n" + temp.DiscountMbr + "\n" + temp.Rewards;

            if (!temp.Feedback.Contains("INVALID"))
            {
                lblFeedback.Text = temp.AddARecord();   //if no errors weh setting values, then perform the insertion into db
            }
            else
            {
                lblFeedback.Text = temp.Feedback;       //else...dispay the error msg
            }


        }//End btn Submit

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txtFb_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void lblPersonV2_ID_Click(object sender, EventArgs e)
        {

        }

 /*       private void btnDelete_Click(object sender, EventArgs e)
        {
            //Get the ID from the label
            Int32 intPerson_ID = Convert.ToInt32(lblPerson_ID.Text);
            //Creat a Person so can use the delete method
            PersonV2 temp = new PersonV2();

            //Use the Person ID and pass it to the delete function and get the number of records deleted
            lblFeedback.Text = temp.DeleteOnePerson(intPerson_ID);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            PersonV2 temp = new PersonV2();

            //Getting the string from the form and setting them in object
            temp.FName = txtFName.Text;
            temp.MName = txtMName.Text;
            temp.LName = txtLName.Text;
            temp.Street1 = txtStreet1.Text;
            temp.Street2 = txtStreet2.Text;
            temp.City = txtCity.Text;
            temp.State = txtState.Text;
            temp.Zip = txtZip.Text;
            temp.Phone = txtPhone.Text;
            temp.Cell = txtCell.Text;
            temp.Email = txtEmail.Text;
            temp.Fb = txtFb.Text;
        } */

    }
}

