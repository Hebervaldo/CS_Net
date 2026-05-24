using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebServiceInspecaoCSNet40
{
    /// <summary>
    /// Summary description for WebServiceInspecao
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceInspecao : System.Web.Services.WebService
    {
        public WebServiceInspecao()
        {
            new _Default();
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        public List<List<object>> mtdConverterTabelaDadosListaDados(System.Data.DataTable Dt)
        {
            List<List<object>> Dados = new List<List<object>> { };

            Dados.Add(new List<object> { });
            for (int coluna = 0; coluna <= Dt.Columns.Count - 1; coluna++)
            {
                Dados[0].Add(Dt.Columns[coluna].ColumnName);
            }

            for (int linha = 0; linha <= Dt.Rows.Count - 1; linha++)
            {
                Dados.Add(new List<object> { });

                for (int coluna = 0; coluna <= Dt.Columns.Count - 1; coluna++)
                {
                    Dados[linha + 1].Add(Dt.Rows[linha].ItemArray[coluna]);
                }
            }

            return Dados;
        }

        public System.Data.DataSet mtdObterDadosTabelaInspecao_()
        {
            _Default objDefault = new _Default();

            System.Data.DataSet ds = new System.Data.DataSet() { };

            ds.Tables.Add(objDefault.mtdSelecionarDadosTabelaInspecao(0, _Default.lstColunasTabelaInspecao[(int)_Default.enmColunasTabelaInspecao.HashCode], "LIKE", "'%'", _Default.lstColunasTabelaInspecao[(int)_Default.enmColunasTabelaInspecao.Endereco], true));

            return ds;
        }

        [WebMethod]
        public System.Data.DataSet mtdObterDadosTabelaInspecao()
        {
            return mtdObterDadosTabelaInspecao_();
        }

        public System.Data.DataSet mtdObterDadosTabelaEstatistica_(string Tabela, string Coluna, string Dados)
        {
            _Default objDefault = new _Default();

            System.Data.DataSet ds = new System.Data.DataSet() { };

            ds.Tables.Add(objDefault.mtdSelecionarDadosTabelaEstatistica(Tabela, Coluna, Dados));

            return ds;
        }

        public System.Data.DataSet mtdObterDadosTabelaEstatistica_01_()
        {
            return mtdObterDadosTabelaEstatistica_(_Default.strTabelaEstatistica_01, _Default.lstColunasTabelaEstatisticaObject[0].ToString(), "'%'");
        }

        public System.Data.DataSet mtdObterDadosTabelaEstatistica_02_()
        {
            return mtdObterDadosTabelaEstatistica_(_Default.strTabelaEstatistica_02, _Default.lstColunasTabelaEstatisticaObject[0].ToString(), "'%'");
        }

        [WebMethod]
        public System.Data.DataSet mtdObterDadosTabelaEstatistica_01()
        {
            return mtdObterDadosTabelaEstatistica_01_();
        }

        [WebMethod]
        public System.Data.DataSet mtdObterDadosTabelaEstatistica_02()
        {
            return mtdObterDadosTabelaEstatistica_02_();
        }

        [WebMethod]
        public bool mtdInserirDadosTabelaInspecao(System.Data.DataSet Ds)
        {
            bool Retorno = true;
            bool blnAuxiliar = false;
            bool blnRetornoInserir = true;
            bool blnRetornoAlterar = true;

            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados();

            // clsManipulacaoBaseDados objManipulacaoBaseDados = new clsManipulacaoBaseDados(_Default.strConexaoMySQL, _Default.strTabelaInspecao);

            _Default.strConexaoMySQL = objImplementacaoBancoDados.mtdDefinirStringConexaoMySQL(clsConexaoBancoDados.TipoConexao.ConexaoMySQLNativa, _Default.strServidorMySQL, _Default.strPortaMySQL, _Default.strNomeBancoDadosMySQL, _Default.strUsuarioMySQL, _Default.strSenhaMySQL);
            List<List<object>> Dados = mtdConverterTabelaDadosListaDados(Ds.Tables[0]);
            List<List<object>> Dados_ = new List<List<object>> { };

            Dados_.Add(Dados[0]);
            Dados_.Add(Dados[1]);

            for (int linha = 1; linha <= Dados.Count - 1; linha++)
            {
                Dados_[1] = Dados[linha];

                blnAuxiliar = objImplementacaoBancoDados.mtdInserirDadosParametroComandoMySQL(_Default.strTabelaInspecao, Dados_, enmModoParametroComando.Valor);
                blnRetornoInserir &= blnAuxiliar;

                if (!blnAuxiliar)
                {
                    Dados_[1].Add(Dados_[0][(int)_Default.enmColunasTabelaInspecao.HashCode]);
                    Dados_[1].Add("LIKE");
                    Dados_[1].Add(Dados_[1][(int)_Default.enmColunasTabelaInspecao.HashCode]);

                    blnRetornoAlterar &= objImplementacaoBancoDados.mtdAtualizarDadosParametroComandoMySQL(_Default.strTabelaInspecao, Dados_, enmModoParametroComando.Valor);
                }
            }

            objImplementacaoBancoDados.Dispose();

            Retorno = blnRetornoInserir || blnRetornoAlterar;

            return Retorno;
        }

        [WebMethod]
        public System.Data.DataSet mtdObterDadosTabelaEndereco()
        {
            _Default objDefault = new _Default();

            System.Data.DataSet ds = new System.Data.DataSet() { };

            ds.Tables.Add(objDefault.mtdSelecionarDadosTabelaEndereco());

            return ds;
        }

        [WebMethod]
        public System.DateTime mtdObterDataTempoSistemaAtual()
        {
            // lock (LockObterDataTempoSistemaAtual)
            {
                // System.Threading.Thread.Sleep(1);

                return System.DateTime.Now;
            }
        }

        // private static object LockObterDataTempoSistemaUtc = new object();

        [WebMethod]
        public System.DateTime mtdObterDataTempoSistemaUtc()
        {
            // lock (LockObterDataTempoSistemaUtc)
            {
                // System.Threading.Thread.Sleep(1);

                return System.DateTime.UtcNow;
            }
        }

        private bool isDisposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    // Code to dispose managed resources
                    // held by the class
                    System.GC.Collect(0);
                }
            }
            // Code to dispose unmanaged resources
            // held by the class
            isDisposed = true;
            //base.Dispose(disposing);
        }

        ~WebServiceInspecao()
        {
            Dispose(true);
        }
    }
}
