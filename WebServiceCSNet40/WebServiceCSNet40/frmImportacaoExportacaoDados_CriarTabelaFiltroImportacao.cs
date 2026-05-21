using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceCSNet40
{
    public partial class frmImportacaoExportacaoDados
    {
        private System.Threading.Thread ThCriarTabelaFiltroImportacao;

        private string strNomeProcessoCriarTabelaFiltroImportacao = "Criar Tabela de Usuários";
        internal void mtdIniciarThreadCriarTabelaFiltroImportacao()
        {
            mtdIniciarThreadCriarTabelaFiltroImportacao(true);
        }

        internal void mtdIniciarThreadCriarTabelaFiltroImportacao(bool Iniciar)
        {
            try
            {
                //intProgresso = 0
                //strNomeProcesso = strNomeProcessoCriarTabelaFiltroImportacao
                blnAbortarThreadCriarTabelaFiltroImportacao = !Iniciar;
                blnForcarAbortarThreadCriarTabelaFiltroImportacao = false;
                blnThreadAtivadaCriarTabelaFiltroImportacao = true;
                blnSucessoCriarTabelaFiltroImportacao = false;
                ThCriarTabelaFiltroImportacao = new System.Threading.Thread(new System.Threading.ThreadStart(mtdRotinaThreadCriarTabelaFiltroImportacao));
                ThCriarTabelaFiltroImportacao.IsBackground = true;
                ThCriarTabelaFiltroImportacao.Priority = System.Threading.ThreadPriority.Normal;
                ThCriarTabelaFiltroImportacao.Start();

            }
            catch (Exception ex)
            {
                string strExcecao = "mtdIniciarThreadCriarTabelaFiltroImportacao: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        internal void mtdReIniciarThreadCriarTabelaFiltroImportacao()
        {
            //intProgresso = 0
            //strNomeProcesso = strNomeProcessoCriarTabelaFiltroImportacao
            blnAbortarThreadCriarTabelaFiltroImportacao = false;
            blnForcarAbortarThreadCriarTabelaFiltroImportacao = false;

            blnThreadAtivadaCriarTabelaFiltroImportacao = true;
            blnSucessoCriarTabelaFiltroImportacao = false;
        }

        private static bool blnForcarAbortarThreadCriarTabelaFiltroImportacao = false;
        private static bool blnAbortarThreadCriarTabelaFiltroImportacao = false;

        private static int intTempoSaidaAbortarThreadCriarTabelaFiltroImportacao = 1000;
        internal void mtdAbortarThreadCriarTabelaFiltroImportacao()
        {
            mtdAbortarThreadCriarTabelaFiltroImportacao(false);
        }

        internal void mtdAbortarThreadCriarTabelaFiltroImportacao(bool Forcar)
        {
            //intProgresso = 100
            System.Threading.Thread.Sleep(1);
            //intProgresso = 0
            //strNomeProcesso = strNomeProcessoCriarTabelaFiltroImportacao
            blnAbortarThreadCriarTabelaFiltroImportacao = true;
            blnForcarAbortarThreadCriarTabelaFiltroImportacao = Forcar;

            blnThreadAtivadaCriarTabelaFiltroImportacao = false;
            blnSucessoCriarTabelaFiltroImportacao = false;

            try
            {
                ThCriarTabelaFiltroImportacao.Join(intTempoSaidaAbortarThreadCriarTabelaFiltroImportacao);
                ThCriarTabelaFiltroImportacao.Abort();
                ThCriarTabelaFiltroImportacao = null;
            }
            catch (Exception ex)
            {
                string strExcecao = "mtdAbortarThreadCriarTabelaFiltroImportacao: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        internal void mtdPararThreadCriarTabelaFiltroImportacao()
        {
            //intProgresso = 100
            System.Threading.Thread.Sleep(1);
            //intProgresso = 0
            //strNomeProcesso = strNomeProcessoCriarTabelaFiltroImportacao
            blnAbortarThreadCriarTabelaFiltroImportacao = true;
            blnForcarAbortarThreadCriarTabelaFiltroImportacao = true;

            blnThreadAtivadaCriarTabelaFiltroImportacao = false;
            blnSucessoCriarTabelaFiltroImportacao = false;
        }


        private static object LockerCriarTabelaFiltroImportacao = new object();
        private void mtdRotinaThreadCriarTabelaFiltroImportacao()
        {
            while (true)
            {
                if (!blnAbortarThreadCriarTabelaFiltroImportacao)
                {
                    //System.Threading.Monitor.Enter(LockerCriarTabelaFiltroImportacao);
                    lock (LockerCriarTabelaFiltroImportacao)
                    {
                        try
                        {
                            mtdGerarTabelaFiltroImportacao();
                            mtdAbortarThreadCriarTabelaFiltroImportacao(true);
                        }
                        finally
                        {
                            //System.Threading.Monitor.Exit(LockerCriarTabelaFiltroImportacao);
                        }
                    }
                }

                System.Threading.Thread.Sleep(1);
            }
        }

        internal bool blnThreadAtivadaCriarTabelaFiltroImportacao = false;

        internal bool blnSucessoCriarTabelaFiltroImportacao = false;

        private long lngCodigoCriarTabelaFiltroImportacao = 0;
        protected internal void mtdGerarTabelaFiltroImportacao()
        {
            //mtdDeletarTabelaFiltroImportacao()
            //mtdDeletarDadosTabelaFiltroImportacao()
            mtdCriarTabelaFiltroImportacao();
            mtdInserirDadosTabelaFiltroImportacao();
        }


        private int intcolunaFiltroImportacao = 0;

        private string[][] camposFiltroImportacao;
        public void mtdDeletarTabelaFiltroImportacao()
        {
            string BancoDados = "Principal";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

            objImplementacaoBancoDados.mtdDeletarTabela(strTabelasAuxiliaresFiltroImportacaoPrincipal);
            objImplementacaoBancoDados.Dispose();
        }

        public void mtdDeletarDadosTabelaFiltroImportacao()
        {
            string BancoDados = "Principal";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

            objImplementacaoBancoDados.mtdDeletarDados(strTabelasAuxiliaresFiltroImportacaoPrincipal, strColunaFiltroImportacaoPrincipal, "LIKE", "'%'");
            objImplementacaoBancoDados.Dispose();
        }

        public void mtdCriarTabelaFiltroImportacao()
        {
            string BancoDados = "Principal";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

            string[][] campos = new string[1][];
            campos[0] = new string[4] 
            {
                strColunaFiltroImportacaoPrincipal,
                "TEXT",
                "255",
                "CONSTRAINT primarykeyFiltroImportacao PRIMARY KEY"
            };
            objImplementacaoBancoDados.mtdCriarTabela(strTabelasAuxiliaresFiltroImportacaoPrincipal, campos);

            objImplementacaoBancoDados.Dispose();
        }

        private string strFiltroImportacaoPadrao = "'|4000'";

        public void mtdInserirDadosTabelaFiltroImportacao()
        {
            string BancoDados = "Principal";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

            objImplementacaoBancoDados.mtdAbrirConexao();
            objImplementacaoBancoDados.mtdExecutarComando(string.Format("SELECT * FROM {0};", strTabelasAuxiliaresFiltroImportacaoPrincipal));
            objImplementacaoBancoDados.mtdDefinirLeitorDados();
            objImplementacaoBancoDados.mtdProximoRegistro();

            string[][] dados = new string[2][];
            dados[0] = objImplementacaoBancoDados.mtdObterCabecalhoColunas();
            dados[1] = new string[1] { strFiltroImportacaoPadrao };
            objImplementacaoBancoDados.mtdInserirDados(strTabelasAuxiliaresFiltroImportacaoPrincipal, dados);

            objImplementacaoBancoDados.Dispose();
        }

    }
}