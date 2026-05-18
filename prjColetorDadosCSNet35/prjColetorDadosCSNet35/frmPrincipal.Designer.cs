namespace prjColetorDadosCSNet35
{
    public partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mnm1;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                mtdAbortarThreadCadastroOtimizado(true);

                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.mnm1 = new System.Windows.Forms.MainMenu();
            this.mni1 = new System.Windows.Forms.MenuItem();
            this.mni2 = new System.Windows.Forms.MenuItem();
            this.ofd1 = new System.Windows.Forms.OpenFileDialog();
            this.tbpConfiguracoes = new System.Windows.Forms.TabPage();
            this.txtComprimentoColunas = new System.Windows.Forms.TextBox();
            this.lblComprimentoColunas = new System.Windows.Forms.Label();
            this.btnTestarConexao = new System.Windows.Forms.Button();
            this.btnFlashDisk = new System.Windows.Forms.Button();
            this.btnStorageCard = new System.Windows.Forms.Button();
            this.btnBatteryStatus = new System.Windows.Forms.Button();
            this.btnMonitorCarregamentoDados = new System.Windows.Forms.Button();
            this.lblEnderecoBaseDados = new System.Windows.Forms.Label();
            this.txtSenhaBaseDados = new System.Windows.Forms.TextBox();
            this.lblSenhaBaseDados = new System.Windows.Forms.Label();
            this.txtNumeroLinhas = new System.Windows.Forms.TextBox();
            this.lblNumeroLinhas = new System.Windows.Forms.Label();
            this.btnSincronizarHorarioServidor = new System.Windows.Forms.Button();
            this.pctConfiguracoes = new System.Windows.Forms.PictureBox();
            this.btnCompactarRepararBancoDados = new System.Windows.Forms.Button();
            this.btnEnderecoBaseDados = new System.Windows.Forms.Button();
            this.txtEnderecoBaseDados = new System.Windows.Forms.TextBox();
            this.tbpTabelas = new System.Windows.Forms.TabPage();
            this.tbc2 = new System.Windows.Forms.TabControl();
            this.tbpTabelaInventario = new System.Windows.Forms.TabPage();
            this.cmbConsultarInventario = new System.Windows.Forms.ComboBox();
            this.txtConsultarInventario = new System.Windows.Forms.TextBox();
            this.dtg1 = new System.Windows.Forms.DataGrid();
            this.tbpTabelaSap = new System.Windows.Forms.TabPage();
            this.cmbConsultarSAP = new System.Windows.Forms.ComboBox();
            this.txtConsultarSAP = new System.Windows.Forms.TextBox();
            this.dtg2 = new System.Windows.Forms.DataGrid();
            this.tbpTabelaEmpregados = new System.Windows.Forms.TabPage();
            this.cmbConsultarEmpregados = new System.Windows.Forms.ComboBox();
            this.txtConsultarEmpregados = new System.Windows.Forms.TextBox();
            this.dtg3 = new System.Windows.Forms.DataGrid();
            this.tblTabelaCentroCusto = new System.Windows.Forms.TabPage();
            this.cmbConsultarCentroCusto = new System.Windows.Forms.ComboBox();
            this.txtConsultarCentroCusto = new System.Windows.Forms.TextBox();
            this.dtg4 = new System.Windows.Forms.DataGrid();
            this.tbpDadosGerais = new System.Windows.Forms.TabPage();
            this.btnPatrimonioItemOutrosDadosItem = new System.Windows.Forms.Button();
            this.btnPatrimonioItemIdentificacaoItem = new System.Windows.Forms.Button();
            this.btnNSerieItemOutrosDadosItem = new System.Windows.Forms.Button();
            this.btnNSerieItemIdentificacaoItem = new System.Windows.Forms.Button();
            this.btnDadosGeraisSelecionarButoesA = new System.Windows.Forms.Button();
            this.btnDadosGeraisSelecionarButoesL = new System.Windows.Forms.Button();
            this.btnDadosGeraisSelecionarButoes = new System.Windows.Forms.Button();
            this.lblQuantidadeItem = new System.Windows.Forms.Label();
            this.txtQuantidadeItem = new System.Windows.Forms.TextBox();
            this.btnSemPatrimonio = new System.Windows.Forms.Button();
            this.txtPlacaVeiculoItem = new System.Windows.Forms.TextBox();
            this.txtNSerieItem = new System.Windows.Forms.TextBox();
            this.txtDenominacaoItem = new System.Windows.Forms.TextBox();
            this.txtPatrimonioItem = new System.Windows.Forms.TextBox();
            this.btnPlacaVeiculoItemA = new System.Windows.Forms.Button();
            this.btnPlacaVeiculoItemL = new System.Windows.Forms.Button();
            this.btnNSerieItemA = new System.Windows.Forms.Button();
            this.btnNSerieItemL = new System.Windows.Forms.Button();
            this.btnDenominacaoItemA = new System.Windows.Forms.Button();
            this.btnDenominacaoItemL = new System.Windows.Forms.Button();
            this.btnPatrimonioItemL = new System.Windows.Forms.Button();
            this.btnPatrimonioItemA = new System.Windows.Forms.Button();
            this.btnPlacaVeiculoItem = new System.Windows.Forms.Button();
            this.btnNSerieItem = new System.Windows.Forms.Button();
            this.btnDenominacaoItem = new System.Windows.Forms.Button();
            this.btnPatrimonioItem = new System.Windows.Forms.Button();
            this.tbpControleFisico = new System.Windows.Forms.TabPage();
            this.txtMatriculaItem = new System.Windows.Forms.TextBox();
            this.txtNomeItem = new System.Windows.Forms.TextBox();
            this.txtSalaItem = new System.Windows.Forms.TextBox();
            this.txtOrgaoItem = new System.Windows.Forms.TextBox();
            this.txtCentroCustoItem = new System.Windows.Forms.TextBox();
            this.txtTRGItem = new System.Windows.Forms.TextBox();
            this.btnControleFisicoSelecionarButoesL = new System.Windows.Forms.Button();
            this.btnControleFisicoSelecionarButoesA = new System.Windows.Forms.Button();
            this.btnMatriculaItemL = new System.Windows.Forms.Button();
            this.btnMatriculaItemA = new System.Windows.Forms.Button();
            this.btnNomeItemL = new System.Windows.Forms.Button();
            this.btnNomeItemA = new System.Windows.Forms.Button();
            this.btnSalaItemL = new System.Windows.Forms.Button();
            this.btnSalaItemA = new System.Windows.Forms.Button();
            this.btnOrgaoItemL = new System.Windows.Forms.Button();
            this.btnOrgaoItemA = new System.Windows.Forms.Button();
            this.btnCentroCustoItemL = new System.Windows.Forms.Button();
            this.btnCentroCustoItemA = new System.Windows.Forms.Button();
            this.btnTRGItemL = new System.Windows.Forms.Button();
            this.btnTRGItemA = new System.Windows.Forms.Button();
            this.txtNumeroInventario = new System.Windows.Forms.Label();
            this.btnControleFisicoSelecionarButoes = new System.Windows.Forms.Button();
            this.btnNomeItem = new System.Windows.Forms.Button();
            this.btnMatriculaItem = new System.Windows.Forms.Button();
            this.btnSalaItem = new System.Windows.Forms.Button();
            this.btnOrgaoItem = new System.Windows.Forms.Button();
            this.btnCentroCustoItem = new System.Windows.Forms.Button();
            this.btnTRGItem = new System.Windows.Forms.Button();
            this.dtpDataInventario = new System.Windows.Forms.DateTimePicker();
            this.lblNumeroInventario = new System.Windows.Forms.Label();
            this.lblDataInventario = new System.Windows.Forms.Label();
            this.tbpPrincipal = new System.Windows.Forms.TabPage();
            this.btnNivelBateria = new System.Windows.Forms.Button();
            this.txtMatriculaInventario = new System.Windows.Forms.TextBox();
            this.txtUsuarioInventario = new System.Windows.Forms.TextBox();
            this.btnModoCadastroInventario = new System.Windows.Forms.Button();
            this.btnDataTempoSistema = new System.Windows.Forms.Button();
            this.dtpDataSistema = new System.Windows.Forms.DateTimePicker();
            this.dtpTempoSistema = new System.Windows.Forms.DateTimePicker();
            this.lblNomeDispositivo = new System.Windows.Forms.Label();
            this.txtNomeDispositivo = new System.Windows.Forms.TextBox();
            this.pctUsuarioInventario = new System.Windows.Forms.PictureBox();
            this.lblUsuarioInventario = new System.Windows.Forms.Label();
            this.lblMatriculaInventario = new System.Windows.Forms.Label();
            this.tbc1 = new System.Windows.Forms.TabControl();
            this.tbpDadosComplementares = new System.Windows.Forms.TabPage();
            this.btnOutrosDadosItemAvancar = new System.Windows.Forms.Button();
            this.btnOutrosDadosItemRecuar = new System.Windows.Forms.Button();
            this.btnDadosComplementaresSelecionarButoesA = new System.Windows.Forms.Button();
            this.btnDadosComplementaresSelecionarButoesL = new System.Windows.Forms.Button();
            this.btnDadosComplementaresSelecionarButoes = new System.Windows.Forms.Button();
            this.btnIdentificacaoItemAvancar = new System.Windows.Forms.Button();
            this.btnIdentificacaoItemRecuar = new System.Windows.Forms.Button();
            this.txtIdentificacaoItem = new System.Windows.Forms.TextBox();
            this.txtOutrosDadosItem = new System.Windows.Forms.TextBox();
            this.btnOutrosDadosItemA = new System.Windows.Forms.Button();
            this.btnOutrosDadosItemL = new System.Windows.Forms.Button();
            this.btnOutrosDadosItem = new System.Windows.Forms.Button();
            this.btnIdentificacaoItemA = new System.Windows.Forms.Button();
            this.btnIdentificacaoItemL = new System.Windows.Forms.Button();
            this.btnIdentificacaoItem = new System.Windows.Forms.Button();
            this.btnObservacaoItemRecuar = new System.Windows.Forms.Button();
            this.btnObservacaoItemL = new System.Windows.Forms.Button();
            this.btnObservacaoItem = new System.Windows.Forms.Button();
            this.cmbObservacaoItem = new System.Windows.Forms.ComboBox();
            this.tbpRelatorios = new System.Windows.Forms.TabPage();
            this.tbc3 = new System.Windows.Forms.TabControl();
            this.tblContador = new System.Windows.Forms.TabPage();
            this.txtTabelaRelatorioFiltro = new System.Windows.Forms.TextBox();
            this.lblTabelaRelatorioFiltro = new System.Windows.Forms.Label();
            this.cmbConsultarCamposRelatorio = new System.Windows.Forms.ComboBox();
            this.cmbConsultarTabelaRelatorio = new System.Windows.Forms.ComboBox();
            this.dtg5 = new System.Windows.Forms.DataGrid();
            this.tblRepeticoes = new System.Windows.Forms.TabPage();
            this.lblRepeticoes = new System.Windows.Forms.Label();
            this.cmbConsultarInventarioRepeticoes = new System.Windows.Forms.ComboBox();
            this.txtRepeticoes = new System.Windows.Forms.TextBox();
            this.dtg6 = new System.Windows.Forms.DataGrid();
            this.tblRegistros = new System.Windows.Forms.TabPage();
            this.lblRelatorioExtra = new System.Windows.Forms.Label();
            this.btnRelatorioExtra = new System.Windows.Forms.Button();
            this.txtTabelaCentroCustoColunas = new System.Windows.Forms.Label();
            this.txtTabelaCentroCustoLinhas = new System.Windows.Forms.Label();
            this.lblTabelaCentroCustoColunas = new System.Windows.Forms.Label();
            this.lblTabelaCentroCustoLinhas = new System.Windows.Forms.Label();
            this.lblTabelaCentroCusto = new System.Windows.Forms.Label();
            this.txtTabelaEmpregadosColunas = new System.Windows.Forms.Label();
            this.txtTabelaEmpregadosLinhas = new System.Windows.Forms.Label();
            this.lblTabelaEmpregadosColunas = new System.Windows.Forms.Label();
            this.lblTabelaEmpregadosLinhas = new System.Windows.Forms.Label();
            this.lblTabelaEmpregados = new System.Windows.Forms.Label();
            this.txtTabelaSAPColunas = new System.Windows.Forms.Label();
            this.txtTabelaSAPLinhas = new System.Windows.Forms.Label();
            this.lblTabelaSAPColunas = new System.Windows.Forms.Label();
            this.lblTabelaSAPLinhas = new System.Windows.Forms.Label();
            this.lblTabelaSAP = new System.Windows.Forms.Label();
            this.txtTabelaInventarioBensColunas = new System.Windows.Forms.Label();
            this.txtTabelaInventarioBensLinhas = new System.Windows.Forms.Label();
            this.lblTabelaInventarioBensColunas = new System.Windows.Forms.Label();
            this.lblTabelaInventarioBensLinhas = new System.Windows.Forms.Label();
            this.lblTabelaInventarioBens = new System.Windows.Forms.Label();
            this.tbpFotografia = new System.Windows.Forms.TabPage();
            this.btnTirarFotografiaL = new System.Windows.Forms.Button();
            this.btnTravarFotografia = new System.Windows.Forms.Button();
            this.btnZerarFotografia = new System.Windows.Forms.Button();
            this.btnTirarFotografia = new System.Windows.Forms.Button();
            this.pctFotografia = new System.Windows.Forms.PictureBox();
            this.tbpGPS = new System.Windows.Forms.TabPage();
            this.btnGPSPerimeter = new System.Windows.Forms.Button();
            this.btnGPSMenu = new System.Windows.Forms.Button();
            this.lblGPSPositionDilutionOfPrecision = new System.Windows.Forms.Label();
            this.txtGPSPositionDilutionOfPrecision = new System.Windows.Forms.TextBox();
            this.lblEllipsoidAltitude = new System.Windows.Forms.Label();
            this.txtEllipsoidAltitude = new System.Windows.Forms.TextBox();
            this.lblGPSLongitude = new System.Windows.Forms.Label();
            this.txtGPSLongitude = new System.Windows.Forms.TextBox();
            this.lblGPSLatitute = new System.Windows.Forms.Label();
            this.txtGPSLatitute = new System.Windows.Forms.TextBox();
            this.lblGPSServiceState = new System.Windows.Forms.Label();
            this.txtGPSServiceState = new System.Windows.Forms.TextBox();
            this.lblGPSDeviceState = new System.Windows.Forms.Label();
            this.txtGPSDeviceState = new System.Windows.Forms.TextBox();
            this.lblGPSDeviceUsed = new System.Windows.Forms.Label();
            this.txtGPSDeviceUsed = new System.Windows.Forms.TextBox();
            this.tbpMapa = new System.Windows.Forms.TabPage();
            this.btnVisualizarMapa = new System.Windows.Forms.Button();
            this.tcbMapa = new System.Windows.Forms.TrackBar();
            this.wbMapa = new System.Windows.Forms.WebBrowser();
            this.tbpConfiguracoesExtras = new System.Windows.Forms.TabPage();
            this.chkProcuraAutomatica = new System.Windows.Forms.CheckBox();
            this.chkIncrementarPatrimonio = new System.Windows.Forms.CheckBox();
            this.chkPermitirExibicaoNotificacoes = new System.Windows.Forms.CheckBox();
            this.chkModoOtimizadoCadastro = new System.Windows.Forms.CheckBox();
            this.cmbPrioridadeModoOtimizadoCadastro = new System.Windows.Forms.ComboBox();
            this.lblPrioridadeModoOtimizadoCadastro = new System.Windows.Forms.Label();
            this.lblTipoMapa = new System.Windows.Forms.Label();
            this.cmbTipoMapa = new System.Windows.Forms.ComboBox();
            this.lblQualidadeFotografia = new System.Windows.Forms.Label();
            this.cmbQualidadeFotografia = new System.Windows.Forms.ComboBox();
            this.lblResolucaoFotografia = new System.Windows.Forms.Label();
            this.cmbResolucaoFotografia = new System.Windows.Forms.ComboBox();
            this.pctConfiguracoesExtras = new System.Windows.Forms.PictureBox();
            this.tbpZerarTabelas = new System.Windows.Forms.TabPage();
            this.txtSenhaZerarTabelas = new System.Windows.Forms.TextBox();
            this.lblSenhaZerarTabelas = new System.Windows.Forms.Label();
            this.lblDeletarTodosDados = new System.Windows.Forms.Label();
            this.lblZerarTabelaCentroCusto = new System.Windows.Forms.Label();
            this.btnZerarTabelaCentroCusto = new System.Windows.Forms.Button();
            this.lblZerarTabelaEmpregados = new System.Windows.Forms.Label();
            this.btnZerarTabelaEmpregados = new System.Windows.Forms.Button();
            this.lblZerarTabelaSAP = new System.Windows.Forms.Label();
            this.lblZerarTabelaInventarioBens = new System.Windows.Forms.Label();
            this.btnZerarTabelaSAP = new System.Windows.Forms.Button();
            this.btnZerarTabelaInventarioBens = new System.Windows.Forms.Button();
            this.tbpSair = new System.Windows.Forms.TabPage();
            this.btnTemporizadorCancelar = new System.Windows.Forms.Button();
            this.lblTemporizadorUnidade = new System.Windows.Forms.Label();
            this.txtTemporizador = new System.Windows.Forms.TextBox();
            this.lblTemporizador = new System.Windows.Forms.Label();
            this.btnForcarDesligamento = new System.Windows.Forms.Button();
            this.btnSairFazerBackup = new System.Windows.Forms.Button();
            this.lblTeclaPressionada = new System.Windows.Forms.Label();
            this.txtNumeroCopiasBackup = new System.Windows.Forms.TextBox();
            this.lblNumeroCopiasBackup = new System.Windows.Forms.Label();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnSobre = new System.Windows.Forms.Button();
            this.txtCodigoTeclaDigitado = new System.Windows.Forms.TextBox();
            this.pctSairAplicativo = new System.Windows.Forms.PictureBox();
            this.ntf1 = new Microsoft.WindowsCE.Forms.Notification();
            this.tmr1 = new System.Windows.Forms.Timer();
            this.tbpConfiguracoes.SuspendLayout();
            this.tbpTabelas.SuspendLayout();
            this.tbc2.SuspendLayout();
            this.tbpTabelaInventario.SuspendLayout();
            this.tbpTabelaSap.SuspendLayout();
            this.tbpTabelaEmpregados.SuspendLayout();
            this.tblTabelaCentroCusto.SuspendLayout();
            this.tbpDadosGerais.SuspendLayout();
            this.tbpControleFisico.SuspendLayout();
            this.tbpPrincipal.SuspendLayout();
            this.tbc1.SuspendLayout();
            this.tbpDadosComplementares.SuspendLayout();
            this.tbpRelatorios.SuspendLayout();
            this.tbc3.SuspendLayout();
            this.tblContador.SuspendLayout();
            this.tblRepeticoes.SuspendLayout();
            this.tblRegistros.SuspendLayout();
            this.tbpFotografia.SuspendLayout();
            this.tbpGPS.SuspendLayout();
            this.tbpMapa.SuspendLayout();
            this.tbpConfiguracoesExtras.SuspendLayout();
            this.tbpZerarTabelas.SuspendLayout();
            this.tbpSair.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnm1
            // 
            this.mnm1.MenuItems.Add(this.mni1);
            this.mnm1.MenuItems.Add(this.mni2);
            // 
            // mni1
            // 
            this.mni1.Text = "";
            this.mni1.Click += new System.EventHandler(this.mni1_Click);
            // 
            // mni2
            // 
            this.mni2.Text = "";
            this.mni2.Click += new System.EventHandler(this.mni2_Click);
            // 
            // ofd1
            // 
            this.ofd1.FileName = "*.sdf";
            // 
            // tbpConfiguracoes
            // 
            this.tbpConfiguracoes.Controls.Add(this.txtComprimentoColunas);
            this.tbpConfiguracoes.Controls.Add(this.lblComprimentoColunas);
            this.tbpConfiguracoes.Controls.Add(this.btnTestarConexao);
            this.tbpConfiguracoes.Controls.Add(this.btnFlashDisk);
            this.tbpConfiguracoes.Controls.Add(this.btnStorageCard);
            this.tbpConfiguracoes.Controls.Add(this.btnBatteryStatus);
            this.tbpConfiguracoes.Controls.Add(this.btnMonitorCarregamentoDados);
            this.tbpConfiguracoes.Controls.Add(this.lblEnderecoBaseDados);
            this.tbpConfiguracoes.Controls.Add(this.txtSenhaBaseDados);
            this.tbpConfiguracoes.Controls.Add(this.lblSenhaBaseDados);
            this.tbpConfiguracoes.Controls.Add(this.txtNumeroLinhas);
            this.tbpConfiguracoes.Controls.Add(this.lblNumeroLinhas);
            this.tbpConfiguracoes.Controls.Add(this.btnSincronizarHorarioServidor);
            this.tbpConfiguracoes.Controls.Add(this.pctConfiguracoes);
            this.tbpConfiguracoes.Controls.Add(this.btnCompactarRepararBancoDados);
            this.tbpConfiguracoes.Controls.Add(this.btnEnderecoBaseDados);
            this.tbpConfiguracoes.Controls.Add(this.txtEnderecoBaseDados);
            this.tbpConfiguracoes.Location = new System.Drawing.Point(0, 0);
            this.tbpConfiguracoes.Name = "tbpConfiguracoes";
            this.tbpConfiguracoes.Size = new System.Drawing.Size(232, 242);
            this.tbpConfiguracoes.Text = "Configurações";
            // 
            // txtComprimentoColunas
            // 
            this.txtComprimentoColunas.Location = new System.Drawing.Point(183, 127);
            this.txtComprimentoColunas.Name = "txtComprimentoColunas";
            this.txtComprimentoColunas.Size = new System.Drawing.Size(50, 21);
            this.txtComprimentoColunas.TabIndex = 8;
            this.txtComprimentoColunas.TextChanged += new System.EventHandler(this.txtComprimentoColunas_TextChanged);
            this.txtComprimentoColunas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtComprimentoColunas_KeyPress);
            // 
            // lblComprimentoColunas
            // 
            this.lblComprimentoColunas.BackColor = System.Drawing.Color.White;
            this.lblComprimentoColunas.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblComprimentoColunas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblComprimentoColunas.Location = new System.Drawing.Point(119, 128);
            this.lblComprimentoColunas.Name = "lblComprimentoColunas";
            this.lblComprimentoColunas.Size = new System.Drawing.Size(58, 20);
            this.lblComprimentoColunas.Text = "Colunas";
            this.lblComprimentoColunas.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnTestarConexao
            // 
            this.btnTestarConexao.BackColor = System.Drawing.Color.White;
            this.btnTestarConexao.ForeColor = System.Drawing.Color.RosyBrown;
            this.btnTestarConexao.Location = new System.Drawing.Point(7, 57);
            this.btnTestarConexao.Name = "btnTestarConexao";
            this.btnTestarConexao.Size = new System.Drawing.Size(226, 16);
            this.btnTestarConexao.TabIndex = 2;
            this.btnTestarConexao.Text = "&Testar Conexão";
            this.btnTestarConexao.Click += new System.EventHandler(this.btnTestarConexao_Click);
            // 
            // btnFlashDisk
            // 
            this.btnFlashDisk.BackColor = System.Drawing.Color.White;
            this.btnFlashDisk.ForeColor = System.Drawing.Color.SlateBlue;
            this.btnFlashDisk.Location = new System.Drawing.Point(123, 78);
            this.btnFlashDisk.Name = "btnFlashDisk";
            this.btnFlashDisk.Size = new System.Drawing.Size(110, 16);
            this.btnFlashDisk.TabIndex = 4;
            this.btnFlashDisk.Text = "&Flash Disk";
            this.btnFlashDisk.Click += new System.EventHandler(this.btnFlashDisk_Click);
            // 
            // btnStorageCard
            // 
            this.btnStorageCard.BackColor = System.Drawing.Color.White;
            this.btnStorageCard.ForeColor = System.Drawing.Color.OliveDrab;
            this.btnStorageCard.Location = new System.Drawing.Point(7, 78);
            this.btnStorageCard.Name = "btnStorageCard";
            this.btnStorageCard.Size = new System.Drawing.Size(110, 16);
            this.btnStorageCard.TabIndex = 3;
            this.btnStorageCard.Text = "&Storage Card";
            this.btnStorageCard.Click += new System.EventHandler(this.btnStorageCard_Click);
            // 
            // btnBatteryStatus
            // 
            this.btnBatteryStatus.BackColor = System.Drawing.Color.White;
            this.btnBatteryStatus.ForeColor = System.Drawing.Color.CadetBlue;
            this.btnBatteryStatus.Location = new System.Drawing.Point(7, 154);
            this.btnBatteryStatus.Name = "btnBatteryStatus";
            this.btnBatteryStatus.Size = new System.Drawing.Size(226, 16);
            this.btnBatteryStatus.TabIndex = 9;
            this.btnBatteryStatus.Text = "&Battery Status";
            this.btnBatteryStatus.Click += new System.EventHandler(this.btnBatteryStatus_Click);
            // 
            // btnMonitorCarregamentoDados
            // 
            this.btnMonitorCarregamentoDados.BackColor = System.Drawing.Color.White;
            this.btnMonitorCarregamentoDados.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnMonitorCarregamentoDados.ForeColor = System.Drawing.Color.Green;
            this.btnMonitorCarregamentoDados.Location = new System.Drawing.Point(7, 176);
            this.btnMonitorCarregamentoDados.Name = "btnMonitorCarregamentoDados";
            this.btnMonitorCarregamentoDados.Size = new System.Drawing.Size(226, 18);
            this.btnMonitorCarregamentoDados.TabIndex = 10;
            this.btnMonitorCarregamentoDados.Text = "&Monitor de Carregamento de Dados";
            this.btnMonitorCarregamentoDados.Click += new System.EventHandler(this.btnMonitorCarregamentoDados_Click);
            // 
            // lblEnderecoBaseDados
            // 
            this.lblEnderecoBaseDados.BackColor = System.Drawing.Color.White;
            this.lblEnderecoBaseDados.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblEnderecoBaseDados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblEnderecoBaseDados.Location = new System.Drawing.Point(53, 7);
            this.lblEnderecoBaseDados.Name = "lblEnderecoBaseDados";
            this.lblEnderecoBaseDados.Size = new System.Drawing.Size(180, 20);
            this.lblEnderecoBaseDados.Text = "Base de Dados";
            this.lblEnderecoBaseDados.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtSenhaBaseDados
            // 
            this.txtSenhaBaseDados.Location = new System.Drawing.Point(120, 30);
            this.txtSenhaBaseDados.Name = "txtSenhaBaseDados";
            this.txtSenhaBaseDados.PasswordChar = '*';
            this.txtSenhaBaseDados.Size = new System.Drawing.Size(113, 21);
            this.txtSenhaBaseDados.TabIndex = 1;
            this.txtSenhaBaseDados.TextChanged += new System.EventHandler(this.txtSenhaBaseDados_TextChanged);
            this.txtSenhaBaseDados.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSenhaBaseDados_KeyPress);
            // 
            // lblSenhaBaseDados
            // 
            this.lblSenhaBaseDados.BackColor = System.Drawing.Color.White;
            this.lblSenhaBaseDados.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblSenhaBaseDados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblSenhaBaseDados.Location = new System.Drawing.Point(53, 31);
            this.lblSenhaBaseDados.Name = "lblSenhaBaseDados";
            this.lblSenhaBaseDados.Size = new System.Drawing.Size(61, 20);
            this.lblSenhaBaseDados.Text = "Senha:";
            this.lblSenhaBaseDados.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtNumeroLinhas
            // 
            this.txtNumeroLinhas.Location = new System.Drawing.Point(63, 127);
            this.txtNumeroLinhas.Name = "txtNumeroLinhas";
            this.txtNumeroLinhas.Size = new System.Drawing.Size(50, 21);
            this.txtNumeroLinhas.TabIndex = 7;
            this.txtNumeroLinhas.TextChanged += new System.EventHandler(this.txtNumeroLinhas_TextChanged);
            this.txtNumeroLinhas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroLinhas_KeyPress);
            // 
            // lblNumeroLinhas
            // 
            this.lblNumeroLinhas.BackColor = System.Drawing.Color.White;
            this.lblNumeroLinhas.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblNumeroLinhas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblNumeroLinhas.Location = new System.Drawing.Point(7, 128);
            this.lblNumeroLinhas.Name = "lblNumeroLinhas";
            this.lblNumeroLinhas.Size = new System.Drawing.Size(50, 20);
            this.lblNumeroLinhas.Text = "Linhas";
            this.lblNumeroLinhas.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnSincronizarHorarioServidor
            // 
            this.btnSincronizarHorarioServidor.BackColor = System.Drawing.Color.White;
            this.btnSincronizarHorarioServidor.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnSincronizarHorarioServidor.ForeColor = System.Drawing.Color.Sienna;
            this.btnSincronizarHorarioServidor.Location = new System.Drawing.Point(7, 224);
            this.btnSincronizarHorarioServidor.Name = "btnSincronizarHorarioServidor";
            this.btnSincronizarHorarioServidor.Size = new System.Drawing.Size(226, 18);
            this.btnSincronizarHorarioServidor.TabIndex = 12;
            this.btnSincronizarHorarioServidor.Text = "Sincronizar &Horario com o Servidor";
            this.btnSincronizarHorarioServidor.Click += new System.EventHandler(this.btnSincronizarHorarioServidor_Click);
            // 
            // pctConfiguracoes
            // 
            this.pctConfiguracoes.Image = ((System.Drawing.Image)(resources.GetObject("pctConfiguracoes.Image")));
            this.pctConfiguracoes.Location = new System.Drawing.Point(7, 7);
            this.pctConfiguracoes.Name = "pctConfiguracoes";
            this.pctConfiguracoes.Size = new System.Drawing.Size(40, 40);
            this.pctConfiguracoes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // btnCompactarRepararBancoDados
            // 
            this.btnCompactarRepararBancoDados.BackColor = System.Drawing.Color.White;
            this.btnCompactarRepararBancoDados.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnCompactarRepararBancoDados.ForeColor = System.Drawing.Color.Olive;
            this.btnCompactarRepararBancoDados.Location = new System.Drawing.Point(7, 200);
            this.btnCompactarRepararBancoDados.Name = "btnCompactarRepararBancoDados";
            this.btnCompactarRepararBancoDados.Size = new System.Drawing.Size(226, 18);
            this.btnCompactarRepararBancoDados.TabIndex = 11;
            this.btnCompactarRepararBancoDados.Text = "&Compactar e Reparar Banco de Dados";
            this.btnCompactarRepararBancoDados.Click += new System.EventHandler(this.btnCompactarRepararBancoDados_Click);
            // 
            // btnEnderecoBaseDados
            // 
            this.btnEnderecoBaseDados.Location = new System.Drawing.Point(213, 100);
            this.btnEnderecoBaseDados.Name = "btnEnderecoBaseDados";
            this.btnEnderecoBaseDados.Size = new System.Drawing.Size(20, 21);
            this.btnEnderecoBaseDados.TabIndex = 6;
            this.btnEnderecoBaseDados.Text = "...";
            this.btnEnderecoBaseDados.Click += new System.EventHandler(this.btnEnderecoBaseDados_Click);
            // 
            // txtEnderecoBaseDados
            // 
            this.txtEnderecoBaseDados.Location = new System.Drawing.Point(7, 100);
            this.txtEnderecoBaseDados.Name = "txtEnderecoBaseDados";
            this.txtEnderecoBaseDados.Size = new System.Drawing.Size(200, 21);
            this.txtEnderecoBaseDados.TabIndex = 5;
            this.txtEnderecoBaseDados.TextChanged += new System.EventHandler(this.txtEnderecoBaseDados_TextChanged);
            // 
            // tbpTabelas
            // 
            this.tbpTabelas.Controls.Add(this.tbc2);
            this.tbpTabelas.Location = new System.Drawing.Point(0, 0);
            this.tbpTabelas.Name = "tbpTabelas";
            this.tbpTabelas.Size = new System.Drawing.Size(240, 245);
            this.tbpTabelas.Text = "Tabelas";
            // 
            // tbc2
            // 
            this.tbc2.Controls.Add(this.tbpTabelaInventario);
            this.tbc2.Controls.Add(this.tbpTabelaSap);
            this.tbc2.Controls.Add(this.tbpTabelaEmpregados);
            this.tbc2.Controls.Add(this.tblTabelaCentroCusto);
            this.tbc2.Location = new System.Drawing.Point(0, 0);
            this.tbc2.Name = "tbc2";
            this.tbc2.SelectedIndex = 0;
            this.tbc2.Size = new System.Drawing.Size(240, 242);
            this.tbc2.TabIndex = 61;
            this.tbc2.SelectedIndexChanged += new System.EventHandler(this.tbc2_SelectedIndexChanged);
            // 
            // tbpTabelaInventario
            // 
            this.tbpTabelaInventario.Controls.Add(this.cmbConsultarInventario);
            this.tbpTabelaInventario.Controls.Add(this.txtConsultarInventario);
            this.tbpTabelaInventario.Controls.Add(this.dtg1);
            this.tbpTabelaInventario.Location = new System.Drawing.Point(0, 0);
            this.tbpTabelaInventario.Name = "tbpTabelaInventario";
            this.tbpTabelaInventario.Size = new System.Drawing.Size(240, 219);
            this.tbpTabelaInventario.Text = "Inventario";
            // 
            // cmbConsultarInventario
            // 
            this.cmbConsultarInventario.Location = new System.Drawing.Point(7, 196);
            this.cmbConsultarInventario.Name = "cmbConsultarInventario";
            this.cmbConsultarInventario.Size = new System.Drawing.Size(110, 22);
            this.cmbConsultarInventario.TabIndex = 2;
            this.cmbConsultarInventario.GotFocus += new System.EventHandler(this.cmbConsultarInventario_GotFocus);
            // 
            // txtConsultarInventario
            // 
            this.txtConsultarInventario.Location = new System.Drawing.Point(123, 196);
            this.txtConsultarInventario.Name = "txtConsultarInventario";
            this.txtConsultarInventario.Size = new System.Drawing.Size(110, 21);
            this.txtConsultarInventario.TabIndex = 3;
            this.txtConsultarInventario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConsultarInventario_KeyPress);
            // 
            // dtg1
            // 
            this.dtg1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dtg1.GridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.dtg1.Location = new System.Drawing.Point(7, 7);
            this.dtg1.Name = "dtg1";
            this.dtg1.Size = new System.Drawing.Size(226, 187);
            this.dtg1.TabIndex = 1;
            this.dtg1.DoubleClick += new System.EventHandler(this.dtg1_DoubleClick);
            this.dtg1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtg1_KeyDown);
            this.dtg1.Click += new System.EventHandler(this.dtg1_Click);
            // 
            // tbpTabelaSap
            // 
            this.tbpTabelaSap.Controls.Add(this.cmbConsultarSAP);
            this.tbpTabelaSap.Controls.Add(this.txtConsultarSAP);
            this.tbpTabelaSap.Controls.Add(this.dtg2);
            this.tbpTabelaSap.Location = new System.Drawing.Point(0, 0);
            this.tbpTabelaSap.Name = "tbpTabelaSap";
            this.tbpTabelaSap.Size = new System.Drawing.Size(232, 216);
            this.tbpTabelaSap.Text = "SAP";
            // 
            // cmbConsultarSAP
            // 
            this.cmbConsultarSAP.Location = new System.Drawing.Point(7, 196);
            this.cmbConsultarSAP.Name = "cmbConsultarSAP";
            this.cmbConsultarSAP.Size = new System.Drawing.Size(110, 22);
            this.cmbConsultarSAP.TabIndex = 2;
            this.cmbConsultarSAP.GotFocus += new System.EventHandler(this.cmbConsultarSAP_GotFocus);
            // 
            // txtConsultarSAP
            // 
            this.txtConsultarSAP.Location = new System.Drawing.Point(123, 196);
            this.txtConsultarSAP.Name = "txtConsultarSAP";
            this.txtConsultarSAP.Size = new System.Drawing.Size(110, 21);
            this.txtConsultarSAP.TabIndex = 3;
            this.txtConsultarSAP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConsultarSAP_KeyPress);
            // 
            // dtg2
            // 
            this.dtg2.BackgroundColor = System.Drawing.Color.LavenderBlush;
            this.dtg2.GridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.dtg2.Location = new System.Drawing.Point(7, 7);
            this.dtg2.Name = "dtg2";
            this.dtg2.Size = new System.Drawing.Size(226, 187);
            this.dtg2.TabIndex = 1;
            this.dtg2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtg2_KeyDown);
            this.dtg2.Click += new System.EventHandler(this.dtg2_Click);
            // 
            // tbpTabelaEmpregados
            // 
            this.tbpTabelaEmpregados.Controls.Add(this.cmbConsultarEmpregados);
            this.tbpTabelaEmpregados.Controls.Add(this.txtConsultarEmpregados);
            this.tbpTabelaEmpregados.Controls.Add(this.dtg3);
            this.tbpTabelaEmpregados.Location = new System.Drawing.Point(0, 0);
            this.tbpTabelaEmpregados.Name = "tbpTabelaEmpregados";
            this.tbpTabelaEmpregados.Size = new System.Drawing.Size(232, 216);
            this.tbpTabelaEmpregados.Text = "Empregados";
            // 
            // cmbConsultarEmpregados
            // 
            this.cmbConsultarEmpregados.Location = new System.Drawing.Point(7, 196);
            this.cmbConsultarEmpregados.Name = "cmbConsultarEmpregados";
            this.cmbConsultarEmpregados.Size = new System.Drawing.Size(110, 22);
            this.cmbConsultarEmpregados.TabIndex = 2;
            this.cmbConsultarEmpregados.GotFocus += new System.EventHandler(this.cmbConsultarEmpregados_GotFocus);
            // 
            // txtConsultarEmpregados
            // 
            this.txtConsultarEmpregados.Location = new System.Drawing.Point(123, 196);
            this.txtConsultarEmpregados.Name = "txtConsultarEmpregados";
            this.txtConsultarEmpregados.Size = new System.Drawing.Size(110, 21);
            this.txtConsultarEmpregados.TabIndex = 3;
            this.txtConsultarEmpregados.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConsultarEmpregados_KeyPress);
            // 
            // dtg3
            // 
            this.dtg3.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtg3.GridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.dtg3.Location = new System.Drawing.Point(7, 7);
            this.dtg3.Name = "dtg3";
            this.dtg3.Size = new System.Drawing.Size(226, 187);
            this.dtg3.TabIndex = 1;
            this.dtg3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtg3_KeyDown);
            this.dtg3.Click += new System.EventHandler(this.dtg3_Click);
            // 
            // tblTabelaCentroCusto
            // 
            this.tblTabelaCentroCusto.Controls.Add(this.cmbConsultarCentroCusto);
            this.tblTabelaCentroCusto.Controls.Add(this.txtConsultarCentroCusto);
            this.tblTabelaCentroCusto.Controls.Add(this.dtg4);
            this.tblTabelaCentroCusto.Location = new System.Drawing.Point(0, 0);
            this.tblTabelaCentroCusto.Name = "tblTabelaCentroCusto";
            this.tblTabelaCentroCusto.Size = new System.Drawing.Size(232, 216);
            this.tblTabelaCentroCusto.Text = "Centro Custo";
            // 
            // cmbConsultarCentroCusto
            // 
            this.cmbConsultarCentroCusto.Location = new System.Drawing.Point(7, 196);
            this.cmbConsultarCentroCusto.Name = "cmbConsultarCentroCusto";
            this.cmbConsultarCentroCusto.Size = new System.Drawing.Size(110, 22);
            this.cmbConsultarCentroCusto.TabIndex = 2;
            this.cmbConsultarCentroCusto.GotFocus += new System.EventHandler(this.cmbConsultarCentroCusto_GotFocus);
            // 
            // txtConsultarCentroCusto
            // 
            this.txtConsultarCentroCusto.Location = new System.Drawing.Point(123, 196);
            this.txtConsultarCentroCusto.Name = "txtConsultarCentroCusto";
            this.txtConsultarCentroCusto.Size = new System.Drawing.Size(110, 21);
            this.txtConsultarCentroCusto.TabIndex = 3;
            this.txtConsultarCentroCusto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConsultarCentroCusto_KeyPress);
            // 
            // dtg4
            // 
            this.dtg4.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtg4.GridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.dtg4.Location = new System.Drawing.Point(7, 7);
            this.dtg4.Name = "dtg4";
            this.dtg4.Size = new System.Drawing.Size(226, 187);
            this.dtg4.TabIndex = 1;
            this.dtg4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtg4_KeyDown);
            this.dtg4.Click += new System.EventHandler(this.dtg4_Click);
            // 
            // tbpDadosGerais
            // 
            this.tbpDadosGerais.Controls.Add(this.btnPatrimonioItemOutrosDadosItem);
            this.tbpDadosGerais.Controls.Add(this.btnPatrimonioItemIdentificacaoItem);
            this.tbpDadosGerais.Controls.Add(this.btnNSerieItemOutrosDadosItem);
            this.tbpDadosGerais.Controls.Add(this.btnNSerieItemIdentificacaoItem);
            this.tbpDadosGerais.Controls.Add(this.btnDadosGeraisSelecionarButoesA);
            this.tbpDadosGerais.Controls.Add(this.btnDadosGeraisSelecionarButoesL);
            this.tbpDadosGerais.Controls.Add(this.btnDadosGeraisSelecionarButoes);
            this.tbpDadosGerais.Controls.Add(this.lblQuantidadeItem);
            this.tbpDadosGerais.Controls.Add(this.txtQuantidadeItem);
            this.tbpDadosGerais.Controls.Add(this.btnSemPatrimonio);
            this.tbpDadosGerais.Controls.Add(this.txtPlacaVeiculoItem);
            this.tbpDadosGerais.Controls.Add(this.txtNSerieItem);
            this.tbpDadosGerais.Controls.Add(this.txtDenominacaoItem);
            this.tbpDadosGerais.Controls.Add(this.txtPatrimonioItem);
            this.tbpDadosGerais.Controls.Add(this.btnPlacaVeiculoItemA);
            this.tbpDadosGerais.Controls.Add(this.btnPlacaVeiculoItemL);
            this.tbpDadosGerais.Controls.Add(this.btnNSerieItemA);
            this.tbpDadosGerais.Controls.Add(this.btnNSerieItemL);
            this.tbpDadosGerais.Controls.Add(this.btnDenominacaoItemA);
            this.tbpDadosGerais.Controls.Add(this.btnDenominacaoItemL);
            this.tbpDadosGerais.Controls.Add(this.btnPatrimonioItemL);
            this.tbpDadosGerais.Controls.Add(this.btnPatrimonioItemA);
            this.tbpDadosGerais.Controls.Add(this.btnPlacaVeiculoItem);
            this.tbpDadosGerais.Controls.Add(this.btnNSerieItem);
            this.tbpDadosGerais.Controls.Add(this.btnDenominacaoItem);
            this.tbpDadosGerais.Controls.Add(this.btnPatrimonioItem);
            this.tbpDadosGerais.Location = new System.Drawing.Point(0, 0);
            this.tbpDadosGerais.Name = "tbpDadosGerais";
            this.tbpDadosGerais.Size = new System.Drawing.Size(240, 245);
            this.tbpDadosGerais.Text = "Dados Gerais";
            // 
            // btnPatrimonioItemOutrosDadosItem
            // 
            this.btnPatrimonioItemOutrosDadosItem.BackColor = System.Drawing.Color.White;
            this.btnPatrimonioItemOutrosDadosItem.ForeColor = System.Drawing.Color.Olive;
            this.btnPatrimonioItemOutrosDadosItem.Location = new System.Drawing.Point(213, 30);
            this.btnPatrimonioItemOutrosDadosItem.Name = "btnPatrimonioItemOutrosDadosItem";
            this.btnPatrimonioItemOutrosDadosItem.Size = new System.Drawing.Size(20, 21);
            this.btnPatrimonioItemOutrosDadosItem.TabIndex = 6;
            this.btnPatrimonioItemOutrosDadosItem.Text = "O";
            this.btnPatrimonioItemOutrosDadosItem.Click += new System.EventHandler(this.btnPatrimonioItemOutrosDadosItem_Click);
            // 
            // btnPatrimonioItemIdentificacaoItem
            // 
            this.btnPatrimonioItemIdentificacaoItem.BackColor = System.Drawing.Color.White;
            this.btnPatrimonioItemIdentificacaoItem.ForeColor = System.Drawing.Color.Sienna;
            this.btnPatrimonioItemIdentificacaoItem.Location = new System.Drawing.Point(7, 30);
            this.btnPatrimonioItemIdentificacaoItem.Name = "btnPatrimonioItemIdentificacaoItem";
            this.btnPatrimonioItemIdentificacaoItem.Size = new System.Drawing.Size(20, 21);
            this.btnPatrimonioItemIdentificacaoItem.TabIndex = 4;
            this.btnPatrimonioItemIdentificacaoItem.Text = "I";
            this.btnPatrimonioItemIdentificacaoItem.Click += new System.EventHandler(this.btnPatrimonioItemIdentificacaoItem_Click);
            // 
            // btnNSerieItemOutrosDadosItem
            // 
            this.btnNSerieItemOutrosDadosItem.BackColor = System.Drawing.Color.White;
            this.btnNSerieItemOutrosDadosItem.ForeColor = System.Drawing.Color.Olive;
            this.btnNSerieItemOutrosDadosItem.Location = new System.Drawing.Point(213, 170);
            this.btnNSerieItemOutrosDadosItem.Name = "btnNSerieItemOutrosDadosItem";
            this.btnNSerieItemOutrosDadosItem.Size = new System.Drawing.Size(20, 21);
            this.btnNSerieItemOutrosDadosItem.TabIndex = 21;
            this.btnNSerieItemOutrosDadosItem.Text = "O";
            this.btnNSerieItemOutrosDadosItem.Click += new System.EventHandler(this.btnNSerieItemOutrosDadosItem_Click);
            // 
            // btnNSerieItemIdentificacaoItem
            // 
            this.btnNSerieItemIdentificacaoItem.BackColor = System.Drawing.Color.White;
            this.btnNSerieItemIdentificacaoItem.ForeColor = System.Drawing.Color.Sienna;
            this.btnNSerieItemIdentificacaoItem.Location = new System.Drawing.Point(7, 170);
            this.btnNSerieItemIdentificacaoItem.Name = "btnNSerieItemIdentificacaoItem";
            this.btnNSerieItemIdentificacaoItem.Size = new System.Drawing.Size(20, 21);
            this.btnNSerieItemIdentificacaoItem.TabIndex = 19;
            this.btnNSerieItemIdentificacaoItem.Text = "I";
            this.btnNSerieItemIdentificacaoItem.Click += new System.EventHandler(this.btnNSerieItemIdentificacaoItem_Click);
            // 
            // btnDadosGeraisSelecionarButoesA
            // 
            this.btnDadosGeraisSelecionarButoesA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDadosGeraisSelecionarButoesA.Enabled = false;
            this.btnDadosGeraisSelecionarButoesA.Location = new System.Drawing.Point(7, 57);
            this.btnDadosGeraisSelecionarButoesA.Name = "btnDadosGeraisSelecionarButoesA";
            this.btnDadosGeraisSelecionarButoesA.Size = new System.Drawing.Size(48, 15);
            this.btnDadosGeraisSelecionarButoesA.TabIndex = 7;
            this.btnDadosGeraisSelecionarButoesA.Click += new System.EventHandler(this.btnDadosGeraisSelecionarButoesA_Click);
            // 
            // btnDadosGeraisSelecionarButoesL
            // 
            this.btnDadosGeraisSelecionarButoesL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDadosGeraisSelecionarButoesL.Location = new System.Drawing.Point(61, 57);
            this.btnDadosGeraisSelecionarButoesL.Name = "btnDadosGeraisSelecionarButoesL";
            this.btnDadosGeraisSelecionarButoesL.Size = new System.Drawing.Size(48, 15);
            this.btnDadosGeraisSelecionarButoesL.TabIndex = 9;
            this.btnDadosGeraisSelecionarButoesL.Click += new System.EventHandler(this.btnDadosGeraisSelecionarButoesL_Click);
            // 
            // btnDadosGeraisSelecionarButoes
            // 
            this.btnDadosGeraisSelecionarButoes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnDadosGeraisSelecionarButoes.Location = new System.Drawing.Point(7, 77);
            this.btnDadosGeraisSelecionarButoes.Name = "btnDadosGeraisSelecionarButoes";
            this.btnDadosGeraisSelecionarButoes.Size = new System.Drawing.Size(48, 15);
            this.btnDadosGeraisSelecionarButoes.TabIndex = 8;
            this.btnDadosGeraisSelecionarButoes.Click += new System.EventHandler(this.btnDadosGeraisSelecionarButoes_Click);
            // 
            // lblQuantidadeItem
            // 
            this.lblQuantidadeItem.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblQuantidadeItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblQuantidadeItem.Location = new System.Drawing.Point(61, 77);
            this.lblQuantidadeItem.Name = "lblQuantidadeItem";
            this.lblQuantidadeItem.Size = new System.Drawing.Size(48, 15);
            this.lblQuantidadeItem.Text = "Qtd.:";
            // 
            // txtQuantidadeItem
            // 
            this.txtQuantidadeItem.Location = new System.Drawing.Point(115, 71);
            this.txtQuantidadeItem.Name = "txtQuantidadeItem";
            this.txtQuantidadeItem.Size = new System.Drawing.Size(118, 21);
            this.txtQuantidadeItem.TabIndex = 11;
            this.txtQuantidadeItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantidadeItem_KeyPress);
            this.txtQuantidadeItem.LostFocus += new System.EventHandler(this.txtQuantidadeItem_LostFocus);
            // 
            // btnSemPatrimonio
            // 
            this.btnSemPatrimonio.BackColor = System.Drawing.Color.White;
            this.btnSemPatrimonio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSemPatrimonio.Location = new System.Drawing.Point(115, 53);
            this.btnSemPatrimonio.Name = "btnSemPatrimonio";
            this.btnSemPatrimonio.Size = new System.Drawing.Size(118, 16);
            this.btnSemPatrimonio.TabIndex = 10;
            this.btnSemPatrimonio.Text = "Sem Patrimônio";
            this.btnSemPatrimonio.Click += new System.EventHandler(this.btnSemPatrimonio_Click);
            // 
            // txtPlacaVeiculoItem
            // 
            this.txtPlacaVeiculoItem.Location = new System.Drawing.Point(7, 221);
            this.txtPlacaVeiculoItem.Name = "txtPlacaVeiculoItem";
            this.txtPlacaVeiculoItem.Size = new System.Drawing.Size(226, 21);
            this.txtPlacaVeiculoItem.TabIndex = 25;
            this.txtPlacaVeiculoItem.GotFocus += new System.EventHandler(this.txtPlacaVeiculoItem_GotFocus);
            this.txtPlacaVeiculoItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPlacaVeiculoItem_KeyPress);
            this.txtPlacaVeiculoItem.LostFocus += new System.EventHandler(this.txtPlacaVeiculoItem_LostFocus);
            // 
            // txtNSerieItem
            // 
            this.txtNSerieItem.Location = new System.Drawing.Point(33, 171);
            this.txtNSerieItem.Name = "txtNSerieItem";
            this.txtNSerieItem.Size = new System.Drawing.Size(174, 21);
            this.txtNSerieItem.TabIndex = 20;
            this.txtNSerieItem.TextChanged += new System.EventHandler(this.txtNSerieItem_TextChanged);
            this.txtNSerieItem.GotFocus += new System.EventHandler(this.txtNSerieItem_GotFocus);
            this.txtNSerieItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNSerieItem_KeyPress);
            this.txtNSerieItem.LostFocus += new System.EventHandler(this.txtNSerieItem_LostFocus);
            // 
            // txtDenominacaoItem
            // 
            this.txtDenominacaoItem.Location = new System.Drawing.Point(7, 121);
            this.txtDenominacaoItem.Name = "txtDenominacaoItem";
            this.txtDenominacaoItem.Size = new System.Drawing.Size(226, 21);
            this.txtDenominacaoItem.TabIndex = 15;
            this.txtDenominacaoItem.TextChanged += new System.EventHandler(this.txtDenominacaoItem_TextChanged);
            this.txtDenominacaoItem.GotFocus += new System.EventHandler(this.txtDenominacaoItem_GotFocus);
            this.txtDenominacaoItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDenominacaoItem_KeyPress);
            this.txtDenominacaoItem.LostFocus += new System.EventHandler(this.txtDenominacaoItem_LostFocus);
            // 
            // txtPatrimonioItem
            // 
            this.txtPatrimonioItem.Location = new System.Drawing.Point(33, 30);
            this.txtPatrimonioItem.Name = "txtPatrimonioItem";
            this.txtPatrimonioItem.Size = new System.Drawing.Size(174, 21);
            this.txtPatrimonioItem.TabIndex = 5;
            this.txtPatrimonioItem.TextChanged += new System.EventHandler(this.txtPatrimonioItem_TextChanged);
            this.txtPatrimonioItem.GotFocus += new System.EventHandler(this.txtPatrimonioItem_GotFocus);
            this.txtPatrimonioItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPatrimonioItem_KeyPress);
            this.txtPatrimonioItem.LostFocus += new System.EventHandler(this.txtPatrimonioItem_LostFocus);
            // 
            // btnPlacaVeiculoItemA
            // 
            this.btnPlacaVeiculoItemA.BackColor = System.Drawing.Color.White;
            this.btnPlacaVeiculoItemA.Enabled = false;
            this.btnPlacaVeiculoItemA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPlacaVeiculoItemA.Location = new System.Drawing.Point(7, 198);
            this.btnPlacaVeiculoItemA.Name = "btnPlacaVeiculoItemA";
            this.btnPlacaVeiculoItemA.Size = new System.Drawing.Size(20, 16);
            this.btnPlacaVeiculoItemA.TabIndex = 22;
            this.btnPlacaVeiculoItemA.Text = "A";
            this.btnPlacaVeiculoItemA.Click += new System.EventHandler(this.btnPlacaVeiculoItemA_Click);
            // 
            // btnPlacaVeiculoItemL
            // 
            this.btnPlacaVeiculoItemL.BackColor = System.Drawing.Color.White;
            this.btnPlacaVeiculoItemL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPlacaVeiculoItemL.Location = new System.Drawing.Point(213, 198);
            this.btnPlacaVeiculoItemL.Name = "btnPlacaVeiculoItemL";
            this.btnPlacaVeiculoItemL.Size = new System.Drawing.Size(20, 16);
            this.btnPlacaVeiculoItemL.TabIndex = 24;
            this.btnPlacaVeiculoItemL.Text = "L";
            this.btnPlacaVeiculoItemL.Click += new System.EventHandler(this.btnPlacaVeiculoItemL_Click);
            // 
            // btnNSerieItemA
            // 
            this.btnNSerieItemA.BackColor = System.Drawing.Color.White;
            this.btnNSerieItemA.Enabled = false;
            this.btnNSerieItemA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnNSerieItemA.Location = new System.Drawing.Point(7, 148);
            this.btnNSerieItemA.Name = "btnNSerieItemA";
            this.btnNSerieItemA.Size = new System.Drawing.Size(20, 16);
            this.btnNSerieItemA.TabIndex = 16;
            this.btnNSerieItemA.Text = "A";
            this.btnNSerieItemA.Click += new System.EventHandler(this.btnNSerieItemA_Click);
            // 
            // btnNSerieItemL
            // 
            this.btnNSerieItemL.BackColor = System.Drawing.Color.White;
            this.btnNSerieItemL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnNSerieItemL.Location = new System.Drawing.Point(213, 148);
            this.btnNSerieItemL.Name = "btnNSerieItemL";
            this.btnNSerieItemL.Size = new System.Drawing.Size(20, 16);
            this.btnNSerieItemL.TabIndex = 18;
            this.btnNSerieItemL.Text = "L";
            this.btnNSerieItemL.Click += new System.EventHandler(this.btnNSerieItemL_Click);
            // 
            // btnDenominacaoItemA
            // 
            this.btnDenominacaoItemA.BackColor = System.Drawing.Color.White;
            this.btnDenominacaoItemA.Enabled = false;
            this.btnDenominacaoItemA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnDenominacaoItemA.Location = new System.Drawing.Point(7, 98);
            this.btnDenominacaoItemA.Name = "btnDenominacaoItemA";
            this.btnDenominacaoItemA.Size = new System.Drawing.Size(20, 16);
            this.btnDenominacaoItemA.TabIndex = 12;
            this.btnDenominacaoItemA.Text = "A";
            this.btnDenominacaoItemA.Click += new System.EventHandler(this.btnDenominacaoItemA_Click);
            // 
            // btnDenominacaoItemL
            // 
            this.btnDenominacaoItemL.BackColor = System.Drawing.Color.White;
            this.btnDenominacaoItemL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDenominacaoItemL.Location = new System.Drawing.Point(213, 98);
            this.btnDenominacaoItemL.Name = "btnDenominacaoItemL";
            this.btnDenominacaoItemL.Size = new System.Drawing.Size(20, 16);
            this.btnDenominacaoItemL.TabIndex = 14;
            this.btnDenominacaoItemL.Text = "L";
            this.btnDenominacaoItemL.Click += new System.EventHandler(this.btnDenominacaoItemL_Click);
            // 
            // btnPatrimonioItemL
            // 
            this.btnPatrimonioItemL.BackColor = System.Drawing.Color.White;
            this.btnPatrimonioItemL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPatrimonioItemL.Location = new System.Drawing.Point(213, 7);
            this.btnPatrimonioItemL.Name = "btnPatrimonioItemL";
            this.btnPatrimonioItemL.Size = new System.Drawing.Size(20, 16);
            this.btnPatrimonioItemL.TabIndex = 3;
            this.btnPatrimonioItemL.Text = "L";
            this.btnPatrimonioItemL.Click += new System.EventHandler(this.btnPatrimonioItemL_Click);
            // 
            // btnPatrimonioItemA
            // 
            this.btnPatrimonioItemA.BackColor = System.Drawing.Color.White;
            this.btnPatrimonioItemA.Enabled = false;
            this.btnPatrimonioItemA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnPatrimonioItemA.Location = new System.Drawing.Point(7, 7);
            this.btnPatrimonioItemA.Name = "btnPatrimonioItemA";
            this.btnPatrimonioItemA.Size = new System.Drawing.Size(20, 16);
            this.btnPatrimonioItemA.TabIndex = 1;
            this.btnPatrimonioItemA.Text = "A";
            this.btnPatrimonioItemA.Click += new System.EventHandler(this.btnPatrimonioItemA_Click);
            // 
            // btnPlacaVeiculoItem
            // 
            this.btnPlacaVeiculoItem.BackColor = System.Drawing.Color.White;
            this.btnPlacaVeiculoItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnPlacaVeiculoItem.Location = new System.Drawing.Point(33, 198);
            this.btnPlacaVeiculoItem.Name = "btnPlacaVeiculoItem";
            this.btnPlacaVeiculoItem.Size = new System.Drawing.Size(174, 16);
            this.btnPlacaVeiculoItem.TabIndex = 23;
            this.btnPlacaVeiculoItem.Text = "Placa do Veículo";
            this.btnPlacaVeiculoItem.Click += new System.EventHandler(this.btnPlacaVeiculoItem_Click);
            // 
            // btnNSerieItem
            // 
            this.btnNSerieItem.BackColor = System.Drawing.Color.White;
            this.btnNSerieItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnNSerieItem.Location = new System.Drawing.Point(33, 148);
            this.btnNSerieItem.Name = "btnNSerieItem";
            this.btnNSerieItem.Size = new System.Drawing.Size(174, 16);
            this.btnNSerieItem.TabIndex = 17;
            this.btnNSerieItem.Text = "Número de Série";
            this.btnNSerieItem.Click += new System.EventHandler(this.btnNSerieItem_Click);
            // 
            // btnDenominacaoItem
            // 
            this.btnDenominacaoItem.BackColor = System.Drawing.Color.White;
            this.btnDenominacaoItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnDenominacaoItem.Location = new System.Drawing.Point(33, 98);
            this.btnDenominacaoItem.Name = "btnDenominacaoItem";
            this.btnDenominacaoItem.Size = new System.Drawing.Size(174, 16);
            this.btnDenominacaoItem.TabIndex = 13;
            this.btnDenominacaoItem.Text = "Denominação";
            this.btnDenominacaoItem.Click += new System.EventHandler(this.btnDenominacaoItem_Click);
            // 
            // btnPatrimonioItem
            // 
            this.btnPatrimonioItem.BackColor = System.Drawing.Color.White;
            this.btnPatrimonioItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnPatrimonioItem.Location = new System.Drawing.Point(33, 7);
            this.btnPatrimonioItem.Name = "btnPatrimonioItem";
            this.btnPatrimonioItem.Size = new System.Drawing.Size(174, 16);
            this.btnPatrimonioItem.TabIndex = 2;
            this.btnPatrimonioItem.Text = "Patrimônio";
            this.btnPatrimonioItem.Click += new System.EventHandler(this.btnPatrimonioItem_Click);
            // 
            // tbpControleFisico
            // 
            this.tbpControleFisico.Controls.Add(this.txtMatriculaItem);
            this.tbpControleFisico.Controls.Add(this.txtNomeItem);
            this.tbpControleFisico.Controls.Add(this.txtSalaItem);
            this.tbpControleFisico.Controls.Add(this.txtOrgaoItem);
            this.tbpControleFisico.Controls.Add(this.txtCentroCustoItem);
            this.tbpControleFisico.Controls.Add(this.txtTRGItem);
            this.tbpControleFisico.Controls.Add(this.btnControleFisicoSelecionarButoesL);
            this.tbpControleFisico.Controls.Add(this.btnControleFisicoSelecionarButoesA);
            this.tbpControleFisico.Controls.Add(this.btnMatriculaItemL);
            this.tbpControleFisico.Controls.Add(this.btnMatriculaItemA);
            this.tbpControleFisico.Controls.Add(this.btnNomeItemL);
            this.tbpControleFisico.Controls.Add(this.btnNomeItemA);
            this.tbpControleFisico.Controls.Add(this.btnSalaItemL);
            this.tbpControleFisico.Controls.Add(this.btnSalaItemA);
            this.tbpControleFisico.Controls.Add(this.btnOrgaoItemL);
            this.tbpControleFisico.Controls.Add(this.btnOrgaoItemA);
            this.tbpControleFisico.Controls.Add(this.btnCentroCustoItemL);
            this.tbpControleFisico.Controls.Add(this.btnCentroCustoItemA);
            this.tbpControleFisico.Controls.Add(this.btnTRGItemL);
            this.tbpControleFisico.Controls.Add(this.btnTRGItemA);
            this.tbpControleFisico.Controls.Add(this.txtNumeroInventario);
            this.tbpControleFisico.Controls.Add(this.btnControleFisicoSelecionarButoes);
            this.tbpControleFisico.Controls.Add(this.btnNomeItem);
            this.tbpControleFisico.Controls.Add(this.btnMatriculaItem);
            this.tbpControleFisico.Controls.Add(this.btnSalaItem);
            this.tbpControleFisico.Controls.Add(this.btnOrgaoItem);
            this.tbpControleFisico.Controls.Add(this.btnCentroCustoItem);
            this.tbpControleFisico.Controls.Add(this.btnTRGItem);
            this.tbpControleFisico.Controls.Add(this.dtpDataInventario);
            this.tbpControleFisico.Controls.Add(this.lblNumeroInventario);
            this.tbpControleFisico.Controls.Add(this.lblDataInventario);
            this.tbpControleFisico.Location = new System.Drawing.Point(0, 0);
            this.tbpControleFisico.Name = "tbpControleFisico";
            this.tbpControleFisico.Size = new System.Drawing.Size(232, 242);
            this.tbpControleFisico.Text = "Controle Físico";
            // 
            // txtMatriculaItem
            // 
            this.txtMatriculaItem.Location = new System.Drawing.Point(123, 200);
            this.txtMatriculaItem.Name = "txtMatriculaItem";
            this.txtMatriculaItem.Size = new System.Drawing.Size(110, 21);
            this.txtMatriculaItem.TabIndex = 25;
            this.txtMatriculaItem.GotFocus += new System.EventHandler(this.txtMatriculaItem_GotFocus);
            this.txtMatriculaItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMatriculaItem_KeyPress);
            this.txtMatriculaItem.LostFocus += new System.EventHandler(this.txtMatriculaItem_LostFocus);
            // 
            // txtNomeItem
            // 
            this.txtNomeItem.Location = new System.Drawing.Point(7, 200);
            this.txtNomeItem.Name = "txtNomeItem";
            this.txtNomeItem.Size = new System.Drawing.Size(110, 21);
            this.txtNomeItem.TabIndex = 24;
            this.txtNomeItem.GotFocus += new System.EventHandler(this.txtNomeItem_GotFocus);
            this.txtNomeItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNomeItem_KeyPress);
            this.txtNomeItem.LostFocus += new System.EventHandler(this.txtNomeItem_LostFocus);
            // 
            // txtSalaItem
            // 
            this.txtSalaItem.Location = new System.Drawing.Point(123, 150);
            this.txtSalaItem.Name = "txtSalaItem";
            this.txtSalaItem.Size = new System.Drawing.Size(110, 21);
            this.txtSalaItem.TabIndex = 17;
            this.txtSalaItem.GotFocus += new System.EventHandler(this.txtSalaItem_GotFocus);
            this.txtSalaItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSalaItem_KeyPress);
            this.txtSalaItem.LostFocus += new System.EventHandler(this.txtSalaItem_LostFocus);
            // 
            // txtOrgaoItem
            // 
            this.txtOrgaoItem.Location = new System.Drawing.Point(7, 150);
            this.txtOrgaoItem.Name = "txtOrgaoItem";
            this.txtOrgaoItem.Size = new System.Drawing.Size(110, 21);
            this.txtOrgaoItem.TabIndex = 16;
            this.txtOrgaoItem.GotFocus += new System.EventHandler(this.txtOrgaoItem_GotFocus);
            this.txtOrgaoItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOrgaoItem_KeyPress);
            this.txtOrgaoItem.LostFocus += new System.EventHandler(this.txtOrgaoItem_LostFocus);
            // 
            // txtCentroCustoItem
            // 
            this.txtCentroCustoItem.Location = new System.Drawing.Point(123, 100);
            this.txtCentroCustoItem.Name = "txtCentroCustoItem";
            this.txtCentroCustoItem.Size = new System.Drawing.Size(110, 21);
            this.txtCentroCustoItem.TabIndex = 9;
            this.txtCentroCustoItem.GotFocus += new System.EventHandler(this.txtCentroCustoItem_GotFocus);
            this.txtCentroCustoItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCentroCustoItem_KeyPress);
            this.txtCentroCustoItem.LostFocus += new System.EventHandler(this.txtCentroCustoItem_LostFocus);
            // 
            // txtTRGItem
            // 
            this.txtTRGItem.Location = new System.Drawing.Point(7, 100);
            this.txtTRGItem.Name = "txtTRGItem";
            this.txtTRGItem.Size = new System.Drawing.Size(110, 21);
            this.txtTRGItem.TabIndex = 8;
            this.txtTRGItem.GotFocus += new System.EventHandler(this.txtTRGItem_GotFocus);
            this.txtTRGItem.LostFocus += new System.EventHandler(this.txtTRGItem_LostFocus);
            // 
            // btnControleFisicoSelecionarButoesL
            // 
            this.btnControleFisicoSelecionarButoesL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnControleFisicoSelecionarButoesL.Location = new System.Drawing.Point(203, 227);
            this.btnControleFisicoSelecionarButoesL.Name = "btnControleFisicoSelecionarButoesL";
            this.btnControleFisicoSelecionarButoesL.Size = new System.Drawing.Size(30, 15);
            this.btnControleFisicoSelecionarButoesL.TabIndex = 28;
            this.btnControleFisicoSelecionarButoesL.Click += new System.EventHandler(this.btnControleFisicoSelecionarButoesL_Click);
            // 
            // btnControleFisicoSelecionarButoesA
            // 
            this.btnControleFisicoSelecionarButoesA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnControleFisicoSelecionarButoesA.Location = new System.Drawing.Point(7, 227);
            this.btnControleFisicoSelecionarButoesA.Name = "btnControleFisicoSelecionarButoesA";
            this.btnControleFisicoSelecionarButoesA.Size = new System.Drawing.Size(30, 15);
            this.btnControleFisicoSelecionarButoesA.TabIndex = 26;
            this.btnControleFisicoSelecionarButoesA.Click += new System.EventHandler(this.btnControleFisicoSelecionarButoesA_Click);
            // 
            // btnMatriculaItemL
            // 
            this.btnMatriculaItemL.BackColor = System.Drawing.Color.White;
            this.btnMatriculaItemL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnMatriculaItemL.Location = new System.Drawing.Point(213, 177);
            this.btnMatriculaItemL.Name = "btnMatriculaItemL";
            this.btnMatriculaItemL.Size = new System.Drawing.Size(20, 16);
            this.btnMatriculaItemL.TabIndex = 23;
            this.btnMatriculaItemL.Text = "L";
            this.btnMatriculaItemL.Click += new System.EventHandler(this.btnMatriculaItemL_Click);
            // 
            // btnMatriculaItemA
            // 
            this.btnMatriculaItemA.BackColor = System.Drawing.Color.White;
            this.btnMatriculaItemA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnMatriculaItemA.Location = new System.Drawing.Point(123, 177);
            this.btnMatriculaItemA.Name = "btnMatriculaItemA";
            this.btnMatriculaItemA.Size = new System.Drawing.Size(20, 16);
            this.btnMatriculaItemA.TabIndex = 21;
            this.btnMatriculaItemA.Text = "A";
            this.btnMatriculaItemA.Click += new System.EventHandler(this.btnMatriculaItemA_Click);
            // 
            // btnNomeItemL
            // 
            this.btnNomeItemL.BackColor = System.Drawing.Color.White;
            this.btnNomeItemL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnNomeItemL.Location = new System.Drawing.Point(97, 177);
            this.btnNomeItemL.Name = "btnNomeItemL";
            this.btnNomeItemL.Size = new System.Drawing.Size(20, 16);
            this.btnNomeItemL.TabIndex = 20;
            this.btnNomeItemL.Text = "L";
            this.btnNomeItemL.Click += new System.EventHandler(this.btnNomeItemL_Click);
            // 
            // btnNomeItemA
            // 
            this.btnNomeItemA.BackColor = System.Drawing.Color.White;
            this.btnNomeItemA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnNomeItemA.Location = new System.Drawing.Point(7, 177);
            this.btnNomeItemA.Name = "btnNomeItemA";
            this.btnNomeItemA.Size = new System.Drawing.Size(20, 16);
            this.btnNomeItemA.TabIndex = 18;
            this.btnNomeItemA.Text = "A";
            this.btnNomeItemA.Click += new System.EventHandler(this.btnNomeItemA_Click);
            // 
            // btnSalaItemL
            // 
            this.btnSalaItemL.BackColor = System.Drawing.Color.White;
            this.btnSalaItemL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSalaItemL.Location = new System.Drawing.Point(213, 127);
            this.btnSalaItemL.Name = "btnSalaItemL";
            this.btnSalaItemL.Size = new System.Drawing.Size(20, 16);
            this.btnSalaItemL.TabIndex = 15;
            this.btnSalaItemL.Text = "L";
            this.btnSalaItemL.Click += new System.EventHandler(this.btnSalaItemL_Click);
            // 
            // btnSalaItemA
            // 
            this.btnSalaItemA.BackColor = System.Drawing.Color.White;
            this.btnSalaItemA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSalaItemA.Location = new System.Drawing.Point(123, 127);
            this.btnSalaItemA.Name = "btnSalaItemA";
            this.btnSalaItemA.Size = new System.Drawing.Size(20, 16);
            this.btnSalaItemA.TabIndex = 13;
            this.btnSalaItemA.Text = "A";
            this.btnSalaItemA.Click += new System.EventHandler(this.btnSalaItemA_Click);
            // 
            // btnOrgaoItemL
            // 
            this.btnOrgaoItemL.BackColor = System.Drawing.Color.White;
            this.btnOrgaoItemL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnOrgaoItemL.Location = new System.Drawing.Point(97, 127);
            this.btnOrgaoItemL.Name = "btnOrgaoItemL";
            this.btnOrgaoItemL.Size = new System.Drawing.Size(20, 16);
            this.btnOrgaoItemL.TabIndex = 12;
            this.btnOrgaoItemL.Text = "L";
            this.btnOrgaoItemL.Click += new System.EventHandler(this.btnOrgaoItemL_Click);
            // 
            // btnOrgaoItemA
            // 
            this.btnOrgaoItemA.BackColor = System.Drawing.Color.White;
            this.btnOrgaoItemA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnOrgaoItemA.Location = new System.Drawing.Point(7, 127);
            this.btnOrgaoItemA.Name = "btnOrgaoItemA";
            this.btnOrgaoItemA.Size = new System.Drawing.Size(20, 16);
            this.btnOrgaoItemA.TabIndex = 10;
            this.btnOrgaoItemA.Text = "A";
            this.btnOrgaoItemA.Click += new System.EventHandler(this.btnOrgaoItemA_Click);
            // 
            // btnCentroCustoItemL
            // 
            this.btnCentroCustoItemL.BackColor = System.Drawing.Color.White;
            this.btnCentroCustoItemL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCentroCustoItemL.Location = new System.Drawing.Point(213, 77);
            this.btnCentroCustoItemL.Name = "btnCentroCustoItemL";
            this.btnCentroCustoItemL.Size = new System.Drawing.Size(20, 16);
            this.btnCentroCustoItemL.TabIndex = 7;
            this.btnCentroCustoItemL.Text = "L";
            this.btnCentroCustoItemL.Click += new System.EventHandler(this.btnCentroCustoItemL_Click);
            // 
            // btnCentroCustoItemA
            // 
            this.btnCentroCustoItemA.BackColor = System.Drawing.Color.White;
            this.btnCentroCustoItemA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCentroCustoItemA.Location = new System.Drawing.Point(123, 77);
            this.btnCentroCustoItemA.Name = "btnCentroCustoItemA";
            this.btnCentroCustoItemA.Size = new System.Drawing.Size(20, 16);
            this.btnCentroCustoItemA.TabIndex = 5;
            this.btnCentroCustoItemA.Text = "A";
            this.btnCentroCustoItemA.Click += new System.EventHandler(this.btnCentroCustoItemA_Click);
            // 
            // btnTRGItemL
            // 
            this.btnTRGItemL.BackColor = System.Drawing.Color.White;
            this.btnTRGItemL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnTRGItemL.Location = new System.Drawing.Point(97, 77);
            this.btnTRGItemL.Name = "btnTRGItemL";
            this.btnTRGItemL.Size = new System.Drawing.Size(20, 16);
            this.btnTRGItemL.TabIndex = 4;
            this.btnTRGItemL.Text = "L";
            this.btnTRGItemL.Click += new System.EventHandler(this.btnTRGItemL_Click);
            // 
            // btnTRGItemA
            // 
            this.btnTRGItemA.BackColor = System.Drawing.Color.White;
            this.btnTRGItemA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnTRGItemA.Location = new System.Drawing.Point(7, 77);
            this.btnTRGItemA.Name = "btnTRGItemA";
            this.btnTRGItemA.Size = new System.Drawing.Size(20, 16);
            this.btnTRGItemA.TabIndex = 2;
            this.btnTRGItemA.Text = "A";
            this.btnTRGItemA.Click += new System.EventHandler(this.btnTRGItemA_Click);
            // 
            // txtNumeroInventario
            // 
            this.txtNumeroInventario.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtNumeroInventario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtNumeroInventario.Location = new System.Drawing.Point(11, 26);
            this.txtNumeroInventario.Name = "txtNumeroInventario";
            this.txtNumeroInventario.Size = new System.Drawing.Size(226, 20);
            this.txtNumeroInventario.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnControleFisicoSelecionarButoes
            // 
            this.btnControleFisicoSelecionarButoes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnControleFisicoSelecionarButoes.Location = new System.Drawing.Point(43, 227);
            this.btnControleFisicoSelecionarButoes.Name = "btnControleFisicoSelecionarButoes";
            this.btnControleFisicoSelecionarButoes.Size = new System.Drawing.Size(154, 15);
            this.btnControleFisicoSelecionarButoes.TabIndex = 27;
            this.btnControleFisicoSelecionarButoes.Click += new System.EventHandler(this.btnControleFisicoSelecionarButoes_Click);
            // 
            // btnNomeItem
            // 
            this.btnNomeItem.BackColor = System.Drawing.Color.White;
            this.btnNomeItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnNomeItem.Location = new System.Drawing.Point(33, 177);
            this.btnNomeItem.Name = "btnNomeItem";
            this.btnNomeItem.Size = new System.Drawing.Size(58, 16);
            this.btnNomeItem.TabIndex = 19;
            this.btnNomeItem.Text = "Nome";
            this.btnNomeItem.Click += new System.EventHandler(this.btnNomeItem_Click);
            // 
            // btnMatriculaItem
            // 
            this.btnMatriculaItem.BackColor = System.Drawing.Color.White;
            this.btnMatriculaItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnMatriculaItem.Location = new System.Drawing.Point(149, 177);
            this.btnMatriculaItem.Name = "btnMatriculaItem";
            this.btnMatriculaItem.Size = new System.Drawing.Size(58, 16);
            this.btnMatriculaItem.TabIndex = 22;
            this.btnMatriculaItem.Text = "Matr.";
            this.btnMatriculaItem.Click += new System.EventHandler(this.btnMatriculaItem_Click);
            // 
            // btnSalaItem
            // 
            this.btnSalaItem.BackColor = System.Drawing.Color.White;
            this.btnSalaItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSalaItem.Location = new System.Drawing.Point(149, 127);
            this.btnSalaItem.Name = "btnSalaItem";
            this.btnSalaItem.Size = new System.Drawing.Size(58, 16);
            this.btnSalaItem.TabIndex = 14;
            this.btnSalaItem.Text = "Sala";
            this.btnSalaItem.Click += new System.EventHandler(this.btnSalaItem_Click);
            // 
            // btnOrgaoItem
            // 
            this.btnOrgaoItem.BackColor = System.Drawing.Color.White;
            this.btnOrgaoItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnOrgaoItem.Location = new System.Drawing.Point(33, 127);
            this.btnOrgaoItem.Name = "btnOrgaoItem";
            this.btnOrgaoItem.Size = new System.Drawing.Size(58, 16);
            this.btnOrgaoItem.TabIndex = 11;
            this.btnOrgaoItem.Text = "Órgão";
            this.btnOrgaoItem.Click += new System.EventHandler(this.btnOrgaoItem_Click);
            // 
            // btnCentroCustoItem
            // 
            this.btnCentroCustoItem.BackColor = System.Drawing.Color.White;
            this.btnCentroCustoItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnCentroCustoItem.Location = new System.Drawing.Point(149, 77);
            this.btnCentroCustoItem.Name = "btnCentroCustoItem";
            this.btnCentroCustoItem.Size = new System.Drawing.Size(58, 16);
            this.btnCentroCustoItem.TabIndex = 6;
            this.btnCentroCustoItem.Text = "C. Custo";
            this.btnCentroCustoItem.Click += new System.EventHandler(this.btnCentroCustoItem_Click);
            // 
            // btnTRGItem
            // 
            this.btnTRGItem.BackColor = System.Drawing.Color.White;
            this.btnTRGItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnTRGItem.Location = new System.Drawing.Point(33, 77);
            this.btnTRGItem.Name = "btnTRGItem";
            this.btnTRGItem.Size = new System.Drawing.Size(58, 16);
            this.btnTRGItem.TabIndex = 3;
            this.btnTRGItem.Text = "TRG";
            this.btnTRGItem.Click += new System.EventHandler(this.btnTRGItem_Click);
            // 
            // dtpDataInventario
            // 
            this.dtpDataInventario.CalendarFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.dtpDataInventario.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.dtpDataInventario.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataInventario.Location = new System.Drawing.Point(123, 49);
            this.dtpDataInventario.Name = "dtpDataInventario";
            this.dtpDataInventario.Size = new System.Drawing.Size(110, 22);
            this.dtpDataInventario.TabIndex = 1;
            this.dtpDataInventario.ValueChanged += new System.EventHandler(this.dtpDataInventario_ValueChanged);
            // 
            // lblNumeroInventario
            // 
            this.lblNumeroInventario.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblNumeroInventario.ForeColor = System.Drawing.Color.Maroon;
            this.lblNumeroInventario.Location = new System.Drawing.Point(7, 4);
            this.lblNumeroInventario.Name = "lblNumeroInventario";
            this.lblNumeroInventario.Size = new System.Drawing.Size(226, 20);
            this.lblNumeroInventario.Text = "Número do Inventário";
            this.lblNumeroInventario.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDataInventario
            // 
            this.lblDataInventario.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblDataInventario.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblDataInventario.Location = new System.Drawing.Point(7, 52);
            this.lblDataInventario.Name = "lblDataInventario";
            this.lblDataInventario.Size = new System.Drawing.Size(110, 19);
            this.lblDataInventario.Text = "Data do Inventário";
            this.lblDataInventario.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tbpPrincipal
            // 
            this.tbpPrincipal.Controls.Add(this.btnNivelBateria);
            this.tbpPrincipal.Controls.Add(this.txtMatriculaInventario);
            this.tbpPrincipal.Controls.Add(this.txtUsuarioInventario);
            this.tbpPrincipal.Controls.Add(this.btnModoCadastroInventario);
            this.tbpPrincipal.Controls.Add(this.btnDataTempoSistema);
            this.tbpPrincipal.Controls.Add(this.dtpDataSistema);
            this.tbpPrincipal.Controls.Add(this.dtpTempoSistema);
            this.tbpPrincipal.Controls.Add(this.lblNomeDispositivo);
            this.tbpPrincipal.Controls.Add(this.txtNomeDispositivo);
            this.tbpPrincipal.Controls.Add(this.pctUsuarioInventario);
            this.tbpPrincipal.Controls.Add(this.lblUsuarioInventario);
            this.tbpPrincipal.Controls.Add(this.lblMatriculaInventario);
            this.tbpPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tbpPrincipal.Name = "tbpPrincipal";
            this.tbpPrincipal.Size = new System.Drawing.Size(240, 245);
            this.tbpPrincipal.Text = "Principal";
            // 
            // btnNivelBateria
            // 
            this.btnNivelBateria.BackColor = System.Drawing.Color.White;
            this.btnNivelBateria.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnNivelBateria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnNivelBateria.Location = new System.Drawing.Point(61, 7);
            this.btnNivelBateria.Name = "btnNivelBateria";
            this.btnNivelBateria.Size = new System.Drawing.Size(172, 16);
            this.btnNivelBateria.TabIndex = 1;
            this.btnNivelBateria.Click += new System.EventHandler(this.btnNivelBateria_Click);
            // 
            // txtMatriculaInventario
            // 
            this.txtMatriculaInventario.Location = new System.Drawing.Point(7, 120);
            this.txtMatriculaInventario.Name = "txtMatriculaInventario";
            this.txtMatriculaInventario.Size = new System.Drawing.Size(226, 21);
            this.txtMatriculaInventario.TabIndex = 4;
            this.txtMatriculaInventario.TextChanged += new System.EventHandler(this.txtMatriculaInventario_TextChanged);
            this.txtMatriculaInventario.GotFocus += new System.EventHandler(this.txtMatriculaInventario_GotFocus);
            this.txtMatriculaInventario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMatriculaInventario_KeyPress);
            this.txtMatriculaInventario.LostFocus += new System.EventHandler(this.txtMatriculaInventario_LostFocus);
            // 
            // txtUsuarioInventario
            // 
            this.txtUsuarioInventario.Location = new System.Drawing.Point(7, 73);
            this.txtUsuarioInventario.Name = "txtUsuarioInventario";
            this.txtUsuarioInventario.Size = new System.Drawing.Size(226, 21);
            this.txtUsuarioInventario.TabIndex = 3;
            this.txtUsuarioInventario.TextChanged += new System.EventHandler(this.txtUsuarioInventario_TextChanged);
            this.txtUsuarioInventario.GotFocus += new System.EventHandler(this.txtUsuarioInventario_GotFocus);
            this.txtUsuarioInventario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsuarioInventario_KeyPress);
            this.txtUsuarioInventario.LostFocus += new System.EventHandler(this.txtUsuarioInventario_LostFocus);
            // 
            // btnModoCadastroInventario
            // 
            this.btnModoCadastroInventario.BackColor = System.Drawing.Color.White;
            this.btnModoCadastroInventario.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnModoCadastroInventario.ForeColor = System.Drawing.Color.Olive;
            this.btnModoCadastroInventario.Location = new System.Drawing.Point(61, 29);
            this.btnModoCadastroInventario.Name = "btnModoCadastroInventario";
            this.btnModoCadastroInventario.Size = new System.Drawing.Size(172, 16);
            this.btnModoCadastroInventario.TabIndex = 2;
            this.btnModoCadastroInventario.Text = "Modo &Inventário";
            this.btnModoCadastroInventario.Click += new System.EventHandler(this.btnModoCadastroInventario_Click);
            // 
            // btnDataTempoSistema
            // 
            this.btnDataTempoSistema.BackColor = System.Drawing.Color.White;
            this.btnDataTempoSistema.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnDataTempoSistema.Location = new System.Drawing.Point(7, 194);
            this.btnDataTempoSistema.Name = "btnDataTempoSistema";
            this.btnDataTempoSistema.Size = new System.Drawing.Size(226, 20);
            this.btnDataTempoSistema.TabIndex = 6;
            this.btnDataTempoSistema.Text = "Data e Tempo do Sistema";
            this.btnDataTempoSistema.Click += new System.EventHandler(this.btnDataTempoSistema_Click);
            // 
            // dtpDataSistema
            // 
            this.dtpDataSistema.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataSistema.Location = new System.Drawing.Point(7, 220);
            this.dtpDataSistema.Name = "dtpDataSistema";
            this.dtpDataSistema.Size = new System.Drawing.Size(110, 22);
            this.dtpDataSistema.TabIndex = 7;
            // 
            // dtpTempoSistema
            // 
            this.dtpTempoSistema.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTempoSistema.Location = new System.Drawing.Point(122, 220);
            this.dtpTempoSistema.Name = "dtpTempoSistema";
            this.dtpTempoSistema.Size = new System.Drawing.Size(110, 22);
            this.dtpTempoSistema.TabIndex = 8;
            // 
            // lblNomeDispositivo
            // 
            this.lblNomeDispositivo.BackColor = System.Drawing.Color.White;
            this.lblNomeDispositivo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblNomeDispositivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblNomeDispositivo.Location = new System.Drawing.Point(7, 144);
            this.lblNomeDispositivo.Name = "lblNomeDispositivo";
            this.lblNomeDispositivo.Size = new System.Drawing.Size(226, 20);
            this.lblNomeDispositivo.Text = "Nome do Dispositivo";
            this.lblNomeDispositivo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtNomeDispositivo
            // 
            this.txtNomeDispositivo.Location = new System.Drawing.Point(7, 167);
            this.txtNomeDispositivo.Name = "txtNomeDispositivo";
            this.txtNomeDispositivo.Size = new System.Drawing.Size(226, 21);
            this.txtNomeDispositivo.TabIndex = 5;
            this.txtNomeDispositivo.TextChanged += new System.EventHandler(this.txtNomeDispositivo_TextChanged);
            // 
            // pctUsuarioInventario
            // 
            this.pctUsuarioInventario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pctUsuarioInventario.Image = ((System.Drawing.Image)(resources.GetObject("pctUsuarioInventario.Image")));
            this.pctUsuarioInventario.Location = new System.Drawing.Point(7, 7);
            this.pctUsuarioInventario.Name = "pctUsuarioInventario";
            this.pctUsuarioInventario.Size = new System.Drawing.Size(40, 40);
            this.pctUsuarioInventario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // lblUsuarioInventario
            // 
            this.lblUsuarioInventario.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblUsuarioInventario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblUsuarioInventario.Location = new System.Drawing.Point(7, 49);
            this.lblUsuarioInventario.Name = "lblUsuarioInventario";
            this.lblUsuarioInventario.Size = new System.Drawing.Size(226, 20);
            this.lblUsuarioInventario.Text = "Usuário Inventariante";
            this.lblUsuarioInventario.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblMatriculaInventario
            // 
            this.lblMatriculaInventario.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblMatriculaInventario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblMatriculaInventario.Location = new System.Drawing.Point(7, 96);
            this.lblMatriculaInventario.Name = "lblMatriculaInventario";
            this.lblMatriculaInventario.Size = new System.Drawing.Size(226, 20);
            this.lblMatriculaInventario.Text = "Matrícula do Inventariante";
            this.lblMatriculaInventario.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tbc1
            // 
            this.tbc1.Controls.Add(this.tbpPrincipal);
            this.tbc1.Controls.Add(this.tbpDadosGerais);
            this.tbc1.Controls.Add(this.tbpDadosComplementares);
            this.tbc1.Controls.Add(this.tbpControleFisico);
            this.tbc1.Controls.Add(this.tbpTabelas);
            this.tbc1.Controls.Add(this.tbpRelatorios);
            this.tbc1.Controls.Add(this.tbpFotografia);
            this.tbc1.Controls.Add(this.tbpGPS);
            this.tbc1.Controls.Add(this.tbpMapa);
            this.tbc1.Controls.Add(this.tbpConfiguracoes);
            this.tbc1.Controls.Add(this.tbpConfiguracoesExtras);
            this.tbc1.Controls.Add(this.tbpZerarTabelas);
            this.tbc1.Controls.Add(this.tbpSair);
            this.tbc1.Location = new System.Drawing.Point(0, 0);
            this.tbc1.Name = "tbc1";
            this.tbc1.SelectedIndex = 0;
            this.tbc1.Size = new System.Drawing.Size(240, 268);
            this.tbc1.TabIndex = 0;
            this.tbc1.SelectedIndexChanged += new System.EventHandler(this.tbc1_SelectedIndexChanged);
            // 
            // tbpDadosComplementares
            // 
            this.tbpDadosComplementares.Controls.Add(this.btnOutrosDadosItemAvancar);
            this.tbpDadosComplementares.Controls.Add(this.btnOutrosDadosItemRecuar);
            this.tbpDadosComplementares.Controls.Add(this.btnDadosComplementaresSelecionarButoesA);
            this.tbpDadosComplementares.Controls.Add(this.btnDadosComplementaresSelecionarButoesL);
            this.tbpDadosComplementares.Controls.Add(this.btnDadosComplementaresSelecionarButoes);
            this.tbpDadosComplementares.Controls.Add(this.btnIdentificacaoItemAvancar);
            this.tbpDadosComplementares.Controls.Add(this.btnIdentificacaoItemRecuar);
            this.tbpDadosComplementares.Controls.Add(this.txtIdentificacaoItem);
            this.tbpDadosComplementares.Controls.Add(this.txtOutrosDadosItem);
            this.tbpDadosComplementares.Controls.Add(this.btnOutrosDadosItemA);
            this.tbpDadosComplementares.Controls.Add(this.btnOutrosDadosItemL);
            this.tbpDadosComplementares.Controls.Add(this.btnOutrosDadosItem);
            this.tbpDadosComplementares.Controls.Add(this.btnIdentificacaoItemA);
            this.tbpDadosComplementares.Controls.Add(this.btnIdentificacaoItemL);
            this.tbpDadosComplementares.Controls.Add(this.btnIdentificacaoItem);
            this.tbpDadosComplementares.Controls.Add(this.btnObservacaoItemRecuar);
            this.tbpDadosComplementares.Controls.Add(this.btnObservacaoItemL);
            this.tbpDadosComplementares.Controls.Add(this.btnObservacaoItem);
            this.tbpDadosComplementares.Controls.Add(this.cmbObservacaoItem);
            this.tbpDadosComplementares.Location = new System.Drawing.Point(0, 0);
            this.tbpDadosComplementares.Name = "tbpDadosComplementares";
            this.tbpDadosComplementares.Size = new System.Drawing.Size(240, 245);
            this.tbpDadosComplementares.Text = "Dados Complementares";
            // 
            // btnOutrosDadosItemAvancar
            // 
            this.btnOutrosDadosItemAvancar.BackColor = System.Drawing.Color.White;
            this.btnOutrosDadosItemAvancar.ForeColor = System.Drawing.Color.Olive;
            this.btnOutrosDadosItemAvancar.Location = new System.Drawing.Point(213, 78);
            this.btnOutrosDadosItemAvancar.Name = "btnOutrosDadosItemAvancar";
            this.btnOutrosDadosItemAvancar.Size = new System.Drawing.Size(20, 21);
            this.btnOutrosDadosItemAvancar.TabIndex = 12;
            this.btnOutrosDadosItemAvancar.Text = "A";
            this.btnOutrosDadosItemAvancar.Click += new System.EventHandler(this.btnOutrosDadosItemAvancar_Click);
            // 
            // btnOutrosDadosItemRecuar
            // 
            this.btnOutrosDadosItemRecuar.BackColor = System.Drawing.Color.White;
            this.btnOutrosDadosItemRecuar.ForeColor = System.Drawing.Color.Sienna;
            this.btnOutrosDadosItemRecuar.Location = new System.Drawing.Point(7, 78);
            this.btnOutrosDadosItemRecuar.Name = "btnOutrosDadosItemRecuar";
            this.btnOutrosDadosItemRecuar.Size = new System.Drawing.Size(20, 21);
            this.btnOutrosDadosItemRecuar.TabIndex = 10;
            this.btnOutrosDadosItemRecuar.Text = "R";
            this.btnOutrosDadosItemRecuar.Click += new System.EventHandler(this.btnOutrosDadosItemRecuar_Click);
            // 
            // btnDadosComplementaresSelecionarButoesA
            // 
            this.btnDadosComplementaresSelecionarButoesA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDadosComplementaresSelecionarButoesA.Enabled = false;
            this.btnDadosComplementaresSelecionarButoesA.Location = new System.Drawing.Point(7, 155);
            this.btnDadosComplementaresSelecionarButoesA.Name = "btnDadosComplementaresSelecionarButoesA";
            this.btnDadosComplementaresSelecionarButoesA.Size = new System.Drawing.Size(30, 15);
            this.btnDadosComplementaresSelecionarButoesA.TabIndex = 17;
            this.btnDadosComplementaresSelecionarButoesA.Click += new System.EventHandler(this.btnDadosComplementaresSelecionarButoesA_Click);
            // 
            // btnDadosComplementaresSelecionarButoesL
            // 
            this.btnDadosComplementaresSelecionarButoesL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDadosComplementaresSelecionarButoesL.Location = new System.Drawing.Point(203, 155);
            this.btnDadosComplementaresSelecionarButoesL.Name = "btnDadosComplementaresSelecionarButoesL";
            this.btnDadosComplementaresSelecionarButoesL.Size = new System.Drawing.Size(30, 15);
            this.btnDadosComplementaresSelecionarButoesL.TabIndex = 19;
            this.btnDadosComplementaresSelecionarButoesL.Click += new System.EventHandler(this.btnDadosComplementaresSelecionarButoesL_Click);
            // 
            // btnDadosComplementaresSelecionarButoes
            // 
            this.btnDadosComplementaresSelecionarButoes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnDadosComplementaresSelecionarButoes.Location = new System.Drawing.Point(43, 155);
            this.btnDadosComplementaresSelecionarButoes.Name = "btnDadosComplementaresSelecionarButoes";
            this.btnDadosComplementaresSelecionarButoes.Size = new System.Drawing.Size(154, 15);
            this.btnDadosComplementaresSelecionarButoes.TabIndex = 18;
            this.btnDadosComplementaresSelecionarButoes.Click += new System.EventHandler(this.btnDadosComplementaresSelecionarButoes_Click);
            // 
            // btnIdentificacaoItemAvancar
            // 
            this.btnIdentificacaoItemAvancar.BackColor = System.Drawing.Color.White;
            this.btnIdentificacaoItemAvancar.ForeColor = System.Drawing.Color.Olive;
            this.btnIdentificacaoItemAvancar.Location = new System.Drawing.Point(213, 29);
            this.btnIdentificacaoItemAvancar.Name = "btnIdentificacaoItemAvancar";
            this.btnIdentificacaoItemAvancar.Size = new System.Drawing.Size(20, 21);
            this.btnIdentificacaoItemAvancar.TabIndex = 6;
            this.btnIdentificacaoItemAvancar.Text = "A";
            this.btnIdentificacaoItemAvancar.Click += new System.EventHandler(this.btnIdentificacaoItemAvancar_Click);
            // 
            // btnIdentificacaoItemRecuar
            // 
            this.btnIdentificacaoItemRecuar.BackColor = System.Drawing.Color.White;
            this.btnIdentificacaoItemRecuar.ForeColor = System.Drawing.Color.Sienna;
            this.btnIdentificacaoItemRecuar.Location = new System.Drawing.Point(7, 29);
            this.btnIdentificacaoItemRecuar.Name = "btnIdentificacaoItemRecuar";
            this.btnIdentificacaoItemRecuar.Size = new System.Drawing.Size(20, 21);
            this.btnIdentificacaoItemRecuar.TabIndex = 4;
            this.btnIdentificacaoItemRecuar.Text = "R";
            this.btnIdentificacaoItemRecuar.Click += new System.EventHandler(this.btnIdentificacaoItemRecuar_Click);
            // 
            // txtIdentificacaoItem
            // 
            this.txtIdentificacaoItem.Location = new System.Drawing.Point(33, 29);
            this.txtIdentificacaoItem.Name = "txtIdentificacaoItem";
            this.txtIdentificacaoItem.Size = new System.Drawing.Size(174, 21);
            this.txtIdentificacaoItem.TabIndex = 5;
            this.txtIdentificacaoItem.GotFocus += new System.EventHandler(this.txtIdentificacaoItem_GotFocus);
            this.txtIdentificacaoItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdentificacaoItem_KeyPress);
            this.txtIdentificacaoItem.LostFocus += new System.EventHandler(this.txtIdentificacaoItem_LostFocus);
            // 
            // txtOutrosDadosItem
            // 
            this.txtOutrosDadosItem.Location = new System.Drawing.Point(33, 78);
            this.txtOutrosDadosItem.Name = "txtOutrosDadosItem";
            this.txtOutrosDadosItem.Size = new System.Drawing.Size(174, 21);
            this.txtOutrosDadosItem.TabIndex = 11;
            this.txtOutrosDadosItem.GotFocus += new System.EventHandler(this.txtOutrosDadosItem_GotFocus);
            this.txtOutrosDadosItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOutrosDadosItem_KeyPress);
            this.txtOutrosDadosItem.LostFocus += new System.EventHandler(this.txtOutrosDadosItem_LostFocus);
            // 
            // btnOutrosDadosItemA
            // 
            this.btnOutrosDadosItemA.BackColor = System.Drawing.Color.White;
            this.btnOutrosDadosItemA.Enabled = false;
            this.btnOutrosDadosItemA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnOutrosDadosItemA.Location = new System.Drawing.Point(7, 56);
            this.btnOutrosDadosItemA.Name = "btnOutrosDadosItemA";
            this.btnOutrosDadosItemA.Size = new System.Drawing.Size(20, 16);
            this.btnOutrosDadosItemA.TabIndex = 7;
            this.btnOutrosDadosItemA.Text = "A";
            this.btnOutrosDadosItemA.Click += new System.EventHandler(this.btnOutrosDadosItemA_Click);
            // 
            // btnOutrosDadosItemL
            // 
            this.btnOutrosDadosItemL.BackColor = System.Drawing.Color.White;
            this.btnOutrosDadosItemL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnOutrosDadosItemL.Location = new System.Drawing.Point(213, 56);
            this.btnOutrosDadosItemL.Name = "btnOutrosDadosItemL";
            this.btnOutrosDadosItemL.Size = new System.Drawing.Size(20, 16);
            this.btnOutrosDadosItemL.TabIndex = 9;
            this.btnOutrosDadosItemL.Text = "L";
            this.btnOutrosDadosItemL.Click += new System.EventHandler(this.btnOutrosDadosItemL_Click);
            // 
            // btnOutrosDadosItem
            // 
            this.btnOutrosDadosItem.BackColor = System.Drawing.Color.White;
            this.btnOutrosDadosItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnOutrosDadosItem.Location = new System.Drawing.Point(33, 56);
            this.btnOutrosDadosItem.Name = "btnOutrosDadosItem";
            this.btnOutrosDadosItem.Size = new System.Drawing.Size(174, 16);
            this.btnOutrosDadosItem.TabIndex = 8;
            this.btnOutrosDadosItem.Text = "Outros Dados";
            this.btnOutrosDadosItem.Click += new System.EventHandler(this.btnOutrosDadosItem_Click);
            // 
            // btnIdentificacaoItemA
            // 
            this.btnIdentificacaoItemA.BackColor = System.Drawing.Color.White;
            this.btnIdentificacaoItemA.Enabled = false;
            this.btnIdentificacaoItemA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnIdentificacaoItemA.Location = new System.Drawing.Point(7, 7);
            this.btnIdentificacaoItemA.Name = "btnIdentificacaoItemA";
            this.btnIdentificacaoItemA.Size = new System.Drawing.Size(20, 16);
            this.btnIdentificacaoItemA.TabIndex = 1;
            this.btnIdentificacaoItemA.Text = "A";
            this.btnIdentificacaoItemA.Click += new System.EventHandler(this.btnIdentificacaoItemA_Click);
            // 
            // btnIdentificacaoItemL
            // 
            this.btnIdentificacaoItemL.BackColor = System.Drawing.Color.White;
            this.btnIdentificacaoItemL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnIdentificacaoItemL.Location = new System.Drawing.Point(213, 7);
            this.btnIdentificacaoItemL.Name = "btnIdentificacaoItemL";
            this.btnIdentificacaoItemL.Size = new System.Drawing.Size(20, 16);
            this.btnIdentificacaoItemL.TabIndex = 3;
            this.btnIdentificacaoItemL.Text = "L";
            this.btnIdentificacaoItemL.Click += new System.EventHandler(this.btnIdentificacaoItemL_Click);
            // 
            // btnIdentificacaoItem
            // 
            this.btnIdentificacaoItem.BackColor = System.Drawing.Color.White;
            this.btnIdentificacaoItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnIdentificacaoItem.Location = new System.Drawing.Point(33, 7);
            this.btnIdentificacaoItem.Name = "btnIdentificacaoItem";
            this.btnIdentificacaoItem.Size = new System.Drawing.Size(174, 16);
            this.btnIdentificacaoItem.TabIndex = 2;
            this.btnIdentificacaoItem.Text = "Identificação";
            this.btnIdentificacaoItem.Click += new System.EventHandler(this.btnIdentificacaoItem_Click);
            // 
            // btnObservacaoItemRecuar
            // 
            this.btnObservacaoItemRecuar.BackColor = System.Drawing.Color.White;
            this.btnObservacaoItemRecuar.Enabled = false;
            this.btnObservacaoItemRecuar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnObservacaoItemRecuar.Location = new System.Drawing.Point(7, 105);
            this.btnObservacaoItemRecuar.Name = "btnObservacaoItemRecuar";
            this.btnObservacaoItemRecuar.Size = new System.Drawing.Size(20, 16);
            this.btnObservacaoItemRecuar.TabIndex = 13;
            this.btnObservacaoItemRecuar.Text = "A";
            this.btnObservacaoItemRecuar.Click += new System.EventHandler(this.btnObservacaoItemA_Click);
            // 
            // btnObservacaoItemL
            // 
            this.btnObservacaoItemL.BackColor = System.Drawing.Color.White;
            this.btnObservacaoItemL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnObservacaoItemL.Location = new System.Drawing.Point(213, 105);
            this.btnObservacaoItemL.Name = "btnObservacaoItemL";
            this.btnObservacaoItemL.Size = new System.Drawing.Size(20, 16);
            this.btnObservacaoItemL.TabIndex = 15;
            this.btnObservacaoItemL.Text = "L";
            this.btnObservacaoItemL.Click += new System.EventHandler(this.btnObservacaoItemL_Click);
            // 
            // btnObservacaoItem
            // 
            this.btnObservacaoItem.BackColor = System.Drawing.Color.White;
            this.btnObservacaoItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnObservacaoItem.Location = new System.Drawing.Point(33, 105);
            this.btnObservacaoItem.Name = "btnObservacaoItem";
            this.btnObservacaoItem.Size = new System.Drawing.Size(174, 16);
            this.btnObservacaoItem.TabIndex = 14;
            this.btnObservacaoItem.Text = "Observação";
            this.btnObservacaoItem.Click += new System.EventHandler(this.btnObservacaoItem_Click);
            // 
            // cmbObservacaoItem
            // 
            this.cmbObservacaoItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cmbObservacaoItem.Location = new System.Drawing.Point(7, 127);
            this.cmbObservacaoItem.Name = "cmbObservacaoItem";
            this.cmbObservacaoItem.Size = new System.Drawing.Size(226, 22);
            this.cmbObservacaoItem.TabIndex = 16;
            this.cmbObservacaoItem.LostFocus += new System.EventHandler(this.cmbObservacaoItem_LostFocus);
            this.cmbObservacaoItem.GotFocus += new System.EventHandler(this.cmbObservacaoItem_GotFocus);
            // 
            // tbpRelatorios
            // 
            this.tbpRelatorios.Controls.Add(this.tbc3);
            this.tbpRelatorios.Location = new System.Drawing.Point(0, 0);
            this.tbpRelatorios.Name = "tbpRelatorios";
            this.tbpRelatorios.Size = new System.Drawing.Size(240, 245);
            this.tbpRelatorios.Text = "Relatórios";
            // 
            // tbc3
            // 
            this.tbc3.Controls.Add(this.tblContador);
            this.tbc3.Controls.Add(this.tblRepeticoes);
            this.tbc3.Controls.Add(this.tblRegistros);
            this.tbc3.Location = new System.Drawing.Point(0, 0);
            this.tbc3.Name = "tbc3";
            this.tbc3.SelectedIndex = 0;
            this.tbc3.Size = new System.Drawing.Size(240, 242);
            this.tbc3.TabIndex = 64;
            this.tbc3.SelectedIndexChanged += new System.EventHandler(this.tbc3_SelectedIndexChanged);
            // 
            // tblContador
            // 
            this.tblContador.Controls.Add(this.txtTabelaRelatorioFiltro);
            this.tblContador.Controls.Add(this.lblTabelaRelatorioFiltro);
            this.tblContador.Controls.Add(this.cmbConsultarCamposRelatorio);
            this.tblContador.Controls.Add(this.cmbConsultarTabelaRelatorio);
            this.tblContador.Controls.Add(this.dtg5);
            this.tblContador.Location = new System.Drawing.Point(0, 0);
            this.tblContador.Name = "tblContador";
            this.tblContador.Size = new System.Drawing.Size(240, 219);
            this.tblContador.Text = "Contador";
            // 
            // txtTabelaRelatorioFiltro
            // 
            this.txtTabelaRelatorioFiltro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTabelaRelatorioFiltro.Location = new System.Drawing.Point(68, 195);
            this.txtTabelaRelatorioFiltro.Name = "txtTabelaRelatorioFiltro";
            this.txtTabelaRelatorioFiltro.Size = new System.Drawing.Size(165, 21);
            this.txtTabelaRelatorioFiltro.TabIndex = 10;
            this.txtTabelaRelatorioFiltro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTabelaRelatorioFiltro_KeyPress);
            // 
            // lblTabelaRelatorioFiltro
            // 
            this.lblTabelaRelatorioFiltro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblTabelaRelatorioFiltro.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblTabelaRelatorioFiltro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTabelaRelatorioFiltro.Location = new System.Drawing.Point(7, 195);
            this.lblTabelaRelatorioFiltro.Name = "lblTabelaRelatorioFiltro";
            this.lblTabelaRelatorioFiltro.Size = new System.Drawing.Size(63, 20);
            this.lblTabelaRelatorioFiltro.Text = "Filtro:";
            this.lblTabelaRelatorioFiltro.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmbConsultarCamposRelatorio
            // 
            this.cmbConsultarCamposRelatorio.Location = new System.Drawing.Point(123, 167);
            this.cmbConsultarCamposRelatorio.Name = "cmbConsultarCamposRelatorio";
            this.cmbConsultarCamposRelatorio.Size = new System.Drawing.Size(110, 22);
            this.cmbConsultarCamposRelatorio.TabIndex = 9;
            this.cmbConsultarCamposRelatorio.GotFocus += new System.EventHandler(this.cmbConsultarCamposRelatorio_GotFocus);
            // 
            // cmbConsultarTabelaRelatorio
            // 
            this.cmbConsultarTabelaRelatorio.Location = new System.Drawing.Point(7, 167);
            this.cmbConsultarTabelaRelatorio.Name = "cmbConsultarTabelaRelatorio";
            this.cmbConsultarTabelaRelatorio.Size = new System.Drawing.Size(110, 22);
            this.cmbConsultarTabelaRelatorio.TabIndex = 8;
            this.cmbConsultarTabelaRelatorio.GotFocus += new System.EventHandler(this.cmbConsultarTabelaRelatorio_GotFocus);
            // 
            // dtg5
            // 
            this.dtg5.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dtg5.GridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.dtg5.Location = new System.Drawing.Point(7, 7);
            this.dtg5.Name = "dtg5";
            this.dtg5.Size = new System.Drawing.Size(226, 154);
            this.dtg5.TabIndex = 7;
            // 
            // tblRepeticoes
            // 
            this.tblRepeticoes.Controls.Add(this.lblRepeticoes);
            this.tblRepeticoes.Controls.Add(this.cmbConsultarInventarioRepeticoes);
            this.tblRepeticoes.Controls.Add(this.txtRepeticoes);
            this.tblRepeticoes.Controls.Add(this.dtg6);
            this.tblRepeticoes.Location = new System.Drawing.Point(0, 0);
            this.tblRepeticoes.Name = "tblRepeticoes";
            this.tblRepeticoes.Size = new System.Drawing.Size(240, 219);
            this.tblRepeticoes.Text = "Repetições";
            // 
            // lblRepeticoes
            // 
            this.lblRepeticoes.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblRepeticoes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.lblRepeticoes.Location = new System.Drawing.Point(123, 196);
            this.lblRepeticoes.Name = "lblRepeticoes";
            this.lblRepeticoes.Size = new System.Drawing.Size(82, 20);
            this.lblRepeticoes.Text = "Repetições:";
            this.lblRepeticoes.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmbConsultarInventarioRepeticoes
            // 
            this.cmbConsultarInventarioRepeticoes.Location = new System.Drawing.Point(7, 194);
            this.cmbConsultarInventarioRepeticoes.Name = "cmbConsultarInventarioRepeticoes";
            this.cmbConsultarInventarioRepeticoes.Size = new System.Drawing.Size(110, 22);
            this.cmbConsultarInventarioRepeticoes.TabIndex = 6;
            this.cmbConsultarInventarioRepeticoes.GotFocus += new System.EventHandler(this.cmbConsultarInventarioRepeticoes_GotFocus);
            // 
            // txtRepeticoes
            // 
            this.txtRepeticoes.Location = new System.Drawing.Point(211, 195);
            this.txtRepeticoes.Name = "txtRepeticoes";
            this.txtRepeticoes.Size = new System.Drawing.Size(22, 21);
            this.txtRepeticoes.TabIndex = 7;
            // 
            // dtg6
            // 
            this.dtg6.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dtg6.GridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.dtg6.Location = new System.Drawing.Point(7, 7);
            this.dtg6.Name = "dtg6";
            this.dtg6.Size = new System.Drawing.Size(226, 181);
            this.dtg6.TabIndex = 5;
            // 
            // tblRegistros
            // 
            this.tblRegistros.Controls.Add(this.lblRelatorioExtra);
            this.tblRegistros.Controls.Add(this.btnRelatorioExtra);
            this.tblRegistros.Controls.Add(this.txtTabelaCentroCustoColunas);
            this.tblRegistros.Controls.Add(this.txtTabelaCentroCustoLinhas);
            this.tblRegistros.Controls.Add(this.lblTabelaCentroCustoColunas);
            this.tblRegistros.Controls.Add(this.lblTabelaCentroCustoLinhas);
            this.tblRegistros.Controls.Add(this.lblTabelaCentroCusto);
            this.tblRegistros.Controls.Add(this.txtTabelaEmpregadosColunas);
            this.tblRegistros.Controls.Add(this.txtTabelaEmpregadosLinhas);
            this.tblRegistros.Controls.Add(this.lblTabelaEmpregadosColunas);
            this.tblRegistros.Controls.Add(this.lblTabelaEmpregadosLinhas);
            this.tblRegistros.Controls.Add(this.lblTabelaEmpregados);
            this.tblRegistros.Controls.Add(this.txtTabelaSAPColunas);
            this.tblRegistros.Controls.Add(this.txtTabelaSAPLinhas);
            this.tblRegistros.Controls.Add(this.lblTabelaSAPColunas);
            this.tblRegistros.Controls.Add(this.lblTabelaSAPLinhas);
            this.tblRegistros.Controls.Add(this.lblTabelaSAP);
            this.tblRegistros.Controls.Add(this.txtTabelaInventarioBensColunas);
            this.tblRegistros.Controls.Add(this.txtTabelaInventarioBensLinhas);
            this.tblRegistros.Controls.Add(this.lblTabelaInventarioBensColunas);
            this.tblRegistros.Controls.Add(this.lblTabelaInventarioBensLinhas);
            this.tblRegistros.Controls.Add(this.lblTabelaInventarioBens);
            this.tblRegistros.Location = new System.Drawing.Point(0, 0);
            this.tblRegistros.Name = "tblRegistros";
            this.tblRegistros.Size = new System.Drawing.Size(240, 219);
            this.tblRegistros.Text = "Registros";
            // 
            // lblRelatorioExtra
            // 
            this.lblRelatorioExtra.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblRelatorioExtra.ForeColor = System.Drawing.Color.DimGray;
            this.lblRelatorioExtra.Location = new System.Drawing.Point(7, 4);
            this.lblRelatorioExtra.Name = "lblRelatorioExtra";
            this.lblRelatorioExtra.Size = new System.Drawing.Size(226, 20);
            this.lblRelatorioExtra.Text = "Relatório Tabelas Linhas/Colunas";
            this.lblRelatorioExtra.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnRelatorioExtra
            // 
            this.btnRelatorioExtra.BackColor = System.Drawing.Color.White;
            this.btnRelatorioExtra.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnRelatorioExtra.ForeColor = System.Drawing.Color.DimGray;
            this.btnRelatorioExtra.Location = new System.Drawing.Point(7, 198);
            this.btnRelatorioExtra.Name = "btnRelatorioExtra";
            this.btnRelatorioExtra.Size = new System.Drawing.Size(226, 18);
            this.btnRelatorioExtra.TabIndex = 42;
            this.btnRelatorioExtra.Text = "&Consultar";
            this.btnRelatorioExtra.Click += new System.EventHandler(this.btnRelatorioExtra_Click);
            // 
            // txtTabelaCentroCustoColunas
            // 
            this.txtTabelaCentroCustoColunas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtTabelaCentroCustoColunas.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.txtTabelaCentroCustoColunas.ForeColor = System.Drawing.Color.Olive;
            this.txtTabelaCentroCustoColunas.Location = new System.Drawing.Point(180, 164);
            this.txtTabelaCentroCustoColunas.Name = "txtTabelaCentroCustoColunas";
            this.txtTabelaCentroCustoColunas.Size = new System.Drawing.Size(53, 20);
            this.txtTabelaCentroCustoColunas.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtTabelaCentroCustoLinhas
            // 
            this.txtTabelaCentroCustoLinhas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtTabelaCentroCustoLinhas.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.txtTabelaCentroCustoLinhas.ForeColor = System.Drawing.Color.Olive;
            this.txtTabelaCentroCustoLinhas.Location = new System.Drawing.Point(65, 164);
            this.txtTabelaCentroCustoLinhas.Name = "txtTabelaCentroCustoLinhas";
            this.txtTabelaCentroCustoLinhas.Size = new System.Drawing.Size(55, 20);
            this.txtTabelaCentroCustoLinhas.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTabelaCentroCustoColunas
            // 
            this.lblTabelaCentroCustoColunas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblTabelaCentroCustoColunas.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblTabelaCentroCustoColunas.ForeColor = System.Drawing.Color.Olive;
            this.lblTabelaCentroCustoColunas.Location = new System.Drawing.Point(119, 164);
            this.lblTabelaCentroCustoColunas.Name = "lblTabelaCentroCustoColunas";
            this.lblTabelaCentroCustoColunas.Size = new System.Drawing.Size(65, 20);
            this.lblTabelaCentroCustoColunas.Text = "Colunas:";
            this.lblTabelaCentroCustoColunas.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTabelaCentroCustoLinhas
            // 
            this.lblTabelaCentroCustoLinhas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblTabelaCentroCustoLinhas.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblTabelaCentroCustoLinhas.ForeColor = System.Drawing.Color.Olive;
            this.lblTabelaCentroCustoLinhas.Location = new System.Drawing.Point(7, 164);
            this.lblTabelaCentroCustoLinhas.Name = "lblTabelaCentroCustoLinhas";
            this.lblTabelaCentroCustoLinhas.Size = new System.Drawing.Size(60, 20);
            this.lblTabelaCentroCustoLinhas.Text = "Linhas:";
            this.lblTabelaCentroCustoLinhas.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTabelaCentroCusto
            // 
            this.lblTabelaCentroCusto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblTabelaCentroCusto.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblTabelaCentroCusto.ForeColor = System.Drawing.Color.Olive;
            this.lblTabelaCentroCusto.Location = new System.Drawing.Point(7, 144);
            this.lblTabelaCentroCusto.Name = "lblTabelaCentroCusto";
            this.lblTabelaCentroCusto.Size = new System.Drawing.Size(226, 20);
            this.lblTabelaCentroCusto.Text = "Tabela de Centro de Custo";
            this.lblTabelaCentroCusto.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtTabelaEmpregadosColunas
            // 
            this.txtTabelaEmpregadosColunas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtTabelaEmpregadosColunas.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.txtTabelaEmpregadosColunas.ForeColor = System.Drawing.Color.Green;
            this.txtTabelaEmpregadosColunas.Location = new System.Drawing.Point(180, 124);
            this.txtTabelaEmpregadosColunas.Name = "txtTabelaEmpregadosColunas";
            this.txtTabelaEmpregadosColunas.Size = new System.Drawing.Size(53, 20);
            this.txtTabelaEmpregadosColunas.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtTabelaEmpregadosLinhas
            // 
            this.txtTabelaEmpregadosLinhas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtTabelaEmpregadosLinhas.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.txtTabelaEmpregadosLinhas.ForeColor = System.Drawing.Color.Green;
            this.txtTabelaEmpregadosLinhas.Location = new System.Drawing.Point(65, 124);
            this.txtTabelaEmpregadosLinhas.Name = "txtTabelaEmpregadosLinhas";
            this.txtTabelaEmpregadosLinhas.Size = new System.Drawing.Size(55, 20);
            this.txtTabelaEmpregadosLinhas.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTabelaEmpregadosColunas
            // 
            this.lblTabelaEmpregadosColunas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblTabelaEmpregadosColunas.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblTabelaEmpregadosColunas.ForeColor = System.Drawing.Color.Green;
            this.lblTabelaEmpregadosColunas.Location = new System.Drawing.Point(119, 124);
            this.lblTabelaEmpregadosColunas.Name = "lblTabelaEmpregadosColunas";
            this.lblTabelaEmpregadosColunas.Size = new System.Drawing.Size(65, 20);
            this.lblTabelaEmpregadosColunas.Text = "Colunas:";
            this.lblTabelaEmpregadosColunas.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTabelaEmpregadosLinhas
            // 
            this.lblTabelaEmpregadosLinhas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblTabelaEmpregadosLinhas.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblTabelaEmpregadosLinhas.ForeColor = System.Drawing.Color.Green;
            this.lblTabelaEmpregadosLinhas.Location = new System.Drawing.Point(7, 124);
            this.lblTabelaEmpregadosLinhas.Name = "lblTabelaEmpregadosLinhas";
            this.lblTabelaEmpregadosLinhas.Size = new System.Drawing.Size(60, 20);
            this.lblTabelaEmpregadosLinhas.Text = "Linhas:";
            this.lblTabelaEmpregadosLinhas.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTabelaEmpregados
            // 
            this.lblTabelaEmpregados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblTabelaEmpregados.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblTabelaEmpregados.ForeColor = System.Drawing.Color.Green;
            this.lblTabelaEmpregados.Location = new System.Drawing.Point(7, 104);
            this.lblTabelaEmpregados.Name = "lblTabelaEmpregados";
            this.lblTabelaEmpregados.Size = new System.Drawing.Size(226, 20);
            this.lblTabelaEmpregados.Text = "Tabela de Empregados";
            this.lblTabelaEmpregados.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtTabelaSAPColunas
            // 
            this.txtTabelaSAPColunas.BackColor = System.Drawing.Color.LavenderBlush;
            this.txtTabelaSAPColunas.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.txtTabelaSAPColunas.ForeColor = System.Drawing.Color.Maroon;
            this.txtTabelaSAPColunas.Location = new System.Drawing.Point(180, 84);
            this.txtTabelaSAPColunas.Name = "txtTabelaSAPColunas";
            this.txtTabelaSAPColunas.Size = new System.Drawing.Size(53, 20);
            this.txtTabelaSAPColunas.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtTabelaSAPLinhas
            // 
            this.txtTabelaSAPLinhas.BackColor = System.Drawing.Color.LavenderBlush;
            this.txtTabelaSAPLinhas.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.txtTabelaSAPLinhas.ForeColor = System.Drawing.Color.Maroon;
            this.txtTabelaSAPLinhas.Location = new System.Drawing.Point(65, 84);
            this.txtTabelaSAPLinhas.Name = "txtTabelaSAPLinhas";
            this.txtTabelaSAPLinhas.Size = new System.Drawing.Size(55, 20);
            this.txtTabelaSAPLinhas.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTabelaSAPColunas
            // 
            this.lblTabelaSAPColunas.BackColor = System.Drawing.Color.LavenderBlush;
            this.lblTabelaSAPColunas.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblTabelaSAPColunas.ForeColor = System.Drawing.Color.Maroon;
            this.lblTabelaSAPColunas.Location = new System.Drawing.Point(119, 84);
            this.lblTabelaSAPColunas.Name = "lblTabelaSAPColunas";
            this.lblTabelaSAPColunas.Size = new System.Drawing.Size(65, 20);
            this.lblTabelaSAPColunas.Text = "Colunas:";
            this.lblTabelaSAPColunas.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTabelaSAPLinhas
            // 
            this.lblTabelaSAPLinhas.BackColor = System.Drawing.Color.LavenderBlush;
            this.lblTabelaSAPLinhas.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblTabelaSAPLinhas.ForeColor = System.Drawing.Color.Maroon;
            this.lblTabelaSAPLinhas.Location = new System.Drawing.Point(7, 84);
            this.lblTabelaSAPLinhas.Name = "lblTabelaSAPLinhas";
            this.lblTabelaSAPLinhas.Size = new System.Drawing.Size(60, 20);
            this.lblTabelaSAPLinhas.Text = "Linhas:";
            this.lblTabelaSAPLinhas.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTabelaSAP
            // 
            this.lblTabelaSAP.BackColor = System.Drawing.Color.LavenderBlush;
            this.lblTabelaSAP.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblTabelaSAP.ForeColor = System.Drawing.Color.Maroon;
            this.lblTabelaSAP.Location = new System.Drawing.Point(7, 64);
            this.lblTabelaSAP.Name = "lblTabelaSAP";
            this.lblTabelaSAP.Size = new System.Drawing.Size(226, 20);
            this.lblTabelaSAP.Text = "Tabela do SAP";
            this.lblTabelaSAP.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtTabelaInventarioBensColunas
            // 
            this.txtTabelaInventarioBensColunas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtTabelaInventarioBensColunas.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.txtTabelaInventarioBensColunas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtTabelaInventarioBensColunas.Location = new System.Drawing.Point(180, 44);
            this.txtTabelaInventarioBensColunas.Name = "txtTabelaInventarioBensColunas";
            this.txtTabelaInventarioBensColunas.Size = new System.Drawing.Size(53, 20);
            this.txtTabelaInventarioBensColunas.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtTabelaInventarioBensLinhas
            // 
            this.txtTabelaInventarioBensLinhas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtTabelaInventarioBensLinhas.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.txtTabelaInventarioBensLinhas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtTabelaInventarioBensLinhas.Location = new System.Drawing.Point(65, 44);
            this.txtTabelaInventarioBensLinhas.Name = "txtTabelaInventarioBensLinhas";
            this.txtTabelaInventarioBensLinhas.Size = new System.Drawing.Size(55, 20);
            this.txtTabelaInventarioBensLinhas.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTabelaInventarioBensColunas
            // 
            this.lblTabelaInventarioBensColunas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lblTabelaInventarioBensColunas.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblTabelaInventarioBensColunas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTabelaInventarioBensColunas.Location = new System.Drawing.Point(119, 44);
            this.lblTabelaInventarioBensColunas.Name = "lblTabelaInventarioBensColunas";
            this.lblTabelaInventarioBensColunas.Size = new System.Drawing.Size(65, 20);
            this.lblTabelaInventarioBensColunas.Text = "Colunas:";
            this.lblTabelaInventarioBensColunas.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTabelaInventarioBensLinhas
            // 
            this.lblTabelaInventarioBensLinhas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lblTabelaInventarioBensLinhas.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblTabelaInventarioBensLinhas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTabelaInventarioBensLinhas.Location = new System.Drawing.Point(7, 44);
            this.lblTabelaInventarioBensLinhas.Name = "lblTabelaInventarioBensLinhas";
            this.lblTabelaInventarioBensLinhas.Size = new System.Drawing.Size(60, 20);
            this.lblTabelaInventarioBensLinhas.Text = "Linhas:";
            this.lblTabelaInventarioBensLinhas.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTabelaInventarioBens
            // 
            this.lblTabelaInventarioBens.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lblTabelaInventarioBens.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblTabelaInventarioBens.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTabelaInventarioBens.Location = new System.Drawing.Point(7, 24);
            this.lblTabelaInventarioBens.Name = "lblTabelaInventarioBens";
            this.lblTabelaInventarioBens.Size = new System.Drawing.Size(226, 20);
            this.lblTabelaInventarioBens.Text = "Tabela de Inventário de Bens";
            this.lblTabelaInventarioBens.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tbpFotografia
            // 
            this.tbpFotografia.Controls.Add(this.btnTirarFotografiaL);
            this.tbpFotografia.Controls.Add(this.btnTravarFotografia);
            this.tbpFotografia.Controls.Add(this.btnZerarFotografia);
            this.tbpFotografia.Controls.Add(this.btnTirarFotografia);
            this.tbpFotografia.Controls.Add(this.pctFotografia);
            this.tbpFotografia.Location = new System.Drawing.Point(0, 0);
            this.tbpFotografia.Name = "tbpFotografia";
            this.tbpFotografia.Size = new System.Drawing.Size(232, 242);
            this.tbpFotografia.Text = "Fotografia";
            // 
            // btnTirarFotografiaL
            // 
            this.btnTirarFotografiaL.BackColor = System.Drawing.Color.White;
            this.btnTirarFotografiaL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnTirarFotografiaL.Location = new System.Drawing.Point(59, 226);
            this.btnTirarFotografiaL.Name = "btnTirarFotografiaL";
            this.btnTirarFotografiaL.Size = new System.Drawing.Size(20, 16);
            this.btnTirarFotografiaL.TabIndex = 2;
            this.btnTirarFotografiaL.Text = "L";
            this.btnTirarFotografiaL.Click += new System.EventHandler(this.btnTirarFotografiaL_Click);
            // 
            // btnTravarFotografia
            // 
            this.btnTravarFotografia.BackColor = System.Drawing.Color.White;
            this.btnTravarFotografia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnTravarFotografia.Location = new System.Drawing.Point(7, 226);
            this.btnTravarFotografia.Name = "btnTravarFotografia";
            this.btnTravarFotografia.Size = new System.Drawing.Size(46, 16);
            this.btnTravarFotografia.TabIndex = 1;
            this.btnTravarFotografia.Text = "&Travar";
            this.btnTravarFotografia.Click += new System.EventHandler(this.btnTravarFotografia_Click);
            // 
            // btnZerarFotografia
            // 
            this.btnZerarFotografia.BackColor = System.Drawing.Color.White;
            this.btnZerarFotografia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnZerarFotografia.Location = new System.Drawing.Point(85, 226);
            this.btnZerarFotografia.Name = "btnZerarFotografia";
            this.btnZerarFotografia.Size = new System.Drawing.Size(72, 16);
            this.btnZerarFotografia.TabIndex = 3;
            this.btnZerarFotografia.Text = "&Zerar";
            this.btnZerarFotografia.Click += new System.EventHandler(this.btnZerarFotografia_Click);
            // 
            // btnTirarFotografia
            // 
            this.btnTirarFotografia.BackColor = System.Drawing.Color.White;
            this.btnTirarFotografia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnTirarFotografia.Location = new System.Drawing.Point(161, 226);
            this.btnTirarFotografia.Name = "btnTirarFotografia";
            this.btnTirarFotografia.Size = new System.Drawing.Size(72, 16);
            this.btnTirarFotografia.TabIndex = 4;
            this.btnTirarFotografia.Text = "&Fotografar";
            this.btnTirarFotografia.Click += new System.EventHandler(this.btnTirarFotografia_Click);
            // 
            // pctFotografia
            // 
            this.pctFotografia.Image = ((System.Drawing.Image)(resources.GetObject("pctFotografia.Image")));
            this.pctFotografia.Location = new System.Drawing.Point(7, 7);
            this.pctFotografia.Name = "pctFotografia";
            this.pctFotografia.Size = new System.Drawing.Size(226, 213);
            this.pctFotografia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            // 
            // tbpGPS
            // 
            this.tbpGPS.Controls.Add(this.btnGPSPerimeter);
            this.tbpGPS.Controls.Add(this.btnGPSMenu);
            this.tbpGPS.Controls.Add(this.lblGPSPositionDilutionOfPrecision);
            this.tbpGPS.Controls.Add(this.txtGPSPositionDilutionOfPrecision);
            this.tbpGPS.Controls.Add(this.lblEllipsoidAltitude);
            this.tbpGPS.Controls.Add(this.txtEllipsoidAltitude);
            this.tbpGPS.Controls.Add(this.lblGPSLongitude);
            this.tbpGPS.Controls.Add(this.txtGPSLongitude);
            this.tbpGPS.Controls.Add(this.lblGPSLatitute);
            this.tbpGPS.Controls.Add(this.txtGPSLatitute);
            this.tbpGPS.Controls.Add(this.lblGPSServiceState);
            this.tbpGPS.Controls.Add(this.txtGPSServiceState);
            this.tbpGPS.Controls.Add(this.lblGPSDeviceState);
            this.tbpGPS.Controls.Add(this.txtGPSDeviceState);
            this.tbpGPS.Controls.Add(this.lblGPSDeviceUsed);
            this.tbpGPS.Controls.Add(this.txtGPSDeviceUsed);
            this.tbpGPS.Location = new System.Drawing.Point(0, 0);
            this.tbpGPS.Name = "tbpGPS";
            this.tbpGPS.Size = new System.Drawing.Size(232, 242);
            this.tbpGPS.Text = "GPS";
            // 
            // btnGPSPerimeter
            // 
            this.btnGPSPerimeter.BackColor = System.Drawing.Color.White;
            this.btnGPSPerimeter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGPSPerimeter.Location = new System.Drawing.Point(7, 227);
            this.btnGPSPerimeter.Name = "btnGPSPerimeter";
            this.btnGPSPerimeter.Size = new System.Drawing.Size(110, 16);
            this.btnGPSPerimeter.TabIndex = 8;
            this.btnGPSPerimeter.Text = "GPS Perimeter";
            this.btnGPSPerimeter.Click += new System.EventHandler(this.btnGPSPerimeter_Click);
            // 
            // btnGPSMenu
            // 
            this.btnGPSMenu.BackColor = System.Drawing.Color.White;
            this.btnGPSMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnGPSMenu.Location = new System.Drawing.Point(123, 227);
            this.btnGPSMenu.Name = "btnGPSMenu";
            this.btnGPSMenu.Size = new System.Drawing.Size(110, 16);
            this.btnGPSMenu.TabIndex = 9;
            this.btnGPSMenu.Text = "GPS";
            this.btnGPSMenu.Click += new System.EventHandler(this.btnmenuGPS_Click);
            // 
            // lblGPSPositionDilutionOfPrecision
            // 
            this.lblGPSPositionDilutionOfPrecision.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblGPSPositionDilutionOfPrecision.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.lblGPSPositionDilutionOfPrecision.Location = new System.Drawing.Point(123, 157);
            this.lblGPSPositionDilutionOfPrecision.Name = "lblGPSPositionDilutionOfPrecision";
            this.lblGPSPositionDilutionOfPrecision.Size = new System.Drawing.Size(110, 34);
            this.lblGPSPositionDilutionOfPrecision.Text = "Posição diluição da precisão";
            this.lblGPSPositionDilutionOfPrecision.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtGPSPositionDilutionOfPrecision
            // 
            this.txtGPSPositionDilutionOfPrecision.Enabled = false;
            this.txtGPSPositionDilutionOfPrecision.Location = new System.Drawing.Point(123, 194);
            this.txtGPSPositionDilutionOfPrecision.Name = "txtGPSPositionDilutionOfPrecision";
            this.txtGPSPositionDilutionOfPrecision.Size = new System.Drawing.Size(110, 21);
            this.txtGPSPositionDilutionOfPrecision.TabIndex = 7;
            // 
            // lblEllipsoidAltitude
            // 
            this.lblEllipsoidAltitude.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblEllipsoidAltitude.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.lblEllipsoidAltitude.Location = new System.Drawing.Point(7, 157);
            this.lblEllipsoidAltitude.Name = "lblEllipsoidAltitude";
            this.lblEllipsoidAltitude.Size = new System.Drawing.Size(110, 20);
            this.lblEllipsoidAltitude.Text = "Altitude";
            this.lblEllipsoidAltitude.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtEllipsoidAltitude
            // 
            this.txtEllipsoidAltitude.Enabled = false;
            this.txtEllipsoidAltitude.Location = new System.Drawing.Point(7, 194);
            this.txtEllipsoidAltitude.Name = "txtEllipsoidAltitude";
            this.txtEllipsoidAltitude.Size = new System.Drawing.Size(110, 21);
            this.txtEllipsoidAltitude.TabIndex = 6;
            // 
            // lblGPSLongitude
            // 
            this.lblGPSLongitude.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblGPSLongitude.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.lblGPSLongitude.Location = new System.Drawing.Point(123, 110);
            this.lblGPSLongitude.Name = "lblGPSLongitude";
            this.lblGPSLongitude.Size = new System.Drawing.Size(110, 20);
            this.lblGPSLongitude.Text = "Longitude";
            this.lblGPSLongitude.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtGPSLongitude
            // 
            this.txtGPSLongitude.Enabled = false;
            this.txtGPSLongitude.Location = new System.Drawing.Point(123, 133);
            this.txtGPSLongitude.Name = "txtGPSLongitude";
            this.txtGPSLongitude.Size = new System.Drawing.Size(110, 21);
            this.txtGPSLongitude.TabIndex = 5;
            // 
            // lblGPSLatitute
            // 
            this.lblGPSLatitute.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblGPSLatitute.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.lblGPSLatitute.Location = new System.Drawing.Point(7, 110);
            this.lblGPSLatitute.Name = "lblGPSLatitute";
            this.lblGPSLatitute.Size = new System.Drawing.Size(110, 20);
            this.lblGPSLatitute.Text = "Latitude";
            this.lblGPSLatitute.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtGPSLatitute
            // 
            this.txtGPSLatitute.Enabled = false;
            this.txtGPSLatitute.Location = new System.Drawing.Point(7, 133);
            this.txtGPSLatitute.Name = "txtGPSLatitute";
            this.txtGPSLatitute.Size = new System.Drawing.Size(110, 21);
            this.txtGPSLatitute.TabIndex = 4;
            // 
            // lblGPSServiceState
            // 
            this.lblGPSServiceState.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblGPSServiceState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.lblGPSServiceState.Location = new System.Drawing.Point(123, 51);
            this.lblGPSServiceState.Name = "lblGPSServiceState";
            this.lblGPSServiceState.Size = new System.Drawing.Size(110, 32);
            this.lblGPSServiceState.Text = "Estado do Serviço";
            this.lblGPSServiceState.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtGPSServiceState
            // 
            this.txtGPSServiceState.Enabled = false;
            this.txtGPSServiceState.Location = new System.Drawing.Point(123, 86);
            this.txtGPSServiceState.Name = "txtGPSServiceState";
            this.txtGPSServiceState.Size = new System.Drawing.Size(110, 21);
            this.txtGPSServiceState.TabIndex = 3;
            // 
            // lblGPSDeviceState
            // 
            this.lblGPSDeviceState.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblGPSDeviceState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.lblGPSDeviceState.Location = new System.Drawing.Point(7, 51);
            this.lblGPSDeviceState.Name = "lblGPSDeviceState";
            this.lblGPSDeviceState.Size = new System.Drawing.Size(110, 32);
            this.lblGPSDeviceState.Text = "Estado do Dispositivo";
            this.lblGPSDeviceState.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtGPSDeviceState
            // 
            this.txtGPSDeviceState.Enabled = false;
            this.txtGPSDeviceState.Location = new System.Drawing.Point(7, 86);
            this.txtGPSDeviceState.Name = "txtGPSDeviceState";
            this.txtGPSDeviceState.Size = new System.Drawing.Size(110, 21);
            this.txtGPSDeviceState.TabIndex = 2;
            // 
            // lblGPSDeviceUsed
            // 
            this.lblGPSDeviceUsed.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblGPSDeviceUsed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.lblGPSDeviceUsed.Location = new System.Drawing.Point(7, 4);
            this.lblGPSDeviceUsed.Name = "lblGPSDeviceUsed";
            this.lblGPSDeviceUsed.Size = new System.Drawing.Size(226, 20);
            this.lblGPSDeviceUsed.Text = "GPS Usado";
            this.lblGPSDeviceUsed.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtGPSDeviceUsed
            // 
            this.txtGPSDeviceUsed.Enabled = false;
            this.txtGPSDeviceUsed.Location = new System.Drawing.Point(7, 27);
            this.txtGPSDeviceUsed.Name = "txtGPSDeviceUsed";
            this.txtGPSDeviceUsed.Size = new System.Drawing.Size(226, 21);
            this.txtGPSDeviceUsed.TabIndex = 1;
            // 
            // tbpMapa
            // 
            this.tbpMapa.Controls.Add(this.btnVisualizarMapa);
            this.tbpMapa.Controls.Add(this.tcbMapa);
            this.tbpMapa.Controls.Add(this.wbMapa);
            this.tbpMapa.Location = new System.Drawing.Point(0, 0);
            this.tbpMapa.Name = "tbpMapa";
            this.tbpMapa.Size = new System.Drawing.Size(232, 242);
            this.tbpMapa.Text = "Mapa";
            // 
            // btnVisualizarMapa
            // 
            this.btnVisualizarMapa.BackColor = System.Drawing.Color.White;
            this.btnVisualizarMapa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnVisualizarMapa.Location = new System.Drawing.Point(164, 220);
            this.btnVisualizarMapa.Name = "btnVisualizarMapa";
            this.btnVisualizarMapa.Size = new System.Drawing.Size(69, 20);
            this.btnVisualizarMapa.TabIndex = 2;
            this.btnVisualizarMapa.Text = "Visualizar";
            this.btnVisualizarMapa.Click += new System.EventHandler(this.btnVisualizarMapa_Click);
            // 
            // tcbMapa
            // 
            this.tcbMapa.Location = new System.Drawing.Point(7, 220);
            this.tcbMapa.Maximum = 21;
            this.tcbMapa.Name = "tcbMapa";
            this.tcbMapa.Size = new System.Drawing.Size(151, 18);
            this.tcbMapa.TabIndex = 1;
            this.tcbMapa.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tcbMapa.Value = 4;
            this.tcbMapa.ValueChanged += new System.EventHandler(this.tcbMapa_ValueChanged);
            // 
            // wbMapa
            // 
            this.wbMapa.Location = new System.Drawing.Point(7, 7);
            this.wbMapa.Name = "wbMapa";
            this.wbMapa.ScriptErrorsSuppressed = true;
            this.wbMapa.Size = new System.Drawing.Size(226, 207);
            // 
            // tbpConfiguracoesExtras
            // 
            this.tbpConfiguracoesExtras.Controls.Add(this.chkProcuraAutomatica);
            this.tbpConfiguracoesExtras.Controls.Add(this.chkIncrementarPatrimonio);
            this.tbpConfiguracoesExtras.Controls.Add(this.chkPermitirExibicaoNotificacoes);
            this.tbpConfiguracoesExtras.Controls.Add(this.chkModoOtimizadoCadastro);
            this.tbpConfiguracoesExtras.Controls.Add(this.cmbPrioridadeModoOtimizadoCadastro);
            this.tbpConfiguracoesExtras.Controls.Add(this.lblPrioridadeModoOtimizadoCadastro);
            this.tbpConfiguracoesExtras.Controls.Add(this.lblTipoMapa);
            this.tbpConfiguracoesExtras.Controls.Add(this.cmbTipoMapa);
            this.tbpConfiguracoesExtras.Controls.Add(this.lblQualidadeFotografia);
            this.tbpConfiguracoesExtras.Controls.Add(this.cmbQualidadeFotografia);
            this.tbpConfiguracoesExtras.Controls.Add(this.lblResolucaoFotografia);
            this.tbpConfiguracoesExtras.Controls.Add(this.cmbResolucaoFotografia);
            this.tbpConfiguracoesExtras.Controls.Add(this.pctConfiguracoesExtras);
            this.tbpConfiguracoesExtras.Location = new System.Drawing.Point(0, 0);
            this.tbpConfiguracoesExtras.Name = "tbpConfiguracoesExtras";
            this.tbpConfiguracoesExtras.Size = new System.Drawing.Size(232, 242);
            this.tbpConfiguracoesExtras.Text = "Configurações Extras";
            // 
            // chkProcuraAutomatica
            // 
            this.chkProcuraAutomatica.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.chkProcuraAutomatica.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.chkProcuraAutomatica.Location = new System.Drawing.Point(7, 166);
            this.chkProcuraAutomatica.Name = "chkProcuraAutomatica";
            this.chkProcuraAutomatica.Size = new System.Drawing.Size(226, 20);
            this.chkProcuraAutomatica.TabIndex = 18;
            this.chkProcuraAutomatica.Text = "&Procura Automática";
            this.chkProcuraAutomatica.Click += new System.EventHandler(this.chkProcuraAutomatica_Click);
            // 
            // chkIncrementarPatrimonio
            // 
            this.chkIncrementarPatrimonio.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.chkIncrementarPatrimonio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.chkIncrementarPatrimonio.Location = new System.Drawing.Point(7, 192);
            this.chkIncrementarPatrimonio.Name = "chkIncrementarPatrimonio";
            this.chkIncrementarPatrimonio.Size = new System.Drawing.Size(226, 20);
            this.chkIncrementarPatrimonio.TabIndex = 12;
            this.chkIncrementarPatrimonio.Text = "&Incrementar Patrimonio";
            this.chkIncrementarPatrimonio.Click += new System.EventHandler(this.chkIncrementarPatrimonio_Click);
            // 
            // chkPermitirExibicaoNotificacoes
            // 
            this.chkPermitirExibicaoNotificacoes.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.chkPermitirExibicaoNotificacoes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.chkPermitirExibicaoNotificacoes.Location = new System.Drawing.Point(7, 114);
            this.chkPermitirExibicaoNotificacoes.Name = "chkPermitirExibicaoNotificacoes";
            this.chkPermitirExibicaoNotificacoes.Size = new System.Drawing.Size(226, 20);
            this.chkPermitirExibicaoNotificacoes.TabIndex = 4;
            this.chkPermitirExibicaoNotificacoes.Text = "&Permitir exibições de notificações";
            this.chkPermitirExibicaoNotificacoes.Click += new System.EventHandler(this.chkPermitirExibicaoNotificacoes_Click);
            // 
            // chkModoOtimizadoCadastro
            // 
            this.chkModoOtimizadoCadastro.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.chkModoOtimizadoCadastro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.chkModoOtimizadoCadastro.Location = new System.Drawing.Point(7, 140);
            this.chkModoOtimizadoCadastro.Name = "chkModoOtimizadoCadastro";
            this.chkModoOtimizadoCadastro.Size = new System.Drawing.Size(226, 20);
            this.chkModoOtimizadoCadastro.TabIndex = 5;
            this.chkModoOtimizadoCadastro.Text = "Modo Otimizado de &Cadastro";
            this.chkModoOtimizadoCadastro.Click += new System.EventHandler(this.chkModoOtimizadoCadastro_Click);
            // 
            // cmbPrioridadeModoOtimizadoCadastro
            // 
            this.cmbPrioridadeModoOtimizadoCadastro.Location = new System.Drawing.Point(93, 221);
            this.cmbPrioridadeModoOtimizadoCadastro.Name = "cmbPrioridadeModoOtimizadoCadastro";
            this.cmbPrioridadeModoOtimizadoCadastro.Size = new System.Drawing.Size(140, 22);
            this.cmbPrioridadeModoOtimizadoCadastro.TabIndex = 6;
            this.cmbPrioridadeModoOtimizadoCadastro.TextChanged += new System.EventHandler(this.cmbPrioridadeModoOtimizadoCadastro_TextChanged);
            // 
            // lblPrioridadeModoOtimizadoCadastro
            // 
            this.lblPrioridadeModoOtimizadoCadastro.Font = new System.Drawing.Font("Tahoma", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblPrioridadeModoOtimizadoCadastro.ForeColor = System.Drawing.Color.Navy;
            this.lblPrioridadeModoOtimizadoCadastro.Location = new System.Drawing.Point(7, 221);
            this.lblPrioridadeModoOtimizadoCadastro.Name = "lblPrioridadeModoOtimizadoCadastro";
            this.lblPrioridadeModoOtimizadoCadastro.Size = new System.Drawing.Size(80, 22);
            this.lblPrioridadeModoOtimizadoCadastro.Text = "Prioridade:";
            this.lblPrioridadeModoOtimizadoCadastro.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTipoMapa
            // 
            this.lblTipoMapa.BackColor = System.Drawing.Color.White;
            this.lblTipoMapa.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblTipoMapa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblTipoMapa.Location = new System.Drawing.Point(53, 7);
            this.lblTipoMapa.Name = "lblTipoMapa";
            this.lblTipoMapa.Size = new System.Drawing.Size(180, 20);
            this.lblTipoMapa.Text = "Tipo do Mapa";
            this.lblTipoMapa.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmbTipoMapa
            // 
            this.cmbTipoMapa.Location = new System.Drawing.Point(53, 30);
            this.cmbTipoMapa.Name = "cmbTipoMapa";
            this.cmbTipoMapa.Size = new System.Drawing.Size(180, 22);
            this.cmbTipoMapa.TabIndex = 1;
            // 
            // lblQualidadeFotografia
            // 
            this.lblQualidadeFotografia.BackColor = System.Drawing.Color.White;
            this.lblQualidadeFotografia.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblQualidadeFotografia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblQualidadeFotografia.Location = new System.Drawing.Point(7, 60);
            this.lblQualidadeFotografia.Name = "lblQualidadeFotografia";
            this.lblQualidadeFotografia.Size = new System.Drawing.Size(94, 20);
            this.lblQualidadeFotografia.Text = "Qual. da Fot.:";
            this.lblQualidadeFotografia.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmbQualidadeFotografia
            // 
            this.cmbQualidadeFotografia.Location = new System.Drawing.Point(107, 58);
            this.cmbQualidadeFotografia.Name = "cmbQualidadeFotografia";
            this.cmbQualidadeFotografia.Size = new System.Drawing.Size(126, 22);
            this.cmbQualidadeFotografia.TabIndex = 2;
            this.cmbQualidadeFotografia.TextChanged += new System.EventHandler(this.cmbQualidadeFotografia_TextChanged);
            // 
            // lblResolucaoFotografia
            // 
            this.lblResolucaoFotografia.BackColor = System.Drawing.Color.White;
            this.lblResolucaoFotografia.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblResolucaoFotografia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblResolucaoFotografia.Location = new System.Drawing.Point(7, 88);
            this.lblResolucaoFotografia.Name = "lblResolucaoFotografia";
            this.lblResolucaoFotografia.Size = new System.Drawing.Size(94, 20);
            this.lblResolucaoFotografia.Text = "Res. da Fot.:";
            this.lblResolucaoFotografia.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmbResolucaoFotografia
            // 
            this.cmbResolucaoFotografia.Location = new System.Drawing.Point(107, 86);
            this.cmbResolucaoFotografia.Name = "cmbResolucaoFotografia";
            this.cmbResolucaoFotografia.Size = new System.Drawing.Size(126, 22);
            this.cmbResolucaoFotografia.TabIndex = 3;
            this.cmbResolucaoFotografia.TextChanged += new System.EventHandler(this.cmbResolucaoFotografia_TextChanged);
            // 
            // pctConfiguracoesExtras
            // 
            this.pctConfiguracoesExtras.Image = ((System.Drawing.Image)(resources.GetObject("pctConfiguracoesExtras.Image")));
            this.pctConfiguracoesExtras.Location = new System.Drawing.Point(7, 7);
            this.pctConfiguracoesExtras.Name = "pctConfiguracoesExtras";
            this.pctConfiguracoesExtras.Size = new System.Drawing.Size(40, 40);
            this.pctConfiguracoesExtras.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // tbpZerarTabelas
            // 
            this.tbpZerarTabelas.Controls.Add(this.txtSenhaZerarTabelas);
            this.tbpZerarTabelas.Controls.Add(this.lblSenhaZerarTabelas);
            this.tbpZerarTabelas.Controls.Add(this.lblDeletarTodosDados);
            this.tbpZerarTabelas.Controls.Add(this.lblZerarTabelaCentroCusto);
            this.tbpZerarTabelas.Controls.Add(this.btnZerarTabelaCentroCusto);
            this.tbpZerarTabelas.Controls.Add(this.lblZerarTabelaEmpregados);
            this.tbpZerarTabelas.Controls.Add(this.btnZerarTabelaEmpregados);
            this.tbpZerarTabelas.Controls.Add(this.lblZerarTabelaSAP);
            this.tbpZerarTabelas.Controls.Add(this.lblZerarTabelaInventarioBens);
            this.tbpZerarTabelas.Controls.Add(this.btnZerarTabelaSAP);
            this.tbpZerarTabelas.Controls.Add(this.btnZerarTabelaInventarioBens);
            this.tbpZerarTabelas.Location = new System.Drawing.Point(0, 0);
            this.tbpZerarTabelas.Name = "tbpZerarTabelas";
            this.tbpZerarTabelas.Size = new System.Drawing.Size(232, 242);
            this.tbpZerarTabelas.Text = "Zerar Tabelas";
            // 
            // txtSenhaZerarTabelas
            // 
            this.txtSenhaZerarTabelas.Location = new System.Drawing.Point(93, 221);
            this.txtSenhaZerarTabelas.Name = "txtSenhaZerarTabelas";
            this.txtSenhaZerarTabelas.PasswordChar = '*';
            this.txtSenhaZerarTabelas.Size = new System.Drawing.Size(140, 21);
            this.txtSenhaZerarTabelas.TabIndex = 23;
            // 
            // lblSenhaZerarTabelas
            // 
            this.lblSenhaZerarTabelas.BackColor = System.Drawing.Color.White;
            this.lblSenhaZerarTabelas.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblSenhaZerarTabelas.ForeColor = System.Drawing.Color.SlateGray;
            this.lblSenhaZerarTabelas.Location = new System.Drawing.Point(7, 222);
            this.lblSenhaZerarTabelas.Name = "lblSenhaZerarTabelas";
            this.lblSenhaZerarTabelas.Size = new System.Drawing.Size(80, 20);
            this.lblSenhaZerarTabelas.Text = "Senha:";
            this.lblSenhaZerarTabelas.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDeletarTodosDados
            // 
            this.lblDeletarTodosDados.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblDeletarTodosDados.ForeColor = System.Drawing.Color.SlateGray;
            this.lblDeletarTodosDados.Location = new System.Drawing.Point(7, 4);
            this.lblDeletarTodosDados.Name = "lblDeletarTodosDados";
            this.lblDeletarTodosDados.Size = new System.Drawing.Size(226, 20);
            this.lblDeletarTodosDados.Text = "Deletar Todos os Dados";
            this.lblDeletarTodosDados.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblZerarTabelaCentroCusto
            // 
            this.lblZerarTabelaCentroCusto.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblZerarTabelaCentroCusto.ForeColor = System.Drawing.Color.Olive;
            this.lblZerarTabelaCentroCusto.Location = new System.Drawing.Point(7, 160);
            this.lblZerarTabelaCentroCusto.Name = "lblZerarTabelaCentroCusto";
            this.lblZerarTabelaCentroCusto.Size = new System.Drawing.Size(226, 20);
            this.lblZerarTabelaCentroCusto.Text = "Centro de Custo";
            this.lblZerarTabelaCentroCusto.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnZerarTabelaCentroCusto
            // 
            this.btnZerarTabelaCentroCusto.BackColor = System.Drawing.Color.White;
            this.btnZerarTabelaCentroCusto.ForeColor = System.Drawing.Color.DarkKhaki;
            this.btnZerarTabelaCentroCusto.Location = new System.Drawing.Point(7, 183);
            this.btnZerarTabelaCentroCusto.Name = "btnZerarTabelaCentroCusto";
            this.btnZerarTabelaCentroCusto.Size = new System.Drawing.Size(226, 16);
            this.btnZerarTabelaCentroCusto.TabIndex = 18;
            this.btnZerarTabelaCentroCusto.Text = "Zer&ar Número de Itens";
            this.btnZerarTabelaCentroCusto.Click += new System.EventHandler(this.btnZerarTabelaCentroCusto_Click);
            // 
            // lblZerarTabelaEmpregados
            // 
            this.lblZerarTabelaEmpregados.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblZerarTabelaEmpregados.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblZerarTabelaEmpregados.Location = new System.Drawing.Point(7, 118);
            this.lblZerarTabelaEmpregados.Name = "lblZerarTabelaEmpregados";
            this.lblZerarTabelaEmpregados.Size = new System.Drawing.Size(226, 20);
            this.lblZerarTabelaEmpregados.Text = "Empregados";
            this.lblZerarTabelaEmpregados.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnZerarTabelaEmpregados
            // 
            this.btnZerarTabelaEmpregados.BackColor = System.Drawing.Color.White;
            this.btnZerarTabelaEmpregados.ForeColor = System.Drawing.Color.CadetBlue;
            this.btnZerarTabelaEmpregados.Location = new System.Drawing.Point(7, 141);
            this.btnZerarTabelaEmpregados.Name = "btnZerarTabelaEmpregados";
            this.btnZerarTabelaEmpregados.Size = new System.Drawing.Size(226, 16);
            this.btnZerarTabelaEmpregados.TabIndex = 15;
            this.btnZerarTabelaEmpregados.Text = "Ze&rar Número de Itens";
            this.btnZerarTabelaEmpregados.Click += new System.EventHandler(this.btnZerarTabelaEmpregados_Click);
            // 
            // lblZerarTabelaSAP
            // 
            this.lblZerarTabelaSAP.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblZerarTabelaSAP.ForeColor = System.Drawing.Color.Firebrick;
            this.lblZerarTabelaSAP.Location = new System.Drawing.Point(7, 76);
            this.lblZerarTabelaSAP.Name = "lblZerarTabelaSAP";
            this.lblZerarTabelaSAP.Size = new System.Drawing.Size(226, 20);
            this.lblZerarTabelaSAP.Text = "SAP";
            this.lblZerarTabelaSAP.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblZerarTabelaInventarioBens
            // 
            this.lblZerarTabelaInventarioBens.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblZerarTabelaInventarioBens.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblZerarTabelaInventarioBens.Location = new System.Drawing.Point(7, 34);
            this.lblZerarTabelaInventarioBens.Name = "lblZerarTabelaInventarioBens";
            this.lblZerarTabelaInventarioBens.Size = new System.Drawing.Size(226, 20);
            this.lblZerarTabelaInventarioBens.Text = "Inventário Bens";
            this.lblZerarTabelaInventarioBens.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnZerarTabelaSAP
            // 
            this.btnZerarTabelaSAP.BackColor = System.Drawing.Color.White;
            this.btnZerarTabelaSAP.ForeColor = System.Drawing.Color.IndianRed;
            this.btnZerarTabelaSAP.Location = new System.Drawing.Point(7, 99);
            this.btnZerarTabelaSAP.Name = "btnZerarTabelaSAP";
            this.btnZerarTabelaSAP.Size = new System.Drawing.Size(226, 16);
            this.btnZerarTabelaSAP.TabIndex = 11;
            this.btnZerarTabelaSAP.Text = "Z&erar Número de Itens";
            this.btnZerarTabelaSAP.Click += new System.EventHandler(this.btnZerarTabelaSAP_Click);
            // 
            // btnZerarTabelaInventarioBens
            // 
            this.btnZerarTabelaInventarioBens.BackColor = System.Drawing.Color.White;
            this.btnZerarTabelaInventarioBens.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btnZerarTabelaInventarioBens.Location = new System.Drawing.Point(7, 57);
            this.btnZerarTabelaInventarioBens.Name = "btnZerarTabelaInventarioBens";
            this.btnZerarTabelaInventarioBens.Size = new System.Drawing.Size(226, 16);
            this.btnZerarTabelaInventarioBens.TabIndex = 10;
            this.btnZerarTabelaInventarioBens.Text = "&Zerar Número de Itens";
            this.btnZerarTabelaInventarioBens.Click += new System.EventHandler(this.btnZerarTabelaInventarioBens_Click);
            // 
            // tbpSair
            // 
            this.tbpSair.Controls.Add(this.btnTemporizadorCancelar);
            this.tbpSair.Controls.Add(this.lblTemporizadorUnidade);
            this.tbpSair.Controls.Add(this.txtTemporizador);
            this.tbpSair.Controls.Add(this.lblTemporizador);
            this.tbpSair.Controls.Add(this.btnForcarDesligamento);
            this.tbpSair.Controls.Add(this.btnSairFazerBackup);
            this.tbpSair.Controls.Add(this.lblTeclaPressionada);
            this.tbpSair.Controls.Add(this.txtNumeroCopiasBackup);
            this.tbpSair.Controls.Add(this.lblNumeroCopiasBackup);
            this.tbpSair.Controls.Add(this.btnBackup);
            this.tbpSair.Controls.Add(this.btnSobre);
            this.tbpSair.Controls.Add(this.txtCodigoTeclaDigitado);
            this.tbpSair.Controls.Add(this.pctSairAplicativo);
            this.tbpSair.Location = new System.Drawing.Point(0, 0);
            this.tbpSair.Name = "tbpSair";
            this.tbpSair.Size = new System.Drawing.Size(232, 242);
            this.tbpSair.Text = "Sair";
            // 
            // btnTemporizadorCancelar
            // 
            this.btnTemporizadorCancelar.BackColor = System.Drawing.Color.White;
            this.btnTemporizadorCancelar.ForeColor = System.Drawing.Color.Maroon;
            this.btnTemporizadorCancelar.Location = new System.Drawing.Point(203, 140);
            this.btnTemporizadorCancelar.Name = "btnTemporizadorCancelar";
            this.btnTemporizadorCancelar.Size = new System.Drawing.Size(30, 16);
            this.btnTemporizadorCancelar.TabIndex = 20;
            this.btnTemporizadorCancelar.Text = "&C";
            this.btnTemporizadorCancelar.Click += new System.EventHandler(this.btnTemporizadorCancelar_Click);
            // 
            // lblTemporizadorUnidade
            // 
            this.lblTemporizadorUnidade.BackColor = System.Drawing.Color.White;
            this.lblTemporizadorUnidade.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblTemporizadorUnidade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblTemporizadorUnidade.Location = new System.Drawing.Point(165, 136);
            this.lblTemporizadorUnidade.Name = "lblTemporizadorUnidade";
            this.lblTemporizadorUnidade.Size = new System.Drawing.Size(32, 20);
            this.lblTemporizadorUnidade.Text = "min.";
            this.lblTemporizadorUnidade.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtTemporizador
            // 
            this.txtTemporizador.Location = new System.Drawing.Point(109, 135);
            this.txtTemporizador.Name = "txtTemporizador";
            this.txtTemporizador.Size = new System.Drawing.Size(50, 21);
            this.txtTemporizador.TabIndex = 15;
            this.txtTemporizador.TextChanged += new System.EventHandler(this.txtTemporizador_TextChanged);
            this.txtTemporizador.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTemporizador_KeyPress);
            // 
            // lblTemporizador
            // 
            this.lblTemporizador.BackColor = System.Drawing.Color.White;
            this.lblTemporizador.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblTemporizador.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblTemporizador.Location = new System.Drawing.Point(7, 136);
            this.lblTemporizador.Name = "lblTemporizador";
            this.lblTemporizador.Size = new System.Drawing.Size(96, 20);
            this.lblTemporizador.Text = "Temporizador:";
            this.lblTemporizador.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnForcarDesligamento
            // 
            this.btnForcarDesligamento.BackColor = System.Drawing.Color.White;
            this.btnForcarDesligamento.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnForcarDesligamento.Location = new System.Drawing.Point(7, 225);
            this.btnForcarDesligamento.Name = "btnForcarDesligamento";
            this.btnForcarDesligamento.Size = new System.Drawing.Size(226, 16);
            this.btnForcarDesligamento.TabIndex = 10;
            this.btnForcarDesligamento.Text = "Forçar &Desligamento";
            this.btnForcarDesligamento.Click += new System.EventHandler(this.btnForcarDesligamento_Click);
            // 
            // btnSairFazerBackup
            // 
            this.btnSairFazerBackup.BackColor = System.Drawing.Color.White;
            this.btnSairFazerBackup.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnSairFazerBackup.Location = new System.Drawing.Point(7, 203);
            this.btnSairFazerBackup.Name = "btnSairFazerBackup";
            this.btnSairFazerBackup.Size = new System.Drawing.Size(226, 16);
            this.btnSairFazerBackup.TabIndex = 6;
            this.btnSairFazerBackup.Text = "Sair e &Fazer Backup";
            this.btnSairFazerBackup.Click += new System.EventHandler(this.btnSairFazerBackup_Click);
            // 
            // lblTeclaPressionada
            // 
            this.lblTeclaPressionada.BackColor = System.Drawing.Color.White;
            this.lblTeclaPressionada.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblTeclaPressionada.ForeColor = System.Drawing.Color.Firebrick;
            this.lblTeclaPressionada.Location = new System.Drawing.Point(7, 38);
            this.lblTeclaPressionada.Name = "lblTeclaPressionada";
            this.lblTeclaPressionada.Size = new System.Drawing.Size(226, 20);
            this.lblTeclaPressionada.Text = "Tecla Pressionada:";
            this.lblTeclaPressionada.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtNumeroCopiasBackup
            // 
            this.txtNumeroCopiasBackup.Location = new System.Drawing.Point(7, 108);
            this.txtNumeroCopiasBackup.Name = "txtNumeroCopiasBackup";
            this.txtNumeroCopiasBackup.Size = new System.Drawing.Size(226, 21);
            this.txtNumeroCopiasBackup.TabIndex = 2;
            this.txtNumeroCopiasBackup.TextChanged += new System.EventHandler(this.txtNumeroCopiasBackup_TextChanged);
            this.txtNumeroCopiasBackup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroCopiasBackup_KeyPress);
            // 
            // lblNumeroCopiasBackup
            // 
            this.lblNumeroCopiasBackup.BackColor = System.Drawing.Color.White;
            this.lblNumeroCopiasBackup.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblNumeroCopiasBackup.ForeColor = System.Drawing.Color.Firebrick;
            this.lblNumeroCopiasBackup.Location = new System.Drawing.Point(7, 85);
            this.lblNumeroCopiasBackup.Name = "lblNumeroCopiasBackup";
            this.lblNumeroCopiasBackup.Size = new System.Drawing.Size(226, 20);
            this.lblNumeroCopiasBackup.Text = "Número de Cópias:";
            this.lblNumeroCopiasBackup.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnBackup
            // 
            this.btnBackup.BackColor = System.Drawing.Color.White;
            this.btnBackup.ForeColor = System.Drawing.Color.OliveDrab;
            this.btnBackup.Location = new System.Drawing.Point(7, 159);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(226, 16);
            this.btnBackup.TabIndex = 3;
            this.btnBackup.Text = "&Backup";
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnSobre
            // 
            this.btnSobre.BackColor = System.Drawing.Color.White;
            this.btnSobre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.btnSobre.Location = new System.Drawing.Point(7, 181);
            this.btnSobre.Name = "btnSobre";
            this.btnSobre.Size = new System.Drawing.Size(226, 16);
            this.btnSobre.TabIndex = 4;
            this.btnSobre.Text = "S&obre";
            this.btnSobre.Click += new System.EventHandler(this.btnSobre_Click);
            // 
            // txtCodigoTeclaDigitado
            // 
            this.txtCodigoTeclaDigitado.Enabled = false;
            this.txtCodigoTeclaDigitado.Location = new System.Drawing.Point(7, 61);
            this.txtCodigoTeclaDigitado.Multiline = true;
            this.txtCodigoTeclaDigitado.Name = "txtCodigoTeclaDigitado";
            this.txtCodigoTeclaDigitado.Size = new System.Drawing.Size(226, 21);
            this.txtCodigoTeclaDigitado.TabIndex = 1;
            this.txtCodigoTeclaDigitado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pctSairAplicativo
            // 
            this.pctSairAplicativo.Image = ((System.Drawing.Image)(resources.GetObject("pctSairAplicativo.Image")));
            this.pctSairAplicativo.Location = new System.Drawing.Point(105, 3);
            this.pctSairAplicativo.Name = "pctSairAplicativo";
            this.pctSairAplicativo.Size = new System.Drawing.Size(30, 30);
            this.pctSairAplicativo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctSairAplicativo.Tag = "";
            this.pctSairAplicativo.Click += new System.EventHandler(this.pctSairAplicativo_Click);
            // 
            // ntf1
            // 
            this.ntf1.Icon = ((System.Drawing.Icon)(resources.GetObject("ntf1.Icon")));
            this.ntf1.Text = "";
            // 
            // tmr1
            // 
            this.tmr1.Enabled = true;
            this.tmr1.Interval = 500;
            this.tmr1.Tick += new System.EventHandler(this.tmr1_Tick);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.tbc1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Menu = this.mnm1;
            this.Name = "frmPrincipal";
            this.Text = "Coletor de Dados";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.Click += new System.EventHandler(this.frmPrincipal_Click);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmPrincipal_Closing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPrincipal_KeyDown);
            this.tbpConfiguracoes.ResumeLayout(false);
            this.tbpTabelas.ResumeLayout(false);
            this.tbc2.ResumeLayout(false);
            this.tbpTabelaInventario.ResumeLayout(false);
            this.tbpTabelaSap.ResumeLayout(false);
            this.tbpTabelaEmpregados.ResumeLayout(false);
            this.tblTabelaCentroCusto.ResumeLayout(false);
            this.tbpDadosGerais.ResumeLayout(false);
            this.tbpControleFisico.ResumeLayout(false);
            this.tbpPrincipal.ResumeLayout(false);
            this.tbc1.ResumeLayout(false);
            this.tbpDadosComplementares.ResumeLayout(false);
            this.tbpRelatorios.ResumeLayout(false);
            this.tbc3.ResumeLayout(false);
            this.tblContador.ResumeLayout(false);
            this.tblRepeticoes.ResumeLayout(false);
            this.tblRegistros.ResumeLayout(false);
            this.tbpFotografia.ResumeLayout(false);
            this.tbpGPS.ResumeLayout(false);
            this.tbpMapa.ResumeLayout(false);
            this.tbpConfiguracoesExtras.ResumeLayout(false);
            this.tbpZerarTabelas.ResumeLayout(false);
            this.tbpSair.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem mni1;
        private System.Windows.Forms.MenuItem mni2;
        private System.Windows.Forms.OpenFileDialog ofd1;
        private System.Windows.Forms.TabPage tbpConfiguracoes;
        private System.Windows.Forms.Button btnEnderecoBaseDados;
        private System.Windows.Forms.TextBox txtEnderecoBaseDados;
        private System.Windows.Forms.TabPage tbpTabelas;
        private System.Windows.Forms.TabPage tbpDadosGerais;
        private System.Windows.Forms.TabPage tbpControleFisico;
        private System.Windows.Forms.Label lblNumeroInventario;
        private System.Windows.Forms.Label lblDataInventario;
        private System.Windows.Forms.TabPage tbpPrincipal;
        private System.Windows.Forms.Label lblUsuarioInventario;
        private System.Windows.Forms.Label lblMatriculaInventario;
        private System.Windows.Forms.TabControl tbc1;
        private System.Windows.Forms.PictureBox pctUsuarioInventario;
        private Microsoft.WindowsCE.Forms.Notification ntf1;
        private System.Windows.Forms.TabPage tbpFotografia;
        private System.Windows.Forms.Button btnTirarFotografia;
        private System.Windows.Forms.PictureBox pctFotografia;
        private System.Windows.Forms.TabPage tbpGPS;
        private System.Windows.Forms.Label lblGPSDeviceUsed;
        private System.Windows.Forms.TextBox txtGPSDeviceUsed;
        private System.Windows.Forms.Label lblGPSPositionDilutionOfPrecision;
        private System.Windows.Forms.TextBox txtGPSPositionDilutionOfPrecision;
        private System.Windows.Forms.Label lblEllipsoidAltitude;
        private System.Windows.Forms.TextBox txtEllipsoidAltitude;
        private System.Windows.Forms.Label lblGPSLongitude;
        private System.Windows.Forms.TextBox txtGPSLongitude;
        private System.Windows.Forms.Label lblGPSLatitute;
        private System.Windows.Forms.TextBox txtGPSLatitute;
        private System.Windows.Forms.Label lblGPSServiceState;
        private System.Windows.Forms.TextBox txtGPSServiceState;
        private System.Windows.Forms.Label lblGPSDeviceState;
        private System.Windows.Forms.TextBox txtGPSDeviceState;
        private System.Windows.Forms.Button btnGPSMenu;
        private System.Windows.Forms.Button btnZerarFotografia;
        private System.Windows.Forms.Button btnCompactarRepararBancoDados;
        private System.Windows.Forms.TabPage tbpSair;
        private System.Windows.Forms.PictureBox pctSairAplicativo;
        private System.Windows.Forms.PictureBox pctConfiguracoes;
        private System.Windows.Forms.Button btnTRGItem;
        private System.Windows.Forms.Button btnNomeItem;
        private System.Windows.Forms.Button btnMatriculaItem;
        private System.Windows.Forms.Button btnSalaItem;
        private System.Windows.Forms.Button btnOrgaoItem;
        private System.Windows.Forms.Button btnCentroCustoItem;
        private System.Windows.Forms.Button btnControleFisicoSelecionarButoes;
        private System.Windows.Forms.Label txtNumeroInventario;
        private System.Windows.Forms.TextBox txtCodigoTeclaDigitado;
        private System.Windows.Forms.Button btnPatrimonioItem;
        private System.Windows.Forms.Button btnDenominacaoItem;
        private System.Windows.Forms.Button btnNSerieItem;
        private System.Windows.Forms.Button btnPlacaVeiculoItem;
        private System.Windows.Forms.Button btnTravarFotografia;
        private System.Windows.Forms.Label lblNomeDispositivo;
        private System.Windows.Forms.TextBox txtNomeDispositivo;
        private System.Windows.Forms.DateTimePicker dtpTempoSistema;
        private System.Windows.Forms.DateTimePicker dtpDataSistema;
        private System.Windows.Forms.Timer tmr1;
        private System.Windows.Forms.Button btnDataTempoSistema;
        private System.Windows.Forms.Button btnModoCadastroInventario;
        private System.Windows.Forms.TabPage tbpMapa;
        private System.Windows.Forms.WebBrowser wbMapa;
        private System.Windows.Forms.TrackBar tcbMapa;
        private System.Windows.Forms.Button btnSincronizarHorarioServidor;
        private System.Windows.Forms.TabPage tbpConfiguracoesExtras;
        private System.Windows.Forms.PictureBox pctConfiguracoesExtras;
        private System.Windows.Forms.Button btnPatrimonioItemA;
        private System.Windows.Forms.Button btnPatrimonioItemL;
        private System.Windows.Forms.Button btnDenominacaoItemA;
        private System.Windows.Forms.Button btnDenominacaoItemL;
        private System.Windows.Forms.Button btnNSerieItemA;
        private System.Windows.Forms.Button btnNSerieItemL;
        private System.Windows.Forms.Button btnPlacaVeiculoItemA;
        private System.Windows.Forms.Button btnPlacaVeiculoItemL;
        private System.Windows.Forms.Button btnTRGItemL;
        private System.Windows.Forms.Button btnTRGItemA;
        private System.Windows.Forms.Button btnCentroCustoItemL;
        private System.Windows.Forms.Button btnCentroCustoItemA;
        private System.Windows.Forms.Button btnMatriculaItemL;
        private System.Windows.Forms.Button btnMatriculaItemA;
        private System.Windows.Forms.Button btnNomeItemL;
        private System.Windows.Forms.Button btnNomeItemA;
        private System.Windows.Forms.Button btnSalaItemL;
        private System.Windows.Forms.Button btnSalaItemA;
        private System.Windows.Forms.Button btnOrgaoItemL;
        private System.Windows.Forms.Button btnOrgaoItemA;
        private System.Windows.Forms.Button btnControleFisicoSelecionarButoesL;
        private System.Windows.Forms.Button btnControleFisicoSelecionarButoesA;
        private System.Windows.Forms.Button btnTirarFotografiaL;
        private System.Windows.Forms.Button btnVisualizarMapa;
        private System.Windows.Forms.Label lblResolucaoFotografia;
        private System.Windows.Forms.ComboBox cmbResolucaoFotografia;
        private System.Windows.Forms.Label lblQualidadeFotografia;
        private System.Windows.Forms.ComboBox cmbQualidadeFotografia;
        private System.Windows.Forms.Label lblNumeroLinhas;
        private System.Windows.Forms.Label lblTipoMapa;
        private System.Windows.Forms.ComboBox cmbTipoMapa;
        private System.Windows.Forms.TextBox txtSenhaBaseDados;
        private System.Windows.Forms.Label lblSenhaBaseDados;
        private System.Windows.Forms.Label lblEnderecoBaseDados;
        private System.Windows.Forms.Button btnMonitorCarregamentoDados;
        private System.Windows.Forms.TabPage tbpZerarTabelas;
        private System.Windows.Forms.TextBox txtPatrimonioItem;
        private System.Windows.Forms.TextBox txtDenominacaoItem;
        private System.Windows.Forms.TextBox txtNSerieItem;
        private System.Windows.Forms.TextBox txtPlacaVeiculoItem;
        private System.Windows.Forms.TextBox txtCentroCustoItem;
        private System.Windows.Forms.TextBox txtTRGItem;
        private System.Windows.Forms.TextBox txtOrgaoItem;
        private System.Windows.Forms.TextBox txtMatriculaItem;
        private System.Windows.Forms.TextBox txtNomeItem;
        private System.Windows.Forms.TextBox txtSalaItem;
        private System.Windows.Forms.TextBox txtMatriculaInventario;
        private System.Windows.Forms.TextBox txtUsuarioInventario;
        private System.Windows.Forms.ComboBox cmbPrioridadeModoOtimizadoCadastro;
        private System.Windows.Forms.Label lblPrioridadeModoOtimizadoCadastro;
        public System.Windows.Forms.DateTimePicker dtpDataInventario;
        private System.Windows.Forms.Button btnSobre;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.TextBox txtNumeroLinhas;
        private System.Windows.Forms.TextBox txtNumeroCopiasBackup;
        private System.Windows.Forms.Label lblNumeroCopiasBackup;
        private System.Windows.Forms.Button btnSemPatrimonio;
        private System.Windows.Forms.TextBox txtQuantidadeItem;
        private System.Windows.Forms.TabPage tbpDadosComplementares;
        private System.Windows.Forms.Button btnIdentificacaoItemA;
        private System.Windows.Forms.Button btnIdentificacaoItemL;
        private System.Windows.Forms.Button btnIdentificacaoItem;
        private System.Windows.Forms.Button btnObservacaoItemRecuar;
        private System.Windows.Forms.Button btnObservacaoItemL;
        private System.Windows.Forms.Button btnObservacaoItem;
        private System.Windows.Forms.ComboBox cmbObservacaoItem;
        private System.Windows.Forms.Button btnOutrosDadosItemA;
        private System.Windows.Forms.Button btnOutrosDadosItemL;
        private System.Windows.Forms.Button btnOutrosDadosItem;
        private System.Windows.Forms.TextBox txtIdentificacaoItem;
        private System.Windows.Forms.TextBox txtOutrosDadosItem;
        private System.Windows.Forms.Label lblQuantidadeItem;
        private System.Windows.Forms.Button btnIdentificacaoItemAvancar;
        private System.Windows.Forms.Button btnIdentificacaoItemRecuar;
        private System.Windows.Forms.Label lblTeclaPressionada;
        private System.Windows.Forms.Button btnDadosGeraisSelecionarButoesA;
        private System.Windows.Forms.Button btnDadosGeraisSelecionarButoesL;
        private System.Windows.Forms.Button btnDadosGeraisSelecionarButoes;
        private System.Windows.Forms.Button btnDadosComplementaresSelecionarButoesA;
        private System.Windows.Forms.Button btnDadosComplementaresSelecionarButoesL;
        private System.Windows.Forms.Button btnDadosComplementaresSelecionarButoes;
        private System.Windows.Forms.Button btnGPSPerimeter;
        private System.Windows.Forms.Button btnOutrosDadosItemRecuar;
        protected internal System.Windows.Forms.CheckBox chkModoOtimizadoCadastro;
        private System.Windows.Forms.Button btnPatrimonioItemOutrosDadosItem;
        private System.Windows.Forms.Button btnPatrimonioItemIdentificacaoItem;
        private System.Windows.Forms.Button btnNSerieItemOutrosDadosItem;
        private System.Windows.Forms.Button btnNSerieItemIdentificacaoItem;
        private System.Windows.Forms.Button btnBatteryStatus;
        private System.Windows.Forms.Button btnNivelBateria;
        private System.Windows.Forms.CheckBox chkPermitirExibicaoNotificacoes;
        private System.Windows.Forms.Button btnFlashDisk;
        private System.Windows.Forms.Button btnStorageCard;
        private System.Windows.Forms.Button btnOutrosDadosItemAvancar;
        private System.Windows.Forms.Button btnTestarConexao;
        private System.Windows.Forms.Label lblComprimentoColunas;
        private System.Windows.Forms.TextBox txtComprimentoColunas;
        private System.Windows.Forms.Button btnSairFazerBackup;
        private System.Windows.Forms.Button btnForcarDesligamento;
        private System.Windows.Forms.TextBox txtTemporizador;
        private System.Windows.Forms.Label lblTemporizador;
        private System.Windows.Forms.Label lblTemporizadorUnidade;
        private System.Windows.Forms.Button btnTemporizadorCancelar;
        private System.Windows.Forms.TabControl tbc2;
        private System.Windows.Forms.TabPage tbpTabelaInventario;
        public System.Windows.Forms.ComboBox cmbConsultarInventario;
        public System.Windows.Forms.TextBox txtConsultarInventario;
        protected internal System.Windows.Forms.DataGrid dtg1;
        private System.Windows.Forms.TabPage tbpTabelaSap;
        private System.Windows.Forms.ComboBox cmbConsultarSAP;
        private System.Windows.Forms.TextBox txtConsultarSAP;
        private System.Windows.Forms.DataGrid dtg2;
        private System.Windows.Forms.TabPage tbpTabelaEmpregados;
        private System.Windows.Forms.ComboBox cmbConsultarEmpregados;
        private System.Windows.Forms.TextBox txtConsultarEmpregados;
        private System.Windows.Forms.DataGrid dtg3;
        private System.Windows.Forms.TabPage tblTabelaCentroCusto;
        private System.Windows.Forms.ComboBox cmbConsultarCentroCusto;
        private System.Windows.Forms.TextBox txtConsultarCentroCusto;
        private System.Windows.Forms.DataGrid dtg4;
        private System.Windows.Forms.TabPage tbpRelatorios;
        private System.Windows.Forms.TabControl tbc3;
        private System.Windows.Forms.TabPage tblContador;
        private System.Windows.Forms.TextBox txtTabelaRelatorioFiltro;
        private System.Windows.Forms.Label lblTabelaRelatorioFiltro;
        private System.Windows.Forms.ComboBox cmbConsultarCamposRelatorio;
        private System.Windows.Forms.ComboBox cmbConsultarTabelaRelatorio;
        private System.Windows.Forms.DataGrid dtg5;
        private System.Windows.Forms.TabPage tblRepeticoes;
        private System.Windows.Forms.Label lblRepeticoes;
        public System.Windows.Forms.ComboBox cmbConsultarInventarioRepeticoes;
        private System.Windows.Forms.TextBox txtRepeticoes;
        private System.Windows.Forms.DataGrid dtg6;
        private System.Windows.Forms.TabPage tblRegistros;
        private System.Windows.Forms.Label lblRelatorioExtra;
        private System.Windows.Forms.Button btnRelatorioExtra;
        private System.Windows.Forms.Label txtTabelaCentroCustoColunas;
        private System.Windows.Forms.Label txtTabelaCentroCustoLinhas;
        private System.Windows.Forms.Label lblTabelaCentroCustoColunas;
        private System.Windows.Forms.Label lblTabelaCentroCustoLinhas;
        private System.Windows.Forms.Label lblTabelaCentroCusto;
        private System.Windows.Forms.Label txtTabelaEmpregadosColunas;
        private System.Windows.Forms.Label txtTabelaEmpregadosLinhas;
        private System.Windows.Forms.Label lblTabelaEmpregadosColunas;
        private System.Windows.Forms.Label lblTabelaEmpregadosLinhas;
        private System.Windows.Forms.Label lblTabelaEmpregados;
        private System.Windows.Forms.Label txtTabelaSAPColunas;
        private System.Windows.Forms.Label txtTabelaSAPLinhas;
        private System.Windows.Forms.Label lblTabelaSAPColunas;
        private System.Windows.Forms.Label lblTabelaSAPLinhas;
        private System.Windows.Forms.Label lblTabelaSAP;
        private System.Windows.Forms.Label txtTabelaInventarioBensColunas;
        private System.Windows.Forms.Label txtTabelaInventarioBensLinhas;
        private System.Windows.Forms.Label lblTabelaInventarioBensColunas;
        private System.Windows.Forms.Label lblTabelaInventarioBensLinhas;
        private System.Windows.Forms.Label lblTabelaInventarioBens;
        private System.Windows.Forms.Button btnZerarTabelaSAP;
        private System.Windows.Forms.Button btnZerarTabelaInventarioBens;
        private System.Windows.Forms.Label lblZerarTabelaInventarioBens;
        private System.Windows.Forms.Label lblZerarTabelaSAP;
        private System.Windows.Forms.Label lblZerarTabelaCentroCusto;
        private System.Windows.Forms.Button btnZerarTabelaCentroCusto;
        private System.Windows.Forms.Label lblZerarTabelaEmpregados;
        private System.Windows.Forms.Button btnZerarTabelaEmpregados;
        private System.Windows.Forms.Label lblDeletarTodosDados;
        protected internal System.Windows.Forms.CheckBox chkIncrementarPatrimonio;
        protected internal System.Windows.Forms.CheckBox chkProcuraAutomatica;
        private System.Windows.Forms.TextBox txtSenhaZerarTabelas;
        private System.Windows.Forms.Label lblSenhaZerarTabelas;
    }
}