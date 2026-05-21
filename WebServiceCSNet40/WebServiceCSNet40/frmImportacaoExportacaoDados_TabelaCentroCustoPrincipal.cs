using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceCSNet40
{
    public partial class frmImportacaoExportacaoDados
    {
        private System.Threading.Thread ThreadImportarDadosTabelaCentroCustoPrincipal;

        private string strNomeProcessoImportarDadosTabelaCentroCustoPrincipal = "Importação de dados - Centro de Custo - Principal";

        public void mtdIniciarThreadDownloadTabelaInventarioCentroCustoPrincipal()
        {
            mtdIniciarThreadDownloadTabelaInventarioCentroCustoPrincipal(true);
        }

        public void mtdIniciarThreadDownloadTabelaInventarioCentroCustoPrincipal(bool Iniciar)
        {
            try
            {
                intProgresso = 0;
                strNomeProcesso = strNomeProcessoImportarDadosTabelaCentroCustoPrincipal;
                blnAbortarThreadImportarDadosTabelaBensPrincipal = !Iniciar;
                blnForcarAbortarThreadImportarDadosTabelaBensPrincipal = false;
                blnAbortarThreadImportarDadosTabelaCentroCustoPrincipal = !Iniciar;
                blnForcarAbortarThreadImportarDadosTabelaCentroCustoPrincipal = false;
                ThreadImportarDadosTabelaCentroCustoPrincipal = new System.Threading.Thread
                    (
                    new System.Threading.ThreadStart
                        (
                        mtdRotinaThreadImportarDadosTabelaCentroCustoPrincipal
                        )
                    );
                ThreadImportarDadosTabelaCentroCustoPrincipal.IsBackground = true;
                ThreadImportarDadosTabelaCentroCustoPrincipal.Priority = System.Threading.ThreadPriority.Normal;
                ThreadImportarDadosTabelaCentroCustoPrincipal.Start();
            }
            catch (Exception ex)
            {
                string strExcecao = "mtdIniciarThreadDownloadTabelaInventarioCentroCustoPrincipal: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        public void mtdReIniciarThreadDownloadTabelaInventarioCentroCustoPrincipal()
        {
            intProgresso = 0;
            strNomeProcesso = strNomeProcessoImportarDadosTabelaCentroCustoPrincipal;
            blnAbortarThreadImportarDadosTabelaBensPrincipal = false;
            blnForcarAbortarThreadImportarDadosTabelaBensPrincipal = false;
            blnAbortarThreadImportarDadosTabelaCentroCustoPrincipal = false;
            blnForcarAbortarThreadImportarDadosTabelaCentroCustoPrincipal = false;
        }

        private static bool blnForcarAbortarThreadImportarDadosTabelaCentroCustoPrincipal = false;
        private static bool blnAbortarThreadImportarDadosTabelaCentroCustoPrincipal = false;
        private static int intTempoSaidaAbortarThreadImportarDadosTabelaCentroCustoPrincipal = 1000;

        public void mtdAbortarThreadImportarDadosTabelaCentroCustoPrincipal()
        {
            mtdAbortarThreadImportarDadosTabelaCentroCustoPrincipal(false);
        }

        public void mtdAbortarThreadImportarDadosTabelaCentroCustoPrincipal(bool Forcar)
        {
            intProgresso = 100;
            System.Threading.Thread.Sleep(1000);
            intProgresso = 0;
            strNomeProcesso = strNomeProcessoImportarDadosTabelaCentroCustoPrincipal;
            blnAbortarThreadImportarDadosTabelaBensPrincipal = true;
            blnForcarAbortarThreadImportarDadosTabelaBensPrincipal = Forcar;
            blnAbortarThreadImportarDadosTabelaCentroCustoPrincipal = true;
            blnForcarAbortarThreadImportarDadosTabelaCentroCustoPrincipal = Forcar;

            try
            {
                ThreadImportarDadosTabelaCentroCustoPrincipal.Join(intTempoSaidaAbortarThreadImportarDadosTabelaCentroCustoPrincipal);
                ThreadImportarDadosTabelaCentroCustoPrincipal.Abort();
                ThreadImportarDadosTabelaCentroCustoPrincipal = null;
            }
            catch (Exception ex)
            {
                string strExcecao = "mtdAbortarThreadImportarDadosTabelaCentroCustoPrincipal: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        public void mtdPararThreadDownloadTabelaInventarioCentroCustoPrincipal()
        {
            intProgresso = 100;
            System.Threading.Thread.Sleep(1000);
            intProgresso = 0;
            strNomeProcesso = strNomeProcessoImportarDadosTabelaCentroCustoPrincipal;
            blnAbortarThreadImportarDadosTabelaBensPrincipal = true;
            blnForcarAbortarThreadImportarDadosTabelaBensPrincipal = true;
            blnAbortarThreadImportarDadosTabelaCentroCustoPrincipal = true;
            blnForcarAbortarThreadImportarDadosTabelaCentroCustoPrincipal = true;
        }

        private static object LockImportarDadosTabelaCentroCustoPrincipal = new object();

        private void mtdRotinaThreadImportarDadosTabelaCentroCustoPrincipal()
        {
            while (true)
            {
                if (!blnAbortarThreadImportarDadosTabelaBensPrincipal & !blnAbortarThreadImportarDadosTabelaCentroCustoPrincipal)
                {
                    //System.Threading.Monitor.Enter(LockImportarDadosTabelaCentroCustoPrincipal);
                    lock (LockImportarDadosTabelaCentroCustoPrincipal)
                    {
                        try
                        {
                            mtdRotinaImportarDadosTabelaCentroCustoPrincipal
                                (
                                blnComandoImplementadoDeletarDadosTabelaCentroCustoPrincipal,
                                blnComandoImplementadoInserirDadosTabelaCentroCustoPrincipal
                                );
                            mtdAbortarThreadImportarDadosTabelaCentroCustoPrincipal(true);
                        }
                        finally
                        {
                            //System.Threading.Monitor.Exit(LockImportarDadosTabelaCentroCustoPrincipal);
                        }
                    }
                }

                System.Threading.Thread.Sleep(1);
            }
        }

        private void mtdRotinaImportarDadosTabelaCentroCustoPrincipal()
        {
            mtdRotinaImportarDadosTabelaCentroCustoPrincipal(true, true);
        }

        private void mtdRotinaImportarDadosTabelaCentroCustoPrincipal(bool Deletar, bool Inserir)
        {
            if (blnAbortarThreadImportarDadosTabelaBensPrincipal && blnForcarAbortarThreadImportarDadosTabelaBensPrincipal) return;
            if (blnAbortarThreadImportarDadosTabelaCentroCustoPrincipal && blnForcarAbortarThreadImportarDadosTabelaCentroCustoPrincipal) return;
            if (blnAbortarThreadPreparacaoPrincipal && blnForcarAbortarThreadPreparacaoPrincipal) return;

            if (Deletar)
            {
                mtdDeletarTabelaCentroCustoPrincipal();
                mtdDeletarDadosTabelaCentroCustoPrincipal();
            }
            mtdCriarTabelaCentroCustoPrincipal();
            if (Inserir)
            {
                mtdInserirDadosTabelaCentroCustoPrincipal();
            }
        }

        public bool blnComandoImplementadoDeletarDadosTabelaCentroCustoPrincipal = true;

        public void mtdDeletarTabelaCentroCustoPrincipal()
        {
            if (blnAbortarThreadImportarDadosTabelaBensPrincipal && blnForcarAbortarThreadImportarDadosTabelaBensPrincipal) return;
            if (blnAbortarThreadImportarDadosTabelaCentroCustoPrincipal && blnForcarAbortarThreadImportarDadosTabelaCentroCustoPrincipal) return;
            if (blnAbortarThreadPreparacaoPrincipal && blnForcarAbortarThreadPreparacaoPrincipal) return;

            string BancoDados = "Principal";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

            objImplementacaoBancoDados.mtdDeletarTabela(Default.strTabelaCentroCusto);
            objImplementacaoBancoDados.Dispose();
        }

        public void mtdDeletarDadosTabelaCentroCustoPrincipal()
        {
            if (blnAbortarThreadImportarDadosTabelaBensPrincipal && blnForcarAbortarThreadImportarDadosTabelaBensPrincipal) return;
            if (blnAbortarThreadImportarDadosTabelaCentroCustoPrincipal && blnForcarAbortarThreadImportarDadosTabelaCentroCustoPrincipal) return;
            if (blnAbortarThreadPreparacaoPrincipal && blnForcarAbortarThreadPreparacaoPrincipal) return;

            string BancoDados = "Principal";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

            objImplementacaoBancoDados.mtdDeletarDados(Default.strTabelaCentroCusto, strColunaPrincipal, "LIKE", "'%'");
            objImplementacaoBancoDados.Dispose();
        }

        private string[][] camposTabelaCentroCustoPrincipal;

        public void mtdCriarTabelaCentroCustoPrincipal()
        {
            if (blnAbortarThreadImportarDadosTabelaBensPrincipal && blnForcarAbortarThreadImportarDadosTabelaBensPrincipal) return;
            if (blnAbortarThreadImportarDadosTabelaCentroCustoPrincipal && blnForcarAbortarThreadImportarDadosTabelaCentroCustoPrincipal) return;
            if (blnAbortarThreadPreparacaoPrincipal && blnForcarAbortarThreadPreparacaoPrincipal) return;

            string BancoDados = "Principal";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

            intcolunaTabelaCentroCusto = 3;

            camposTabelaCentroCustoPrincipal = new string[intcolunaTabelaCentroCusto][];
            camposTabelaCentroCustoPrincipal[0] = new string[] { "CentroCusto", "INTEGER", string.Empty, "CONSTRAINT PrimaryKeyCentroCusto PRIMARY KEY" };
            camposTabelaCentroCustoPrincipal[1] = new string[] { "Orgao", "TEXT", "255", string.Empty };
            camposTabelaCentroCustoPrincipal[2] = new string[] { "OrgaoDescricao", "TEXT", "255", string.Empty };

            objImplementacaoBancoDados.mtdCriarTabela(Default.strTabelaCentroCusto, camposTabelaCentroCustoPrincipal);
            objImplementacaoBancoDados.Dispose();
        }

        public bool blnComandoImplementadoInserirDadosTabelaCentroCustoPrincipal = true;

        public void mtdInserirDadosTabelaCentroCustoPrincipal()
        {
            if (blnAbortarThreadImportarDadosTabelaBensPrincipal && blnForcarAbortarThreadImportarDadosTabelaBensPrincipal) return;
            if (blnAbortarThreadImportarDadosTabelaCentroCustoPrincipal && blnForcarAbortarThreadImportarDadosTabelaCentroCustoPrincipal) return;
            if (blnAbortarThreadPreparacaoPrincipal && blnForcarAbortarThreadPreparacaoPrincipal) return;

            string BancoDados = "Principal";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);
            clsImplementacaoBancoDados objImplementacaoBancoDadosI = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

            string[][] dados = new string[2][];
            dados[0] = new string[intcolunaTabelaCentroCusto];

            for (int contador = 0; contador <= intcolunaTabelaCentroCusto - 1; contador++)
            {
                if (blnAbortarThreadImportarDadosTabelaBensPrincipal && blnForcarAbortarThreadImportarDadosTabelaBensPrincipal) return;
                if (blnAbortarThreadImportarDadosTabelaCentroCustoPrincipal && blnForcarAbortarThreadImportarDadosTabelaCentroCustoPrincipal) return;
                if (blnAbortarThreadPreparacaoPrincipal && blnForcarAbortarThreadPreparacaoPrincipal) return;

                dados[0][contador] = camposTabelaCentroCustoPrincipal[contador][0];
            }

            intProgresso = 0;
            strNomeProcesso = strNomeProcessoImportarDadosTabelaCentroCustoPrincipal;

            objImplementacaoBancoDados.mtdAbrirConexao();
            objImplementacaoBancoDados.mtdExecutarComando
                (
                string.Format
                (
                "SELECT DISTINCT {0} FROM {1}",
                "Centro_Custo, Orgao",
                Default.strTabelaBensEletronorte
                )
                );

            intNumeroLinhasPrincipal = objImplementacaoBancoDados.mtdNumeroLinhas();
            objImplementacaoBancoDados.mtdDefinirLeitorDados();
            intNumeroColunasPrincipal = intcolunaTabelaCentroCusto;
            objImplementacaoBancoDados.mtdProximoRegistro();
            vetTipoColunasPrincipal = objImplementacaoBancoDados.mtdObterTipoRegistro();

            string[] dadosI = new string[intcolunaTabelaCentroCusto];

            for (int linha = 0; linha <= intNumeroLinhasPrincipal - 1; linha++)
            {
                if (blnAbortarThreadImportarDadosTabelaBensPrincipal && blnForcarAbortarThreadImportarDadosTabelaBensPrincipal) return;
                if (blnAbortarThreadImportarDadosTabelaCentroCustoPrincipal && blnForcarAbortarThreadImportarDadosTabelaCentroCustoPrincipal) return;
                if (blnAbortarThreadPreparacaoPrincipal && blnForcarAbortarThreadPreparacaoPrincipal) return;

                // dados(linha) = New String(intNumeroColunasPrincipal) {}
                for (int coluna = 0; coluna <= intcolunaTabelaCentroCusto - 2; coluna++)
                {
                    if (blnAbortarThreadImportarDadosTabelaBensPrincipal && blnForcarAbortarThreadImportarDadosTabelaBensPrincipal) return;
                    if (blnAbortarThreadImportarDadosTabelaCentroCustoPrincipal && blnForcarAbortarThreadImportarDadosTabelaCentroCustoPrincipal) return;
                    if (blnAbortarThreadPreparacaoPrincipal && blnForcarAbortarThreadPreparacaoPrincipal) return;

                    string strFormatoRegistro = mtdObterFormatoTipo(vetTipoColunasPrincipal[coluna]);
                    string strValorRegistro = objManipuladorTexto.mtdExecutarTudo
                         (
                         objImplementacaoBancoDados.mtdObterValorRegistro(coluna) != null ?
                         objImplementacaoBancoDados.mtdObterValorRegistro(coluna).ToString() :
                         string.Empty);

                    dadosI[coluna] = string.Format(strFormatoRegistro, strValorRegistro);
                }
                dados[1] = new string[intcolunaTabelaCentroCusto];

                for (int coluna = 0; coluna <= intNumeroColunasPrincipal - 1; coluna++)
                {
                    if (blnAbortarThreadImportarDadosTabelaBensPrincipal && blnForcarAbortarThreadImportarDadosTabelaBensPrincipal) return;
                    if (blnAbortarThreadImportarDadosTabelaCentroCustoPrincipal && blnForcarAbortarThreadImportarDadosTabelaCentroCustoPrincipal) return;
                    if (blnAbortarThreadPreparacaoPrincipal && blnForcarAbortarThreadPreparacaoPrincipal) return;

                    switch (coluna)
                    {
                        case 0:
                            dados[1][coluna] = dadosI[0];
                            break;
                        case 1:
                            dados[1][coluna] = string.Format("'{0}'", dadosI[1].Split(' ')[0].Replace("'", ""));
                            break;
                        case 2:
                            dados[1][coluna] = dadosI[1];
                            break;
                    }
                }
                objImplementacaoBancoDadosI.mtdInserirDados(Default.strTabelaCentroCusto, dados);
                objImplementacaoBancoDados.mtdProximoRegistro();

                intProgresso = mtdProgresso(linha, intNumeroLinhasPrincipal);
                strNomeProcesso = strNomeProcessoImportarDadosTabelaCentroCustoPrincipal;
            }

            intProgresso = 99;
            strNomeProcesso = strNomeProcessoImportarDadosTabelaCentroCustoPrincipal;

            objImplementacaoBancoDados.Dispose();
            objImplementacaoBancoDadosI.Dispose();
        }
    }
}