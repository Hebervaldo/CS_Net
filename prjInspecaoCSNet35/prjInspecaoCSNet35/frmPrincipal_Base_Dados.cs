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
        public static string cntExtensaoBancoDadosColetor = ".sdf";

        //public static clsEnderecoAplicativo objEnderecoAplicativo = new clsEnderecoAplicativo();

        private static string strEnderecoStorageCard = @"\Storage Card\";
        private static string strEnderecoFlashDisk = @"\Flash Disk\";

        public readonly string cntEnderecoBancoDadosColetor = System.IO.Path.GetDirectoryName
        (
            System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase
        );
        // public static string cntEnderecoBancoDadosColetor = AppDomain.CurrentDomain.BaseDirectory;

        public static string strEnderecoBancoDadosColetor = string.Empty;
        //private static string strEnderecoBancoDadosColetor = @"\Storage Card\";
        //private static string strEnderecoBancoDadosColetor = cntEnderecoBancoDadosColetor;

        public static string DiretorioEnderecoAplicativo = string.Empty;
        public const string DiretorioArmazenamento = "Armazenamento";
        public static string DiretorioArmazenamentoCompleto = string.Empty;

        public static string cntNomeBancoDadosColetor = @"dbInspecao";
        public static string cntSenhaBaseDadosColetor = "12345678";

        public static string strNomeBancoDadosColetor = @"dbInspecao";
        public static string strBaseDadosColetor = string.Empty;
        public static string strSenhaBaseDadosColetor = "12345678";

        public static string strTabelaInspecao = "tblInspecao";
        public static string strTabelaEstatistica_01 = "tblEstatistica_01";
        public static string strTabelaEstatistica_02 = "tblEstatistica_02";
        public static string strTabelaDadosCamposColetor = "tblDadosCamposColetor";
        public static string strTabelaEndereco = "tblEndereco";

        public static clsManipulacaoBaseDados objManipulacaoBaseDadosColetor = new clsManipulacaoBaseDados(strBaseDadosColetor, strSenhaBaseDadosColetor, strTabelaInspecao);

        public static List<string> lstColunasTabelaInspecao = new List<string> { };
        public static List<object> lstColunasTabelaInspecaoObject = new List<object> { };
        public static List<List<string>> tblCamposTabelaInspecao = new List<List<string>> { };
        public static List<List<object>> tblCamposDadosTabelaInspecao = new List<List<object>> { };

        //public static List<string> lstColunasTabelaEstatistica = new List<string> { };
        public static List<object> lstColunasTabelaEstatisticaObject = new List<object> { };
        public static List<List<string>> tblCamposTabelaEstatistica = new List<List<string>> { };
        public static List<List<object>> tblCamposDadosTabelaEstatistica = new List<List<object>> { };

        public static List<string> lstColunasTabelaDadosCamposColetor = new List<string> { };
        public static List<object> lstColunasTabelaDadosCamposColetorObject = new List<object> { };
        public static List<List<string>> tblCamposTabelaDadosCamposColetor = new List<List<string>> { };
        public static List<List<object>> tblCamposDadosTabelaDadosCamposColetor = new List<List<object>> { };

        public static List<string> lstColunasTabelaEndereco = new List<string> { };
        public static List<object> lstColunasTabelaEnderecoObject = new List<object> { };
        public static List<List<string>> tblCamposTabelaEndereco = new List<List<string>> { };
        public static List<List<object>> tblCamposDadosTabelaEndereco = new List<List<object>> { };

        private string mtdGerarCaminhoBaseDadosColetor(string EnderecoBancoDadosColetor, string NomeBancoDadosColetor)
        {
            if (!EnderecoBancoDadosColetor.Contains(DiretorioArmazenamento))
            {
                frmPrincipal.DiretorioArmazenamentoCompleto = String.Format(@"{0}\{1}\", EnderecoBancoDadosColetor, DiretorioArmazenamento).Replace(@"\\", @"\");
            }
            else
            {
                frmPrincipal.DiretorioArmazenamentoCompleto = String.Format(@"{0}\", EnderecoBancoDadosColetor).Replace(@"\\", @"\");
            }

            try
            {
                System.IO.Directory.CreateDirectory(frmPrincipal.DiretorioArmazenamentoCompleto);
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdBaseDados_Load: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
            frmPrincipal.DiretorioEnderecoAplicativo = DiretorioArmazenamentoCompleto;
            strBaseDadosColetor = (frmPrincipal.DiretorioArmazenamentoCompleto + NomeBancoDadosColetor + (NomeBancoDadosColetor.Contains(cntExtensaoBancoDadosColetor) ? string.Empty : cntExtensaoBancoDadosColetor));

            return strBaseDadosColetor;
        }

        private void mtdBaseDados_Load()
        {
            mtdGerarListaColunasTabelaInspecao();
            mtdGerarListaColunasTabelaDadosCamposColetor();
            mtdGerarListaColunasTabelaEndereco();
            mtdRotinaPreparacaoColetor();
            mtdCriarTabelaInspecao();
            mtdCriarTabelaCamposDadosColetor();
            mtdCriarTabelaEndereco();
        }

        public enum enmColunasTabelaInspecao
        {
            Codigo = 0,
            Identificacao = 1,
            HashCode = 2,
            Data = 3,
            Data_Hora = 4,
            Inspetor = 5,
            Coletor = 6,
            Servico = 7,
            Endereco = 8,
            Item = 9,
            Nota = 10,
            Enviar = 11
        }

        public enum enmColunasTabelaDadosCamposColetor
        {
            Campos = 0,
            Dados = 1,
        }

        public enum enmColunasTabelaEndereco
        {
            Endereco = 0
        }

        public void mtdGerarListaColunasTabelaInspecao()
        {
            lstColunasTabelaInspecao = new List<string> { };
            lstColunasTabelaInspecao.Add("Codigo");
            lstColunasTabelaInspecao.Add("Identificacao");
            lstColunasTabelaInspecao.Add("HashCode");
            lstColunasTabelaInspecao.Add("Data");
            lstColunasTabelaInspecao.Add("Data_Hora");
            lstColunasTabelaInspecao.Add("Inspetor");
            lstColunasTabelaInspecao.Add("Coletor");
            lstColunasTabelaInspecao.Add("Servico");
            lstColunasTabelaInspecao.Add("Endereco");
            lstColunasTabelaInspecao.Add("Item");
            lstColunasTabelaInspecao.Add("Nota");
            lstColunasTabelaInspecao.Add("Enviar");

            foreach (string item in frmPrincipal.lstColunasTabelaInspecao)
            {
                lstColunasTabelaInspecaoObject.Add(item.ToString());
            }
        }

        public List<object> mtdGerarListaColunasTabelaEstatistica(List<string> ListaColunas)
        {
            List<object> Retorno = new List<object> { };

            foreach (string item in ListaColunas)
            {
                Retorno.Add(item.ToString());
            }

            return Retorno;
        }

        public void mtdGerarListaColunasTabelaDadosCamposColetor()
        {
            lstColunasTabelaDadosCamposColetor = new List<string> { };
            lstColunasTabelaDadosCamposColetor.Add("Campos");
            lstColunasTabelaDadosCamposColetor.Add("Dados");

            foreach (string item in frmPrincipal.lstColunasTabelaDadosCamposColetor)
            {
                lstColunasTabelaDadosCamposColetorObject.Add(item.ToString());
            }
        }

        public void mtdGerarListaColunasTabelaEndereco()
        {
            lstColunasTabelaEndereco = new List<string> { };
            lstColunasTabelaEndereco.Add("Endereco");

            foreach (string item in frmPrincipal.lstColunasTabelaEndereco)
            {
                lstColunasTabelaEnderecoObject.Add(item.ToString());
            }
        }

        private void mtdRotinaPreparacaoColetor()
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

            if (!objImplementacaoBancoDados.mtdAbrirConexao())
            {
                blnCriado = mtdCriarBaseDadosColetor();
                blnReparado = mtdRepararBancoDadosColetor();
                blnCompactado = mtdCompactarBancoDadosColetor();
            }

            objImplementacaoBancoDados.Dispose();
        }

        private bool mtdCompactarBancoDadosColetor()
        {
            bool saida = false;

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

            saida = objImplementacaoBancoDados.mtdCompactarBancoDadosSQLServerCE();

            objImplementacaoBancoDados.Dispose();

            return saida;
        }

        private bool mtdRepararBancoDadosColetor()
        {
            bool saida = false;

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

            saida = objImplementacaoBancoDados.mtdRepararBancoDadosSQLServerCE();

            objImplementacaoBancoDados.Dispose();

            return saida;
        }

        public bool mtdCriarBaseDadosColetor()
        {
            bool Retorno = false;

            Retorno = objManipulacaoBaseDadosColetor.mtdCriarBancoDados(strBaseDadosColetor, strSenhaBaseDadosColetor);

            return Retorno;
        }

        public bool mtdCriarTabelaInspecao()
        {
            bool Retorno = false;

            tblCamposTabelaInspecao = new List<List<string>> { };

            for (int contador = 0; contador <= lstColunasTabelaInspecao.Count - 1; contador++)
            {
                switch (contador)
                {
                    case 0:
                        tblCamposTabelaInspecao.Add
                        (
                            new List<string> 
                            {
                                lstColunasTabelaInspecao[contador], 
                                "INTEGER",
                                string.Empty, 
                                string.Format
                                (
                                    "CONSTRAINT PrimaryKey{0} PRIMARY KEY", 
                                    lstColunasTabelaInspecao[contador]
                                )
                            }
                        );
                        break;
                    case 10:
                        tblCamposTabelaInspecao.Add
                        (
                            new List<string> 
                            {
                                lstColunasTabelaInspecao[contador], 
                                "FLOAT",
                                string.Empty, 
                                string.Empty
                            }
                        );
                        break;
                    case 11:
                        tblCamposTabelaInspecao.Add
                        (
                            new List<string> 
                            {
                                lstColunasTabelaInspecao[contador], 
                                "INT",
                                string.Empty, 
                                string.Empty
                            }
                        );
                        break;
                    default:
                        tblCamposTabelaInspecao.Add
                        (
                            new List<string> 
                            { 
                                lstColunasTabelaInspecao[contador],
                                "NVARCHAR",
                                "255",
                                string.Empty 
                            }
                        );
                        break;
                }
            }

            Retorno = objManipulacaoBaseDadosColetor.mtdCriarTabela(strTabelaInspecao, tblCamposTabelaInspecao);

            return Retorno;
        }

        public bool mtdCriarTabelaEstatistica(string Tabela, List<string> ListaNomesColunas, List<string> ListaTiposColunas)
        {
            bool Retorno = false;

            tblCamposTabelaEstatistica.Clear();
            tblCamposTabelaEstatistica = new List<List<string>> { };

            for (int contador = 0; contador <= ListaNomesColunas.Count - 1; contador++)
            {
                tblCamposTabelaEstatistica.Add
                (
                    new List<string> 
                    {
                        ListaNomesColunas[contador],
                        ListaTiposColunas[contador],
                        ListaTiposColunas[contador] == "NVARCHAR"? "255": string.Empty,
                        string.Empty
                    }
                );
            }

            Retorno = objManipulacaoBaseDadosColetor.mtdCriarTabela(Tabela, tblCamposTabelaEstatistica);

            return Retorno;
        }

        public bool mtdCriarTabelaCamposDadosColetor()
        {
            bool Retorno = false;

            tblCamposTabelaDadosCamposColetor = new List<List<string>> { };

            for (int contador = 0; contador <= lstColunasTabelaDadosCamposColetor.Count - 1; contador++)
            {
                switch (contador)
                {
                    case 0:
                        tblCamposTabelaDadosCamposColetor.Add
                        (
                            new List<string> 
                            {
                                lstColunasTabelaDadosCamposColetor[contador], 
                                "INTEGER",
                                string.Empty, 
                                string.Format
                                (
                                    "CONSTRAINT PrimaryKey{0} PRIMARY KEY", 
                                    lstColunasTabelaDadosCamposColetor[contador]
                                )
                            }
                        );
                        break;
                    default:
                        tblCamposTabelaDadosCamposColetor.Add
                        (
                            new List<string> 
                            { 
                                lstColunasTabelaDadosCamposColetor[contador],
                                "NVARCHAR",
                                "255",
                                string.Empty 
                            }
                        );
                        break;
                }
            }

            Retorno = objManipulacaoBaseDadosColetor.mtdCriarTabela(strTabelaDadosCamposColetor, tblCamposTabelaDadosCamposColetor);

            return Retorno;
        }

        public bool mtdCriarTabelaEndereco()
        {
            bool Retorno = false;

            tblCamposTabelaEndereco = new List<List<string>> { };

            for (int contador = 0; contador <= lstColunasTabelaEndereco.Count - 1; contador++)
            {
                switch (contador)
                {
                    case 0:
                        tblCamposTabelaEndereco.Add
                        (
                            new List<string> 
                            {
                                lstColunasTabelaEndereco[contador], 
                                "NVARCHAR",
                                "255", 
                                string.Format
                                (
                                    "CONSTRAINT PrimaryKey{0} PRIMARY KEY", 
                                    lstColunasTabelaEndereco[contador]
                                )
                            }
                        );
                        break;
                }
            }

            Retorno = objManipulacaoBaseDadosColetor.mtdCriarTabela(strTabelaEndereco, tblCamposTabelaEndereco);

            return Retorno;
        }

        public bool mtdDeletarTabelaEstatistica(string Tabela)
        {
            bool Retorno = false;

            Retorno = objManipulacaoBaseDadosColetor.mtdCriarTabela(Tabela, tblCamposTabelaEstatistica);

            return Retorno;
        }

        public bool mtdDeletarTabela(string Tabela)
        {
            bool Retorno = false;

            Retorno = objManipulacaoBaseDadosColetor.mtdDeletarTabela(string.Format(@"{0}{1}", strEnderecoBancoDadosColetor, strNomeBancoDadosColetor), strSenhaBaseDadosColetor, Tabela);

            return Retorno;
        }

        public bool mtdAlterarDadosTabelaInspecao
        (
            int Codigo,
            string Identificacao,
            string CodigoEspalhamento,
            string Data,
            string Data_Hora,
            string Inspetor,
            string Coletor,
            string Servico,
            string Endereco,
            string Item,
            string Nota,
            int Enviar,
            string CampoBase,
            string Operacao,
            object DadoBase
        )
        {
            bool Retorno = false;

            tblCamposDadosTabelaInspecao = new List<List<object>> { };
            tblCamposDadosTabelaInspecao.Add(lstColunasTabelaInspecaoObject);
            tblCamposDadosTabelaInspecao.Add
            (
                new List<object>
                { 
                    Codigo,
                    Identificacao,
                    CodigoEspalhamento,
                    Data,
                    Data_Hora,
                    Inspetor,
                    Coletor,
                    Servico,
                    Endereco,
                    Item,
                    Nota,
                    Enviar,
                    CampoBase,
                    Operacao, 
                    DadoBase 
                }
            );

            Retorno = objManipulacaoBaseDadosColetor.mtdAlterarDadosTabela(strTabelaInspecao, tblCamposDadosTabelaInspecao);

            return Retorno;
        }

        public bool mtdAlterarDadosTabelaDadosCamposColetor
        (
             int Campos,
             string Dados,
             string CampoBase,
             string Operacao,
             object DadoBase
        )
        {
            bool Retorno = false;

            tblCamposDadosTabelaDadosCamposColetor = new List<List<object>> { };
            tblCamposDadosTabelaDadosCamposColetor.Add(lstColunasTabelaDadosCamposColetorObject);
            tblCamposDadosTabelaDadosCamposColetor.Add
            (
                new List<object>
                { 
                    Campos,
                    Dados,
                    CampoBase,
                    Operacao, 
                    DadoBase 
                }
            );

            Retorno = objManipulacaoBaseDadosColetor.mtdAlterarDadosTabela(strTabelaDadosCamposColetor, tblCamposDadosTabelaDadosCamposColetor);

            return Retorno;
        }

        public bool mtdAlterarDadosTabelaEndereco
        (
             int Campos,
             string Dados,
             string CampoBase,
             string Operacao,
             object DadoBase
        )
        {
            bool Retorno = false;

            tblCamposDadosTabelaEndereco = new List<List<object>> { };
            tblCamposDadosTabelaEndereco.Add(lstColunasTabelaEnderecoObject);
            tblCamposDadosTabelaEndereco.Add
            (
                new List<object>
                { 
                    Campos,
                    Dados,
                    CampoBase,
                    Operacao, 
                    DadoBase 
                }
            );

            Retorno = objManipulacaoBaseDadosColetor.mtdAlterarDadosTabela(strTabelaEndereco, tblCamposDadosTabelaEndereco);

            return Retorno;
        }

        public bool mtdInserirDadosTabelaInspecao
        (
            int Codigo,
            int Identificacao,
            string Data,
            string Data_Hora,
            string Inspetor,
            string Coletor,
            string Servico,
            string Endereco,
            string Item,
            string Nota,
            int Enviar
        )
        {
            bool Retorno = false;

            tblCamposDadosTabelaInspecao = new List<List<object>> { };
            tblCamposDadosTabelaInspecao.Add(lstColunasTabelaInspecaoObject);
            tblCamposDadosTabelaInspecao.Add
            (
                new List<object> 
                {
                    Codigo,
                    Identificacao,
                    mtdCalcularCodigoEspalhamento(new List<object> { Codigo, Identificacao, Data, Data_Hora, Inspetor, Coletor, Servico, Endereco, Item, Nota, Item, Enviar }),
                    Data,
                    Data_Hora,
                    Inspetor,
                    Coletor,
                    Servico,
                    Endereco,
                    Item,
                    Nota,
                    Enviar
                }
            );

            Retorno = objManipulacaoBaseDadosColetor.mtdInserirDadosTabela(strTabelaInspecao, tblCamposDadosTabelaInspecao);

            return Retorno;
        }

        public bool mtdInserirDadosTabelaDadosCamposColetor
        (
            int Campos,
            string Dados
        )
        {
            bool Retorno = false;

            tblCamposDadosTabelaDadosCamposColetor = new List<List<object>> { };
            tblCamposDadosTabelaDadosCamposColetor.Add(lstColunasTabelaDadosCamposColetorObject);
            tblCamposDadosTabelaDadosCamposColetor.Add
            (
                new List<object> 
                {
                    Campos,
                    Dados
                }
            );

            Retorno = objManipulacaoBaseDadosColetor.mtdInserirDadosTabela(strTabelaDadosCamposColetor, tblCamposDadosTabelaDadosCamposColetor);

            return Retorno;
        }

        public bool mtdInserirDadosTabelaEndereco
        (
            string Endereco
        )
        {
            bool Retorno = false;

            tblCamposDadosTabelaEndereco = new List<List<object>> { };
            tblCamposDadosTabelaEndereco.Add(lstColunasTabelaEnderecoObject);
            tblCamposDadosTabelaEndereco.Add
            (
                new List<object> 
                {
                    Endereco
                }
            );

            Retorno = objManipulacaoBaseDadosColetor.mtdInserirDadosTabela(strTabelaEndereco, tblCamposDadosTabelaEndereco);

            return Retorno;
        }

        public bool mtdDeletarDadosTabelaInspecao(string CampoSelecionador, object Dado)
        {
            bool Retorno = false;

            Retorno = objManipulacaoBaseDadosColetor.mtdDeletarDadosTabela(strTabelaInspecao, CampoSelecionador, "LIKE", Dado);

            return Retorno;
        }

        public bool mtdDeletarDadosTabelaInspecao
        (
            string CampoSelecionador1,
            object Dado1,
            string CampoSelecionador2,
            object Dado2
        )
        {
            bool Retorno = false;

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

            objImplementacaoBancoDados.mtdAbrirConexao();
            Retorno = objImplementacaoBancoDados.mtdExecutarComando
            (
                string.Format
                (
                    "DELETE FROM {0} WHERE {1} LIKE {2} AND {3} LIKE {4};",
                    strTabelaInspecao,
                    CampoSelecionador1,
                    Dado1,
                    CampoSelecionador2,
                    Dado2
                )
            );

            objImplementacaoBancoDados.mtdFecharConexao();

            objImplementacaoBancoDados.Dispose();

            return Retorno;
        }

        public bool mtdDeletarDadosTabelaEstatistica(string Tabela, string CampoSelecionador, object Dado)
        {
            bool Retorno = false;

            Retorno = objManipulacaoBaseDadosColetor.mtdDeletarDadosTabela(Tabela, CampoSelecionador, "LIKE", Dado);

            return Retorno;
        }

        public bool mtdDeletarDadosTabelaDadosCamposColetor(string CampoSelecionador, object Dado)
        {
            bool Retorno = false;

            Retorno = objManipulacaoBaseDadosColetor.mtdDeletarDadosTabela(strTabelaDadosCamposColetor, CampoSelecionador, "LIKE", Dado);

            return Retorno;
        }

        public bool mtdDeletarDadosTabelaEndereco(string CampoSelecionador, object Dado)
        {
            bool Retorno = false;

            Retorno = objManipulacaoBaseDadosColetor.mtdDeletarDadosTabela(strTabelaEndereco, CampoSelecionador, "LIKE", Dado);

            return Retorno;
        }

        public System.Data.DataTable mtdSelecionarDadosTabelaInspecao
        (
            uint NumeroLinhas,
            string CampoSelecionador,
            string Operacao,
            object Dado,
            string CampoOrdenador,
            bool Crescente
        )
        {
            return objManipulacaoBaseDadosColetor.mtdSelecionarDadosTabela(NumeroLinhas, lstColunasTabelaInspecao, strTabelaInspecao, CampoSelecionador, Operacao, Dado, CampoSelecionador, Crescente);
        }

        public System.Data.DataTable mtdSelecionarDadosTabelaEndereco()
        {
            return objManipulacaoBaseDadosColetor.mtdSelecionarDadosTabela(0, lstColunasTabelaEndereco, strTabelaEndereco, lstColunasTabelaEndereco[0], "LIKE", "'%'", lstColunasTabelaEndereco[0], true);
        }

        private List<string> mtdSelecionarDados
        (
          string Campos,
          string Tabela,
          string CampoSelecionador,
          string Operacao,
          object Dado,
          string CampoAgrupador,
          string CampoOrdenador,
          bool Crescente
        )
        {
            List<string> Retorno = new List<string> { };

            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados();

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
            (
                clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                frmPrincipal.strBaseDadosColetor,
                frmPrincipal.strSenhaBaseDadosColetor
            );

            objImplementacaoBancoDados.mtdSelecionarDados
            (
                true,
                false,
                Campos,
                Tabela,
                CampoSelecionador,
                Operacao,
                Dado,
                CampoAgrupador,
                CampoOrdenador,
                Crescente
            );

            objImplementacaoBancoDados.mtdDefinirLeitorDados();

            while (objImplementacaoBancoDados.mtdProximoRegistro())
            {
                Retorno.Add(objImplementacaoBancoDados.mtdObterValorRegistroVetor(0).ToString());
            }

            objImplementacaoBancoDados.Dispose();

            return Retorno;
        }

        private System.Data.DataTable mtdSelecionarDados
        (
            List<string> Campos,
            string Tabela,
            string CampoSelecionador,
            object Dado,
            string CampoOrdenador,
            bool Crescente
        )
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
                    "SELECT {0} FROM {1} WHERE {2} LIKE {3} ORDER BY {4}{5}",
                    objImplementacaoBancoDados.mtdListaLinhaCampos(Campos),
                    Tabela,
                    CampoSelecionador,
                    Dado,
                    CampoOrdenador,
                    Crescente ? string.Empty : " DESC"
                )
            );

            objImplementacaoBancoDados.mtdAdaptadorDados();

            Retorno = objImplementacaoBancoDados.prpAjustadorDados.Tables[0];

            objImplementacaoBancoDados.Dispose();

            return Retorno;
        }

        private System.Data.DataTable mtdSelecionarDados
        (
           List<string> Campos,
           string Tabela,
           string CampoSelecionador1,
           object Dado1,
           string CampoSelecionador2,
           object Dado2,
           string CampoOrdenador,
           bool Crescente
        )
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
                    "SELECT {0} FROM {1} WHERE {2} LIKE {3} AND {4} LIKE {5} ORDER BY {6}{7}",
                    objImplementacaoBancoDados.mtdListaLinhaCampos(Campos),
                    Tabela,
                    CampoSelecionador1,
                    Dado1,
                    CampoSelecionador2,
                    Dado2,
                    CampoOrdenador,
                    Crescente ? string.Empty : " DESC"
                )
            );

            objImplementacaoBancoDados.mtdAdaptadorDados();

            try
            {
                Retorno = objImplementacaoBancoDados.prpAjustadorDados.Tables[0];
            }
            catch (System.Exception ex)
            {

            }

            objImplementacaoBancoDados.Dispose();

            return Retorno;
        }

        private System.Data.DataTable mtdSelecionarDados
        (
            List<string> Campos,
            string Tabela,
            string CampoSelecionador1,
            object Dado1,
            string CampoSelecionador2,
            object Dado2,
            string CampoSelecionador3,
            object Dado3,
            string CampoOrdenador,
            bool Crescente
        )
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
                    "SELECT {0} FROM {1} WHERE {2} LIKE {3} AND {4} LIKE {5} AND {6} LIKE {7} ORDER BY {8}{9}",
                    objImplementacaoBancoDados.mtdListaLinhaCampos(Campos),
                    Tabela,
                    CampoSelecionador1,
                    Dado1,
                    CampoSelecionador2,
                    Dado2,
                    CampoSelecionador3,
                    Dado3,
                    CampoOrdenador,
                    Crescente ? string.Empty : " DESC"
                )
            );

            objImplementacaoBancoDados.mtdAdaptadorDados();

            try
            {
                Retorno = objImplementacaoBancoDados.prpAjustadorDados.Tables[0];
            }
            catch (System.Exception ex)
            {

            }

            objImplementacaoBancoDados.Dispose();

            return Retorno;
        }

        public System.Data.DataTable mtdSelecionarDadosTabelaDadosCamposColetor
        (
            uint NumeroLinhas,
            string CampoSelecionador,
            string Operacao,
            object Dado,
            string CampoOrdenador,
            bool Crescente
        )
        {
            return objManipulacaoBaseDadosColetor.mtdSelecionarDadosTabela(NumeroLinhas, lstColunasTabelaDadosCamposColetor, strTabelaDadosCamposColetor, CampoSelecionador, Operacao, Dado, CampoSelecionador, Crescente);
        }
    }
}