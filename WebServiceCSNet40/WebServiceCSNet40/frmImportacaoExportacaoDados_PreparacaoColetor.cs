using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceCSNet40
{
    public partial class frmImportacaoExportacaoDados
    {
        private System.Threading.Thread ThreadPreparacaoColetorDados;

        private string strNomeProcessoPreparacaoColetorDados = "Preparação do Coletor de Dados";

        private void mtdIniciarThreadPreparacaoColetorDados()
        {
            mtdIniciarThreadPreparacaoColetorDados(true);
        }

        private void mtdIniciarThreadPreparacaoColetorDados(bool Iniciar)
        {
            try
            {
                intProgresso = 0;
                strNomeProcesso = strNomeProcessoPreparacaoColetorDados;
                blnAbortarThreadPreparacaoColetorDados = !Iniciar;
                blnForcarAbortarThreadPreparacaoColetorDados = false;
                ThreadPreparacaoColetorDados = new System.Threading.Thread
                    (
                    new System.Threading.ThreadStart
                        (
                        mtdRotinaThreadPreparacaoColetorDados
                        )
                    );
                ThreadPreparacaoColetorDados.IsBackground = true;
                ThreadPreparacaoColetorDados.Priority = System.Threading.ThreadPriority.Normal;
                ThreadPreparacaoColetorDados.Start();
            }
            catch (Exception ex)
            {
                string strExcecao = "mtdIniciarThreadPreparacaoColetorDados: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao); 
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        private void mtdReIniciarThreadPreparacaoColetorDados()
        {
            intProgresso = 0;
            strNomeProcesso = strNomeProcessoPreparacaoColetorDados;
            blnAbortarThreadPreparacaoColetorDados = false;
            blnForcarAbortarThreadPreparacaoColetorDados = false;
        }

        private static bool blnForcarAbortarThreadPreparacaoColetorDados = false;
        private static bool blnAbortarThreadPreparacaoColetorDados = false;
        private static int intTempoSaidaAbortarThreadPreparacaoColetorDados = 1000;

        private void mtdAbortarThreadPreparacaoColetorDados()
        {
            mtdAbortarThreadPreparacaoColetorDados(false);
        }

        private void mtdAbortarThreadPreparacaoColetorDados(bool Forcar)
        {
            intProgresso = 100;
            System.Threading.Thread.Sleep(1000);
            intProgresso = 0;
            strNomeProcesso = strNomeProcessoPreparacaoColetorDados;
            blnAbortarThreadPreparacaoColetorDados = true;
            blnForcarAbortarThreadPreparacaoColetorDados = Forcar;

            try
            {
                mtdAbortarThreadImportarDadosTabelaBensColetor(Forcar);
                mtdAbortarThreadImportarDadosTabelaEmpregadosColetor(Forcar);
                mtdAbortarThreadTransferirDadosTabelaInventarioBensColetor(Forcar);

                ThreadPreparacaoColetorDados.Join(intTempoSaidaAbortarThreadPreparacaoColetorDados);
                ThreadPreparacaoColetorDados.Abort();
                ThreadPreparacaoColetorDados = null;
            }
            catch (Exception ex)
            {
                string strExcecao = "mtdAbortarThreadPreparacaoColetorDados: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao); 
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        private void mtdPararThreadPreparacaoColetorDados()
        {
            intProgresso = 100;
            System.Threading.Thread.Sleep(1000);
            intProgresso = 0;
            strNomeProcesso = strNomeProcessoPreparacaoColetorDados;
            blnAbortarThreadPreparacaoColetorDados = true;
            blnForcarAbortarThreadPreparacaoColetorDados = true;
        }

        private static object LockPreparacaoColetorDados = new object();

        //private int intPassoPadraoUploadTabelaInventarioBensColetor = 0;

        private void mtdRotinaThreadPreparacaoColetorDados()
        {
            while (true)
            {
                if (!blnAbortarThreadPreparacaoColetorDados)
                {
                    //System.Threading.Monitor.Enter(LockPreparacaoColetorDados);
                    lock (LockPreparacaoColetorDados)
                    {
                        try
                        {
                            mtdRotinaPreparacaoColetorDados();
                            mtdAbortarThreadPreparacaoColetorDados(true);
                        }
                        finally
                        {
                            //System.Threading.Monitor.Exit(LockPreparacaoColetorDados);
                        }
                    }
                }

                System.Threading.Thread.Sleep(1);
            }
        }

        private void mtdRotinaPreparacaoColetorDados()
        {
            Default.mtdCriarBancoDadosColetor();
            Default.mtdRepararBancoDadosColetor();
            Default.mtdCompactarBancoDadosColetor();

            mtdRotinaImportarDadosTabelaBensColetor();
            mtdRotinaImportarDadosTabelaEmpregadosColetor();
            mtdRotinaImportarDadosTabelaCentroCustoColetor();
            mtdRotinaTransferirDadosTabelaInventarioBensColetor();
        }
    }
}