using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
#region "BancoDados"

namespace prjColetorDadosIntermecCSNet35
{
    public partial class clsBancoDados : IDisposable
    {

        protected static int intNumeroInstanciasCriadas = 0;
        private int intColuna = 0;
        private int intLinha = 0;
        protected string strConexao = string.Empty;
        protected string strComando = string.Empty;
        private string strExcecao = "Nao há excecoes.";
        private string strTabela = "Tabela";
        private System.Data.CommandBehavior bhvComportamenteComando = System.Data.CommandBehavior.Default;
        public System.Data.DataSet objAjustadorDados = new System.Data.DataSet();
        public System.Data.DataTable objTabelaDados = new System.Data.DataTable();

        private TipoSistemaGerenciadorBancoDadosRelacional enuTipoSistemaGerenciadorBancoDadosRelacional = TipoSistemaGerenciadorBancoDadosRelacional.Indisponivel;

        public clsBancoDados()
            : this(string.Empty, string.Empty, TipoSistemaGerenciadorBancoDadosRelacional.Indisponivel)
        {
        }

        public clsBancoDados(string Conexao)
            : this(Conexao, string.Empty, TipoSistemaGerenciadorBancoDadosRelacional.Indisponivel)
        {
        }

        public clsBancoDados(TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional)
            : this(string.Empty, string.Empty, TipoSistemaGerenciadorBancoDadosRelacional)
        {
        }

        public clsBancoDados(string Conexao, TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional)
            : this(Conexao, string.Empty, TipoSistemaGerenciadorBancoDadosRelacional)
        {
        }

        public clsBancoDados(string Conexao, string Comando, TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional)
        {
            strConexao = Conexao;
            strComando = Comando;
            prpTipoSistemaGerenciadorBancoDadosRelacional = TipoSistemaGerenciadorBancoDadosRelacional;
            intNumeroInstanciasCriadas += 1;
        }

        public enum TipoSistemaGerenciadorBancoDadosRelacional
        {
            Indisponivel,
            DB2,
            Firebird,
            MySQL,
            Odbc,
            OleDb,
            Oracle,
            Postgre,
            SQLite,
            SQLServer,
            SQLServerCE
        }

        public TipoSistemaGerenciadorBancoDadosRelacional prpTipoSistemaGerenciadorBancoDadosRelacional
        {
            get { return enuTipoSistemaGerenciadorBancoDadosRelacional; }
            set { enuTipoSistemaGerenciadorBancoDadosRelacional = value; }
        }

        public static int getNumeroInstanciasCriadas
        {
            get { return intNumeroInstanciasCriadas; }
        }

        protected static int setNumeroInstanciasCriadas
        {
            set { intNumeroInstanciasCriadas = value; }
        }

        public string getExcecao
        {
            get { return strExcecao; }
        }

        protected string setExcecao
        {
            set { strExcecao = value; }
        }

        /// <summary>
        /// Propriedade que ajusta e resgata o valor da string contida na variável de instância strConexao.
        /// </summary>
        /// <returns></returns>
        public string prpConexao
        {
            get { return strConexao; }
            set { strConexao = value; }
        }

        private static object LockBancoDados = new object();

        /// <summary>
        /// O Método a seguir tem por finalidade abrir uma conexão de dados.
        /// </summary>
        /// <returns></returns>
        public bool mtdAbrirConexao()
        {
            return mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
        }

