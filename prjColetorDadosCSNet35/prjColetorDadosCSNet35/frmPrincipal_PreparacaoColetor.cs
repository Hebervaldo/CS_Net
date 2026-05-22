using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace prjColetorDadosCSNet35
{
    public partial class frmPrincipal
    {
        private System.Threading.Thread ThPreparacaoColetor;
        
        private void mtdIniciarThreadPreparacaoColetor()
        {
            ThPreparacaoColetor = new System.Threading.Thread
                (
                new System.Threading.ThreadStart
                    (
                    this.mtdRotinaPreparacaoColetor
                    )
                );
            ThPreparacaoColetor.IsBackground = true;
            ThPreparacaoColetor.Priority = System.Threading.ThreadPriority.BelowNormal;
            ThPreparacaoColetor.Start();
        }

        private void mtdAbortarThreadPreparacaoColetor()
        {
            try
            {
                ThPreparacaoColetor.Abort();
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdAbortarThreadPreparacaoColetor: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private static object LockerRotinaPreparacaoColetor = new object();

        private void mtdRotinaPreparacaoColetor()
        {
            mtdRotinaPreparacaoColetor(true);
        }

        //private int intTempoEspera = 10000;

        private void mtdRotinaPreparacaoColetor(bool AjustarDataTempoSistema)
        {
            lock (LockerRotinaPreparacaoColetor)
            {
                clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                    (
                    clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                    );

                objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                    (
                    clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                    strBaseDadosColetor,
                    strSenhaColetor
                    );

                if (!objImplementacaoBancoDados.mtdAbrirConexao())
                {
                    mtdCriarBancoDadosColetor();
                    blnReparado = mtdRepararBancoDadosColetor();
                    blnCompactado = mtdCompactarBancoDadosColetor();
                }

                mtdCriarTabelaBensEletronorteColetor();
                mtdCriarTabelaCentroCustoColetor();
                mtdCriarTabelaEmpregadosColetor();
                mtdCriarTabelaInventarioBensColetor();

                objMonitorCarregamentoDados.mtdEnderecoWebService(true);
                objMonitorCarregamentoDados.mtdObterNumeroIdentificacao();

                clsDataTempoSistema.mtdAjustarDataTempoSistema(objMonitorCarregamentoDados.wb.Url);

                objImplementacaoBancoDados.Dispose();

                mtdAbortarThreadPreparacaoColetor();

                //System.Threading.Thread.Sleep(intTempoEspera);
            }
        }
    }
}
