namespace Solucoes_Rede_Neural_CSCoreNet
{
    internal static class Program
    {
        public static frmPrincipal objPrincipal;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            objPrincipal = new frmPrincipal();
            Application.Run(objPrincipal);
        }
    }
}