        public bool mtdAbrirConexao(string Conexao)
        {
            return mtdAbrirConexao(Conexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
        }

        public bool mtdAbrirConexao(TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional)
        {
            return mtdAbrirConexao(prpConexao, TipoSistemaGerenciadorBancoDadosRelacional);
        }

        /// <summary>
        ///  O método a seguir abre a conexão de dados definindo uma conexão de dados pelo seu argumento.
        /// </summary>
        /// <returns></returns>
        public bool mtdAbrirConexao(string Conexao, TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional)
        {
            lock (LockBancoDados)
            {
                bool saida = false;
                strExcecao = "mtdAbrirConexao: Nao houve excecao.";
                prpConexao = Conexao;
                prpTipoSistemaGerenciadorBancoDadosRelacional = TipoSistemaGerenciadorBancoDadosRelacional;
                try
                {
                    switch (enuTipoSistemaGerenciadorBancoDadosRelacional)
                    {
                        //case TipoSistemaGerenciadorBancoDadosRelacional.DB2:
                        //    objConexaoDB2.ConnectionString = prpConexao;
                        //    objConexaoDB2.Open();
                        //    if (objConexaoDB2.State == System.Data.ConnectionState.Open)
                        //    {
                        //        saida = true;
                        //    }
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.Firebird:
                        //    objConexaoFirebird.ConnectionString = prpConexao;
                        //    objConexaoFirebird.Open();
                        //    if (objConexaoFirebird.State == System.Data.ConnectionState.Open)
                        //    {
                        //        saida = true;
                        //    }
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.MySQL:
                        //    objConexaoMySQL.ConnectionString = prpConexao;
                        //    objConexaoMySQL.Open();
                        //    if (objConexaoMySQL.State == System.Data.ConnectionState.Open)
                        //    {
                        //        saida = true;
                        //    }
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.Odbc:
                        //    objConexaoOdbc.ConnectionString = prpConexao;
                        //    objConexaoOdbc.Open();
                        //    if (objConexaoOdbc.State == System.Data.ConnectionState.Open)
                        //    {
                        //        saida = true;
                        //    }
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.OleDb:
                        //    objConexaoOleDb.ConnectionString = prpConexao;
                        //    objConexaoOleDb.Open();
                        //    if (objConexaoOleDb.State == System.Data.ConnectionState.Open)
                        //    {
                        //        saida = true;
                        //    }
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.Oracle:
                        //    objConexaoOracle.ConnectionString = prpConexao;
                        //    objConexaoOracle.Open();
                        //    if (objConexaoOracle.State == System.Data.ConnectionState.Open)
                        //    {
                        //        saida = true;
                        //    }
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.Postgre:
                        //    objConexaoPostgre.ConnectionString = prpConexao;
                        //    objConexaoPostgre.Open();
                        //    if (objConexaoPostgre.State == System.Data.ConnectionState.Open)
                        //    {
                        //        saida = true;
                        //    }
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.SQLite:
                        //    objConexaoSQLite.ConnectionString = prpConexao;
                        //    objConexaoSQLite.Open();
                        //    if (objConexaoSQLite.State == System.Data.ConnectionState.Open)
                        //    {
                        //        saida = true;
                        //    }
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.SQLServer:
                        //    objConexaoSQLServer.ConnectionString = prpConexao;
                        //    objConexaoSQLServer.Open();
                        //    if (objConexaoSQLServer.State == System.Data.ConnectionState.Open)
                        //    {
                        //        saida = true;
                        //    }
                        //    break;
                        case TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE:
                            if (objConexaoSQLServerCE.State == System.Data.ConnectionState.Open)
                            {
                                saida = true;
                            }
                            else
                            {
                                objConexaoSQLServerCE.ConnectionString = prpConexao;
                                objConexaoSQLServerCE.Open();
                                if (objConexaoSQLServerCE.State == System.Data.ConnectionState.Open)
                                {
                                    saida = true;
                                }
                                else
                                {
                                    saida = false;
                                }
                            }
                            break;
                    }
                }
                catch (System.Exception ex)
                {
                    strExcecao = "mtdAbrirConexao: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                    //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);

                    saida = false;
                }
                return saida;
            }
        }

        /// <summary>
        /// Método que fecha a conexão aberta.
        /// </summary>
        /// <returns></returns>
        public bool mtdFecharConexao()
        {
            lock (LockBancoDados)
            {
                bool saida = false;
                strExcecao = "mtdFecharConexao: Nao houve excecao.";
                setNumeroLinhas = 0;
                try
                {
                    switch (enuTipoSistemaGerenciadorBancoDadosRelacional)
                    {
                        //case TipoSistemaGerenciadorBancoDadosRelacional.DB2:
                        //    objConexaoDB2.Close();
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.Firebird:
                        //    objConexaoFirebird.Close();
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.MySQL:
                        //    objConexaoMySQL.Close();
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.Odbc:
                        //    objConexaoOdbc.Close();
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.OleDb:
                        //    objConexaoOleDb.Close();
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.Oracle:
                        //    objConexaoOracle.Close();
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.Postgre:
                        //    objConexaoPostgre.Close();
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.SQLite:
                        //    objConexaoSQLite.Close();
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.SQLServer:
                        //    objConexaoSQLServer.Close();
                        //    break;
                        case TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE:
                            objConexaoSQLServerCE.Close();
                            break;
                    }
                    saida = true;
                }
                catch (System.Exception ex)
                {
                    strExcecao = "mtdFecharConexao: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                    //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);

                    saida = false;
                }
                return saida;
            }
        }

        /// <summary>
        /// Propriedade que ajusta e resgata o valor da string contida na variável de instância strComando.
        /// </summary>
        /// <returns></returns>
        public string prpComando
        {
            get { return strComando; }
            set { strComando = value; }
        }

        public bool mtdExecutarComando()
        {
            return mtdExecutarComando(prpComando);
        }

        /// <summary>
        /// O Método a seguir tem por finalidade executar o comando sql informado com a string definida no argumento.
        /// </summary>
        /// <returns></returns>
        /// 
        public bool mtdExecutarComando(string Comando)
        {
            lock (LockBancoDados)
            {
                bool saida = false;
                strExcecao = "mtdExecutarComando: Nao houve excecao.";
                try
                {
                    prpComando = Comando;
                    switch (enuTipoSistemaGerenciadorBancoDadosRelacional)
                    {
                        //case TipoSistemaGerenciadorBancoDadosRelacional.DB2:
                        //    objComandoDB2.CommandType = System.Data.CommandType.Text;
                        //    objComandoDB2.CommandText = prpComando;
                        //    objComandoDB2.Connection = objConexaoDB2;
                        //    mtdFecharLeitorDados();
                        //    objComandoDB2.ExecuteNonQuery();
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.Firebird:
                        //    objComandoFirebird.CommandType = System.Data.CommandType.Text;
                        //    objComandoFirebird.CommandText = prpComando;
                        //    objComandoFirebird.Connection = objConexaoFirebird;
                        //    mtdFecharLeitorDados();
                        //    objComandoFirebird.ExecuteNonQuery();
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.MySQL:
                        //    objComandoMySQL.CommandType = System.Data.CommandType.Text;
                        //    objComandoMySQL.CommandText = prpComando;
                        //    objComandoMySQL.Connection = objConexaoMySQL;
                        //    mtdFecharLeitorDados();
                        //    objComandoMySQL.ExecuteNonQuery();
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.Odbc:
                        //    objComandoOdbc.CommandType = System.Data.CommandType.Text;
                        //    objComandoOdbc.CommandText = prpComando;
                        //    objComandoOdbc.Connection = objConexaoOdbc;
                        //    mtdFecharLeitorDados();
                        //    objComandoOdbc.ExecuteNonQuery();
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.OleDb:
                        //    objComandoOleDb.CommandType = System.Data.CommandType.Text;
                        //    objComandoOleDb.CommandText = prpComando;
                        //    objComandoOleDb.Connection = objConexaoOleDb;
                        //    mtdFecharLeitorDados();
                        //    objComandoOleDb.ExecuteNonQuery();
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.Oracle:
                        //    objComandoOracle.CommandType = System.Data.CommandType.Text;
                        //    objComandoOracle.CommandText = prpComando;
                        //    objComandoOracle.Connection = objConexaoOracle;
                        //    mtdFecharLeitorDados();
                        //    objComandoOracle.ExecuteNonQuery();
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.Postgre:
                        //    objComandoPostgre.CommandType = System.Data.CommandType.Text;
                        //    objComandoPostgre.CommandText = prpComando;
                        //    objComandoPostgre.Connection = objConexaoPostgre;
                        //    mtdFecharLeitorDados();
                        //    objComandoPostgre.ExecuteNonQuery();
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.SQLite:
                        //    objComandoSQLite.CommandType = System.Data.CommandType.Text;
                        //    objComandoSQLite.CommandText = prpComando;
                        //    objComandoSQLite.Connection = objConexaoSQLite;
                        //    mtdFecharLeitorDados();
                        //    objComandoSQLite.ExecuteNonQuery();
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.SQLServer:
                        //    objComandoSQLServer.CommandType = System.Data.CommandType.Text;
                        //    objComandoSQLServer.CommandText = prpComando;
                        //    objComandoSQLServer.Connection = objConexaoSQLServer;
                        //    mtdFecharLeitorDados();
                        //    objComandoSQLServer.ExecuteNonQuery();
                        //    break;
                        case TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE:
                            objComandoSQLServerCE.CommandType = System.Data.CommandType.Text;
                            objComandoSQLServerCE.CommandText = prpComando;
                            objComandoSQLServerCE.Connection = objConexaoSQLServerCE;
                            mtdFecharLeitorDados();
                            objComandoSQLServerCE.ExecuteNonQuery();
                            break;
                    }

                    System.Threading.Thread.Sleep(1);

                    saida = true;
                }
                catch (System.Exception ex)
                {
                    strExcecao = "mtdExecutarComando: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                    //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);

                    saida = false;
                }
                return saida;
            }
        }

        public System.Data.CommandBehavior prpComandoComportamento
        {
            get { return bhvComportamenteComando; }
            set { bhvComportamenteComando = value; }
        }

        public string mtdReDefinirConexaoString(string[] SubStringConexao)
        {
            string[] vetConexao = prpConexao.Split(';');
            string[] vetSubConexao = null;

            prpConexao = string.Empty;
            for (int contador = vetConexao.GetLowerBound(0); contador <= vetConexao.GetUpperBound(0) - 1; contador++)
            {
                if (vetConexao[contador].Contains(SubStringConexao[0]))
                {
                    vetSubConexao = vetConexao[contador].Split('=');
                    vetSubConexao[1] = SubStringConexao[1].Trim();
                    vetConexao[contador] = string.Format("{0}={1}", vetSubConexao[0].Trim(), vetSubConexao[1].Trim());
                }
                prpConexao += string.Format("{0}; ", vetConexao[contador].Trim());
            }
            prpConexao = prpConexao.Trim();
            return prpConexao;
        }

        public string mtdObterCabecalhoColunas(int Coluna)
        {
            return mtdObterCabecalhoColunas()[Coluna];
        }

        //public string mtdObterCabecalhoColunas(string Coluna)
        //{
        //    return mtdObterCabecalhoColunas()[mtdObterNumeroColuna(Coluna)];
        //}

        public void mtdObterCabecalhoColunas(ref string[] Colunas)
        {
            Colunas = mtdObterCabecalhoColunas();
        }

        public string[] mtdObterCabecalhoColunas()
        {
            return mtdObterCabecalhoColunas(prpTabela, prpComando);
        }

        public string[] mtdObterCabecalhoColunas(string Comando)
        {
            return mtdObterCabecalhoColunas(prpTabela, Comando);
        }

        public string[] mtdObterCabecalhoColunas(string Tabela, string Comando)
        {
            return mtdObterCabecalhoColunas(Tabela, Comando, true);
        }

        public string[] mtdObterCabecalhoColunas(string Tabela, string Comando, bool Otimizacao)
        {
            lock (LockBancoDados)
            {
                strExcecao = "mtdObterCabecalhoColunas: Nao houve excecao.";

                int intNumeroColunas = 0;
                string[] vetCabecalhos = new string[intNumeroColunas];
                try
                {
                    if (Otimizacao)
                    {
                        prpTabela = Tabela;
                        prpComando = Comando;
                        intNumeroColunas = mtdNumeroColunas();
                        vetCabecalhos = new string[intNumeroColunas];
                        for (int contador = 0; contador <= intNumeroColunas - 1; contador++)
                        {
                            switch (enuTipoSistemaGerenciadorBancoDadosRelacional)
                            {
                                //case TipoSistemaGerenciadorBancoDadosRelacional.DB2:
                                //    vetCabecalhos[contador] = objLeitorDadosDB2.GetName(contador);
                                //    break;
                                //case TipoSistemaGerenciadorBancoDadosRelacional.Firebird:
                                //    vetCabecalhos[contador] = objLeitorDadosFirebird.GetName(contador);
                                //    break;
                                //case TipoSistemaGerenciadorBancoDadosRelacional.MySQL:
                                //    vetCabecalhos[contador] = objLeitorDadosMySQL.GetName(contador);
                                //    break;
                                //case TipoSistemaGerenciadorBancoDadosRelacional.Odbc:
                                //    vetCabecalhos[contador] = objLeitorDadosOdbc.GetName(contador);
                                //    break;
                                //case TipoSistemaGerenciadorBancoDadosRelacional.OleDb:
                                //    vetCabecalhos[contador] = objLeitorDadosOleDb.GetName(contador);
                                //    break;
                                //case TipoSistemaGerenciadorBancoDadosRelacional.Oracle:
                                //    vetCabecalhos[contador] = objLeitorDadosOracle.GetName(contador);
                                //    break;
                                //case TipoSistemaGerenciadorBancoDadosRelacional.Postgre:
                                //    vetCabecalhos[contador] = objLeitorDadosPostgre.GetName(contador);
                                //    break;
                                //case TipoSistemaGerenciadorBancoDadosRelacional.SQLite:
                                //    vetCabecalhos[contador] = objLeitorDadosSQLite.GetName(contador);
                                //    break;
                                //case TipoSistemaGerenciadorBancoDadosRelacional.SQLServer:
                                //    vetCabecalhos[contador] = objLeitorDadosSQLServer.GetName(contador);
                                //    break;
                                case TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE:
                                    vetCabecalhos[contador] = objLeitorDadosSQLServerCE.GetName(contador);
                                    break;
                            }
                        }
                    }
                    else
                    {
                        mtdAdaptadorDados();
                        intNumeroColunas = mtdNumeroColunas(false);
                        vetCabecalhos = new string[intNumeroColunas];
                        for (int contador = 0; contador <= intNumeroColunas - 1; contador += 1)
                        {
                            vetCabecalhos[contador] = objAjustadorDados.Tables[strTabela].Columns[contador].ColumnName.ToString();
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    strExcecao = "mtdObterCabecalhoColunas: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                    //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                }
                return vetCabecalhos;
            }
        }

        public int mtdObterNumeroColuna(string Coluna)
        {
            lock (LockBancoDados)
            {
                strExcecao = "mtdObterNumeroColuna: Nao houve excecao.";
                System.Exception ex = new System.Exception("A coluna informada nao foi encontrada.");

                string[] vetObterCabecalhoColunas = mtdObterCabecalhoColunas();
                int saida = -1;

                for (int dimensao = 0; dimensao <= vetObterCabecalhoColunas.Rank - 1; dimensao++)
                {
                    for (int contador = vetObterCabecalhoColunas.GetLowerBound(dimensao); contador <= vetObterCabecalhoColunas.GetUpperBound(dimensao); contador++)
                    {
                        if (Coluna == vetObterCabecalhoColunas[contador])
                        {
                            saida = contador;
                        }
                    }
                }
                if (saida == -1)
                {
                    try
                    {
                        throw ex;
                    }
                    catch
                    {
                        strExcecao = "mtdObterNumeroColuna: " + ex.Message;
                    }
                }
                return saida;
            }
        }

        /// <summary>
        /// Propriedade que resgata o valor da string contida na variável de instância objAjustadorDados.
        /// </summary>
        /// <returns></returns>
        public System.Data.DataSet prpAjustadorDados
        {
            get { return objAjustadorDados; }
            set { objAjustadorDados = value; }
        }

        /// <summary>
        /// O Método a seguir tem por finalidade definir o leitor de dados a partir do comando (objComando.ExecuteReader).
        /// </summary>
        /// <returns></returns>
        public bool mtdDefinirLeitorDados()
        {
            return mtdDefinirLeitorDados(prpComandoComportamento);
        }

        /// <summary>
        /// O Método a seguir tem por finalidade definir o leitor de dados a partir do comando (objComando.ExecuteReader).
        /// </summary>
        /// <returns></returns>
        public bool mtdDefinirLeitorDados(System.Data.CommandBehavior ComandoComportamento)
        {
            lock (LockBancoDados)
            {
                bool saida = false;
                strExcecao = "mtdDefinirLeitorDados: Nao houve excecao.";
                prpComandoComportamento = ComandoComportamento;
                try
                {
                    switch (enuTipoSistemaGerenciadorBancoDadosRelacional)
                    {
                        //case TipoSistemaGerenciadorBancoDadosRelacional.DB2:
                        //    objLeitorDadosDB2 = objComandoDB2.ExecuteReader(prpComandoComportamento);
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.Firebird:
                        //    objLeitorDadosFirebird = objComandoFirebird.ExecuteReader(prpComandoComportamento);
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.MySQL:
                        //    objLeitorDadosMySQL = objComandoMySQL.ExecuteReader(prpComandoComportamento);
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.Odbc:
                        //    objLeitorDadosOdbc = objComandoOdbc.ExecuteReader(prpComandoComportamento);
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.OleDb:
                        //    objLeitorDadosOleDb = objComandoOleDb.ExecuteReader(prpComandoComportamento);
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.Oracle:
                        //    objLeitorDadosOracle = objComandoOracle.ExecuteReader(prpComandoComportamento);
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.Postgre:
                        //    objLeitorDadosPostgre = objComandoPostgre.ExecuteReader(prpComandoComportamento);
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.SQLite:
                        //    objLeitorDadosSQLite = objComandoSQLite.ExecuteReader(prpComandoComportamento);
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.SQLServer:
                        //    objLeitorDadosSQLServer = objComandoSQLServer.ExecuteReader(prpComandoComportamento);
                        //    break;
                        case TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE:
                            objLeitorDadosSQLServerCE = objComandoSQLServerCE.ExecuteReader(prpComandoComportamento);
                            break;
                    }
                    saida = true;
                }
                catch (System.Exception ex)
                {
                    strExcecao = "mtdDefinirLeitorDados: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                    //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);

                    saida = false;
                }
                intLinha = 0;
                return saida;
            }
        }

        /// <summary>
        /// Método que resgata o valor do datareader contido na variável de instância objLeitorDados, no entanto o datareader mantêm-se no mesmo registro.
        /// </summary>
        /// <returns></returns>

        public object mtdObterValorRegistro(int Coluna)
        {
            return mtdObterValorRegistro()[Coluna];
        }

        //public object mtdObterValorRegistro(string Coluna)
        //{
        //    return mtdObterValorRegistro()[mtdObterNumeroColuna(Coluna)];
        //}

        public void mtdObterValorRegistro(ref object[] Colunas)
        {
            Colunas = mtdObterValorRegistro();
        }

        public object[] mtdObterValorRegistro()
        {
            return mtdObterValorRegistro(prpTabela, prpComando);
        }

        public object[] mtdObterValorRegistro(string Comando)
        {
            return mtdObterValorRegistro(prpTabela, Comando);
        }

        public object[] mtdObterValorRegistro(string Tabela, string Comando)
        {
            return mtdObterValorRegistro(Tabela, Comando, true);
        }

        public object[] mtdObterValorRegistro(string Tabela, string Comando, bool Otimizacao)
        {
            lock (LockBancoDados)
            {
                strExcecao = "mtdObterValorRegistro: Nao houve excecao.";
                int intNumeroColunas = 0;
                object[] vetValores = null;
                try
                {
                    if (Otimizacao)
                    {
                        prpTabela = Tabela;
                        prpComando = Comando;
                        intNumeroColunas = mtdNumeroColunas();
                        vetValores = new object[intNumeroColunas];
                        for (int contador = 0; contador <= intNumeroColunas - 1; contador++)
                        {
                            switch (enuTipoSistemaGerenciadorBancoDadosRelacional)
                            {
                                //case TipoSistemaGerenciadorBancoDadosRelacional.DB2:
                                //    vetValores[contador] = objLeitorDadosDB2[contador];
                                //    break;
                                //case TipoSistemaGerenciadorBancoDadosRelacional.Firebird:
                                //    vetValores[contador] = objLeitorDadosFirebird[contador];
                                //    break;
                                //case TipoSistemaGerenciadorBancoDadosRelacional.MySQL:
                                //    vetValores[contador] = objLeitorDadosMySQL[contador];
                                //    break;
                                //case TipoSistemaGerenciadorBancoDadosRelacional.Odbc:
                                //    vetValores[contador] = objLeitorDadosOdbc[contador];
                                //    break;
                                //case TipoSistemaGerenciadorBancoDadosRelacional.OleDb:
                                //    vetValores[contador] = objLeitorDadosOleDb[contador];
                                //    break;
                                //case TipoSistemaGerenciadorBancoDadosRelacional.Oracle:
                                //    vetValores[contador] = objLeitorDadosOracle[contador];
                                //    break;
                                //case TipoSistemaGerenciadorBancoDadosRelacional.Postgre:
                                //    vetValores[contador] = objLeitorDadosPostgre[contador];
                                //    break;
                                //case TipoSistemaGerenciadorBancoDadosRelacional.SQLite:
                                //    vetValores[contador] = objLeitorDadosSQLite[contador];
                                //    break;
                                //case TipoSistemaGerenciadorBancoDadosRelacional.SQLServer:
                                //    vetValores[contador] = objLeitorDadosSQLServer[contador];
                                //    break;
                                case TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE:
                                    vetValores[contador] = (object)objLeitorDadosSQLServerCE[contador];
                                    break;
                            }
                        }
                    }
                    else
                    {
                        mtdAdaptadorDados();
                        intNumeroColunas = mtdNumeroColunas(false);
                        vetValores = new string[intNumeroColunas];
                        for (int contador = 0; contador <= intNumeroColunas - 1; contador += 1)
                        {
                            vetValores[contador] = objAjustadorDados.Tables[strTabela].Rows[0][contador];
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    strExcecao = "mtdObterValorRegistro: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                    //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                }
                return vetValores;
            }
        }

        /// <summary>
        /// Método que resgata o tipo do datareader contido na variável de instância objLeitorDados, no entanto o datareader mantêm-se no mesmo registro.
        /// </summary>
        /// <returns></returns>

        public System.Type mtdObterTipoRegistro(int Coluna)
        {
            return mtdObterTipoRegistro()[Coluna];
        }

        //public string mtdObterTipoRegistro(string Coluna)
        //{
        //    return mtdObterTipoRegistro()[mtdObterNumeroColuna[Coluna]];
        //}

        public void mtdObterTipoRegistro(ref System.Type[] Colunas)
        {
            Colunas = mtdObterTipoRegistro();
        }

        public System.Type[] mtdObterTipoRegistro()
        {
            return mtdObterTipoRegistro(prpTabela, prpComando);
        }

        public System.Type[] mtdObterTipoRegistro(string Comando)
        {
            return mtdObterTipoRegistro(prpTabela, Comando);
        }

        public System.Type[] mtdObterTipoRegistro(string Tabela, string Comando)
        {
            return mtdObterTipoRegistro(Tabela, Comando, true);
        }

        public System.Type[] mtdObterTipoRegistro(string Tabela, string Comando, bool Otimizacao)
        {
            lock (LockBancoDados)
            {
                strExcecao = "mtdObterTipoRegistro: Nao houve excecao.";
                int intNumeroColunas = 0;
                System.Type[] vetTipos = null;
                try
                {
                    if (Otimizacao)
                    {
                        prpTabela = Tabela;
                        prpComando = Comando;
                        intNumeroColunas = mtdNumeroColunas();
                        vetTipos = new System.Type[intNumeroColunas];
                        for (int contador = 0; contador <= intNumeroColunas - 1; contador++)
                        {
                            switch (enuTipoSistemaGerenciadorBancoDadosRelacional)
                            {
                                //case TipoSistemaGerenciadorBancoDadosRelacional.DB2:
                                //    vetTipos[contador] = objLeitorDadosDB2.GetValue(contador).GetType();
                                //    break;
                                //case TipoSistemaGerenciadorBancoDadosRelacional.Firebird:
                                //    vetTipos[contador] = objLeitorDadosFirebird.GetValue(contador).GetType();
                                //    break;
                                //case TipoSistemaGerenciadorBancoDadosRelacional.MySQL:
                                //    vetTipos[contador] = objLeitorDadosMySQL.GetValue(contador).GetType();
                                //    break;
                                //case TipoSistemaGerenciadorBancoDadosRelacional.Odbc:
                                //    vetTipos[contador] = objLeitorDadosOdbc.GetValue(contador).GetType();
                                //    break;
                                //case TipoSistemaGerenciadorBancoDadosRelacional.OleDb:
                                //    vetTipos[contador] = objLeitorDadosOleDb.GetValue(contador).GetType();
                                //    break;
                                //case TipoSistemaGerenciadorBancoDadosRelacional.Oracle:
                                //    vetTipos[contador] = objLeitorDadosOracle.GetValue(contador).GetType();
                                //    break;
                                //case TipoSistemaGerenciadorBancoDadosRelacional.Postgre:
                                //    vetTipos[contador] = objLeitorDadosPostgre.GetValue(contador).GetType();
                                //    break;
                                //case TipoSistemaGerenciadorBancoDadosRelacional.SQLite:
                                //    vetTipos[contador] = objLeitorDadosSQLite.GetValue(contador).GetType();
                                //    break;
                                //case TipoSistemaGerenciadorBancoDadosRelacional.SQLServer:
                                //    vetTipos[contador] = objLeitorDadosSQLServer.GetValue(contador).GetType();
                                //    break;
                                case TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE:
                                    vetTipos[contador] = objLeitorDadosSQLServerCE.GetValue(contador).GetType();
                                    break;
                            }
                        }
                    }
                    else
                    {
                        mtdAdaptadorDados();
                        intNumeroColunas = mtdNumeroColunas(false);
                        vetTipos = new System.Type[intNumeroColunas];
                        for (int contador = 0; contador <= intNumeroColunas - 1; contador += 1)
                        {
                            vetTipos[contador] = objAjustadorDados.Tables[strTabela].Columns[contador].Caption.GetType();
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    strExcecao = "mtdObterTipoRegistro: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                    //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                }
                return vetTipos;
            }
        }

        public void mtdObterCabecalhoTipoRegistro(object[][] CabecalhoTipoRegistro)
        {
            CabecalhoTipoRegistro = new object[2][] {
			mtdObterCabecalhoColunas(),
			mtdObterTipoRegistro()
		};
        }

        public void mtdObterCabecalhoTipoRegistro(int Coluna, object[] CabecalhoTipoRegistro)
        {
            CabecalhoTipoRegistro = new object[2] 
            {
			mtdObterCabecalhoColunas(Coluna),
			mtdObterTipoRegistro(Coluna)	
            };
        }

        public void mtdObterCabecalhoTipoRegistro(string Coluna, object[] CabecalhoTipoRegistro)
        {
            CabecalhoTipoRegistro = new object[2] 
            {
			mtdObterCabecalhoColunas(mtdObterNumeroColuna(Coluna)),
			mtdObterTipoRegistro(mtdObterNumeroColuna(Coluna))
            };
        }

        public object[][] mtdObterCabecalhoTipoRegistro()
        {
            return new object[2][]
            {
			mtdObterCabecalhoColunas(),
			mtdObterTipoRegistro()
            };
        }

        public object[] mtdObterCabecalhoTipoRegistro(int Coluna)
        {
            return new object[2] {
			mtdObterCabecalhoColunas(Coluna),
			mtdObterTipoRegistro(Coluna)
		};
        }

        public object[] mtdObterCabecalhoTipoRegistro(string Coluna)
        {
            return new object[2] {
			mtdObterCabecalhoColunas(mtdObterNumeroColuna(Coluna)),
			mtdObterTipoRegistro(mtdObterNumeroColuna(Coluna))
		};
        }

        public void mtdObterValorTipoRegistro(object[][] ValorTipoRegistro)
        {
            ValorTipoRegistro = new object[2][] {
			mtdObterValorRegistro(),
			mtdObterTipoRegistro()
		};
        }

        public void mtdObterValorTipoRegistro(int Coluna, object[] ValorTipoRegistro)
        {
            ValorTipoRegistro = new object[2] {
			mtdObterValorRegistro(Coluna),
			mtdObterTipoRegistro(Coluna)
		};
        }

        public void mtdObterValorTipoRegistro(string Coluna, object[] ValorTipoRegistro)
        {
            ValorTipoRegistro = new object[2] {
			mtdObterValorRegistro(mtdObterNumeroColuna(Coluna)),
			mtdObterTipoRegistro(mtdObterNumeroColuna(Coluna))
		};
        }

        public object[][] mtdObterValorTipoRegistro()
        {
            return new object[2][] {
			mtdObterValorRegistro(),
			mtdObterTipoRegistro()
		};
        }

        public object[] mtdObterValorTipoRegistro(int Coluna)
        {
            return new object[2] {
			mtdObterValorRegistro(Coluna),
			mtdObterTipoRegistro(Coluna)
		};
        }

        public object[] mtdObterValorTipoRegistro(string Coluna)
        {
            return new object[2] {
			mtdObterValorRegistro(mtdObterNumeroColuna(Coluna)),
			mtdObterTipoRegistro(mtdObterNumeroColuna(Coluna))
		};
        }

        /// <summary>
        /// O Método a seguir fecha o Leitor de Dados.
        /// </summary>
        /// <returns></returns>
        public bool mtdFecharLeitorDados()
        {
            lock (LockBancoDados)
            {
                bool saida = false;
                strExcecao = "mtdFecharLeitorDados: Nao houve excecao.";
                try
                {
                    switch (enuTipoSistemaGerenciadorBancoDadosRelacional)
                    {
                        //case TipoSistemaGerenciadorBancoDadosRelacional.DB2:
                        //    if (!objLeitorDadosDB2.IsClosed)
                        //    {
                        //        objLeitorDadosDB2.Close();
                        //    }
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.Firebird:
                        //    if (!objLeitorDadosFirebird.IsClosed)
                        //    {
                        //        objLeitorDadosFirebird.Close();
                        //    }
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.MySQL:
                        //    if (!objLeitorDadosMySQL.IsClosed)
                        //    {
                        //        objLeitorDadosMySQL.Close();
                        //    }
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.Odbc:
                        //    if (!objLeitorDadosOdbc.IsClosed)
                        //    {
                        //        objLeitorDadosOdbc.Close();
                        //    }
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.OleDb:
                        //    if (!objLeitorDadosOleDb.IsClosed)
                        //    {
                        //        objLeitorDadosOleDb.Close();
                        //    }
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.Oracle:
                        //    if (!objLeitorDadosOracle.IsClosed)
                        //    {
                        //        objLeitorDadosOracle.Close();
                        //    }
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.Postgre:
                        //    if (!objLeitorDadosPostgre.IsClosed)
                        //    {
                        //        objLeitorDadosPostgre.Close();
                        //    }
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.SQLite:
                        //    if (!objLeitorDadosSQLite.IsClosed)
                        //    {
                        //        objLeitorDadosSQLite.Close();
                        //    }
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.SQLServer:
                        //    if (!objLeitorDadosSQLServer.IsClosed)
                        //    {
                        //        objLeitorDadosSQLServer.Close();
                        //    }
                        //    break;
                        case TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE:
                            if (objLeitorDadosSQLServerCE != null)
                            {
                                if (!objLeitorDadosSQLServerCE.IsClosed)
                                {
                                    objLeitorDadosSQLServerCE.Close();
                                }
                            }
                            break;
                    }
                    saida = true;
                }
                catch (System.Exception ex)
                {
                    strExcecao = "mtdFecharLeitorDados: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                    //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);

                    saida = false;
                }
                intLinha = 0;
                return saida;
            }
        }

        public string prpTabela
        {
            get { return strTabela; }
            set { strTabela = value; }
        }

        public System.Data.DataTable prpTabelaDados
        {
            get { return objTabelaDados; }
            set { objTabelaDados = value; }
        }

        ///<summary>
        /// O Método a seguir tem por finalidade definir (ou redefinir) a conexão e o comando do Adaptador de Dados que no caso é a variável de instância (objAdaptadorDados).
        /// </summary>
        /// <returns></returns>
        public bool mtdAdaptadorDados()
        {
            return mtdAdaptadorDados(prpConexao, prpComando, prpTabela, prpTipoSistemaGerenciadorBancoDadosRelacional);
        }

        ///<summary>
        /// Método mtdAdaptadorDados está sobrecarregado.
        /// </summary>
        /// <returns></returns>
        public bool mtdAdaptadorDados(string Tabela)
        {
            return mtdAdaptadorDados(prpConexao, prpComando, Tabela, prpTipoSistemaGerenciadorBancoDadosRelacional);
        }

        public bool mtdAdaptadorDados(TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional)
        {
            return mtdAdaptadorDados(prpConexao, prpComando, prpTabela, TipoSistemaGerenciadorBancoDadosRelacional);
        }

        public bool mtdAdaptadorDados(string Tabela, TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional)
        {
            return mtdAdaptadorDados(prpConexao, prpComando, Tabela, TipoSistemaGerenciadorBancoDadosRelacional);
        }

        ///<summary>
        /// Método mtdAdaptadorDados está sobrecarregado.
        /// </summary>
        /// <returns></returns>
        public bool mtdAdaptadorDados(string Conexao, string Tabela)
        {
            return mtdAdaptadorDados(Conexao, prpComando, Tabela, prpTipoSistemaGerenciadorBancoDadosRelacional);
        }

        public bool mtdAdaptadorDados(string Conexao, string Tabela, TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional)
        {
            return mtdAdaptadorDados(Conexao, prpComando, Tabela, TipoSistemaGerenciadorBancoDadosRelacional);
        }

        public bool mtdAdaptadorDados(string Conexao, string Comando, string Tabela)
        {
            return mtdAdaptadorDados(Conexao, Comando, Tabela, prpTipoSistemaGerenciadorBancoDadosRelacional);
        }

        ///<summary>
        /// Método mtdAdaptadorDados está sobrecarregado.
        /// </summary>
        /// <returns></returns>
        public bool mtdAdaptadorDados(string Conexao, string Comando, string Tabela, TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional)
        {
            lock (LockBancoDados)
            {
                bool saida = false;
                strExcecao = "mtdAdaptadorDados: Nao houve excecao.";
                prpConexao = Conexao;
                prpComando = Comando;
                prpTabela = Tabela;
                prpAjustadorDados = new System.Data.DataSet();
                prpTabelaDados = new System.Data.DataTable();
                prpTipoSistemaGerenciadorBancoDadosRelacional = TipoSistemaGerenciadorBancoDadosRelacional;
                try
                {
                    switch (enuTipoSistemaGerenciadorBancoDadosRelacional)
                    {
                        //case TipoSistemaGerenciadorBancoDadosRelacional.DB2:
                        //    objAdaptadorDadosDB2 = new IBM.Data.DB2.DB2DataAdapter(prpComando, prpConexao);
                        //    objAdaptadorDadosDB2.Fill(prpAjustadorDados, Tabela);
                        //    objAdaptadorDadosDB2.Fill(prpTabelaDados);
                        //    saida = true;
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.Firebird:
                        //    objAdaptadorDadosFirebird = new FirebirdSql.Data.FirebirdClient.FbDataAdapter(prpComando, prpConexao);
                        //    objAdaptadorDadosFirebird.Fill(prpAjustadorDados, Tabela);
                        //    objAdaptadorDadosFirebird.Fill(prpTabelaDados);
                        //    saida = true;
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.MySQL:
                        //    objAdaptadorDadosMySQL = new MySql.Data.MySqlClient.MySqlDataAdapter(prpComando, prpConexao);
                        //    objAdaptadorDadosMySQL.Fill(prpAjustadorDados, Tabela);
                        //    objAdaptadorDadosMySQL.Fill(prpTabelaDados);
                        //    saida = true;
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.Odbc:
                        //    objAdaptadorDadosOdbc = new System.Data.Odbc.OdbcDataAdapter(prpComando, prpConexao);
                        //    objAdaptadorDadosOdbc.Fill(prpAjustadorDados, Tabela);
                        //    objAdaptadorDadosOdbc.Fill(prpTabelaDados);
                        //    saida = true;
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.OleDb:
                        //    objAdaptadorDadosOleDb = new System.Data.OleDb.OleDbDataAdapter(prpComando, prpConexao);
                        //    objAdaptadorDadosOleDb.Fill(prpAjustadorDados, Tabela);
                        //    objAdaptadorDadosOleDb.Fill(prpTabelaDados);
                        //    saida = true;
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.Oracle:
                        //    objAdaptadorDadosOracle = new System.Data.OracleClient.OracleDataAdapter(prpComando, prpConexao);
                        //    objAdaptadorDadosOracle.Fill(prpAjustadorDados, Tabela);
                        //    objAdaptadorDadosOracle.Fill(prpTabelaDados);
                        //    saida = true;
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.Postgre:
                        //    objAdaptadorDadosPostgre = new Npgsql.NpgsqlDataAdapter(prpComando, prpConexao);
                        //    objAdaptadorDadosPostgre.Fill(prpAjustadorDados, Tabela);
                        //    objAdaptadorDadosPostgre.Fill(prpTabelaDados);
                        //    saida = true;
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.SQLite:
                        //    objAdaptadorDadosSQLite = new System.Data.SQLite.SQLiteDataAdapter(prpComando, prpConexao);
                        //    objAdaptadorDadosSQLite.Fill(prpAjustadorDados, Tabela);
                        //    objAdaptadorDadosSQLite.Fill(prpTabelaDados);
                        //    saida = true;
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.SQLServer:
                        //    objAdaptadorDadosSQLServer = new System.Data.SqlClient.SqlDataAdapter(prpComando, prpConexao);
                        //    objAdaptadorDadosSQLServer.Fill(prpAjustadorDados, Tabela);
                        //    objAdaptadorDadosSQLServer.Fill(prpTabelaDados);
                        //    saida = true;
                        //    break;
                        case TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE:
                            objAdaptadorDadosSQLServerCE = new System.Data.SqlServerCe.SqlCeDataAdapter(prpComando, prpConexao);
                            objAdaptadorDadosSQLServerCE.Fill(prpAjustadorDados, Tabela);
                            objAdaptadorDadosSQLServerCE.Fill(prpTabelaDados);
                            saida = true;
                            break;
                    }
                }
                catch (System.Exception ex)
                {
                    strExcecao = "mtdAdaptadorDados: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                    //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);

                    saida = false;
                }
                return saida;
            }
        }

        ///<summary>
        /// O Método seguinte tem por finalidade ler o próximo registro.
        /// </summary>
        /// <returns></returns>
        public bool mtdProximoRegistro()
        {
            lock (LockBancoDados)
            {
                strExcecao = "mtdProximoRegistro: Nao houve excecao.";
                bool saida = false;
                try
                {
                    switch (enuTipoSistemaGerenciadorBancoDadosRelacional)
                    {
                        //case TipoSistemaGerenciadorBancoDadosRelacional.DB2:
                        //    saida = objLeitorDadosDB2.Read();
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.Firebird:
                        //    saida = objLeitorDadosFirebird.Read();
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.MySQL:
                        //    saida = objLeitorDadosMySQL.Read();
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.Odbc:
                        //    saida = objLeitorDadosOdbc.Read();
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.OleDb:
                        //    saida = objLeitorDadosOleDb.Read();
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.Oracle:
                        //    saida = objLeitorDadosOracle.Read();
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.Postgre:
                        //    saida = objLeitorDadosPostgre.Read();
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.SQLite:
                        //    saida = objLeitorDadosSQLite.Read();
                        //    break;
                        //case TipoSistemaGerenciadorBancoDadosRelacional.SQLServer:
                        //    saida = objLeitorDadosSQLServer.Read();
                        //    break;
                        case TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE:
                            saida = objLeitorDadosSQLServerCE.Read();
                            break;
                    }
                    if (saida)
                    {
                        intLinha += 1;
                    }
                    else
                    {
                        intLinha = 0;
                    }
                }
                catch (System.Exception ex)
                {
                    intLinha = -1;
                    strExcecao = "mtdProximoRegistro: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                    //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                }
                return saida;
            }
        }

        public void mtdAvancarRegistro()
        {
            if (!mtdProximoRegistro())
            {
                mtdFecharLeitorDados();
                mtdDefinirLeitorDados();
                if (enuTipoSistemaGerenciadorBancoDadosRelacional == TipoSistemaGerenciadorBancoDadosRelacional.SQLite)
                {
                    mtdProximoRegistro();
                }
            }
        }

        public object mtdAvancarRegistro(int Coluna)
        {
            mtdAvancarRegistro();
            return mtdObterValorRegistro(Coluna);
        }

        public object mtdAvancarRegistro(string Coluna)
        {
            return mtdAvancarRegistro(mtdObterNumeroColuna(Coluna));
        }

        public void mtdPrimeiroRegistro()
        {
            mtdFecharLeitorDados();
            mtdDefinirLeitorDados();
            mtdProximoRegistro();
        }

        public object mtdPrimeiroRegistro(int Coluna)
        {
            mtdPrimeiroRegistro();
            return mtdObterValorRegistro(Coluna);
        }

        public object mtdPrimeiroRegistro(string Coluna)
        {
            return mtdPrimeiroRegistro(mtdObterNumeroColuna(Coluna));
        }

        public void mtdRetrocederRegistro()
        {
            int intNumeroLinhas = mtdNumeroLinhas();
            int intIncrementarValor = 0;
            mtdFecharLeitorDados();
            mtdDefinirLeitorDados();
            if (enuTipoSistemaGerenciadorBancoDadosRelacional == TipoSistemaGerenciadorBancoDadosRelacional.SQLite)
            {
                intIncrementarValor = 1;
            }
            for (int contador = 0; contador <= intNumeroLinhas - intIncrementarValor - 1; contador++)
            {
                mtdAvancarRegistro();
            }
        }

        public object mtdRetrocederRegistro(int Coluna)
        {
            mtdRetrocederRegistro();
            return mtdObterValorRegistro(Coluna);
        }

        public object mtdRetrocederRegistro(string Coluna)
        {
            return mtdRetrocederRegistro(mtdObterNumeroColuna(Coluna));
        }

        public void mtdUltimoRegistro()
        {
            int intNumeroLinhas = mtdNumeroLinhas();
            mtdFecharLeitorDados();
            mtdDefinirLeitorDados();
            for (int contador = 0; contador <= intNumeroLinhas - 1; contador++)
            {
                mtdProximoRegistro();
            }
        }

        public object mtdUltimoRegistro(int Coluna)
        {
            mtdUltimoRegistro();
            return mtdObterValorRegistro(Coluna);
        }

        public object mtdUltimoRegistro(string Coluna)
        {
            return mtdUltimoRegistro(mtdObterNumeroColuna(Coluna));
        }

        public void mtdSelecionarRegistro(int Linha)
        {
            strExcecao = "mtdSelecionarRegistro: Nao houve excecao.";
            System.Exception ex = new System.Exception("O numero da linha informada e maior do que o numero de linhas da tabela selecionada.");
            if (Linha <= mtdNumeroLinhas())
            {
                mtdFecharLeitorDados();
                mtdDefinirLeitorDados();
                for (int contador = 0; contador <= Linha - 1; contador++)
                {
                    mtdProximoRegistro();
                    if (enuTipoSistemaGerenciadorBancoDadosRelacional == TipoSistemaGerenciadorBancoDadosRelacional.SQLite)
                    {
                        mtdProximoRegistro();
                    }
                }
            }
            else
            {
                try
                {
                    throw ex;
                }
                catch
                {
                    strExcecao = "mtdSelecionarRegistro: " + ex.Message;
                }
            }
        }

        public object mtdSelecionarRegistro(int Linha, int Coluna)
        {
            mtdSelecionarRegistro(Linha);
            return mtdObterValorRegistro(Coluna);
        }

        public object mtdSelecionarRegistro(int Linha, string Coluna)
        {
            return mtdSelecionarRegistro(Linha, mtdObterNumeroColuna(Coluna));
        }

        public int getNumeroColunas
        {
            get { return intColuna; }
        }

        protected int setNumeroColunas
        {
            set { intColuna = value; }
        }

        ///<summary>
        /// O método a seguir resgata o número de colunas do Leitor de Dados.
        /// </summary>
        /// <returns></returns>
        public int mtdNumeroColunas()
        {
            return mtdNumeroColunas(true);
        }

        public int mtdNumeroColunas(bool Otimizacao)
        {
            lock (LockBancoDados)
            {
                strExcecao = "mtdNumeroColunas: Nao houve excecao.";
                int intNumeroColunas = 0;
                try
                {
                    if (Otimizacao)
                    {
                        switch (enuTipoSistemaGerenciadorBancoDadosRelacional)
                        {
                            //case TipoSistemaGerenciadorBancoDadosRelacional.DB2:
                            //    intNumeroColunas = objLeitorDadosDB2.FieldCount;
                            //    break;
                            //case TipoSistemaGerenciadorBancoDadosRelacional.Firebird:
                            //    intNumeroColunas = objLeitorDadosFirebird.FieldCount;
                            //    break;
                            //case TipoSistemaGerenciadorBancoDadosRelacional.MySQL:
                            //    intNumeroColunas = objLeitorDadosMySQL.FieldCount;
                            //    break;
                            //case TipoSistemaGerenciadorBancoDadosRelacional.Odbc:
                            //    intNumeroColunas = objLeitorDadosOdbc.FieldCount;
                            //    break;
                            //case TipoSistemaGerenciadorBancoDadosRelacional.OleDb:
                            //    intNumeroColunas = objLeitorDadosOleDb.FieldCount;
                            //    break;
                            //case TipoSistemaGerenciadorBancoDadosRelacional.Oracle:
                            //    intNumeroColunas = objLeitorDadosOracle.FieldCount;
                            //    break;
                            //case TipoSistemaGerenciadorBancoDadosRelacional.Postgre:
                            //    intNumeroColunas = objLeitorDadosPostgre.FieldCount;
                            //    break;
                            //case TipoSistemaGerenciadorBancoDadosRelacional.SQLite:
                            //    intNumeroColunas = objLeitorDadosSQLite.FieldCount;
                            //    break;
                            //case TipoSistemaGerenciadorBancoDadosRelacional.SQLServer:
                            //    intNumeroColunas = objLeitorDadosSQLServer.FieldCount;
                            //    break;
                            case TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE:
                                intNumeroColunas = objLeitorDadosSQLServerCE.FieldCount;
                                break;
                        }
                    }
                    else
                    {
                        mtdAdaptadorDados();
                        intNumeroColunas = objAjustadorDados.Tables[strTabela].Columns.Count;
                    }
                }
                catch (System.Exception ex)
                {
                    strExcecao = "mtdNumeroColunas: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                    //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                }
                return intNumeroColunas;
            }
        }

        public int getNumeroLinhas
        {
            get { return intLinha; }
        }

        protected int setNumeroLinhas
        {
            set { intLinha = value; }
        }

        /// <summary>
        /// O Método a seguir encontra e resgata o número máximo de registros presente no Leitor de Dados.
        /// </summary>
        /// <returns></returns>
        public int mtdNumeroLinhas()
        {
            return mtdNumeroLinhas(true);
        }

        public int mtdNumeroLinhas(bool Otimizacao)
        {
            lock (LockBancoDados)
            {
                strExcecao = "mtdNumeroLinhas: Nao houve excecao.";
                int intNumeroLinhas = 0;
                try
                {
                    if (Otimizacao)
                    {
                        switch (enuTipoSistemaGerenciadorBancoDadosRelacional)
                        {
                            //case TipoSistemaGerenciadorBancoDadosRelacional.DB2:
                            //    intNumeroLinhas = mtdContarNumeroLinhas();
                            //    break;
                            //case TipoSistemaGerenciadorBancoDadosRelacional.Firebird:
                            //    intNumeroLinhas = mtdContarNumeroLinhas();
                            //    break;
                            //case TipoSistemaGerenciadorBancoDadosRelacional.MySQL:
                            //    intNumeroLinhas = mtdContarNumeroLinhas();
                            //    break;
                            //case TipoSistemaGerenciadorBancoDadosRelacional.Odbc:
                            //    intNumeroLinhas = mtdContarNumeroLinhas();
                            //    break;
                            //case TipoSistemaGerenciadorBancoDadosRelacional.OleDb:
                            //    intNumeroLinhas = mtdContarNumeroLinhas();
                            //    break;
                            //case TipoSistemaGerenciadorBancoDadosRelacional.Oracle:
                            //    intNumeroLinhas = mtdContarNumeroLinhas();
                            //    break;
                            //case TipoSistemaGerenciadorBancoDadosRelacional.Postgre:
                            //    intNumeroLinhas = mtdContarNumeroLinhas();
                            //    break;
                            //case TipoSistemaGerenciadorBancoDadosRelacional.SQLite:
                            //    intNumeroLinhas = mtdContarNumeroLinhas();
                            //    break;
                            //case TipoSistemaGerenciadorBancoDadosRelacional.SQLServer:
                            //    intNumeroLinhas = mtdContarNumeroLinhas();
                            //    break;
                            case TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE:
                                intNumeroLinhas = mtdContarNumeroLinhas();
                                break;
                        }
                    }
                    else
                    {
                        mtdAdaptadorDados();
                        intNumeroLinhas = objAjustadorDados.Tables[strTabela].Rows.Count;
                    }
                }
                catch (System.Exception ex)
                {
                    strExcecao = "mtdNumeroLinhas: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                    //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                }
                return intNumeroLinhas;
            }
        }

        private int mtdContarNumeroLinhas()
        {
            int intNumeroLinhas = 0;
            mtdExecutarComando();
            mtdDefinirLeitorDados();
            while (mtdProximoRegistro())
            {
                intNumeroLinhas += 1;
            }
            mtdFecharLeitorDados();
            return intNumeroLinhas;
        }

        private bool isDisposed = false;

        public void Dispose()
        {
            Dispose(true);
            //GC.WaitForPendingFinalizers();
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
                    mtdFecharLeitorDados();
                    mtdFecharConexao();
                    intNumeroInstanciasCriadas -= 1;

                    try
                    {
                        System.GC.Collect();
                    }
                    catch (System.Exception ex)
                    {
                        string strExcecao = "Dispose: " + ex.Message;
                        System.Diagnostics.Debug.WriteLine(strExcecao);
                        //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                    }
                }
            }
            // Code to dispose unmanaged resources
            // held by the class
            isDisposed = true;
            //base.Dispose(disposing);
        }

        ~clsBancoDados()
        {
            Dispose(false);
        }
    }
}
#endregion