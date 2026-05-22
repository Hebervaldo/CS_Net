namespace prjInspecaoCSNet35
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.mmnPrincipal = new System.Windows.Forms.MainMenu();
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
            this.txtEndereco = new System.Windows.Forms.TextBox();
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
            this.btnSairAplicativo = new System.Windows.Forms.Button();
            this.pctConfiguracoes = new System.Windows.Forms.PictureBox();
            this.txtLegenda = new System.Windows.Forms.TextBox();
            this.btnCompactarRepararBancoDados = new System.Windows.Forms.Button();
            this.tbpControlePrincipal.SuspendLayout();
            this.tbpPrincipal.SuspendLayout();
            this.tbpInspecao.SuspendLayout();
            this.tbpServicos.SuspendLayout();
            this.tbpEstatistica.SuspendLayout();
            this.tbpFerramentas.SuspendLayout();
            this.SuspendLayout();
            // 
            // mmnPrincipal
            // 
            this.mmnPrincipal.MenuItems.Add(this.mni1);
            this.mmnPrincipal.MenuItems.Add(this.mni2);
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
            // tbpControlePrincipal
            // 
            this.tbpControlePrincipal.Controls.Add(this.tbpPrincipal);
            this.tbpControlePrincipal.Controls.Add(this.tbpInspecao);
            this.tbpControlePrincipal.Controls.Add(this.tbpServicos);
            this.tbpControlePrincipal.Controls.Add(this.tbpEstatistica);
            this.tbpControlePrincipal.Controls.Add(this.tbpFerramentas);
            this.tbpControlePrincipal.Location = new System.Drawing.Point(0, 0);
            this.tbpControlePrincipal.Name = "tbpControlePrincipal";
            this.tbpControlePrincipal.SelectedIndex = 0;
            this.tbpControlePrincipal.Size = new System.Drawing.Size(240, 265);
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
            this.tbpPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tbpPrincipal.Name = "tbpPrincipal";
            this.tbpPrincipal.Size = new System.Drawing.Size(240, 242);
            this.tbpPrincipal.Text = "Principal";
            // 
            // pctPrincipal
            // 
            this.pctPrincipal.Image = ((System.Drawing.Image)(resources.GetObject("pctPrincipal.Image")));
            this.pctPrincipal.Location = new System.Drawing.Point(7, 7);
            this.pctPrincipal.Name = "pctPrincipal";
            this.pctPrincipal.Size = new System.Drawing.Size(140, 108);
            // 
            // txtColetor
            // 
            this.txtColetor.Location = new System.Drawing.Point(83, 191);
            this.txtColetor.Name = "txtColetor";
            this.txtColetor.Size = new System.Drawing.Size(150, 21);
            this.txtColetor.TabIndex = 14;
            // 
            // lblColetor
            // 
            this.lblColetor.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblColetor.Location = new System.Drawing.Point(7, 192);
            this.lblColetor.Name = "lblColetor";
            this.lblColetor.Size = new System.Drawing.Size(70, 20);
            this.lblColetor.Text = "Coletor:";
            // 
            // lblData
            // 
            this.lblData.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblData.Location = new System.Drawing.Point(7, 165);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(70, 20);
            this.lblData.Text = "Data:";
            // 
            // dtpDataInspecao
            // 
            this.dtpDataInspecao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataInspecao.Location = new System.Drawing.Point(83, 163);
            this.dtpDataInspecao.Name = "dtpDataInspecao";
            this.dtpDataInspecao.Size = new System.Drawing.Size(150, 22);
            this.dtpDataInspecao.TabIndex = 10;
            // 
            // lblInspetor
            // 
            this.lblInspetor.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblInspetor.Location = new System.Drawing.Point(7, 219);
            this.lblInspetor.Name = "lblInspetor";
            this.lblInspetor.Size = new System.Drawing.Size(70, 20);
            this.lblInspetor.Text = "Inspetor:";
            // 
            // txtInspetor
            // 
            this.txtInspetor.Location = new System.Drawing.Point(83, 218);
            this.txtInspetor.Name = "txtInspetor";
            this.txtInspetor.Size = new System.Drawing.Size(150, 21);
            this.txtInspetor.TabIndex = 8;
            // 
            // tbpInspecao
            // 
            this.tbpInspecao.Controls.Add(this.btnConsultarInspecao);
            this.tbpInspecao.Controls.Add(this.cmbIdentificacao);
            this.tbpInspecao.Controls.Add(this.cmbDataInspecao);
            this.tbpInspecao.Controls.Add(this.lsvInspecao);
            this.tbpInspecao.Location = new System.Drawing.Point(0, 0);
            this.tbpInspecao.Name = "tbpInspecao";
            this.tbpInspecao.Size = new System.Drawing.Size(232, 239);
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
            this.cmbIdentificacao.Size = new System.Drawing.Size(226, 22);
            this.cmbIdentificacao.TabIndex = 13;
            this.cmbIdentificacao.LostFocus += new System.EventHandler(this.cmbIdentificacao_LostFocus);
            this.cmbIdentificacao.GotFocus += new System.EventHandler(this.cmbIdentificacao_GotFocus);
            // 
            // cmbDataInspecao
            // 
            this.cmbDataInspecao.Location = new System.Drawing.Point(7, 7);
            this.cmbDataInspecao.Name = "cmbDataInspecao";
            this.cmbDataInspecao.Size = new System.Drawing.Size(226, 22);
            this.cmbDataInspecao.TabIndex = 11;
            this.cmbDataInspecao.GotFocus += new System.EventHandler(this.cmbDataInspecao_GotFocus);
            // 
            // lsvInspecao
            // 
            this.lsvInspecao.Location = new System.Drawing.Point(7, 63);
            this.lsvInspecao.Name = "lsvInspecao";
            this.lsvInspecao.Size = new System.Drawing.Size(226, 150);
            this.lsvInspecao.TabIndex = 10;
            this.lsvInspecao.SelectedIndexChanged += new System.EventHandler(this.lsvInspecao_SelectedIndexChanged);
            // 
            // tbpServicos
            // 
            this.tbpServicos.Controls.Add(this.txtEndereco);
            this.tbpServicos.Controls.Add(this.lblEndereco);
            this.tbpServicos.Controls.Add(this.btnDeletarInspecao);
            this.tbpServicos.Controls.Add(this.btnAlterarInspecao);
            this.tbpServicos.Controls.Add(this.btnIncluirInspecao);
            this.tbpServicos.Controls.Add(this.cmbServicos);
            this.tbpServicos.Controls.Add(this.btnAtribuirNotaServicos);
            this.tbpServicos.Controls.Add(this.txtNotaServicos);
            this.tbpServicos.Controls.Add(this.lsvServicos);
            this.tbpServicos.Location = new System.Drawing.Point(0, 0);
            this.tbpServicos.Name = "tbpServicos";
            this.tbpServicos.Size = new System.Drawing.Size(232, 239);
            this.tbpServicos.Text = "Servicos";
            // 
            // txtEndereco
            // 
            this.txtEndereco.Location = new System.Drawing.Point(60, 192);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(106, 21);
            this.txtEndereco.TabIndex = 21;
            // 
            // lblEndereco
            // 
            this.lblEndereco.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblEndereco.Location = new System.Drawing.Point(7, 193);
            this.lblEndereco.Name = "lblEndereco";
            this.lblEndereco.Size = new System.Drawing.Size(47, 20);
            this.lblEndereco.Text = "End.:";
            // 
            // btnDeletarInspecao
            // 
            this.btnDeletarInspecao.Location = new System.Drawing.Point(172, 218);
            this.btnDeletarInspecao.Name = "btnDeletarInspecao";
            this.btnDeletarInspecao.Size = new System.Drawing.Size(60, 20);
            this.btnDeletarInspecao.TabIndex = 17;
            this.btnDeletarInspecao.Text = "&Deletar";
            this.btnDeletarInspecao.Click += new System.EventHandler(this.btnDeletarInspecao_Click);
            // 
            // btnAlterarInspecao
            // 
            this.btnAlterarInspecao.Location = new System.Drawing.Point(106, 218);
            this.btnAlterarInspecao.Name = "btnAlterarInspecao";
            this.btnAlterarInspecao.Size = new System.Drawing.Size(60, 20);
            this.btnAlterarInspecao.TabIndex = 13;
            this.btnAlterarInspecao.Text = "&Alterar";
            this.btnAlterarInspecao.Click += new System.EventHandler(this.btnAlterarInspecao_Click);
            // 
            // btnIncluirInspecao
            // 
            this.btnIncluirInspecao.Location = new System.Drawing.Point(172, 192);
            this.btnIncluirInspecao.Name = "btnIncluirInspecao";
            this.btnIncluirInspecao.Size = new System.Drawing.Size(60, 20);
            this.btnIncluirInspecao.TabIndex = 11;
            this.btnIncluirInspecao.Text = "&Incluir";
            this.btnIncluirInspecao.Click += new System.EventHandler(this.btnIncluirInspecao_Click);
            // 
            // cmbServicos
            // 
            this.cmbServicos.Location = new System.Drawing.Point(7, 7);
            this.cmbServicos.Name = "cmbServicos";
            this.cmbServicos.Size = new System.Drawing.Size(226, 22);
            this.cmbServicos.TabIndex = 8;
            this.cmbServicos.SelectedIndexChanged += new System.EventHandler(this.cmbServicos_SelectedIndexChanged);
            this.cmbServicos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbServicos_KeyDown);
            // 
            // btnAtribuirNotaServicos
            // 
            this.btnAtribuirNotaServicos.Location = new System.Drawing.Point(60, 218);
            this.btnAtribuirNotaServicos.Name = "btnAtribuirNotaServicos";
            this.btnAtribuirNotaServicos.Size = new System.Drawing.Size(40, 20);
            this.btnAtribuirNotaServicos.TabIndex = 3;
            this.btnAtribuirNotaServicos.Text = "&Nota";
            this.btnAtribuirNotaServicos.Click += new System.EventHandler(this.btnAtribuirNotaServicos_Click);
            // 
            // txtNotaServicos
            // 
            this.txtNotaServicos.Location = new System.Drawing.Point(7, 217);
            this.txtNotaServicos.Name = "txtNotaServicos";
            this.txtNotaServicos.Size = new System.Drawing.Size(47, 21);
            this.txtNotaServicos.TabIndex = 2;
            this.txtNotaServicos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNotaServicos_KeyDown);
            // 
            // lsvServicos
            // 
            this.lsvServicos.Location = new System.Drawing.Point(7, 36);
            this.lsvServicos.Name = "lsvServicos";
            this.lsvServicos.Size = new System.Drawing.Size(226, 150);
            this.lsvServicos.TabIndex = 0;
            this.lsvServicos.SelectedIndexChanged += new System.EventHandler(this.lsvServicos_SelectedIndexChanged);
            this.lsvServicos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsvServicos_KeyDown);
            // 
            // tbpEstatistica
            // 
            this.tbpEstatistica.Controls.Add(this.cmbOpcaoEstatistica);
            this.tbpEstatistica.Controls.Add(this.btnCalcularEstatistica);
            this.tbpEstatistica.Controls.Add(this.lsvEstatistica);
            this.tbpEstatistica.Location = new System.Drawing.Point(0, 0);
            this.tbpEstatistica.Name = "tbpEstatistica";
            this.tbpEstatistica.Size = new System.Drawing.Size(232, 239);
            this.tbpEstatistica.Text = "Estatistica";
            // 
            // cmbOpcaoEstatistica
            // 
            this.cmbOpcaoEstatistica.Location = new System.Drawing.Point(7, 7);
            this.cmbOpcaoEstatistica.Name = "cmbOpcaoEstatistica";
            this.cmbOpcaoEstatistica.Size = new System.Drawing.Size(226, 22);
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
            // 
            // tbpFerramentas
            // 
            this.tbpFerramentas.Controls.Add(this.btnSairAplicativo);
            this.tbpFerramentas.Controls.Add(this.pctConfiguracoes);
            this.tbpFerramentas.Controls.Add(this.txtLegenda);
            this.tbpFerramentas.Controls.Add(this.btnCompactarRepararBancoDados);
            this.tbpFerramentas.Location = new System.Drawing.Point(0, 0);
            this.tbpFerramentas.Name = "tbpFerramentas";
            this.tbpFerramentas.Size = new System.Drawing.Size(232, 239);
            this.tbpFerramentas.Text = "Ferramentas";
            // 
            // btnSairAplicativo
            // 
            this.btnSairAplicativo.Location = new System.Drawing.Point(7, 219);
            this.btnSairAplicativo.Name = "btnSairAplicativo";
            this.btnSairAplicativo.Size = new System.Drawing.Size(226, 20);
            this.btnSairAplicativo.TabIndex = 20;
            this.btnSairAplicativo.Text = "&Sair";
            this.btnSairAplicativo.Click += new System.EventHandler(this.btnSairAplicativo_Click);
            // 
            // pctConfiguracoes
            // 
            this.pctConfiguracoes.Image = ((System.Drawing.Image)(resources.GetObject("pctConfiguracoes.Image")));
            this.pctConfiguracoes.Location = new System.Drawing.Point(100, 7);
            this.pctConfiguracoes.Name = "pctConfiguracoes";
            this.pctConfiguracoes.Size = new System.Drawing.Size(40, 40);
            this.pctConfiguracoes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // txtLegenda
            // 
            this.txtLegenda.Enabled = false;
            this.txtLegenda.Location = new System.Drawing.Point(7, 53);
            this.txtLegenda.Multiline = true;
            this.txtLegenda.Name = "txtLegenda";
            this.txtLegenda.Size = new System.Drawing.Size(226, 134);
            this.txtLegenda.TabIndex = 17;
            // 
            // btnCompactarRepararBancoDados
            // 
            this.btnCompactarRepararBancoDados.Location = new System.Drawing.Point(7, 193);
            this.btnCompactarRepararBancoDados.Name = "btnCompactarRepararBancoDados";
            this.btnCompactarRepararBancoDados.Size = new System.Drawing.Size(226, 20);
            this.btnCompactarRepararBancoDados.TabIndex = 16;
            this.btnCompactarRepararBancoDados.Text = "&Compactar e Reparar";
            this.btnCompactarRepararBancoDados.Click += new System.EventHandler(this.btnCompactarRepararBancoDados_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.tbpControlePrincipal);
            this.KeyPreview = true;
            this.Menu = this.mmnPrincipal;
            this.Name = "frmPrincipal";
            this.Text = "Inspecao";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPrincipal_KeyDown);
            this.tbpControlePrincipal.ResumeLayout(false);
            this.tbpPrincipal.ResumeLayout(false);
            this.tbpInspecao.ResumeLayout(false);
            this.tbpServicos.ResumeLayout(false);
            this.tbpEstatistica.ResumeLayout(false);
            this.tbpFerramentas.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnCompactarRepararBancoDados;
        private System.Windows.Forms.ComboBox cmbOpcaoEstatistica;
        private System.Windows.Forms.PictureBox pctConfiguracoes;
        private System.Windows.Forms.TextBox txtLegenda;
        private System.Windows.Forms.PictureBox pctPrincipal;
        private System.Windows.Forms.MenuItem mni1;
        private System.Windows.Forms.MenuItem mni2;
        private System.Windows.Forms.Button btnSairAplicativo;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.Label lblEndereco;
    }
}

