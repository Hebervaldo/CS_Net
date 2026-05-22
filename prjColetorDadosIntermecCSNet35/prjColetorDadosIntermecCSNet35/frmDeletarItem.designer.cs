namespace prjColetorDadosIntermecCSNet35
{
    partial class frmDeletarItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDeletarItem));
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnItemSelecionado = new System.Windows.Forms.Button();
            this.btnTodosItens = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pct1 = new System.Windows.Forms.PictureBox();
            this.lsv1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblMessage.ForeColor = System.Drawing.Color.Gray;
            this.lblMessage.Location = new System.Drawing.Point(3, 542);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(491, 41);
            this.lblMessage.Text = "Selecione as opções abaixo:";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTimer
            // 
            this.lblTimer.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblTimer.ForeColor = System.Drawing.Color.Maroon;
            this.lblTimer.Location = new System.Drawing.Point(3, 724);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(491, 41);
            this.lblTimer.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblTitle.Location = new System.Drawing.Point(50, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(444, 41);
            this.lblTitle.Text = "Deletar";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnItemSelecionado
            // 
            this.btnItemSelecionado.BackColor = System.Drawing.Color.White;
            this.btnItemSelecionado.ForeColor = System.Drawing.Color.DimGray;
            this.btnItemSelecionado.Location = new System.Drawing.Point(3, 586);
            this.btnItemSelecionado.Name = "btnItemSelecionado";
            this.btnItemSelecionado.Size = new System.Drawing.Size(491, 41);
            this.btnItemSelecionado.TabIndex = 3;
            this.btnItemSelecionado.Text = "&Item Selecionado";
            this.btnItemSelecionado.Click += new System.EventHandler(this.btnItemSelecionado_Click);
            // 
            // btnTodosItens
            // 
            this.btnTodosItens.BackColor = System.Drawing.Color.White;
            this.btnTodosItens.ForeColor = System.Drawing.Color.DimGray;
            this.btnTodosItens.Location = new System.Drawing.Point(3, 633);
            this.btnTodosItens.Name = "btnTodosItens";
            this.btnTodosItens.Size = new System.Drawing.Size(491, 41);
            this.btnTodosItens.TabIndex = 4;
            this.btnTodosItens.Text = "&Todos os Itens";
            this.btnTodosItens.Click += new System.EventHandler(this.btnTodosItens_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.ForeColor = System.Drawing.Color.DimGray;
            this.btnCancelar.Location = new System.Drawing.Point(3, 680);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(491, 41);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // pct1
            // 
            this.pct1.Image = ((System.Drawing.Image)(resources.GetObject("pct1.Image")));
            this.pct1.Location = new System.Drawing.Point(3, 3);
            this.pct1.Name = "pct1";
            this.pct1.Size = new System.Drawing.Size(41, 41);
            this.pct1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // lsv1
            // 
            this.lsv1.CheckBoxes = true;
            this.lsv1.Location = new System.Drawing.Point(3, 47);
            this.lsv1.Name = "lsv1";
            this.lsv1.Size = new System.Drawing.Size(491, 492);
            this.lsv1.TabIndex = 9;
            // 
            // frmDeletarItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(497, 765);
            this.ControlBox = false;
            this.Controls.Add(this.lsv1);
            this.Controls.Add(this.pct1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnTodosItens);
            this.Controls.Add(this.btnItemSelecionado);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.lblMessage);
            this.Location = new System.Drawing.Point(0, 52);
            this.Name = "frmDeletarItem";
            this.Text = "Deletar Item";
            this.Load += new System.EventHandler(this.MyMessageBox_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label lblMessage;
        public System.Windows.Forms.Label lblTimer;
        public System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnItemSelecionado;
        private System.Windows.Forms.Button btnTodosItens;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.PictureBox pct1;
        private System.Windows.Forms.ListView lsv1;

    }
}