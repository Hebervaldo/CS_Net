using System.Windows.Forms;

namespace Solucoes_Rede_Neural_CSCoreNet
{
    partial class frmSubVisualizador
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
            this.btnSair = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.txt1 = new System.Windows.Forms.TextBox();
            this.lstv1 = new System.Windows.Forms.ListView();
            this.btnCriar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(519, 107);
            this.btnSair.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(230, 24);
            this.btnSair.TabIndex = 12;
            this.btnSair.Text = "&Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnRemover
            // 
            this.btnRemover.Location = new System.Drawing.Point(519, 74);
            this.btnRemover.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(230, 25);
            this.btnRemover.TabIndex = 11;
            this.btnRemover.Text = "&Remover";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // txt1
            // 
            this.txt1.Location = new System.Drawing.Point(519, 12);
            this.txt1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(229, 23);
            this.txt1.TabIndex = 10;
            // 
            // lstv1
            // 
            this.lstv1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lstv1.Location = new System.Drawing.Point(14, 15);
            this.lstv1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lstv1.Name = "lstv1";
            this.lstv1.Size = new System.Drawing.Size(497, 242);
            this.lstv1.TabIndex = 9;
            this.lstv1.UseCompatibleStateImageBehavior = false;
            // 
            // btnCriar
            // 
            this.btnCriar.Location = new System.Drawing.Point(519, 42);
            this.btnCriar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCriar.Name = "btnCriar";
            this.btnCriar.Size = new System.Drawing.Size(230, 25);
            this.btnCriar.TabIndex = 8;
            this.btnCriar.Text = "&Criar";
            this.btnCriar.UseVisualStyleBackColor = true;
            this.btnCriar.Click += new System.EventHandler(this.btnCriar_Click);
            // 
            // frmSubVisualizador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(761, 269);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.txt1);
            this.Controls.Add(this.lstv1);
            this.Controls.Add(this.btnCriar);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmSubVisualizador";
            this.Text = "Fornecer as Colunas";
            this.Load += new System.EventHandler(this.frmSubVisualizador_Load);
            this.SizeChanged += new System.EventHandler(this.frmSubVisualizador_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnSair;
        internal System.Windows.Forms.Button btnRemover;
        internal System.Windows.Forms.TextBox txt1;
        internal System.Windows.Forms.ListView lstv1;
        internal System.Windows.Forms.Button btnCriar;
    }
}