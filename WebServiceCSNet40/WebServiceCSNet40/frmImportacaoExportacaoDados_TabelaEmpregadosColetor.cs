using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceCSNet40
{
    public partial class frmImportacaoExportacaoDados
    {
        private System.Threading.Thread ThreadImportarDadosTabelaEmpregadosColetor;

        private string strNomeProcessoImportarDadosTabelaEmpregadosColetor = "Importação de dados - Empregados - Coletor";

        public void mtdIniciarThreadDownloadTabelaEmpregadosColetor()
        {
            mtdIniciarThreadDownloadTabelaEmpregadosColetor(true);
        }

        public void mtdIniciarThreadDownloadTabelaEmpregadosColetor(bool Iniciar)
        {
            try
            {
                intProgresso = 0;
                strNomeProcesso = strNomeProcessoImportarDadosTabelaEmpregadosColetor;
                blnAbortarThreadImportarDadosTabelaEmpregadosColetor = !Iniciar;
                blnForcarAbortarThreadImportarDadosTabelaEmpregadosColetor = false;
                ThreadImportarDadosTabelaEmpregadosColetor = new System.Threading.Thread
                    (
                    new System.Threading.ThreadStart
                        (
                        mtdRotinaThreadImportarDadosTabelaEmpregadosColetor
                        )
                    );
                ThreadImportarDadosTabelaEmpregadosColetor.IsBackground = true;
                ThreadImportarDadosTabelaEmpregadosColetor.Priority = System.Threading.ThreadPriority.Normal;
                ThreadImportarDadosTabelaEmpregadosColetor.Start();
            }
            catch (Exception ex)
            {
                string strExcecao = "mtdIniciarThreadDownloadTabelaEmpregadosColetor: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        public void mtdReIniciarThreadDownloadTabelaEmpregadosColetor()
        {
            intProgresso = 0;
            strNomeProcesso = strNomeProcessoImportarDadosTabelaEmpregadosColetor;
            blnAbortarThreadImportarDadosTabelaEmpregadosColetor = false;
            blnForcarAbortarThreadImportarDadosTabelaEmpregadosColetor = false;
        }

        private static bool blnForcarAbortarThreadImportarDadosTabelaEmpregadosColetor = false;
        private static bool blnAbortarThreadImportarDadosTabelaEmpregadosColetor = false;
        private static int intTempoSaidaAbortarThreadImportarDadosTabelaEmpregadosColetor = 1000;

        public void mtdAbortarThreadImportarDadosTabelaEmpregadosColetor()
        {
            mtdAbortarThreadImportarDadosTabelaEmpregadosColetor(false);
        }

        public void mtdAbortarThreadImportarDadosTabelaEmpregadosColetor(bool Forcar)
        {
            intProgresso = 100;
            System.Threading.Thread.Sleep(1000);
            intProgresso = 0;
            strNomeProcesso = strNomeProcessoImportarDadosTabelaEmpregadosColetor;
            blnAbortarThreadImportarDadosTabelaEmpregadosColetor = true;
            blnForcarAbortarThreadImportarDadosTabelaEmpregadosColetor = Forcar;

            try
            {
                ThreadImportarDadosTabelaEmpregadosColetor.Join(intTempoSaidaAbortarThreadImportarDadosTabelaEmpregadosColetor);
                ThreadImportarDadosTabelaEmpregadosColetor.Abort();
                ThreadImportarDadosTabelaEmpregadosColetor = null;
            }
            catch (Exception ex)
            {
                string strExcecao = "mtdAbortarThreadImportarDadosTabelaEmpregadosColetor: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        public void mtdPararThreadDownloadTabelaEmpregadosColetor()
        {
            intProgresso = 100;
            System.Threading.Thread.Sleep(1000);
            intProgresso = 0;
            strNomeProcesso = strNomeProcessoImportarDadosTabelaEmpregadosColetor;
            blnAbortarThreadImportarDadosTabelaEmpregadosColetor = true;
            blnForcarAbortarThreadImportarDadosTabelaEmpregadosColetor = true;
        }

        private static object LockImportarDadosTabelaEmpregadosColetor = new object();

        //private int intPassoPadraoUploadTabelaEmpregadosColetor = 0;

        private void mtdRotinaThreadImportarDadosTabelaEmpregadosColetor()
        {
            while (true)
            {
                if (!blnAbortarThreadImportarDadosTabelaEmpregadosColetor)
                {
                    //System.Threading.Monitor.Enter(LockImportarDadosTabelaEmpregadosColetor);
                    lock (LockImportarDadosTabelaEmpregadosColetor)
                    {
                        try
                        {
                            mtdRotinaImportarDadosTabelaEmpregadosColetor
                                (
                                blnComandoImplementadoDeletarDadosTabelaEmpregadosColetor,
                                blnComandoImplementadoInserirDadosTabelaEmpregadosColetor
                                );
                            mtdAbortarThreadImportarDadosTabelaEmpregadosColetor(true);
                        }
                        finally
                        {
                            //System.Threading.Monitor.Exit(LockImportarDadosTabelaEmpregadosColetor);
                        }
                    }
                }

                System.Threading.Thread.Sleep(1);
            }
        }

        private void mtdRotinaImportarDadosTabelaEmpregadosColetor()
        {
            mtdRotinaImportarDadosTabelaEmpregadosColetor(true, true);
        }

        private void mtdRotinaImportarDadosTabelaEmpregadosColetor(bool Deletar, bool Inserir)
        {

            if (blnAbortarThreadImportarDadosTabelaEmpregadosColetor && blnForcarAbortarThreadImportarDadosTabelaEmpregadosColetor) return;
            if (blnAbortarThreadPreparacaoColetorDados && blnForcarAbortarThreadPreparacaoColetorDados) return;

            if (Deletar)
            {
                mtdDeletarTabelaEmpregadosColetor();
                mtdDeletarDadosTabelaEmpregadosColetor();
            }

            mtdCriarTabelaEmpregadosColetor();
            if (Inserir)
            {
                mtdInserirDadosTabelaEmpregadosColetor();
            }
        }

        public bool blnComandoImplementadoDeletarDadosTabelaEmpregadosColetor = true;

        public void mtdDeletarTabelaEmpregadosColetor()
        {
            string BancoDadosColetor = "Coletor";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacionalColetor = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexaoColetor = Default.mtdDefinirStringConexao(BancoDadosColetor, ref TipoSistemaGerenciadorBancoDadosRelacionalColetor);
            clsImplementacaoBancoDados objBancoDadosColetor = new clsImplementacaoBancoDados(strConexaoColetor, TipoSistemaGerenciadorBancoDadosRelacionalColetor);

            objBancoDadosColetor.mtdDeletarTabela(Default.strTabelaEmpregados);
            objBancoDadosColetor.Dispose();
        }

        public void mtdDeletarDadosTabelaEmpregadosColetor()
        {
            string BancoDadosColetor = "Coletor";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacionalColetor = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexaoColetor = Default.mtdDefinirStringConexao(BancoDadosColetor, ref TipoSistemaGerenciadorBancoDadosRelacionalColetor);
            clsImplementacaoBancoDados objBancoDadosColetor = new clsImplementacaoBancoDados(strConexaoColetor, TipoSistemaGerenciadorBancoDadosRelacionalColetor);

            objBancoDadosColetor.mtdDeletarDados(Default.strTabelaEmpregados, Default.vetCamposTabelaEmpregados[1], "LIKE", "'%'");
            objBancoDadosColetor.Dispose();
        }

        public void mtdCriarTabelaEmpregadosColetor()
        {
            try
            {
                string BancoDadosColetor = "Coletor";

                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacionalColetor = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
                string strConexaoColetor = Default.mtdDefinirStringConexao(BancoDadosColetor, ref TipoSistemaGerenciadorBancoDadosRelacionalColetor);
                clsImplementacaoBancoDados objBancoDadosColetor = new clsImplementacaoBancoDados(strConexaoColetor, TipoSistemaGerenciadorBancoDadosRelacionalColetor);

                string BancoDadosCADU = "CADU";

                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacionalCADU = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
                string strConexaoCADU = Default.mtdDefinirStringConexao(BancoDadosCADU, ref TipoSistemaGerenciadorBancoDadosRelacionalCADU);
                clsImplementacaoBancoDados objBancoDadosCADU = new clsImplementacaoBancoDados(strConexaoCADU, TipoSistemaGerenciadorBancoDadosRelacionalCADU);

                objBancoDadosColetor.prpTipoSistemaGerenciadorBancoDadosRelacional = clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE;
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
                    if (blnAbortarThreadImportarDadosTabelaEmpregadosColetor && blnForcarAbortarThreadImportarDadosTabelaEmpregadosColetor) return;
                    if (blnAbortarThreadPreparacaoColetorDados && blnForcarAbortarThreadPreparacaoColetorDados) return;

                    vetTipoColunasCADU[contador] = objBancoDadosCADU.mtdObterTipoRegistro(contador);
                }

                campos[0] = new string[4]
                {
                    vetColunasCADU[0],
                    mtdIdentificarTipoColetor(vetTipoColunasCADU[0]),
                    mtdIdentificarTamanhoTipo(vetTipoColunasCADU[0]),
                    string.Empty
                };
                for (int contador = 1; contador <= intNumeroColunasCADU; contador += 1)
                {
                    if (blnAbortarThreadImportarDadosTabelaEmpregadosColetor && blnForcarAbortarThreadImportarDadosTabelaEmpregadosColetor) return;
                    if (blnAbortarThreadPreparacaoColetorDados && blnForcarAbortarThreadPreparacaoColetorDados) return;

                    switch ((contador))
                    {
                        case 1:
                            campos[contador] = new string[4] 
                            {
                                vetColunasCADU[contador],
                                mtdIdentificarTipoColetor(vetTipoColunasCADU[contador]),
                                mtdIdentificarTamanhoTipo(vetTipoColunasCADU[contador]),
                                string.Format("CONSTRAINT primarykey{0} PRIMARY KEY", vetColunasCADU[contador])
                            };
                            break;
                        default:
                            campos[contador] = new string[4]
                            {
                                vetColunasCADU[contador],
                            mtdIdentificarTipoColetor(vetTipoColunasCADU[contador]),
                            mtdIdentificarTamanhoTipo(vetTipoColunasCADU[contador]),
                            string.Empty
                            };
                            break;
                    }
                }

                objBancoDadosColetor.mtdCriarTabela(Default.strTabelaEmpregados, campos);

                objBancoDadosCADU.Dispose();
                objBancoDadosColetor.Dispose();
            }
            catch (Exception ex)
            {
                string strExcecao = "mtdCriarTabelaEmpregadosColetor: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        public bool blnComandoImplementadoInserirDadosTabelaEmpregadosColetor = true;

        private void mtdInserirDadosTabelaEmpregadosColetor()
        {
            try
            {
                string BancoDadosColetor = "Coletor";

                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacionalColetor = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
                string strConexaoColetor = Default.mtdDefinirStringConexao(BancoDadosColetor, ref TipoSistemaGerenciadorBancoDadosRelacionalColetor);
                clsImplementacaoBancoDados objBancoDadosColetor = new clsImplementacaoBancoDados(strConexaoColetor, TipoSistemaGerenciadorBancoDadosRelacionalColetor);

                string BancoDadosCADU = "CADU";

                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacionalCADU = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
                string strConexaoCADU = Default.mtdDefinirStringConexao(BancoDadosCADU, ref TipoSistemaGerenciadorBancoDadosRelacionalCADU);
                clsImplementacaoBancoDados objBancoDadosCADU = new clsImplementacaoBancoDados(strConexaoCADU, TipoSistemaGerenciadorBancoDadosRelacionalCADU);

                intProgresso = 0;
                strNomeProcesso = strNomeProcessoImportarDadosTabelaEmpregadosColetor;

                string[][] dados = new string[2][];
                objBancoDadosCADU.mtdSelecionarDados("*", Default.strTabelaCADU);
                intNumeroLinhasCADU = objBancoDadosCADU.mtdNumeroLinhas();
                objBancoDadosCADU.mtdDefinirLeitorDados();
                objBancoDadosCADU.mtdProximoRegistro();
                intNumeroColunasCADU = objBancoDadosCADU.mtdNumeroColunas() - 1;
                objBancoDadosColetor.mtdSelecionarDados("*", Default.strTabelaEmpregados);
                objBancoDadosColetor.mtdDefinirLeitorDados();
                dados[0] = objBancoDadosColetor.mtdObterCabecalhoColunas();
                dados[1] = new string[intNumeroColunasCADU + 1];
                for (int linha = 0; linha <= intNumeroLinhasCADU; linha += 1)
                {
                    if (blnAbortarThreadImportarDadosTabelaEmpregadosColetor && blnForcarAbortarThreadImportarDadosTabelaEmpregadosColetor) return;
                    if (blnAbortarThreadPreparacaoColetorDados && blnForcarAbortarThreadPreparacaoColetorDados) return;

                    //dados(linha) = New String(intNumeroColunasCADU) {}
                    for (int coluna = 0; coluna <= intNumeroColunasCADU; coluna += 1)
                    {
                        if (blnAbortarThreadImportarDadosTabelaEmpregadosColetor && blnForcarAbortarThreadImportarDadosTabelaEmpregadosColetor) return;
                        if (blnAbortarThreadPreparacaoColetorDados && blnForcarAbortarThreadPreparacaoColetorDados) return;

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
                    objBancoDadosColetor.mtdInserirDados(Default.strTabelaEmpregados, dados);
                    objBancoDadosCADU.mtdProximoRegistro();
                    intProgresso = mtdProgresso(linha, intNumeroLinhasCADU);
                    strNomeProcesso = strNomeProcessoImportarDadosTabelaEmpregadosColetor;
                }
                intProgresso = 99;
                strNomeProcesso = strNomeProcessoImportarDadosTabelaEmpregadosColetor;
                objBancoDadosColetor.Dispose();
                objBancoDadosCADU.Dispose();
                //System.Windows.Forms.MessageBox.Show("A importação dos dados finalizou com sucesso.", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
            catch (Exception ex)
            {
                string strExcecao = "mtdInserirDadosTabelaEmpregadosColetor: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }
    }
}