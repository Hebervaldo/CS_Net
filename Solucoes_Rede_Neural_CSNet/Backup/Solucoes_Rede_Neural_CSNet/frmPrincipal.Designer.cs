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
            this.dlgabrirEletronorteGSDE = new System.Windows.Forms.OpenFileDialog();
            this.barstsEletronorteGSDE = new System.Windows.Forms.StatusStrip();
            this.barprgEletronorteGSDE = new System.Windows.Forms.ToolStripProgressBar();
            this.barlblHorario = new System.Windows.Forms.ToolStripStatusLabel();
            this.barlblMostrHorario = new System.Windows.Forms.ToolStripStatusLabel();
            this.barlblContUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.barlblMostrContUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.barmnuEletronorteGSDE = new System.Windows.Forms.MenuStrip();
            this.mnuArquivo = new System.Windows.Forms.ToolStripMenuItem();
            this.smnAbrir = new System.Windows.Forms.ToolStripMenuItem();
            this.smnSair = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuJanela = new System.Windows.Forms.ToolStripMenuItem();
            this.smnHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.smnVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.smnCascata = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRedeNeural = new System.Windows.Forms.ToolStripMenuItem();
            this.tmr1 = new System.Windows.Forms.Timer(this.components);
            this.barstsEletronorteGSDE.SuspendLayout();
            this.barmnuEletronorteGSDE.SuspendLayout();
            this.SuspendLayout();
            // 
            // dlgabrirEletronorteGSDE
            // 
            this.dlgabrirEletronorteGSDE.FileName = "OpenFileDialog1";
            // 
            // barstsEletronorteGSDE
            // 
            this.barstsEletronorteGSDE.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barprgEletronorteGSDE,
            this.barlblHorario,
            this.barlblMostrHorario,
            this.barlblContUser,
            this.barlblMostrContUser});
            this.barstsEletronorteGSDE.Location = new System.Drawing.Point(0, 433);
            this.barstsEletronorteGSDE.Name = "barstsEletronorteGSDE";
            this.barstsEletronorteGSDE.Size = new System.Drawing.Size(652, 22);
            this.barstsEletronorteGSDE.TabIndex = 8;
            this.barstsEletronorteGSDE.Text = "Horario";
            // 
            // barprgEletronorteGSDE
            // 
            this.barprgEletronorteGSDE.Name = "barprgEletronorteGSDE";
            this.barprgEletronorteGSDE.Size = new System.Drawing.Size(100, 16);
            // 
            // barlblHorario
            // 
            this.barlblHorario.Name = "barlblHorario";
            this.barlblHorario.Size = new System.Drawing.Size(49, 17);
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
            this.barlblContUser.Size = new System.Drawing.Size(94, 17);
            this.barlblContUser.Text = "Conta do Usuário:";
            // 
            // barlblMostrContUser
            // 
            this.barlblMostrContUser.Name = "barlblMostrContUser";
            this.barlblMostrContUser.Size = new System.Drawing.Size(0, 17);
            // 
            // barmnuEletronorteGSDE
            // 
            this.barmnuEletronorteGSDE.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuArquivo,
            this.mnuJanela,
            this.mnuRedeNeural});
            this.barmnuEletronorteGSDE.Location = new System.Drawing.Point(0, 0);
            this.barmnuEletronorteGSDE.Name = "barmnuEletronorteGSDE";
            this.barmnuEletronorteGSDE.Size = new System.Drawing.Size(652, 24);
            this.barmnuEletronorteGSDE.TabIndex = 9;
            // 
            // mnuArquivo
            // 
            this.mnuArquivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smnAbrir,
            this.smnSair});
            this.mnuArquivo.Name = "mnuArquivo";
            this.mnuArquivo.Size = new System.Drawing.Size(56, 20);
            this.mnuArquivo.Text = "&Arquivo";
            // 
            // smnAbrir
            // 
            this.smnAbrir.Enabled = false;
            this.smnAbrir.Name = "smnAbrir";
            this.smnAbrir.Size = new System.Drawing.Size(152, 22);
            this.smnAbrir.Text = "&Abrir";
            // 
            // smnSair
            // 
            this.smnSair.Name = "smnSair";
            this.smnSair.Size = new System.Drawing.Size(152, 22);
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
            this.mnuJanela.Size = new System.Drawing.Size(50, 20);
            this.mnuJanela.Text = "&Janela";
            // 
            // smnHorizontal
            // 
            this.smnHorizontal.Name = "smnHorizontal";
            this.smnHorizontal.Size = new System.Drawing.Size(198, 22);
            this.smnHorizontal.Text = "Lado a lado - &Horizontal";
            this.smnHorizontal.Click += new System.EventHandler(this.smnHorizontal_Click);
            // 
            // smnVertical
            // 
            this.smnVertical.Name = "smnVertical";
            this.smnVertical.Size = new System.Drawing.Size(198, 22);
            this.smnVertical.Text = "Lado a lado - &Vertical";
            this.smnVertical.Click += new System.EventHandler(this.smnVertical_Click);
            // 
            // smnCascata
            // 
            this.smnCascata.Name = "smnCascata";
            this.smnCascata.Size = new System.Drawing.Size(198, 22);
            this.smnCascata.Text = "&Cascata";
            this.smnCascata.Click += new System.EventHandler(this.smnCascata_Click);
            // 
            // mnuRedeNeural
            // 
            this.mnuRedeNeural.Name = "mnuRedeNeural";
            this.mnuRedeNeural.Size = new System.Drawing.Size(78, 20);
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
            this.ClientSize = new System.Drawing.Size(652, 455);
            this.Controls.Add(this.barstsEletronorteGSDE);
            this.Controls.Add(this.barmnuEletronorteGSDE);
            this.IsMdiContainer = true;
            this.Name = "frmPrincipal";
            this.Text = "Rede Neural (CS.Net)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrincipal_FormClosing);
            this.barstsEletronorteGSDE.ResumeLayout(false);
            this.barstsEletronorteGSDE.PerformLayout();
            this.barmnuEletronorteGSDE.ResumeLayout(false);
            this.barmnuEletronorteGSDE.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.OpenFileDialog dlgabrirEletronorteGSDE;
        internal System.Windows.Forms.StatusStrip barstsEletronorteGSDE;
        internal System.Windows.Forms.ToolStripProgressBar barprgEletronorteGSDE;
        internal System.Windows.Forms.ToolStripStatusLabel barlblHorario;
        internal System.Windows.Forms.ToolStripStatusLabel barlblMostrHorario;
        internal System.Windows.Forms.ToolStripStatusLabel barlblContUser;
        internal System.Windows.Forms.ToolStripStatusLabel barlblMostrContUser;
        internal System.Windows.Forms.MenuStrip barmnuEletronorteGSDE;
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

