using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace prjInspecaoCSNet40
{
    public class clsManipulacaoBaseDados
    {
        public static string strBaseDados = string.Empty;
        public static string strSenhaBaseDados = string.Empty;
        public static string strTabela = string.Empty;

        public int intContadorCampos = 0;
        public int intColunaIndice = 1;

        public List<List<string>> lstCamposTabela = new List<List<string>> { };
        public List<List<string>> lstCamposTabelaIndice = new List<List<string>> { };
        public List<List<string>> lstCamposDadosTabela = new List<List<string>> { };

        public clsManipulacaoBaseDados()
            : this(string.Empty, string.Empty, string.Empty)
        {
        }

        public clsManipulacaoBaseDados(string BaseDados, string SenhaBaseDados)
            : this(BaseDados, SenhaBaseDados, string.Empty)
        {
        }

        public clsManipulacaoBaseDados(string BaseDados, string SenhaBaseDados, string NomeTabela)
        {
            mtdResetarCamposTabela();

            strBaseDados = BaseDados;
            strSenhaBaseDados = SenhaBaseDados;
            strTabela = NomeTabela;
        }

        public bool mtdCriarBancoDados()
        {
            return mtdCriarBancoDados(strBaseDados, strSenhaBaseDados);
        }

        public bool mtdCriarBancoDados(string BaseDados, string SenhaBaseDados)
        {
            strBaseDados = BaseDados;
            strSenhaBaseDados = SenhaBaseDados;

            bool Retorno = false;

            try
            {
                clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
               (
                clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
               );

                objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                (
                    clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                    strBaseDados,
                    strSenhaBaseDados
                );

                Retorno = objImplementacaoBancoDados.mtdCriarBancoDadosSQLServerCE();

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
            return mtdCriarTabela(strBaseDados, strSenhaBaseDados, NomeTabela, CamposTabela);
        }

        public bool mtdCriarTabela(string BaseDados, string SenhaBaseDados, string NomeTabela, List<List<string>> CamposTabela)
        {
            bool Retorno = false;

            strBaseDados = BaseDados;
            strSenhaBaseDados = SenhaBaseDados;
            strTabela = NomeTabela;
            lstCamposTabela = CamposTabela;

            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
            (
                clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
            );

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
            (
                clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                BaseDados,
                SenhaBaseDados
            );

            Retorno = objImplementacaoBancoDados.mtdCriarTabela
                  (
                      NomeTabela,
                      CamposTabela
                  );

            objImplementacaoBancoDados.Dispose();

            return Retorno;
        }

         public bool mtdAlterarDadosTabela(List<List<object>> Campos_Dados_CampoBase_Operacao_DadoBase)
        {
            return mtdAlterarDadosTabela(strTabela, Campos_Dados_CampoBase_Operacao_DadoBase);
        }

        public bool mtdAlterarDadosTabela(string Tabela, List<List<object>> Campos_Dados_CampoBase_Operacao_DadoBase)
        {
            bool Retorno = false;

            strTabela = Tabela;

            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
               (
               clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
               );

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                (
                clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                strBaseDados,
                strSenhaBaseDados
                );

            Retorno = objImplementacaoBancoDados.mtdAtualizarDadosParametroComandoSQLServerCE(strTabela, Campos_Dados_CampoBase_Operacao_DadoBase, enmModoParametroComando.Valor);

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

            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
               (
               clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
               );

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                (
                clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                strBaseDados,
                strSenhaBaseDados
                );

            Retorno = objImplementacaoBancoDados.mtdInserirDadosParametroComandoSQLServerCE(strTabela, Campos_Dados, enmModoParametroComando.Valor);

            objImplementacaoBancoDados.Dispose();

            return Retorno;
        }

        public bool mtdDeletarDadosTabela(string Tabela, string CampoSelecionador, string Operacao, object Dado)
        {
            bool Retorno = false;

            strTabela = Tabela;

            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
               (
               clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
               );

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                (
                clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                strBaseDados,
                strSenhaBaseDados
                );

            Retorno = objImplementacaoBancoDados.mtdDeletarDadosParametroComandoSQLServerCE(strTabela, CampoSelecionador, Operacao, Dado);

            objImplementacaoBancoDados.Dispose();

            return Retorno;
        }

        public System.Data.DataTable mtdSelecionarDadosTabela(uint NumeroLinhas, List<string> Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado, string CampoOrdenador, bool Crescente)
        {
            return mtdSelecionarDadosTabela(strTabela, NumeroLinhas, Campos, NomeTabela, CampoSelecionador, Operacao, Dado, CampoOrdenador, Crescente);
        }

        public System.Data.DataTable mtdSelecionarDadosTabela(string Tabela, uint NumeroLinhas, List<string> Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado, string CampoOrdenador, bool Crescente)
        {
            System.Data.DataTable Retorno = new System.Data.DataTable();

            strTabela = Tabela;

            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
               (
               clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
               );

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                (
                clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                strBaseDados,
                strSenhaBaseDados
                );

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