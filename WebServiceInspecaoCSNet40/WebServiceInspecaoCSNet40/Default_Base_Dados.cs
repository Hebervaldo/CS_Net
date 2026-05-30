using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

namespace WebServiceInspecaoCSNet40
{
    public partial class _Default
    {
        public static readonly string DiretorioArmazenamento = "Armazenamento";
        public static string DiretorioArmazenamentoCompleto = string.Empty;

        public static string cntExtensaoBancoDadosColetor = ".sdf";

        //public static clsEnderecoAplicativo objEnderecoAplicativo = new clsEnderecoAplicativo();

        //public static string strEnderecoBancoDadosColetor = System.IO.Path.GetDirectoryName
        //(
        //    System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase
        //);

        // Excel

        public static string cntBaseDadosExcel = string.Empty;
        public static string cntNomeBancoDadosExcel = "dbInspecao.xls";
        public static string cntEnderecoBancoDadosExcel = string.Empty;
        public static string cntPlanilhaExcel = "ExportacaoExcel";

        public static string strBaseDadosExcel = string.Empty;
        public static string strNomeBancoDadosExcel = string.Empty;
        public static string strEnderecoBancoDadosExcel = string.Empty;
        public static string strPlanilhaExcel = string.Empty;

        // MySQL
        public static string strConexaoMySQL = string.Empty;
        public static string strConexaoMySQL_SemBD = string.Empty;

        public static string strServidorMySQL = @"localhost";
        public static string strPortaMySQL = @"3307";
        public static string strNomeBancoDadosMySQL = @"dbInspecao";
        public static string strUsuarioMySQL = @"root";
        public static string strSenhaMySQL = @"12345678";

        public static string strTabelaInspecao = "tblInspecao";
        public static string strTabelaEstatistica_01 = "tblEstatistica_01";
        public static string strTabelaEstatistica_02 = "tblEstatistica_02";
        public static string strTabelaEndereco = "tblEndereco";

        public static clsManipulacaoBaseDados objManipulacaoBaseDadosWebService = new clsManipulacaoBaseDados(strConexaoMySQL, strTabelaInspecao);

        public static List<string> lstColunasTabelaInspecao = new List<string> { };
        public static List<object> lstColunasTabelaInspecaoObject = new List<object> { };
        public static List<List<string>> tblCamposTabelaInspecao = new List<List<string>> { };
        public static List<List<object>> tblCamposDadosTabelaInspecao = new List<List<object>> { };

        //public static List<string> lstColunasTabelaEstatistica = new List<string> { };
        public static List<object> lstColunasTabelaEstatisticaObject = new List<object> { };
        public static List<List<string>> tblCamposTabelaEstatistica = new List<List<string>> { };
        public static List<List<object>> tblCamposDadosTabelaEstatistica = new List<List<object>> { };

        public static List<string> lstColunasTabelaEndereco = new List<string> { };
        public static List<object> lstColunasTabelaEnderecoObject = new List<object> { };
        public static List<List<string>> tblCamposTabelaEndereco = new List<List<string>> { };
        public static List<List<object>> tblCamposDadosTabelaEndereco = new List<List<object>> { };

        public void mtdDefinirStringConexaoExcel()
        {
            cntEnderecoBancoDadosExcel = DiretorioArmazenamentoCompleto;
            strEnderecoBancoDadosExcel = cntEnderecoBancoDadosExcel;

            strBaseDadosExcel = string.Format(@"{0}\{1}", strEnderecoBancoDadosExcel, cntNomeBancoDadosExcel).Replace(@"\\", @"\");
        }

        public string mtdDefinirStringConexaoMySQL()
        {
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados();

            strConexaoMySQL_SemBD = objImplementacaoBancoDados.mtdDefinirStringConexaoMySQL(clsConexaoBancoDados.TipoConexao.ConexaoMySQLNativa, strServidorMySQL, strPortaMySQL, strUsuarioMySQL, strSenhaMySQL);
            strConexaoMySQL = objImplementacaoBancoDados.mtdDefinirStringConexaoMySQL(clsConexaoBancoDados.TipoConexao.ConexaoMySQLNativa, strServidorMySQL, strPortaMySQL, strNomeBancoDadosMySQL, strUsuarioMySQL, strSenhaMySQL);
            // strConexaoMySQL = string.Format("Server={0}; Port={1}; Database={2}; Uid={3}; Pwd={4}; Encrypt=False; Connection Timeout=5; Pooling=False;", strServidorMySQL, strPortaMySQL, strNomeBancoDadosMySQL, strUsuarioMySQL, strSenhaMySQL);
            objImplementacaoBancoDados.Dispose();

            return strConexaoMySQL;
        }

        public void mtdBaseDados_Load()
        {
            mtdDefinirStringConexaoExcel();
            mtdDefinirStringConexaoMySQL();
            mtdGerarListaColunasTabelaInspecao();
            mtdGerarListaColunasTabelaEndereco();
            mtdCriarBaseDadosWebService();
            mtdCriarTabelaInspecao();
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

            lstColunasTabelaInspecaoObject.Clear();
            lstColunasTabelaInspecaoObject = new List<object>() { };

            foreach (string item in _Default.lstColunasTabelaInspecao)
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

        public void mtdGerarListaColunasTabelaEndereco()
        {
            lstColunasTabelaEndereco = new List<string> { };
            lstColunasTabelaEndereco.Add("Endereco");

            lstColunasTabelaEnderecoObject.Clear();
            lstColunasTabelaEnderecoObject = new List<object>() { };

            foreach (string item in lstColunasTabelaEndereco)
            {
                lstColunasTabelaEnderecoObject.Add(item.ToString());
            }
        }

        public bool mtdCriarBaseDadosWebService()
        {
            bool Retorno = false;

            Retorno = objManipulacaoBaseDadosWebService.mtdCriarBancoDados(strConexaoMySQL_SemBD, strNomeBancoDadosMySQL);

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
                                string.Empty
                                //string.Format
                                //(
                                //    "NOT NULL PRIMARY KEY", 
                                //    lstColunasTabelaInspecao[contador]
                                //)
                            }
                        );
                        break;
                    case 2:
                        tblCamposTabelaInspecao.Add
                        (
                            new List<string>
                            {
                                lstColunasTabelaInspecao[contador],
                                "VARCHAR",
                                "255",
                                string.Format
                                (
                                    "NOT NULL PRIMARY KEY", 
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
                                "DOUBLE",
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
                                "VARCHAR",
                                "255",
                                string.Empty 
                            }
                        );
                        break;
                }
            }

