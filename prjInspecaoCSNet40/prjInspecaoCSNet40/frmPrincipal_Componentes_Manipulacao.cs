using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace prjInspecaoCSNet40
{
    public partial class frmPrincipal : Form
    {
        private enum enmEnviar
        {
            Nao = 0,
            Sim = 1
        }

        private uint uintComprimento = 200;

        private void mtdComponentes_Manipulacao_Load()
        {
        }

        private void mtdIniciarLsvCmbIndice(ref System.Windows.Forms.ListView Lsv, int posicao)
        {
            mtdObterVetTblColunasItens(ref Lsv, posicao);

            mtdPreencherLsvIndiceCmb(posicao);

            mtdAjustarVetTblColunasItens(Lsv, posicao);
        }

        private void mtdPreencherCmbOpcaoEstatistica()
        {
            if (cmbOpcaoEstatistica.Items.Count == 0)
            {
                cmbOpcaoEstatistica.Items.Add(string.Format("{0} - {1} - {2}", lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Data], lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Endereco], lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Servico]));
                cmbOpcaoEstatistica.Items.Add(string.Format("{0} - {1}", lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Data], lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Endereco]));
                cmbOpcaoEstatistica.Items.Add(string.Format("{0}", lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Data]));
                cmbOpcaoEstatistica.SelectedIndex = 0;
            }
        }

        private void mtdPreencherCmbEndereco()
        {
            List<string> ListaEndereco = new List<string> { };

            System.Data.DataTable dt = mtdSelecionarDadosTabelaEndereco();

            for (int linha = 0; linha <= dt.Rows.Count - 1; linha++)
            {
                ListaEndereco.Add(dt.Rows[linha].ItemArray[0].ToString());
            }

            mtdPreencherCmb(ref cmbEndereco, ListaEndereco);
        }

        private void mtdPreencherCmb(ref System.Windows.Forms.ComboBox Cmb, List<string> Cbi)
        {
            if (Cmb.Items.Count == 0)
            {
                Cmb.Items.Clear();
                foreach (string item in Cbi)
                {
                    Cmb.Items.Add(item);
                }

                if (Cmb.Items.Count != 0)
                {
                    Cmb.SelectedIndex = 0;
                }
            }
        }

        private void mtdAcrescentarItemLsv(ref System.Windows.Forms.ListView Lsv, ListViewItem Lvi)
        {
            Lsv.Items.Add(Lvi);
        }

        private void mtdIniciarLsv(ref System.Windows.Forms.ListView Lsv)
        {
            mtdIniciarLsv(ref Lsv, true);
        }

        private void mtdIniciarLsv(ref System.Windows.Forms.ListView Lsv, bool CheckBoxes)
        {
            Lsv.Clear();
            Lsv.Columns.Clear();
            Lsv.Items.Clear();

            Lsv.View = System.Windows.Forms.View.Details;
            //Lsv.LabelEdit = false;
            //Lsv.AllowColumnReorder = true;
            Lsv.CheckBoxes = CheckBoxes;
            Lsv.FullRowSelect = true;
            //Lsv.GridLines = true;
        }

        private void mtdPreencherColunasLsv(ref System.Windows.Forms.ListView Lsv, List<List<string>> Colunas)
        {
            if (Colunas.Count > 0)
            {
                foreach (List<string> coluna in Colunas)
                {
                    Lsv.Columns.Add(coluna[0], System.Convert.ToInt32(coluna[1]), HorizontalAlignment.Left);
                }
            }
        }

        private void mtdPreencherColunasLsv(ref System.Windows.Forms.ListView Lsv, System.Data.DataTable dt, uint Comprimento)
        {
            for (int coluna = 0; coluna <= dt.Columns.Count - 1; coluna++)
            {
                Lsv.Columns.Add
                    (
                    dt.Columns[coluna].Caption.ToString(),
                    (int)Comprimento,
                    HorizontalAlignment.Left
                    );
                Lsv.Columns[coluna].Width = (int)Comprimento;
            }
        }

        private void mtdPreencherDadosLsv(ref System.Windows.Forms.ListView Lsv, List<List<string>> Itens)
        {
            try
            {
                Lsv.Items.Clear();

                if (lsvServicos.Items.Count == 0)
                {
                    foreach (List<string> item in Itens)
                    {
                        mtdAcrescentarItemLsv(ref Lsv, new ListViewItem(new string[] { item[0], item[1] }));
                    }
                }
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdPreencherLsv: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void mtdPreencherDadosLsv(ref System.Windows.Forms.ListView Lsv, System.Data.DataTable dt)
        {
            int intColunaSelecionada = -1;
            int intLinhaSelecionada = -1;

            ListViewItem lvi = new ListViewItem();
            ListViewItem.ListViewSubItem lvs = new ListViewItem.ListViewSubItem();

            for (int linha = 0; linha <= dt.Rows.Count - 1; linha++)
            {
                for (int coluna = 0; coluna <= dt.Columns.Count - 1; coluna++)
                {
                    if (coluna == 0)
                    {
                        //if (dt.Rows[linha].ItemArray[coluna].ToString() == codigo.ToString())
                        //{
                        intColunaSelecionada = coluna;
                        intLinhaSelecionada = linha;
                        //}
                        lvi = new ListViewItem(dt.Rows[linha].ItemArray[coluna].ToString());
                    }
                    else
                    {
                        lvs = new ListViewItem.ListViewSubItem();
                        lvs.Text = dt.Rows[linha].ItemArray[coluna].ToString();
                        lvi.SubItems.Add(lvs);
                    }
                }

                Lsv.Items.Add(lvi);
            }

            //if (intLinhaSelecionada > -1 && intColunaSelecionada > -1)
            //{
            //    lsv1.Items[intLinhaSelecionada].Checked = true;
            //}
        }

        private void mtdIniciarDtg(ref System.Windows.Forms.DataGrid Dtg)
        {
            Dtg.GridLineStyle = System.Windows.Forms.DataGridLineStyle.Solid;
        }

        private void mtdPreencherDtg(ref System.Windows.Forms.DataGrid Dtg, System.Data.DataTable dt, uint Comprimento)
        {
            Dtg.TableStyles.Clear();
            Dtg.TableStyles.Add(mtdAjustarComprimentoColunasDtg(ref dt, (uint)Comprimento));

            Dtg.DataSource = dt;
            if (Dtg.VisibleRowCount > 0)
            {
                Dtg.Select(Dtg.VisibleRowCount - 1);
            }
        }

        private DataGridTableStyle mtdAjustarComprimentoColunasDtg(ref System.Data.DataTable dt, uint Comprimento)
        {
            DataGridTableStyle ts = new DataGridTableStyle();

            try
            {
                ts.MappingName = dt.TableName;

                foreach (DataColumn item in dt.Columns)
                {
                    DataGridTextBoxColumn tbcName = new DataGridTextBoxColumn();
                    tbcName.Width = System.Convert.ToInt32(Comprimento);
                    tbcName.MappingName = item.ColumnName;
                    tbcName.HeaderText = item.ColumnName;
                    ts.GridColumnStyles.Add(tbcName);
                }
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdAjustarComprimentoColunasDtg: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }

            return ts;
        }

        private object mtdObterValorDtg(System.Windows.Forms.DataGrid Dtg, int NumeroLinha, int NumeroColuna)
        {
            return Dtg[NumeroLinha, NumeroColuna];
        }

        private object mtdObterValorLsv(System.Windows.Forms.ListView Lsv, int NumeroLinha, int NumeroColuna)
        {
            return Lsv.Items[NumeroLinha].SubItems[NumeroColuna].Text;
        }

        private void mtdAjustarVetTblColunasItens(System.Windows.Forms.ListView Lsv, int posicao)
        {
            try
            {
                List<List<string>> tblItens = new List<List<string>>();

                for (int linha = 0; linha <= Lsv.Items.Count - 1; linha++)
                {
                    tblItens.Add(new List<string> { });

                    for (int coluna = 0; coluna <= Lsv.Items[coluna].SubItems.Count - 1; coluna++)
                    {
                        tblItens[linha].Add(Lsv.Items[linha].SubItems[coluna].Text);
                    }
                }

                mtdAjustarTblItens(ref tblItens, posicao);
            }
            catch (System.Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show(ex.Message, "Aviso!");
            }
        }

        private void mtdObterVetTblColunasItens(ref System.Windows.Forms.ListView Lsv, int posicao)
        {
            try
            {
                int intSubPosicao = 1;
                List<List<string>> tblItens = mtdObterTblItens(posicao);

                for (int contador = 0; contador <= tblItens.Count - 1; contador++)
                {
                    Lsv.Items[contador].SubItems[intSubPosicao].Text = tblItens[contador][intSubPosicao];
                }
            }
            catch (System.Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show(ex.Message, "Aviso!");
            }
        }

        public bool mtdAlterarDadosTabelaInspecao
        (
            int Enviar,
            string CampoBase,
            string Operacao,
            object DadoBase
        )
        {
            bool Retorno = false;

            tblCamposDadosTabelaInspecao = new List<List<object>> { };
            tblCamposDadosTabelaInspecao.Add(new List<object> { lstColunasTabelaInspecaoObject[(int)enmColunasTabelaInspecao.Enviar] });
            tblCamposDadosTabelaInspecao.Add
            (
                new List<object>
                { 
                    Enviar,
                    CampoBase,
                    Operacao, 
                    DadoBase 
                }
            );

            Retorno = objManipulacaoBaseDadosColetor.mtdAlterarDadosTabela(strTabelaInspecao, tblCamposDadosTabelaInspecao);

            return Retorno;
        }

        private bool mtdAlterarInspecao()
        {
            bool Retorno = true;

            if (cmbIdentificacao.Text != string.Empty)
            {
                System.Data.DataTable dt = mtdSelecionarDados
                (
                    lstColunasTabelaInspecao,
                    strTabelaInspecao,
                    lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Data],
                    string.Format("'{0}'", cmbDataInspecao.Text),
                    lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Identificacao],
                    string.Format("'{0}'", cmbIdentificacao.Text),
                    lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Codigo],
                    true
                );

                int linha = 0;

                for (int contador = 0; contador <= cmbServicos.Items.Count - 1; contador++)
                {
                    List<List<string>> tblItens = mtdObterTblItens(contador);

                    foreach (List<string> lista in tblItens)
                    {
                        if (linha <= dt.Rows.Count)
                        {
                            int codigo = System.Convert.ToInt32(dt.Rows[linha].ItemArray[(int)enmColunasTabelaInspecao.Codigo].ToString());
                            string identificaco = dt.Rows[linha].ItemArray[(int)enmColunasTabelaInspecao.Identificacao].ToString();
                            string codigoespalhamento = dt.Rows[linha++].ItemArray[(int)enmColunasTabelaInspecao.HashCode].ToString();

                            Retorno &= mtdAlterarDadosTabelaInspecao
                            (
                                codigo,
                                identificaco,
                                codigoespalhamento,
                                mtdConverterDataString(dtpDataInspecao.Value, false),
                                mtdConverterDataString(dtpDataInspecao.Value),
                                txtInspetor.Text,
                                txtColetor.Text,
                                cmbServicos.Items[contador].ToString(),
                                cmbEndereco.Text,
                                lista[(int)enmColunasTabelaInspecao.Codigo],
                                lista[(int)enmColunasTabelaInspecao.Identificacao],
                                (int)enmEnviar.Sim,
                                lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Codigo],
                                "LIKE",
                                (object)codigo
                            );
                        }
                    }
                }
            }

            //mtdPreencherDtgInspecao(uintNumeroLinhas, false);
            mtdPreencherLsv(ref lsvInspecao, uintNumeroLinhas, false);

            return Retorno;
        }

        private bool mtdIncluirInspecao()
        {
            bool Retorno = true;

            int codigo = 0;
            int identificaco = System.Convert.ToInt32(mtdGerarProximoNumeroIdentificacao(strTabelaInspecao, lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Identificacao]));

            for (int contador = 0; contador <= cmbServicos.Items.Count - 1; contador++)
            {
                List<List<string>> tblItens = mtdObterTblItens(contador);

                foreach (List<string> lista in tblItens)
                {
                    codigo = System.Convert.ToInt32(mtdGerarProximoNumeroCodigo(strTabelaInspecao, lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Codigo]));

                    Retorno = mtdInserirDadosTabelaInspecao
                    (
                        codigo,
                        identificaco,
                        mtdConverterDataString(dtpDataInspecao.Value, false),
                        mtdConverterDataString(dtpDataInspecao.Value),
                        txtInspetor.Text,
                        txtColetor.Text,
                        cmbServicos.Items[contador].ToString(),
                        cmbEndereco.Text,
                        lista[(int)enmColunasTabelaInspecao.Codigo],
                        lista[(int)enmColunasTabelaInspecao.Identificacao],
                        (int)enmEnviar.Sim
                    );
                }
            }

            //mtdPreencherDtgInspecao(uintNumeroLinhas, false);
            mtdPreencherLsv(ref lsvInspecao, uintNumeroLinhas, false);

            return Retorno;
        }

        private void mtdPreencherCmb(ref System.Windows.Forms.ComboBox Cmb, string ColunaSelecionada, string ColunaSelecionadora, string DadoSelecionador)
        {
            List<string> lst = new List<string> { };

            lst = mtdSelecionarDados
            (
                ColunaSelecionada,
                strTabelaInspecao,
                ColunaSelecionadora,
                "LIKE",
                DadoSelecionador,
                ColunaSelecionada,
                ColunaSelecionada,
                true
            );

            Cmb.Items.Clear();
            Cmb.Items.Add(string.Empty);

            for (int contador = 0; contador <= lst.Count - 1; contador++)
            {
                Cmb.Items.Add(lst[contador]);
            }

            Cmb.SelectedIndex = 0;
        }

        private List<List<object>> tblDadosEstatisticos = new List<List<object>> { };

        private System.Data.DataTable mtdObterDadosEstatisticos(string Tabela, List<string> ListaColuna, List<string> ListaGrupoColuna, string ColunaOrdenadora, bool Crescente)
        {
            System.Data.DataTable Retorno = new System.Data.DataTable { };

            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados();

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
            (
                clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                frmPrincipal.strBaseDadosColetor,
                frmPrincipal.strSenhaBaseDadosColetor
            );

            objImplementacaoBancoDados.mtdAbrirConexao();
            objImplementacaoBancoDados.mtdExecutarComando
            (
                string.Format
                (
                    "SELECT DISTINCT {0} FROM {1} GROUP BY {2} ORDER BY {3}{4}",
                    objImplementacaoBancoDados.mtdListaLinhaCampos(ListaColuna),
                    Tabela,
                    objImplementacaoBancoDados.mtdListaLinhaCampos(ListaGrupoColuna),
                    ColunaOrdenadora,
                    Crescente ? string.Empty : " DESC"
                )
            );

            objImplementacaoBancoDados.mtdAdaptadorDados();

            Retorno = objImplementacaoBancoDados.prpAjustadorDados.Tables[0];

            objImplementacaoBancoDados.Dispose();

            return Retorno;
        }

        private void mtdPreehcerDadosTabelaEstatistica(string Tabela, System.Data.DataTable Dt, string ColunaSelecionadora, string DadoSelecionador, List<object> ListaColunas)
        {
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados();

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
            (
                clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                frmPrincipal.strBaseDadosColetor,
                frmPrincipal.strSenhaBaseDadosColetor
            );

            mtdDeletarDadosTabelaEstatistica(Tabela, ColunaSelecionadora, DadoSelecionador);

            List<List<object>> Dados = new List<List<object>> { };

            Dados.Add(ListaColunas);

            for (int linha = 0; linha <= Dt.Rows.Count - 1; linha++)
            {
                Dados.Add(new List<object> { });

                for (int coluna = 0; coluna <= Dt.Columns.Count - 1; coluna++)
                {
                    Dados[linha + 1].Add(Dt.Rows[linha].ItemArray[coluna]);
                }
            }

            objImplementacaoBancoDados.mtdInserirDadosParametroComandoSQLServerCE(Tabela, Dados, enmModoParametroComando.Valor);
            objImplementacaoBancoDados.Dispose();
        }

        private void mtdPrepararTabelaEstatisticaMedia(string Tabela, List<string> NomesColunas, List<string> TiposColunas, System.Data.DataTable Dt, string ColunaSelecionadora)
        {
            System.Data.DataTable Retorno = new System.Data.DataTable();

            mtdCriarTabelaEstatistica(Tabela, NomesColunas, TiposColunas);

            lstColunasTabelaEstatisticaObject.Clear();
            lstColunasTabelaEstatisticaObject.AddRange(mtdGerarListaColunasTabelaEstatistica(NomesColunas));

            mtdPreehcerDadosTabelaEstatistica(Tabela, Dt, ColunaSelecionadora, "%", lstColunasTabelaEstatisticaObject);
        }

        private void mtdCalcularMediaTabelaEstatisticaMedia(string Tabela, List<string> NomesColunas, ref System.Data.DataTable Dt, string MediaColuna, string AcrescentarColuna)
        {
            List<string> NomesColunas_Adicional = new List<string> { };
            NomesColunas_Adicional.Clear();
            NomesColunas_Adicional = new List<string> { };

            NomesColunas_Adicional.AddRange(NomesColunas);
            NomesColunas_Adicional.Add(string.Format("AVG({0}) AS {1}_{0}", MediaColuna, AcrescentarColuna));

            Dt = mtdObterDadosEstatisticos
            (
                Tabela,
                NomesColunas_Adicional,
                NomesColunas,
                NomesColunas[0],
                true
            );
        }

        private void mtdObterListaNomesTiposColunas(ref List<string> ListaNomesColunas, ref List<string> ListaTiposColunas, ref System.Data.DataTable Dt)
        {
            ListaNomesColunas.Clear();
            ListaTiposColunas.Clear();

            for (int coluna = 0; coluna <= Dt.Columns.Count - 1; coluna++)
            {
                ListaNomesColunas.Add(Dt.Columns[coluna].ColumnName);

                switch (Dt.Columns[coluna].DataType.FullName)
                {
                    case "System.String":
                        ListaTiposColunas.Add("NVARCHAR");
                        break;
                    case "System.Double":
                        ListaTiposColunas.Add("FLOAT");
                        break;
                }
            }
        }

        private void mtdObterTabelaMedia(string NomeTabela, ref System.Data.DataTable Dt, int NumeroColunas, string MediaColuna, string AcrescentarColuna)
        {
            List<string> lstColunas = new List<string> { };

            List<string> ListaNomesCampos = new List<string> { };
            List<string> ListaTiposCampos = new List<string> { };

            mtdObterListaNomesTiposColunas(ref ListaNomesCampos, ref ListaTiposCampos, ref Dt);

            lstColunas.Clear();
            lstColunas.AddRange(ListaNomesCampos);

            mtdPrepararTabelaEstatisticaMedia(NomeTabela, lstColunas, ListaTiposCampos, Dt, lstColunas[0]);

            lstColunas.Clear();
            for (int contador = 0; contador <= NumeroColunas - 1; contador++)
            {
                lstColunas.Add(ListaNomesCampos[contador]);
            }

            mtdCalcularMediaTabelaEstatisticaMedia(NomeTabela, lstColunas, ref  Dt, MediaColuna, AcrescentarColuna);
        }

        private void mtdCmbIdentificacaoAjustarTblItens_PreencherValorAleatorio(System.Data.DataTable dt, bool DadoVazio)
        {
            Random rnd = new Random();
            int linha = 0;

            for (int contador = 0; contador <= cmbServicos.Items.Count - 1; contador++)
            {
                List<List<string>> tblItens = mtdObterTblItens(contador);

                for (int contadorLista = 0; contadorLista <= tblItens.Count - 1; contadorLista++)
                {
                    tblItens[contadorLista][1] = DadoVazio ? dt.Rows[linha++].ItemArray[10].ToString() : System.Convert.ToString(System.Convert.ToInt32(rnd.Next(0, 3)));
                }

                mtdAjustarTblItens(ref tblItens, contador);
            }
        }

        private void mtdCmbIdentificacaoAjustarTblItens_PreencherValor(System.Data.DataTable dt, bool DadoVazio, string Valor)
        {
            int linha = 0;

            for (int contador = 0; contador <= cmbServicos.Items.Count - 1; contador++)
            {
                List<List<string>> tblItens = mtdObterTblItens(contador);

                for (int contadorLista = 0; contadorLista <= tblItens.Count - 1; contadorLista++)
                {
                    tblItens[contadorLista][1] = DadoVazio ? dt.Rows[linha++].ItemArray[10].ToString() : Valor;
                }

                mtdAjustarTblItens(ref tblItens, contador);
            }
        }

        private void mtdCmbIdentificacaoAjustarTblItens_PreencherValorIntervalo(System.Data.DataTable dt, bool DadoVazio, string ValorInferior, string ValorSuperior)
        {
            int linha = 0;
            int Valor = 0;
            Valor = System.Convert.ToInt32(ValorInferior) - 1;

            for (int contador = 0; contador <= cmbServicos.Items.Count - 1; contador++)
            {
                List<List<string>> tblItens = mtdObterTblItens(contador);

                for (int contadorLista = 0; contadorLista <= tblItens.Count - 1; contadorLista++)
                {
                    tblItens[contadorLista][1] = DadoVazio ? dt.Rows[linha++].ItemArray[10].ToString() : System.Convert.ToString(++Valor <= System.Convert.ToInt32(ValorSuperior) ? Valor : Valor = System.Convert.ToInt32(ValorInferior));
                }

                mtdAjustarTblItens(ref tblItens, contador);
            }
        }

        private void mtdPreencherLsvServicos(string Conteudo)
        {
            System.Data.DataTable dt = new System.Data.DataTable();

            dt = mtdSelecionarDados
            (
                lstColunasTabelaInspecao,
                strTabelaInspecao,
                lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Identificacao],
                cmbIdentificacao.Text != string.Empty ? string.Format("'{0}'", Conteudo) : "'%'",
                lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Codigo],
                true
            );

            mtdCmbIdentificacaoAjustarTblItens_PreencherValorAleatorio(dt, Conteudo != string.Empty);

            mtdIniciarLsvCmbIndice(ref lsvServicos, cmbServicos.SelectedIndex);
        }

        private void mtdPreencherLsvServicos(string Conteudo, string Valor)
        {
            System.Data.DataTable dt = new System.Data.DataTable();

            dt = mtdSelecionarDados
            (
                lstColunasTabelaInspecao,
                strTabelaInspecao,
                lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Identificacao],
                cmbIdentificacao.Text != string.Empty ? string.Format("'{0}'", Conteudo) : "'%'",
                lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Codigo],
                true
            );

            mtdCmbIdentificacaoAjustarTblItens_PreencherValor(dt, Conteudo != string.Empty, Valor);

            mtdIniciarLsvCmbIndice(ref lsvServicos, cmbServicos.SelectedIndex);
        }

        private void mtdPreencherLsvServicos(string Conteudo, string ValorInferior, string ValorSuperior)
        {
            System.Data.DataTable dt = new System.Data.DataTable();

            dt = mtdSelecionarDados
            (
                lstColunasTabelaInspecao,
                strTabelaInspecao,
                lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Identificacao],
                cmbIdentificacao.Text != string.Empty ? string.Format("'{0}'", Conteudo) : "'%'",
                lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Codigo],
                true
            );

            mtdCmbIdentificacaoAjustarTblItens_PreencherValorIntervalo(dt, Conteudo != string.Empty, ValorInferior, ValorSuperior);

            mtdIniciarLsvCmbIndice(ref lsvServicos, cmbServicos.SelectedIndex);
        }
    }
}