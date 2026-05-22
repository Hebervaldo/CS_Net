using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace prjColetorDadosIntermecCSNet35
{
    public partial class frmMonitorCarregamentoDados
    {
        private System.Threading.Thread ThForcarParada;

        private void mtdIniciarThreadForcarParada(string ForcarParada)
        {
            try
            {
                strForcarParada = ForcarParada;

                mtdAbortarThreadForcarParada();

                ThForcarParada = new System.Threading.Thread
                    (
                    new System.Threading.ThreadStart
                        (
                        this.mtdRotinaForcarParada
                        )
                        );
                ThForcarParada.IsBackground = true;
                ThForcarParada.Priority = System.Threading.ThreadPriority.Lowest;
                ThForcarParada.Start();
            }
            catch (System.Exception ex)
            {
                //mtdAbortarThreadForcarParada();

                string strExcecao = "mtdIniciarThreadForcarParada: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void mtdAbortarThreadForcarParada()
        {
            try
            {
                ThForcarParada.Abort();
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdAbortarThreadForcarParada: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private static object LockerRotinaForcarParada = new object();

        private void mtdRotinaForcarParada()
        {
            lock (LockerRotinaForcarParada)
            {
                mtdForcarParada();
                mtdAbortarThreadForcarParada();
            }
        }
    }
}
