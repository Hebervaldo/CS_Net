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
        private clsManipuladorTexto objManipuladorTexto = new clsManipuladorTexto();

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            txtLegenda.Text = mtdObterLegenda();

            DiretorioArmazenamentoCompleto = mtdObterEnderecoBancoDadosColetor();

            mtdAjustarEnderecoNomeTextoBancoDados(DiretorioArmazenamentoCompleto);
            DiretorioArmazenamentoCompleto = mtdGerarCaminhoBaseDadosColetor(strEnderecoBancoDadosColetor, strNomeBancoDadosColetor);

            strSenhaBaseDadosColetor = mtdObterSenhaBancoDadosColetor();
            txtSenhaBancoDados.Text = strSenhaBaseDadosColetor;

            objManipulacaoBaseDadosColetor = new clsManipulacaoBaseDados(strBaseDadosColetor, strSenhaBaseDadosColetor);

            mtdBaseDados_Load();
            mtdComponentes_Manipulacao_Load();

            mtdPreencherCmbServicos();
            mtdPreencherLsv(ref lsvInspecao, uintNumeroLinhas, false);
            mtdPreencherCmbEndereco();
            //mtdIniciarDtgInspecao();
            //mtdPreencherDtgInspecao(uintNumeroLinhas, false);

            mtdIniciarTblColunasItens();
            mtdIniciarLsvCmbIndice(ref lsvServicos, 0);
            mtdObterMediaNotaServicos();
            mtdPreencherCmbOpcaoEstatistica();

            btnConsultarInspecao_Click(sender, e);

            string strColetor = mtdObterConteudoCamposDadosColetor(0);
            txtColetor.Text = strColetor == string.Empty ? System.Net.Dns.GetHostName() : strColetor;

            txtInspetor.Text = mtdObterConteudoCamposDadosColetor(1);
            cmbEndereco.Text = mtdObterConteudoCamposDadosColetor(2);

            string strEnderecoWebService = mtdObterConteudoCamposDadosColetor(3);
            strEnderecoWebService = strEnderecoWebService == string.Empty ? objWebServiceInspecao.Url : strEnderecoWebService;
            txtEnderecoWebService.Text = strEnderecoWebService;
            if (strEnderecoWebService != string.Empty)
            {
                objWebServiceInspecao.Url = strEnderecoWebService;
            }

            mtdSincronizarHorarioServidor(false);
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
        // private void cmbDataInspecao_Enter(object sender, EventArgs e)
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
        // private void cmbIdentificacao_Enter(object sender, EventArgs e)
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
                lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Endereco],
                lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Servico]
            };

            List<string> lstColunas_Adicional = new List<string> { };

            lstColunas_Adicional.AddRange(lstColunas);

            lstColunas_Adicional.Add(string.Format("AVG({0}) AS {1}_{0}", lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Nota], "Media"));

            System.Data.DataTable dt = mtdObterDadosEstatisticos
            (
                strTabelaInspecao,
                lstColunas_Adicional,
                lstColunas,
                lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Data],
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

        private bool blnCriado = false;

        private void btnCriarBancoDados_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.MessageBox.Show
            (
            "Deseja criar o Banco de Dados?",
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

                    if (blnCriado)
                    {
                        System.Windows.Forms.MessageBox.Show
                            (
                            "O Banco de Dados foi Criado com sucesso.",
                            "Aviso!", System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Exclamation,
                            System.Windows.Forms.MessageBoxDefaultButton.Button1
                            );
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show
                            (
                            "Houve algum erro ao Criar o Banco de Dados.",
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

        private void btnCriarTabelas_Click(object sender, EventArgs e)
        {

            bool Retorno = true;

            if
            (
                System.Windows.Forms.MessageBox.Show
                (
                    "Deseja criar as Tabelas DadosCamposColetor, Endereco e Inspecao?",
                    "Aviso!",
                    System.Windows.Forms.MessageBoxButtons.YesNo,
                    System.Windows.Forms.MessageBoxIcon.Question,
                    System.Windows.Forms.MessageBoxDefaultButton.Button2
                )
                ==
                System.Windows.Forms.DialogResult.Yes
            )
            {
                Retorno &= mtdCriarTabelaInspecao();
                Retorno &= mtdCriarTabelaCamposDadosColetor();
                Retorno &= mtdCriarTabelaEndereco();

                if (Retorno)
                {
                    System.Windows.Forms.MessageBox.Show
                    (
                        "As Tabelas foram criadas.",
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
                        "Nao foi possivel criar algumas das Tabelas.",
                        "Aviso!",
                        System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Exclamation,
                        System.Windows.Forms.MessageBoxDefaultButton.Button1
                    );
                }
            }
        }

        private void btnDeletarTabelas_Click(object sender, EventArgs e)
        {
            bool Retorno = true;

            if
            (
                System.Windows.Forms.MessageBox.Show
                (
                    "Deseja deletar as Tabelas DadosCamposColetor, Endereco e Inspecao?",
                    "Aviso!",
                    System.Windows.Forms.MessageBoxButtons.YesNo,
                    System.Windows.Forms.MessageBoxIcon.Question,
                    System.Windows.Forms.MessageBoxDefaultButton.Button2
                )
                ==
                System.Windows.Forms.DialogResult.Yes
            )
            {
                Retorno &= mtdDeletarTabela(strTabelaDadosCamposColetor);
                Retorno &= mtdDeletarTabela(strTabelaEndereco);
                Retorno &= mtdDeletarTabela(strTabelaInspecao);

                if (Retorno)
                {
                    System.Windows.Forms.MessageBox.Show
                    (
                        "As Tabelas foram deletadas.",
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
                        "Nao foi possivel deletar algumas das Tabelas.",
                        "Aviso!",
                        System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Exclamation,
                        System.Windows.Forms.MessageBoxDefaultButton.Button1
                    );
                }
            }
        }

        private void cmbIdentificacao_LostFocus(object sender, EventArgs e)
        {
            mtdPreencherLsvServicos(cmbIdentificacao.Text, "0");
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
                                cmbEndereco.Focus();
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
                                cmbEndereco.Focus();
                                cmbEndereco.Select(0, cmbEndereco.Text.Length);
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
                cmbServicos.SelectedIndex = cmbServicos.SelectedIndex >= cmbServicos.Items.Count - 1 ? 0 : cmbServicos.SelectedIndex + 1;
                lsvServicos.Focus();
                if (lsvServicos.Items.Count > 0)
                {
                    lsvServicos.Items[0].Selected = true;
                }
            }
            if (e.KeyCode == Keys.W)
            {
                cmbServicos.SelectedIndex = cmbServicos.SelectedIndex <= 0 ? cmbServicos.Items.Count - 1 : cmbServicos.SelectedIndex - 1;
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
                case "Comp. Rep.":
                    btnCompactarRepararBancoDados_Click(sender, e);
                    break;
                case "Consultar":
                    btnConsultarInspecao_Click(sender, e);
                    break;
                case "Nota":
                    mtdAtribuirNotaServicos(txtNotaServicos.Text);
                    break;
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
                case "Sincronizar":
                    mtdSincronizarHorarioServidor();
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
                    mni1.Text = "Comp. Rep.";
                    mni2.Text = "Sair";
                    break;
                case 5:
                    mni1.Text = "Sincronizar";
                    mni2.Text = "Sair";
                    break;
                default:
                    mni1.Text = string.Empty;
                    mni2.Text = string.Empty;
                    break;
            }
        }

        private void btnWebServiceUpload_Click(object sender, EventArgs e)
        {
            bool blnEnvio = false;

            try
            {
                blnEnvio = mtdUploadWebService(chbForcarUpload.Checked);
            }
            catch (System.Exception)
            {
                blnEnvio = false;
            }
            
            if (blnEnvio)
            {
                System.Windows.Forms.MessageBox.Show
                (
                "Os dados foram transferidos com sucesso.",
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
                    "Houve algum erro ao transferir os dados.",
                    "Aviso!",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Exclamation,
                    System.Windows.Forms.MessageBoxDefaultButton.Button1
                );
            }
        }

        private void btnZerar_Click(object sender, EventArgs e)
        {
            mtdPreencherLsvServicos(string.Empty, "0");
        }

        private void btnPreencher_Um_Click(object sender, EventArgs e)
        {
            mtdPreencherLsvServicos(string.Empty, "1");
        }

        private void btnPreencher_Dois_Click(object sender, EventArgs e)
        {
            mtdPreencherLsvServicos(string.Empty, "2");
        }

        private void btnPreencher_Zero_Um_Click(object sender, EventArgs e)
        {
            mtdPreencherLsvServicos(string.Empty, "0", "1");
        }

        private void btnPreencher_Zero_Um_Dois_Click(object sender, EventArgs e)
        {
            mtdPreencherLsvServicos(string.Empty, "0", "2");
        }

        private void btnPreencher_Valor_Aleatorio_Click(object sender, EventArgs e)
        {
            mtdPreencherLsvServicos(string.Empty);
        }

        private void mtdAjustarConteudoCamposDadosColetor(int posicao, string Dados)
        {
            if
            (
                !mtdInserirDadosTabelaDadosCamposColetor
                (
                    posicao,
                    Dados
                )
            )
            {
                mtdAlterarDadosTabelaDadosCamposColetor
                (
                    posicao,
                    Dados,
                    lstColunasTabelaDadosCamposColetor[(int)enmColunasTabelaDadosCamposColetor.Campos],
                    "LIKE",
                    posicao
                );
            }
        }

        private string mtdObterConteudoCamposDadosColetor(int posicao)
        {
            string Retorno = string.Empty;

            try
            {
                System.Data.DataTable dt = mtdSelecionarDadosTabelaDadosCamposColetor
                (
                    0,
                    lstColunasTabelaDadosCamposColetor[(int)enmColunasTabelaDadosCamposColetor.Campos],
                    "LIKE",
                    string.Format("{0}", posicao),
                    lstColunasTabelaDadosCamposColetor[(int)enmColunasTabelaDadosCamposColetor.Campos],
                    true
                );

                Retorno = dt.Rows[0].ItemArray[1].ToString();
            }
            catch (System.Exception ex)
            {
                mtdInserirDadosTabelaDadosCamposColetor
                (
                    posicao,
                    Retorno
                );
            }

            return Retorno;
        }

        private void txtColetor_LostFocus(object sender, EventArgs e)
        // private void txtColetor_Leave(object sender, EventArgs e)
        {
            txtColetor.Text = objManipuladorTexto.mtdExecutarTudo(txtColetor.Text);

            mtdAjustarConteudoCamposDadosColetor(0, txtColetor.Text);
        }

        private void txtInspetor_LostFocus(object sender, EventArgs e)
        // private void txtInspetor_Leave(object sender, EventArgs e)
        {
            txtInspetor.Text = objManipuladorTexto.mtdExecutarTudo(txtInspetor.Text);

            mtdAjustarConteudoCamposDadosColetor(1, txtInspetor.Text);
        }

        private void txtEndereco_LostFocus(object sender, EventArgs e)
        {
            cmbEndereco.Text = objManipuladorTexto.mtdExecutarTudo(cmbEndereco.Text);

            mtdAjustarConteudoCamposDadosColetor(2, cmbEndereco.Text);
        }

        private void txtEnderecoWebService_LostFocus(object sender, EventArgs e)
        // private void txtEnderecoWebService_Leave(object sender, EventArgs e)
        {
            string strEnderecoWebService = txtEnderecoWebService.Text;

            mtdAjustarConteudoCamposDadosColetor(3, strEnderecoWebService);

            if (strEnderecoWebService != string.Empty)
            {
                objWebServiceInspecao.Url = strEnderecoWebService;
            }
        }

        private string mtdAbrirArquivoDialogo()
        {
            string Retorno = string.Empty;

            //define as propriedades do controle 
            //OpenFileDialog
            ofd1.InitialDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);

            //filtra para exibir somente arquivos de imagens
            ofd1.Filter = "Arquivos do SQL Server CE (*.sdf)|*.sdf|Todos Arquivos (*.*)|*.*";
            ofd1.FilterIndex = 1;

            DialogResult dr = this.ofd1.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                // Le os arquivos selecionados 
                Retorno = strBaseDadosColetor = ofd1.FileName;
            }

            return Retorno;
        }

        private void btnAbrirArquivoDialogo_Click(object sender, EventArgs e)
        {
            DiretorioArmazenamentoCompleto = mtdAbrirArquivoDialogo();
            mtdAjustarEnderecoNomeTextoBancoDados(DiretorioArmazenamentoCompleto);
        }

        private void txtEnderecoBancoDados_LostFocus(object sender, EventArgs e)
        // private void txtEnderecoBancoDados_Leave(object sender, EventArgs e)
        {
            DiretorioArmazenamentoCompleto = txtEnderecoBancoDados.Text;
            mtdAjustarEnderecoNomeTextoBancoDados(DiretorioArmazenamentoCompleto);
        }

        private void txtSenhaBancoDados_LostFocus(object sender, EventArgs e)
        {
            strSenhaBaseDadosColetor = txtSenhaBancoDados.Text;
            mtdAjustarSenhaBancoDadosColetor(strSenhaBaseDadosColetor);
        }

        private void btnEnderecoBancoDadosFlashDisk_Click(object sender, EventArgs e)
        {
            strEnderecoBancoDadosColetor = strEnderecoFlashDisk;
            strNomeBancoDadosColetor = cntNomeBancoDadosColetor;
            DiretorioArmazenamentoCompleto = mtdGerarCaminhoBaseDadosColetor(strEnderecoBancoDadosColetor, strNomeBancoDadosColetor);
            mtdAjustarEnderecoNomeTextoBancoDados(DiretorioArmazenamentoCompleto);
            strSenhaBaseDadosColetor = cntSenhaBaseDadosColetor;
            mtdCriarBaseDadosColetor();
            if (!mtdTestarConexao(DiretorioArmazenamentoCompleto, strSenhaBaseDadosColetor))
            {
                mtdAjustarEnderecoNomeTextoBancoDados(mtdGerarCaminhoBaseDadosColetor(cntEnderecoBancoDadosColetor, cntNomeBancoDadosColetor));
                strSenhaBaseDadosColetor = cntSenhaBaseDadosColetor;
                txtSenhaBancoDados.Text = strSenhaBaseDadosColetor;
            }
        }

        private void btnEnderecoBancoDadosStorageCard_Click(object sender, EventArgs e)
        {
            strEnderecoBancoDadosColetor = strEnderecoStorageCard;
            strNomeBancoDadosColetor = cntNomeBancoDadosColetor;
            DiretorioArmazenamentoCompleto = mtdGerarCaminhoBaseDadosColetor(strEnderecoBancoDadosColetor, strNomeBancoDadosColetor);
            mtdAjustarEnderecoNomeTextoBancoDados(DiretorioArmazenamentoCompleto);
            strSenhaBaseDadosColetor = cntSenhaBaseDadosColetor;
            mtdCriarBaseDadosColetor();
            if (!mtdTestarConexao(DiretorioArmazenamentoCompleto, strSenhaBaseDadosColetor))
            {
                mtdAjustarEnderecoNomeTextoBancoDados(mtdGerarCaminhoBaseDadosColetor(cntEnderecoBancoDadosColetor, cntNomeBancoDadosColetor));
                strSenhaBaseDadosColetor = cntSenhaBaseDadosColetor;
                txtSenhaBancoDados.Text = strSenhaBaseDadosColetor;
            }
        }

        private void btnEnderecoBancoDadosPadrao_Click(object sender, EventArgs e)
        {
            mtdCriarBaseDadosColetor();
            mtdAjustarEnderecoNomeTextoBancoDados(mtdGerarCaminhoBaseDadosColetor(cntEnderecoBancoDadosColetor, cntNomeBancoDadosColetor));
            strSenhaBaseDadosColetor = cntSenhaBaseDadosColetor;
            txtSenhaBancoDados.Text = strSenhaBaseDadosColetor;
        }

        private void btnTestarEnderecoBancoDados_Click(object sender, EventArgs e)
        {
            mtdTestarConexao_();
        }

        private void btnSincronizarHorarioServidor_Click(object sender, EventArgs e)
        {
            mtdSincronizarHorarioServidor();
        }

        private void txtNotaServicos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!objManipuladorTexto.mtdPermitirDigitarSoNumero(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnWebServiceDownload_Click(object sender, EventArgs e)
        {
            bool Retorno = true;

            try
            {
                Retorno &= mtdDeletarDadosTabelaEndereco(lstColunasTabelaEndereco[(int)enmColunasTabelaEndereco.Endereco], "%");

                System.Data.DataSet dt = objWebServiceInspecao.mtdObterDadosTabelaEndereco();

                for (int linha = 0; linha <= dt.Tables[0].Rows.Count - 1; linha++)
                {
                    Retorno &= mtdInserirDadosTabelaEndereco(dt.Tables[0].Rows[linha].ItemArray[(int)enmColunasTabelaEndereco.Endereco].ToString());
                }
            }
            catch (System.Exception ex)
            {
                Retorno = false;
            }

            if (Retorno)
            {
                System.Windows.Forms.MessageBox.Show
                (
                    "Os dados foram transferidos.",
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
                    "Houve algum erro ao transferir os dados.",
                    "Aviso!",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Exclamation,
                    System.Windows.Forms.MessageBoxDefaultButton.Button1
                );
            }
        }

        private void cmbEndereco_KeyDown(object sender, KeyEventArgs e)
        // private void cmbEndereco_Click(object sender, EventArgs e)
        {
            mtdPreencherCmbEndereco();
        }
    }
}