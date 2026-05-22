using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace prjColetorDadosCSNet35
{
    public partial class frmMonitorCarregamentoDados
    {
        private static System.Threading.Thread ThManterCanalAberto;

        private void mtdIniciarThreadManterCanalAberto()
        {
            try
            {
                mtdAbortarThreadManterCanalAberto();

                blnForcarAbortoManterCanalAberto = false;

                ThManterCanalAberto = new System.Threading.Thread
                    (
                    new System.Threading.ThreadStart
                        (
                        this.mtdRotinaManterCanalAberto
                        )
                        );
                ThManterCanalAberto.IsBackground = true;
                ThManterCanalAberto.Priority = System.Threading.ThreadPriority.Lowest;
                ThManterCanalAberto.Start();
            }
            catch (System.Exception ex)
            {
                //mtdAbortarThreadManterCanalAberto();

                string strExcecao = "mtdIniciarThreadManterCanalAberto: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        public static void mtdAbortarThreadManterCanalAberto()
        {
            try
            {
                blnForcarAbortoManterCanalAberto = true;

                ThManterCanalAberto.Abort();
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdAbortarThreadManterCanalAberto: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private static bool blnForcarAbortoManterCanalAberto = false;

        private static object LockerRotinaManterCanalAberto = new object();

        private void mtdRotinaManterCanalAberto()
        {
            lock (LockerRotinaManterCanalAberto)
            {
                while (!blnForcarAbortoManterCanalAberto)
                {
                    mtdManterCanalAberto();
                }
            }
        }
    }
}
