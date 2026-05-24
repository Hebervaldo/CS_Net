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
        private uint uintNumeroLinhas = 100;

        private string mtdObterLegenda()
        {
            string Retorno = string.Format
            (
                "{0}" + Environment.NewLine + "{1}" + Environment.NewLine + "{2}" + Environment.NewLine + "{3}",
                string.Format("{0}", "Legenda:"),
                string.Format("{0}", "  Nota 0 - Serviço não realizado;"),
                string.Format("{0}", "  Nota 1 - Serviço realizado e não conforme;"),
                string.Format("{0}", "  Nota 2 - Serviço realizado em conformidade.")
            );

            return Retorno;
        }

        private void mtdPreencherLsvIndiceCmb(int Indice)
        {
            switch (Indice)
            {
                case 0:
                    mtdPreencherLsvBanheiroMasculino();
                    break;
                case 1:
                    mtdPreencherLsvBanheiroFeminino();
                    break;
                case 2:
                    mtdPreencherLsvPisos();
                    break;
                case 3:
                    mtdPreencherLsvReposicaoMateriais();
                    break;
                case 4:
                    mtdPreencherLsvRecolhimentoLixo();
                    break;
                case 5:
                    mtdPreencherLsvOutrosServicosLimpeza();
                    break;
            }
        }

        private List<string> cbiServicos = new List<string>() { };

        private void mtdPreencherCmbServicos()
        {
            cbiServicos.Clear();

            cbiServicos.Add("Banheiro Masculino");
            cbiServicos.Add("Banheiro Feminino");
            cbiServicos.Add("Piso");
            cbiServicos.Add("Reposicao de Materiais");
            cbiServicos.Add("Recolhimento de Lixo");
            cbiServicos.Add("Outros Servicos de Limpeza");

            mtdPreencherCmb(ref cmbServicos, cbiServicos);
        }

        private void mtdIniciarTblColunasItens()
        {
            mtdIniciarTblColunasItensBanheiroMasculino();
            mtdIniciarTblColunasItensBanheiroFeminino();
            mtdIniciarTblColunasItensPisos();
            mtdIniciarTblColunasItensReposicaoMateriais();
            mtdIniciarTblColunasItensRecolhimentoLixo();
            mtdIniciarTblColunasItensOutrosServicosLimpeza();
        }

        List<List<string>> tblColunasBanheiroMasculino = new List<List<string>> { };
        List<List<string>> tblItensBanheiroMasculino = new List<List<string>> { };

        private void mtdIniciarTblColunasItensBanheiroMasculino()
        {
            tblColunasBanheiroMasculino.Clear();

            tblColunasBanheiroMasculino.Add(new List<string> { "Item", "170" });
            tblColunasBanheiroMasculino.Add(new List<string> { "Nota", "100" });

            tblItensBanheiroMasculino.Clear();

            tblItensBanheiroMasculino.Add(new List<String> { "Vaso sanitário", "0" });
            tblItensBanheiroMasculino.Add(new List<String> { "Pia", "0" });
            tblItensBanheiroMasculino.Add(new List<String> { "Mictório", "0" });
            tblItensBanheiroMasculino.Add(new List<String> { "Piso", "0" });
        }

        private void mtdPreencherLsvBanheiroMasculino()
        {
            mtdIniciarLsv(ref lsvServicos);
            mtdPreencherColunasLsv(ref lsvServicos, tblColunasBanheiroMasculino);
            mtdPreencherDadosLsv(ref lsvServicos, tblItensBanheiroMasculino);
        }

        List<List<string>> tblColunasBanheiroFeminino = new List<List<string>> { };
        List<List<string>> tblItensBanheiroFeminino = new List<List<string>> { };

        private void mtdIniciarTblColunasItensBanheiroFeminino()
        {
            tblColunasBanheiroFeminino.Clear();

            tblColunasBanheiroFeminino.Add(new List<string> { "Item", "170" });
            tblColunasBanheiroFeminino.Add(new List<string> { "Nota", "100" });

            tblItensBanheiroFeminino.Clear();

            tblItensBanheiroFeminino.Add(new List<String> { "Vaso sanitário", "0" });
            tblItensBanheiroFeminino.Add(new List<String> { "Pia", "0" });
            tblItensBanheiroFeminino.Add(new List<String> { "Piso", "0" });
        }

        private void mtdPreencherLsvBanheiroFeminino()
        {
            mtdIniciarLsv(ref lsvServicos);
            mtdPreencherColunasLsv(ref lsvServicos, tblColunasBanheiroFeminino);
            mtdPreencherDadosLsv(ref lsvServicos, tblItensBanheiroFeminino);
        }

        List<List<string>> tblColunasPisos = new List<List<string>> { };
        List<List<string>> tblItensPisos = new List<List<string>> { };

        private void mtdIniciarTblColunasItensPisos()
        {
            tblColunasPisos.Clear();

            tblColunasPisos.Add(new List<string> { "Item", "170" });
            tblColunasPisos.Add(new List<string> { "Nota", "100" });

            tblItensPisos.Clear();

            tblItensPisos.Add(new List<String> { "Corredores Torres", "0" });
            tblItensPisos.Add(new List<String> { "Corredores Subsolos", "0" });
            tblItensPisos.Add(new List<String> { "Salas", "0" });
            tblItensPisos.Add(new List<String> { "Carpete", "0" });
        }

        private void mtdPreencherLsvPisos()
        {
            mtdIniciarLsv(ref lsvServicos);
            mtdPreencherColunasLsv(ref lsvServicos, tblColunasPisos);
            mtdPreencherDadosLsv(ref lsvServicos, tblItensPisos);
        }

        List<List<string>> tblColunasReposicaoMateriais = new List<List<string>> { };
        List<List<string>> tblItensReposicaoMateriais = new List<List<string>> { };

        private void mtdIniciarTblColunasItensReposicaoMateriais()
        {
            tblColunasReposicaoMateriais.Clear();

            tblColunasReposicaoMateriais.Add(new List<string> { "Item", "170" });
            tblColunasReposicaoMateriais.Add(new List<string> { "Nota", "100" });

            tblItensReposicaoMateriais.Clear();

            tblItensReposicaoMateriais.Add(new List<String> { "Papel Toalha", "0" });
            tblItensReposicaoMateriais.Add(new List<String> { "Papel Higiênico", "0" });
            tblItensReposicaoMateriais.Add(new List<String> { "Sabonete Líquido", "0" });
            tblItensReposicaoMateriais.Add(new List<String> { "Protetor de Assento", "0" });
            tblItensReposicaoMateriais.Add(new List<String> { "Alcool Gel", "0" });
        }

        private void mtdPreencherLsvReposicaoMateriais()
        {
            mtdIniciarLsv(ref lsvServicos);
            mtdPreencherColunasLsv(ref lsvServicos, tblColunasReposicaoMateriais);
            mtdPreencherDadosLsv(ref lsvServicos, tblItensReposicaoMateriais);
        }

        List<List<string>> tblColunasRecolhimentoLixo = new List<List<string>> { };
        List<List<string>> tblItensRecolhimentoLixo = new List<List<string>> { };

        private void mtdIniciarTblColunasItensRecolhimentoLixo()
        {
            tblColunasRecolhimentoLixo.Clear();

            tblColunasRecolhimentoLixo.Add(new List<string> { "Item", "170" });
            tblColunasRecolhimentoLixo.Add(new List<string> { "Nota", "100" });

            tblItensRecolhimentoLixo.Clear();

            tblItensRecolhimentoLixo.Add(new List<String> { "Lixo dos banheiros", "0" });
            tblItensRecolhimentoLixo.Add(new List<String> { "Lixo outras áreas", "0" });
            tblItensRecolhimentoLixo.Add(new List<String> { "Lixo reciclável", "0" });
        }

        private void mtdPreencherLsvRecolhimentoLixo()
        {
            mtdIniciarLsv(ref lsvServicos);
            mtdPreencherColunasLsv(ref lsvServicos, tblColunasRecolhimentoLixo);
            mtdPreencherDadosLsv(ref lsvServicos, tblItensRecolhimentoLixo);
        }

        List<List<string>> tblColunasOutrosServicosLimpeza = new List<List<string>> { };
        List<List<string>> tblItensOutrosServicosLimpeza = new List<List<string>> { };

        private void mtdIniciarTblColunasItensOutrosServicosLimpeza()
        {
            tblColunasOutrosServicosLimpeza.Clear();

            tblColunasOutrosServicosLimpeza.Add(new List<string> { "Item", "170" });
            tblColunasOutrosServicosLimpeza.Add(new List<string> { "Nota", "100" });

            tblItensOutrosServicosLimpeza.Clear();

            tblItensOutrosServicosLimpeza.Add(new List<String> { "Mobiliário", "0" });
            tblItensOutrosServicosLimpeza.Add(new List<String> { "Persianas", "0" });
            tblItensOutrosServicosLimpeza.Add(new List<String> { "Vidros", "0" });
        }

        private void mtdPreencherLsvOutrosServicosLimpeza()
        {
            mtdIniciarLsv(ref lsvServicos);
            mtdPreencherColunasLsv(ref lsvServicos, tblColunasOutrosServicosLimpeza);
            mtdPreencherDadosLsv(ref lsvServicos, tblItensOutrosServicosLimpeza);
        }

        List<List<string>> tblColunasInspecao = new List<List<string>> { };
        List<List<string>> tblItensInspecao = new List<List<string>> { };

        private void mtdIniciarDtg()
        {
            //mtdIniciarDtg(ref dtgInspecao);
        }

        private void mtdPreencherDtg(ref System.Windows.Forms.DataGrid Dtg, uint NumeroLinhas, bool Crescente)
        {
            System.Data.DataTable dt = mtdSelecionarDadosTabelaInspecao(NumeroLinhas, lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Codigo], "LIKE", "'%'", lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Codigo], Crescente);
            //mtdPreencherDtg(ref Dtg, dt, uintComprimento);
        }

        private void mtdPreencherLsv(ref System.Windows.Forms.ListView Lsv, uint NumeroLinhas, bool Crescente)
        {
            System.Data.DataTable dt = mtdSelecionarDadosTabelaInspecao(NumeroLinhas, lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Codigo], "LIKE", "'%'", lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Codigo], Crescente);
            mtdPreencherLsv(ref Lsv, NumeroLinhas, Crescente, dt);
        }

        private void mtdPreencherLsv(ref System.Windows.Forms.ListView Lsv, uint NumeroLinhas, bool Crescente, System.Data.DataTable dt)
        {
            mtdIniciarLsv(ref Lsv, false);
            mtdPreencherColunasLsv(ref Lsv, dt, uintComprimento);
            mtdPreencherDadosLsv(ref Lsv, dt);
        }

        public WebServiceInspecao.WebServiceInspecao objWebServiceInspecao = new WebServiceInspecao.WebServiceInspecao();

        private bool mtdUploadWebService()
        {
            bool Retorno = false;
            
            Retorno = mtdUploadWebService(false);

            return Retorno;
        }

        private bool mtdUploadWebService(bool ForcarUpload)
        {
            bool Retorno = true;

            try
            {
                System.Data.DataSet ds = new System.Data.DataSet();
                System.Data.DataTable dt = new System.Data.DataTable();

                dt = objManipulacaoBaseDadosColetor.mtdSelecionarDadosTabela
                    (
                        0,
                        lstColunasTabelaInspecao,
                        strTabelaInspecao,
                        lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Codigo],
                        "LIKE",
                        "'%'",
                        lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Codigo],
                        true
                    );

                ds.Tables.Add(dt.Clone());
                ds.Tables[0].Rows.Add();

                for (int linha = 0; linha <= dt.Rows.Count - 1; linha++)
                {
                    if (System.Convert.ToInt32(dt.Rows[linha].ItemArray[(int)enmColunasTabelaInspecao.Enviar]) == 1 || ForcarUpload)
                    {
                        mtdAlterarDadosTabelaInspecao
                        (
                            0,
                            lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Codigo],
                            "LIKE",
                            dt.Rows[linha].ItemArray[(int)enmColunasTabelaInspecao.Codigo]
                        );

                        ds.Tables[0].Rows[0].ItemArray = dt.Rows[linha].ItemArray;
                        ds.Tables[0].Rows[0].ItemArray[(int)enmColunasTabelaInspecao.Enviar] = 0;
                        Retorno &= objWebServiceInspecao.mtdInserirDadosTabelaInspecao(ds);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Retorno = false;
            }
            finally
            {
            }

            return Retorno;
        }

        private List<string> mtdGerarEnderecoNomeBancoDados(string BaseDadosColetor)
        {
            string[] strBaseDados = BaseDadosColetor.Split('\\');

            string strEnderecoBancoDadosColetor = string.Empty;

            for (int contador = strBaseDados.GetLowerBound(0); contador <= strBaseDados.GetUpperBound(0) - 1; contador++)
            {
                strEnderecoBancoDadosColetor += strBaseDados[contador] + @"\";
            }

            return new List<string> { strEnderecoBancoDadosColetor, strBaseDados[strBaseDados.GetUpperBound(0)] };
        }

        private void mtdAjustarEnderecoNomeTextoBancoDados(string Diretorio)
        {
            mtdAjustarEnderecoBancoDadosColetor(Diretorio);
            List<string> vetNomeEnderecoBancoDados = mtdGerarEnderecoNomeBancoDados(Diretorio);
            strEnderecoBancoDadosColetor = vetNomeEnderecoBancoDados[0];
            strNomeBancoDadosColetor = vetNomeEnderecoBancoDados[1];
            txtEnderecoBancoDados.Text = Diretorio;
        }

        private void mtdAjustarEnderecoBancoDadosColetor(string Valor)
        {
            // Write out to text file

            string strEnderecoArquivo = string.Format(@"{0}\{1}\", cntEnderecoBancoDadosColetor, "Arquivo");
            System.IO.Directory.CreateDirectory(strEnderecoArquivo);
            System.IO.StreamWriter writer = System.IO.File.CreateText(string.Format(@"{0}\EnderecoBancoDadosColetor.txt", strEnderecoArquivo));
            writer.WriteLine(Valor);

            writer.Close();
        }

        private string mtdObterEnderecoBancoDadosColetor()
        {
            string Retorno = string.Empty;

            try
            {
                // Read all lines from text file
                string strEnderecoArquivo = string.Format(@"{0}\{1}\", cntEnderecoBancoDadosColetor, "Arquivo");
                System.IO.Directory.CreateDirectory(strEnderecoArquivo);
                System.IO.StreamReader reader = System.IO.File.OpenText(string.Format(@"{0}\EnderecoBancoDadosColetor.txt", strEnderecoArquivo));
                string line = reader.ReadLine();
                //while (line != null)
                //{
                //    line = reader.ReadLine();
                //}

                Retorno = line;

                reader.Close();
            }
            catch (System.Exception ex)
            {
                Retorno = mtdGerarCaminhoBaseDadosColetor(cntEnderecoBancoDadosColetor, cntNomeBancoDadosColetor);
                mtdAjustarEnderecoBancoDadosColetor(Retorno);
            }

            return Retorno;
        }

        private void mtdAjustarSenhaBancoDadosColetor(string Valor)
        {
            // Write out to text file

            string strEnderecoArquivo = string.Format(@"{0}\{1}\", cntEnderecoBancoDadosColetor, "Arquivo");
            System.IO.Directory.CreateDirectory(strEnderecoArquivo);
            System.IO.StreamWriter writer = System.IO.File.CreateText(string.Format(@"{0}\SenhaBancoDadosColetor.txt", strEnderecoArquivo));
            writer.WriteLine(Valor);

            writer.Close();
        }

        private string mtdObterSenhaBancoDadosColetor()
        {
            string Retorno = string.Empty;

            try
            {
                // Read all lines from text file
                string strEnderecoArquivo = string.Format(@"{0}\{1}\", cntEnderecoBancoDadosColetor, "Arquivo");
                System.IO.Directory.CreateDirectory(strEnderecoArquivo);
                System.IO.StreamReader reader = System.IO.File.OpenText(string.Format(@"{0}\SenhaBancoDadosColetor.txt", strEnderecoArquivo));
                string line = reader.ReadLine();
                //while (line != null)
                //{
                //    line = reader.ReadLine();
                //}

                Retorno = line;

                reader.Close();
            }
            catch (System.Exception ex)
            {
                Retorno = cntSenhaBaseDadosColetor;
                mtdAjustarSenhaBancoDadosColetor(Retorno);
            }

            return Retorno;
        }

        private bool mtdTestarConexao()
        {
            return mtdTestarConexao(strBaseDadosColetor, strSenhaBaseDadosColetor);
        }

        private bool mtdTestarConexao(string BaseDadosColetor, string SenhaBaseDadosColetor)
        {
            bool retorno = false;

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

            retorno = objImplementacaoBancoDados.mtdAbrirConexao();

            objImplementacaoBancoDados.Dispose();

            return retorno;
        }

        private void mtdTestarConexao_()
        {
            System.Windows.Forms.MessageBox.Show
                (
                mtdTestarConexao() ? "A conexão foi realizada com sucesso." : "Não foi possível realizar a conexão, verifique se o arquivo existe ou se a senha está correta.",
                "Aviso!",
                System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.Exclamation,
                System.Windows.Forms.MessageBoxDefaultButton.Button1
                );
        }

        public void mtdSincronizarHorarioServidor()
        {
            mtdSincronizarHorarioServidor(true);
        }

        public void mtdSincronizarHorarioServidor(bool Notificacao)
        {
            string Retorno = string.Empty;

            try
            {
                Cursor.Current = Cursors.WaitCursor; // set the wait cursor
                //Do some work

                if (clsDataTempoSistema.mtdAjustarDataTempoSistema(objWebServiceInspecao.Url))
                {
                    dtpDataInspecao.Value = System.DateTime.Now;

                    try
                    {
                        Retorno = "A data e o tempo do dispositivo foram sincronizados com um servidor externo.";
                    }
                    catch (System.Exception ex)
                    {
                        Retorno = "A data e o tempo foram sincronizados.";
                    }
                }
                else
                {
                    try
                    {
                        Retorno = "Não foi possível sincronizar a data e o tempo do dispositivo com um servidor externo.";
                    }
                    catch (System.Exception ex)
                    {
                        Retorno = "A data e o tempo não foram sincronizados.";
                    }
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default; //restore the old cursor
            }

            if (Notificacao)
            {
                System.Windows.Forms.MessageBox.Show
                (
                    Retorno,
                    "Aviso!",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Exclamation,
                    System.Windows.Forms.MessageBoxDefaultButton.Button1
                );
            }
        }
    }
}