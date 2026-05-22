using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjObterDadosMBPPdfMBPI
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
                    "numeroMBPI", "INTEGER", string.Empty, string.Empty
                }
            );
            campos.Add
            (
                new List<string>
                {
                    "patrimonio", "TEXT", "(255)", string.Empty
                }
            );
            campos.Add
            (
                new List<string>
                {
                    "nome", "TEXT", "(255)", string.Empty
                }
            );
            campos.Add
            (
                new List<string>
                {
                    "matricula", "TEXT", "(255)", string.Empty
                }
            );
            campos.Add
            (
                new List<string>
                {
                    "orgao", "TEXT", "(255)", string.Empty
                }
            );
            campos.Add
            (
                new List<string>
                {
                    "local", "TEXT", "(255)", string.Empty
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

        public void mtdPopularDados(string NumeroMBPI, string Patrimonio, string Nome, string Matricula, string Orgao, string Local)
        {
            dados.Add(new List<object>());
            dados[dados.Count - 1] = new List<object>();
            dados[dados.Count - 1].Add(NumeroMBPI);
            dados[dados.Count - 1].Add(Patrimonio);
            dados[dados.Count - 1].Add(Nome);
            dados[dados.Count - 1].Add(Matricula);
            dados[dados.Count - 1].Add(Orgao);
            dados[dados.Count - 1].Add(Local);
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
