namespace Solucoes_Rede_Neural_CSNet
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
            this.btnSair.Location = new System.Drawing.Point(552, 95);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(197, 21);
            this.btnSair.TabIndex = 12;
            this.btnSair.Text = "&Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnRemover
            // 
            this.btnRemover.Location = new System.Drawing.Point(552, 67);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(197, 22);
            this.btnRemover.TabIndex = 11;
            this.btnRemover.Text = "&Remover";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // txt1
            // 
            this.txt1.Location = new System.Drawing.Point(552, 13);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(197, 20);
            this.txt1.TabIndex = 10;
            // 
            // lstv1
            // 
            this.lstv1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lstv1.Location = new System.Drawing.Point(12, 13);
            this.lstv1.Name = "lstv1";
            this.lstv1.Size = new System.Drawing.Size(534, 243);
            this.lstv1.TabIndex = 9;
            this.lstv1.UseCompatibleStateImageBehavior = false;
            // 
            // btnCriar
            // 
            this.btnCriar.Location = new System.Drawing.Point(552, 39);
            this.btnCriar.Name = "btnCriar";
            this.btnCriar.Size = new System.Drawing.Size(197, 22);
            this.btnCriar.TabIndex = 8;
            this.btnCriar.Text = "&Criar";
            this.btnCriar.UseVisualStyleBackColor = true;
            this.btnCriar.Click += new System.EventHandler(this.btnCriar_Click);
            // 
            // frmSubVisualizador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(761, 269);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.txt1);
            this.Controls.Add(this.lstv1);
            this.Controls.Add(this.btnCriar);
            this.Name = "frmSubVisualizador";
            this.Text = "frmSubVisualizador";
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