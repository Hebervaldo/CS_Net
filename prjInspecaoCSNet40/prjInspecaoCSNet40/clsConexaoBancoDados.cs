using System;
using System.Collections.Generic;
using System.Text;

namespace prjInspecaoCSNet40
{
    public partial class clsConexaoBancoDados : clsInfraestruturaBancoDados
    {

        private TipoConexao enuTipoConexao = TipoConexao.Indisponivel;

        public enum TipoConexao
        {
            ConexaoAccessOdbc,
            ConexaoAccess2003OleDb,
            ConexaoAccess2007OleDb,
            ConexaoExcelOdbc,
            ConexaoExcel2007OleDb,
            ConexaoExcel2003OleDb,
            ConexaoDB2Nativa,
            ConexaoDB2Odbc,
            ConexaoFirebirdNativa,
            ConexaoFirebirdOdbc,
            ConexaoMySQLNativa,
            ConexaoMySQLOdbc,
            ConexaoMySQLOleDb,
            ConexaoOracleNativa,
            ConexaoOracleOdbc,
            ConexaoOracleOleDb,
            ConexaoPostgreNativa,
            ConexaoPostgreOdbc,
            ConexaoPostgreOleDb,
            ConexaoSQLiteNativa,
            ConexaoSQLiteOdbc,
            ConexaoSQLServerNativa,
            ConexaoSQLServerOdbc,
            ConexaoSQLServerOleDb,
            ConexaoSQLServerCENativa,
            ConexaoSQLServerCEOleDb,
            Indisponivel
        }

        public TipoConexao prpTipoConexao
        {
            get
            {
                return enuTipoConexao;
            }
            set
            {
                enuTipoConexao = value;
            }
        }

        // Metodo de Instancia, Construtor

        public clsConexaoBancoDados()
            : base(string.Empty, string.Empty, TipoSistemaGerenciadorBancoDadosRelacional.Indisponivel)
        {
        }

        public clsConexaoBancoDados(string Conexao)
            : base(Conexao, string.Empty, TipoSistemaGerenciadorBancoDadosRelacional.Indisponivel)
        {
        }

        public clsConexaoBancoDados(TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional)
            : base(string.Empty, string.Empty, TipoSistemaGerenciadorBancoDadosRelacional)
        {
        }

        public clsConexaoBancoDados(string Conexao, TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional)
            : base(Conexao, string.Empty, TipoSistemaGerenciadorBancoDadosRelacional)
        {
        }

        public clsConexaoBancoDados(string Conexao, string Comando, TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional)
            : base(Conexao, Comando, TipoSistemaGerenciadorBancoDadosRelacional)
        {
        }

        // Metodos de instancia generico

        private string mtdEliminarAtribudoIndisponivelStringConexao(string StringConexao)
        {
            string saida = string.Empty;
            string[] vetSubTexto = StringConexao.Split(';');
            string[] vetSubSubTexto;
            for (int contador = vetSubTexto.GetLowerBound(0); contador <= vetSubTexto.GetUpperBound(0); contador++)
            {
                if (enuTipoConexao == TipoConexao.ConexaoOracleNativa)
                {
                    saida = StringConexao;
                }
                else
                {
                    vetSubSubTexto = vetSubTexto[contador].Split('=');
                    saida += vetSubSubTexto[vetSubSubTexto.GetUpperBound(0)] != string.Empty ? string.Format("{0}={1}; ", vetSubSubTexto[vetSubSubTexto.GetLowerBound(0)],
                        vetSubSubTexto[vetSubSubTexto.GetUpperBound(0)]) : string.Empty;
                    saida = saida.Replace("  ", " ");
                }

            }
            return saida.Trim();
        }

        private string[] mtdValidarConexao(string Conexao, string[] vetGenerico)
        {
            string[] vetConexao = Conexao.Split(';');
            string[] vetPartes = null;
            string[] saida = null;

            for (int i_vetConexao = vetConexao.GetLowerBound(0); i_vetConexao <= vetConexao.GetUpperBound(0); i_vetConexao++)
            {
                vetPartes = vetConexao[i_vetConexao].Split('=');
                for (int i_vetCategoria = vetGenerico.GetLowerBound(0); i_vetCategoria <= vetGenerico.GetUpperBound(0); i_vetCategoria++)
                {
                    if (vetPartes[vetPartes.GetLowerBound(0)].ToLower().Trim().Equals(vetGenerico[i_vetCategoria].ToLower().Trim()))
                    {
                        saida = vetConexao[i_vetConexao].Split('=');
                    }
                }
            }
            return saida;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Code to cleanup managed resources held by the class.
            }
            // Code to cleanup unmanaged resources held by the class.
            base.Dispose(disposing);
        }
        // Note that the derived class does not // re-implement IDisposable
    }
}