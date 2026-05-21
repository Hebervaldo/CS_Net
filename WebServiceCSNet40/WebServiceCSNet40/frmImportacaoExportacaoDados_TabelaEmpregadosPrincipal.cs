using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceCSNet40
{
    public partial class frmImportacaoExportacaoDados
    {
        private System.Threading.Thread ThreadImportarDadosTabelaEmpregadosPrincipal;

        private string strNomeProcessoImportarDadosTabelaEmpregadosPrincipal = "Importação de dados - Empregados - Principal";

        public void mtdIniciarThreadDownloadTabelaEmpregadosPrincipal()
        {
            mtdIniciarThreadDownloadTabelaEmpregadosPrincipal(true);
        }

        public void mtdIniciarThreadDownloadTabelaEmpregadosPrincipal(bool Iniciar)
        {
            try
            {
                intProgresso = 0;
                strNomeProcesso = strNomeProcessoImportarDadosTabelaEmpregadosPrincipal;
                blnAbortarThreadImportarDadosTabelaEmpregadosPrincipal = !Iniciar;
                blnForcarAbortarThreadImportarDadosTabelaEmpregadosPrincipal = false;
                ThreadImportarDadosTabelaEmpregadosPrincipal = new System.Threading.Thread
                    (
                    new System.Threading.ThreadStart
                        (
                        mtdRotinaThreadImportarDadosTabelaEmpregadosPrincipal
                        )
                    );
                ThreadImportarDadosTabelaEmpregadosPrincipal.IsBackground = true;
                ThreadImportarDadosTabelaEmpregadosPrincipal.Priority = System.Threading.ThreadPriority.Normal;
                ThreadImportarDadosTabelaEmpregadosPrincipal.Start();
            }
            catch (Exception ex)
            {
                string strExcecao = "mtdIniciarThreadDownloadTabelaEmpregadosPrincipal: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        public void mtdReIniciarThreadDownloadTabelaEmpregadosPrincipal()
        {
            intProgresso = 0;
            strNomeProcesso = strNomeProcessoImportarDadosTabelaEmpregadosPrincipal;
            blnAbortarThreadImportarDadosTabelaEmpregadosPrincipal = false;
            blnForcarAbortarThreadImportarDadosTabelaEmpregadosPrincipal = false;
        }

        private static bool blnForcarAbortarThreadImportarDadosTabelaEmpregadosPrincipal = false;
        private static bool blnAbortarThreadImportarDadosTabelaEmpregadosPrincipal = false;
        private static int intTempoSaidaAbortarThreadImportarDadosTabelaEmpregadosPrincipal = 1000;

        public void mtdAbortarThreadImportarDadosTabelaEmpregadosPrincipal()
        {
            mtdAbortarThreadImportarDadosTabelaEmpregadosPrincipal(false);
        }

        public void mtdAbortarThreadImportarDadosTabelaEmpregadosPrincipal(bool Forcar)
        {
            intProgresso = 100;
            System.Threading.Thread.Sleep(1000);
            intProgresso = 0;
            strNomeProcesso = strNomeProcessoImportarDadosTabelaEmpregadosPrincipal;
            blnAbortarThreadImportarDadosTabelaEmpregadosPrincipal = true;
            blnForcarAbortarThreadImportarDadosTabelaEmpregadosPrincipal = Forcar;

            try
            {
                ThreadImportarDadosTabelaEmpregadosPrincipal.Join(intTempoSaidaAbortarThreadImportarDadosTabelaEmpregadosPrincipal);
                ThreadImportarDadosTabelaEmpregadosPrincipal.Abort();
                ThreadImportarDadosTabelaEmpregadosPrincipal = null;
            }
            catch (Exception ex)
            {
                string strExcecao = "mtdAbortarThreadImportarDadosTabelaEmpregadosPrincipal: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);               // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        public void mtdPararThreadDownloadTabelaEmpregadosPrincipal()
        {
            intProgresso = 100;
            System.Threading.Thread.Sleep(1000);
            intProgresso = 0;
            strNomeProcesso = strNomeProcessoImportarDadosTabelaEmpregadosPrincipal;
            blnAbortarThreadImportarDadosTabelaEmpregadosPrincipal = true;
            blnForcarAbortarThreadImportarDadosTabelaEmpregadosPrincipal = true;
        }

        private static object LockImportarDadosTabelaEmpregadosPrincipal = new object();

        //private int intPassoPadraoUploadTabelaEmpregadosPrincipal = 0;

        private void mtdRotinaThreadImportarDadosTabelaEmpregadosPrincipal()
        {
            while (true)
            {
                if (!blnAbortarThreadImportarDadosTabelaEmpregadosPrincipal)
                {
                    //System.Threading.Monitor.Enter(LockImportarDadosTabelaEmpregadosPrincipal);
                    lock (LockImportarDadosTabelaEmpregadosPrincipal)
                    {
                        try
                        {
                            mtdRotinaImportarDadosTabelaEmpregadosPrincipal
                                (
                                blnComandoImplementadoDeletarDadosTabelaEmpregadosPrincipal,
                                blnComandoImplementadoInserirDadosTabelaEmpregadosPrincipal
                                );
                            mtdAbortarThreadImportarDadosTabelaEmpregadosPrincipal(true);
                        }
                        finally
                        {
                            //System.Threading.Monitor.Exit(LockImportarDadosTabelaEmpregadosPrincipal);
                        }
                    }
                }

                System.Threading.Thread.Sleep(1);
            }
        }

        private void mtdRotinaImportarDadosTabelaEmpregadosPrincipal()
        {
            mtdRotinaImportarDadosTabelaEmpregadosPrincipal(true, true);
        }

        private void mtdRotinaImportarDadosTabelaEmpregadosPrincipal(bool Deletar, bool Inserir)
        {
            if (blnAbortarThreadImportarDadosTabelaEmpregadosPrincipal && blnForcarAbortarThreadImportarDadosTabelaEmpregadosPrincipal) return;
            if (blnAbortarThreadPreparacaoPrincipal && blnForcarAbortarThreadPreparacaoPrincipal) return;

            if (Deletar)
            {
                mtdDeletarTabelaEmpregadosPrincipal();
                mtdDeletarDadosTabelaEmpregadosPrincipal();
            }
            mtdCriarTabelaEmpregadosPrincipal();
            if (Inserir)
            {
                mtdInserirDadosTabelaEmpregadosPrincipal();
            }
        }

        public bool blnComandoImplementadoDeletarDadosTabelaEmpregadosPrincipal = true;

        public void mtdDeletarTabelaEmpregadosPrincipal()
        {
            string BancoDadosPrincipal = "Principal";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacionalPrincipal = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexaoPrincipal = Default.mtdDefinirStringConexao(BancoDadosPrincipal, ref TipoSistemaGerenciadorBancoDadosRelacionalPrincipal);
            clsImplementacaoBancoDados objBancoDadosPrincipal = new clsImplementacaoBancoDados(strConexaoPrincipal, TipoSistemaGerenciadorBancoDadosRelacionalPrincipal);

            objBancoDadosPrincipal.mtdDeletarTabela(Default.strTabelaEmpregados);
            objBancoDadosPrincipal.Dispose();
        }

        public void mtdDeletarDadosTabelaEmpregadosPrincipal()
        {
            string BancoDadosPrincipal = "Principal";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacionalPrincipal = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexaoPrincipal = Default.mtdDefinirStringConexao(BancoDadosPrincipal, ref TipoSistemaGerenciadorBancoDadosRelacionalPrincipal);
            clsImplementacaoBancoDados objBancoDadosPrincipal = new clsImplementacaoBancoDados(strConexaoPrincipal, TipoSistemaGerenciadorBancoDadosRelacionalPrincipal);

            objBancoDadosPrincipal.mtdDeletarDados(Default.strTabelaEmpregados, Default.vetCamposTabelaEmpregados[1], "LIKE", "'%'");
            objBancoDadosPrincipal.Dispose();
        }

        public void mtdCriarTabelaEmpregadosPrincipal()
        {
            try
            {
                string BancoDadosPrincipal = "Principal";

                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacionalPrincipal = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
                string strConexaoPrincipal = Default.mtdDefinirStringConexao(BancoDadosPrincipal, ref TipoSistemaGerenciadorBancoDadosRelacionalPrincipal);
                clsImplementacaoBancoDados objBancoDadosPrincipal = new clsImplementacaoBancoDados(strConexaoPrincipal, TipoSistemaGerenciadorBancoDadosRelacionalPrincipal);

                string BancoDadosCADU = "CADU";

                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacionalCADU = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
                string strConexaoCADU = Default.mtdDefinirStringConexao(BancoDadosCADU, ref TipoSistemaGerenciadorBancoDadosRelacionalCADU);
                clsImplementacaoBancoDados objBancoDadosCADU = new clsImplementacaoBancoDados(strConexaoCADU, TipoSistemaGerenciadorBancoDadosRelacionalCADU);

                objBancoDadosPrincipal.prpTipoSistemaGerenciadorBancoDadosRelacional = clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb;
                objBancoDadosCADU.prpTipoSistemaGerenciadorBancoDadosRelacional = clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServer;
                objBancoDadosCADU.mtdSelecionarDados("*", Default.strTabelaCADU);
                intNumeroLinhasCADU = objBancoDadosCADU.mtdNumeroLinhas();
                objBancoDadosCADU.mtdDefinirLeitorDados();
                string[] vetColunasCADU = objBancoDadosCADU.mtdObterCabecalhoColunas();
                intNumeroColunasCADU = objBancoDadosCADU.mtdNumeroColunas() - 1;
                string[][] campos = new string[intNumeroColunasCADU + 1][];

                // A rotina abaixo gera uma tabela com as colunas e tipos de outra tabela
                vetTipoColunasCADU = new string[intNumeroColunasCADU + 1];
                objBancoDadosCADU.mtdProximoRegistro();
                for (int contador = 0; contador <= intNumeroColunasCADU; contador += 1)
                {
                    if (blnAbortarThreadImportarDadosTabelaEmpregadosPrincipal && blnForcarAbortarThreadImportarDadosTabelaEmpregadosPrincipal) return;
                    if (blnAbortarThreadPreparacaoPrincipal && blnForcarAbortarThreadPreparacaoPrincipal) return;

                    vetTipoColunasCADU[contador] = objBancoDadosCADU.mtdObterTipoRegistro(contador);
                }

                campos[0] = new string[4]
                {
                    vetColunasCADU[0],
                    mtdIdentificarTipoPrincipal(vetTipoColunasCADU[0]),
                    mtdIdentificarTamanhoTipo(vetTipoColunasCADU[0]),
                    string.Empty
                };
                for (int contador = 1; contador <= intNumeroColunasCADU; contador += 1)
                {
                    if (blnAbortarThreadImportarDadosTabelaEmpregadosPrincipal && blnForcarAbortarThreadImportarDadosTabelaEmpregadosPrincipal) return;
                    if (blnAbortarThreadPreparacaoPrincipal && blnForcarAbortarThreadPreparacaoPrincipal) return;

                    switch ((contador))
                    {
                        case 1:
                            campos[contador] = new string[4] 
                            {
                                vetColunasCADU[contador],
                                mtdIdentificarTipoPrincipal(vetTipoColunasCADU[contador]),
                                mtdIdentificarTamanhoTipo(vetTipoColunasCADU[contador]),
                                string.Format("CONSTRAINT primarykey{0} PRIMARY KEY", vetColunasCADU[contador])
                            };
                            break;
                        default:
                            campos[contador] = new string[4]
                            {
                                vetColunasCADU[contador],
                            mtdIdentificarTipoPrincipal(vetTipoColunasCADU[contador]),
                            mtdIdentificarTamanhoTipo(vetTipoColunasCADU[contador]),
                            string.Empty
                            };
                            break;
                    }
                }

                objBancoDadosPrincipal.mtdCriarTabela(Default.strTabelaEmpregados, campos);

                objBancoDadosCADU.Dispose();
                objBancoDadosPrincipal.Dispose();
            }
            catch (Exception ex)
            {
                string strExcecao = "mtdCriarTabelaEmpregadosPrincipal: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        public bool blnComandoImplementadoInserirDadosTabelaEmpregadosPrincipal = true;

        private void mtdInserirDadosTabelaEmpregadosPrincipal()
        {
            try
            {
                string BancoDadosPrincipal = "Principal";

                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacionalPrincipal = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
                string strConexaoPrincipal = Default.mtdDefinirStringConexao(BancoDadosPrincipal, ref TipoSistemaGerenciadorBancoDadosRelacionalPrincipal);
                clsImplementacaoBancoDados objBancoDadosPrincipal = new clsImplementacaoBancoDados(strConexaoPrincipal, TipoSistemaGerenciadorBancoDadosRelacionalPrincipal);

                string BancoDadosCADU = "CADU";

                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacionalCADU = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
                string strConexaoCADU = Default.mtdDefinirStringConexao(BancoDadosCADU, ref TipoSistemaGerenciadorBancoDadosRelacionalCADU);
                clsImplementacaoBancoDados objBancoDadosCADU = new clsImplementacaoBancoDados(strConexaoCADU, TipoSistemaGerenciadorBancoDadosRelacionalCADU);

                intProgresso = 0;
                strNomeProcesso = strNomeProcessoImportarDadosTabelaEmpregadosPrincipal;

                string[][] dados = new string[2][];
                objBancoDadosCADU.mtdSelecionarDados("*", Default.strTabelaCADU);
                intNumeroLinhasCADU = objBancoDadosCADU.mtdNumeroLinhas();
                objBancoDadosCADU.mtdDefinirLeitorDados();
                objBancoDadosCADU.mtdProximoRegistro();
                intNumeroColunasCADU = objBancoDadosCADU.mtdNumeroColunas() - 1;
                objBancoDadosPrincipal.mtdSelecionarDados("*", Default.strTabelaEmpregados);
                objBancoDadosPrincipal.mtdDefinirLeitorDados();
                dados[0] = objBancoDadosPrincipal.mtdObterCabecalhoColunas();
                dados[1] = new string[intNumeroColunasCADU + 1];
                for (int linha = 0; linha <= intNumeroLinhasCADU; linha += 1)
                {
                    if (blnAbortarThreadImportarDadosTabelaEmpregadosPrincipal && blnForcarAbortarThreadImportarDadosTabelaEmpregadosPrincipal) return;
                    if (blnAbortarThreadPreparacaoPrincipal && blnForcarAbortarThreadPreparacaoPrincipal) return;

                    //dados(linha) = New String(intNumeroColunasCADU) {}
                    for (int coluna = 0; coluna <= intNumeroColunasCADU; coluna += 1)
                    {
                        if (blnAbortarThreadImportarDadosTabelaEmpregadosPrincipal && blnForcarAbortarThreadImportarDadosTabelaEmpregadosPrincipal) return;
                        if (blnAbortarThreadPreparacaoPrincipal && blnForcarAbortarThreadPreparacaoPrincipal) return;

                        string strFormatoRegistro = mtdObterFormatoTipo(vetTipoColunasCADU[coluna]);
                        string strValorRegistro = string.Empty;
                        if (coluna == Default.intColunaTabelaEmpregadosMatricula)
                        {
                            strValorRegistro = objBancoDadosCADU.mtdObterValorRegistro(coluna) != null ? objBancoDadosCADU.mtdObterValorRegistro(coluna).ToString().ToLower().Trim() : string.Empty;
                        }
                        else
                        {
                            strValorRegistro = objManipuladorTexto.mtdExecutarTudo((objBancoDadosCADU.mtdObterValorRegistro(coluna) != null) ? objBancoDadosCADU.mtdObterValorRegistro(coluna).ToString() : string.Empty);
                        }
                        dados[1][coluna] = string.Format(strFormatoRegistro, strValorRegistro);
                    }
                    objBancoDadosPrincipal.mtdInserirDados(Default.strTabelaEmpregados, dados);
                    objBancoDadosCADU.mtdProximoRegistro();
                    intProgresso = mtdProgresso(linha, intNumeroLinhasCADU);
                    strNomeProcesso = strNomeProcessoImportarDadosTabelaEmpregadosPrincipal;
                }
                intProgresso = 99;
                strNomeProcesso = strNomeProcessoImportarDadosTabelaEmpregadosPrincipal;
                objBancoDadosPrincipal.Dispose();
                objBancoDadosCADU.Dispose();
                //System.Windows.Forms.MessageBox.Show("A importação dos dados finalizou com sucesso.", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
            catch (Exception ex)
            {
                string strExcecao = "mtdInserirDadosTabelaEmpregadosPrincipal: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }
    }
}
