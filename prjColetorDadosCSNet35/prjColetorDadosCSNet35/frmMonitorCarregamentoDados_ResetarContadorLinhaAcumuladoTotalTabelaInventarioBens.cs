using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace prjColetorDadosCSNet35
{
    public partial class frmMonitorCarregamentoDados
    {
        private System.Threading.Thread ThResetarContadorLinhaAcumuladoTotalTabelaInventarioBens;

        private void mtdIniciarThreadResetarContadorLinhaAcumuladoTotalTabelaInventarioBens()
        {
            try
            {
                mtdAbortarThreadResetarContadorLinhaAcumuladoTotalTabelaInventarioBens();

                ThResetarContadorLinhaAcumuladoTotalTabelaInventarioBens = new System.Threading.Thread
                    (
                    new System.Threading.ThreadStart
                        (
                        this.mtdRotinaResetarContadorLinhaAcumuladoTotalTabelaInventarioBens
                        )
                        );
                ThResetarContadorLinhaAcumuladoTotalTabelaInventarioBens.IsBackground = true;
                ThResetarContadorLinhaAcumuladoTotalTabelaInventarioBens.Priority = System.Threading.ThreadPriority.Lowest;
                ThResetarContadorLinhaAcumuladoTotalTabelaInventarioBens.Start();
            }
            catch (System.Exception ex)
            {
                //mtdAbortarThreadResetarContadorLinhaAcumuladoTotalTabelaInventarioBens();

                string strExcecao = "mtdIniciarThreadResetarContadorLinhaAcumuladoTotalTabelaInventarioBens: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void mtdAbortarThreadResetarContadorLinhaAcumuladoTotalTabelaInventarioBens()
        {
            try
            {
                ThResetarContadorLinhaAcumuladoTotalTabelaInventarioBens.Abort();
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdAbortarThreadResetarContadorLinhaAcumuladoTotalTabelaInventarioBens: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private static object LockerRotinaResetarContadorLinhaAcumuladoTotalTabelaInventarioBens = new object();

        private void mtdRotinaResetarContadorLinhaAcumuladoTotalTabelaInventarioBens()
        {
            lock (LockerRotinaResetarContadorLinhaAcumuladoTotalTabelaInventarioBens)
            {
                mtdResetarContadorLinhaAcumuladoTotalTabelaInventarioBens();
                mtdAbortarThreadResetarContadorLinhaAcumuladoTotalTabelaInventarioBens();
            }
        }
    }
}
