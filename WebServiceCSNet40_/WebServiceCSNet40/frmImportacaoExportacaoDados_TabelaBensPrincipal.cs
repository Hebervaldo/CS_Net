using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceCSNet40
{
    public partial class frmImportacaoExportacaoDados
    {
        private System.Threading.Thread ThreadImportarDadosTabelaBensPrincipal;

        private string strNomeProcessoImportarDadosTabelaBensPrincipal = "Importação de dados - Bens - Centro de Custo - Principal";

        public void mtdIniciarThreadDownloadTabelaInventarioBensPrincipal()
        {
            mtdIniciarThreadDownloadTabelaInventarioBensPrincipal(true);
        }

        public void mtdIniciarThreadDownloadTabelaInventarioBensPrincipal(bool Iniciar)
        {
            try
            {
                intProgresso = 0;
                strNomeProcesso = strNomeProcessoImportarDadosTabelaBensPrincipal;
                blnAbortarThreadImportarDadosTabelaBensPrincipal = !Iniciar;
                blnForcarAbortarThreadImportarDadosTabelaBensPrincipal = false;
                ThreadImportarDadosTabelaBensPrincipal = new System.Threading.Thread
                    (
                    new System.Threading.ThreadStart
                        (
                        mtdRotinaThreadImportarDadosTabelaBensPrincipal
                        )
                    );
                ThreadImportarDadosTabelaBensPrincipal.IsBackground = true;
                ThreadImportarDadosTabelaBensPrincipal.Priority = System.Threading.ThreadPriority.Normal;
                ThreadImportarDadosTabelaBensPrincipal.Start();
            }
            catch (Exception ex)
            {
                string strExcecao = "mtdIniciarThreadDownloadTabelaInventarioBensPrincipal: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        public void mtdReIniciarThreadDownloadTabelaInventarioBensPrincipal()
        {
            intProgresso = 0;
            strNomeProcesso = strNomeProcessoImportarDadosTabelaBensPrincipal;
            blnAbortarThreadImportarDadosTabelaBensPrincipal = false;
            blnForcarAbortarThreadImportarDadosTabelaBensPrincipal = false;
        }

        private static bool blnForcarAbortarThreadImportarDadosTabelaBensPrincipal = false;
        private static bool blnAbortarThreadImportarDadosTabelaBensPrincipal = false;
        private static int intTempoSaidaAbortarThreadImportarDadosTabelaBensPrincipal = 1000;

        public void mtdAbortarThreadImportarDadosTabelaBensPrincipal()
        {
            mtdAbortarThreadImportarDadosTabelaBensPrincipal(false);
        }

        public void mtdAbortarThreadImportarDadosTabelaBensPrincipal(bool Forcar)
        {
            intProgresso = 100;
            System.Threading.Thread.Sleep(1000);
            intProgresso = 0;
            strNomeProcesso = strNomeProcessoImportarDadosTabelaBensPrincipal;
            blnAbortarThreadImportarDadosTabelaBensPrincipal = true;
            blnForcarAbortarThreadImportarDadosTabelaBensPrincipal = Forcar;

            try
            {
                ThreadImportarDadosTabelaBensPrincipal.Join(intTempoSaidaAbortarThreadImportarDadosTabelaBensPrincipal);
                ThreadImportarDadosTabelaBensPrincipal.Abort();
                ThreadImportarDadosTabelaBensPrincipal = null;
            }
            catch (Exception ex)
            {
                string strExcecao = "mtdAbortarThreadImportarDadosTabelaBensPrincipal: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        public void mtdPararThreadDownloadTabelaInventarioBensPrincipal()
        {
            intProgresso = 100;
            System.Threading.Thread.Sleep(1000);
            intProgresso = 0;
            strNomeProcesso = strNomeProcessoImportarDadosTabelaBensPrincipal;
            blnAbortarThreadImportarDadosTabelaBensPrincipal = true;
            blnForcarAbortarThreadImportarDadosTabelaBensPrincipal = true;
        }

        private static object LockImportarDadosTabelaBensPrincipal = new object();

        private void mtdRotinaThreadImportarDadosTabelaBensPrincipal()
        {
            while (true)
            {
                if (!blnAbortarThreadImportarDadosTabelaBensPrincipal)
                {
                    //System.Threading.Monitor.Enter(LockImportarDadosTabelaBensPrincipal);
                    lock (LockImportarDadosTabelaBensPrincipal)
                    {
                        try
                        {
                            mtdRotinaImportarDadosTabelaBensPrincipal
                                (
                                blnComandoImplementadoDeletarDadosTabelaBensEletronortePrincipal,
                                blnComandoImplementadoInserirDadosTabelaBensEletronortePrincipal
                                );
                            mtdRotinaImportarDadosTabelaCentroCustoPrincipal
                                (
                                blnComandoImplementadoDeletarDadosTabelaCentroCustoPrincipal,
                                blnComandoImplementadoInserirDadosTabelaCentroCustoPrincipal
                                );
                            mtdAbortarThreadImportarDadosTabelaBensPrincipal(true);
                            mtdAbortarThreadImportarDadosTabelaCentroCustoPrincipal(true);
                        }
                        finally
                        {
                            //System.Threading.Monitor.Exit(LockImportarDadosTabelaBensPrincipal);
                        }
                    }
                }

                System.Threading.Thread.Sleep(1);
            }
        }

        private void mtdRotinaImportarDadosTabelaBensPrincipal()
        {
            mtdRotinaImportarDadosTabelaBensPrincipal(true, true);
        }
        private void mtdRotinaImportarDadosTabelaBensPrincipal(bool Deletar, bool Inserir)
        {
            if (blnAbortarThreadImportarDadosTabelaBensPrincipal && blnForcarAbortarThreadImportarDadosTabelaBensPrincipal) return;
            if (blnAbortarThreadPreparacaoPrincipal && blnForcarAbortarThreadPreparacaoPrincipal) return;

            if (Deletar)
            {
                mtdDeletarTabelaBensEletronortePrincipal();
                mtdDeletarDadosTabelaBensEletronortePrincipal();
            }
            mtdCriarTabelaBensEletronortePrincipal();
            if (Inserir)
            {
                mtdInserirDadosTabelaBensEletronortePrincipal();
            }
        }

        public bool blnComandoImplementadoDeletarDadosTabelaBensEletronortePrincipal = true;

        public void mtdDeletarTabelaBensEletronortePrincipal()
        {
            if (blnAbortarThreadImportarDadosTabelaBensPrincipal && blnForcarAbortarThreadImportarDadosTabelaBensPrincipal) return;
            if (blnAbortarThreadPreparacaoPrincipal && blnForcarAbortarThreadPreparacaoPrincipal) return;

            string BancoDados = "Principal";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

            objImplementacaoBancoDados.mtdDeletarTabela(Default.strTabelaBensEletronorte);
            objImplementacaoBancoDados.Dispose();
            objImplementacaoBancoDados.Dispose();
        }

        private string strColunaPrincipal = "Imobilizado";

        public void mtdDeletarDadosTabelaBensEletronortePrincipal()
        {
            if (blnAbortarThreadImportarDadosTabelaBensPrincipal && blnForcarAbortarThreadImportarDadosTabelaBensPrincipal) return;
            if (blnAbortarThreadPreparacaoPrincipal && blnForcarAbortarThreadPreparacaoPrincipal) return;

            string BancoDados = "Principal";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

            objImplementacaoBancoDados.mtdDeletarDados(Default.strTabelaBensEletronorte, strColunaPrincipal, "LIKE", "'%'");
            objImplementacaoBancoDados.Dispose();
        }

        private int colTabelaBensPrincipal = 1;
        private int linTabelaBensPrincipal = 0;
        private int intcolunaTabelaBensPrincipal = 0;

        private string[][] camposTabelaBensEletronortePrincipal;

        private string[] vetLinhaTextoTabelaBensEletronortePrincipal;

        public void mtdCriarTabelaBensEletronortePrincipal()
        {
            if (blnAbortarThreadImportarDadosTabelaBensPrincipal && blnForcarAbortarThreadImportarDadosTabelaBensPrincipal) return;
            if (blnAbortarThreadPreparacaoPrincipal && blnForcarAbortarThreadPreparacaoPrincipal) return;

            string BancoDados = "Principal";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

            intcolunaTabelaBensPrincipal = Default.intColunaTabelaBensEletronortePrincipalOrgao;

            camposTabelaBensEletronortePrincipal = new string[intcolunaTabelaBensPrincipal + 1][];
            camposTabelaBensEletronortePrincipal[0] = new string[4] 
            {
                "Imobilizado",
                "TEXT",
                "255",
                string.Empty
            };
            camposTabelaBensEletronortePrincipal[1] = new string[4] 
            {
		        "Patrimonio",
		        "INTEGER",
		        string.Empty,
                "CONSTRAINT PrimaryKeyPatrimonio PRIMARY KEY"
            	};
            camposTabelaBensEletronortePrincipal[2] = new string[4] 
            {
		        "Denominacao",
		        "TEXT",
		        "255",
		        string.Empty
	        };
            camposTabelaBensEletronortePrincipal[3] = new string[4] 
            {
		        "Denominacao_Extra",
		        "TEXT",
		        "255",
		        string.Empty
	        };
            camposTabelaBensEletronortePrincipal[4] = new string[4]
            {
		        "N_Serie",
		        "TEXT",
		        "255",
		        string.Empty
	        };
            camposTabelaBensEletronortePrincipal[5] = new string[4]
            {
		        "Sala",
		        "TEXT",
		        "255",
		        string.Empty
	        };
            camposTabelaBensEletronortePrincipal[6] = new string[4] 
            {
		        "Matricula",
		        "INTEGER",
		        string.Empty,
		        string.Empty
	        };
            camposTabelaBensEletronortePrincipal[7] = new string[4] 
            {
		        "Centro_Custo",
		        "INTEGER",
		        string.Empty,
		        string.Empty
	        };
            camposTabelaBensEletronortePrincipal[8] = new string[4] 
            {
		        "Atividade",
		        "TEXT",
		        "255",
		        string.Empty
	        };
            camposTabelaBensEletronortePrincipal[9] = new string[4] 
            {
		        "Orgao",
		        "TEXT",
		        "255",
		        string.Empty
	        };

            objImplementacaoBancoDados.mtdCriarTabela(Default.strTabelaBensEletronorte, camposTabelaBensEletronortePrincipal);
            objImplementacaoBancoDados.Dispose();
        }

        public bool blnComandoImplementadoInserirDadosTabelaBensEletronortePrincipal = true;

        private void mtdInserirDadosTabelaBensEletronortePrincipal()
        {
            if (blnAbortarThreadImportarDadosTabelaBensPrincipal && blnForcarAbortarThreadImportarDadosTabelaBensPrincipal) return;
            if (blnAbortarThreadPreparacaoPrincipal && blnForcarAbortarThreadPreparacaoPrincipal) return;

            string BancoDados = "Principal";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

            string strTabelaAuxiliaresTermoResponsabilidadeGeralPrincipal = "tblTabelasAuxiliaresTermoResponsabilidadeGeral";
            string strTabelaAuxiliaresFiltroImportacaoPrincipal = "tblTabelasAuxiliaresFiltroImportacao";

            int count = 0;

            objImplementacaoBancoDados.mtdSelecionarDados("*", strTabelaAuxiliaresFiltroImportacaoPrincipal);
            int intNumeroLinhasFiltroImportacao = objImplementacaoBancoDados.mtdNumeroLinhas();
            string[] vetFiltroImportacao = new string[intNumeroLinhasFiltroImportacao];

            objImplementacaoBancoDados.mtdDefinirLeitorDados();

            while (objImplementacaoBancoDados.mtdProximoRegistro())
            {
                if (blnAbortarThreadImportarDadosTabelaBensPrincipal && blnForcarAbortarThreadImportarDadosTabelaBensPrincipal) return;
                if (blnAbortarThreadPreparacaoPrincipal && blnForcarAbortarThreadPreparacaoPrincipal) return;

                vetFiltroImportacao[count] = objImplementacaoBancoDados.mtdObterValorRegistro(0).ToString();
                count += 1;
            }

            count = 0;

            objImplementacaoBancoDados.mtdSelecionarDados("*", strTabelaAuxiliaresTermoResponsabilidadeGeralPrincipal);
            int intNumeroLinhasTermoResponsabilidadeGeral = objImplementacaoBancoDados.mtdNumeroLinhas();
            string[] vetTermoResponsabilidadeGeral = new string[intNumeroLinhasTermoResponsabilidadeGeral];

            objImplementacaoBancoDados.mtdDefinirLeitorDados();

            while (objImplementacaoBancoDados.mtdProximoRegistro())
            {
                if (blnAbortarThreadImportarDadosTabelaBensPrincipal && blnForcarAbortarThreadImportarDadosTabelaBensPrincipal) return;
                if (blnAbortarThreadPreparacaoPrincipal && blnForcarAbortarThreadPreparacaoPrincipal) return;

                vetTermoResponsabilidadeGeral[count] = objImplementacaoBancoDados.mtdObterValorRegistro(0).ToString().Length == 1 ? string.Format("000{0}", objImplementacaoBancoDados.mtdObterValorRegistro(0)) : string.Format("00{0}", objImplementacaoBancoDados.mtdObterValorRegistro(0));
                count += 1;
            }

            intProgresso = 0;
            strNomeProcesso = strNomeProcessoImportarDadosTabelaBensPrincipal;

            string[][] dados = new string[2][];
            dados[0] = new string[intcolunaTabelaBensPrincipal + 1];
            dados[0][Default.intColunaTabelaBensEletronortePrincipalImobilizado] = camposTabelaBensEletronortePrincipal[0][Default.intColunaTabelaBensEletronortePrincipalImobilizado];

            clsManipuladorTexto objManipuladorTexto = new clsManipuladorTexto();
            clsArquivoTXT objArquivoTXT = new clsArquivoTXT();
            int numLinhaArquivoTXT = 0;

            objArquivoTXT.mtdAbrirLeitorTexto(Default.strArquivoTexto);

            int intNumMaxLinha = int.MaxValue;

            while ((!objArquivoTXT.getFimArquivo))
            {
                if (blnAbortarThreadImportarDadosTabelaBensPrincipal && blnForcarAbortarThreadImportarDadosTabelaBensPrincipal) return;
                if (blnAbortarThreadPreparacaoPrincipal && blnForcarAbortarThreadPreparacaoPrincipal) return;

                numLinhaArquivoTXT += 1;

                if (numLinhaArquivoTXT <= 10)
                {
                    string strConteudo = string.Empty;
                    string strLinha = objArquivoTXT.mtdLeitorTextoLinha();

                    if (strLinha.Contains("Registros selecionados:"))
                    {
                        for (int contador = 0; contador <= strLinha.Length - 1; contador += 1)
                        {
                            if (!(Convert.ToInt32(strLinha[contador]) == Convert.ToInt32(':')))
                            {
                                try
                                {
                                    strConteudo = strLinha.Split(':')[1];
                                    intNumMaxLinha = Int32.Parse(strConteudo.Trim());
                                    numLinhaArquivoTXT = intNumMaxLinha;
                                    break; // TODO: might not be correct. Was : Exit While
                                }
                                catch (System.Exception ex)
                                {
                                }
                            }
                        }
                    }
                }

                System.Threading.Thread.Sleep(1);
            }

            objArquivoTXT.prpLeitorTexto.Close();

            string strLinhaTexto = string.Empty;
            //Dim blnVerificado As Boolean = False
            for (int coluna = camposTabelaBensEletronortePrincipal.GetLowerBound(0); coluna <= camposTabelaBensEletronortePrincipal.GetUpperBound(0); coluna += 1)
            {
                if (blnAbortarThreadImportarDadosTabelaBensPrincipal && blnForcarAbortarThreadImportarDadosTabelaBensPrincipal) return;
                if (blnAbortarThreadPreparacaoPrincipal && blnForcarAbortarThreadPreparacaoPrincipal) return;

                dados[0][coluna] = camposTabelaBensEletronortePrincipal[coluna][Default.intColunaTabelaBensEletronortePrincipalImobilizado];
            }

            objArquivoTXT.mtdAbrirLeitorTexto();

            while ((!objArquivoTXT.getFimArquivo))
            {
                if (blnAbortarThreadImportarDadosTabelaBensPrincipal && blnForcarAbortarThreadImportarDadosTabelaBensPrincipal) return;
                if (blnAbortarThreadPreparacaoPrincipal && blnForcarAbortarThreadPreparacaoPrincipal) return;

                vetLinhaTextoTabelaBensEletronortePrincipal = null;
                strLinhaTexto = objArquivoTXT.prpLeitorTexto.ReadLine();
                //If Not blnVerificado Then
                //    If (strLinhaTexto.Contains(String.Format("|{0} |", strColuna))) Then
                //        vetLinhaTextoTabelaBensEletronortePrincipal = New String(intcoluna) {}
                //        vetLinhaTextoTabelaBensEletronortePrincipal = strLinhaTexto.Split("|"c)
                //        blnVerificado = True
                //    End If
                //End If

                bool blnContemFiltroImportacao = true;
                for (count = vetFiltroImportacao.GetLowerBound(0); count <= vetFiltroImportacao.GetUpperBound(0); count += 1)
                {
                    blnContemFiltroImportacao = blnContemFiltroImportacao & strLinhaTexto.Contains(vetFiltroImportacao[count]);
                }

                bool blnContemTermoResponsabilidadeGeral = false;
                for (count = vetTermoResponsabilidadeGeral.GetLowerBound(0); count <= vetTermoResponsabilidadeGeral.GetUpperBound(0); count += 1)
                {
                    blnContemTermoResponsabilidadeGeral = blnContemTermoResponsabilidadeGeral | strLinhaTexto.Contains(vetTermoResponsabilidadeGeral[count]);
                }

                if ((blnContemFiltroImportacao & blnContemTermoResponsabilidadeGeral))
                {
                    vetLinhaTextoTabelaBensEletronortePrincipal = new string[intcolunaTabelaBensPrincipal + 1];
                    vetLinhaTextoTabelaBensEletronortePrincipal = strLinhaTexto.Split('|');
                }

                if ((vetLinhaTextoTabelaBensEletronortePrincipal != null))
                {
                    dados[1] = new string[intcolunaTabelaBensPrincipal + 1];
                    colTabelaBensPrincipal = 0;
                    for (int coluna = vetLinhaTextoTabelaBensEletronortePrincipal.GetLowerBound(0); coluna <= vetLinhaTextoTabelaBensEletronortePrincipal.GetUpperBound(0); coluna += 1)
                    {
                        if (blnAbortarThreadImportarDadosTabelaBensPrincipal && blnForcarAbortarThreadImportarDadosTabelaBensPrincipal) return;
                        if (blnAbortarThreadPreparacaoPrincipal && blnForcarAbortarThreadPreparacaoPrincipal) return;

                        if (colTabelaBensPrincipal == Default.intColunaTabelaBensEletronortePrincipalAtividade)
                        {
                            dados[1][colTabelaBensPrincipal] = string.Format("'{0}'", strModoCapitalizacao);
                            colTabelaBensPrincipal += 1;
                        }

                        switch (coluna)
                        {
                            case 1:
                                dados[1][colTabelaBensPrincipal] = string.Format("{0}", objManipuladorTexto.mtdExecutarTudo(vetLinhaTextoTabelaBensEletronortePrincipal[coluna]));
                                colTabelaBensPrincipal += 1;
                                break;
                            case 2:
                            case 3:
                            case 4:
                            case 5:
                            case 8:
                            case 10:
                            case 11:
                            case 14:
                                dados[1][colTabelaBensPrincipal] = string.Format("'{0}'", objManipuladorTexto.mtdExecutarTudo(vetLinhaTextoTabelaBensEletronortePrincipal[coluna]));
                                colTabelaBensPrincipal += 1;
                                break;
                        }
                    }
                    objImplementacaoBancoDados.mtdFecharConexao();
                    objImplementacaoBancoDados.mtdInserirDados(Default.strTabelaBensEletronorte, dados);
                }

                intProgresso = mtdProgresso(linTabelaBensPrincipal, numLinhaArquivoTXT);
                strNomeProcesso = strNomeProcessoImportarDadosTabelaBensPrincipal;

                linTabelaBensPrincipal += 1;
            }

            intProgresso = 99;
            strNomeProcesso = strNomeProcessoImportarDadosTabelaBensPrincipal;

            objArquivoTXT.prpLeitorTexto.Close();
            objImplementacaoBancoDados.Dispose();
        }
    }
}