using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Kerala_Forest_Dept
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Parent1());
        }
    }
}
