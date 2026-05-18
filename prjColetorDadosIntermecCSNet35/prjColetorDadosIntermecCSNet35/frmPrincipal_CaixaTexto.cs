using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace prjColetorDadosIntermecCSNet35
{
    public partial class frmPrincipal
    {
        private void mtdProcurarCaixaTexto()
        {
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                (
                clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                );

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                (
                clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                strBaseDadosColetor,
                strSenhaColetor
                );

            try
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor; // set the wait cursor
                //Do some work

                clsManipuladorTexto objManipuladorTexto = new clsManipuladorTexto();

                switch (strTextoSelecionado)
                {
                    case "txtTRGItem":
                        objImplementacaoBancoDados.mtdSelecionarDados
                            (
                            vetCamposTabelaBensEletronorte,
                            strTabelaBensEletronorte,
                            string.Format
                            (
                            "{0}",
                            vetCamposTabelaBensEletronorte[intColunaTabelaBensEletronorteTRG]
                            ),
                            "LIKE",
                            string.Format
                            (
                            "N'%{0}%'",
                            txtTRGItem.Text
                            ),
                            string.Format
                            (
                            "{0}",
                            vetCamposTabelaBensEletronorte[intColunaTabelaBensEletronortePatrimonio]
                            ),
                            true
                            );
                        break;
                    case "txtCentroCustoItem":
                        objImplementacaoBancoDados.mtdSelecionarDados
                            (
                            vetCamposTabelaBensEletronorte,
                            strTabelaBensEletronorte,
                            string.Format
                            (
                            "{0}",
                            vetCamposTabelaBensEletronorte[intColunaTabelaBensEletronorteCentro_Custo]
                            ),
                            "LIKE",
                            string.Format
                            (
                            "N'%{0}%'",
                            txtCentroCustoItem.Text
                            ),
                            string.Format
                            (
                            "{0}",
                            vetCamposTabelaBensEletronorte[intColunaTabelaBensEletronortePatrimonio]
                            ),
                            true
                            );
                        break;
                    case "txtOrgaoItem":
                        objImplementacaoBancoDados.mtdSelecionarDados
                            (
                            vetCamposTabelaBensEletronorte,
                            strTabelaBensEletronorte,
                            string.Format
                            (
                            "{0}",
                            vetCamposTabelaBensEletronorte[intColunaTabelaBensEletronorteOrgao]
                            ),
                            "LIKE",
                            string.Format
                            (
                            "N'%{0}%'",
                            txtOrgaoItem.Text
                            ),
                            string.Format
                            (
                            "{0}",
                            vetCamposTabelaBensEletronorte[intColunaTabelaBensEletronortePatrimonio]
                            ),
                            true
                            );
                        break;
                    case "txtNomeItem":
                        objImplementacaoBancoDados.mtdAbrirConexao();
                        objImplementacaoBancoDados.mtdExecutarComando
                            (
                            string.Format
                            (
                            "SELECT {0} FROM {1} WHERE {2} IN (SELECT {3} FROM {4} WHERE {5} LIKE {6}) ORDER BY {7}{8};",
                            objImplementacaoBancoDados.mtdVetorLinhaCampos(vetCamposTabelaBensEletronorte),
                            strTabelaBensEletronorte,
                            vetCamposTabelaBensEletronorte[intColunaTabelaBensEletronorteMatricula],
                            vetCamposTabelaEmpregados[intColunaTabelaEmpregadosMatricula],
                            strTabelaEmpregados,
                            vetCamposTabelaEmpregados[intColunaTabelaEmpregadosNome],
                            string.Format
                            (
                            "N'%{0}%'",
                            txtNomeItem.Text
                            ),
                            vetCamposTabelaBensEletronorte[intColunaTabelaBensEletronortePatrimonio],
                            string.Empty
                            )
                            );
                        break;
                    case "txtMatriculaItem":
                        objImplementacaoBancoDados.mtdSelecionarDados
                            (
                            vetCamposTabelaBensEletronorte,
                            strTabelaBensEletronorte,
                            string.Format
                            (
                            "{0}",
                            vetCamposTabelaBensEletronorte[intColunaTabelaBensEletronorteMatricula]
                            ),
                            "LIKE",
                            string.Format
                            (
                            "N'%{0}%'",
                            txtMatriculaItem.Text
                            ),
                            string.Format
                            (
                            "{0}",
                            vetCamposTabelaBensEletronorte[intColunaTabelaBensEletronortePatrimonio]
                            ),
                            true
                            );
                        break;
                    case "txtPatrimonioItem":
                        objImplementacaoBancoDados.mtdSelecionarDados
                            (
                            vetCamposTabelaBensEletronorte,
                            strTabelaBensEletronorte,
                            string.Format
                            (
                            "{0}",
                            vetCamposTabelaBensEletronorte[intColunaTabelaBensEletronortePatrimonio]
                            ),
                            "LIKE",
                            string.Format
                            (
                            "N'%{0}%'",
                            txtPatrimonioItem.Text
                            ),
                            string.Format
                            (
                            "{0}",
                            vetCamposTabelaBensEletronorte[intColunaTabelaBensEletronortePatrimonio]
                            ),
                            true
                            );
                        break;
                    case "txtDenominacaoItem":
                        objImplementacaoBancoDados.mtdSelecionarDados
                            (
                            vetCamposTabelaBensEletronorte,
                            strTabelaBensEletronorte,
                            string.Format
                            (
                            "{0}",
                            vetCamposTabelaBensEletronorte[intColunaTabelaBensEletronorteDenominacao]
                            ),
                            "LIKE",
                            string.Format
                            (
                            "N'%{0}%'",
                            txtDenominacaoItem.Text
                            ),
                            string.Format
                            (
                            "{0}",
                            vetCamposTabelaBensEletronorte[intColunaTabelaBensEletronortePatrimonio]
                            ),
                            true
                            );
                        break;
                    case "txtNSerieItem":
                        objImplementacaoBancoDados.mtdSelecionarDados
                            (
                            vetCamposTabelaBensEletronorte,
                            strTabelaBensEletronorte,
                            string.Format
                            (
                            "{0}",
                            vetCamposTabelaBensEletronorte[intColunaTabelaBensEletronorteN_Serie]
                            ),
                            "LIKE",
                            string.Format
                            (
                            "N'%{0}%'",
                            txtNSerieItem.Text
                            ),
                            string.Format
                            (
                            "{0}",
                            vetCamposTabelaBensEletronorte[intColunaTabelaBensEletronortePatrimonio]
                            ),
                            true
                            );
                        break;
                    case "txtPlacaVeiculoItem":
                        objImplementacaoBancoDados.mtdSelecionarDados
                          (
                          vetCamposTabelaBensEletronorte,
                          strTabelaBensEletronorte,
                          string.Format
                          (
                          "{0}",
                          vetCamposTabelaBensEletronorte[intColunaTabelaBensEletronortePlaca_Veiculo]
                          ),
                          "LIKE",
                          string.Format
                          (
                          "N'%{0}%'",
                          txtPlacaVeiculoItem.Text
                          ),
                          string.Format
                          (
                          "{0}",
                          vetCamposTabelaBensEletronorte[intColunaTabelaBensEletronortePatrimonio]
                          ),
                          true
                          );
                        break;
                }
                objImplementacaoBancoDados.mtdDefinirLeitorDados();
                if (objImplementacaoBancoDados.mtdProximoRegistro())
                {
                    txtTRGItem.Text = btnTRGItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)) ?
                        objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaBensEletronorteTRG).ToString() :
                        txtTRGItem.Text;
                    txtCentroCustoItem.Text = btnCentroCustoItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)) ?
                        objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaBensEletronorteCentro_Custo).ToString() :
                        txtCentroCustoItem.Text;
                    //txtOrgaoItem.Text = objImplementacaoBancoDados.mtdObterValorRegistro(x).ToString();
                    string strOrgaoItem = objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaBensEletronorteOrgao).ToString();
                    txtOrgaoItem.Text = btnOrgaoItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)) ?
                        objManipuladorTexto.mtdExecutarTudo
                        (
                        strOrgaoItem.Split(' ')[strOrgaoItem.Split(' ').GetLowerBound(0)]
                        ) :
                        txtOrgaoItem.Text;
                    txtSalaItem.Text = btnSalaItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)) ?
                        objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaBensEletronorteSala).ToString() :
                        txtSalaItem.Text;
                    txtNomeItem.Text = btnNomeItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)) ?
                        string.Empty :
                        txtNomeItem.Text;
                    txtMatriculaItem.Text = btnMatriculaItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)) ?
                        objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaBensEletronorteMatricula).ToString() :
                        txtMatriculaItem.Text;
                    txtPatrimonioItem.Text = btnPatrimonioItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192)) ?
                        objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaBensEletronortePatrimonio).ToString() :
                        txtPatrimonioItem.Text;
                    txtQuantidadeItem.Text = "1";
                    txtDenominacaoItem.Text = btnDenominacaoItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192)) ?
                        string.Format("{0} {1}", objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaBensEletronorteDenominacao).ToString(),
                        objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaBensEletronorteDenominacao_Extra).ToString()) :
                        txtDenominacaoItem.Text;
                    txtNSerieItem.Text = btnNSerieItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192)) ?
                        objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaBensEletronorteN_Serie).ToString() :
                        txtNSerieItem.Text;
                    txtPlacaVeiculoItem.Text = btnPlacaVeiculoItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192)) ?
                        objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaBensEletronortePlaca_Veiculo).ToString() :
                        txtPlacaVeiculoItem.Text;
                    if (txtOutrosDadosItem.Text.Equals(string.Empty))
                    {
                        txtOutrosDadosItem.Text = btnOutrosDadosItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192))
                            ?
                            txtOrgaoItem.Text != string.Empty
                            ?
                            objManipuladorTexto.mtdExecutarTudo(string.Format("{0}_{1}_{2}", txtOrgaoItem.Text, dtpDataInventario.Value.Year, dtpDataInventario.Value.Month.ToString("00")))
                            :
                            string.Empty
                            :
                            txtOutrosDadosItem.Text;
                    }

                    if (btnNomeItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)))
                    {
                        mtdPreencherTxtNomeItem(objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaBensEletronorteMatricula).ToString());
                    }

                    System.Windows.Forms.MessageBox.Show
                        (
                        "A procura terminou.",
                        "Aviso!", System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Exclamation,
                        System.Windows.Forms.MessageBoxDefaultButton.Button1
                        );
                }
                else
                {
                    cmbObservacaoItem.Text = btnObservacaoItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192)) ?
                        cmbObservacaoItem.Items[1].ToString() :
                        cmbObservacaoItem.Text;

                    txtDenominacaoItem.Text = btnDenominacaoItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192)) ?
                        string.Empty :
                        txtDenominacaoItem.Text;
                    txtNSerieItem.Text = btnNSerieItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192)) ?
                        string.Empty :
                        txtNSerieItem.Text;
                    txtPlacaVeiculoItem.Text = btnPlacaVeiculoItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192)) ?
                        string.Empty :
                        txtPlacaVeiculoItem.Text;

                    System.Windows.Forms.MessageBox.Show
                        (
                        "Não foi possível encontrar nenhum registro.",
                        "Aviso!",
                        System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Exclamation,
                        System.Windows.Forms.MessageBoxDefaultButton.Button1
                        );
                }
            }
            finally
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default; //restore the old cursor
            }

            objImplementacaoBancoDados.Dispose();
        }

        private void mtdCarregarCaixaTextoDtgv1(long Numero_Inventario)
        {
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                (
                clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                );

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                (
                clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                strBaseDadosColetor,
                strSenhaColetor
                );

            try
            {
                if (dtg1.CurrentCell.RowNumber > -1)
                {
                    objImplementacaoBancoDados.mtdSelecionarDados
                        (
                        vetCamposTabelaInventarioBens,
                        strTabelaInventarioBens,
                        vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensNumero_Inventario],
                        "=",
                        Numero_Inventario
                        );

                    objImplementacaoBancoDados.mtdDefinirLeitorDados();
                    objImplementacaoBancoDados.mtdProximoRegistro();

                    txtNumeroInventario.Text = objImplementacaoBancoDados.mtdObterValorRegistro(0).ToString();
                    txtTRGItem.Text = btnTRGItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)) ?
                        objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensTRG).ToString() :
                        txtTRGItem.Text;
                    txtCentroCustoItem.Text = btnCentroCustoItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)) ?
                        objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensCentroCusto).ToString() :
                        txtCentroCustoItem.Text;
                    txtOrgaoItem.Text = btnOrgaoItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)) ?
                        objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensOrgao).ToString() :
                        txtOrgaoItem.Text;
                    txtSalaItem.Text = btnSalaItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)) ?
                        objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensSala).ToString() :
                        txtSalaItem.Text;
                    txtNomeItem.Text = btnNomeItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)) ?
                        objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensNome).ToString() :
                        txtNomeItem.Text;
                    txtMatriculaItem.Text = btnMatriculaItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)) ?
                        objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensMatricula).ToString() :
                        txtMatriculaItem.Text;
                    txtPatrimonioItem.Text = btnPatrimonioItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192)) ?
                        objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensPatrimonio).ToString() :
                        txtPatrimonioItem.Text;
                    txtQuantidadeItem.Text = objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensQuantidade).ToString().Equals(string.Empty) ?
                        "1" :
                        objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensQuantidade).ToString();
                    txtDenominacaoItem.Text = btnDenominacaoItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192)) ?
                        objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensDenominacao).ToString() :
                        txtDenominacaoItem.Text;
                    txtNSerieItem.Text = btnNSerieItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192)) ?
                        objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensN_Serie).ToString() :
                        txtNSerieItem.Text;
                    txtPlacaVeiculoItem.Text = btnPlacaVeiculoItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192)) ?
                        objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensPlaca_Veiculo).ToString() :
                        txtPlacaVeiculoItem.Text;
                    txtIdentificacaoItem.Text = btnIdentificacaoItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192)) ?
                        objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensIdentificacao_Inventario).ToString() :
                        txtIdentificacaoItem.Text;
                    txtOutrosDadosItem.Text = btnOutrosDadosItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192)) ?
                        objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensOutrosDados_Inventario).ToString() :
                        txtOutrosDadosItem.Text;
                    cmbObservacaoItem.Text = btnObservacaoItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192)) ?
                        objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensObservacao).ToString() :
                        cmbObservacaoItem.Text;

                    if (btnTravarFotografia.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)))
                    {
                        byte[] photo_array = null;

                        photo_array = (byte[])objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensFotografia);
                        System.IO.MemoryStream ms = new System.IO.MemoryStream(photo_array);
                        System.Drawing.Image im = new System.Drawing.Bitmap(ms);
                        pctFotografia.Image = im;
                    }
                }
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdCarregarCaixaTextoDtgv1: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }

            objImplementacaoBancoDados.Dispose();
        }

        private void mtdCarregarCaixaTextoDtgv2()
        {
            try
            {
                txtTRGItem.Text = btnTRGItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)) ?
                    dtg2[dtg2.CurrentCell.RowNumber, intColunaTabelaBensEletronorteTRG].ToString() :
                    txtTRGItem.Text;
                txtCentroCustoItem.Text = btnCentroCustoItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)) ?
                    string.Empty :
                    txtCentroCustoItem.Text;
                txtOrgaoItem.Text = btnOrgaoItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)) ?
                    dtg2[dtg2.CurrentCell.RowNumber, intColunaTabelaBensEletronorteOrgao].ToString().Split(' ')[0] :
                    txtOrgaoItem.Text;
                txtSalaItem.Text = btnSalaItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)) ?
                    dtg2[dtg2.CurrentCell.RowNumber, intColunaTabelaBensEletronorteSala].ToString() :
                    txtSalaItem.Text;
                txtNomeItem.Text = btnNomeItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)) ?
                    string.Empty :
                    txtNomeItem.Text;
                txtMatriculaItem.Text = btnMatriculaItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)) ?
                    dtg2[dtg2.CurrentCell.RowNumber, intColunaTabelaBensEletronorteMatricula].ToString() :
                    txtMatriculaItem.Text;
                txtPatrimonioItem.Text = btnPatrimonioItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192)) ?
                    dtg2[dtg2.CurrentCell.RowNumber, intColunaTabelaBensEletronortePatrimonio].ToString() :
                    txtPatrimonioItem.Text;
                txtDenominacaoItem.Text = btnDenominacaoItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192)) ?
                    string.Format
                    (
                    "{0} {1}", dtg2[dtg2.CurrentCell.RowNumber, intColunaTabelaBensEletronorteDenominacao].ToString(),
                    dtg2[dtg2.CurrentCell.RowNumber, intColunaTabelaBensEletronorteDenominacao_Extra].ToString()
                    ) :
                    txtDenominacaoItem.Text;
                txtNSerieItem.Text = btnNSerieItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192)) ?
                    dtg2[dtg2.CurrentCell.RowNumber, intColunaTabelaBensEletronorteN_Serie].ToString() :
                    txtNSerieItem.Text;
                txtPlacaVeiculoItem.Text = btnPatrimonioItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192)) ?
                    dtg2[dtg2.CurrentCell.RowNumber, intColunaTabelaBensEletronortePlaca_Veiculo].ToString() :
                    txtPlacaVeiculoItem.Text;
                if (btnNomeItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)))
                {
                    mtdPreencherTxtNomeItem(dtg2[dtg2.CurrentCell.RowNumber, intColunaTabelaBensEletronorteMatricula].ToString(), false);
                }
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdCarregarCaixaComboDtgv3: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void mtdCarregarCaixaTextoDtgv3()
        {
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                (
                clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                );

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                (
                clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                strBaseDadosColetor,
                strSenhaColetor
                );

            try
            {
                txtOrgaoItem.Text = btnOrgaoItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)) ?
                    dtg3[dtg3.CurrentCell.RowNumber, intColunaTabelaCentroCustoOrgaoDescricao].ToString().Split(' ')[0] : txtOrgaoItem.Text;

                objImplementacaoBancoDados.mtdSelecionarDados
                    (
                      vetCamposTabelaCentroCusto,
                      strTabelaCentroCusto,
                      string.Format
                      (
                      "{0}",
                      vetCamposTabelaCentroCusto[intColunaTabelaCentroCustoOrgao]
                      ),
                      "LIKE",
                      string.Format
                      (
                      "N'%{0}%'",
                      dtg3[dtg3.CurrentCell.RowNumber, intColunaTabelaCentroCustoOrgaoDescricao].ToString().Split(' ')[0]
                      ),
                      string.Format
                      (
                      "{0}",
                      vetCamposTabelaCentroCusto[intColunaTabelaCentroCustoCentroCusto]
                      ),
                      false
                      );

                objImplementacaoBancoDados.mtdDefinirLeitorDados();
                if (objImplementacaoBancoDados.mtdProximoRegistro())
                {
                    txtCentroCustoItem.Text = btnCentroCustoItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)) ?
                        objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaCentroCustoCentroCusto).ToString() :
                        txtCentroCustoItem.Text;
                }
                else
                {
                    txtCentroCustoItem.Text = btnCentroCustoItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)) ?
                        string.Empty :
                        txtCentroCustoItem.Text;
                }

                txtSalaItem.Text = btnSalaItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)) ? dtg3[dtg3.CurrentCell.RowNumber, intColunaTabelaEmpregadosEndereco].ToString() : txtSalaItem.Text;
                txtNomeItem.Text = btnNomeItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)) ? dtg3[dtg3.CurrentCell.RowNumber, intColunaTabelaEmpregadosNome].ToString() : txtNomeItem.Text;
                txtMatriculaItem.Text = btnMatriculaItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)) ? dtg3[dtg3.CurrentCell.RowNumber, intColunaTabelaEmpregadosMatricula].ToString() : txtMatriculaItem.Text;
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdCarregarCaixaTextoDtgv3: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }

            objImplementacaoBancoDados.Dispose();
        }

        private void mtdCarregarCaixaTextoDtgv4()
        {
            try
            {
                txtCentroCustoItem.Text = btnCentroCustoItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)) ? dtg4[dtg4.CurrentCell.RowNumber, 0].ToString().Split(' ')[0] : txtCentroCustoItem.Text;
                txtOrgaoItem.Text = btnOrgaoItem.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)) ? dtg4[dtg4.CurrentCell.RowNumber, 1].ToString().Split(' ')[0] : txtOrgaoItem.Text;
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdCarregarCaixaTextoDtgv4: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private bool mtdAtualizarCaixaTexto()
        {
            bool blnRetorno = false;

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor; // set the wait cursor
            //Do some work

            mtdExecutarTudoTextos();

            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                (
                clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                );

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                (
                clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                strBaseDadosColetor,
                strSenhaColetor
                );

            ulong ulngNumeroInventario = 0;
            object Inventario = null;

            if (!txtNumeroInventario.Text.Equals(string.Empty))
            {
                ulngNumeroInventario = System.Convert.ToUInt64(txtNumeroInventario.Text);
            }
            else
            {
                ulngNumeroInventario = mtdGerarProximoNumeroInventario();
            }

            bool blnValidarRegistro = false;

            objImplementacaoBancoDados.mtdSelecionarDados
                (
                vetCamposTabelaInventarioBens,
                strTabelaInventarioBens,
                vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensPatrimonio],
                "LIKE",
                string.Format
                (
                "'{0}'",
                txtPatrimonioItem.Text
                ),
                vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensPatrimonio],
                true
                );
            objImplementacaoBancoDados.mtdDefinirLeitorDados();

            if (objImplementacaoBancoDados.mtdProximoRegistro())
            {
                blnValidarRegistro = true;
            }
            else
            {
                objImplementacaoBancoDados.mtdFecharConexao();

                objImplementacaoBancoDados.mtdSelecionarDados
                    (
                    vetCamposTabelaInventarioBens,
                    strTabelaInventarioBens,
                    vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensNumero_Inventario],
                    "LIKE",
                    string.Format
                    (
                    "{0}",
                    txtNumeroInventario.Text
                    ),
                    vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensNumero_Inventario],
                    true
                    );
                objImplementacaoBancoDados.mtdDefinirLeitorDados();

                if (objImplementacaoBancoDados.mtdProximoRegistro())
                {
                    blnValidarRegistro = true;
                }
                else
                {
                    blnValidarRegistro = false;
                }
            }

            try
            {
                if (blnValidarRegistro)
                {
                    ulngNumeroInventario = System.Convert.ToUInt64(objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensNumero_Inventario));
                    Inventario = objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensInventario);

                    objImplementacaoBancoDados.mtdSelecionarDados
                    (
                    vetCamposTabelaInventarioBens,
                    strTabelaInventarioBens
                    );

                    object[][] dados = new object[2][];
                    objImplementacaoBancoDados.mtdDefinirLeitorDados();

                    dados[0] = objImplementacaoBancoDados.mtdObterCabecalhoColunas();
                    dados[1] = new object[vetCamposTabelaInventarioBens.GetUpperBound(0) + 1 + 3];

                    for (int contador = dados[0].GetLowerBound(0); contador <= dados[0].GetUpperBound(0); contador++)
                    {
                        dados[1][contador] = string.Format("@{0}", dados[0][contador].ToString());
                    }
                    dados[1][dados[0].GetUpperBound(0) + 1] = string.Format(
                        "{0}",
                        vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensNumero_Inventario]
                        );
                    dados[1][dados[0].GetUpperBound(0) + 2] = string.Format(
                        "{0}",
                        "="
                        );
                    dados[1][dados[0].GetUpperBound(0) + 3] = string.Format(
                        "{0}",
                        ulngNumeroInventario
                        );

                    object[][] dadosP = new object[2][];

                    objImplementacaoBancoDados.mtdDefinirLeitorDados();
                    dadosP[0] = dados[0];
                    dadosP[1] = new object[vetCamposTabelaInventarioBens.GetUpperBound(0) + 1];
                    dadosP[1][intColunaTabelaInventarioBensNumero_Inventario] = ulngNumeroInventario;
                    dadosP[1][intColunaTabelaInventarioBensData_Inventario] = dtpDataInventario.Value;
                    dadosP[1][intColunaTabelaInventarioBensTRG] = txtTRGItem.Text;
                    dadosP[1][intColunaTabelaInventarioBensCentroCusto] = txtCentroCustoItem.Text;
                    dadosP[1][intColunaTabelaInventarioBensOrgao] = txtOrgaoItem.Text;
                    dadosP[1][intColunaTabelaInventarioBensSala] = txtSalaItem.Text;
                    dadosP[1][intColunaTabelaInventarioBensNome] = txtNomeItem.Text;
                    dadosP[1][intColunaTabelaInventarioBensMatricula] = txtMatriculaItem.Text;
                    dadosP[1][intColunaTabelaInventarioBensPatrimonio] = txtPatrimonioItem.Text;
                    dadosP[1][intColunaTabelaInventarioBensQuantidade] = txtQuantidadeItem.Text.Equals(string.Empty) ? "1" : txtQuantidadeItem.Text;
                    dadosP[1][intColunaTabelaInventarioBensDenominacao] = txtDenominacaoItem.Text;
                    dadosP[1][intColunaTabelaInventarioBensN_Serie] = txtNSerieItem.Text;
                    dadosP[1][intColunaTabelaInventarioBensPlaca_Veiculo] = txtPlacaVeiculoItem.Text;
                    dadosP[1][intColunaTabelaInventarioBensIdentificacao_Inventario] = txtIdentificacaoItem.Text;
                    dadosP[1][intColunaTabelaInventarioBensOutrosDados_Inventario] = txtOutrosDadosItem.Text;
                    dadosP[1][intColunaTabelaInventarioBensObservacao] = cmbObservacaoItem.Text;
                    dadosP[1][intColunaTabelaInventarioBensColetor] = txtNomeDispositivo.Text;
                    dadosP[1][intColunaTabelaInventarioBensUsuario_Inventariante] = txtUsuarioInventario.Text;
                    dadosP[1][intColunaTabelaInventarioBensMatricula_Inventariante] = txtMatriculaInventario.Text;
                    dadosP[1][intColunaTabelaInventarioBensInventario] = Inventario;
                    dadosP[1][intColunaTabelaInventarioBensFotografia] = imageToByteArray(pctFotografia.Image);
                    dadosP[1][intColunaTabelaInventarioBensGPS_Latitute] = txtGPSLatitute.Text;
                    dadosP[1][intColunaTabelaInventarioBensGPS_Longitude] = txtGPSLongitude.Text;
                    dadosP[1][intColunaTabelaInventarioBensGPS_EllipsoidAltitude] = txtEllipsoidAltitude.Text;
                    dadosP[1][intColunaTabelaInventarioBensGPS_PositionDilutionOfPrecision] = txtGPSPositionDilutionOfPrecision.Text;

                    objImplementacaoBancoDados.prpComandoSQLServerCE.Parameters.Clear();

                    for (int contador = dadosP[0].GetLowerBound(0); contador <= dadosP[0].GetUpperBound(0); contador++)
                    {
                        if (contador == intColunaTabelaInventarioBensFotografia)
                        {
                            objImplementacaoBancoDados.mtdExecutarParametroComandoSQLServerCE
                                (
                                dadosP[0][contador].ToString(),
                                System.Data.SqlDbType.Image,
                                dadosP[1][contador]
                                );
                        }
                        else
                        {
                            objImplementacaoBancoDados.mtdExecutarParametroComandoSQLServerCE(dadosP[0][contador].ToString(), dadosP[1][contador]);
                        }
                    }

                    blnRetorno = objImplementacaoBancoDados.mtdAtualizarDados(strTabelaInventarioBens, dados);

                    blnPermitirAtualizacaoDtpDataInventario = true;
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show
                    (
                    "Não foi possível alterar o cadastro do item.",
                    "Aviso!", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Exclamation,
                    System.Windows.Forms.MessageBoxDefaultButton.Button1
                    );
                blnRetorno = false;

                string strExcecao = "mtdAtualizarCaixaTexto: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }

            if (btnTravarFotografia.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)))
            {
                pctFotografia.Image = tmpImage;
                originalFileName = string.Empty;
            }

            objImplementacaoBancoDados.Dispose();

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default; //restore the old cursor

            return blnRetorno;
        }

        private bool mtdAtualizarListaCaixaTexto(string NumeroInventario)
        {
            bool blnRetorno = false;

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor; // set the wait cursor
            //Do some work

            mtdExecutarTudoTextos();
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                (
                clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                );

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                (
                clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                strBaseDadosColetor,
                strSenhaColetor
                );

            ulong ulngNumeroInventario = 0;
            object Inventario = null;
            System.DateTime dtDataInventario = System.DateTime.Now;

            if (!NumeroInventario.Equals(string.Empty))
            {
                ulngNumeroInventario = System.Convert.ToUInt64(NumeroInventario);
            }
            else
            {
                ulngNumeroInventario = mtdGerarProximoNumeroInventario();
            }

            objImplementacaoBancoDados.mtdSelecionarDados
                (
                vetCamposTabelaInventarioBens,
                strTabelaInventarioBens,
                vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensNumero_Inventario],
                "LIKE",
                string.Format
                (
                "'{0}'",
                NumeroInventario
                ),
                vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensNumero_Inventario],
                true
                );
            objImplementacaoBancoDados.mtdDefinirLeitorDados();

            try
            {
                if (objImplementacaoBancoDados.mtdProximoRegistro())
                {
                    //ulngNumeroInventario = System.Convert.ToUInt64(NumeroInventario);
                    Inventario = objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensInventario);

                    object[][] dados = new object[2][];

                    dados[0] = objImplementacaoBancoDados.mtdObterCabecalhoColunas();
                    dados[1] = new object[vetCamposTabelaInventarioBens.GetUpperBound(0) + 1 + 3];

                    for (int contador = dados[0].GetLowerBound(0); contador <= dados[0].GetUpperBound(0); contador++)
                    {
                        dados[1][contador] = string.Format("@{0}", dados[0][contador].ToString());
                    }
                    dados[1][dados[0].GetUpperBound(0) + 1] = string.Format(
                        "{0}",
                        vetCamposTabelaInventarioBens[0]
                        );
                    dados[1][dados[0].GetUpperBound(0) + 2] = string.Format(
                        "{0}",
                        "="
                        );
                    dados[1][dados[0].GetUpperBound(0) + 3] = string.Format(
                        "{0}",
                        ulngNumeroInventario
                        );

                    object[][] dadosP = new object[2][];

                    dadosP[0] = dados[0];
                    dadosP[1] = new object[vetCamposTabelaInventarioBens.GetUpperBound(0) + 1];
                    dadosP[1][intColunaTabelaInventarioBensNumero_Inventario] = ulngNumeroInventario;
                    dadosP[1][intColunaTabelaInventarioBensData_Inventario] = dtpDataInventario.Value;
                    dadosP[1][intColunaTabelaInventarioBensTRG] = btnTRGItemL.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)) ?
                    txtTRGItem.Text :
                    objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensTRG);
                    dadosP[1][intColunaTabelaInventarioBensCentroCusto] = btnCentroCustoItemL.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)) ?
                    txtCentroCustoItem.Text :
                    objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensCentroCusto);
                    dadosP[1][intColunaTabelaInventarioBensOrgao] = btnOrgaoItemL.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)) ?
                    txtOrgaoItem.Text :
                    objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensOrgao);
                    dadosP[1][intColunaTabelaInventarioBensSala] = btnSalaItemL.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)) ?
                    txtSalaItem.Text :
                    objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensSala);
                    dadosP[1][intColunaTabelaInventarioBensNome] = btnNomeItemL.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)) ?
                    txtNomeItem.Text :
                    objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensNome);
                    dadosP[1][intColunaTabelaInventarioBensMatricula] = btnMatriculaItemL.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)) ?
                    txtMatriculaItem.Text :
                    objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensMatricula);
                    dadosP[1][intColunaTabelaInventarioBensPatrimonio] = btnPatrimonioItemL.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192)) ?
                    txtPatrimonioItem.Text :
                    objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensPatrimonio);
                    dadosP[1][intColunaTabelaInventarioBensQuantidade] = txtQuantidadeItem.Text.Equals(string.Empty) ? "1" : txtQuantidadeItem.Text;
                    dadosP[1][intColunaTabelaInventarioBensDenominacao] = btnDenominacaoItemL.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192)) ?
                    txtDenominacaoItem.Text :
                    objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensDenominacao);
                    dadosP[1][intColunaTabelaInventarioBensN_Serie] = btnNSerieItemL.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192)) ?
                    txtNSerieItem.Text :
                    objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensN_Serie);
                    dadosP[1][intColunaTabelaInventarioBensPlaca_Veiculo] = btnPlacaVeiculoItemL.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192)) ?
                    txtPlacaVeiculoItem.Text :
                    objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensPlaca_Veiculo);
                    dadosP[1][intColunaTabelaInventarioBensIdentificacao_Inventario] = btnIdentificacaoItemL.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192)) ?
                    txtIdentificacaoItem.Text :
                    objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensIdentificacao_Inventario);
                    dadosP[1][intColunaTabelaInventarioBensOutrosDados_Inventario] = btnOutrosDadosItemL.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192)) ?
                    txtOutrosDadosItem.Text :
                    objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensOutrosDados_Inventario);
                    dadosP[1][intColunaTabelaInventarioBensObservacao] = btnObservacaoItemL.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 0, 192)) ?
                    cmbObservacaoItem.Text :
                    objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensObservacao);
                    dadosP[1][intColunaTabelaInventarioBensColetor] = txtNomeDispositivo.Text;
                    dadosP[1][intColunaTabelaInventarioBensUsuario_Inventariante] = txtUsuarioInventario.Text;
                    dadosP[1][intColunaTabelaInventarioBensMatricula_Inventariante] = txtMatriculaInventario.Text;
                    dadosP[1][intColunaTabelaInventarioBensInventario] = Inventario;
                    dadosP[1][intColunaTabelaInventarioBensFotografia] = btnTirarFotografiaL.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)) ?
                        imageToByteArray(pctFotografia.Image) :
                        objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensFotografia);
                    dadosP[1][intColunaTabelaInventarioBensGPS_Latitute] = txtGPSLatitute.Text;
                    dadosP[1][intColunaTabelaInventarioBensGPS_Longitude] = txtGPSLongitude.Text;
                    dadosP[1][intColunaTabelaInventarioBensGPS_EllipsoidAltitude] = txtEllipsoidAltitude.Text;
                    dadosP[1][intColunaTabelaInventarioBensGPS_PositionDilutionOfPrecision] = txtGPSPositionDilutionOfPrecision.Text;

                    objImplementacaoBancoDados.prpComandoSQLServerCE.Parameters.Clear();

                    for (int contador = dadosP[0].GetLowerBound(0); contador <= dadosP[0].GetUpperBound(0); contador++)
                    {
                        if (contador == intColunaTabelaInventarioBensFotografia)
                        {
                            objImplementacaoBancoDados.mtdExecutarParametroComandoSQLServerCE
                                (
                                dadosP[0][contador].ToString(),
                                System.Data.SqlDbType.Image,
                                dadosP[1][contador]
                                );
                        }
                        else
                        {
                            objImplementacaoBancoDados.mtdExecutarParametroComandoSQLServerCE(dadosP[0][contador].ToString(), dadosP[1][contador]);
                        }
                    }

                    blnRetorno = objImplementacaoBancoDados.mtdAtualizarDados(strTabelaInventarioBens, dados);

                    blnPermitirAtualizacaoDtpDataInventario = true;
                }
            }
            catch (System.Exception ex)
            {
                blnRetorno = false;

                string strExcecao = "mtdAtualizarListaCaixaTexto: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }

            if (btnTravarFotografia.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)))
            {
                pctFotografia.Image = tmpImage;
                originalFileName = string.Empty;
            }

            objImplementacaoBancoDados.Dispose();

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default; //restore the old cursor

            return blnRetorno;
        }

        private void mtdInserirCaixaTexto()
        {
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                (
                clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                );

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                (
                clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                strBaseDadosColetor,
                strSenhaColetor
                );

            ulong ulngGerarProximoNumeroInventario = 0;

            if (!txtNumeroInventario.Text.Equals(string.Empty))
            {
                ulngGerarProximoNumeroInventario = System.Convert.ToUInt64(txtNumeroInventario.Text);
            }
            else
            {
                ulngGerarProximoNumeroInventario = mtdGerarProximoNumeroInventario();
            }

            ulngGerarProximoNumeroInventario = mtdGerarProximoNumeroInventario();

            objImplementacaoBancoDados.mtdSelecionarDados
                (
                vetCamposTabelaInventarioBens,
                strTabelaInventarioBens
                );

            object[][] dados = new object[2][];
            objImplementacaoBancoDados.mtdDefinirLeitorDados();

            dados[0] = objImplementacaoBancoDados.mtdObterCabecalhoColunas();
            dados[1] = objImplementacaoBancoDados.mtdObterCabecalhoColunas();

            for (int contador = dados[0].GetLowerBound(0); contador <= dados[0].GetUpperBound(0); contador++)
            {
                dados[1][contador] = string.Format("@{0}", dados[0][contador].ToString());
            }

            object[][] dadosP = new object[2][];

            dadosP[0] = dados[0];
            dadosP[1] = new object[vetCamposTabelaInventarioBens.GetUpperBound(0) + 1];
            dadosP[1][intColunaTabelaInventarioBensNumero_Inventario] = ulngGerarProximoNumeroInventario;
            dadosP[1][intColunaTabelaInventarioBensData_Inventario] = dtpDataInventario.Value;
            dadosP[1][intColunaTabelaInventarioBensTRG] = txtTRGItem.Text;
            dadosP[1][intColunaTabelaInventarioBensCentroCusto] = txtCentroCustoItem.Text;
            dadosP[1][intColunaTabelaInventarioBensOrgao] = txtOrgaoItem.Text;
            dadosP[1][intColunaTabelaInventarioBensSala] = txtSalaItem.Text;
            dadosP[1][intColunaTabelaInventarioBensNome] = txtNomeItem.Text;
            dadosP[1][intColunaTabelaInventarioBensMatricula] = txtMatriculaItem.Text;
            dadosP[1][intColunaTabelaInventarioBensPatrimonio] = txtPatrimonioItem.Text;
            dadosP[1][intColunaTabelaInventarioBensQuantidade] = txtQuantidadeItem.Equals(txtQuantidadeItem.Text) ? "1" : txtQuantidadeItem.Text;
            dadosP[1][intColunaTabelaInventarioBensDenominacao] = txtDenominacaoItem.Text;
            dadosP[1][intColunaTabelaInventarioBensN_Serie] = txtNSerieItem.Text;
            dadosP[1][intColunaTabelaInventarioBensPlaca_Veiculo] = txtPlacaVeiculoItem.Text;
            dadosP[1][intColunaTabelaInventarioBensIdentificacao_Inventario] = txtIdentificacaoItem.Text;
            dadosP[1][intColunaTabelaInventarioBensOutrosDados_Inventario] = txtOutrosDadosItem.Text;
            dadosP[1][intColunaTabelaInventarioBensObservacao] = cmbObservacaoItem.Text;
            dadosP[1][intColunaTabelaInventarioBensColetor] = txtNomeDispositivo.Text;
            dadosP[1][intColunaTabelaInventarioBensUsuario_Inventariante] = txtUsuarioInventario.Text;
            dadosP[1][intColunaTabelaInventarioBensMatricula_Inventariante] = txtMatriculaInventario.Text;
            dadosP[1][intColunaTabelaInventarioBensInventario] = string.Empty;
            try
            {
                dadosP[1][intColunaTabelaInventarioBensFotografia] = imageToByteArray(pctFotografia.Image);
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdInserirCaixaTexto: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
            dadosP[1][intColunaTabelaInventarioBensGPS_Latitute] = txtGPSLatitute.Text;
            dadosP[1][intColunaTabelaInventarioBensGPS_Longitude] = txtGPSLongitude.Text;
            dadosP[1][intColunaTabelaInventarioBensGPS_EllipsoidAltitude] = txtEllipsoidAltitude.Text;
            dadosP[1][intColunaTabelaInventarioBensGPS_PositionDilutionOfPrecision] = txtGPSPositionDilutionOfPrecision.Text;

            long lngCodigoEspalhamento = 0;
            long[] vetCodigoEspalhamento = new long[dadosP[1].GetLength(0)];
            for (int contador = dadosP[1].GetLowerBound(0) + 1; contador <= dadosP[1].GetUpperBound(0); contador++)
            {
                if (contador == intColunaTabelaInventarioBensData_Inventario)
                {
                    vetCodigoEspalhamento[contador] = mtdObterCodigoEspalhamento
                        (
                        System.Convert.ToString
                        (
                        System.Convert.ToDateTime
                        (
                        dadosP[1][contador]
                        ).Ticks
                        )
                        );
                }
                else
                {
                    vetCodigoEspalhamento[contador] = mtdObterCodigoEspalhamento
                        (
                        System.Convert.ToString
                        (
                        dadosP[1][contador]
                        )
                        );
                }
                System.Diagnostics.Debug.WriteLine(String.Format(System.Globalization.CultureInfo.GetCultureInfo("pt-BR"), "Vetor({0:00}):{1}", contador, vetCodigoEspalhamento[contador]));
                lngCodigoEspalhamento = lngCodigoEspalhamento ^ vetCodigoEspalhamento[contador];
            }
            dadosP[1][intColunaTabelaInventarioBensInventario] = lngCodigoEspalhamento;

            objImplementacaoBancoDados.prpComandoSQLServerCE.Parameters.Clear();

            for (int contador = dadosP[0].GetLowerBound(0); contador <= dadosP[0].GetUpperBound(0); contador++)
            {
                if (contador == intColunaTabelaInventarioBensFotografia)
                {
                    objImplementacaoBancoDados.mtdExecutarParametroComandoSQLServerCE
                        (
                        dadosP[0][contador].ToString(),
                        System.Data.SqlDbType.Image,
                        dadosP[1][contador]
                        );
                }
                else
                {
                    objImplementacaoBancoDados.mtdExecutarParametroComandoSQLServerCE(dadosP[0][contador].ToString(), dadosP[1][contador]);
                }
            }

            if (objImplementacaoBancoDados.mtdInserirDados(strTabelaInventarioBens, dados))
            {
                System.Windows.Forms.MessageBox.Show
                    (
                    "O Item foi inserido.",
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
                    "O item não pode ser inserido.",
                    "Aviso!",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Exclamation,
                    System.Windows.Forms.MessageBoxDefaultButton.Button1
                    );
            }

            txtNumeroInventario.Text = System.Convert.ToString(ulngGerarProximoNumeroInventario + 1);

            blnPermitirAtualizacaoDtpDataInventario = true;
        }

        private void mtdCadastrarCaixaTexto()
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor; // set the wait cursor
            //Do some work

            mtdExecutarTudoTextos();

            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                (
                clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                );

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                (
                clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                strBaseDadosColetor,
                strSenhaColetor
                );

            objImplementacaoBancoDados.mtdSelecionarDados
               (
               vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensPatrimonio],
               strTabelaInventarioBens,
               vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensPatrimonio],
               "LIKE",
               string.Format
               (
               "'{0}'",
               txtPatrimonioItem.Text
               ),
               vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensPatrimonio],
               true
               );

            objImplementacaoBancoDados.mtdDefinirLeitorDados();

            if (!objImplementacaoBancoDados.mtdProximoRegistro())
            {
                mtdInserirCaixaTexto();
            }
            else
            {
                System.Windows.Forms.DialogResult dgrlt
                =
                System.Windows.Forms.MessageBox.Show
                    (
                    "Esse número de patrimônio já foi cadastrado. Pressione: Yes, para inseri-lo novamente; No, para alterar os dados do item já cadastrado; Cancel, para não fazer nada.",
                    "Aviso!",
                    System.Windows.Forms.MessageBoxButtons.YesNoCancel,
                    System.Windows.Forms.MessageBoxIcon.Exclamation,
                    System.Windows.Forms.MessageBoxDefaultButton.Button3
                    );

                switch (dgrlt)
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        mtdInserirCaixaTexto();
                        break;
                    case System.Windows.Forms.DialogResult.No:
                        mtdAtualizar();
                        System.Windows.Forms.MessageBox.Show
                            (
                            "O Item foi alterado.",
                            "Aviso!",
                            System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Exclamation,
                            System.Windows.Forms.MessageBoxDefaultButton.Button1
                            );
                        break;
                    case System.Windows.Forms.DialogResult.Cancel:
                        System.Windows.Forms.MessageBox.Show
                            (
                            "A ação foi cancelada.",
                            "Aviso!",
                            System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Exclamation,
                            System.Windows.Forms.MessageBoxDefaultButton.Button1
                            );
                        break;
                }
            }
            if (btnTravarFotografia.ForeColor.Equals(System.Drawing.Color.FromArgb(0, 192, 0)))
            {
                pctFotografia.Image = tmpImage;
                originalFileName = string.Empty;
            }

            objImplementacaoBancoDados.Dispose();

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default; //restore the old cursor
        }
    }
}
