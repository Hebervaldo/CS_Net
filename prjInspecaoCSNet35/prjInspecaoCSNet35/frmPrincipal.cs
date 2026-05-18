using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace prjInspecaoCSNet35
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            txtLegenda.Text = mtdObterLegenda();
            mtdBaseDados_Load();
            mtdComponentes_Manipulacao_Load();

            objManipulacaoBaseDadosColetor = new clsManipulacaoBaseDados(strBaseDadosColetor, strSenhaBaseDadosColetor);

            mtdPreencherCmbServicos();
            mtdPreencherLsv(ref lsvInspecao, uintNumeroLinhas, false);
            //mtdIniciarDtgInspecao();
            //mtdPreencherDtgInspecao(uintNumeroLinhas, false);

            mtdIniciarTblColunasItens();
            mtdIniciarLsvCmbIndice(ref lsvServicos, 0);
            mtdObterMediaNotaServicos();
            mtdPreencherCmbOpcaoEstatistica();

            txtColetor.Text = System.Net.Dns.GetHostName();

            btnConsultarInspecao_Click(sender, e);
        }

        private bool blnItemChkLsvServicos = false;

        private void mtdAtribuirNotaServicos(string NotaServicos)
        {
            mtdAtribuirNotaServicos(NotaServicos, false);
        }

        private void mtdAtribuirNotaServicos(string NotaServicos, bool ForcarItemSelecionado)
        {
            try
            {
                if (System.Convert.ToInt32(NotaServicos) >= intNotaMinima & System.Convert.ToInt32(NotaServicos) <= intNotaMaxima)
                {
                    if (!ForcarItemSelecionado)
                    {
                        for (int contador = 0; contador <= lsvServicos.Items.Count - 1; contador++)
                        {
                            if (lsvServicos.Items[contador].Checked)
                            {
                                lsvServicos.Items[contador].SubItems[1].Text = NotaServicos;

                                blnItemChkLsvServicos = true;
                            }

                            lsvServicos.Items[contador].Checked = false;
                        }
                    }

                    if (!blnItemChkLsvServicos | ForcarItemSelecionado)
                    {
                        lsvServicos.Items[intLsvServicosNumeroLinha].SubItems[1].Text = NotaServicos;
                    }

                    mtdAjustarVetTblColunasItens(lsvServicos, cmbServicos.SelectedIndex);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show
                    (
                        string.Format("A Nota digitada deve ser um número inteiro compreendido entre {0} e {1}.", intNotaMinima, intNotaMaxima),
                        "Aviso!",
                        System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Exclamation,
                        System.Windows.Forms.MessageBoxDefaultButton.Button1
                    );
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show
                (
                    string.Format("A Nota digitada deve ser um número inteiro compreendido entre {0} e {1}.", intNotaMinima, intNotaMaxima),
                    "Aviso!",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Exclamation,
                    System.Windows.Forms.MessageBoxDefaultButton.Button1
                );
            }
        }

        private void btnAtribuirNotaServicos_Click(object sender, EventArgs e)
        {
            mtdAtribuirNotaServicos(txtNotaServicos.Text);
        }

        private List<double> lstNotas = new List<double> { };

        private void mtdObterMediaNotaServicos()
        {
            lstNotas.Clear();

            for (int contador = 0; contador <= lsvServicos.Items.Count - 1; contador++)
            {
                lstNotas.Add(System.Convert.ToDouble(lsvServicos.Items[contador].SubItems[1].Text));
            }
        }

        private void cmbServicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            blnAlternarSelecaoLsvServicos = new bool[100];
            int16AlterarValorLsvServicosNotas = new Int16[100];

            mtdIniciarLsvCmbIndice(ref lsvServicos, cmbServicos.SelectedIndex);
        }

        //private int intDtgInspecaoNumeroColuna = 0;
        //private int intDtgInspecaoNumeroLinha = 0;

        private void dtgInspecao_Click(object sender, EventArgs e)
        {
            //intDtgInspecaoNumeroColuna = dtgInspecao.CurrentCell.ColumnNumber;
            //intDtgInspecaoNumeroLinha = dtgInspecao.CurrentCell.RowNumber;
        }

        private int intLsvInspecaoNumeroColuna = 0;
        private int intLsvInspecaoNumeroLinha = 0;

        private void lsvInspecao_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection objlsvInspecao_SelectedIndexChanged = lsvInspecao.SelectedIndices;

            intLsvInspecaoNumeroColuna = 0;
            foreach (int item in objlsvInspecao_SelectedIndexChanged)
            {
                intLsvInspecaoNumeroLinha = item;
            }
        }

        private int intLsvServicosNumeroColuna = 0;
        private int intLsvServicosNumeroLinha = 0;

        private void lsvServicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection objlsvServicos_SelectedIndexChanged = lsvServicos.SelectedIndices;

            intLsvServicosNumeroColuna = 0;
            foreach (int item in objlsvServicos_SelectedIndexChanged)
            {
                intLsvServicosNumeroLinha = item;
            }
        }

        private void btnAlterarInspecao_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor; // set the wait cursor
            //Do some work

            if (mtdAlterarInspecao())
            {
                System.Windows.Forms.MessageBox.Show
                (
                    "O Item foi alterado.",
                    "Aviso!",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Exclamation,
                    System.Windows.Forms.MessageBoxDefaultButton.Button1
                );
            }
            else
            {
                System.Windows.Forms.MessageBox.Show
                (
                    "Houve erro ao alterar o item.",
                    "Aviso!",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Exclamation,
                    System.Windows.Forms.MessageBoxDefaultButton.Button1
                );
            }

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default; //restore the old cursor
        }

        private void btnIncluirInspecao_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor; // set the wait cursor
            //Do some work

            if (mtdIncluirInspecao())
            {
                System.Windows.Forms.MessageBox.Show
                (
                    "O Item foi incluido.",
                    "Aviso!",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Exclamation,
                    System.Windows.Forms.MessageBoxDefaultButton.Button1
                );
            }
            else
            {
                System.Windows.Forms.MessageBox.Show
                (
                    "Houve erro ao incluir o item.",
                    "Aviso!",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Exclamation,
                    System.Windows.Forms.MessageBoxDefaultButton.Button1
                );
            }

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default; //restore the old cursor
        }

        private void btnDeletarInspecao_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor; // set the wait cursor
            //Do some work

            if
            (
                System.Windows.Forms.MessageBox.Show
                (
                    "Deseja realmente deletar o item selecionado?",
                    "Aviso!", System.Windows.Forms.MessageBoxButtons.YesNo,
                    System.Windows.Forms.MessageBoxIcon.Exclamation,
                    System.Windows.Forms.MessageBoxDefaultButton.Button2
                )
                ==
                System.Windows.Forms.DialogResult.Yes
            )
            {
                bool blnDeletar = false;

                if (!(cmbDataInspecao.Text == string.Empty && cmbIdentificacao.Text == string.Empty))
                {
                    blnDeletar = mtdDeletarDadosTabelaInspecao
                    (
                      lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Data],
                      cmbDataInspecao.Text != string.Empty ? string.Format("'{0}'", cmbDataInspecao.Text) : "'%'",
                      lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Identificacao],
                      cmbIdentificacao.Text != string.Empty ? string.Format("'{0}'", cmbIdentificacao.Text) : "'%'"
                    );
                }

                //mtdPreencherDtgInspecao(uintNumeroLinhas, false);

                mtdPreencherLsv(ref lsvInspecao, uintNumeroLinhas, false);

                if (blnDeletar)
                {
                    System.Windows.Forms.MessageBox.Show
                    (
                        "O Item foi deletado.",
                        "Aviso!",
                        System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Exclamation,
                        System.Windows.Forms.MessageBoxDefaultButton.Button1
                    );
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show
                    (
                        "Houve erro ao deletar o item.",
                        "Aviso!",
                        System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Exclamation,
                        System.Windows.Forms.MessageBoxDefaultButton.Button1
                    );
                }
            }

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default; //restore the old cursor
        }

        private void cmbDataInspecao_GotFocus(object sender, EventArgs e)
        {
            mtdPreencherCmb
            (
                ref cmbDataInspecao,
                lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Data],
                lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Codigo],
                string.Format("'{0}'", "%")
            );
        }

        private void cmbIdentificacao_GotFocus(object sender, EventArgs e)
        {
            mtdPreencherCmb
            (
                ref cmbIdentificacao,
                lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Identificacao],
                lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Data],
                string.Format("'{0}'", cmbDataInspecao.Text)
           );
        }

        private void btnConsultarInspecao_Click(object sender, EventArgs e)
        {
            System.Data.DataTable dt = new System.Data.DataTable();

            dt = mtdSelecionarDados
            (
                lstColunasTabelaInspecao,
                strTabelaInspecao,
                lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Data],
                cmbDataInspecao.Text != string.Empty ? string.Format("'{0}'", cmbDataInspecao.Text) : "'%'",
                lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Identificacao],
                cmbIdentificacao.Text != string.Empty ? string.Format("'{0}'", cmbIdentificacao.Text) : "'%'",
                lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Codigo],
                false
            );

            mtdPreencherLsv
            (
                ref lsvInspecao,
                0,
                false,
                dt
             );
        }

        private void btnCalcularEstatistica_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor; // set the wait cursor
            //Do some work

            List<string> lstColunas = new List<string>
            { 
                lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Data],
                lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Identificacao],
                lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Servico]
            };

            List<string> lstColunas_Adicional = new List<string> { };

            lstColunas_Adicional.AddRange(lstColunas);

            lstColunas_Adicional.Add(string.Format("AVG({0}) AS {1}_{0}", lstColunasTabelaInspecao[10], "Media"));

            System.Data.DataTable dt = mtdObterDadosEstatisticos
            (
                strTabelaInspecao,
                lstColunas_Adicional,
                lstColunas,
                lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Identificacao],
                true
            );

            switch (cmbOpcaoEstatistica.SelectedIndex)
            {
                case 1:
                    mtdObterTabelaMedia(strTabelaEstatistica_01, ref dt, 2, "Media_Nota", "Media");
                    break;
                case 2:
                    mtdObterTabelaMedia(strTabelaEstatistica_01, ref dt, 2, "Media_Nota", "Media");
                    mtdObterTabelaMedia(strTabelaEstatistica_02, ref dt, 1, "Media_Media_Nota", "Media");
                    break;
            }

            mtdPreencherLsv
            (
                ref lsvEstatistica,
                0,
                false,
                dt
            );

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default; //restore the old cursor
        }

        private bool blnReparado = false;
        private bool blnCompactado = false;

        private void btnCompactarRepararBancoDados_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.MessageBox.Show
            (
            "Provavelmente essa operação demorará muito, deseja continuar?",
            "Aviso!", System.Windows.Forms.MessageBoxButtons.YesNo,
            System.Windows.Forms.MessageBoxIcon.Exclamation,
            System.Windows.Forms.MessageBoxDefaultButton.Button2
            ) == System.Windows.Forms.DialogResult.Yes)
            {
                clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                    (
                    clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                    );

                objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                    (
                    clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                    strBaseDadosColetor,
                    strSenhaBaseDadosColetor
                    );

                try
                {
                    Cursor.Current = Cursors.WaitCursor; // set the wait cursor
                    //Do some work

                    mtdRotinaPreparacaoColetor();

                    if (blnReparado && blnCompactado)
                    {
                        System.Windows.Forms.MessageBox.Show
                            (
                            "O Banco de Dados foi Compactado e Reparado.",
                            "Aviso!", System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Exclamation,
                            System.Windows.Forms.MessageBoxDefaultButton.Button1
                            );
                    }
                    else if (blnReparado)
                    {
                        System.Windows.Forms.MessageBox.Show
                            (
                            "O Banco de Dados foi somente Reparado.",
                            "Aviso!",
                            System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Exclamation,
                            System.Windows.Forms.MessageBoxDefaultButton.Button1
                            );
                    }
                    else if (blnCompactado)
                    {
                        System.Windows.Forms.MessageBox.Show
                            (
                            "O Banco de Dados foi somente Compactado.",
                            "Aviso!",
                            System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Exclamation,
                            System.Windows.Forms.MessageBoxDefaultButton.Button1
                            );
                    }
                }
                finally
                {
                    Cursor.Current = Cursors.Default; //restore the old cursor
                }

                objImplementacaoBancoDados.Dispose();
            }
        }

        private void cmbIdentificacao_LostFocus(object sender, EventArgs e)
        {
            System.Data.DataTable dt = new System.Data.DataTable();

            dt = mtdSelecionarDados
            (
                lstColunasTabelaInspecao,
                strTabelaInspecao,
                lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Identificacao],
                cmbIdentificacao.Text != string.Empty ? string.Format("'{0}'", cmbIdentificacao.Text) : "'%'",
                lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Codigo],
                true
            );

            mtdCmbIdentificacaoAjustarTblItens(dt, cmbIdentificacao.Text != string.Empty);

            mtdIniciarLsvCmbIndice(ref lsvServicos, cmbServicos.SelectedIndex);
        }

        private void cmbOpcaoEstatistica_GotFocus(object sender, EventArgs e)
        {
            mtdPreencherCmbOpcaoEstatistica();
        }

        System.DateTime TempoPressionamentoBotao = new System.DateTime();

        private bool mtdDuploPressionamento(System.DateTime TempoPressionamentoBotao, int IntervaloPressionamento_ms)
        {
            bool Retorno = false;

            if (TempoPressionamentoBotao.Millisecond - this.TempoPressionamentoBotao.Millisecond <= IntervaloPressionamento_ms)
            {
                Retorno = true;
            }

            this.TempoPressionamentoBotao = TempoPressionamentoBotao;

            return Retorno;
        }

        int intAlternarSelecaoControles = 0;

        private void frmPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Up
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Down
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                // Left
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                // Right
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                // Enter
            }
            //if (e.KeyCode == Keys.ControlKey)
            if (e.KeyValue == 211)
            {
                int intTbpControlePrincipalSelectedIndex = tbpControlePrincipal.SelectedIndex;
                switch (intTbpControlePrincipalSelectedIndex)
                {
                    case 0:
                        switch (intAlternarSelecaoControles)
                        {
                            case 0:
                                dtpDataInspecao.Focus();
                                intAlternarSelecaoControles++;
                                break;
                            case 1:
                                txtColetor.Focus();
                                intAlternarSelecaoControles++;
                                break;
                            case 2:
                                txtInspetor.Focus();
                                intAlternarSelecaoControles++;
                                break;
                            case 3:
                                txtEndereco.Focus();
                                intAlternarSelecaoControles = 0;
                                break;
                        }
                        break;
                    case 1:
                        switch (intAlternarSelecaoControles)
                        {
                            case 0:
                                cmbDataInspecao.Focus();
                                intAlternarSelecaoControles++;
                                break;
                            case 1:
                                cmbIdentificacao.Focus();
                                intAlternarSelecaoControles++;
                                break;
                            case 2:
                                lsvInspecao.Focus();
                                if (lsvInspecao.Items.Count > 0)
                                {
                                    lsvInspecao.Items[0].Selected = true;
                                }
                                intAlternarSelecaoControles++;
                                break;
                            case 3:
                                btnConsultarInspecao.Focus();
                                intAlternarSelecaoControles = 0;
                                break;
                        }
                        break;
                    case 2:
                        switch (intAlternarSelecaoControles)
                        {
                            case 0:
                                lsvServicos.Focus();
                                if (lsvServicos.Items.Count > 0)
                                {
                                    lsvServicos.Items[0].Selected = true;
                                }
                                intAlternarSelecaoControles++;
                                break;
                            case 1:
                                txtEndereco.Focus();
                                txtEndereco.Select(0, txtEndereco.Text.Length);
                                intAlternarSelecaoControles = 0;
                                break;
                        }
                        break;
                    case 3:
                        switch (intAlternarSelecaoControles)
                        {
                            case 0:
                                cmbOpcaoEstatistica.Focus();
                                intAlternarSelecaoControles++;
                                break;
                            case 1:
                                lsvEstatistica.Focus();
                                if (lsvEstatistica.Items.Count > 0)
                                {
                                    lsvEstatistica.Items[0].Selected = true;
                                }
                                intAlternarSelecaoControles++;
                                break;
                            case 2:
                                btnCalcularEstatistica.Focus();
                                intAlternarSelecaoControles = 0;
                                break;
                        }
                        break;
                    case 4:
                        btnCompactarRepararBancoDados.Focus();
                        break;
                }
            }
            //if (e.KeyCode == Keys.ShiftKey)
            if (e.KeyValue == 212)
            {
                intAlternarSelecaoControles = 0;
                tbpControlePrincipal.Focus();
            }
        }

        bool[] blnAlternarSelecaoLsvServicos = new bool[100];
        Int16[] int16AlterarValorLsvServicosNotas = new Int16[100];

        private void lsvServicos_KeyDown(object sender, KeyEventArgs e)
        {
            int intLsvServicosContadorItens = lsvServicos.Items.Count;

            try
            {
                int intValorTecla = e.KeyValue - 48;

                if (intValorTecla >= 0 & intValorTecla <= intLsvServicosContadorItens - 1)
                {
                    lsvServicos.Items[intValorTecla].Selected = true;
                    //lsvServicos.Items[intValorTecla].Checked = (blnAlternarSelecaoLsvServicos[intValorTecla] = !blnAlternarSelecaoLsvServicos[intValorTecla]);
                }
            }
            catch (System.Exception ex)
            {

            }
            if (e.KeyCode == Keys.A)
            {
                int16AlterarValorLsvServicosNotas[intLsvServicosNumeroLinha] = System.Convert.ToInt16(int16AlterarValorLsvServicosNotas[intLsvServicosNumeroLinha] <= intNotaMinima ? intNotaMaxima : int16AlterarValorLsvServicosNotas[intLsvServicosNumeroLinha] - 1);
                lsvServicos.Items[intLsvServicosNumeroLinha].SubItems[1].Text = System.Convert.ToString(int16AlterarValorLsvServicosNotas[intLsvServicosNumeroLinha]);
                mtdAtribuirNotaServicos(System.Convert.ToString(int16AlterarValorLsvServicosNotas[intLsvServicosNumeroLinha]), true);
            }
            if (e.KeyCode == Keys.D)
            {
                int16AlterarValorLsvServicosNotas[intLsvServicosNumeroLinha] = System.Convert.ToInt16(int16AlterarValorLsvServicosNotas[intLsvServicosNumeroLinha] >= intNotaMaxima ? intNotaMinima : int16AlterarValorLsvServicosNotas[intLsvServicosNumeroLinha] + 1);
                lsvServicos.Items[intLsvServicosNumeroLinha].SubItems[1].Text = System.Convert.ToString(int16AlterarValorLsvServicosNotas[intLsvServicosNumeroLinha]);
                mtdAtribuirNotaServicos(System.Convert.ToString(int16AlterarValorLsvServicosNotas[intLsvServicosNumeroLinha]), true);
            }
            if (e.KeyCode == Keys.S)
            {
                cmbServicos.SelectedIndex = cmbServicos.SelectedIndex <= 0 ? cmbServicos.Items.Count - 1 : cmbServicos.SelectedIndex - 1;
                lsvServicos.Focus();
                if (lsvServicos.Items.Count > 0)
                {
                    lsvServicos.Items[0].Selected = true;
                }
            }
            if (e.KeyCode == Keys.W)
            {
                cmbServicos.SelectedIndex = cmbServicos.SelectedIndex >= cmbServicos.Items.Count - 1 ? 0 : cmbServicos.SelectedIndex + 1;
                lsvServicos.Focus();
                if (lsvServicos.Items.Count > 0)
                {
                    lsvServicos.Items[0].Selected = true;
                }
            }
        }

        private void txtNotaServicos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                mtdAtribuirNotaServicos(txtNotaServicos.Text);
            }
        }

        private void cmbServicos_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                int intValorTecla = e.KeyValue - 48;

                if (intValorTecla >= 0 & intValorTecla <= cmbServicos.Items.Count - 1)
                {
                    cmbServicos.SelectedIndex = intValorTecla;
                }
            }
            catch (System.Exception ex)
            {

            }
        }

        private void tbpControlePrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                int intValorTecla = e.KeyValue - 48;

                if (intValorTecla >= 0 & intValorTecla <= cmbServicos.Items.Count - 1)
                {
                    tbpControlePrincipal.SelectedIndex = intValorTecla;
                }
            }
            catch (System.Exception ex)
            {

            }
        }

        private void mni1_Click(object sender, EventArgs e)
        {
            switch (mni1.Text)
            {
                case "Prox. Sel.":
                    if (cmbOpcaoEstatistica.SelectedIndex <= cmbOpcaoEstatistica.Items.Count - 2)
                    {
                        cmbOpcaoEstatistica.SelectedIndex++;
                    }
                    else
                    {
                        cmbOpcaoEstatistica.SelectedIndex = 0;
                    }
                    break;
                case "Consultar":
                    btnConsultarInspecao_Click(sender, e);
                    break;
                case "Nota":
                    mtdAtribuirNotaServicos(txtNotaServicos.Text);
                    break;
            }
        }

        private void mni2_Click(object sender, EventArgs e)
        {
            switch (mni2.Text)
            {
                case "Calcular":
                    btnCalcularEstatistica_Click(sender, e);
                    break;
                case "Deletar":
                    btnDeletarInspecao_Click(sender, e);
                    break;
                case "Incluir":
                    btnIncluirInspecao_Click(sender, e);
                    break;
                case "Sair":
                    mtdSairAplicativo();
                    break;
            }
        }

        private void btnSairAplicativo_Click(object sender, EventArgs e)
        {
            mtdSairAplicativo();
        }

        private void tbpControlePrincipal_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intTbpControlePrincipalSelectedIndex = tbpControlePrincipal.SelectedIndex;

            switch (intTbpControlePrincipalSelectedIndex)
            {
                case 1:
                    mni1.Text = "Consultar";
                    mni2.Text = "Deletar";
                    break;
                case 2:
                    mni1.Text = "Nota";
                    mni2.Text = "Incluir";
                    break;
                case 3:
                    mni1.Text = "Prox. Sel.";
                    mni2.Text = "Calcular";
                    break;
                case 4:
                    mni1.Text = "";
                    mni2.Text = "Sair";
                    break;
                default:
                    mni1.Text = string.Empty;
                    mni2.Text = string.Empty;
                    break;
            }
        }
    }
}