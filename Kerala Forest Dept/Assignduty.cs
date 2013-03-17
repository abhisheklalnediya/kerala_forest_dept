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
    public partial class Assignduty : Form
    {
        Form f;
        ProgressBar c;
        public Assignduty()
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
                //return dt.Rows;
                return dt;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;

        }
        private void Assignduty_Load(object sender, EventArgs e)
        {
            f = Parent1.ActiveForm;
            c = (ProgressBar)f.Controls["progressBar1"];
            comboBox1.DataSource = execquery("select DISTINCT duty from Duty");
            //DataTable dtt = execquery("select Employee.Eid,Employee.Ename from Employee where Employee.Eid=Attentance.Eid AND Attentance.Present=1 AND Attentance.AttDate='" + dateTimePicker1.Value.ToShortDateString() + "'");
            //for (int i = 0; i < dtt.Rows.Count; i++)
            //{
            //    listView2.Items.Add(dtt.Rows[i].ItemArray.GetValue(0).ToString());
            //    listView2.Items[i].SubItems.Add(dtt.Rows[i].ItemArray.GetValue(1).ToString());
            //    DataTable dttt = execquery("select Duty from Duty where Eid='" + dtt.Rows[i].ItemArray.GetValue(0).ToString() + "' and ddate='" + dateTimePicker1.Value.ToShortDateString() + "'");
            //    string str="";
            //    for (int x = 0; x < dttt.Rows.Count;x++ )
            //    {
            //        str += dttt.Rows[x].ItemArray.GetValue(0).ToString();
            //        str += ", ";
            //        //listView2.Items[i].SubItems.Add(dttt.Rows[0].ItemArray.GetValue(0).ToString());
            //        //MessageBox.Show(dttt.Rows[0].ItemArray.GetValue(0).ToString());
            //    }
            //    listView2.Items[i].SubItems.Add(str);
            //}
            
            listView2.View = View.Details;
            listView2.LabelEdit = true;
            listView2.AllowColumnReorder = true;
            listView2.CheckBoxes = true;
            listView2.FullRowSelect = true;            
            listView2.GridLines = true;
            dateTimePicker1.Value = DateTime.Now;
            textBox1.Text = listView2.CheckedItems.Count.ToString();
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
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                c.Maximum = listView2.CheckedItems.Count - 1;
            }
            catch(Exception ex)
            {
            }
            for (int i = 0; i < listView2.CheckedItems.Count; i++)
            {
                c.Value = i;
                string str = "insert into duty values ('"+listView2.CheckedItems[i].Text+"','"+comboBox1.Text+"','"+dateTimePicker1.Value.ToShortDateString()+"','"+textBox2.Text+"')";
                insert(str);
                
                //dt.Rows.Add();
                //MessageBox.Show(str);
            }
            listView2.Items.Clear();
            comboBox1.DataSource = execquery("select DISTINCT duty from Duty");
            textBox2.Text = "";
            dateTimePicker1_ValueChanged(null, null);
           

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void listView2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            textBox1.Text = listView2.CheckedItems.Count.ToString();
        }
        private void listView2_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            textBox1.Text = listView2.CheckedItems.Count.ToString();
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                listView2.Items.Clear();
                DataTable dtt = execquery("SELECT Employee.Eid, Employee.Ename FROM Employee INNER JOIN Attentence ON Employee.Eid = Attentence.Eid WHERE (Attentence.Present = 1) AND (Attentence.AttDate = '" + dateTimePicker1.Value.ToShortDateString() + "')");
                Console.WriteLine("SELECT Employee.Eid, Employee.Ename FROM Employee INNER JOIN Attentence ON Employee.Eid = Attentence.Eid WHERE (Attentence.Present = 1) AND (Attentence.AttDate = '" + dateTimePicker1.Value.ToShortDateString() + "'");
                c.Maximum = dtt.Rows.Count - 1;
                for (int i = 0; i < dtt.Rows.Count; i++)
                {
                    c.Value = i;
                    listView2.Items.Add(dtt.Rows[i].ItemArray.GetValue(0).ToString());
                    listView2.Items[i].SubItems.Add(dtt.Rows[i].ItemArray.GetValue(1).ToString());
                    DataTable dttt = execquery("select Duty from Duty where Eid='" + dtt.Rows[i].ItemArray.GetValue(0).ToString() + "' and ddate='" + dateTimePicker1.Value.ToShortDateString() + "'");
                    string str = "";
                    for (int x = 0; x < dttt.Rows.Count; x++)
                    {
                        str += dttt.Rows[x].ItemArray.GetValue(0).ToString();
                        str += ",";
                        //listView2.Items[i].SubItems.Add(dttt.Rows[0].ItemArray.GetValue(0).ToString());
                        //MessageBox.Show(dttt.Rows[0].ItemArray.GetValue(0).ToString());
                    }
                    listView2.Items[i].SubItems.Add(str);
                }
                comboBox1.DataSource = execquery("select DISTINCT duty from Duty");
            }
            catch (Exception ex)
            {
                listView2.Items.Clear();
            }
           

        }
        
    }
}
