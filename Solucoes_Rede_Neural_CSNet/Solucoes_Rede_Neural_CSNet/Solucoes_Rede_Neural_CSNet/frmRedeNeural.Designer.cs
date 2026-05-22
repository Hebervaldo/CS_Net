using System.Windows.Forms;

namespace Solucoes_Rede_Neural_CSNet
{
    partial class frmRedeNeural: Form
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
            this.cmb5 = new System.Windows.Forms.ComboBox();
            this.tslbl7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl12 = new System.Windows.Forms.Label();
            this.txt3 = new System.Windows.Forms.TextBox();
            this.btnExecutar = new System.Windows.Forms.Button();
            this.pgbr1 = new System.Windows.Forms.ProgressBar();
            this.grpb1 = new System.Windows.Forms.GroupBox();
            this.lbl2 = new System.Windows.Forms.Label();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnAbortar = new System.Windows.Forms.Button();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl10 = new System.Windows.Forms.Label();
            this.lbl11 = new System.Windows.Forms.Label();
            this.tslbl4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txt2 = new System.Windows.Forms.TextBox();
            this.tslbl5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslbl3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslbl6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl8 = new System.Windows.Forms.Label();
            this.tslbl2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ststrp1 = new System.Windows.Forms.StatusStrip();
            this.tslbl1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslbl8 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnET = new System.Windows.Forms.Button();
            this.btnR = new System.Windows.Forms.Button();
            this.lbl9 = new System.Windows.Forms.Label();
            this.btnT = new System.Windows.Forms.Button();
            this.btnP = new System.Windows.Forms.Button();
            this.btnE = new System.Windows.Forms.Button();
            this.grpb2 = new System.Windows.Forms.GroupBox();
            this.txt1 = new System.Windows.Forms.TextBox();
            this.cmb4 = new System.Windows.Forms.ComboBox();
            this.lbl7 = new System.Windows.Forms.Label();
            this.cmb3 = new System.Windows.Forms.ComboBox();
            this.lbl6 = new System.Windows.Forms.Label();
            this.cmb2 = new System.Windows.Forms.ComboBox();
            this.lbl5 = new System.Windows.Forms.Label();
            this.cmb1 = new System.Windows.Forms.ComboBox();
            this.grpb1.SuspendLayout();
            this.ststrp1.SuspendLayout();
            this.grpb2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmb5
            // 
            this.cmb5.BackColor = System.Drawing.SystemColors.Window;
            this.cmb5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb5.FormattingEnabled = true;
            this.cmb5.Location = new System.Drawing.Point(53, 90);
            this.cmb5.Name = "cmb5";
            this.cmb5.Size = new System.Drawing.Size(142, 21);
            this.cmb5.TabIndex = 35;
            this.cmb5.SelectedValueChanged += new System.EventHandler(this.cmb5_SelectedValueChanged);
            // 
            // tslbl7
            // 
            this.tslbl7.Name = "tslbl7";
            this.tslbl7.Size = new System.Drawing.Size(40, 17);
            this.tslbl7.Text = "Altura:";
            // 
            // lbl12
            // 
            this.lbl12.AutoSize = true;
            this.lbl12.Location = new System.Drawing.Point(6, 93);
            this.lbl12.Name = "lbl12";
            this.lbl12.Size = new System.Drawing.Size(41, 13);
            this.lbl12.TabIndex = 34;
            this.lbl12.Text = "Tarefa:";
            // 
            // txt3
            // 
            this.txt3.BackColor = System.Drawing.SystemColors.Window;
            this.txt3.Location = new System.Drawing.Point(102, 42);
            this.txt3.Name = "txt3";
            this.txt3.Size = new System.Drawing.Size(137, 20);
            this.txt3.TabIndex = 30;
            this.txt3.Text = "2";
            // 
            // btnExecutar
            // 
            this.btnExecutar.Location = new System.Drawing.Point(6, 63);
            this.btnExecutar.Name = "btnExecutar";
            this.btnExecutar.Size = new System.Drawing.Size(135, 21);
            this.btnExecutar.TabIndex = 2;
            this.btnExecutar.Text = "&Executar";
            this.btnExecutar.UseVisualStyleBackColor = true;
            this.btnExecutar.Click += new System.EventHandler(this.btnExecutar_Click);
            // 
            // pgbr1
            // 
            this.pgbr1.BackColor = System.Drawing.SystemColors.Info;
            this.pgbr1.Location = new System.Drawing.Point(18, 32);
            this.pgbr1.Name = "pgbr1";
            this.pgbr1.Size = new System.Drawing.Size(214, 13);
            this.pgbr1.TabIndex = 8;
            // 
            // grpb1
            // 
            this.grpb1.BackColor = System.Drawing.SystemColors.Control;
            this.grpb1.Controls.Add(this.cmb5);
            this.grpb1.Controls.Add(this.lbl12);
            this.grpb1.Controls.Add(this.btnExecutar);
            this.grpb1.Controls.Add(this.pgbr1);
            this.grpb1.Controls.Add(this.lbl2);
            this.grpb1.Controls.Add(this.btnSair);
            this.grpb1.Controls.Add(this.btnAbortar);
            this.grpb1.Controls.Add(this.lbl4);
            this.grpb1.Controls.Add(this.lbl3);
            this.grpb1.Location = new System.Drawing.Point(12, 261);
            this.grpb1.Name = "grpb1";
            this.grpb1.Size = new System.Drawing.Size(437, 119);
            this.grpb1.TabIndex = 22;
            this.grpb1.TabStop = false;
            this.grpb1.Text = "Andamento";
            // 
            // lbl2
            // 
            this.lbl2.BackColor = System.Drawing.SystemColors.Control;
            this.lbl2.Location = new System.Drawing.Point(147, 16);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(85, 13);
            this.lbl2.TabIndex = 13;
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(292, 63);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(135, 21);
            this.btnSair.TabIndex = 17;
            this.btnSair.Text = "&Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnAbortar
            // 
            this.btnAbortar.Location = new System.Drawing.Point(151, 63);
            this.btnAbortar.Name = "btnAbortar";
            this.btnAbortar.Size = new System.Drawing.Size(135, 21);
            this.btnAbortar.TabIndex = 14;
            this.btnAbortar.Text = "&Abortar";
            this.btnAbortar.UseVisualStyleBackColor = true;
            this.btnAbortar.Click += new System.EventHandler(this.btnAbortar_Click);
            // 
            // lbl4
            // 
            this.lbl4.BackColor = System.Drawing.SystemColors.Control;
            this.lbl4.Location = new System.Drawing.Point(6, 48);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(421, 13);
            this.lbl4.TabIndex = 16;
            this.lbl4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(17, 16);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(124, 13);
            this.lbl3.TabIndex = 15;
            this.lbl3.Text = "Porcentagem concluída:";
            // 
            // lbl10
            // 
            this.lbl10.AutoSize = true;
            this.lbl10.Location = new System.Drawing.Point(10, 49);
            this.lbl10.Name = "lbl10";
            this.lbl10.Size = new System.Drawing.Size(86, 13);
            this.lbl10.TabIndex = 31;
            this.lbl10.Text = "N° de neurônios:";
            // 
            // lbl11
            // 
            this.lbl11.AutoSize = true;
            this.lbl11.Location = new System.Drawing.Point(245, 20);
            this.lbl11.Name = "lbl11";
            this.lbl11.Size = new System.Drawing.Size(29, 13);
            this.lbl11.TabIndex = 29;
            this.lbl11.Text = "Erro:";
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
            // txt2
            // 
            this.txt2.BackColor = System.Drawing.SystemColors.Window;
            this.txt2.Location = new System.Drawing.Point(280, 13);
            this.txt2.Name = "txt2";
            this.txt2.Size = new System.Drawing.Size(150, 20);
            this.txt2.TabIndex = 28;
            this.txt2.Text = "0,004";
            // 
            // tslbl5
            // 
            this.tslbl5.Name = "tslbl5";
            this.tslbl5.Size = new System.Drawing.Size(74, 17);
            this.tslbl5.Text = "Comprimento:";
            // 
            // tslbl3
            // 
            this.tslbl3.Name = "tslbl3";
            this.tslbl3.Size = new System.Drawing.Size(17, 17);
            this.tslbl3.Text = "Y:";
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
            // lbl8
            // 
            this.lbl8.AutoSize = true;
            this.lbl8.Location = new System.Drawing.Point(10, 166);
            this.lbl8.Name = "lbl8";
            this.lbl8.Size = new System.Drawing.Size(109, 13);
            this.lbl8.TabIndex = 26;
            this.lbl8.Text = "Prioridade do cálculo:";
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
            this.ststrp1.Location = new System.Drawing.Point(0, 392);
            this.ststrp1.Name = "ststrp1";
            this.ststrp1.Size = new System.Drawing.Size(460, 22);
            this.ststrp1.TabIndex = 24;
            this.ststrp1.Text = "StatusStrip1";
            // 
            // tslbl1
            // 
            this.tslbl1.Name = "tslbl1";
            this.tslbl1.Size = new System.Drawing.Size(17, 17);
            this.tslbl1.Text = "X:";
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
            // btnET
            // 
            this.btnET.Location = new System.Drawing.Point(6, 189);
            this.btnET.Name = "btnET";
            this.btnET.Size = new System.Drawing.Size(135, 21);
            this.btnET.TabIndex = 4;
            this.btnET.Text = "&EntradasTreinamento";
            this.btnET.UseVisualStyleBackColor = true;
            this.btnET.Click += new System.EventHandler(this.btnET_Click);
            // 
            // btnR
            // 
            this.btnR.Location = new System.Drawing.Point(151, 216);
            this.btnR.Name = "btnR";
            this.btnR.Size = new System.Drawing.Size(135, 21);
            this.btnR.TabIndex = 18;
            this.btnR.Text = "&Resultado";
            this.btnR.UseVisualStyleBackColor = true;
            this.btnR.Click += new System.EventHandler(this.btnR_Click);
            // 
            // lbl9
            // 
            this.lbl9.AutoSize = true;
            this.lbl9.Location = new System.Drawing.Point(10, 20);
            this.lbl9.Name = "lbl9";
            this.lbl9.Size = new System.Drawing.Size(54, 13);
            this.lbl9.TabIndex = 11;
            this.lbl9.Text = "Iterações:";
            // 
            // btnT
            // 
            this.btnT.Location = new System.Drawing.Point(151, 189);
            this.btnT.Name = "btnT";
            this.btnT.Size = new System.Drawing.Size(135, 21);
            this.btnT.TabIndex = 5;
            this.btnT.Text = "&Target";
            this.btnT.UseVisualStyleBackColor = true;
            this.btnT.Click += new System.EventHandler(this.btnT_Click);
            // 
            // btnP
            // 
            this.btnP.Location = new System.Drawing.Point(292, 189);
            this.btnP.Name = "btnP";
            this.btnP.Size = new System.Drawing.Size(135, 21);
            this.btnP.TabIndex = 6;
            this.btnP.Text = "&Pesos";
            this.btnP.UseVisualStyleBackColor = true;
            this.btnP.Click += new System.EventHandler(this.btnP_Click);
            // 
            // btnE
            // 
            this.btnE.Location = new System.Drawing.Point(6, 216);
            this.btnE.Name = "btnE";
            this.btnE.Size = new System.Drawing.Size(135, 21);
            this.btnE.TabIndex = 7;
            this.btnE.Text = "&Erro";
            this.btnE.UseVisualStyleBackColor = true;
            this.btnE.Click += new System.EventHandler(this.btnE_Click);
            // 
            // grpb2
            // 
            this.grpb2.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.grpb2.Controls.Add(this.txt3);
            this.grpb2.Controls.Add(this.lbl10);
            this.grpb2.Controls.Add(this.lbl11);
            this.grpb2.Controls.Add(this.txt2);
            this.grpb2.Controls.Add(this.lbl8);
            this.grpb2.Controls.Add(this.txt1);
            this.grpb2.Controls.Add(this.cmb4);
            this.grpb2.Controls.Add(this.lbl7);
            this.grpb2.Controls.Add(this.cmb3);
            this.grpb2.Controls.Add(this.lbl6);
            this.grpb2.Controls.Add(this.cmb2);
            this.grpb2.Controls.Add(this.lbl5);
            this.grpb2.Controls.Add(this.cmb1);
            this.grpb2.Controls.Add(this.lbl9);
            this.grpb2.Controls.Add(this.btnET);
            this.grpb2.Controls.Add(this.btnR);
            this.grpb2.Controls.Add(this.btnT);
            this.grpb2.Controls.Add(this.btnP);
            this.grpb2.Controls.Add(this.btnE);
            this.grpb2.Location = new System.Drawing.Point(12, 12);
            this.grpb2.Name = "grpb2";
            this.grpb2.Size = new System.Drawing.Size(437, 243);
            this.grpb2.TabIndex = 23;
            this.grpb2.TabStop = false;
            this.grpb2.Text = "Controle";
            // 
            // txt1
            // 
            this.txt1.BackColor = System.Drawing.SystemColors.Window;
            this.txt1.Location = new System.Drawing.Point(76, 13);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(163, 20);
            this.txt1.TabIndex = 3;
            this.txt1.Text = "1000";
            // 
            // cmb4
            // 
            this.cmb4.BackColor = System.Drawing.SystemColors.Window;
            this.cmb4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb4.FormattingEnabled = true;
            this.cmb4.Location = new System.Drawing.Point(138, 158);
            this.cmb4.Name = "cmb4";
            this.cmb4.Size = new System.Drawing.Size(292, 21);
            this.cmb4.TabIndex = 27;
            this.cmb4.SelectedValueChanged += new System.EventHandler(this.cmb4_SelectedValueChanged);
            // 
            // lbl7
            // 
            this.lbl7.AutoSize = true;
            this.lbl7.Location = new System.Drawing.Point(10, 139);
            this.lbl7.Name = "lbl7";
            this.lbl7.Size = new System.Drawing.Size(85, 13);
            this.lbl7.TabIndex = 24;
            this.lbl7.Text = "Escolha o Delta:";
            // 
            // cmb3
            // 
            this.cmb3.BackColor = System.Drawing.SystemColors.Window;
            this.cmb3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb3.FormattingEnabled = true;
            this.cmb3.Location = new System.Drawing.Point(138, 131);
            this.cmb3.Name = "cmb3";
            this.cmb3.Size = new System.Drawing.Size(292, 21);
            this.cmb3.TabIndex = 25;
            this.cmb3.SelectedValueChanged += new System.EventHandler(this.cmb3_SelectedValueChanged);
            // 
            // lbl6
            // 
            this.lbl6.AutoSize = true;
            this.lbl6.Location = new System.Drawing.Point(10, 85);
            this.lbl6.Name = "lbl6";
            this.lbl6.Size = new System.Drawing.Size(122, 13);
            this.lbl6.TabIndex = 22;
            this.lbl6.Text = "Escolha o tipo de saída:";
            // 
            // cmb2
            // 
            this.cmb2.BackColor = System.Drawing.SystemColors.Window;
            this.cmb2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb2.FormattingEnabled = true;
            this.cmb2.Location = new System.Drawing.Point(138, 104);
            this.cmb2.Name = "cmb2";
            this.cmb2.Size = new System.Drawing.Size(292, 21);
            this.cmb2.TabIndex = 23;
            this.cmb2.SelectedValueChanged += new System.EventHandler(this.cmb2_SelectedValueChanged);
            // 
            // lbl5
            // 
            this.lbl5.AutoSize = true;
            this.lbl5.Location = new System.Drawing.Point(10, 112);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(113, 13);
            this.lbl5.TabIndex = 19;
            this.lbl5.Text = "Escolha o tipo de erro:";
            // 
            // cmb1
            // 
            this.cmb1.BackColor = System.Drawing.SystemColors.Window;
            this.cmb1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb1.FormattingEnabled = true;
            this.cmb1.Location = new System.Drawing.Point(138, 77);
            this.cmb1.Name = "cmb1";
            this.cmb1.Size = new System.Drawing.Size(292, 21);
            this.cmb1.TabIndex = 21;
            this.cmb1.SelectedValueChanged += new System.EventHandler(this.cmb1_SelectedValueChanged);
            // 
            // frmRedeNeural
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(460, 414);
            this.Controls.Add(this.grpb1);
            this.Controls.Add(this.ststrp1);
            this.Controls.Add(this.grpb2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmRedeNeural";
            this.Text = "Rede Neural";
            this.Load += new System.EventHandler(this.frmRedeNeural_Load);
            this.grpb1.ResumeLayout(false);
            this.grpb1.PerformLayout();
            this.ststrp1.ResumeLayout(false);
            this.ststrp1.PerformLayout();
            this.grpb2.ResumeLayout(false);
            this.grpb2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal ComboBox cmb5;
        internal ToolStripStatusLabel tslbl7;
        internal Label lbl12;
        private TextBox txt3;
        private Button btnExecutar;
        internal ProgressBar pgbr1;
        internal GroupBox grpb1;
        internal Label lbl2;
        private Button btnSair;
        private Button btnAbortar;
        internal Label lbl4;
        internal Label lbl3;
        internal Label lbl10;
        internal Label lbl11;
        internal ToolStripStatusLabel tslbl4;
        private TextBox txt2;
        internal ToolStripStatusLabel tslbl5;
        internal ToolStripStatusLabel tslbl3;
        internal ToolStripStatusLabel tslbl6;
        internal Label lbl8;
        internal ToolStripStatusLabel tslbl2;
        internal StatusStrip ststrp1;
        internal ToolStripStatusLabel tslbl1;
        internal ToolStripStatusLabel tslbl8;
        private Button btnET;
        private Button btnR;
        internal Label lbl9;
        private Button btnT;
        private Button btnP;
        private Button btnE;
        internal GroupBox grpb2;
        private TextBox txt1;
        internal ComboBox cmb4;
        internal Label lbl7;
        internal ComboBox cmb3;
        internal Label lbl6;
        internal ComboBox cmb2;
        internal Label lbl5;
        internal ComboBox cmb1;
    }
}