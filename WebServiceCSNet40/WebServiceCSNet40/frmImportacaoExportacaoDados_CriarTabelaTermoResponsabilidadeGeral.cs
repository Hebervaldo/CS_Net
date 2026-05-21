using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceCSNet40
{
    public partial class frmImportacaoExportacaoDados
    {
        private System.Threading.Thread ThCriarTabelaTermoResponsabilidadeGeral;

        private string strNomeProcessoCriarTabelaTermoResponsabilidadeGeral = "Criar Tabela de Usuários";
        internal void mtdIniciarThreadCriarTabelaTermoResponsabilidadeGeral()
        {
            mtdIniciarThreadCriarTabelaTermoResponsabilidadeGeral(true);
        }

        internal void mtdIniciarThreadCriarTabelaTermoResponsabilidadeGeral(bool Iniciar)
        {
            try
            {
                //intProgresso = 0
                //strNomeProcesso = strNomeProcessoCriarTabelaTermoResponsabilidadeGeral
                blnAbortarThreadCriarTabelaTermoResponsabilidadeGeral = !Iniciar;
                blnForcarAbortarThreadCriarTabelaTermoResponsabilidadeGeral = false;
                blnThreadAtivadaCriarTabelaTermoResponsabilidadeGeral = true;
                blnSucessoCriarTabelaTermoResponsabilidadeGeral = false;
                ThCriarTabelaTermoResponsabilidadeGeral = new System.Threading.Thread(new System.Threading.ThreadStart(mtdRotinaThreadCriarTabelaTermoResponsabilidadeGeral));
                ThCriarTabelaTermoResponsabilidadeGeral.IsBackground = true;
                ThCriarTabelaTermoResponsabilidadeGeral.Priority = System.Threading.ThreadPriority.Normal;
                ThCriarTabelaTermoResponsabilidadeGeral.Start();

            }
            catch (Exception ex)
            {
                string strExcecao = "mtdIniciarThreadCriarTabelaTermoResponsabilidadeGeral: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        internal void mtdReIniciarThreadCriarTabelaTermoResponsabilidadeGeral()
        {
            //intProgresso = 0
            //strNomeProcesso = strNomeProcessoCriarTabelaTermoResponsabilidadeGeral
            blnAbortarThreadCriarTabelaTermoResponsabilidadeGeral = false;
            blnForcarAbortarThreadCriarTabelaTermoResponsabilidadeGeral = false;

            blnThreadAtivadaCriarTabelaTermoResponsabilidadeGeral = true;
            blnSucessoCriarTabelaTermoResponsabilidadeGeral = false;
        }

        private static bool blnForcarAbortarThreadCriarTabelaTermoResponsabilidadeGeral = false;
        private static bool blnAbortarThreadCriarTabelaTermoResponsabilidadeGeral = false;

        private static int intTempoSaidaAbortarThreadCriarTabelaTermoResponsabilidadeGeral = 1000;
        internal void mtdAbortarThreadCriarTabelaTermoResponsabilidadeGeral()
        {
            mtdAbortarThreadCriarTabelaTermoResponsabilidadeGeral(false);
        }

        internal void mtdAbortarThreadCriarTabelaTermoResponsabilidadeGeral(bool Forcar)
        {
            //intProgresso = 100
            System.Threading.Thread.Sleep(1);
            //intProgresso = 0
            //strNomeProcesso = strNomeProcessoCriarTabelaTermoResponsabilidadeGeral
            blnAbortarThreadCriarTabelaTermoResponsabilidadeGeral = true;
            blnForcarAbortarThreadCriarTabelaTermoResponsabilidadeGeral = Forcar;

            blnThreadAtivadaCriarTabelaTermoResponsabilidadeGeral = false;
            blnSucessoCriarTabelaTermoResponsabilidadeGeral = false;

            try
            {
                ThCriarTabelaTermoResponsabilidadeGeral.Join(intTempoSaidaAbortarThreadCriarTabelaTermoResponsabilidadeGeral);
                ThCriarTabelaTermoResponsabilidadeGeral.Abort();
                ThCriarTabelaTermoResponsabilidadeGeral = null;
            }
            catch (Exception ex)
            {
                string strExcecao = "mtdAbortarThreadCriarTabelaTermoResponsabilidadeGeral: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        internal void mtdPararThreadCriarTabelaTermoResponsabilidadeGeral()
        {
            //intProgresso = 100
            System.Threading.Thread.Sleep(1);
            //intProgresso = 0
            //strNomeProcesso = strNomeProcessoCriarTabelaTermoResponsabilidadeGeral
            blnAbortarThreadCriarTabelaTermoResponsabilidadeGeral = true;
            blnForcarAbortarThreadCriarTabelaTermoResponsabilidadeGeral = true;

            blnThreadAtivadaCriarTabelaTermoResponsabilidadeGeral = false;
            blnSucessoCriarTabelaTermoResponsabilidadeGeral = false;
        }


        private static object LockerCriarTabelaTermoResponsabilidadeGeral = new object();
        private void mtdRotinaThreadCriarTabelaTermoResponsabilidadeGeral()
        {
            while (true)
            {
                if (!blnAbortarThreadCriarTabelaTermoResponsabilidadeGeral)
                {
                    //System.Threading.Monitor.Enter(LockerCriarTabelaTermoResponsabilidadeGeral);
                    lock (LockerCriarTabelaTermoResponsabilidadeGeral)
                    {
                        try
                        {
                            mtdGerarTabelaTermoResponsabilidadeGeral();
                            mtdAbortarThreadCriarTabelaTermoResponsabilidadeGeral(true);
                        }
                        finally
                        {
                            //System.Threading.Monitor.Exit(LockerCriarTabelaTermoResponsabilidadeGeral);
                        }
                    }
                }

                System.Threading.Thread.Sleep(1);
            }
        }

        internal bool blnThreadAtivadaCriarTabelaTermoResponsabilidadeGeral = false;

        internal bool blnSucessoCriarTabelaTermoResponsabilidadeGeral = false;

        private long lngCodigoCriarTabelaTermoResponsabilidadeGeral = 0;
        protected internal void mtdGerarTabelaTermoResponsabilidadeGeral()
        {
            //mtdDeletarTabelaTermoResponsabilidadeGeral()
            //mtdDeletarDadosTabelaTermoResponsabilidadeGeral()
            mtdCriarTabelaTermoResponsabilidadeGeral();
            mtdInserirDadosTabelaTermoResponsabilidadeGeral();
        }


        private int intcolunaTermoResponsabilidadeGeral = 0;

        private string[][] camposTermoResponsabilidadeGeral;
        public void mtdDeletarTabelaTermoResponsabilidadeGeral()
        {
            string BancoDados = "Principal";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

            objImplementacaoBancoDados.mtdDeletarTabela(strTabelaAuxiliaresTermoResponsabilidadeGeralPrincipal);
            objImplementacaoBancoDados.Dispose();
        }

        public void mtdDeletarDadosTabelaTermoResponsabilidadeGeral()
        {
            string BancoDados = "Principal";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

            objImplementacaoBancoDados.mtdDeletarDados(strTabelaAuxiliaresTermoResponsabilidadeGeralPrincipal, strColunaFiltroImportacaoPrincipal, "LIKE", "'%'");
            objImplementacaoBancoDados.Dispose();
        }

        public void mtdCriarTabelaTermoResponsabilidadeGeral()
        {
            string BancoDados = "Principal";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);
            string[][] campos = new string[1][];
            campos[0] = new string[4]
            {
                strColunaTermoResponsabilidadeGeralPrincipal,
                "TEXT",
                "255",
                "CONSTRAINT primarykeyTermoResponsabilidadeGeral PRIMARY KEY"
                };
            objImplementacaoBancoDados.mtdCriarTabela(strTabelaAuxiliaresTermoResponsabilidadeGeralPrincipal, campos);
            objImplementacaoBancoDados.Dispose();
        }

        private string strTermoResponsabilidadeGeralPadrao = "0033";

        public void mtdInserirDadosTabelaTermoResponsabilidadeGeral()
        {
            string BancoDados = "Principal";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

            objImplementacaoBancoDados.mtdAbrirConexao();
            objImplementacaoBancoDados.mtdExecutarComando(string.Format("SELECT * FROM {0};", strTabelaAuxiliaresTermoResponsabilidadeGeralPrincipal));
            objImplementacaoBancoDados.mtdDefinirLeitorDados();
            objImplementacaoBancoDados.mtdProximoRegistro();

            string[][] dados = new string[2][];
            dados[0] = objImplementacaoBancoDados.mtdObterCabecalhoColunas();
            dados[1] = new string[1] { strTermoResponsabilidadeGeralPadrao };
            objImplementacaoBancoDados.mtdInserirDados(strTabelaAuxiliaresTermoResponsabilidadeGeralPrincipal, dados);

            objImplementacaoBancoDados.Dispose();
        }

    }
}