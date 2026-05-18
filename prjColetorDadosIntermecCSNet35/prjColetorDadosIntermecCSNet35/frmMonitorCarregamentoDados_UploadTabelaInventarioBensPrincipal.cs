using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace prjColetorDadosIntermecCSNet35
{
    public partial class frmMonitorCarregamentoDados
    {
        private void SetValueUploadTabelaInventarioBensPrincipal(int ProgressoUploadTabelaInventarioBensPrincipal, long IteracoesUploadTabelaInventarioBensPrincipal)
        {
            if (ProgressoUploadTabelaInventarioBensPrincipal >= 0 & ProgressoUploadTabelaInventarioBensPrincipal <= 100)
            {
                prgUploadTabelaInventarioBens.Value = ProgressoUploadTabelaInventarioBensPrincipal;
                lblProgressoUploadTabelaInventarioBens.Text = string.Format
                    (
                    "Pr.: {0}% - Iter.: {1} - Seg.: {2}/{3}.",
                    ProgressoUploadTabelaInventarioBensPrincipal,
                    IteracoesUploadTabelaInventarioBensPrincipal,
                    lngSegmentoUploadTabelaInventarioBensPrincipal,
                    lngMaxSegmentoUploadTabelaInventarioBensPrincipal - 1
                    );
            }
        }

        private void SetValueIntermediarioUploadTabelaInventarioBensPrincipal(int ObterLinhaTabelaInventarioBens, int ObterLinhaTotalTabelaInventarioBens)
        {
            int intProgressoIntermediarioUploadTabelaInventarioBensPrincipal = System.Convert.ToInt32(intObterLinhaTotalTabelaInventarioBens != 0 ? ((100 * intObterLinhaTabelaInventarioBens) / intObterLinhaTotalTabelaInventarioBens) : 0);

            if (intProgressoIntermediarioUploadTabelaInventarioBensPrincipal >= 0 & intProgressoIntermediarioUploadTabelaInventarioBensPrincipal <= 100)
            {
                prgIntermediarioUploadTabelaInventarioBens.Value = intProgressoIntermediarioUploadTabelaInventarioBensPrincipal;
                this.lblIntermediarioUploadTabelaInventarioBens.Text = string.Format
                    (
                    "N.: {0} - T.: {1} - P.: {2}% - Ac.: {3} - Is.: {4} - At.: {5} - In.: {6} - S.: {7}.",
                    intObterLinhaTabelaInventarioBens,
                    intObterLinhaTotalTabelaInventarioBens,
                    intProgressoIntermediarioUploadTabelaInventarioBensPrincipal,
                    intObterLinhaAcumuladoTotalTabelaInventarioBens,
                    intObterNumeroItensInseridos,
                    intObterNumeroItensAtualizados,
                    intObterNumeroItensInalterados,
                    intObterNumeroItensInseridos + intObterNumeroItensAtualizados + intObterNumeroItensInalterados
                    );
            }
        }

        public void mtdIniciarThreadUploadTabelaInventarioBensPrincipal()
        {
            mtdIniciarThreadUploadTabelaInventarioBensPrincipal(true);
        }

        public void mtdIniciarThreadUploadTabelaInventarioBensPrincipal(bool Iniciar)
        {
            try
            {
                blnAbortarThreadUploadTabelaInventarioBensPrincipal = !Iniciar;
                blnForcarAbortarThreadUploadTabelaInventarioBensPrincipal = false;
                intProgressoUploadTabelaInventarioBensPrincipal = 0;

                blnThreadAtivadaUploadTabelaInventarioBensPrincipal = true;
                blnSucessoUploadTabelaInventarioBensPrincipal = false;

                ThUploadTabelaInventarioBensPrincipal = new System.Threading.Thread
                    (
                    new System.Threading.ThreadStart
                        (
                        mtdRotinaThreadUploadTabelaInventarioBensPrincipal
                        )
                    );
                ThUploadTabelaInventarioBensPrincipal.IsBackground = true;
                ThUploadTabelaInventarioBensPrincipal.Priority = System.Threading.ThreadPriority.Normal;
                ThUploadTabelaInventarioBensPrincipal.Start();
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdIniciarThreadUploadTabelaInventarioBensPrincipal: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        public void mtdReIniciarThreadUploadTabelaInventarioBensPrincipal()
        {
            blnAbortarThreadUploadTabelaInventarioBensPrincipal = false;
            blnForcarAbortarThreadUploadTabelaInventarioBensPrincipal = false;
            intProgressoUploadTabelaInventarioBensPrincipal = 0;

            blnThreadAtivadaUploadTabelaInventarioBensPrincipal = true;
            blnSucessoUploadTabelaInventarioBensPrincipal = false;
        }

        private static bool blnForcarAbortarThreadUploadTabelaInventarioBensPrincipal = false;
        private static bool blnAbortarThreadUploadTabelaInventarioBensPrincipal = false;
        private static int intTempoSaidaAbortarThreadUploadTabelaInventarioBensPrincipal = 1000;

        public void mtdAbortarThreadUploadTabelaInventarioBensPrincipal()
        {
            mtdAbortarThreadUploadTabelaInventarioBensPrincipal(false);
        }

        public void mtdAbortarThreadUploadTabelaInventarioBensPrincipal(bool Forcar)
        {
            blnAbortarThreadUploadTabelaInventarioBensPrincipal = true;
            blnForcarAbortarThreadUploadTabelaInventarioBensPrincipal = Forcar;
            intProgressoUploadTabelaInventarioBensPrincipal = 100;

            blnThreadAtivadaUploadTabelaInventarioBensPrincipal = false;
            blnSucessoUploadTabelaInventarioBensPrincipal = false;

            try
            {
                ThUploadTabelaInventarioBensPrincipal.Join(intTempoSaidaAbortarThreadUploadTabelaInventarioBensPrincipal);
                ThUploadTabelaInventarioBensPrincipal.Abort();
                ThUploadTabelaInventarioBensPrincipal = null;
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdAbortarThreadUploadTabelaInventarioBensPrincipal: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }

            System.Threading.Thread.Sleep(1);
            intProgressoUploadTabelaInventarioBensPrincipal = 0;
        }

        public void mtdPararThreadUploadTabelaInventarioBensPrincipal()
        {
            blnAbortarThreadUploadTabelaInventarioBensPrincipal = true;
            blnForcarAbortarThreadUploadTabelaInventarioBensPrincipal = true;
            intProgressoUploadTabelaInventarioBensPrincipal = 100;

            blnThreadAtivadaUploadTabelaInventarioBensPrincipal = false;
            blnSucessoUploadTabelaInventarioBensPrincipal = false;

            System.Threading.Thread.Sleep(1);
            intProgressoUploadTabelaInventarioBensPrincipal = 0;
        }

        private static object LockerUploadTabelaInventarioBensPrincipal = new object();

        private void mtdRotinaThreadUploadTabelaInventarioBensPrincipal()
        {
            while (true)
            {
                if (!blnAbortarThreadUploadTabelaInventarioBensPrincipal)
                {
                    lock (LockerUploadTabelaInventarioBensPrincipal)
                    {
                        //System.Threading.Monitor.Enter(LockerUploadTabelaInventarioBensPrincipal);
                        try
                        {
                            mtdUploadTabelaInventarioBensPrincipal();
                            //System.Threading.Thread.Sleep(1);
                            //mtdAbortarThreadUploadTabelaInventarioBensPrincipal(true);
                            //mtdPararThreadUploadTabelaInventarioBensPrincipal();
                        }
                        finally
                        {
                            //System.Threading.Monitor.Exit(LockerUploadTabelaInventarioBensPrincipal);
                        }
                    }
                }

                System.Threading.Thread.Sleep(1);
            }
        }

        private int intProgressoUploadTabelaInventarioBensPrincipal = 0;
        private long lngIteracoesUploadTabelaInventarioBensPrincipal = 0;
        private int intObterLinhaTabelaInventarioBens = 0;
        private int intObterLinhaTotalTabelaInventarioBens = 0;
        private int intObterLinhaAcumuladoTotalTabelaInventarioBens = 0;
        private int intObterNumeroItensInseridos = 0;
        private int intObterNumeroItensAtualizados = 0;
        private int intObterNumeroItensInalterados = 0;
        private bool blnThreadAtivadaUploadTabelaInventarioBensPrincipal = false;
        private bool blnSucessoUploadTabelaInventarioBensPrincipal = false;
        private long lngMaxLinhaUploadTabelaInventarioBensPrincipal = 0;
        private long lngSegmentoUploadTabelaInventarioBensPrincipal = 0;
        private long lngMaxSegmentoUploadTabelaInventarioBensPrincipal = 0;
        //private long lngMaxLinhaUploadWTabelaInventarioBensPrincipal = 0;
        private long lngMinCodigoUploadTabelaInventarioBensMobile = 0;
        private long lngMaxCodigoUploadTabelaInventarioBensMobile = 0;
        private string strIP = string.Empty;

        private System.Data.DataSet AjustadorDadosUploadTabelaInventarioBensPrincipal;

        private System.DateTime dtmInicioUploadTabelaInventarioBensPrincipal = System.DateTime.Now;
        private System.DateTime dtmParcialUploadTabelaInventarioBensPrincipal = System.DateTime.Now;
        private double dblTempoRestanteMilisegundosUploadTabelaInventarioBensPrincipal = 0;
        //private double dblTempoRestanteMilisegundosIntermediarioUploadTabelaInventarioBensPrincipal = 0;

        private bool blnComandoImplementadoUploadTabelaInventarioBensPrincipal = true;

        private bool blnMtdComandoUploadTabelaInventarioBensPrincipal = false;

        private void mtdComandoUploadTabelaInventarioBensPrincipal(string CampoSelecionador, string DadoSelecionador)
        {
            blnMtdComandoUploadTabelaInventarioBensPrincipal = false;

            while (!blnMtdComandoUploadTabelaInventarioBensPrincipal)
            {
                try
                {
                    wb.mtdResetarGerarProximoNumeroCodigoOtimizado();
                }
                catch (System.Exception ex)
                {
                    string strExcecao = "mtdComandoUploadTabelaInventarioBensPrincipal: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                    //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                }

                mtdGerarPasso(ref intPassoUploadTabelaInventarioBensPrincipal, blnMtdComandoUploadTabelaInventarioBensPrincipal);

                //    mtdObterNumeroIdentificacao();

                string BancoDados = "Coletor";
                string WbBancoDados = "Principal";

                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
                string strConexao = mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
                clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

                try
                {
                    dtmInicioUploadTabelaInventarioBensPrincipal = System.DateTime.Now;

                    string Tabela = frmPrincipal.strTabelaInventarioBens;
                    string Campo = frmPrincipal.vetCamposTabelaInventarioBens[frmPrincipal.intColunaTabelaInventarioBensNumero_Inventario];

                    bool blnPermitirUploadWTabelaInventarioBensPrincipal = true;

                    intProgressoUploadTabelaInventarioBensPrincipal = 0;

                    //lngMaxLinhaUploadWTabelaInventarioBensPrincipal = wb.mtdObterNumeroLinhas
                    //    (
                    //    WbBancoDados,
                    //    Tabela,
                    //    Campo,
                    //    "%"
                    //    );

                    //if (blnForcarUploadUploadTabela)
                    //{
                    //    blnPermitirUploadWTabelaInventarioBensPrincipal = true;
                    //}
                    //else
                    //{
                    //    lngMaxLinhaUploadWTabelaInventarioBensPrincipal = wb.mtdObterNumeroLinhas
                    //        (
                    //        WbBancoDados,
                    //        Tabela,
                    //        Campo,
                    //        "%"
                    //        );
                    //    lngMaxLinhaUploadabelaInventarioBensPrincipal = mtdObterNumeroLinhas
                    //        (
                    //        BancoDados,
                    //        Tabela,
                    //        Campo,
                    //        "%"
                    //        );
                    //    if
                    //      (
                    //      lngMaxLinhaUploadWTabelaInventarioBensPrincipal
                    //      !=
                    //      lngMaxLinhaUploadTabelaInventarioBensPrincipal
                    //      )
                    //    {
                    //        blnPermitirUploadWTabelaInventarioBensPrincipal = true;
                    //    }
                    //    else
                    //    {
                    //        if (blnIgnorarCodigoEspalhamentoTabela)
                    //        {
                    //            blnPermitirUploadWTabelaInventarioBensPrincipal = true;
                    //        }
                    //        else
                    //        {
                    //            long lng1 = wb.mtdCalcularCodigoEspalhamentoTabelaInventarioBens
                    //                (
                    //                WbBancoDados,
                    //                Campo,
                    //                "%"
                    //                );
                    //            long lng2 = mtdCalcularCodigoEspalhamentoTabelaInventarioBens
                    //                (
                    //                BancoDados,
                    //                Campo,
                    //                "%"
                    //                );

                    //            if
                    //                (
                    //                lng1 != lng2
                    //                )
                    //            {
                    //                blnPermitirUploadWTabelaInventarioBensPrincipal = true;
                    //            }
                    //            else
                    //            {
                    //                blnPermitirUploadWTabelaInventarioBensPrincipal = false;
                    //            }
                    //        }
                    //    }
                    //}

                    if (blnPermitirUploadWTabelaInventarioBensPrincipal)
                    {
                        //blnComandoImplementadoUploadTabelaInventarioBensPrincipal = objImplementacaoBancoDados.mtdSelecionarDados
                        //    (
                        //     0,
                        //     objImplementacaoBancoDados.mtdVetorLinhaCampos(frmPrincipal.vetCamposTabelaInventarioBens),
                        //     frmPrincipal.strTabelaInventarioBens,
                        //     frmPrincipal.vetCamposTabelaInventarioBens[frmPrincipal.intColunaTabelaInventarioBensNumero_Inventario],
                        //     "LIKE",
                        //     "'%'"
                        //     );

                        blnComandoImplementadoUploadTabelaInventarioBensPrincipal = objImplementacaoBancoDados.mtdSelecionarDados
                            (
                             0,
                             objImplementacaoBancoDados.mtdVetorLinhaCampos(frmPrincipal.vetCamposTabelaInventarioBens),
                             frmPrincipal.strTabelaInventarioBens,
                             CampoSelecionador,
                             "LIKE",
                             string.Format("{0}", DadoSelecionador)
                             );

                        objImplementacaoBancoDados.mtdAdaptadorDados();
                        System.Data.DataSet AjustadorDados = objImplementacaoBancoDados.prpAjustadorDados;

                        lngMinCodigoUploadTabelaInventarioBensMobile = 0;
                        lngMaxCodigoUploadTabelaInventarioBensMobile = 0;
                        lngMaxCodigoUploadTabelaInventarioBensMobile += intPassoUploadTabelaInventarioBensPrincipal;
                        lngMaxLinhaUploadTabelaInventarioBensPrincipal = objImplementacaoBancoDados.mtdNumeroLinhas();
                        lngSegmentoUploadTabelaInventarioBensPrincipal = 0;
                        lngMaxSegmentoUploadTabelaInventarioBensPrincipal = (System.Convert.ToInt64(lngMaxLinhaUploadTabelaInventarioBensPrincipal / intPassoUploadTabelaInventarioBensPrincipal) + 1);
                        //AjustadorDadosUploadTabelaInventarioBensPrincipal = null;

                        blnComandoImplementadoUploadTabelaInventarioBensPrincipal = objImplementacaoBancoDados.mtdDefinirLeitorDados();

                        if (!blnComandoImplementadoUploadTabelaInventarioBensPrincipal) goto SaidaUploadTabelaInventarioBensPrincipal;

                        int linha = (int)lngMinCodigoUploadTabelaInventarioBensMobile;

                        AjustadorDadosUploadTabelaInventarioBensPrincipal = new System.Data.DataSet();
                        AjustadorDadosUploadTabelaInventarioBensPrincipal.Tables.Add(AjustadorDados.Tables[0].Clone());

                        while (objImplementacaoBancoDados.mtdProximoRegistro())
                        {
                            try
                            {
                                System.GC.Collect();
                            }
                            catch (System.Exception ex)
                            {
                                string strExcecao = "mtdComandoUploadTabelaInventarioBensPrincipal: " + ex.Message;
                                System.Diagnostics.Debug.WriteLine(strExcecao);
                                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                            }
                            System.Threading.Thread.Sleep(1);
                            if (blnAbortarThreadUploadTabelaInventarioBensPrincipal & blnForcarAbortarThreadUploadTabelaInventarioBensPrincipal) goto SaidaUploadTabelaInventarioBensPrincipal;

                            AjustadorDadosUploadTabelaInventarioBensPrincipal.Tables[0].Rows.Add(objImplementacaoBancoDados.mtdObterValorRegistro());

                            objImplementacaoBancoDados.prpAdaptadorDadosSQLServerCE = null;

                            if (System.Convert.ToInt32(linha * 100 / lngMaxLinhaUploadTabelaInventarioBensPrincipal) <= 100)
                            {
                                intProgressoUploadTabelaInventarioBensPrincipal = System.Convert.ToInt32(linha * 100 / lngMaxLinhaUploadTabelaInventarioBensPrincipal);
                            }
                            else
                            {
                                intProgressoUploadTabelaInventarioBensPrincipal = 100;
                            }

                            dtmParcialUploadTabelaInventarioBensPrincipal = System.DateTime.Now;
                            if (linha != 0)
                            {
                                dblTempoRestanteMilisegundosUploadTabelaInventarioBensPrincipal = ((double)(dtmParcialUploadTabelaInventarioBensPrincipal - dtmInicioUploadTabelaInventarioBensPrincipal).TotalMilliseconds * ((double)(lngMaxLinhaUploadTabelaInventarioBensPrincipal / (double)linha) - 1));
                            }

                            System.Diagnostics.Debug.WriteLine(string.Format("mtdUploadTabelaInventarioBensPrincipal: {0}", intProgressoUploadTabelaInventarioBensPrincipal));

                            blnSucessoUploadTabelaInventarioBensPrincipal = true;

                            if (linha == lngMaxCodigoUploadTabelaInventarioBensMobile - 1 | linha == lngMaxLinhaUploadTabelaInventarioBensPrincipal - 1)
                            {
                                //mtdObterNumeroIdentificacao(false);

                                wb.setTabelaInventarioBens(WbBancoDados, AjustadorDadosUploadTabelaInventarioBensPrincipal, intNumeroIdentificacao);

                                try
                                {
                                    //wb.Abort();
                                }
                                catch (System.Exception ex)
                                {
                                    string strExcecao = "mtdComandoUploadTabelaInventarioBensPrincipal: " + ex.Message;
                                    System.Diagnostics.Debug.WriteLine(strExcecao);
                                    //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                                }

                                lngMinCodigoUploadTabelaInventarioBensMobile = lngMaxCodigoUploadTabelaInventarioBensMobile;
                                lngMaxCodigoUploadTabelaInventarioBensMobile += intPassoUploadTabelaInventarioBensPrincipal;

                                linha = (int)lngMinCodigoUploadTabelaInventarioBensMobile;

                                AjustadorDadosUploadTabelaInventarioBensPrincipal = new System.Data.DataSet();
                                AjustadorDadosUploadTabelaInventarioBensPrincipal.Tables.Add(AjustadorDados.Tables[0].Clone());
                                lngSegmentoUploadTabelaInventarioBensPrincipal++;
                                lngMaxSegmentoUploadTabelaInventarioBensPrincipal = (System.Convert.ToInt64(lngMaxLinhaUploadTabelaInventarioBensPrincipal / intPassoUploadTabelaInventarioBensPrincipal) + 1);
                            }
                            else
                            {
                                linha++;
                            }

                            try
                            {
                                System.GC.Collect();
                            }
                            catch (System.Exception ex)
                            {
                                string strExcecao = "mtdComandoUploadTabelaInventarioBensPrincipal: " + ex.Message;
                                System.Diagnostics.Debug.WriteLine(strExcecao);
                                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                            }
                            System.Threading.Thread.Sleep(1);
                        }

                        intProgressoUploadTabelaInventarioBensPrincipal = 100;

                        dblTempoRestanteMilisegundosUploadTabelaInventarioBensPrincipal = 0;

                        blnSucessoUploadTabelaInventarioBensPrincipal = true;

                        lngIteracoesUploadTabelaInventarioBensPrincipal++;
                    }

                    blnMtdComandoUploadTabelaInventarioBensPrincipal = true;
                }
                catch (System.Exception ex)
                {
                    string strExcecao = string.Empty;

                    try
                    {
                        System.GC.Collect();
                    }
                    catch (System.Exception ex_)
                    {
                        strExcecao = "mtdComandoUploadTabelaInventarioBensPrincipal: " + ex_.Message;
                        System.Diagnostics.Debug.WriteLine(strExcecao);
                        //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                    }

                    blnSucessoUploadTabelaInventarioBensPrincipal = false;
                    strExcecao = "mtdUploadTabelaInventarioBensPrincipal: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                    //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);

                    blnMtdComandoUploadTabelaInventarioBensPrincipal = false;
                }
                finally
                {
                }

            SaidaUploadTabelaInventarioBensPrincipal:

                objImplementacaoBancoDados.Dispose();

                System.Threading.Thread.Sleep(1);
            }
        }

        private string CampoSelecionador = string.Empty;
        private string DadoSelecionador = string.Empty;

        private int intlsv = 0;
        private bool[] blnvetlsv;
        private string[] strvetlsv;
        private string[] strvetlsvsi;

        private void mtdUploadTabelaInventarioBensPrincipal()
        {
            int numLinha = 0;
            string[] vetNumeroItens = new string[intlsv];
            string[] vetNumeroItensTotal;

            for (int linha = 0; linha <= intlsv - 1; linha++)
            {
                if (blnvetlsv[linha])
                {
                    vetNumeroItens[linha] = strvetlsv[linha];
                    numLinha++;
                }
                else
                {
                    vetNumeroItens[linha] = string.Empty;
                }
            }

            vetNumeroItensTotal = new string[numLinha];

            int contador = 0;
            for (int linha = 0; linha <= intlsv - 1; linha++)
            {
                if (blnvetlsv[linha])
                {
                    vetNumeroItensTotal[contador] = vetNumeroItens[linha];
                    contador++;
                }
            }

            int intNumeroItensTotal = 0;

            try
            {
                intNumeroItensTotal = vetNumeroItensTotal.Length;
            }
            catch (System.Exception ex)
            {
                intNumeroItensTotal = 0;

                string strExcecao = "mtdUploadTabelaInventarioBensPrincipal: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }

            if (intNumeroItensTotal > 0)
            {
                for (int contadorGeral = vetNumeroItensTotal.GetLowerBound(0); contadorGeral <= vetNumeroItensTotal.GetUpperBound(0); contadorGeral++)
                {
                    CampoSelecionador = CampoSelecionador != string.Empty ? CampoSelecionador : frmPrincipal.vetCamposTabelaInventarioBens[frmPrincipal.intColunaTabelaInventarioBensInventario];
                    DadoSelecionador = vetNumeroItensTotal[contadorGeral] != string.Empty ? string.Format("'%{0}%'", vetNumeroItensTotal[contadorGeral]) : "''";

                    mtdComandoUploadTabelaInventarioBensPrincipal(CampoSelecionador, DadoSelecionador);
                }
            }
            else
            {
                CampoSelecionador = frmPrincipal.vetCamposTabelaInventarioBens[frmPrincipal.intColunaTabelaInventarioBensInventario];
                DadoSelecionador = "'%'";

                mtdComandoUploadTabelaInventarioBensPrincipal(CampoSelecionador, DadoSelecionador);
            }

            if (blnForcarDesligamento)
            {
                //clsShutdownDevice.mtdForcePowerOff();
                mtdIniciarThreadTemporizadorForcarDesligamento();
            }

            if (!blnIteracoesContinuas)
            {
                mtdAbortarThreadUploadTabelaInventarioBensPrincipal(true);
            }

            //mtdAbortarThreadManterCanalAberto();
        }
    }
}