using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kerala_Forest_Dept
{
    public partial class newempfrm : Form
    {
        public newempfrm()
        {
            InitializeComponent();
        }

        private void employeeBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.employeeBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.kFD_DBDataSet);

        }

        private void newempfrm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kFD_DBDataSet.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.kFD_DBDataSet.Employee);
            employeeBindingSource.AddNew();
            
        }

        private void enameLabel_Click(object sender, EventArgs e)
        {

        }

        private void eidLabel_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //employeeBindingSource.EndEdit();
            //tableAdapterManager.UpdateAll(kFD_DBDataSet);
            employeeTableAdapter.Update(kFD_DBDataSet);
            MessageBox.Show("Updated");

            

         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            employeeBindingSource.AddNew();
            enameTextBox.Clear();
            eidTextBox.Clear();
            typeComboBox.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
