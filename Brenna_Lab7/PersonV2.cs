using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Use these namespaces to include DB capabilities for generic components and SQL Server
using System.Data;
using System.Data.SqlClient;

namespace Brenna_Lab5
{ //public class 
    public class PersonV2 : Person   //Create new class called "PersonV2" inherit the original person class and add two new properties: Cell Phone and Facebook; Update Main 
    {
        //-----Decalre vars
        private String fb; //lower case because..
        private String cell;

        //Create var to hold Persons ID assigned by the DB
        private int Person_ID;

        //protected string feedback;  //NEW --Protected..Children see this but others do not

        public string Fb
        {
            get { return fb; }
            set
            {
                if (ValidationLibrary.IsValidFb(value))
                { fb = value; }
                else { feedback += "\nINVALID: Facebook"; }
            }
        } //end of public string Fb

        public string Cell
        {
            get { return cell; }
            set
            {
                if (ValidationLibrary.IsValidCell(value))
                { cell = value; }
                else
                { feedback += "\nINVALID: Cell Phone Number"; }
            }
        } //end of public string cell

        //-----Allow class to communicate with outside programs
        public string Feedback
        {
            get { return feedback; }  //allows outside code to see feedback, no set because only class can change feedback
        }


        
        //------Goal is to add a record, but first make sure connected to the DB
        public string AddARecord()
        {
            //Init string var
            string strResult = "";

            //Make a connection object
            SqlConnection Conn = new SqlConnection();

            //Initialize it's properties
            Conn.ConnectionString = @GetConnected();  //Set the Who/What/Where of DB
            
            string strSQL = "INSERT INTO Persons (FirstName, MiddleName, LastName, st1, st2, City, State, Zip, Phone, Cell, Email, Fb) VALUES (@FName, @MName, @LName, @Street1, @Street2, @City, @State, @Zip, @Phone, @Cell, @Email, @Fb)";
            // Bark out command
            SqlCommand comm = new SqlCommand();
            comm.CommandText = strSQL;  //Commander knows what to say
            comm.Connection = Conn;     //Where's the phone?  Here it is

            //-----Fill in the paramters (Has to be created in same sequence as they are used in SQL Statement)
            comm.Parameters.AddWithValue("@FName", FName);
            comm.Parameters.AddWithValue("@MName", MName);
            comm.Parameters.AddWithValue("@LName", LName);
            comm.Parameters.AddWithValue("@Street1", Street1);
            comm.Parameters.AddWithValue("@Street2", Street2);
            comm.Parameters.AddWithValue("@City", City);
            comm.Parameters.AddWithValue("@State", State);
            comm.Parameters.AddWithValue("@Zip", Zip);
            comm.Parameters.AddWithValue("@Phone", Phone.Replace("-", string.Empty));
            comm.Parameters.AddWithValue("@Cell", Cell.Replace("-", string.Empty));
            comm.Parameters.AddWithValue("@Email", Email);
            comm.Parameters.AddWithValue("@Fb", Fb);
            /*
            comm.Parameters.AddWithValue("@CustSince", CustSince);
            comm.Parameters.AddWithValue("@TotalPurch", TotalPurch);
            comm.Parameters.AddWithValue("@DiscountMbr", DiscountMbr);
            comm.Parameters.AddWithValue("@Rewards", Rewards);
            */
            
            //-----attempt to connect to the server
            try
            {
                Conn.Open();                                        //Open connection to DB - Think of dialing a friend on phone
                int intRecs = comm.ExecuteNonQuery();
                strResult = $"SUCCESS: Inserted {intRecs} records.";       //Report that we made the connection and added a record
                Conn.Close();                                       //Hanging up after phone call
            }
            catch (Exception err)                                   //If we got here, there was a problem connecting to DB
            {
                strResult = "ERROR: " + err.Message;                //Set feedback to state there was an error & error info
            }
            finally
            {

            }

            //Return resulting feedback string
            return strResult;
        }
       

