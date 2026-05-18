using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace prjColetorDadosCSNet35
{
    public partial class frmMonitorCarregamentoDados
    {
        private bool blnAbortarThreadThMonitorarWebService = false;

        private System.Threading.Thread ThMonitorarWebService;

        private void mtdIniciarThreadNotificacao()
        {
            blnAbortarThreadThMonitorarWebService = false;

            ThMonitorarWebService = new System.Threading.Thread(new System.Threading.ThreadStart(this.mtdRotinaMonitorarWebService));
            ThMonitorarWebService.IsBackground = true;
            ThMonitorarWebService.Priority = System.Threading.ThreadPriority.Lowest;
            ThMonitorarWebService.Start();
        }

        private void mtdAbortarThreadThMonitorarWebService()
        {
            try
            {
                blnAbortarThreadThMonitorarWebService = true;
                ThMonitorarWebService.Abort();
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdAbortarThreadThMonitorarWebService: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private int intTempoEspera = 5000;

        private void mtdRotinaMonitorarWebService()
        {
            while (!blnAbortarThreadThMonitorarWebService)
            {
                try
                {
                    strIP = frmPrincipal.mtdObterIpLocal();

                    intObterLinhaTabelaInventarioBens = wb.mtdObterLinhaTabelaInventarioBens(intNumeroIdentificacao);
                    intObterLinhaTotalTabelaInventarioBens = wb.mtdObterLinhaTotalTabelaInventarioBens(intNumeroIdentificacao);
                    intObterLinhaAcumuladoTotalTabelaInventarioBens = wb.mtdObterLinhaAcumuladoTotalTabelaInventarioBens(intNumeroIdentificacao);
                    intObterNumeroItensInseridos = wb.mtdObterNumeroItensInseridos(intNumeroIdentificacao);
                    intObterNumeroItensAtualizados = wb.mtdObterNumeroItensAtualizados(intNumeroIdentificacao);
                    intObterNumeroItensInalterados = wb.mtdObterNumeroItensInalterados(intNumeroIdentificacao);

                    try
                    {
                        //wb.Abort();
                    }
                    catch (System.Exception ex)
                    {
                        string strExcecao = "mtdRotinaMonitorarWebService: " + ex.Message;
                        System.Diagnostics.Debug.WriteLine(strExcecao);
                        //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                    }
                    
                    mtdObterNumeroIdentificacao();
                }
                catch (System.Exception ex)
                {
                    string strExcecao = "mtdRotinaMonitorarWebService: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                    //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                }

                System.Threading.Thread.Sleep(intTempoEspera);
            }
        }
    }
}