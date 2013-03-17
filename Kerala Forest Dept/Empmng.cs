using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PrintPreviewRichTextBox;
using System.Data.SqlServerCe;

namespace Kerala_Forest_Dept
{
    public partial class Empmng : Form
    {
        
        BindingSource bSource;
        SqlCeDataAdapter adp;
        DataTable dt;
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
        private DataTable execquery(String str)
        {
            try
            {

                SqlCeConnection conn;
                SqlCeCommand selectcmd;
                
                DataSet ds;
                
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
                bSource = new BindingSource();

                //set the BindingSource DataSource
                bSource.DataSource = dt;

                //set the DataGridView DataSource
                dataGridView1.DataSource = bSource;
            
                return dt;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;

        }
        public Empmng()
        {
            InitializeComponent();
        }

        private void Empmng_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            DataTable d = execquery("select * from Employee");
            //dataGridView1.DataSource = dt;
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //DataSet ds = (DataSet)dataGridView1.DataSource;
            //ds.AcceptChanges();
            //Console.WriteLine("adasd");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            //DataSet ds = (DataSet)dataGridView1.DataSource;
            //ds.AcceptChanges();
            for (int i = 1; i < dataGridView1.Rows.Count-1; i++)
            {
                if (dataGridView1.Rows[i].IsNewRow == true)
                {
                    execquery_noreturn("INSERT INTO Employee (Eid, Ename, Address, Phone, Sex, EmpType, WorkType) VALUES ('" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[5].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[6].Value.ToString() + "')");
                    MessageBox.Show("asdasd");
                }
            }
            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SqlCeCommandBuilder sb = new SqlCeCommandBuilder(adp);
            adp.UpdateCommand = sb.GetUpdateCommand();
            adp.InsertCommand = sb.GetInsertCommand();
            adp.Update(dt);
            MessageBox.Show("Employee Details Updated!");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //DataSet ds = (DataSet)dataGridView1.Rows[1].DataBoundItem;
            //d.AcceptChanges();
          
            //Console.WriteLine(adp.InsertCommand.CommandText.ToString());
            
        }
    }
}