        // -----DRILL-DOWN Search, Takes search params to narrow the search results
        //Calling SearchPersons, passing 
        public DataSet SearchPersons(String strFSearch, String strLSearch)
        {
            //Create a dataset to return filled
            DataSet ds = new DataSet();
            //Create a command for our SQL statement
            SqlCommand comm = new SqlCommand();
            //THIS
            //Write a Select Statement to perform Search
            String strSQL = "SELECT Person_ID, FirstName, MiddleName, LastName, st1, st2, City, State, Zip, Phone, Cell, Email, Fb FROM Persons WHERE 0=0";
//!!!!!HERE
        //If the First/Last Name is filled in include it as search criteria
        if (strFSearch.Length > 0)
            {
                strSQL += " AND FirstName LIKE @FName";
                //% Don't care what starts or ends with
                comm.Parameters.AddWithValue("@FName", "%" + strFSearch + "%"); 
            }
        if (strLSearch.Length > 0)
            {
                strSQL += " AND LastName LIKE @LName";
                //% Don't care what starts or ends with
                comm.Parameters.AddWithValue("@LName", "%" + strLSearch + "%");
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
            da.Fill(ds, "Person_Temp"); //Fill the dataset with results from database and call it "Persons_Temp"
          
            conn.Close(); //Close the connection (hang up the phone)

            //Return the data
            return ds;
        }

         //-----Method that returns a Data Reader filled with all the data of one 'Person'. This 'Person' is specified by the ID passed to this function
        public SqlDataReader FindOnePerson(int intPersonV2_ID)
        {
            //Creat and Initialize the DB Tools we need
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();

            //My Connection String
            string strConn = GetConnected();

            //My SQL command string to pull up one 'Persons' data
            string sqlString = "SELECT * FROM Persons WHERE Person_ID = @Person_ID;";

            //Tell the connection object the who, what, where, how
            conn.ConnectionString = strConn;

            //Give the command object info it needs
            comm.Connection = conn;
            comm.CommandText = sqlString;
            comm.Parameters.AddWithValue("Person_ID", intPersonV2_ID); //PersonV2_ID change to Person_ID

            //Open the DataBase Connection and Yell our SQL Command
            conn.Open();

            //Return some form of feedback
            return comm.ExecuteReader();  //Return the dataset to be used by others (the calling form)
        }

        //Method that will delete one Person record specified by the ID
        //It will return an Interger meant for feedback on how many records were deleted
     /*   public string DeleteOnePerson(int intPerson_ID)
        {
            Int32 intRecords = 0;
            string strResult = "";
            //Create and Initialize the DB tools we need
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();

            //Connection string
            string strConn = GetConnected();

            //MySQL command string to pull one Person's data
            string sqlString = "DELETE FROM Persons WHERE Person_ID = @Person_ID;";
            //Tell the connection object the who, what where, how
            conn.ConnectionString = strConn;

            //Give the command object info it needs
            comm.Connection = conn;
            comm.CommandText = sqlString;
            comm.Parameters.AddWithValue("@Person_ID", Person_ID);

            try
            {
                //Open the connection
                conn.Open();
                //Run the Delete and store the number of records effected
                intRecords = comm.ExecuteNonQuery();
                strResult = intRecords.ToString() + " Records Deleted.";
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

        public string UpdateARecord()
        {
            Int32 intRecords = 0;
        }
        */

        //-----Utility function so that one string controls all SQL Server Login info
        private string GetConnected()
        {
            return "Server=sql.neit.edu,4500;Database=SE245_bgiroux;User Id=SE245_bgiroux;Password=008007874;";
        }

        //-----Default Constructor
        public PersonV2() : base()  //calls the parent constructor
        {
            Fb = "";
            Cell = "";
            feedback = "";
        }

    } //end of class PersonV2 : Person      
}
