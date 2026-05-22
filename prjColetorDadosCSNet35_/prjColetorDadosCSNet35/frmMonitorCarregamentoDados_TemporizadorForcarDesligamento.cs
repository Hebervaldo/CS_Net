using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace prjColetorDadosCSNet35
{
    public partial class frmMonitorCarregamentoDados
    {
        private static System.Threading.Thread ThTemporizadorForcarDesligamento;

        private void mtdIniciarThreadTemporizadorForcarDesligamento()
        {
            try
            {
                mtdAbortarThreadTemporizadorForcarDesligamento();

                blnForcarAbortoTemporizadorForcarDesligamento = false;

                ThTemporizadorForcarDesligamento = new System.Threading.Thread
                    (
                    new System.Threading.ThreadStart
                        (
                        this.mtdRotinaTemporizadorForcarDesligamento
                        )
                        );
                ThTemporizadorForcarDesligamento.IsBackground = true;
                ThTemporizadorForcarDesligamento.Priority = System.Threading.ThreadPriority.Lowest;
                ThTemporizadorForcarDesligamento.Start();

                blnTemporizadorAtivado = true;
            }
            catch (System.Exception ex)
            {
                //mtdAbortarThreadTemporizadorForcarDesligamento();

                string strExcecao = "mtdIniciarThreadTemporizadorForcarDesligamento: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        public static void mtdAbortarThreadTemporizadorForcarDesligamento()
        {
            try
            {
                blnTemporizadorAtivado = false;

                blnForcarAbortoTemporizadorForcarDesligamento = true;

                ThTemporizadorForcarDesligamento.Abort();
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdAbortarThreadTemporizadorForcarDesligamento: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        public static bool blnTemporizadorAtivado = false;

        private static bool blnForcarAbortoTemporizadorForcarDesligamento = false;

        private static object LockerRotinaTemporizadorForcarDesligamento = new object();

        private void mtdRotinaTemporizadorForcarDesligamento()
        {
            while (!blnForcarAbortoTemporizadorForcarDesligamento)
            {
                blnTemporizadorAtivado = true;

                lock (LockerRotinaTemporizadorForcarDesligamento)
                {
                    mtdTemporizadorForcarDesligamento();
                }
            }
        }

        private static double dblTempoTemporizadorForcarDesligamento = DateTime.Now.TimeOfDay.TotalMilliseconds;
        private static double dblDiferencaTemporizadorForcarDesligamento = 0;

        private void mtdTemporizadorForcarDesligamento()
        {
            dblDiferencaTemporizadorForcarDesligamento = DateTime.Now.TimeOfDay.TotalMilliseconds - dblTempoTemporizadorForcarDesligamento;
            if (dblDiferencaTemporizadorForcarDesligamento >= (double)(frmPrincipal.uintTemporizador * 60 * 1000))
            {
                dblTempoTemporizadorForcarDesligamento = DateTime.Now.TimeOfDay.TotalMilliseconds;
                clsShutdownDevice.mtdForcePowerOff();
                mtdAbortarThreadTemporizadorForcarDesligamento();
            }
        }
    }
}