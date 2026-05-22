using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjConsolePDFOCRCSNet480
{
    internal class clsManipularBancoDadosAccess
    {
        private clsConexaoBancoDados.TipoConexao TipoConexaoAccess = clsConexaoBancoDados.TipoConexao.ConexaoAccess2003OleDb;
        private string strBaseDadosAccess = string.Empty;
        private string strNomeBancoDadosAccess = @"dbPrimeiroBancoDadosAccess";
        private string strEnderecoBancoDadosAccess = @"C:\Users\Usuario\Desktop\";
        private string strTabelaAccess = @"tblTabelaAccess";
        private string strVersaoAccess = String.Empty;

        private clsImplementacaoBancoDados objImplementacaoBancoDadosOleDb = new clsBDOleDb();

        private List<List<object>> dados = new List<List<object>> { };
        private List<List<string>> campos = new List<List<string>> { };

        private int numColunas = 0;

        private List<List<string>> mtdCriarTabelaAccess()
        {
            List<List<string>> campos = new List<List<string>> { };

            campos.Add
            (
                new List<string>
                {
                    "id", "LONG", string.Empty, string.Format("CONSTRAINT primarykey{0} PRIMARY KEY", "id")
                }
            );
            campos.Add
            (
                new List<string>
                {
                    "descricao", "TEXT", "255", string.Empty
                }
            );
            campos.Add
            (
                new List<string>
                {
                    "pagina", "LONG", string.Empty, string.Empty
                }
            );
            campos.Add
            (
                new List<string>
                {
                    "documento", "TEXT", "255", string.Empty
                }
            );
            campos.Add
            (
                new List<string>
                {
                    "texto_ocr", "LONGTEXT", string.Empty, string.Empty
                }
            );
            campos.Add
            (
                new List<string>
                {
                    "indice", "TEXT", "255", string.Empty
                }
            );

            return campos;
        }

        public bool mtdCriarBancoDadosTabela(string BancoDados, string Tabela)
        {
            bool Retorno = true;

            strNomeBancoDadosAccess = BancoDados;
            strTabelaAccess = Tabela;

            strVersaoAccess = (TipoConexaoAccess == clsConexaoBancoDados.TipoConexao.ConexaoAccess2003OleDb ? ".mdb" : ".accdb");
            strBaseDadosAccess = strEnderecoBancoDadosAccess + strNomeBancoDadosAccess + strVersaoAccess;

            objImplementacaoBancoDadosOleDb = new clsBDOleDb();

            objImplementacaoBancoDadosOleDb.mtdDefinirStringConexaoAccess(TipoConexaoAccess, strBaseDadosAccess);
            objImplementacaoBancoDadosOleDb.mtdDeletarBancoDadosAccess();
            Retorno &= objImplementacaoBancoDadosOleDb.mtdCriarBancoDadosAccess();

            mtdAjustarCabecalhoDados();

            Retorno &= objImplementacaoBancoDadosOleDb.mtdCriarTabela(strTabelaAccess, campos);

            return Retorno;
        }

        public bool mtdAbrirConexaoBancoDados()
        {
            strVersaoAccess = (TipoConexaoAccess == clsConexaoBancoDados.TipoConexao.ConexaoAccess2003OleDb ? ".mdb" : ".accdb");
            strBaseDadosAccess = strEnderecoBancoDadosAccess + strNomeBancoDadosAccess + strVersaoAccess;

            objImplementacaoBancoDadosOleDb = new clsBDOleDb();

            objImplementacaoBancoDadosOleDb.mtdDefinirStringConexaoAccess(TipoConexaoAccess, strBaseDadosAccess);
            return objImplementacaoBancoDadosOleDb.mtdAbrirConexao();
        }

        public void mtdAjustarCabecalhoDados()
        {
            campos = mtdCriarTabelaAccess();
            numColunas = campos.Count;
            dados.Add(new List<object>());

            for (int contador = 0; contador <= numColunas - 1; contador++)
            {
                dados[0].Add(campos[contador][0]);
            }
        }


        public void mtdPopularDados(ulong Id, string Descricao, ulong Pagina, string Documento, string Texto_Ocr, string Indice)
        {
            dados.Add(new List<object>());
            dados[dados.Count - 1] = new List<object>();
            dados[dados.Count - 1].Add(Id);
            dados[dados.Count - 1].Add(Descricao);
            dados[dados.Count - 1].Add(Pagina);
            dados[dados.Count - 1].Add(Documento);
            dados[dados.Count - 1].Add(Texto_Ocr);
            dados[dados.Count - 1].Add(Indice);
        }

        public bool mtdInserirDados()
        {
            return objImplementacaoBancoDadosOleDb.mtdInserirDados(strTabelaAccess, dados);
        }

        public void mtdResetarDados()
        {
            dados = new List<List<object>> { };
            mtdAjustarCabecalhoDados();
        }

        public bool mtdFecharConexaoBancoDados()
        {
            return objImplementacaoBancoDadosOleDb.mtdFecharConexao();
        }
    }
}
