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
    public partial class Parent1 : Form
    {
        private int childFormNumber = 0;

        public Parent1()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            newempfrm ne = new newempfrm();
            bool b = true;
            foreach (Form fr in this.MdiChildren)
            {
                if (fr.GetType() == ne.GetType())
                {
                    b = false;
                    fr.Activate();
                }
            }
            if (b)
            {
                ne.MdiParent = this;
                ne.Show();
            }
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Empmng tp = new Empmng();
            tp.MdiParent=this;
            tp.Show();
        }

        private void dailyToolStripMenuItem_Click(object sender, EventArgs e)
        {
             Attentance f = new Attentance();
             
            bool b = true;
            foreach (Form fr in this.MdiChildren)
            {
                if (fr.GetType() == f.GetType())
                {
                    b = false;
                    fr.Activate();
                }
            }
            if (b)
            {
                f.MdiParent = this;
                f.Show();
            }
        }

        private void Parent1_Load(object sender, EventArgs e)
        {
            
        }

        private void dutyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void assignDutyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Assignduty ass = new Assignduty();
            bool b = true;
            foreach (Form fr in this.MdiChildren)
            {
                if (fr.GetType() == ass.GetType())
                {
                    b = false;
                    fr.Activate();
                }
            }
            if (b)
            {
                ass.MdiParent = this;
                ass.Show();
            }

        }

        private void reviewDutyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printres ass = new printres();
            //Assignduty ass = new Assignduty();
            bool b = true;
            foreach (Form fr in this.MdiChildren)
            {
                if (fr.GetType() == ass.GetType())
                {
                    b = false;
                    fr.Activate();
                }
            }
            if (b)
            {
                ass.MdiParent = this;
                ass.Show();
            }

        }

        private void takeToolStripMenuItem_Click(object sender, EventArgs e)
        {
         //   attanta att = new attanta();
           // att.MdiParent = this;
           // att.Show();
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            //printres p;
            //p.Form = this.ActivateMdiChild();
            //p = (Kerala_Forest_Dept.printres)printres.ActiveForm;
            //p.print();
            //p.FO
            
        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {
            
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AttReport ass = new AttReport();
            //Assignduty ass = new Assignduty();
            bool b = true;
            foreach (Form fr in this.MdiChildren)
            {
                if (fr.GetType() == ass.GetType())
                {
                    b = false;
                    fr.Activate();
                }
            }
            if (b)
            {
                ass.MdiParent = this;
                ass.Show();
            }

        }

        
        

        
    }
}
