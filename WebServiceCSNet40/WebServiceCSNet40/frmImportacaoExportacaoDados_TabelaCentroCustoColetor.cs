using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceCSNet40
{
    public partial class frmImportacaoExportacaoDados
    {
        private System.Threading.Thread ThreadImportarDadosTabelaCentroCustoColetor;

        private string strNomeProcessoImportarDadosTabelaCentroCustoColetor = "Importação de dados - Centro de Custo - Coletor";

        public void mtdIniciarThreadDownloadTabelaInventarioCentroCustoColetor()
        {
            mtdIniciarThreadDownloadTabelaInventarioCentroCustoColetor(true);
        }

        public void mtdIniciarThreadDownloadTabelaInventarioCentroCustoColetor(bool Iniciar)
        {
            try
            {
                intProgresso = 0;
                strNomeProcesso = strNomeProcessoImportarDadosTabelaCentroCustoColetor;
                blnAbortarThreadImportarDadosTabelaBensColetor = !Iniciar;
                blnForcarAbortarThreadImportarDadosTabelaBensColetor = false;
                blnAbortarThreadImportarDadosTabelaCentroCustoColetor = !Iniciar;
                blnForcarAbortarThreadImportarDadosTabelaCentroCustoColetor = false;
                ThreadImportarDadosTabelaCentroCustoColetor = new System.Threading.Thread
                    (
                    new System.Threading.ThreadStart
                        (
                        mtdRotinaThreadImportarDadosTabelaCentroCustoColetor
                        )
                    );
                ThreadImportarDadosTabelaCentroCustoColetor.IsBackground = true;
                ThreadImportarDadosTabelaCentroCustoColetor.Priority = System.Threading.ThreadPriority.Normal;
                ThreadImportarDadosTabelaCentroCustoColetor.Start();
            }
            catch (Exception ex)
            {
                string strExcecao = "mtdIniciarThreadDownloadTabelaInventarioCentroCustoColetor: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        public void mtdReIniciarThreadDownloadTabelaInventarioCentroCustoColetor()
        {
            intProgresso = 0;
            strNomeProcesso = strNomeProcessoImportarDadosTabelaCentroCustoColetor;
            blnAbortarThreadImportarDadosTabelaBensColetor = false;
            blnForcarAbortarThreadImportarDadosTabelaBensColetor = false;
            blnAbortarThreadImportarDadosTabelaCentroCustoColetor = false;
            blnForcarAbortarThreadImportarDadosTabelaCentroCustoColetor = false;
        }

        private static bool blnForcarAbortarThreadImportarDadosTabelaCentroCustoColetor = false;
        private static bool blnAbortarThreadImportarDadosTabelaCentroCustoColetor = false;
        private static int intTempoSaidaAbortarThreadImportarDadosTabelaCentroCustoColetor = 1000;

        public void mtdAbortarThreadImportarDadosTabelaCentroCustoColetor()
        {
            mtdAbortarThreadImportarDadosTabelaCentroCustoColetor(false);
        }

        public void mtdAbortarThreadImportarDadosTabelaCentroCustoColetor(bool Forcar)
        {
            intProgresso = 100;
            System.Threading.Thread.Sleep(1000);
            intProgresso = 0;
            strNomeProcesso = strNomeProcessoImportarDadosTabelaCentroCustoColetor;
            blnAbortarThreadImportarDadosTabelaBensColetor = true;
            blnForcarAbortarThreadImportarDadosTabelaBensColetor = Forcar;
            blnAbortarThreadImportarDadosTabelaCentroCustoColetor = true;
            blnForcarAbortarThreadImportarDadosTabelaCentroCustoColetor = Forcar;

            try
            {
                ThreadImportarDadosTabelaCentroCustoColetor.Join(intTempoSaidaAbortarThreadImportarDadosTabelaCentroCustoColetor);
                ThreadImportarDadosTabelaCentroCustoColetor.Abort();
                ThreadImportarDadosTabelaCentroCustoColetor = null;
            }
            catch (Exception ex)
            {
                string strExcecao = "mtdAbortarThreadImportarDadosTabelaCentroCustoColetor: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        public void mtdPararThreadDownloadTabelaInventarioCentroCustoColetor()
        {
            intProgresso = 100;
            System.Threading.Thread.Sleep(1000);
            intProgresso = 0;
            strNomeProcesso = strNomeProcessoImportarDadosTabelaCentroCustoColetor;
            blnAbortarThreadImportarDadosTabelaBensColetor = true;
            blnForcarAbortarThreadImportarDadosTabelaBensColetor = true;
            blnAbortarThreadImportarDadosTabelaCentroCustoColetor = true;
            blnForcarAbortarThreadImportarDadosTabelaCentroCustoColetor = true;
        }

        private static object LockImportarDadosTabelaCentroCustoColetor = new object();

        //private int intPassoPadraoUploadTabelaInventarioCentroCustoColetor = 0;
        //public static int intProgressoTabelaCentroCustoColetor = 0;

        private void mtdRotinaThreadImportarDadosTabelaCentroCustoColetor()
        {
            while (true)
            {
                if (!blnAbortarThreadImportarDadosTabelaBensColetor & !blnAbortarThreadImportarDadosTabelaCentroCustoColetor)
                {
                    //System.Threading.Monitor.Enter(LockImportarDadosTabelaCentroCustoColetor);
                    lock (LockImportarDadosTabelaCentroCustoColetor)
                    {
                        try
                        {
                            mtdRotinaImportarDadosTabelaCentroCustoColetor
                                (
                                blnComandoImplementadoDeletarDadosTabelaCentroCustoColetor,
                                blnComandoImplementadoInserirDadosTabelaCentroCustoColetor
                                );
                            mtdAbortarThreadImportarDadosTabelaCentroCustoColetor(true);
                        }
                        finally
                        {
                            //System.Threading.Monitor.Exit(LockImportarDadosTabelaCentroCustoColetor);
                        }
                    }
                }

                System.Threading.Thread.Sleep(1);
            }
        }

        private void mtdRotinaImportarDadosTabelaCentroCustoColetor()
        {
            mtdRotinaImportarDadosTabelaCentroCustoColetor(true, true);
        }

        private void mtdRotinaImportarDadosTabelaCentroCustoColetor(bool Deletar, bool Inserir)
        {
            if (blnAbortarThreadImportarDadosTabelaBensColetor && blnForcarAbortarThreadImportarDadosTabelaBensColetor) return;
            if (blnAbortarThreadImportarDadosTabelaCentroCustoColetor && blnForcarAbortarThreadImportarDadosTabelaCentroCustoColetor) return;
            if (blnAbortarThreadPreparacaoColetorDados && blnForcarAbortarThreadPreparacaoColetorDados) return;

            if (Deletar)
            {
                mtdDeletarTabelaCentroCustoColetor();
                mtdDeletarDadosTabelaCentroCustoColetor();
            }
            mtdCriarTabelaCentroCustoColetor();
            if (Inserir)
            {
                mtdInserirDadosTabelaCentroCustoColetor();
            }
        }

        public bool blnComandoImplementadoDeletarDadosTabelaCentroCustoColetor = true;

        public void mtdDeletarTabelaCentroCustoColetor()
        {
            if (blnAbortarThreadImportarDadosTabelaBensColetor && blnForcarAbortarThreadImportarDadosTabelaBensColetor) return;
            if (blnAbortarThreadImportarDadosTabelaCentroCustoColetor && blnForcarAbortarThreadImportarDadosTabelaCentroCustoColetor) return;
            if (blnAbortarThreadPreparacaoColetorDados && blnForcarAbortarThreadPreparacaoColetorDados) return;

            string BancoDados = "Coletor";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

            objImplementacaoBancoDados.mtdDeletarTabela(Default.strTabelaCentroCusto);
            objImplementacaoBancoDados.Dispose();
        }

        public void mtdDeletarDadosTabelaCentroCustoColetor()
        {
            if (blnAbortarThreadImportarDadosTabelaBensColetor && blnForcarAbortarThreadImportarDadosTabelaBensColetor) return;
            if (blnAbortarThreadImportarDadosTabelaCentroCustoColetor && blnForcarAbortarThreadImportarDadosTabelaCentroCustoColetor) return;
            if (blnAbortarThreadPreparacaoColetorDados && blnForcarAbortarThreadPreparacaoColetorDados) return;

            string BancoDados = "Coletor";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

            objImplementacaoBancoDados.mtdDeletarDados(Default.strTabelaCentroCusto, strColunaColetor, "LIKE", "'%'");
            objImplementacaoBancoDados.Dispose();
        }

        private string[][] camposTabelaCentroCustoColetor;

        public void mtdCriarTabelaCentroCustoColetor()
        {
            if (blnAbortarThreadImportarDadosTabelaBensColetor && blnForcarAbortarThreadImportarDadosTabelaBensColetor) return;
            if (blnAbortarThreadImportarDadosTabelaCentroCustoColetor && blnForcarAbortarThreadImportarDadosTabelaCentroCustoColetor) return;
            if (blnAbortarThreadPreparacaoColetorDados && blnForcarAbortarThreadPreparacaoColetorDados) return;

            string BancoDados = "Coletor";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

            intcolunaTabelaCentroCusto = 3;

            camposTabelaCentroCustoColetor = new string[intcolunaTabelaCentroCusto][];
            camposTabelaCentroCustoColetor[0] = new string[] { "CentroCusto", "INTEGER", string.Empty, "CONSTRAINT PrimaryKeyCentroCusto PRIMARY KEY" };
            camposTabelaCentroCustoColetor[1] = new string[] { "Orgao", "NVARCHAR", "255", string.Empty };
            camposTabelaCentroCustoColetor[2] = new string[] { "OrgaoDescricao", "NVARCHAR", "255", string.Empty };

            objImplementacaoBancoDados.mtdCriarTabela(Default.strTabelaCentroCusto, camposTabelaCentroCustoColetor);
            objImplementacaoBancoDados.Dispose();
        }

        public bool blnComandoImplementadoInserirDadosTabelaCentroCustoColetor = true;

        public void mtdInserirDadosTabelaCentroCustoColetor()
        {
            if (blnAbortarThreadImportarDadosTabelaBensColetor && blnForcarAbortarThreadImportarDadosTabelaBensColetor) return;
            if (blnAbortarThreadImportarDadosTabelaCentroCustoColetor && blnForcarAbortarThreadImportarDadosTabelaCentroCustoColetor) return;
            if (blnAbortarThreadPreparacaoColetorDados && blnForcarAbortarThreadPreparacaoColetorDados) return;

            string BancoDados = "Coletor";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);
            clsImplementacaoBancoDados objImplementacaoBancoDadosI = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

            string[][] dados = new string[2][];
            dados[0] = new string[intcolunaTabelaCentroCusto];

            for (int contador = 0; contador <= intcolunaTabelaCentroCusto - 1; contador++)
            {
                if (blnAbortarThreadImportarDadosTabelaBensColetor && blnForcarAbortarThreadImportarDadosTabelaBensColetor) return;
                if (blnAbortarThreadImportarDadosTabelaCentroCustoColetor && blnForcarAbortarThreadImportarDadosTabelaCentroCustoColetor) return;
                if (blnAbortarThreadPreparacaoColetorDados && blnForcarAbortarThreadPreparacaoColetorDados) return;

                dados[0][contador] = camposTabelaCentroCustoColetor[contador][0];
            }

            intProgresso = 0;
            strNomeProcesso = strNomeProcessoImportarDadosTabelaCentroCustoColetor;

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

            intNumeroLinhasColetor = objImplementacaoBancoDados.mtdNumeroLinhas();
            objImplementacaoBancoDados.mtdDefinirLeitorDados();
            intNumeroColunasColetor = intcolunaTabelaCentroCusto;
            objImplementacaoBancoDados.mtdProximoRegistro();
            vetTipoColunasColetor = objImplementacaoBancoDados.mtdObterTipoRegistro();

            string[] dadosI = new string[intcolunaTabelaCentroCusto];

            for (int linha = 0; linha <= intNumeroLinhasColetor - 1; linha++)
            {
                if (blnAbortarThreadImportarDadosTabelaBensColetor && blnForcarAbortarThreadImportarDadosTabelaBensColetor) return;
                if (blnAbortarThreadImportarDadosTabelaCentroCustoColetor && blnForcarAbortarThreadImportarDadosTabelaCentroCustoColetor) return;
                if (blnAbortarThreadPreparacaoColetorDados && blnForcarAbortarThreadPreparacaoColetorDados) return;

                // dados(linha) = New String(intNumeroColunasColetor) {}
                for (int coluna = 0; coluna <= intcolunaTabelaCentroCusto - 2; coluna++)
                {
                    if (blnAbortarThreadImportarDadosTabelaBensColetor && blnForcarAbortarThreadImportarDadosTabelaBensColetor) return;
                    if (blnAbortarThreadImportarDadosTabelaCentroCustoColetor && blnForcarAbortarThreadImportarDadosTabelaCentroCustoColetor) return;
                    if (blnAbortarThreadPreparacaoColetorDados && blnForcarAbortarThreadPreparacaoColetorDados) return;

                    string strFormatoRegistro = mtdObterFormatoTipo(vetTipoColunasColetor[coluna]);
                    string strValorRegistro = objManipuladorTexto.mtdExecutarTudo
                         (
                         objImplementacaoBancoDados.mtdObterValorRegistro(coluna) != null ?
                         objImplementacaoBancoDados.mtdObterValorRegistro(coluna).ToString() :
                         string.Empty);

                    dadosI[coluna] = string.Format(strFormatoRegistro, strValorRegistro);
                }
                dados[1] = new string[intcolunaTabelaCentroCusto];

                for (int coluna = 0; coluna <= intNumeroColunasColetor - 1; coluna++)
                {
                    if (blnAbortarThreadImportarDadosTabelaBensColetor && blnForcarAbortarThreadImportarDadosTabelaBensColetor) return;
                    if (blnAbortarThreadImportarDadosTabelaCentroCustoColetor && blnForcarAbortarThreadImportarDadosTabelaCentroCustoColetor) return;
                    if (blnAbortarThreadPreparacaoColetorDados && blnForcarAbortarThreadPreparacaoColetorDados) return;

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

                intProgresso = mtdProgresso(linha, intNumeroLinhasColetor);
                strNomeProcesso = strNomeProcessoImportarDadosTabelaCentroCustoColetor;
            }

            intProgresso = 99;
            strNomeProcesso = strNomeProcessoImportarDadosTabelaCentroCustoColetor;

            objImplementacaoBancoDados.Dispose();
            objImplementacaoBancoDadosI.Dispose();
        }
    }
}