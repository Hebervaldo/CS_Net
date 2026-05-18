using System;
using System.Windows.Forms;

namespace Solucoes_Rede_Neural_CSCoreNet
{
    public partial class frmPrincipal : Form
    {
        // Variável de Instância
        private clsEnderecoAplicativo objEnderecoAplicativo = new clsEnderecoAplicativo();
        public string varEnderecoAplicativo;

        // Variável de Instância
        private bool varbarProgressivo = true;
        private int contTempo = 0;

        // Métodos

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void mtdFechar()
        {
            //frmRedeNeural objRedeNeural = new frmRedeNeural();
            try
            {
                frmRedeNeural.Th1.Abort();
                try
                {
                    frmRedeNeural.Th2.Abort();
                }
                finally
                {
                }
            }
            finally 
            {
            }
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Pergunta se o usuário quer, realmente, fechar o formulário
            DialogResult resposta;
            resposta = MessageBox.Show("Deseja realmente fechar o aplicativo?", "Aviso!", MessageBoxButtons.YesNo);
            // Se o usuário respondeu "Não", cancela o fechamento do formulário
            if (resposta == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
            }
            else if (resposta == System.Windows.Forms.DialogResult.Yes)
            {
                e.Cancel = false;
            }
        }

        private void frmPrincipal_Load(object sender, System.EventArgs e)
        {
            varEnderecoAplicativo = objEnderecoAplicativo.Endereco();
            barlblMostrContUser.Text = System.Environment.UserName;
            tmr1.Interval = 1000;
            tmr1.Enabled = true;
            barprg1.Step = 1;
            barprg1.Style = ProgressBarStyle.Blocks;
            barprg1.Value = 0;
            contTempo = 0;
        }

        private void smnHorizontal_Click(object sender, System.EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void smnVertical_Click(object sender, System.EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void smnCascata_Click(object sender, System.EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void tmr1_Tick(object sender, System.EventArgs e)
        {
            // Estrutura de controle do label que mostra as horas na barra de status
            barlblMostrHorario.Text = System.DateTime.Now.ToShortTimeString();
            // Estrutura para controle da barra de progresso da barra de status
            if (varbarProgressivo == true)
            {
                barprg1.Value += barprg1.Step;
                if (!(barprg1.Value < 100))
                {
                    contTempo = 100;
                    varbarProgressivo = false;
                }
            }
            else
            {
                barprg1.Value -= barprg1.Step;
                if (!(barprg1.Value > 0))
                {
                    contTempo = 0;
                    varbarProgressivo = true;
                }
            }
        }

        private void smnSair_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void mnuRedeNeural_Click(object sender, System.EventArgs e)
        {
            frmRedeNeural objRedeNeural = new frmRedeNeural();
            objRedeNeural.MdiParent = this;
            objRedeNeural.Show();
        }
    }
}