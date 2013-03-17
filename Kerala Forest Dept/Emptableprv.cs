using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace Kerala_Forest_Dept
{
    public partial class Emptableprv : Form
    {
        public Emptableprv()
        {
            InitializeComponent();
        }
        private DataTable execquery(String str)
        {
            SqlCeConnection conn;
            SqlCeCommand selectcmd;
            SqlCeDataAdapter adp;
            DataSet ds;
            DataTable dt;

            try
            {
                conn = new SqlCeConnection("Data Source=KFD_DB.sdf;Password=86130002");

                selectcmd = conn.CreateCommand();
                selectcmd.CommandText = str;
                adp = new SqlCeDataAdapter(selectcmd);
                ds = new DataSet();
                dt = new DataTable();
                conn.Open();
                adp.Fill(ds);
                adp.Fill(dt);
                return dt;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;

        }
        private void insert(string str)
        {
            SqlCeConnection conn;
            SqlCeCommand selectcmd;
            SqlCeDataAdapter adp;
            DataSet ds;
            DataTable dt;
            try
            {
                conn = new SqlCeConnection("Data Source=KFD_DB.sdf;Password=86130002");

                selectcmd = conn.CreateCommand();
                selectcmd.CommandText = str;
                adp = new SqlCeDataAdapter(selectcmd);
                //ds = new DataSet();
                //dt = new DataTable();
                conn.Open();
                selectcmd.ExecuteNonQuery();
                conn.Close();
                //adp.Fill(ds);
                //adp.Fill(dt);
                //return dt.Rows;
                //return dt;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        private void employeeBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.employeeBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.kFD_DBDataSet);
            DataTable dt=execquery("select * from Attentence WHERE (AttDate = '" + DateTime.Now.ToShortDateString() + "')");
            if (dt.Rows.Count != 0)
            {
                dt = execquery("SELECT Eid FROM Employee WHERE (Eid NOT IN  (SELECT Eid FROM Attentence))");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    insert("INSERT INTO Attentence(Eid, AttDate, Present)VALUES ('" + dt.Rows[i].ItemArray.GetValue(0).ToString() + "', '" + DateTime.Now + "', 0)");
                }
            }


        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kFD_DBDataSet.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.kFD_DBDataSet.Employee);
            // TODO: This line of code loads data into the 'kFD_DBDataSet.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.kFD_DBDataSet.Employee);

        }

        private void employeeBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.employeeBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.kFD_DBDataSet);

        }
    }
}
