using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace prjColetorDadosCSNet35
{
    public partial class frmDeletarItem : Form
    {
        public static frmDeletarItem newMessageBox;
        public Timer msgTimer = new Timer();
        private static int Button_id = 0;
        private static int intTimerCountDown = 600;
        private static string strNumeroInventario = string.Empty;
        private int disposeFormTimer = 0;
        public static string[] vetNumeroInventario;
        public int intCamposTabelaInventarioBens = frmPrincipal.intCamposTabelaInventarioBens;

        public frmDeletarItem()
            : this(intTimerCountDown, strNumeroInventario)
        {
        }

        public frmDeletarItem(int TimerCountDown)
            : this(TimerCountDown, strNumeroInventario)
        {
        }

        public frmDeletarItem(string NumeroInventario)
            : this(intTimerCountDown, NumeroInventario)
        {
        }

        public frmDeletarItem(int TimerCountDown, string NumeroInventario)
        {
            frmDeletarItem.intTimerCountDown = TimerCountDown;
            frmDeletarItem.strNumeroInventario = NumeroInventario;
            InitializeComponent();
            this.msgTimer.Tick += new System.EventHandler(this.msgTimer_Tick);
        }

        public static int ShowBox()
        {
            return ShowBox(frmDeletarItem.intTimerCountDown, frmDeletarItem.strNumeroInventario);
        }

        public static int ShowBox(int TimerCountDown)
        {
            return ShowBox(TimerCountDown, frmDeletarItem.strNumeroInventario);
        }

        public static int ShowBox(string NumeroInventario)
        {
            return ShowBox(frmDeletarItem.intTimerCountDown, NumeroInventario);
        }

        public static int ShowBox(int TimerCountDown, string NumeroInventario)
        {
            newMessageBox = new frmDeletarItem(TimerCountDown, NumeroInventario);
            //newMessageBox.Show();
            newMessageBox.ShowDialog();

            return Button_id;
        }

        //public static string ShowBox(string txtMessage)
        //{
        //    ShowBox(txtMessage, string.Empty);
        //}

        //public static string ShowBox(string txtMessage, string txtTitle)
        //{
        //    newMessageBox = new MyMessageBox();
        //    newMessageBox.lblTitle.Text = txtTitle;
        //    newMessageBox.lblMessage.Text = txtMessage;
        //    newMessageBox.ShowDialog();
        //    return Button_id;
        //}

        private void MyMessageBox_Load(object sender, EventArgs e)
        {
            this.disposeFormTimer = frmDeletarItem.intTimerCountDown;
            this.lblTimer.Text = disposeFormTimer.ToString();
            this.msgTimer.Interval = 1000;
            this.msgTimer.Enabled = true;
            //msgTimer.Start();

            mtdCarregarLsv1();
        }

        private void MyMessageBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics mGraphics = e.Graphics;
            Pen pen1 = new Pen(Color.FromArgb(96, 155, 173), 1);

            Rectangle Area1 = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            System.Drawing.SolidBrush SB = new System.Drawing.SolidBrush(System.Drawing.Color.White);
            //System.Drawing.Drawing2D.LinearGradientBrush LGB = new System.Drawing.Drawing2D.LinearGradientBrush
            //(
            //Area1, 
            //Color.FromArgb(96, 155, 173),
            //Color.FromArgb(245, 251, 251),
            //System.Drawing.Drawing2D.LinearGradientMode.Vertical
            //);
            mGraphics.FillRectangle(SB, Area1);
            mGraphics.DrawRectangle(pen1, Area1);
        }

        private void mtdItemSelecionado()
        {
            mtdVerificarItensChecados();
            this.msgTimer.Enabled = false;
            //newMessageBox.msgTimer.Stop();
            this.msgTimer.Dispose();
            frmDeletarItem.Button_id = 1;
            this.Dispose();
        }

        private void mtdTodosItens()
        {
            mtdVerificarItensChecados();
            this.msgTimer.Enabled = false;
            //newMessageBox.msgTimer.Stop();
            this.msgTimer.Dispose();
            frmDeletarItem.Button_id = 2;
            this.Dispose();
        }

        private void mtdCancelar()
        {
            mtdVerificarItensChecados();
            this.msgTimer.Enabled = false;
            //newMessageBox.msgTimer.Stop();
            this.msgTimer.Dispose();
            frmDeletarItem.Button_id = 3;
            this.Dispose();
        }

        private void btnItemSelecionado_Click(object sender, EventArgs e)
        {
            mtdItemSelecionado();
        }

        private void btnTodosItens_Click(object sender, EventArgs e)
        {
            if (
                System.Windows.Forms.MessageBox.Show
                (
                "Deseja realmente deletar todos os itens da tabela?",
                "Aviso!",
                System.Windows.Forms.MessageBoxButtons.YesNo,
                System.Windows.Forms.MessageBoxIcon.Exclamation,
                System.Windows.Forms.MessageBoxDefaultButton.Button1
                ) == System.Windows.Forms.DialogResult.Yes
                )
            {
                mtdTodosItens();
            }
            else
            {
                mtdCancelar();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            mtdCancelar();
        }

        private void msgTimer_Tick(object sender, EventArgs e)
        {
            disposeFormTimer--;

            if (disposeFormTimer >= 0)
            {
                this.lblTimer.Text = disposeFormTimer.ToString();
            }
            else
            {
                mtdCancelar();
            }
        }

        private void mtdInicializaLsv1()
        {
            // exibe detalhes
            lsv1.View = View.Details;
            // permite ao usuário editar o texto
            //lsv1.LabelEdit = true;
            // permite ao usuário rearranjar as colunas
            //lsv1.AllowColumnReorder = true;
            // Selecione o item e subitem quando um seleção for feita
            lsv1.FullRowSelect = true;
            // Exibe as linhas no ListView
            //lsv1.GridLines = true;
        }

        private void mtdCarregarLsv1()
        {
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                (
                clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                );

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                (
                clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                frmPrincipal.strBaseDadosColetor,
                frmPrincipal.strSenhaColetor
                );

            string[] vetCamposTabelaInventarioBens = new string[intCamposTabelaInventarioBens];

            for (int contador = 0; contador <= intCamposTabelaInventarioBens - 1; contador++)
            {
                vetCamposTabelaInventarioBens[contador] = frmPrincipal.vetCamposTabelaInventarioBens[contador];
            }

            objImplementacaoBancoDados.mtdSelecionarDados
                (
                frmPrincipal. uintNumeroLinhas,
                vetCamposTabelaInventarioBens,
                frmPrincipal.strTabelaInventarioBens,
                vetCamposTabelaInventarioBens[0],
                "LIKE",
                "'%'",
                vetCamposTabelaInventarioBens[0],
                false
                );

            int numLinhas = objImplementacaoBancoDados.mtdNumeroLinhas();

            objImplementacaoBancoDados.mtdDefinirLeitorDados();

            string[] vetCabecalhoColunas = objImplementacaoBancoDados.mtdObterCabecalhoColunas();
            int numColunas = objImplementacaoBancoDados.mtdNumeroColunas();

            mtdInicializaLsv1();
            lsv1.Items.Clear();

            for (int coluna = vetCabecalhoColunas.GetLowerBound(0); coluna <= vetCabecalhoColunas.GetUpperBound(0); coluna++)
            {
                lsv1.Columns.Add(vetCabecalhoColunas[coluna], 100, HorizontalAlignment.Left);
            }

            int intColunaSelecionada = -1;
            int intLinhaSelecionada = -1;

            for (int linha = 0; linha < numLinhas; linha++)
            {
                objImplementacaoBancoDados.mtdProximoRegistro();
                int coluna = 0;
                if (objImplementacaoBancoDados.mtdObterValorRegistro(coluna).ToString() == strNumeroInventario)
                {
                    intColunaSelecionada = coluna;
                    intLinhaSelecionada = linha;
                }
                ListViewItem lvi = new ListViewItem(objImplementacaoBancoDados.mtdObterValorRegistro(coluna).ToString());
                for (coluna = 1; coluna < numColunas; coluna++)
                    lvi.SubItems.Add(objImplementacaoBancoDados.mtdObterValorRegistro(coluna).ToString());

                lsv1.Items.Add(lvi);
            }

            if (intLinhaSelecionada > -1 && intColunaSelecionada > -1)
            {
                lsv1.Items[intLinhaSelecionada].Checked = true;
            }

            objImplementacaoBancoDados.Dispose();
        }

        private void mtdVerificarItensChecados()
        {
            vetNumeroInventario = new string[lsv1.Items.Count];

            for (int linha = 0; linha < lsv1.Items.Count; linha++)
            {
                vetNumeroInventario[linha] = lsv1.Items[linha].Checked ? lsv1.Items[linha].Text : string.Empty;
            }
        }
    }
}