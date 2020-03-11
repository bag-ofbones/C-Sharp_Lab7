using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BGiroux_Final
{
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Get Data
            Pet temp = new Pet();
            //Perform the search created in the Pet class and store in returned dataset
            DataSet ds = temp.SearchPet(txtFSearch.Text);
            //Display data (dataset)
            //point datagrid to dataset
            dataGridView1.DataSource = ds;    
            dataGridView1.DataMember = ds.Tables["Pet_Temp"].ToString(); 
        }
        //Event-Handler Method - When we double-click a data cell, get the ID and use it to search for the whole record 
        //object sender= button in generic form, have to convert over to button to have features
        private void dataGridView1_CellDoubeClick(object sender, DataGridViewCellEventArgs e)
        {
            //Gather the information (Gathers the row clicked, then chooses the first cell's data
            string strPetID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            //Display data in Pop-up
            MessageBox.Show(strPetID);

            //Convert the string over to an integer
            int intPetID = Convert.ToInt32(strPetID);

            //Create the editor form, passing it one Pet ID and show it
            // The ID being passed will call the overloaded version of the constructor
            Form1 Editor = new Form1(intPetID);
            Editor.ShowDialog();

        }

        private void Search_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtFSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