            objManipulacaoBaseDadosWebService.mtdIncluirIndicesListaColuna(lstColunasTabelaInspecaoObject);
            Retorno = objManipulacaoBaseDadosWebService.mtdCriarTabela(strConexaoMySQL, strTabelaInspecao, tblCamposTabelaInspecao);

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
                        ListaTiposColunas[contador] == "NVARCHAR" ? "255": string.Empty,
                        string.Empty
                    }
                );
            }

            objManipulacaoBaseDadosWebService.mtdIncluirIndicesListaColuna(lstColunasTabelaEstatisticaObject);
            Retorno = objManipulacaoBaseDadosWebService.mtdCriarTabela(Tabela, tblCamposTabelaEstatistica);

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
                                    "NOT NULL PRIMARY KEY", 
                                    lstColunasTabelaEndereco[contador]
                                )
                            }
                        );
                        break;
                }
            }

            Retorno = objManipulacaoBaseDadosWebService.mtdCriarTabela(strTabelaEndereco, tblCamposTabelaEndereco);

            return Retorno;
        }

        public bool mtdDeletarTabelaEstatistica(string Tabela)
        {
            bool Retorno = false;

            Retorno = objManipulacaoBaseDadosWebService.mtdCriarTabela(Tabela, tblCamposTabelaEstatistica);

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

            Retorno = objManipulacaoBaseDadosWebService.mtdAlterarDadosTabela(strTabelaInspecao, tblCamposDadosTabelaInspecao);

            return Retorno;
        }

        public bool mtdAlterarDadosTabelaEndereco
        (
             string Endereco,
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
                    Endereco,
                    CampoBase,
                    Operacao, 
                    DadoBase 
                }
            );

            Retorno = objManipulacaoBaseDadosWebService.mtdAlterarDadosTabela(strTabelaEndereco, tblCamposDadosTabelaEndereco);

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
                    mtdCalcularCodigoEspalhamento(new List<object> { Codigo, Identificacao, Data, Data_Hora, Inspetor, Coletor, Servico, Endereco, Item, Nota, Enviar }),
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

            Retorno = objManipulacaoBaseDadosWebService.mtdInserirDadosTabela(strTabelaInspecao, tblCamposDadosTabelaInspecao);

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

            Retorno = objManipulacaoBaseDadosWebService.mtdInserirDadosTabela(strTabelaEndereco, tblCamposDadosTabelaEndereco);

            return Retorno;
        }

        public bool mtdDeletarDadosTabelaInspecao(string CampoSelecionador, object Dado)
        {
            bool Retorno = false;

            Retorno = objManipulacaoBaseDadosWebService.mtdDeletarDadosTabela(strTabelaInspecao, CampoSelecionador, "LIKE", Dado);

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

            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexaoMySQL, clsInfraestruturaBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.MySQL);

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

            Retorno = objManipulacaoBaseDadosWebService.mtdDeletarDadosTabela(Tabela, CampoSelecionador, "LIKE", Dado);

            return Retorno;
        }

        public bool mtdDeletarDadosTabelaEndereco(string CampoSelecionador, object Dado)
        {
            bool Retorno = false;

            Retorno = objManipulacaoBaseDadosWebService.mtdDeletarDadosTabela(strTabelaEndereco, CampoSelecionador, "LIKE", Dado);

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
            return objManipulacaoBaseDadosWebService.mtdSelecionarDadosTabela(NumeroLinhas, lstColunasTabelaInspecao, strTabelaInspecao, CampoSelecionador, Operacao, Dado, CampoSelecionador, Crescente);
        }

        public System.Data.DataTable mtdSelecionarDadosTabelaEndereco()
        {
            return objManipulacaoBaseDadosWebService.mtdSelecionarDadosTabela(0, lstColunasTabelaEndereco, strTabelaEndereco, lstColunasTabelaEndereco[0], "LIKE", "'%'", lstColunasTabelaEndereco[0], true);
        }

        public System.Data.DataTable mtdSelecionarDadosTabelaEstatistica(string Tabela, string Coluna, string Dados)
        {
            return objManipulacaoBaseDadosWebService.mtdSelecionarDadosTabela(0, "*", Tabela, Coluna, "LIKE", Dados, Coluna, true);
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

            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexaoMySQL, clsInfraestruturaBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.MySQL);

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

            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexaoMySQL, clsInfraestruturaBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.MySQL);

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

            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexaoMySQL, clsInfraestruturaBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.MySQL);

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
            string CampoSelecionador3,
            object Dado3,
            string CampoOrdenador,
            bool Crescente
        )
        {
            System.Data.DataTable Retorno = new System.Data.DataTable { };

            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexaoMySQL, clsInfraestruturaBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.MySQL);

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
    }
}