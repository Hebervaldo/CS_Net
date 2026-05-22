using System;
using System.Windows.Forms;

namespace Solucoes_Rede_Neural_CSNet
{
    static class Program
    {
        public static frmPrincipal objPrincipal;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            objPrincipal = new frmPrincipal(); 
            Application.Run(objPrincipal);
        }
    }
}
