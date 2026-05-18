using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace prjColetorDadosIntermecCSNet35
{
    public partial class frmMonitorCarregamentoDados
    {
        private void SetValueDownloadTabelaInventarioBensPrincipal(int ProgressoDownloadTabelaInventarioBensPrincipal, long IteracoesDownloadTabelaInventarioBensPrincipal)
        {
            if (ProgressoDownloadTabelaInventarioBensPrincipal >= 0 & ProgressoDownloadTabelaInventarioBensPrincipal <= 100)
            {
                prgDownloadTabelaInventarioBens.Value = ProgressoDownloadTabelaInventarioBensPrincipal;
                lblProgressoDownloadTabelaInventarioBens.Text = string.Format("Progresso: {0}% - Iterações: {1}", ProgressoDownloadTabelaInventarioBensPrincipal, IteracoesDownloadTabelaInventarioBensPrincipal);
            }
        }

        public void mtdIniciarThreadDownloadTabelaInventarioBensPrincipal()
        {
            mtdIniciarThreadDownloadTabelaInventarioBensPrincipal(true);
        }

        public void mtdIniciarThreadDownloadTabelaInventarioBensPrincipal(bool Iniciar)
        {
            try
            {
                blnAbortarThreadDownloadTabelaInventarioBensPrincipal = !Iniciar;
                blnForcarAbortarThreadDownloadTabelaInventarioBensPrincipal = false;
                intProgressoDownloadTabelaInventarioBensPrincipal = 0;

                blnThreadAtivadaDownloadTabelaInventarioBensPrincipal = true;
                blnSucessoDownloadTabelaInventarioBensPrincipal = false;

                ThDownloadTabelaInventarioBensPrincipal = new System.Threading.Thread
                    (
                    new System.Threading.ThreadStart
                        (
                        mtdRotinaThreadDownloadTabelaInventarioBensPrincipal
                        )
                    );
                ThDownloadTabelaInventarioBensPrincipal.IsBackground = true;
                ThDownloadTabelaInventarioBensPrincipal.Priority = System.Threading.ThreadPriority.Normal;
                ThDownloadTabelaInventarioBensPrincipal.Start();
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdIniciarThreadDownloadTabelaInventarioBensPrincipal: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        public void mtdReIniciarThreadDownloadTabelaInventarioBensPrincipal()
        {
            blnAbortarThreadDownloadTabelaInventarioBensPrincipal = false;
            blnForcarAbortarThreadDownloadTabelaInventarioBensPrincipal = false;
            intProgressoDownloadTabelaInventarioBensPrincipal = 0;

            blnThreadAtivadaDownloadTabelaInventarioBensPrincipal = true;
            blnSucessoDownloadTabelaInventarioBensPrincipal = false;
        }

        private static bool blnForcarAbortarThreadDownloadTabelaInventarioBensPrincipal = false;
        private static bool blnAbortarThreadDownloadTabelaInventarioBensPrincipal = false;
        private static int intTempoSaidaAbortarThreadDownloadTabelaInventarioBensPrincipal = 1000;

        public void mtdAbortarThreadDownloadTabelaInventarioBensPrincipal()
        {
            mtdAbortarThreadDownloadTabelaInventarioBensPrincipal(false);
        }

        public void mtdAbortarThreadDownloadTabelaInventarioBensPrincipal(bool Forcar)
        {
            blnAbortarThreadDownloadTabelaInventarioBensPrincipal = true;
            blnForcarAbortarThreadDownloadTabelaInventarioBensPrincipal = Forcar;
            intProgressoDownloadTabelaInventarioBensPrincipal = 100;

            blnThreadAtivadaDownloadTabelaInventarioBensPrincipal = false;
            blnSucessoDownloadTabelaInventarioBensPrincipal = false;

            try
            {
                ThDownloadTabelaInventarioBensPrincipal.Join(intTempoSaidaAbortarThreadDownloadTabelaInventarioBensPrincipal);
                ThDownloadTabelaInventarioBensPrincipal.Abort();
                ThDownloadTabelaInventarioBensPrincipal = null;
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdAbortarThreadDownloadTabelaInventarioBensPrincipal: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }

            System.Threading.Thread.Sleep(500);
            intProgressoDownloadTabelaInventarioBensPrincipal = 0;
        }

        public void mtdPararThreadDownloadTabelaInventarioBensPrincipal()
        {
            blnAbortarThreadDownloadTabelaInventarioBensPrincipal = true;
            blnForcarAbortarThreadDownloadTabelaInventarioBensPrincipal = true;
            intProgressoDownloadTabelaInventarioBensPrincipal = 100;

            blnThreadAtivadaDownloadTabelaInventarioBensPrincipal = false;
            blnSucessoDownloadTabelaInventarioBensPrincipal = false;

            System.Threading.Thread.Sleep(500);
            intProgressoDownloadTabelaInventarioBensPrincipal = 0;
        }

        private static object LockerDownloadTabelaInventarioBensPrincipal = new object();

        private void mtdRotinaThreadDownloadTabelaInventarioBensPrincipal()
        {
            string BancoDados = "Coletor";
            string WbBancoDados = "Principal";
            string Tabela = frmPrincipal.strTabelaInventarioBens;
            string Campo = frmPrincipal.vetCamposTabelaInventarioBens[frmPrincipal.intColunaTabelaInventarioBensNumero_Inventario];

            while (true)
            {
                if (!blnAbortarThreadDownloadTabelaInventarioBensPrincipal)
                {
                    //System.Threading.Monitor.Enter(LockerDownloadTabelaInventarioBensPrincipal);
                    lock (LockerDownloadTabelaInventarioBensPrincipal)
                    {
                        try
                        {
                            mtdDownloadTabelaInventarioBensPrincipal(BancoDados, WbBancoDados, Tabela, Campo);
                            //System.Threading.Thread.Sleep(1);
                            //mtdAbortarThreadDownloadTabelaInventarioBensPrincipal(true);
                            //mtdPararThreadDownloadTabelaInventarioBensPrincipal();
                        }
                        finally
                        {
                            //System.Threading.Monitor.Exit(LockerDownloadTabelaInventarioBensPrincipal);
                        }
                    }
                }
                System.Threading.Thread.Sleep(1);
            }
        }

        private int intProgressoDownloadTabelaInventarioBensPrincipal = 0;
        private long lngIteracoesDownloadTabelaInventarioBensPrincipal = 0;
        private bool blnThreadAtivadaDownloadTabelaInventarioBensPrincipal = false;
        private bool blnSucessoDownloadTabelaInventarioBensPrincipal = false;
        //private long lngMaxLinhaDownloadTabelaInventarioBensPrincipal = 0;
        private long lngMaxLinhaDownloadWTabelaInventarioBensPrincipal = 0;
        private long lngLinhaDownloadTabelaInventarioBensPrincipal = 0;

        private System.Data.DataSet AjustadorDadosDownloadTabelaInventarioBensPrincipal;

        private System.DateTime dtmInicioDownloadTabelaInventarioBensPrincipal = System.DateTime.Now;
        private System.DateTime dtmParcialDownloadTabelaInventarioBensPrincipal = System.DateTime.Now;
        private double dblTempoRestanteMilisegundosDownloadTabelaInventarioBensPrincipal = 0;

        private bool blnComandoImplementadoDownloadTabelaInventarioBensPrincipal = true;

        private bool blnMtdDownloadTabelaInventarioBensPrincipal = false;

        private void mtdDownloadTabelaInventarioBensPrincipal(string BancoDados, string WbBancoDados, string Tabela, string Campo)
        {
            blnMtdDownloadTabelaInventarioBensPrincipal = false;

            while (!blnMtdDownloadTabelaInventarioBensPrincipal)
            {
                mtdGerarPasso(ref intPassoDownloadTabelaInventarioBensPrincipal, blnMtdDownloadTabelaInventarioBensPrincipal);

                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
                string strConexao = mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
                clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

                try
                {
                    dtmInicioDownloadTabelaInventarioBensPrincipal = System.DateTime.Now;

                    bool blnPermitirDownloadWTabelaInventarioBensPrincipal = true;

                    intProgressoDownloadTabelaInventarioBensPrincipal = 0;

                    //if (blnForcarUploadDownloadTabela)
                    //{
                    //    blnPermitirDownloadWTabelaInventarioBensPrincipal = true;
                    //}
                    //else
                    //{
                    //    lngMaxLinhaDownloadWTabelaInventarioBensPrincipal = wb.mtdObterNumeroLinhas
                    //        (
                    //        WbBancoDados,
                    //        Tabela,
                    //        Campo,
                    //        "%"
                    //        );
                    //    lngMaxLinhaDownloadTabelaInventarioBensPrincipal = mtdObterNumeroLinhas
                    //        (
                    //        BancoDados,
                    //        Tabela,
                    //        Campo,
                    //        "%"
                    //        );
                    //    if
                    //      (
                    //      lngMaxLinhaDownloadWTabelaInventarioBensPrincipal
                    //      !=
                    //      lngMaxLinhaDownloadTabelaInventarioBensPrincipal
                    //      )
                    //    {
                    //        blnPermitirDownloadWTabelaInventarioBensPrincipal = true;
                    //    }
                    //    else
                    //    {
                    //        if (blnIgnorarCodigoEspalhamentoTabela)
                    //        {
                    //            blnPermitirDownloadWTabelaInventarioBensPrincipal = true;
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
                    //                blnPermitirDownloadWTabelaInventarioBensPrincipal = true;
                    //            }
                    //            else
                    //            {
                    //                blnPermitirDownloadWTabelaInventarioBensPrincipal = false;
                    //            }
                    //        }
                    //    }
                    //}

                    if (blnPermitirDownloadWTabelaInventarioBensPrincipal)
                    {
                        //mtdObterNumeroIdentificacao(false);

                        lngMaxLinhaDownloadWTabelaInventarioBensPrincipal = wb.mtdObterNumeroLinhas(WbBancoDados, Tabela, Campo, "%");
                        wb.mtdResetarContadorTabelaInventarioBensMobile(intNumeroIdentificacao);
                        AjustadorDadosDownloadTabelaInventarioBensPrincipal = wb.getTabelaInventarioBensMobile(WbBancoDados, intPassoDownloadTabelaInventarioBensPrincipal, intNumeroIdentificacao);
                        while (AjustadorDadosDownloadTabelaInventarioBensPrincipal.Tables[0].Rows.Count == 0)
                        {
                            AjustadorDadosDownloadTabelaInventarioBensPrincipal = wb.getTabelaInventarioBensMobile(WbBancoDados, intPassoDownloadTabelaInventarioBensPrincipal, intNumeroIdentificacao);
                            System.Threading.Thread.Sleep(1);
                        }

                        try
                        {
                            //wb.Abort();
                        }
                        catch (System.Exception ex)
                        {
                            string strExcecao = "mtdRotinaMonitorarWebService: " + ex.Message;
                            System.Diagnostics.Debug.WriteLine(strExcecao);
                            //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                        }

                        object[][] dados = new object[3][];
                        dados[0] = new object[AjustadorDadosDownloadTabelaInventarioBensPrincipal.Tables[0].Columns.Count];
                        dados[1] = new object[AjustadorDadosDownloadTabelaInventarioBensPrincipal.Tables[0].Columns.Count];
                        dados[2] = new object[AjustadorDadosDownloadTabelaInventarioBensPrincipal.Tables[0].Columns.Count];

                        for (int coluna = 0; coluna <= AjustadorDadosDownloadTabelaInventarioBensPrincipal.Tables[0].Columns.Count - 1; coluna++)
                        {
                            System.Threading.Thread.Sleep(1);
                            if (blnAbortarThreadDownloadTabelaInventarioBensPrincipal & blnForcarAbortarThreadDownloadTabelaInventarioBensPrincipal) goto SaidaDownloadTabelaInventarioBensPrincipal;

                            dados[0][coluna] = AjustadorDadosDownloadTabelaInventarioBensPrincipal.Tables[0].Columns[coluna].ColumnName;
                            switch (coluna)
                            {
                                case frmPrincipal.intColunaTabelaInventarioBensFotografia:
                                    dados[1][coluna] = System.Data.SqlDbType.Image;
                                    break;
                                default:
                                    dados[1][coluna] = null;
                                    break;
                            }
                        }

                        while (AjustadorDadosDownloadTabelaInventarioBensPrincipal != null)
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
                            if (blnAbortarThreadDownloadTabelaInventarioBensPrincipal & blnForcarAbortarThreadDownloadTabelaInventarioBensPrincipal) goto SaidaDownloadTabelaInventarioBensPrincipal;

                            if (AjustadorDadosDownloadTabelaInventarioBensPrincipal.Tables[0].Rows.Count != 0)
                            {
                                for (int linha = 0; linha <= AjustadorDadosDownloadTabelaInventarioBensPrincipal.Tables[0].Rows.Count - 1; linha++)
                                {
                                    System.Threading.Thread.Sleep(1);
                                    if (blnAbortarThreadDownloadTabelaInventarioBensPrincipal & blnForcarAbortarThreadDownloadTabelaInventarioBensPrincipal) goto SaidaDownloadTabelaInventarioBensPrincipal;

                                    for (int coluna = 0; coluna <= AjustadorDadosDownloadTabelaInventarioBensPrincipal.Tables[0].Columns.Count - 1; coluna++)
                                    {
                                        System.Threading.Thread.Sleep(1);
                                        if (blnAbortarThreadDownloadTabelaInventarioBensPrincipal & blnForcarAbortarThreadDownloadTabelaInventarioBensPrincipal) goto SaidaDownloadTabelaInventarioBensPrincipal;

                                        switch (coluna)
                                        {
                                            case 0:
                                                dados[2][coluna] = mtdGerarProximoNumeroCodigo
                                                    (
                                                    BancoDados,
                                                    frmPrincipal.strTabelaInventarioBens,
                                                    frmPrincipal.vetCamposTabelaInventarioBens[coluna]
                                                    );
                                                break;
                                            default:
                                                dados[2][coluna] = AjustadorDadosDownloadTabelaInventarioBensPrincipal.Tables[0].Rows[linha][coluna];
                                                break;
                                        }
                                    }

                                    blnComandoImplementadoDownloadTabelaInventarioBensPrincipal = objImplementacaoBancoDados.mtdInserirDadosParametroComandoSQLServerCE
                                       (
                                       Tabela,
                                       dados,
                                       clsImplementacaoBancoDados.enmModoParametroComando.ValorTipo
                                       );

                                    if (!blnComandoImplementadoDownloadTabelaInventarioBensPrincipal)
                                    {
                                        dados[2][frmPrincipal.intColunaTabelaInventarioBensNumero_Inventario] = AjustadorDadosDownloadTabelaInventarioBensPrincipal.Tables[0].Rows[linha][frmPrincipal.intColunaTabelaInventarioBensNumero_Inventario];

                                        //long lngCodigoEspalhamentoColetor = mtdCalcularCodigoEspalhamentoTabelaInventarioBens
                                        //    (
                                        //    BancoDados,
                                        //    frmPrincipal.vetCamposTabelaInventarioBens[frmPrincipal.intColunaTabelaInventarioBensInventario],
                                        //    dados[2][frmPrincipal.intColunaTabelaInventarioBensInventario]
                                        //    );
                                        //long lngCodigoEspalhamentoAjustadorDados = mtdCalcularCodigoEspalhamentoAjustadorDadosTabelaInventarioBensLinha
                                        //    (
                                        //    AjustadorDadosDownloadTabelaInventarioBensPrincipal,
                                        //    linha
                                        //    );

                                        //if (lngCodigoEspalhamentoColetor != lngCodigoEspalhamentoAjustadorDados)
                                        {
                                            if (
                                                mtdVerificarDataMaisAtualAjustadorDadosInventarioBensTabelaInventarioBens
                                                (
                                                AjustadorDadosDownloadTabelaInventarioBensPrincipal,
                                                linha,
                                                frmPrincipal.intColunaTabelaInventarioBensData_Inventario,
                                                BancoDados,
                                                frmPrincipal.vetCamposTabelaInventarioBens[frmPrincipal.intColunaTabelaInventarioBensInventario],
                                                dados[2][frmPrincipal.intColunaTabelaInventarioBensInventario]
                                                )
                                                )
                                            {
                                                bool blnBugAtivo = false;
                                                blnBugAtivo = !objImplementacaoBancoDados.mtdAtualizarDadosParametroComandoSQLServerCE
                                                    (
                                                    frmPrincipal.strTabelaInventarioBens,
                                                    dados,
                                                    frmPrincipal.vetCamposTabelaInventarioBens[frmPrincipal.intColunaTabelaInventarioBensInventario],
                                                    "LIKE",
                                                    dados[2][frmPrincipal.intColunaTabelaInventarioBensInventario],
                                                    clsImplementacaoBancoDados.enmModoParametroComando.ValorTipo
                                                    );

                                                blnComandoImplementadoDownloadTabelaInventarioBensPrincipal = !blnBugAtivo;

                                                if (blnBugAtivo)
                                                {
                                                    blnComandoImplementadoDownloadTabelaInventarioBensPrincipal = true;
                                                    blnComandoImplementadoDownloadTabelaInventarioBensPrincipal &= objImplementacaoBancoDados.mtdDeletarDadosParametroComandoSQLServerCE
                                                        (
                                                        frmPrincipal.strTabelaInventarioBens,
                                                        frmPrincipal.vetCamposTabelaInventarioBens[frmPrincipal.intColunaTabelaInventarioBensInventario],
                                                        "LIKE",
                                                        dados[2][frmPrincipal.intColunaTabelaInventarioBensInventario]
                                                        );
                                                    blnComandoImplementadoDownloadTabelaInventarioBensPrincipal &= objImplementacaoBancoDados.mtdInserirDadosParametroComandoSQLServerCE
                                                        (
                                                        frmPrincipal.strTabelaInventarioBens,
                                                        dados,
                                                        clsImplementacaoBancoDados.enmModoParametroComando.ValorTipo
                                                        );
                                                }
                                            }
                                            else
                                            {
                                                blnComandoImplementadoDownloadTabelaInventarioBensPrincipal = true;
                                            }
                                        }
                                    }

                                    if (!blnComandoImplementadoDownloadTabelaInventarioBensPrincipal) goto SaidaDownloadTabelaInventarioBensPrincipal;

                                    if (System.Convert.ToInt32((linha + lngLinhaDownloadTabelaInventarioBensPrincipal) * 100 / lngMaxLinhaDownloadWTabelaInventarioBensPrincipal) <= 100)
                                    {
                                        intProgressoDownloadTabelaInventarioBensPrincipal = System.Convert.ToInt32((linha + lngLinhaDownloadTabelaInventarioBensPrincipal) * 100 / lngMaxLinhaDownloadWTabelaInventarioBensPrincipal);
                                    }
                                    else
                                    {
                                        intProgressoDownloadTabelaInventarioBensPrincipal = 100;
                                    }

                                    dtmParcialDownloadTabelaInventarioBensPrincipal = System.DateTime.Now;
                                    if ((linha + lngLinhaDownloadTabelaInventarioBensPrincipal) != 0)
                                    {
                                        dblTempoRestanteMilisegundosDownloadTabelaInventarioBensPrincipal = ((double)(dtmParcialDownloadTabelaInventarioBensPrincipal - dtmInicioDownloadTabelaInventarioBensPrincipal).TotalMilliseconds * ((double)(lngMaxLinhaDownloadWTabelaInventarioBensPrincipal / (double)(linha + lngLinhaDownloadTabelaInventarioBensPrincipal)) - 1));
                                    }

                                    System.Diagnostics.Debug.WriteLine(string.Format("mtdDownloadTabelaInventarioBensPrincipal: {0}", intProgressoDownloadTabelaInventarioBensPrincipal));

                                    blnSucessoDownloadTabelaInventarioBensPrincipal = true;
                                }
                            }

                            AjustadorDadosDownloadTabelaInventarioBensPrincipal = wb.getTabelaInventarioBensMobile(WbBancoDados, intPassoDownloadTabelaInventarioBensPrincipal, intNumeroIdentificacao);
                            while (AjustadorDadosDownloadTabelaInventarioBensPrincipal.Tables[0].Rows.Count == 0)
                            {
                                AjustadorDadosDownloadTabelaInventarioBensPrincipal = wb.getTabelaInventarioBensMobile(WbBancoDados, intPassoDownloadTabelaInventarioBensPrincipal, intNumeroIdentificacao);
                                System.Threading.Thread.Sleep(1);
                            }

                            try
                            {
                                //wb.Abort();
                            }
                            catch (System.Exception ex)
                            {
                                string strExcecao = "mtdRotinaMonitorarWebService: " + ex.Message;
                                System.Diagnostics.Debug.WriteLine(strExcecao);
                                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                            }

                            System.Diagnostics.Debug.WriteLine(string.Format("mtdDownloadTabelaInventarioBensPrincipal: {0}", intProgressoDownloadTabelaInventarioBensPrincipal));

                            blnSucessoDownloadTabelaInventarioBensPrincipal = true;

                            if (AjustadorDadosDownloadTabelaInventarioBensPrincipal != null)
                            {
                                lngLinhaDownloadTabelaInventarioBensPrincipal += AjustadorDadosDownloadTabelaInventarioBensPrincipal.Tables[0].Rows.Count;
                            }
                            else
                            {
                                lngLinhaDownloadTabelaInventarioBensPrincipal = lngMaxLinhaDownloadWTabelaInventarioBensPrincipal;
                            }

                            if (System.Convert.ToInt32(lngLinhaDownloadTabelaInventarioBensPrincipal * 100 / lngMaxLinhaDownloadWTabelaInventarioBensPrincipal) <= 100)
                            {
                                intProgressoDownloadTabelaInventarioBensPrincipal = System.Convert.ToInt32(lngLinhaDownloadTabelaInventarioBensPrincipal * 100 / lngMaxLinhaDownloadWTabelaInventarioBensPrincipal);
                            }
                            else
                            {
                                intProgressoDownloadTabelaInventarioBensPrincipal = 100;
                            }

                            dtmParcialDownloadTabelaInventarioBensPrincipal = System.DateTime.Now;
                            if (lngLinhaDownloadTabelaInventarioBensPrincipal != 0)
                            {
                                dblTempoRestanteMilisegundosDownloadTabelaInventarioBensPrincipal = ((double)(dtmParcialDownloadTabelaInventarioBensPrincipal - dtmInicioDownloadTabelaInventarioBensPrincipal).TotalMilliseconds * ((double)(lngMaxLinhaDownloadWTabelaInventarioBensPrincipal / (double)lngLinhaDownloadTabelaInventarioBensPrincipal) - 1));
                            }

                            try
                            {
                                System.GC.Collect();
                            }
                            catch (System.Exception ex)
                            {
                                string strExcecao = "mtdDownloadTabelaInventarioBensPrincipal: " + ex.Message;
                                System.Diagnostics.Debug.WriteLine(strExcecao);
                                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                            }
                            System.Threading.Thread.Sleep(1);
                        }
                    }

                    intProgressoDownloadTabelaInventarioBensPrincipal = 100;

                    dtmParcialDownloadTabelaInventarioBensPrincipal = System.DateTime.Now;
                    if (lngLinhaDownloadTabelaInventarioBensPrincipal != 0)
                    {
                        dblTempoRestanteMilisegundosDownloadTabelaInventarioBensPrincipal = ((double)(dtmParcialDownloadTabelaInventarioBensPrincipal - dtmInicioDownloadTabelaInventarioBensPrincipal).TotalMilliseconds * ((double)(lngMaxLinhaDownloadWTabelaInventarioBensPrincipal / (double)lngLinhaDownloadTabelaInventarioBensPrincipal) - 1));
                    }

                    System.Diagnostics.Debug.WriteLine(string.Format("mtdDownloadTabelaInventarioBensPrincipal: {0}", intProgressoDownloadTabelaInventarioBensPrincipal));

                    blnSucessoDownloadTabelaInventarioBensPrincipal = true;

                    lngIteracoesDownloadTabelaInventarioBensPrincipal++;

                    blnMtdDownloadTabelaInventarioBensPrincipal = true;
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

                    blnSucessoDownloadTabelaInventarioBensPrincipal = false;
                    strExcecao = "mtdDownloadTabelaInventarioBensPrincipal: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                    //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);

                    blnMtdDownloadTabelaInventarioBensPrincipal = false;
                }
                finally
                {
                    if (blnForcarDesligamento)
                    {
                        //clsShutdownDevice.mtdForcePowerOff();
                        mtdIniciarThreadTemporizadorForcarDesligamento();
                    }

                    if (!blnIteracoesContinuas)
                    {
                        mtdAbortarThreadDownloadTabelaInventarioBensPrincipal(true);
                    }
                }

            SaidaDownloadTabelaInventarioBensPrincipal:

                objImplementacaoBancoDados.Dispose();

                //mtdAbortarThreadManterCanalAberto();

                System.Threading.Thread.Sleep(1);
            }
        }
    }
}
