using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebServiceCSNet40
{
    /// <summary>
    /// Summary description for WebServicoBancoDados
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public partial class WebServicoBancoDados : System.Web.Services.WebService
    {
        private const int cntIntNumeroInstancias = 100;

        private static System.Web.UI.Page pg = new System.Web.UI.Page();

        private static object LockGerarProximoNumeroIdentificacao = new object();

        private int mtdGerarProximoNumeroIdentificacao()
        {
            //lock (LockGerarProximoNumeroIdentificacao)
            {
                System.Threading.Thread.Sleep(1);

                if (intNumeroIdentificacao < cntIntNumeroInstancias - 1)
                {
                    intNumeroIdentificacao++;
                }
                else
                {
                    intNumeroIdentificacao = -1;
                }

                return intNumeroIdentificacao;
            }
        }

        private int mtdGerarNumeroIdentificacao_()
        {
            int Retorno = 0;

            Retorno = mtdGerarProximoNumeroIdentificacao();

            if (intNumeroIdentificacao > -1)
            {
                while (blnCanalAberto[intNumeroIdentificacao])
                {
                    Retorno = mtdGerarProximoNumeroIdentificacao();
                }
            }
            else
            {
                Retorno = mtdGerarProximoNumeroIdentificacao();
            }

            return Retorno;
        }

        [WebMethod]
        public int mtdGerarNumeroIdentificacao()
        {
            return mtdGerarNumeroIdentificacao_();
        }

        // private static object Lock_WebServicoBancoDados = new object();

        public static void _WebServicoBancoDados()
        {
            // lock (Lock_WebServicoBancoDados)
            {
                AppDomain.CurrentDomain.SetData("SQLServerCompactEditionUnderWebHosting", true);

                //Default._Default();

                //Default.mtdIniciarCriacaoTabelas();

                if (!pg.IsPostBack)
                {

                }

                //m_Sb = new System.Text.StringBuilder();
                //m_bDirty = false;
                //m_bIsWatching = false;
                //mtdMonitorarDiretorioArquivo()
            }
        }

        public WebServicoBancoDados()
        {
            _WebServicoBancoDados();
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        // private static object LockTabela = new object();

        private System.Data.DataSet getTabela(string BancoDados, string Tabela)
        {
            // lock (LockTabela)
            {
                // System.Threading.Thread.Sleep(1);

                System.Data.DataSet AjustadorDados;

                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
                string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
                clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

                objImplementacaoBancoDados.mtdSelecionarDados("*", Tabela);

                objImplementacaoBancoDados.mtdAdaptadorDados(Tabela);
                AjustadorDados = objImplementacaoBancoDados.prpAjustadorDados;
                objImplementacaoBancoDados.Dispose();

                return AjustadorDados;
            }
        }

        private static int intNumeroIdentificacao = -1;

        // private static object LockObterNumeroIdentificacao = new object();

        [WebMethod]
        public int mtdObterNumeroIdentificacao()
        {
            // lock (LockObterNumeroIdentificacao)
            {
                // System.Threading.Thread.Sleep(1);

                return intNumeroIdentificacao;
            }
        }

        private static System.Data.DataSet[] AjustadorDadosTabelaBensEletronorteMobile = new System.Data.DataSet[cntIntNumeroInstancias];

        // private static object LockResetarContadorTabelaBensEletronorteMobile = new object();

        [WebMethod]
        public void mtdResetarContadorTabelaBensEletronorteMobile(int NumeroIdentificacao)
        {
            // lock (LockResetarContadorTabelaBensEletronorteMobile)
            {
                // System.Threading.Thread.Sleep(1);

                if (NumeroIdentificacao > -1 && NumeroIdentificacao < cntIntNumeroInstancias)
                {
                    AjustadorDadosTabelaBensEletronorteMobile[NumeroIdentificacao] = null;
                }
            }
        }

        private static System.Data.DataSet[] AjustadorDadosTabelaCentroCustoMobile = new System.Data.DataSet[cntIntNumeroInstancias];

        // private static object LockResetarContadorTabelaCentroCustoMobile = new object();

        [WebMethod]
        public void mtdResetarContadorTabelaCentroCustoMobile(int NumeroIdentificacao)
        {
            // lock (LockResetarContadorTabelaCentroCustoMobile)
            {
                // System.Threading.Thread.Sleep(1);

                if (NumeroIdentificacao > -1 && NumeroIdentificacao < cntIntNumeroInstancias)
                {
                    AjustadorDadosTabelaCentroCustoMobile[NumeroIdentificacao] = null;
                }
            }
        }

        private static System.Data.DataSet[] AjustadorDadosTabelaEmpregadosMobile = new System.Data.DataSet[cntIntNumeroInstancias];

        // private static object LockResetarContadorTabelaEmpregadosMobile = new object();

        [WebMethod]
        public void mtdResetarContadorTabelaEmpregadosMobile(int NumeroIdentificacao)
        {
            // lock (LockResetarContadorTabelaEmpregadosMobile)
            {
                // System.Threading.Thread.Sleep(1);

                if (NumeroIdentificacao > -1 && NumeroIdentificacao < cntIntNumeroInstancias)
                {
                    AjustadorDadosTabelaEmpregadosMobile[NumeroIdentificacao] = null;
                }
            }
        }

        private static System.Data.DataSet[] AjustadorDadosTabelaInventarioBensMobile = new System.Data.DataSet[cntIntNumeroInstancias];

        // private static object LockResetarContadorTabelaInventarioBensMobile = new object();

        [WebMethod]
        public void mtdResetarContadorTabelaInventarioBensMobile(int NumeroIdentificacao)
        {
            // lock (LockResetarContadorTabelaInventarioBensMobile)
            {
                // System.Threading.Thread.Sleep(1);

                if (NumeroIdentificacao > -1 && NumeroIdentificacao < cntIntNumeroInstancias)
                {
                    AjustadorDadosTabelaInventarioBensMobile[NumeroIdentificacao] = null;
                }
            }
        }

        private static int[] intPassoTabelaBensEletronorteMobile = new int[cntIntNumeroInstancias];

        private static clsImplementacaoBancoDados[] objImplementacaoBancoDadosTabelaBensEletronorteMobile = new clsImplementacaoBancoDados[cntIntNumeroInstancias];

        private static bool[] ForcarParadagetTabelaBensEletronorteMobile = new bool[cntIntNumeroInstancias];
        //private static object LockTabelaBensEletronorteMobile = new object();

        [WebMethod]
        public System.Data.DataSet getTabelaBensEletronorteMobile(string BancoDados, int Passo, int NumeroIdentificacao)
        {
            // lock (LockTabelaBensEletronorteMobile)
            {
                System.Threading.Thread.Sleep(1);

                ForcarParadagetTabelaBensEletronorteMobile[NumeroIdentificacao] = false;

                if (NumeroIdentificacao > -1 && NumeroIdentificacao < cntIntNumeroInstancias)
                {
                    intPassoTabelaBensEletronorteMobile[NumeroIdentificacao] = Passo;
                    try
                    {
                        if (AjustadorDadosTabelaBensEletronorteMobile[NumeroIdentificacao] == null)
                        {
                            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
                            string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
                            objImplementacaoBancoDadosTabelaBensEletronorteMobile[NumeroIdentificacao] = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

                            objImplementacaoBancoDadosTabelaBensEletronorteMobile[NumeroIdentificacao].mtdAbrirConexao();
                            switch (BancoDados)
                            {
                                case "Principal":
                                    objImplementacaoBancoDadosTabelaBensEletronorteMobile[NumeroIdentificacao].mtdExecutarComando
                                        (
                                        string.Format
                                        (
                                        "SELECT TOP {0} {1} FROM {2} ORDER BY {3} {4};",
                                        1,
                                        objImplementacaoBancoDadosTabelaBensEletronorteMobile[NumeroIdentificacao].mtdVetorLinhaCampos(Default.vetCamposTabelaBensEletronortePrincipal),
                                        Default.strTabelaBensEletronorte,
                                        Default.vetCamposTabelaBensEletronortePrincipal[Default.intColunaTabelaBensEletronortePrincipalPatrimonio],
                                        string.Empty
                                        )
                                        );
                                    break;
                                case "Coletor":
                                    objImplementacaoBancoDadosTabelaBensEletronorteMobile[NumeroIdentificacao].mtdExecutarComando
                                        (
                                        string.Format
                                        (
                                        "SELECT TOP {0} {1} FROM {2} ORDER BY {3} {4};",
                                        1,
                                        objImplementacaoBancoDadosTabelaBensEletronorteMobile[NumeroIdentificacao].mtdVetorLinhaCampos(Default.vetCamposTabelaBensEletronorteColetor),
                                        Default.strTabelaBensEletronorte,
                                        Default.vetCamposTabelaBensEletronorteColetor[Default.intColunaTabelaBensEletronorteColetorPatrimonio],
                                        string.Empty
                                        )
                                        );
                                    break;
                            }

                            objImplementacaoBancoDadosTabelaBensEletronorteMobile[NumeroIdentificacao].mtdAdaptadorDados();
                            //System.Data.DataSet AjustadorDados = objImplementacaoBancoDadosTabelaBensEletronorteMobile[NumeroIdentificacao].prpAjustadorDados;
                            AjustadorDadosTabelaBensEletronorteMobile[NumeroIdentificacao] = new System.Data.DataSet();
                            //AjustadorDadosTabelaBensEletronorteMobile[NumeroIdentificacao].Tables.Add(AjustadorDados.Tables[0].Clone());
                            AjustadorDadosTabelaBensEletronorteMobile[NumeroIdentificacao].Tables.Add(objImplementacaoBancoDadosTabelaBensEletronorteMobile[NumeroIdentificacao].prpAjustadorDados.Tables[0].Clone());

                            switch (BancoDados)
                            {
                                case "Principal":
                                    objImplementacaoBancoDadosTabelaBensEletronorteMobile[NumeroIdentificacao].mtdExecutarComando
                                        (
                                        string.Format
                                        (
                                        "SELECT {0} FROM {1} ORDER BY {2} {3};",
                                        objImplementacaoBancoDadosTabelaBensEletronorteMobile[NumeroIdentificacao].mtdVetorLinhaCampos(Default.vetCamposTabelaBensEletronortePrincipal),
                                        Default.strTabelaBensEletronorte,
                                        Default.vetCamposTabelaBensEletronortePrincipal[Default.intColunaTabelaBensEletronortePrincipalPatrimonio],
                                        string.Empty
                                        )
                                        );
                                    break;
                                case "Coletor":
                                    objImplementacaoBancoDadosTabelaBensEletronorteMobile[NumeroIdentificacao].mtdExecutarComando
                                        (
                                        string.Format
                                        (
                                        "SELECT {0} FROM {1} ORDER BY {2} {3};",
                                        objImplementacaoBancoDadosTabelaBensEletronorteMobile[NumeroIdentificacao].mtdVetorLinhaCampos(Default.vetCamposTabelaBensEletronorteColetor),
                                        Default.strTabelaBensEletronorte,
                                        Default.vetCamposTabelaBensEletronorteColetor[Default.intColunaTabelaBensEletronorteColetorPatrimonio],
                                        string.Empty
                                        )
                                        );
                                    break;
                            }

                            objImplementacaoBancoDadosTabelaBensEletronorteMobile[NumeroIdentificacao].mtdDefinirLeitorDados();
                        }

                        AjustadorDadosTabelaBensEletronorteMobile[NumeroIdentificacao].Tables[0].Rows.Clear();

                        if (objImplementacaoBancoDadosTabelaBensEletronorteMobile[NumeroIdentificacao] != null)
                        {
                            for
                                (
                                int linha = 0;
                                linha <= intPassoTabelaBensEletronorteMobile[NumeroIdentificacao] - 1;
                                linha++
                                )
                            {
                                if (!blnCanalAberto[NumeroIdentificacao] & Default.blnPermitirControleColetorUpLoad) break;
                                if (ForcarParadagetTabelaBensEletronorteMobile[NumeroIdentificacao]) break;

                                if (objImplementacaoBancoDadosTabelaBensEletronorteMobile[NumeroIdentificacao].mtdProximoRegistro())
                                {
                                    AjustadorDadosTabelaBensEletronorteMobile[NumeroIdentificacao].Tables[0].Rows.Add(objImplementacaoBancoDadosTabelaBensEletronorteMobile[NumeroIdentificacao].mtdObterValorRegistro());
                                }
                                else
                                {
                                    if (objImplementacaoBancoDadosTabelaBensEletronorteMobile[NumeroIdentificacao] != null)
                                    {
                                        objImplementacaoBancoDadosTabelaBensEletronorteMobile[NumeroIdentificacao].Dispose();
                                        objImplementacaoBancoDadosTabelaBensEletronorteMobile[NumeroIdentificacao] = null;
                                    }

                                    break;
                                }

                                System.Threading.Thread.Sleep(1);
                            }
                        }
                        else
                        {
                            mtdResetarContadorTabelaBensEletronorteMobile(NumeroIdentificacao);
                        }

                        try
                        {
                            System.GC.Collect();
                        }
                        catch (System.Exception ex)
                        {
                        }
                    }
                    catch (Exception ex)
                    {
                        if (objImplementacaoBancoDadosTabelaBensEletronorteMobile[NumeroIdentificacao] != null)
                        {
                            objImplementacaoBancoDadosTabelaBensEletronorteMobile[NumeroIdentificacao].Dispose();
                            objImplementacaoBancoDadosTabelaBensEletronorteMobile[NumeroIdentificacao] = null;
                        }
                        mtdResetarContadorTabelaBensEletronorteMobile(NumeroIdentificacao);

                        string strExcecao = "getTabelaBensEletronorteMobile: " + ex.Message;
                        System.Diagnostics.Debug.WriteLine(strExcecao);
                        // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
                    }
                }
            }

            return AjustadorDadosTabelaBensEletronorteMobile[NumeroIdentificacao];
        }

        private static int[] intPassoTabelaCentroCustoMobile = new int[cntIntNumeroInstancias];

        private static clsImplementacaoBancoDados[] objImplementacaoBancoDadosTabelaCentroCustoMobile = new clsImplementacaoBancoDados[cntIntNumeroInstancias];

        private static bool[] ForcarParadagetTabelaCentroCustoMobile = new bool[cntIntNumeroInstancias];
        //private static object LockTabelaCentroCustoMobile = new object();

        [WebMethod]
        public System.Data.DataSet getTabelaCentroCustoMobile(string BancoDados, int Passo, int NumeroIdentificacao)
        {
            // lock (LockTabelaCentroCustoMobile)
            {
                System.Threading.Thread.Sleep(1);

                ForcarParadagetTabelaCentroCustoMobile[NumeroIdentificacao] = false;

                if (NumeroIdentificacao > -1 && NumeroIdentificacao < cntIntNumeroInstancias)
                {
                    intPassoTabelaCentroCustoMobile[NumeroIdentificacao] = Passo;
                    try
                    {
                        if (AjustadorDadosTabelaCentroCustoMobile[NumeroIdentificacao] == null)
                        {
                            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
                            string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
                            objImplementacaoBancoDadosTabelaCentroCustoMobile[NumeroIdentificacao] = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

                            objImplementacaoBancoDadosTabelaCentroCustoMobile[NumeroIdentificacao].mtdAbrirConexao();
                            objImplementacaoBancoDadosTabelaCentroCustoMobile[NumeroIdentificacao].mtdExecutarComando
                                (
                                string.Format
                                (
                                "SELECT TOP {0} {1} FROM {2} ORDER BY {3} {4};",
                                1,
                                objImplementacaoBancoDadosTabelaCentroCustoMobile[NumeroIdentificacao].mtdVetorLinhaCampos(Default.vetCamposTabelaCentroCusto),
                                Default.strTabelaCentroCusto,
                                Default.vetCamposTabelaCentroCusto[Default.intColunaTabelaCentroCustoCentroCusto],
                                string.Empty
                                )
                                );

                            objImplementacaoBancoDadosTabelaCentroCustoMobile[NumeroIdentificacao].mtdAdaptadorDados();
                            //System.Data.DataSet AjustadorDados = objImplementacaoBancoDadosTabelaCentroCustoMobile[NumeroIdentificacao].prpAjustadorDados;
                            AjustadorDadosTabelaCentroCustoMobile[NumeroIdentificacao] = new System.Data.DataSet();
                            //AjustadorDadosTabelaCentroCustoMobile[NumeroIdentificacao].Tables.Add(AjustadorDados.Tables[0].Clone());
                            AjustadorDadosTabelaCentroCustoMobile[NumeroIdentificacao].Tables.Add(objImplementacaoBancoDadosTabelaCentroCustoMobile[NumeroIdentificacao].prpAjustadorDados.Tables[0].Clone());

                            objImplementacaoBancoDadosTabelaCentroCustoMobile[NumeroIdentificacao].mtdExecutarComando
                                (
                                string.Format
                                (
                                "SELECT {0} FROM {1} ORDER BY {2} {3};",
                                objImplementacaoBancoDadosTabelaCentroCustoMobile[NumeroIdentificacao].mtdVetorLinhaCampos(Default.vetCamposTabelaCentroCusto),
                                Default.strTabelaCentroCusto,
                                Default.vetCamposTabelaCentroCusto[0],
                                string.Empty
                                )
                                );

                            objImplementacaoBancoDadosTabelaCentroCustoMobile[NumeroIdentificacao].mtdDefinirLeitorDados();
                        }

                        AjustadorDadosTabelaCentroCustoMobile[NumeroIdentificacao].Tables[0].Rows.Clear();

                        if (objImplementacaoBancoDadosTabelaCentroCustoMobile[NumeroIdentificacao] != null)
                        {
                            for
                                (
                                int linha = 0;
                                linha <= intPassoTabelaCentroCustoMobile[NumeroIdentificacao] - 1;
                                linha++
                                )
                            {
                                if (!blnCanalAberto[NumeroIdentificacao] & Default.blnPermitirControleColetorUpLoad) break;
                                if (ForcarParadagetTabelaCentroCustoMobile[NumeroIdentificacao]) break;

                                if (objImplementacaoBancoDadosTabelaCentroCustoMobile[NumeroIdentificacao].mtdProximoRegistro())
                                {
                                    AjustadorDadosTabelaCentroCustoMobile[NumeroIdentificacao].Tables[0].Rows.Add(objImplementacaoBancoDadosTabelaCentroCustoMobile[NumeroIdentificacao].mtdObterValorRegistro());
                                }
                                else
                                {
                                    if (objImplementacaoBancoDadosTabelaCentroCustoMobile[NumeroIdentificacao] != null)
                                    {
                                        objImplementacaoBancoDadosTabelaCentroCustoMobile[NumeroIdentificacao].Dispose();
                                        objImplementacaoBancoDadosTabelaCentroCustoMobile[NumeroIdentificacao] = null;
                                    }

                                    break;
                                }

                                System.Threading.Thread.Sleep(1);
                            }
                        }
                        else
                        {
                            mtdResetarContadorTabelaCentroCustoMobile(NumeroIdentificacao);
                        }

                        try
                        {
                            System.GC.Collect();
                        }
                        catch (System.Exception ex)
                        {
                        }
                    }
                    catch (Exception ex)
                    {
                        if (objImplementacaoBancoDadosTabelaCentroCustoMobile[NumeroIdentificacao] != null)
                        {
                            objImplementacaoBancoDadosTabelaCentroCustoMobile[NumeroIdentificacao].Dispose();
                            objImplementacaoBancoDadosTabelaCentroCustoMobile[NumeroIdentificacao] = null;
                        }
                        mtdResetarContadorTabelaCentroCustoMobile(NumeroIdentificacao);

                        string strExcecao = "getTabelaCentroCustoMobile: " + ex.Message;
                        System.Diagnostics.Debug.WriteLine(strExcecao);
                        // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
                    }
                }
            }

            return AjustadorDadosTabelaCentroCustoMobile[NumeroIdentificacao];
        }

        private static int[] intPassoTabelaEmpregadosMobile = new int[cntIntNumeroInstancias];

        private static clsImplementacaoBancoDados[] objImplementacaoBancoDadosTabelaEmpregadosMobile = new clsImplementacaoBancoDados[cntIntNumeroInstancias];

        private static bool[] ForcarParadagetTabelaEmpregadosMobile = new bool[cntIntNumeroInstancias];
        //private static object LockTabelaEmpregadosMobile = new object();

        [WebMethod]
        public System.Data.DataSet getTabelaEmpregadosMobile(string BancoDados, int Passo, int NumeroIdentificacao)
        {
            // lock (LockTabelaEmpregadosMobile)
            {
                System.Threading.Thread.Sleep(1);

                ForcarParadagetTabelaEmpregadosMobile[NumeroIdentificacao] = false;

                if (NumeroIdentificacao > -1 && NumeroIdentificacao < cntIntNumeroInstancias)
                {
                    intPassoTabelaEmpregadosMobile[NumeroIdentificacao] = Passo;
                    try
                    {
                        if (AjustadorDadosTabelaEmpregadosMobile[NumeroIdentificacao] == null)
                        {
                            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
                            string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
                            objImplementacaoBancoDadosTabelaEmpregadosMobile[NumeroIdentificacao] = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

                            objImplementacaoBancoDadosTabelaEmpregadosMobile[NumeroIdentificacao].mtdAbrirConexao();
                            objImplementacaoBancoDadosTabelaEmpregadosMobile[NumeroIdentificacao].mtdExecutarComando
                                (
                                string.Format
                                (
                                "SELECT TOP {0} {1} FROM {2} ORDER BY {3} {4};",
                                1,
                                objImplementacaoBancoDadosTabelaEmpregadosMobile[NumeroIdentificacao].mtdVetorLinhaCampos(Default.vetCamposTabelaEmpregados),
                                Default.strTabelaEmpregados,
                                Default.vetCamposTabelaEmpregados[Default.intColunaTabelaEmpregadosMatricula],
                                string.Empty
                                )
                                );

                            objImplementacaoBancoDadosTabelaEmpregadosMobile[NumeroIdentificacao].mtdAdaptadorDados();
                            //System.Data.DataSet AjustadorDados = objImplementacaoBancoDadosTabelaEmpregadosMobile[NumeroIdentificacao].prpAjustadorDados;
                            AjustadorDadosTabelaEmpregadosMobile[NumeroIdentificacao] = new System.Data.DataSet();
                            //AjustadorDadosTabelaEmpregadosMobile[NumeroIdentificacao].Tables.Add(AjustadorDados.Tables[0].Clone());
                            AjustadorDadosTabelaEmpregadosMobile[NumeroIdentificacao].Tables.Add(objImplementacaoBancoDadosTabelaEmpregadosMobile[NumeroIdentificacao].prpAjustadorDados.Tables[0].Clone());

                            objImplementacaoBancoDadosTabelaEmpregadosMobile[NumeroIdentificacao].mtdExecutarComando
                                (
                                string.Format
                                (
                                "SELECT {0} FROM {1} ORDER BY {2} {3};",
                                objImplementacaoBancoDadosTabelaEmpregadosMobile[NumeroIdentificacao].mtdVetorLinhaCampos(Default.vetCamposTabelaEmpregados),
                                Default.strTabelaEmpregados,
                                Default.vetCamposTabelaEmpregados[Default.intColunaTabelaEmpregadosMatricula],
                                string.Empty
                                )
                                );

                            objImplementacaoBancoDadosTabelaEmpregadosMobile[NumeroIdentificacao].mtdDefinirLeitorDados();
                        }

                        AjustadorDadosTabelaEmpregadosMobile[NumeroIdentificacao].Tables[0].Rows.Clear();

                        if (objImplementacaoBancoDadosTabelaEmpregadosMobile[NumeroIdentificacao] != null)
                        {
                            for
                                (
                                int linha = 0;
                                linha <= intPassoTabelaEmpregadosMobile[NumeroIdentificacao] - 1;
                                linha++
                                )
                            {
                                if (!blnCanalAberto[NumeroIdentificacao] & Default.blnPermitirControleColetorUpLoad) break;
                                if (ForcarParadagetTabelaEmpregadosMobile[NumeroIdentificacao]) break;

                                if (objImplementacaoBancoDadosTabelaEmpregadosMobile[NumeroIdentificacao].mtdProximoRegistro())
                                {
                                    AjustadorDadosTabelaEmpregadosMobile[NumeroIdentificacao].Tables[0].Rows.Add(objImplementacaoBancoDadosTabelaEmpregadosMobile[NumeroIdentificacao].mtdObterValorRegistro());
                                }
                                else
                                {
                                    if (objImplementacaoBancoDadosTabelaEmpregadosMobile[NumeroIdentificacao] != null)
                                    {
                                        objImplementacaoBancoDadosTabelaEmpregadosMobile[NumeroIdentificacao].Dispose();
                                        objImplementacaoBancoDadosTabelaEmpregadosMobile[NumeroIdentificacao] = null;
                                    }

                                    break;
                                }

                                System.Threading.Thread.Sleep(1);
                            }
                        }
                        else
                        {
                            mtdResetarContadorTabelaEmpregadosMobile(NumeroIdentificacao);
                        }

                        try
                        {
                            System.GC.Collect();
                        }
                        catch (System.Exception ex)
                        {
                        }
                    }
                    catch (Exception ex)
                    {
                        if (objImplementacaoBancoDadosTabelaEmpregadosMobile[NumeroIdentificacao] != null)
                        {
                            objImplementacaoBancoDadosTabelaEmpregadosMobile[NumeroIdentificacao].Dispose();
                            objImplementacaoBancoDadosTabelaEmpregadosMobile[NumeroIdentificacao] = null;
                        }
                        mtdResetarContadorTabelaEmpregadosMobile(NumeroIdentificacao);

                        string strExcecao = "getTabelaEmpregadosMobile: " + ex.Message;
                        System.Diagnostics.Debug.WriteLine(strExcecao);
                        // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
                    }

                }
            }

            return AjustadorDadosTabelaEmpregadosMobile[NumeroIdentificacao];
        }

        private static int[] intPassoTabelaInventarioBensMobile = new int[cntIntNumeroInstancias];

        private static clsImplementacaoBancoDados[] objImplementacaoBancoDadosTabelaInventarioBensMobile = new clsImplementacaoBancoDados[cntIntNumeroInstancias];

        private static bool[] ForcarParadagetTabelaInventarioBensMobile = new bool[cntIntNumeroInstancias];
        //private static object LockTabelaInventarioBensMobile = new object();

        [WebMethod]
        public System.Data.DataSet getTabelaInventarioBensMobile(string BancoDados, int Passo, int NumeroIdentificacao)
        {
            // lock (LockTabelaInventarioBensMobile)
            {
                System.Threading.Thread.Sleep(1);

                ForcarParadagetTabelaInventarioBensMobile[NumeroIdentificacao] = false;

                if (NumeroIdentificacao > -1 && NumeroIdentificacao < cntIntNumeroInstancias)
                {
                    intPassoTabelaInventarioBensMobile[NumeroIdentificacao] = Passo;
                    try
                    {
                        if (AjustadorDadosTabelaInventarioBensMobile[NumeroIdentificacao] == null)
                        {
                            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
                            string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
                            objImplementacaoBancoDadosTabelaInventarioBensMobile[NumeroIdentificacao] = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

                            objImplementacaoBancoDadosTabelaInventarioBensMobile[NumeroIdentificacao].mtdAbrirConexao();
                            objImplementacaoBancoDadosTabelaInventarioBensMobile[NumeroIdentificacao].mtdExecutarComando
                                (
                                string.Format
                                (
                                "SELECT TOP {0} {1} FROM {2} ORDER BY {3} {4};",
                                1,
                                objImplementacaoBancoDadosTabelaInventarioBensMobile[NumeroIdentificacao].mtdVetorLinhaCampos(Default.vetCamposTabelaInventarioBens),
                                Default.strTabelaInventarioBens,
                                Default.vetCamposTabelaInventarioBens[Default.intColunaTabelaInventarioBensNumero_Inventario],
                                string.Empty
                                )
                                );

                            objImplementacaoBancoDadosTabelaInventarioBensMobile[NumeroIdentificacao].mtdAdaptadorDados();
                            //System.Data.DataSet AjustadorDados = objImplementacaoBancoDadosTabelaInventarioBensMobile[NumeroIdentificacao].prpAjustadorDados;
                            AjustadorDadosTabelaInventarioBensMobile[NumeroIdentificacao] = new System.Data.DataSet();
                            //AjustadorDadosTabelaInventarioBensMobile[NumeroIdentificacao].Tables.Add(AjustadorDados.Tables[0].Clone());
                            AjustadorDadosTabelaInventarioBensMobile[NumeroIdentificacao].Tables.Add(objImplementacaoBancoDadosTabelaInventarioBensMobile[NumeroIdentificacao].prpAjustadorDados.Tables[0].Clone());

                            objImplementacaoBancoDadosTabelaInventarioBensMobile[NumeroIdentificacao].mtdExecutarComando
                                (
                                string.Format
                                (
                                "SELECT {0} FROM {1} ORDER BY {2} {3};",
                                objImplementacaoBancoDadosTabelaInventarioBensMobile[NumeroIdentificacao].mtdVetorLinhaCampos(Default.vetCamposTabelaInventarioBens),
                                Default.strTabelaInventarioBens,
                                Default.vetCamposTabelaInventarioBens[Default.intColunaTabelaInventarioBensNumero_Inventario],
                                string.Empty
                                )
                                );

                            objImplementacaoBancoDadosTabelaInventarioBensMobile[NumeroIdentificacao].mtdDefinirLeitorDados();
                        }

                        AjustadorDadosTabelaInventarioBensMobile[NumeroIdentificacao].Tables[0].Rows.Clear();

                        if (objImplementacaoBancoDadosTabelaInventarioBensMobile[NumeroIdentificacao] != null)
                        {
                            for
                                (
                                int linha = 0;
                                linha <= intPassoTabelaInventarioBensMobile[NumeroIdentificacao] - 1;
                                linha++
                                )
                            {
                                if (!blnCanalAberto[NumeroIdentificacao] & Default.blnPermitirControleColetorUpLoad) break;
                                if (ForcarParadagetTabelaInventarioBensMobile[NumeroIdentificacao]) break;

                                if (objImplementacaoBancoDadosTabelaInventarioBensMobile[NumeroIdentificacao].mtdProximoRegistro())
                                {
                                    AjustadorDadosTabelaInventarioBensMobile[NumeroIdentificacao].Tables[0].Rows.Add(objImplementacaoBancoDadosTabelaInventarioBensMobile[NumeroIdentificacao].mtdObterValorRegistro());
                                }
                                else
                                {
                                    if (objImplementacaoBancoDadosTabelaInventarioBensMobile[NumeroIdentificacao] != null)
                                    {
                                        objImplementacaoBancoDadosTabelaInventarioBensMobile[NumeroIdentificacao].Dispose();
                                        objImplementacaoBancoDadosTabelaInventarioBensMobile[NumeroIdentificacao] = null;
                                    }

                                    break;
                                }

                                System.Threading.Thread.Sleep(1);
                            }
                        }
                        else
                        {
                            mtdResetarContadorTabelaInventarioBensMobile(NumeroIdentificacao);
                        }

                        try
                        {
                            System.GC.Collect();
                        }
                        catch (System.Exception ex)
                        {
                        }
                    }
                    catch (Exception ex)
                    {
                        if (objImplementacaoBancoDadosTabelaInventarioBensMobile[NumeroIdentificacao] != null)
                        {
                            objImplementacaoBancoDadosTabelaInventarioBensMobile[NumeroIdentificacao].Dispose();
                            objImplementacaoBancoDadosTabelaInventarioBensMobile[NumeroIdentificacao] = null;
                        }
                        mtdResetarContadorTabelaInventarioBensMobile(NumeroIdentificacao);

                        string strExcecao = "getTabelaInventarioBensMobile: " + ex.Message;
                        System.Diagnostics.Debug.WriteLine(strExcecao);
                        // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
                    }
                }
            }

            return AjustadorDadosTabelaInventarioBensMobile[NumeroIdentificacao];
        }

        // private static object LockTabelaCentroCusto = new object();

        //[System.Web.Services.Protocols.SoapHeader("Authentication", Required = true)]
        [WebMethod]
        public System.Data.DataSet getTabelaCentroCusto(string BancoDados)
        {
            // lock (LockTabelaCentroCusto)
            {
                // System.Threading.Thread.Sleep(1);

                return getTabela(BancoDados, Default.strTabelaCentroCusto);
            }
        }

        // private static object LockTabelaBensEletronorte = new object();

        [WebMethod]
        public System.Data.DataSet getTabelaBensEletronorte(string BancoDados)
        {
            // lock (LockTabelaBensEletronorte)
            {
                // System.Threading.Thread.Sleep(1);

                return getTabela(BancoDados, Default.strTabelaBensEletronorte);
            }
        }

        // private static object LockTabelaEmpregados = new object();

        [WebMethod]
        public System.Data.DataSet getTabelaEmpregados(string BancoDados)
        {
            // lock (LockTabelaEmpregados)
            {
                // System.Threading.Thread.Sleep(1);

                return getTabela(BancoDados, Default.strTabelaEmpregados);
            }
        }

        // private static object LockTabelaInventarioBens_g = new object();

        [WebMethod]
        public System.Data.DataSet getTabelaInventarioBens(string BancoDados)
        {
            // lock (LockTabelaInventarioBens_g)
            {
                // System.Threading.Thread.Sleep(1);

                return getTabela(BancoDados, Default.strTabelaInventarioBens);
            }
        }

        private static int intTempoReinicio = 15;
        private static int intNumeroOtimizado = 1000;
        private static ulong ulngProximoNumeroCodigo = 0;
        private static bool blnGerarProximoNumeroCodigo = true;

        private static int[] intNumeroItensInseridos = new int[cntIntNumeroInstancias];
        private static int[] intNumeroItensAtualizados = new int[cntIntNumeroInstancias];
        private static int[] intNumeroItensInalterados = new int[cntIntNumeroInstancias];

        private bool blnComandoImplementadoSetTabelaInventarioBens = false;

        private static int[] intLinhaTabelaInventarioBens = new int[cntIntNumeroInstancias];
        private static int[] intLinhaTotalTabelaInventarioBens = new int[cntIntNumeroInstancias];
        private static int[] intLinhaAcumuladoTotalTabelaInventarioBens = new int[cntIntNumeroInstancias];

        private static bool[] ForcarParadasetTabelaInventarioBens_ = new bool[cntIntNumeroInstancias];
        private static object LockTabelaInventarioBens_ = new object();

        public void setTabelaInventarioBens_(string BancoDados, System.Data.DataSet AjustadorDados, int NumeroIdentificacao)
        {
            lock (LockTabelaInventarioBens_)
            {
                System.Threading.Thread.Sleep(1);

                ForcarParadasetTabelaInventarioBens_[NumeroIdentificacao] = false;
                string mensagemErro = string.Empty;

                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
                string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
                clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

                //objImplementacaoBancoDados.mtdSelecionarDados(0, "*", Default.strTabelaInventarioBens, Default.vetCamposTabelaInventarioBens[Default.intColunaTabelaInventarioBensNumero_Inventario], true);
                //objImplementacaoBancoDados.mtdAdaptadorDados();

                object[][] dados = new object[3][];
                dados[0] = new object[Default.vetCamposTabelaInventarioBens.Length];
                dados[1] = new object[Default.vetCamposTabelaInventarioBens.Length];
                dados[2] = new object[Default.vetCamposTabelaInventarioBens.Length];

                for (int coluna = 0; coluna <= Default.vetCamposTabelaInventarioBens.Length - 1; coluna++)
                {
                    dados[0][coluna] = Default.vetCamposTabelaInventarioBens[coluna];
                    switch (coluna)
                    {
                        case 1:
                            dados[1][coluna] = System.Data.OleDb.OleDbType.Date;
                            break;
                        default:
                            dados[1][coluna] = null;
                            break;
                    }
                }

                intLinhaTotalTabelaInventarioBens[NumeroIdentificacao] = AjustadorDados.Tables[0].Rows.Count;
                intLinhaAcumuladoTotalTabelaInventarioBens[NumeroIdentificacao] += intLinhaTotalTabelaInventarioBens[NumeroIdentificacao];

                for (int linha = 0; linha <= intLinhaTotalTabelaInventarioBens[NumeroIdentificacao] - 1; linha++)
                {
                    intLinhaTabelaInventarioBens[NumeroIdentificacao] = linha;

                    for (int coluna = 0; coluna <= Default.vetCamposTabelaInventarioBens.Length - 1; coluna++)
                    {
                        dados[2][coluna] = AjustadorDados.Tables[0].Rows[linha][coluna];
                    }

                    if (blnGerarProximoNumeroCodigo)
                    {
                        ulngProximoNumeroCodigo = Default.mtdGerarProximoNumeroCodigo
                        (
                        BancoDados,
                        Default.strTabelaInventarioBens,
                        Default.vetCamposTabelaInventarioBens[Default.intColunaTabelaInventarioBensNumero_Inventario],
                        intNumeroOtimizado,
                        intTempoReinicio
                        );
                    }

                    dados[2][0] = ulngProximoNumeroCodigo;

                    //if (!mtdVerificarExistenciaRegistro(BancoDados, Default.strTabelaInventarioBens, Default.vetCamposTabelaInventarioBens[Default.intColunaTabelaInventarioBensInventario], dados[2][Default.intColunaTabelaInventarioBensInventario]))
                    //{
                    switch (BancoDados)
                    {
                        case "Principal":
                            blnComandoImplementadoSetTabelaInventarioBens = objImplementacaoBancoDados.mtdInserirDadosParametroComandoOleDb
                                (
                                Default.strTabelaInventarioBens,
                                dados,
                                clsImplementacaoBancoDados.enmModoParametroComando.ValorTipo
                                );
                            break;
                        case "Coletor":
                            blnComandoImplementadoSetTabelaInventarioBens = objImplementacaoBancoDados.mtdInserirDadosParametroComandoSQLServerCE
                                (
                                Default.strTabelaInventarioBens,
                                dados,
                                clsImplementacaoBancoDados.enmModoParametroComando.ValorTipo
                                );
                            break;
                    }
                    // System.Threading.Thread.Sleep(1);
                    //}
                    //else
                    //{
                    //    blnComandoImplementadoSetTabelaInventarioBens = false;

                    //long lngCodigoEspalhamentoColetor = mtdCalcularCodigoEspalhamentoTabelaInventarioBens
                    //    (
                    //    BancoDados,
                    //    Default.vetCamposTabelaInventarioBens[Default.intColunaTabelaInventarioBensInventario],
                    //    dados[2][Default.intColunaTabelaInventarioBensInventario]
                    //    );
                    //long lngCodigoEspalhamentoAjustadorDados = mtdCalcularCodigoEspalhamentoAjustadorDadosTabelaInventarioBensLinha
                    //    (
                    //    AjustadorDados,
                    //    linha
                    //    );

                    //if (lngCodigoEspalhamentoColetor != lngCodigoEspalhamentoAjustadorDados)
                    if (!blnComandoImplementadoSetTabelaInventarioBens)
                    {
                        if (
                            Default.mtdVerificarDataMaisAtualAjustadorDadosInventarioBensTabelaInventarioBens
                            (
                            AjustadorDados,
                            linha,
                            1,
                            BancoDados,
                            Default.vetCamposTabelaInventarioBens[Default.intColunaTabelaInventarioBensInventario],
                            dados[2][Default.intColunaTabelaInventarioBensInventario]
                            )
                            )
                        {
                            switch (BancoDados)
                            {
                                case "Principal":
                                    blnComandoImplementadoSetTabelaInventarioBens = objImplementacaoBancoDados.mtdAtualizarDadosParametroComandoOleDb
                                        (
                                        Default.strTabelaInventarioBens,
                                        dados,
                                        Default.vetCamposTabelaInventarioBens[Default.intColunaTabelaInventarioBensInventario],
                                        "LIKE",
                                        dados[2][Default.intColunaTabelaInventarioBensInventario],
                                        clsImplementacaoBancoDados.enmModoParametroComando.ValorTipo
                                        );
                                    break;
                                case "Coletor":
                                    blnComandoImplementadoSetTabelaInventarioBens = objImplementacaoBancoDados.mtdAtualizarDadosParametroComandoSQLServerCE
                                        (
                                        Default.strTabelaInventarioBens,
                                        dados,
                                        Default.vetCamposTabelaInventarioBens[Default.intColunaTabelaInventarioBensInventario],
                                        "LIKE",
                                        dados[2][Default.intColunaTabelaInventarioBensInventario],
                                        clsImplementacaoBancoDados.enmModoParametroComando.ValorTipo
                                        );
                                    break;
                            }

                            if (blnComandoImplementadoSetTabelaInventarioBens)
                            {
                                intNumeroItensAtualizados[NumeroIdentificacao]++;
                            }
                            else
                            {
                                intNumeroItensInalterados[NumeroIdentificacao]++;
                            }
                            System.Threading.Thread.Sleep(1);
                        }
                        else
                        {
                            intNumeroItensInalterados[NumeroIdentificacao]++;

                            mensagemErro = objImplementacaoBancoDados.getExcecao;
                        }
                    }
                    else
                    {
                        intNumeroItensInseridos[NumeroIdentificacao]++;
                    }

                    blnGerarProximoNumeroCodigo = blnComandoImplementadoSetTabelaInventarioBens;
                    //}

                    if (!blnCanalAberto[NumeroIdentificacao] & Default.blnPermitirControleColetorUpLoad) { blnGerarProximoNumeroCodigo = true; break; }
                    if (ForcarParadasetTabelaInventarioBens_[NumeroIdentificacao]) { blnGerarProximoNumeroCodigo = true; break; }

                    System.Threading.Thread.Sleep(1);
                }

                try
                {
                    System.GC.Collect();
                }
                catch (System.Exception ex)
                {
                    blnGerarProximoNumeroCodigo = true;
                }
                finally
                {
                    intLinhaTabelaInventarioBens[NumeroIdentificacao] = 0;
                    intLinhaTotalTabelaInventarioBens[NumeroIdentificacao] = 0;
                    //intLinhaAcumuladoTotalTabelaInventarioBens[NumeroIdentificacao] = 0;
                }

                objImplementacaoBancoDados.Dispose();
            }
        }

        private string BancoDados_setTabelaInventarioBens = string.Empty;
        System.Data.DataSet AjustadorDados_setTabelaInventarioBens = new System.Data.DataSet();
        int NumeroIdentificacao_setTabelaInventarioBens = 0;

        //private static object LocksetTabelaInventarioBens = new object();

        [WebMethod]
        public void setTabelaInventarioBens(string BancoDados, System.Data.DataSet AjustadorDados, int NumeroIdentificacao)
        {
            // lock (LockTabelaInventarioBens)
            {
                this.BancoDados_setTabelaInventarioBens = BancoDados;
                this.AjustadorDados_setTabelaInventarioBens = AjustadorDados;
                this.NumeroIdentificacao_setTabelaInventarioBens = NumeroIdentificacao;

                mtdIniciarThreadsetTabelaInventarioBens();
            }
        }

        // private static object LockTabelaInventarioBens_p = new object();

        [WebMethod]
        public System.Data.DataSet prpTabelaInventarioBens(string BancoDados, System.Data.DataSet AjustadorDados, int NumeroIdentificacao)
        {
            // lock (LockTabelaInventarioBens_p)
            {
                // System.Threading.Thread.Sleep(1);

                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
                string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
                clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

                setTabelaInventarioBens(BancoDados, AjustadorDados, NumeroIdentificacao);

                objImplementacaoBancoDados.mtdSelecionarDados("*", Default.strTabelaInventarioBens, Default.vetCamposTabelaInventarioBens[Default.intColunaTabelaInventarioBensNumero_Inventario], true);
                objImplementacaoBancoDados.mtdAdaptadorDados();
                System.Data.DataSet sAjustadorDados = objImplementacaoBancoDados.prpAjustadorDados;

                objImplementacaoBancoDados.Dispose();

                return sAjustadorDados;
            }
        }

        // private static object LockUploadArquivo = new object();

        /// <summary> 
        /// Upload any file to the web service; this function may be 
        /// used in any application where it is necessary to upload 
        /// a file through a web service 
        /// </summary> 
        /// <param name="NomeArquivo">Pass the file path to upload</param> 
        [WebMethod]
        public bool mtdUploadArquivo(byte[] f, string NomeArquivo)
        {
            // lock (LockUploadArquivo)
            {
                // System.Threading.Thread.Sleep(1);

                bool retorno = false;
                // the byte array argument contains the content of the file 
                // the string argument contains the name and extension 
                // of the file passed in the byte array 
                try
                {
                    // instance a memory stream and pass the 
                    // byte array to its constructor 
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(f);

                    // instance a filestream pointing to the 
                    // storage folder, use the original file name 
                    // to name the resulting file 
                    System.IO.FileStream fs = new System.IO.FileStream
                        (
                        string.Format("{0}{1}", Default.DiretorioArmazenamentoCompleto, NomeArquivo),
                        System.IO.FileMode.Create
                        );
                    // write the memory stream containing the original 
                    // file as a byte array to the filestream 
                    ms.WriteTo(fs);
                    // clean up 
                    ms.Close();
                    fs.Close();
                    fs.Dispose();
                    // return OK if we made it this far 
                    retorno = true;
                }
                catch (Exception ex)
                {
                    // return the error message if the operation fails 
                    retorno = false;
                }

                return retorno;
            }
        }

        // private static object LockVerificarExistenciaRegistro = new object();

        private bool mtdVerificarExistenciaRegistro(string BancoDados, string Tabela, string CampoSelecionador, object Dado)
        {
            // lock (LockVerificarExistenciaRegistro)
            {
                bool saida = false;

                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
                string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
                clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

                switch (BancoDados)
                {
                    case "Principal":
                        objImplementacaoBancoDados.mtdSelecionarDadosParametroComandoOleDb(1, "*", Tabela, CampoSelecionador, "LIKE", Dado);
                        break;
                    case "Coletor":
                        objImplementacaoBancoDados.mtdSelecionarDadosParametroComandoSQLServerCE(1, "*", Tabela, CampoSelecionador, "LIKE", Dado);
                        break;
                }

                objImplementacaoBancoDados.mtdDefinirLeitorDados();
                saida = objImplementacaoBancoDados.mtdProximoRegistro();

                objImplementacaoBancoDados.Dispose();

                return saida;
            }
        }

        // private static object LockObterDataTempoSistemaAtual = new object();

        [WebMethod]
        public System.DateTime mtdObterDataTempoSistemaAtual()
        {
            // lock (LockObterDataTempoSistemaAtual)
            {
                // System.Threading.Thread.Sleep(1);

                return System.DateTime.Now;
            }
        }

        // private static object LockObterDataTempoSistemaUtc = new object();

        [WebMethod]
        public System.DateTime mtdObterDataTempoSistemaUtc()
        {
            // lock (LockObterDataTempoSistemaUtc)
            {
                // System.Threading.Thread.Sleep(1);

                return System.DateTime.UtcNow;
            }
        }

        // private static object LockCalcularCodigoEspalhamentoTotal = new object();

        [WebMethod]
        public long mtdCalcularCodigoEspalhamentoTotal(string BancoDados, string Tabela, string CampoSelecionador)
        {
            // lock (LockCalcularCodigoEspalhamentoTotal)
            {
                // System.Threading.Thread.Sleep(1);

                return mtdCalcularCodigoEspalhamento(BancoDados, Tabela, CampoSelecionador, "%");
            }
        }

        // private static object LockCalcularCodigoEspalhamento = new object();

        [WebMethod]
        public long mtdCalcularCodigoEspalhamento(string BancoDados, string Tabela, string CampoSelecionador, object Dado)
        {
            // lock (LockCalcularCodigoEspalhamento)
            {
                // System.Threading.Thread.Sleep(1);

                long saida = 0;

                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
                string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
                clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

                switch (BancoDados)
                {
                    case "Principal":
                        objImplementacaoBancoDados.mtdSelecionarDadosParametroComandoOleDb(0, "*", Tabela, CampoSelecionador, "LIKE", Dado);
                        break;
                    case "Coletor":
                        objImplementacaoBancoDados.mtdSelecionarDadosParametroComandoSQLServerCE(0, "*", Tabela, CampoSelecionador, "LIKE", Dado);
                        break;
                }

                objImplementacaoBancoDados.mtdDefinirLeitorDados();
                int numColunas = objImplementacaoBancoDados.mtdNumeroColunas();

                while (objImplementacaoBancoDados.mtdProximoRegistro())
                {
                    for (int coluna = 0; coluna <= numColunas - 1; coluna++)
                    {
                        saida = saida ^ mtdObterCodigoEspalhamento(objImplementacaoBancoDados.mtdObterValorRegistro(coluna).ToString());
                    }
                }

                objImplementacaoBancoDados.Dispose();

                return saida;
            }
        }

        // private static object LockCalcularCodigoEspalhamentoTabelaInventarioBensTotal = new object();

        [WebMethod]
        public long mtdCalcularCodigoEspalhamentoTabelaInventarioBensTotal(string BancoDados)
        {
            // lock (LockCalcularCodigoEspalhamentoTabelaInventarioBensTotal)
            {
                // System.Threading.Thread.Sleep(1);

                return mtdCalcularCodigoEspalhamentoTabelaInventarioBens(BancoDados, Default.vetCamposTabelaInventarioBens[Default.intColunaTabelaInventarioBensInventario], "%");
            }
        }

        // private static object LockCalcularCodigoEspalhamentoTabelaInventarioBens = new object();

        [WebMethod]
        public long mtdCalcularCodigoEspalhamentoTabelaInventarioBens(string BancoDados, string CampoSelecionador, object Dado)
        {
            // lock (LockCalcularCodigoEspalhamentoTabelaInventarioBens)
            {
                // System.Threading.Thread.Sleep(1);

                long saida = 0;
                string Tabela = Default.strTabelaInventarioBens;

                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
                string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
                clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

                switch (BancoDados)
                {
                    case "Principal":
                        objImplementacaoBancoDados.mtdSelecionarDadosParametroComandoOleDb(0, "*", Tabela, CampoSelecionador, "LIKE", Dado);
                        break;
                    case "Coletor":
                        objImplementacaoBancoDados.mtdSelecionarDadosParametroComandoSQLServerCE(0, "*", Tabela, CampoSelecionador, "LIKE", Dado);
                        break;
                }

                objImplementacaoBancoDados.mtdDefinirLeitorDados();
                int numColunas = objImplementacaoBancoDados.mtdNumeroColunas();

                while (objImplementacaoBancoDados.mtdProximoRegistro())
                {
                    for (int coluna = 1; coluna <= numColunas - 1; coluna++)
                    {
                        switch (coluna)
                        {
                            case Default.intColunaTabelaInventarioBensData_Inventario:
                                saida = saida ^ mtdObterCodigoEspalhamento
                                    (
                                    System.Convert.ToString
                                    (
                                    System.Convert.ToDateTime
                                    (
                                    objImplementacaoBancoDados.mtdObterValorRegistro(coluna)
                                    ).Ticks
                                    )
                                    );
                                break;
                            case Default.intColunaTabelaInventarioBensInventario:
                                saida = saida ^ mtdObterCodigoEspalhamento(string.Empty);
                                break;
                            default:
                                saida = saida ^ mtdObterCodigoEspalhamento(objImplementacaoBancoDados.mtdObterValorRegistro(coluna).ToString());
                                break;
                        }
                    }
                }

                objImplementacaoBancoDados.Dispose();

                return saida;
            }
        }

        // private static object LockCalcularCodigoEspalhamentoAjustadorDados = new object();

        [WebMethod]
        public long mtdCalcularCodigoEspalhamentoAjustadorDados(System.Data.DataSet AjustadorDados)
        {
            // lock (LockCalcularCodigoEspalhamentoAjustadorDados)
            {
                // System.Threading.Thread.Sleep(1);

                long saida = 0;

                int numLinhas = AjustadorDados.Tables[0].Rows.Count;

                for (int linha = 1; linha <= numLinhas - 1; linha++)
                {
                    saida = saida ^ mtdCalcularCodigoEspalhamentoAjustadorDadosTabelaInventarioBensLinha(AjustadorDados, linha);
                }

                return saida;
            }
        }

        // private static object LockCalcularCodigoEspalhamentoAjustadorDadosLinha = new object();

        [WebMethod]
        public long mtdCalcularCodigoEspalhamentoAjustadorDadosLinha(System.Data.DataSet AjustadorDados, int linha)
        {
            // lock (LockCalcularCodigoEspalhamentoAjustadorDadosLinha)
            {
                // System.Threading.Thread.Sleep(1);

                long saida = 0;

                int numColunas = AjustadorDados.Tables[0].Columns.Count;

                for (int coluna = 0; coluna <= numColunas - 1; coluna++)
                {
                    saida = saida ^ mtdObterCodigoEspalhamento(AjustadorDados.Tables[0].Rows[linha][coluna].ToString());
                }

                return saida;
            }
        }

        // private static object LockCalcularCodigoEspalhamentoAjustadorDadosTabelaInventarioBensLinha = new object();

        [WebMethod]
        public long mtdCalcularCodigoEspalhamentoAjustadorDadosTabelaInventarioBensLinha(System.Data.DataSet AjustadorDados, int linha)
        {
            // lock (LockCalcularCodigoEspalhamentoAjustadorDadosLinha)
            {
                // System.Threading.Thread.Sleep(1);

                long saida = 0;

                int numColunas = AjustadorDados.Tables[0].Columns.Count;

                for (int coluna = 1; coluna <= numColunas - 1; coluna++)
                {
                    switch (coluna)
                    {
                        case Default.intColunaTabelaInventarioBensData_Inventario:
                            saida = saida ^ mtdObterCodigoEspalhamento
                                (
                                System.Convert.ToString
                                (
                                System.Convert.ToDateTime
                                (
                                AjustadorDados.Tables[0].Rows[linha][coluna]
                                ).Ticks
                                )
                                );
                            break;
                        case Default.intColunaTabelaInventarioBensInventario:
                            saida = saida ^ mtdObterCodigoEspalhamento(string.Empty);
                            break;
                        default:
                            saida = saida ^ mtdObterCodigoEspalhamento(AjustadorDados.Tables[0].Rows[linha][coluna].ToString());
                            break;
                    }
                }

                return saida;
            }
        }

        // private static object LockObterNumeroColunas = new object();

        [WebMethod]
        public long mtdObterNumeroColunas(string BancoDados, string Tabela, string CampoSelecionador, object Dado)
        {
            // lock (LockObterNumeroColunas)
            {
                // System.Threading.Thread.Sleep(1);

                long saida = 0;

                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
                string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
                clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

                switch (BancoDados)
                {
                    case "Principal":
                        objImplementacaoBancoDados.mtdSelecionarDadosParametroComandoOleDb(0, "*", Tabela, CampoSelecionador, "LIKE", Dado);
                        break;
                    case "Coletor":
                        objImplementacaoBancoDados.mtdSelecionarDadosParametroComandoSQLServerCE(0, "*", Tabela, CampoSelecionador, "LIKE", Dado);
                        break;
                }

                objImplementacaoBancoDados.mtdDefinirLeitorDados();

                saida = objImplementacaoBancoDados.mtdNumeroColunas();

                objImplementacaoBancoDados.Dispose();

                return saida;
            }
        }

        // private static object LockObterNumeroLinhas = new object();

        [WebMethod]
        public long mtdObterNumeroLinhas(string BancoDados, string Tabela, string CampoSelecionador, object Dado)
        {
            // lock (LockObterNumeroLinhas)
            {
                // System.Threading.Thread.Sleep(1);

                long saida = 0;

                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
                string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
                clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

                switch (BancoDados)
                {
                    case "Principal":
                        objImplementacaoBancoDados.mtdSelecionarDadosParametroComandoOleDb(0, "*", Tabela, CampoSelecionador, "LIKE", Dado);
                        break;
                    case "Coletor":
                        objImplementacaoBancoDados.mtdSelecionarDadosParametroComandoSQLServerCE(0, "*", Tabela, CampoSelecionador, "LIKE", Dado);
                        break;
                }

                objImplementacaoBancoDados.mtdDefinirLeitorDados();

                saida = objImplementacaoBancoDados.mtdNumeroLinhas();

                objImplementacaoBancoDados.Dispose();

                return saida;
            }
        }

        // private static object LockObterNumeroColunasAjustadorDados = new object();

        [WebMethod]
        public int mtdObterNumeroColunasAjustadorDados(System.Data.DataSet AjustadorDados)
        {
            // lock (LockObterNumeroColunasAjustadorDados)
            {
                // System.Threading.Thread.Sleep(1);

                return AjustadorDados.Tables[0].Columns.Count;
            }
        }

        // private static object LockObterNumeroLinhasAjustadorDados = new object();

        [WebMethod]
        public int mtdObterNumeroLinhasAjustadorDados(System.Data.DataSet AjustadorDados)
        {
            // lock (LockObterNumeroLinhasAjustadorDados)
            {
                // System.Threading.Thread.Sleep(1);

                return AjustadorDados.Tables[0].Rows.Count;
            }
        }

        // private static object LockObterNumeroLinhasAjustadorDadosTabela = new object();

        [WebMethod]
        public int mtdObterNumeroLinhasAjustadorDadosTabela(System.Data.DataSet AjustadorDados, int Tabela)
        {
            // lock (LockObterNumeroLinhasAjustadorDados)
            {
                // System.Threading.Thread.Sleep(1);

                return AjustadorDados.Tables[Tabela].Rows.Count;
            }
        }

        [WebMethod]
        public bool mtdTestarConexaoAbertaBancoDados(string BancoDados)
        {
            // System.Threading.Thread.Sleep(1);

            return login.mtdTestarConexaoAbertaBancoDados(BancoDados);
        }

        [WebMethod]
        public bool mtdTestarExecucaoComandoBancoDados(string BancoDados, string Tabela)
        {
            // System.Threading.Thread.Sleep(1);

            return login.mtdTestarExecucaoComandoBancoDados(BancoDados, Tabela);
        }

        [WebMethod]
        public void mtdResetarConfiguracoes()
        {
            // System.Threading.Thread.Sleep(1);

            Default.mtdResetarConfiguracoes();
        }

        [WebMethod]
        public void mtdIniciarCriacaoTabelas()
        {
            Default.mtdIniciarCriacaoTabelas();
        }

        // private static object LockObterCodigoEspalhamento = new object();

        private long mtdObterCodigoEspalhamento(string Dado)
        {
            // lock (LockObterCodigoEspalhamento)
            {
                // System.Threading.Thread.Sleep(1);

                long saida = 0;

                System.Security.Cryptography.HashAlgorithm algorithm = System.Security.Cryptography.SHA1.Create();
                Byte[] vetData = System.Text.Encoding.Unicode.GetBytes(Dado);
                Byte[] vetDataHash = algorithm.ComputeHash(vetData);
                saida = BitConverter.ToInt64(vetDataHash, 0);

                return saida;
            }
        }

        // private static object LockObterLinhaTabelaInventarioBens = new object();

        [WebMethod]
        public int mtdObterLinhaTabelaInventarioBens(int NumeroIdentificacao)
        {
            // lock (LockObterLinhaTabelaInventarioBens)
            {
                // System.Threading.Thread.Sleep(1);

                int Retorno = 0;

                if (NumeroIdentificacao >= intLinhaTabelaInventarioBens.GetLowerBound(0) & NumeroIdentificacao <= intLinhaTabelaInventarioBens.GetUpperBound(0))
                {
                    Retorno = intLinhaTabelaInventarioBens[NumeroIdentificacao];
                }
                else
                {
                    Retorno = 0;
                }

                return Retorno;
            }
        }

        // private static object LockObterLinhaTotalTabelaInventarioBens = new object();

        [WebMethod]
        public int mtdObterLinhaTotalTabelaInventarioBens(int NumeroIdentificacao)
        {
            // lock (LockObterLinhaTotalTabelaInventarioBens)
            {
                // System.Threading.Thread.Sleep(1);

                int Retorno = 0;

                if (NumeroIdentificacao >= intLinhaTotalTabelaInventarioBens.GetLowerBound(0) & NumeroIdentificacao <= intLinhaTotalTabelaInventarioBens.GetUpperBound(0))
                {
                    Retorno = intLinhaTotalTabelaInventarioBens[NumeroIdentificacao];
                }
                else
                {
                    Retorno = 0;
                }

                return Retorno;
            }
        }

        // private static object LockObterLinhaAcumuladoTotalTabelaInventarioBens = new object();

        [WebMethod]
        public int mtdObterLinhaAcumuladoTotalTabelaInventarioBens(int NumeroIdentificacao)
        {
            // lock (LockObterLinhaAcumuladoTotalTabelaInventarioBens)
            {
                // System.Threading.Thread.Sleep(1);

                int Retorno = 0;

                if (NumeroIdentificacao >= intLinhaAcumuladoTotalTabelaInventarioBens.GetLowerBound(0) & NumeroIdentificacao <= intLinhaAcumuladoTotalTabelaInventarioBens.GetUpperBound(0))
                {
                    Retorno = intLinhaAcumuladoTotalTabelaInventarioBens[NumeroIdentificacao];
                }
                else
                {
                    Retorno = 0;
                }

                return Retorno;
            }
        }

        // private static object LockObterNumeroItensInseridos = new object();

        [WebMethod]
        public int mtdObterNumeroItensInseridos(int NumeroIdentificacao)
        {
            // lock (LockObterNumeroItensInseridos)
            {
                // System.Threading.Thread.Sleep(1);

                int Retorno = 0;

                if (NumeroIdentificacao >= intNumeroItensInseridos.GetLowerBound(0) & NumeroIdentificacao <= intNumeroItensInseridos.GetUpperBound(0))
                {
                    Retorno = intNumeroItensInseridos[NumeroIdentificacao];
                }
                else
                {
                    Retorno = 0;
                }

                return Retorno;
            }
        }

        // private static object LockObterNumeroItensAtualizados = new object();

        [WebMethod]
        public int mtdObterNumeroItensAtualizados(int NumeroIdentificacao)
        {
            // lock (LockObterNumeroItensAtualizados)
            {
                // System.Threading.Thread.Sleep(1);

                int Retorno = 0;

                if (NumeroIdentificacao >= intNumeroItensAtualizados.GetLowerBound(0) & NumeroIdentificacao <= intNumeroItensAtualizados.GetUpperBound(0))
                {
                    Retorno = intNumeroItensAtualizados[NumeroIdentificacao];
                }
                else
                {
                    Retorno = 0;
                }

                return Retorno;
            }
        }

        // private static object LockObterNumeroItensInalterados = new object();

        [WebMethod]
        public int mtdObterNumeroItensInalterados(int NumeroIdentificacao)
        {
            // lock (LockObterNumeroItensInalterados)
            {
                // System.Threading.Thread.Sleep(1);

                int Retorno = 0;

                if (NumeroIdentificacao >= intNumeroItensInalterados.GetLowerBound(0) & NumeroIdentificacao <= intNumeroItensInalterados.GetUpperBound(0))
                {
                    Retorno = intNumeroItensInalterados[NumeroIdentificacao];
                }
                else
                {
                    Retorno = 0;
                }

                return Retorno;
            }
        }

        // private static object LockResetarContadorLinhaAcumuladoTotalTabelaInventarioBens = new object();

        [WebMethod]
        public void mtdResetarContadorLinhaAcumuladoTotalTabelaInventarioBens(int NumeroIdentificacao)
        {
            // lock (LockResetarContadorLinhaAcumuladoTotalTabelaInventarioBens)
            {
                // System.Threading.Thread.Sleep(1);

                bool Retorno = false;

                if (NumeroIdentificacao >= intLinhaAcumuladoTotalTabelaInventarioBens.GetLowerBound(0) & NumeroIdentificacao <= intLinhaAcumuladoTotalTabelaInventarioBens.GetUpperBound(0))
                {
                    intLinhaAcumuladoTotalTabelaInventarioBens[NumeroIdentificacao] = 0;

                    intNumeroItensInseridos[NumeroIdentificacao] = 0;
                    intNumeroItensAtualizados[NumeroIdentificacao] = 0;
                    intNumeroItensInalterados[NumeroIdentificacao] = 0;

                    Retorno = true;
                }
                else
                {
                    Retorno = false;
                }

                //return Retorno;
            }
        }

        [WebMethod]
        public void mtdResetarGerarProximoNumeroCodigoOtimizado()
        {
            Default.lngAuxNumeroInventario = -1;
            //Default.dblTempoGerarProximoNumeroCodigo = DateTime.Now.TimeOfDay.TotalMilliseconds;
        }

        private const int cntIntQuantidade = 10;

        protected internal static bool[] blnCanalAberto = new bool[cntIntNumeroInstancias];
        protected internal static bool[,] blnCanalAberto_ = new bool[cntIntNumeroInstancias, cntIntQuantidade];

        // private static object LockManterCanalAberto_ = new object();

        public bool mtdManterCanalAberto_(int NumeroIdentificacao)
        {
            // lock (LockManterCanalAberto_)
            {
                // System.Threading.Thread.Sleep(1);

                bool blnRetorno = false;

                try
                {
                    if (NumeroIdentificacao > -1 && NumeroIdentificacao < cntIntNumeroInstancias)
                    {
                        blnCanalAberto[NumeroIdentificacao] = true;

                        for (int contador = 0; contador <= cntIntQuantidade - 1; contador++)
                        {
                            blnCanalAberto_[NumeroIdentificacao, contador] = true;
                        }
                    }

                    blnRetorno = true;
                }
                catch (System.Exception ex)
                {
                    blnRetorno = false;
                }

                return blnRetorno;
            }
        }

        [WebMethod]
        public bool mtdManterCanalAberto(int NumeroIdentificacao)
        {
            return mtdManterCanalAberto_(NumeroIdentificacao);
        }

        // private static object LockFecharCanal_ = new object();

        public void mtdFecharCanal_(int NumeroIdentificacao)
        {
            // lock (LockFecharCanal_)
            {
                // System.Threading.Thread.Sleep(1);

                try
                {
                    blnCanalAberto[NumeroIdentificacao] = false;
                }
                catch (System.Exception ex)
                {
                }
            }
        }

        // private static object LockFecharCanal = new object();

        [WebMethod]
        public void mtdFecharCanal(int NumeroIdentificacao)
        {
            // lock (LockFecharCanal)
            {
                // System.Threading.Thread.Sleep(1);

                mtdManterCanalAberto_(NumeroIdentificacao);
            }
        }

        private static bool mtdFecharCanais()
        {
            bool blnFinalizarProcesso = true;
            bool blnFecharCanalAberto = true;

            for (int contador = blnCanalAberto.GetLowerBound(0); contador <= blnCanalAberto.GetUpperBound(0); contador++)
            {
                blnFinalizarProcesso = blnFinalizarProcesso & !blnCanalAberto[contador];

                if (quantidade >= cntIntQuantidade)
                {
                    quantidade = 0;

                    dblTempoRotinaFecharTodosCanais = DateTime.Now.TimeOfDay.TotalMilliseconds;
                }

                try
                {
                    blnCanalAberto_[contador, quantidade++] = false;
                }
                catch (System.Exception ex)
                {
                    string strExcecao = "mtdFecharCanais: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                    // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
                }

                for (int count = blnCanalAberto_.GetLowerBound(1); count <= blnCanalAberto_.GetUpperBound(1); count++)
                {
                    blnFecharCanalAberto &= !blnCanalAberto_[contador, count];
                }

                if (blnFecharCanalAberto)
                {
                    blnCanalAberto[contador] = false;

                    try
                    {
                        if (objImplementacaoBancoDadosTabelaBensEletronorteMobile[contador] != null)
                        {
                            objImplementacaoBancoDadosTabelaBensEletronorteMobile[contador].Dispose();
                            objImplementacaoBancoDadosTabelaBensEletronorteMobile[contador] = null;
                        }
                    }
                    catch (System.Exception ex)
                    {
                        string strExcecao = "mtdFecharCanais: " + ex.Message;
                        System.Diagnostics.Debug.WriteLine(strExcecao);
                        // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
                    }
                    try
                    {
                        if (objImplementacaoBancoDadosTabelaEmpregadosMobile[contador] != null)
                        {
                            objImplementacaoBancoDadosTabelaEmpregadosMobile[contador].Dispose();
                            objImplementacaoBancoDadosTabelaEmpregadosMobile[contador] = null;
                        }
                    }
                    catch (System.Exception ex)
                    {
                        string strExcecao = "mtdFecharCanais: " + ex.Message;
                        System.Diagnostics.Debug.WriteLine(strExcecao);
                        // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
                    }
                    try
                    {
                        if (objImplementacaoBancoDadosTabelaCentroCustoMobile[contador] != null)
                        {
                            objImplementacaoBancoDadosTabelaCentroCustoMobile[contador].Dispose();
                            objImplementacaoBancoDadosTabelaCentroCustoMobile[contador] = null;
                        }
                    }
                    catch (System.Exception ex)
                    {
                        string strExcecao = "mtdFecharCanais: " + ex.Message;
                        System.Diagnostics.Debug.WriteLine(strExcecao);
                        // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
                    }
                    try
                    {
                        if (objImplementacaoBancoDadosTabelaInventarioBensMobile[contador] != null)
                        {
                            objImplementacaoBancoDadosTabelaInventarioBensMobile[contador].Dispose();
                            objImplementacaoBancoDadosTabelaInventarioBensMobile[contador] = null;
                        }
                    }
                    catch (System.Exception ex)
                    {
                        string strExcecao = "mtdFecharCanais: " + ex.Message;
                        System.Diagnostics.Debug.WriteLine(strExcecao);
                        // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
                    }
                }
            }

            return blnFinalizarProcesso;
        }

        public static double dblIntervaloRotinaFecharTodosCanais = 4 * 60 * 60 * 1000;
        public static double dblTempoRotinaFecharTodosCanais = DateTime.Now.TimeOfDay.TotalMilliseconds;
        public static double dblDiferencaTempoRotinaFecharTodosCanais = 0;

        private static int quantidade = 0;

        private static object LockFecharTodosCanais_ = new object();

        public static void mtdFecharTodosCanais_()
        {
            // lock (LockFecharTodosCanais_)
            {
                bool blnFinalizarProcesso = false;

                if (Default.blnPermitirControleColetorUpLoad)
                {
                    blnFinalizarProcesso = mtdFecharCanais();
                }
                else
                {
                    if (dblDiferencaTempoRotinaFecharTodosCanais >= dblIntervaloRotinaFecharTodosCanais)
                    {
                        blnFinalizarProcesso = mtdFecharCanais();
                    }
                }

                foreach (System.Diagnostics.Process processo in Default.processos)
                {
                    try
                    {
                        if (blnFinalizarProcesso || processo.WorkingSet64 > Default.intLimiteMemoria)
                        {
                            processo.Kill();
                        }
                    }
                    catch (System.Exception ex)
                    {
                        string strExcecao = "mtdFecharTodosCanais_: " + ex.Message;
                        System.Diagnostics.Debug.WriteLine(strExcecao);
                        // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
                    }
                }
            }
        }

        [WebMethod]
        public void mtdFecharTodosCanais()
        {
            // System.Threading.Thread.Sleep(1);

            Default.mtdIniciarThreadFecharTodosCanais();
        }

        // private static object LockForcarParadagetTabelaBensEletronorteMobile = new object();

        [WebMethod]
        public void mtdForcarParadagetTabelaBensEletronorteMobile(int NumeroIdentificacao)
        {
            // lock (LockForcarParadagetTabelaBensEletronorteMobile)
            {
                // System.Threading.Thread.Sleep(1);

                ForcarParadagetTabelaBensEletronorteMobile[NumeroIdentificacao] = true;
            }
        }

        // private static object LockForcarParadagetTabelaCentroCustoMobile = new object();

        [WebMethod]
        public void mtdForcarParadagetTabelaCentroCustoMobile(int NumeroIdentificacao)
        {
            // lock (LockForcarParadagetTabelaCentroCustoMobile)
            {
                // System.Threading.Thread.Sleep(1);

                ForcarParadagetTabelaCentroCustoMobile[NumeroIdentificacao] = true;
            }
        }

        // private static object LockForcarParadagetTabelaEmpregadosMobile = new object();

        [WebMethod]
        public void mtdForcarParadagetTabelaEmpregadosMobile(int NumeroIdentificacao)
        {
            // lock (LockForcarParadagetTabelaEmpregadosMobile)
            {
                // System.Threading.Thread.Sleep(1);

                ForcarParadagetTabelaEmpregadosMobile[NumeroIdentificacao] = true;
            }
        }

        // private static object LockForcarParadagetTabelaInventarioBensMobile = new object();

        [WebMethod]
        public void mtdForcarParadagetTabelaInventarioBensMobile(int NumeroIdentificacao)
        {
            // lock (LockForcarParadagetTabelaInventarioBensMobile)
            {
                // System.Threading.Thread.Sleep(1);

                ForcarParadagetTabelaInventarioBensMobile[NumeroIdentificacao] = true;
            }
        }

        // private static object LockForcarParadasetTabelaInventarioBens = new object();

        [WebMethod]
        public void mtdForcarParadasetTabelaInventarioBens(int NumeroIdentificacao)
        {
            // lock (LockForcarParadasetTabelaInventarioBens)
            {
                // System.Threading.Thread.Sleep(1);

                ForcarParadasetTabelaInventarioBens_[NumeroIdentificacao] = true;
            }
        }

        private bool isDisposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    // Code to dispose managed resources
                    // held by the class
                    if (intNumeroIdentificacao >= -1)
                    {
                        intNumeroIdentificacao--;
                    }
                    else
                    {
                        intNumeroIdentificacao = -1;
                    }
                    System.GC.Collect(0);
                }
            }
            // Code to dispose unmanaged resources
            // held by the class
            isDisposed = true;
            //base.Dispose(disposing);
        }

        ~WebServicoBancoDados()
        {
            Dispose(true);
        }
    }
}