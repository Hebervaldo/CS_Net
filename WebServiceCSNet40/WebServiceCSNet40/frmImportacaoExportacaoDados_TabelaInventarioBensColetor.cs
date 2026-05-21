using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceCSNet40
{
    public partial class frmImportacaoExportacaoDados
    {
        private System.Threading.Thread ThreadTransferirDadosTabelaInventarioBensColetor;

        private string strNomeProcessoTransferirDadosTabelaInventarioBensColetor = "Transferência de dados - Inventário de Bens - Coletor";

        public void mtdIniciarThreadTransferirTabelaInventarioBensColetor()
        {
            mtdIniciarThreadTransferirTabelaInventarioBensColetor(true);
        }

        public void mtdIniciarThreadTransferirTabelaInventarioBensColetor(bool Iniciar)
        {
            try
            {
                intProgresso = 0;
                strNomeProcesso = strNomeProcessoTransferirDadosTabelaInventarioBensColetor;
                blnAbortarThreadTransferirDadosTabelaInventarioBensColetor = !Iniciar;
                blnForcarAbortarThreadTransferirDadosTabelaInventarioBensColetor = false;
                ThreadTransferirDadosTabelaInventarioBensColetor = new System.Threading.Thread
                    (
                    new System.Threading.ThreadStart
                        (
                        mtdRotinaThreadTransferirDadosTabelaInventarioBensColetor
                        )
                    );
                ThreadTransferirDadosTabelaInventarioBensColetor.IsBackground = true;
                ThreadTransferirDadosTabelaInventarioBensColetor.Priority = System.Threading.ThreadPriority.Normal;
                ThreadTransferirDadosTabelaInventarioBensColetor.Start();
            }
            catch (Exception ex)
            {
                string strExcecao = "mtdIniciarThreadTransferirTabelaInventarioBensColetor: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao); 
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        public void mtdReIniciarThreadTransferirTabelaInventarioBensColetor()
        {
            intProgresso = 0;
            strNomeProcesso = strNomeProcessoTransferirDadosTabelaInventarioBensColetor;
            blnAbortarThreadTransferirDadosTabelaInventarioBensColetor = false;
            blnForcarAbortarThreadTransferirDadosTabelaInventarioBensColetor = false;
        }

        private static bool blnForcarAbortarThreadTransferirDadosTabelaInventarioBensColetor = false;
        private static bool blnAbortarThreadTransferirDadosTabelaInventarioBensColetor = false;
        private static int intTempoSaidaAbortarThreadTransferirDadosTabelaInventarioBensColetor = 1000;

        public void mtdAbortarThreadTransferirDadosTabelaInventarioBensColetor()
        {
            mtdAbortarThreadTransferirDadosTabelaInventarioBensColetor(false);
        }

        public void mtdAbortarThreadTransferirDadosTabelaInventarioBensColetor(bool Forcar)
        {
            intProgresso = 100;
            System.Threading.Thread.Sleep(1000);
            intProgresso = 0;
            strNomeProcesso = strNomeProcessoTransferirDadosTabelaInventarioBensColetor;
            blnAbortarThreadTransferirDadosTabelaInventarioBensColetor = true;
            blnForcarAbortarThreadTransferirDadosTabelaInventarioBensColetor = Forcar;

            try
            {
                ThreadTransferirDadosTabelaInventarioBensColetor.Join(intTempoSaidaAbortarThreadTransferirDadosTabelaInventarioBensColetor);
                ThreadTransferirDadosTabelaInventarioBensColetor.Abort();
                ThreadTransferirDadosTabelaInventarioBensColetor = null;
            }
            catch (Exception ex)
            {
                string strExcecao = "mtdAbortarThreadTransferirDadosTabelaInventarioBensColetor: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        public void mtdPararThreadTransferirTabelaInventarioBensColetor()
        {
            intProgresso = 100;
            System.Threading.Thread.Sleep(1000);
            intProgresso = 0;
            strNomeProcesso = strNomeProcessoTransferirDadosTabelaInventarioBensColetor;
            blnAbortarThreadTransferirDadosTabelaInventarioBensColetor = true;
            blnForcarAbortarThreadTransferirDadosTabelaInventarioBensColetor = true;
        }

        private static object LockTransferirDadosTabelaInventarioBensColetor = new object();

        //private int intPassoPadraoUploadTabelaInventarioBensColetor = 0;

        private void mtdRotinaThreadTransferirDadosTabelaInventarioBensColetor()
        {
            while (true)
            {
                if (!blnAbortarThreadTransferirDadosTabelaInventarioBensColetor)
                {
                    //System.Threading.Monitor.Enter(LockTransferirDadosTabelaInventarioBensColetor);
                    lock (LockTransferirDadosTabelaInventarioBensColetor)
                    {
                        try
                        {
                            mtdRotinaTransferirDadosTabelaInventarioBensColetor
                                (
                                blnComandoImplementadoDeletarDadosTabelaInventarioBensColetor,
                                blnComandoImplementadoInserirDadosTabelaInventarioBensColetor
                                );

                            mtdAbortarThreadTransferirDadosTabelaInventarioBensColetor(true);
                        }
                        finally
                        {
                            //System.Threading.Monitor.Exit(LockTransferirDadosTabelaInventarioBensColetor);
                        }
                    }
                }

                System.Threading.Thread.Sleep(1);
            }
        }


        private void mtdRotinaTransferirDadosTabelaInventarioBensColetor()
        {
            mtdRotinaTransferirDadosTabelaInventarioBensColetor(true, true);
        }

        private void mtdRotinaTransferirDadosTabelaInventarioBensColetor(bool Deletar, bool Inserir)
        {
            if (blnAbortarThreadTransferirDadosTabelaInventarioBensColetor && blnForcarAbortarThreadTransferirDadosTabelaInventarioBensColetor) return;
            if (blnAbortarThreadPreparacaoColetorDados && blnForcarAbortarThreadPreparacaoColetorDados) return;

            if (Deletar)
            {
                mtdDeletarTabelaInventarioBensColetor();
                mtdDeletarDadosTabelaInventarioBensColetor();
            }
            mtdCriarTabelaInventarioBensColetor();
            if (Inserir)
            {
                mtdInserirDadosTabelaInventarioBensColetor();
            }
        }

        public bool blnComandoImplementadoDeletarDadosTabelaInventarioBensColetor = true;

        public void mtdDeletarTabelaInventarioBensColetor()
        {
            if (blnAbortarThreadTransferirDadosTabelaInventarioBensColetor && blnForcarAbortarThreadTransferirDadosTabelaInventarioBensColetor) return;
            if (blnAbortarThreadPreparacaoColetorDados && blnForcarAbortarThreadPreparacaoColetorDados) return;

            string BancoDadosColetor = "Coletor";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacionalColetor = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexaoColetor = Default.mtdDefinirStringConexao(BancoDadosColetor, ref TipoSistemaGerenciadorBancoDadosRelacionalColetor);
            clsImplementacaoBancoDados objBancoDadosColetor = new clsImplementacaoBancoDados(strConexaoColetor, TipoSistemaGerenciadorBancoDadosRelacionalColetor);

            objBancoDadosColetor.mtdDeletarTabela(Default.strTabelaInventarioBens);
            objBancoDadosColetor.Dispose();
        }

        public void mtdDeletarDadosTabelaInventarioBensColetor()
        {
            if (blnAbortarThreadTransferirDadosTabelaInventarioBensColetor && blnForcarAbortarThreadTransferirDadosTabelaInventarioBensColetor) return;
            if (blnAbortarThreadPreparacaoColetorDados && blnForcarAbortarThreadPreparacaoColetorDados) return;

            string BancoDadosColetor = "Coletor";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacionalColetor = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexaoColetor = Default.mtdDefinirStringConexao(BancoDadosColetor, ref TipoSistemaGerenciadorBancoDadosRelacionalColetor);
            clsImplementacaoBancoDados objBancoDadosColetor = new clsImplementacaoBancoDados(strConexaoColetor, TipoSistemaGerenciadorBancoDadosRelacionalColetor);

            objBancoDadosColetor.mtdDeletarDados(Default.strTabelaInventarioBens, Default.vetCamposTabelaInventarioBens[0], "LIKE", "'%'");
            objBancoDadosColetor.Dispose();
        }

        private int colTabelaInventarioBensColetor = 1;
        private int linTabelaInventarioBensColetor = 0;
        private int intcolunaTabelaInventarioBensColetor = 0;

        private string[][] camposTabelaInventarioBensColetor;

        public void mtdCriarTabelaInventarioBensColetor()
        {
            if (blnAbortarThreadTransferirDadosTabelaInventarioBensColetor && blnForcarAbortarThreadTransferirDadosTabelaInventarioBensColetor) return;
            if (blnAbortarThreadPreparacaoColetorDados && blnForcarAbortarThreadPreparacaoColetorDados) return;

            clsImplementacaoBancoDados objBancoDadosColetor = new clsImplementacaoBancoDados(Default.strTabelaInventarioBens, clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE);
            intcolunaTabelaInventarioBensColetor = 24;
            camposTabelaInventarioBensColetor = new string[intcolunaTabelaInventarioBensColetor + 1][];
            camposTabelaInventarioBensColetor[0] = new string[4]
            {
                "Numero_Inventario",
                "LONG",
                string.Empty,
                "CONSTRAINT PrimaryKeyNumero_Inventario PRIMARY KEY"
            };
            camposTabelaInventarioBensColetor[1] = new string[4] 
            {
                "Data_Inventario",
                "DATETIME",
                string.Empty,
                string.Empty
            };
            camposTabelaInventarioBensColetor[2] = new string[4]
            {
                "TRG",
                "NVARCHAR",
                "255",
                string.Empty
            };
            camposTabelaInventarioBensColetor[3] = new string[4]
            {
		        "CentroCusto",
		        "NVARCHAR",
		        "255",
		        string.Empty
            };
            camposTabelaInventarioBensColetor[4] = new string[4] 
            {
		        "Orgao",
		        "NVARCHAR",
		        "255",
		        string.Empty
        	};
            camposTabelaInventarioBensColetor[5] = new string[4]
            {
		        "Sala",
		        "NVARCHAR",
		        "255",
		        string.Empty
	        };
            camposTabelaInventarioBensColetor[6] = new string[4]
            {
		        "Nome",
		        "NVARCHAR",
		        "255",
		        string.Empty
	        };
            camposTabelaInventarioBensColetor[7] = new string[4]
            {
		        "Matricula",
		        "NVARCHAR",
		        "255",
		        string.Empty
	        };
            camposTabelaInventarioBensColetor[8] = new string[4]
            {
		        "Patrimonio",
		        "NVARCHAR",
		        "255",
		        string.Empty
	        };
            camposTabelaInventarioBensColetor[9] = new string[4] 
            {
		        "Quantidade",
		        "BIGINT",
		        string.Empty,
		        string.Empty
            };
            camposTabelaInventarioBensColetor[10] = new string[4] 
            {
		        "Denominacao",
		        "NVARCHAR",
		        "255",
		        string.Empty
	        };
            camposTabelaInventarioBensColetor[11] = new string[4]
            {
		        "N_Serie",
		        "NVARCHAR",
		        "255",
		        string.Empty
	        };
            camposTabelaInventarioBensColetor[12] = new string[4]
            {
		        "Placa_Veiculo",
		        "NVARCHAR",
		        "255",
		        string.Empty
	        };
            camposTabelaInventarioBensColetor[13] = new string[4]
            {
		        "Identificacao_Inventario",
		        "NVARCHAR",
		        "255",
		        string.Empty
	        };
            camposTabelaInventarioBensColetor[14] = new string[4]
            {
		        "OutrosDados_Inventario",
		        "NVARCHAR",
		        "255",
		        string.Empty
	        };
            camposTabelaInventarioBensColetor[15] = new string[4] 
            {
		        "Observacao",
		        "NVARCHAR",
		        "255",
		        string.Empty
	        };
            camposTabelaInventarioBensColetor[16] = new string[4] 
            {
		        "Coletor",
		        "NVARCHAR",
		        "255",
		        string.Empty
	        };
            camposTabelaInventarioBensColetor[17] = new string[4] 
            {
		        "Usuario_Inventariante",
		        "NVARCHAR",
		        "255",
		        string.Empty
	        };
            camposTabelaInventarioBensColetor[18] = new string[4] 
            {
		        "Matricula_Inventariante",
		        "NVARCHAR",
		        "255",
		        string.Empty
	        };
            camposTabelaInventarioBensColetor[19] = new string[4] 
            {
		        "Inventario",
		        "NVARCHAR",
		        "255",
		        "FOREIGN KEY NOT NULL"
	        };
            camposTabelaInventarioBensColetor[20] = new string[4] 
            {
		        "Fotografia",
		        "IMAGE",
		        string.Empty,
		        string.Empty
	        };
            camposTabelaInventarioBensColetor[21] = new string[4] 
            {
		        "GPS_Latitute",
		        "NVARCHAR",
		        "255",
		        string.Empty
	        };
            camposTabelaInventarioBensColetor[22] = new string[4]
            {
		        "GPS_Longitude",
		        "NVARCHAR",
		        "255",
		        string.Empty
	        };
            camposTabelaInventarioBensColetor[23] = new string[4] 
            {
		        "GPS_EllipsoidAltitude",
		        "NVARCHAR",
		        "255",
		        string.Empty
	        };
            camposTabelaInventarioBensColetor[24] = new string[4] 
            {
		        "GPS_PositionDilutionOfPrecision",
		        "NVARCHAR",
		        "255",
		        string.Empty
	        };

            objBancoDadosColetor.mtdCriarTabela(Default.strTabelaInventarioBens, camposTabelaInventarioBensColetor);

            objBancoDadosColetor.Dispose();
        }

        public bool blnComandoImplementadoInserirDadosTabelaInventarioBensColetor = true;

        private void mtdInserirDadosTabelaInventarioBensColetor()
        {
            if (blnAbortarThreadTransferirDadosTabelaInventarioBensColetor && blnForcarAbortarThreadTransferirDadosTabelaInventarioBensColetor) return;
            if (blnAbortarThreadPreparacaoColetorDados && blnForcarAbortarThreadPreparacaoColetorDados) return;

            string BancoDadosPrincipal = "Principal";
            string BancoDadosColetor = "Coletor";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacionalPrincipal = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexaoPrincipal = Default.mtdDefinirStringConexao(BancoDadosPrincipal, ref TipoSistemaGerenciadorBancoDadosRelacionalPrincipal);
            clsImplementacaoBancoDados objBancoDadosPrincipal = new clsImplementacaoBancoDados(strConexaoPrincipal, TipoSistemaGerenciadorBancoDadosRelacionalPrincipal);

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacionalColetor = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexaoColetor = Default.mtdDefinirStringConexao(BancoDadosColetor, ref TipoSistemaGerenciadorBancoDadosRelacionalColetor);
            clsImplementacaoBancoDados objBancoDadosColetor = new clsImplementacaoBancoDados(strConexaoColetor, TipoSistemaGerenciadorBancoDadosRelacionalColetor);

            //objBancoDadosPrincipal.mtdAbrirConexao(frmPrincipal.strConexaoBancoDadosPrincipal)

            objBancoDadosPrincipal.mtdSelecionarDados("*", Default.strTabelaInventarioBens, Default.vetCamposTabelaInventarioBens[0], true);

            int NumeroLinha = objBancoDadosPrincipal.mtdNumeroLinhas();

            objBancoDadosPrincipal.mtdDefinirLeitorDados();

            int NumeroColuna = objBancoDadosPrincipal.mtdNumeroColunas();
            intProgresso = 0;
            strNomeProcesso = strNomeProcessoTransferirDadosTabelaInventarioBensColetor;

            object[][] dados = new object[2][];

            dados[0] = objBancoDadosPrincipal.mtdObterCabecalhoColunas();

            object[][] dadosP = new object[2][];

            dadosP[0] = dados[0];
            dadosP[1] = new object[dados[0].GetUpperBound(0) + 1];
            int count = 1;
            while (objBancoDadosPrincipal.mtdProximoRegistro())
            {
                if (blnAbortarThreadTransferirDadosTabelaInventarioBensColetor && blnForcarAbortarThreadTransferirDadosTabelaInventarioBensColetor) return;
                if (blnAbortarThreadPreparacaoColetorDados && blnForcarAbortarThreadPreparacaoColetorDados) return;

                objBancoDadosColetor.prpComandoSQLServerCE.Parameters.Clear();
                for (int contador = 0; contador <= NumeroColuna - 1; contador += 1)
                {
                    switch (contador)
                    {
                        case 0:
                            dadosP[1][contador] = Default.mtdGerarProximoNumeroCodigo(BancoDadosColetor, Default.strTabelaInventarioBens, Default.vetCamposTabelaInventarioBens[Default.intColunaTabelaInventarioBensNumero_Inventario]);
                            break;
                        default:
                            dadosP[1][contador] = objBancoDadosPrincipal.mtdObterValorRegistro(contador);
                            break;
                    }
                }

                object objRegistroExisteTabelaInventarioBensColetor = null;

                if (!blnComandoImplementadoDeletarDadosTabelaInventarioBensColetor)
                {
                    objRegistroExisteTabelaInventarioBensColetor = Default.mtdSelecionarTabelaInventarioBens(BancoDadosColetor, string.Format("{0}", dadosP[0][15]), string.Format("'{0}'", dadosP[1][15]));
                }

                for (int contador = dadosP[0].GetLowerBound(0); contador <= dadosP[0].GetUpperBound(0); contador += 1)
                {
                    switch ((contador))
                    {
                        case 0:
                            if (!blnComandoImplementadoDeletarDadosTabelaInventarioBensColetor & objRegistroExisteTabelaInventarioBensColetor != null)
                            {
                                dadosP[1][contador] = objRegistroExisteTabelaInventarioBensColetor;
                            }
                            objBancoDadosColetor.mtdExecutarParametroComandoSQLServerCE(dadosP[0][contador].ToString(), dadosP[1][contador]);
                            break;
                        case 1:
                            objBancoDadosColetor.mtdExecutarParametroComandoSQLServerCE(dadosP[0][contador].ToString(), System.Data.SqlDbType.DateTime, dadosP[1][contador]);
                            break;
                        default:
                            objBancoDadosColetor.mtdExecutarParametroComandoSQLServerCE(dadosP[0][contador].ToString(), dadosP[1][contador]);
                            break;
                    }
                }

                if (!blnComandoImplementadoDeletarDadosTabelaInventarioBensColetor & objRegistroExisteTabelaInventarioBensColetor != null)
                {
                    long lngCodigoEspalhamentoColetor = Default.mtdCalcularCodigoEspalhamento(BancoDadosColetor, Default.strTabelaInventarioBens, Default.vetCamposTabelaInventarioBens[Default.intColunaTabelaInventarioBensInventario], string.Format("{0}", dadosP[1][Default.intColunaTabelaInventarioBensInventario]));
                    long lngCodigoEspalhamentoPrincipal = Default.mtdCalcularCodigoEspalhamento(BancoDadosPrincipal, Default.strTabelaInventarioBens, Default.vetCamposTabelaInventarioBens[Default.intColunaTabelaInventarioBensInventario], string.Format("{0}", dadosP[1][Default.intColunaTabelaInventarioBensInventario]));

                    if (!(lngCodigoEspalhamentoColetor == lngCodigoEspalhamentoPrincipal))
                    {
                        if (
                            Default.mtdVerificarDataMaisAtualTabelaInventarioBensColetorPrincipal
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
                            objBancoDadosColetor.mtdAtualizarDados(Default.strTabelaInventarioBens, dados);
                        }
                    }
                }
                else
                {
                    dados[1] = objBancoDadosPrincipal.mtdObterCabecalhoColunas();
                    for (int contador = dados[0].GetLowerBound(0); contador <= dados[0].GetUpperBound(0); contador += 1)
                    {
                        dados[1][contador] = string.Format("@{0}", dados[0][contador].ToString());
                    }

                    objBancoDadosColetor.mtdInserirDados(Default.strTabelaInventarioBens, dados);
                }

                intProgresso = mtdProgresso(count, NumeroLinha);
                strNomeProcesso = strNomeProcessoTransferirDadosTabelaInventarioBensColetor;
                count += 1;
            }

            intProgresso = 99;
            strNomeProcesso = strNomeProcessoTransferirDadosTabelaInventarioBensColetor;

            objBancoDadosPrincipal.Dispose(); objBancoDadosColetor.Dispose();
        }
    }
}