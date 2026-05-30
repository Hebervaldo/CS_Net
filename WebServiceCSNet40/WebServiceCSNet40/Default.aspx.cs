using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebServiceCSNet40
{
    public partial class Default : System.Web.UI.Page
    {
        public static int intLimiteMemoria = 500 * 1024 * 1024;
        public static string strNomeProcesso = "w3wp";
        //public static string strNomeProcesso = "WebDev.WebServer40";

        public static System.Diagnostics.ThreadPriorityLevel thNivelPrioridade = System.Diagnostics.ThreadPriorityLevel.Highest;

        public static System.Diagnostics.Process[] processos = System.Diagnostics.Process.GetProcessesByName(strNomeProcesso);

        public static string strNomeUsuario = string.Empty;
        public static string strContaUsuario = string.Empty;
        public static string strStatusUsuario = string.Empty;

        public static string DiretorioArmazenamento = "Armazenamento";
        public static string DiretorioArmazenamentoCompleto = string.Empty;

        public static string DiretorioArmazenamentoRegistro = string.Empty;

        public static string strTabelaBensEletronorte = @"tblBensEletronorte";
        public static string strTabelaCentroCusto = @"tblCentroCusto";
        public static string strTabelaEmpregados = @"tblEmpregados";
        public static string strTabelaInventarioBens = @"tblInventarioBens";

        // Arquvio Texto
        public static string cntArquivoTexto = string.Empty;
        public static string cntNomeArquivoTexto = "ZAM017.txt";
        public static string cntEnderecoArquivoTexto = string.Empty;

        public static string strArquivoTexto = string.Empty;
        public static string strNomeArquivoTexto = string.Empty;
        public static string strEnderecoArquivoTexto = string.Empty;

        // Principal

        public static clsConexaoBancoDados.TipoConexao TipoConexaoPrincipal = clsConexaoBancoDados.TipoConexao.ConexaoAccess2003OleDb;

        //public const string cntBaseDadosPrincipal = string.Empty;
        public static string cntNomeBancoDadosPrincipal = "dbPatrimonio.mdb";
        public static string cntEnderecoBancoDadosPrincipal = string.Empty;
        public static string cntUsuarioPrincipal = string.Empty;
        public static string cntSenhaPrincipal = "12345678";

        public static string strBaseDadosPrincipal = string.Empty;
        public static string strNomeBancoDadosPrincipal = string.Empty;
        public static string strEnderecoBancoDadosPrincipal = string.Empty;
        public static string strUsuarioPrincipal = string.Empty;
        public static string strSenhaPrincipal = string.Empty;

        // Excel

        public static string cntBaseDadosExcel = string.Empty;
        public static string cntNomeBancoDadosExcel = "dbPatrimonio.xls";
        public static string cntEnderecoBancoDadosExcel = string.Empty;
        public static string cntPlanilhaExcel = "ExportacaoSAP";

        public static string strBaseDadosExcel = string.Empty;
        public static string strNomeBancoDadosExcel = string.Empty;
        public static string strEnderecoBancoDadosExcel = string.Empty;
        public static string strPlanilhaExcel = string.Empty;

        // SQL Server

        public static string cntBaseDadosCADU = string.Empty;
        public static string cntServidorCADU = @"10.61.119.27";
        public static string cntBancoDadosCADU = @"cadu";
        public static string cntUsuarioCADU = "user_bens_patrimoniais";
        public static string cntSenhaCADU = "user_bens_patrimoniais_senha";
        public static string cntTabelaCADU = "vw_patrimonio";

        public static string strBaseDadosCADU = string.Empty;
        public static string strServidorCADU = string.Empty;
        public static string strBancoDadosCADU = string.Empty;
        public static string strUsuarioCADU = string.Empty;
        public static string strSenhaCADU = string.Empty;
        public static string strTabelaCADU = string.Empty;

        // SQL Server Compact Edition

        public static string cntBaseDadosColetor = string.Empty;
        public static string cntNomeBancoDadosColetor = "dbPatrimonio.sdf";
        public static string cntEnderecoBancoDadosColetor = string.Empty;
        public static string cntSenhaColetor = "12345678";

        public static string strBaseDadosColetor = string.Empty;
        public static string strNomeBancoDadosColetor = string.Empty;
        public static string strEnderecoBancoDadosColetor = string.Empty;
        public static string strSenhaColetor = string.Empty;

        public static bool blnPermitirControleColetorUpLoad = true;

        public const int intColunaTabelaInventarioBensNumero_Inventario = 0;
        public const int intColunaTabelaInventarioBensData_Inventario = 1;
        public const int intColunaTabelaInventarioBensTRG = 2;
        public const int intColunaTabelaInventarioBensCentroCusto = 3;
        public const int intColunaTabelaInventarioBensOrgao = 4;
        public const int intColunaTabelaInventarioBensSala = 5;
        public const int intColunaTabelaInventarioBensNome = 6;
        public const int intColunaTabelaInventarioBensMatricula = 7;
        public const int intColunaTabelaInventarioBensPatrimonio = 8;
        public const int intColunaTabelaInventarioBensQuantidade = 9;
        public const int intColunaTabelaInventarioBensDenominacao = 10;
        public const int intColunaTabelaInventarioBensN_Serie = 11;
        public const int intColunaTabelaInventarioBensPlaca_Veiculo = 12;
        public const int intColunaTabelaInventarioBensIdentificacao_Inventario = 13;
        public const int intColunaTabelaInventarioBensOutrosDados_Inventario = 14;
        public const int intColunaTabelaInventarioBensObservacao = 15;
        public const int intColunaTabelaInventarioBensColetor = 16;
        public const int intColunaTabelaInventarioBensUsuario_Inventariante = 17;
        public const int intColunaTabelaInventarioBensMatricula_Inventariante = 18;
        public const int intColunaTabelaInventarioBensInventario = 19;
        public const int intColunaTabelaInventarioBensFotografia = 20;
        public const int intColunaTabelaInventarioBensGPS_Latitute = 21;
        public const int intColunaTabelaInventarioBensGPS_Longitude = 22;
        public const int intColunaTabelaInventarioBensGPS_EllipsoidAltitude = 23;
        public const int intColunaTabelaInventarioBensGPS_PositionDilutionOfPrecision = 24;

        public static string[] vetCamposTabelaInventarioBens =
        { 
        "Numero_Inventario",
        "Data_Inventario", 
        "TRG", 
        "CentroCusto", 
        "Orgao", 
        "Sala",
        "Nome", 
        "Matricula",
        "Patrimonio", 
        "Quantidade", 
        "Denominacao", 
        "N_Serie", 
        "Placa_Veiculo", 
        "Identificacao_Inventario", 
        "OutrosDados_Inventario", 
        "Observacao", 
        "Coletor",
        "Usuario_Inventariante",
        "Matricula_Inventariante", 
        "Inventario", 
        "Fotografia",
        "GPS_Latitute",
        "GPS_Longitude",
        "GPS_EllipsoidAltitude",
        "GPS_PositionDilutionOfPrecision"
        };

        public const int intColunaTabelaBensEletronortePrincipalImobilizado = 0;
        public const int intColunaTabelaBensEletronortePrincipalPatrimonio = 1;
        public const int intColunaTabelaBensEletronortePrincipalDenominacao = 2;
        public const int intColunaTabelaBensEletronortePrincipalDenominacao_Extra = 3;
        public const int intColunaTabelaBensEletronortePrincipalN_Serie = 4;
        public const int intColunaTabelaBensEletronortePrincipalSala = 5;
        public const int intColunaTabelaBensEletronortePrincipalMatricula = 6;
        public const int intColunaTabelaBensEletronortePrincipalCentro_Custo = 7;
        public const int intColunaTabelaBensEletronortePrincipalAtividade = 8;
        public const int intColunaTabelaBensEletronortePrincipalOrgao = 9;
        public const int intColunaTabelaBensEletronortePrincipalTRG = 10;
        public const int intColunaTabelaBensEletronortePrincipalPlaca_Veiculo = 11;

        public static string[] vetCamposTabelaBensEletronortePrincipal = 
        { 
        "Imobilizado",
        "Patrimonio", 
        "Denominacao",
        "Denominacao_Extra",
        "N_Serie", 
        "Sala",
        "Matricula", 
        "Centro_Custo", 
        "Atividade", 
        "Orgao"
        };

        public const int intColunaTabelaBensEletronorteColetorImobilizado = 0;
        public const int intColunaTabelaBensEletronorteColetorPatrimonio = 1;
        public const int intColunaTabelaBensEletronorteColetorDenominacao = 2;
        public const int intColunaTabelaBensEletronorteColetorDenominacao_Extra = 3;
        public const int intColunaTabelaBensEletronorteColetorN_Serie = 4;
        public const int intColunaTabelaBensEletronorteColetorSala = 5;
        public const int intColunaTabelaBensEletronorteColetorMatricula = 6;
        public const int intColunaTabelaBensEletronorteColetorCentro_Custo = 7;
        public const int intColunaTabelaBensEletronorteColetorAtividade = 8;
        public const int intColunaTabelaBensEletronorteColetorOrgao = 9;
        public const int intColunaTabelaBensEletronorteColetorTRG = 10;
        public const int intColunaTabelaBensEletronorteColetorPlaca_Veiculo = 11;

        public static string[] vetCamposTabelaBensEletronorteColetor = 
        { 
        "Imobilizado",
        "Patrimonio", 
        "Denominacao",
        "Denominacao_Extra",
        "N_Serie", 
        "Sala",
        "Matricula", 
        "Centro_Custo", 
        "Atividade", 
        "Orgao",
        "TRG",
        "Placa_Veiculo"
        };

        public const int intColunaTabelaEmpregadosNome = 0;
        public const int intColunaTabelaEmpregadosMatricula = 1;
        public const int intColunaTabelaEmpregadosOrgao = 2;
        public const int intColunaTabelaEmpregadosDDDDRR = 3;
        public const int intColunaTabelaEmpregadosTelefone = 4;
        public const int intColunaTabelaEmpregadosEndereco = 5;
        public const int intColunaTabelaEmpregadosEmail = 6;
        public const int intColunaTabelaEmpregadosConta = 7;
        public const int intColunaTabelaEmpregadosFuncao = 8;

        public static string[] vetCamposTabelaEmpregados = 
        {
        "Nome",
        "Matricula",
        "Orgao",
        "DDDDRR", 
        "Telefone",
        "Endereco", 
        "Email", 
        "Conta",
        "Funcao"
        };

        public const int intColunaTabelaCentroCustoCentroCusto = 0;
        public const int intColunaTabelaCentroCustoOrgao = 1;
        public const int intColunaTabelaCentroCustoOrgaoDescricao = 2;

        public static string[] vetCamposTabelaCentroCusto = 
        {
        "CentroCusto", 
        "Orgao",
        "OrgaoDescricao"
        };

        public const int intColunaTabelaExportacaoMassaExcelImobilizado = 0;
        public const int intColunaTabelaExportacaoMassaExcelDenomin = 1;
        public const int intColunaTabelaExportacaoMassaExcelDenomin_Extra = 2;
        public const int intColunaTabelaExportacaoMassaExcelSerie = 3;
        public const int intColunaTabelaExportacaoMassaExcelPatrimonio = 4;
        public const int intColunaTabelaExportacaoMassaExcelQtd = 5;
        public const int intColunaTabelaExportacaoMassaExcelUn = 6;
        public const int intColunaTabelaExportacaoMassaExcelUlt_invent = 7;
        public const int intColunaTabelaExportacaoMassaExcelNt_Invent = 8;
        public const int intColunaTabelaExportacaoMassaExcelAtiv = 9;
        public const int intColunaTabelaExportacaoMassaExcelCc = 10;
        public const int intColunaTabelaExportacaoMassaExcelCcR = 11;
        public const int intColunaTabelaExportacaoMassaExcelCen_Dep = 12;
        public const int intColunaTabelaExportacaoMassaExcelEnder = 13;
        public const int intColunaTabelaExportacaoMassaExcelSala = 14;
        public const int intColunaTabelaExportacaoMassaExcelMatr = 15;
        public const int intColunaTabelaExportacaoMassaExcelUc = 16;
        public const int intColunaTabelaExportacaoMassaExcelUar = 17;
        public const int intColunaTabelaExportacaoMassaExcelOdi = 18;
        public const int intColunaTabelaExportacaoMassaExcelTp = 19;
        public const int intColunaTabelaExportacaoMassaExcelLocal = 20;
        public const int intColunaTabelaExportacaoMassaExcelGener = 21;
        public const int intColunaTabelaExportacaoMassaExcelFornec = 22;
        public const int intColunaTabelaExportacaoMassaExcelDoc_Aquis = 23;
        public const int intColunaTabelaExportacaoMassaExcelCD = 24;
        public const int intColunaTabelaExportacaoMassaExcelOrigem = 25;

        public static string[] vetCamposTabelaExportacaoMassaExcel = new string[]
        {
            string.Format("{0}", "Imobilizado"),
            string.Format("{0}", "Denomin"),
            string.Format("{0}", "Denomin_Extra"),
            string.Format("{0}", "Serie"),
            string.Format("{0}", "Patrimonio"),
            string.Format("{0}", "Qtd"),
            string.Format("{0}", "Un"),
            string.Format("{0}", "Ult_invent"),
            string.Format("{0}", "Nt_Invent"),
            string.Format("{0}", "Ativ"),
            string.Format("{0}", "Cc"),
            string.Format("{0}", "CcR"),
            string.Format("{0}", "Cen_Dep"),
            string.Format("{0}", "Ender"),
            string.Format("{0}", "Sala"),
            string.Format("{0}", "Matr"),
            string.Format("{0}", "Uc"),
            string.Format("{0}", "Uar"),
            string.Format("{0}", "Odi"),
            string.Format("{0}", "Tp"),
            string.Format("{0}", "Local"),
            string.Format("{0}", "Gener"),
            string.Format("{0}", "Fornec"),
            string.Format("{0}", "Doc_Aquis"),
            string.Format("{0}", "CD"),
            string.Format("{0}", "Origem")
        };

        protected internal static void _Default()
        {
            processos = System.Diagnostics.Process.GetProcessesByName(strNomeProcesso);

            foreach (System.Diagnostics.Process processo in processos)
            {
                try
                {
                    if (processo.WorkingSet64 > intLimiteMemoria)
                    {
                        for (int contador = 0; contador <= processo.Threads.Count - 1; contador++)
                        {
                            processo.Threads[0].PriorityLevel = thNivelPrioridade;
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    string strExcecao = "_Default: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                    // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
                }
            }

            AppDomain.CurrentDomain.SetData("SQLServerCompactEditionUnderWebHosting", true);

            DiretorioArmazenamentoRegistro = System.Web.Hosting.HostingEnvironment.MapPath(string.Format(@"~/{0}/", DiretorioArmazenamento)); ;

            DiretorioArmazenamentoCompleto = DiretorioArmazenamentoRegistro;

            System.IO.Directory.CreateDirectory(DiretorioArmazenamentoCompleto);

            cntEnderecoArquivoTexto = DiretorioArmazenamentoRegistro;
            cntEnderecoBancoDadosPrincipal = DiretorioArmazenamentoRegistro;
            cntEnderecoBancoDadosExcel = DiretorioArmazenamentoRegistro;
            cntEnderecoBancoDadosColetor = DiretorioArmazenamentoRegistro;

            _mtdEnderecoTexto();
            _mtdNomeTexto();

            _mtdEnderecoPrincipal();
            _mtdNomePrincipal();
            _mtdSenhaPrincipal();

            _mtdEnderecoExcel();
            _mtdNomeExcel();
            //_mtdSenhaExcel();

            _mtdServidorCADU();
            _mtdBancoDadosCADU();
            _mtdUsuarioCADU();
            _mtdSenhaCADU();
            _mtdTabelaCADU();

            _mtdEnderecoColetor();
            _mtdNomeColetor();
            _mtdSenhaColetor();

            _mtdPermitirControleColetorUpLoad();

            DiretorioArmazenamentoCompleto = strEnderecoBancoDadosPrincipal.Equals(string.Empty)
            ?
            System.Web.Hosting.HostingEnvironment.MapPath(string.Format(@"~/{0}/", DiretorioArmazenamento))
            :
            strEnderecoBancoDadosPrincipal;

            cntEnderecoArquivoTexto = DiretorioArmazenamentoRegistro;
            cntEnderecoBancoDadosPrincipal = DiretorioArmazenamentoRegistro;
            cntEnderecoBancoDadosExcel = DiretorioArmazenamentoRegistro;
            cntEnderecoBancoDadosColetor = DiretorioArmazenamentoRegistro;

            mtdIniciarThreadFecharTodosCanais();
        }

        protected static internal void mtdReiniciarVariaveis()
        {
            strNomeUsuario = string.Empty;
            strContaUsuario = string.Empty;
            strStatusUsuario = string.Empty;

            DiretorioArmazenamento = "Armazenamento";
            DiretorioArmazenamentoCompleto = string.Empty;

            DiretorioArmazenamentoRegistro = string.Empty;

            strTabelaBensEletronorte = @"tblBensEletronorte";
            strTabelaCentroCusto = @"tblCentroCusto";
            strTabelaEmpregados = @"tblEmpregados";
            strTabelaInventarioBens = @"tblInventarioBens";

            // Arquvio Texto
            cntArquivoTexto = string.Empty;
            cntNomeArquivoTexto = "ZAM017.txt";
            cntEnderecoArquivoTexto = DiretorioArmazenamentoRegistro;

            strArquivoTexto = string.Empty;
            strNomeArquivoTexto = string.Empty;
            strEnderecoArquivoTexto = string.Empty;

            // Principal

            //public const string cntBaseDadosPrincipal = string.Empty;
            cntNomeBancoDadosPrincipal = "dbPatrimonio.mdb";
            cntEnderecoBancoDadosPrincipal = DiretorioArmazenamentoRegistro;
            cntUsuarioPrincipal = string.Empty;
            cntSenhaPrincipal = "12345678";

            strBaseDadosPrincipal = string.Empty;
            strNomeBancoDadosPrincipal = string.Empty;
            strEnderecoBancoDadosPrincipal = string.Empty;
            strUsuarioPrincipal = string.Empty;
            strSenhaPrincipal = string.Empty;

            // Excel

            cntBaseDadosExcel = string.Empty;
            cntNomeBancoDadosExcel = "dbPatrimonio.xls";
            cntEnderecoBancoDadosExcel = DiretorioArmazenamentoRegistro;
            cntPlanilhaExcel = "ExportacaoSAP";

            strBaseDadosExcel = string.Empty;
            strNomeBancoDadosExcel = string.Empty;
            strEnderecoBancoDadosExcel = string.Empty;
            strPlanilhaExcel = string.Empty;

            // SQL Server

            cntBaseDadosCADU = string.Empty;
            cntServidorCADU = string.Empty;
            cntBancoDadosCADU = string.Empty;
            cntUsuarioCADU = string.Empty;
            cntSenhaCADU = string.Empty;
            cntTabelaCADU = string.Empty;

            strBaseDadosCADU = string.Empty;
            strServidorCADU = string.Empty;
            strBancoDadosCADU = string.Empty;
            strUsuarioCADU = string.Empty;
            strSenhaCADU = string.Empty;
            strTabelaCADU = string.Empty;

            // SQL Server Compact Edition

            cntBaseDadosColetor = string.Empty;
            cntNomeBancoDadosColetor = "dbPatrimonio.sdf";
            cntEnderecoBancoDadosColetor = DiretorioArmazenamentoRegistro;
            cntSenhaColetor = "12345678";

            strBaseDadosColetor = string.Empty;
            strNomeBancoDadosColetor = string.Empty;
            strEnderecoBancoDadosColetor = string.Empty;
            strSenhaColetor = string.Empty;
        }

        private static object LockResetarConfiguracoes = new object();

        protected static internal void mtdResetarConfiguracoes()
        {
            lock (LockResetarConfiguracoes)
            {
                try
                {
                    string ChavePrincipal = "Software";
                    string Secao = "Eletronorte";
                    string Chave = "Principal";

                    if (blnEscolherRegistro)
                    {
                        Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.CurrentUser;

                        //clsAutorizacaoRegistroWindows objAutorizacaoRegistroWindows = new clsAutorizacaoRegistroWindows();
                        //regKey.SetAccessControl(objAutorizacaoRegistroWindows.mtdAutorizarUsuarioControleTotalChaveRegistroWindows(WebServiceCSNet40.Default.strNomeUsuario));

                        regKey = regKey.OpenSubKey(System.Convert.ToString(ChavePrincipal), true);
                        regKey = regKey.OpenSubKey(System.Convert.ToString(Secao), true);
                        regKey.DeleteValue(System.Convert.ToString(Chave), true);
                    }
                    else
                    {
                        string nomeArquivoParcial = string.Format(@"{0}_{1}_{2}", "Software", "Eletronorte", "Principal");

                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(DiretorioArmazenamentoRegistro);

                        foreach (System.IO.FileInfo arquivo in dir.GetFiles("*"))
                        {
                            if
                                (
                                arquivo.FullName.Contains(nomeArquivoParcial)
                                |
                                arquivo.FullName.Contains("Relatorio_Erros.txt")
                                )
                            {
                                System.IO.File.Delete(arquivo.FullName);
                                System.Diagnostics.Debug.Print(arquivo.FullName);
                            }
                        }
                    }

                    mtdReiniciarVariaveis();
                    _Default();
                    mtdIniciarCriacaoTabelas();
                }
                catch (Exception ex)
                {
                    string strExcecao = "mtdResetarConfiguracoes: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                    // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
                }
            }
        }

        private static object LockIniciarCriacaoTabelas = new object();

        protected static internal void mtdIniciarCriacaoTabelas()
        {
            lock (LockIniciarCriacaoTabelas)
            {
                mtdCriarBancoDadosPrincipal();
                mtdCriarBancoDadosExcel();
                mtdIniciarThreadPreparacaoColetor();
                frmCadastroUsuario objCadastroUsuario = new frmCadastroUsuario();
                objCadastroUsuario.mtdIniciarThreadImportarTabelaUsuarios();
                mtdCriarTabelas();
            }
        }

        protected static internal void mtdCriarTabelas()
        {
            frmImportacaoExportacaoDados objImportacaoExportacaoDados = new frmImportacaoExportacaoDados();

            objImportacaoExportacaoDados.blnComandoImplementadoDeletarDadosTabelaEmpregadosPrincipal = false;
            objImportacaoExportacaoDados.blnComandoImplementadoInserirDadosTabelaEmpregadosPrincipal = false;
            objImportacaoExportacaoDados.mtdIniciarThreadDownloadTabelaEmpregadosPrincipal();
            objImportacaoExportacaoDados.blnComandoImplementadoDeletarDadosTabelaEmpregadosColetor = false;
            objImportacaoExportacaoDados.blnComandoImplementadoInserirDadosTabelaEmpregadosColetor = false;
            objImportacaoExportacaoDados.mtdIniciarThreadDownloadTabelaEmpregadosColetor();

            objImportacaoExportacaoDados.blnComandoImplementadoDeletarDadosTabelaBensEletronortePrincipal = false;
            objImportacaoExportacaoDados.blnComandoImplementadoInserirDadosTabelaBensEletronortePrincipal = false;
            objImportacaoExportacaoDados.mtdIniciarThreadDownloadTabelaInventarioBensPrincipal();
            objImportacaoExportacaoDados.blnComandoImplementadoDeletarDadosTabelaBensEletronorteColetor = false;
            objImportacaoExportacaoDados.blnComandoImplementadoInserirDadosTabelaBensEletronorteColetor = false;
            objImportacaoExportacaoDados.mtdIniciarThreadDownloadTabelaInventarioBensColetor();

            objImportacaoExportacaoDados.blnComandoImplementadoDeletarDadosTabelaCentroCustoPrincipal = false;
            objImportacaoExportacaoDados.blnComandoImplementadoInserirDadosTabelaCentroCustoPrincipal = false;
            objImportacaoExportacaoDados.mtdIniciarThreadDownloadTabelaInventarioCentroCustoPrincipal();
            objImportacaoExportacaoDados.blnComandoImplementadoDeletarDadosTabelaCentroCustoColetor = false;
            objImportacaoExportacaoDados.blnComandoImplementadoInserirDadosTabelaCentroCustoColetor = false;
            objImportacaoExportacaoDados.mtdIniciarThreadDownloadTabelaInventarioCentroCustoColetor();

            objImportacaoExportacaoDados.blnComandoImplementadoDeletarDadosTabelaInventarioBensPrincipal = false;
            objImportacaoExportacaoDados.blnComandoImplementadoInserirDadosTabelaInventarioBensPrincipal = false;
            objImportacaoExportacaoDados.mtdIniciarThreadTransferirTabelaInventarioBensPrincipal();
            objImportacaoExportacaoDados.blnComandoImplementadoDeletarDadosTabelaInventarioBensColetor = false;
            objImportacaoExportacaoDados.blnComandoImplementadoInserirDadosTabelaInventarioBensColetor = false;
            objImportacaoExportacaoDados.mtdIniciarThreadTransferirTabelaInventarioBensColetor();

            objImportacaoExportacaoDados.mtdIniciarThreadCriarTabelaFiltroImportacao();
            objImportacaoExportacaoDados.mtdIniciarThreadCriarTabelaTermoResponsabilidadeGeral();
        }

        protected Default()
        {
            _Default();

            //mtdIniciarCriacaoTabelas();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //if (Page.User.IsInRole("Administrador"))
                    //{
                    //    hlkPerfil.NavigateUrl = @"~/Administrador/administrador.aspx";
                    //    hlkPerfil.Text = "Acesso a página de Administração";
                    //    hlkPerfil.Visible = Page.User.IsInRole("Administrador");
                    //}

                    //else if (Page.User.IsInRole("Usuario"))
                    //{
                    //    hlkPerfil.NavigateUrl = "~/Usuario/usuario.aspx";
                    //    hlkPerfil.Text = "Acesso a página de Usuários";
                    //    hlkPerfil.Visible = Page.User.IsInRole("Usuario");
                    //}

                    lblUsuario.Text = login.NomeUsuario;

                    hlkPerfil.Text = Default.strStatusUsuario;

                    lblSaudacao.Text = Default.mtdSaudacao();

                    lblAviso.Text = "Seja bem vindo!";

                    txtEnderecoTexto.Focus();

                    mtdCarregarCaixasTexto(enmTipoCarregamentoCaixasTexto.Obter);

                    mtdTestarConexao();

                    mtdObterIp();

                    mtdObterCanaisAbertos();

                    IntervaloThread = 0;
                    for (int contador = 0; contador <= 29; contador++)
                    {
                        WebServicoBancoDados.mtdFecharTodosCanais_();
                    }
                }
            }
            catch (System.Exception ex)
            {
                string strExcecao = "Page_Load: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        public enum enmTipoCarregamentoCaixasTexto
        {
            Obter,
            Salvar,
            ObterSalvar
        }

        private void mtdCarregarCaixasTexto(enmTipoCarregamentoCaixasTexto TipoCarregamentoCaixasTexto)
        {
            if (TipoCarregamentoCaixasTexto == enmTipoCarregamentoCaixasTexto.Salvar | TipoCarregamentoCaixasTexto == enmTipoCarregamentoCaixasTexto.ObterSalvar)
            {
                mtdSalvarEnderecoTexto();
                mtdSalvarNomeTexto();
                mtdSalvarEnderecoPrincipal();
                mtdSalvarNomePrincipal();
                mtdSalvarSenhaPrincipal();
                mtdSalvarEnderecoExcel();
                mtdSalvarNomeExcel();
                //mtdSalvarSenhaExcel();
                mtdSalvarServidorCADU();
                mtdSalvarBancoDadosCADU();
                mtdSalvarUsuarioCADU();
                mtdSalvarSenhaCADU();
                mtdSalvarTabelaCADU();
                mtdSalvarEnderecoColetor();
                mtdSalvarNomeColetor();
                mtdSalvarSenhaColetor();
                mtdSalvarPermitirControleColetorUpLoad();
            }

            if (TipoCarregamentoCaixasTexto == enmTipoCarregamentoCaixasTexto.Obter | TipoCarregamentoCaixasTexto == enmTipoCarregamentoCaixasTexto.ObterSalvar)
            {
                mtdObterEnderecoTexto();
                mtdObterNomeTexto();
                mtdObterEnderecoPrincipal();
                mtdObterNomePrincipal();
                mtdObterSenhaPrincipal();
                mtdObterEnderecoExcel();
                mtdObterNomeExcel();
                //mtdObterSenhaExcel();
                mtdObterServidorCADU();
                mtdObterBancoDadosCADU();
                mtdObterUsuarioCADU();
                mtdObterSenhaCADU();
                mtdObterTabelaCADU();
                mtdObterEnderecoColetor();
                mtdObterNomeColetor();
                mtdObterSenhaColetor();
                mtdObterPermitirControleColetorUpLoad();
            }
        }

        public static string mtdSaudacao()
        {
            string saida = string.Empty;

            try
            {
                string strDia = "Bom dia!";
                string strTarde = "Boa tarde!";
                string strNoite = "Boa noite!";
                DateTime objDateTime = DateTime.Now;

                if (objDateTime.Hour >= 0 && objDateTime.Hour < 12)
                {
                    saida = strDia;
                }
                else if (objDateTime.Hour >= 11 && objDateTime.Hour < 18)
                {
                    saida = strTarde;
                }
                else if (objDateTime.Hour >= 17 && objDateTime.Hour < 24)
                {
                    saida = strNoite;
                }
            }
            catch (System.Exception ex)
            {
                string strExcecao = "Page_Load: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }

            return saida;
        }

        private static clsRegistroWindows objRegistroWindows = new clsRegistroWindows();

        private bool mtdTestarConexao(string BancoDados)
        {
            bool saida = false;

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

            saida = objImplementacaoBancoDados.mtdAbrirConexao();

            objImplementacaoBancoDados.Dispose();

            return saida;
        }

        private bool mtdTestarConexaoPrincipal()
        {
            bool blnTestarConexao = false;

            blnTestarConexao = mtdTestarConexao("Principal");
            btnTestarConexaoPrincipal.BackColor = blnTestarConexao ? System.Drawing.Color.FromArgb(204, 255, 204) : System.Drawing.Color.FromArgb(255, 204, 255);
            btnTestarConexaoPrincipal.Text = blnTestarConexao ? "Conexao bem sucedida." : "Não foi possível conectar.";

            return blnTestarConexao;
        }

        private bool mtdTestarConexaoExcel()
        {
            bool blnTestarConexao = false;

            blnTestarConexao = mtdTestarConexao("Excel");
            btnTestarConexaoExcel.BackColor = blnTestarConexao ? System.Drawing.Color.FromArgb(204, 255, 204) : System.Drawing.Color.FromArgb(255, 204, 255);
            btnTestarConexaoExcel.Text = blnTestarConexao ? "Conexao bem sucedida." : "Não foi possível conectar.";

            return blnTestarConexao;
        }

        private bool mtdTestarConexaoCADU()
        {
            bool blnTestarConexao = false;

            blnTestarConexao = mtdTestarConexao("CADU");
            btnTestarConexaoCADU.BackColor = blnTestarConexao ? System.Drawing.Color.FromArgb(204, 255, 204) : System.Drawing.Color.FromArgb(255, 204, 255);
            btnTestarConexaoCADU.Text = blnTestarConexao ? "Conexao bem sucedida." : "Não foi possível conectar.";

            return blnTestarConexao;
        }

        private bool mtdTestarConexaoColetor()
        {
            bool blnTestarConexao = false;

            blnTestarConexao = mtdTestarConexao("Coletor");
            btnTestarConexaoColetor.BackColor = blnTestarConexao ? System.Drawing.Color.FromArgb(204, 255, 204) : System.Drawing.Color.FromArgb(255, 204, 255);
            btnTestarConexaoColetor.Text = blnTestarConexao ? "Conexao bem sucedida." : "Não foi possível conectar.";

            return blnTestarConexao;
        }

        private void mtdTestarConexao()
        {
            _Default();

            mtdTestarConexaoPrincipal();
            mtdTestarConexaoExcel();
            mtdTestarConexaoCADU();
            mtdTestarConexaoColetor();
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            mtdCarregarCaixasTexto(enmTipoCarregamentoCaixasTexto.ObterSalvar);

            mtdTestarConexao();
        }

        public static string mtdDefinirStringConexao(string BancoDados, ref clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional)
        {
            string strStringConexao = string.Empty;

            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados();

            switch (BancoDados)
            {
                case "Principal":
                    TipoSistemaGerenciadorBancoDadosRelacional = clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb;

                    strStringConexao = objImplementacaoBancoDados.mtdDefinirStringConexaoAccess
                            (
                            clsConexaoBancoDados.TipoConexao.ConexaoAccess2003OleDb,
                            Default.strBaseDadosPrincipal,
                            Default.strUsuarioPrincipal,
                            Default.strSenhaPrincipal
                            );
                    break;
                case "Excel":
                    TipoSistemaGerenciadorBancoDadosRelacional = clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb;

                    strStringConexao = objImplementacaoBancoDados.mtdDefinirStringConexaoExcel
                            (
                            clsConexaoBancoDados.TipoConexao.ConexaoExcel2003OleDb,
                            Default.strBaseDadosExcel
                        //Default.strUsuarioExcel,
                        //Default.strSenhaExcel
                            );
                    break;
                case "CADU":
                    TipoSistemaGerenciadorBancoDadosRelacional = clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServer;

                    strStringConexao = objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServer
                            (
                            clsConexaoBancoDados.TipoConexao.ConexaoSQLServerNativa,
                            Default.strServidorCADU,
                            Default.strBancoDadosCADU,
                            Default.strUsuarioCADU,
                            Default.strSenhaCADU
                            );
                    break;
                case "Coletor":
                    TipoSistemaGerenciadorBancoDadosRelacional = clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE;

                    strStringConexao = objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                            (
                            clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                            Default.strBaseDadosColetor,
                            Default.strSenhaColetor
                            );
                    break;
            }

            objImplementacaoBancoDados.Dispose();

            return strStringConexao;
        }

        //private int col = 1;
        //private int lin = 0;
        //private int intcoluna = 0;

        //private string[][] campos;
        //private string[] vetLinhaTexto;
        //private string strModoCapitalizacao = "Capitalizado";

        protected void mnu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            if (mnu1.Items[0].Text == mnu1.SelectedItem.Text)
            {
                Response.Redirect("~/frmCadastroUsuario.aspx");
            }
            if (mnu1.Items[1].Text == mnu1.SelectedItem.Text)
            {
                Response.Redirect("~/frmConsultarTabelaDados.aspx");
            }
            if (mnu1.Items[2].Text == mnu1.SelectedItem.Text)
            {
                Response.Redirect("~/frmImportacaoExportacaoDados.aspx");
            }
            if (mnu1.Items[3].Text == mnu1.SelectedItem.Text)
            {
                Response.Redirect("~/Todos/WebServicoBancoDados.asmx");
            }
        }

        private static System.Threading.Thread ThPreparacaoColetor;

        private static void mtdIniciarThreadPreparacaoColetor()
        {
            try
            {
                ThPreparacaoColetor = new System.Threading.Thread
                    (
                    new System.Threading.ThreadStart
                        (
                        mtdRotinaPreparacaoColetor
                        )
                        );
                ThPreparacaoColetor.IsBackground = true;
                ThPreparacaoColetor.Priority = System.Threading.ThreadPriority.Lowest;
                ThPreparacaoColetor.Start();
            }
            catch (Exception ex)
            {
                string strExcecao = "mtdIniciarThreadPreparacaoColetor: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        private static void mtdAbortarThreadPreparacaoColetor()
        {
            try
            {
                ThPreparacaoColetor.Abort();
            }
            catch (Exception ex)
            {
                string strExcecao = "mtdAbortarThreadPreparacaoColetor: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        private static void mtdRotinaPreparacaoColetor()
        {
            string BancoDados = "Coletor";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

            if (!objImplementacaoBancoDados.mtdAbrirConexao())
            {
                mtdCriarBancoDadosColetor();
                blnReparado = mtdRepararBancoDadosColetor();
                blnCompactado = mtdCompactarBancoDadosColetor();
            }

            objImplementacaoBancoDados.Dispose();

            mtdAbortarThreadPreparacaoColetor();
        }


        private static bool blnReparado = false;
        private static bool blnCompactado = false;

        public static bool mtdCompactarBancoDadosColetor()
        {
            bool saida = false;

            string BancoDados = "Coletor";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE();

            saida = objImplementacaoBancoDados.mtdCompactarBancoDadosSQLServerCE();

            objImplementacaoBancoDados.Dispose();

            return saida;
        }

        public static bool mtdRepararBancoDadosColetor()
        {
            bool saida = false;

            string BancoDados = "Coletor";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE();

            saida = objImplementacaoBancoDados.mtdRepararBancoDadosSQLServerCE();

            objImplementacaoBancoDados.Dispose();

            return saida;
        }

        public static bool mtdCriarBancoDadosColetor()
        {
            bool saida = false;

            string BancoDados = "Coletor";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE();

            saida = objImplementacaoBancoDados.mtdCriarBancoDadosSQLServerCE();

            objImplementacaoBancoDados.Dispose();

            return saida;
        }

        public static bool mtdCriarBancoDadosPrincipal()
        {
            bool saida = false;

            string BancoDados = "Principal";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

            objImplementacaoBancoDados.mtdDefinirStringConexaoAccess();

            if ((objImplementacaoBancoDados.mtdCriarBancoDadosAccess()))
            {
                saida = true;
            }
            else
            {
                saida = false;
            }
            objImplementacaoBancoDados.Dispose();

            return saida;
        }

        public static bool mtdCriarBancoDadosExcel()
        {
            bool saida = false;

            string BancoDados = "Excel";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

            objImplementacaoBancoDados.mtdDefinirStringConexaoExcel();

            if ((objImplementacaoBancoDados.mtdCriarBancoDadosExcel()))
            {
                saida = true;
            }
            else
            {
                saida = false;
            }
            objImplementacaoBancoDados.Dispose();

            return saida;
        }

        public static object mtdSelecionarTabelaInventarioBens(string BancoDados, string Campo, string Dado)
        {
            object saida = null;

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

            objImplementacaoBancoDados.mtdSelecionarDados
                (
                "*",
                Default.strTabelaInventarioBens,
                Campo,
                "LIKE",
                string.Format
                (
                "{0}",
                Dado
                ),
                Campo,
                true
                );
            objImplementacaoBancoDados.mtdDefinirLeitorDados();

            if (objImplementacaoBancoDados.mtdProximoRegistro())
            {
                saida = objImplementacaoBancoDados.mtdObterValorRegistro(0);
            }
            objImplementacaoBancoDados.Dispose();
            return saida;
        }

        private static object LockGerarProximoNumeroCodigo = new object();

        public static ulong mtdGerarProximoNumeroCodigo(string BancoDados, string Tabela, string Campo)
        {
            lock (LockGerarProximoNumeroCodigo)
            {
                int intNumeroControle = 1000000;
                int intNumeroLinhas = 1;

                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
                string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
                clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

                System.DateTime dtAtual = System.DateTime.Today;
                objImplementacaoBancoDados.mtdAbrirConexao();
                objImplementacaoBancoDados.mtdExecutarComando
                    (
                    string.Format
                    (
                    "SELECT {0}{1} FROM {2} ORDER BY {1} {3};",
                    intNumeroLinhas >= 1 ? string.Format("TOP {0} ", intNumeroLinhas) : string.Empty,
                    Campo,
                    Tabela,
                    "DESC"
                    )
                    );

                objImplementacaoBancoDados.mtdDefinirLeitorDados();
                ulong ulngNumeroInventario = System.Convert.ToUInt64((dtAtual.Year * intNumeroControle) + 1);
                if (objImplementacaoBancoDados.mtdProximoRegistro())
                {
                    ulngNumeroInventario = System.Convert.ToUInt64(objImplementacaoBancoDados.mtdObterValorRegistro(0));
                    ulong ulngAuxNumeroInventario = (ulong)System.Math.Truncate((double)(ulngNumeroInventario / (ulong)intNumeroControle));
                    ulngNumeroInventario = (ulong)dtAtual.Year > ulngAuxNumeroInventario ? Convert.ToUInt64((dtAtual.Year * intNumeroControle) + 1) : ulngNumeroInventario + 1;
                }
                else
                {
                    ulngNumeroInventario = System.Convert.ToUInt64((dtAtual.Year * intNumeroControle) + 1);
                }

                objImplementacaoBancoDados.Dispose();

                return ulngNumeroInventario;
            }
        }

        public static double dblTempoGerarProximoNumeroCodigo = DateTime.Now.TimeOfDay.TotalMilliseconds;
        private static double dblDiferencaGerarProximoNumeroCodigo = 0;

        private static ulong ulngNumeroInventario = 0;
        public static long lngAuxNumeroInventario = -1;

        public static ulong mtdGerarProximoNumeroCodigo(string BancoDados, string Tabela, string Campo, int NumeroOtimizado, int TempoReinicio)
        {
            dblDiferencaGerarProximoNumeroCodigo = System.DateTime.Now.TimeOfDay.TotalMilliseconds - dblTempoGerarProximoNumeroCodigo;

            if ((lngAuxNumeroInventario < (long)NumeroOtimizado) & (lngAuxNumeroInventario != -1) & (dblDiferencaGerarProximoNumeroCodigo / (60 * 1000) <= TempoReinicio))
            {
                ulngNumeroInventario++;
                lngAuxNumeroInventario++;
            }
            else
            {
                ulngNumeroInventario = mtdGerarProximoNumeroCodigo(BancoDados, Tabela, Campo);
                lngAuxNumeroInventario = 0;
                dblTempoGerarProximoNumeroCodigo = DateTime.Now.TimeOfDay.TotalMilliseconds;
            }

            return ulngNumeroInventario;
        }

        private static object LockObterCodigoEspalhamento = new object();

        public static long mtdObterCodigoEspalhamento(string Dado)
        {
            lock (LockObterCodigoEspalhamento)
            {
                long saida = 0;
                System.Security.Cryptography.HashAlgorithm algorithm = System.Security.Cryptography.SHA1.Create();
                byte[] vetData = System.Text.Encoding.Unicode.GetBytes(Dado);
                byte[] vetDataHash = algorithm.ComputeHash(vetData);
                saida = BitConverter.ToInt64(vetDataHash, 0);
                return saida;
            }
        }

        private static object LockCalcularCodigoEspalhamento = new object();

        public static long mtdCalcularCodigoEspalhamento(string BancoDados, string Tabela, string CampoSelecionador, string Dado)
        {
            lock (LockCalcularCodigoEspalhamento)
            {
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

                if (objImplementacaoBancoDados.mtdProximoRegistro())
                {
                    for (int coluna = 1; coluna <= numColunas - 1; coluna += 1)
                    {
                        saida = saida ^ mtdObterCodigoEspalhamento(objImplementacaoBancoDados.mtdObterValorRegistro(coluna).ToString());
                    }
                }
                objImplementacaoBancoDados.Dispose();
                return saida;
            }
        }

        private static object LockVerificarDataMaisAtualAjustadorDadosInventarioBensTabelaInventarioBens = new object();

        public static bool mtdVerificarDataMaisAtualAjustadorDadosInventarioBensTabelaInventarioBens
            (
            System.Data.DataSet AjustadorDados,
            int linha,
            int coluna,
            string BancoDados,
            string CampoSelecionador,
            object Dado
            )
        {
            lock (LockVerificarDataMaisAtualAjustadorDadosInventarioBensTabelaInventarioBens)
            {
                bool saida = false;

                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
                string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
                clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

                switch (BancoDados)
                {
                    case "Principal":
                        objImplementacaoBancoDados.mtdSelecionarDadosParametroComandoOleDb(0, "*", Default.strTabelaInventarioBens, CampoSelecionador, "LIKE", Dado);
                        break;
                    case "Coletor":
                        objImplementacaoBancoDados.mtdSelecionarDadosParametroComandoSQLServerCE(0, "*", Default.strTabelaInventarioBens, CampoSelecionador, "LIKE", Dado);
                        break;
                }

                objImplementacaoBancoDados.mtdDefinirLeitorDados();
                if (objImplementacaoBancoDados.mtdProximoRegistro())
                {
                    if
                          (
                          System.Convert.ToDateTime(System.Convert.ToString(AjustadorDados.Tables[0].Rows[linha][coluna])).Ticks
                          >
                          System.Convert.ToDateTime(System.Convert.ToString(objImplementacaoBancoDados.mtdObterValorRegistro(coluna))).Ticks
                          )
                    {
                        saida = true;
                    }
                    else
                    {
                        saida = false;
                    }
                }

                objImplementacaoBancoDados.Dispose();

                return saida;
            }
        }

        private static object LockVerificarDataMaisAtualTabelaInventarioBensPrincipalColetor = new object();

        public static bool mtdVerificarDataMaisAtualTabelaInventarioBensPrincipalColetor
           (
            int coluna,
            string CampoSelecionador,
            object Dado
            )
        {
            lock (LockVerificarDataMaisAtualTabelaInventarioBensPrincipalColetor)
            {
                bool saida = false;

                string BancoDadosPrincipal = "Principal";
                string BancoDadosColetor = "Coletor";

                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacionalPrincipal = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
                string strConexaoPrincipal = Default.mtdDefinirStringConexao(BancoDadosPrincipal, ref TipoSistemaGerenciadorBancoDadosRelacionalPrincipal);
                clsImplementacaoBancoDados objBancoDadosPrincipal = new clsImplementacaoBancoDados(strConexaoPrincipal, TipoSistemaGerenciadorBancoDadosRelacionalPrincipal);

                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacionalColetor = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
                string strConexaoColetor = Default.mtdDefinirStringConexao(BancoDadosColetor, ref TipoSistemaGerenciadorBancoDadosRelacionalColetor);
                clsImplementacaoBancoDados objBancoDadosColetor = new clsImplementacaoBancoDados(strConexaoColetor, TipoSistemaGerenciadorBancoDadosRelacionalColetor);

                objBancoDadosPrincipal.mtdSelecionarDadosParametroComandoOleDb(0, "*", Default.strTabelaInventarioBens, CampoSelecionador, "LIKE", Dado);

                objBancoDadosPrincipal.mtdDefinirLeitorDados();
                objBancoDadosPrincipal.mtdProximoRegistro();

                objBancoDadosColetor.mtdSelecionarDadosParametroComandoSQLServerCE(0, "*", Default.strTabelaInventarioBens, CampoSelecionador, "LIKE", Dado);

                objBancoDadosColetor.mtdDefinirLeitorDados();
                objBancoDadosColetor.mtdProximoRegistro();

                if
                    (
                    System.Convert.ToDateTime(System.Convert.ToString(objBancoDadosPrincipal.mtdObterValorRegistro(coluna))).Ticks
                    >
                    System.Convert.ToDateTime(System.Convert.ToString(objBancoDadosColetor.mtdObterValorRegistro(coluna))).Ticks
                    )
                {
                    saida = true;
                }
                else
                {
                    saida = false;
                }

                objBancoDadosPrincipal.Dispose();
                objBancoDadosColetor.Dispose();

                return saida;
            }
        }

        private static object LockVerificarDataMaisAtualTabelaInventarioBensColetorPrincipal = new object();

        public static bool mtdVerificarDataMaisAtualTabelaInventarioBensColetorPrincipal
            (
            int coluna,
            string CampoSelecionador,
            object Dado
            )
        {
            lock (LockVerificarDataMaisAtualTabelaInventarioBensColetorPrincipal)
            {
                bool saida = false;

                string BancoDadosPrincipal = "Principal";
                string BancoDadosColetor = "Coletor";

                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacionalPrincipal = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
                string strConexaoPrincipal = Default.mtdDefinirStringConexao(BancoDadosPrincipal, ref TipoSistemaGerenciadorBancoDadosRelacionalPrincipal);
                clsImplementacaoBancoDados objBancoDadosPrincipal = new clsImplementacaoBancoDados(strConexaoPrincipal, TipoSistemaGerenciadorBancoDadosRelacionalPrincipal);

                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacionalColetor = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
                string strConexaoColetor = Default.mtdDefinirStringConexao(BancoDadosColetor, ref TipoSistemaGerenciadorBancoDadosRelacionalColetor);
                clsImplementacaoBancoDados objBancoDadosColetor = new clsImplementacaoBancoDados(strConexaoColetor, TipoSistemaGerenciadorBancoDadosRelacionalColetor);

                objBancoDadosPrincipal.mtdSelecionarDadosParametroComandoOleDb(0, "*", Default.strTabelaInventarioBens, CampoSelecionador, "LIKE", Dado);

                objBancoDadosPrincipal.mtdDefinirLeitorDados();
                objBancoDadosPrincipal.mtdProximoRegistro();

                objBancoDadosColetor.mtdSelecionarDadosParametroComandoSQLServerCE(0, "*", Default.strTabelaInventarioBens, CampoSelecionador, "LIKE", Dado);

                objBancoDadosColetor.mtdDefinirLeitorDados();
                objBancoDadosColetor.mtdProximoRegistro();

                if
                    (
                    System.Convert.ToDateTime(System.Convert.ToString(objBancoDadosColetor.mtdObterValorRegistro(coluna))).Ticks
                    >
                    System.Convert.ToDateTime(System.Convert.ToString(objBancoDadosPrincipal.mtdObterValorRegistro(coluna))).Ticks
                    )
                {
                    saida = true;
                }
                else
                {
                    saida = false;
                }

                objBancoDadosPrincipal.Dispose();
                objBancoDadosColetor.Dispose();

                return saida;
            }
        }

        protected void btnTestarConexaoPrincipal_Click(object sender, EventArgs e)
        {
            mtdTestarConexaoPrincipal();
        }

        protected void btnTestarConexaoExcel_Click(object sender, EventArgs e)
        {
            mtdTestarConexaoExcel();
        }

        protected void btnTestarConexaoCADU_Click(object sender, EventArgs e)
        {
            mtdTestarConexaoCADU();
        }

        protected void btnTestarConexaoColetor_Click(object sender, EventArgs e)
        {
            mtdTestarConexaoColetor();
        }

        protected void btnUploadArquivo_Click(object sender, EventArgs e)
        {
            try
            {
                string arq = fileImg.PostedFile.FileName;

                string extensao = "";

                int tamanho = 0;

                int permitido = 2 * 1024 * 1024;

                int erroRegra = 0;

                if (fileImg.PostedFile != null)
                {
                    tamanho = (int)(fileImg.PostedFile.ContentLength / 1024);

                    extensao = arq.Substring(arq.Length - 4).ToLower();

                    string nomeArq = System.IO.Path.GetFileName(arq);

                    txtNomeTexto.Text = mtdTirarAcentos(nomeArq);

                    mtdSalvarNomeTexto();
                    mtdObterNomeTexto();

                    string diretorio = strEnderecoArquivoTexto + strNomeArquivoTexto;

                    if (tamanho > permitido)
                    {
                        this.lblAviso.Text = "Tamanho Máximo permitido é de " + permitido + " kilobyte(s)!";

                        erroRegra = 1;
                    }

                    if ((extensao != ".txt"))
                    {
                        this.lblAviso.Text = "Extensão inválida, só é permitida .txt!";

                        erroRegra = 2;
                    }

                    if (erroRegra == 0)
                    {
                        try
                        {
                            //if (!System.IO.File.Exists(diretorio))
                            //{
                            fileImg.PostedFile.SaveAs(diretorio);

                            this.lblAviso.Text = "Arquivo enviado com sucesso!";
                            //}
                            //else
                            //{
                            //    this.lblAviso.Text = "Já existe um arquivo com esse nome!";

                            //}
                        }
                        catch (UnauthorizedAccessException ex)
                        {
                            this.lblAviso.Text = "Erro no Upload:" + ex.Message;

                            string strExcecao = "btnUploadArquivo_Click: " + ex.Message;
                            System.Diagnostics.Debug.WriteLine(strExcecao);
                            // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                this.lblAviso.Text = "Erro no Upload";

                string strExcecao = "btnUploadArquivo_Click: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        public static string mtdTirarAcentos(string texto)
        {
            string ComAcentos = "!@#$%¨&*()-?:{}][ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç ";
            string SemAcentos = "_________________AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc_";

            for (int i = 0; i < ComAcentos.Length; i++)
            {
                texto = texto.Replace(ComAcentos[i].ToString(), SemAcentos[i].ToString()).Trim();
            }

            return texto;
        }

        private static long lngContador = 0;
        private static clsArquivoTXT objArquivoTXT = new clsArquivoTXT();

        private static object LockGerarRelatorioErros = new object();

        public static void mtdGerarRelatorioErros(string EnderecoNomeArquivo, string Conteudo)
        {
            lock (LockGerarRelatorioErros)
            {
                try
                {
                    if (!System.IO.File.Exists(EnderecoNomeArquivo))
                    {
                        lngContador = 0;
                        objArquivoTXT.mtdCriadorTexto(EnderecoNomeArquivo, string.Empty);
                        objArquivoTXT.mtdAcrescentarTexto(EnderecoNomeArquivo, string.Format("{0} - {1}", lngContador++, Conteudo));
                    }
                    else
                    {
                        if (lngContador == 0)
                        {
                            lngContador = mtdObterNumeroLinhasRelatorioErros(EnderecoNomeArquivo) + 1;
                        }
                        objArquivoTXT.mtdCriadorTexto(EnderecoNomeArquivo, string.Empty);
                        objArquivoTXT.mtdAcrescentarTexto(EnderecoNomeArquivo, string.Format("{0} - {1}", lngContador++, Conteudo));
                    }
                }
                catch (System.Exception ex)
                {
                    lngContador = 0;

                    string strExcecao = "mtdObterNumeroLinhasRelatorioErros: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);

                    if (lngContador == 0)
                    {
                        lngContador = mtdObterNumeroLinhasRelatorioErros(EnderecoNomeArquivo) + 1;
                    }
                    objArquivoTXT.mtdCriadorTexto(EnderecoNomeArquivo, string.Empty);
                    objArquivoTXT.mtdAcrescentarTexto(EnderecoNomeArquivo, string.Format("{0} - {1}", lngContador++, strExcecao));
                }
            }
        }

        private static object LockObterNumeroLinhasRelatorioErros = new object();

        public static long mtdObterNumeroLinhasRelatorioErros(string EnderecoNomeArquivo)
        {
            lock (LockObterNumeroLinhasRelatorioErros)
            {
                long lngRetorno = 0;

                try
                {
                    objArquivoTXT.mtdAbrirLeitorTexto(EnderecoNomeArquivo);

                    while (!objArquivoTXT.getFimArquivo)
                    {
                        string strTextoLinha = objArquivoTXT.mtdLeitorTextoLinha();
                        if (strTextoLinha != string.Empty)
                        {
                            lngRetorno = System.Convert.ToInt64(strTextoLinha.Split('-')[0]) > lngRetorno ? System.Convert.ToInt64(strTextoLinha.Split('-')[0]) : lngRetorno;
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    lngRetorno = 0;

                    string strExcecao = "mtdObterNumeroLinhasRelatorioErros: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);

                    if (lngContador == 0)
                    {
                        lngContador = mtdObterNumeroLinhasRelatorioErros(EnderecoNomeArquivo) + 1;
                    }
                    objArquivoTXT.mtdCriadorTexto(EnderecoNomeArquivo, string.Empty);
                    objArquivoTXT.mtdAcrescentarTexto(EnderecoNomeArquivo, string.Format("{0} - {1}", lngContador++, strExcecao));
                }

                return lngRetorno;
            }
        }

        public void mtdObterIp()
        {
            lblIpLocal.Text = string.Format("{0}: {1}", "Ip Local", login.mtdObterIpLocal());
            //lblIpInternet.Text = string.Format("{0}: {1}", "Ip Local: ", login.mtdObterIpInternet());
        }

        public void mtdObterCanaisAbertos()
        {
            login.mtdObterListaCanaisAbertos();

            lblCanalAberto.Text = "Canais Abertos: ";

            for (int contador = 0; contador <= login.lstCanalAberto.Count - 1; contador++)
            {
                if (contador != login.lstCanalAberto.Count - 1)
                {
                    lblCanalAberto.Text += string.Format("{0}, ", login.lstCanalAberto[contador]);
                }
                else
                {
                    lblCanalAberto.Text += string.Format("{0}.", login.lstCanalAberto[contador]);
                }
            }
        }

        protected void btnObterInformacoes_Click(object sender, EventArgs e)
        {
            mtdObterIp();

            mtdObterCanaisAbertos();

            IntervaloThread = 0;
            for (int contador = 0; contador <= 29; contador++)
            {
                WebServicoBancoDados.mtdFecharTodosCanais_();
            }
        }

        ~Default()
        {
            mtdAbortarThreadFecharTodosCanais();
        }
    }
}