using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceCSNet40
{
    public partial class frmImportacaoExportacaoDados
    {
        private System.Threading.Thread ThreadTransferirDadosTabelaInventarioBensPrincipal;

        private string strNomeProcessoTransferirDadosTabelaInventarioBensPrincipal = "Transferência de dados - Inventário de Bens - Principal";

        public void mtdIniciarThreadTransferirTabelaInventarioBensPrincipal()
        {
            mtdIniciarThreadTransferirTabelaInventarioBensPrincipal(true);
        }

        public void mtdIniciarThreadTransferirTabelaInventarioBensPrincipal(bool Iniciar)
        {
            try
            {
                intProgresso = 0;
                strNomeProcesso = strNomeProcessoTransferirDadosTabelaInventarioBensPrincipal;
                blnAbortarThreadTransferirDadosTabelaInventarioBensPrincipal = !Iniciar;
                blnForcarAbortarThreadTransferirDadosTabelaInventarioBensPrincipal = false;
                ThreadTransferirDadosTabelaInventarioBensPrincipal = new System.Threading.Thread
                    (
                    new System.Threading.ThreadStart
                        (
                        mtdRotinaThreadTransferirDadosTabelaInventarioBensPrincipal
                        )
                    );
                ThreadTransferirDadosTabelaInventarioBensPrincipal.IsBackground = true;
                ThreadTransferirDadosTabelaInventarioBensPrincipal.Priority = System.Threading.ThreadPriority.Normal;
                ThreadTransferirDadosTabelaInventarioBensPrincipal.Start();
            }
            catch (Exception ex)
            {
                string strExcecao = "mtdIniciarThreadTransferirTabelaInventarioBensPrincipal: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        public void mtdReIniciarThreadTransferirTabelaInventarioBensPrincipal()
        {
            intProgresso = 0;
            strNomeProcesso = strNomeProcessoTransferirDadosTabelaInventarioBensPrincipal;
            blnAbortarThreadTransferirDadosTabelaInventarioBensPrincipal = false;
            blnForcarAbortarThreadTransferirDadosTabelaInventarioBensPrincipal = false;
        }

        private static bool blnForcarAbortarThreadTransferirDadosTabelaInventarioBensPrincipal = false;
        private static bool blnAbortarThreadTransferirDadosTabelaInventarioBensPrincipal = false;
        private static int intTempoSaidaAbortarThreadTransferirDadosTabelaInventarioBensPrincipal = 1000;

        public void mtdAbortarThreadTransferirDadosTabelaInventarioBensPrincipal()
        {
            mtdAbortarThreadTransferirDadosTabelaInventarioBensPrincipal(false);
        }

        public void mtdAbortarThreadTransferirDadosTabelaInventarioBensPrincipal(bool Forcar)
        {
            intProgresso = 100;
            System.Threading.Thread.Sleep(1000);
            intProgresso = 0;
            strNomeProcesso = strNomeProcessoTransferirDadosTabelaInventarioBensPrincipal;
            blnAbortarThreadTransferirDadosTabelaInventarioBensPrincipal = true;
            blnForcarAbortarThreadTransferirDadosTabelaInventarioBensPrincipal = Forcar;

            try
            {
                ThreadTransferirDadosTabelaInventarioBensPrincipal.Join(intTempoSaidaAbortarThreadTransferirDadosTabelaInventarioBensPrincipal);
                ThreadTransferirDadosTabelaInventarioBensPrincipal.Abort();
                ThreadTransferirDadosTabelaInventarioBensPrincipal = null;
            }
            catch (Exception ex)
            {
                string strExcecao = "mtdAbortarThreadTransferirDadosTabelaInventarioBensPrincipal: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        public void mtdPararThreadTransferirTabelaInventarioBensPrincipal()
        {
            intProgresso = 100;
            System.Threading.Thread.Sleep(1000);
            intProgresso = 0;
            strNomeProcesso = strNomeProcessoTransferirDadosTabelaInventarioBensPrincipal;
            blnAbortarThreadTransferirDadosTabelaInventarioBensPrincipal = true;
            blnForcarAbortarThreadTransferirDadosTabelaInventarioBensPrincipal = true;
        }

        private static object LockTransferirDadosTabelaInventarioBensPrincipal = new object();

        //private int intPassoPadraoUploadTabelaInventarioBensPrincipal = 0;

        private void mtdRotinaThreadTransferirDadosTabelaInventarioBensPrincipal()
        {
            while (true)
            {
                if (!blnAbortarThreadTransferirDadosTabelaInventarioBensPrincipal)
                {
                    //System.Threading.Monitor.Enter(LockTransferirDadosTabelaInventarioBensPrincipal);
                    lock (LockTransferirDadosTabelaInventarioBensPrincipal)
                    {
                        try
                        {
                            mtdRotinaTransferirDadosTabelaInventarioBensPrincipal
                                (
                                blnComandoImplementadoDeletarDadosTabelaInventarioBensPrincipal,
                                blnComandoImplementadoInserirDadosTabelaInventarioBensPrincipal
                                );
                            mtdAbortarThreadTransferirDadosTabelaInventarioBensPrincipal(true);
                        }
                        finally
                        {
                            //System.Threading.Monitor.Exit(LockTransferirDadosTabelaInventarioBensPrincipal);
                        }
                    }
                }

                System.Threading.Thread.Sleep(1);
            }
        }

        private void mtdRotinaTransferirDadosTabelaInventarioBensPrincipal()
        {
            mtdRotinaTransferirDadosTabelaInventarioBensPrincipal(true, true);
        }

        private void mtdRotinaTransferirDadosTabelaInventarioBensPrincipal(bool Deletar, bool Inserir)
        {
            if (blnAbortarThreadTransferirDadosTabelaInventarioBensPrincipal && blnForcarAbortarThreadTransferirDadosTabelaInventarioBensPrincipal) return;
            if (blnAbortarThreadPreparacaoPrincipal && blnForcarAbortarThreadPreparacaoPrincipal) return;

            if (Deletar)
            {
                mtdDeletarTabelaInventarioBensPrincipal();
                mtdDeletarDadosTabelaInventarioBensPrincipal();
            }
            mtdCriarTabelaInventarioBensPrincipal();
            if (Inserir)
            {
                mtdInserirDadosTabelaInventarioBensPrincipal();
            }
        }

        public bool blnComandoImplementadoDeletarDadosTabelaInventarioBensPrincipal = true;

        public void mtdDeletarTabelaInventarioBensPrincipal()
        {
            if (blnAbortarThreadTransferirDadosTabelaInventarioBensPrincipal && blnForcarAbortarThreadTransferirDadosTabelaInventarioBensPrincipal) return;
            if (blnAbortarThreadPreparacaoPrincipal && blnForcarAbortarThreadPreparacaoPrincipal) return;

            string BancoDadosPrincipal = "Principal";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacionalPrincipal = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexaoPrincipal = Default.mtdDefinirStringConexao(BancoDadosPrincipal, ref TipoSistemaGerenciadorBancoDadosRelacionalPrincipal);
            clsImplementacaoBancoDados objBancoDadosPrincipal = new clsImplementacaoBancoDados(strConexaoPrincipal, TipoSistemaGerenciadorBancoDadosRelacionalPrincipal);

            objBancoDadosPrincipal.mtdDeletarTabela(Default.strTabelaInventarioBens);
            objBancoDadosPrincipal.Dispose();
        }

        public void mtdDeletarDadosTabelaInventarioBensPrincipal()
        {
            if (blnAbortarThreadTransferirDadosTabelaInventarioBensPrincipal && blnForcarAbortarThreadTransferirDadosTabelaInventarioBensPrincipal) return;
            if (blnAbortarThreadPreparacaoPrincipal && blnForcarAbortarThreadPreparacaoPrincipal) return;

            string BancoDadosPrincipal = "Principal";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacionalPrincipal = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexaoPrincipal = Default.mtdDefinirStringConexao(BancoDadosPrincipal, ref TipoSistemaGerenciadorBancoDadosRelacionalPrincipal);
            clsImplementacaoBancoDados objBancoDadosPrincipal = new clsImplementacaoBancoDados(strConexaoPrincipal, TipoSistemaGerenciadorBancoDadosRelacionalPrincipal);

            objBancoDadosPrincipal.mtdDeletarDados(Default.strTabelaInventarioBens, Default.vetCamposTabelaInventarioBens[0], "LIKE", "'%'");
            objBancoDadosPrincipal.Dispose();
        }

        private int colTabelaInventarioBensPrincipal = 1;
        private int linTabelaInventarioBensPrincipal = 0;
        private int intcolunaTabelaInventarioBensPrincipal = 0;

        private string[][] camposTabelaInventarioBensPrincipal;

        public void mtdCriarTabelaInventarioBensPrincipal()
        {
            if (blnAbortarThreadTransferirDadosTabelaInventarioBensPrincipal && blnForcarAbortarThreadTransferirDadosTabelaInventarioBensPrincipal) return;
            if (blnAbortarThreadPreparacaoPrincipal && blnForcarAbortarThreadPreparacaoPrincipal) return;

            string BancoDadosPrincipal = "Principal";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacionalPrincipal = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexaoPrincipal = Default.mtdDefinirStringConexao(BancoDadosPrincipal, ref TipoSistemaGerenciadorBancoDadosRelacionalPrincipal);
            clsImplementacaoBancoDados objBancoDadosPrincipal = new clsImplementacaoBancoDados(strConexaoPrincipal, TipoSistemaGerenciadorBancoDadosRelacionalPrincipal);

            intcolunaTabelaInventarioBensPrincipal = 24;

            camposTabelaInventarioBensPrincipal = new string[intcolunaTabelaInventarioBensPrincipal + 1][];
            camposTabelaInventarioBensPrincipal[0] = new string[4]
            {
                "Numero_Inventario",
                "LONG",
                string.Empty,
                "CONSTRAINT PrimaryKeyNumero_Inventario PRIMARY KEY"
            };
            camposTabelaInventarioBensPrincipal[1] = new string[4] 
            {
                "Data_Inventario",
                "DATETIME",
                string.Empty,
                string.Empty
            };
            camposTabelaInventarioBensPrincipal[2] = new string[4]
            {
                "TRG",
                "TEXT",
                "255",
                string.Empty
            };
            camposTabelaInventarioBensPrincipal[3] = new string[4]
            {
		        "CentroCusto",
		        "TEXT",
		        "255",
		        string.Empty
            };
            camposTabelaInventarioBensPrincipal[4] = new string[4] 
            {
		        "Orgao",
		        "TEXT",
		        "255",
		        string.Empty
        	};
            camposTabelaInventarioBensPrincipal[5] = new string[4]
            {
		        "Sala",
		        "TEXT",
		        "255",
		        string.Empty
	        };
            camposTabelaInventarioBensPrincipal[6] = new string[4]
            {
		        "Nome",
		        "TEXT",
		        "255",
		        string.Empty
	        };
            camposTabelaInventarioBensPrincipal[7] = new string[4]
            {
		        "Matricula",
		        "TEXT",
		        "255",
		        string.Empty
	        };
            camposTabelaInventarioBensPrincipal[8] = new string[4]
            {
		        "Patrimonio",
		        "TEXT",
		        "255",
		        string.Empty
	        };
            camposTabelaInventarioBensPrincipal[9] = new string[4] 
            {
		        "Quantidade",
		        "INTEGER",
		        string.Empty,
		        string.Empty
            };
            camposTabelaInventarioBensPrincipal[10] = new string[4] 
            {
		        "Denominacao",
		        "TEXT",
		        "255",
		        string.Empty
	        };
            camposTabelaInventarioBensPrincipal[11] = new string[4]
            {
		        "N_Serie",
		        "TEXT",
		        "255",
		        string.Empty
	        };
            camposTabelaInventarioBensPrincipal[12] = new string[4]
            {
		        "Placa_Veiculo",
		        "TEXT",
		        "255",
		        string.Empty
	        };
            camposTabelaInventarioBensPrincipal[13] = new string[4]
            {
		        "Identificacao_Inventario",
		        "TEXT",
		        "255",
		        string.Empty
	        };
            camposTabelaInventarioBensPrincipal[14] = new string[4]
            {
		        "OutrosDados_Inventario",
		        "TEXT",
		        "255",
		        string.Empty
	        };
            camposTabelaInventarioBensPrincipal[15] = new string[4] 
            {
		        "Observacao",
		        "TEXT",
		        "255",
		        string.Empty
	        };
            camposTabelaInventarioBensPrincipal[16] = new string[4] 
            {
		        "Coletor",
		        "TEXT",
		        "255",
		        string.Empty
	        };
            camposTabelaInventarioBensPrincipal[17] = new string[4] 
            {
		        "Usuario_Inventariante",
		        "TEXT",
		        "255",
		        string.Empty
	        };
            camposTabelaInventarioBensPrincipal[18] = new string[4] 
            {
		        "Matricula_Inventariante",
		        "TEXT",
		        "255",
		        string.Empty
	        };
            camposTabelaInventarioBensPrincipal[19] = new string[4] 
            {
		        "Inventario",
		        "TEXT",
		        "255",
		        " NOT NULL CONSTRAINT UniqueInventario UNIQUE"
	        };
            camposTabelaInventarioBensPrincipal[20] = new string[4] 
            {
		        "Fotografia",
		        "IMAGE",
		        string.Empty,
		        string.Empty
	        };
            camposTabelaInventarioBensPrincipal[21] = new string[4] 
            {
		        "GPS_Latitute",
		        "TEXT",
		        "255",
		        string.Empty
	        };
            camposTabelaInventarioBensPrincipal[22] = new string[4]
            {
		        "GPS_Longitude",
		        "TEXT",
		        "255",
		        string.Empty
	        };
            camposTabelaInventarioBensPrincipal[23] = new string[4] 
            {
		        "GPS_EllipsoidAltitude",
		        "TEXT",
		        "255",
		        string.Empty
	        };
            camposTabelaInventarioBensPrincipal[24] = new string[4] 
            {
		        "GPS_PositionDilutionOfPrecision",
		        "TEXT",
		        "255",
		        string.Empty
	        };

            objBancoDadosPrincipal.mtdCriarTabela(Default.strTabelaInventarioBens, camposTabelaInventarioBensPrincipal);
            objBancoDadosPrincipal.Dispose();
        }

        public bool blnComandoImplementadoInserirDadosTabelaInventarioBensPrincipal = true;

        private void mtdInserirDadosTabelaInventarioBensPrincipal()
        {
            if (blnAbortarThreadTransferirDadosTabelaInventarioBensPrincipal && blnForcarAbortarThreadTransferirDadosTabelaInventarioBensPrincipal) return;
            if (blnAbortarThreadPreparacaoPrincipal && blnForcarAbortarThreadPreparacaoPrincipal) return;

            string BancoDadosPrincipal = "Principal";
            string BancoDadosColetor = "Coletor";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacionalPrincipal = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexaoPrincipal = Default.mtdDefinirStringConexao(BancoDadosPrincipal, ref TipoSistemaGerenciadorBancoDadosRelacionalPrincipal);
            clsImplementacaoBancoDados objBancoDadosPrincipal = new clsImplementacaoBancoDados(strConexaoPrincipal, TipoSistemaGerenciadorBancoDadosRelacionalPrincipal);

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacionalColetor = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexaoColetor = Default.mtdDefinirStringConexao(BancoDadosColetor, ref TipoSistemaGerenciadorBancoDadosRelacionalColetor);
            clsImplementacaoBancoDados objBancoDadosColetor = new clsImplementacaoBancoDados(strConexaoColetor, TipoSistemaGerenciadorBancoDadosRelacionalColetor);

            //objBancoDadosColetor.mtdAbrirConexao(frmPrincipal.strConexaoBancoDadosColetor)
            objBancoDadosColetor.mtdSelecionarDados("*", Default.strTabelaInventarioBens, Default.vetCamposTabelaInventarioBens[0], true);

            int NumeroLinha = objBancoDadosColetor.mtdNumeroLinhas();

            objBancoDadosColetor.mtdDefinirLeitorDados();
            int NumeroColuna = objBancoDadosColetor.mtdNumeroColunas();

            intProgresso = 0;
            strNomeProcesso = strNomeProcessoTransferirDadosTabelaInventarioBensPrincipal;

            object[][] dados = new object[2][];
            dados[0] = objBancoDadosColetor.mtdObterCabecalhoColunas();

            object[][] dadosP = new object[2][];

            dadosP[0] = dados[0];
            dadosP[1] = new object[dados[0].GetUpperBound(0) + 1];

            int count = 1;

            while (objBancoDadosColetor.mtdProximoRegistro())
            {
                if (blnAbortarThreadTransferirDadosTabelaInventarioBensPrincipal && blnForcarAbortarThreadTransferirDadosTabelaInventarioBensPrincipal) return;
                if (blnAbortarThreadPreparacaoPrincipal && blnForcarAbortarThreadPreparacaoPrincipal) return;

                objBancoDadosPrincipal.prpComandoOleDb.Parameters.Clear();

                for (int contador = 0; contador <= NumeroColuna - 1; contador += 1)
                {
                    switch (contador)
                    {
                        case 0:
                            dadosP[1][contador] = Default.mtdGerarProximoNumeroCodigo(BancoDadosPrincipal, Default.strTabelaInventarioBens, Default.vetCamposTabelaInventarioBens[0]);
                            break;
                        default:
                            dadosP[1][contador] = objBancoDadosColetor.mtdObterValorRegistro(contador);
                            break;
                    }
                }

                object objRegistroExisteTabelaInventarioBensPrincipal = null;

                if (!blnComandoImplementadoDeletarDadosTabelaInventarioBensPrincipal)
                {
                    objRegistroExisteTabelaInventarioBensPrincipal = Default.mtdSelecionarTabelaInventarioBens(BancoDadosPrincipal, string.Format("{0}", dadosP[0][Default.intColunaTabelaInventarioBensInventario]), string.Format("'{0}'", dadosP[1][Default.intColunaTabelaInventarioBensInventario]));
                }

                for (int contador = dadosP[0].GetLowerBound(0); contador <= dadosP[0].GetUpperBound(0); contador += 1)
                {
                    switch ((contador))
                    {
                        case Default.intColunaTabelaInventarioBensNumero_Inventario:
                            if (!blnComandoImplementadoDeletarDadosTabelaInventarioBensPrincipal & objRegistroExisteTabelaInventarioBensPrincipal != null)
                            {
                                dadosP[1][contador] = objRegistroExisteTabelaInventarioBensPrincipal;
                            }
                            objBancoDadosPrincipal.mtdExecutarParametroComandoOleDb(dadosP[0][contador].ToString(), dadosP[1][contador]);
                            break;
                        case Default.intColunaTabelaInventarioBensData_Inventario:
                            objBancoDadosPrincipal.mtdExecutarParametroComandoOleDb(dadosP[0][contador].ToString(), System.Data.OleDb.OleDbType.Date, dadosP[1][contador]);
                            break;
                        default:
                            objBancoDadosPrincipal.mtdExecutarParametroComandoOleDb(dadosP[0][contador].ToString(), dadosP[1][contador]);
                            break;
                    }
                }

                if (!blnComandoImplementadoDeletarDadosTabelaInventarioBensPrincipal & objRegistroExisteTabelaInventarioBensPrincipal != null)
                {
                    long lngCodigoEspalhamentoPrincipal = Default.mtdCalcularCodigoEspalhamento(BancoDadosPrincipal, Default.strTabelaInventarioBens, Default.vetCamposTabelaInventarioBens[Default.intColunaTabelaInventarioBensInventario], string.Format("{0}", dadosP[1][Default.intColunaTabelaInventarioBensInventario]));
                    long lngCodigoEspalhamentoColetor = Default.mtdCalcularCodigoEspalhamento(BancoDadosColetor, Default.strTabelaInventarioBens, Default.vetCamposTabelaInventarioBens[Default.intColunaTabelaInventarioBensInventario], string.Format("{0}", dadosP[1][Default.intColunaTabelaInventarioBensInventario]));

                    if (!(lngCodigoEspalhamentoPrincipal == lngCodigoEspalhamentoColetor))
                    {
                        if (
                            Default.mtdVerificarDataMaisAtualTabelaInventarioBensPrincipalColetor
                            (
                            Default.intColunaTabelaInventarioBensData_Inventario,
                            Default.vetCamposTabelaInventarioBens[Default.intColunaTabelaInventarioBensInventario],
                            dados[2][Default.intColunaTabelaInventarioBensInventario]
                            )
                            )
                        {
                            dados[1] = new object[dados[0].GetUpperBound(0) + 0 + 4];

                            for (int contador = dados[0].GetLowerBound(0); contador <= dados[0].GetUpperBound(0); contador += 1)
                            {
                                dados[1][contador] = string.Format("@{0}", dados[0][contador].ToString());
                            }

                            dados[1][dados[0].GetUpperBound(0) + 1] = string.Format("{0}", dadosP[0][Default.intColunaTabelaInventarioBensInventario]);
                            dados[1][dados[0].GetUpperBound(0) + 2] = string.Format("{0}", "LIKE");
                            dados[1][dados[0].GetUpperBound(0) + 3] = string.Format("'{0}'", dadosP[1][Default.intColunaTabelaInventarioBensInventario]);

                            objBancoDadosPrincipal.mtdAtualizarDados(Default.strTabelaInventarioBens, dados);
                        }
                    }
                }
                else
                {
                    dados[1] = objBancoDadosColetor.mtdObterCabecalhoColunas();

                    for (int contador = dados[0].GetLowerBound(0); contador <= dados[0].GetUpperBound(0); contador += 1)
                    {
                        dados[1][contador] = string.Format("@{0}", dados[0][contador].ToString());
                    }

                    objBancoDadosPrincipal.mtdInserirDados(Default.strTabelaInventarioBens, dados);
                }

                intProgresso = mtdProgresso(count, NumeroLinha);
                strNomeProcesso = strNomeProcessoTransferirDadosTabelaInventarioBensPrincipal;
                count += 1;
            }

            intProgresso = 99;
            strNomeProcesso = strNomeProcessoTransferirDadosTabelaInventarioBensPrincipal;

            objBancoDadosPrincipal.Dispose();
            objBancoDadosColetor.Dispose();
        }
    }
}