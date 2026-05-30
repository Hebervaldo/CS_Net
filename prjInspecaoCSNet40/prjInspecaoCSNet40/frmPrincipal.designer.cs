namespace prjInspecaoCSNet40
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mmnPrincipal;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        // Flag que indica que não queremos o botão fechar.
        private const int CP_NOCLOSE_BUTTON = 0x200;

        protected override System.Windows.Forms.CreateParams CreateParams
        {
            get
            {
                // Obtém as flags atuais
                System.Windows.Forms.CreateParams parametros = base.CreateParams;
                // Adiciona a flag que indica que o "X" não deve ser mostrado
                // parametros.ClassStyle = parametros.ClassStyle | CP_NOCLOSE_BUTTON;
                // Retorna as flags modificadas
                return parametros;
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.mmnPrincipal = new System.Windows.Forms.MainMenu(this.components);
            this.mni1 = new System.Windows.Forms.MenuItem();
            this.mni2 = new System.Windows.Forms.MenuItem();
            this.tbpControlePrincipal = new System.Windows.Forms.TabControl();
            this.tbpPrincipal = new System.Windows.Forms.TabPage();
            this.pctPrincipal = new System.Windows.Forms.PictureBox();
            this.txtColetor = new System.Windows.Forms.TextBox();
            this.lblColetor = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.dtpDataInspecao = new System.Windows.Forms.DateTimePicker();
            this.lblInspetor = new System.Windows.Forms.Label();
            this.txtInspetor = new System.Windows.Forms.TextBox();
            this.tbpInspecao = new System.Windows.Forms.TabPage();
            this.btnConsultarInspecao = new System.Windows.Forms.Button();
            this.cmbIdentificacao = new System.Windows.Forms.ComboBox();
            this.cmbDataInspecao = new System.Windows.Forms.ComboBox();
            this.lsvInspecao = new System.Windows.Forms.ListView();
            this.tbpServicos = new System.Windows.Forms.TabPage();
            this.btnPreencher_Valor_Aleatorio = new System.Windows.Forms.Button();
            this.btnPreencher_Zero_Um_Dois = new System.Windows.Forms.Button();
            this.btnPreencher_Zero_Um = new System.Windows.Forms.Button();
            this.btnPreencher_Dois = new System.Windows.Forms.Button();
            this.btnPreencher_Um = new System.Windows.Forms.Button();
            this.cmbEndereco = new System.Windows.Forms.ComboBox();
            this.btnZerar = new System.Windows.Forms.Button();
            this.lblEndereco = new System.Windows.Forms.Label();
            this.btnDeletarInspecao = new System.Windows.Forms.Button();
            this.btnAlterarInspecao = new System.Windows.Forms.Button();
            this.btnIncluirInspecao = new System.Windows.Forms.Button();
            this.cmbServicos = new System.Windows.Forms.ComboBox();
            this.btnAtribuirNotaServicos = new System.Windows.Forms.Button();
            this.txtNotaServicos = new System.Windows.Forms.TextBox();
            this.lsvServicos = new System.Windows.Forms.ListView();
            this.tbpEstatistica = new System.Windows.Forms.TabPage();
            this.cmbOpcaoEstatistica = new System.Windows.Forms.ComboBox();
            this.btnCalcularEstatistica = new System.Windows.Forms.Button();
            this.lsvEstatistica = new System.Windows.Forms.ListView();
            this.tbpFerramentas = new System.Windows.Forms.TabPage();
            this.btnCompactarRepararBancoDados = new System.Windows.Forms.Button();
            this.btnCriarTabelas = new System.Windows.Forms.Button();
            this.btnDeletarTabelas = new System.Windows.Forms.Button();
            this.btnCriarBancoDados = new System.Windows.Forms.Button();
            this.lblSenhaBancoDados = new System.Windows.Forms.Label();
            this.txtSenhaBancoDados = new System.Windows.Forms.TextBox();
            this.btnTestarEnderecoBancoDados = new System.Windows.Forms.Button();
            this.btnEnderecoBancoDadosPadrao = new System.Windows.Forms.Button();
            this.btnAbrirArquivoDialogo = new System.Windows.Forms.Button();
            this.btnEnderecoBancoDadosFlashDisk = new System.Windows.Forms.Button();
            this.lblEnderecoBancoDados = new System.Windows.Forms.Label();
            this.txtEnderecoBancoDados = new System.Windows.Forms.TextBox();
            this.btnEnderecoBancoDadosStorageCard = new System.Windows.Forms.Button();
            this.lblEnderecoWebService = new System.Windows.Forms.Label();
            this.txtEnderecoWebService = new System.Windows.Forms.TextBox();
            this.pctConfiguracoes = new System.Windows.Forms.PictureBox();
            this.tbpUtilitarios = new System.Windows.Forms.TabPage();
            this.btnWebServiceDownload = new System.Windows.Forms.Button();
            this.chbForcarUpload = new System.Windows.Forms.CheckBox();
            this.btnWebServiceUpload = new System.Windows.Forms.Button();
            this.btnSairAplicativo = new System.Windows.Forms.Button();
            this.btnSincronizarHorarioServidor = new System.Windows.Forms.Button();
            this.txtLegenda = new System.Windows.Forms.TextBox();
            this.ofd1 = new System.Windows.Forms.OpenFileDialog();
            this.tbpControlePrincipal.SuspendLayout();
            this.tbpPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctPrincipal)).BeginInit();
            this.tbpInspecao.SuspendLayout();
            this.tbpServicos.SuspendLayout();
            this.tbpEstatistica.SuspendLayout();
            this.tbpFerramentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctConfiguracoes)).BeginInit();
            this.tbpUtilitarios.SuspendLayout();
            this.SuspendLayout();
            // 
            // mmnPrincipal
            // 
            this.mmnPrincipal.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mni1,
            this.mni2});
            // 
            // mni1
            // 
            this.mni1.Index = 0;
            this.mni1.Text = "";
            this.mni1.Click += new System.EventHandler(this.mni1_Click);
            // 
            // mni2
            // 
            this.mni2.Index = 1;
            this.mni2.Text = "";
            this.mni2.Click += new System.EventHandler(this.mni2_Click);
            // 
            // tbpControlePrincipal
            // 
            this.tbpControlePrincipal.Controls.Add(this.tbpPrincipal);
            this.tbpControlePrincipal.Controls.Add(this.tbpInspecao);
            this.tbpControlePrincipal.Controls.Add(this.tbpServicos);
            this.tbpControlePrincipal.Controls.Add(this.tbpEstatistica);
            this.tbpControlePrincipal.Controls.Add(this.tbpFerramentas);
            this.tbpControlePrincipal.Controls.Add(this.tbpUtilitarios);
            this.tbpControlePrincipal.Location = new System.Drawing.Point(5, 0);
            this.tbpControlePrincipal.Name = "tbpControlePrincipal";
            this.tbpControlePrincipal.SelectedIndex = 0;
            this.tbpControlePrincipal.Size = new System.Drawing.Size(245, 269);
            this.tbpControlePrincipal.TabIndex = 0;
            this.tbpControlePrincipal.SelectedIndexChanged += new System.EventHandler(this.tbpControlePrincipal_SelectedIndexChanged);
            this.tbpControlePrincipal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbpControlePrincipal_KeyDown);
            // 
            // tbpPrincipal
            // 
            this.tbpPrincipal.Controls.Add(this.pctPrincipal);
            this.tbpPrincipal.Controls.Add(this.txtColetor);
            this.tbpPrincipal.Controls.Add(this.lblColetor);
            this.tbpPrincipal.Controls.Add(this.lblData);
            this.tbpPrincipal.Controls.Add(this.dtpDataInspecao);
            this.tbpPrincipal.Controls.Add(this.lblInspetor);
            this.tbpPrincipal.Controls.Add(this.txtInspetor);
            this.tbpPrincipal.Location = new System.Drawing.Point(4, 22);
            this.tbpPrincipal.Name = "tbpPrincipal";
            this.tbpPrincipal.Size = new System.Drawing.Size(237, 243);
            this.tbpPrincipal.TabIndex = 0;
            this.tbpPrincipal.Text = "Principal";
            // 
            // pctPrincipal
            // 
            this.pctPrincipal.Image = ((System.Drawing.Image)(resources.GetObject("pctPrincipal.Image")));
            this.pctPrincipal.Location = new System.Drawing.Point(3, 7);
            this.pctPrincipal.Name = "pctPrincipal";
            this.pctPrincipal.Size = new System.Drawing.Size(230, 150);
            this.pctPrincipal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctPrincipal.TabIndex = 0;
            this.pctPrincipal.TabStop = false;
            // 
            // txtColetor
            // 
            this.txtColetor.Location = new System.Drawing.Point(83, 191);
            this.txtColetor.Name = "txtColetor";
            this.txtColetor.Size = new System.Drawing.Size(150, 20);
            this.txtColetor.TabIndex = 14;
            this.txtColetor.Leave += new System.EventHandler(this.txtColetor_Leave);
            // 
            // lblColetor
            // 
            this.lblColetor.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblColetor.Location = new System.Drawing.Point(7, 192);
            this.lblColetor.Name = "lblColetor";
            this.lblColetor.Size = new System.Drawing.Size(70, 20);
            this.lblColetor.TabIndex = 15;
            this.lblColetor.Text = "Coletor:";
            // 
            // lblData
            // 
            this.lblData.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblData.Location = new System.Drawing.Point(7, 165);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(70, 20);
            this.lblData.TabIndex = 16;
            this.lblData.Text = "Data:";
            // 
            // dtpDataInspecao
            // 
            this.dtpDataInspecao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataInspecao.Location = new System.Drawing.Point(83, 163);
            this.dtpDataInspecao.Name = "dtpDataInspecao";
            this.dtpDataInspecao.Size = new System.Drawing.Size(150, 20);
            this.dtpDataInspecao.TabIndex = 10;
            // 
            // lblInspetor
            // 
            this.lblInspetor.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblInspetor.Location = new System.Drawing.Point(7, 219);
            this.lblInspetor.Name = "lblInspetor";
            this.lblInspetor.Size = new System.Drawing.Size(70, 20);
            this.lblInspetor.TabIndex = 17;
            this.lblInspetor.Text = "Inspetor:";
            // 
            // txtInspetor
            // 
            this.txtInspetor.Location = new System.Drawing.Point(83, 218);
            this.txtInspetor.Name = "txtInspetor";
            this.txtInspetor.Size = new System.Drawing.Size(150, 20);
            this.txtInspetor.TabIndex = 8;
            this.txtInspetor.Leave += new System.EventHandler(this.txtInspetor_Leave);
            // 
            // tbpInspecao
            // 
            this.tbpInspecao.Controls.Add(this.btnConsultarInspecao);
            this.tbpInspecao.Controls.Add(this.cmbIdentificacao);
            this.tbpInspecao.Controls.Add(this.cmbDataInspecao);
            this.tbpInspecao.Controls.Add(this.lsvInspecao);
            this.tbpInspecao.Location = new System.Drawing.Point(4, 22);
            this.tbpInspecao.Name = "tbpInspecao";
            this.tbpInspecao.Size = new System.Drawing.Size(237, 243);
            this.tbpInspecao.TabIndex = 1;
            this.tbpInspecao.Text = "Inspecao";
            // 
            // btnConsultarInspecao
            // 
            this.btnConsultarInspecao.Location = new System.Drawing.Point(7, 219);
            this.btnConsultarInspecao.Name = "btnConsultarInspecao";
            this.btnConsultarInspecao.Size = new System.Drawing.Size(226, 20);
            this.btnConsultarInspecao.TabIndex = 14;
            this.btnConsultarInspecao.Text = "&Consultar";
            this.btnConsultarInspecao.Click += new System.EventHandler(this.btnConsultarInspecao_Click);
            // 
            // cmbIdentificacao
            // 
            this.cmbIdentificacao.Location = new System.Drawing.Point(7, 35);
            this.cmbIdentificacao.Name = "cmbIdentificacao";
            this.cmbIdentificacao.Size = new System.Drawing.Size(226, 21);
            this.cmbIdentificacao.TabIndex = 13;
            this.cmbIdentificacao.Enter += new System.EventHandler(this.cmbIdentificacao_Enter);
            this.cmbIdentificacao.LostFocus += new System.EventHandler(this.cmbIdentificacao_LostFocus);
            // 
            // cmbDataInspecao
            // 
            this.cmbDataInspecao.Location = new System.Drawing.Point(7, 7);
            this.cmbDataInspecao.Name = "cmbDataInspecao";
            this.cmbDataInspecao.Size = new System.Drawing.Size(226, 21);
            this.cmbDataInspecao.TabIndex = 11;
            this.cmbDataInspecao.Enter += new System.EventHandler(this.cmbDataInspecao_Enter);
            // 
            // lsvInspecao
            // 
            this.lsvInspecao.Location = new System.Drawing.Point(7, 63);
            this.lsvInspecao.Name = "lsvInspecao";
            this.lsvInspecao.Size = new System.Drawing.Size(226, 150);
            this.lsvInspecao.TabIndex = 10;
            this.lsvInspecao.UseCompatibleStateImageBehavior = false;
            this.lsvInspecao.SelectedIndexChanged += new System.EventHandler(this.lsvInspecao_SelectedIndexChanged);
            // 
            // tbpServicos
            // 
            this.tbpServicos.Controls.Add(this.btnPreencher_Valor_Aleatorio);
            this.tbpServicos.Controls.Add(this.btnPreencher_Zero_Um_Dois);
            this.tbpServicos.Controls.Add(this.btnPreencher_Zero_Um);
            this.tbpServicos.Controls.Add(this.btnPreencher_Dois);
            this.tbpServicos.Controls.Add(this.btnPreencher_Um);
            this.tbpServicos.Controls.Add(this.cmbEndereco);
            this.tbpServicos.Controls.Add(this.btnZerar);
            this.tbpServicos.Controls.Add(this.lblEndereco);
            this.tbpServicos.Controls.Add(this.btnDeletarInspecao);
            this.tbpServicos.Controls.Add(this.btnAlterarInspecao);
            this.tbpServicos.Controls.Add(this.btnIncluirInspecao);
            this.tbpServicos.Controls.Add(this.cmbServicos);
            this.tbpServicos.Controls.Add(this.btnAtribuirNotaServicos);
            this.tbpServicos.Controls.Add(this.txtNotaServicos);
            this.tbpServicos.Controls.Add(this.lsvServicos);
            this.tbpServicos.Location = new System.Drawing.Point(4, 22);
            this.tbpServicos.Name = "tbpServicos";
            this.tbpServicos.Size = new System.Drawing.Size(237, 243);
            this.tbpServicos.TabIndex = 2;
            this.tbpServicos.Text = "Servicos";
            // 
            // btnPreencher_Valor_Aleatorio
            // 
            this.btnPreencher_Valor_Aleatorio.Location = new System.Drawing.Point(192, 35);
            this.btnPreencher_Valor_Aleatorio.Name = "btnPreencher_Valor_Aleatorio";
            this.btnPreencher_Valor_Aleatorio.Size = new System.Drawing.Size(41, 20);
            this.btnPreencher_Valor_Aleatorio.TabIndex = 31;
            this.btnPreencher_Valor_Aleatorio.Text = "A";
            this.btnPreencher_Valor_Aleatorio.Click += new System.EventHandler(this.btnPreencher_Valor_Aleatorio_Click);
            // 
            // btnPreencher_Zero_Um_Dois
            // 
            this.btnPreencher_Zero_Um_Dois.Location = new System.Drawing.Point(145, 35);
            this.btnPreencher_Zero_Um_Dois.Name = "btnPreencher_Zero_Um_Dois";
            this.btnPreencher_Zero_Um_Dois.Size = new System.Drawing.Size(41, 20);
            this.btnPreencher_Zero_Um_Dois.TabIndex = 30;
            this.btnPreencher_Zero_Um_Dois.Text = "0-1-2";
            this.btnPreencher_Zero_Um_Dois.Click += new System.EventHandler(this.btnPreencher_Zero_Um_Dois_Click);
            // 
            // btnPreencher_Zero_Um
            // 
            this.btnPreencher_Zero_Um.Location = new System.Drawing.Point(98, 35);
            this.btnPreencher_Zero_Um.Name = "btnPreencher_Zero_Um";
            this.btnPreencher_Zero_Um.Size = new System.Drawing.Size(41, 20);
            this.btnPreencher_Zero_Um.TabIndex = 29;
            this.btnPreencher_Zero_Um.Text = "0-1";
            this.btnPreencher_Zero_Um.Click += new System.EventHandler(this.btnPreencher_Zero_Um_Click);
            // 
            // btnPreencher_Dois
            // 
            this.btnPreencher_Dois.Location = new System.Drawing.Point(51, 35);
            this.btnPreencher_Dois.Name = "btnPreencher_Dois";
            this.btnPreencher_Dois.Size = new System.Drawing.Size(41, 20);
            this.btnPreencher_Dois.TabIndex = 28;
            this.btnPreencher_Dois.Text = "2";
            this.btnPreencher_Dois.Click += new System.EventHandler(this.btnPreencher_Dois_Click);
            // 
            // btnPreencher_Um
            // 
            this.btnPreencher_Um.Location = new System.Drawing.Point(3, 35);
            this.btnPreencher_Um.Name = "btnPreencher_Um";
            this.btnPreencher_Um.Size = new System.Drawing.Size(41, 20);
            this.btnPreencher_Um.TabIndex = 27;
            this.btnPreencher_Um.Text = "1";
            this.btnPreencher_Um.Click += new System.EventHandler(this.btnPreencher_Um_Click);
            // 
            // cmbEndereco
            // 
            this.cmbEndereco.Location = new System.Drawing.Point(51, 189);
            this.cmbEndereco.Name = "cmbEndereco";
            this.cmbEndereco.Size = new System.Drawing.Size(182, 21);
            this.cmbEndereco.TabIndex = 25;
            this.cmbEndereco.Click += new System.EventHandler(this.cmbEndereco_Click);
            // 
            // btnZerar
            // 
            this.btnZerar.Location = new System.Drawing.Point(192, 9);
            this.btnZerar.Name = "btnZerar";
            this.btnZerar.Size = new System.Drawing.Size(41, 20);
            this.btnZerar.TabIndex = 23;
            this.btnZerar.Text = "Zerar";
            this.btnZerar.Click += new System.EventHandler(this.btnZerar_Click);
            // 
            // lblEndereco
            // 
            this.lblEndereco.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblEndereco.Location = new System.Drawing.Point(3, 189);
            this.lblEndereco.Name = "lblEndereco";
            this.lblEndereco.Size = new System.Drawing.Size(42, 20);
            this.lblEndereco.TabIndex = 26;
            this.lblEndereco.Text = "End.:";
            // 
            // btnDeletarInspecao
            // 
            this.btnDeletarInspecao.Location = new System.Drawing.Point(182, 216);
            this.btnDeletarInspecao.Name = "btnDeletarInspecao";
            this.btnDeletarInspecao.Size = new System.Drawing.Size(51, 20);
            this.btnDeletarInspecao.TabIndex = 17;
            this.btnDeletarInspecao.Text = "&Deletar";
            this.btnDeletarInspecao.Click += new System.EventHandler(this.btnDeletarInspecao_Click);
            // 
            // btnAlterarInspecao
            // 
            this.btnAlterarInspecao.Location = new System.Drawing.Point(121, 216);
            this.btnAlterarInspecao.Name = "btnAlterarInspecao";
            this.btnAlterarInspecao.Size = new System.Drawing.Size(56, 20);
            this.btnAlterarInspecao.TabIndex = 13;
            this.btnAlterarInspecao.Text = "&Alterar";
            this.btnAlterarInspecao.Click += new System.EventHandler(this.btnAlterarInspecao_Click);
            // 
            // btnIncluirInspecao
            // 
            this.btnIncluirInspecao.Location = new System.Drawing.Point(72, 216);
            this.btnIncluirInspecao.Name = "btnIncluirInspecao";
            this.btnIncluirInspecao.Size = new System.Drawing.Size(43, 20);
            this.btnIncluirInspecao.TabIndex = 11;
            this.btnIncluirInspecao.Text = "&Incluir";
            this.btnIncluirInspecao.Click += new System.EventHandler(this.btnIncluirInspecao_Click);
            // 
            // cmbServicos
            // 
            this.cmbServicos.Location = new System.Drawing.Point(3, 8);
            this.cmbServicos.Name = "cmbServicos";
            this.cmbServicos.Size = new System.Drawing.Size(183, 21);
            this.cmbServicos.TabIndex = 8;
            this.cmbServicos.SelectedIndexChanged += new System.EventHandler(this.cmbServicos_SelectedIndexChanged);
            this.cmbServicos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbServicos_KeyDown);
            // 
            // btnAtribuirNotaServicos
            // 
            this.btnAtribuirNotaServicos.Location = new System.Drawing.Point(28, 216);
            this.btnAtribuirNotaServicos.Name = "btnAtribuirNotaServicos";
            this.btnAtribuirNotaServicos.Size = new System.Drawing.Size(38, 20);
            this.btnAtribuirNotaServicos.TabIndex = 3;
            this.btnAtribuirNotaServicos.Text = "&Nota";
            this.btnAtribuirNotaServicos.Click += new System.EventHandler(this.btnAtribuirNotaServicos_Click);
            // 
            // txtNotaServicos
            // 
            this.txtNotaServicos.Location = new System.Drawing.Point(3, 216);
            this.txtNotaServicos.Name = "txtNotaServicos";
            this.txtNotaServicos.Size = new System.Drawing.Size(19, 20);
            this.txtNotaServicos.TabIndex = 2;
            this.txtNotaServicos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNotaServicos_KeyDown);
            this.txtNotaServicos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNotaServicos_KeyPress);
            // 
            // lsvServicos
            // 
            this.lsvServicos.Location = new System.Drawing.Point(3, 61);
            this.lsvServicos.Name = "lsvServicos";
            this.lsvServicos.Size = new System.Drawing.Size(230, 122);
            this.lsvServicos.TabIndex = 0;
            this.lsvServicos.UseCompatibleStateImageBehavior = false;
            this.lsvServicos.SelectedIndexChanged += new System.EventHandler(this.lsvServicos_SelectedIndexChanged);
            this.lsvServicos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsvServicos_KeyDown);
            // 
            // tbpEstatistica
            // 
            this.tbpEstatistica.Controls.Add(this.cmbOpcaoEstatistica);
            this.tbpEstatistica.Controls.Add(this.btnCalcularEstatistica);
            this.tbpEstatistica.Controls.Add(this.lsvEstatistica);
            this.tbpEstatistica.Location = new System.Drawing.Point(4, 22);
            this.tbpEstatistica.Name = "tbpEstatistica";
            this.tbpEstatistica.Size = new System.Drawing.Size(237, 243);
            this.tbpEstatistica.TabIndex = 3;
            this.tbpEstatistica.Text = "Estatistica";
            // 
            // cmbOpcaoEstatistica
            // 
            this.cmbOpcaoEstatistica.Location = new System.Drawing.Point(7, 7);
            this.cmbOpcaoEstatistica.Name = "cmbOpcaoEstatistica";
            this.cmbOpcaoEstatistica.Size = new System.Drawing.Size(226, 21);
            this.cmbOpcaoEstatistica.TabIndex = 16;
            this.cmbOpcaoEstatistica.GotFocus += new System.EventHandler(this.cmbOpcaoEstatistica_GotFocus);
            // 
            // btnCalcularEstatistica
            // 
            this.btnCalcularEstatistica.Location = new System.Drawing.Point(7, 219);
            this.btnCalcularEstatistica.Name = "btnCalcularEstatistica";
            this.btnCalcularEstatistica.Size = new System.Drawing.Size(226, 20);
            this.btnCalcularEstatistica.TabIndex = 15;
            this.btnCalcularEstatistica.Text = "&Calcular";
            this.btnCalcularEstatistica.Click += new System.EventHandler(this.btnCalcularEstatistica_Click);
            // 
            // lsvEstatistica
            // 
            this.lsvEstatistica.Location = new System.Drawing.Point(7, 35);
            this.lsvEstatistica.Name = "lsvEstatistica";
            this.lsvEstatistica.Size = new System.Drawing.Size(226, 178);
            this.lsvEstatistica.TabIndex = 2;
            this.lsvEstatistica.UseCompatibleStateImageBehavior = false;
            // 
            // tbpFerramentas
            // 
            this.tbpFerramentas.Controls.Add(this.btnCompactarRepararBancoDados);
            this.tbpFerramentas.Controls.Add(this.btnCriarTabelas);
            this.tbpFerramentas.Controls.Add(this.btnDeletarTabelas);
            this.tbpFerramentas.Controls.Add(this.btnCriarBancoDados);
            this.tbpFerramentas.Controls.Add(this.lblSenhaBancoDados);
            this.tbpFerramentas.Controls.Add(this.txtSenhaBancoDados);
            this.tbpFerramentas.Controls.Add(this.btnTestarEnderecoBancoDados);
            this.tbpFerramentas.Controls.Add(this.btnEnderecoBancoDadosPadrao);
            this.tbpFerramentas.Controls.Add(this.btnAbrirArquivoDialogo);
            this.tbpFerramentas.Controls.Add(this.btnEnderecoBancoDadosFlashDisk);
            this.tbpFerramentas.Controls.Add(this.lblEnderecoBancoDados);
            this.tbpFerramentas.Controls.Add(this.txtEnderecoBancoDados);
            this.tbpFerramentas.Controls.Add(this.btnEnderecoBancoDadosStorageCard);
            this.tbpFerramentas.Controls.Add(this.lblEnderecoWebService);
            this.tbpFerramentas.Controls.Add(this.txtEnderecoWebService);
            this.tbpFerramentas.Controls.Add(this.pctConfiguracoes);
            this.tbpFerramentas.Location = new System.Drawing.Point(4, 22);
            this.tbpFerramentas.Name = "tbpFerramentas";
            this.tbpFerramentas.Size = new System.Drawing.Size(237, 243);
            this.tbpFerramentas.TabIndex = 4;
            this.tbpFerramentas.Text = "Ferramentas";
            // 
            // btnCompactarRepararBancoDados
            // 
            this.btnCompactarRepararBancoDados.Location = new System.Drawing.Point(7, 140);
            this.btnCompactarRepararBancoDados.Name = "btnCompactarRepararBancoDados";
            this.btnCompactarRepararBancoDados.Size = new System.Drawing.Size(226, 20);
            this.btnCompactarRepararBancoDados.TabIndex = 47;
            this.btnCompactarRepararBancoDados.Text = "&Compactar e Reparar";
            this.btnCompactarRepararBancoDados.Click += new System.EventHandler(this.btnCompactarRepararBancoDados_Click);
            // 
            // btnCriarTabelas
            // 
            this.btnCriarTabelas.Location = new System.Drawing.Point(7, 166);
            this.btnCriarTabelas.Name = "btnCriarTabelas";
            this.btnCriarTabelas.Size = new System.Drawing.Size(226, 20);
            this.btnCriarTabelas.TabIndex = 46;
            this.btnCriarTabelas.Text = "&Criar Tabelas";
            this.btnCriarTabelas.Click += new System.EventHandler(this.btnCriarTabelas_Click);
            // 
            // btnDeletarTabelas
            // 
            this.btnDeletarTabelas.Location = new System.Drawing.Point(7, 192);
            this.btnDeletarTabelas.Name = "btnDeletarTabelas";
            this.btnDeletarTabelas.Size = new System.Drawing.Size(226, 20);
            this.btnDeletarTabelas.TabIndex = 45;
            this.btnDeletarTabelas.Text = "&Deletar Tabelas";
            this.btnDeletarTabelas.Click += new System.EventHandler(this.btnDeletarTabelas_Click);
            // 
            // btnCriarBancoDados
            // 
            this.btnCriarBancoDados.Location = new System.Drawing.Point(7, 114);
            this.btnCriarBancoDados.Name = "btnCriarBancoDados";
            this.btnCriarBancoDados.Size = new System.Drawing.Size(226, 20);
            this.btnCriarBancoDados.TabIndex = 40;
            this.btnCriarBancoDados.Text = "&Criar Banco Dados";
            this.btnCriarBancoDados.Click += new System.EventHandler(this.btnCriarBancoDados_Click);
            // 
            // lblSenhaBancoDados
            // 
            this.lblSenhaBancoDados.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblSenhaBancoDados.Location = new System.Drawing.Point(7, 63);
            this.lblSenhaBancoDados.Name = "lblSenhaBancoDados";
            this.lblSenhaBancoDados.Size = new System.Drawing.Size(50, 20);
            this.lblSenhaBancoDados.TabIndex = 41;
            this.lblSenhaBancoDados.Text = "Senha:";
            this.lblSenhaBancoDados.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtSenhaBancoDados
            // 
            this.txtSenhaBancoDados.Location = new System.Drawing.Point(63, 62);
            this.txtSenhaBancoDados.Name = "txtSenhaBancoDados";
            this.txtSenhaBancoDados.PasswordChar = '*';
            this.txtSenhaBancoDados.Size = new System.Drawing.Size(108, 20);
            this.txtSenhaBancoDados.TabIndex = 37;
            this.txtSenhaBancoDados.Leave += new System.EventHandler(this.txtSenhaBancoDados_Leave);
            // 
            // btnTestarEnderecoBancoDados
            // 
            this.btnTestarEnderecoBancoDados.Location = new System.Drawing.Point(177, 63);
            this.btnTestarEnderecoBancoDados.Name = "btnTestarEnderecoBancoDados";
            this.btnTestarEnderecoBancoDados.Size = new System.Drawing.Size(56, 20);
            this.btnTestarEnderecoBancoDados.TabIndex = 36;
            this.btnTestarEnderecoBancoDados.Text = "Testar";
            this.btnTestarEnderecoBancoDados.Click += new System.EventHandler(this.btnTestarEnderecoBancoDados_Click);
            // 
            // btnEnderecoBancoDadosPadrao
            // 
            this.btnEnderecoBancoDadosPadrao.Location = new System.Drawing.Point(177, 36);
            this.btnEnderecoBancoDadosPadrao.Name = "btnEnderecoBancoDadosPadrao";
            this.btnEnderecoBancoDadosPadrao.Size = new System.Drawing.Size(25, 20);
            this.btnEnderecoBancoDadosPadrao.TabIndex = 35;
            this.btnEnderecoBancoDadosPadrao.Text = "P";
            this.btnEnderecoBancoDadosPadrao.Click += new System.EventHandler(this.btnEnderecoBancoDadosPadrao_Click);
            // 
            // btnAbrirArquivoDialogo
            // 
            this.btnAbrirArquivoDialogo.Location = new System.Drawing.Point(208, 36);
            this.btnAbrirArquivoDialogo.Name = "btnAbrirArquivoDialogo";
            this.btnAbrirArquivoDialogo.Size = new System.Drawing.Size(25, 20);
            this.btnAbrirArquivoDialogo.TabIndex = 34;
            this.btnAbrirArquivoDialogo.Text = "...";
            this.btnAbrirArquivoDialogo.Click += new System.EventHandler(this.btnAbrirArquivoDialogo_Click);
            // 
            // btnEnderecoBancoDadosFlashDisk
            // 
            this.btnEnderecoBancoDadosFlashDisk.Location = new System.Drawing.Point(7, 88);
            this.btnEnderecoBancoDadosFlashDisk.Name = "btnEnderecoBancoDadosFlashDisk";
            this.btnEnderecoBancoDadosFlashDisk.Size = new System.Drawing.Size(110, 20);
            this.btnEnderecoBancoDadosFlashDisk.TabIndex = 33;
            this.btnEnderecoBancoDadosFlashDisk.Text = "&Flash Disk";
            this.btnEnderecoBancoDadosFlashDisk.Click += new System.EventHandler(this.btnEnderecoBancoDadosFlashDisk_Click);
            // 
            // lblEnderecoBancoDados
            // 
            this.lblEnderecoBancoDados.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblEnderecoBancoDados.Location = new System.Drawing.Point(43, 13);
            this.lblEnderecoBancoDados.Name = "lblEnderecoBancoDados";
            this.lblEnderecoBancoDados.Size = new System.Drawing.Size(191, 20);
            this.lblEnderecoBancoDados.TabIndex = 42;
            this.lblEnderecoBancoDados.Text = "Endereco Banco Dados";
            this.lblEnderecoBancoDados.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtEnderecoBancoDados
            // 
            this.txtEnderecoBancoDados.Location = new System.Drawing.Point(7, 36);
            this.txtEnderecoBancoDados.Name = "txtEnderecoBancoDados";
            this.txtEnderecoBancoDados.Size = new System.Drawing.Size(164, 20);
            this.txtEnderecoBancoDados.TabIndex = 31;
            this.txtEnderecoBancoDados.Leave += new System.EventHandler(this.txtEnderecoBancoDados_Leave);
            // 
            // btnEnderecoBancoDadosStorageCard
            // 
            this.btnEnderecoBancoDadosStorageCard.Location = new System.Drawing.Point(123, 88);
            this.btnEnderecoBancoDadosStorageCard.Name = "btnEnderecoBancoDadosStorageCard";
            this.btnEnderecoBancoDadosStorageCard.Size = new System.Drawing.Size(110, 20);
            this.btnEnderecoBancoDadosStorageCard.TabIndex = 29;
            this.btnEnderecoBancoDadosStorageCard.Text = "&Storage Card";
            this.btnEnderecoBancoDadosStorageCard.Click += new System.EventHandler(this.btnEnderecoBancoDadosStorageCard_Click);
            // 
            // lblEnderecoWebService
            // 
            this.lblEnderecoWebService.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblEnderecoWebService.Location = new System.Drawing.Point(9, 218);
            this.lblEnderecoWebService.Name = "lblEnderecoWebService";
            this.lblEnderecoWebService.Size = new System.Drawing.Size(30, 20);
            this.lblEnderecoWebService.TabIndex = 43;
            this.lblEnderecoWebService.Text = "Wb:";
            this.lblEnderecoWebService.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtEnderecoWebService
            // 
            this.txtEnderecoWebService.Location = new System.Drawing.Point(45, 216);
            this.txtEnderecoWebService.Name = "txtEnderecoWebService";
            this.txtEnderecoWebService.Size = new System.Drawing.Size(188, 20);
            this.txtEnderecoWebService.TabIndex = 27;
            this.txtEnderecoWebService.Leave += new System.EventHandler(this.txtEnderecoWebService_Leave);
            // 
            // pctConfiguracoes
            // 
            this.pctConfiguracoes.Image = ((System.Drawing.Image)(resources.GetObject("pctConfiguracoes.Image")));
            this.pctConfiguracoes.Location = new System.Drawing.Point(7, 3);
            this.pctConfiguracoes.Name = "pctConfiguracoes";
            this.pctConfiguracoes.Size = new System.Drawing.Size(30, 30);
            this.pctConfiguracoes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctConfiguracoes.TabIndex = 44;
            this.pctConfiguracoes.TabStop = false;
            // 
            // tbpUtilitarios
            // 
            this.tbpUtilitarios.Controls.Add(this.btnWebServiceDownload);
            this.tbpUtilitarios.Controls.Add(this.chbForcarUpload);
            this.tbpUtilitarios.Controls.Add(this.btnWebServiceUpload);
            this.tbpUtilitarios.Controls.Add(this.btnSairAplicativo);
            this.tbpUtilitarios.Controls.Add(this.btnSincronizarHorarioServidor);
            this.tbpUtilitarios.Controls.Add(this.txtLegenda);
            this.tbpUtilitarios.Location = new System.Drawing.Point(4, 22);
            this.tbpUtilitarios.Name = "tbpUtilitarios";
            this.tbpUtilitarios.Size = new System.Drawing.Size(237, 243);
            this.tbpUtilitarios.TabIndex = 5;
            this.tbpUtilitarios.Text = "Utilitários";
            // 
            // btnWebServiceDownload
            // 
            this.btnWebServiceDownload.Location = new System.Drawing.Point(128, 141);
            this.btnWebServiceDownload.Name = "btnWebServiceDownload";
            this.btnWebServiceDownload.Size = new System.Drawing.Size(105, 20);
            this.btnWebServiceDownload.TabIndex = 28;
            this.btnWebServiceDownload.Text = "&Download";
            this.btnWebServiceDownload.Click += new System.EventHandler(this.btnWebServiceDownload_Click);
            // 
            // chbForcarUpload
            // 
            this.chbForcarUpload.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chbForcarUpload.Location = new System.Drawing.Point(7, 167);
            this.chbForcarUpload.Name = "chbForcarUpload";
            this.chbForcarUpload.Size = new System.Drawing.Size(114, 20);
            this.chbForcarUpload.TabIndex = 27;
            this.chbForcarUpload.Text = "Forcar Upload";
            // 
            // btnWebServiceUpload
            // 
            this.btnWebServiceUpload.Location = new System.Drawing.Point(128, 167);
            this.btnWebServiceUpload.Name = "btnWebServiceUpload";
            this.btnWebServiceUpload.Size = new System.Drawing.Size(105, 20);
            this.btnWebServiceUpload.TabIndex = 26;
            this.btnWebServiceUpload.Text = "&Upload";
            this.btnWebServiceUpload.Click += new System.EventHandler(this.btnWebServiceUpload_Click);
            // 
            // btnSairAplicativo
            // 
            this.btnSairAplicativo.Location = new System.Drawing.Point(7, 219);
            this.btnSairAplicativo.Name = "btnSairAplicativo";
            this.btnSairAplicativo.Size = new System.Drawing.Size(226, 20);
            this.btnSairAplicativo.TabIndex = 22;
            this.btnSairAplicativo.Text = "&Sair";
            this.btnSairAplicativo.Click += new System.EventHandler(this.btnSairAplicativo_Click);
            // 
            // btnSincronizarHorarioServidor
            // 
            this.btnSincronizarHorarioServidor.Location = new System.Drawing.Point(7, 193);
            this.btnSincronizarHorarioServidor.Name = "btnSincronizarHorarioServidor";
            this.btnSincronizarHorarioServidor.Size = new System.Drawing.Size(226, 20);
            this.btnSincronizarHorarioServidor.TabIndex = 21;
            this.btnSincronizarHorarioServidor.Text = "Sincronizar &Horario com Servidor";
            this.btnSincronizarHorarioServidor.Click += new System.EventHandler(this.btnSincronizarHorarioServidor_Click);
            // 
            // txtLegenda
            // 
            this.txtLegenda.Enabled = false;
            this.txtLegenda.Location = new System.Drawing.Point(7, 7);
            this.txtLegenda.Multiline = true;
            this.txtLegenda.Name = "txtLegenda";
            this.txtLegenda.Size = new System.Drawing.Size(226, 128);
            this.txtLegenda.TabIndex = 18;
            // 
            // ofd1
            // 
            this.ofd1.FileName = "ofd1";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(255, 279);
            this.Controls.Add(this.tbpControlePrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Menu = this.mmnPrincipal;
            this.Name = "frmPrincipal";
            this.Text = "Inspecao";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPrincipal_KeyDown);
            this.tbpControlePrincipal.ResumeLayout(false);
            this.tbpPrincipal.ResumeLayout(false);
            this.tbpPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctPrincipal)).EndInit();
            this.tbpInspecao.ResumeLayout(false);
            this.tbpServicos.ResumeLayout(false);
            this.tbpServicos.PerformLayout();
            this.tbpEstatistica.ResumeLayout(false);
            this.tbpFerramentas.ResumeLayout(false);
            this.tbpFerramentas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctConfiguracoes)).EndInit();
            this.tbpUtilitarios.ResumeLayout(false);
            this.tbpUtilitarios.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbpControlePrincipal;
        private System.Windows.Forms.TabPage tbpPrincipal;
        private System.Windows.Forms.TabPage tbpServicos;
        private System.Windows.Forms.ListView lsvServicos;
        private System.Windows.Forms.TextBox txtNotaServicos;
        private System.Windows.Forms.Button btnAtribuirNotaServicos;
        private System.Windows.Forms.ComboBox cmbServicos;
        private System.Windows.Forms.TabPage tbpInspecao;
        private System.Windows.Forms.Label lblInspetor;
        private System.Windows.Forms.TextBox txtInspetor;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.DateTimePicker dtpDataInspecao;
        private System.Windows.Forms.ListView lsvInspecao;
        private System.Windows.Forms.TextBox txtColetor;
        private System.Windows.Forms.Label lblColetor;
        private System.Windows.Forms.TabPage tbpEstatistica;
        private System.Windows.Forms.Button btnIncluirInspecao;
        private System.Windows.Forms.Button btnAlterarInspecao;
        private System.Windows.Forms.ComboBox cmbDataInspecao;
        private System.Windows.Forms.ComboBox cmbIdentificacao;
        private System.Windows.Forms.Button btnConsultarInspecao;
        private System.Windows.Forms.Button btnDeletarInspecao;
        private System.Windows.Forms.ListView lsvEstatistica;
        private System.Windows.Forms.Button btnCalcularEstatistica;
        private System.Windows.Forms.TabPage tbpFerramentas;
        private System.Windows.Forms.ComboBox cmbOpcaoEstatistica;
        private System.Windows.Forms.PictureBox pctConfiguracoes;
        private System.Windows.Forms.PictureBox pctPrincipal;
        private System.Windows.Forms.MenuItem mni1;
        private System.Windows.Forms.MenuItem mni2;
        private System.Windows.Forms.Label lblEndereco;
        private System.Windows.Forms.Button btnZerar;
        private System.Windows.Forms.TabPage tbpUtilitarios;
        private System.Windows.Forms.TextBox txtLegenda;
        private System.Windows.Forms.Label lblEnderecoWebService;
        private System.Windows.Forms.TextBox txtEnderecoWebService;
        private System.Windows.Forms.Label lblEnderecoBancoDados;
        private System.Windows.Forms.TextBox txtEnderecoBancoDados;
        private System.Windows.Forms.Button btnEnderecoBancoDadosStorageCard;
        private System.Windows.Forms.Button btnEnderecoBancoDadosFlashDisk;
        private System.Windows.Forms.Button btnAbrirArquivoDialogo;
        private System.Windows.Forms.OpenFileDialog ofd1;
        private System.Windows.Forms.Button btnEnderecoBancoDadosPadrao;
        private System.Windows.Forms.Button btnTestarEnderecoBancoDados;
        private System.Windows.Forms.TextBox txtSenhaBancoDados;
        private System.Windows.Forms.Label lblSenhaBancoDados;
        private System.Windows.Forms.Button btnCriarBancoDados;
        private System.Windows.Forms.Button btnSincronizarHorarioServidor;
        private System.Windows.Forms.Button btnSairAplicativo;
        private System.Windows.Forms.ComboBox cmbEndereco;
        private System.Windows.Forms.CheckBox chbForcarUpload;
        private System.Windows.Forms.Button btnWebServiceUpload;
        private System.Windows.Forms.Button btnWebServiceDownload;
        private System.Windows.Forms.Button btnDeletarTabelas;
        private System.Windows.Forms.Button btnPreencher_Dois;
        private System.Windows.Forms.Button btnPreencher_Um;
        private System.Windows.Forms.Button btnPreencher_Zero_Um_Dois;
        private System.Windows.Forms.Button btnPreencher_Zero_Um;
        private System.Windows.Forms.Button btnPreencher_Valor_Aleatorio;
        private System.Windows.Forms.Button btnCriarTabelas;
        private System.Windows.Forms.Button btnCompactarRepararBancoDados;
    }
}

