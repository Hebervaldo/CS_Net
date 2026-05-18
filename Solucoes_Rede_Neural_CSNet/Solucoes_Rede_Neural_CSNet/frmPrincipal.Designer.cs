namespace Solucoes_Rede_Neural_CSNet
{
    partial class frmPrincipal
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
            this.components = new System.ComponentModel.Container();
            this.dlgabrir1 = new System.Windows.Forms.OpenFileDialog();
            this.barsts1 = new System.Windows.Forms.StatusStrip();
            this.barprg1 = new System.Windows.Forms.ToolStripProgressBar();
            this.barlblHorario = new System.Windows.Forms.ToolStripStatusLabel();
            this.barlblMostrHorario = new System.Windows.Forms.ToolStripStatusLabel();
            this.barlblContUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.barlblMostrContUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.barmnu1 = new System.Windows.Forms.MenuStrip();
            this.mnuArquivo = new System.Windows.Forms.ToolStripMenuItem();
            this.smnAbrir = new System.Windows.Forms.ToolStripMenuItem();
            this.smnSair = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuJanela = new System.Windows.Forms.ToolStripMenuItem();
            this.smnHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.smnVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.smnCascata = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRedeNeural = new System.Windows.Forms.ToolStripMenuItem();
            this.tmr1 = new System.Windows.Forms.Timer(this.components);
            this.barsts1.SuspendLayout();
            this.barmnu1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dlgabrir1
            // 
            this.dlgabrir1.FileName = "OpenFileDialog1";
            // 
            // barsts1
            // 
            this.barsts1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barprg1,
            this.barlblHorario,
            this.barlblMostrHorario,
            this.barlblContUser,
            this.barlblMostrContUser});
            this.barsts1.Location = new System.Drawing.Point(0, 539);
            this.barsts1.Name = "barsts1";
            this.barsts1.Size = new System.Drawing.Size(784, 22);
            this.barsts1.TabIndex = 8;
            this.barsts1.Text = "Horario";
            // 
            // barprg1
            // 
            this.barprg1.Name = "barprg1";
            this.barprg1.Size = new System.Drawing.Size(100, 16);
            // 
            // barlblHorario
            // 
            this.barlblHorario.Name = "barlblHorario";
            this.barlblHorario.Size = new System.Drawing.Size(53, 17);
            this.barlblHorario.Text = " Horário:";
            // 
            // barlblMostrHorario
            // 
            this.barlblMostrHorario.Name = "barlblMostrHorario";
            this.barlblMostrHorario.Size = new System.Drawing.Size(0, 17);
            // 
            // barlblContUser
            // 
            this.barlblContUser.Name = "barlblContUser";
            this.barlblContUser.Size = new System.Drawing.Size(102, 17);
            this.barlblContUser.Text = "Conta do Usuário:";
            // 
            // barlblMostrContUser
            // 
            this.barlblMostrContUser.Name = "barlblMostrContUser";
            this.barlblMostrContUser.Size = new System.Drawing.Size(0, 17);
            // 
            // barmnu1
            // 
            this.barmnu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuArquivo,
            this.mnuJanela,
            this.mnuRedeNeural});
            this.barmnu1.Location = new System.Drawing.Point(0, 0);
            this.barmnu1.Name = "barmnu1";
            this.barmnu1.Size = new System.Drawing.Size(784, 24);
            this.barmnu1.TabIndex = 9;
            // 
            // mnuArquivo
            // 
            this.mnuArquivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smnAbrir,
            this.smnSair});
            this.mnuArquivo.Name = "mnuArquivo";
            this.mnuArquivo.Size = new System.Drawing.Size(61, 20);
            this.mnuArquivo.Text = "&Arquivo";
            // 
            // smnAbrir
            // 
            this.smnAbrir.Enabled = false;
            this.smnAbrir.Name = "smnAbrir";
            this.smnAbrir.Size = new System.Drawing.Size(100, 22);
            this.smnAbrir.Text = "&Abrir";
            // 
            // smnSair
            // 
            this.smnSair.Name = "smnSair";
            this.smnSair.Size = new System.Drawing.Size(100, 22);
            this.smnSair.Text = "&Sair";
            this.smnSair.Click += new System.EventHandler(this.smnSair_Click);
            // 
            // mnuJanela
            // 
            this.mnuJanela.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smnHorizontal,
            this.smnVertical,
            this.smnCascata});
            this.mnuJanela.Name = "mnuJanela";
            this.mnuJanela.Size = new System.Drawing.Size(51, 20);
            this.mnuJanela.Text = "&Janela";
            // 
            // smnHorizontal
            // 
            this.smnHorizontal.Name = "smnHorizontal";
            this.smnHorizontal.Size = new System.Drawing.Size(201, 22);
            this.smnHorizontal.Text = "Lado a lado - &Horizontal";
            this.smnHorizontal.Click += new System.EventHandler(this.smnHorizontal_Click);
            // 
            // smnVertical
            // 
            this.smnVertical.Name = "smnVertical";
            this.smnVertical.Size = new System.Drawing.Size(201, 22);
            this.smnVertical.Text = "Lado a lado - &Vertical";
            this.smnVertical.Click += new System.EventHandler(this.smnVertical_Click);
            // 
            // smnCascata
            // 
            this.smnCascata.Name = "smnCascata";
            this.smnCascata.Size = new System.Drawing.Size(201, 22);
            this.smnCascata.Text = "&Cascata";
            this.smnCascata.Click += new System.EventHandler(this.smnCascata_Click);
            // 
            // mnuRedeNeural
            // 
            this.mnuRedeNeural.Name = "mnuRedeNeural";
            this.mnuRedeNeural.Size = new System.Drawing.Size(83, 20);
            this.mnuRedeNeural.Text = "Rede &Neural";
            this.mnuRedeNeural.Click += new System.EventHandler(this.mnuRedeNeural_Click);
            // 
            // tmr1
            // 
            this.tmr1.Tick += new System.EventHandler(this.tmr1_Tick);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.barsts1);
            this.Controls.Add(this.barmnu1);
            this.IsMdiContainer = true;
            this.Name = "frmPrincipal";
            this.Text = "Rede Neural (CS.Net)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.barsts1.ResumeLayout(false);
            this.barsts1.PerformLayout();
            this.barmnu1.ResumeLayout(false);
            this.barmnu1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.OpenFileDialog dlgabrir1;
        internal System.Windows.Forms.StatusStrip barsts1;
        internal System.Windows.Forms.ToolStripProgressBar barprg1;
        internal System.Windows.Forms.ToolStripStatusLabel barlblHorario;
        internal System.Windows.Forms.ToolStripStatusLabel barlblMostrHorario;
        internal System.Windows.Forms.ToolStripStatusLabel barlblContUser;
        internal System.Windows.Forms.ToolStripStatusLabel barlblMostrContUser;
        internal System.Windows.Forms.MenuStrip barmnu1;
        internal System.Windows.Forms.ToolStripMenuItem mnuArquivo;
        internal System.Windows.Forms.ToolStripMenuItem smnAbrir;
        internal System.Windows.Forms.ToolStripMenuItem smnSair;
        internal System.Windows.Forms.ToolStripMenuItem mnuJanela;
        internal System.Windows.Forms.ToolStripMenuItem smnHorizontal;
        internal System.Windows.Forms.ToolStripMenuItem smnVertical;
        internal System.Windows.Forms.ToolStripMenuItem smnCascata;
        internal System.Windows.Forms.ToolStripMenuItem mnuRedeNeural;
        internal System.Windows.Forms.Timer tmr1;
    }
}

