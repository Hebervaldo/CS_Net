using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BibliotecaTemporaria_CSNet;

namespace Solucoes_Rede_Neural_CSNet
{
    public partial class frmSubVisualizador : Form
    {
        private int dfrmbtntxt1H;
        private int dfrmbtnSairH;
        private int dfrmbtnRemoverH;
        private int dfrmbtnCriarH;
        private int dfrmlstv1V;
        private int dfrmlstv1H;
        private bool varHouveRedimensionamento = false;
        private clsArquivoTXT objArquivoTXT = new clsArquivoTXT();
        private frmRedeNeural objRedeNeural = new frmRedeNeural();
        private int i; 
        public frmSubVisualizador()
        {
            InitializeComponent();
        }

        private void frmSubVisualizador_Load(object sender, EventArgs e)
        {
            lstv1.View = View.Details;
            lstv1.LabelEdit = true;
            lstv1.AllowColumnReorder = true;
            lstv1.CheckBoxes = true;
            lstv1.FullRowSelect = true;
            lstv1.GridLines = true;
            lstv1.Sorting = SortOrder.Ascending;
            lstv1.Columns.Add("Acrescentar Campo", 200, HorizontalAlignment.Left);
            for (i = 0; i <= frmRedeNeural.dtgv.Columns.Count - 1; i += 1)
            {
                lstv1.Items.Add(frmRedeNeural.dtgv.Columns[i].HeaderText);
            }
            this.Controls.Add(lstv1);
            txt1.Text = mtdRotinaNomeCampo() + String.Format((i + 1).ToString(), "000");
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= lstv1.CheckedItems.Count; i++)
            {
                if (lstv1.CheckedItems[0].Checked)
                {
                    lstv1.Items[lstv1.CheckedItems[0].Index].Remove();
                }
            }
            objRedeNeural.RePreencherDataGridView(ref frmRedeNeural.dtgv, ref lstv1);
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            lstv1.Items.Add(txt1.Text);
            objRedeNeural.RePreencherDataGridView(ref frmRedeNeural.dtgv, ref lstv1);
            txt1.Text = mtdRotinaNomeCampo() + string.Format((i + 1).ToString(), "000");
        }
        private string mtdRotinaNomeCampo()
        {
            char chrChr = '\0';
            string strStr = string.Empty;
            string strStrAux = string.Empty;
            string strNumeros = "0123456789";
            i = frmRedeNeural.dtgv.Columns.Count;
            strStrAux = lstv1.Text;
            for (int j = 0; j <= strStrAux.Length - 1; j++)
            {
                chrChr = Convert.ToChar(strStrAux.Substring(j, 1));
                if (!strNumeros.Contains(Convert.ToString(chrChr)))
                {
                    strStr += chrChr;
                }
            }
            return strStr;
        }

        private void mtdRedimensionar()
        {
            if (varHouveRedimensionamento == false)
            {
                dfrmbtntxt1H = this.Size.Width - txt1.Left;
                // dfrmbtntxt1V = Me.Size.Height - txt1.Top 
                dfrmbtnSairH = this.Size.Width - btnSair.Left;
                // dfrmbtnSairV = Me.Size.Height - btnSair.Top 
                dfrmbtnRemoverH = this.Size.Width - btnRemover.Left;
                // dfrmbtnRemoverV = Me.Size.Height - btnRemover.Top 
                dfrmbtnCriarH = this.Size.Width - btnCriar.Left;
                // dfrmbtnCriarV = Me.Size.Height - btnCriar.Top 
                dfrmlstv1V = this.Size.Height - lstv1.Height;
                dfrmlstv1H = this.Size.Width - lstv1.Width;
                varHouveRedimensionamento = true;
            }
            // txt1.Top = Me.Size.Height - dfrmbtntxt1V 
            txt1.Left = this.Size.Width - dfrmbtntxt1H;
            // btnSair.Top = Me.Size.Height - dfrmbtnSairV 
            btnSair.Left = this.Size.Width - dfrmbtnSairH;
            // btnRemover.Top = Me.Size.Height - dfrmbtnRemoverV 
            btnRemover.Left = this.Size.Width - dfrmbtnRemoverH;
            // btnCriar.Top = Me.Size.Height - dfrmbtnCriarV 
            btnCriar.Left = this.Size.Width - dfrmbtnCriarH;
            lstv1.Height = this.Height - dfrmlstv1V;
            lstv1.Width = this.Width - dfrmlstv1H;
        }

        private void frmSubVisualizador_SizeChanged(object sender, EventArgs e)
        {
            mtdRedimensionar();
        } 
    }
}
