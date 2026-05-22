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
    public partial class frmVisualizador : Form
    {
        public static string tipoformulario = string.Empty;

        private int[] vetCelulaSelecionada = new int[2];
        private int dfrmbtnAjustarH;
        private int dfrmbtnAjustarV;
        private int dfrmbtnCadastrarH;
        private int dfrmbtnCadastrarV;
        private int dfrmbtnLerH;
        private int dfrmbtnLerV;
        private int dfrmbtnSairH;
        private int dfrmbtnSairV;
        private int dfrmdtgv1H;
        private int dfrmdtgv1V;
        private clsArquivoTXT objArquivoTXT = new clsArquivoTXT();
        private clsManipuladorTexto objManipuladorTexto = new clsManipuladorTexto();
        private frmSubVisualizador objSF = new frmSubVisualizador();
        private frmRedeNeural objRedeNeural = new frmRedeNeural();
        private string strEnderecoArquivo;
        private bool varHouveRedimensionamento = false;

        public frmVisualizador()
        {
            InitializeComponent();
        }

        private void frmVisualizador_Load(object sender, EventArgs e)
        {
            mtdLer(dtgv1);
            mtdAtributos();
            switch (tipoformulario)
            {
                case "EntradasTreinamento":
                    btnAjustar.Enabled = true;
                    break;
                case "Target":
                    btnAjustar.Enabled = true;
                    break;
                default:
                    btnAjustar.Enabled = false;
                    break;
            }
        }
        public void EnderecoArquivo(string EnderecoArquivo)
        {
            strEnderecoArquivo = EnderecoArquivo;
        }
        public void mtdLer(DataGridView dtgv)
        {
            string nomecoluna = string.Empty;
            objRedeNeural.RotinaLeitura(strEnderecoArquivo);
            switch (tipoformulario)
            {
                case "EntradasTreinamento":
                    nomecoluna = "Entrada";
                    break;
                case "Target":
                    nomecoluna = "Alvo";
                    break;
                default:
                    nomecoluna = "Campo";
                    break;
            }
            objRedeNeural.PreencherDataGridView(ref dtgv, nomecoluna);
        }
        public void mtdCadastrar(DataGridView dtgv)
        {
            objRedeNeural.RotinaCadastro(strEnderecoArquivo, ref dtgv);
            switch (tipoformulario)
            {
                case "EntradasTreinamento":
                    frmRedeNeural.NumeroEntrada = dtgv.ColumnCount;
                    frmRedeNeural.NumeroPadroes = dtgv.RowCount - 1;
                    break;
                case "Target":
                    frmRedeNeural.NumeroSaida = dtgv.ColumnCount;
                    frmRedeNeural.NumeroPadroesConferencia = dtgv.RowCount - 1;
                    break;
            }
        }

        private void mtdRedimensionar()
        {
            if (!varHouveRedimensionamento)
            {
                dfrmbtnAjustarH = this.Size.Width - btnAjustar.Left;
                dfrmbtnAjustarV = this.Size.Height - btnAjustar.Top;
                dfrmbtnCadastrarH = this.Size.Width - btnCadastrar.Left;
                dfrmbtnCadastrarV = this.Size.Height - btnCadastrar.Top;
                dfrmbtnLerH = this.Size.Width - btnLer.Left;
                dfrmbtnLerV = this.Size.Height - btnLer.Top;
                dfrmbtnSairH = this.Size.Width - btnSair.Left;
                dfrmbtnSairV = this.Size.Height - btnSair.Top;
                dfrmdtgv1H = this.Size.Width - dtgv1.Width;
                dfrmdtgv1V = this.Size.Height - dtgv1.Height;
                varHouveRedimensionamento = true;
            }
            btnSair.Top = this.Size.Height - dfrmbtnSairV;
            btnSair.Left = this.Size.Width - dfrmbtnSairH;
            btnCadastrar.Top = this.Size.Height - dfrmbtnCadastrarV;
            btnCadastrar.Left = this.Size.Width - dfrmbtnCadastrarH;
            btnLer.Top = this.Size.Height - dfrmbtnLerV;
            btnLer.Left = this.Size.Width - dfrmbtnLerH;
            btnAjustar.Top = this.Size.Height - dfrmbtnAjustarV;
            btnAjustar.Left = this.Size.Width - dfrmbtnAjustarH;
            dtgv1.Height = this.Height - dfrmdtgv1V;
            dtgv1.Width = this.Width - dfrmdtgv1H;
        }
        private void mtdAtributos()
        {
            tslbl2.Text = Convert.ToString(dtgv1.RowCount - 1);
            tslbl4.Text = Convert.ToString(dtgv1.ColumnCount);
            tslbl6.Text = Convert.ToString(dtgv1.SelectedCells[0].RowIndex + 1);
            tslbl8.Text = Convert.ToString(dtgv1.SelectedCells[0].ColumnIndex + 1);
        }

        private void btnAjustar_Click(object sender, EventArgs e)
        {
            objSF.Show();
        }

        private void btnLer_Click(object sender, EventArgs e)
        {
            mtdLer(dtgv1);
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            mtdCadastrar(dtgv1);
        mtdAtributos();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            mtdAtributos();
            vetCelulaSelecionada[0] = dtgv1.SelectedCells[0].ColumnIndex;
            vetCelulaSelecionada[1] = dtgv1.SelectedCells[0].RowIndex; 
        }

        private void frmVisualizador_SizeChanged(object sender, EventArgs e)
        {
            mtdRedimensionar();
        }

    }
}
