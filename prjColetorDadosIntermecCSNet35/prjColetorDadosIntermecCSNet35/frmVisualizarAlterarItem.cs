using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace prjColetorDadosIntermecCSNet35
{
    public partial class frmVisualizarAlterarItem : Form
    {
        public bool blnUsarLista = true;
        public int intColunaSelecionada1 = 0;
        public int intColunaSelecionada2 = 0;
        public int intLinhaSelecionada = 0;

        public string[] vetNumeroInventario;

        public object[][] objDado = new object[2][];

        public frmVisualizarAlterarItem()
            : this(true)
        {
        }

        public frmVisualizarAlterarItem(bool UsarLista)
        {
            blnUsarLista = UsarLista;

            InitializeComponent();
        }

        private void mtdPreencherCmbCampo(ref System.Windows.Forms.ComboBox Cmb)
        {
            Cmb.Items.Clear();

            for (int coluna = objDado[0].GetLowerBound(0); coluna <= objDado[0].GetUpperBound(0); coluna++)
            {
                switch (coluna)
                {
                    case frmPrincipal.intColunaTabelaInventarioBensTRG:
                    case frmPrincipal.intColunaTabelaInventarioBensCentroCusto:
                    case frmPrincipal.intColunaTabelaInventarioBensOrgao:
                    case frmPrincipal.intColunaTabelaInventarioBensSala:
                    case frmPrincipal.intColunaTabelaInventarioBensNome:
                    case frmPrincipal.intColunaTabelaInventarioBensMatricula:
                    case frmPrincipal.intColunaTabelaInventarioBensPatrimonio:
                    case frmPrincipal.intColunaTabelaInventarioBensQuantidade:
                    case frmPrincipal.intColunaTabelaInventarioBensDenominacao:
                    case frmPrincipal.intColunaTabelaInventarioBensN_Serie:
                    case frmPrincipal.intColunaTabelaInventarioBensPlaca_Veiculo:
                    case frmPrincipal.intColunaTabelaInventarioBensIdentificacao_Inventario:
                    case frmPrincipal.intColunaTabelaInventarioBensOutrosDados_Inventario:
                    case frmPrincipal.intColunaTabelaInventarioBensObservacao:
                    case frmPrincipal.intColunaTabelaInventarioBensColetor:
                    case frmPrincipal.intColunaTabelaInventarioBensUsuario_Inventariante:
                    case frmPrincipal.intColunaTabelaInventarioBensMatricula_Inventariante:
                        Cmb.Items.Add(objDado[0][coluna]);
                        break;
                }
            }
        }

        private void mtdCarregarTextosEstaticos()
        {
            txtNumeroInventario.Text = objDado[1][frmPrincipal.intColunaTabelaInventarioBensNumero_Inventario].ToString();
            txtPatrimonioItem.Text = objDado[1][frmPrincipal.intColunaTabelaInventarioBensPatrimonio].ToString();
        }

        private void mtdCarregarTextosDinamicos(int ColunaSelecionada, ref System.Windows.Forms.TextBox Txt)
        {
            //cmbCampo.Text = objDado[0][ColunaSelecionada].ToString();
            Txt.Text = objDado[1][ColunaSelecionada].ToString();
        }

        private void frmVisualizarItem_Load(object sender, EventArgs e)
        {
            chkHabilitarCmbCampo2.Checked = false;
            cmbCampo2.Enabled = chkHabilitarCmbCampo2.Checked;
            txtDado2.Enabled = chkHabilitarCmbCampo2.Checked;

            mtdPreencherCmbCampo(ref cmbCampo1);
            mtdPreencherCmbCampo(ref cmbCampo2);

            cmbCampo1.Text = objDado[0][intColunaSelecionada1].ToString();
            cmbCampo2.Text = objDado[0][intColunaSelecionada2].ToString();

            mtdCarregarTextosEstaticos();
            mtdCarregarTextosDinamicos(intColunaSelecionada1, ref txtDado1);
            mtdCarregarTextosDinamicos(intColunaSelecionada2, ref txtDado2);

            lsv1.Enabled = blnUsarLista;
            btnItemSelecionado.Enabled = blnUsarLista;
            btnTodosItens.Enabled = blnUsarLista;

            if (blnUsarLista)
            {
                mtdCarregarLsv1();
            }
        }

        private void mni1_Click(object sender, EventArgs e)
        {
            mtdItemSelecionado();
        }

        private void mni2_Click(object sender, EventArgs e)
        {
            mtdCancelar();
        }

        private void mtdAlterarDadosSelecionados()
        {
            for
                (
                int contador = vetNumeroInventario.GetLowerBound(0);
                contador <= vetNumeroInventario.GetUpperBound(0);
                contador++
                )
            {
                mtdAlterarDado
                    (
                    objDado[0][intColunaSelecionada1].ToString(),
                    txtDado1.Text,
                    objDado[0][intColunaSelecionada2].ToString(),
                    txtDado2.Text,
                    objDado[0][frmPrincipal.intColunaTabelaInventarioBensNumero_Inventario].ToString(),
                    "LIKE",
                    vetNumeroInventario[contador]
                    );
            }
        }

        private void mtdAlterarDado
            (
            string Coluna1,
            string Dado1,
            string Coluna2,
            string Dado2,
            string ColunaSelecionada,
            string Operacao,
            string DadoSelecionado
            )
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

            object[][] dado = new object[2][];

            if (chkHabilitarCmbCampo2.Checked)
            {
                dado[0] = new object[3] { frmPrincipal.vetCamposTabelaInventarioBens[frmPrincipal.intColunaTabelaInventarioBensData_Inventario], Coluna1, Coluna2 };
                dado[1] = new object[3] { Program.objPrincipal.dtpDataInventario.Value, Dado1, Dado2 };
            }
            else
            {
                dado[0] = new object[2] { frmPrincipal.vetCamposTabelaInventarioBens[frmPrincipal.intColunaTabelaInventarioBensData_Inventario], Coluna1 };
                dado[1] = new object[2] { Program.objPrincipal.dtpDataInventario.Value, Dado1 };
            }

            objImplementacaoBancoDados.mtdAtualizarDadosParametroComandoSQLServerCE
                (
                frmPrincipal.strTabelaInventarioBens,
                dado,
                ColunaSelecionada,
                Operacao,
                DadoSelecionado,
                clsImplementacaoBancoDados.enmModoParametroComando.Valor
                );

            objImplementacaoBancoDados.Dispose();
        }

        private void mtdItemSelecionado()
        {
            if
                (
                System.Windows.Forms.MessageBox.Show
                (
                blnUsarLista
                ?
                "Deseja realmente alterar o(s) registro(s) selecionado(s)?"
                :
                "Deseja realmente alterar o registro selecionado?",
                "Aviso!", System.Windows.Forms.MessageBoxButtons.YesNo,
                System.Windows.Forms.MessageBoxIcon.Exclamation,
                System.Windows.Forms.MessageBoxDefaultButton.Button2
                )
                ==
                System.Windows.Forms.DialogResult.Yes
                )
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor; // set the wait cursor
                    //Do some work

                    if (blnUsarLista)
                    {
                        mtdVerificarItensChecados();

                        mtdAlterarDadosSelecionados();
                    }
                    else
                    {
                        mtdAlterarDado
                            (
                            objDado[0][intColunaSelecionada1].ToString(),
                            txtDado1.Text,
                            objDado[0][intColunaSelecionada2].ToString(),
                            txtDado2.Text,
                            objDado[0][frmPrincipal.intColunaTabelaInventarioBensNumero_Inventario].ToString(),
                            "LIKE",
                            txtNumeroInventario.Text
                            );
                    }

                    Program.objPrincipal.mtdAtualizarDtg1
                    (
                    Program.objPrincipal.cmbConsultarInventario.Text,
                    Program.objPrincipal.txtConsultarInventario.Text,
                    frmPrincipal.uintNumeroLinhas
                    );

                    Program.objPrincipal.Show();
                    this.Close();
                    this.Dispose();
                    Program.objPrincipal.mtdVisualizarAlterarItem(intLinhaSelecionada, intColunaSelecionada1, intColunaSelecionada2, blnUsarLista);
                }
                finally
                {
                    Cursor.Current = Cursors.Default; //restore the old cursor
                }
            }
        }

        private void mtdTodosItens()
        {
            if
                (
                System.Windows.Forms.MessageBox.Show
                (
                "Deseja realmente alterar todos os registros selecionados?",
                "Aviso!", System.Windows.Forms.MessageBoxButtons.YesNo,
                System.Windows.Forms.MessageBoxIcon.Exclamation,
                System.Windows.Forms.MessageBoxDefaultButton.Button2
                )
                ==
                System.Windows.Forms.DialogResult.Yes
                )
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor; // set the wait cursor
                    //Do some work
                    for (int linha = 0; linha <= Program.objPrincipal.dt.Rows.Count - 1; linha++)
                    {
                        if (linha > -1)
                        {
                            lsv1.Items[linha].Checked = true;
                        }
                    }

                    mtdVerificarItensChecados();

                    mtdAlterarDadosSelecionados();

                    Program.objPrincipal.mtdAtualizarDtg1
                        (
                        Program.objPrincipal.cmbConsultarInventario.Text,
                        Program.objPrincipal.txtConsultarInventario.Text,
                        frmPrincipal.uintNumeroLinhas
                        );

                    Program.objPrincipal.Show();
                    this.Close();
                    this.Dispose();
                    Program.objPrincipal.mtdVisualizarAlterarItem(intLinhaSelecionada, intColunaSelecionada1, intColunaSelecionada2, blnUsarLista);
                }
                finally
                {
                    Cursor.Current = Cursors.Default; //restore the old cursor
                }
            }
        }

        private void mtdCancelar()
        {
            //mtdVerificarItensChecados();

            Program.objPrincipal.Show();
            this.Close();
            this.Dispose();
        }

        private void btnItemSelecionado_Click(object sender, EventArgs e)
        {
            mtdItemSelecionado();
        }

        private void btnTodosItens_Click(object sender, EventArgs e)
        {
            mtdTodosItens();
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
                        if
                            (
                            Program.objPrincipal.dt.Rows[linha].ItemArray[coluna].ToString()
                            ==
                            objDado[1][frmPrincipal.intColunaTabelaInventarioBensNumero_Inventario].ToString()
                            )
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

            this.vetNumeroInventario = new string[numLinha];

            int contador = 0;
            for (int linha = 0; linha < lsv1.Items.Count; linha++)
            {
                if (lsv1.Items[linha].Checked)
                {
                    this.vetNumeroInventario[contador] = vetNumeroInventario[linha];
                    contador++;
                }
            }
        }

        private void txtDado1_LostFocus(object sender, EventArgs e)
        {
            txtDado1.Text = frmPrincipal.objManipuladorTexto.mtdExecutarTudo(txtDado1.Text);
        }

        private void cmbCampo1_GotFocus(object sender, EventArgs e)
        {
            if (cmbCampo1.Items.Count == 0)
            {
                mtdPreencherCmbCampo(ref cmbCampo1);
            }
        }

        private void txtDado2_LostFocus(object sender, EventArgs e)
        {
            txtDado2.Text = frmPrincipal.objManipuladorTexto.mtdExecutarTudo(txtDado2.Text);
        }

        private void cmbCampo2_GotFocus(object sender, EventArgs e)
        {
            if (cmbCampo2.Items.Count == 0)
            {
                mtdPreencherCmbCampo(ref cmbCampo2);
            }
        }

        private int mtdCampo_TextChanged(ref System.Windows.Forms.ComboBox Cmb)
        {
            int ColunaSelecionada = 0;

            if (Cmb.Text == frmPrincipal.vetCamposTabelaInventarioBens[frmPrincipal.intColunaTabelaInventarioBensTRG])
            {
                ColunaSelecionada = frmPrincipal.intColunaTabelaInventarioBensTRG;
            }
            if (Cmb.Text == frmPrincipal.vetCamposTabelaInventarioBens[frmPrincipal.intColunaTabelaInventarioBensCentroCusto])
            {
                ColunaSelecionada = frmPrincipal.intColunaTabelaInventarioBensCentroCusto;
            }
            if (Cmb.Text == frmPrincipal.vetCamposTabelaInventarioBens[frmPrincipal.intColunaTabelaInventarioBensOrgao])
            {
                ColunaSelecionada = frmPrincipal.intColunaTabelaInventarioBensOrgao;
            }
            if (Cmb.Text == frmPrincipal.vetCamposTabelaInventarioBens[frmPrincipal.intColunaTabelaInventarioBensSala])
            {
                ColunaSelecionada = frmPrincipal.intColunaTabelaInventarioBensSala;
            }
            if (Cmb.Text == frmPrincipal.vetCamposTabelaInventarioBens[frmPrincipal.intColunaTabelaInventarioBensNome])
            {
                ColunaSelecionada = frmPrincipal.intColunaTabelaInventarioBensNome;
            }
            if (Cmb.Text == frmPrincipal.vetCamposTabelaInventarioBens[frmPrincipal.intColunaTabelaInventarioBensMatricula])
            {
                ColunaSelecionada = frmPrincipal.intColunaTabelaInventarioBensMatricula;
            }
            if (Cmb.Text == frmPrincipal.vetCamposTabelaInventarioBens[frmPrincipal.intColunaTabelaInventarioBensPatrimonio])
            {
                ColunaSelecionada = frmPrincipal.intColunaTabelaInventarioBensPatrimonio;
            }
            if (Cmb.Text == frmPrincipal.vetCamposTabelaInventarioBens[frmPrincipal.intColunaTabelaInventarioBensQuantidade])
            {
                ColunaSelecionada = frmPrincipal.intColunaTabelaInventarioBensQuantidade;
            }
            if (Cmb.Text == frmPrincipal.vetCamposTabelaInventarioBens[frmPrincipal.intColunaTabelaInventarioBensDenominacao])
            {
                ColunaSelecionada = frmPrincipal.intColunaTabelaInventarioBensDenominacao;
            }
            if (Cmb.Text == frmPrincipal.vetCamposTabelaInventarioBens[frmPrincipal.intColunaTabelaInventarioBensN_Serie])
            {
                ColunaSelecionada = frmPrincipal.intColunaTabelaInventarioBensN_Serie;
            }
            if (Cmb.Text == frmPrincipal.vetCamposTabelaInventarioBens[frmPrincipal.intColunaTabelaInventarioBensPlaca_Veiculo])
            {
                ColunaSelecionada = frmPrincipal.intColunaTabelaInventarioBensPlaca_Veiculo;
            }
            if (Cmb.Text == frmPrincipal.vetCamposTabelaInventarioBens[frmPrincipal.intColunaTabelaInventarioBensIdentificacao_Inventario])
            {
                ColunaSelecionada = frmPrincipal.intColunaTabelaInventarioBensIdentificacao_Inventario;
            }
            if (Cmb.Text == frmPrincipal.vetCamposTabelaInventarioBens[frmPrincipal.intColunaTabelaInventarioBensOutrosDados_Inventario])
            {
                ColunaSelecionada = frmPrincipal.intColunaTabelaInventarioBensOutrosDados_Inventario;
            }
            if (Cmb.Text == frmPrincipal.vetCamposTabelaInventarioBens[frmPrincipal.intColunaTabelaInventarioBensObservacao])
            {
                ColunaSelecionada = frmPrincipal.intColunaTabelaInventarioBensObservacao;
            }
            if (Cmb.Text == frmPrincipal.vetCamposTabelaInventarioBens[frmPrincipal.intColunaTabelaInventarioBensColetor])
            {
                ColunaSelecionada = frmPrincipal.intColunaTabelaInventarioBensColetor;
            }
            if (Cmb.Text == frmPrincipal.vetCamposTabelaInventarioBens[frmPrincipal.intColunaTabelaInventarioBensUsuario_Inventariante])
            {
                ColunaSelecionada = frmPrincipal.intColunaTabelaInventarioBensUsuario_Inventariante;
            }
            if (Cmb.Text == frmPrincipal.vetCamposTabelaInventarioBens[frmPrincipal.intColunaTabelaInventarioBensMatricula_Inventariante])
            {
                ColunaSelecionada = frmPrincipal.intColunaTabelaInventarioBensMatricula_Inventariante;
            }

            return ColunaSelecionada;
        }

        private void cmbCampo1_TextChanged(object sender, EventArgs e)
        {
            intColunaSelecionada1 = mtdCampo_TextChanged(ref cmbCampo1);

            mtdCarregarTextosEstaticos();
            mtdCarregarTextosDinamicos(intColunaSelecionada1, ref txtDado1);
        }

        private void cmbCampo2_TextChanged(object sender, EventArgs e)
        {
            intColunaSelecionada2 = mtdCampo_TextChanged(ref cmbCampo2);

            mtdCarregarTextosEstaticos();
            mtdCarregarTextosDinamicos(intColunaSelecionada2, ref txtDado2);
        }

        private void lsv1_ItemActivate(object sender, EventArgs e)
        {
            objDado[0] = new object[lsv1.Columns.Count];
            objDado[1] = new object[lsv1.Columns.Count];

            for (int coluna = objDado[0].GetLowerBound(0); coluna <= objDado[0].GetUpperBound(0); coluna++)
            {
                objDado[0][coluna] = lsv1.Columns[coluna].Text;
                if (coluna == 0)
                {
                    objDado[1][coluna] = lsv1.Items[lsv1.SelectedIndices[0]].Text;
                }
                else
                {
                    objDado[1][coluna] = lsv1.Items[lsv1.SelectedIndices[0]].SubItems[coluna].Text;
                }
            }

            mtdCarregarTextosEstaticos();
            mtdCarregarTextosDinamicos(intColunaSelecionada1, ref txtDado1);
            mtdCarregarTextosDinamicos(intColunaSelecionada2, ref txtDado2);
        }

        private void chkHabilitarCmbCampo2_CheckStateChanged(object sender, EventArgs e)
        {
            cmbCampo2.Enabled = chkHabilitarCmbCampo2.Checked;
            txtDado2.Enabled = chkHabilitarCmbCampo2.Checked;
        }
    }
}