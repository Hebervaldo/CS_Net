namespace prjColetorDadosCSNet35
{
    public partial class frmMonitorCarregamentoDados
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                mtdAbortarThreadDownloadTabelaApoio(true);
                mtdAbortarThreadDownloadTabelaInventarioBensPrincipal(true);
                mtdAbortarThreadUploadTabelaInventarioBensPrincipal(true);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMonitorCarregamentoDados));
            this.chkForcarUploadDownloadTabela = new System.Windows.Forms.CheckBox();
            this.txtNumeroIdentificacao = new System.Windows.Forms.TextBox();
            this.lblNumeroIdentificacao = new System.Windows.Forms.Label();
            this.cmbPrioridadeDownloadTabelaApoio = new System.Windows.Forms.ComboBox();
            this.tbpConfiguracoes = new System.Windows.Forms.TabPage();
            this.chkGerarPassoAutomatico = new System.Windows.Forms.CheckBox();
            this.lblIP = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.lblRegistroIteracao = new System.Windows.Forms.Label();
            this.lblRegistroIteracaoDownloadTabelaApoio = new System.Windows.Forms.Label();
            this.txtRegistroIteracaoDownloadTabelaApoio = new System.Windows.Forms.TextBox();
            this.lblRegistroIteracaoDownloadTabelaInventarioBens = new System.Windows.Forms.Label();
            this.txtRegistroIteracaoDownloadTabelaInventarioBens = new System.Windows.Forms.TextBox();
            this.lblRegistroIteracaoUploadTabelaInventarioBens = new System.Windows.Forms.Label();
            this.txtRegistroIteracaoUploadTabelaInventarioBens = new System.Windows.Forms.TextBox();
            this.lblEnderecoWebService = new System.Windows.Forms.Label();
            this.txtEnderecoWebService = new System.Windows.Forms.TextBox();
            this.lblPrioridadeDownloadTabelaApoio = new System.Windows.Forms.Label();
            this.chkIteracoesContinuas = new System.Windows.Forms.CheckBox();
            this.cmbPrioridadeUploadTabelaInventarioBens = new System.Windows.Forms.ComboBox();
            this.lblPrioridadeUploadTabelaInventarioBens = new System.Windows.Forms.Label();
            this.prgUploadTabelaInventarioBens = new System.Windows.Forms.ProgressBar();
            this.lblProgressoUploadTabelaInventarioBens = new System.Windows.Forms.Label();
            this.tbpMonitorTabelaApoio = new System.Windows.Forms.TabPage();
            this.chkForcarDesligamento = new System.Windows.Forms.CheckBox();
            this.cmbTabelaApoioApresentacao = new System.Windows.Forms.ComboBox();
            this.chkIgnorarCodigoEspalhamentoTabela = new System.Windows.Forms.CheckBox();
            this.btnAvancarDownloadTabelaApoio = new System.Windows.Forms.Button();
            this.lblProgressoDownloadTabelaApoio = new System.Windows.Forms.Label();
            this.lblTabelaApoio = new System.Windows.Forms.Label();
            this.prgDownloadTabelaApoio = new System.Windows.Forms.ProgressBar();
            this.btnDownloadTabelaApoio = new System.Windows.Forms.Button();
            this.tbc1 = new System.Windows.Forms.TabControl();
            this.tbpMonitorTabelaInventarioBensDownload = new System.Windows.Forms.TabPage();
            this.cmbPrioridadeDownloadTabelaInventarioBens = new System.Windows.Forms.ComboBox();
            this.lblPrioridadeDownloadTabelaInventarioBens = new System.Windows.Forms.Label();
            this.lblProgressoDownloadTabelaInventarioBens = new System.Windows.Forms.Label();
            this.prgDownloadTabelaInventarioBens = new System.Windows.Forms.ProgressBar();
            this.btnDownloadTabelaInventarioBens = new System.Windows.Forms.Button();
            this.lblTabelaInventarioBensDownload = new System.Windows.Forms.Label();
            this.tbpMonitorTabelaInventarioBensUpload = new System.Windows.Forms.TabPage();
            this.lblIntermediarioUploadTabelaInventarioBensDado = new System.Windows.Forms.Label();
            this.lblIntermediarioUploadTabelaInventarioBensCampo = new System.Windows.Forms.Label();
            this.lblIntermediarioUploadTabelaInventarioBens = new System.Windows.Forms.Label();
            this.lblTabelaInventarioBensUpload = new System.Windows.Forms.Label();
            this.prgIntermediarioUploadTabelaInventarioBens = new System.Windows.Forms.ProgressBar();
            this.btnUploadTabelaInventarioBens = new System.Windows.Forms.Button();
            this.tbpTabelaInventarioBensUpload = new System.Windows.Forms.TabPage();
            this.btnMarcarDesmarcarTodos = new System.Windows.Forms.Button();
            this.lblMostrarIteracoesInventarioBensUpload = new System.Windows.Forms.Label();
            this.lblCampoIteracoesInventarioBensUpload = new System.Windows.Forms.Label();
            this.lblMostrarTotalInventarioBensUpload = new System.Windows.Forms.Label();
            this.lblCampoTotalInventarioBensUpload = new System.Windows.Forms.Label();
            this.btnCarregarListaTabelaInventarioBensUpload = new System.Windows.Forms.Button();
            this.cmbTabelaInventarioBensUpload = new System.Windows.Forms.ComboBox();
            this.txtTabelaInventarioBensUpload = new System.Windows.Forms.TextBox();
            this.lsv1 = new System.Windows.Forms.ListView();
            this.tmr1 = new System.Windows.Forms.Timer();
            this.mni1 = new System.Windows.Forms.MenuItem();
            this.mni2 = new System.Windows.Forms.MenuItem();
            this.mnm1 = new System.Windows.Forms.MainMenu();
            this.tbpConfiguracoes.SuspendLayout();
            this.tbpMonitorTabelaApoio.SuspendLayout();
            this.tbc1.SuspendLayout();
            this.tbpMonitorTabelaInventarioBensDownload.SuspendLayout();
            this.tbpMonitorTabelaInventarioBensUpload.SuspendLayout();
            this.tbpTabelaInventarioBensUpload.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkForcarUploadDownloadTabela
            // 
            this.chkForcarUploadDownloadTabela.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.chkForcarUploadDownloadTabela.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkForcarUploadDownloadTabela.Location = new System.Drawing.Point(7, 176);
            this.chkForcarUploadDownloadTabela.Name = "chkForcarUploadDownloadTabela";
            this.chkForcarUploadDownloadTabela.Size = new System.Drawing.Size(226, 18);
            this.chkForcarUploadDownloadTabela.TabIndex = 5;
            this.chkForcarUploadDownloadTabela.Text = "&Forçar Upload/Download da Tabela";
            this.chkForcarUploadDownloadTabela.Click += new System.EventHandler(this.chkForcarUploadDownloadTabela_Click);
            // 
            // txtNumeroIdentificacao
            // 
            this.txtNumeroIdentificacao.Enabled = false;
            this.txtNumeroIdentificacao.ForeColor = System.Drawing.Color.Maroon;
            this.txtNumeroIdentificacao.Location = new System.Drawing.Point(166, 44);
            this.txtNumeroIdentificacao.Name = "txtNumeroIdentificacao";
            this.txtNumeroIdentificacao.Size = new System.Drawing.Size(67, 21);
            this.txtNumeroIdentificacao.TabIndex = 2;
            // 
            // lblNumeroIdentificacao
            // 
            this.lblNumeroIdentificacao.BackColor = System.Drawing.Color.White;
            this.lblNumeroIdentificacao.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblNumeroIdentificacao.ForeColor = System.Drawing.Color.Green;
            this.lblNumeroIdentificacao.Location = new System.Drawing.Point(7, 44);
            this.lblNumeroIdentificacao.Name = "lblNumeroIdentificacao";
            this.lblNumeroIdentificacao.Size = new System.Drawing.Size(153, 18);
            this.lblNumeroIdentificacao.Text = "Nº. de Identificação:";
            this.lblNumeroIdentificacao.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmbPrioridadeDownloadTabelaApoio
            // 
            this.cmbPrioridadeDownloadTabelaApoio.Location = new System.Drawing.Point(88, 124);
            this.cmbPrioridadeDownloadTabelaApoio.Name = "cmbPrioridadeDownloadTabelaApoio";
            this.cmbPrioridadeDownloadTabelaApoio.Size = new System.Drawing.Size(145, 22);
            this.cmbPrioridadeDownloadTabelaApoio.TabIndex = 3;
            this.cmbPrioridadeDownloadTabelaApoio.TextChanged += new System.EventHandler(this.cmbPrioridadeDownloadTabelaApoio_TextChanged);
            // 
            // tbpConfiguracoes
            // 
            this.tbpConfiguracoes.Controls.Add(this.chkGerarPassoAutomatico);
            this.tbpConfiguracoes.Controls.Add(this.lblIP);
            this.tbpConfiguracoes.Controls.Add(this.txtIP);
            this.tbpConfiguracoes.Controls.Add(this.lblNumeroIdentificacao);
            this.tbpConfiguracoes.Controls.Add(this.txtNumeroIdentificacao);
            this.tbpConfiguracoes.Controls.Add(this.lblRegistroIteracao);
            this.tbpConfiguracoes.Controls.Add(this.lblRegistroIteracaoDownloadTabelaApoio);
            this.tbpConfiguracoes.Controls.Add(this.txtRegistroIteracaoDownloadTabelaApoio);
            this.tbpConfiguracoes.Controls.Add(this.lblRegistroIteracaoDownloadTabelaInventarioBens);
            this.tbpConfiguracoes.Controls.Add(this.txtRegistroIteracaoDownloadTabelaInventarioBens);
            this.tbpConfiguracoes.Controls.Add(this.lblRegistroIteracaoUploadTabelaInventarioBens);
            this.tbpConfiguracoes.Controls.Add(this.txtRegistroIteracaoUploadTabelaInventarioBens);
            this.tbpConfiguracoes.Controls.Add(this.lblEnderecoWebService);
            this.tbpConfiguracoes.Controls.Add(this.txtEnderecoWebService);
            this.tbpConfiguracoes.Location = new System.Drawing.Point(0, 0);
            this.tbpConfiguracoes.Name = "tbpConfiguracoes";
            this.tbpConfiguracoes.Size = new System.Drawing.Size(240, 245);
            this.tbpConfiguracoes.Text = "Configurações";
            // 
            // chkGerarPassoAutomatico
            // 
            this.chkGerarPassoAutomatico.Location = new System.Drawing.Point(166, 221);
            this.chkGerarPassoAutomatico.Name = "chkGerarPassoAutomatico";
            this.chkGerarPassoAutomatico.Size = new System.Drawing.Size(67, 20);
            this.chkGerarPassoAutomatico.TabIndex = 7;
            this.chkGerarPassoAutomatico.Text = "GPA";
            this.chkGerarPassoAutomatico.CheckStateChanged += new System.EventHandler(this.chkGerarPassoAutomatico_CheckStateChanged);
            // 
            // lblIP
            // 
            this.lblIP.BackColor = System.Drawing.Color.White;
            this.lblIP.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblIP.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lblIP.Location = new System.Drawing.Point(7, 221);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(43, 18);
            this.lblIP.Text = "IP:";
            this.lblIP.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtIP
            // 
            this.txtIP.Enabled = false;
            this.txtIP.ForeColor = System.Drawing.Color.Maroon;
            this.txtIP.Location = new System.Drawing.Point(56, 221);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(104, 21);
            this.txtIP.TabIndex = 6;
            // 
            // lblRegistroIteracao
            // 
            this.lblRegistroIteracao.BackColor = System.Drawing.Color.White;
            this.lblRegistroIteracao.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblRegistroIteracao.ForeColor = System.Drawing.Color.Navy;
            this.lblRegistroIteracao.Location = new System.Drawing.Point(7, 68);
            this.lblRegistroIteracao.Name = "lblRegistroIteracao";
            this.lblRegistroIteracao.Size = new System.Drawing.Size(226, 18);
            this.lblRegistroIteracao.Text = "Registro por Iteração";
            this.lblRegistroIteracao.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblRegistroIteracaoDownloadTabelaApoio
            // 
            this.lblRegistroIteracaoDownloadTabelaApoio.BackColor = System.Drawing.Color.White;
            this.lblRegistroIteracaoDownloadTabelaApoio.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblRegistroIteracaoDownloadTabelaApoio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblRegistroIteracaoDownloadTabelaApoio.Location = new System.Drawing.Point(7, 86);
            this.lblRegistroIteracaoDownloadTabelaApoio.Name = "lblRegistroIteracaoDownloadTabelaApoio";
            this.lblRegistroIteracaoDownloadTabelaApoio.Size = new System.Drawing.Size(226, 18);
            this.lblRegistroIteracaoDownloadTabelaApoio.Text = "Download - Tabela Apoio";
            this.lblRegistroIteracaoDownloadTabelaApoio.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtRegistroIteracaoDownloadTabelaApoio
            // 
            this.txtRegistroIteracaoDownloadTabelaApoio.Location = new System.Drawing.Point(7, 107);
            this.txtRegistroIteracaoDownloadTabelaApoio.Name = "txtRegistroIteracaoDownloadTabelaApoio";
            this.txtRegistroIteracaoDownloadTabelaApoio.Size = new System.Drawing.Size(226, 21);
            this.txtRegistroIteracaoDownloadTabelaApoio.TabIndex = 3;
            this.txtRegistroIteracaoDownloadTabelaApoio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRegistroIteracaoDownloadTabelaApoio_KeyPress);
            this.txtRegistroIteracaoDownloadTabelaApoio.LostFocus += new System.EventHandler(this.txtRegistroIteracaoDownloadTabelaApoio_LostFocus);
            // 
            // lblRegistroIteracaoDownloadTabelaInventarioBens
            // 
            this.lblRegistroIteracaoDownloadTabelaInventarioBens.BackColor = System.Drawing.Color.White;
            this.lblRegistroIteracaoDownloadTabelaInventarioBens.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblRegistroIteracaoDownloadTabelaInventarioBens.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblRegistroIteracaoDownloadTabelaInventarioBens.Location = new System.Drawing.Point(7, 131);
            this.lblRegistroIteracaoDownloadTabelaInventarioBens.Name = "lblRegistroIteracaoDownloadTabelaInventarioBens";
            this.lblRegistroIteracaoDownloadTabelaInventarioBens.Size = new System.Drawing.Size(226, 18);
            this.lblRegistroIteracaoDownloadTabelaInventarioBens.Text = "Download - Tabela Inventário Bens";
            this.lblRegistroIteracaoDownloadTabelaInventarioBens.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtRegistroIteracaoDownloadTabelaInventarioBens
            // 
            this.txtRegistroIteracaoDownloadTabelaInventarioBens.Location = new System.Drawing.Point(7, 152);
            this.txtRegistroIteracaoDownloadTabelaInventarioBens.Name = "txtRegistroIteracaoDownloadTabelaInventarioBens";
            this.txtRegistroIteracaoDownloadTabelaInventarioBens.Size = new System.Drawing.Size(226, 21);
            this.txtRegistroIteracaoDownloadTabelaInventarioBens.TabIndex = 4;
            this.txtRegistroIteracaoDownloadTabelaInventarioBens.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRegistroIteracaoDownloadTabelaInventarioBens_KeyPress);
            this.txtRegistroIteracaoDownloadTabelaInventarioBens.LostFocus += new System.EventHandler(this.txtRegistroIteracaoDownloadTabelaInventarioBens_LostFocus);
            // 
            // lblRegistroIteracaoUploadTabelaInventarioBens
            // 
            this.lblRegistroIteracaoUploadTabelaInventarioBens.BackColor = System.Drawing.Color.White;
            this.lblRegistroIteracaoUploadTabelaInventarioBens.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblRegistroIteracaoUploadTabelaInventarioBens.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblRegistroIteracaoUploadTabelaInventarioBens.Location = new System.Drawing.Point(7, 176);
            this.lblRegistroIteracaoUploadTabelaInventarioBens.Name = "lblRegistroIteracaoUploadTabelaInventarioBens";
            this.lblRegistroIteracaoUploadTabelaInventarioBens.Size = new System.Drawing.Size(226, 18);
            this.lblRegistroIteracaoUploadTabelaInventarioBens.Text = "Upload - Tabela Inventário Bens";
            this.lblRegistroIteracaoUploadTabelaInventarioBens.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtRegistroIteracaoUploadTabelaInventarioBens
            // 
            this.txtRegistroIteracaoUploadTabelaInventarioBens.Location = new System.Drawing.Point(7, 197);
            this.txtRegistroIteracaoUploadTabelaInventarioBens.Name = "txtRegistroIteracaoUploadTabelaInventarioBens";
            this.txtRegistroIteracaoUploadTabelaInventarioBens.Size = new System.Drawing.Size(226, 21);
            this.txtRegistroIteracaoUploadTabelaInventarioBens.TabIndex = 5;
            this.txtRegistroIteracaoUploadTabelaInventarioBens.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRegistroIteracaoUploadTabelaInventarioBens_KeyPress);
            this.txtRegistroIteracaoUploadTabelaInventarioBens.LostFocus += new System.EventHandler(this.txtRegistroIteracaoUploadTabelaInventarioBens_LostFocus);
            // 
            // lblEnderecoWebService
            // 
            this.lblEnderecoWebService.BackColor = System.Drawing.Color.White;
            this.lblEnderecoWebService.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblEnderecoWebService.ForeColor = System.Drawing.Color.Navy;
            this.lblEnderecoWebService.Location = new System.Drawing.Point(4, 2);
            this.lblEnderecoWebService.Name = "lblEnderecoWebService";
            this.lblEnderecoWebService.Size = new System.Drawing.Size(229, 18);
            this.lblEnderecoWebService.Text = "Endereço do WebService";
            this.lblEnderecoWebService.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtEnderecoWebService
            // 
            this.txtEnderecoWebService.Location = new System.Drawing.Point(7, 20);
            this.txtEnderecoWebService.Name = "txtEnderecoWebService";
            this.txtEnderecoWebService.Size = new System.Drawing.Size(226, 21);
            this.txtEnderecoWebService.TabIndex = 1;
            this.txtEnderecoWebService.LostFocus += new System.EventHandler(this.txtEnderecoWebService_LostFocus);
            // 
            // lblPrioridadeDownloadTabelaApoio
            // 
            this.lblPrioridadeDownloadTabelaApoio.Font = new System.Drawing.Font("Tahoma", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblPrioridadeDownloadTabelaApoio.ForeColor = System.Drawing.Color.Navy;
            this.lblPrioridadeDownloadTabelaApoio.Location = new System.Drawing.Point(7, 128);
            this.lblPrioridadeDownloadTabelaApoio.Name = "lblPrioridadeDownloadTabelaApoio";
            this.lblPrioridadeDownloadTabelaApoio.Size = new System.Drawing.Size(75, 18);
            this.lblPrioridadeDownloadTabelaApoio.Text = "Prioridade:";
            this.lblPrioridadeDownloadTabelaApoio.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chkIteracoesContinuas
            // 
            this.chkIteracoesContinuas.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.chkIteracoesContinuas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkIteracoesContinuas.Location = new System.Drawing.Point(7, 200);
            this.chkIteracoesContinuas.Name = "chkIteracoesContinuas";
            this.chkIteracoesContinuas.Size = new System.Drawing.Size(143, 18);
            this.chkIteracoesContinuas.TabIndex = 6;
            this.chkIteracoesContinuas.Text = "&Iterações Contínuas";
            this.chkIteracoesContinuas.Click += new System.EventHandler(this.chkIteracoesContinuas_Click);
            // 
            // cmbPrioridadeUploadTabelaInventarioBens
            // 
            this.cmbPrioridadeUploadTabelaInventarioBens.Location = new System.Drawing.Point(7, 101);
            this.cmbPrioridadeUploadTabelaInventarioBens.Name = "cmbPrioridadeUploadTabelaInventarioBens";
            this.cmbPrioridadeUploadTabelaInventarioBens.Size = new System.Drawing.Size(226, 22);
            this.cmbPrioridadeUploadTabelaInventarioBens.TabIndex = 2;
            this.cmbPrioridadeUploadTabelaInventarioBens.TextChanged += new System.EventHandler(this.cmbPrioridadeUploadTabelaInventarioBens_TextChanged);
            // 
            // lblPrioridadeUploadTabelaInventarioBens
            // 
            this.lblPrioridadeUploadTabelaInventarioBens.Font = new System.Drawing.Font("Tahoma", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblPrioridadeUploadTabelaInventarioBens.ForeColor = System.Drawing.Color.Navy;
            this.lblPrioridadeUploadTabelaInventarioBens.Location = new System.Drawing.Point(7, 80);
            this.lblPrioridadeUploadTabelaInventarioBens.Name = "lblPrioridadeUploadTabelaInventarioBens";
            this.lblPrioridadeUploadTabelaInventarioBens.Size = new System.Drawing.Size(226, 18);
            this.lblPrioridadeUploadTabelaInventarioBens.Text = "Prioridade:";
            this.lblPrioridadeUploadTabelaInventarioBens.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // prgUploadTabelaInventarioBens
            // 
            this.prgUploadTabelaInventarioBens.Location = new System.Drawing.Point(7, 49);
            this.prgUploadTabelaInventarioBens.Name = "prgUploadTabelaInventarioBens";
            this.prgUploadTabelaInventarioBens.Size = new System.Drawing.Size(226, 10);
            // 
            // lblProgressoUploadTabelaInventarioBens
            // 
            this.lblProgressoUploadTabelaInventarioBens.Font = new System.Drawing.Font("Tahoma", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblProgressoUploadTabelaInventarioBens.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblProgressoUploadTabelaInventarioBens.Location = new System.Drawing.Point(7, 62);
            this.lblProgressoUploadTabelaInventarioBens.Name = "lblProgressoUploadTabelaInventarioBens";
            this.lblProgressoUploadTabelaInventarioBens.Size = new System.Drawing.Size(226, 18);
            this.lblProgressoUploadTabelaInventarioBens.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tbpMonitorTabelaApoio
            // 
            this.tbpMonitorTabelaApoio.Controls.Add(this.chkForcarDesligamento);
            this.tbpMonitorTabelaApoio.Controls.Add(this.cmbTabelaApoioApresentacao);
            this.tbpMonitorTabelaApoio.Controls.Add(this.chkIteracoesContinuas);
            this.tbpMonitorTabelaApoio.Controls.Add(this.chkForcarUploadDownloadTabela);
            this.tbpMonitorTabelaApoio.Controls.Add(this.cmbPrioridadeDownloadTabelaApoio);
            this.tbpMonitorTabelaApoio.Controls.Add(this.lblPrioridadeDownloadTabelaApoio);
            this.tbpMonitorTabelaApoio.Controls.Add(this.chkIgnorarCodigoEspalhamentoTabela);
            this.tbpMonitorTabelaApoio.Controls.Add(this.btnAvancarDownloadTabelaApoio);
            this.tbpMonitorTabelaApoio.Controls.Add(this.lblProgressoDownloadTabelaApoio);
            this.tbpMonitorTabelaApoio.Controls.Add(this.lblTabelaApoio);
            this.tbpMonitorTabelaApoio.Controls.Add(this.prgDownloadTabelaApoio);
            this.tbpMonitorTabelaApoio.Controls.Add(this.btnDownloadTabelaApoio);
            this.tbpMonitorTabelaApoio.Location = new System.Drawing.Point(0, 0);
            this.tbpMonitorTabelaApoio.Name = "tbpMonitorTabelaApoio";
            this.tbpMonitorTabelaApoio.Size = new System.Drawing.Size(240, 245);
            this.tbpMonitorTabelaApoio.Text = "Apoio";
            // 
            // chkForcarDesligamento
            // 
            this.chkForcarDesligamento.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.chkForcarDesligamento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkForcarDesligamento.Location = new System.Drawing.Point(156, 200);
            this.chkForcarDesligamento.Name = "chkForcarDesligamento";
            this.chkForcarDesligamento.Size = new System.Drawing.Size(77, 20);
            this.chkForcarDesligamento.TabIndex = 11;
            this.chkForcarDesligamento.Text = "Desligar";
            this.chkForcarDesligamento.Click += new System.EventHandler(this.chkForcarDesligamento_Click);
            // 
            // cmbTabelaApoioApresentacao
            // 
            this.cmbTabelaApoioApresentacao.Location = new System.Drawing.Point(7, 38);
            this.cmbTabelaApoioApresentacao.Name = "cmbTabelaApoioApresentacao";
            this.cmbTabelaApoioApresentacao.Size = new System.Drawing.Size(226, 22);
            this.cmbTabelaApoioApresentacao.TabIndex = 1;
            this.cmbTabelaApoioApresentacao.LostFocus += new System.EventHandler(this.cmbTabelaApoioApresentacao_LostFocus);
            this.cmbTabelaApoioApresentacao.SelectedIndexChanged += new System.EventHandler(this.cmbTabelaApoioApresentacao_SelectedIndexChanged);
            this.cmbTabelaApoioApresentacao.GotFocus += new System.EventHandler(this.cmbTabelaApoioApresentacao_GotFocus);
            // 
            // chkIgnorarCodigoEspalhamentoTabela
            // 
            this.chkIgnorarCodigoEspalhamentoTabela.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.chkIgnorarCodigoEspalhamentoTabela.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkIgnorarCodigoEspalhamentoTabela.Location = new System.Drawing.Point(7, 152);
            this.chkIgnorarCodigoEspalhamentoTabela.Name = "chkIgnorarCodigoEspalhamentoTabela";
            this.chkIgnorarCodigoEspalhamentoTabela.Size = new System.Drawing.Size(226, 18);
            this.chkIgnorarCodigoEspalhamentoTabela.TabIndex = 4;
            this.chkIgnorarCodigoEspalhamentoTabela.Text = "&Ignorar Hash Code da Tabela";
            this.chkIgnorarCodigoEspalhamentoTabela.Click += new System.EventHandler(this.chkIgnorarCodigoEspalhamentoTabela_Click);
            // 
            // btnAvancarDownloadTabelaApoio
            // 
            this.btnAvancarDownloadTabelaApoio.BackColor = System.Drawing.Color.White;
            this.btnAvancarDownloadTabelaApoio.ForeColor = System.Drawing.Color.Navy;
            this.btnAvancarDownloadTabelaApoio.Location = new System.Drawing.Point(7, 224);
            this.btnAvancarDownloadTabelaApoio.Name = "btnAvancarDownloadTabelaApoio";
            this.btnAvancarDownloadTabelaApoio.Size = new System.Drawing.Size(226, 18);
            this.btnAvancarDownloadTabelaApoio.TabIndex = 7;
            this.btnAvancarDownloadTabelaApoio.Text = "&Avançar Download da Tabela";
            this.btnAvancarDownloadTabelaApoio.Click += new System.EventHandler(this.btnAvancarDownloadTabelaApoio_Click);
            // 
            // lblProgressoDownloadTabelaApoio
            // 
            this.lblProgressoDownloadTabelaApoio.Font = new System.Drawing.Font("Tahoma", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblProgressoDownloadTabelaApoio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblProgressoDownloadTabelaApoio.Location = new System.Drawing.Point(7, 103);
            this.lblProgressoDownloadTabelaApoio.Name = "lblProgressoDownloadTabelaApoio";
            this.lblProgressoDownloadTabelaApoio.Size = new System.Drawing.Size(226, 18);
            this.lblProgressoDownloadTabelaApoio.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTabelaApoio
            // 
            this.lblTabelaApoio.BackColor = System.Drawing.Color.White;
            this.lblTabelaApoio.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblTabelaApoio.ForeColor = System.Drawing.Color.Navy;
            this.lblTabelaApoio.Location = new System.Drawing.Point(7, 4);
            this.lblTabelaApoio.Name = "lblTabelaApoio";
            this.lblTabelaApoio.Size = new System.Drawing.Size(226, 18);
            this.lblTabelaApoio.Text = "Tabelas de Apoio";
            this.lblTabelaApoio.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // prgDownloadTabelaApoio
            // 
            this.prgDownloadTabelaApoio.Location = new System.Drawing.Point(7, 90);
            this.prgDownloadTabelaApoio.Name = "prgDownloadTabelaApoio";
            this.prgDownloadTabelaApoio.Size = new System.Drawing.Size(226, 10);
            // 
            // btnDownloadTabelaApoio
            // 
            this.btnDownloadTabelaApoio.BackColor = System.Drawing.Color.White;
            this.btnDownloadTabelaApoio.ForeColor = System.Drawing.Color.Maroon;
            this.btnDownloadTabelaApoio.Location = new System.Drawing.Point(7, 66);
            this.btnDownloadTabelaApoio.Name = "btnDownloadTabelaApoio";
            this.btnDownloadTabelaApoio.Size = new System.Drawing.Size(226, 18);
            this.btnDownloadTabelaApoio.TabIndex = 2;
            this.btnDownloadTabelaApoio.Text = "&Download";
            this.btnDownloadTabelaApoio.Click += new System.EventHandler(this.btnDownloadTabelaApoio_Click);
            // 
            // tbc1
            // 
            this.tbc1.Controls.Add(this.tbpConfiguracoes);
            this.tbc1.Controls.Add(this.tbpMonitorTabelaInventarioBensDownload);
            this.tbc1.Controls.Add(this.tbpMonitorTabelaInventarioBensUpload);
            this.tbc1.Controls.Add(this.tbpTabelaInventarioBensUpload);
            this.tbc1.Controls.Add(this.tbpMonitorTabelaApoio);
            this.tbc1.Location = new System.Drawing.Point(0, 0);
            this.tbc1.Name = "tbc1";
            this.tbc1.SelectedIndex = 0;
            this.tbc1.Size = new System.Drawing.Size(240, 268);
            this.tbc1.TabIndex = 0;
            this.tbc1.SelectedIndexChanged += new System.EventHandler(this.tbc1_SelectedIndexChanged);
            // 
            // tbpMonitorTabelaInventarioBensDownload
            // 
            this.tbpMonitorTabelaInventarioBensDownload.Controls.Add(this.cmbPrioridadeDownloadTabelaInventarioBens);
            this.tbpMonitorTabelaInventarioBensDownload.Controls.Add(this.lblPrioridadeDownloadTabelaInventarioBens);
            this.tbpMonitorTabelaInventarioBensDownload.Controls.Add(this.lblProgressoDownloadTabelaInventarioBens);
            this.tbpMonitorTabelaInventarioBensDownload.Controls.Add(this.prgDownloadTabelaInventarioBens);
            this.tbpMonitorTabelaInventarioBensDownload.Controls.Add(this.btnDownloadTabelaInventarioBens);
            this.tbpMonitorTabelaInventarioBensDownload.Controls.Add(this.lblTabelaInventarioBensDownload);
            this.tbpMonitorTabelaInventarioBensDownload.Location = new System.Drawing.Point(0, 0);
            this.tbpMonitorTabelaInventarioBensDownload.Name = "tbpMonitorTabelaInventarioBensDownload";
            this.tbpMonitorTabelaInventarioBensDownload.Size = new System.Drawing.Size(240, 245);
            this.tbpMonitorTabelaInventarioBensDownload.Text = "Inventário - Download";
            // 
            // cmbPrioridadeDownloadTabelaInventarioBens
            // 
            this.cmbPrioridadeDownloadTabelaInventarioBens.Location = new System.Drawing.Point(7, 101);
            this.cmbPrioridadeDownloadTabelaInventarioBens.Name = "cmbPrioridadeDownloadTabelaInventarioBens";
            this.cmbPrioridadeDownloadTabelaInventarioBens.Size = new System.Drawing.Size(226, 22);
            this.cmbPrioridadeDownloadTabelaInventarioBens.TabIndex = 2;
            this.cmbPrioridadeDownloadTabelaInventarioBens.TextChanged += new System.EventHandler(this.cmbPrioridadeDownloadTabelaInventarioBens_TextChanged);
            // 
            // lblPrioridadeDownloadTabelaInventarioBens
            // 
            this.lblPrioridadeDownloadTabelaInventarioBens.Font = new System.Drawing.Font("Tahoma", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblPrioridadeDownloadTabelaInventarioBens.ForeColor = System.Drawing.Color.Navy;
            this.lblPrioridadeDownloadTabelaInventarioBens.Location = new System.Drawing.Point(7, 80);
            this.lblPrioridadeDownloadTabelaInventarioBens.Name = "lblPrioridadeDownloadTabelaInventarioBens";
            this.lblPrioridadeDownloadTabelaInventarioBens.Size = new System.Drawing.Size(226, 18);
            this.lblPrioridadeDownloadTabelaInventarioBens.Text = "Prioridade:";
            this.lblPrioridadeDownloadTabelaInventarioBens.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblProgressoDownloadTabelaInventarioBens
            // 
            this.lblProgressoDownloadTabelaInventarioBens.Font = new System.Drawing.Font("Tahoma", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblProgressoDownloadTabelaInventarioBens.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblProgressoDownloadTabelaInventarioBens.Location = new System.Drawing.Point(7, 62);
            this.lblProgressoDownloadTabelaInventarioBens.Name = "lblProgressoDownloadTabelaInventarioBens";
            this.lblProgressoDownloadTabelaInventarioBens.Size = new System.Drawing.Size(226, 18);
            this.lblProgressoDownloadTabelaInventarioBens.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // prgDownloadTabelaInventarioBens
            // 
            this.prgDownloadTabelaInventarioBens.Location = new System.Drawing.Point(7, 49);
            this.prgDownloadTabelaInventarioBens.Name = "prgDownloadTabelaInventarioBens";
            this.prgDownloadTabelaInventarioBens.Size = new System.Drawing.Size(226, 10);
            // 
            // btnDownloadTabelaInventarioBens
            // 
            this.btnDownloadTabelaInventarioBens.BackColor = System.Drawing.Color.White;
            this.btnDownloadTabelaInventarioBens.ForeColor = System.Drawing.Color.Maroon;
            this.btnDownloadTabelaInventarioBens.Location = new System.Drawing.Point(7, 25);
            this.btnDownloadTabelaInventarioBens.Name = "btnDownloadTabelaInventarioBens";
            this.btnDownloadTabelaInventarioBens.Size = new System.Drawing.Size(226, 18);
            this.btnDownloadTabelaInventarioBens.TabIndex = 1;
            this.btnDownloadTabelaInventarioBens.Text = "&Download";
            this.btnDownloadTabelaInventarioBens.Click += new System.EventHandler(this.btnDownloadTabelaInventarioBens_Click);
            // 
            // lblTabelaInventarioBensDownload
            // 
            this.lblTabelaInventarioBensDownload.BackColor = System.Drawing.Color.White;
            this.lblTabelaInventarioBensDownload.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblTabelaInventarioBensDownload.ForeColor = System.Drawing.Color.Navy;
            this.lblTabelaInventarioBensDownload.Location = new System.Drawing.Point(7, 4);
            this.lblTabelaInventarioBensDownload.Name = "lblTabelaInventarioBensDownload";
            this.lblTabelaInventarioBensDownload.Size = new System.Drawing.Size(226, 18);
            this.lblTabelaInventarioBensDownload.Text = "Tabela de Inventario de Bens";
            this.lblTabelaInventarioBensDownload.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tbpMonitorTabelaInventarioBensUpload
            // 
            this.tbpMonitorTabelaInventarioBensUpload.Controls.Add(this.lblIntermediarioUploadTabelaInventarioBensDado);
            this.tbpMonitorTabelaInventarioBensUpload.Controls.Add(this.lblIntermediarioUploadTabelaInventarioBensCampo);
            this.tbpMonitorTabelaInventarioBensUpload.Controls.Add(this.lblIntermediarioUploadTabelaInventarioBens);
            this.tbpMonitorTabelaInventarioBensUpload.Controls.Add(this.lblTabelaInventarioBensUpload);
            this.tbpMonitorTabelaInventarioBensUpload.Controls.Add(this.prgIntermediarioUploadTabelaInventarioBens);
            this.tbpMonitorTabelaInventarioBensUpload.Controls.Add(this.cmbPrioridadeUploadTabelaInventarioBens);
            this.tbpMonitorTabelaInventarioBensUpload.Controls.Add(this.lblPrioridadeUploadTabelaInventarioBens);
            this.tbpMonitorTabelaInventarioBensUpload.Controls.Add(this.lblProgressoUploadTabelaInventarioBens);
            this.tbpMonitorTabelaInventarioBensUpload.Controls.Add(this.prgUploadTabelaInventarioBens);
            this.tbpMonitorTabelaInventarioBensUpload.Controls.Add(this.btnUploadTabelaInventarioBens);
            this.tbpMonitorTabelaInventarioBensUpload.Location = new System.Drawing.Point(0, 0);
            this.tbpMonitorTabelaInventarioBensUpload.Name = "tbpMonitorTabelaInventarioBensUpload";
            this.tbpMonitorTabelaInventarioBensUpload.Size = new System.Drawing.Size(240, 245);
            this.tbpMonitorTabelaInventarioBensUpload.Text = "Inventário - Upload";
            // 
            // lblIntermediarioUploadTabelaInventarioBensDado
            // 
            this.lblIntermediarioUploadTabelaInventarioBensDado.Font = new System.Drawing.Font("Tahoma", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblIntermediarioUploadTabelaInventarioBensDado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblIntermediarioUploadTabelaInventarioBensDado.Location = new System.Drawing.Point(7, 194);
            this.lblIntermediarioUploadTabelaInventarioBensDado.Name = "lblIntermediarioUploadTabelaInventarioBensDado";
            this.lblIntermediarioUploadTabelaInventarioBensDado.Size = new System.Drawing.Size(226, 40);
            this.lblIntermediarioUploadTabelaInventarioBensDado.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblIntermediarioUploadTabelaInventarioBensCampo
            // 
            this.lblIntermediarioUploadTabelaInventarioBensCampo.Font = new System.Drawing.Font("Tahoma", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblIntermediarioUploadTabelaInventarioBensCampo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblIntermediarioUploadTabelaInventarioBensCampo.Location = new System.Drawing.Point(7, 176);
            this.lblIntermediarioUploadTabelaInventarioBensCampo.Name = "lblIntermediarioUploadTabelaInventarioBensCampo";
            this.lblIntermediarioUploadTabelaInventarioBensCampo.Size = new System.Drawing.Size(226, 18);
            this.lblIntermediarioUploadTabelaInventarioBensCampo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblIntermediarioUploadTabelaInventarioBens
            // 
            this.lblIntermediarioUploadTabelaInventarioBens.Font = new System.Drawing.Font("Tahoma", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblIntermediarioUploadTabelaInventarioBens.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblIntermediarioUploadTabelaInventarioBens.Location = new System.Drawing.Point(7, 136);
            this.lblIntermediarioUploadTabelaInventarioBens.Name = "lblIntermediarioUploadTabelaInventarioBens";
            this.lblIntermediarioUploadTabelaInventarioBens.Size = new System.Drawing.Size(226, 40);
            this.lblIntermediarioUploadTabelaInventarioBens.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTabelaInventarioBensUpload
            // 
            this.lblTabelaInventarioBensUpload.BackColor = System.Drawing.Color.White;
            this.lblTabelaInventarioBensUpload.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblTabelaInventarioBensUpload.ForeColor = System.Drawing.Color.Navy;
            this.lblTabelaInventarioBensUpload.Location = new System.Drawing.Point(7, 4);
            this.lblTabelaInventarioBensUpload.Name = "lblTabelaInventarioBensUpload";
            this.lblTabelaInventarioBensUpload.Size = new System.Drawing.Size(226, 18);
            this.lblTabelaInventarioBensUpload.Text = "Tabela de Inventario de Bens";
            this.lblTabelaInventarioBensUpload.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // prgIntermediarioUploadTabelaInventarioBens
            // 
            this.prgIntermediarioUploadTabelaInventarioBens.Location = new System.Drawing.Point(7, 128);
            this.prgIntermediarioUploadTabelaInventarioBens.Name = "prgIntermediarioUploadTabelaInventarioBens";
            this.prgIntermediarioUploadTabelaInventarioBens.Size = new System.Drawing.Size(226, 5);
            // 
            // btnUploadTabelaInventarioBens
            // 
            this.btnUploadTabelaInventarioBens.BackColor = System.Drawing.Color.White;
            this.btnUploadTabelaInventarioBens.ForeColor = System.Drawing.Color.Maroon;
            this.btnUploadTabelaInventarioBens.Location = new System.Drawing.Point(7, 25);
            this.btnUploadTabelaInventarioBens.Name = "btnUploadTabelaInventarioBens";
            this.btnUploadTabelaInventarioBens.Size = new System.Drawing.Size(226, 18);
            this.btnUploadTabelaInventarioBens.TabIndex = 1;
            this.btnUploadTabelaInventarioBens.Text = "&Upload";
            this.btnUploadTabelaInventarioBens.Click += new System.EventHandler(this.btnUploadTabelaInventarioBensPrincipal_Click);
            // 
            // tbpTabelaInventarioBensUpload
            // 
            this.tbpTabelaInventarioBensUpload.Controls.Add(this.btnMarcarDesmarcarTodos);
            this.tbpTabelaInventarioBensUpload.Controls.Add(this.lblMostrarIteracoesInventarioBensUpload);
            this.tbpTabelaInventarioBensUpload.Controls.Add(this.lblCampoIteracoesInventarioBensUpload);
            this.tbpTabelaInventarioBensUpload.Controls.Add(this.lblMostrarTotalInventarioBensUpload);
            this.tbpTabelaInventarioBensUpload.Controls.Add(this.lblCampoTotalInventarioBensUpload);
            this.tbpTabelaInventarioBensUpload.Controls.Add(this.btnCarregarListaTabelaInventarioBensUpload);
            this.tbpTabelaInventarioBensUpload.Controls.Add(this.cmbTabelaInventarioBensUpload);
            this.tbpTabelaInventarioBensUpload.Controls.Add(this.txtTabelaInventarioBensUpload);
            this.tbpTabelaInventarioBensUpload.Controls.Add(this.lsv1);
            this.tbpTabelaInventarioBensUpload.Location = new System.Drawing.Point(0, 0);
            this.tbpTabelaInventarioBensUpload.Name = "tbpTabelaInventarioBensUpload";
            this.tbpTabelaInventarioBensUpload.Size = new System.Drawing.Size(240, 245);
            this.tbpTabelaInventarioBensUpload.Text = "Tabela Inventário - Upload";
            // 
            // btnMarcarDesmarcarTodos
            // 
            this.btnMarcarDesmarcarTodos.BackColor = System.Drawing.Color.White;
            this.btnMarcarDesmarcarTodos.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnMarcarDesmarcarTodos.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnMarcarDesmarcarTodos.Location = new System.Drawing.Point(103, 224);
            this.btnMarcarDesmarcarTodos.Name = "btnMarcarDesmarcarTodos";
            this.btnMarcarDesmarcarTodos.Size = new System.Drawing.Size(129, 18);
            this.btnMarcarDesmarcarTodos.TabIndex = 5;
            this.btnMarcarDesmarcarTodos.Text = "&Marcar/Desm. Todos";
            this.btnMarcarDesmarcarTodos.Click += new System.EventHandler(this.btnMarcarDesmarcarTodos_Click);
            // 
            // lblMostrarIteracoesInventarioBensUpload
            // 
            this.lblMostrarIteracoesInventarioBensUpload.Location = new System.Drawing.Point(122, 176);
            this.lblMostrarIteracoesInventarioBensUpload.Name = "lblMostrarIteracoesInventarioBensUpload";
            this.lblMostrarIteracoesInventarioBensUpload.Size = new System.Drawing.Size(111, 18);
            // 
            // lblCampoIteracoesInventarioBensUpload
            // 
            this.lblCampoIteracoesInventarioBensUpload.Location = new System.Drawing.Point(7, 176);
            this.lblCampoIteracoesInventarioBensUpload.Name = "lblCampoIteracoesInventarioBensUpload";
            this.lblCampoIteracoesInventarioBensUpload.Size = new System.Drawing.Size(110, 18);
            this.lblCampoIteracoesInventarioBensUpload.Text = "Iterações:";
            // 
            // lblMostrarTotalInventarioBensUpload
            // 
            this.lblMostrarTotalInventarioBensUpload.Location = new System.Drawing.Point(122, 158);
            this.lblMostrarTotalInventarioBensUpload.Name = "lblMostrarTotalInventarioBensUpload";
            this.lblMostrarTotalInventarioBensUpload.Size = new System.Drawing.Size(111, 18);
            // 
            // lblCampoTotalInventarioBensUpload
            // 
            this.lblCampoTotalInventarioBensUpload.Location = new System.Drawing.Point(7, 158);
            this.lblCampoTotalInventarioBensUpload.Name = "lblCampoTotalInventarioBensUpload";
            this.lblCampoTotalInventarioBensUpload.Size = new System.Drawing.Size(110, 18);
            this.lblCampoTotalInventarioBensUpload.Text = "Total de Bens:";
            // 
            // btnCarregarListaTabelaInventarioBensUpload
            // 
            this.btnCarregarListaTabelaInventarioBensUpload.BackColor = System.Drawing.Color.White;
            this.btnCarregarListaTabelaInventarioBensUpload.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnCarregarListaTabelaInventarioBensUpload.ForeColor = System.Drawing.Color.Green;
            this.btnCarregarListaTabelaInventarioBensUpload.Location = new System.Drawing.Point(7, 224);
            this.btnCarregarListaTabelaInventarioBensUpload.Name = "btnCarregarListaTabelaInventarioBensUpload";
            this.btnCarregarListaTabelaInventarioBensUpload.Size = new System.Drawing.Size(90, 18);
            this.btnCarregarListaTabelaInventarioBensUpload.TabIndex = 4;
            this.btnCarregarListaTabelaInventarioBensUpload.Text = "&Carregar Lista";
            this.btnCarregarListaTabelaInventarioBensUpload.Click += new System.EventHandler(this.btnCarregarListaTabelaInventarioBensUpload_Click);
            // 
            // cmbTabelaInventarioBensUpload
            // 
            this.cmbTabelaInventarioBensUpload.Location = new System.Drawing.Point(7, 197);
            this.cmbTabelaInventarioBensUpload.Name = "cmbTabelaInventarioBensUpload";
            this.cmbTabelaInventarioBensUpload.Size = new System.Drawing.Size(110, 22);
            this.cmbTabelaInventarioBensUpload.TabIndex = 2;
            this.cmbTabelaInventarioBensUpload.GotFocus += new System.EventHandler(this.cmbTabelaInventarioBensUpload_GotFocus);
            // 
            // txtTabelaInventarioBensUpload
            // 
            this.txtTabelaInventarioBensUpload.Location = new System.Drawing.Point(122, 197);
            this.txtTabelaInventarioBensUpload.Name = "txtTabelaInventarioBensUpload";
            this.txtTabelaInventarioBensUpload.Size = new System.Drawing.Size(111, 21);
            this.txtTabelaInventarioBensUpload.TabIndex = 3;
            this.txtTabelaInventarioBensUpload.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTabelaInventarioBensUpload_KeyPress);
            // 
            // lsv1
            // 
            this.lsv1.CheckBoxes = true;
            this.lsv1.Location = new System.Drawing.Point(7, 7);
            this.lsv1.Name = "lsv1";
            this.lsv1.Size = new System.Drawing.Size(226, 148);
            this.lsv1.TabIndex = 1;
            this.lsv1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lsv1_ColumnClick);
            // 
            // tmr1
            // 
            this.tmr1.Enabled = true;
            this.tmr1.Interval = 1000;
            this.tmr1.Tick += new System.EventHandler(this.tmr1_Tick);
            // 
            // mni1
            // 
            this.mni1.Text = "Form. Padrão";
            this.mni1.Click += new System.EventHandler(this.mni1_Click);
            // 
            // mni2
            // 
            this.mni2.Text = "";
            this.mni2.Click += new System.EventHandler(this.mni2_Click);
            // 
            // mnm1
            // 
            this.mnm1.MenuItems.Add(this.mni1);
            this.mnm1.MenuItems.Add(this.mni2);
            // 
            // frmMonitorCarregamentoDados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.tbc1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mnm1;
            this.Name = "frmMonitorCarregamentoDados";
            this.Text = "Monitor de Carregamento de Dados";
            this.Load += new System.EventHandler(this.frmMonitorCarregamentoDados_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmMonitorCarregamentoDados_Closing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMonitorCarregamentoDados_KeyDown);
            this.tbpConfiguracoes.ResumeLayout(false);
            this.tbpMonitorTabelaApoio.ResumeLayout(false);
            this.tbc1.ResumeLayout(false);
            this.tbpMonitorTabelaInventarioBensDownload.ResumeLayout(false);
            this.tbpMonitorTabelaInventarioBensUpload.ResumeLayout(false);
            this.tbpTabelaInventarioBensUpload.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkForcarUploadDownloadTabela;
        private System.Windows.Forms.TextBox txtNumeroIdentificacao;
        private System.Windows.Forms.Label lblNumeroIdentificacao;
        private System.Windows.Forms.ComboBox cmbPrioridadeDownloadTabelaApoio;
        private System.Windows.Forms.TabPage tbpConfiguracoes;
        private System.Windows.Forms.Label lblRegistroIteracao;
        private System.Windows.Forms.Label lblRegistroIteracaoDownloadTabelaApoio;
        private System.Windows.Forms.TextBox txtRegistroIteracaoDownloadTabelaApoio;
        private System.Windows.Forms.Label lblRegistroIteracaoDownloadTabelaInventarioBens;
        private System.Windows.Forms.TextBox txtRegistroIteracaoDownloadTabelaInventarioBens;
        private System.Windows.Forms.Label lblRegistroIteracaoUploadTabelaInventarioBens;
        private System.Windows.Forms.TextBox txtRegistroIteracaoUploadTabelaInventarioBens;
        private System.Windows.Forms.Label lblEnderecoWebService;
        private System.Windows.Forms.TextBox txtEnderecoWebService;
        private System.Windows.Forms.Label lblPrioridadeDownloadTabelaApoio;
        private System.Windows.Forms.CheckBox chkIteracoesContinuas;
        private System.Windows.Forms.ComboBox cmbPrioridadeUploadTabelaInventarioBens;
        private System.Windows.Forms.Label lblPrioridadeUploadTabelaInventarioBens;
        private System.Windows.Forms.ProgressBar prgUploadTabelaInventarioBens;
        private System.Windows.Forms.Label lblProgressoUploadTabelaInventarioBens;
        private System.Windows.Forms.TabPage tbpMonitorTabelaApoio;
        private System.Windows.Forms.CheckBox chkIgnorarCodigoEspalhamentoTabela;
        private System.Windows.Forms.Button btnAvancarDownloadTabelaApoio;
        private System.Windows.Forms.Label lblProgressoDownloadTabelaApoio;
        private System.Windows.Forms.Label lblTabelaApoio;
        private System.Windows.Forms.ProgressBar prgDownloadTabelaApoio;
        private System.Windows.Forms.Button btnDownloadTabelaApoio;
        private System.Windows.Forms.TabControl tbc1;
        private System.Windows.Forms.TabPage tbpMonitorTabelaInventarioBensUpload;
        private System.Windows.Forms.Button btnUploadTabelaInventarioBens;
        private System.Windows.Forms.Timer tmr1;
        private System.Windows.Forms.TabPage tbpTabelaInventarioBensUpload;
        public System.Windows.Forms.ComboBox cmbTabelaInventarioBensUpload;
        public System.Windows.Forms.TextBox txtTabelaInventarioBensUpload;
        private System.Windows.Forms.ListView lsv1;
        private System.Windows.Forms.Button btnCarregarListaTabelaInventarioBensUpload;
        private System.Windows.Forms.ProgressBar prgIntermediarioUploadTabelaInventarioBens;
        private System.Windows.Forms.TabPage tbpMonitorTabelaInventarioBensDownload;
        private System.Windows.Forms.Label lblTabelaInventarioBensUpload;
        private System.Windows.Forms.ComboBox cmbPrioridadeDownloadTabelaInventarioBens;
        private System.Windows.Forms.Label lblPrioridadeDownloadTabelaInventarioBens;
        private System.Windows.Forms.Label lblProgressoDownloadTabelaInventarioBens;
        private System.Windows.Forms.ProgressBar prgDownloadTabelaInventarioBens;
        private System.Windows.Forms.Button btnDownloadTabelaInventarioBens;
        private System.Windows.Forms.Label lblTabelaInventarioBensDownload;
        private System.Windows.Forms.Label lblIntermediarioUploadTabelaInventarioBens;
        private System.Windows.Forms.Label lblMostrarTotalInventarioBensUpload;
        private System.Windows.Forms.Label lblCampoTotalInventarioBensUpload;
        private System.Windows.Forms.Label lblMostrarIteracoesInventarioBensUpload;
        private System.Windows.Forms.Label lblCampoIteracoesInventarioBensUpload;
        private System.Windows.Forms.MenuItem mni1;
        private System.Windows.Forms.MenuItem mni2;
        private System.Windows.Forms.MainMenu mnm1;
        private System.Windows.Forms.ComboBox cmbTabelaApoioApresentacao;
        private System.Windows.Forms.Label lblIntermediarioUploadTabelaInventarioBensCampo;
        private System.Windows.Forms.Label lblIntermediarioUploadTabelaInventarioBensDado;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Button btnMarcarDesmarcarTodos;
        private System.Windows.Forms.CheckBox chkGerarPassoAutomatico;
        private System.Windows.Forms.CheckBox chkForcarDesligamento;

    }
}