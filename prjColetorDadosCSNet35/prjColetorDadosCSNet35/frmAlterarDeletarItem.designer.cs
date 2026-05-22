namespace prjColetorDadosCSNet35
{
    partial class frmAlterarDeletarItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAlterarDeletarItem));
            this.mnm1 = new System.Windows.Forms.MainMenu();
            this.mni1 = new System.Windows.Forms.MenuItem();
            this.mni2 = new System.Windows.Forms.MenuItem();
            this.lblTimer = new System.Windows.Forms.Label();
            this.pctAlterar = new System.Windows.Forms.PictureBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnTodosItens = new System.Windows.Forms.Button();
            this.btnItemSelecionado = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lsv1 = new System.Windows.Forms.ListView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pctDeletar = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // mnm1
            // 
            this.mnm1.MenuItems.Add(this.mni1);
            this.mnm1.MenuItems.Add(this.mni2);
            // 
            // mni1
            // 
            this.mni1.Text = "Alterar";
            this.mni1.Click += new System.EventHandler(this.mni1_Click);
            // 
            // mni2
            // 
            this.mni2.Text = "Deletar";
            this.mni2.Click += new System.EventHandler(this.mni2_Click);
            // 
            // lblTimer
            // 
            this.lblTimer.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblTimer.ForeColor = System.Drawing.Color.Maroon;
            this.lblTimer.Location = new System.Drawing.Point(179, 11);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(58, 20);
            this.lblTimer.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pctAlterar
            // 
            this.pctAlterar.Image = ((System.Drawing.Image)(resources.GetObject("pctAlterar.Image")));
            this.pctAlterar.Location = new System.Drawing.Point(73, 6);
            this.pctAlterar.Name = "pctAlterar";
            this.pctAlterar.Size = new System.Drawing.Size(25, 25);
            this.pctAlterar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.ForeColor = System.Drawing.Color.DimGray;
            this.btnCancelar.Location = new System.Drawing.Point(3, 245);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(234, 20);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnTodosItens
            // 
            this.btnTodosItens.BackColor = System.Drawing.Color.White;
            this.btnTodosItens.ForeColor = System.Drawing.Color.DimGray;
            this.btnTodosItens.Location = new System.Drawing.Point(3, 219);
            this.btnTodosItens.Name = "btnTodosItens";
            this.btnTodosItens.Size = new System.Drawing.Size(234, 20);
            this.btnTodosItens.TabIndex = 2;
            this.btnTodosItens.Text = "&Todos os Itens";
            this.btnTodosItens.Click += new System.EventHandler(this.btnTodosItens_Click);
            // 
            // btnItemSelecionado
            // 
            this.btnItemSelecionado.BackColor = System.Drawing.Color.White;
            this.btnItemSelecionado.ForeColor = System.Drawing.Color.DimGray;
            this.btnItemSelecionado.Location = new System.Drawing.Point(3, 193);
            this.btnItemSelecionado.Name = "btnItemSelecionado";
            this.btnItemSelecionado.Size = new System.Drawing.Size(234, 20);
            this.btnItemSelecionado.TabIndex = 1;
            this.btnItemSelecionado.Text = "&Item Selecionado";
            this.btnItemSelecionado.Click += new System.EventHandler(this.btnItemSelecionado_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblMessage.ForeColor = System.Drawing.Color.Gray;
            this.lblMessage.Location = new System.Drawing.Point(3, 170);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(234, 20);
            this.lblMessage.Text = "Selecione as opções abaixo:";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lsv1
            // 
            this.lsv1.CheckBoxes = true;
            this.lsv1.Location = new System.Drawing.Point(3, 37);
            this.lsv1.Name = "lsv1";
            this.lsv1.Size = new System.Drawing.Size(234, 130);
            this.lsv1.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblTitle.Location = new System.Drawing.Point(104, 11);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(69, 20);
            this.lblTitle.Text = "Alterar";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pctDeletar
            // 
            this.pctDeletar.Image = ((System.Drawing.Image)(resources.GetObject("pctDeletar.Image")));
            this.pctDeletar.Location = new System.Drawing.Point(73, 6);
            this.pctDeletar.Name = "pctDeletar";
            this.pctDeletar.Size = new System.Drawing.Size(25, 25);
            this.pctDeletar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctDeletar.Visible = false;
            // 
            // frmAlterarDeletarItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.ControlBox = false;
            this.Controls.Add(this.pctDeletar);
            this.Controls.Add(this.lsv1);
            this.Controls.Add(this.pctAlterar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnTodosItens);
            this.Controls.Add(this.btnItemSelecionado);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.lblMessage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Menu = this.mnm1;
            this.Name = "frmAlterarDeletarItem";
            this.Text = "Alterar Item";
            this.Load += new System.EventHandler(this.MyMessageBox_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MainMenu mnm1;
        private System.Windows.Forms.MenuItem mni1;
        private System.Windows.Forms.MenuItem mni2;
        public System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.PictureBox pctAlterar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnTodosItens;
        private System.Windows.Forms.Button btnItemSelecionado;
        public System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.ListView lsv1;
        public System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pctDeletar;

    }
}