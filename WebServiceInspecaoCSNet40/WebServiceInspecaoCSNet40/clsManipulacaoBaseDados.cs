using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace WebServiceInspecaoCSNet40
{
    public class clsManipulacaoBaseDados
    {
        public static string strConexao = string.Empty;

        public static string strTabela = string.Empty;

        public int intContadorCampos = 0;
        public int intColunaIndice = 1;

        public List<List<string>> lstCamposTabela = new List<List<string>> { };
        public List<List<string>> lstCamposTabelaIndice = new List<List<string>> { };
        public List<List<string>> lstCamposDadosTabela = new List<List<string>> { };

        public clsManipulacaoBaseDados()
            : this(string.Empty, string.Empty)
        {
        }

        public clsManipulacaoBaseDados(string Conexao, string NomeTabela)
        {
            mtdResetarCamposTabela();

            strConexao = Conexao;
            strTabela = NomeTabela;
        }

        public bool mtdCriarBancoDados()
        {
            return mtdCriarBancoDados(strConexao);
        }

        public bool mtdCriarBancoDados(string Conexao)
        {
            strConexao = Conexao;

            bool Retorno = false;

            try
            {
                clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, clsInfraestruturaBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.MySQL);
                objImplementacaoBancoDados.mtdValidarConexaoMySQL(strConexao);

                Retorno = objImplementacaoBancoDados.mtdCriarBancoDadosMySQL();

                objImplementacaoBancoDados.Dispose();
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdCriarBancoDados: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }

            return Retorno;
        }

        public bool mtdCriarTabela(string NomeTabela, List<List<string>> CamposTabela)
        {
            return mtdCriarTabela(strConexao, NomeTabela, CamposTabela);
        }

        public bool mtdCriarTabela(string Conexao, string NomeTabela, List<List<string>> CamposTabela)
        {
            bool Retorno = false;

            strConexao = Conexao;

            strTabela = NomeTabela;
            lstCamposTabela = CamposTabela;

            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, clsInfraestruturaBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.MySQL);

            Retorno = objImplementacaoBancoDados.mtdCriarTabela
                  (
                      NomeTabela,
                      CamposTabela
                  );

            objImplementacaoBancoDados.Dispose();

            return Retorno;
        }

        public bool mtdDeletarTabela(string NomeTabela)
        {
            return mtdDeletarTabela(strConexao, NomeTabela);
        }

        public bool mtdDeletarTabela(string Conexao, string NomeTabela)
        {
            bool Retorno = false;

            strConexao = Conexao;

            strTabela = NomeTabela;

            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, clsInfraestruturaBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.MySQL);

            Retorno = objImplementacaoBancoDados.mtdDeletarTabela
            (
                NomeTabela
            );

            objImplementacaoBancoDados.Dispose();

            return Retorno;
        }

        public bool mtdDeletarBancoDados(string Conexao)
        {
            bool Retorno = false;

            strConexao = Conexao;

            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, clsInfraestruturaBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.MySQL);

            Retorno = objImplementacaoBancoDados.mtdDeletarBancoDadosMySQL(strConexao);

            objImplementacaoBancoDados.Dispose();

            return Retorno;
        }

        public List<List<string>> mtdIncluirIndicesListaColuna(string Coluna)
        {
            intContadorCampos = System.Convert.ToInt32(lstCamposTabelaIndice[lstCamposTabelaIndice.Count - 1][intColunaIndice]);
            lstCamposTabelaIndice.Add(new List<string> { Coluna, System.Convert.ToString(intContadorCampos++) });

            return lstCamposTabelaIndice;
        }

        public List<List<string>> mtdIncluirIndicesListaColuna(List<object> ListaColuna)
        {
            mtdResetarCamposTabela();

            foreach (object item in ListaColuna)
            {
                lstCamposTabelaIndice.Add(new List<string> { item.ToString(), System.Convert.ToString(intContadorCampos++) });
            }

            return lstCamposTabelaIndice;
        }

        public bool mtdAlterarDadosTabela(List<List<object>> Campos_Dados_CampoBase_Operacao_DadoBase)
        {
            return mtdAlterarDadosTabela(strTabela, Campos_Dados_CampoBase_Operacao_DadoBase);
        }

        public bool mtdAlterarDadosTabela(string Tabela, List<List<object>> Campos_Dados_CampoBase_Operacao_DadoBase)
        {
            bool Retorno = false;

            strTabela = Tabela;

            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, clsInfraestruturaBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.MySQL);

            Retorno = objImplementacaoBancoDados.mtdAtualizarDadosParametroComandoMySQL(strTabela, Campos_Dados_CampoBase_Operacao_DadoBase, enmModoParametroComando.Valor);

            objImplementacaoBancoDados.Dispose();

            return Retorno;
        }

        public bool mtdInserirDadosTabela(List<List<object>> Campos_Dados)
        {
            return mtdInserirDadosTabela(strTabela, Campos_Dados);
        }

        public bool mtdInserirDadosTabela(string Tabela, List<List<object>> Campos_Dados)
        {
            bool Retorno = false;

            strTabela = Tabela;

            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, clsInfraestruturaBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.MySQL);

            Retorno = objImplementacaoBancoDados.mtdInserirDadosParametroComandoMySQL(strTabela, Campos_Dados, enmModoParametroComando.Valor);

            objImplementacaoBancoDados.Dispose();

            return Retorno;
        }

        public bool mtdDeletarDadosTabela(string Tabela, string CampoSelecionador, string Operacao, object Dado)
        {
            bool Retorno = false;

            strTabela = Tabela;

            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, clsInfraestruturaBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.MySQL);

            Retorno = objImplementacaoBancoDados.mtdDeletarDadosParametroComandoMySQL(strTabela, CampoSelecionador, Operacao, Dado);

            objImplementacaoBancoDados.Dispose();

            return Retorno;
        }

        public System.Data.DataTable mtdSelecionarDadosTabela(uint NumeroLinhas, string Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado, string CampoOrdenador, bool Crescente)
        {
            return mtdSelecionarDadosTabela(strTabela, NumeroLinhas, Campos, NomeTabela, CampoSelecionador, Operacao, Dado, CampoOrdenador, Crescente);
        }

        public System.Data.DataTable mtdSelecionarDadosTabela(uint NumeroLinhas, List<string> Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado, string CampoOrdenador, bool Crescente)
        {
            return mtdSelecionarDadosTabela(strTabela, NumeroLinhas, Campos, NomeTabela, CampoSelecionador, Operacao, Dado, CampoOrdenador, Crescente);
        }

        public System.Data.DataTable mtdSelecionarDadosTabela(string Tabela, uint NumeroLinhas, string Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado, string CampoOrdenador, bool Crescente)
        {
            System.Data.DataTable Retorno = new System.Data.DataTable();

            strTabela = Tabela;

            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, clsInfraestruturaBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.MySQL);

            objImplementacaoBancoDados.mtdSelecionarDados(NumeroLinhas, Campos, NomeTabela, CampoSelecionador, Operacao, Dado, CampoOrdenador, Crescente);
            objImplementacaoBancoDados.mtdAdaptadorDados();

            Retorno = objImplementacaoBancoDados.prpTabelaDados;

            objImplementacaoBancoDados.Dispose();

            return Retorno;
        }

        public System.Data.DataTable mtdSelecionarDadosTabela(string Tabela, uint NumeroLinhas, List<string> Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado, string CampoOrdenador, bool Crescente)
        {
            System.Data.DataTable Retorno = new System.Data.DataTable();

            strTabela = Tabela;

            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, clsInfraestruturaBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.MySQL);

            objImplementacaoBancoDados.mtdSelecionarDados(NumeroLinhas, Campos, NomeTabela, CampoSelecionador, Operacao, Dado, CampoOrdenador, Crescente);
            objImplementacaoBancoDados.mtdAdaptadorDados();

            Retorno = objImplementacaoBancoDados.prpTabelaDados;

            objImplementacaoBancoDados.Dispose();

            return Retorno;
        }

        public void mtdResetarCamposTabela()
        {
            intContadorCampos = 0;
            lstCamposTabela = new List<List<string>> { };
            lstCamposTabelaIndice = new List<List<string>> { };
        }
    }
}