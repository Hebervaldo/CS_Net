using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
namespace prjInspecaoCSNet35
{
    static class Program
    {
        public static frmPrincipal objPrincipal = new frmPrincipal();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            Application.Run(objPrincipal);
        }
    }
}