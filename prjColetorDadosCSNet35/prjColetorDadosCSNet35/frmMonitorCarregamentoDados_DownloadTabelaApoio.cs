using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace prjColetorDadosCSNet35
{
    public partial class frmMonitorCarregamentoDados
    {
        private void SetValueDownloadTabelaApoio(int ProgressoDownloadTabelaApoio, long IteracoesDownloadTabelaApoio)
        {
            if (ProgressoDownloadTabelaApoio >= 0 & ProgressoDownloadTabelaApoio <= 100)
            {
                prgDownloadTabelaApoio.Value = ProgressoDownloadTabelaApoio;
                lblProgressoDownloadTabelaApoio.Text = string.Format("Progresso: {0}% - Iterações: {1}", ProgressoDownloadTabelaApoio, IteracoesDownloadTabelaApoio);
            }
        }

        public void mtdIniciarThreadDownloadTabelaApoio()
        {
            mtdIniciarThreadDownloadTabelaApoio(true);
        }

        public void mtdIniciarThreadDownloadTabelaApoio(bool Iniciar)
        {
            try
            {
                blnAbortarThreadDownloadTabelaApoio = !Iniciar;
                blnForcarAbortarThreadDownloadTabelaApoio = false;
                intProgressoDownloadTabelaApoio = 0;

                blnThreadAtivadaDownloadTabelaApoio = true;
                blnSucessoDownloadTabelaApoio = false;

                ThDownloadTabelaApoio = new System.Threading.Thread
                    (
                    new System.Threading.ThreadStart
                        (
                        mtdRotinaThreadDownloadTabelaApoio
                        )
                    );
                ThDownloadTabelaApoio.IsBackground = true;
                ThDownloadTabelaApoio.Priority = System.Threading.ThreadPriority.Normal;
                ThDownloadTabelaApoio.Start();
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdIniciarThreadDownloadTabelaApoio: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        public void mtdReIniciarThreadDownloadTabelaApoio()
        {
            blnAbortarThreadDownloadTabelaApoio = false;
            blnForcarAbortarThreadDownloadTabelaApoio = false;
            intProgressoDownloadTabelaApoio = 0;

            blnThreadAtivadaDownloadTabelaApoio = true;
            blnSucessoDownloadTabelaApoio = false;
        }

        private static bool blnForcarAbortarThreadDownloadTabelaApoio = false;
        private static bool blnAbortarThreadDownloadTabelaApoio = false;
        private static int intTempoSaidaAbortarThreadDownloadTabelaApoio = 1000;

        public void mtdAbortarThreadDownloadTabelaApoio()
        {
            mtdAbortarThreadDownloadTabelaApoio(false);
        }

        public void mtdAbortarThreadDownloadTabelaApoio(bool Forcar)
        {
            blnAbortarThreadDownloadTabelaApoio = true;
            blnForcarAbortarThreadDownloadTabelaApoio = Forcar;
            intProgressoDownloadTabelaApoio = 100;

            blnThreadAtivadaDownloadTabelaApoio = false;
            blnSucessoDownloadTabelaApoio = false;

            try
            {
                ThDownloadTabelaApoio.Join(intTempoSaidaAbortarThreadDownloadTabelaApoio);
                ThDownloadTabelaApoio.Abort();
                ThDownloadTabelaApoio = null;
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdAbortarThreadDownloadTabelaApoio: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }

            System.Threading.Thread.Sleep(1);
            intProgressoDownloadTabelaApoio = 0;
        }

        public void mtdPararThreadDownloadTabelaApoio()
        {
            blnAbortarThreadDownloadTabelaApoio = true;
            blnForcarAbortarThreadDownloadTabelaApoio = true;
            intProgressoDownloadTabelaApoio = 100;

            blnThreadAtivadaDownloadTabelaApoio = false;
            blnSucessoDownloadTabelaApoio = false;

            System.Threading.Thread.Sleep(1);
            intProgressoDownloadTabelaApoio = 0;
        }

        private int intContadorDownloadTabelaApoio = 0;

        private static object LockerDownloadTabelaApoio = new object();

        private static int intContadorTabelaApoioApresentacao = 0;

        private void mtdRotinaThreadDownloadTabelaApoio()
        {
            string BancoDados = "Coletor";
            string WbBancoDados = "Principal";
            string Tabela = string.Empty;
            string[] Campos;
            string Campo = string.Empty;

            intContadorDownloadTabelaApoio = 0;

            while (!blnAbortarThreadDownloadTabelaApoio)
            {
                //System.Threading.Monitor.Enter(LockerDownloadTabelaApoio);
                lock (LockerDownloadTabelaApoio)
                {
                    try
                    {
                        switch (intContadorTabelaApoioApresentacao)
                        {
                            case 0:
                                intContadorDownloadTabelaApoio += 1;
                                Tabela = frmPrincipal.strTabelaBensEletronorte;
                                Campos = frmPrincipal.vetCamposTabelaBensEletronorteCompleto;
                                Campo = frmPrincipal.vetCamposTabelaBensEletronorteCompleto[frmPrincipal.intColunaTabelaBensEletronorteCompletoPatrimonio];
                                mtdDownloadTabelaApoio(BancoDados, WbBancoDados, Tabela, Campos, Campo);
                                System.Threading.Thread.Sleep(1);
                                intContadorTabelaApoioApresentacao += 1;
                                break;
                            case 1:
                                intContadorDownloadTabelaApoio += 1;
                                Tabela = frmPrincipal.strTabelaEmpregados;
                                Campos = frmPrincipal.vetCamposTabelaEmpregados;
                                Campo = frmPrincipal.vetCamposTabelaEmpregados[frmPrincipal.intColunaTabelaEmpregadosMatricula];
                                mtdDownloadTabelaApoio(BancoDados, WbBancoDados, Tabela, Campos, Campo);
                                System.Threading.Thread.Sleep(1);
                                intContadorTabelaApoioApresentacao += 1;
                                break;
                            case 2:
                                intContadorDownloadTabelaApoio += 1;
                                Tabela = frmPrincipal.strTabelaCentroCusto;
                                Campos = frmPrincipal.vetCamposTabelaCentroCusto;
                                Campo = frmPrincipal.vetCamposTabelaCentroCusto[frmPrincipal.intColunaTabelaCentroCustoCentroCusto];
                                mtdDownloadTabelaApoio(BancoDados, WbBancoDados, Tabela, Campos, Campo);
                                System.Threading.Thread.Sleep(1);
                                intContadorTabelaApoioApresentacao = 0;
                                break;
                        }

                        //mtdAbortarThreadDownloadTabelaApoio(true);
                        //mtdPararThreadDownloadTabelaApoio();
                    }
                    finally
                    {
                        //System.Threading.Monitor.Exit(LockerDownloadTabelaApoio);
                    }
                }

                System.Threading.Thread.Sleep(1);
            }
        }

        private static int intProgressoDownloadTabelaApoio = 0;
        private long lngIteracoesDownloadTabelaApoio = 0;
        private bool blnThreadAtivadaDownloadTabelaApoio = false;
        private bool blnSucessoDownloadTabelaApoio = false;
        private long lngMaxLinhaDownloadTabelaApoio = 0;
        private long lngMaxLinhaDownloadWTabelaApoio = 0;
        private long lngLinhaDownloadTabelaApoio = 0;

        private System.Data.DataSet AjustadorDadosDownloadTabelaApoio;

        private System.DateTime dtmInicioDownloadTabelaApoio = System.DateTime.Now;
        private System.DateTime dtmParcialDownloadTabelaApoio = System.DateTime.Now;
        private double dblTempoRestanteMilisegundosDownloadTabelaApoio = 0;

        private bool blnComandoImplementadoDownloadTabelaApoio = true;

        private bool blnMtdDownloadTabelaApoio = false;

        private void mtdDownloadTabelaApoio(string BancoDados, string WbBancoDados, string Tabela, string[] Campos, string Campo)
        {
            blnMtdDownloadTabelaApoio = false;

            while (!blnMtdDownloadTabelaApoio)
            {
                mtdGerarPasso(ref intPassoDownloadTabelaApoio, blnMtdDownloadTabelaApoio);

                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
                string strConexao = mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
                clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

                try
                {
                    dtmInicioDownloadTabelaApoio = System.DateTime.Now;

                    bool blnPermitirDownloadWTabelaApoio = false;

                    AjustadorDadosDownloadTabelaApoio = null;

                    intProgressoDownloadTabelaApoio = 0;
                    lngLinhaDownloadTabelaApoio = 0;

                    lngMaxLinhaDownloadWTabelaApoio = wb.mtdObterNumeroLinhas
                        (
                        WbBancoDados,
                        Tabela,
                        Campo,
                        "%"
                        );
                    lngMaxLinhaDownloadTabelaApoio = mtdObterNumeroLinhas
                        (
                        BancoDados,
                        Tabela,
                        Campo,
                        "%"
                        );

                    try
                    {
                        //wb.Abort();
                    }
                    catch (System.Exception ex)
                    {
                        string strExcecao = "mtdDownloadTabelaApoio: " + ex.Message;
                        System.Diagnostics.Debug.WriteLine(strExcecao);
                        //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                    }

                    if (blnForcarUploadDownloadTabela)
                    {
                        blnPermitirDownloadWTabelaApoio = true;
                    }
                    else
                    {
                        if (lngMaxLinhaDownloadTabelaApoio != 0)
                        {
                            if
                                (
                                lngMaxLinhaDownloadWTabelaApoio
                                !=
                                lngMaxLinhaDownloadTabelaApoio
                                )
                            {
                                blnPermitirDownloadWTabelaApoio = true;
                            }
                            else
                            {
                                if (blnIgnorarCodigoEspalhamentoTabela)
                                {
                                    blnPermitirDownloadWTabelaApoio = true;
                                }
                                else
                                {
                                    long lngCalcularCodigoEspalhamentoWTabelaApoio = wb.mtdCalcularCodigoEspalhamento(
                                        WbBancoDados,
                                        Tabela,
                                        Campo,
                                        "%"
                                        );
                                    long lngCalcularCodigoEspalhamentoTabelaApoio = mtdCalcularCodigoEspalhamento
                                            (
                                            BancoDados,
                                            Tabela,
                                            Campos,
                                            Campo,
                                            "%"
                                            );

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

                                    if
                                        (
                                        lngCalcularCodigoEspalhamentoWTabelaApoio
                                        !=
                                        lngCalcularCodigoEspalhamentoTabelaApoio
                                        )
                                    {
                                        blnPermitirDownloadWTabelaApoio = true;
                                    }
                                    else
                                    {
                                        blnPermitirDownloadWTabelaApoio = false;
                                    }
                                }
                            }
                        }
                        else
                        {
                            blnPermitirDownloadWTabelaApoio = true;
                        }
                    }

                    if (blnPermitirDownloadWTabelaApoio)
                    {
                        //objImplementacaoBancoDados.mtdDeletarTabela(Tabela);

                        //objImplementacaoBancoDados.mtdDeletarDados
                        //    (
                        //    Tabela,
                        //    Campo,
                        //    "LIKE",
                        //    "'%'"
                        //    );

                        //mtdObterNumeroIdentificacao(false);

                        switch (intContadorTabelaApoioApresentacao)
                        {
                            case 0:
                                //Program.objPrincipal.mtdCriarTabelaBensEletronorteColetor();
                                //mtdObterNumeroIdentificacao();
                                wb.mtdResetarContadorTabelaBensEletronorteMobile(intNumeroIdentificacao);
                                AjustadorDadosDownloadTabelaApoio = wb.getTabelaBensEletronorteMobile(WbBancoDados, intPassoDownloadTabelaApoio, intNumeroIdentificacao);
                                while (AjustadorDadosDownloadTabelaApoio.Tables[0].Rows.Count == 0)
                                {
                                    //mtdObterNumeroIdentificacao(false);
                                    wb.mtdResetarContadorTabelaBensEletronorteMobile(intNumeroIdentificacao);
                                    AjustadorDadosDownloadTabelaApoio = wb.getTabelaBensEletronorteMobile(WbBancoDados, intPassoDownloadTabelaApoio, intNumeroIdentificacao);
                                }
                                break;
                            case 1:
                                //Program.objPrincipal.mtdCriarTabelaEmpregadosColetor();
                                //mtdObterNumeroIdentificacao();
                                wb.mtdResetarContadorTabelaEmpregadosMobile(intNumeroIdentificacao);
                                AjustadorDadosDownloadTabelaApoio = wb.getTabelaEmpregadosMobile(WbBancoDados, intPassoDownloadTabelaApoio, intNumeroIdentificacao);
                                while (AjustadorDadosDownloadTabelaApoio.Tables[0].Rows.Count == 0)
                                {
                                    //mtdObterNumeroIdentificacao(false);
                                    wb.mtdResetarContadorTabelaEmpregadosMobile(intNumeroIdentificacao);
                                    AjustadorDadosDownloadTabelaApoio = wb.getTabelaEmpregadosMobile(WbBancoDados, intPassoDownloadTabelaApoio, intNumeroIdentificacao);
                                }
                                break;
                            case 2:
                                //Program.objPrincipal.mtdCriarTabelaCentroCustoColetor();
                                //mtdObterNumeroIdentificacao();
                                wb.mtdResetarContadorTabelaCentroCustoMobile(intNumeroIdentificacao);
                                AjustadorDadosDownloadTabelaApoio = wb.getTabelaCentroCustoMobile(WbBancoDados, intPassoDownloadTabelaApoio, intNumeroIdentificacao);
                                while (AjustadorDadosDownloadTabelaApoio.Tables[0].Rows.Count == 0)
                                {
                                    //mtdObterNumeroIdentificacao(false);
                                    wb.mtdResetarContadorTabelaCentroCustoMobile(intNumeroIdentificacao);
                                    AjustadorDadosDownloadTabelaApoio = wb.getTabelaCentroCustoMobile(WbBancoDados, intPassoDownloadTabelaApoio, intNumeroIdentificacao);
                                }
                                break;
                        }

                        try
                        {
                            //wb.Abort();
                        }
                        catch (System.Exception ex)
                        {
                            string strExcecao = "mtdDownloadTabelaApoio: " + ex.Message;
                            System.Diagnostics.Debug.WriteLine(strExcecao);
                            //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                        }

                        object[][] dados = new object[3][];

                        dados[0] = new object[AjustadorDadosDownloadTabelaApoio.Tables[0].Columns.Count];
                        dados[1] = new object[AjustadorDadosDownloadTabelaApoio.Tables[0].Columns.Count];
                        dados[2] = new object[AjustadorDadosDownloadTabelaApoio.Tables[0].Columns.Count];

                        for (int coluna = 0; coluna <= AjustadorDadosDownloadTabelaApoio.Tables[0].Columns.Count - 1; coluna++)
                        {
                            System.Threading.Thread.Sleep(1);
                            if (blnAbortarThreadDownloadTabelaApoio & blnForcarAbortarThreadDownloadTabelaApoio) goto SaidaDownloadTabelaApoio;

                            dados[0][coluna] = AjustadorDadosDownloadTabelaApoio.Tables[0].Columns[coluna].ColumnName;
                            dados[1][coluna] = null;
                        }

                        if (AjustadorDadosDownloadTabelaApoio != null)
                        {
                            switch (intContadorTabelaApoioApresentacao)
                            {
                                case 0:
                                    objImplementacaoBancoDados.mtdDeletarTabela(Tabela);
                                    Program.objPrincipal.mtdCriarTabelaBensEletronorteColetor();
                                    break;
                                case 1:
                                    objImplementacaoBancoDados.mtdDeletarTabela(Tabela);
                                    Program.objPrincipal.mtdCriarTabelaEmpregadosColetor();
                                    break;
                                case 2:
                                    objImplementacaoBancoDados.mtdDeletarTabela(Tabela);
                                    Program.objPrincipal.mtdCriarTabelaCentroCustoColetor();
                                    break;
                            }

                            while (AjustadorDadosDownloadTabelaApoio != null)
                            {
                                try
                                {
                                    System.GC.Collect();
                                }
                                catch (System.Exception ex)
                                {
                                    string strExcecao = "mtdDownloadTabelaApoio: " + ex.Message;
                                    System.Diagnostics.Debug.WriteLine(strExcecao);
                                    //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                                }
                                System.Threading.Thread.Sleep(1);
                                if (blnAbortarThreadDownloadTabelaApoio & blnForcarAbortarThreadDownloadTabelaApoio) goto SaidaDownloadTabelaApoio;

                                if (AjustadorDadosDownloadTabelaApoio.Tables[0].Rows.Count != 0)
                                {
                                    for (int linha = 0; linha <= AjustadorDadosDownloadTabelaApoio.Tables[0].Rows.Count - 1; linha++)
                                    {
                                        System.Threading.Thread.Sleep(1);
                                        if (blnAbortarThreadDownloadTabelaApoio & blnForcarAbortarThreadDownloadTabelaApoio) goto SaidaDownloadTabelaApoio;

                                        for (int coluna = 0; coluna <= AjustadorDadosDownloadTabelaApoio.Tables[0].Columns.Count - 1; coluna++)
                                        {
                                            if (blnAbortarThreadDownloadTabelaApoio & blnForcarAbortarThreadDownloadTabelaApoio) goto SaidaDownloadTabelaApoio;

                                            dados[2][coluna] = AjustadorDadosDownloadTabelaApoio.Tables[0].Rows[linha][coluna];
                                            System.Threading.Thread.Sleep(1);
                                        }

                                        blnComandoImplementadoDownloadTabelaApoio = objImplementacaoBancoDados.mtdInserirDadosParametroComandoSQLServerCE
                                            (
                                            Tabela,
                                            dados,
                                            clsImplementacaoBancoDados.enmModoParametroComando.ValorTipo
                                            );

                                        if (!blnComandoImplementadoDownloadTabelaApoio) goto SaidaDownloadTabelaApoio;

                                        if (System.Convert.ToInt32((linha + lngLinhaDownloadTabelaApoio) * 100 / lngMaxLinhaDownloadWTabelaApoio) <= 100)
                                        {
                                            intProgressoDownloadTabelaApoio = System.Convert.ToInt32((linha + lngLinhaDownloadTabelaApoio) * 100 / lngMaxLinhaDownloadWTabelaApoio);
                                        }
                                        else
                                        {
                                            intProgressoDownloadTabelaApoio = 100;
                                        }

                                        dtmParcialDownloadTabelaApoio = System.DateTime.Now;
                                        if ((linha + lngLinhaDownloadTabelaApoio) != 0)
                                        {
                                            dblTempoRestanteMilisegundosDownloadTabelaApoio = ((double)(dtmParcialDownloadTabelaApoio - dtmInicioDownloadTabelaApoio).TotalMilliseconds * (((double)lngMaxLinhaDownloadWTabelaApoio / (double)(linha + lngLinhaDownloadTabelaApoio)) - 1));
                                        }

                                        System.Diagnostics.Debug.WriteLine(string.Format("mtdDownloadTabelaApoio: {0}", intProgressoDownloadTabelaApoio));

                                        blnSucessoDownloadTabelaApoio = true;
                                    }
                                }

                                switch (intContadorTabelaApoioApresentacao)
                                {
                                    case 0:
                                        AjustadorDadosDownloadTabelaApoio = wb.getTabelaBensEletronorteMobile(WbBancoDados, intPassoDownloadTabelaApoio, intNumeroIdentificacao);
                                        while (AjustadorDadosDownloadTabelaApoio.Tables[0].Rows.Count == 0)
                                        {
                                            AjustadorDadosDownloadTabelaApoio = wb.getTabelaBensEletronorteMobile(WbBancoDados, intPassoDownloadTabelaApoio, intNumeroIdentificacao);
                                        }
                                        break;
                                    case 1:
                                        AjustadorDadosDownloadTabelaApoio = wb.getTabelaEmpregadosMobile(WbBancoDados, intPassoDownloadTabelaApoio, intNumeroIdentificacao);
                                        while (AjustadorDadosDownloadTabelaApoio.Tables[0].Rows.Count == 0)
                                        {
                                            AjustadorDadosDownloadTabelaApoio = wb.getTabelaEmpregadosMobile(WbBancoDados, intPassoDownloadTabelaApoio, intNumeroIdentificacao);
                                        }
                                        break;
                                    case 2:
                                        AjustadorDadosDownloadTabelaApoio = wb.getTabelaCentroCustoMobile(WbBancoDados, intPassoDownloadTabelaApoio, intNumeroIdentificacao);
                                        while (AjustadorDadosDownloadTabelaApoio.Tables[0].Rows.Count == 0)
                                        {
                                            AjustadorDadosDownloadTabelaApoio = wb.getTabelaCentroCustoMobile(WbBancoDados, intPassoDownloadTabelaApoio, intNumeroIdentificacao);
                                        }
                                        break;
                                }

                                try
                                {
                                    //wb.Abort();
                                }
                                catch (System.Exception ex)
                                {
                                    string strExcecao = "mtdDownloadTabelaApoio: " + ex.Message;
                                    System.Diagnostics.Debug.WriteLine(strExcecao);
                                    //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                                }

                                System.Diagnostics.Debug.WriteLine(string.Format("mtdDownloadTabelaApoio: {0}", intProgressoDownloadTabelaApoio));

                                blnSucessoDownloadTabelaApoio = true;

                                if (AjustadorDadosDownloadTabelaApoio != null)
                                {
                                    lngLinhaDownloadTabelaApoio += AjustadorDadosDownloadTabelaApoio.Tables[0].Rows.Count;
                                }
                                else
                                {
                                    lngLinhaDownloadTabelaApoio = lngMaxLinhaDownloadWTabelaApoio;
                                }

                                if (System.Convert.ToInt32(lngLinhaDownloadTabelaApoio * 100 / lngMaxLinhaDownloadWTabelaApoio) <= 100)
                                {
                                    intProgressoDownloadTabelaApoio = System.Convert.ToInt32(lngLinhaDownloadTabelaApoio * 100 / lngMaxLinhaDownloadWTabelaApoio);
                                }
                                else
                                {
                                    intProgressoDownloadTabelaApoio = 100;
                                }

                                dtmParcialDownloadTabelaApoio = System.DateTime.Now;
                                if (lngLinhaDownloadTabelaApoio != 0)
                                {
                                    dblTempoRestanteMilisegundosDownloadTabelaApoio = ((double)(dtmParcialDownloadTabelaApoio - dtmInicioDownloadTabelaApoio).TotalMilliseconds * (((double)lngMaxLinhaDownloadWTabelaApoio / (double)lngLinhaDownloadTabelaApoio) - 1));
                                }

                                try
                                {
                                    System.GC.Collect();
                                }
                                catch (System.Exception ex)
                                {
                                    string strExcecao = "mtdDownloadTabelaApoio: " + ex.Message;
                                    System.Diagnostics.Debug.WriteLine(strExcecao);
                                    //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                                }
                                System.Threading.Thread.Sleep(1);
                            }
                        }
                    }

                    intProgressoDownloadTabelaApoio = 100;

                    dtmParcialDownloadTabelaApoio = System.DateTime.Now;
                    if (lngLinhaDownloadTabelaApoio != 0)
                    {
                        dblTempoRestanteMilisegundosDownloadTabelaApoio = ((double)(dtmParcialDownloadTabelaApoio - dtmInicioDownloadTabelaApoio).TotalMilliseconds * (((double)lngMaxLinhaDownloadWTabelaApoio / (double)lngLinhaDownloadTabelaApoio) - 1));
                    }

                    System.Diagnostics.Debug.WriteLine(string.Format("mtdDownloadTabelaApoio: {0}", intProgressoDownloadTabelaApoio));

                    blnSucessoDownloadTabelaApoio = true;

                    lngIteracoesDownloadTabelaApoio++;

                    blnMtdDownloadTabelaApoio = true;
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
                        strExcecao = "mtdDownloadTabelaApoio: " + ex_.Message;
                        System.Diagnostics.Debug.WriteLine(strExcecao);
                        //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                    }

                    blnSucessoDownloadTabelaApoio = false;
                    strExcecao = "mtdDownloadTabelaApoio: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                    //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);

                    blnMtdDownloadTabelaApoio = false;
                }
                finally
                {
                    if (blnForcarDesligamento && intContadorDownloadTabelaApoio >= 3)
                    {
                        //clsShutdownDevice.mtdForcePowerOff();
                        mtdIniciarThreadTemporizadorForcarDesligamento();
                    }

                    //ThDownloadTabelaApoio.Priority = System.Threading.ThreadPriority.Lowest;
                    if (intContadorTabelaApoioApresentacao == 2 && intControleContadorTabelaApoioApresentacao == 0)
                    {
                        if (!blnIteracoesContinuas)
                        {
                            intProgressoDownloadTabelaApoio = 0;
                            intContadorTabelaApoioApresentacao = 0;

                            mtdAbortarThreadDownloadTabelaApoio(true);
                        }
                    }
                    if (intContadorTabelaApoioApresentacao == 0 && intControleContadorTabelaApoioApresentacao == 1)
                    {
                        if (!blnIteracoesContinuas)
                        {
                            intProgressoDownloadTabelaApoio = 0;
                            intContadorTabelaApoioApresentacao = 0;

                            mtdAbortarThreadDownloadTabelaApoio(true);
                        }
                    }
                    if (intContadorTabelaApoioApresentacao == 1 && intControleContadorTabelaApoioApresentacao == 2)
                    {
                        if (!blnIteracoesContinuas)
                        {
                            intProgressoDownloadTabelaApoio = 0;
                            intContadorTabelaApoioApresentacao = 0;

                            mtdAbortarThreadDownloadTabelaApoio(true);
                        }
                    }
                }

            SaidaDownloadTabelaApoio:

                objImplementacaoBancoDados.Dispose();

                //mtdAbortarThreadManterCanalAberto();

                System.Threading.Thread.Sleep(1);
            }
        }
    }
}