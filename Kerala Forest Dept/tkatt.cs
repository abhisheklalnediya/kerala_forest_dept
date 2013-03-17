using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
namespace Kerala_Forest_Dept
{
    public partial class Attentance : Form
    {
        public Attentance()
        {
            InitializeComponent();
        }
        private DataTable dgdt;

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
        private void execquery_noreturn(String str)
        {
            SqlCeConnection conn;
            SqlCeCommand selectcmd;
            DataSet ds;
            

            try
            {
                conn = new SqlCeConnection("Data Source=KFD_DB.sdf;Password=86130002");
                selectcmd = conn.CreateCommand();
                selectcmd.CommandText = str;
                ds = new DataSet();
                conn.Open();
                selectcmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        Form f;
        ProgressBar c;

        private void Form1_Load(object sender, EventArgs e)
        {
            f = Parent1.ActiveForm;
            c = (ProgressBar)f.Controls["progressBar1"];
            
            dateTimePicker1.Value = DateTime.Now;
            //DataTable dt= execquery("select * from Attentence WHERE (AttDate = '" + dateTimePicker1.Value.Date.ToShortDateString() + "')");
            //dgdt = dt;
            //dataGridView1.DataSource = dgdt;
            dateTimePicker1.MaxDate = DateTime.Now;
        }

  
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DataTable dt= execquery("select * from Attentence WHERE (AttDate = '" + dateTimePicker1.Value.Date.ToShortDateString() + "')");
            dgdt = dt;
            dataGridView1.DataSource = dgdt;
            if (dt.Rows.Count == 0)
            {    
                DataTable dtt = execquery("select Eid from employee");
                c.Maximum = dtt.Rows.Count - 1;
                for (int i = 0; i < dtt.Rows.Count;i++ )
                {
                    c.Value = i;
                    //DataRow dr=drc[i];
                    string str = dtt.Rows[i].ItemArray.GetValue(0).ToString();
                    execquery_noreturn("INSERT INTO Attentence(Eid, AttDate, Present)VALUES ('" + str + "', '" + dateTimePicker1.Value.Date.ToShortDateString() + "', 0)");
                }
                
            }

            DataTable dttt= execquery("select Attentence.Eid,Employee.Ename,Attentence.Present from Employee,Attentence WHERE (AttDate = '" + dateTimePicker1.Value.Date.ToShortDateString() + "' AND Employee.Eid=Attentence.Eid)");
            dgdt = dttt;
            dataGridView1.DataSource = dgdt;
            dataGridView1.Columns[0].HeaderText = "E ID";
            dataGridView1.Columns[1].HeaderText = "Name";
            dataGridView1.Columns[2].HeaderText = "Present";

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           // dataGridView1.SelectedRows


        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectAll();
            //MessageBox.Show(dataGridView1.Rows[1].Cells[2].Value.ToString());

            //return;
            c.Maximum = dataGridView1.Rows.Count - 2;
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                c.Value=i;
                if (dataGridView1.Rows[i].Cells[2].Value.ToString() == "True")
                {
                    execquery_noreturn("UPDATE Attentence set Present=1 where Eid='" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "'");
                    //    Console.WriteLine("UPDATE Attentence set Present=1 where Eid='" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "'");
                }
                else
                {
                    execquery_noreturn("UPDATE Attentence set Present=0 where Eid='" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "'");
                }
            }
            DataTable dt = execquery("select Attentence.Eid,Employee.Ename,Attentence.Present from Employee,Attentence WHERE (AttDate = '" + dateTimePicker1.Value.Date.ToShortDateString() + "' AND Employee.Eid=Attentence.Eid and Attentence.value=1)");
            DataTable dttt = execquery("select Attentence.Eid,Employee.Ename,Attentence.Present from Employee,Attentence WHERE (AttDate = '" + dateTimePicker1.Value.Date.ToShortDateString() + "' AND Employee.Eid=Attentence.Eid)");
            dgdt = dttt;
            dataGridView1.DataSource = dgdt;
            dataGridView1.Columns[0].HeaderText = "E ID";
            dataGridView1.Columns[1].HeaderText = "Name";
            dataGridView1.Columns[2].HeaderText = "Present";

        }

        
    }
}
