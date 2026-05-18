using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace prjColetorDadosCSNet35
{
    static class Program
    {
        public static frmPrincipal objPrincipal = new frmPrincipal();
        //public static frmBatteryStatus objBatteryStatus = new frmBatteryStatus();

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