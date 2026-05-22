using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace prjInspecaoCSNet40
{
    static class Program
    {
        public static frmPrincipal objPrincipal = new frmPrincipal();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(objPrincipal);
        }
    }
}
