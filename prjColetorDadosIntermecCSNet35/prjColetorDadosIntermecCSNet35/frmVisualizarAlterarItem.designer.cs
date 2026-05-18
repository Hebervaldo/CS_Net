namespace prjColetorDadosIntermecCSNet35
{
    partial class frmVisualizarAlterarItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVisualizarAlterarItem));
            this.mnm1 = new System.Windows.Forms.MainMenu();
            this.mni1 = new System.Windows.Forms.MenuItem();
            this.mni2 = new System.Windows.Forms.MenuItem();
            this.tbc1 = new System.Windows.Forms.TabControl();
            this.tbpItem = new System.Windows.Forms.TabPage();
            this.chkHabilitarCmbCampo2 = new System.Windows.Forms.CheckBox();
            this.cmbCampo2 = new System.Windows.Forms.ComboBox();
            this.txtDado2 = new System.Windows.Forms.TextBox();
            this.txtNumeroInventario = new System.Windows.Forms.Label();
            this.txtPatrimonioItem = new System.Windows.Forms.Label();
            this.lblNumeroInventario = new System.Windows.Forms.Label();
            this.lblPatrimonioItem = new System.Windows.Forms.Label();
            this.cmbCampo1 = new System.Windows.Forms.ComboBox();
            this.txtDado1 = new System.Windows.Forms.TextBox();
            this.tbpLista = new System.Windows.Forms.TabPage();
            this.lsv1 = new System.Windows.Forms.ListView();
            this.btnTodosItens = new System.Windows.Forms.Button();
            this.btnItemSelecionado = new System.Windows.Forms.Button();
            this.tbc1.SuspendLayout();
            this.tbpItem.SuspendLayout();
            this.tbpLista.SuspendLayout();
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
            this.mni2.Text = "Sair";
            this.mni2.Click += new System.EventHandler(this.mni2_Click);
            // 
            // tbc1
            // 
            this.tbc1.Controls.Add(this.tbpItem);
            this.tbc1.Controls.Add(this.tbpLista);
            this.tbc1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbc1.Location = new System.Drawing.Point(0, 0);
            this.tbc1.Name = "tbc1";
            this.tbc1.SelectedIndex = 0;
            this.tbc1.Size = new System.Drawing.Size(480, 696);
            this.tbc1.TabIndex = 0;
            // 
            // tbpItem
            // 
            this.tbpItem.Controls.Add(this.chkHabilitarCmbCampo2);
            this.tbpItem.Controls.Add(this.cmbCampo2);
            this.tbpItem.Controls.Add(this.txtDado2);
            this.tbpItem.Controls.Add(this.txtNumeroInventario);
            this.tbpItem.Controls.Add(this.txtPatrimonioItem);
            this.tbpItem.Controls.Add(this.lblNumeroInventario);
            this.tbpItem.Controls.Add(this.lblPatrimonioItem);
            this.tbpItem.Controls.Add(this.cmbCampo1);
            this.tbpItem.Controls.Add(this.txtDado1);
            this.tbpItem.Location = new System.Drawing.Point(0, 0);
            this.tbpItem.Name = "tbpItem";
            this.tbpItem.Size = new System.Drawing.Size(480, 652);
            this.tbpItem.Text = "Item";
            // 
            // chkHabilitarCmbCampo2
            // 
            this.chkHabilitarCmbCampo2.Location = new System.Drawing.Point(432, 277);
            this.chkHabilitarCmbCampo2.Name = "chkHabilitarCmbCampo2";
            this.chkHabilitarCmbCampo2.Size = new System.Drawing.Size(41, 41);
            this.chkHabilitarCmbCampo2.TabIndex = 4;
            this.chkHabilitarCmbCampo2.CheckStateChanged += new System.EventHandler(this.chkHabilitarCmbCampo2_CheckStateChanged);
            // 
            // cmbCampo2
            // 
            this.cmbCampo2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.cmbCampo2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.cmbCampo2.Location = new System.Drawing.Point(7, 273);
            this.cmbCampo2.Name = "cmbCampo2";
            this.cmbCampo2.Size = new System.Drawing.Size(419, 45);
            this.cmbCampo2.TabIndex = 3;
            this.cmbCampo2.GotFocus += new System.EventHandler(this.cmbCampo2_GotFocus);
            this.cmbCampo2.TextChanged += new System.EventHandler(this.cmbCampo2_TextChanged);
            // 
            // txtDado2
            // 
            this.txtDado2.Location = new System.Drawing.Point(7, 324);
            this.txtDado2.Multiline = true;
            this.txtDado2.Name = "txtDado2";
            this.txtDado2.Size = new System.Drawing.Size(466, 45);
            this.txtDado2.TabIndex = 5;
            this.txtDado2.LostFocus += new System.EventHandler(this.txtDado2_LostFocus);
            // 
            // txtNumeroInventario
            // 
            this.txtNumeroInventario.BackColor = System.Drawing.Color.White;
            this.txtNumeroInventario.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtNumeroInventario.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNumeroInventario.Location = new System.Drawing.Point(7, 45);
            this.txtNumeroInventario.Name = "txtNumeroInventario";
            this.txtNumeroInventario.Size = new System.Drawing.Size(466, 41);
            this.txtNumeroInventario.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtPatrimonioItem
            // 
            this.txtPatrimonioItem.BackColor = System.Drawing.Color.White;
            this.txtPatrimonioItem.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtPatrimonioItem.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPatrimonioItem.Location = new System.Drawing.Point(7, 127);
            this.txtPatrimonioItem.Name = "txtPatrimonioItem";
            this.txtPatrimonioItem.Size = new System.Drawing.Size(466, 41);
            this.txtPatrimonioItem.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblNumeroInventario
            // 
            this.lblNumeroInventario.BackColor = System.Drawing.Color.White;
            this.lblNumeroInventario.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblNumeroInventario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.lblNumeroInventario.Location = new System.Drawing.Point(7, 4);
            this.lblNumeroInventario.Name = "lblNumeroInventario";
            this.lblNumeroInventario.Size = new System.Drawing.Size(466, 41);
            this.lblNumeroInventario.Text = "Número do Inventário";
            this.lblNumeroInventario.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblPatrimonioItem
            // 
            this.lblPatrimonioItem.BackColor = System.Drawing.Color.White;
            this.lblPatrimonioItem.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblPatrimonioItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.lblPatrimonioItem.Location = new System.Drawing.Point(7, 86);
            this.lblPatrimonioItem.Name = "lblPatrimonioItem";
            this.lblPatrimonioItem.Size = new System.Drawing.Size(466, 41);
            this.lblPatrimonioItem.Text = "Patrimônio";
            this.lblPatrimonioItem.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmbCampo1
            // 
            this.cmbCampo1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.cmbCampo1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.cmbCampo1.Location = new System.Drawing.Point(7, 171);
            this.cmbCampo1.Name = "cmbCampo1";
            this.cmbCampo1.Size = new System.Drawing.Size(466, 45);
            this.cmbCampo1.TabIndex = 1;
            this.cmbCampo1.GotFocus += new System.EventHandler(this.cmbCampo1_GotFocus);
            this.cmbCampo1.TextChanged += new System.EventHandler(this.cmbCampo1_TextChanged);
            // 
            // txtDado1
            // 
            this.txtDado1.Location = new System.Drawing.Point(7, 222);
            this.txtDado1.Multiline = true;
            this.txtDado1.Name = "txtDado1";
            this.txtDado1.Size = new System.Drawing.Size(466, 45);
            this.txtDado1.TabIndex = 2;
            this.txtDado1.LostFocus += new System.EventHandler(this.txtDado1_LostFocus);
            // 
            // tbpLista
            // 
            this.tbpLista.Controls.Add(this.lsv1);
            this.tbpLista.Controls.Add(this.btnTodosItens);
            this.tbpLista.Controls.Add(this.btnItemSelecionado);
            this.tbpLista.Location = new System.Drawing.Point(0, 0);
            this.tbpLista.Name = "tbpLista";
            this.tbpLista.Size = new System.Drawing.Size(480, 652);
            this.tbpLista.Text = "Lista";
            // 
            // lsv1
            // 
            this.lsv1.CheckBoxes = true;
            this.lsv1.Location = new System.Drawing.Point(3, 3);
            this.lsv1.Name = "lsv1";
            this.lsv1.Size = new System.Drawing.Size(474, 552);
            this.lsv1.TabIndex = 1;
            this.lsv1.ItemActivate += new System.EventHandler(this.lsv1_ItemActivate);
            // 
            // btnTodosItens
            // 
            this.btnTodosItens.BackColor = System.Drawing.Color.White;
            this.btnTodosItens.ForeColor = System.Drawing.Color.DimGray;
            this.btnTodosItens.Location = new System.Drawing.Point(3, 608);
            this.btnTodosItens.Name = "btnTodosItens";
            this.btnTodosItens.Size = new System.Drawing.Size(474, 41);
            this.btnTodosItens.TabIndex = 3;
            this.btnTodosItens.Text = "&Todos os Itens";
            this.btnTodosItens.Click += new System.EventHandler(this.btnTodosItens_Click);
            // 
            // btnItemSelecionado
            // 
            this.btnItemSelecionado.BackColor = System.Drawing.Color.White;
            this.btnItemSelecionado.ForeColor = System.Drawing.Color.DimGray;
            this.btnItemSelecionado.Location = new System.Drawing.Point(3, 561);
            this.btnItemSelecionado.Name = "btnItemSelecionado";
            this.btnItemSelecionado.Size = new System.Drawing.Size(474, 41);
            this.btnItemSelecionado.TabIndex = 2;
            this.btnItemSelecionado.Text = "&Item Selecionado";
            this.btnItemSelecionado.Click += new System.EventHandler(this.btnItemSelecionado_Click);
            // 
            // frmVisualizarAlterarItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(480, 696);
            this.Controls.Add(this.tbc1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 52);
            this.Menu = this.mnm1;
            this.Name = "frmVisualizarAlterarItem";
            this.Text = "Visualizar Alterar Item";
            this.Load += new System.EventHandler(this.frmVisualizarItem_Load);
            this.tbc1.ResumeLayout(false);
            this.tbpItem.ResumeLayout(false);
            this.tbpLista.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem mni1;
        private System.Windows.Forms.MenuItem mni2;
        private System.Windows.Forms.TabControl tbc1;
        private System.Windows.Forms.TabPage tbpItem;
        private System.Windows.Forms.TabPage tbpLista;
        private System.Windows.Forms.ListView lsv1;
        private System.Windows.Forms.Button btnTodosItens;
        private System.Windows.Forms.Button btnItemSelecionado;
        private System.Windows.Forms.Label txtNumeroInventario;
        private System.Windows.Forms.Label txtPatrimonioItem;
        private System.Windows.Forms.Label lblNumeroInventario;
        private System.Windows.Forms.Label lblPatrimonioItem;
        private System.Windows.Forms.ComboBox cmbCampo1;
        private System.Windows.Forms.TextBox txtDado1;
        private System.Windows.Forms.ComboBox cmbCampo2;
        private System.Windows.Forms.TextBox txtDado2;
        private System.Windows.Forms.CheckBox chkHabilitarCmbCampo2;
    }
}