using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BGiroux_Final
{
    public class Pet
    { //-----Declare vars
        private String fName;        
        private String gender;
        private String species;
        private String breed;
        private String color;
        private String age;
        private DateTime dob;
        private String weight;
        private String intact;
        private String vaccinated; 
        private String rabies;
        private String microchip;
        private String medications;
        private String veterinarian;

        protected string feedback;  //Protected;Children see this but others do not
       //Create var to hold Pet ID assigned by the DB
        private int petID;
        public int PetID
        {
            get { return petID; }
            set
            { petID = value; }
        } //end of public string private int PetID


        public string FName
        {
            get { return fName; }
            set
            {
                if (ValidationLibrary.IsItFilledIn(value))
                { fName = value; }
                else
                { feedback += "\nINVALID: Enter your Pets First Name"; }
            }

        }
        public string Gender
        {
            get { return gender; }
            set
            {
                if (ValidationLibrary.IsItFilledIn(value))
                { gender = value; }
                else
                { feedback += "\nINVALID: Enter a Gender"; }
            }
        }
        public string Species
        {
            get { return species; }
            set
            {
                if (ValidationLibrary.IsItFilledIn(value))
                { species = value; }
                else
                { feedback += "\nINVALID: Enter a Species"; }
            }
        }
        public string Breed
        {
            get { return breed; }
            set
            {
                if (ValidationLibrary.IsItFilledIn(value))
                { breed = value; }
                else
                { feedback += "\nINVALID: Enter a Breed"; }
            }
        }

        public string Color
        {
            get { return color; }
            set
            {
                if (ValidationLibrary.IsItFilledIn(value))
                { color = value; }
                else
                { feedback += "\nINVALID: Enter a Color"; }
            }
        }

        public string Age
        {
            get { return age; }
            set
            {
                if (ValidationLibrary.IsItFilledIn(value))
                { age = value; }
                else
                { feedback += "\nINVALID: Age"; }
            }
        }

        public DateTime DOB
        {
            get { return dob; }
            set
            {
                if (ValidationLibrary.IsADate(value))
                { dob = value; }
                else
                { feedback += "\nINVALID: DOB"; }

            }
        }

        public string Weight
        {
            get { return weight; }
            set
            {
                if (ValidationLibrary.IsValidWeight(value))
                { weight = value; }
                else
                { feedback += "\nINVALID: Weight"; }

            }
        }

        public string Intact
        {
            get { return intact; }
            set
            {
                if (ValidationLibrary.IsItFilledIn(value))
                { intact = value; }
                else
                { feedback += "\nINVALID: Intact -Is your Pet Spayed/Neutered/Gelded?"; }
            }
        }
        public string Vaccinated
        {
            get { return vaccinated; }
            set
            {
                if (ValidationLibrary.IsItFilledIn(value))
                { vaccinated = value; }
                else
                { feedback += "\nINVALID: Vaccinated"; }
            }
        }
        public string Rabies
        {
            get { return rabies; }
            set
            {
                if (ValidationLibrary.IsValidRabies(value))
                { rabies = value; }
                else
                { feedback += "\nINVALID: Rabies ID"; }
            }
        }
        public string Microchip
        {
            get { return microchip; }
            set
            {
                if (ValidationLibrary.IsValidRabies(value))
                { microchip = value; }
                else
                { feedback += "\nINVALID: Microchip ID"; }
            }
        }
        public string Medications
        {
            get { return medications; }
            set
            {
                if (ValidationLibrary.IsItFilledIn(value))
                { medications = value; }
                else
                { feedback += "\nINVALID: Medications -Does your Pet take any Medications?"; }
            }
        }

        public string Veterinarian
        {
            get { return veterinarian; }
            set
            {   //if valid email address, store it
                //ValidationLibrary = another class, holding validation functions
                if (ValidationLibrary.IsItFilledIn(value))
                { veterinarian = value; }
                else
                { feedback += "\nINVALID: Veterinarian"; }
            }
        } 

        //Default Constructor - Runs automatically when object instance is created
        public Pet()
        {
            //Initialize so that there are no nulls, especially feedback
            fName = "";
            gender = "";
            species = "";
            breed = "";
            color = "";
            age = "";
            dob = DateTime.Parse("1/1/1500"); 
            weight = "";
            intact = "";
            vaccinated = "";
            microchip = "";
            medications = "";
            veterinarian = "";
            feedback = "";
        }
        //-----Allow class to communicate with outside programs
        public string Feedback
        {
            get { return feedback; }  //allows outside code to see feedback, no set because only class can change feedback
        }


        //------Add a record, but make sure connected to the DB
        public string AddARecord()
        {
            //Init string var
            string strResult = "";

            //Make a connection object
            SqlConnection Conn = new SqlConnection();

            //Initialize it's properties
            Conn.ConnectionString = @GetConnected();  //Set the Who/What/Where of DB

            string strSQL = "INSERT INTO Pet (FirstName, Gender, Species, Breed, Color, Age, DOB, Weight, Intact, Vaccinated, RabiesID, MicrochipID, Medications, Veterinarian) VALUES (@FName, @Gender, @Species, @Breed, @Color, @Age, @DOB, @Weight, @Intact, @Vaccinated, @Rabies, @Microchip, @Medications, @Veterinarian)";

            //Bark out command
            SqlCommand comm = new SqlCommand();
            comm.CommandText = strSQL;  //Commander knows what to say
            comm.Connection = Conn;     //Where's the phone?  Here it is

            //-----Fill in the paramters (Has to be created in same sequence as they are used in SQL Statement)
            comm.Parameters.AddWithValue("@FName", FName);
            comm.Parameters.AddWithValue("@Gender", Gender);
            comm.Parameters.AddWithValue("@Species", Species);
            comm.Parameters.AddWithValue("@Breed", Breed);
            comm.Parameters.AddWithValue("@Color", Color);
            comm.Parameters.AddWithValue("@Age", Age);
            comm.Parameters.AddWithValue("@DOB", DOB);
            comm.Parameters.AddWithValue("@Weight", Weight);
            comm.Parameters.AddWithValue("@Intact", Intact);
            comm.Parameters.AddWithValue("@Vaccinated", Vaccinated);
            comm.Parameters.AddWithValue("@Rabies", Rabies.Replace("-", string.Empty));
            comm.Parameters.AddWithValue("@Microchip", Microchip.Replace("-", string.Empty));
            comm.Parameters.AddWithValue("@Medications", Medications);
            comm.Parameters.AddWithValue("@Veterinarian", Veterinarian);
           
            //-----attempt to connect to the server
            try
            {
                Conn.Open();                                        //Open connection to DB - Think of dialing a friend on phone
                int intRecs = comm.ExecuteNonQuery();
                //Report that connection was made and added a record
                strResult = $"SUCCESS: Inserted {intRecs} records.";  
                Conn.Close(); //Hanging up after phone call
            }
            //If err here, there was a problem connecting to DB
            catch (Exception err)
            { //Set feedback to state there was an error & error info
                strResult = "ERROR: " + err.Message;                
            }
            finally
            {

            }
            //Return resulting feedback string
            return strResult;
        }


        // -----DRILL-DOWN Search, Takes search param to narrow search results
        public DataSet SearchPet(String strFSearch)
        {
            //Create a dataset to return filled
            DataSet ds = new DataSet();
            //Create a command for our SQL statement
            SqlCommand comm = new SqlCommand();
            //THIS
            //Write a Select Statement to perform Search
            String strSQL = "SELECT PetID, FirstName, Gender, Species, Breed, Color, Age, DOB, Weight, Intact, Vaccinated, RabiesID, MicrochipID, Medications, Veterinarian FROM Pet WHERE 0=0";

            //If the First is filled in include it as search criteria
            if (strFSearch.Length > 0)
            {
                strSQL += " AND FirstName LIKE @FName";
                //% Don't care what starts or ends with
                comm.Parameters.AddWithValue("@FName", "%" + strFSearch + "%");
            }

            //------Create DB tools and Configure
            SqlConnection conn = new SqlConnection();
            //Create the who, waht where of the DB
            string strConn = GetConnected();
            conn.ConnectionString = strConn;

            //Fill in basic info to command object
            comm.Connection = conn;    //tell the commander what connection to use 
            comm.CommandText = strSQL; //tell the command what to say

            //Create Data Adapter
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = comm;  //commander needs a translator (DataAdapter) to speak with datasets

            //Get Data
            conn.Open();    //Open the connection (pick up the phone)
            da.Fill(ds, "Pet_Temp"); //Fill the dataset with results from database and call it "Pet_Temp"

            conn.Close(); //Close the connection (hang up the phone)

            //Return the data
            return ds;
        }

        //-----Method that returns a Data Reader filled with all the data of one 'Person'. This 'Person' is specified by the ID passed to this function
        public SqlDataReader FindOnePet(int intPetID)
        {
            //Creat and Initialize the DB Tools we need
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();

            //My Connection String
            string strConn = GetConnected();

            //My SQL command string to pull up one 'Persons' data
            string sqlString = "SELECT * FROM Pet WHERE PetID = @PetID;";

            //Tell the connection object the who, what, where, how
            conn.ConnectionString = strConn;

            //Give the command object info it needs
            comm.Connection = conn;
            comm.CommandText = sqlString;
            comm.Parameters.AddWithValue("PetID", intPetID); 

            //Open the DataBase Connection and Yell our SQL Command
            conn.Open();

            //Return some form of feedback
            return comm.ExecuteReader();  //Return the dataset to be used by others (the calling form)
        }

        //Method that will delete one Pet record specified by the ID
        //It will return an Interger meant for feedback on how many records were  
        public string DeleteOnePet(int intPetID)
        {
            Int32 intRecords = 0;
            string strResult = "";
            //Create and Initialize the DB tools needed
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();

            //Connection string
            string strConn = GetConnected();

            //MySQL command string to pull one Person's data
            string sqlString = "DELETE FROM Pet WHERE PetID = @PetID;";
            //Tell the connection object the who, what where, how
            conn.ConnectionString = strConn;

            //Give the command object info it needs
            comm.Connection = conn;
            comm.CommandText = sqlString;
            comm.Parameters.AddWithValue("@PetID", intPetID);            
            try
            {
                //Open the connection
                conn.Open();
                //Run the Delete and store the number of records effected
                intRecords = comm.ExecuteNonQuery();
                strResult = intRecords.ToString() + " Record(s) Deleted.";
            }
            catch (Exception err)
            {
                strResult = "ERROR: " + err.Message;  //Set feedback to state there was an error & error info
            }
            finally
            {
                //close the connection
                conn.Close();
            }
            return strResult; 
        }

        public String UpdateARecord() 
        {
            Int32 intRecords = 0;
            string strResult = "";

            //Create and Initialize the DB tools we need
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = @GetConnected();

            //MySQL command string to pull one Pet's data
            string sqlString = "UPDATE Pet SET FirstName= @FName, Gender= @Gender, Species= @Species, Breed= @Breed, Color= @Color, Age= @Age, DOB= @DOB, Weight= @Weight, Intact= @Intact, Vaccinated= @Vaccinated, RabiesID= @Rabies, MicrochipID= @Microchip, Medications= @Medications, Veterinarian= @Veterinarian WHERE PetID= @PetID";

            //???????????How can you see the SQL command being passed???

            //string sqlString = "UPDATE Pet SET FirstName= @PetID WHERE PetID = 2 ";

            // Bark out command
            SqlCommand comm = new SqlCommand();
            comm.CommandText = sqlString;  //Commander knows what to say
            comm.Connection = conn;     //Where's the phone?  Here it is

            //-----Fill in the paramters 
            comm.Parameters.AddWithValue("@FName", FName);
            comm.Parameters.AddWithValue("@Gender", Gender);
            comm.Parameters.AddWithValue("@Species", Species);
            comm.Parameters.AddWithValue("@Breed", Breed);
            comm.Parameters.AddWithValue("@Color", Color);
            comm.Parameters.AddWithValue("@Age", Age);
            comm.Parameters.AddWithValue("@DOB", DOB);
            comm.Parameters.AddWithValue("@Weight", Weight);
            comm.Parameters.AddWithValue("@Intact", Intact);
            comm.Parameters.AddWithValue("@Vaccinated", Vaccinated);
            comm.Parameters.AddWithValue("@Rabies", Rabies.Replace("-", string.Empty));
            comm.Parameters.AddWithValue("@Microchip", Microchip.Replace("-", string.Empty));
            comm.Parameters.AddWithValue("@Medications", Medications);
            comm.Parameters.AddWithValue("@Veterinarian", Veterinarian);
            comm.Parameters.AddWithValue("@PetID", PetID);
            //PetID is equalling to 0
            try
            {
                //Open the connection
                conn.Open();
                //Run the Update and store the number of records effected
                intRecords = comm.ExecuteNonQuery();
                strResult = intRecords.ToString() + " Records Updated.";
            }
            catch (Exception err)
            {
                strResult = "ERROR: " + err.Message;  //Set feedback to state there was an error & error info
            }
            finally
            {
                //close the connection 
                conn.Close();
            }
            //return strResult;
            return strResult;
        }

        //-----Utility function so that one string controls all SQL Server Login info
        private string GetConnected()
        {
            return "Server=sql.neit.edu,4500;Database=SE245_bgiroux;User Id=SE245_bgiroux;Password=008007874;";
        }
               
    } //End of class Pet
}
