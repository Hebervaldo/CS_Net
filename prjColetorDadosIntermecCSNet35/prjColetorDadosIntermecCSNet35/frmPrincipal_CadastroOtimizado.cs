using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace prjColetorDadosIntermecCSNet35
{
    public partial class frmPrincipal
    {
        private System.Threading.Thread[] vetTh = new System.Threading.Thread[1];

        private int intContadorCadastroOtimizado = 0;

        private void mtdIniciarThreadCadastroOtimizado()
        {
            if (intContadorCadastroOtimizado <= vetTh.GetUpperBound(0))
            {
                try
                {
                    blnAbortarThreadCadastroOtimizado = false;
                    blnForcarAbortarThreadCadastroOtimizado = false;
                    vetTh[intContadorCadastroOtimizado] = new System.Threading.Thread
                        (
                        new System.Threading.ThreadStart
                        (
                        this.mtdRotinaCadastroOtimizado
                        )
                        );
                    vetTh[intContadorCadastroOtimizado].IsBackground = true;
                    vetTh[intContadorCadastroOtimizado].Priority = System.Threading.ThreadPriority.Lowest;
                    vetTh[intContadorCadastroOtimizado].Start();
                }
                catch (Exception ex)
                {
                    string strExcecao = "mtdIniciarThreadCadastroOtimizado: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                    //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                }
                intContadorCadastroOtimizado++;
            }
            else
            {
                intContadorCadastroOtimizado = vetTh.GetLowerBound(0);
            }
        }

        private bool blnForcarAbortarThreadCadastroOtimizado = false;
        private bool blnAbortarThreadCadastroOtimizado = false;
        private int intTempoSaidaAbortarThreadCadastroOtimizado = 1000;

        private void mtdAbortarThreadCadastroOtimizado()
        {
            mtdAbortarThreadCadastroOtimizado(false);
        }

        private void mtdAbortarThreadCadastroOtimizado(bool Forcar)
        {
            for (int contador = vetTh.GetLowerBound(0); contador <= vetTh.GetUpperBound(0); contador++)
            {
                try
                {
                    blnAbortarThreadCadastroOtimizado = true;
                    blnForcarAbortarThreadCadastroOtimizado = Forcar;
                    vetTh[contador].Join(intTempoSaidaAbortarThreadCadastroOtimizado);
                    vetTh[contador].Abort();
                }
                catch (Exception ex)
                {
                    string strExcecao = "mtdAbortarThreadCadastroOtimizado: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                    //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                }
            }
        }

        private void mtdRotinaCadastroOtimizado()
        {
            lock (thisLock)
            {
                while (!blnAbortarThreadCadastroOtimizado)
                {
                    if (blnForcarAbortarThreadCadastroOtimizado) return;

                    mtdCadastroOtimizado();
                }
            }
            System.Threading.Thread.Sleep(1);
        }

        private Object thisLock = new Object();
        private bool blnValidarEscritaRegistro = false;

        private int intProcurarParcial = 10;
        private int intContadorProcurarParcial = 0;

        private string[] vetStrValidarEscritaRegistro = new string[14];
        private bool[] vetBlnValidarEscritaRegistro = new bool[14];

        private void mtdCadastroOtimizado()
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
                vetStrValidarEscritaRegistro[0] = vetCamposTabelaInventarioBens[frmPrincipal.intColunaTabelaInventarioBensTRG];
                vetStrValidarEscritaRegistro[1] = vetCamposTabelaInventarioBens[frmPrincipal.intColunaTabelaInventarioBensCentroCusto];
                vetStrValidarEscritaRegistro[2] = vetCamposTabelaInventarioBens[frmPrincipal.intColunaTabelaInventarioBensOrgao];
                vetStrValidarEscritaRegistro[3] = vetCamposTabelaInventarioBens[frmPrincipal.intColunaTabelaInventarioBensSala];
                vetStrValidarEscritaRegistro[4] = vetCamposTabelaInventarioBens[frmPrincipal.intColunaTabelaInventarioBensNome];
                vetStrValidarEscritaRegistro[5] = vetCamposTabelaInventarioBens[frmPrincipal.intColunaTabelaInventarioBensMatricula];
                vetStrValidarEscritaRegistro[6] = vetCamposTabelaInventarioBens[frmPrincipal.intColunaTabelaInventarioBensPatrimonio];
                vetStrValidarEscritaRegistro[7] = vetCamposTabelaInventarioBens[frmPrincipal.intColunaTabelaInventarioBensQuantidade];
                vetStrValidarEscritaRegistro[8] = vetCamposTabelaInventarioBens[frmPrincipal.intColunaTabelaInventarioBensDenominacao];
                vetStrValidarEscritaRegistro[9] = vetCamposTabelaInventarioBens[frmPrincipal.intColunaTabelaInventarioBensN_Serie];
                vetStrValidarEscritaRegistro[10] = vetCamposTabelaInventarioBens[frmPrincipal.intColunaTabelaInventarioBensPlaca_Veiculo];
                vetStrValidarEscritaRegistro[11] = vetCamposTabelaInventarioBens[frmPrincipal.intColunaTabelaInventarioBensIdentificacao_Inventario];
                vetStrValidarEscritaRegistro[12] = vetCamposTabelaInventarioBens[frmPrincipal.intColunaTabelaInventarioBensOutrosDados_Inventario];
                vetStrValidarEscritaRegistro[13] = vetCamposTabelaInventarioBens[frmPrincipal.intColunaTabelaInventarioBensObservacao];

                vetBlnValidarEscritaRegistro[0] = blnTRGItemA;
                vetBlnValidarEscritaRegistro[1] = blnCentroCustoItemA;
                vetBlnValidarEscritaRegistro[2] = blnOrgaoItemA;
                vetBlnValidarEscritaRegistro[3] = blnSalaItemA;
                vetBlnValidarEscritaRegistro[4] = blnNomeItemA;
                vetBlnValidarEscritaRegistro[5] = blnMatriculaItemA;
                vetBlnValidarEscritaRegistro[6] = blnPatrimonioItemA;
                vetBlnValidarEscritaRegistro[7] = blnQuantidadeItemA;
                vetBlnValidarEscritaRegistro[8] = blnDenominacaoItemA;
                vetBlnValidarEscritaRegistro[9] = blnNSerieItemA;
                vetBlnValidarEscritaRegistro[10] = blnPlacaVeiculoItemA;
                vetBlnValidarEscritaRegistro[11] = blnIdentificacaoItemA;
                vetBlnValidarEscritaRegistro[12] = blnOutrosDadosItemA;
                vetBlnValidarEscritaRegistro[13] = blnObservacaoItemA;

                int intColuna = 0;

                for (int coluna = 2; coluna <= 12; coluna++)
                {
                    System.Threading.Thread.Sleep(1);
                    if (blnAbortarThreadCadastroOtimizado & blnForcarAbortarThreadCadastroOtimizado) goto SaidaCadastroOtimizado;

                    blnValidarEscritaRegistro = false;

                    if (vetBlnValidarEscritaRegistro[coluna - 2])
                    {
                        if (coluna != intColunaTabelaInventarioBensPatrimonio)
                        {
                            blnValidarEscritaRegistro = true;
                            intColuna = coluna;
                            break;
                        }
                        else
                        {
                            blnValidarEscritaRegistro = false;
                        }
                    }
                }

                if (blnValidarEscritaRegistro)
                {
                    if (intContadorProcurarParcial < intProcurarParcial)
                    {
                        objImplementacaoBancoDados.mtdSelecionarDados
                            (
                            uintNumeroLinhas,
                            vetCamposTabelaInventarioBens,
                            strTabelaInventarioBens,
                            vetStrValidarEscritaRegistro[intColuna - 2],
                            "LIKE",
                            string.Format("'{0}'", string.Empty),
                            vetStrValidarEscritaRegistro[intColuna - 2],
                            false
                            );
                        intContadorProcurarParcial++;
                    }
                    else
                    {
                        objImplementacaoBancoDados.mtdSelecionarDados
                            (
                            0,
                            vetCamposTabelaInventarioBens,
                            strTabelaInventarioBens,
                            vetStrValidarEscritaRegistro[intColuna - 2],
                            "LIKE",
                            string.Format("'{0}'", string.Empty),
                            vetStrValidarEscritaRegistro[intColuna - 2],
                            false
                            );
                        intContadorProcurarParcial = 0;
                    }
                }

                objImplementacaoBancoDados.mtdDefinirLeitorDados();

                while (objImplementacaoBancoDados.mtdProximoRegistro())
                {
                    System.Threading.Thread.Sleep(1);
                    if (blnAbortarThreadCadastroOtimizado & blnForcarAbortarThreadCadastroOtimizado) goto SaidaCadastroOtimizado;

                    mtdProcurarOtimizado
                        (
                        objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensPatrimonio).ToString(),
                        objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensNumero_Inventario).ToString()
                        );
                    mtdAtualizarOtimizado
                        (
                        objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensPatrimonio).ToString(),
                        objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensNumero_Inventario).ToString()
                        );
                }
            }
            catch (Exception ex)
            {
                string strExcecao = "mtdCadastroOtimizado: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }

        SaidaCadastroOtimizado:

            objImplementacaoBancoDados.Dispose();
        }

        private string strSemConteudo = "NAO HA INFORMACOES";

        private void mtdProcurarOtimizado(string PatrimonioItem, string NumeroInventario)
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
                System.Threading.Thread.Sleep(1);
                if (blnAbortarThreadCadastroOtimizado & blnForcarAbortarThreadCadastroOtimizado) goto SaidaProcurarOtimizado;

                clsManipuladorTexto objManipuladorTexto = new clsManipuladorTexto();

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
                    "N'{0}'",
                    PatrimonioItem
                    ),
                    string.Format
                    (
                    "{0}",
                    vetCamposTabelaBensEletronorte[intColunaTabelaBensEletronortePatrimonio]
                    ),
                    true
                    );

                objImplementacaoBancoDados.mtdDefinirLeitorDados();
                if (objImplementacaoBancoDados.mtdProximoRegistro())
                {
                    strTRGItem = objManipuladorTexto.mtdExecutarTudo(objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaBensEletronorteTRG).ToString());
                    strCentroCustoItem = objManipuladorTexto.mtdExecutarTudo(objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaBensEletronorteCentro_Custo).ToString());
                    strOrgaoItem = objManipuladorTexto.mtdExecutarTudo(objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaBensEletronorteOrgao).ToString());
                    strOrgaoItem = objManipuladorTexto.mtdExecutarTudo
                        (
                        strOrgaoItem.Split(' ')[strOrgaoItem.Split(' ').GetLowerBound(0)]
                        );
                    strSalaItem = objManipuladorTexto.mtdExecutarTudo(objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaBensEletronorteSala).ToString());
                    //strNomeItem.Text = string.Empty;
                    strMatriculaItem = objManipuladorTexto.mtdExecutarTudo(objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaBensEletronorteMatricula).ToString());
                    strPatrimonioItem = objManipuladorTexto.mtdExecutarTudo(objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaBensEletronortePatrimonio).ToString());
                    strQuantidadeItem = "1";
                    strDenominacaoItem = objManipuladorTexto.mtdExecutarTudo
                        (
                        string.Format
                        (
                        "{0} {1}",
                        objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaBensEletronorteDenominacao).ToString(),
                        objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaBensEletronorteDenominacao_Extra).ToString())
                        );
                    strNSerieItem = objManipuladorTexto.mtdExecutarTudo(objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaBensEletronorteN_Serie).ToString());
                    strPlacaVeiculoItem = objManipuladorTexto.mtdExecutarTudo(objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaBensEletronortePlaca_Veiculo).ToString());
                    strNomeItem = objManipuladorTexto.mtdExecutarTudo(mtdObterNomeItem(objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaBensEletronorteMatricula).ToString()));
                }
                else
                {
                    if (blnValidarEscritaRegistro)
                    {
                        strNumeroInventario = NumeroInventario;
                        strPatrimonioItem = PatrimonioItem;
                    }
                    else
                    {
                        strNumeroInventario = string.Empty;
                        strPatrimonioItem = string.Empty;
                    }

                    strTRGItem = vetBlnValidarEscritaRegistro[0] ? strSemConteudo : string.Empty;
                    strCentroCustoItem = vetBlnValidarEscritaRegistro[1] ? strSemConteudo : string.Empty;
                    strOrgaoItem = vetBlnValidarEscritaRegistro[2] ? strSemConteudo : string.Empty;
                    strSalaItem = vetBlnValidarEscritaRegistro[3] ? strSemConteudo : string.Empty;
                    strNomeItem = vetBlnValidarEscritaRegistro[4] ? strSemConteudo : string.Empty;
                    strMatriculaItem = vetBlnValidarEscritaRegistro[5] ? strSemConteudo : string.Empty;
                    strQuantidadeItem = "1";
                    strDenominacaoItem = vetBlnValidarEscritaRegistro[6] ? strSemConteudo : string.Empty;
                    strNSerieItem = vetBlnValidarEscritaRegistro[7] ? strSemConteudo : string.Empty;
                    strPlacaVeiculoItem = vetBlnValidarEscritaRegistro[8] ? strSemConteudo : string.Empty;
                }
            }
            catch (Exception ex)
            {
                strNumeroInventario = string.Empty;
                strPatrimonioItem = string.Empty;

                strTRGItem = string.Empty;
                strCentroCustoItem = string.Empty;
                strOrgaoItem = string.Empty;
                strSalaItem = string.Empty;
                strNomeItem = string.Empty;
                strMatriculaItem = string.Empty;
                strQuantidadeItem = "1";
                strDenominacaoItem = string.Empty;
                strNSerieItem = string.Empty;
                strPlacaVeiculoItem = string.Empty;

                string strExcecao = "mtdProcurarOtimizado: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }

        SaidaProcurarOtimizado:

            objImplementacaoBancoDados.Dispose();
        }

        private void mtdAtualizarOtimizado(string PatrimonioItem, string NumeroInventario)
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

            System.Threading.Thread.Sleep(1);
            if (blnAbortarThreadCadastroOtimizado & blnForcarAbortarThreadCadastroOtimizado) goto SaidaAtualizarOtimizado;

            ulong ulngNumeroInventario = 0;
            object Inventario = null;

            if (!NumeroInventario.Equals(string.Empty))
            {
                ulngNumeroInventario = System.Convert.ToUInt64(NumeroInventario);
            }
            else
            {
                ulngNumeroInventario = mtdGerarProximoNumeroInventario();
            }

            objImplementacaoBancoDados.mtdAbrirConexao();
            objImplementacaoBancoDados.mtdExecutarComando
                (
                string.Format
                (
                "SELECT {0} FROM {1} WHERE ({2} LIKE {4} AND {3} LIKE {5}) ORDER BY {6}",
                "*",
                strTabelaInventarioBens,
                vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensNumero_Inventario],
                vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensPatrimonio],
                string.Format
                (
                "'{0}'",
                NumeroInventario
                ),
                string.Format
                (
                "N'{0}'",
                PatrimonioItem
                ),
                string.Format
                (
                "{0}",
                vetCamposTabelaInventarioBens[intColunaTabelaInventarioBensNumero_Inventario]
                )
                )
                );
            objImplementacaoBancoDados.mtdDefinirLeitorDados();

            try
            {
                if (objImplementacaoBancoDados.mtdProximoRegistro())
                {
                    ulngNumeroInventario = System.Convert.ToUInt64(objImplementacaoBancoDados.mtdObterValorRegistro(0).ToString());
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

                    dadosP[0] = dados[0];
                    dadosP[1] = new object[vetCamposTabelaInventarioBens.GetUpperBound(0) + 1];
                    dadosP[1][intColunaTabelaInventarioBensNumero_Inventario] = ulngNumeroInventario;
                    //dadosP[1][intColunaTabelaInventarioBensTRG] = objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensTRG);
                    dadosP[1][intColunaTabelaInventarioBensData_Inventario] = System.DateTime.Now;
                    dadosP[1][intColunaTabelaInventarioBensTRG] = blnTRGItemA ? strTRGItem : objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensTRG);
                    dadosP[1][intColunaTabelaInventarioBensCentroCusto] = blnCentroCustoItemA ? strCentroCustoItem : objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensCentroCusto);
                    dadosP[1][intColunaTabelaInventarioBensOrgao] = blnOrgaoItemA ? strOrgaoItem : objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensOrgao);
                    dadosP[1][intColunaTabelaInventarioBensSala] = blnSalaItemA ? strSalaItem : objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensSala);
                    dadosP[1][intColunaTabelaInventarioBensNome] = blnNomeItemA ? strNomeItem : objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensNome);
                    dadosP[1][intColunaTabelaInventarioBensMatricula] = blnMatriculaItemA ? strMatriculaItem : objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensMatricula);
                    dadosP[1][intColunaTabelaInventarioBensPatrimonio] = blnPatrimonioItemA ? PatrimonioItem : objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensPatrimonio);
                    dadosP[1][intColunaTabelaInventarioBensQuantidade] = blnQuantidadeItemA ? strQuantidadeItem : objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensQuantidade);
                    dadosP[1][intColunaTabelaInventarioBensDenominacao] = blnDenominacaoItemA ? strDenominacaoItem : objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensDenominacao);
                    dadosP[1][intColunaTabelaInventarioBensN_Serie] = blnNSerieItemA ? strNSerieItem : objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensN_Serie);
                    dadosP[1][intColunaTabelaInventarioBensPlaca_Veiculo] = blnPlacaVeiculoItemA ? strPlacaVeiculoItem : objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensPlaca_Veiculo);
                    dadosP[1][intColunaTabelaInventarioBensObservacao] = objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensObservacao);
                    dadosP[1][intColunaTabelaInventarioBensIdentificacao_Inventario] = blnIdentificacaoItemA ? strIdentificacaoItem : objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensIdentificacao_Inventario);
                    dadosP[1][intColunaTabelaInventarioBensOutrosDados_Inventario] = blnOutrosDadosItemA ? strOutrosDadosItem : objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensOutrosDados_Inventario);
                    dadosP[1][intColunaTabelaInventarioBensColetor] = objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensColetor);
                    dadosP[1][intColunaTabelaInventarioBensUsuario_Inventariante] = objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensUsuario_Inventariante);
                    dadosP[1][intColunaTabelaInventarioBensMatricula_Inventariante] = objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensMatricula_Inventariante);
                    //dadosP[1][intColunaTabelaInventarioBensInventario] = string.Empty;
                    dadosP[1][intColunaTabelaInventarioBensInventario] = Inventario;
                    dadosP[1][intColunaTabelaInventarioBensFotografia] = objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensFotografia);
                    dadosP[1][intColunaTabelaInventarioBensGPS_Latitute] = objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensGPS_Latitute);
                    dadosP[1][intColunaTabelaInventarioBensGPS_Longitude] = objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensGPS_Longitude);
                    dadosP[1][intColunaTabelaInventarioBensGPS_EllipsoidAltitude] = objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensGPS_EllipsoidAltitude);
                    dadosP[1][intColunaTabelaInventarioBensGPS_PositionDilutionOfPrecision] = objImplementacaoBancoDados.mtdObterValorRegistro(intColunaTabelaInventarioBensGPS_PositionDilutionOfPrecision);

                    //long lngCodigoEspalhamento = 0;
                    //long[] vetCodigoEspalhamento = new long[dadosP[1].GetLength(0)];
                    //for (int contador = dadosP[1].GetLowerBound(0) + 1; contador <= dadosP[1].GetUpperBound(0); contador++)
                    //{
                    //    if (blnAbortarThreadCadastroOtimizado & blnForcarAbortarThreadCadastroOtimizado) goto SaidaAtualizarOtimizado;

                    //    if (contador == 1)
                    //    {
                    //        vetCodigoEspalhamento[contador] = mtdObterCodigoEspalhamento
                    //            (
                    //            System.Convert.ToString
                    //            (
                    //            System.Convert.ToDateTime
                    //            (
                    //            dadosP[1][contador]
                    //            ).Ticks
                    //            )
                    //            );
                    //    }
                    //    else
                    //    {
                    //        vetCodigoEspalhamento[contador] = mtdObterCodigoEspalhamento
                    //            (
                    //            System.Convert.ToString
                    //            (
                    //            dadosP[1][contador]
                    //            )
                    //            );
                    //    }
                    //    lngCodigoEspalhamento = lngCodigoEspalhamento ^ vetCodigoEspalhamento[contador];
                    //}
                    //dadosP[1][intColunaTabelaInventarioBensInventario] = lngCodigoEspalhamento;

                    objImplementacaoBancoDados.prpComandoSQLServerCE.Parameters.Clear();

                    for (int contador = dadosP[0].GetLowerBound(0); contador <= dadosP[0].GetUpperBound(0); contador++)
                    {
                        System.Threading.Thread.Sleep(1);
                        if (blnAbortarThreadCadastroOtimizado & blnForcarAbortarThreadCadastroOtimizado) goto SaidaAtualizarOtimizado;

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
                    objImplementacaoBancoDados.mtdAtualizarDados(strTabelaInventarioBens, dados);
                }
            }
            catch (Exception ex)
            {
                string strExcecao = "mtdAtualizarOtimizado: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }

        SaidaAtualizarOtimizado:

            objImplementacaoBancoDados.Dispose();
        }
    }
}
