using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Brenna_Lab5
{
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }

//HERE!!! On Searcg.cs[Design] add the Event (lightening Bolt) "Click" 
// NOW TO GO PersonV2.cs line 123 and PUT A SPACE before AND, SQL needs the space or it will combine AND with other command
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Get Data
            PersonV2 temp = new PersonV2();
            //Perform the search created in PersonV2 class and store in returned dataset
            DataSet ds = temp.SearchPersons(txtFSearch.Text, txtLSearch.Text);

            //Display data (dataset)
            dataGridView1.DataSource = ds;    //point datagrid to dataset
            dataGridView1.DataMember = ds.Tables["Person_Temp"].ToString(); // What table in the dataset?
        }
        //Event-Handler Method - When we double-click a data cell, get the ID and use it to search for the whole record //object sender= button in generic form, have to convert over to button to have features
        private void dataGridView1_CellDoubeClick(object sender, DataGridViewCellEventArgs e)
        {
            //Gather the information (Gathers the row clicked, then chooses the first cell's data
            string strPerson_ID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            //Display data in Pop-up
            MessageBox.Show(strPerson_ID);

            //Convert the string over to an integer
            int intPerson_ID = Convert.ToInt32(strPerson_ID);

            //Create the editor form, passing it one PersonV2 ID and show it
            // NOTE THAT THE ID BEING PASSED WILL CALL THE OVERLOADED VERSION OF THE CONSTRUCTOR...TELL IT, IN ESSENCE THAT WE ARE PULLING UP RATHER THAN ADDING DATA 
            Form1 Editor = new Form1(intPerson_ID);
            Editor.ShowDialog();

        }

        private void Search_Load(object sender, EventArgs e)
        {

        }
        private void Search_Load_1(object sender, EventArgs e)
        {

        }

       
    }
}
