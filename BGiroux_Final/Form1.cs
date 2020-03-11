using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Include this namesapace to have DB capabilities
using System.Data.SqlClient;

namespace BGiroux_Final
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnUpdate.Visible = false;
            btnUpdate.Enabled = false;
            btnDelete.Visible = false;
            btnDelete.Enabled = false;
        }
        //-----Add Constructor that Receives Pet ID
        public Form1(Int32 intPetID)
        {
            InitializeComponent();   //Creates and initalizes all for objects
            //Disable Edit and Delete capabilities because they do not exist
            btnSubmit.Visible = false;
            btnSubmit.Enabled = false;

            //Display/Gather information from Class Pet 
            //Gather information about this one pet and store it in a DataReader
            Pet temp = new Pet();   
            SqlDataReader dr = temp.FindOnePet(intPetID);

            //Use that info to fill out the form
            //Loop thru the records stored in the reader one record at a time
            //Note that since this is basone on one person's ID, then we should only have one record
            while (dr.Read())
            {
                //Take the Name(s) from the DataReader and copy them into the appropriate text fields in SQL DB
                txtFName.Text = dr["FirstName"].ToString();
                txtGender.Text = dr["Gender"].ToString(); 
                txtSpecies.Text = dr["Species"].ToString();
                txtBreed.Text = dr["Breed"].ToString();
                txtColor.Text = dr["Color"].ToString();
                txtAge.Text = dr["Age"].ToString();
                txtDOB.Text = dr["DOB"].ToString();
                txtWeight.Text = dr["Weight"].ToString();
                txtIntact.Text = dr["Intact"].ToString();
                txtVacs.Text = dr["Vaccinated"].ToString();
                txtRabies.Text = dr["RabiesID"].ToString();
                txtMicroC.Text = dr["MicrochipID"].ToString();
                txtMeds.Text = dr["Medications"].ToString();
                txtVet.Text = dr["Veterinarian"].ToString();
                lblPet_ID.Text = dr["PetID"].ToString(); 
            }
        } //End of public Form1

     

        private void Form1_Load(object sender, EventArgs e)
        {
           // MessageBox.Show("INSERT POP-UP MESSSAGE HERE!"); //When form loads, pops up this
        }

        private void btnSubmit_Click(object sender, EventArgs e) 
        {   //Gather information stored in var temp, store         
            Pet temp = new Pet();

            //Getting the strings from Pet and setting in an Object
            temp.FName = txtFName.Text;
            temp.Gender = txtGender.Text;
            temp.Species = txtSpecies.Text;
            temp.Breed = txtBreed.Text;
            temp.Color = txtColor.Text;
            temp.Age = txtAge.Text;
            temp.DOB = txtDOB.Value;
            temp.Weight = txtWeight.Text;
            temp.Intact = txtIntact.Text;
            temp.Vaccinated = txtVacs.Text;
            temp.Rabies = txtRabies.Text;
            temp.Microchip = txtMicroC.Text;
            temp.Medications = txtMeds.Text;
            temp.Veterinarian = txtVet.Text;

            //-----Output what was stored take from txt box put in variable,print
            lblFeedback.Text = temp.FName + " " + temp.Gender + " " + temp.Species + "\n" + temp.Breed + " " + temp.Color + "\n" + temp.Age + "   " + temp.DOB + ", " + temp.Weight + "\n" + temp.Intact + "\n" + temp.Vaccinated + "\n" + temp.Rabies + "\n" + temp.Microchip + "\n" + temp.Medications + "\n" + temp.Veterinarian;


            if (!temp.Feedback.Contains("INVALID"))
            {
                lblFeedback.Text = temp.AddARecord();   //if no errors weh setting values, then perform the insertion into db
            }
            else
            {
                lblFeedback.Text = temp.Feedback;  //else...dispay the error msg
            }
        }//End btn Submit
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Pet temp = new Pet();

            //Getting the string from the form and setting them in object
            temp.FName = txtFName.Text;
            temp.Gender = txtGender.Text;
            temp.Species = txtSpecies.Text;
            temp.Breed = txtBreed.Text;
            temp.Color = txtColor.Text;
            temp.Age = txtAge.Text;
            temp.DOB = txtDOB.Value;
            temp.Weight = txtWeight.Text;
            temp.Intact = txtIntact.Text;
            temp.Vaccinated = txtVacs.Text;
            temp.Rabies = txtRabies.Text;
            temp.Microchip = txtMicroC.Text;
            temp.Medications = txtMeds.Text;
            temp.Veterinarian = txtVet.Text;
            temp.PetID = Int32.Parse(lblPet_ID.Text);

            //-----Output what was stored take from txt box put in variable,print
            lblFeedback.Text = temp.FName + " " + temp.Gender + " " + temp.Species + "\n" + temp.Breed + " " + temp.Color + "\n" + temp.Age + "   " + temp.DOB + ", " + temp.Weight + "\n" + temp.Intact + "\n" + temp.Vaccinated + "\n" + temp.Rabies + "\n" + temp.Microchip + "\n" + temp.Medications + "\n" + temp.Veterinarian;

            //Validate information
            if (!temp.Feedback.Contains("INVALID"))
            {
                String feedback = temp.UpdateARecord();
                //Display feedback to user
                lblFeedback.Text = feedback;
            }

            else
            { lblFeedback.Text = temp.Feedback; } //else...dispay the error msg
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Get the ID from the label
            Int32 intPet_ID = Convert.ToInt32(lblPet_ID.Text);
            //Create a Pet so can use the delete method
            Pet temp = new Pet();

            //Use the Pet ID and pass it to the delete function and get the number of records deleted
            String strRecords = temp.DeleteOnePet(intPet_ID);

            //Display the feedback to user
            lblFeedback.Text = strRecords; //.ToString() + " Record(s) Deleted.";
        }

        private void txtDOB_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblPetID_Click(object sender, EventArgs e)
        {

        }

        private void lblFeedback_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtAge_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
