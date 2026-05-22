using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceCSNet40
{
    public partial class frmImportacaoExportacaoDados
    {
        private System.Threading.Thread ThreadImportarDadosTabelaBensColetor;

        private string strNomeProcessoImportarDadosTabelaBensColetor = "Importação de dados - Bens - Centro de Custo - Coletor";

        public void mtdIniciarThreadDownloadTabelaInventarioBensColetor()
        {
            mtdIniciarThreadDownloadTabelaInventarioBensColetor(true);
        }

        public void mtdIniciarThreadDownloadTabelaInventarioBensColetor(bool Iniciar)
        {
            try
            {
                intProgresso = 0;
                strNomeProcesso = strNomeProcessoImportarDadosTabelaBensColetor;
                blnAbortarThreadImportarDadosTabelaBensColetor = !Iniciar;
                blnForcarAbortarThreadImportarDadosTabelaBensColetor = false;
                ThreadImportarDadosTabelaBensColetor = new System.Threading.Thread
                    (
                    new System.Threading.ThreadStart
                        (
                        mtdRotinaThreadImportarDadosTabelaBensColetor
                        )
                    );
                ThreadImportarDadosTabelaBensColetor.IsBackground = true;
                ThreadImportarDadosTabelaBensColetor.Priority = System.Threading.ThreadPriority.Normal;
                ThreadImportarDadosTabelaBensColetor.Start();
            }
            catch (Exception ex)
            {
                string strExcecao = "mtdIniciarThreadDownloadTabelaInventarioBensColetor: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        public void mtdReIniciarThreadDownloadTabelaInventarioBensColetor()
        {
            intProgresso = 0;
            strNomeProcesso = strNomeProcessoImportarDadosTabelaBensColetor;
            blnAbortarThreadImportarDadosTabelaBensColetor = false;
            blnForcarAbortarThreadImportarDadosTabelaBensColetor = false;
        }

        private static bool blnForcarAbortarThreadImportarDadosTabelaBensColetor = false;
        private static bool blnAbortarThreadImportarDadosTabelaBensColetor = false;
        private static int intTempoSaidaAbortarThreadImportarDadosTabelaBensColetor = 1000;

        public void mtdAbortarThreadImportarDadosTabelaBensColetor()
        {
            mtdAbortarThreadImportarDadosTabelaBensColetor(false);
        }

        public void mtdAbortarThreadImportarDadosTabelaBensColetor(bool Forcar)
        {
            intProgresso = 100;
            System.Threading.Thread.Sleep(1000);
            intProgresso = 0;
            strNomeProcesso = strNomeProcessoImportarDadosTabelaBensColetor;
            blnAbortarThreadImportarDadosTabelaBensColetor = true;
            blnForcarAbortarThreadImportarDadosTabelaBensColetor = Forcar;

            try
            {
                ThreadImportarDadosTabelaBensColetor.Join(intTempoSaidaAbortarThreadImportarDadosTabelaBensColetor);
                ThreadImportarDadosTabelaBensColetor.Abort();
                ThreadImportarDadosTabelaBensColetor = null;
            }
            catch (Exception ex)
            {
                string strExcecao = "mtdAbortarThreadImportarDadosTabelaBensColetor: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        public void mtdPararThreadDownloadTabelaInventarioBensColetor()
        {
            intProgresso = 100;
            System.Threading.Thread.Sleep(1000);
            intProgresso = 0;
            strNomeProcesso = strNomeProcessoImportarDadosTabelaBensColetor;
            blnAbortarThreadImportarDadosTabelaBensColetor = true;
            blnForcarAbortarThreadImportarDadosTabelaBensColetor = true;
        }

        private static object LockImportarDadosTabelaBensColetor = new object();

        private void mtdRotinaThreadImportarDadosTabelaBensColetor()
        {
            while (true)
            {
                if (!blnAbortarThreadImportarDadosTabelaBensColetor)
                {
                    //System.Threading.Monitor.Enter(LockImportarDadosTabelaBensColetor);
                    lock (LockImportarDadosTabelaBensColetor)
                    {
                        try
                        {
                            mtdRotinaImportarDadosTabelaBensColetor
                                (
                                blnComandoImplementadoDeletarDadosTabelaBensEletronorteColetor,
                                blnComandoImplementadoInserirDadosTabelaBensEletronorteColetor
                                );
                            mtdRotinaImportarDadosTabelaCentroCustoColetor
                                (
                                blnComandoImplementadoDeletarDadosTabelaCentroCustoColetor,
                                blnComandoImplementadoInserirDadosTabelaCentroCustoColetor
                                );
                            mtdAbortarThreadImportarDadosTabelaBensColetor(true);
                            mtdAbortarThreadImportarDadosTabelaCentroCustoColetor(true);
                        }
                        finally
                        {
                            //System.Threading.Monitor.Exit(LockImportarDadosTabelaBensColetor);
                        }
                    }
                }

                System.Threading.Thread.Sleep(1);
            }
        }

        public bool blnComandoImplementadoDeletarDadosTabelaBensEletronorteColetor = true;

        private void mtdRotinaImportarDadosTabelaBensColetor()
        {
            mtdRotinaImportarDadosTabelaBensColetor(true, true);
        }

        private void mtdRotinaImportarDadosTabelaBensColetor(bool Deletar, bool Inserir)
        {
            if (blnAbortarThreadImportarDadosTabelaBensColetor && blnForcarAbortarThreadImportarDadosTabelaBensColetor) return;
            if (blnAbortarThreadPreparacaoColetorDados && blnForcarAbortarThreadPreparacaoColetorDados) return;

            if (Deletar)
            {
                mtdDeletarTabelaBensEletronorteColetor();
                mtdDeletarDadosTabelaBensEletronorteColetor();
            }
            mtdCriarTabelaBensEletronorteColetor();
            if (Inserir)
            {
                mtdInserirDadosTabelaBensEletronorteColetor();
            }
        }

        public void mtdDeletarTabelaBensEletronorteColetor()
        {
            if (blnAbortarThreadImportarDadosTabelaBensColetor && blnForcarAbortarThreadImportarDadosTabelaBensColetor) return;
            if (blnAbortarThreadPreparacaoColetorDados && blnForcarAbortarThreadPreparacaoColetorDados) return;

            string BancoDados = "Coletor";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

            objImplementacaoBancoDados.mtdDeletarTabela(Default.strTabelaBensEletronorte);
            objImplementacaoBancoDados.Dispose();
        }

        private string strColunaColetor = "Imobilizado";

        public void mtdDeletarDadosTabelaBensEletronorteColetor()
        {
            if (blnAbortarThreadImportarDadosTabelaBensColetor && blnForcarAbortarThreadImportarDadosTabelaBensColetor) return;
            if (blnAbortarThreadPreparacaoColetorDados && blnForcarAbortarThreadPreparacaoColetorDados) return;

            string BancoDados = "Coletor";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

            objImplementacaoBancoDados.mtdDeletarDados(Default.strTabelaBensEletronorte, strColunaColetor, "LIKE", "'%'");
            objImplementacaoBancoDados.Dispose();
        }

        private int colTabelaBensColetor = 1;
        private int linTabelaBensColetor = 0;
        private int intcolunaTabelaBensColetor = 0;

        private string[][] camposTabelaBensEletronorteColetor;

        private string[] vetLinhaTextoTabelaBensEletronorteColetor;

        public void mtdCriarTabelaBensEletronorteColetor()
        {
            if (blnAbortarThreadImportarDadosTabelaBensColetor && blnForcarAbortarThreadImportarDadosTabelaBensColetor) return;
            if (blnAbortarThreadPreparacaoColetorDados && blnForcarAbortarThreadPreparacaoColetorDados) return;

            string BancoDados = "Coletor";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

            intcolunaTabelaBensColetor = 11;

            camposTabelaBensEletronorteColetor = new string[intcolunaTabelaBensColetor + 1][];
            camposTabelaBensEletronorteColetor[0] = new string[4] 
            {
                "Imobilizado",
                "NVARCHAR",
                "255",
                string.Empty
            };
            camposTabelaBensEletronorteColetor[1] = new string[4] 
            {
		        "Patrimonio",
		        "INTEGER",
		        string.Empty,
                "CONSTRAINT PrimaryKeyPatrimonio PRIMARY KEY"
            	};
            camposTabelaBensEletronorteColetor[2] = new string[4] 
            {
		        "Denominacao",
		        "NVARCHAR",
		        "255",
		        string.Empty
	        };
            camposTabelaBensEletronorteColetor[3] = new string[4] 
            {
		        "Denominacao_Extra",
		        "NVARCHAR",
		        "255",
		        string.Empty
	        };
            camposTabelaBensEletronorteColetor[4] = new string[4]
            {
		        "N_Serie",
		        "NVARCHAR",
		        "255",
		        string.Empty
	        };
            camposTabelaBensEletronorteColetor[5] = new string[4]
            {
		        "Sala",
		        "NVARCHAR",
		        "255",
		        string.Empty
	        };
            camposTabelaBensEletronorteColetor[6] = new string[4] 
            {
		        "Matricula",
		        "INTEGER",
		        string.Empty,
		        string.Empty
	        };
            camposTabelaBensEletronorteColetor[7] = new string[4] 
            {
		        "Centro_Custo",
		        "INTEGER",
		        string.Empty,
		        string.Empty
	        };
            camposTabelaBensEletronorteColetor[8] = new string[4] 
            {
		        "Atividade",
		        "NVARCHAR",
		        "255",
		        string.Empty
	        };
            camposTabelaBensEletronorteColetor[9] = new string[4] 
            {
		        "Orgao",
		        "NVARCHAR",
		        "255",
		        string.Empty
	        };
            camposTabelaBensEletronorteColetor[10] = new string[4] 
            {
		        "TRG",
		        "NVARCHAR",
		        "255",
		        string.Empty
	        };
            camposTabelaBensEletronorteColetor[11] = new string[4] 
            {
		        "Placa_Veiculo",
		        "NVARCHAR",
		        "255",
		        string.Empty
	        };

            objImplementacaoBancoDados.mtdCriarTabela(Default.strTabelaBensEletronorte, camposTabelaBensEletronorteColetor);
            objImplementacaoBancoDados.Dispose();
        }

        public bool blnComandoImplementadoInserirDadosTabelaBensEletronorteColetor = true;

        private void mtdInserirDadosTabelaBensEletronorteColetor()
        {
            if (blnAbortarThreadImportarDadosTabelaBensColetor && blnForcarAbortarThreadImportarDadosTabelaBensColetor) return;
            if (blnAbortarThreadPreparacaoColetorDados && blnForcarAbortarThreadPreparacaoColetorDados) return;

            string BancoDadosPrincipal = "Principal";
            string BancoDadosColetor = "Coletor";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacionalPrincipal = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexaoPrincipal = Default.mtdDefinirStringConexao(BancoDadosPrincipal, ref TipoSistemaGerenciadorBancoDadosRelacionalPrincipal);
            clsImplementacaoBancoDados objBancoDadosPrincipal = new clsImplementacaoBancoDados(strConexaoPrincipal, TipoSistemaGerenciadorBancoDadosRelacionalPrincipal);

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacionalColetor = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexaoColetor = Default.mtdDefinirStringConexao(BancoDadosColetor, ref TipoSistemaGerenciadorBancoDadosRelacionalColetor);
            clsImplementacaoBancoDados objBancoDadosColetor = new clsImplementacaoBancoDados(strConexaoColetor, TipoSistemaGerenciadorBancoDadosRelacionalColetor);

            string strTabelaAuxiliaresTermoResponsabilidadeGeralPrincipal = "tblTabelasAuxiliaresTermoResponsabilidadeGeral";
            string strTabelaAuxiliaresFiltroImportacaoPrincipal = "tblTabelasAuxiliaresFiltroImportacao";

            int count = 0;

            objBancoDadosPrincipal.mtdSelecionarDados("*", strTabelaAuxiliaresFiltroImportacaoPrincipal);
            int intNumeroLinhasFiltroImportacao = objBancoDadosPrincipal.mtdNumeroLinhas();
            string[] vetFiltroImportacao = new string[intNumeroLinhasFiltroImportacao];

            objBancoDadosPrincipal.mtdDefinirLeitorDados();

            while (objBancoDadosPrincipal.mtdProximoRegistro())
            {
                if (blnAbortarThreadImportarDadosTabelaBensColetor && blnForcarAbortarThreadImportarDadosTabelaBensColetor) return;
                if (blnAbortarThreadPreparacaoColetorDados && blnForcarAbortarThreadPreparacaoColetorDados) return;

                vetFiltroImportacao[count] = objBancoDadosPrincipal.mtdObterValorRegistro(0).ToString();
                count += 1;
            }

            count = 0;

            objBancoDadosPrincipal.mtdSelecionarDados("*", strTabelaAuxiliaresTermoResponsabilidadeGeralPrincipal);
            int intNumeroLinhasTermoResponsabilidadeGeral = objBancoDadosPrincipal.mtdNumeroLinhas();
            string[] vetTermoResponsabilidadeGeral = new string[intNumeroLinhasTermoResponsabilidadeGeral];

            objBancoDadosPrincipal.mtdDefinirLeitorDados();

            while (objBancoDadosPrincipal.mtdProximoRegistro())
            {
                if (blnAbortarThreadImportarDadosTabelaBensColetor && blnForcarAbortarThreadImportarDadosTabelaBensColetor) return;
                if (blnAbortarThreadPreparacaoColetorDados && blnForcarAbortarThreadPreparacaoColetorDados) return;

                vetTermoResponsabilidadeGeral[count] = objBancoDadosPrincipal.mtdObterValorRegistro(0).ToString().Length == 1 ? string.Format("000{0}", objBancoDadosPrincipal.mtdObterValorRegistro(0)) : string.Format("00{0}", objBancoDadosPrincipal.mtdObterValorRegistro(0));
                count += 1;
            }

            intProgresso = 0;
            strNomeProcesso = strNomeProcessoImportarDadosTabelaBensColetor;

            string[][] dados = new string[2][];
            dados[0] = new string[intcolunaTabelaBensColetor + 1];
            dados[0][0] = camposTabelaBensEletronorteColetor[0][0];

            clsManipuladorTexto objManipuladorTexto = new clsManipuladorTexto();
            clsArquivoTXT objArquivoTXT = new clsArquivoTXT();
            int numLinhaArquivoTXT = 0;

            objArquivoTXT.mtdAbrirLeitorTexto(Default.strArquivoTexto);
            
            int intNumMaxLinha = int.MaxValue;

            while ((!objArquivoTXT.getFimArquivo))
            {
                if (blnAbortarThreadImportarDadosTabelaBensColetor && blnForcarAbortarThreadImportarDadosTabelaBensColetor) return;
                if (blnAbortarThreadPreparacaoColetorDados && blnForcarAbortarThreadPreparacaoColetorDados) return;

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
            for (int coluna = camposTabelaBensEletronorteColetor.GetLowerBound(0); coluna <= camposTabelaBensEletronorteColetor.GetUpperBound(0); coluna += 1)
            {
                if (blnAbortarThreadImportarDadosTabelaBensColetor && blnForcarAbortarThreadImportarDadosTabelaBensColetor) return;
                if (blnAbortarThreadPreparacaoColetorDados && blnForcarAbortarThreadPreparacaoColetorDados) return;

                dados[0][coluna] = camposTabelaBensEletronorteColetor[coluna][0];
            }

            objArquivoTXT.mtdAbrirLeitorTexto();

            while ((!objArquivoTXT.getFimArquivo))
            {
                if (blnAbortarThreadImportarDadosTabelaBensColetor && blnForcarAbortarThreadImportarDadosTabelaBensColetor) return;
                if (blnAbortarThreadPreparacaoColetorDados && blnForcarAbortarThreadPreparacaoColetorDados) return;

                vetLinhaTextoTabelaBensEletronorteColetor = null;
                strLinhaTexto = objArquivoTXT.prpLeitorTexto.ReadLine();
                //If Not blnVerificado Then
                //    If (strLinhaTexto.Contains(String.Format("|{0} |", strColuna))) Then
                //        vetLinhaTextoTabelaBensEletronorteColetor = New String(intcoluna) {}
                //        vetLinhaTextoTabelaBensEletronorteColetor = strLinhaTexto.Split("|"c)
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
                    vetLinhaTextoTabelaBensEletronorteColetor = new string[intcolunaTabelaBensColetor + 1];
                    vetLinhaTextoTabelaBensEletronorteColetor = strLinhaTexto.Split('|');
                }

                if ((vetLinhaTextoTabelaBensEletronorteColetor != null))
                {
                    dados[1] = new string[intcolunaTabelaBensColetor + 1];
                    colTabelaBensColetor = 0;
                    for (int coluna = vetLinhaTextoTabelaBensEletronorteColetor.GetLowerBound(0); coluna <= vetLinhaTextoTabelaBensEletronorteColetor.GetUpperBound(0); coluna += 1)
                    {
                        if (blnAbortarThreadImportarDadosTabelaBensColetor && blnForcarAbortarThreadImportarDadosTabelaBensColetor) return;
                        if (blnAbortarThreadPreparacaoColetorDados && blnForcarAbortarThreadPreparacaoColetorDados) return;

                        if (colTabelaBensColetor == 8)
                        {
                            dados[1][colTabelaBensColetor] = string.Format("'{0}'", strModoCapitalizacao);
                            colTabelaBensColetor += 1;
                        }

                        switch (coluna)
                        {
                            case 1:
                                dados[1][0] = string.Format("{0}", objManipuladorTexto.mtdExecutarTudo(vetLinhaTextoTabelaBensEletronorteColetor[coluna]));
                                colTabelaBensColetor += 1;
                                break;
                            case 2:
                                dados[1][1] = string.Format("'{0}'", objManipuladorTexto.mtdExecutarTudo(vetLinhaTextoTabelaBensEletronorteColetor[coluna]));
                                colTabelaBensColetor += 1;
                                break;
                            case 3:
                                dados[1][2] = string.Format("'{0}'", objManipuladorTexto.mtdExecutarTudo(vetLinhaTextoTabelaBensEletronorteColetor[coluna]));
                                colTabelaBensColetor += 1;
                                break;
                            case 4:
                                dados[1][3] = string.Format("'{0}'", objManipuladorTexto.mtdExecutarTudo(vetLinhaTextoTabelaBensEletronorteColetor[coluna]));
                                colTabelaBensColetor += 1;
                                break;
                            case 5:
                                dados[1][4] = string.Format("'{0}'", objManipuladorTexto.mtdExecutarTudo(vetLinhaTextoTabelaBensEletronorteColetor[coluna]));
                                colTabelaBensColetor += 1;
                                break;
                            case 8:
                                dados[1][5] = string.Format("'{0}'", objManipuladorTexto.mtdExecutarTudo(vetLinhaTextoTabelaBensEletronorteColetor[coluna]));
                                colTabelaBensColetor += 1;
                                break;
                            case 10:
                                dados[1][6] = string.Format("'{0}'", objManipuladorTexto.mtdExecutarTudo(vetLinhaTextoTabelaBensEletronorteColetor[coluna]));
                                colTabelaBensColetor += 1;
                                break;
                            case 11:
                                dados[1][7] = string.Format("'{0}'", objManipuladorTexto.mtdExecutarTudo(vetLinhaTextoTabelaBensEletronorteColetor[coluna]));
                                colTabelaBensColetor += 1;
                                break;
                            case 14:
                                dados[1][9] = string.Format("'{0}'", objManipuladorTexto.mtdExecutarTudo(vetLinhaTextoTabelaBensEletronorteColetor[coluna]));
                                colTabelaBensColetor += 1;
                                break;
                            case 12:
                                dados[1][10] = string.Format("'{0}'", objManipuladorTexto.mtdExecutarTudo(vetLinhaTextoTabelaBensEletronorteColetor[coluna]));
                                colTabelaBensColetor += 1;
                                break;
                            case 9:
                                dados[1][11] = string.Format("'{0}'", objManipuladorTexto.mtdExecutarTudo(vetLinhaTextoTabelaBensEletronorteColetor[coluna]));
                                colTabelaBensColetor += 1;
                                break;
                        }
                    }
                    objBancoDadosPrincipal.mtdFecharConexao();
                    objBancoDadosColetor.mtdInserirDados(Default.strTabelaBensEletronorte, dados);
                }

                intProgresso = mtdProgresso(linTabelaBensColetor, numLinhaArquivoTXT);
                strNomeProcesso = strNomeProcessoImportarDadosTabelaBensColetor;

                linTabelaBensColetor += 1;
            }

            intProgresso = 99;
            strNomeProcesso = strNomeProcessoImportarDadosTabelaBensColetor;

            objArquivoTXT.prpLeitorTexto.Close();
            objBancoDadosPrincipal.Dispose();
            objBancoDadosColetor.Dispose();
        }
    }
}