using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceCSNet40
{
    public partial class frmImportacaoExportacaoDados
    {
        private System.Threading.Thread ThreadPreparacaoPrincipal;

        private string strNomeProcessoPreparacaoPrincipal = "Preparação do Principal";

        private void mtdIniciarThreadPreparacaoPrincipal()
        {
            mtdIniciarThreadPreparacaoPrincipal(true);
        }

        private void mtdIniciarThreadPreparacaoPrincipal(bool Iniciar)
        {
            try
            {
                intProgresso = 0;
                strNomeProcesso = strNomeProcessoPreparacaoPrincipal;
                blnAbortarThreadPreparacaoPrincipal = !Iniciar;
                blnForcarAbortarThreadPreparacaoPrincipal = false;
                ThreadPreparacaoPrincipal = new System.Threading.Thread
                    (
                    new System.Threading.ThreadStart
                        (
                        mtdRotinaThreadPreparacaoPrincipal
                        )
                    );
                ThreadPreparacaoPrincipal.IsBackground = true;
                ThreadPreparacaoPrincipal.Priority = System.Threading.ThreadPriority.Normal;
                ThreadPreparacaoPrincipal.Start();
            }
            catch (Exception ex)
            {
                string strExcecao = "mtdIniciarThreadPreparacaoPrincipal: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        private void mtdReIniciarThreadPreparacaoPrincipal()
        {
            intProgresso = 0;
            strNomeProcesso = strNomeProcessoPreparacaoPrincipal;
            blnAbortarThreadPreparacaoPrincipal = false;
            blnForcarAbortarThreadPreparacaoPrincipal = false;
        }

        private static bool blnForcarAbortarThreadPreparacaoPrincipal = false;
        private static bool blnAbortarThreadPreparacaoPrincipal = false;
        private static int intTempoSaidaAbortarThreadPreparacaoPrincipal = 1000;

        private void mtdAbortarThreadPreparacaoPrincipal()
        {
            mtdAbortarThreadPreparacaoPrincipal(false);
        }

        private void mtdAbortarThreadPreparacaoPrincipal(bool Forcar)
        {
            intProgresso = 100;
            System.Threading.Thread.Sleep(1000);
            intProgresso = 0;
            strNomeProcesso = strNomeProcessoPreparacaoPrincipal;
            blnAbortarThreadPreparacaoPrincipal = true;
            blnForcarAbortarThreadPreparacaoPrincipal = Forcar;

            try
            {
                mtdAbortarThreadImportarDadosTabelaBensPrincipal(Forcar);
                mtdAbortarThreadImportarDadosTabelaEmpregadosPrincipal(Forcar);
                mtdAbortarThreadTransferirDadosTabelaInventarioBensPrincipal(Forcar);

                ThreadPreparacaoPrincipal.Join(intTempoSaidaAbortarThreadPreparacaoPrincipal);
                ThreadPreparacaoPrincipal.Abort();
                ThreadPreparacaoPrincipal = null;
            }
            catch (Exception ex)
            {
                string strExcecao = "mtdAbortarThreadPreparacaoPrincipal: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        private void mtdPararThreadPreparacaoPrincipal()
        {
            intProgresso = 100;
            System.Threading.Thread.Sleep(1000);
            intProgresso = 0;
            strNomeProcesso = strNomeProcessoPreparacaoPrincipal;
            blnAbortarThreadPreparacaoPrincipal = true;
            blnForcarAbortarThreadPreparacaoPrincipal = true;
        }

        private static object LockPreparacaoPrincipal = new object();

        //private int intPassoPadraoUploadTabelaInventarioBensPrincipal = 0;

        private void mtdRotinaThreadPreparacaoPrincipal()
        {
            while (true)
            {
                if (!blnAbortarThreadPreparacaoPrincipal)
                {
                    //System.Threading.Monitor.Enter(LockPreparacaoPrincipal);
                    lock (LockPreparacaoPrincipal)
                    {
                        try
                        {
                            mtdRotinaPreparacaoPrincipal();
                            mtdAbortarThreadPreparacaoPrincipal(true);
                        }
                        finally
                        {
                            //System.Threading.Monitor.Exit(LockPreparacaoPrincipal);
                        }
                    }
                }

                System.Threading.Thread.Sleep(1);
            }
        }

        private void mtdRotinaPreparacaoPrincipal()
        {
            Default.mtdCriarBancoDadosPrincipal();
            //Default.mtdRepararBancoDadosPrincipal();
            //Default.mtdCompactarBancoDadosPrincipal();

            mtdRotinaImportarDadosTabelaBensPrincipal();
            mtdRotinaImportarDadosTabelaEmpregadosPrincipal();
            mtdRotinaImportarDadosTabelaCentroCustoPrincipal();
            //mtdRotinaTransferirDadosTabelaInventarioBensPrincipal();
        }
    }
}