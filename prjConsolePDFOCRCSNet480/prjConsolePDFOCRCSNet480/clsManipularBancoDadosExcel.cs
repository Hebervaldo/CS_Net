using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjConsolePDFOCRCSNet480
{
    internal class clsManipularBancoDadosExcel
    {
        private clsConexaoBancoDados.TipoConexao TipoConexaoExcel = clsConexaoBancoDados.TipoConexao.ConexaoExcel2003OleDb;
        private string strBaseDadosExcel = string.Empty;
        private string strNomeBancoDadosExcel = @"dbPrimeiroBancoDadosExcel";
        private string strEnderecoBancoDadosExcel = @"C:\Users\Usuario\Desktop\";
        private string strTabelaExcel = @"tblTabelaExcel";
        private string strVersaoExcel = String.Empty;

        private clsImplementacaoBancoDados objImplementacaoBancoDadosOleDb = new clsBDOleDb();

        private List<List<object>> dados = new List<List<object>> { };
        private List<List<string>> campos = new List<List<string>> { };

        private int numColunas = 0;

        private List<List<string>> mtdCriarTabelaExcel()
        {
            List<List<string>> campos = new List<List<string>> { };

            campos.Add
            (
                new List<string>
                {
                    "id", "INTEGER", string.Empty, string.Format("CONSTRAINT primarykey{0} PRIMARY KEY", "id")
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
                    "pagina", "INTEGER", string.Empty, string.Empty
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

        public void mtdCriarBancoDadosTabela(string BancoDados, string Tabela)
        {
            strNomeBancoDadosExcel = BancoDados;
            strTabelaExcel = Tabela;

            strVersaoExcel = (TipoConexaoExcel == clsConexaoBancoDados.TipoConexao.ConexaoExcel2003OleDb ? ".xls" : ".xlsx");
            strBaseDadosExcel = strEnderecoBancoDadosExcel + strNomeBancoDadosExcel + strVersaoExcel;

            objImplementacaoBancoDadosOleDb.mtdDefinirStringConexaoExcel(TipoConexaoExcel, strBaseDadosExcel);
            objImplementacaoBancoDadosOleDb.mtdDeletarBancoDadosExcel();

            campos = mtdCriarTabelaExcel();
            numColunas = campos.Count;
            dados.Add(new List<object>());

            for (int contador = 0; contador <= numColunas - 1; contador++)
            {
                dados[0].Add(campos[contador][0]);
            }

            objImplementacaoBancoDadosOleDb.mtdAbrirInserirPlanilhaExcel_Otimizado(strTabelaExcel);
            objImplementacaoBancoDadosOleDb.mtdCabecalhoInserirPlanilhaExcel_Otimizado(dados);
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

        public void mtdInserirDados()
        {
            objImplementacaoBancoDadosOleDb.mtdDadosInserirPlanilhaExcel_Otimizado(dados, false);

            objImplementacaoBancoDadosOleDb.mtdInserirDadosPlanilhaExcel(strTabelaExcel, dados);

            objImplementacaoBancoDadosOleDb.mtdDefinirStringConexaoExcel(TipoConexaoExcel, strBaseDadosExcel);
            // objImplementacaoBancoDadosOleDb.mtdSelecionarDados("*", strTabelaExcel);
            // objImplementacaoBancoDadosOleDb.mtdAdaptadorDados(strTabelaExcel);

            objImplementacaoBancoDadosOleDb.mtdFecharInserirPlanilhaExcel_Otimizado();
        }
    }
}
