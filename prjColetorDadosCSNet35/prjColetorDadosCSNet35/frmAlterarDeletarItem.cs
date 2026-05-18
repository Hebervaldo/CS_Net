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
    public partial class frmAlterarDeletarItem : Form
    {
        public static frmAlterarDeletarItem newMessageBox;
        public Timer msgTimer = new Timer();
        private static int Button_id = 0;
        private static int intTimerCountDown = 600;
        private static string strNumeroInventario = string.Empty;
        public static string Modo = "Alterar";
        public static string[] vetNumeroInventario;
        private int disposeFormTimer = 0;

        public frmAlterarDeletarItem()
            : this(intTimerCountDown, strNumeroInventario)
        {
        }

        public frmAlterarDeletarItem(int TimerCountDown)
            : this(TimerCountDown, strNumeroInventario)
        {
        }

        public frmAlterarDeletarItem(string NumeroInventario)
            : this(intTimerCountDown, NumeroInventario)
        {
        }

        public frmAlterarDeletarItem(int TimerCountDown, string NumeroInventario)
        {
            frmAlterarDeletarItem.intTimerCountDown = TimerCountDown;
            frmAlterarDeletarItem.strNumeroInventario = NumeroInventario;
            InitializeComponent();
            this.msgTimer.Tick += new System.EventHandler(this.msgTimer_Tick);
        }

        public static int ShowBox()
        {
            return ShowBox(frmAlterarDeletarItem.intTimerCountDown, frmAlterarDeletarItem.strNumeroInventario);
        }

        public static int ShowBox(int TimerCountDown)
        {
            return ShowBox(TimerCountDown, frmAlterarDeletarItem.strNumeroInventario);
        }

        public static int ShowBox(string NumeroInventario)
        {
            return ShowBox(frmAlterarDeletarItem.intTimerCountDown, NumeroInventario);
        }

        public static int ShowBox(int TimerCountDown, string NumeroInventario)
        {
            newMessageBox = new frmAlterarDeletarItem(TimerCountDown, NumeroInventario);
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
            this.disposeFormTimer = frmAlterarDeletarItem.intTimerCountDown;
            this.lblTimer.Text = disposeFormTimer.ToString();
            this.msgTimer.Interval = 1000;
            this.msgTimer.Enabled = true;
            //msgTimer.Start();

            mtdCarregarLsv1();

            if (Modo == "Alterar")
            {
                mtdModoAlterar();
            }
            else
            {
                mtdModoDeletar();
            }
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
            frmAlterarDeletarItem.Button_id = 1;
            this.Dispose();
        }

        private void mtdTodosItens()
        {
            for (int linha = 0; linha <= Program.objPrincipal.dt.Rows.Count - 1; linha++)
            {
                if (linha > -1)
                {
                    lsv1.Items[linha].Checked = true;
                }
            }

            mtdVerificarItensChecados();
            this.msgTimer.Enabled = false;
            //newMessageBox.msgTimer.Stop();
            this.msgTimer.Dispose();
            frmAlterarDeletarItem.Button_id = 2;
            this.Dispose();
        }

        private void mtdCancelar()
        {
            mtdVerificarItensChecados();
            this.msgTimer.Enabled = false;
            //newMessageBox.msgTimer.Stop();
            this.msgTimer.Dispose();
            frmAlterarDeletarItem.Button_id = 3;
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
                "Deseja realmente alterar todos os itens da tabela?",
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
            // exibe as caixas de marcacao (check boxes.)
            lsv1.CheckBoxes = true;
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
            lsv1.Clear();
            lsv1.Columns.Clear();
            lsv1.Items.Clear();

            mtdInicializaLsv1();

            int intColunaSelecionada = -1;
            int intLinhaSelecionada = -1;

            for (int coluna = 0; coluna <= Program.objPrincipal.dt.Columns.Count - 1; coluna++)
            {
                lsv1.Columns.Add
                    (
                    Program.objPrincipal.dt.Columns[coluna].Caption.ToString(),
                    100,
                    HorizontalAlignment.Left
                    );
            }

            ListViewItem lvi = new ListViewItem();
            ListViewItem.ListViewSubItem lvs = new ListViewItem.ListViewSubItem();

            for (int linha = 0; linha <= Program.objPrincipal.dt.Rows.Count - 1; linha++)
            {
                for (int coluna = 0; coluna <= Program.objPrincipal.dt.Columns.Count - 1; coluna++)
                {
                    if (coluna == 0)
                    {
                        if (Program.objPrincipal.dt.Rows[linha].ItemArray[coluna].ToString() == strNumeroInventario)
                        {
                            intColunaSelecionada = coluna;
                            intLinhaSelecionada = linha;
                        }
                        lvi = new ListViewItem(Program.objPrincipal.dt.Rows[linha].ItemArray[coluna].ToString());
                    }
                    else
                    {
                        lvs = new ListViewItem.ListViewSubItem();
                        lvs.Text = Program.objPrincipal.dt.Rows[linha].ItemArray[coluna].ToString();
                        lvi.SubItems.Add(lvs);
                    }
                }

                lsv1.Items.Add(lvi);
            }

            if (intLinhaSelecionada > -1 && intColunaSelecionada > -1)
            {
                lsv1.Items[intLinhaSelecionada].Checked = true;
            }
        }

        private void mtdVerificarItensChecados()
        {
            int numLinha = 0;
            string[] vetNumeroInventario = new string[lsv1.Items.Count];

            for (int linha = 0; linha < lsv1.Items.Count; linha++)
            {
                if (lsv1.Items[linha].Checked)
                {
                    vetNumeroInventario[linha] = lsv1.Items[linha].Checked ? lsv1.Items[linha].Text : string.Empty;
                    numLinha++;
                }
            }

            frmAlterarDeletarItem.vetNumeroInventario = new string[numLinha];

            int contador = 0;
            for (int linha = 0; linha < lsv1.Items.Count; linha++)
            {
                if (lsv1.Items[linha].Checked)
                {
                    frmAlterarDeletarItem.vetNumeroInventario[contador] = vetNumeroInventario[linha];
                    contador++;
                }
            }
        }

        private void mni1_Click(object sender, EventArgs e)
        {
            mtdModoAlterar();
        }

        private void mni2_Click(object sender, EventArgs e)
        {
            mtdModoDeletar();
        }

        private void mtdModoAlterar()
        {
            this.Text = "Alterar Item";
            lblTitle.Text = "Alterar";
            Modo = "Alterar";
            pctAlterar.Visible = true;
            pctDeletar.Visible = false;
        }

        private void mtdModoDeletar()
        {
            this.Text = "Deletar Item";
            lblTitle.Text = "Deletar";
            Modo = "Deletar";
            pctAlterar.Visible = false;
            pctDeletar.Visible = true;
        }
    }
}