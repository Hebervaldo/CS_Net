using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace prjColetorDadosCSNet35
{
    public partial class frmPrincipal : Form
    {
        private delegate void SetValueCallbacktmr1();

        public static string cntExtensaoBancoDadosColetor = ".sdf";

        //public static clsEnderecoAplicativo objEnderecoAplicativo = new clsEnderecoAplicativo();

        public static string strEnderecoBancoDadosColetor = System.IO.Path.GetDirectoryName
        (
            System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase
        );
        //private string strEnderecoBancoDadosColetor = @"\Storage Card\";

        public static string DiretorioEnderecoAplicativo = string.Empty;
        public static string DiretorioArmazenamento = "Armazenamento";
        public static string DiretorioArmazenamentoCompleto = string.Empty;

        public static uint uintNumeroLinhas = 200;
        public static uint uintComprimentoColunas = 200;
        public static uint uintIntervaloBackup = 15;
        public static uint uintNumeroCopiasBackup = 1;
        public static uint uintTemporizador = 15;

        public static int intCamposTabelaInventarioBens = 25;
        public static string strNomeBancoDadosColetor = @"dbPatrimonio";
        public static string strBaseDadosColetor = string.Empty;
        public static string strTabelaBensEletronorte = "tblBensEletronorte";
        public static string strTabelaEmpregados = "tblEmpregados";
        public static string strTabelaInventarioBens = "tblInventarioBens";
        public static string strTabelaCentroCusto = "tblCentroCusto";
        public static string strSenhaColetor = "12345678";

        public static string strEnderecoTesteInternet = "http://www.google.com.br/";

        public static clsManipuladorTexto objManipuladorTexto = new clsManipuladorTexto();

        private delegate void SetTextCallback(string text);
        private delegate void dlgCarregarPermitirEscritaColuna();

        private string strTextoSelecionado = string.Empty;
        private int intRepeticoes = 2;
        private int intRepeticoesPadrao = 2;

        //private byte[] image;
        private System.Drawing.Image tmpImage;

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

        public const int intColunaTabelaBensEletronortePatrimonio = 0;
        public const int intColunaTabelaBensEletronorteDenominacao = 1;
        public const int intColunaTabelaBensEletronorteDenominacao_Extra = 2;
        public const int intColunaTabelaBensEletronorteN_Serie = 3;
        public const int intColunaTabelaBensEletronorteSala = 4;
        public const int intColunaTabelaBensEletronorteMatricula = 5;
        public const int intColunaTabelaBensEletronorteCentro_Custo = 6;
        public const int intColunaTabelaBensEletronorteAtividade = 7;
        public const int intColunaTabelaBensEletronorteOrgao = 8;
        public const int intColunaTabelaBensEletronorteTRG = 9;
        public const int intColunaTabelaBensEletronortePlaca_Veiculo = 10;

        public static string[] vetCamposTabelaBensEletronorte = 
        { 
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

        public const int intColunaTabelaBensEletronorteCompletoImobilizado = 0;
        public const int intColunaTabelaBensEletronorteCompletoPatrimonio = 1;
        public const int intColunaTabelaBensEletronorteCompletoDenominacao = 2;
        public const int intColunaTabelaBensEletronorteCompletoDenominacao_Extra = 3;
        public const int intColunaTabelaBensEletronorteCompletoN_Serie = 4;
        public const int intColunaTabelaBensEletronorteCompletoSala = 5;
        public const int intColunaTabelaBensEletronorteCompletoMatricula = 6;
        public const int intColunaTabelaBensEletronorteCompletoCentro_Custo = 7;
        public const int intColunaTabelaBensEletronorteCompletoAtividade = 8;
        public const int intColunaTabelaBensEletronorteCompletoOrgao = 9;
        public const int intColunaTabelaBensEletronorteCompletoTRG = 10;
        public const int intColunaTabelaBensEletronorteCompletoPlaca_Veiculo = 11;

        public static string[] vetCamposTabelaBensEletronorteCompleto = 
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

        public frmPrincipal()
            : this(string.Empty)
        {
        }

        public frmPrincipal(string EnderecoBancoDadosColetor)
        {
            InitializeComponent();

            prpEnderecoBancoDadosColetor = EnderecoBancoDadosColetor;

            objgps = new Microsoft.WindowsMobile.Samples.Location.Gps();
        }

        private void mtdProcurar()
        {
            mtdProcurarCaixaTexto();
        }

        private void SetText(string text)
        {
            ntf1.Text = text;
        }

        private void mni1_Click(object sender, EventArgs e)
        {
            switch (mni1.Text)
            {
                case "Cadastro":
                    mtdModoCadastroInventario_();
                    break;
                case "Consultar":
                    System.Windows.Forms.DialogResult msb = System.Windows.Forms.MessageBox.Show
                        (
                        "Sim: exibe todos os dados.\nNão: exibe parte dos dados.",
                        "Aviso!",
                        System.Windows.Forms.MessageBoxButtons.YesNoCancel,
                        System.Windows.Forms.MessageBoxIcon.Exclamation,
                        System.Windows.Forms.MessageBoxDefaultButton.Button2
                        );

                    switch (msb)
                    {
                        case (System.Windows.Forms.DialogResult.Yes):
                            switch (tbc2.SelectedIndex)
                            {
                                case 0:
                                    mtdConsultarInventario();
                                    break;
                                case 1:
                                    mtdConsultarSAP();
                                    break;
                                case 2:
                                    mtdConsultarEmpregados();
                                    break;
                                case 3:
                                    mtdConsultarCentroCusto();
                                    break;
                            }
                            switch (tbc3.SelectedIndex)
                            {
                                case 0:
                                    mtdConsultarRelatorio();
                                    break;
                                case 2:
                                    mtdCarregarRelatoriosExtra();
                                    break;
                            }
                            break;
                        case (System.Windows.Forms.DialogResult.No):
                            switch (tbc2.SelectedIndex)
                            {
                                case 0:
                                    mtdConsultarInventario(uintNumeroLinhas);
                                    break;
                                case 1:
                                    mtdConsultarSAP(uintNumeroLinhas);
                                    break;
                                case 2:
                                    mtdConsultarEmpregados(uintNumeroLinhas);
                                    break;
                                case 3:
                                    mtdConsultarCentroCusto(uintNumeroLinhas);
                                    break;
                            }
                            switch (tbc3.SelectedIndex)
                            {
                                case 0:
                                    mtdConsultarRelatorio(uintNumeroLinhas);
                                    break;
                                case 2:
                                    mtdCarregarRelatoriosExtra();
                                    break;
                            }
                            break;
                        case (System.Windows.Forms.DialogResult.Cancel):
                            break;
                    }
                    break;
                case "Definir":
                    mtdAjustarDataTempoSistema();
                    btnDataTempoSistema.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
                    dtpDataSistema.Enabled = false;
                    dtpTempoSistema.Enabled = false;
                    mni1.Text = "Otimizado";
                    dtpDataInventario.Value = System.DateTime.Now;
                    break;
                case "GPS":
                    mtdAtivarDesativarGPS();
                    break;
                case "Inventário":
                    mtdModoCadastroInventario_();
                    break;
                case "Monitor":
                    btnMonitorCarregamentoDados_Click(sender, e);
                    break;
                case "Otimizado":
                    if (chkModoOtimizadoCadastro.Enabled)
                    {
                        mtdChecarModoOtimizadoCadastro();
                        mtdRegistroModoOtimizadoCadastro();
                    }
                    break;
                case "Patrimonio":
                    mtdConsultarItensRepetidosCampoInformado(vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensPatrimonio], cmbConsultarInventarioRepeticoes.Text);
                    break;
                case "Permitir":
                    chkPermitirExibicaoNotificacoes.Checked = !chkPermitirExibicaoNotificacoes.Checked;
                    chkPermitirExibicaoNotificacoes_Click(sender, e);
                    break;
                case "Procurar":
                    mtdProcurar();
                    //if (System.Windows.Forms.MessageBox.Show
                    //    (
                    //    "Deseja preencher as tabelas auxiliares?",
                    //    "Aviso!",
                    //    System.Windows.Forms.MessageBoxButtons.YesNo,
                    //    System.Windows.Forms.MessageBoxIcon.Exclamation,
                    //    System.Windows.Forms.MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes
                    //    )
                    //{
                    //    if (chkCarregarCombosDados.Checked)
                    //    {
                    //        mtdAtualizarDtg2(vetCamposTabelaBensEletronorte[0], cmbPatrimonioItem.Text, uintNumeroLinhas);
                    //        mtdAtualizarDtg3(vetCamposTabelaEmpregados[1], cmbMatriculaInventario.Text, uintNumeroLinhas);
                    //        mtdAtualizarDtg4(vetCamposTabelaCentroCusto[1], cmbOrgaoItem.Text, uintNumeroLinhas);
                    //    }
                    //    else
                    //    {
                    //        mtdAtualizarDtg2(vetCamposTabelaBensEletronorte[0], txtPatrimonioItem.Text, uintNumeroLinhas);
                    //        mtdAtualizarDtg3(vetCamposTabelaEmpregados[1], txtMatriculaInventario.Text, uintNumeroLinhas);
                    //        mtdAtualizarDtg4(vetCamposTabelaCentroCusto[1], txtOrgaoItem.Text, uintNumeroLinhas);
                    //    }
                    //}
                    break;
                case "Sair/Backup":
                    mtdSairFazerBackup();
                    break;
                case "Visualizar":
                    mtdVisualizarMapa();
                    break;
                case "Zerar":
                    switch (tbc1.SelectedIndex)
                    {
                        case 6:
                            mtdZerarFotografia();
                            break;
                        case 11:
                            btnZerarTabelaInventarioBens_Click(sender, e);
                            break;
                    }
                    break;
            }
        }

        private void mni2_Click(object sender, EventArgs e)
        {
            switch (mni2.Text)
            {
                case "Alt/Deletar":
                    mtdComandoAlterarDeletar();
                    break;
                case "Cadastrar":
                    mtdCadastrar();
                    mtdAtualizarDtg1(vetCamposTabelaInventarioBens[0], string.Empty, 1);
                    //mtdConsultarItensRepetidosCampoInformado(vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensN_Serie], vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensIdentificacao_Inventario]);
                    if (btnModoCadastroInventario.Text.Equals("Modo &Inventário"))
                    {
                        try
                        {
                            txtPatrimonioItem.Focus();
                            txtPatrimonioItem.SelectAll();
                        }
                        catch (System.Exception ex)
                        {
                            string strExcecao = "mni2_Click: " + ex.Message;
                            System.Diagnostics.Debug.WriteLine(strExcecao);
                            //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                        }
                    }
                    else
                    {
                        try
                        {
                            if (blnIncrementarPatrimonio)
                            {
                                txtPatrimonioItem.Text = System.Convert.ToString(System.Convert.ToInt64(txtPatrimonioItem.Text) + 1);
                            }
                            txtNSerieItem.Focus();
                            txtNSerieItem.SelectAll();
                        }
                        catch (System.Exception ex)
                        {
                            txtPatrimonioItem.Focus();
                            txtPatrimonioItem.SelectAll();

                            string strExcecao = "mni2_Click: " + ex.Message;
                            System.Diagnostics.Debug.WriteLine(strExcecao);
                            //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                        }
                    }
                    break;
                case "Fotografar":
                    mtdTirarFotografia();
                    break;
                case "N_Serie":
                    mtdConsultarItensRepetidosCampoInformado(vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensN_Serie], cmbConsultarInventarioRepeticoes.Text);
                    break;
                case "Otimizado":
                    if (chkModoOtimizadoCadastro.Enabled)
                    {
                        mtdChecarModoOtimizadoCadastro();
                        mtdRegistroModoOtimizadoCadastro();
                    }
                    break;
                case "Permitir":
                    chkPermitirExibicaoNotificacoes.Checked = !chkPermitirExibicaoNotificacoes.Checked;
                    chkPermitirExibicaoNotificacoes_Click(sender, e);
                    break;
                case "Sair":
                    mtdSairAplicativo();
                    break;
                case "Sincronizar":
                    mtdSincronizarHorarioServidor();
                    break;
            }
        }

        private void mtdPreencherTxtNomeItem(string MatriculaItem)
        {
            mtdPreencherTxtNomeItem(MatriculaItem, true);
        }

        private void mtdPreencherTxtNomeItem(string MatriculaItem, bool Notificar)
        {
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                (
                clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                );

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                (
                clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                strBaseDadosColetor,
                strSenhaColetor
                );

            objImplementacaoBancoDados.mtdSelecionarDados
                (
                true,
                false,
                vetCamposTabelaEmpregados[intColunaTabelaEmpregadosNome],
                strTabelaEmpregados,
                string.Format
                (
                "{0}, {1}",
                vetCamposTabelaEmpregados[intColunaTabelaEmpregadosNome],
                vetCamposTabelaEmpregados[intColunaTabelaEmpregadosMatricula]
                ),
                vetCamposTabelaEmpregados[intColunaTabelaEmpregadosMatricula],
                "LIKE",
                string.Format
                (
                "N'{0}'",
                MatriculaItem
                ),
                vetCamposTabelaEmpregados[intColunaTabelaEmpregadosNome],
                true
                );

            objImplementacaoBancoDados.mtdDefinirLeitorDados();
            if (objImplementacaoBancoDados.mtdProximoRegistro())
            {
                txtNomeItem.Text = objImplementacaoBancoDados.mtdObterValorRegistro(0).ToString();
            }
            else
            {
                txtNomeItem.Text = string.Empty;

                if (Notificar)
                {
                    System.Windows.Forms.MessageBox.Show
                        (
                        "Não foi possível encontrar usuário com essa matrícula.",
                        "Aviso!",
                        System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Exclamation,
                        System.Windows.Forms.MessageBoxDefaultButton.Button1
                        );
                }
            }

            objImplementacaoBancoDados.Dispose();
        }

        private static object LockObterNomeItem = new object();

        private string mtdObterNomeItem(string MatriculaItem)
        {
            lock (LockObterNomeItem)
            {
                string NomeItem = string.Empty;
                clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                    (
                    clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                    );

                objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                    (
                    clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                    strBaseDadosColetor,
                    strSenhaColetor
                    );

                objImplementacaoBancoDados.mtdSelecionarDados
                    (
                    true,
                    false,
                    vetCamposTabelaEmpregados[intColunaTabelaEmpregadosNome],
                    strTabelaEmpregados,
                    vetCamposTabelaEmpregados[intColunaTabelaEmpregadosMatricula],
                    "LIKE",
                    string.Format
                    (
                    "N'%{0}%'",
                    MatriculaItem
                    ),
                    vetCamposTabelaEmpregados[intColunaTabelaEmpregadosNome],
                    vetCamposTabelaEmpregados[intColunaTabelaEmpregadosNome],
                    true
                    );

                objImplementacaoBancoDados.mtdDefinirLeitorDados();
                if (objImplementacaoBancoDados.mtdProximoRegistro())
                {
                    NomeItem = objImplementacaoBancoDados.mtdObterValorRegistro(0).ToString();
                }

                objImplementacaoBancoDados.Dispose();

                return NomeItem;
            }
        }

        private bool mtdCompactarBancoDadosColetor()
        {
            bool saida = false;

            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                (
                clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                );

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                (
                clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                strBaseDadosColetor,
                strSenhaColetor
                );

            saida = objImplementacaoBancoDados.mtdCompactarBancoDadosSQLServerCE();

            objImplementacaoBancoDados.Dispose();

            return saida;
        }

        private bool mtdRepararBancoDadosColetor()
        {
            bool saida = false;

            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                (
                clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                );

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                (
                clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                strBaseDadosColetor,
                strSenhaColetor
                );

            saida = objImplementacaoBancoDados.mtdRepararBancoDadosSQLServerCE();

            objImplementacaoBancoDados.Dispose();

            return saida;
        }

        private bool mtdCriarBancoDadosColetor()
        {
            bool saida = false;

            try
            {
                clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                   (
                   clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                   );

                objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                    (
                    clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                    strBaseDadosColetor,
                    strSenhaColetor
                    );

                saida = objImplementacaoBancoDados.mtdCriarBancoDadosSQLServerCE();

                objImplementacaoBancoDados.Dispose();
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdCriarBancoDadosColetor: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }

            return saida;
        }

        private static void mtdCriarTabelaInventarioBensColetor()
        {
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                (
                clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                );

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                (
                clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                strBaseDadosColetor,
                strSenhaColetor
                );

            string[][] campos;

            campos = new string[vetCamposTabelaInventarioBens.GetUpperBound(0) + 1][];
            for (int contador = vetCamposTabelaInventarioBens.GetLowerBound(0);
                contador <= vetCamposTabelaInventarioBens.GetUpperBound(0);
                contador++)
            {
                switch (contador)
                {
                    case intColunaTabelaInventarioBensNumero_Inventario:
                        campos[contador] = new string[4] 
                        { 
                            vetCamposTabelaInventarioBens[contador], 
                            "BIGINT",
                            string.Empty,
                            string.Format("CONSTRAINT PrimaryKey{0} PRIMARY KEY", vetCamposTabelaInventarioBens[contador])
                        };
                        break;
                    case intColunaTabelaInventarioBensData_Inventario:
                        campos[contador] = new string[4]
                        {
                            vetCamposTabelaInventarioBens[contador], 
                            "DATETIME",
                            string.Empty,
                            string.Empty 
                        };
                        break;
                    case intColunaTabelaInventarioBensInventario:
                        campos[contador] = new string[4]
                        {
                            vetCamposTabelaInventarioBens[contador], 
                            "NVARCHAR", 
                            "255", 
                            string.Format
                            (
                            " UNIQUE REFERENCES {0}({1})",
                            strTabelaInventarioBens,
                            vetCamposTabelaInventarioBens[contador]
                            ) 
                        };
                        break;
                    case intColunaTabelaInventarioBensQuantidade:
                        campos[contador] = new string[4] 
                        { 
                            vetCamposTabelaInventarioBens[contador], 
                            "BIGINT",
                            string.Empty,
                            string.Empty
                        };
                        break;
                    case intColunaTabelaInventarioBensFotografia:
                        campos[contador] = new string[4]
                        {
                            vetCamposTabelaInventarioBens[contador], 
                            "IMAGE",
                            string.Empty, 
                            string.Empty 
                        };
                        break;
                    default:
                        campos[contador] = new string[4]
                        {
                            vetCamposTabelaInventarioBens[contador], 
                            "NVARCHAR", 
                            "255", 
                            string.Empty 
                        };
                        break;
                }
            }
            objImplementacaoBancoDados.mtdCriarTabela(
                strTabelaInventarioBens,
                campos);

            objImplementacaoBancoDados.Dispose();
        }

        public static void mtdCriarTabelaBensEletronorteColetor()
        {
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                (
                clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                );

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                (
                clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                strBaseDadosColetor,
                strSenhaColetor
                );

            string[][] campos;

            campos = new string[vetCamposTabelaBensEletronorteCompleto.GetUpperBound(0) + 1][];
            for (int contador = vetCamposTabelaBensEletronorteCompleto.GetLowerBound(0);
                contador <= vetCamposTabelaBensEletronorteCompleto.GetUpperBound(0);
                contador++)
            {
                switch (contador)
                {
                    case intColunaTabelaBensEletronorteCompletoImobilizado:
                        campos[contador] = new string[4] 
                        { 
                            vetCamposTabelaBensEletronorteCompleto[contador], 
                            "NVARCHAR",
                            "255", 
                            string.Empty
                        };
                        break;
                    case intColunaTabelaBensEletronorteCompletoPatrimonio:
                        campos[contador] = new string[4]
                        {
                            vetCamposTabelaBensEletronorteCompleto[contador], 
                            "INTEGER",
                            string.Empty, 
                            string.Format("CONSTRAINT PrimaryKey{0} PRIMARY KEY", vetCamposTabelaBensEletronorteCompleto[contador])
                        };
                        break;
                    default:
                        campos[contador] = new string[4]
                        {
                            vetCamposTabelaBensEletronorteCompleto[contador], 
                            "NVARCHAR", 
                            "255", 
                            string.Empty 
                        };
                        break;
                }
            }
            objImplementacaoBancoDados.mtdCriarTabela(
                strTabelaBensEletronorte,
                campos);

            objImplementacaoBancoDados.Dispose();
        }

        public static void mtdCriarTabelaEmpregadosColetor()
        {
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                (
                clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                );

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                (
                clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                strBaseDadosColetor,
                strSenhaColetor
                );

            string[][] campos;

            campos = new string[vetCamposTabelaEmpregados.GetUpperBound(0) + 1][];
            for (int contador = vetCamposTabelaEmpregados.GetLowerBound(0);
                contador <= vetCamposTabelaEmpregados.GetUpperBound(0);
                contador++)
            {
                switch (contador)
                {
                    case intColunaTabelaEmpregadosMatricula:
                        campos[contador] = new string[4]
                        {
                            vetCamposTabelaEmpregados[contador], 
                            "INTEGER",
                            string.Empty, 
                            string.Format("CONSTRAINT PrimaryKey{0} PRIMARY KEY", vetCamposTabelaEmpregados[contador])
                        };
                        break;
                    default:
                        campos[contador] = new string[4]
                        {
                            vetCamposTabelaEmpregados[contador], 
                            "NVARCHAR", 
                            "255", 
                            string.Empty 
                        };
                        break;
                }
            }
            objImplementacaoBancoDados.mtdCriarTabela(
                strTabelaEmpregados,
                campos);

            objImplementacaoBancoDados.Dispose();
        }

        public static void mtdCriarTabelaCentroCustoColetor()
        {
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                (
                clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                );

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                (
                clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                strBaseDadosColetor,
                strSenhaColetor
                );

            string[][] campos;
            campos = new string[vetCamposTabelaCentroCusto.GetUpperBound(0) + 1][];
            for (int contador = vetCamposTabelaCentroCusto.GetLowerBound(0);
                contador <= vetCamposTabelaCentroCusto.GetUpperBound(0);
                contador++)
            {
                switch (contador)
                {
                    case intColunaTabelaCentroCustoCentroCusto:
                        campos[contador] = new string[4] 
                        { 
                            vetCamposTabelaCentroCusto[contador], 
                            "INTEGER",
                            string.Empty,
                            string.Format("CONSTRAINT PrimaryKey{0} PRIMARY KEY", vetCamposTabelaCentroCusto[contador])
                        };
                        break;
                    default:
                        campos[contador] = new string[4]
                        {
                            vetCamposTabelaCentroCusto[contador], 
                            "NVARCHAR", 
                            "255", 
                            string.Empty 
                        };
                        break;
                }
            }
            objImplementacaoBancoDados.mtdCriarTabela(strTabelaCentroCusto, campos);

            objImplementacaoBancoDados.Dispose();
        }

        public string mtdVetorLinhaCampos(string[] Campos)
        {
            string strCampos = string.Empty;
            for (int contador = Campos.GetLowerBound(0); contador <= Campos.GetUpperBound(0); contador++)
            {
                strCampos += string.Format((!(contador == Campos.GetUpperBound(0))) ? "{0}, " : "{0}", Campos[contador]);
            }
            return strCampos;
        }

        public static string prpEnderecoBancoDadosColetor
        {
            get
            {
                return strEnderecoBancoDadosColetor;
            }
            set
            {
                if (value != string.Empty)
                {
                    strEnderecoBancoDadosColetor = value;
                }
            }
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            dblTempoPressionamentoBotao = DateTime.Now.TimeOfDay.TotalMilliseconds;

            //strEnderecoBancoDadosColetor = objEnderecoAplicativo.Endereco();
            frmPrincipal.DiretorioArmazenamentoCompleto = String.Format(@"{0}\{1}\", strEnderecoBancoDadosColetor, DiretorioArmazenamento);
            frmPrincipal.DiretorioEnderecoAplicativo = DiretorioArmazenamentoCompleto;

            try
            {
                System.IO.Directory.CreateDirectory(frmPrincipal.DiretorioArmazenamentoCompleto);
            }
            catch (System.Exception ex)
            {
                string strExcecao = "frmPrincipal_Load: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }

            mtdSenhaBaseDados();
            mtdEnderecoBaseDados();

            mtdIniciarThreadPreparacaoColetor();

            txtNomeDispositivo.Text = System.Net.Dns.GetHostName();
            txtQuantidadeItem.Text = "1";

            mtdSetarTbc1();
            mtdNumeroLinhas();
            mtdComprimentoColunas();
            mtdNumeroCopiasBackup();
            mtdTemporizador();

            mtdCarregarCmbCCSQ();
            mtdCarregarCmbObservacaoItem();
            mtdCarregarCmbTipoMapa();
            mtdCarregarCmbResolucaoFotografia();
            mtdCarregarCmbPrioridadeModoOtimizadoCadastro();

            try
            {
                mtdCarregarCmb
                    (
                    ref cmbConsultarInventario,
                    string.Format("SELECT TOP (0) * FROM {0}", strTabelaInventarioBens)
                    );
                cmbConsultarInventario.SelectedIndex = 0;
                mtdCarregarCmb
                    (
                    ref cmbConsultarSAP,
                    string.Format("SELECT TOP (0) {0} FROM {1}", mtdVetorLinhaCampos(vetCamposTabelaBensEletronorte), strTabelaBensEletronorte)
                    );
                cmbConsultarSAP.SelectedIndex = 1;
                mtdCarregarCmb
                    (
                    ref cmbConsultarEmpregados,
                    string.Format("SELECT TOP (0) * FROM {0}", strTabelaEmpregados)
                    );
                cmbConsultarEmpregados.SelectedIndex = 0;
                mtdCarregarCmb
                    (
                    ref cmbConsultarCentroCusto,
                    string.Format("SELECT TOP (0) * FROM {0}", strTabelaCentroCusto)
                    );
                cmbConsultarCentroCusto.SelectedIndex = 1;
                mtdCarregarCmb
                    (
                    ref cmbConsultarInventarioRepeticoes,
                    string.Format("SELECT TOP (0) * FROM {0}", strTabelaInventarioBens)
                    );
                cmbConsultarInventarioRepeticoes.SelectedIndex = intColunaTabelaInventarioBensIdentificacao_Inventario;

                mtdCarregarCmbConsultarTabelaRelatorio();
                cmbConsultarTabelaRelatorio.SelectedIndex = 0;
            }
            catch (System.Exception ex)
            {
                string strExcecao = "frmPrincipal_Load: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }

            mtdPermitirExibicaoNotificacoes();
            mtdModoOtimizadoCadastro();
            mtdProcuraAutomatica();
            mtdIncrementarPatrimonio();
            blnEstadoAnteriorModoOtimizadoCadastro = chkModoOtimizadoCadastro.Checked;
            mtdModoCadastroInventario();
            mtdUsuarioInventario();
            mtdMatriculaInventario();
            mtdQualidadeFotografia();
            mtdResolucaoFotografia();
            mtdPrioridadeModoOtimizadoCadastro();

            //mtdEnderecoProxy();
            //mtdPortaProxy();
            //mtdDominioProxy();
            //mtdUsuarioProxy();
            //mtdSenhaProxy();

            //mtdAtivarDesativarGPS();

            mtdAtualizarDtg1(vetCamposTabelaInventarioBens[0], string.Empty, uintNumeroLinhas);
            tmpImage = pctFotografia.Image;

            try
            {
                ntf1.Text = "Digite o nome ou a matrícula do agente da coleta e pressione a tecla enter.";
            }
            catch (System.Exception ex)
            {
                ntf1.Text = "Digite o nome ou a matrícula do agente da coleta.";
            }

            if (btnModoCadastroInventario.Text.Equals("Modo &Inventário"))
            {
                chkModoOtimizadoCadastro.Enabled = true;
                chkModoOtimizadoCadastro.Checked = blnEstadoAnteriorModoOtimizadoCadastro;
            }
            else
            {
                blnEstadoAnteriorModoOtimizadoCadastro = chkModoOtimizadoCadastro.Checked;
                chkModoOtimizadoCadastro.Checked = false;
                chkModoOtimizadoCadastro.Enabled = false;
            }

            if (chkModoOtimizadoCadastro.Checked)
            {
                btnDenominacaoItem.ForeColor = Color.FromArgb(192, 0, 0);
                btnNSerieItem.ForeColor = Color.FromArgb(192, 0, 0);
                btnPlacaVeiculoItem.ForeColor = Color.FromArgb(192, 0, 0);
                txtDenominacaoItem.Text = string.Empty;
                txtNSerieItem.Text = string.Empty;
                txtPlacaVeiculoItem.Text = string.Empty;
                txtIdentificacaoItem.Text = string.Empty;
                txtOutrosDadosItem.Text = string.Empty;

                mtdIniciarThreadCadastroOtimizado();
            }
            else
            {
                btnDenominacaoItem.ForeColor = Color.FromArgb(0, 0, 192);
                btnNSerieItem.ForeColor = Color.FromArgb(0, 0, 192);
                btnPlacaVeiculoItem.ForeColor = Color.FromArgb(0, 0, 192);
                btnIdentificacaoItem.ForeColor = Color.FromArgb(0, 0, 192);
                btnOutrosDadosItem.ForeColor = Color.FromArgb(0, 0, 192);

                mtdAbortarThreadCadastroOtimizado(true);
            }

            blnPermitirAtualizacaoDtpDataInventario = true;
            dtpDataSistema.Enabled = false;
            dtpTempoSistema.Enabled = false;

            mtdIdentificacaoItemAvancar();
            mtdNivelBateria();
            mtdColorirNivelBateria();
            mtdGerarNivelBateria(true, true);

            txtRepeticoes.Text = System.Convert.ToString(intRepeticoesPadrao);
            mtdConsultarItensRepetidosCampoInformado(vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensN_Serie], vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensIdentificacao_Inventario]);
            txtTemporizador.Text = System.Convert.ToString(uintTemporizador);
        }

        private void frmPrincipal_Closing(object sender, CancelEventArgs args)
        {
            if (!retornoSairAplicativo)
            {
                args.Cancel = true;
            }
        }

        private bool retornoSairAplicativo = true;

        private bool mtdSairAplicativo()
        {
            if (System.Windows.Forms.MessageBox.Show
                (
                "Deseja realmente sair do aplicativo?",
                "Aviso!",
                System.Windows.Forms.MessageBoxButtons.YesNo,
                System.Windows.Forms.MessageBoxIcon.Exclamation,
                System.Windows.Forms.MessageBoxDefaultButton.Button2) ==
                System.Windows.Forms.DialogResult.Yes
                )
            {
                try
                {
                    mtdAbortarThreadCadastroOtimizado(true);
                    mtdAbortarThreadPreparacaoColetor();
                    mtdAbortarThreadNotificacao();

                    ntf1.Visible = false;
                    ntf1.Dispose();

                    frmMonitorCarregamentoDados.mtdAbortarThreadManterCanalAberto();

                    objMonitorCarregamentoDados.Close();
                    objMonitorCarregamentoDados.Dispose();

                    objBatteryStatus.Close();
                    objBatteryStatus.Dispose();

                    objGpsPerimeter.Close();
                    objGpsPerimeter.Dispose();

                    if (objgps.Opened)
                    {
                        objgps.DeviceStateChanged -= gps_DeviceStateChange;
                        objgps.LocationChanged -= gps_LocationChanged;
                        objgps.Close();
                    }
                }
                catch (System.Exception ex)
                {
                    string strExcecao = "mtdSairAplicativo: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                    //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                }

                try
                {
                    retornoSairAplicativo = true;

                    //this.Close();
                    //this.Dispose();
                    Application.Exit();
                }
                catch (System.Exception ex)
                {
                    string strExcecao = "mtdSairAplicativo: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                    //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                }
                finally
                {
                }
            }
            else
            {
                retornoSairAplicativo = false;
            }

            return retornoSairAplicativo;
        }

        private void mtdPreencherCmb(ref System.Windows.Forms.ComboBox cmb, string CampoSelecionador, string Tabela, bool Crescente)
        {
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                (
                clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                );

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                (
                clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                strBaseDadosColetor,
                strSenhaColetor
                );

            objImplementacaoBancoDados.mtdAbrirConexao();
            objImplementacaoBancoDados.mtdExecutarComando
                (
                string.Format
                (
                "SELECT DISTINCT {0} FROM {1} ORDER BY {0} {2};",
                CampoSelecionador,
                Tabela,
                Crescente ? string.Empty : "DESC"
                )
                );

            objImplementacaoBancoDados.mtdDefinirLeitorDados();

            while (objImplementacaoBancoDados.mtdProximoRegistro())
            {
                cmb.Items.Add(objImplementacaoBancoDados.mtdObterValorRegistro(0));
            }

            objImplementacaoBancoDados.Dispose();
        }

        private void txtUsuarioInventario_GotFocus(object sender, EventArgs e)
        {
            txtUsuarioInventario.SelectAll();
        }

        private void txtMatriculaInventario_GotFocus(object sender, EventArgs e)
        {
            txtMatriculaInventario.SelectAll();
        }

        private void txtTRGItem_GotFocus(object sender, EventArgs e)
        {
            strTextoSelecionado = txtTRGItem.Name;

            txtTRGItem.SelectAll();
        }

        private void txtCentroCustoItem_GotFocus(object sender, EventArgs e)
        {
            strTextoSelecionado = txtCentroCustoItem.Name;

            txtCentroCustoItem.SelectAll();
        }

        private void txtOrgaoItem_GotFocus(object sender, EventArgs e)
        {
            strTextoSelecionado = txtOrgaoItem.Name;

            txtOrgaoItem.SelectAll();
        }

        private void txtSalaItem_GotFocus(object sender, EventArgs e)
        {
            strTextoSelecionado = txtSalaItem.Name;

            txtSalaItem.SelectAll();
        }

        private void txtNomeItem_GotFocus(object sender, EventArgs e)
        {
            strTextoSelecionado = txtNomeItem.Name;

            txtNomeItem.SelectAll();
        }

        private void txtMatriculaItem_GotFocus(object sender, EventArgs e)
        {
            strTextoSelecionado = txtMatriculaItem.Name;

            txtMatriculaItem.SelectAll();
        }

        private void txtPatrimonioItem_GotFocus(object sender, EventArgs e)
        {
            strTextoSelecionado = txtPatrimonioItem.Name;

            txtPatrimonioItem.SelectAll();
        }

        private void txtDenominacaoItem_GotFocus(object sender, EventArgs e)
        {
            strTextoSelecionado = txtDenominacaoItem.Name;

            txtDenominacaoItem.SelectAll();
        }

        private void txtNSerieItem_GotFocus(object sender, EventArgs e)
        {
            strTextoSelecionado = txtNSerieItem.Name;

            txtNSerieItem.SelectAll();
        }

        private void txtPlacaVeiculoItem_GotFocus(object sender, EventArgs e)
        {
            strTextoSelecionado = txtPlacaVeiculoItem.Name;

            txtPlacaVeiculoItem.SelectAll();
        }

        private void txtIdentificacaoItem_GotFocus(object sender, EventArgs e)
        {
            strTextoSelecionado = txtIdentificacaoItem.Name;

            txtIdentificacaoItem.SelectAll();
        }

        private void txtOutrosDadosItem_GotFocus(object sender, EventArgs e)
        {
            strTextoSelecionado = txtOutrosDadosItem.Name;

            txtOutrosDadosItem.SelectAll();
        }

        private void cmbObservacaoItem_GotFocus(object sender, EventArgs e)
        {
            strTextoSelecionado = cmbObservacaoItem.Name;

            cmbObservacaoItem.SelectAll();
        }

        private void mtdCarregarEnderecoBaseDados()
        {
            //define as propriedades do controle 
            //OpenFileDialog
            ofd1.InitialDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);

            //filtra para exibir somente arquivos de imagens
            ofd1.Filter = "Arquivos do SQL Server CE (*.sdf)|*.sdf|Todos Arquivos (*.*)|*.*";
            ofd1.FilterIndex = 1;

            DialogResult dr = this.ofd1.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                // Le os arquivos selecionados 
                txtEnderecoBaseDados.Text = ofd1.FileName;
                strBaseDadosColetor = ofd1.FileName;
            }
        }

        private void btnEnderecoBaseDados_Click(object sender, EventArgs e)
        {
            mtdCarregarEnderecoBaseDados();
        }

        private void mtdCarregarCaixaDtgv1(long Numero_Inventario)
        {
            mtdCarregarCaixaTextoDtgv1(Numero_Inventario);
        }

        private void mtdCarregarCaixaDtgv2()
        {
            mtdCarregarCaixaTextoDtgv2();
        }

        private void mtdCarregarCaixaDtgv3()
        {
            mtdCarregarCaixaTextoDtgv3();
        }

        private void mtdCarregarCaixaDtgv4()
        {
            mtdCarregarCaixaTextoDtgv4();
        }

        private void mtdCarregarDtgv5()
        {
            try
            {
                if (cmbConsultarTabelaRelatorio.Text == cmbConsultarTabelaRelatorio.Items[0].ToString())
                {
                    cmbConsultarInventario.Text = cmbConsultarCamposRelatorio.Text;
                    txtConsultarInventario.Text = dtg5[dtg5.CurrentCell.RowNumber, 0].ToString();
                }
                if (cmbConsultarTabelaRelatorio.Text == cmbConsultarTabelaRelatorio.Items[1].ToString())
                {
                    cmbConsultarSAP.Text = cmbConsultarCamposRelatorio.Text;
                    txtConsultarSAP.Text = dtg5[dtg5.CurrentCell.RowNumber, 0].ToString();
                }
                if (cmbConsultarTabelaRelatorio.Text == cmbConsultarTabelaRelatorio.Items[2].ToString())
                {
                    cmbConsultarEmpregados.Text = cmbConsultarCamposRelatorio.Text;
                    txtConsultarEmpregados.Text = dtg5[dtg5.CurrentCell.RowNumber, 0].ToString();
                }
                if (cmbConsultarTabelaRelatorio.Text == cmbConsultarTabelaRelatorio.Items[3].ToString())
                {
                    cmbConsultarCentroCusto.Text = cmbConsultarCamposRelatorio.Text;
                    txtConsultarCentroCusto.Text = dtg5[dtg5.CurrentCell.RowNumber, 0].ToString();
                }
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdCarregarDtgv5: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void dtg1_Click(object sender, EventArgs e)
        {
            if (dtg1.CurrentRowIndex >= 0)
            {
                mtdCarregarCaixaDtgv1(System.Convert.ToInt64(dtg1[dtg1.CurrentRowIndex, 0]));
            }
        }

        private void dtg2_Click(object sender, EventArgs e)
        {
            mtdCarregarCaixaDtgv2();
        }

        private void dtg3_Click(object sender, EventArgs e)
        {
            mtdCarregarCaixaDtgv3();
        }

        private void dtg4_Click(object sender, EventArgs e)
        {
            mtdCarregarCaixaDtgv4();
        }

        private void dtg5_Click(object sender, EventArgs e)
        {
            mtdCarregarDtgv5();
        }

        //Open file in to a filestream and read data in a byte array.
        private byte[] ReadFile(string sPath)
        {
            //Initialize byte array with a null value initially.
            byte[] data = null;
            if (!(sPath.Equals(string.Empty)))
            {
                //Use FileInfo object to get file size.
                System.IO.FileInfo fInfo = new System.IO.FileInfo(sPath);
                long numBytes = fInfo.Length;

                //Open FileStream to read file
                System.IO.FileStream fStream = new System.IO.FileStream
                    (
                    sPath,
                    System.IO.FileMode.Open,
                    System.IO.FileAccess.Read
                    );

                //Use BinaryReader to read file stream into byte array.
                System.IO.BinaryReader br = new System.IO.BinaryReader(fStream);

                //When you use BinaryReader, you need to supply number of bytes to read from file.
                //In this case we want to read entire file. So supplying total number of bytes.
                data = br.ReadBytes((int)numBytes);
            }
            else
            {
                data = imageToByteArray(tmpImage);
            }

            return data;
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        //public Image byteArrayToImage(byte[] byteArrayIn)
        //{
        //    System.IO.MemoryStream ms = new System.IO.MemoryStream(byteArrayIn);
        //    Image returnImage = Image.FromStream(ms);
        //    return returnImage;
        //}

        private void mtdExecutarTudoTextos()
        {
            txtUsuarioInventario.Text = objManipuladorTexto.mtdExecutarTudo(txtUsuarioInventario.Text);
            txtMatriculaInventario.Text = objManipuladorTexto.mtdExecutarTudo(txtMatriculaInventario.Text);
            txtTRGItem.Text = objManipuladorTexto.mtdExecutarTudo(txtTRGItem.Text);
            txtCentroCustoItem.Text = objManipuladorTexto.mtdExecutarTudo(txtCentroCustoItem.Text);
            txtOrgaoItem.Text = objManipuladorTexto.mtdExecutarTudo(txtOrgaoItem.Text);
            txtSalaItem.Text = objManipuladorTexto.mtdExecutarTudo(txtSalaItem.Text);
            txtNomeItem.Text = objManipuladorTexto.mtdExecutarTudo(txtNomeItem.Text);
            txtMatriculaItem.Text = objManipuladorTexto.mtdExecutarTudo(txtMatriculaItem.Text);
            txtPatrimonioItem.Text = objManipuladorTexto.mtdExecutarTudo(txtPatrimonioItem.Text);
            try
            {
                txtPatrimonioItem.Text = System.Convert.ToInt64(txtPatrimonioItem.Text).ToString();
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdExecutarTudoCombos: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
            txtDenominacaoItem.Text = objManipuladorTexto.mtdExecutarTudo(txtDenominacaoItem.Text);
            txtNSerieItem.Text = objManipuladorTexto.mtdExecutarTudo(txtNSerieItem.Text);
            txtPlacaVeiculoItem.Text = objManipuladorTexto.mtdExecutarTudo(txtPlacaVeiculoItem.Text);
            txtIdentificacaoItem.Text = objManipuladorTexto.mtdExecutarTudo(txtIdentificacaoItem.Text);
            txtOutrosDadosItem.Text = objManipuladorTexto.mtdExecutarTudo(txtOutrosDadosItem.Text);
            cmbObservacaoItem.Text = objManipuladorTexto.mtdMaiusculo(cmbObservacaoItem.Text);
        }

        private bool mtdAtualizar()
        {
            return mtdAtualizarCaixaTexto();
        }

        private bool mtdAtualizarLista(string NumeroInventario)
        {
            return mtdAtualizarListaCaixaTexto(NumeroInventario);
        }

        private void mtdCadastrar()
        {
            mtdCadastrarCaixaTexto();
        }

        private bool mtdDeletarDadosTabelaInventarioBens(string NumeroInventario)
        {
            bool blnRetorno = false;

            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                (
                clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                );

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                (
                clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                strBaseDadosColetor,
                strSenhaColetor
                );

            try
            {
                blnRetorno = objImplementacaoBancoDados.mtdDeletarDados
                                (
                                strTabelaInventarioBens,
                                vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensNumero_Inventario],
                                "LIKE",
                                NumeroInventario
                                );
            }
            catch (System.Exception ex)
            {
                blnRetorno = false;

                string strExcecao = "mtdDeletarDadosTabelaInventarioBens: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }

            objImplementacaoBancoDados.Dispose();

            return blnRetorno;
        }

        private bool mtdDeletarDadosTabelaSAP(string Patrimonio)
        {
            bool blnRetorno = false;

            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                (
                clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                );

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                (
                clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                strBaseDadosColetor,
                strSenhaColetor
                );

            try
            {
                blnRetorno = objImplementacaoBancoDados.mtdDeletarDados
                                (
                                strTabelaBensEletronorte,
                                vetCamposTabelaBensEletronorte[intColunaTabelaBensEletronortePatrimonio],
                                "LIKE",
                                Patrimonio
                                );
            }
            catch (System.Exception ex)
            {
                blnRetorno = false;

                string strExcecao = "mtdDeletarDadosTabelaSAP: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }

            objImplementacaoBancoDados.Dispose();

            return blnRetorno;
        }

        private bool mtdDeletarDadosTabelaEmpregados(string Matricula)
        {
            bool blnRetorno = false;

            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                (
                clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                );

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                (
                clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                strBaseDadosColetor,
                strSenhaColetor
                );

            try
            {
                blnRetorno = objImplementacaoBancoDados.mtdDeletarDados
                                (
                                strTabelaEmpregados,
                                vetCamposTabelaEmpregados[intColunaTabelaEmpregadosMatricula],
                                "LIKE",
                                Matricula
                                );
            }
            catch (System.Exception ex)
            {
                blnRetorno = false;

                string strExcecao = "mtdDeletarDadosTabelaEmpregados: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }

            objImplementacaoBancoDados.Dispose();

            return blnRetorno;
        }

        private bool mtdDeletarDadosTabelaCentroCusto(string CentroCusto)
        {
            bool blnRetorno = false;

            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                (
                clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                );

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                (
                clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                strBaseDadosColetor,
                strSenhaColetor
                );

            try
            {
                blnRetorno = objImplementacaoBancoDados.mtdDeletarDados
                                (
                                strTabelaCentroCusto,
                                vetCamposTabelaCentroCusto[intColunaTabelaCentroCustoCentroCusto],
                                "LIKE",
                                CentroCusto
                                );
            }
            catch (System.Exception ex)
            {
                blnRetorno = false;

                string strExcecao = "mtdDeletarDadosTabelaCentroCusto: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }

            objImplementacaoBancoDados.Dispose();

            return blnRetorno;
        }

        private ulong mtdGerarProximoNumeroInventario()
        {
            int intNumeroControle = 1000000;

            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                (
                clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                );

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                (
                clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                strBaseDadosColetor,
                strSenhaColetor
                );

            System.DateTime dtAtual = System.DateTime.Today;

            objImplementacaoBancoDados.mtdSelecionarDados
                (
                vetCamposTabelaInventarioBens,
                strTabelaInventarioBens,
                vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensNumero_Inventario],
                false
                );

            ulong ulngNumeroInventario = 0;
            ulong ulngMaximoNumeroInventario = 0;

            objImplementacaoBancoDados.mtdDefinirLeitorDados();

            if (objImplementacaoBancoDados.mtdProximoRegistro())
            {
                string strValorRegistro = objImplementacaoBancoDados.mtdObterValorRegistro(0).ToString();
                if (strValorRegistro != string.Empty)
                {
                    ulngMaximoNumeroInventario = Convert.ToUInt64(strValorRegistro);
                    if ((ulngMaximoNumeroInventario > (ulong)(dtAtual.Year * intNumeroControle)
                        && ulngMaximoNumeroInventario < (ulong)(dtAtual.AddYears(1).Year * intNumeroControle)))
                    {
                        objImplementacaoBancoDados.mtdExecutarComando
                            (
                            string.Format
                            (
                            "SELECT {0} FROM {1} WHERE  {0} > {2} AND {0} < {3} ORDER BY {0} DESC;",
                            vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensNumero_Inventario],
                            strTabelaInventarioBens,
                            dtAtual.Year * intNumeroControle,
                            (dtAtual.Year + 1) * intNumeroControle
                            )
                            );
                        objImplementacaoBancoDados.mtdDefinirLeitorDados();
                        if (objImplementacaoBancoDados.mtdProximoRegistro())
                        {
                            strValorRegistro = objImplementacaoBancoDados.mtdObterValorRegistro(0).ToString();
                            ulngMaximoNumeroInventario = Convert.ToUInt64(strValorRegistro);
                        }
                        else
                        {
                            ulngMaximoNumeroInventario = Convert.ToUInt64(dtAtual.Year * intNumeroControle);
                        }
                    }
                    ulngNumeroInventario = ulngMaximoNumeroInventario + 1;
                }
                else
                {
                    ulngNumeroInventario = (ulong)((dtAtual.Year * intNumeroControle) + 1);
                }
            }
            else
            {
                ulngNumeroInventario = (ulong)((dtAtual.Year * intNumeroControle) + 1);
            }

            objImplementacaoBancoDados.Dispose();

            return ulngNumeroInventario;
        }

        private DataGridTableStyle mtdAjustarComprimentoColunasDtg(ref System.Data.DataTable dt, string cn, string cm, uint Comprimento)
        {
            DataGridTableStyle ts = new DataGridTableStyle();

            try
            {
                //System.Data.Coletor.SqlCeDataAdapter da = new System.Data.Coletor.SqlCeDataAdapter(cm, cn);
                //da.Fill(dt);

                //ts = new DataGridTableStyle();
                ts.MappingName = dt.TableName;

                foreach (DataColumn item in dt.Columns)
                {
                    DataGridTextBoxColumn tbcName = new DataGridTextBoxColumn();
                    tbcName.Width = System.Convert.ToInt32(Comprimento);
                    tbcName.MappingName = item.ColumnName;
                    tbcName.HeaderText = item.ColumnName;
                    ts.GridColumnStyles.Add(tbcName);
                }
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdAjustarComprimentoColunasDtg: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }

            return ts;
        }

        public DataTable dt = new DataTable();

        private void mtdPreencherDtg
            (
            ref System.Windows.Forms.DataGrid dtg,
            uint NumeroLinhas,
            string[] Campos,
            string NomeTabela,
            string CampoSelecionador,
            string Operacao,
            string Dado,
            string CampoOrdenador,
            bool Crescente
            )
        {
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                (
                clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                );

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                (
                clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                strBaseDadosColetor,
                strSenhaColetor
                );

            Cursor.Current = Cursors.WaitCursor; // set the wait cursor
            //Do some work

            try
            {
                objImplementacaoBancoDados.mtdSelecionarDados
                    (
                    NumeroLinhas,
                    Campos,
                    NomeTabela,
                    CampoSelecionador,
                    Operacao,
                    Dado,
                    CampoOrdenador,
                    Crescente
                    );

                if (dtg.Name == dtg1.Name)
                {
                    //objImplementacaoBancoDados.mtdAdaptadorDados();

                    objImplementacaoBancoDados.mtdDefinirLeitorDados();
                    objImplementacaoBancoDados.mtdProximoRegistro();

                    dt = new DataTable();
                    DataRow dr;

                    dr = dt.NewRow();

                    object[][] vetColunaTipo = objImplementacaoBancoDados.mtdObterCabecalhoTipoRegistro();

                    for (int coluna = 0; coluna <= intCamposTabelaInventarioBens - 1; coluna++)
                    {
                        if ((vetColunaTipo[1][coluna]).ToString() != "System.DBNull")
                        {
                            dt.Columns.Add
                                (
                                vetColunaTipo[0][coluna].ToString(),
                                (System.Type)
                                vetColunaTipo[1][coluna]
                                );
                        }
                        else
                        {
                            dt.Columns.Add
                                (
                                vetColunaTipo[0][coluna].ToString(),
                                System.Type.GetType("System.Object")
                                );
                        }

                        dr[coluna] = objImplementacaoBancoDados.mtdObterValorRegistro(coluna);
                    }

                    dt.Rows.Add(dr);

                    while (objImplementacaoBancoDados.mtdProximoRegistro())
                    {
                        dr = dt.NewRow();
                        for (int coluna = 0; coluna <= intCamposTabelaInventarioBens - 1; coluna++)
                        {
                            dr[coluna] = objImplementacaoBancoDados.mtdObterValorRegistro(coluna);
                        }
                        dt.Rows.Add(dr);
                    }

                    dtg.TableStyles.Clear();
                    dtg.TableStyles.Add(mtdAjustarComprimentoColunasDtg(ref dt, objImplementacaoBancoDados.prpConexao, objImplementacaoBancoDados.prpComando, uintComprimentoColunas));

                    dtg.DataSource = dt;
                    if (dtg.VisibleRowCount > 0)
                    {
                        dtg.Select(dtg.VisibleRowCount - 1);
                    }
                }
                else
                {
                    objImplementacaoBancoDados.mtdAdaptadorDados();

                    dtg.TableStyles.Clear();
                    dtg.TableStyles.Add(mtdAjustarComprimentoColunasDtg(ref objImplementacaoBancoDados.objTabelaDados, objImplementacaoBancoDados.prpConexao, objImplementacaoBancoDados.prpComando, uintComprimentoColunas));

                    dtg.DataSource = objImplementacaoBancoDados.prpTabelaDados;
                    if (dtg.VisibleRowCount > 0)
                    {
                        dtg.Select(dtg.VisibleRowCount - 1);
                    }
                }
            }
            catch (System.Exception ex)
            {
                dtg.DataSource = null;

                ntf1.Text = "Não foi possível preencher a tabela.";
                string strExcecao = "mtdPreencherDtg: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }

            Cursor.Current = Cursors.Default; //restore the old cursor

            objImplementacaoBancoDados.Dispose();
        }

        private void mtdPreencherDtg
            (
            ref System.Windows.Forms.DataGrid dtg,
            uint NumeroLinhas,
            string[] Campos,
            string NomeTabela,
            string Selecao,
            string CampoOrdenador,
            bool Crescente
            )
        {
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
               (
               clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
               );

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                (
                clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                strBaseDadosColetor,
                strSenhaColetor
                );

            Cursor.Current = Cursors.WaitCursor; // set the wait cursor
            //Do some work

            try
            {
                objImplementacaoBancoDados.mtdAbrirConexao();
                objImplementacaoBancoDados.mtdExecutarComando
                    (
                    string.Format
                    (
                    "SELECT {0}{1} FROM {2} WHERE {3} ORDER BY {4}{5};",
                    NumeroLinhas != 0 ? string.Format("TOP ({0}) ", NumeroLinhas) : string.Empty,
                    mtdVetorLinhaCampos(Campos),
                    NomeTabela,
                    Selecao,
                    CampoOrdenador,
                    Crescente ? string.Empty : " DESC"
                    )
                    );

                if (dtg.Name == dtg1.Name)
                {
                    //objImplementacaoBancoDados.mtdAdaptadorDados();

                    objImplementacaoBancoDados.mtdDefinirLeitorDados();
                    objImplementacaoBancoDados.mtdProximoRegistro();

                    dt = new DataTable();
                    DataRow dr;

                    dr = dt.NewRow();

                    object[][] vetColunaTipo = objImplementacaoBancoDados.mtdObterCabecalhoTipoRegistro();

                    for (int coluna = 0; coluna <= intCamposTabelaInventarioBens - 1; coluna++)
                    {
                        if ((vetColunaTipo[1][coluna]).ToString() != "System.DBNull")
                        {
                            dt.Columns.Add
                                (
                                vetColunaTipo[0][coluna].ToString(),
                                (System.Type)
                                vetColunaTipo[1][coluna]
                                );
                        }
                        else
                        {
                            dt.Columns.Add
                                (
                                vetColunaTipo[0][coluna].ToString(),
                                System.Type.GetType("System.Object")
                                );
                        }

                        dr[coluna] = objImplementacaoBancoDados.mtdObterValorRegistro(coluna);
                    }

                    dt.Rows.Add(dr);

                    while (objImplementacaoBancoDados.mtdProximoRegistro())
                    {
                        dr = dt.NewRow();
                        for (int coluna = 0; coluna <= intCamposTabelaInventarioBens - 1; coluna++)
                        {
                            dr[coluna] = objImplementacaoBancoDados.mtdObterValorRegistro(coluna);
                        }
                        dt.Rows.Add(dr);
                    }

                    dtg.TableStyles.Clear();
                    dtg.TableStyles.Add(mtdAjustarComprimentoColunasDtg(ref dt, objImplementacaoBancoDados.prpConexao, objImplementacaoBancoDados.prpComando, uintComprimentoColunas));

                    dtg.DataSource = dt;
                    if (dtg.VisibleRowCount > 0)
                    {
                        dtg.Select(dtg.VisibleRowCount - 1);
                    }
                }
                else
                {
                    if (dtg.Name == dtg2.Name)
                    {
                        txtTabelaSAPLinhas.Text = objImplementacaoBancoDados.mtdNumeroLinhas().ToString();
                        objImplementacaoBancoDados.mtdDefinirLeitorDados();
                        txtTabelaSAPColunas.Text = objImplementacaoBancoDados.mtdNumeroColunas().ToString();
                    }
                    if (dtg.Name == dtg3.Name)
                    {
                        txtTabelaEmpregadosLinhas.Text = objImplementacaoBancoDados.mtdNumeroLinhas().ToString();
                        objImplementacaoBancoDados.mtdDefinirLeitorDados();
                        txtTabelaEmpregadosColunas.Text = objImplementacaoBancoDados.mtdNumeroColunas().ToString();
                    }
                    if (dtg.Name == dtg4.Name)
                    {
                        txtTabelaCentroCustoLinhas.Text = objImplementacaoBancoDados.mtdNumeroLinhas().ToString();
                        objImplementacaoBancoDados.mtdDefinirLeitorDados();
                        txtTabelaCentroCustoColunas.Text = objImplementacaoBancoDados.mtdNumeroColunas().ToString();
                    }

                    objImplementacaoBancoDados.mtdAdaptadorDados();

                    dtg.TableStyles.Clear();
                    dtg.TableStyles.Add(mtdAjustarComprimentoColunasDtg(ref objImplementacaoBancoDados.objTabelaDados, objImplementacaoBancoDados.prpConexao, objImplementacaoBancoDados.prpComando, uintComprimentoColunas));

                    dtg.DataSource = objImplementacaoBancoDados.prpTabelaDados;
                    if (dtg.VisibleRowCount > 0)
                    {
                        dtg.Select(dtg.VisibleRowCount - 1);
                    }
                }
            }
            catch (System.Exception ex)
            {
                dtg.DataSource = null;

                ntf1.Text = "Não foi possível preencher a tabela.";
                string strExcecao = "mtdPreencherDtg: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }

            Cursor.Current = Cursors.Default; //restore the old cursor

            objImplementacaoBancoDados.Dispose();
        }

        private void mtdPreencherDtg
            (
            ref System.Windows.Forms.DataGrid dtg,
            uint NumeroLinhas,
            string Campo,
            string NomeTabela,
            string Selecao,
            string CampoOrdenador,
            bool Crescente
            )
        {
            string CampoContador = "Contador";

            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                (
                clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                );

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                (
                clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                strBaseDadosColetor,
                strSenhaColetor
                );

            Cursor.Current = Cursors.WaitCursor; // set the wait cursor
            //Do some work

            try
            {
                objImplementacaoBancoDados.mtdAbrirConexao();
                objImplementacaoBancoDados.mtdExecutarComando
                (
                string.Format
                (
                "SELECT DISTINCT {0}{1}, COUNT({1}) AS {2} FROM {3} GROUP BY {1} HAVING {4} ORDER BY {5}{6};",
                NumeroLinhas != 0 ? string.Format("TOP ({0}) ", NumeroLinhas) : string.Empty,
                Campo,
                CampoContador,
                NomeTabela,
                Selecao,
                CampoOrdenador,
                Crescente ? string.Empty : " DESC"
                )
                );

                objImplementacaoBancoDados.mtdAdaptadorDados();

                dtg.TableStyles.Clear();
                dtg.TableStyles.Add(mtdAjustarComprimentoColunasDtg(ref objImplementacaoBancoDados.objTabelaDados, objImplementacaoBancoDados.prpConexao, objImplementacaoBancoDados.prpComando, uintComprimentoColunas));

                dtg.DataSource = objImplementacaoBancoDados.prpTabelaDados;
                if (dtg.VisibleRowCount > 0)
                {
                    dtg.Select(dtg.VisibleRowCount - 1);
                }
            }
            catch (System.Exception ex)
            {
                dtg.DataSource = null;

                ntf1.Text = "Não foi possível preencher a tabela.";
                string strExcecao = "mtdPreencherDtg: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }

            Cursor.Current = Cursors.Default; //restore the old cursor

            objImplementacaoBancoDados.Dispose();
        }

        public void mtdAtualizarDtg1(string Coluna, string Filtro, uint NumeroLinhas)
        {
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                (
                clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                );

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                (
                clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                strBaseDadosColetor,
                strSenhaColetor
                );

            string strCadeiaCarecteres = "N'%{0}%'";
            objImplementacaoBancoDados.mtdSelecionarDados(0, vetCamposTabelaInventarioBens, strTabelaInventarioBens);
            objImplementacaoBancoDados.mtdDefinirLeitorDados();
            if (objImplementacaoBancoDados.mtdProximoRegistro())
            {
                try
                {
                    string strObterTipoRegistro = objImplementacaoBancoDados.mtdObterTipoRegistro(objImplementacaoBancoDados.mtdObterNumeroColuna(Coluna)).ToString();
                    switch (strObterTipoRegistro)
                    {
                        case "System.Byte[]":
                            strCadeiaCarecteres = "{0}";
                            break;
                        case "System.DateTime":
                            strCadeiaCarecteres = "{0}";
                            break;
                        case "System.Int64":
                            strCadeiaCarecteres = "'%{0}%'";
                            break;
                        case "System.String":
                            strCadeiaCarecteres = "N'%{0}%'";
                            break;
                    }
                }
                catch (System.Exception ex)
                {
                    strCadeiaCarecteres = "N'%{0}%'";

                    string strExcecao = "mtdAtualizarDtg1: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                    //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                }
            }

            if (cmbConsultarInventario.Text != vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensData_Inventario])
            {
                mtdPreencherDtg
                    (
                    ref dtg1,
                    NumeroLinhas,
                    vetCamposTabelaInventarioBens,
                    strTabelaInventarioBens,
                    Coluna,
                    "LIKE",
                    string.Format
                    (
                    strCadeiaCarecteres,
                    Filtro
                    ),
                    vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensNumero_Inventario],
                    false
                    );
            }
            else
            {
                mtdPreencherDtg
                    (
                    ref dtg1,
                    NumeroLinhas,
                    vetCamposTabelaInventarioBens,
                    strTabelaInventarioBens,
                    mtdConsultarData_Inventario(Coluna, Filtro),
                    vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensNumero_Inventario],
                    false
                    );
            }

            objImplementacaoBancoDados.Dispose();
        }

        public void mtdAtualizarDtg2(string Coluna, string Filtro, uint NumeroLinhas)
        {
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                (
                clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                );

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                (
                clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                strBaseDadosColetor,
                strSenhaColetor
                );

            string strCadeiaCarecteres = "N'%{0}%'";
            objImplementacaoBancoDados.mtdSelecionarDados(0, vetCamposTabelaBensEletronorte, strTabelaBensEletronorte);
            objImplementacaoBancoDados.mtdDefinirLeitorDados();
            if (objImplementacaoBancoDados.mtdProximoRegistro())
            {
                try
                {
                    string strObterTipoRegistro = objImplementacaoBancoDados.mtdObterTipoRegistro(objImplementacaoBancoDados.mtdObterNumeroColuna(Coluna)).ToString();
                    switch (strObterTipoRegistro)
                    {
                        case "System.Byte[]":
                            strCadeiaCarecteres = "{0}";
                            break;
                        case "System.DateTime":
                            strCadeiaCarecteres = "{0}";
                            break;
                        case "System.Int64":
                            strCadeiaCarecteres = "'%{0}%'";
                            break;
                        case "System.String":
                            strCadeiaCarecteres = "N'%{0}%'";
                            break;
                    }
                }
                catch (System.Exception ex)
                {
                    strCadeiaCarecteres = "N'%{0}%'";

                    string strExcecao = "mtdAtualizarDtg2: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                    //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                }
            }

            mtdPreencherDtg
                (
                ref dtg2,
                NumeroLinhas,
                vetCamposTabelaBensEletronorte,
                strTabelaBensEletronorte,
                Coluna,
                "LIKE",
                string.Format
                (
                strCadeiaCarecteres,
                Filtro
                ),
                vetCamposTabelaBensEletronorte[intColunaTabelaBensEletronortePatrimonio],
                true
                );

            objImplementacaoBancoDados.Dispose();
        }

        public void mtdAtualizarDtg3(string Coluna, string Filtro, uint NumeroLinhas)
        {
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                (
                clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                );

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                (
                clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                strBaseDadosColetor,
                strSenhaColetor
                );

            string strCadeiaCarecteres = "N'%{0}%'";
            objImplementacaoBancoDados.mtdSelecionarDados(0, vetCamposTabelaEmpregados, strTabelaEmpregados);
            objImplementacaoBancoDados.mtdDefinirLeitorDados();
            if (objImplementacaoBancoDados.mtdProximoRegistro())
            {
                try
                {
                    string strObterTipoRegistro = objImplementacaoBancoDados.mtdObterTipoRegistro(objImplementacaoBancoDados.mtdObterNumeroColuna(Coluna)).ToString();
                    switch (strObterTipoRegistro)
                    {
                        case "System.Byte[]":
                            strCadeiaCarecteres = "{0}";
                            break;
                        case "System.DateTime":
                            strCadeiaCarecteres = "{0}";
                            break;
                        case "System.Int64":
                            strCadeiaCarecteres = "'%{0}%'";
                            break;
                        case "System.String":
                            strCadeiaCarecteres = "N'%{0}%'";
                            break;
                    }
                }
                catch (System.Exception ex)
                {
                    strCadeiaCarecteres = "N'%{0}%'";

                    string strExcecao = "mtdAtualizarDtg3: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                    //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                }
            }

            mtdPreencherDtg
                (
                ref dtg3,
                NumeroLinhas,
                vetCamposTabelaEmpregados,
                strTabelaEmpregados,
                Coluna,
                "LIKE",
                string.Format
                (
                strCadeiaCarecteres,
                Filtro
                ),
                vetCamposTabelaEmpregados[intColunaTabelaEmpregadosNome],
                true
                );

            objImplementacaoBancoDados.Dispose();
        }

        public void mtdAtualizarDtg4(string Coluna, string Filtro, uint NumeroLinhas)
        {
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                (
                clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                );

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                (
                clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                strBaseDadosColetor,
                strSenhaColetor
                );

            string strCadeiaCarecteres = "N'%{0}%'";
            objImplementacaoBancoDados.mtdSelecionarDados(0, vetCamposTabelaCentroCusto, strTabelaCentroCusto);
            objImplementacaoBancoDados.mtdDefinirLeitorDados();
            if (objImplementacaoBancoDados.mtdProximoRegistro())
            {
                try
                {
                    string strObterTipoRegistro = objImplementacaoBancoDados.mtdObterTipoRegistro(objImplementacaoBancoDados.mtdObterNumeroColuna(Coluna)).ToString();
                    switch (strObterTipoRegistro)
                    {
                        case "System.Byte[]":
                            strCadeiaCarecteres = "{0}";
                            break;
                        case "System.DateTime":
                            strCadeiaCarecteres = "{0}";
                            break;
                        case "System.Int64":
                            strCadeiaCarecteres = "'%{0}%'";
                            break;
                        case "System.String":
                            strCadeiaCarecteres = "N'%{0}%'";
                            break;
                    }
                }
                catch (System.Exception ex)
                {
                    strCadeiaCarecteres = "N'%{0}%'";

                    string strExcecao = "mtdAtualizarDtg4: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                    //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                }
            }

            mtdPreencherDtg
                (
                ref dtg4,
                NumeroLinhas,
                vetCamposTabelaCentroCusto,
                strTabelaCentroCusto,
                Coluna,
                "LIKE",
                string.Format
                (
                strCadeiaCarecteres,
                Filtro
                ),
                vetCamposTabelaCentroCusto[intColunaTabelaCentroCustoCentroCusto],
                true
                );

            objImplementacaoBancoDados.Dispose();
        }

        public void mtdAtualizarDtg5(string NomeTabela, string Campo, string Filtro, uint NumeroLinhas)
        {
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                (
                clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                );

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                (
                clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                strBaseDadosColetor,
                strSenhaColetor
                );

            string strCadeiaCarecteres = "N'%{0}%'";
            objImplementacaoBancoDados.mtdSelecionarDados(0, "*", NomeTabela);
            objImplementacaoBancoDados.mtdDefinirLeitorDados();
            if (objImplementacaoBancoDados.mtdProximoRegistro())
            {
                try
                {
                    string strObterTipoRegistro = objImplementacaoBancoDados.mtdObterTipoRegistro(objImplementacaoBancoDados.mtdObterNumeroColuna(Campo)).ToString();
                    switch (strObterTipoRegistro)
                    {
                        case "System.Byte[]":
                            strCadeiaCarecteres = "{0}";
                            break;
                        case "System.DateTime":
                            strCadeiaCarecteres = "{0}";
                            break;
                        case "System.Int64":
                            strCadeiaCarecteres = "'%{0}%'";
                            break;
                        case "System.String":
                            strCadeiaCarecteres = "N'%{0}%'";
                            break;
                    }
                }
                catch (System.Exception ex)
                {
                    strCadeiaCarecteres = "N'%{0}%'";

                    string strExcecao = "mtdAtualizarDtg5: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                    //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                }
            }

            mtdPreencherDtg
                (
                ref dtg5,
                NumeroLinhas,
                Campo,
                NomeTabela,
                cmbConsultarCamposRelatorio.Text != vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensData_Inventario]
                ?
                string.Format("{0} LIKE {1}", Campo, string.Format(strCadeiaCarecteres, Filtro))
                :
                mtdConsultarData_Inventario(Campo, Filtro),
                Campo,
                true
                );

            objImplementacaoBancoDados.Dispose();
        }

        public string mtdConsultarData_Inventario(string Campo, string Data)
        {
            string saida = string.Empty;

            try
            {
                System.Globalization.CultureInfo[] cultures =
                    { 
                        System.Globalization.CultureInfo.CreateSpecificCulture("en-US"),
                        System.Globalization.CultureInfo.CreateSpecificCulture("pt-BR")
                    };

                string[] formats = 
                {
                    "d",
                    "D",
                    "f",
                    "F", 
                    "g",
                    "G", 
                    "m",
                    "o",
                    "r",
                    "s", 
                    "t",
                    "T",
                    "u",
                    "U",
                    "Y",
                    "MM-dd-yyyy hh:mm:ss tt",
                    "MM-dd-yyyy hh:mm:ss"
                };

                System.DateTime dtDataInicial = System.Convert.ToDateTime(Data, cultures[1]);
                System.DateTime dtDataFinal = System.Convert.ToDateTime(Data, cultures[1]).AddDays(1);

                string DataInicial = dtDataInicial.ToString(formats[15], cultures[0]).Replace('/', '-');
                string DataFinal = dtDataFinal.ToString(formats[15], cultures[0]).Replace('/', '-');

                saida = string.Format
                    (
                    "({0} >= CONVERT(DATETIME, '{1}', 102)) AND ({0} < CONVERT(DATETIME, '{2}', 102))",
                    Campo,
                    DataInicial,
                    DataFinal
                    );
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdCriarBancoDadosColetor: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }

            return saida;
        }

        public void mtdConsultarInventario()
        {
            mtdAtualizarDtg1(cmbConsultarInventario.Text, txtConsultarInventario.Text, 0);
        }

        public void mtdConsultarSAP()
        {
            mtdConsultarSAP(0);
        }

        public void mtdConsultarEmpregados()
        {
            mtdConsultarEmpregados(0);
        }

        public void mtdConsultarCentroCusto()
        {
            mtdConsultarCentroCusto(0);
        }

        public void mtdConsultarRelatorio()
        {
            mtdConsultarRelatorio(0);
        }

        public void mtdCarregarRelatoriosExtra()
        {
            mtdCarregarRelatoriosExtra(0);
        }

        public void mtdConsultarInventario(uint uintNumeroLinhas)
        {
            mtdAtualizarDtg1(cmbConsultarInventario.Text, txtConsultarInventario.Text, uintNumeroLinhas);
        }

        public void mtdConsultarSAP(uint uintNumeroLinhas)
        {
            mtdAtualizarDtg2(cmbConsultarSAP.Text, txtConsultarSAP.Text, uintNumeroLinhas);
        }

        public void mtdConsultarEmpregados(uint uintNumeroLinhas)
        {
            mtdAtualizarDtg3(cmbConsultarEmpregados.Text, txtConsultarEmpregados.Text, uintNumeroLinhas);
        }

        public void mtdConsultarCentroCusto(uint uintNumeroLinhas)
        {
            mtdAtualizarDtg4(cmbConsultarCentroCusto.Text, txtConsultarCentroCusto.Text, uintNumeroLinhas);
        }

        public void mtdConsultarRelatorio(uint uintNumeroLinhas)
        {
            mtdAtualizarDtg5
                (
                string.Format("tbl{0}", cmbConsultarTabelaRelatorio.Text),
                cmbConsultarCamposRelatorio.Text,
                txtTabelaRelatorioFiltro.Text,
                uintNumeroLinhas
                );
        }

        private static object LockCarregarRelatoriosExtra = new object();

        private void mtdCarregarRelatoriosExtra(uint uintNumeroLinhas)
        {
            lock (LockCarregarRelatoriosExtra)
            {
                Cursor.Current = Cursors.WaitCursor; // set the wait cursor
                //Do some work

                clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                 (
                 clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                 );

                objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                    (
                    clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                    strBaseDadosColetor,
                    strSenhaColetor
                    );

                objImplementacaoBancoDados.mtdSelecionarDados(uintNumeroLinhas, vetCamposTabelaInventarioBens, strTabelaInventarioBens);
                txtTabelaInventarioBensLinhas.Text = objImplementacaoBancoDados.mtdNumeroLinhas().ToString();
                objImplementacaoBancoDados.mtdDefinirLeitorDados();
                txtTabelaInventarioBensColunas.Text = objImplementacaoBancoDados.mtdNumeroColunas().ToString();

                objImplementacaoBancoDados.mtdSelecionarDados(uintNumeroLinhas, vetCamposTabelaBensEletronorte, strTabelaBensEletronorte);
                txtTabelaSAPLinhas.Text = objImplementacaoBancoDados.mtdNumeroLinhas().ToString();
                objImplementacaoBancoDados.mtdDefinirLeitorDados();
                txtTabelaSAPColunas.Text = objImplementacaoBancoDados.mtdNumeroColunas().ToString();

                objImplementacaoBancoDados.mtdSelecionarDados(uintNumeroLinhas, vetCamposTabelaEmpregados, strTabelaEmpregados);
                txtTabelaEmpregadosLinhas.Text = objImplementacaoBancoDados.mtdNumeroLinhas().ToString();
                objImplementacaoBancoDados.mtdDefinirLeitorDados();
                txtTabelaEmpregadosColunas.Text = objImplementacaoBancoDados.mtdNumeroColunas().ToString();

                objImplementacaoBancoDados.mtdSelecionarDados(uintNumeroLinhas, vetCamposTabelaCentroCusto, strTabelaCentroCusto);
                txtTabelaCentroCustoLinhas.Text = objImplementacaoBancoDados.mtdNumeroLinhas().ToString();
                objImplementacaoBancoDados.mtdDefinirLeitorDados();
                txtTabelaCentroCustoColunas.Text = objImplementacaoBancoDados.mtdNumeroColunas().ToString();

                Cursor.Current = Cursors.Default; //restore the old cursor
            }
        }

        private bool blnValidarAlterarDeletarRegistro = false;

        private void mtdAlterarDeletar(string NumeroInventario)
        {
            int result = frmAlterarDeletarItem.ShowBox(NumeroInventario);

            this.Show();

            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                (
                clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                );

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                (
                clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                strBaseDadosColetor,
                strSenhaColetor
                );

            try
            {
                Cursor.Current = Cursors.WaitCursor; // set the wait cursor
                //Do some work

                if (result != 3)
                {
                    string strDado = string.Empty;
                    if (frmAlterarDeletarItem.vetNumeroInventario.GetLength(0) > 1)
                    {
                        if (frmAlterarDeletarItem.Modo == "Alterar")
                        {
                            bool[] vetValidarAlterarDeletarRegistro = new bool[13];

                            vetValidarAlterarDeletarRegistro[0] = btnTRGItemL.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0));
                            vetValidarAlterarDeletarRegistro[1] = btnCentroCustoItemL.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0));
                            vetValidarAlterarDeletarRegistro[2] = btnOrgaoItemL.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0));
                            vetValidarAlterarDeletarRegistro[3] = btnSalaItemL.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0));
                            vetValidarAlterarDeletarRegistro[4] = btnNomeItemL.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0));
                            vetValidarAlterarDeletarRegistro[5] = btnMatriculaItemL.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0));
                            vetValidarAlterarDeletarRegistro[6] = btnPatrimonioItemL.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192));
                            vetValidarAlterarDeletarRegistro[7] = btnDenominacaoItemL.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192));
                            vetValidarAlterarDeletarRegistro[8] = btnNSerieItemL.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192));
                            vetValidarAlterarDeletarRegistro[9] = btnPlacaVeiculoItemL.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192));
                            vetValidarAlterarDeletarRegistro[10] = btnIdentificacaoItemL.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192));
                            vetValidarAlterarDeletarRegistro[11] = btnOutrosDadosItemL.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192));
                            vetValidarAlterarDeletarRegistro[12] = btnObservacaoItemL.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192));

                            blnValidarAlterarDeletarRegistro = false;

                            for (int coluna = vetValidarAlterarDeletarRegistro.GetLowerBound(0); coluna <= vetValidarAlterarDeletarRegistro.GetUpperBound(0); coluna++)
                            {
                                if (vetValidarAlterarDeletarRegistro[coluna])
                                {
                                    blnValidarAlterarDeletarRegistro = true;
                                    break;
                                }
                                else
                                {
                                    blnValidarAlterarDeletarRegistro = false;
                                }
                            }
                        }
                        else
                        {
                            blnValidarAlterarDeletarRegistro = true;
                        }

                        bool blnAcaoValida = true;

                        if (blnValidarAlterarDeletarRegistro)
                        {
                            if (frmAlterarDeletarItem.Modo == "Alterar")
                            {
                                for
                                    (
                                    int contador = frmAlterarDeletarItem.vetNumeroInventario.GetLowerBound(0);
                                    contador <= frmAlterarDeletarItem.vetNumeroInventario.GetUpperBound(0);
                                    contador++
                                    )
                                {
                                    strDado = frmAlterarDeletarItem.vetNumeroInventario[contador];
                                    if (!strDado.Equals(string.Empty))
                                    {
                                        blnAcaoValida &= mtdAtualizarLista(strDado);
                                    }
                                }
                                if (blnAcaoValida)
                                {
                                    System.Windows.Forms.MessageBox.Show
                                        (
                                        "Os Itens foram alterados.",
                                        "Aviso!", System.Windows.Forms.MessageBoxButtons.OK,
                                        System.Windows.Forms.MessageBoxIcon.Exclamation,
                                        System.Windows.Forms.MessageBoxDefaultButton.Button1
                                        );
                                }
                                else
                                {
                                    System.Windows.Forms.MessageBox.Show
                                        (
                                        "Ocorreu pelo menos um erro, ao alterar os itens.",
                                        "Aviso!", System.Windows.Forms.MessageBoxButtons.OK,
                                        System.Windows.Forms.MessageBoxIcon.Exclamation,
                                        System.Windows.Forms.MessageBoxDefaultButton.Button1
                                        );
                                }
                            }
                            else
                            {
                                for
                                    (
                                    int contador = frmAlterarDeletarItem.vetNumeroInventario.GetLowerBound(0);
                                    contador <= frmAlterarDeletarItem.vetNumeroInventario.GetUpperBound(0);
                                    contador++
                                    )
                                {
                                    strDado = frmAlterarDeletarItem.vetNumeroInventario[contador];
                                    if (!strDado.Equals(string.Empty))
                                    {
                                        blnAcaoValida &= mtdDeletarDadosTabelaInventarioBens(strDado);
                                    }
                                }
                                if (blnAcaoValida)
                                {
                                    System.Windows.Forms.MessageBox.Show
                                        (
                                        "Os Itens foram deletados.",
                                        "Aviso!", System.Windows.Forms.MessageBoxButtons.OK,
                                        System.Windows.Forms.MessageBoxIcon.Exclamation,
                                        System.Windows.Forms.MessageBoxDefaultButton.Button1
                                        );
                                }
                                else
                                {
                                    System.Windows.Forms.MessageBox.Show
                                        (
                                        "Ocorreu pelo menos um erro, ao deletar os itens.",
                                        "Aviso!", System.Windows.Forms.MessageBoxButtons.OK,
                                        System.Windows.Forms.MessageBoxIcon.Exclamation,
                                        System.Windows.Forms.MessageBoxDefaultButton.Button1
                                        );
                                }
                            }
                        }
                    }
                    else
                    {
                        strDado = frmAlterarDeletarItem.vetNumeroInventario[0];
                        if (!strDado.Equals(string.Empty))
                        {
                            if (frmAlterarDeletarItem.Modo == "Alterar")
                            {
                                if (mtdAtualizar())
                                {
                                    System.Windows.Forms.MessageBox.Show
                                        (
                                        "O item foi alterado.",
                                        "Aviso!", System.Windows.Forms.MessageBoxButtons.OK,
                                        System.Windows.Forms.MessageBoxIcon.Exclamation,
                                        System.Windows.Forms.MessageBoxDefaultButton.Button1
                                        );
                                }
                                else
                                {
                                    System.Windows.Forms.MessageBox.Show
                                        (
                                        "O item não foi alterado.",
                                        "Aviso!", System.Windows.Forms.MessageBoxButtons.OK,
                                        System.Windows.Forms.MessageBoxIcon.Exclamation,
                                        System.Windows.Forms.MessageBoxDefaultButton.Button1
                                        );
                                }
                            }
                            else
                            {
                                if (mtdDeletarDadosTabelaInventarioBens(strDado))
                                {
                                    System.Windows.Forms.MessageBox.Show
                                        (
                                        "O item foi deletado.",
                                        "Aviso!", System.Windows.Forms.MessageBoxButtons.OK,
                                        System.Windows.Forms.MessageBoxIcon.Exclamation,
                                        System.Windows.Forms.MessageBoxDefaultButton.Button1
                                        );
                                }
                                else
                                {
                                    System.Windows.Forms.MessageBox.Show
                                        (
                                        "O item não foi deletado.",
                                        "Aviso!", System.Windows.Forms.MessageBoxButtons.OK,
                                        System.Windows.Forms.MessageBoxIcon.Exclamation,
                                        System.Windows.Forms.MessageBoxDefaultButton.Button1
                                        );
                                }
                            }
                        }
                    }
                    mtdAtualizarDtg1(cmbConsultarInventario.Text, txtConsultarInventario.Text, uintNumeroLinhas);
                }
                else
                {
                    if (frmAlterarDeletarItem.Modo == "Alterar")
                    {
                        System.Windows.Forms.MessageBox.Show
                            (
                            "Não houve dados alterados.",
                            "Aviso!", System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Exclamation,
                            System.Windows.Forms.MessageBoxDefaultButton.Button1
                            );
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show
                            (
                            "Não houve dados deletados.",
                            "Aviso!", System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Exclamation,
                            System.Windows.Forms.MessageBoxDefaultButton.Button1
                            );
                    }
                }
            }
            catch (System.Exception ex)
            {
                if (frmAlterarDeletarItem.Modo == "Alterar")
                {
                    System.Windows.Forms.MessageBox.Show
                        (
                        "Não houve dados alterados.",
                        "Aviso!", System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Exclamation,
                        System.Windows.Forms.MessageBoxDefaultButton.Button1
                        );
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show
                        (
                        "Não houve dados deletados.",
                        "Aviso!", System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Exclamation,
                        System.Windows.Forms.MessageBoxDefaultButton.Button1
                        );
                }
                string strExcecao = "mtdAlterarDeletar: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
            finally
            {
                Cursor.Current = Cursors.Default; //restore the old cursor
            }

            objImplementacaoBancoDados.Dispose();
        }

        private void mtdAlterar(string Dado)
        {
            mtdAtualizarLista(Dado);
        }

        private void mtdDeletar(string Dado)
        {
            mtdDeletarDadosTabelaInventarioBens(Dado);
        }

        private int intIntervaloPressionamentoBotaoEnter = 4000;
        private double dblTempoPressionamentoBotaoEnter = DateTime.Now.TimeOfDay.TotalMilliseconds;

        private void dtg1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Delete)
            {
                bool blnModoOtimizadoCadastro = chkModoOtimizadoCadastro.Checked;
                chkModoOtimizadoCadastro.Checked = false;
                try
                {
                    if (dtg1.CurrentCell.RowNumber > -1 & dtg1.CurrentCell.ColumnNumber > -1)
                    {
                        if
                            (
                            System.Windows.Forms.MessageBox.Show
                            (
                            "Deseja realmente deletar o registro selecionado?",
                            "Aviso!", System.Windows.Forms.MessageBoxButtons.YesNo,
                            System.Windows.Forms.MessageBoxIcon.Exclamation,
                            System.Windows.Forms.MessageBoxDefaultButton.Button2
                            )
                            ==
                            System.Windows.Forms.DialogResult.Yes
                            )
                        {
                            mtdDeletar(dtg1[dtg1.CurrentCell.RowNumber, intColunaTabelaInventarioBensNumero_Inventario].ToString());
                            System.Windows.Forms.MessageBox.Show
                                (
                                "O item foi deletado.",
                                "Aviso!", System.Windows.Forms.MessageBoxButtons.OK,
                                System.Windows.Forms.MessageBoxIcon.Exclamation,
                                System.Windows.Forms.MessageBoxDefaultButton.Button1
                                );
                            mtdAtualizarDtg1(vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensNumero_Inventario], string.Empty, uintNumeroLinhas);
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show
                                (
                                "Não houve dados deletados.",
                                "Aviso!", System.Windows.Forms.MessageBoxButtons.OK,
                                System.Windows.Forms.MessageBoxIcon.Exclamation,
                                System.Windows.Forms.MessageBoxDefaultButton.Button1
                                );
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    mtdDeletar(string.Empty);
                    string strExcecao = "dtg1_KeyDown: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                    //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                }
                chkModoOtimizadoCadastro.Checked = blnModoOtimizadoCadastro;
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Up
                //mtdCarregarDtgv1();
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Down
                //mtdCarregarDtgv1();
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                // Left
                //mtdCarregarDtgv1();
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                // Right
                //mtdCarregarDtgv1();
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                // Enter
                mtdCarregarCaixaDtgv1(System.Convert.ToInt64(dtg1[dtg1.CurrentRowIndex, 0]));

                double dblDiferencaTempoPressionamentoBotaoEnter = System.DateTime.Now.TimeOfDay.TotalMilliseconds - dblTempoPressionamentoBotaoEnter;
                if (dblDiferencaTempoPressionamentoBotaoEnter >= 250 & dblDiferencaTempoPressionamentoBotaoEnter <= intIntervaloPressionamentoBotaoEnter)
                {
                    mtdVisualizarAlterarItemControlado();
                }

                dblTempoPressionamentoBotaoEnter = DateTime.Now.TimeOfDay.TotalMilliseconds;
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Return))
            {
                // Return
                mtdCarregarCaixaDtgv1(System.Convert.ToInt64(dtg1[dtg1.CurrentRowIndex, 0]));
            }
        }

        private void dtg2_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Up
                mtdCarregarCaixaDtgv2();
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Down
                mtdCarregarCaixaDtgv2();
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                // Left
                mtdCarregarCaixaDtgv2();
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                // Right
                mtdCarregarCaixaDtgv2();
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                // Enter
                //mtdCarregarDtgv2();
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Return))
            {
                // Return
                //mtdCarregarDtgv2();
            }
        }

        private void dtg3_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Up
                mtdCarregarCaixaDtgv3();
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Down
                mtdCarregarCaixaDtgv3();
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                // Left
                mtdCarregarCaixaDtgv3();
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                // Right
                mtdCarregarCaixaDtgv3();
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                // Enter
                //mtdCarregarDtgv3();
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Return))
            {
                // Return
                //mtdCarregarDtgv3();
            }
        }

        private void dtg4_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Up
                mtdCarregarCaixaDtgv4();
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Down
                mtdCarregarCaixaDtgv4();
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                // Left
                mtdCarregarCaixaDtgv4();
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                // Right
                mtdCarregarCaixaDtgv4();
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                // Enter
                //mtdCarregarDtgv4();
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Return))
            {
                // Return
                //mtdCarregarDtgv4();
            }
        }

        private void dtg5_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Up
                mtdCarregarDtgv5();
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Down
                mtdCarregarDtgv5();
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                // Left
                mtdCarregarDtgv5();
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                // Right
                mtdCarregarDtgv5();
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                // Enter
                //mtdCarregarDtgv5();
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Return))
            {
                // Return
                //mtdCarregarDtgv5();
            }
        }

        private void mtdComandoAlterarDeletar()
        {
            bool blnModoOtimizadoCadastro = chkModoOtimizadoCadastro.Checked;
            chkModoOtimizadoCadastro.Checked = false;
            try
            {
                if (dtg1.CurrentCell.RowNumber > -1 & dtg1.CurrentCell.ColumnNumber > -1)
                {
                    mtdAlterarDeletar(dtg1[dtg1.CurrentCell.RowNumber, intColunaTabelaInventarioBensNumero_Inventario].ToString());
                }
            }
            catch (System.Exception ex)
            {
                mtdAlterarDeletar(string.Empty);
                string strExcecao = "mtdComandoAlterarDeletar: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }

            btnPatrimonioItemL.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            btnDenominacaoItemL.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            btnNSerieItemL.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            btnPlacaVeiculoItemL.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            btnIdentificacaoItemL.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            btnOutrosDadosItemL.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            btnObservacaoItemL.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            btnControleFisicoSelecionarButoesL.BackColor = System.Drawing.Color.FromArgb(255, 192, 192);
            btnTRGItemL.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            btnCentroCustoItemL.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            btnOrgaoItemL.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            btnSalaItemL.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            btnNomeItemL.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            btnMatriculaItemL.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            btnTirarFotografiaL.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);

            chkModoOtimizadoCadastro.Checked = blnModoOtimizadoCadastro;
        }

        private int intIntervaloPressionamentoBotaoLeitorCodigoBarra = 4000;

        private void mtdPatrimonioItem_KeyPress()
        {
            dblDiferencaTempoPressionamentoBotaoLeitorCodigoBarra = System.DateTime.Now.TimeOfDay.TotalMilliseconds - dblTempoPressionamentoBotaoLeitorCodigoBarra;
            if (dblDiferencaTempoPressionamentoBotaoLeitorCodigoBarra <= intIntervaloPressionamentoBotaoLeitorCodigoBarra)
            {
                if (btnModoCadastroInventario.Text.Equals("Modo &Inventário"))
                {
                    if (!chkModoOtimizadoCadastro.Checked)
                    {
                        mtdProcurar();
                        cmbObservacaoItem.Text = btnObservacaoItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192)) ?
                            cmbObservacaoItem.Items[8].ToString() :
                            cmbObservacaoItem.Text;
                    }
                    else
                    {
                        cmbObservacaoItem.Text = btnObservacaoItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192)) ?
                            cmbObservacaoItem.Items[8].ToString() :
                            cmbObservacaoItem.Text;
                        mtdCadastrar();
                        mtdAtualizarDtg1(vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensNumero_Inventario], string.Empty, 1);
                        //mtdConsultarItensRepetidosCampoInformado(vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensN_Serie], vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensIdentificacao_Inventario]);
                    }
                }
                else
                {
                    cmbObservacaoItem.Text = btnObservacaoItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192)) ?
                        cmbObservacaoItem.Items[intColunaTabelaInventarioBensNumero_Inventario].ToString() :
                        cmbObservacaoItem.Text;
                }
            }
            else
            {
                if (btnModoCadastroInventario.Text.Equals("Modo &Inventário"))
                {
                    if (!chkModoOtimizadoCadastro.Checked)
                    {
                        mtdProcurar();
                        cmbObservacaoItem.Text = btnObservacaoItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192)) ?
                            cmbObservacaoItem.Items[13].ToString() :
                            cmbObservacaoItem.Text;
                    }
                    else
                    {
                        cmbObservacaoItem.Text = btnObservacaoItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192)) ?
                            cmbObservacaoItem.Items[13].ToString() :
                            cmbObservacaoItem.Text;
                        mtdCadastrar();
                        mtdAtualizarDtg1(vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensNumero_Inventario], string.Empty, 1);
                        //mtdConsultarItensRepetidosCampoInformado(vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensN_Serie], vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensIdentificacao_Inventario]);
                    }
                }
                else
                {
                    cmbObservacaoItem.Text = btnObservacaoItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192)) ?
                        cmbObservacaoItem.Items[intColunaTabelaInventarioBensNumero_Inventario].ToString() :
                        cmbObservacaoItem.Text;
                }
            }
        }

        private void mtdDenominacaoItem_KeyPress()
        {
            if (btnModoCadastroInventario.Text.Equals("Modo &Inventário"))
            {
                if (!chkModoOtimizadoCadastro.Checked)
                {
                    mtdProcurar();
                }
            }
        }

        private void mtdNSerieItem_KeyPress()
        {
            if (btnModoCadastroInventario.Text.Equals("Modo &Inventário"))
            {
                if (!chkModoOtimizadoCadastro.Checked)
                {
                    mtdProcurar();
                }
            }
        }

        private void mtdPlacaVeiculoItem_KeyPress()
        {
            if (btnModoCadastroInventario.Text.Equals("Modo &Inventário"))
            {
                if (!chkModoOtimizadoCadastro.Checked)
                {
                    mtdProcurar();
                }
            }
        }

        private void mtdUsuarioInventarioMatriculaInventario_KeyPress(string CampoSelecionador, string DadoSelecionador, string CampoOrdenador, ref string UsuarioInventario, ref string MatriculaInventario)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor; // set the wait cursor
                //Do some work
                clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                    (
                    clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                    );

                objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                    (
                    clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                    strBaseDadosColetor,
                    strSenhaColetor
                    );

                objImplementacaoBancoDados.mtdSelecionarDados
                    (
                    vetCamposTabelaEmpregados,
                    strTabelaEmpregados,
                    string.Format
                    (
                    "{0}",
                    CampoSelecionador
                    ),
                    "LIKE",
                    string.Format
                    (
                    "N'%{0}%'",
                    DadoSelecionador
                    ),
                    string.Format
                    (
                    "{0}",
                    CampoOrdenador
                    ),
                    true
                    );

                objImplementacaoBancoDados.mtdDefinirLeitorDados();
                if (objImplementacaoBancoDados.mtdProximoRegistro())
                {
                    UsuarioInventario = objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaEmpregadosNome).ToString();
                    MatriculaInventario = objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaEmpregadosMatricula).ToString();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show
                        (
                        "O nome informado não foi encontrado.",
                        "Aviso!", System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Exclamation,
                        System.Windows.Forms.MessageBoxDefaultButton.Button1
                        );
                }

                objImplementacaoBancoDados.Dispose();
            }
            finally
            {
                Cursor.Current = Cursors.Default; //restore the old cursor
            }
        }

        private void mtdNomeItemMatriculaItemOrgaoItemSalaItemCentroCustoItem_KeyPress(string DadoSelecionador, ref string NomeItem, ref string MatriculaItem, ref string CentroCustoItem, ref string OrgaoItem, ref string SalaItem)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor; // set the wait cursor
                //Do some work
                clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                    (
                    clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                    );

                objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                    (
                    clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                    strBaseDadosColetor,
                    strSenhaColetor
                    );

                objImplementacaoBancoDados.mtdAbrirConexao();
                objImplementacaoBancoDados.mtdExecutarComando
                    (
                    string.Format
                    (
                    "SELECT {0} FROM {1} WHERE {2} ORDER BY {3};",
                    objImplementacaoBancoDados.mtdVetorLinhaCampos(vetCamposTabelaEmpregados),
                    strTabelaEmpregados,
                    string.Format
                    (
                    "{0} LIKE {2} AND ({1} LIKE {3} OR {1} LIKE {4} OR {1} LIKE {5} OR {1} LIKE {6})",
                    vetCamposTabelaEmpregados[2],
                    vetCamposTabelaEmpregados[8],
                    string.Format
                    (
                    "N'%{0}%'",
                    DadoSelecionador
                    ),
                    "N'%Assistente de Diretor%'",
                    "N'%Superintendente%'",
                    "N'%Gerente%'",
                    "N'%'"
                    ),
                    string.Format
                    (
                    "{0}{1}",
                    vetCamposTabelaEmpregados[intColunaTabelaEmpregadosOrgao],
                    string.Empty
                    )
                    )
                    );
                objImplementacaoBancoDados.mtdDefinirLeitorDados();
                if (objImplementacaoBancoDados.mtdProximoRegistro())
                {
                    NomeItem = btnNomeItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)) ? objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaEmpregadosNome).ToString() : NomeItem;
                    MatriculaItem = btnMatriculaItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)) ? objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaEmpregadosMatricula).ToString() : MatriculaItem;
                    OrgaoItem = btnOrgaoItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)) ? objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaEmpregadosOrgao).ToString() : OrgaoItem;
                    SalaItem = btnSalaItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)) ? objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaEmpregadosEndereco).ToString() : SalaItem;

                    objImplementacaoBancoDados.mtdSelecionarDados
                        (
                        vetCamposTabelaCentroCusto,
                        strTabelaCentroCusto,
                        string.Format
                        (
                        "{0}",
                        vetCamposTabelaCentroCusto[intColunaTabelaCentroCustoOrgao]
                        ),
                        "LIKE",
                        string.Format
                        (
                        "N'%{0}%'",
                        objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaCentroCustoOrgaoDescricao).ToString()
                        ),
                        string.Format
                        (
                        "{0}",
                        vetCamposTabelaCentroCusto[intColunaTabelaCentroCustoCentroCusto]
                        ),
                        false
                        );

                    objImplementacaoBancoDados.mtdDefinirLeitorDados();
                    if (objImplementacaoBancoDados.mtdProximoRegistro())
                    {
                        CentroCustoItem = btnCentroCustoItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)) ?
                            objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaCentroCustoCentroCusto).ToString() :
                            CentroCustoItem;
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show
                            (
                            "Não foi possível encontrar centro de custo.",
                            "Aviso!", System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Exclamation,
                            System.Windows.Forms.MessageBoxDefaultButton.Button1
                            );
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show
                        (
                        "Não foi possível encontrar o dado informado.",
                        "Aviso!", System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Exclamation,
                        System.Windows.Forms.MessageBoxDefaultButton.Button1
                        );
                }

                objImplementacaoBancoDados.Dispose();
            }
            finally
            {
                Cursor.Current = Cursors.Default; //restore the old cursor
            }
        }

        private void mtdNomeItemMatriculaItemOrgaoItemSalaItemCentroCustoItem_KeyPress(string CampoSelecionador, string DadoSelecionador, string CampoOrdenador, ref string NomeItem, ref string MatriculaItem, ref string CentroCustoItem, ref string OrgaoItem, ref string SalaItem)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor; // set the wait cursor
                //Do some work
                clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                    (
                    clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                    );

                objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                    (
                    clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                    strBaseDadosColetor,
                    strSenhaColetor
                    );

                objImplementacaoBancoDados.mtdSelecionarDados
                    (
                    vetCamposTabelaEmpregados,
                    strTabelaEmpregados,
                    string.Format
                    (
                    "{0}",
                    CampoSelecionador
                    ),
                    "LIKE",
                    string.Format
                    (
                    "N'%{0}%'",
                    DadoSelecionador
                    ),
                    string.Format
                    (
                    "{0}",
                    CampoOrdenador
                    ),
                    true
                    );

                objImplementacaoBancoDados.mtdDefinirLeitorDados();
                if (objImplementacaoBancoDados.mtdProximoRegistro())
                {
                    NomeItem = btnNomeItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)) ? objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaEmpregadosNome).ToString() : NomeItem;
                    MatriculaItem = btnMatriculaItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)) ? objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaEmpregadosMatricula).ToString() : MatriculaItem;
                    OrgaoItem = btnOrgaoItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)) ? objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaEmpregadosOrgao).ToString() : OrgaoItem;
                    SalaItem = btnSalaItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)) ? objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaEmpregadosEndereco).ToString() : SalaItem;

                    objImplementacaoBancoDados.mtdSelecionarDados
                        (
                        vetCamposTabelaCentroCusto,
                        strTabelaCentroCusto,
                        string.Format
                        (
                        "{0}",
                        vetCamposTabelaCentroCusto[intColunaTabelaCentroCustoOrgao]
                        ),
                        "LIKE",
                        string.Format
                        (
                        "N'%{0}%'",
                        objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaCentroCustoOrgaoDescricao).ToString()
                        ),
                        string.Format
                        (
                        "{0}",
                        vetCamposTabelaCentroCusto[intColunaTabelaCentroCustoCentroCusto]
                        ),
                        false
                        );

                    objImplementacaoBancoDados.mtdDefinirLeitorDados();
                    if (objImplementacaoBancoDados.mtdProximoRegistro())
                    {
                        CentroCustoItem = btnCentroCustoItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)) ?
                            objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaCentroCustoCentroCusto).ToString() :
                            CentroCustoItem;
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show
                            (
                            "Não foi possível encontrar centro de custo.",
                            "Aviso!", System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Exclamation,
                            System.Windows.Forms.MessageBoxDefaultButton.Button1
                            );
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show
                        (
                        "Não foi possível encontrar o dado informado.",
                        "Aviso!", System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Exclamation,
                        System.Windows.Forms.MessageBoxDefaultButton.Button1
                        );
                }

                objImplementacaoBancoDados.Dispose();
            }
            finally
            {
                Cursor.Current = Cursors.Default; //restore the old cursor
            }
        }

        private void mtdCentroCustoItemNomeItemMatriculaItemOrgaoItemSalaItem_KeyPress(string DadoSelecionador, ref string NomeItem, ref string MatriculaItem, ref string CentroCustoItem, ref string OrgaoItem, ref string SalaItem)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor; // set the wait cursor
                //Do some work
                clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                    (
                    clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                    );

                objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                    (
                    clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                    strBaseDadosColetor,
                    strSenhaColetor
                    );

                objImplementacaoBancoDados.mtdSelecionarDados
                    (
                    vetCamposTabelaCentroCusto,
                    strTabelaCentroCusto,
                    string.Format
                    (
                    "{0}",
                    vetCamposTabelaCentroCusto[intColunaTabelaCentroCustoCentroCusto]
                    ),
                    "LIKE",
                    string.Format
                    (
                    "N'%{0}%'",
                    DadoSelecionador
                    ),
                    string.Format
                    (
                    "{0}",
                    vetCamposTabelaCentroCusto[intColunaTabelaCentroCustoOrgao]
                    ),
                    true
                    );

                objImplementacaoBancoDados.mtdDefinirLeitorDados();
                if (objImplementacaoBancoDados.mtdProximoRegistro())
                {
                    CentroCustoItem = btnCentroCustoItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)) ?
                        objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaCentroCustoCentroCusto).ToString() :
                        CentroCustoItem;
                    string txtOrgao = objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaCentroCustoOrgao).ToString();

                    objImplementacaoBancoDados.mtdAbrirConexao();
                    objImplementacaoBancoDados.mtdExecutarComando
                        (
                        string.Format
                        (
                        "SELECT {0} FROM {1} WHERE {2} ORDER BY {3};",
                        objImplementacaoBancoDados.mtdVetorLinhaCampos(vetCamposTabelaEmpregados),
                        strTabelaEmpregados,
                        string.Format
                        (
                        "{0} LIKE {2} AND ({1} LIKE {3} OR {1} LIKE {4} OR {1} LIKE {5} OR {1} LIKE {6})",
                        vetCamposTabelaEmpregados[2],
                        vetCamposTabelaEmpregados[8],
                        string.Format
                        (
                        "N'%{0}%'",
                        txtOrgao
                        ),
                        "N'Assistente de Diretor'",
                        "N'Superintendente'",
                        "N'Gerente'",
                        "N'%'"
                        ),
                        string.Format
                        (
                        "{0}{1}",
                        vetCamposTabelaEmpregados[intColunaTabelaEmpregadosOrgao],
                        string.Empty
                        )
                        )
                        );
                    objImplementacaoBancoDados.mtdDefinirLeitorDados();
                    if (objImplementacaoBancoDados.mtdProximoRegistro())
                    {
                        NomeItem = btnNomeItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)) ? objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaEmpregadosNome).ToString() : NomeItem;
                        MatriculaItem = btnMatriculaItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)) ? objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaEmpregadosMatricula).ToString() : MatriculaItem;
                        OrgaoItem = btnOrgaoItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)) ? objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaEmpregadosOrgao).ToString() : OrgaoItem;
                        SalaItem = btnSalaItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)) ? objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaEmpregadosEndereco).ToString() : SalaItem;
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show
                            (
                            "Não há órgão com o centro de custo informado.",
                            "Aviso!", System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Exclamation,
                            System.Windows.Forms.MessageBoxDefaultButton.Button1
                            );
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show
                        (
                        "Não foi possível encontrar o dado informado.",
                        "Aviso!", System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Exclamation,
                        System.Windows.Forms.MessageBoxDefaultButton.Button1
                        );
                }

                objImplementacaoBancoDados.Dispose();
            }
            finally
            {
                Cursor.Current = Cursors.Default; //restore the old cursor
            }
        }

        private void cmbPatrimonioItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)System.Windows.Forms.Keys.Enter)
            {
                mtdPatrimonioItem_KeyPress();
            }
        }

        private void cmbDenominacaoItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)System.Windows.Forms.Keys.Enter)
            {
                mtdDenominacaoItem_KeyPress();
            }
        }

        private void cmbNSerieItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)System.Windows.Forms.Keys.Enter)
            {
                mtdNSerieItem_KeyPress();
            }
        }

        private void cmbPlacaVeiculoItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)System.Windows.Forms.Keys.Enter)
            {
                mtdPlacaVeiculoItem_KeyPress();
            }
        }

        private void txtPatrimonioItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)System.Windows.Forms.Keys.Enter)
            {
                mtdPatrimonioItem_KeyPress();
            }
        }

        private void txtDenominacaoItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)System.Windows.Forms.Keys.Enter)
            {
                mtdDenominacaoItem_KeyPress();
            }
        }

        private void txtNSerieItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)System.Windows.Forms.Keys.Enter)
            {
                mtdNSerieItem_KeyPress();
            }
        }

        private void txtPlacaVeiculoItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)System.Windows.Forms.Keys.Enter)
            {
                mtdPlacaVeiculoItem_KeyPress();
            }
        }

        private void txtUsuarioInventario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(System.Windows.Forms.Keys.Enter))
            {
                string UsuarioInventario = txtUsuarioInventario.Text;
                string MatriculaInventario = txtMatriculaInventario.Text;

                mtdUsuarioInventarioMatriculaInventario_KeyPress(vetCamposTabelaEmpregados[intColunaTabelaEmpregadosNome], UsuarioInventario, vetCamposTabelaEmpregados[intColunaTabelaEmpregadosNome], ref UsuarioInventario, ref MatriculaInventario);

                txtUsuarioInventario.Text = UsuarioInventario;
                txtMatriculaInventario.Text = MatriculaInventario;
            }
        }

        private void txtMatriculaInventario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(System.Windows.Forms.Keys.Enter))
            {
                string UsuarioInventario = txtUsuarioInventario.Text;
                string MatriculaInventario = txtMatriculaInventario.Text;

                mtdUsuarioInventarioMatriculaInventario_KeyPress(vetCamposTabelaEmpregados[intColunaTabelaEmpregadosMatricula], MatriculaInventario, vetCamposTabelaEmpregados[intColunaTabelaEmpregadosMatricula], ref UsuarioInventario, ref MatriculaInventario);

                txtUsuarioInventario.Text = UsuarioInventario;
                txtMatriculaInventario.Text = MatriculaInventario;
            }
        }

        private void txtNomeItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(System.Windows.Forms.Keys.Enter))
            {
                string NomeItem = txtNomeItem.Text;
                string MatriculaItem = txtMatriculaItem.Text;
                string CentroCustoItem = txtCentroCustoItem.Text;
                string OrgaoItem = txtOrgaoItem.Text;
                string SalaItem = txtSalaItem.Text;

                mtdNomeItemMatriculaItemOrgaoItemSalaItemCentroCustoItem_KeyPress(vetCamposTabelaEmpregados[intColunaTabelaEmpregadosNome], NomeItem, vetCamposTabelaEmpregados[intColunaTabelaEmpregadosNome], ref NomeItem, ref MatriculaItem, ref CentroCustoItem, ref OrgaoItem, ref SalaItem);

                txtNomeItem.Text = NomeItem;
                txtMatriculaItem.Text = MatriculaItem;
                txtCentroCustoItem.Text = CentroCustoItem;
                txtOrgaoItem.Text = OrgaoItem;
                txtSalaItem.Text = SalaItem;
                if (txtOutrosDadosItem.Text == string.Empty)
                {
                    txtOutrosDadosItem.Text = txtOrgaoItem.Text != string.Empty
                        ?
                        objManipuladorTexto.mtdExecutarTudo(string.Format("{0}_{1}_{2}", txtOrgaoItem.Text, dtpDataInventario.Value.Year, dtpDataInventario.Value.Month.ToString("00")))
                        :
                        string.Empty;
                }
            }
        }

        private void txtMatriculaItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(System.Windows.Forms.Keys.Enter))
            {
                string NomeItem = txtNomeItem.Text;
                string MatriculaItem = txtMatriculaItem.Text;
                string CentroCustoItem = txtCentroCustoItem.Text;
                string OrgaoItem = txtOrgaoItem.Text;
                string SalaItem = txtSalaItem.Text;

                mtdNomeItemMatriculaItemOrgaoItemSalaItemCentroCustoItem_KeyPress(vetCamposTabelaEmpregados[intColunaTabelaEmpregadosMatricula], MatriculaItem, vetCamposTabelaEmpregados[intColunaTabelaEmpregadosMatricula], ref NomeItem, ref MatriculaItem, ref CentroCustoItem, ref OrgaoItem, ref SalaItem);

                txtNomeItem.Text = NomeItem;
                txtMatriculaItem.Text = MatriculaItem;
                txtCentroCustoItem.Text = CentroCustoItem;
                txtOrgaoItem.Text = OrgaoItem;
                txtSalaItem.Text = SalaItem;
                if (txtOutrosDadosItem.Text == string.Empty)
                {
                    txtOutrosDadosItem.Text = txtOrgaoItem.Text != string.Empty
                        ?
                        objManipuladorTexto.mtdExecutarTudo(string.Format("{0}_{1}_{2}", txtOrgaoItem.Text, dtpDataInventario.Value.Year, dtpDataInventario.Value.Month.ToString("00")))
                        :
                        string.Empty;
                }
            }
        }

        private void txtCentroCustoItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(System.Windows.Forms.Keys.Enter))
            {
                string NomeItem = txtNomeItem.Text;
                string MatriculaItem = txtMatriculaItem.Text;
                string CentroCustoItem = txtCentroCustoItem.Text;
                string OrgaoItem = txtOrgaoItem.Text;
                string SalaItem = txtSalaItem.Text;

                mtdCentroCustoItemNomeItemMatriculaItemOrgaoItemSalaItem_KeyPress(CentroCustoItem, ref NomeItem, ref MatriculaItem, ref CentroCustoItem, ref OrgaoItem, ref SalaItem);

                txtNomeItem.Text = NomeItem;
                txtMatriculaItem.Text = MatriculaItem;
                txtCentroCustoItem.Text = CentroCustoItem;
                txtOrgaoItem.Text = OrgaoItem;
                txtSalaItem.Text = SalaItem;
                if (txtOutrosDadosItem.Text == string.Empty)
                {
                    txtOutrosDadosItem.Text = txtOrgaoItem.Text != string.Empty
                        ?
                        objManipuladorTexto.mtdExecutarTudo(string.Format("{0}_{1}_{2}", txtOrgaoItem.Text, dtpDataInventario.Value.Year, dtpDataInventario.Value.Month.ToString("00")))
                        :
                        string.Empty;
                }
            }
        }

        private void txtOrgaoItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(System.Windows.Forms.Keys.Enter))
            {
                string NomeItem = txtNomeItem.Text;
                string MatriculaItem = txtMatriculaItem.Text;
                string CentroCustoItem = txtCentroCustoItem.Text;
                string OrgaoItem = txtOrgaoItem.Text;
                string SalaItem = txtSalaItem.Text;

                mtdNomeItemMatriculaItemOrgaoItemSalaItemCentroCustoItem_KeyPress(OrgaoItem, ref NomeItem, ref MatriculaItem, ref CentroCustoItem, ref OrgaoItem, ref SalaItem);

                txtNomeItem.Text = NomeItem;
                txtMatriculaItem.Text = MatriculaItem;
                txtCentroCustoItem.Text = CentroCustoItem;
                txtOrgaoItem.Text = OrgaoItem;
                txtSalaItem.Text = SalaItem;
                if (txtOutrosDadosItem.Text == string.Empty)
                {
                    txtOutrosDadosItem.Text = txtOrgaoItem.Text != string.Empty
                        ?
                        objManipuladorTexto.mtdExecutarTudo(string.Format("{0}_{1}_{2}", txtOrgaoItem.Text, dtpDataInventario.Value.Year, dtpDataInventario.Value.Month.ToString("00")))
                        :
                        string.Empty;
                }
            }
        }

        private void txtSalaItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(System.Windows.Forms.Keys.Enter))
            {
                string NomeItem = txtNomeItem.Text;
                string MatriculaItem = txtMatriculaItem.Text;
                string CentroCustoItem = txtCentroCustoItem.Text;
                string OrgaoItem = txtOrgaoItem.Text;
                string SalaItem = txtSalaItem.Text;

                mtdNomeItemMatriculaItemOrgaoItemSalaItemCentroCustoItem_KeyPress(vetCamposTabelaEmpregados[intColunaTabelaEmpregadosEndereco], SalaItem, vetCamposTabelaEmpregados[intColunaTabelaEmpregadosEndereco], ref NomeItem, ref MatriculaItem, ref CentroCustoItem, ref OrgaoItem, ref SalaItem);

                txtNomeItem.Text = NomeItem;
                txtMatriculaItem.Text = MatriculaItem;
                txtCentroCustoItem.Text = CentroCustoItem;
                txtOrgaoItem.Text = OrgaoItem;
                txtSalaItem.Text = SalaItem;
                if (txtOutrosDadosItem.Text == string.Empty)
                {
                    txtOutrosDadosItem.Text = txtOrgaoItem.Text != string.Empty
                        ?
                        objManipuladorTexto.mtdExecutarTudo(string.Format("{0}_{1}_{2}", txtOrgaoItem.Text, dtpDataInventario.Value.Year, dtpDataInventario.Value.Month.ToString("00")))
                        :
                        string.Empty;
                }
            }
        }

        private clsRegistroWindows objRegistroWindows = new clsRegistroWindows();

        private string originalFileName = string.Empty;

        private void mtdTirarFotografia()
        {
            Microsoft.WindowsMobile.Forms.CameraCaptureDialog dlg =
                new Microsoft.WindowsMobile.Forms.CameraCaptureDialog();
            dlg.Mode = Microsoft.WindowsMobile.Forms.CameraCaptureMode.Still;
            switch (cmbQualidadeFotografia.Text)
            {
                case "Low":
                    dlg.StillQuality = Microsoft.WindowsMobile.Forms.CameraCaptureStillQuality.Low;
                    break;
                case "Normal":
                    dlg.StillQuality = Microsoft.WindowsMobile.Forms.CameraCaptureStillQuality.Normal;
                    break;
                case "High":
                    dlg.StillQuality = Microsoft.WindowsMobile.Forms.CameraCaptureStillQuality.High;
                    break;
            }

            string[] vetResolucao = cmbResolucaoFotografia.Text.Split('x');
            dlg.Resolution = new Size(System.Convert.ToInt32(vetResolucao[0]), System.Convert.ToInt32(vetResolucao[1]));
            dlg.Title = "Fotografia";
            DialogResult res = new DialogResult();
            try
            {
                res = dlg.ShowDialog();
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdTirarFotografia: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
            if (res == DialogResult.OK)
            {
                this.Refresh();
                dlg.DefaultFileName = "Fotografia.jpg";
                originalFileName = dlg.FileName;
                try
                {
                    //image = ReadFile(originalFileName);

                    pctFotografia.Dock = DockStyle.None;
                    pctFotografia.Image = (Image)new Bitmap(originalFileName);
                }
                catch (System.Exception ex)
                {
                    pctFotografia.Image = tmpImage;
                    string strExcecao = "mtdTirarFotografia: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                    //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                }
                finally
                {
                    dlg.Dispose();
                }
            }
        }

        private void btnTirarFotografia_Click(object sender, EventArgs e)
        {
            mtdTirarFotografia();
        }

        private void mtdZerarFotografia()
        {
            pctFotografia.Image = tmpImage;
        }

        private void btnZerarFotografia_Click(object sender, EventArgs e)
        {
            mtdZerarFotografia();
        }

        private void txtUsuarioInventario_LostFocus(object sender, EventArgs e)
        {
            try
            {
                txtUsuarioInventario.Text = objManipuladorTexto.mtdExecutarTudo(txtUsuarioInventario.Text);

                mtdPreencherColunaCampoConsultarInventario(cmbConsultarInventario.Items[intColunaTabelaInventarioBensUsuario_Inventariante].ToString(), txtUsuarioInventario.Text);
                mtdPreencherTabelaCampoFiltroConsultarRelatorio(strTabelaInventarioBens.Replace("tbl", string.Empty), cmbConsultarInventario.Items[intColunaTabelaInventarioBensUsuario_Inventariante].ToString(), txtUsuarioInventario.Text);
            }
            catch (System.Exception ex)
            {
                string strExcecao = "txtUsuarioInventario_LostFocus: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void txtMatriculaInventario_LostFocus(object sender, EventArgs e)
        {
            try
            {
                txtMatriculaInventario.Text = objManipuladorTexto.mtdExecutarTudo(txtMatriculaInventario.Text);

                mtdPreencherColunaCampoConsultarInventario(cmbConsultarInventario.Items[intColunaTabelaInventarioBensMatricula_Inventariante].ToString(), txtMatriculaInventario.Text);
                mtdPreencherTabelaCampoFiltroConsultarRelatorio(strTabelaInventarioBens.Replace("tbl", string.Empty), cmbConsultarInventario.Items[intColunaTabelaInventarioBensMatricula].ToString(), txtMatriculaItem.Text);
            }
            catch (System.Exception ex)
            {
                string strExcecao = "txtMatriculaInventario_LostFocus: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void txtTRGItem_LostFocus(object sender, EventArgs e)
        {
            try
            {
                txtTRGItem.Text = objManipuladorTexto.mtdExecutarTudo(txtTRGItem.Text);

                mtdPreencherColunaCampoConsultarInventario(cmbConsultarInventario.Items[intColunaTabelaInventarioBensTRG].ToString(), txtTRGItem.Text);
                mtdPreencherColunaCampoConsultarSAP(cmbConsultarSAP.Items[intColunaTabelaBensEletronorteTRG].ToString(), txtTRGItem.Text);
                mtdPreencherTabelaCampoFiltroConsultarRelatorio(strTabelaInventarioBens.Replace("tbl", string.Empty), cmbConsultarInventario.Items[intColunaTabelaInventarioBensTRG].ToString(), txtTRGItem.Text);
            }
            catch (System.Exception ex)
            {
                string strExcecao = "txtTRGItem_LostFocus: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void txtCentroCustoItem_LostFocus(object sender, EventArgs e)
        {
            try
            {
                txtCentroCustoItem.Text = objManipuladorTexto.mtdExecutarTudo(txtCentroCustoItem.Text);

                mtdPreencherColunaCampoConsultarInventario(cmbConsultarInventario.Items[intColunaTabelaInventarioBensCentroCusto].ToString(), txtCentroCustoItem.Text);
                mtdPreencherColunaCampoConsultarSAP(cmbConsultarSAP.Items[intColunaTabelaBensEletronorteCentro_Custo].ToString(), txtCentroCustoItem.Text);
                mtdPreencherColunaCampoConsultarCentroCusto(cmbConsultarCentroCusto.Items[intColunaTabelaCentroCustoCentroCusto].ToString(), txtCentroCustoItem.Text);
                mtdPreencherTabelaCampoFiltroConsultarRelatorio(strTabelaInventarioBens.Replace("tbl", string.Empty), cmbConsultarInventario.Items[intColunaTabelaInventarioBensCentroCusto].ToString(), txtCentroCustoItem.Text);
            }
            catch (System.Exception ex)
            {
                string strExcecao = "txtCentroCustoItem_LostFocus: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void txtOrgaoItem_LostFocus(object sender, EventArgs e)
        {
            try
            {
                txtOrgaoItem.Text = objManipuladorTexto.mtdExecutarTudo(txtOrgaoItem.Text);

                mtdPreencherColunaCampoConsultarInventario(cmbConsultarInventario.Items[intColunaTabelaInventarioBensOrgao].ToString(), txtOrgaoItem.Text);
                mtdPreencherColunaCampoConsultarSAP(cmbConsultarSAP.Items[intColunaTabelaBensEletronorteOrgao].ToString(), txtOrgaoItem.Text);
                mtdPreencherColunaCampoConsultarEmpregados(cmbConsultarEmpregados.Items[intColunaTabelaEmpregadosOrgao].ToString(), txtOrgaoItem.Text);
                mtdPreencherColunaCampoConsultarCentroCusto(cmbConsultarCentroCusto.Items[intColunaTabelaCentroCustoOrgao].ToString(), txtOrgaoItem.Text);
                mtdPreencherTabelaCampoFiltroConsultarRelatorio(strTabelaInventarioBens.Replace("tbl", string.Empty), cmbConsultarInventario.Items[intColunaTabelaInventarioBensOrgao].ToString(), txtOrgaoItem.Text);

                if (txtOutrosDadosItem.Text == string.Empty)
                {
                    txtOutrosDadosItem.Text = txtOrgaoItem.Text != string.Empty
                        ?
                        objManipuladorTexto.mtdExecutarTudo(string.Format("{0}_{1}_{2}", txtOrgaoItem.Text, dtpDataInventario.Value.Year, dtpDataInventario.Value.Month.ToString("00")))
                        :
                        string.Empty;
                }
            }
            catch (System.Exception ex)
            {
                string strExcecao = "txtOrgaoItem_LostFocus: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void txtSalaItem_LostFocus(object sender, EventArgs e)
        {
            try
            {
                txtSalaItem.Text = objManipuladorTexto.mtdExecutarTudo(txtSalaItem.Text);

                mtdPreencherColunaCampoConsultarInventario(cmbConsultarInventario.Items[intColunaTabelaInventarioBensSala].ToString(), txtSalaItem.Text);
                mtdPreencherColunaCampoConsultarSAP(cmbConsultarSAP.Items[intColunaTabelaBensEletronorteSala].ToString(), txtSalaItem.Text);
                mtdPreencherColunaCampoConsultarEmpregados(cmbConsultarEmpregados.Items[intColunaTabelaEmpregadosEndereco].ToString(), txtSalaItem.Text.Replace(' ', '%'));
                mtdPreencherTabelaCampoFiltroConsultarRelatorio(strTabelaInventarioBens.Replace("tbl", string.Empty), cmbConsultarInventario.Items[intColunaTabelaInventarioBensSala].ToString(), txtSalaItem.Text);
            }
            catch (System.Exception ex)
            {
                string strExcecao = "txtSalaItem_LostFocus: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void txtNomeItem_LostFocus(object sender, EventArgs e)
        {
            try
            {

                txtNomeItem.Text = objManipuladorTexto.mtdExecutarTudo(txtNomeItem.Text);

                mtdPreencherColunaCampoConsultarInventario(cmbConsultarInventario.Items[intColunaTabelaInventarioBensNome].ToString(), txtNomeItem.Text);
                mtdPreencherColunaCampoConsultarEmpregados(cmbConsultarEmpregados.Items[intColunaTabelaEmpregadosNome].ToString(), txtNomeItem.Text);
                mtdPreencherTabelaCampoFiltroConsultarRelatorio(strTabelaInventarioBens.Replace("tbl", string.Empty), cmbConsultarInventario.Items[intColunaTabelaInventarioBensNome].ToString(), txtNomeItem.Text);
            }
            catch (System.Exception ex)
            {
                string strExcecao = "txtNomeItem_LostFocus: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void txtMatriculaItem_LostFocus(object sender, EventArgs e)
        {
            try
            {
                txtMatriculaItem.Text = objManipuladorTexto.mtdExecutarTudo(txtMatriculaItem.Text);

                mtdPreencherColunaCampoConsultarInventario(cmbConsultarInventario.Items[intColunaTabelaInventarioBensMatricula].ToString(), txtMatriculaItem.Text);
                mtdPreencherColunaCampoConsultarSAP(cmbConsultarSAP.Items[intColunaTabelaBensEletronorteMatricula].ToString(), txtMatriculaItem.Text);
                mtdPreencherColunaCampoConsultarEmpregados(cmbConsultarEmpregados.Items[intColunaTabelaEmpregadosMatricula].ToString(), txtMatriculaItem.Text);
                mtdPreencherTabelaCampoFiltroConsultarRelatorio(strTabelaInventarioBens.Replace("tbl", string.Empty), cmbConsultarInventario.Items[intColunaTabelaInventarioBensMatricula].ToString(), txtMatriculaItem.Text);
            }
            catch (System.Exception ex)
            {
                string strExcecao = "txtMatriculaItem_LostFocus: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void txtPatrimonioItem_LostFocus(object sender, EventArgs e)
        {
            try
            {
                txtPatrimonioItem.Text = objManipuladorTexto.mtdExecutarTudo(txtPatrimonioItem.Text);

                mtdPreencherColunaCampoConsultarInventario(cmbConsultarInventario.Items[intColunaTabelaInventarioBensPatrimonio].ToString(), txtPatrimonioItem.Text);
                mtdPreencherColunaCampoConsultarSAP(cmbConsultarSAP.Items[intColunaTabelaBensEletronortePatrimonio].ToString(), txtPatrimonioItem.Text);
                mtdPreencherTabelaCampoFiltroConsultarRelatorio(strTabelaInventarioBens.Replace("tbl", string.Empty), cmbConsultarInventario.Items[intColunaTabelaInventarioBensPatrimonio].ToString(), txtPatrimonioItem.Text);

                try
                {
                    txtPatrimonioItem.Text = System.Convert.ToInt64(txtPatrimonioItem.Text).ToString();
                }
                catch (System.Exception ex)
                {
                    string strExcecao = "txtPatrimonioItem_LostFocus: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                    //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                }
            }
            catch (System.Exception ex)
            {
                string strExcecao = "txtPatrimonioItem_LostFocus: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void txtQuantidadeItem_LostFocus(object sender, EventArgs e)
        {
            try
            {
                mtdPreencherColunaCampoConsultarInventario(cmbConsultarInventario.Items[intColunaTabelaInventarioBensQuantidade].ToString(), txtQuantidadeItem.Text);
                mtdPreencherTabelaCampoFiltroConsultarRelatorio(strTabelaInventarioBens.Replace("tbl", string.Empty), cmbConsultarInventario.Items[intColunaTabelaInventarioBensQuantidade].ToString(), txtQuantidadeItem.Text);
            }
            catch (System.Exception ex)
            {
                string strExcecao = "txtQuantidadeItem_LostFocus: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void txtDenominacaoItem_LostFocus(object sender, EventArgs e)
        {
            try
            {
                txtDenominacaoItem.Text = objManipuladorTexto.mtdExecutarTudo(txtDenominacaoItem.Text);

                mtdPreencherColunaCampoConsultarInventario(cmbConsultarInventario.Items[intColunaTabelaInventarioBensDenominacao].ToString(), txtDenominacaoItem.Text);
                mtdPreencherColunaCampoConsultarSAP(cmbConsultarSAP.Items[intColunaTabelaBensEletronorteDenominacao].ToString(), txtDenominacaoItem.Text);
                mtdPreencherTabelaCampoFiltroConsultarRelatorio(strTabelaInventarioBens.Replace("tbl", string.Empty), cmbConsultarInventario.Items[intColunaTabelaInventarioBensDenominacao].ToString(), txtDenominacaoItem.Text);
            }
            catch (System.Exception ex)
            {
                string strExcecao = "txtDenominacaoItem_LostFocus: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void txtNSerieItem_LostFocus(object sender, EventArgs e)
        {
            try
            {
                txtNSerieItem.Text = objManipuladorTexto.mtdExecutarTudo(txtNSerieItem.Text);

                mtdPreencherColunaCampoConsultarInventario(cmbConsultarInventario.Items[intColunaTabelaInventarioBensN_Serie].ToString(), txtNSerieItem.Text);
                mtdPreencherColunaCampoConsultarSAP(cmbConsultarSAP.Items[intColunaTabelaBensEletronorteN_Serie].ToString(), txtNSerieItem.Text);
                mtdPreencherTabelaCampoFiltroConsultarRelatorio(strTabelaInventarioBens.Replace("tbl", string.Empty), cmbConsultarInventario.Items[intColunaTabelaInventarioBensN_Serie].ToString(), txtNSerieItem.Text);
            }
            catch (System.Exception ex)
            {
                string strExcecao = "txtNSerieItem_LostFocus: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void txtPlacaVeiculoItem_LostFocus(object sender, EventArgs e)
        {
            try
            {
                txtPlacaVeiculoItem.Text = objManipuladorTexto.mtdExecutarTudo(txtPlacaVeiculoItem.Text);

                mtdPreencherColunaCampoConsultarInventario(cmbConsultarInventario.Items[intColunaTabelaInventarioBensPlaca_Veiculo].ToString(), txtPlacaVeiculoItem.Text);
                mtdPreencherColunaCampoConsultarSAP(cmbConsultarSAP.Items[intColunaTabelaBensEletronortePlaca_Veiculo].ToString(), txtPlacaVeiculoItem.Text);
                mtdPreencherTabelaCampoFiltroConsultarRelatorio(strTabelaInventarioBens.Replace("tbl", string.Empty), cmbConsultarInventario.Items[intColunaTabelaInventarioBensPlaca_Veiculo].ToString(), txtPlacaVeiculoItem.Text);
            }
            catch (System.Exception ex)
            {
                string strExcecao = "txtPlacaVeiculoItem_LostFocus: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void txtIdentificacaoItem_LostFocus(object sender, EventArgs e)
        {
            try
            {
                txtIdentificacaoItem.Text = objManipuladorTexto.mtdExecutarTudo(txtIdentificacaoItem.Text);

                mtdPreencherColunaCampoConsultarInventario(cmbConsultarInventario.Items[intColunaTabelaInventarioBensIdentificacao_Inventario].ToString(), txtIdentificacaoItem.Text);
                mtdPreencherTabelaCampoFiltroConsultarRelatorio(strTabelaInventarioBens.Replace("tbl", string.Empty), cmbConsultarInventario.Items[intColunaTabelaInventarioBensIdentificacao_Inventario].ToString(), txtIdentificacaoItem.Text);
            }
            catch (System.Exception ex)
            {
                string strExcecao = "txtIdentificacaoItem_LostFocus: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void txtOutrosDadosItem_LostFocus(object sender, EventArgs e)
        {
            try
            {
                txtOutrosDadosItem.Text = objManipuladorTexto.mtdExecutarTudo(txtOutrosDadosItem.Text);

                mtdPreencherColunaCampoConsultarInventario(cmbConsultarInventario.Items[intColunaTabelaInventarioBensOutrosDados_Inventario].ToString(), txtOutrosDadosItem.Text);
                mtdPreencherTabelaCampoFiltroConsultarRelatorio(strTabelaInventarioBens.Replace("tbl", string.Empty), cmbConsultarInventario.Items[intColunaTabelaInventarioBensOutrosDados_Inventario].ToString(), txtOutrosDadosItem.Text);
            }
            catch (System.Exception ex)
            {
                string strExcecao = "txtOutrosDadosItem_LostFocus: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void cmbObservacaoItem_LostFocus(object sender, EventArgs e)
        {
            try
            {
                cmbObservacaoItem.Text = objManipuladorTexto.mtdMaiusculo(cmbObservacaoItem.Text);

                mtdPreencherColunaCampoConsultarInventario(cmbConsultarInventario.Items[intColunaTabelaInventarioBensObservacao].ToString(), cmbObservacaoItem.Text);
                mtdPreencherTabelaCampoFiltroConsultarRelatorio(strTabelaInventarioBens.Replace("tbl", string.Empty), cmbConsultarInventario.Items[intColunaTabelaInventarioBensObservacao].ToString(), cmbObservacaoItem.Text);
            }
            catch (System.Exception ex)
            {
                string strExcecao = "cmbObservacaoItem_LostFocus: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private double dblTempoPressionamentoBotao = DateTime.Now.TimeOfDay.TotalMilliseconds;

        private double dblTempoPressionamentoBotaoF1 = DateTime.Now.TimeOfDay.TotalMilliseconds;
        private double dblTempoPressionamentoBotaoLeitorCodigoBarra = DateTime.Now.TimeOfDay.TotalMilliseconds;
        private double dblDiferencaTempoPressionamentoBotaoLeitorCodigoBarra = 0;
        private bool blnAjustarFocoNSerie = false;

        private void frmPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            dblTempoPressionamentoBotao = DateTime.Now.TimeOfDay.TotalMilliseconds;

            if (e.KeyCode == System.Windows.Forms.Keys.Up)
            {
                // Up
            }
            if (e.KeyCode == System.Windows.Forms.Keys.Down)
            {
                // Down
            }
            if (e.KeyCode == System.Windows.Forms.Keys.Left)
            {
                // Left
            }
            if (e.KeyCode == System.Windows.Forms.Keys.Right)
            {
                // Right
            }
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                // Enter
            }
            if (e.KeyValue == 140)
            {
                mtdTirarFotografia();
            }
            if (e.KeyValue == 150)
            {
                dblTempoPressionamentoBotaoLeitorCodigoBarra = DateTime.Now.TimeOfDay.TotalMilliseconds;
                dblDiferencaTempoPressionamentoBotaoLeitorCodigoBarra = DateTime.Now.TimeOfDay.TotalMilliseconds - dblTempoPressionamentoBotaoLeitorCodigoBarra;
            }
            if (e.KeyValue == 211)
            {
                double dblDiferencaTempoPressionamentoBotaoF1 = System.DateTime.Now.TimeOfDay.TotalMilliseconds - dblTempoPressionamentoBotaoF1;
                switch (tbc1.SelectedIndex)
                {
                    case 0:
                        txtMatriculaInventario.Focus();
                        break;
                    case 1:
                        if (dblDiferencaTempoPressionamentoBotaoF1 >= 250)
                        {
                            txtPatrimonioItem.Focus();
                        }
                        else
                        {
                            if (blnAjustarFocoNSerie)
                            {
                                txtNSerieItem.Focus();
                                blnAjustarFocoNSerie = false;
                            }
                            else
                            {
                                txtDenominacaoItem.Focus();
                                blnAjustarFocoNSerie = true;
                            }
                        }
                        break;
                    case 2:
                        txtIdentificacaoItem.Focus();
                        break;
                    case 3:
                        txtMatriculaItem.Focus();
                        break;
                    case 4:
                        tbc2.Focus();
                        break;
                    case 5:
                        tbc3.Focus();
                        break;
                    case 6:
                        btnTirarFotografia.Focus();
                        break;
                    case 7:
                        btnGPSMenu.Focus();
                        break;
                    case 8:
                        btnVisualizarMapa.Focus();
                        break;
                    case 9:
                        btnMonitorCarregamentoDados.Focus();
                        break;
                    case 10:
                        chkModoOtimizadoCadastro.Focus();
                        break;
                    case 11:
                        btnZerarTabelaInventarioBens.Focus();
                        break;
                    case 12:
                        btnSairFazerBackup.Focus();
                        break;
                }
                dblTempoPressionamentoBotaoF1 = DateTime.Now.TimeOfDay.TotalMilliseconds;
            }
            if (e.KeyValue == 212)
            {
                tbc1.Focus();
            }
            txtCodigoTeclaDigitado.Text = string.Format("KeyCode: {0} - KeyData: {1} - KeyValue: {2}", e.KeyCode.ToString(), e.KeyData.ToString(), e.KeyValue.ToString());
        }

        // Parte do Codigo relativa ao GPS.

        public Microsoft.WindowsMobile.Samples.Location.Gps objgps = new Microsoft.WindowsMobile.Samples.Location.Gps();
        //* Constructor
        //public FormGPS()
        //{
        //    InitializeComponent();
        //    objgps = new Gps();
        //}

        public enum enmEstadoGPS
        {
            Ativar,
            Desativar,
            Alternar
        }

        public void mtdAtivarDesativarGPS()
        {
            mtdAtivarDesativarGPS(enmEstadoGPS.Alternar);
        }

        private double dblTempoPressionamentoBotaoAtivarDesativarGPS = DateTime.Now.TimeOfDay.TotalMilliseconds;
        private double dblDiferencaTempoPressionamentoBotaoAtivarDesativarGPS = 0;

        private int intIntervaloPressionamentoBotaoAtivarDesativarGPS = 1000;

        public void mtdAtivarDesativarGPS(enmEstadoGPS EstadoGPS)
        {
            try
            {
                dblDiferencaTempoPressionamentoBotaoAtivarDesativarGPS = System.DateTime.Now.TimeOfDay.TotalMilliseconds - dblTempoPressionamentoBotaoAtivarDesativarGPS;

                if (dblDiferencaTempoPressionamentoBotaoAtivarDesativarGPS >= intIntervaloPressionamentoBotaoAtivarDesativarGPS)
                {
                    if ((objgps != null))
                    {
                        if (!objgps.Opened && (EstadoGPS == enmEstadoGPS.Ativar || EstadoGPS == enmEstadoGPS.Alternar))
                        {
                            objgps.DeviceStateChanged += new Microsoft.WindowsMobile.Samples.Location.DeviceStateChangedEventHandler(gps_DeviceStateChange);
                            objgps.LocationChanged += new Microsoft.WindowsMobile.Samples.Location.LocationChangedEventHandler(gps_LocationChanged);
                            objgps.Open();
                        }
                        else if (objgps.Opened && (EstadoGPS == enmEstadoGPS.Desativar || EstadoGPS == enmEstadoGPS.Alternar))
                        {
                            objgps.DeviceStateChanged -= new Microsoft.WindowsMobile.Samples.Location.DeviceStateChangedEventHandler(gps_DeviceStateChange);
                            objgps.LocationChanged -= new Microsoft.WindowsMobile.Samples.Location.LocationChangedEventHandler(gps_LocationChanged);
                            objgps.Close();

                            txtGPSDeviceState.Text = "";
                            txtEllipsoidAltitude.Text = "";
                            txtGPSLatitute.Text = "";
                            txtGPSLongitude.Text = "";
                            txtGPSPositionDilutionOfPrecision.Text = "";
                            txtGPSDeviceUsed.Text = "";
                            txtGPSServiceState.Text = "";
                        }

                        btnGPSMenu.ForeColor = objgps.Opened ? Color.FromArgb(0, 192, 0) : Color.FromArgb(192, 0, 0);
                    }
                    else
                    {
                        btnGPSMenu.ForeColor = Color.FromArgb(192, 0, 0);
                    }
                }

                dblTempoPressionamentoBotaoAtivarDesativarGPS = DateTime.Now.TimeOfDay.TotalMilliseconds;
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdAtivarDesativarGPS: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        public frmGpsPerimeter objGpsPerimeter = new frmGpsPerimeter();

        private void btnGPSPerimeter_Click(object sender, EventArgs e)
        {
            if (objGpsPerimeter == null)
            {
                objGpsPerimeter = new frmGpsPerimeter();
            }

            objGpsPerimeter.Show();
        }

        private void btnmenuGPS_Click(object sender, EventArgs e)
        {
            mtdAtivarDesativarGPS();
        }

        private void gps_DeviceStateChange(object sender, Microsoft.WindowsMobile.Samples.Location.DeviceStateChangedEventArgs args)
        {
            Microsoft.WindowsMobile.Samples.Location.GpsDeviceState device = args.DeviceState;
            ControlUpdater cu = UpdateControl;
            Invoke(cu, txtGPSDeviceUsed, device.FriendlyName);
            Invoke(cu, txtGPSDeviceState, device.DeviceState.ToString());
            Invoke(cu, txtGPSServiceState, device.ServiceState.ToString());
        }

        private void gps_LocationChanged(object sender, Microsoft.WindowsMobile.Samples.Location.LocationChangedEventArgs args)
        {
            Microsoft.WindowsMobile.Samples.Location.GpsPosition position = args.Position;
            ControlUpdater cu = UpdateControl;
            if (position.LatitudeValid)
                Invoke(cu, txtGPSLatitute, position.Latitude.ToString());
            if (position.LongitudeValid)
                Invoke(cu, txtGPSLongitude, position.Longitude.ToString());
            if (position.EllipsoidAltitudeValid)
                Invoke(cu, txtEllipsoidAltitude, position.EllipsoidAltitude.ToString());
            if (position.PositionDilutionOfPrecisionValid)
                Invoke(cu, txtGPSPositionDilutionOfPrecision, position.PositionDilutionOfPrecision.ToString());
        }

        private delegate void ControlUpdater(Control c, string s);

        private void UpdateControl(Control con, string strdata)
        {
            con.Text = strdata;
        }

        private void txtSenhaBaseDados_TextChanged(object sender, EventArgs e)
        {
            objRegistroWindows.mtdSalvarDadosRegistro
                (
                Microsoft.Win32.Registry.CurrentUser,
                "Software",
                "Eletronorte",
                "ColetorDados",
                "SenhaBaseDados",
                txtSenhaBaseDados.Text,
                Microsoft.Win32.RegistryValueKind.String
                );

            strSenhaColetor = txtSenhaBaseDados.Text;
        }

        private void txtNumeroLinhas_TextChanged(object sender, EventArgs e)
        {
            objRegistroWindows.mtdSalvarDadosRegistro
                (
                Microsoft.Win32.Registry.CurrentUser,
                "Software",
                "Eletronorte",
                "ColetorDados",
                "NumeroLinhas",
                txtNumeroLinhas.Text,
                Microsoft.Win32.RegistryValueKind.String
                );
            try
            {
                uintNumeroLinhas = Convert.ToUInt32(txtNumeroLinhas.Text);
            }
            catch (System.Exception ex)
            {
                objRegistroWindows.mtdSalvarDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "ColetorDados",
                    "NumeroLinhas",
                    uintNumeroLinhas,
                    Microsoft.Win32.RegistryValueKind.String
                    );

                txtNumeroLinhas.Text = uintNumeroLinhas.ToString();

                string strExcecao = "txtNumeroLinhas_TextChanged: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void txtComprimentoColunas_TextChanged(object sender, EventArgs e)
        {
            objRegistroWindows.mtdSalvarDadosRegistro
                (
                Microsoft.Win32.Registry.CurrentUser,
                "Software",
                "Eletronorte",
                "ColetorDados",
                "ComprimentoColunas",
                txtComprimentoColunas.Text,
                Microsoft.Win32.RegistryValueKind.String
                );
            try
            {
                uintComprimentoColunas = Convert.ToUInt32(txtComprimentoColunas.Text);
            }
            catch (System.Exception ex)
            {
                objRegistroWindows.mtdSalvarDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "ColetorDados",
                    "ComprimentoColunas",
                    uintComprimentoColunas,
                    Microsoft.Win32.RegistryValueKind.String
                    );

                txtComprimentoColunas.Text = uintComprimentoColunas.ToString();

                string strExcecao = "txtComprimentoColunas_TextChanged: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void txtNumeroCopiasBackup_TextChanged(object sender, EventArgs e)
        {
            objRegistroWindows.mtdSalvarDadosRegistro
             (
             Microsoft.Win32.Registry.CurrentUser,
             "Software",
             "Eletronorte",
             "ColetorDados",
             "NumeroCopiasBackup",
             txtNumeroCopiasBackup.Text,
             Microsoft.Win32.RegistryValueKind.String
             );
            try
            {
                uintNumeroCopiasBackup = Convert.ToUInt32(txtNumeroCopiasBackup.Text);
            }
            catch (System.Exception ex)
            {
                objRegistroWindows.mtdSalvarDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "ColetorDados",
                    "NumeroCopiasBackup",
                    uintNumeroCopiasBackup,
                    Microsoft.Win32.RegistryValueKind.String
                    );

                txtNumeroCopiasBackup.Text = uintNumeroCopiasBackup.ToString();

                string strExcecao = "txtNumeroCopiasBackup_TextChanged: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void cmbQualidadeFotografia_TextChanged(object sender, EventArgs e)
        {
            objRegistroWindows.mtdSalvarDadosRegistro
                (
                Microsoft.Win32.Registry.CurrentUser,
                "Software",
                "Eletronorte",
                "ColetorDados",
                "QualidadeFotografia",
                cmbQualidadeFotografia.Text,
                Microsoft.Win32.RegistryValueKind.String
                );
        }

        private void cmbResolucaoFotografia_TextChanged(object sender, EventArgs e)
        {
            objRegistroWindows.mtdSalvarDadosRegistro
                (
                Microsoft.Win32.Registry.CurrentUser,
                "Software",
                "Eletronorte",
                "ColetorDados",
                "ResolucaoFotografia",
                cmbResolucaoFotografia.Text,
                Microsoft.Win32.RegistryValueKind.String
                );
        }

        private void txtTemporizador_TextChanged(object sender, EventArgs e)
        {
            objRegistroWindows.mtdSalvarDadosRegistro
             (
             Microsoft.Win32.Registry.CurrentUser,
             "Software",
             "Eletronorte",
             "ColetorDados",
             "Temporizador",
             txtTemporizador.Text,
             Microsoft.Win32.RegistryValueKind.String
             );
            try
            {
                uintTemporizador = Convert.ToUInt32(txtTemporizador.Text);
            }
            catch (System.Exception ex)
            {
                objRegistroWindows.mtdSalvarDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "ColetorDados",
                    "Temporizador",
                    uintTemporizador,
                    Microsoft.Win32.RegistryValueKind.String
                    );

                txtTemporizador.Text = uintTemporizador.ToString();

                string strExcecao = "txtTemporizador_TextChanged: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private bool blnReparado = false;
        private bool blnCompactado = false;

        private void btnCompactarRepararBancoDados_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.MessageBox.Show
            (
            "Provavelmente essa operação demorará muito, deseja continuar?",
            "Aviso!", System.Windows.Forms.MessageBoxButtons.YesNo,
            System.Windows.Forms.MessageBoxIcon.Exclamation,
            System.Windows.Forms.MessageBoxDefaultButton.Button2
            ) == System.Windows.Forms.DialogResult.Yes)
            {
                clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                    (
                    clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                    );

                objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                    (
                    clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                    strBaseDadosColetor,
                    strSenhaColetor
                    );

                try
                {
                    Cursor.Current = Cursors.WaitCursor; // set the wait cursor
                    //Do some work

                    mtdRotinaPreparacaoColetor(false);

                    if (blnReparado && blnCompactado)
                    {
                        System.Windows.Forms.MessageBox.Show
                            (
                            "O Banco de Dados foi Compactado e Reparado.",
                            "Aviso!", System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Exclamation,
                            System.Windows.Forms.MessageBoxDefaultButton.Button1
                            );
                    }
                    else if (blnReparado)
                    {
                        System.Windows.Forms.MessageBox.Show
                            (
                            "O Banco de Dados foi somente Reparado.",
                            "Aviso!",
                            System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Exclamation,
                            System.Windows.Forms.MessageBoxDefaultButton.Button1
                            );
                    }
                    else if (blnCompactado)
                    {
                        System.Windows.Forms.MessageBox.Show
                            (
                            "O Banco de Dados foi somente Compactado.",
                            "Aviso!",
                            System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Exclamation,
                            System.Windows.Forms.MessageBoxDefaultButton.Button1
                            );
                    }
                }
                finally
                {
                    Cursor.Current = Cursors.Default; //restore the old cursor
                }

                objImplementacaoBancoDados.Dispose();
            }
        }

        private void btnSobre_Click(object sender, EventArgs e)
        {
            frmSobreAplicativo objSobreAplicativo = new frmSobreAplicativo();

            objSobreAplicativo.Show();
        }

        public frmBatteryStatus objBatteryStatus = new frmBatteryStatus();

        private void btnBatteryStatus_Click(object sender, EventArgs e)
        {
            if (objBatteryStatus == null)
            {
                objBatteryStatus = new frmBatteryStatus();
            }

            objBatteryStatus.Show();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor; // set the wait cursor
            //Do some work

            mtdSalvarBancoDados();

            dblTempoPressionamentoBotao = DateTime.Now.TimeOfDay.TotalMilliseconds;

            Cursor.Current = Cursors.Default; //restore the old cursor
        }

        private void btnSairAplicativo_Click(object sender, EventArgs e)
        {
            mtdSairAplicativo();
        }

        private void mtdSairFazerBackup()
        {
            Cursor.Current = Cursors.WaitCursor; // set the wait cursor
            //Do some work

            mtdSalvarBancoDados();
            dblTempoPressionamentoBotao = DateTime.Now.TimeOfDay.TotalMilliseconds;

            Cursor.Current = Cursors.Default; //restore the old cursor

            mtdSairAplicativo();
        }

        private void btnSairFazerBackup_Click(object sender, EventArgs e)
        {
            mtdSairFazerBackup();
        }


        void setDeviceName(string deviceName)
        {
            // Change the device name of the current Windows Mobile device
            using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Ident", true))
            {
                key.SetValue("Name", deviceName);
            }
        }

        private void btnPatrimonioItem_Click(object sender, EventArgs e)
        {
            if (btnPatrimonioItem.ForeColor.Equals(System.Drawing.Color.FromArgb(192, 0, 0)))
            {
                btnPatrimonioItem.ForeColor = Color.FromArgb(0, 0, 192);
            }
            else
            {
                btnPatrimonioItem.ForeColor = Color.FromArgb(192, 0, 0);
            }
        }

        private void btnPatrimonioItemA_Click(object sender, EventArgs e)
        {
            if (btnPatrimonioItemA.ForeColor.Equals(System.Drawing.Color.FromArgb(192, 0, 0)))
            {
                btnPatrimonioItemA.ForeColor = Color.FromArgb(0, 0, 192);
            }
            else
            {
                btnPatrimonioItemA.ForeColor = Color.FromArgb(192, 0, 0);
            }
        }

        private void btnPatrimonioItemL_Click(object sender, EventArgs e)
        {
            if (btnPatrimonioItemL.ForeColor.Equals(System.Drawing.Color.FromArgb(192, 0, 0)))
            {
                btnPatrimonioItemL.ForeColor = Color.FromArgb(0, 0, 192);
            }
            else
            {
                btnPatrimonioItemL.ForeColor = Color.FromArgb(192, 0, 0);
            }
        }

        private void btnDenominacaoItem_Click(object sender, EventArgs e)
        {
            if (btnDenominacaoItem.ForeColor.Equals(System.Drawing.Color.FromArgb(192, 0, 0)))
            {
                btnDenominacaoItem.ForeColor = Color.FromArgb(0, 0, 192);
            }
            else
            {
                btnDenominacaoItem.ForeColor = Color.FromArgb(192, 0, 0);
            }
        }

        private void btnDenominacaoItemA_Click(object sender, EventArgs e)
        {
            if (btnDenominacaoItemA.ForeColor.Equals(System.Drawing.Color.FromArgb(192, 0, 0)))
            {
                btnDenominacaoItemA.ForeColor = Color.FromArgb(0, 0, 192);
            }
            else
            {
                btnDenominacaoItemA.ForeColor = Color.FromArgb(192, 0, 0);
            }
        }

        private void btnDenominacaoItemL_Click(object sender, EventArgs e)
        {
            if (btnDenominacaoItemL.ForeColor.Equals(System.Drawing.Color.FromArgb(192, 0, 0)))
            {
                btnDenominacaoItemL.ForeColor = Color.FromArgb(0, 0, 192);
            }
            else
            {
                btnDenominacaoItemL.ForeColor = Color.FromArgb(192, 0, 0);
            }
        }

        private void btnNSerieItem_Click(object sender, EventArgs e)
        {
            if (btnNSerieItem.ForeColor.Equals(System.Drawing.Color.FromArgb(192, 0, 0)))
            {
                btnNSerieItem.ForeColor = Color.FromArgb(0, 0, 192);
            }
            else
            {
                btnNSerieItem.ForeColor = Color.FromArgb(192, 0, 0);
            }
        }

        private void btnNSerieItemA_Click(object sender, EventArgs e)
        {
            if (btnNSerieItemA.ForeColor.Equals(System.Drawing.Color.FromArgb(192, 0, 0)))
            {
                btnNSerieItemA.ForeColor = Color.FromArgb(0, 0, 192);
            }
            else
            {
                btnNSerieItemA.ForeColor = Color.FromArgb(192, 0, 0);
            }
        }

        private void btnNSerieItemL_Click(object sender, EventArgs e)
        {
            if (btnNSerieItemL.ForeColor.Equals(System.Drawing.Color.FromArgb(192, 0, 0)))
            {
                btnNSerieItemL.ForeColor = Color.FromArgb(0, 0, 192);
            }
            else
            {
                btnNSerieItemL.ForeColor = Color.FromArgb(192, 0, 0);
            }
        }

        private void btnPlacaVeiculoItem_Click(object sender, EventArgs e)
        {
            if (btnPlacaVeiculoItem.ForeColor.Equals(System.Drawing.Color.FromArgb(192, 0, 0)))
            {
                btnPlacaVeiculoItem.ForeColor = Color.FromArgb(0, 0, 192);
            }
            else
            {
                btnPlacaVeiculoItem.ForeColor = Color.FromArgb(192, 0, 0);
            }
        }

        private void btnPlacaVeiculoItemA_Click(object sender, EventArgs e)
        {
            if (btnPlacaVeiculoItemA.ForeColor.Equals(System.Drawing.Color.FromArgb(192, 0, 0)))
            {
                btnPlacaVeiculoItemA.ForeColor = Color.FromArgb(0, 0, 192);
            }
            else
            {
                btnPlacaVeiculoItemA.ForeColor = Color.FromArgb(192, 0, 0);
            }
        }

        private void btnPlacaVeiculoItemL_Click(object sender, EventArgs e)
        {
            if (btnPlacaVeiculoItemL.ForeColor.Equals(System.Drawing.Color.FromArgb(192, 0, 0)))
            {
                btnPlacaVeiculoItemL.ForeColor = Color.FromArgb(0, 0, 192);
            }
            else
            {
                btnPlacaVeiculoItemL.ForeColor = Color.FromArgb(192, 0, 0);
            }
        }


        private void btnIdentificacaoItem_Click(object sender, EventArgs e)
        {
            if (btnIdentificacaoItem.ForeColor.Equals(System.Drawing.Color.FromArgb(192, 0, 0)))
            {
                btnIdentificacaoItem.ForeColor = Color.FromArgb(0, 0, 192);
            }
            else
            {
                btnIdentificacaoItem.ForeColor = Color.FromArgb(192, 0, 0);
            }
        }

        private void btnIdentificacaoItemA_Click(object sender, EventArgs e)
        {
            if (btnIdentificacaoItemA.ForeColor.Equals(System.Drawing.Color.FromArgb(192, 0, 0)))
            {
                btnIdentificacaoItemA.ForeColor = Color.FromArgb(0, 0, 192);
            }
            else
            {
                btnIdentificacaoItemA.ForeColor = Color.FromArgb(192, 0, 0);
            }
        }

        private void btnIdentificacaoItemL_Click(object sender, EventArgs e)
        {
            if (btnIdentificacaoItemL.ForeColor.Equals(System.Drawing.Color.FromArgb(192, 0, 0)))
            {
                btnIdentificacaoItemL.ForeColor = Color.FromArgb(0, 0, 192);
            }
            else
            {
                btnIdentificacaoItemL.ForeColor = Color.FromArgb(192, 0, 0);
            }
        }

        private void btnOutrosDadosItem_Click(object sender, EventArgs e)
        {
            if (btnOutrosDadosItem.ForeColor.Equals(System.Drawing.Color.FromArgb(192, 0, 0)))
            {
                btnOutrosDadosItem.ForeColor = Color.FromArgb(0, 0, 192);
            }
            else
            {
                btnOutrosDadosItem.ForeColor = Color.FromArgb(192, 0, 0);
            }
        }
        private void btnOutrosDadosItemA_Click(object sender, EventArgs e)
        {
            if (btnOutrosDadosItemA.ForeColor.Equals(System.Drawing.Color.FromArgb(192, 0, 0)))
            {
                btnOutrosDadosItemA.ForeColor = Color.FromArgb(0, 0, 192);
            }
            else
            {
                btnOutrosDadosItemA.ForeColor = Color.FromArgb(192, 0, 0);
            }
        }

        private void btnOutrosDadosItemL_Click(object sender, EventArgs e)
        {
            if (btnOutrosDadosItemL.ForeColor.Equals(System.Drawing.Color.FromArgb(192, 0, 0)))
            {
                btnOutrosDadosItemL.ForeColor = Color.FromArgb(0, 0, 192);
            }
            else
            {
                btnOutrosDadosItemL.ForeColor = Color.FromArgb(192, 0, 0);
            }
        }

        private void btnObservacaoItem_Click(object sender, EventArgs e)
        {
            if (btnObservacaoItem.ForeColor.Equals(System.Drawing.Color.FromArgb(192, 0, 0)))
            {
                btnObservacaoItem.ForeColor = Color.FromArgb(0, 0, 192);
            }
            else
            {
                btnObservacaoItem.ForeColor = Color.FromArgb(192, 0, 0);
            }
        }

        private void btnObservacaoItemA_Click(object sender, EventArgs e)
        {
            if (btnObservacaoItemRecuar.ForeColor.Equals(System.Drawing.Color.FromArgb(192, 0, 0)))
            {
                btnObservacaoItemRecuar.ForeColor = Color.FromArgb(0, 0, 192);
            }
            else
            {
                btnObservacaoItemRecuar.ForeColor = Color.FromArgb(192, 0, 0);
            }
        }

        private void btnObservacaoItemL_Click(object sender, EventArgs e)
        {
            if (btnObservacaoItemL.ForeColor.Equals(System.Drawing.Color.FromArgb(192, 0, 0)))
            {
                btnObservacaoItemL.ForeColor = Color.FromArgb(0, 0, 192);
            }
            else
            {
                btnObservacaoItemL.ForeColor = Color.FromArgb(192, 0, 0);
            }
        }

        private void btnTRGItem_Click(object sender, EventArgs e)
        {
            if (btnTRGItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)))
            {
                btnTRGItem.ForeColor = Color.FromArgb(192, 0, 0);
            }
            else
            {
                btnTRGItem.ForeColor = Color.FromArgb(0, 192, 0);
            }
        }

        private void btnTRGItemA_Click(object sender, EventArgs e)
        {
            if (btnTRGItemA.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)))
            {
                btnTRGItemA.ForeColor = Color.FromArgb(192, 0, 0);
            }
            else
            {
                btnTRGItemA.ForeColor = Color.FromArgb(0, 192, 0);
            }
        }

        private void btnTRGItemL_Click(object sender, EventArgs e)
        {
            if (btnTRGItemL.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)))
            {
                btnTRGItemL.ForeColor = Color.FromArgb(192, 0, 0);
            }
            else
            {
                btnTRGItemL.ForeColor = Color.FromArgb(0, 192, 0);
            }
        }

        private void btnCentroCustoItem_Click(object sender, EventArgs e)
        {
            if (btnCentroCustoItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)))
            {
                btnCentroCustoItem.ForeColor = Color.FromArgb(192, 0, 0);
            }
            else
            {
                btnCentroCustoItem.ForeColor = Color.FromArgb(0, 192, 0);
            }
        }

        private void btnCentroCustoItemA_Click(object sender, EventArgs e)
        {
            if (btnCentroCustoItemA.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)))
            {
                btnCentroCustoItemA.ForeColor = Color.FromArgb(192, 0, 0);
            }
            else
            {
                btnCentroCustoItemA.ForeColor = Color.FromArgb(0, 192, 0);
            }
        }

        private void btnCentroCustoItemL_Click(object sender, EventArgs e)
        {
            if (btnCentroCustoItemL.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)))
            {
                btnCentroCustoItemL.ForeColor = Color.FromArgb(192, 0, 0);
            }
            else
            {
                btnCentroCustoItemL.ForeColor = Color.FromArgb(0, 192, 0);
            }
        }

        private void btnOrgaoItem_Click(object sender, EventArgs e)
        {
            if (btnOrgaoItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)))
            {
                btnOrgaoItem.ForeColor = Color.FromArgb(192, 0, 0);
            }
            else
            {
                btnOrgaoItem.ForeColor = Color.FromArgb(0, 192, 0);
            }
        }

        private void btnOrgaoItemA_Click(object sender, EventArgs e)
        {
            if (btnOrgaoItemA.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)))
            {
                btnOrgaoItemA.ForeColor = Color.FromArgb(192, 0, 0);
            }
            else
            {
                btnOrgaoItemA.ForeColor = Color.FromArgb(0, 192, 0);
            }
        }

        private void btnOrgaoItemL_Click(object sender, EventArgs e)
        {
            if (btnOrgaoItemL.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)))
            {
                btnOrgaoItemL.ForeColor = Color.FromArgb(192, 0, 0);
            }
            else
            {
                btnOrgaoItemL.ForeColor = Color.FromArgb(0, 192, 0);
            }
        }

        private void btnSalaItem_Click(object sender, EventArgs e)
        {
            if (btnSalaItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)))
            {
                btnSalaItem.ForeColor = Color.FromArgb(192, 0, 0);
            }
            else
            {
                btnSalaItem.ForeColor = Color.FromArgb(0, 192, 0);
            }
        }

        private void btnSalaItemA_Click(object sender, EventArgs e)
        {
            if (btnSalaItemA.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)))
            {
                btnSalaItemA.ForeColor = Color.FromArgb(192, 0, 0);
            }
            else
            {
                btnSalaItemA.ForeColor = Color.FromArgb(0, 192, 0);
            }
        }

        private void btnSalaItemL_Click(object sender, EventArgs e)
        {
            if (btnSalaItemL.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)))
            {
                btnSalaItemL.ForeColor = Color.FromArgb(192, 0, 0);
            }
            else
            {
                btnSalaItemL.ForeColor = Color.FromArgb(0, 192, 0);
            }
        }

        private void btnNomeItem_Click(object sender, EventArgs e)
        {
            if (btnNomeItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)))
            {
                btnNomeItem.ForeColor = Color.FromArgb(192, 0, 0);
            }
            else
            {
                btnNomeItem.ForeColor = Color.FromArgb(0, 192, 0);
            }
        }

        private void btnNomeItemA_Click(object sender, EventArgs e)
        {
            if (btnNomeItemA.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)))
            {
                btnNomeItemA.ForeColor = Color.FromArgb(192, 0, 0);
            }
            else
            {
                btnNomeItemA.ForeColor = Color.FromArgb(0, 192, 0);
            }
        }

        private void btnNomeItemL_Click(object sender, EventArgs e)
        {
            if (btnNomeItemL.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)))
            {
                btnNomeItemL.ForeColor = Color.FromArgb(192, 0, 0);
            }
            else
            {
                btnNomeItemL.ForeColor = Color.FromArgb(0, 192, 0);
            }
        }

        private void btnMatriculaItem_Click(object sender, EventArgs e)
        {
            if (btnMatriculaItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)))
            {
                btnMatriculaItem.ForeColor = Color.FromArgb(192, 0, 0);
            }
            else
            {
                btnMatriculaItem.ForeColor = Color.FromArgb(0, 192, 0);
            }
        }

        private void btnMatriculaItemA_Click(object sender, EventArgs e)
        {
            if (btnMatriculaItemA.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)))
            {
                btnMatriculaItemA.ForeColor = Color.FromArgb(192, 0, 0);
            }
            else
            {
                btnMatriculaItemA.ForeColor = Color.FromArgb(0, 192, 0);
            }
        }

        private void btnMatriculaItemL_Click(object sender, EventArgs e)
        {
            if (btnMatriculaItemL.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)))
            {
                btnMatriculaItemL.ForeColor = Color.FromArgb(192, 0, 0);
            }
            else
            {
                btnMatriculaItemL.ForeColor = Color.FromArgb(0, 192, 0);
            }
        }

        private void btnDadosGeraisSelecionarButoes_Click(object sender, EventArgs e)
        {
            if (btnDadosGeraisSelecionarButoes.BackColor.Equals(System.Drawing.Color.FromArgb(255, 192, 192)))
            {
                btnDadosGeraisSelecionarButoes.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
                btnPatrimonioItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
                btnDenominacaoItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
                btnNSerieItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
                btnPlacaVeiculoItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
            }
            else
            {
                btnDadosGeraisSelecionarButoes.BackColor = (System.Drawing.Color.FromArgb(255, 192, 192));
                btnPatrimonioItem.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
                btnDenominacaoItem.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
                btnNSerieItem.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
                btnPlacaVeiculoItem.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            }
        }

        private void btnDadosGeraisSelecionarButoesA_Click(object sender, EventArgs e)
        {
            if (btnDadosGeraisSelecionarButoesA.BackColor.Equals(System.Drawing.Color.FromArgb(255, 192, 192)))
            {
                btnDadosGeraisSelecionarButoesA.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
                btnPatrimonioItemA.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
                btnDenominacaoItemA.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
                btnNSerieItemA.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
                btnPlacaVeiculoItemA.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
            }
            else
            {
                btnDadosGeraisSelecionarButoesA.BackColor = (System.Drawing.Color.FromArgb(255, 192, 192));
                btnPatrimonioItemA.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
                btnDenominacaoItemA.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
                btnNSerieItemA.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
                btnPlacaVeiculoItemA.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            }
        }

        private void btnDadosGeraisSelecionarButoesL_Click(object sender, EventArgs e)
        {
            if (btnDadosGeraisSelecionarButoesL.BackColor.Equals(System.Drawing.Color.FromArgb(255, 192, 192)))
            {
                btnDadosGeraisSelecionarButoesL.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
                btnPatrimonioItemL.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
                btnDenominacaoItemL.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
                btnNSerieItemL.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
                btnPlacaVeiculoItemL.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
            }
            else
            {
                btnDadosGeraisSelecionarButoesL.BackColor = (System.Drawing.Color.FromArgb(255, 192, 192));
                btnPatrimonioItemL.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
                btnDenominacaoItemL.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
                btnNSerieItemL.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
                btnPlacaVeiculoItemL.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            }
        }

        private void btnDadosComplementaresSelecionarButoes_Click(object sender, EventArgs e)
        {
            if (btnDadosComplementaresSelecionarButoes.BackColor.Equals(System.Drawing.Color.FromArgb(255, 192, 192)))
            {
                btnDadosComplementaresSelecionarButoes.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
                btnIdentificacaoItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
                btnOutrosDadosItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
                btnObservacaoItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
            }
            else
            {
                btnDadosComplementaresSelecionarButoes.BackColor = (System.Drawing.Color.FromArgb(255, 192, 192));
                btnIdentificacaoItem.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
                btnOutrosDadosItem.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
                btnObservacaoItem.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            }
        }

        private void btnDadosComplementaresSelecionarButoesA_Click(object sender, EventArgs e)
        {
            if (btnDadosComplementaresSelecionarButoesA.BackColor.Equals(System.Drawing.Color.FromArgb(255, 192, 192)))
            {
                btnDadosComplementaresSelecionarButoesA.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
                btnIdentificacaoItemA.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
                btnOutrosDadosItemA.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
                btnObservacaoItemRecuar.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
            }
            else
            {
                btnDadosComplementaresSelecionarButoesA.BackColor = (System.Drawing.Color.FromArgb(255, 192, 192));
                btnIdentificacaoItemA.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
                btnOutrosDadosItemA.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
                btnObservacaoItemRecuar.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            }
        }

        private void btnDadosComplementaresSelecionarButoesL_Click(object sender, EventArgs e)
        {
            if (btnDadosComplementaresSelecionarButoesL.BackColor.Equals(System.Drawing.Color.FromArgb(255, 192, 192)))
            {
                btnDadosComplementaresSelecionarButoesL.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
                btnIdentificacaoItemL.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
                btnOutrosDadosItemL.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
                btnObservacaoItemL.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
            }
            else
            {
                btnDadosComplementaresSelecionarButoesL.BackColor = (System.Drawing.Color.FromArgb(255, 192, 192));
                btnIdentificacaoItemL.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
                btnOutrosDadosItemL.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
                btnObservacaoItemL.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            }
        }

        private void btnControleFisicoSelecionarButoes_Click(object sender, EventArgs e)
        {
            if (btnControleFisicoSelecionarButoes.BackColor.Equals(System.Drawing.Color.FromArgb(255, 192, 192)))
            {
                btnControleFisicoSelecionarButoes.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
                btnTRGItem.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
                btnCentroCustoItem.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
                btnOrgaoItem.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
                btnSalaItem.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
                btnNomeItem.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
                btnMatriculaItem.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
            }
            else
            {
                btnControleFisicoSelecionarButoes.BackColor = (System.Drawing.Color.FromArgb(255, 192, 192));
                btnTRGItem.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
                btnCentroCustoItem.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
                btnOrgaoItem.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
                btnSalaItem.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
                btnNomeItem.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
                btnMatriculaItem.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            }
        }

        private void btnControleFisicoSelecionarButoesA_Click(object sender, EventArgs e)
        {
            if (btnControleFisicoSelecionarButoesA.BackColor.Equals(System.Drawing.Color.FromArgb(255, 192, 192)))
            {
                btnControleFisicoSelecionarButoesA.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
                btnTRGItemA.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
                btnCentroCustoItemA.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
                btnOrgaoItemA.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
                btnSalaItemA.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
                btnNomeItemA.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
                btnMatriculaItemA.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
            }
            else
            {
                btnControleFisicoSelecionarButoesA.BackColor = (System.Drawing.Color.FromArgb(255, 192, 192));
                btnTRGItemA.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
                btnCentroCustoItemA.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
                btnOrgaoItemA.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
                btnSalaItemA.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
                btnNomeItemA.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
                btnMatriculaItemA.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            }
        }

        private void btnControleFisicoSelecionarButoesL_Click(object sender, EventArgs e)
        {
            if (btnControleFisicoSelecionarButoesL.BackColor.Equals(System.Drawing.Color.FromArgb(255, 192, 192)))
            {
                btnControleFisicoSelecionarButoesL.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
                btnTRGItemL.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
                btnCentroCustoItemL.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
                btnOrgaoItemL.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
                btnSalaItemL.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
                btnNomeItemL.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
                btnMatriculaItemL.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
            }
            else
            {
                btnControleFisicoSelecionarButoesL.BackColor = (System.Drawing.Color.FromArgb(255, 192, 192));
                btnTRGItemL.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
                btnCentroCustoItemL.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
                btnOrgaoItemL.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
                btnSalaItemL.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
                btnNomeItemL.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
                btnMatriculaItemL.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            }
        }

        private void chkPermitirExibicaoNotificacoes_Click(object sender, EventArgs e)
        {
            objRegistroWindows.mtdSalvarDadosRegistro
                (
                Microsoft.Win32.Registry.CurrentUser,
                "Software",
                "Eletronorte",
                "ColetorDados",
                "PermitirExibicaoNotificacoes",
                chkPermitirExibicaoNotificacoes.Checked.ToString(),
                Microsoft.Win32.RegistryValueKind.String
                );

            ntf1.InitialDuration = 5;
            ntf1.Critical = chkPermitirExibicaoNotificacoes.Checked;
            ntf1.Visible = chkPermitirExibicaoNotificacoes.Checked;
        }

        private void btnTravarFotografia_Click(object sender, EventArgs e)
        {
            if (btnTravarFotografia.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)))
            {
                btnTravarFotografia.ForeColor = Color.FromArgb(192, 0, 0);
            }
            else
            {
                btnTravarFotografia.ForeColor = Color.FromArgb(0, 192, 0);
            }
        }

        private void btnTirarFotografiaL_Click(object sender, EventArgs e)
        {
            if (btnTirarFotografiaL.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)))
            {
                btnTirarFotografiaL.ForeColor = Color.FromArgb(192, 0, 0);
            }
            else
            {
                btnTirarFotografiaL.ForeColor = Color.FromArgb(0, 192, 0);
            }
        }

        private void mtdAjustarDataTempoSistema()
        {
            System.DateTime dtSistema = new DateTime
                (
                dtpDataSistema.Value.Year,
                dtpDataSistema.Value.Month,
                dtpDataSistema.Value.Day,
                dtpTempoSistema.Value.Hour,
                dtpTempoSistema.Value.Minute,
                dtpTempoSistema.Value.Second,
                dtpTempoSistema.Value.Millisecond
                );

            System.DateTime dtUTCSistema = System.TimeZone.CurrentTimeZone.ToUniversalTime(dtSistema);

            clsDataTempoSistema.mtdAjustarDataTempoSistema(ref dtUTCSistema);
        }

        bool blnPermitirAtualizacaoDtpDataInventario = true;

        private System.DateTime mtdObterDataTempoSistema()
        {
            System.DateTime dtSistema = new System.DateTime();

            dtSistema = new DateTime
                (
                dtpDataSistema.Value.Year,
                dtpDataSistema.Value.Month,
                dtpDataSistema.Value.Day,
                dtpTempoSistema.Value.Hour,
                dtpTempoSistema.Value.Minute,
                dtpTempoSistema.Value.Second,
                dtpTempoSistema.Value.Millisecond
                );

            clsDataTempoSistema.mtdObterDataTempoSistema(ref dtSistema);

            if (!dtpTempoSistema.Enabled)
            {
                dtpDataSistema.Value = System.TimeZone.CurrentTimeZone.ToLocalTime(dtSistema);
                dtpTempoSistema.Value = System.TimeZone.CurrentTimeZone.ToLocalTime(dtSistema);
            }

            if (blnPermitirAtualizacaoDtpDataInventario)
            {
                try
                {
                    dtpDataInventario.Value = System.TimeZone.CurrentTimeZone.ToLocalTime(dtSistema);
                }
                catch (System.Exception ex)
                {
                    string strExcecao = "mtdObterDataTempoSistema: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                    //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                }
            }

            return dtSistema;
        }

        private int intContadorColetorLixo = 0;
        private int intContadorMaximoColetorLixo = 4 * 60;

        private double dblIntervaloTempoPressionamentoBotao = uintIntervaloBackup * 60 * 1000;

        private void mtdtmr1()
        {
            try
            {
                mtdNivelBateria();
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdtmr1: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }

            try
            {
                mtdColorirNivelBateria();
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdtmr1: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }

            try
            {
                mtdIndicarTemporizador();
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdtmr1: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }

            try
            {
                mtdGerarNivelBateria(false, true);
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdtmr1: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }

            try
            {
                mtdCarregarPermitirEscritaColuna();
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdtmr1: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }

            try
            {
                mtdObterDataTempoSistema();
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdtmr1: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }

            try
            {
                for (int contador = vetTh.GetLowerBound(0); contador <= vetTh.GetUpperBound(0); contador++)
                {
                    if (vetTh[contador] != null)
                    {
                        //if (vetTh[contador].ThreadState == System.Threading.ThreadState.Running)
                        //{
                        vetTh[contador].Priority = mtdConverterPrioridadeThread(cmbPrioridadeModoOtimizadoCadastro.Text);
                        //}
                    }
                }
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdtmr1: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }

            try
            {
                double dblDiferencaTempoPressionamentoBotao = System.DateTime.Now.TimeOfDay.TotalMilliseconds - dblTempoPressionamentoBotao;

                dblIntervaloTempoPressionamentoBotao = uintIntervaloBackup * 60 * 1000;
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdtmr1: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }

            try
            {
                if (intContadorColetorLixo >= intContadorMaximoColetorLixo - 1)
                {
                    try
                    {
                        System.GC.Collect();
                    }
                    catch (System.Exception ex)
                    {
                        string strExcecao = "mtdtmr1: " + ex.Message;
                        System.Diagnostics.Debug.WriteLine(strExcecao);
                        //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                    }
                    intContadorColetorLixo = 0;
                }
                else
                {
                    intContadorColetorLixo++;
                }
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdtmr1: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void SetValuetmr1()
        {

        }

        private static object Locktmr1_Tick = new object();

        private void tmr1_Tick(object sender, EventArgs e)
        {
            lock (Locktmr1_Tick)
            {
                if (this.InvokeRequired)
                {
                    SetValueCallbacktmr1 f = new SetValueCallbacktmr1(this.SetValuetmr1);
                    this.Invoke(f, new object[] { });
                }
                else
                {
                    mtdtmr1();
                }
            }
        }

        private void btnDataTempoSistema_Click(object sender, EventArgs e)
        {
            if (btnDataTempoSistema.ForeColor.Equals(System.Drawing.Color.FromArgb(192, 0, 0)))
            {
                btnDataTempoSistema.ForeColor = Color.FromArgb(128, 128, 255);
                dtpDataSistema.Enabled = false;
                dtpTempoSistema.Enabled = false;
                mni1.Text = "Otimizado";
            }
            else
            {
                btnDataTempoSistema.ForeColor = Color.FromArgb(192, 0, 0);
                dtpDataSistema.Enabled = true;
                dtpTempoSistema.Enabled = true;
                mni1.Text = "Definir";
            }
        }

        private void pctSairAplicativo_Click(object sender, EventArgs e)
        {
            mtdSairAplicativo();
        }

        private bool blnEstadoAnteriorModoOtimizadoCadastro = false;
        //private bool blnEstadoAnteriorModoOtimizadoComplexo = false;

        private void mtdModoCadastroInventario_()
        {
            if (btnModoCadastroInventario.Text.Equals("Modo &Inventário"))
            {
                btnModoCadastroInventario.ForeColor = Color.Olive;
                btnModoCadastroInventario.Text = "Modo &Cadastro";
                mni1.Text = "Cadastro";

                blnEstadoAnteriorModoOtimizadoCadastro = chkModoOtimizadoCadastro.Checked;
                chkModoOtimizadoCadastro.Checked = false;
                chkModoOtimizadoCadastro.Enabled = false;
            }
            else
            {
                btnModoCadastroInventario.ForeColor = Color.FromArgb(128, 128, 255);
                btnModoCadastroInventario.Text = "Modo &Inventário";
                mni1.Text = "Inventário";

                chkModoOtimizadoCadastro.Enabled = true;
                chkModoOtimizadoCadastro.Checked = blnEstadoAnteriorModoOtimizadoCadastro;
            }

            if (chkModoOtimizadoCadastro.Checked)
            {
                btnDenominacaoItem.ForeColor = Color.FromArgb(192, 0, 0);
                btnNSerieItem.ForeColor = Color.FromArgb(192, 0, 0);
                btnPlacaVeiculoItem.ForeColor = Color.FromArgb(192, 0, 0);
            }
            else
            {
                btnDenominacaoItem.ForeColor = Color.FromArgb(0, 0, 192);
                btnNSerieItem.ForeColor = Color.FromArgb(0, 0, 192);
                btnPlacaVeiculoItem.ForeColor = Color.FromArgb(0, 0, 192);
            }

            objRegistroWindows.mtdSalvarDadosRegistro
                (
                Microsoft.Win32.Registry.CurrentUser,
                "Software",
                "Eletronorte",
                "ColetorDados",
                "ModoCadastroInventario",
                btnModoCadastroInventario.Text,
                Microsoft.Win32.RegistryValueKind.String
                );

            //mtdIdentificacaoItemAvancar();
            txtIdentificacaoItem.Text = string.Empty;
            txtOutrosDadosItem.Text = string.Empty;
        }

        private void btnModoCadastroInventario_Click(object sender, EventArgs e)
        {
            mtdModoCadastroInventario_();
        }

        private void txtConsultarInventario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)System.Windows.Forms.Keys.Enter)
            {
                mtdAtualizarDtg1(cmbConsultarInventario.Text, txtConsultarInventario.Text, uintNumeroLinhas);
            }
        }

        private void txtConsultarSAP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)System.Windows.Forms.Keys.Enter)
            {
                mtdAtualizarDtg2(cmbConsultarSAP.Text, txtConsultarSAP.Text, uintNumeroLinhas);
            }
        }

        private void txtConsultarEmpregados_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)System.Windows.Forms.Keys.Enter)
            {
                mtdAtualizarDtg3(cmbConsultarEmpregados.Text, txtConsultarEmpregados.Text, uintNumeroLinhas);
            }
        }

        private void txtConsultarCentroCusto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)System.Windows.Forms.Keys.Enter)
            {
                mtdAtualizarDtg4(cmbConsultarCentroCusto.Text, txtConsultarCentroCusto.Text, uintNumeroLinhas);
            }
        }

        private void txtConsultarRelatorio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)System.Windows.Forms.Keys.Enter)
            {
                mtdAtualizarDtg5(cmbConsultarCamposRelatorio.Text, string.Format("tbl{0}", cmbConsultarTabelaRelatorio.Text), txtTabelaRelatorioFiltro.Text, uintNumeroLinhas);
            }
        }

        private void txtTabelaRelatorioFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)System.Windows.Forms.Keys.Enter)
            {
                mtdAtualizarDtg5(cmbConsultarCamposRelatorio.Text, string.Format("tbl{0}", cmbConsultarTabelaRelatorio.Text), txtTabelaRelatorioFiltro.Text, uintNumeroLinhas);
            }
        }

        private enum TipoMapa
        {
            RoadMap,
            Satellite,
            Terrain,
            Hybrid
        }

        private void mtdMapa
            (
            string Latitude,
            string Longitude,
            string Zoom,
            string HorizontalSize,
            string VerticalSize,
            string RotuloMarcador,
            TipoMapa TipoMapa,
            string Sensor
            )
        {
            if (!Latitude.Equals(string.Empty) & !Longitude.Equals(string.Empty))
            {
                Zoom = Zoom.Equals(string.Empty) ?
                    "0" :
                    Zoom;
                HorizontalSize = HorizontalSize.Equals(string.Empty) ?
                    "0" :
                    HorizontalSize;
                VerticalSize = VerticalSize.Equals(string.Empty) ?
                    "0" :
                    VerticalSize;
                Sensor = Sensor.Equals(string.Empty) ?
                    "false" :
                    Sensor.ToString().ToLower();

                mtdMapa
                    (
                    Latitude,
                    Longitude,
                    System.Convert.ToInt32(Zoom),
                    System.Convert.ToInt32(HorizontalSize),
                    System.Convert.ToInt32(VerticalSize),
                    RotuloMarcador,
                    TipoMapa,
                    System.Convert.ToBoolean(Sensor)
                    );
            }
        }

        private string strEnderecoMapa = "http://maps.google.com/maps/api/staticmap?center={0},{1}&zoom={2}&size={3}x{4}&markers=color:blue%7Clabel:{5}%7C{0},{1}&maptype={6}&sensor={7}";

        private void mtdMapa(
            string Latitude,
            string Longitude,
            int Zoom,
            int HorizontalSize,
            int VerticalSize,
            string RotuloMarcador,
            TipoMapa TipoMapa,
            bool Sensor
            )
        {
            if (Zoom < 0)
            {
                Zoom = 0;
            }
            if (Zoom > 21)
            {
                Zoom = 21;
            }

            string strTipoMapa = string.Empty;

            switch (TipoMapa)
            {
                case TipoMapa.RoadMap:
                    strTipoMapa = "roadmap";
                    break;
                case TipoMapa.Satellite:
                    strTipoMapa = "satellite";
                    break;
                case TipoMapa.Terrain:
                    strTipoMapa = "terrain";
                    break;
                case TipoMapa.Hybrid:
                    strTipoMapa = "hybrid";
                    break;
            }

            string queryAddress = string.Format
                (
                strEnderecoMapa,
                Latitude.Replace(',', '.'),
                Longitude.Replace(',', '.'),
                Zoom,
                HorizontalSize,
                VerticalSize,
                RotuloMarcador,
                strTipoMapa,
                Sensor.ToString().ToLower()
                );

            try
            {
                clsVerificarConexao objVerificarConexao = new clsVerificarConexao();

                if (objVerificarConexao.mtdChecarInternet(strEnderecoTesteInternet))
                {
                    wbMapa.Navigate(new System.Uri(queryAddress.ToString()));
                }
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdMapa: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void tcbMapa_ValueChanged(object sender, EventArgs e)
        {
            mtdVisualizarMapa();
        }

        public void mtdSincronizarHorarioServidor()
        {
            mtdSincronizarHorarioServidor(true);
        }

        public void mtdSincronizarHorarioServidor(bool Notificacao)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor; // set the wait cursor
                //Do some work

                if (clsDataTempoSistema.mtdAjustarDataTempoSistema(objMonitorCarregamentoDados.wb.Url))
                {
                    dtpDataInventario.Value = System.DateTime.Now;

                    if (Notificacao)
                    {
                        try
                        {
                            ntf1.Text = "A data e o tempo do dispositivo foram sincronizados com um servidor externo.";
                        }
                        catch (System.Exception ex)
                        {
                            ntf1.Text = "A data e o tempo foram sincronizados.";
                        }
                    }
                }
                else
                {
                    if (Notificacao)
                    {
                        try
                        {
                            ntf1.Text = "Não foi possível sincronizar a data e o tempo do dispositivo com um servidor externo.";
                        }
                        catch (System.Exception ex)
                        {
                            ntf1.Text = "A data e o tempo não foram sincronizados.";
                        }
                    }
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default; //restore the old cursor
            }
        }

        private void btnSincronizarHorarioServidor_Click(object sender, EventArgs e)
        {
            mtdSincronizarHorarioServidor();
        }

        private string strNumeroInventario = string.Empty;
        private string strDataInventario = string.Empty;
        private string strTRGItem = string.Empty;
        private string strCentroCustoItem = string.Empty;
        private string strOrgaoItem = string.Empty;
        private string strSalaItem = string.Empty;
        private string strNomeItem = string.Empty;
        private string strMatriculaItem = string.Empty;
        private string strPatrimonioItem = string.Empty;
        private string strQuantidadeItem = string.Empty;
        private string strDenominacaoItem = string.Empty;
        private string strNSerieItem = string.Empty;
        private string strPlacaVeiculoItem = string.Empty;
        private string strIdentificacaoItem = string.Empty;
        private string strOutrosDadosItem = string.Empty;
        //private string strObservacaoItem = string.Empty;
        private string strUsuarioInventario = string.Empty;
        private string strMatriculaInventario = string.Empty;
        private string strNomeDispositivo = string.Empty;
        //private byte[] vbytFotografia;
        private string strGPSLatitute = string.Empty;
        private string strGPSLongitude = string.Empty;
        private string strEllipsoidAltitude = string.Empty;
        private string strGPSPositionDilutionOfPrecision = string.Empty;

        private bool blnIdentificacaoItemA = false;
        private bool blnOutrosDadosItemA = false;
        private bool blnTRGItemA = false;
        private bool blnCentroCustoItemA = false;
        private bool blnOrgaoItemA = false;
        private bool blnSalaItemA = false;
        private bool blnNomeItemA = false;
        private bool blnMatriculaItemA = false;
        private bool blnPatrimonioItemA = false;
        private bool blnQuantidadeItemA = false;
        private bool blnDenominacaoItemA = false;
        private bool blnNSerieItemA = false;
        private bool blnPlacaVeiculoItemA = false;
        private bool blnObservacaoItemA = false;

        private void chkModoOtimizadoCadastro_Click(object sender, EventArgs e)
        {
            mtdRegistroModoOtimizadoCadastro();
        }

        private void chkProcuraAutomatica_Click(object sender, EventArgs e)
        {
            objRegistroWindows.mtdSalvarDadosRegistro
            (
            Microsoft.Win32.Registry.CurrentUser,
            "Software",
            "Eletronorte",
            "ColetorDados",
            "ProcuraAutomatica",
            chkProcuraAutomatica.Checked.ToString(),
            Microsoft.Win32.RegistryValueKind.String
            );

            blnProcuraAutomatica = chkProcuraAutomatica.Checked;
        }

        private void chkIncrementarPatrimonio_Click(object sender, EventArgs e)
        {
            objRegistroWindows.mtdSalvarDadosRegistro
            (
            Microsoft.Win32.Registry.CurrentUser,
            "Software",
            "Eletronorte",
            "ColetorDados",
            "IncrementarPatrimonio",
            chkIncrementarPatrimonio.Checked.ToString(),
            Microsoft.Win32.RegistryValueKind.String
            );

            blnIncrementarPatrimonio = chkIncrementarPatrimonio.Checked;
        }

        private void mtdCarregarPermitirEscritaColuna()
        {
            blnIdentificacaoItemA = btnIdentificacaoItemA.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192));
            blnOutrosDadosItemA = btnOutrosDadosItemA.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192));
            blnTRGItemA = btnTRGItemA.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0));
            blnCentroCustoItemA = btnCentroCustoItemA.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0));
            blnOrgaoItemA = btnOrgaoItemA.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0));
            blnSalaItemA = btnSalaItemA.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0));
            blnNomeItemA = btnNomeItemA.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0));
            blnMatriculaItemA = btnMatriculaItemA.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0));
            blnPatrimonioItemA = btnPatrimonioItemA.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192));
            blnDenominacaoItemA = btnDenominacaoItemA.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192));
            blnNSerieItemA = btnNSerieItemA.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192));
            blnPlacaVeiculoItemA = btnPlacaVeiculoItemA.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192));
            blnObservacaoItemA = btnObservacaoItemRecuar.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192));
        }

        private void mtdUsuarioInventario_TextChanged(string UsuarioInventario)
        {
            objRegistroWindows.mtdSalvarDadosRegistro
                (
                Microsoft.Win32.Registry.CurrentUser,
                "Software",
                "Eletronorte",
                "ColetorDados",
                "UsuarioInventario",
                UsuarioInventario,
                Microsoft.Win32.RegistryValueKind.String
                );
        }

        private void mtdMatriculaInventario_TextChanged(string MatriculaInventario)
        {
            objRegistroWindows.mtdSalvarDadosRegistro
                (
                Microsoft.Win32.Registry.CurrentUser,
                "Software",
                "Eletronorte",
                "ColetorDados",
                "MatriculaInventario",
                MatriculaInventario,
                Microsoft.Win32.RegistryValueKind.String
                );
        }

        private void mtdPatrimonioItemDenominacaoItemNSerieItem_TextChanged()
        {
            if (btnModoCadastroInventario.Text.Equals("Modo &Inventário"))
            {
                cmbObservacaoItem.Text = btnObservacaoItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192)) ?
                    cmbObservacaoItem.Items[13].ToString() :
                    cmbObservacaoItem.Text;
            }
            else
            {
                cmbObservacaoItem.Text = btnObservacaoItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192)) ?
                    cmbObservacaoItem.Items[0].ToString() :
                    cmbObservacaoItem.Text;
            }
        }

        private void cmbPatrimonioItem_TextChanged(object sender, EventArgs e)
        {
            mtdPatrimonioItemDenominacaoItemNSerieItem_TextChanged();
        }

        private void cmbDenominacaoItem_TextChanged(object sender, EventArgs e)
        {
            mtdPatrimonioItemDenominacaoItemNSerieItem_TextChanged();
        }

        private void cmbNSerieItem_TextChanged(object sender, EventArgs e)
        {
            mtdPatrimonioItemDenominacaoItemNSerieItem_TextChanged();
        }

        private void txtUsuarioInventario_TextChanged(object sender, EventArgs e)
        {
            mtdUsuarioInventario_TextChanged(txtUsuarioInventario.Text);
        }

        private void txtMatriculaInventario_TextChanged(object sender, EventArgs e)
        {
            mtdMatriculaInventario_TextChanged(txtMatriculaInventario.Text);
        }

        private void txtPatrimonioItem_TextChanged(object sender, EventArgs e)
        {
            mtdPatrimonioItemDenominacaoItemNSerieItem_TextChanged();
        }

        private void txtDenominacaoItem_TextChanged(object sender, EventArgs e)
        {
            mtdPatrimonioItemDenominacaoItemNSerieItem_TextChanged();
        }

        private void txtNSerieItem_TextChanged(object sender, EventArgs e)
        {
            mtdPatrimonioItemDenominacaoItemNSerieItem_TextChanged();
        }

        private void mtdVisualizarMapa()
        {
            try
            {
                clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                            (
                            clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                            );

                objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                    (
                    clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                    strBaseDadosColetor,
                    strSenhaColetor
                    );

                objImplementacaoBancoDados.mtdSelecionarDados
                    (
                    vetCamposTabelaInventarioBens,
                    strTabelaInventarioBens,
                    vetCamposTabelaInventarioBens[0],
                    "LIKE",
                    Convert.ToString(dtg1[dtg1.CurrentCell.RowNumber, intColunaTabelaInventarioBensNumero_Inventario])
                    );

                objImplementacaoBancoDados.mtdDefinirLeitorDados();
                objImplementacaoBancoDados.mtdProximoRegistro();

                mtdMapa
                           (
                           Convert.ToString(objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensGPS_Latitute)),
                           Convert.ToString(objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensGPS_Longitude)),
                           Convert.ToString(tcbMapa.Value),
                           Convert.ToString(wbMapa.Size.Width - 10),
                           Convert.ToString(wbMapa.Size.Height - 15),
                           Convert.ToString(objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensPatrimonio)),
                           (TipoMapa)cmbTipoMapa.SelectedItem,
                           Convert.ToString(false)
                           );

                objImplementacaoBancoDados.Dispose();
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdVisualizarMapa: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void btnVisualizarMapa_Click(object sender, EventArgs e)
        {
            mtdVisualizarMapa();
        }

        private void mtdSenhaBaseDados()
        {
            //strSenhaColetor = txtSenhaBaseDados.Text;

            try
            {
                string tmpStrSenhaColetor = objRegistroWindows.mtdObterDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "ColetorDados",
                    "SenhaBaseDados"
                    ).ToString();

                if (!tmpStrSenhaColetor.Equals(string.Empty))
                {
                    strSenhaColetor = tmpStrSenhaColetor;
                }
                txtSenhaBaseDados.Text = strSenhaColetor;
            }
            catch (System.Exception ex)
            {
                txtSenhaBaseDados.Text = strSenhaColetor;
                objRegistroWindows.mtdSalvarDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "ColetorDados",
                    "SenhaBaseDados",
                    txtSenhaBaseDados.Text,
                    Microsoft.Win32.RegistryValueKind.String
                    );
                string strExcecao = "mtdSenhaBaseDados: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void mtdEnderecoBaseDados()
        {
            strBaseDadosColetor = frmPrincipal.DiretorioArmazenamentoCompleto + strNomeBancoDadosColetor + cntExtensaoBancoDadosColetor;

            try
            {
                string tmpStrBaseDadosColetor = objRegistroWindows.mtdObterDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "ColetorDados",
                    "BaseDados"
                    ).ToString();

                if (!tmpStrBaseDadosColetor.Equals(string.Empty))
                {
                    strBaseDadosColetor = tmpStrBaseDadosColetor;
                }
                txtEnderecoBaseDados.Text = strBaseDadosColetor;
            }
            catch (System.Exception ex)
            {
                txtEnderecoBaseDados.Text = strBaseDadosColetor;
                objRegistroWindows.mtdSalvarDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "ColetorDados",
                    "BaseDados",
                    txtEnderecoBaseDados.Text,
                    Microsoft.Win32.RegistryValueKind.String
                    );
                string strExcecao = "mtdEnderecoBaseDados: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
            finally
            {
                mtdGerarNomeEnderecoBancoDados();
            }
        }

        private void mtdNumeroLinhas()
        {
            try
            {
                string tmpStrNumeroLinhas = objRegistroWindows.mtdObterDadosRegistro
                         (
                         Microsoft.Win32.Registry.CurrentUser,
                         "Software",
                         "Eletronorte",
                         "ColetorDados",
                         "NumeroLinhas"
                         ).ToString();

                if (!tmpStrNumeroLinhas.Equals(string.Empty))
                {
                    uintNumeroLinhas = uint.Parse(tmpStrNumeroLinhas);
                }
                txtNumeroLinhas.Text = uintNumeroLinhas.ToString();
            }
            catch (System.Exception ex)
            {
                txtNumeroLinhas.Text = uintNumeroLinhas.ToString();
                objRegistroWindows.mtdSalvarDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "ColetorDados",
                    "NumeroLinhas",
                    txtNumeroLinhas.Text,
                    Microsoft.Win32.RegistryValueKind.String
                    );
                string strExcecao = "mtdNumeroLinhas: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void mtdComprimentoColunas()
        {
            try
            {
                string tmpStrComprimentoColunas = objRegistroWindows.mtdObterDadosRegistro
                         (
                         Microsoft.Win32.Registry.CurrentUser,
                         "Software",
                         "Eletronorte",
                         "ColetorDados",
                         "ComprimentoColunas"
                         ).ToString();

                if (!tmpStrComprimentoColunas.Equals(string.Empty))
                {
                    uintComprimentoColunas = uint.Parse(tmpStrComprimentoColunas);
                }
                txtComprimentoColunas.Text = uintComprimentoColunas.ToString();
            }
            catch (System.Exception ex)
            {
                txtComprimentoColunas.Text = uintComprimentoColunas.ToString();
                objRegistroWindows.mtdSalvarDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "ColetorDados",
                    "ComprimentoColunas",
                    txtComprimentoColunas.Text,
                    Microsoft.Win32.RegistryValueKind.String
                    );
                string strExcecao = "mtdComprimentoColunas: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void mtdNumeroCopiasBackup()
        {
            try
            {
                string tmpStrNumeroCopiasBackup = objRegistroWindows.mtdObterDadosRegistro
                         (
                         Microsoft.Win32.Registry.CurrentUser,
                         "Software",
                         "Eletronorte",
                         "ColetorDados",
                         "NumeroCopiasBackup"
                         ).ToString();

                if (!tmpStrNumeroCopiasBackup.Equals(string.Empty))
                {
                    uintNumeroCopiasBackup = uint.Parse(tmpStrNumeroCopiasBackup);
                }
                txtNumeroCopiasBackup.Text = uintNumeroCopiasBackup.ToString();
            }
            catch (System.Exception ex)
            {
                txtNumeroCopiasBackup.Text = uintNumeroCopiasBackup.ToString();
                objRegistroWindows.mtdSalvarDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "ColetorDados",
                    "NumeroCopiasBackup",
                    txtNumeroCopiasBackup.Text,
                    Microsoft.Win32.RegistryValueKind.String
                    );
                string strExcecao = "mtdNumeroCopiasBackup: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void mtdTemporizador()
        {
            try
            {
                string tmpStrTemporizador = objRegistroWindows.mtdObterDadosRegistro
                         (
                         Microsoft.Win32.Registry.CurrentUser,
                         "Software",
                         "Eletronorte",
                         "ColetorDados",
                         "Temporizador"
                         ).ToString();

                if (!tmpStrTemporizador.Equals(string.Empty))
                {
                    uintTemporizador = uint.Parse(tmpStrTemporizador);
                }
                txtTemporizador.Text = uintTemporizador.ToString();
            }
            catch (System.Exception ex)
            {
                txtTemporizador.Text = uintTemporizador.ToString();
                objRegistroWindows.mtdSalvarDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "ColetorDados",
                    "Temporizador",
                    txtTemporizador.Text,
                    Microsoft.Win32.RegistryValueKind.String
                    );
                string strExcecao = "mtdTemporizador: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void mtdPermitirExibicaoNotificacoes()
        {
            try
            {
                chkPermitirExibicaoNotificacoes.Checked = bool.Parse
                    (
                    objRegistroWindows.mtdObterDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "ColetorDados",
                    "PermitirExibicaoNotificacoes"
                    ).ToString()
                    );
            }
            catch (System.Exception ex)
            {
                chkPermitirExibicaoNotificacoes.Checked = true;
                objRegistroWindows.mtdSalvarDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "ColetorDados",
                    "PermitirExibicaoNotificacoes",
                    chkPermitirExibicaoNotificacoes.Checked.ToString(),
                    Microsoft.Win32.RegistryValueKind.String
                    );
                string strExcecao = "mtdPermitirExibicaoNotificacoes: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }

            ntf1.InitialDuration = 5;
            ntf1.Critical = chkPermitirExibicaoNotificacoes.Checked;
            ntf1.Visible = chkPermitirExibicaoNotificacoes.Checked;
        }

        private bool blnProcuraAutomatica = false;

        private void mtdProcuraAutomatica()
        {
            try
            {
                chkProcuraAutomatica.Checked = bool.Parse
                    (
                    objRegistroWindows.mtdObterDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "ColetorDados",
                    "ProcuraAutomatica"
                    ).ToString()
                    );
            }
            catch (System.Exception ex)
            {
                chkProcuraAutomatica.Checked = true;
                objRegistroWindows.mtdSalvarDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "ColetorDados",
                    "ProcuraAutomatica",
                    chkProcuraAutomatica.Checked.ToString(),
                    Microsoft.Win32.RegistryValueKind.String
                    );
                string strExcecao = "mtdProcuraAutomatica: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }

            blnProcuraAutomatica = chkProcuraAutomatica.Checked;
        }

        private bool blnIncrementarPatrimonio = false;

        private void mtdIncrementarPatrimonio()
        {
            try
            {
                chkIncrementarPatrimonio.Checked = bool.Parse
                    (
                    objRegistroWindows.mtdObterDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "ColetorDados",
                    "IncrementarPatrimonio"
                    ).ToString()
                    );
            }
            catch (System.Exception ex)
            {
                chkIncrementarPatrimonio.Checked = true;
                objRegistroWindows.mtdSalvarDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "ColetorDados",
                    "IncrementarPatrimonio",
                    chkIncrementarPatrimonio.Checked.ToString(),
                    Microsoft.Win32.RegistryValueKind.String
                    );
                string strExcecao = "mtdIncrementarPatrimonio: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }

            blnIncrementarPatrimonio = chkIncrementarPatrimonio.Checked;
        }

        private void mtdModoOtimizadoCadastro()
        {
            try
            {
                chkModoOtimizadoCadastro.Checked = bool.Parse
                    (
                    objRegistroWindows.mtdObterDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "ColetorDados",
                    "ModoOtimizadoCadastro"
                    ).ToString()
                    );
            }
            catch (System.Exception ex)
            {
                chkModoOtimizadoCadastro.Checked = false;
                objRegistroWindows.mtdSalvarDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "ColetorDados",
                    "ModoOtimizadoCadastro",
                    chkModoOtimizadoCadastro.Checked.ToString(),
                    Microsoft.Win32.RegistryValueKind.String
                    );
                string strExcecao = "mtdModoOtimizadoCadastro: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
            finally
            {
                if (chkModoOtimizadoCadastro.Checked)
                {
                    cmbPrioridadeModoOtimizadoCadastro.Enabled = false;

                    btnDenominacaoItem.ForeColor = Color.FromArgb(192, 0, 0);
                    btnNSerieItem.ForeColor = Color.FromArgb(192, 0, 0);
                    btnPlacaVeiculoItem.ForeColor = Color.FromArgb(192, 0, 0);
                    txtDenominacaoItem.Text = string.Empty;
                    txtNSerieItem.Text = string.Empty;
                    txtPlacaVeiculoItem.Text = string.Empty;

                    mtdIniciarThreadCadastroOtimizado();
                }
                else
                {
                    cmbPrioridadeModoOtimizadoCadastro.Enabled = true;

                    btnDenominacaoItem.ForeColor = Color.FromArgb(0, 0, 192);
                    btnNSerieItem.ForeColor = Color.FromArgb(0, 0, 192);
                    btnPlacaVeiculoItem.ForeColor = Color.FromArgb(0, 0, 192);

                    btnTRGItem.ForeColor = Color.FromArgb(0, 192, 0);
                    btnCentroCustoItem.ForeColor = Color.FromArgb(0, 192, 0);
                    btnOrgaoItem.ForeColor = Color.FromArgb(0, 192, 0);
                    btnSalaItem.ForeColor = Color.FromArgb(0, 192, 0);
                    btnNomeItem.ForeColor = Color.FromArgb(0, 192, 0);
                    btnMatriculaItem.ForeColor = Color.FromArgb(0, 192, 0);

                    mtdAbortarThreadCadastroOtimizado(true);
                }
            }
        }

        private void mtdChecarModoOtimizadoCadastro()
        {
            if (chkModoOtimizadoCadastro.Checked)
            {
                chkModoOtimizadoCadastro.Checked = false;
            }
            else
            {
                chkModoOtimizadoCadastro.Checked = true;
            }
        }

        private void mtdRegistroModoOtimizadoCadastro()
        {
            if (chkModoOtimizadoCadastro.Checked)
            {
                cmbPrioridadeModoOtimizadoCadastro.Enabled = false;

                btnDenominacaoItem.ForeColor = Color.FromArgb(192, 0, 0);
                btnNSerieItem.ForeColor = Color.FromArgb(192, 0, 0);
                btnPlacaVeiculoItem.ForeColor = Color.FromArgb(192, 0, 0);
                txtDenominacaoItem.Text = string.Empty;
                txtNSerieItem.Text = string.Empty;
                txtPlacaVeiculoItem.Text = string.Empty;

                if (blnProcuraAutomatica)
                {
                    mtdIniciarThreadCadastroOtimizado();
                }
                else
                {
                    mtdAbortarThreadCadastroOtimizado(true);
                }
            }
            else
            {
                cmbPrioridadeModoOtimizadoCadastro.Enabled = true;

                btnDenominacaoItem.ForeColor = Color.FromArgb(0, 0, 192);
                btnNSerieItem.ForeColor = Color.FromArgb(0, 0, 192);
                btnPlacaVeiculoItem.ForeColor = Color.FromArgb(0, 0, 192);

                btnTRGItem.ForeColor = Color.FromArgb(0, 192, 0);
                btnCentroCustoItem.ForeColor = Color.FromArgb(0, 192, 0);
                btnOrgaoItem.ForeColor = Color.FromArgb(0, 192, 0);
                btnSalaItem.ForeColor = Color.FromArgb(0, 192, 0);
                btnNomeItem.ForeColor = Color.FromArgb(0, 192, 0);
                btnMatriculaItem.ForeColor = Color.FromArgb(0, 192, 0);

                mtdAbortarThreadCadastroOtimizado(true);
            }

            objRegistroWindows.mtdSalvarDadosRegistro
                (
                Microsoft.Win32.Registry.CurrentUser,
                "Software",
                "Eletronorte",
                "ColetorDados",
                "ModoOtimizadoCadastro",
                chkModoOtimizadoCadastro.Checked.ToString(),
                Microsoft.Win32.RegistryValueKind.String
                );
        }

        private void mtdModoCadastroInventario()
        {
            btnModoCadastroInventario.Text = objRegistroWindows.mtdObterDadosRegistro
                (
                Microsoft.Win32.Registry.CurrentUser,
                "Software",
                "Eletronorte",
                "ColetorDados",
                "ModoCadastroInventario"
                ).ToString();

            if (!btnModoCadastroInventario.Text.Equals(string.Empty))
            {

                if (btnModoCadastroInventario.Text.Equals("Modo &Inventário"))
                {
                    btnModoCadastroInventario.ForeColor = Color.FromArgb(128, 128, 255);
                }
                else
                {
                    btnModoCadastroInventario.ForeColor = Color.Olive;
                }
            }
            else
            {
                btnModoCadastroInventario.Text = "Modo &Inventário";

                objRegistroWindows.mtdSalvarDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "ColetorDados",
                    "ModoCadastroInventario",
                    btnModoCadastroInventario.Text,
                    Microsoft.Win32.RegistryValueKind.String
                    );

                if (btnModoCadastroInventario.Text.Equals("Modo &Inventário"))
                {
                    btnModoCadastroInventario.ForeColor = Color.FromArgb(128, 128, 255);
                }
                else
                {
                    btnModoCadastroInventario.ForeColor = Color.Olive;
                }
            }
        }

        private void mtdUsuarioInventario()
        {
            try
            {
                txtUsuarioInventario.Text = objRegistroWindows.mtdObterDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "ColetorDados",
                    "UsuarioInventario"
                    ).ToString();
            }
            catch (System.Exception ex)
            {
                objRegistroWindows.mtdSalvarDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "ColetorDados",
                    "UsuarioInventario",
                    txtUsuarioInventario.Text,
                    Microsoft.Win32.RegistryValueKind.String
                    );
                string strExcecao = "mtdUsuarioInventario: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void mtdMatriculaInventario()
        {
            try
            {
                txtMatriculaInventario.Text = objRegistroWindows.mtdObterDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "ColetorDados",
                    "MatriculaInventario"
                    ).ToString();
            }
            catch (System.Exception ex)
            {
                objRegistroWindows.mtdSalvarDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "ColetorDados",
                    "MatriculaInventario",
                    txtMatriculaInventario.Text,
                    Microsoft.Win32.RegistryValueKind.String
                    );
                string strExcecao = "mtdMatriculaInventario: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void mtdQualidadeFotografia()
        {
            try
            {
                cmbQualidadeFotografia.Text = objRegistroWindows.mtdObterDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "ColetorDados",
                    "QualidadeFotografia"
                    ).ToString();

                if (cmbQualidadeFotografia.Text.Equals(string.Empty))
                {
                    cmbQualidadeFotografia.Text = cmbQualidadeFotografia.Items[0].ToString();
                    objRegistroWindows.mtdSalvarDadosRegistro
                        (
                        Microsoft.Win32.Registry.CurrentUser,
                        "Software",
                        "Eletronorte",
                        "ColetorDados",
                        "QualidadeFotografia",
                        cmbQualidadeFotografia.Text,
                        Microsoft.Win32.RegistryValueKind.String
                        );
                }
            }
            catch (System.Exception ex)
            {
                cmbQualidadeFotografia.Text = cmbQualidadeFotografia.Items[0].ToString();
                objRegistroWindows.mtdSalvarDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "ColetorDados",
                    "QualidadeFotografiaFotografia",
                    cmbQualidadeFotografia.Text,
                    Microsoft.Win32.RegistryValueKind.String
                    );
                string strExcecao = "mtdQualidadeFotografia: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void mtdResolucaoFotografia()
        {
            try
            {
                cmbResolucaoFotografia.Text = objRegistroWindows.mtdObterDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "ColetorDados",
                    "ResolucaoFotografia"
                    ).ToString();

                if (cmbResolucaoFotografia.Text.Equals(string.Empty))
                {
                    cmbResolucaoFotografia.Text = cmbResolucaoFotografia.Items[1].ToString();
                    objRegistroWindows.mtdSalvarDadosRegistro
                        (
                        Microsoft.Win32.Registry.CurrentUser,
                        "Software",
                        "Eletronorte",
                        "ColetorDados",
                        "ResolucaoFotografia",
                        cmbResolucaoFotografia.Text,
                        Microsoft.Win32.RegistryValueKind.String
                        );
                }
            }
            catch (System.Exception ex)
            {
                cmbResolucaoFotografia.Text = cmbResolucaoFotografia.Items[1].ToString();
                objRegistroWindows.mtdSalvarDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "ColetorDados",
                    "ResolucaoFotografia",
                    cmbResolucaoFotografia.Text,
                    Microsoft.Win32.RegistryValueKind.String
                    );
                string strExcecao = "mtdResolucaoFotografia: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void mtdPrioridadeModoOtimizadoCadastro()
        {
            try
            {
                cmbPrioridadeModoOtimizadoCadastro.Text = objRegistroWindows.mtdObterDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "ColetorDados",
                    "PrioridadeModoOtimizadoCadastro"
                    ).ToString();

                if (cmbPrioridadeModoOtimizadoCadastro.Text.Equals(string.Empty))
                {
                    cmbPrioridadeModoOtimizadoCadastro.Text = cmbPrioridadeModoOtimizadoCadastro.Items[0].ToString();
                    objRegistroWindows.mtdSalvarDadosRegistro
                        (
                        Microsoft.Win32.Registry.CurrentUser,
                        "Software",
                        "Eletronorte",
                        "ColetorDados",
                        "PrioridadeModoOtimizadoCadastro",
                        cmbPrioridadeModoOtimizadoCadastro.Text,
                        Microsoft.Win32.RegistryValueKind.String
                        );
                }
            }
            catch (System.Exception ex)
            {
                cmbPrioridadeModoOtimizadoCadastro.Text = cmbPrioridadeModoOtimizadoCadastro.Items[1].ToString();
                objRegistroWindows.mtdSalvarDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "ColetorDados",
                    "PrioridadeModoOtimizadoCadastro",
                    cmbPrioridadeModoOtimizadoCadastro.Text,
                    Microsoft.Win32.RegistryValueKind.String
                    );
                string strExcecao = "mtdPrioridadeModoOtimizadoCadastro: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        //private void mtdEnderecoProxy()
        //{
        //    try
        //    {
        //        txtEnderecoProxy.Text = objRegistroWindows.mtdObterDadosRegistro
        //            (
        //            Microsoft.Win32.Registry.CurrentUser,
        //            "Software",
        //            "Eletronorte",
        //            "ColetorDados",
        //            "EnderecoProxy"
        //            ).ToString();
        //    }
        //    catch (System.Exception ex)
        //    {
        //        objRegistroWindows.mtdSalvarDadosRegistro
        //            (
        //            Microsoft.Win32.Registry.CurrentUser,
        //            "Software",
        //            "Eletronorte",
        //            "ColetorDados",
        //            "EnderecoProxy",
        //            txtEnderecoProxy.Text,
        //            Microsoft.Win32.RegistryValueKind.String
        //            );
        //        string strExcecao = "mtdEnderecoProxy: " + ex.Message;
        //        System.Diagnostics.Debug.WriteLine(strExcecao);
        //        //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
        //    }
        //}

        //private void mtdPortaProxy()
        //{
        //    try
        //    {
        //        txtPortaProxy.Text = objRegistroWindows.mtdObterDadosRegistro
        //            (
        //            Microsoft.Win32.Registry.CurrentUser,
        //            "Software",
        //            "Eletronorte",
        //            "ColetorDados",
        //            "PortaProxy"
        //            ).ToString();
        //    }
        //    catch (System.Exception ex)
        //    {
        //        objRegistroWindows.mtdSalvarDadosRegistro
        //            (
        //            Microsoft.Win32.Registry.CurrentUser,
        //            "Software",
        //            "Eletronorte",
        //            "ColetorDados",
        //            "PortaProxy",
        //            txtPortaProxy.Text,
        //            Microsoft.Win32.RegistryValueKind.String
        //            );
        //        string strExcecao = "mtdPortaProxy: " + ex.Message;
        //        System.Diagnostics.Debug.WriteLine(strExcecao);
        //        //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
        //    }
        //}

        //private void mtdDominioProxy()
        //{
        //    try
        //    {
        //        txtDominioProxy.Text = objRegistroWindows.mtdObterDadosRegistro
        //            (
        //            Microsoft.Win32.Registry.CurrentUser,
        //            "Software",
        //            "Eletronorte",
        //            "ColetorDados",
        //            "DominioProxy"
        //            ).ToString();
        //    }
        //    catch (System.Exception ex)
        //    {
        //        objRegistroWindows.mtdSalvarDadosRegistro
        //            (
        //            Microsoft.Win32.Registry.CurrentUser,
        //            "Software",
        //            "Eletronorte",
        //            "ColetorDados",
        //            "DominioProxy",
        //            txtDominioProxy.Text,
        //            Microsoft.Win32.RegistryValueKind.String
        //            );
        //        string strExcecao = "mtdDominioProxy: " + ex.Message;
        //        System.Diagnostics.Debug.WriteLine(strExcecao);
        //        //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
        //    }
        //}

        //private void mtdUsuarioProxy()
        //{
        //    try
        //    {
        //        txtUsuarioProxy.Text = objRegistroWindows.mtdObterDadosRegistro
        //            (
        //            Microsoft.Win32.Registry.CurrentUser,
        //            "Software",
        //            "Eletronorte",
        //            "ColetorDados",
        //            "UsuarioProxy"
        //            ).ToString();
        //    }
        //    catch (System.Exception ex)
        //    {
        //        objRegistroWindows.mtdSalvarDadosRegistro
        //            (
        //            Microsoft.Win32.Registry.CurrentUser,
        //            "Software",
        //            "Eletronorte",
        //            "ColetorDados",
        //            "UsuarioProxy",
        //            txtUsuarioProxy.Text,
        //            Microsoft.Win32.RegistryValueKind.String
        //            );
        //        string strExcecao = "mtdUsuarioProxy: " + ex.Message;
        //        System.Diagnostics.Debug.WriteLine(strExcecao);
        //        //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
        //    }
        //}

        //private void mtdSenhaProxy()
        //{
        //    try
        //    {
        //        txtSenhaProxy.Text = objRegistroWindows.mtdObterDadosRegistro
        //            (
        //            Microsoft.Win32.Registry.CurrentUser,
        //            "Software",
        //            "Eletronorte",
        //            "ColetorDados",
        //            "SenhaProxy"
        //            ).ToString();
        //    }
        //    catch (System.Exception ex)
        //    {
        //        objRegistroWindows.mtdSalvarDadosRegistro
        //            (
        //            Microsoft.Win32.Registry.CurrentUser,
        //            "Software",
        //            "Eletronorte",
        //            "ColetorDados",
        //            "SenhaProxy",
        //            txtSenhaProxy.Text,
        //            Microsoft.Win32.RegistryValueKind.String
        //            );
        //        string strExcecao = "mtdSenhaProxy: " + ex.Message;
        //        System.Diagnostics.Debug.WriteLine(strExcecao);
        //        //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
        //    }
        //}

        private void mtdCarregarCmbCCSQ()
        {
            Microsoft.WindowsMobile.Forms.CameraCaptureStillQuality[] CCSQ = new Microsoft.WindowsMobile.Forms.CameraCaptureStillQuality[3];

            CCSQ[0] = Microsoft.WindowsMobile.Forms.CameraCaptureStillQuality.Low;
            CCSQ[1] = Microsoft.WindowsMobile.Forms.CameraCaptureStillQuality.Normal;
            CCSQ[2] = Microsoft.WindowsMobile.Forms.CameraCaptureStillQuality.High;

            cmbQualidadeFotografia.Items.Clear();

            for (int contador = CCSQ.GetLowerBound(0); contador <= CCSQ.GetUpperBound(0); contador++)
            {
                cmbQualidadeFotografia.Items.Add(CCSQ[contador]);
            }

            cmbQualidadeFotografia.SelectedIndex = 0;
        }

        private void mtdCarregarCmbObservacaoItem()
        {
            cmbObservacaoItem.Items.Clear();
            cmbObservacaoItem.Items.Add("CADASTRO");
            cmbObservacaoItem.Items.Add("NAO CADASTRADO");
            cmbObservacaoItem.Items.Add("BEM NOVO");
            cmbObservacaoItem.Items.Add("BOM (BEM EM USO)");
            cmbObservacaoItem.Items.Add("REGULAR (BEM EM USO)");
            cmbObservacaoItem.Items.Add("PESSIMO (FORA DE USO)");
            cmbObservacaoItem.Items.Add("CADASTRO COM PLAQUETA COM CODIGO DE BARRA");
            cmbObservacaoItem.Items.Add("BEM NOVO COM PLAQUETA COM CODIGO DE BARRA");
            cmbObservacaoItem.Items.Add("BOM (BEM EM USO) COM PLAQUETA COM CODIGO DE BARRA");
            cmbObservacaoItem.Items.Add("REGULAR (BEM EM USO) COM PLAQUETA COM CODIGO DE BARRA");
            cmbObservacaoItem.Items.Add("PESSIMO (FORA DE USO) COM PLAQUETA COM CODIGO DE BARRA");
            cmbObservacaoItem.Items.Add("CADASTRO SEM PLAQUETA COM CODIGO DE BARRA");
            cmbObservacaoItem.Items.Add("BEM NOVO SEM PLAQUETA COM CODIGO DE BARRA");
            cmbObservacaoItem.Items.Add("BOM (BEM EM USO) SEM PLAQUETA COM CODIGO DE BARRA");
            cmbObservacaoItem.Items.Add("REGULAR (BEM EM USO) SEM PLAQUETA COM CODIGO DE BARRA");
            cmbObservacaoItem.Items.Add("PESSIMO (FORA DE USO) SEM PLAQUETA COM CODIGO DE BARRA");
        }

        private void mtdCarregarCmbResolucaoFotografia()
        {
            cmbResolucaoFotografia.Items.Clear();
            cmbResolucaoFotografia.Items.Add("320x240");
            cmbResolucaoFotografia.Items.Add("640x480");
            cmbResolucaoFotografia.Items.Add("800x600");
            cmbResolucaoFotografia.Items.Add("1024x768");
            cmbResolucaoFotografia.SelectedIndex = 1;
        }

        private void mtdCarregarCmbTipoMapa()
        {
            cmbTipoMapa.Items.Clear();
            cmbTipoMapa.Items.Add(TipoMapa.RoadMap);
            cmbTipoMapa.Items.Add(TipoMapa.Satellite);
            cmbTipoMapa.Items.Add(TipoMapa.Terrain);
            cmbTipoMapa.Items.Add(TipoMapa.Hybrid);
            cmbTipoMapa.SelectedIndex = 0;
        }

        private void mtdCarregarCmbConsultarTabelaRelatorio()
        {
            cmbConsultarTabelaRelatorio.Items.Clear();
            cmbConsultarTabelaRelatorio.Items.Add(strTabelaInventarioBens.Replace("tbl", string.Empty));
            cmbConsultarTabelaRelatorio.Items.Add(strTabelaBensEletronorte.Replace("tbl", string.Empty));
            cmbConsultarTabelaRelatorio.Items.Add(strTabelaEmpregados.Replace("tbl", string.Empty));
            cmbConsultarTabelaRelatorio.Items.Add(strTabelaCentroCusto.Replace("tbl", string.Empty));
            cmbConsultarTabelaRelatorio.SelectedIndex = 0;
        }

        private void mtdCarregarCmbPrioridadeModoOtimizadoCadastro()
        {
            cmbPrioridadeModoOtimizadoCadastro.Items.Clear();
            cmbPrioridadeModoOtimizadoCadastro.Items.Add(System.Threading.ThreadPriority.Lowest);
            cmbPrioridadeModoOtimizadoCadastro.Items.Add(System.Threading.ThreadPriority.BelowNormal);
            cmbPrioridadeModoOtimizadoCadastro.Items.Add(System.Threading.ThreadPriority.Normal);
            cmbPrioridadeModoOtimizadoCadastro.Items.Add(System.Threading.ThreadPriority.AboveNormal);
            cmbPrioridadeModoOtimizadoCadastro.Items.Add(System.Threading.ThreadPriority.Highest);
            cmbPrioridadeModoOtimizadoCadastro.SelectedIndex = 0;
        }

        public void mtdCarregarCmb(ref System.Windows.Forms.ComboBox Cmb, string Sql)
        {
            try
            {
                clsImplementacaoBancoDados objImplementacaoBancoDados =
                    new clsImplementacaoBancoDados
                   (
                   clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                   );

                objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                    (
                    clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                    strBaseDadosColetor,
                    strSenhaColetor
                    );

                objImplementacaoBancoDados.mtdAbrirConexao();
                objImplementacaoBancoDados.mtdExecutarComando
                    (
                    Sql
                    );
                int numlinhas = objImplementacaoBancoDados.mtdNumeroLinhas() - 1;
                objImplementacaoBancoDados.mtdDefinirLeitorDados();
                objImplementacaoBancoDados.mtdProximoRegistro();
                // objBancoDadosColetor.mtdAdaptadorDados()
                // cria tres itens e tres conjuntos de subitems para cada item
                Cmb.Items.Clear();
                int numColuna = objImplementacaoBancoDados.mtdNumeroColunas() - 1;
                for (int contador = 0; contador <= numColuna; contador++)
                {
                    Cmb.Items.Add(objImplementacaoBancoDados.mtdObterCabecalhoColunas(contador));
                }
                Cmb.SelectedIndex = 0;
                objImplementacaoBancoDados.Dispose();
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdCarregarCmb: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void tbc1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mtdSetarTbc1();
        }

        private void tbc2_SelectedIndexChanged(object sender, EventArgs e)
        {
            mtdSetarTbc2();
        }

        private void tbc3_SelectedIndexChanged(object sender, EventArgs e)
        {
            mtdSetarTbc3();
        }

        private void mtdSetarTbc1()
        {
            switch (tbc1.SelectedIndex)
            {
                case 0:
                    mni1.Text = btnModoCadastroInventario.Text == "Modo &Inventário" ? "Inventário" : "Cadastro";
                    mni2.Text = "Sair";
                    break;
                case 1:
                case 2:
                case 3:
                    mni1.Text = "Procurar";
                    mni2.Text = "Cadastrar";
                    break;
                case 4:
                    mtdSetarTbc2();
                    break;
                case 5:
                    mtdSetarTbc3();
                    break;
                case 6:
                    mni1.Text = "Zerar";
                    mni2.Text = "Fotografar";
                    break;
                case 7:
                    mni1.Text = "GPS";
                    mni2.Text = "Sair";
                    break;
                case 8:
                    mni1.Text = "Visualizar";
                    mni2.Text = "Sair";
                    break;
                case 9:
                    mni1.Text = "Monitor";
                    mni2.Text = "Sincronizar";
                    break;
                case 10:
                    mni1.Text = "Permitir";
                    mni2.Text = "Otimizado";
                    break;
                case 11:
                    mni1.Text = "Zerar";
                    mni2.Text = "Sair";
                    break;
                case 12:
                    mni1.Text = "Sair/Backup";
                    mni2.Text = "Sair";
                    break;
            }
        }

        private void mtdSetarTbc2()
        {
            switch (tbc2.SelectedIndex)
            {
                case 0:
                    mni1.Text = "Consultar";
                    mni2.Text = "Alt/Deletar";
                    break;
                case 1:
                case 2:
                case 3:
                    mni1.Text = "Consultar";
                    mni2.Text = "Sair";
                    break;
            }
        }

        private void mtdSetarTbc3()
        {
            switch (tbc3.SelectedIndex)
            {
                case 0:
                    mni1.Text = "Consultar";
                    mni2.Text = "Sair";
                    break;
                case 1:
                    mni1.Text = "Patrimonio";
                    mni2.Text = "N_Serie";
                    break;
                case 2:
                    mni1.Text = "Consultar";
                    mni2.Text = "Sair";
                    break;
            }
        }

        //private void cmbConsultarInventario_TextChanged(object sender, EventArgs e)
        //{
        //    txtConsultarInventario.Focus();
        //}

        //private void cmbConsultarSAP_TextChanged(object sender, EventArgs e)
        //{
        //    txtConsultarSAP.Focus();
        //}

        //private void cmbConsultarEmpregados_TextChanged(object sender, EventArgs e)
        //{
        //    txtConsultarEmpregados.Focus();
        //}

        //private void cmbConsultarCentroCusto_TextChanged(object sender, EventArgs e)
        //{
        //    txtConsultarCentroCusto.Focus();
        //}

        bool blnAlteracaoValorCmbConsultarTabelasRelatorio = false;

        private void cmbConsultarTabelasRelatorio_TextChanged(object sender, EventArgs e)
        {
            blnAlteracaoValorCmbConsultarTabelasRelatorio = true;

            //mtdCarregarCmb
            //    (
            //    ref cmbConsultarCamposRelatorio,
            //    String.Format("SELECT TOP (0) * FROM {0}", string.Format("tbl{0}", cmbConsultarTabelaRelatorio.Text))
            //    );
        }

        //private void cmbConsultarCamposRelatorio_TextChanged(object sender, EventArgs e)
        //{
        //    mtdAtualizarDtg5(cmbConsultarCamposRelatorio.Text, string.Format("tbl{0}", cmbConsultarTabelaRelatorio.Text), uintNumeroLinhas);
        //}

        private void txtEnderecoBaseDados_TextChanged(object sender, EventArgs e)
        {
            objRegistroWindows.mtdSalvarDadosRegistro
                (
                Microsoft.Win32.Registry.CurrentUser,
                "Software",
                "Eletronorte",
                "ColetorDados",
                "BaseDados",
                txtEnderecoBaseDados.Text,
                Microsoft.Win32.RegistryValueKind.String
                );
            strBaseDadosColetor = txtEnderecoBaseDados.Text;

            mtdGerarNomeEnderecoBancoDados();
        }

        private void txtNomeDispositivo_TextChanged(object sender, EventArgs e)
        {
            setDeviceName(txtNomeDispositivo.Text);
        }

        public long mtdObterCodigoEspalhamento(string Dado)
        {
            long saida = 0;
            System.Security.Cryptography.HashAlgorithm algorithm = System.Security.Cryptography.SHA1.Create();
            byte[] vetData = Encoding.Unicode.GetBytes(Dado);
            byte[] vetDataHash = algorithm.ComputeHash(vetData);
            saida = BitConverter.ToInt64(vetDataHash, 0);

            return saida;
        }

        public frmMonitorCarregamentoDados objMonitorCarregamentoDados = new frmMonitorCarregamentoDados();

        private void btnMonitorCarregamentoDados_Click(object sender, EventArgs e)
        {
            cmbPrioridadeModoOtimizadoCadastro.Text = "Lowest";

            for (int contador = vetTh.GetLowerBound(0); contador <= vetTh.GetUpperBound(0); contador++)
            {
                if (vetTh[contador] != null)
                {
                    //if (vetTh[contador].ThreadState == System.Threading.ThreadState.Running)
                    //{
                    try
                    {
                        vetTh[contador].Priority = mtdConverterPrioridadeThread(cmbPrioridadeModoOtimizadoCadastro.Text);
                    }
                    catch (System.Exception ex)
                    {
                        string strExcecao = "btnMonitorCarregamentoDados_Click: " + ex.Message;
                        System.Diagnostics.Debug.WriteLine(strExcecao);
                        //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                    }
                    //}
                }
            }

            try
            {
                objMonitorCarregamentoDados.Show();
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdAbortarThreadForcarParada: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void cmbConsultarInventario_GotFocus(object sender, EventArgs e)
        {
            if (cmbConsultarInventario.Items.Count == 0)
            {
                mtdCarregarCmb
                     (
                     ref cmbConsultarInventario,
                     String.Format("SELECT TOP (0) * FROM {0}", strTabelaInventarioBens)
                     );
            }
        }

        private void cmbConsultarSAP_GotFocus(object sender, EventArgs e)
        {
            if (cmbConsultarSAP.Items.Count == 0)
            {
                mtdCarregarCmb
                    (
                    ref cmbConsultarSAP,
                    string.Format("SELECT TOP (0) {0} FROM {1}", mtdVetorLinhaCampos(vetCamposTabelaBensEletronorte), strTabelaBensEletronorte)
                    );
            }
        }

        private void cmbConsultarEmpregados_GotFocus(object sender, EventArgs e)
        {
            if (cmbConsultarEmpregados.Items.Count == 0)
            {
                mtdCarregarCmb
                    (
                    ref cmbConsultarEmpregados,
                    String.Format("SELECT TOP (0) * FROM {0}", strTabelaEmpregados)
                    );
            }
        }

        private void cmbConsultarCentroCusto_GotFocus(object sender, EventArgs e)
        {
            if (cmbConsultarCentroCusto.Items.Count == 0)
            {
                mtdCarregarCmb
                    (
                    ref cmbConsultarCentroCusto,
                    String.Format("SELECT TOP (0) * FROM {0}", strTabelaCentroCusto)
                    );
            }
        }

        private void cmbConsultarTabelaRelatorio_GotFocus(object sender, EventArgs e)
        {
            blnAlteracaoValorCmbConsultarTabelasRelatorio = false;

            if (cmbConsultarTabelaRelatorio.Items.Count == 0)
            {
                mtdCarregarCmbConsultarTabelaRelatorio();
            }
        }

        private void cmbConsultarCamposRelatorio_GotFocus(object sender, EventArgs e)
        {
            if (cmbConsultarCamposRelatorio.Items.Count == 0 || blnAlteracaoValorCmbConsultarTabelasRelatorio)
            {
                blnAlteracaoValorCmbConsultarTabelasRelatorio = false;

                mtdCarregarCmb
                    (
                    ref cmbConsultarCamposRelatorio,
                    String.Format("SELECT TOP (0) * FROM {0}", string.Format("tbl{0}", cmbConsultarTabelaRelatorio.Text))
                    );
            }
        }

        //private string strEnderecoProxy = string.Empty;
        //private string strPortaProxy = string.Empty;
        //private string strDominioProxy = string.Empty;
        //private string strUsuarioProxy = string.Empty;
        //private string strSenhaProxy = string.Empty;

        //private void txtEnderecoProxy_TextChanged(object sender, EventArgs e)
        //{
        //    objRegistroWindows.mtdSalvarDadosRegistro
        //        (
        //        Microsoft.Win32.Registry.CurrentUser,
        //        "Software",
        //        "Eletronorte",
        //        "ColetorDados",
        //        "EnderecoProxy",
        //        txtEnderecoProxy.Text,
        //        Microsoft.Win32.RegistryValueKind.String
        //        );

        //    strEnderecoProxy = txtEnderecoProxy.Text;
        //}

        //private void txtPortaProxy_TextChanged(object sender, EventArgs e)
        //{
        //    objRegistroWindows.mtdSalvarDadosRegistro
        //        (
        //        Microsoft.Win32.Registry.CurrentUser,
        //        "Software",
        //        "Eletronorte",
        //        "ColetorDados",
        //        "PortaProxy",
        //        txtPortaProxy.Text,
        //        Microsoft.Win32.RegistryValueKind.String
        //        );

        //    strPortaProxy = txtPortaProxy.Text;
        //}

        //private void txtDominioProxy_TextChanged(object sender, EventArgs e)
        //{
        //    objRegistroWindows.mtdSalvarDadosRegistro
        //        (
        //        Microsoft.Win32.Registry.CurrentUser,
        //        "Software",
        //        "Eletronorte",
        //        "ColetorDados",
        //        "DominioProxy",
        //        txtDominioProxy.Text,
        //        Microsoft.Win32.RegistryValueKind.String
        //        );

        //    strDominioProxy = txtDominioProxy.Text;
        //}

        //private void txtUsuarioProxy_TextChanged(object sender, EventArgs e)
        //{
        //    objRegistroWindows.mtdSalvarDadosRegistro
        //        (
        //        Microsoft.Win32.Registry.CurrentUser,
        //        "Software",
        //        "Eletronorte",
        //        "ColetorDados",
        //        "UsuarioProxy",
        //        txtUsuarioProxy.Text,
        //        Microsoft.Win32.RegistryValueKind.String
        //        );

        //    strUsuarioProxy = txtUsuarioProxy.Text;
        //}

        //private void txtSenhaProxy_TextChanged(object sender, EventArgs e)
        //{
        //    objRegistroWindows.mtdSalvarDadosRegistro
        //        (
        //        Microsoft.Win32.Registry.CurrentUser,
        //        "Software",
        //        "Eletronorte",
        //        "ColetorDados",
        //        "SenhaProxy",
        //        txtSenhaProxy.Text,
        //        Microsoft.Win32.RegistryValueKind.String
        //        );

        //    strSenhaProxy = txtSenhaProxy.Text;
        //}

        private void dtpDataInventario_ValueChanged(object sender, EventArgs e)
        {
            blnPermitirAtualizacaoDtpDataInventario = false;
        }

        private void cmbPrioridadeModoOtimizadoCadastro_TextChanged(object sender, EventArgs e)
        {
            objRegistroWindows.mtdSalvarDadosRegistro
                (
                Microsoft.Win32.Registry.CurrentUser,
                "Software",
                "Eletronorte",
                "ColetorDados",
                "PrioridadeModoOtimizadoCadastro",
                cmbPrioridadeModoOtimizadoCadastro.Text,
                Microsoft.Win32.RegistryValueKind.String
                );
        }

        public System.Threading.ThreadPriority mtdConverterPrioridadeThread(string Valor)
        {
            System.Threading.ThreadPriority saida = System.Threading.ThreadPriority.Lowest;

            switch (Valor)
            {
                case "BelowNormal":
                    saida = System.Threading.ThreadPriority.BelowNormal;
                    break;
                case "Normal":
                    saida = System.Threading.ThreadPriority.Normal;
                    break;
                case "AboveNormal":
                    saida = System.Threading.ThreadPriority.AboveNormal;
                    break;
                case "Highest":
                    saida = System.Threading.ThreadPriority.Highest;
                    break;
                default:
                    saida = System.Threading.ThreadPriority.Lowest;
                    break;
            }

            return saida;
        }

        public void mtdVisualizarAlterarItemLista()
        {
            mtdVisualizarAlterarItem
                (
                dtg1.CurrentCell.RowNumber,
                dtg1.CurrentCell.ColumnNumber,
                dtg1.CurrentCell.ColumnNumber < intColunaTabelaInventarioBensMatricula_Inventariante
                ?
                dtg1.CurrentCell.ColumnNumber + 1
                :
                intColunaTabelaInventarioBensTRG,
                true
                );
        }

        public void mtdVisualizarAlterarIndividual()
        {
            mtdVisualizarAlterarItem
                (
                dtg1.CurrentCell.RowNumber,
                intColunaTabelaInventarioBensDenominacao,
                intColunaTabelaInventarioBensN_Serie,
                false
                );
        }

        public void mtdVisualizarAlterarItem(int LinhaSelecionada, int ColunaSelecionada1, int ColunaSelecionada2, bool UsarLista)
        {
            try
            {
                frmVisualizarAlterarItem objVisualizarAlterarItem = new frmVisualizarAlterarItem(UsarLista);

                objVisualizarAlterarItem.intColunaSelecionada1 = ColunaSelecionada1;
                objVisualizarAlterarItem.intColunaSelecionada2 = ColunaSelecionada2;
                objVisualizarAlterarItem.intLinhaSelecionada = LinhaSelecionada;

                objVisualizarAlterarItem.objDado[0] = new object[((System.Data.DataTable)dtg1.DataSource).Columns.Count];
                objVisualizarAlterarItem.objDado[1] = new object[((System.Data.DataTable)dtg1.DataSource).Columns.Count];

                for (int coluna = objVisualizarAlterarItem.objDado[0].GetLowerBound(0); coluna <= objVisualizarAlterarItem.objDado[0].GetUpperBound(0); coluna++)
                {
                    objVisualizarAlterarItem.objDado[0][coluna] = ((System.Data.DataTable)dtg1.DataSource).Columns[coluna].ColumnName;
                    objVisualizarAlterarItem.objDado[1][coluna] = dtg1[LinhaSelecionada, coluna].ToString();
                }

                objVisualizarAlterarItem.Show();
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdComandoAlterarDeletar: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);

                System.Windows.Forms.MessageBox.Show
                    (
                    "Não foi possível mostrar o formulário.",
                    "Aviso!",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Exclamation,
                    System.Windows.Forms.MessageBoxDefaultButton.Button1
                    );
            }
        }

        private void mtdVisualizarAlterarItemControlado()
        {
            switch (dtg1.CurrentCell.ColumnNumber)
            {
                case intColunaTabelaInventarioBensTRG:
                case intColunaTabelaInventarioBensCentroCusto:
                case intColunaTabelaInventarioBensOrgao:
                case intColunaTabelaInventarioBensSala:
                case intColunaTabelaInventarioBensNome:
                case intColunaTabelaInventarioBensMatricula:
                case intColunaTabelaInventarioBensPatrimonio:
                case intColunaTabelaInventarioBensQuantidade:
                case intColunaTabelaInventarioBensDenominacao:
                case intColunaTabelaInventarioBensN_Serie:
                case intColunaTabelaInventarioBensPlaca_Veiculo:
                case intColunaTabelaInventarioBensIdentificacao_Inventario:
                case intColunaTabelaInventarioBensOutrosDados_Inventario:
                case intColunaTabelaInventarioBensObservacao:
                case intColunaTabelaInventarioBensColetor:
                case intColunaTabelaInventarioBensUsuario_Inventariante:
                case intColunaTabelaInventarioBensMatricula_Inventariante:
                    mtdVisualizarAlterarItemLista();
                    break;
                default:
                    mtdVisualizarAlterarIndividual();
                    break;
            }
        }

        private void dtg1_DoubleClick(object sender, EventArgs e)
        {
            mtdVisualizarAlterarItemControlado();
        }

        private void frmPrincipal_Click(object sender, EventArgs e)
        {
            dblTempoPressionamentoBotao = DateTime.Now.TimeOfDay.TotalMilliseconds;
        }

        private void mtdGerarNomeEnderecoBancoDados()
        {
            string[] strBaseDados = strBaseDadosColetor.Split('\\');

            strEnderecoBancoDadosColetor = string.Empty;

            for (int contador = strBaseDados.GetLowerBound(0); contador <= strBaseDados.GetUpperBound(0) - 1; contador++)
            {
                strEnderecoBancoDadosColetor += strBaseDados[contador] + @"\";
            }

            strNomeBancoDadosColetor = strBaseDados[strBaseDados.GetUpperBound(0)];
        }

        private void txtNumeroLinhas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!objManipuladorTexto.mtdPermitirDigitarSoNumero(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtComprimentoColunas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!objManipuladorTexto.mtdPermitirDigitarSoNumero(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtIntervaloBackup_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!objManipuladorTexto.mtdPermitirDigitarSoNumero(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtNumeroCopiasBackup_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!objManipuladorTexto.mtdPermitirDigitarSoNumero(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtQuantidadeItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!objManipuladorTexto.mtdPermitirDigitarSoNumero(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtTemporizador_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!objManipuladorTexto.mtdPermitirDigitarSoNumero(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private string mtdGerarProximoNumeroTabelaInventario(string Texto, string Ano, int Posicao, int Coluna, int Incremento)
        {
            string retorno = string.Empty;
            int contador = 0;
            int multiplicador = 1000000;
            int ano = 0;

            try
            {
                ano = System.Convert.ToInt32(Ano);
            }
            catch (System.Exception ex)
            {
                ano = 0;

                string strExcecao = "mtdGerarProximoNumeroTabelaInventario: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }

            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                (
                    clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                );

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                (
                    clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                    strBaseDadosColetor,
                    strSenhaColetor
                );

            objImplementacaoBancoDados.mtdAbrirConexao();
            objImplementacaoBancoDados.mtdExecutarComando
                (
                    string.Format
                        (
                            "SELECT {0} FROM {1} WHERE ({2} LIKE {3} AND {4} LIKE {5}) ORDER BY {6};",
                            "*",
                            strTabelaInventarioBens,
                            vetCamposTabelaInventarioBens[Coluna],
                            string.Format("'{0}%'", Texto),
                            vetCamposTabelaInventarioBens[Coluna],
                            string.Format("'%{0}%'", Ano),
                            vetCamposTabelaInventarioBens[Coluna]
                        )
                );

            int maiorDado = 0;

            objImplementacaoBancoDados.mtdDefinirLeitorDados();
            while (objImplementacaoBancoDados.mtdProximoRegistro())
            {
                string[] dado = objImplementacaoBancoDados.mtdObterValorRegistro(Coluna).ToString().Split(' ');

                try
                {
                    contador = System.Convert.ToInt32(dado[Posicao]) - ano * multiplicador;

                    if (contador >= maiorDado)
                    {
                        maiorDado = contador;
                    }
                }
                catch (System.Exception ex)
                {
                    contador = 0;

                    string strExcecao = "mtdGerarProximoNumeroTabelaInventario: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                    //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                }
            }

            objImplementacaoBancoDados.Dispose();

            return string.Format("{0} {1}{2:000000}", Texto, Ano, maiorDado + 1 + Incremento > 0 ? maiorDado + 1 + Incremento : 0);
        }

        private void btnSemPatrimonio_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor; // set the wait cursor
            //Do some work

            string strTexto = string.Format
                (
                    "{0} {1}",
                    objManipuladorTexto.mtdExecutarTudo(btnSemPatrimonio.Text),
                    objManipuladorTexto.mtdExecutarTudo(txtNomeDispositivo.Text)
                );

            txtPatrimonioItem.Text = mtdGerarProximoNumeroTabelaInventario
                (
                strTexto,
                string.Format("{0}", string.Empty),
                strTexto.Split(' ').Length,
                intColunaTabelaInventarioBensPatrimonio,
                0
                );

            Cursor.Current = Cursors.Default; //restore the old cursor
        }

        private void mtdIdentificacaoItemRecuar()
        {
            //string strTexto = string.Format
            //    (
            //        "{0} {1}",
            //        objManipuladorTexto.mtdExecutarTudo(btnModoCadastroInventario.Text.Replace("Modo &", string.Empty)),
            //        objManipuladorTexto.mtdExecutarTudo(txtNomeDispositivo.Text)
            //    );

            //string strTexto = string.Format
            //    (
            //        "{0} {1}",
            //        btnModoCadastroInventario.Text == "Modo &Inventário" ? "IN" : "CD",
            //        objManipuladorTexto.mtdExecutarTudo(txtNomeDispositivo.Text)
            //    );

            //txtIdentificacaoItem.Text = mtdGerarProximoNumeroTabelaInventario
            //    (
            //    strTexto,
            //    string.Format("{0}", System.DateTime.Now.Year.ToString()),
            //    strTexto.Split(' ').Length,
            //    intColunaTabelaInventarioBensIdentificacao_Inventario,
            //    -1
            //    );

            int intMes = dtpDataInventario.Value.Month;
            int intAno = dtpDataInventario.Value.Year;

            if (dtpDataInventario.Value.Month > 1)
            {
                intMes = dtpDataInventario.Value.Month - 1;
            }
            else
            {
                intMes = 1;
                intAno = dtpDataInventario.Value.Year - 1;
            }

            string strTexto = string.Format
                (
                    "{0}",
                    btnModoCadastroInventario.Text == "Modo &Inventário" ? "IN" : "CD"
                );

            txtIdentificacaoItem.Text = string.Format
                (
                "{0}_{1}",
                strTexto,
                string.Format
                    (
                    "{0:0000}{1:00}",
                    (intAno),
                    (intMes)
                    ),
                -1
                );
        }

        private void mtdIdentificacaoItemAvancar()
        {
            //string strTexto = string.Format
            //    (
            //        "{0} {1}",
            //        objManipuladorTexto.mtdExecutarTudo(btnModoCadastroInventario.Text.Replace("Modo &", string.Empty)),
            //        objManipuladorTexto.mtdExecutarTudo(txtNomeDispositivo.Text)
            //    );

            //string strTexto = string.Format
            //    (
            //        "{0} {1}",
            //        btnModoCadastroInventario.Text == "Modo &Inventário" ? "IN" : "CD",
            //        objManipuladorTexto.mtdExecutarTudo(txtNomeDispositivo.Text)
            //    );

            //txtIdentificacaoItem.Text = mtdGerarProximoNumeroTabelaInventario
            //    (
            //    strTexto,
            //    string.Format("{0}", System.DateTime.Now.Year.ToString()),
            //    strTexto.Split(' ').Length,
            //    intColunaTabelaInventarioBensIdentificacao_Inventario,
            //    0
            //    );

            int intMes = dtpDataInventario.Value.Month;
            int intAno = dtpDataInventario.Value.Year;

            if (dtpDataInventario.Value.Month < 12)
            {
                intMes = dtpDataInventario.Value.Month + 1;
            }
            else
            {
                intMes = 1;
                intAno = dtpDataInventario.Value.Year + 1;
            }

            string strTexto = string.Format
               (
                "{0}",
                btnModoCadastroInventario.Text == "Modo &Inventário" ? "IN" : "CD"
                );

            txtIdentificacaoItem.Text = string.Format
                (
                "{0}_{1}",
                strTexto,
                string.Format
                    (
                    "{0:0000}{1:00}",
                    (intAno),
                    (intMes)
                    ),
                -1
                );
        }

        private void mtdOutrosDadosItemRecuar()
        {
            int intMes = dtpDataInventario.Value.Month;
            int intAno = dtpDataInventario.Value.Year;

            if (dtpDataInventario.Value.Month > 1)
            {
                intMes = dtpDataInventario.Value.Month - 1;
            }
            else
            {
                intMes = 1;
                intAno = dtpDataInventario.Value.Year - 1;
            }

            txtOutrosDadosItem.Text = txtTRGItem.Text != string.Empty && txtOrgaoItem.Text != string.Empty
                 ?
                 objManipuladorTexto.mtdExecutarTudo(string.Format("{0}_{1}_{2}_{3}", txtTRGItem.Text, txtOrgaoItem.Text, intAno, intMes))
                 :
                 string.Empty;
        }

        private void mtdOutrosDadosItemAvancar()
        {
            int intMes = dtpDataInventario.Value.Month;
            int intAno = dtpDataInventario.Value.Year;

            //if (dtpDataInventario.Value.Month < 12)
            //{
            //    intMes = dtpDataInventario.Value.Month + 1;
            //}
            //else
            //{
            //    intMes = 1;
            //    intAno = dtpDataInventario.Value.Year + 1;
            //}

            txtOutrosDadosItem.Text = txtTRGItem.Text != string.Empty && txtOrgaoItem.Text != string.Empty
                 ?
                 objManipuladorTexto.mtdExecutarTudo(string.Format("{0}_{1}_{2}_{3}", txtTRGItem.Text, txtOrgaoItem.Text, intAno, intMes))
                 :
                 string.Empty;
        }

        private void btnIdentificacaoItemRecuar_Click(object sender, EventArgs e)
        {
            mtdIdentificacaoItemRecuar();
        }

        private void btnIdentificacaoItemAvancar_Click(object sender, EventArgs e)
        {
            mtdIdentificacaoItemAvancar();
        }

        private void btnOutrosDadosItemRecuar_Click(object sender, EventArgs e)
        {
            mtdOutrosDadosItemRecuar();
        }

        private void btnOutrosDadosItemAvancar_Click(object sender, EventArgs e)
        {
            mtdOutrosDadosItemAvancar();
        }

        private void mtdPreencherColunaCampoConsultarInventario(string CmbConsultarInventario, string TxtConsultarInventario)
        {
            cmbConsultarInventario.Text = CmbConsultarInventario;
            txtConsultarInventario.Text = TxtConsultarInventario;
        }

        private void mtdPreencherColunaCampoConsultarSAP(string CmbConsultarSAP, string TxtConsultarSAP)
        {
            cmbConsultarSAP.Text = CmbConsultarSAP;
            txtConsultarSAP.Text = TxtConsultarSAP;
        }

        private void mtdPreencherColunaCampoConsultarEmpregados(string CmbConsultarEmpregados, string TxtConsultarEmpregados)
        {
            cmbConsultarEmpregados.Text = CmbConsultarEmpregados;
            txtConsultarEmpregados.Text = TxtConsultarEmpregados;
        }

        private void mtdPreencherColunaCampoConsultarCentroCusto(string CmbConsultarCentroCusto, string TxtConsultarCentroCusto)
        {
            cmbConsultarCentroCusto.Text = CmbConsultarCentroCusto;
            txtConsultarCentroCusto.Text = TxtConsultarCentroCusto;
        }

        private void mtdPreencherTabelaCampoFiltroConsultarRelatorio(string CmbConsultarTabelaRelatorio, string CmbConsultarCamposRelatorio, string TxtTabelaRelatorioFiltro)
        {
            if (cmbConsultarTabelaRelatorio.Items.Count == 0)
            {
                mtdCarregarCmbConsultarTabelaRelatorio();
            }
            cmbConsultarTabelaRelatorio.Text = CmbConsultarTabelaRelatorio;
            if (cmbConsultarCamposRelatorio.Items.Count == 0)
            {
                mtdCarregarCmb
                  (
                  ref cmbConsultarCamposRelatorio,
                  String.Format("SELECT TOP (0) * FROM {0}", string.Format("tbl{0}", cmbConsultarTabelaRelatorio.Text))
                  );
            }
            cmbConsultarCamposRelatorio.Text = CmbConsultarCamposRelatorio;
            txtTabelaRelatorioFiltro.Text = TxtTabelaRelatorioFiltro;
        }

        private static clsArquivoTXT objArquivoTXT = new clsArquivoTXT();

        private static object LockObterNumeroLinhasRelatorioErros = new object();

        private static long mtdObterNumeroLinhasRelatorioErros(string EnderecoNomeArquivo)
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
                    //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                }

                return lngRetorno;
            }
        }

        private static long lngContador = 0;

        public static void mtdGerarRelatorioErros(string EnderecoNomeArquivo, string Conteudo)
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
                objArquivoTXT.mtdAcrescentarTexto(EnderecoNomeArquivo, string.Format("{0} - {1}", lngContador++, Conteudo));
            }
        }

        private string mtdObterContadorCampo
        (
        uint NumeroLinhas,
        string Campo,
        string NomeTabela,
        string CampoSelecionador,
        string DadoSelecionador,
        string CampoOrdenador,
        bool Crescente
        )
        {
            string Retorno = string.Empty;
            string CampoContador = "Contador";

            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                (
                clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                );

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                (
                clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                strBaseDadosColetor,
                strSenhaColetor
                );

            Cursor.Current = Cursors.WaitCursor; // set the wait cursor
            //Do some work

            try
            {
                objImplementacaoBancoDados.mtdAbrirConexao();
                objImplementacaoBancoDados.mtdExecutarComando
                (
                string.Format
                (
                "SELECT DISTINCT {0}{1}, COUNT({1}) AS {2} FROM {3} GROUP BY {1} HAVING {4} ORDER BY {5}{6};",
                NumeroLinhas != 0 ? string.Format("TOP ({0}) ", NumeroLinhas) : string.Empty,
                Campo,
                CampoContador,
                NomeTabela,
                string.Format("{0} LIKE '{1}'", CampoSelecionador, DadoSelecionador),
                CampoOrdenador,
                Crescente ? string.Empty : " DESC"
                )
                );

                objImplementacaoBancoDados.mtdDefinirLeitorDados();
                if (objImplementacaoBancoDados.mtdProximoRegistro())
                {
                    Retorno = string.Format
                        (
                        "{0}{1}.",
                        "Número de itens cadastrados: ",
                        objImplementacaoBancoDados.mtdObterValorRegistro(1).ToString()
                        );
                }
                else
                {
                    Retorno = string.Format
                        (
                        "{0}.",
                        "Não há itens cadastrados"
                        );
                }
            }
            catch (System.Exception ex)
            {
                Retorno = "Não foi possível obter o número de itens cadastrados no campo informado.";
                string strExcecao = "mtdObterContadorCampo: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }

            Cursor.Current = Cursors.Default; //restore the old cursor

            objImplementacaoBancoDados.Dispose();

            return Retorno;
        }

        private string mtdObterContadorCampo
            (
            uint NumeroLinhas,
            string Campo,
            string Campo2,
            string NomeTabela,
            string CampoSelecionador,
            string DadoSelecionador,
            string CampoSelecionador2,
            string DadoSelecionador2,
            string CampoOrdenador,
            bool Crescente
            )
        {
            string Retorno = string.Empty;
            string CampoContador = "Contador";

            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                (
                clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                );

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                (
                clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                strBaseDadosColetor,
                strSenhaColetor
                );

            Cursor.Current = Cursors.WaitCursor; // set the wait cursor
            //Do some work

            try
            {
                objImplementacaoBancoDados.mtdAbrirConexao();
                objImplementacaoBancoDados.mtdExecutarComando
                (
                string.Format
                (
                "SELECT DISTINCT {0}{1}, {2}, COUNT({1}) AS {3} FROM {4} GROUP BY {1}, {2} HAVING {5} AND {6} ORDER BY {7}{8};",
                NumeroLinhas != 0 ? string.Format("TOP ({0}) ", NumeroLinhas) : string.Empty,
                Campo,
                Campo2,
                CampoContador,
                NomeTabela,
                string.Format("{0} LIKE '{1}'", CampoSelecionador, DadoSelecionador),
                string.Format(DadoSelecionador2 != string.Empty ? "{0} LIKE '{1}'" : "{0} LIKE '%'", CampoSelecionador2, DadoSelecionador2),
                CampoOrdenador,
                Crescente ? string.Empty : " DESC"
                )
                );

                objImplementacaoBancoDados.mtdDefinirLeitorDados();
                if (objImplementacaoBancoDados.mtdProximoRegistro())
                {
                    Retorno = string.Format
                        (
                        DadoSelecionador2
                        !=
                        string.Empty
                        ?
                        "{0} em {1}: {2}."
                        :
                        "{0} na base de dados: {2}.",
                        "Número de itens cadastrados ",
                        DadoSelecionador2,
                        objImplementacaoBancoDados.mtdObterValorRegistro(2).ToString()
                        );
                }
                else
                {
                    Retorno = string.Format
                        (
                        DadoSelecionador2
                        !=
                        string.Empty
                        ?
                        "{0} em {1}."
                        :
                        "{0} na base de dados.",
                        "Não há itens cadastrados",
                        DadoSelecionador2
                        );
                }
            }
            catch (System.Exception ex)
            {
                Retorno = "Não foi possível obter o número de itens cadastrados no campo informado.";
                string strExcecao = "mtdObterContadorCampo: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }

            Cursor.Current = Cursors.Default; //restore the old cursor

            objImplementacaoBancoDados.Dispose();

            return Retorno;
        }

        private void txtIdentificacaoItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)System.Windows.Forms.Keys.Enter)
            {
                System.Windows.Forms.MessageBox.Show
                (
                    mtdObterContadorCampo
                        (
                            0,
                            vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensIdentificacao_Inventario],
                            strTabelaInventarioBens,
                            vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensIdentificacao_Inventario],
                            txtIdentificacaoItem.Text,
                            vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensIdentificacao_Inventario],
                            true
                            ),
                            "Aviso!",
                            System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Exclamation,
                            System.Windows.Forms.MessageBoxDefaultButton.Button1
                        );
            }
        }

        private void txtOutrosDadosItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)System.Windows.Forms.Keys.Enter)
            {
                System.Windows.Forms.MessageBox.Show
                (
                    mtdObterContadorCampo
                        (
                            0,
                            vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensOutrosDados_Inventario],
                            strTabelaInventarioBens,
                            vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensOutrosDados_Inventario],
                            txtIdentificacaoItem.Text,
                            vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensOutrosDados_Inventario],
                            true
                            ),
                            "Aviso!",
                            System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Exclamation,
                            System.Windows.Forms.MessageBoxDefaultButton.Button1
                        );
            }
        }

        private void btnPatrimonioItemIdentificacaoItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show
            (
                mtdObterContadorCampo
                    (
                    0,
                    vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensPatrimonio],
                    vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensIdentificacao_Inventario],
                    strTabelaInventarioBens,
                    vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensPatrimonio],
                    txtPatrimonioItem.Text,
                    vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensIdentificacao_Inventario],
                    txtIdentificacaoItem.Text,
                    vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensIdentificacao_Inventario],
                    true
                    ),
                    "Aviso!",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Exclamation,
                    System.Windows.Forms.MessageBoxDefaultButton.Button1
                );
        }

        private void btnPatrimonioItemOutrosDadosItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show
            (
                mtdObterContadorCampo
                    (
                    0,
                    vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensPatrimonio],
                    vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensOutrosDados_Inventario],
                    strTabelaInventarioBens,
                    vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensPatrimonio],
                    txtPatrimonioItem.Text,
                    vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensOutrosDados_Inventario],
                    txtOutrosDadosItem.Text,
                    vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensOutrosDados_Inventario],
                    true
                    ),
                    "Aviso!",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Exclamation,
                    System.Windows.Forms.MessageBoxDefaultButton.Button1
                );
        }

        private void btnNSerieItemIdentificacaoItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show
            (
                mtdObterContadorCampo
                    (
                    0,
                    vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensN_Serie],
                    vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensIdentificacao_Inventario],
                    strTabelaInventarioBens,
                    vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensN_Serie],
                    txtNSerieItem.Text,
                    vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensIdentificacao_Inventario],
                    txtIdentificacaoItem.Text,
                    vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensIdentificacao_Inventario],
                    true
                    ),
                    "Aviso!",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Exclamation,
                    System.Windows.Forms.MessageBoxDefaultButton.Button1
                );
        }

        private void btnNSerieItemOutrosDadosItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show
            (
                mtdObterContadorCampo
                    (
                    0,
                    vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensN_Serie],
                    vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensOutrosDados_Inventario],
                    strTabelaInventarioBens,
                    vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensN_Serie],
                    txtNSerieItem.Text,
                    vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensOutrosDados_Inventario],
                    txtOutrosDadosItem.Text,
                    vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensOutrosDados_Inventario],
                    true
                    ),
                    "Aviso!",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Exclamation,
                    System.Windows.Forms.MessageBoxDefaultButton.Button1
                );
        }

        private bool blnNivelBateria = true;
        private int intBatteryLifePercent = 0;
        private double dblBatteryVoltage = 0;
        private string strBatteryLifePercent = string.Empty;
        private string strBatteryVoltage = string.Empty;

        private void mtdNivelBateria()
        {
            try
            {
                intBatteryLifePercent = objBatteryStatus._currentStatus.BatteryLifePercent;
                dblBatteryVoltage = 0.001 * (float)objBatteryStatus._currentStatus.BatteryVoltage;
                strBatteryLifePercent = string.Format("{0:#00}%", intBatteryLifePercent);
                strBatteryVoltage = string.Format("{0:0.000}v", dblBatteryVoltage);
            }
            catch (System.Exception ex)
            {
                strBatteryLifePercent = "Não Disponível";
                strBatteryVoltage = "Não Disponível";

                string strExcecao = "mtdNivelBateria: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void mtdColorirNivelBateria()
        {
            if (intBatteryLifePercent >= 0 && intBatteryLifePercent <= 3)
            {
                btnNivelBateria.ForeColor = Color.FromArgb(192, 0, 0);
            }
            else if (intBatteryLifePercent > 3 && intBatteryLifePercent <= 10)
            {
                btnNivelBateria.ForeColor = Color.FromArgb(192, 192, 0);
            }
            else if (intBatteryLifePercent > 10 && intBatteryLifePercent <= 100)
            {
                btnNivelBateria.ForeColor = Color.FromArgb(0, 192, 0);
            }
        }

        private void mtdGerarNivelBateria()
        {
            mtdGerarNivelBateria(false);
        }

        private void mtdGerarNivelBateria(bool ForcarNivel)
        {
            mtdGerarNivelBateria(false, false);
        }

        private void mtdGerarNivelBateria(bool ForcarNivel, bool Display)
        {
            if (blnNivelBateria || ForcarNivel)
            {
                btnNivelBateria.Text = string.Format("Nível da Bateria: {0}", strBatteryLifePercent);
                if (!ForcarNivel && !Display)
                {
                    blnNivelBateria = false;
                }
            }
            else
            {
                btnNivelBateria.Text = string.Format("Tensão da Bateria: {0}", strBatteryVoltage);
                if (!ForcarNivel && !Display)
                {
                    blnNivelBateria = true;
                }
            }
        }

        private void btnNivelBateria_Click(object sender, EventArgs e)
        {
            mtdGerarNivelBateria();
        }

        private void mtdIndicarTemporizador()
        {
            if (frmMonitorCarregamentoDados.blnTemporizadorAtivado)
            {
                btnTemporizadorCancelar.ForeColor = Color.Green;
            }
            else
            {
                btnTemporizadorCancelar.ForeColor = Color.Maroon;
            }
        }

        private string strNomeBancoDados = string.Empty;

        private void mtdGerarDiretorioBancoDados(string Diretorio)
        {
            strNomeBancoDados = strNomeBancoDadosColetor;
            txtEnderecoBaseDados.Text = string.Format(@"{0}\{1}", Diretorio, strNomeBancoDados); ;

            if (!(mtdCriarBancoDadosColetor() || mtdTestarConexao()))
            {
                txtEnderecoBaseDados.Text = string.Format(@"{0}\{1}", DiretorioArmazenamentoCompleto, strNomeBancoDados); ;
            }
        }

        private void btnStorageCard_Click(object sender, EventArgs e)
        {
            mtdGerarDiretorioBancoDados(@"\Storage Card");
        }

        private void btnFlashDisk_Click(object sender, EventArgs e)
        {
            mtdGerarDiretorioBancoDados(@"\FlashDisk");
        }

        private string CampoContador = "Contador";

        private void mtdPreencherDtg6
            (
            uint NumeroLinhas,
            string Campo,
            string Campo2,
            string NomeTabela,
            string CampoSelecionador,
            string DadoSelecionador,
            string CampoOrdenador,
            bool Crescente,
            int Repeticao
            )
        {
            Cursor.Current = Cursors.WaitCursor; // set the wait cursor
            //Do some work

            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                (
                clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                );

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                (
                clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                strBaseDadosColetor,
                strSenhaColetor
                );

            objImplementacaoBancoDados.mtdAbrirConexao();
            objImplementacaoBancoDados.mtdExecutarComando
            (
            string.Format
            (
            "SELECT DISTINCT {0}{2}, {1}, Count({1}) AS {3} FROM {4} GROUP BY {2}, {1} HAVING (Count({1}) > {8} AND {5}) ORDER BY {6}{7};",
            NumeroLinhas != 0 ? string.Format("TOP ({0}) ", NumeroLinhas) : string.Empty,
            Campo,
            Campo2,
            CampoContador,
            NomeTabela,
            string.Format("{0} LIKE {1}", CampoSelecionador, DadoSelecionador != string.Empty ? DadoSelecionador : "N'%'"),
            CampoOrdenador,
            Crescente ? string.Empty : " DESC",
            Repeticao - 1
            )
            );

            string cm = objImplementacaoBancoDados.prpComando;

            objImplementacaoBancoDados.mtdAdaptadorDados();

            dtg6.TableStyles.Clear();
            dtg6.TableStyles.Add(mtdAjustarComprimentoColunasDtg(ref objImplementacaoBancoDados.objTabelaDados, objImplementacaoBancoDados.prpConexao, objImplementacaoBancoDados.prpComando, uintComprimentoColunas));

            dtg6.DataSource = objImplementacaoBancoDados.prpTabelaDados;
            if (dtg6.VisibleRowCount > 0)
            {
                dtg6.Select(dtg6.VisibleRowCount - 1);
            }

            Cursor.Current = Cursors.Default; //restore the old cursor

            objImplementacaoBancoDados.Dispose();
        }

        private void cmbConsultarInventarioRepeticoes_GotFocus(object sender, EventArgs e)
        {
            try
            {
                if (cmbConsultarInventarioRepeticoes.Items.Count == 0)
                {
                    mtdCarregarCmb
                        (
                        ref cmbConsultarInventarioRepeticoes,
                        string.Format("SELECT TOP (0) * FROM {0}", strTabelaInventarioBens)
                        );
                    cmbConsultarInventarioRepeticoes.SelectedIndex = intColunaTabelaInventarioBensIdentificacao_Inventario;
                }
            }
            catch (System.Exception ex)
            {
                string strExcecao = "cmbConsultarInventarioRepeticoes_GotFocus: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void txtRepeticoes_LostFocus(object sender, EventArgs e)
        {
            try
            {
                intRepeticoes = System.Convert.ToInt32(txtRepeticoes.Text);
            }
            catch (System.Exception ex)
            {
                intRepeticoes = intRepeticoesPadrao;
                txtRepeticoes.Text = System.Convert.ToString(intRepeticoes);

                string strExcecao = "txtRepeticoes_LostFocus: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void mtdConsultarItensRepetidosCampoInformado(string CampoItens, string CampoAgrupador)
        {
            try
            {
                clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                   (
                   clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                   );

                objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                    (
                    clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                    strBaseDadosColetor,
                    strSenhaColetor
                    );

                string strCadeiaCarecteres = "N'%{0}%'";
                objImplementacaoBancoDados.mtdSelecionarDados(0, vetCamposTabelaInventarioBens, strTabelaInventarioBens);
                objImplementacaoBancoDados.mtdDefinirLeitorDados();
                if (objImplementacaoBancoDados.mtdProximoRegistro())
                {
                    switch (objImplementacaoBancoDados.mtdObterTipoRegistro(objImplementacaoBancoDados.mtdObterNumeroColuna(CampoAgrupador)).ToString())
                    {
                        case "System.Byte[]":
                            strCadeiaCarecteres = "{0}";
                            break;
                        case "System.DateTime":
                            strCadeiaCarecteres = "{0}";
                            break;
                        case "System.Int64":
                            strCadeiaCarecteres = "'%{0}%'";
                            break;
                        case "System.String":
                            strCadeiaCarecteres = "N'%{0}%'";
                            break;
                    }
                }

                mtdPreencherDtg6
                (
                uintNumeroLinhas,
                CampoItens,
                CampoAgrupador,
                strTabelaInventarioBens,
                CampoItens,
                    //string.Format(strCadeiaCarecteres, string.Empty),
                string.Empty,
                CampoContador,
                false,
                intRepeticoes
                );

                objImplementacaoBancoDados.Dispose();
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdConsultarItensRepetidosCampoInformado: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private bool mtdTestarConexao()
        {
            bool retorno = false;

            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
            (
            clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
            );

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                (
                clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                strBaseDadosColetor,
                strSenhaColetor
                );

            retorno = objImplementacaoBancoDados.mtdAbrirConexao();

            objImplementacaoBancoDados.Dispose();

            return retorno;
        }

        private void mtdTestarConexao_()
        {
            System.Windows.Forms.MessageBox.Show
                (
                mtdTestarConexao() ? "A conexão foi realizada com sucesso." : "Não foi possível realizar a conexão, verifique se o arquivo existe ou se a senha está correta.",
                "Aviso!",
                System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.Exclamation,
                System.Windows.Forms.MessageBoxDefaultButton.Button1
                );
        }

        private void btnTestarConexao_Click(object sender, EventArgs e)
        {
            mtdTestarConexao_();
        }

        private void mtdCarregarCaixaDtgv6(string Campo1, string Dado1, string Campo2, string Dado2)
        {
            try
            {
                int intPosicao = 0;

                for (int posicao = vetCamposTabelaInventarioBens.GetLowerBound(0); posicao <= vetCamposTabelaInventarioBens.GetUpperBound(0); posicao++)
                {
                    if (Campo1 == vetCamposTabelaInventarioBens[posicao])
                    {
                        intPosicao = posicao;
                        break;
                    }
                }

                mtdPreencherColunaCampoConsultarInventario(cmbConsultarInventario.Items[intPosicao].ToString(), Dado1);
                mtdPreencherTabelaCampoFiltroConsultarRelatorio(strTabelaInventarioBens.Replace("tbl", string.Empty), cmbConsultarInventario.Items[intPosicao].ToString(), Dado1);

                if (Campo2 == vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensPatrimonio])
                {
                    mtdPreencherColunaCampoConsultarSAP(cmbConsultarInventario.Items[intColunaTabelaInventarioBensPatrimonio].ToString(), Dado2);
                    mtdPreencherTabelaCampoFiltroConsultarRelatorio(strTabelaInventarioBens.Replace("tbl", string.Empty), cmbConsultarInventario.Items[intColunaTabelaInventarioBensPatrimonio].ToString(), Dado2);
                }
                if (Campo2 == vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensN_Serie])
                {
                    mtdPreencherColunaCampoConsultarSAP(cmbConsultarInventario.Items[intColunaTabelaInventarioBensN_Serie].ToString(), Dado2);
                    mtdPreencherTabelaCampoFiltroConsultarRelatorio(strTabelaInventarioBens.Replace("tbl", string.Empty), cmbConsultarInventario.Items[intColunaTabelaInventarioBensN_Serie].ToString(), Dado2);
                }
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdCarregarCaixaDtgv6: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void dtg6_Click(object sender, EventArgs e)
        {
            if (dtg6.CurrentRowIndex >= 0)
            {
                mtdCarregarCaixaDtgv6(((DataTable)dtg6.DataSource).Columns[0].ColumnName, dtg6[dtg6.CurrentRowIndex, 0].ToString(), ((DataTable)dtg6.DataSource).Columns[1].ColumnName, dtg6[dtg6.CurrentRowIndex, 1].ToString());
            }
        }

        private static object LockObterIpLocal = new object();

        public static string mtdObterIpLocal()
        {
            lock (LockObterIpLocal)
            {
                string retorno = string.Empty;

                String strHostName = string.Empty;
                /* First get the host name of local machine.*/
                strHostName = System.Net.Dns.GetHostName();
                Console.WriteLine("Local Machine's Host Name: " + strHostName);

                /* Then using host name, get the IP address list..*/
                System.Net.IPHostEntry ipEntry = System.Net.Dns.GetHostByName(strHostName);
                System.Net.IPAddress[] addr = ipEntry.AddressList;
                for (int i = 0; i < addr.Length; i++)
                {
                    if (i != addr.Length - 1)
                    {
                        retorno += string.Format("{0} - {1}; ", i, addr[i].ToString());
                    }
                    else
                    {
                        retorno += string.Format("{0} - {1}.", i, addr[i].ToString());
                    }
                }

                return retorno;
            }
        }

        private void btnRelatorioExtra_Click(object sender, EventArgs e)
        {
            mtdCarregarRelatoriosExtra();
        }

        private void btnForcarDesligamento_Click(object sender, EventArgs e)
        {
            clsShutdownDevice.mtdForcePowerOff();
        }

        private void btnTemporizadorCancelar_Click(object sender, EventArgs e)
        {
            frmMonitorCarregamentoDados.mtdAbortarThreadTemporizadorForcarDesligamento();
        }

        private void btnZerarTabelaInventarioBens_Click(object sender, EventArgs e)
        {
            if (txtSenhaZerarTabelas.Text == strSenhaColetor)
            {
                if
                    (
                        System.Windows.Forms.MessageBox.Show
                        (
                        "Sim: deseja realmente deletar todos os dados da Tabela de Inventário de Bens.\nNão: cancelar.",
                        "Aviso!",
                        System.Windows.Forms.MessageBoxButtons.YesNo,
                        System.Windows.Forms.MessageBoxIcon.Exclamation,
                        System.Windows.Forms.MessageBoxDefaultButton.Button2
                        )
                        == System.Windows.Forms.DialogResult.Yes
                    )
                {
                    if (mtdDeletarDadosTabelaInventarioBens("'%'"))
                    {
                        System.Windows.Forms.MessageBox.Show
                            (
                            "Todos os itens foram deletados.",
                            "Aviso!", System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Exclamation,
                            System.Windows.Forms.MessageBoxDefaultButton.Button1
                            );
                        mtdAtualizarDtg1(vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensNumero_Inventario], string.Empty, uintNumeroLinhas);
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show
                            (
                            "Ocorreu algum erro ao deletar os itens.",
                            "Aviso!", System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Exclamation,
                            System.Windows.Forms.MessageBoxDefaultButton.Button1
                            );
                    }
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show
                    (
                    "A senha digita está incorreta.",
                    "Aviso!", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Exclamation,
                    System.Windows.Forms.MessageBoxDefaultButton.Button1
                    );
            }
        }

        private void btnZerarTabelaSAP_Click(object sender, EventArgs e)
        {
            if (txtSenhaZerarTabelas.Text == strSenhaColetor)
            {
                if
                       (
                           System.Windows.Forms.MessageBox.Show
                           (
                           "Sim: deseja realmente deletar todos os dados da Tabela do SAP.\nNão: cancelar.",
                           "Aviso!",
                           System.Windows.Forms.MessageBoxButtons.YesNo,
                           System.Windows.Forms.MessageBoxIcon.Exclamation,
                           System.Windows.Forms.MessageBoxDefaultButton.Button2
                           )
                           == System.Windows.Forms.DialogResult.Yes
                       )
                {
                    if (mtdDeletarDadosTabelaSAP("'%'"))
                    {
                        System.Windows.Forms.MessageBox.Show
                            (
                            "Todos os itens foram deletados.",
                            "Aviso!", System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Exclamation,
                            System.Windows.Forms.MessageBoxDefaultButton.Button1
                            );
                        mtdAtualizarDtg2(vetCamposTabelaBensEletronorte[intColunaTabelaBensEletronortePatrimonio], string.Empty, uintNumeroLinhas);
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show
                            (
                            "Ocorreu algum erro ao deletar os itens.",
                            "Aviso!", System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Exclamation,
                            System.Windows.Forms.MessageBoxDefaultButton.Button1
                            );
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show
                        (
                        "A senha digita está incorreta.",
                        "Aviso!", System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Exclamation,
                        System.Windows.Forms.MessageBoxDefaultButton.Button1
                        );
                }
            }
        }

        private void btnZerarTabelaEmpregados_Click(object sender, EventArgs e)
        {
            if (txtSenhaZerarTabelas.Text == strSenhaColetor)
            {
                if
                      (
                          System.Windows.Forms.MessageBox.Show
                          (
                          "Sim: deseja realmente deletar todos os dados da Tabela de Empregados.\nNão: cancelar.",
                          "Aviso!",
                          System.Windows.Forms.MessageBoxButtons.YesNo,
                          System.Windows.Forms.MessageBoxIcon.Exclamation,
                          System.Windows.Forms.MessageBoxDefaultButton.Button2
                          )
                          == System.Windows.Forms.DialogResult.Yes
                      )
                {
                    if (mtdDeletarDadosTabelaEmpregados("'%'"))
                    {
                        System.Windows.Forms.MessageBox.Show
                            (
                            "Todos os itens foram deletados.",
                            "Aviso!", System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Exclamation,
                            System.Windows.Forms.MessageBoxDefaultButton.Button1
                            );
                        mtdAtualizarDtg3(vetCamposTabelaEmpregados[intColunaTabelaEmpregadosMatricula], string.Empty, uintNumeroLinhas);
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show
                            (
                            "Ocorreu algum erro ao deletar os itens.",
                            "Aviso!", System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Exclamation,
                            System.Windows.Forms.MessageBoxDefaultButton.Button1
                            );
                    }
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show
                    (
                    "A senha digita está incorreta.",
                    "Aviso!", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Exclamation,
                    System.Windows.Forms.MessageBoxDefaultButton.Button1
                    );
            }
        }

        private void btnZerarTabelaCentroCusto_Click(object sender, EventArgs e)
        {
            if (txtSenhaZerarTabelas.Text == strSenhaColetor)
            {
                if
                    (
                        System.Windows.Forms.MessageBox.Show
                        (
                        "Sim: deseja realmente deletar todos os dados da Tabela de Centro de Custo.\nNão: cancelar.",
                        "Aviso!",
                        System.Windows.Forms.MessageBoxButtons.YesNo,
                        System.Windows.Forms.MessageBoxIcon.Exclamation,
                        System.Windows.Forms.MessageBoxDefaultButton.Button2
                        )
                        == System.Windows.Forms.DialogResult.Yes
                    )
                {
                    mtdDeletarDadosTabelaCentroCusto("'%'");
                    System.Windows.Forms.MessageBox.Show
                        (
                        "Todos os itens foram deletados.",
                        "Aviso!", System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Exclamation,
                        System.Windows.Forms.MessageBoxDefaultButton.Button1
                        );
                    mtdAtualizarDtg4(vetCamposTabelaCentroCusto[intColunaTabelaCentroCustoCentroCusto], string.Empty, uintNumeroLinhas);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show
                        (
                        "Ocorreu algum erro ao deletar os itens.",
                        "Aviso!", System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Exclamation,
                        System.Windows.Forms.MessageBoxDefaultButton.Button1
                        );
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show
                    (
                    "A senha digita está incorreta.",
                    "Aviso!", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Exclamation,
                    System.Windows.Forms.MessageBoxDefaultButton.Button1
                    );
            }
        }

        private void txtSenhaBaseDados_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)System.Windows.Forms.Keys.Enter)
            {
                mtdTestarConexao_();
            }
        }
    }
}