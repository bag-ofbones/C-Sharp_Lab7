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
    public partial class ControlPanel : Form
    {
        public ControlPanel()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Create an instance of the form in memory
            Form1 temp = new Form1();
            //to show up on screen
            temp.Show(); //temp.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {  //Add Search form
            Search temp = new Search();
            temp.Show();
        }

        private void ControlPanel_Load(object sender, EventArgs e)
        {

        }
    }
}
