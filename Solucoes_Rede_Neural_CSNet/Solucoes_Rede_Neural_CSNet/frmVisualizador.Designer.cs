using System.Windows.Forms;

namespace Solucoes_Rede_Neural_CSNet
{
    partial class frmVisualizador
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

        // Flag que indica que não queremos o botão fechar.
        private const int CP_NOCLOSE_BUTTON = 0x200;

        protected override CreateParams CreateParams
        {
            get
            {
                // Obtém as flags atuais
                CreateParams parametros = base.CreateParams;
                // Adiciona a flag que indica que o "X" não deve ser mostrado
                parametros.ClassStyle = parametros.ClassStyle | CP_NOCLOSE_BUTTON;
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
            this.dtgv1 = new System.Windows.Forms.DataGridView();
            this.tslbl3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslbl4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslbl5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslbl6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslbl7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslbl2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslbl1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ststrp1 = new System.Windows.Forms.StatusStrip();
            this.tslbl8 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnAjustar = new System.Windows.Forms.Button();
            this.btnLer = new System.Windows.Forms.Button();
            this.btnCadastrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv1)).BeginInit();
            this.ststrp1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgv1
            // 
            this.dtgv1.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dtgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv1.Location = new System.Drawing.Point(12, 6);
            this.dtgv1.Name = "dtgv1";
            this.dtgv1.Size = new System.Drawing.Size(570, 223);
            this.dtgv1.TabIndex = 15;
            this.dtgv1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv1_CellClick);
            // 
            // tslbl3
            // 
            this.tslbl3.Name = "tslbl3";
            this.tslbl3.Size = new System.Drawing.Size(99, 17);
            this.tslbl3.Text = "Total de Colunas:";
            // 
            // tslbl4
            // 
            this.tslbl4.AutoSize = false;
            this.tslbl4.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tslbl4.Name = "tslbl4";
            this.tslbl4.Size = new System.Drawing.Size(50, 17);
            // 
            // tslbl5
            // 
            this.tslbl5.Name = "tslbl5";
            this.tslbl5.Size = new System.Drawing.Size(105, 17);
            this.tslbl5.Text = "Linha Selecionada:";
            // 
            // tslbl6
            // 
            this.tslbl6.AutoSize = false;
            this.tslbl6.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tslbl6.Name = "tslbl6";
            this.tslbl6.Size = new System.Drawing.Size(50, 17);
            // 
            // tslbl7
            // 
            this.tslbl7.Name = "tslbl7";
            this.tslbl7.Size = new System.Drawing.Size(114, 17);
            this.tslbl7.Text = "Coluna Selecionada:";
            // 
            // tslbl2
            // 
            this.tslbl2.AutoSize = false;
            this.tslbl2.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tslbl2.Name = "tslbl2";
            this.tslbl2.Size = new System.Drawing.Size(50, 17);
            // 
            // tslbl1
            // 
            this.tslbl1.Name = "tslbl1";
            this.tslbl1.Size = new System.Drawing.Size(90, 17);
            this.tslbl1.Text = "Total de Linhas:";
            // 
            // ststrp1
            // 
            this.ststrp1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslbl1,
            this.tslbl2,
            this.tslbl3,
            this.tslbl4,
            this.tslbl5,
            this.tslbl6,
            this.tslbl7,
            this.tslbl8});
            this.ststrp1.Location = new System.Drawing.Point(0, 268);
            this.ststrp1.Name = "ststrp1";
            this.ststrp1.Size = new System.Drawing.Size(593, 22);
            this.ststrp1.TabIndex = 20;
            this.ststrp1.Text = "StatusStrip1";
            // 
            // tslbl8
            // 
            this.tslbl8.AutoSize = false;
            this.tslbl8.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tslbl8.Name = "tslbl8";
            this.tslbl8.Size = new System.Drawing.Size(50, 17);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(500, 235);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(82, 22);
            this.btnSair.TabIndex = 19;
            this.btnSair.Text = "&Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnAjustar
            // 
            this.btnAjustar.Location = new System.Drawing.Point(236, 235);
            this.btnAjustar.Name = "btnAjustar";
            this.btnAjustar.Size = new System.Drawing.Size(82, 22);
            this.btnAjustar.TabIndex = 18;
            this.btnAjustar.Text = "&Ajustar";
            this.btnAjustar.UseVisualStyleBackColor = true;
            this.btnAjustar.Click += new System.EventHandler(this.btnAjustar_Click);
            // 
            // btnLer
            // 
            this.btnLer.Location = new System.Drawing.Point(324, 235);
            this.btnLer.Name = "btnLer";
            this.btnLer.Size = new System.Drawing.Size(82, 22);
            this.btnLer.TabIndex = 17;
            this.btnLer.Text = "&Ler";
            this.btnLer.UseVisualStyleBackColor = true;
            this.btnLer.Click += new System.EventHandler(this.btnLer_Click);
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Location = new System.Drawing.Point(412, 235);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(82, 22);
            this.btnCadastrar.TabIndex = 16;
            this.btnCadastrar.Text = "&Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // frmVisualizador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(593, 290);
            this.Controls.Add(this.dtgv1);
            this.Controls.Add(this.ststrp1);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnAjustar);
            this.Controls.Add(this.btnLer);
            this.Controls.Add(this.btnCadastrar);
            this.Name = "frmVisualizador";
            this.Text = "Tabela de Dados";
            this.Load += new System.EventHandler(this.frmVisualizador_Load);
            this.SizeChanged += new System.EventHandler(this.frmVisualizador_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv1)).EndInit();
            this.ststrp1.ResumeLayout(false);
            this.ststrp1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.DataGridView dtgv1;
        internal System.Windows.Forms.ToolStripStatusLabel tslbl3;
        internal System.Windows.Forms.ToolStripStatusLabel tslbl4;
        internal System.Windows.Forms.ToolStripStatusLabel tslbl5;
        internal System.Windows.Forms.ToolStripStatusLabel tslbl6;
        internal System.Windows.Forms.ToolStripStatusLabel tslbl7;
        internal System.Windows.Forms.ToolStripStatusLabel tslbl2;
        internal System.Windows.Forms.ToolStripStatusLabel tslbl1;
        internal System.Windows.Forms.StatusStrip ststrp1;
        internal System.Windows.Forms.ToolStripStatusLabel tslbl8;
        internal System.Windows.Forms.Button btnSair;
        internal System.Windows.Forms.Button btnAjustar;
        internal System.Windows.Forms.Button btnLer;
        internal System.Windows.Forms.Button btnCadastrar;
    }
}