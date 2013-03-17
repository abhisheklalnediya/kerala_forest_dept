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
    public partial class printres : Form
    {
       
        public printres()
        {
            InitializeComponent();
        }
        private ContextMenu cc;


        private void printres_Load(object sender, EventArgs e)
        {
                        
            this.WindowState = FormWindowState.Maximized;
            cc = new ContextMenu();
            Point pos = MousePosition;
            MenuItem mi = new MenuItem("Cu&t", mi_Cut, Shortcut.CtrlX);
            cc.MenuItems.Add(mi);
            mi = new MenuItem("&Copy", mi_Copy, Shortcut.CtrlC);
            cc.MenuItems.Add(mi);
            mi = new MenuItem("&Paste", mi_Paste, Shortcut.CtrlV);
            cc.MenuItems.Add(mi);
            mi = new MenuItem("&Select All", mi_SelectAll, Shortcut.CtrlA);
            cc.MenuItems.Add(mi);
            richTextBox1.ContextMenu = cc;
            
            richTextBox1.SelectAll();
            richTextBox1.Clear();

            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily,10,richTextBox1.SelectionFont.Style);
            int[] x = new int[4] {50,150,250, 500 };
            richTextBox1.SelectionTabs = x;
            dateTimePicker1.Value = DateTime.Now;
            
            
            
        }
        public void print()
        {
            var doc = new RichTextBoxDocument(richTextBox1);
            printDocument1 = doc;
            printDialog1.Document = doc;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            print();
        }

        void mi_Cut(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }
        void mi_SelectAll(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }
        void mi_Copy(object sender, EventArgs e)        
        {
            //Graphics objGraphics;
            Clipboard.SetData(DataFormats.Rtf, richTextBox1.SelectedRtf);
            //Clipboard.Clear();
        }
        void mi_Paste(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText(TextDataFormat.Rtf))
            {
                richTextBox1.SelectedRtf = Clipboard.GetData(DataFormats.Rtf).ToString();
            }
        }
        private DataTable execquery(String str)
        {
            try
            {
                SqlCeConnection conn;
                SqlCeCommand selectcmd;
                SqlCeDataAdapter adp;
                DataSet ds;
                DataTable dt;
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





        
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, 10, richTextBox1.SelectionFont.Style);
            int[] x = new int[4] { 50, 150, 250, 500 };
            richTextBox1.SelectionTabs = x;

            DataTable dt = execquery("select DISTINCT Duty from Duty where ddate='" + dateTimePicker1.Value.ToShortDateString() + "'");
            richTextBox1.AppendText( "\r\nKulathupuzha\t\t\tUnit III\r");
            richTextBox1.AppendText("\t\t\t\t"+dateTimePicker1.Value.ToShortDateString()+"\r\r");
            int cnt = 0;
            for(int i=0;i<dt.Rows.Count;i++)
            {
                DataTable dtt = execquery("select Eid,Notes from Duty where duty='" + dt.Rows[i].ItemArray.GetValue(0) + "' AND ddate='" + dateTimePicker1.Value.ToShortDateString() + "'");
                richTextBox1.SelectAll();
                
                richTextBox1.AppendText(String.Format("{0:00}", i+1)+"\t"+ dt.Rows[i].ItemArray.GetValue(0) + "\t" + dtt.Rows.Count.ToString()+"\t");
                cnt += dtt.Rows.Count;
                for (int j = 0; j < dtt.Rows.Count; j++)
                {
                    
                    if (j == dtt.Rows.Count - 1)
                    {
                        richTextBox1.AppendText( dtt.Rows[j].ItemArray.GetValue(0).ToString());
                    }
                    else
                    {
                        richTextBox1.AppendText( dtt.Rows[j].ItemArray.GetValue(0) + " ,");
                    }
                    if (j % 7 == 0&&j!=0)
                    {
                        richTextBox1.AppendText("\r\t\t\t");
                    }
                }
                richTextBox1.AppendText( "\t"+dtt.Rows[i].ItemArray.GetValue(1));
                richTextBox1.AppendText("\r");
                
            }
            //richTextBox1.AppendText(cnt);
            NumberToWordConverter1 nw = new NumberToWordConverter1();
            richTextBox1.AppendText("\n\t\t"+nw.NumberToText(cnt));
            richTextBox1.AppendText("\n\nCom. Of \t\t: Compensatory off");
            richTextBox1.AppendText("\nLL \t\t: Lend labour");
            richTextBox1.AppendText("\nP.H,I.B,Co.Sc \t: Pump house. Inspection Bunglow, Cooperative society");
            richTextBox1.AppendText("\nP.Tp \t\t: Permanent tappers Extra tappers");
                
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fontDialog1.Font;
            }
        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = fontDialog1.Font;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

    }
}
