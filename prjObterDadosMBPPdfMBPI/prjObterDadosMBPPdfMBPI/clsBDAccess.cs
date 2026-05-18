using System;
using System.Collections.Generic;
using System.Text;

namespace prjObterDadosMBPPdfMBPI
{
    public partial class clsConexaoBancoDados
    {
        public const string cntStringConexaoAccessOdbc = @"Driver={Microsoft Access Driver (*.mdb, *.accdb)}}; Dbq={0}; Uid={1}; Pwd={2};";
        public const string cntStringConexaoAccess2003OleDb = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source={0}; Jet OLEDB:Database Password={2};";
        public const string cntStringConexaoAccess2007OleDb = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source={0}; Jet OLEDB:Database Password={2};";

        public const string cntExemploStringConexaoAccessOdbc = @"Driver={Microsoft Access Driver (*.mdb, *.accdb)}}; Dbq=C:\mydatabase.mdb; Uid=Admin; Pwd=;";
        public const string cntExemploStringConexaoAccess2003OleDb = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source={0}; Jet OLEDB:Database Password=;";
        public const string cntExemploStringConexaoAccess2007OleDb = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source={0}; Jet OLEDB:Database Password=;";

        // Variaveis somente leitura de instancia do Access

        private readonly string[] cntProviderAccess = { "Provider", "Microsoft.Jet.OLEDB.4.0", "Microsoft.ACE.OLEDB.12.0" };
        private readonly string[] cntDriverAccess = { "Driver", "{Microsoft Access Driver (*.mdb)}" };
        private readonly string[] cntDataSourceAccess = { "DataSource", string.Empty };
        private readonly string[] cntUserIdAccess = { "User Id", string.Empty };
        private readonly string[] cntPasswordAccess = { "Password", string.Empty };

        // Variaveis de instancia do Access

        private string[] strProviderAccess;
        private string[] strDriverAccess;
        private string[] strDataSourceAccess;
        private string[] strUserIdAccess;
        private string[] strPasswordAccess;

        private string[] vetProviderAccess = { "Provider" };
        private string[] vetDriverAccess = { "Driver" };
        private string[] vetDataSourceAccess = { "DataSource", "Data Source", "Dbq", "Server" };
        private string[] vetUserIdAccess = { "User Id", "Uid" };
        private string[] vetPasswordAccess = { "Password", "Pwd", "Jet OLEDB:Database Password" };

        // Variaveis que determinam se a conexao incorporara o banco de dados. Isso facilita na criacao, alteracao ou delecao do banco de dados.

        private bool blnPermitirBancoDadosAccess = true;

        // Propriedades de instancia do Access

        public string prpProviderAccess
        {
            get
            {
                if (strProviderAccess == null)
                {
                    strProviderAccess = new string[2] { cntProviderAccess[0], cntProviderAccess[1] };
                }
                return strProviderAccess[1];
            }
            set
            {
                if (strProviderAccess == null)
                {
                    strProviderAccess = new string[2] { cntProviderAccess[0], cntProviderAccess[1] };
                }
                strProviderAccess[1] = value;
                mtdReDefinirConexaoString(strProviderAccess);
            }
        }

        public string prpDriverAccess
        {
            get
            {
                if (strDriverAccess == null)
                {
                    strDriverAccess = new string[2] { cntDriverAccess[0], cntDriverAccess[1] };
                }
                return strDriverAccess[1];
            }
            set
            {
                if (strDriverAccess == null)
                {
                    strDriverAccess = new string[2] { cntDriverAccess[0], cntDriverAccess[1] };
                }
                strDriverAccess[1] = value;
                mtdReDefinirConexaoString(strDriverAccess);
            }
        }

        public string prpDataSourceAccess
        {
            get
            {
                if (strDataSourceAccess == null)
                {
                    strDataSourceAccess = new string[2] { cntDataSourceAccess[0], cntDataSourceAccess[1] };
                }
                return strDataSourceAccess[1];
            }
            set
            {
                if (strDataSourceAccess == null)
                {
                    strDataSourceAccess = new string[2] { cntDataSourceAccess[0], cntDataSourceAccess[1] };
                }
                strDataSourceAccess[1] = value;
                mtdReDefinirConexaoString(strDataSourceAccess);
            }
        }

        public string prpUserIdAccess
        {
            get
            {
                if (strUserIdAccess == null)
                {
                    strUserIdAccess = new string[2] { cntUserIdAccess[0], cntUserIdAccess[1] };
                }
                return strUserIdAccess[1];
            }
            set
            {
                if (strUserIdAccess == null)
                {
                    strUserIdAccess = new string[2] { cntUserIdAccess[0], cntUserIdAccess[1] };
                }
                strUserIdAccess[1] = value;
                mtdReDefinirConexaoString(strUserIdAccess);
            }
        }

        public string prpPasswordAccess
        {
            get
            {
                if (strPasswordAccess == null)
                {
                    strPasswordAccess = new string[2] { cntPasswordAccess[0], cntPasswordAccess[1] };
                }
                return strPasswordAccess[1];
            }
            set
            {
                if (strPasswordAccess == null)
                {
                    strPasswordAccess = new string[2] { cntPasswordAccess[0], cntPasswordAccess[1] };
                }
                strPasswordAccess[1] = value;
                mtdReDefinirConexaoString(strPasswordAccess);
            }
        }

        // Metodos de instancia do Access

        public string[] mtdValidarConexaoDispositivoAccess(string Conexao)
        {
            strDriverAccess = mtdValidarConexao(Conexao, vetDriverAccess);
            return strDriverAccess;
        }

        public string[] mtdValidarConexaoProvedorAccess(string Conexao)
        {
            strProviderAccess = mtdValidarConexao(Conexao, vetProviderAccess);
            return strProviderAccess;
        }

        public string[] mtdValidarConexaoOrigemDadosAccess(string Conexao)
        {
            strDataSourceAccess = mtdValidarConexao(Conexao, vetDataSourceAccess);
            return strDataSourceAccess;
        }

        public string[] mtdValidarConexaoUsuarioAccess(string Conexao)
        {
            strUserIdAccess = mtdValidarConexao(Conexao, vetUserIdAccess);
            return strUserIdAccess;
        }

        public string[] mtdValidarConexaoSenhaAccess(string Conexao)
        {
            strPasswordAccess = mtdValidarConexao(Conexao, vetPasswordAccess);
            return strPasswordAccess;
        }

        public string mtdValidarConexaoAccess(string Conexao)
        {
            string saida = string.Empty;

            prpTipoConexao = TipoConexao.Indisponivel;
            //if (strDriverAccess == null || strDriverAccess[1] == cntDriverAccess[1])
            //{
            mtdValidarConexaoDispositivoAccess(Conexao);
            //}
            if (strDriverAccess != null)
            {
                prpTipoConexao = TipoConexao.ConexaoAccessOdbc;
            }
            //if (strProviderAccess == null || strProviderAccess[1] == cntProviderAccess[1])
            //{
            mtdValidarConexaoProvedorAccess(Conexao);
            //}
            if (strProviderAccess != null)
            {
                if (strProviderAccess[strProviderAccess.GetUpperBound(0)] == cntProviderAccess[cntProviderAccess.GetUpperBound(0)])
                {
                    prpTipoConexao = TipoConexao.ConexaoAccess2007OleDb;
                }
                else
                {
                    prpTipoConexao = TipoConexao.ConexaoAccess2003OleDb;
                }
            }
            //if (strDataSourceAccess == null || strDataSourceAccess[1] == cntDataSourceAccess[1])
            //{
            mtdValidarConexaoOrigemDadosAccess(Conexao);
            //}
            //if (strUserIdAccess == null || strUserIdAccess[1] == cntUserIdAccess[1])
            //{
            mtdValidarConexaoUsuarioAccess(Conexao);
            //}
            //if (strPasswordAccess == null || strPasswordAccess[1] == cntPasswordAccess[1])
            //{
            mtdValidarConexaoSenhaAccess(Conexao);
            //}

            if (strDriverAccess != null)
            {
                saida += string.Format("{0}={1}; ", strDriverAccess[0], strDriverAccess[1]);
            }
            if (strProviderAccess != null)
            {
                saida += string.Format("{0}={1}; ", strProviderAccess[0], strProviderAccess[1]);
            }
            if (strDataSourceAccess != null)
            {
                saida += string.Format("{0}={1}; ", strDataSourceAccess[0], strDataSourceAccess[1]);
            }
            if (strUserIdAccess != null)
            {
                saida += string.Format("{0}={1}; ", strUserIdAccess[0], strUserIdAccess[1]);
            }
            if (strPasswordAccess != null)
            {
                saida += string.Format("{0}={1};", strPasswordAccess[0], strPasswordAccess[1]);
            }
            return saida;
        }

        public string mtdDefinirStringConexaoAccess()
        {
            return mtdDefinirStringConexaoAccess(prpConexao, true);
        }

        public string mtdDefinirStringConexaoAccess(string Conexao, bool PermitirBancoDados)
        {
            blnPermitirBancoDadosAccess = PermitirBancoDados;
            mtdValidarConexaoAccess(Conexao);
            return mtdDefinirStringConexaoAccess(prpTipoConexao,
                prpDataSourceAccess,
                prpUserIdAccess,
                prpPasswordAccess);
        }

        public string mtdDefinirStringConexaoAccess(TipoConexao TipoConexao, string DataSource)
        {
            return mtdDefinirStringConexaoAccess(TipoConexao, DataSource, cntUserIdAccess[1], cntPasswordAccess[1]);
        }

        public string mtdDefinirStringConexaoAccess(TipoConexao TipoConexao, string DataSource, string UserId, string Password)
        {
            enuTipoConexao = TipoConexao;

            string saida = string.Empty;
            switch (TipoConexao)
            {
                case TipoConexao.ConexaoAccessOdbc:
                    saida = string.Format(cntStringConexaoAccessOdbc.Replace(string.Format("Driver={0}; ", cntDriverAccess[1]), string.Empty), DataSource, UserId, Password);
                    strDriverAccess = cntDriverAccess;
                    saida = string.Format("{0}={1}; ", strDriverAccess[0], strDriverAccess[1]) + saida;
                    saida = mtdEliminarAtribudoIndisponivelStringConexao(saida);
                    prpTipoSistemaGerenciadorBancoDadosRelacional = TipoSistemaGerenciadorBancoDadosRelacional.Odbc;
                    break;
                case TipoConexao.ConexaoAccess2003OleDb:
                    saida = string.Format(cntStringConexaoAccess2003OleDb.Replace(string.Format("Provider={0}; ", cntProviderAccess[1]), string.Empty), DataSource, UserId, Password);
                    strProviderAccess = cntProviderAccess;
                    saida = string.Format("{0}={1}; ", strProviderAccess[0], strProviderAccess[1]) + saida;
                    saida = mtdEliminarAtribudoIndisponivelStringConexao(saida);
                    prpTipoSistemaGerenciadorBancoDadosRelacional = TipoSistemaGerenciadorBancoDadosRelacional.OleDb;
                    break;
                case TipoConexao.ConexaoAccess2007OleDb:
                    saida = string.Format(cntStringConexaoAccess2007OleDb.Replace(string.Format("Provider={0}; ", cntProviderAccess[1]), string.Empty), DataSource, UserId, Password);
                    strProviderAccess = cntProviderAccess;
                    saida = string.Format("{0}={1}; ", strProviderAccess[0], strProviderAccess[1]) + saida;
                    saida = mtdEliminarAtribudoIndisponivelStringConexao(saida);
                    prpTipoSistemaGerenciadorBancoDadosRelacional = TipoSistemaGerenciadorBancoDadosRelacional.OleDb;
                    break;
                case TipoConexao.Indisponivel:
                    saida = TipoConexao.Indisponivel.ToString();
                    prpTipoSistemaGerenciadorBancoDadosRelacional = TipoSistemaGerenciadorBancoDadosRelacional.Indisponivel;
                    break;
            }
            prpConexao = mtdValidarConexaoAccess(saida);
            return prpConexao.Trim();
        }
    }

    public partial class clsImplementacaoBancoDados
    {
        // Access

        public bool mtdCompactarRepararBancoDadosAccess()
        {
            return mtdCompactarRepararBancoDadosAccess(prpDataSourceAccess);
        }

        public bool mtdCompactarRepararBancoDadosAccess(string BancoDados)
        {
            bool saida = true;

            System.Exception ex = new System.Exception("Não há banco de dados (arquivo) a ser compactado e reparado.");
            JRO.JetEngine objJRO;
            string[] vetBancoDados = BancoDados.Split('.');
            string NovoBancoDados = string.Format("{0}_compactado_reparado.{1}", vetBancoDados[0], vetBancoDados[1]);

            prpDataSourceAccess = BancoDados;
            string strConexao = mtdDefinirStringConexaoAccess();
            mtdFecharConexao();
            prpDataSourceAccess = NovoBancoDados;
            string strNovaConexao = mtdDefinirStringConexaoAccess();
            mtdFecharConexao();
            try
            {
                if (System.IO.File.Exists(BancoDados))
                {
                    if (!System.IO.File.Exists(NovoBancoDados))
                    {
                        objJRO = new JRO.JetEngine();
                        objJRO.CompactDatabase(strConexao, strNovaConexao);
                        System.IO.File.Delete(BancoDados);
                        System.IO.File.Move(NovoBancoDados, BancoDados);
                        saida = true;
                    }
                    else
                    {
                        ex = new System.Exception("Já existe um banco de dados (arquivo) com esse nome.");
                        saida = false;
                    }
                }
                else
                {
                    setExcecao = ex.Message;
                    saida = false;
                }
            }
            catch (Exception exception)
            {
                setExcecao = exception.Message;
                saida = false;
            }

            return saida;
        }

        public bool mtdAlterarBancoDadosAccess(string NovoBancoDados)
        {
            return mtdAlterarBancoDadosAccess(prpDataSourceAccess, NovoBancoDados);
        }

        public bool mtdAlterarBancoDadosAccess(string BancoDados, string NovoBancoDados)
        {
            bool saida = true;

            System.Exception ex = new System.Exception("Não há banco de dados (arquivo) a ser alterado.");

            try
            {
                prpDataSourceAccess = BancoDados;
                mtdDefinirStringConexaoAccess();
                mtdFecharConexao();
                prpDataSourceAccess = NovoBancoDados;
                mtdDefinirStringConexaoAccess();
                mtdFecharConexao();
                if (System.IO.File.Exists(BancoDados))
                {
                    if (!System.IO.File.Exists(NovoBancoDados))
                    {
                        System.IO.File.Move(BancoDados, NovoBancoDados);
                        saida = true;
                    }
                    else
                    {
                        ex = new System.Exception("Já existe um banco de dados (arquivo) com esse nome.");
                        saida = false;
                    }
                }
                else
                {
                    setExcecao = ex.Message;
                    saida = false;
                }
            }
            catch (Exception exception)
            {
                setExcecao = exception.Message;
                saida = false;
            }
            return saida;
        }

        public bool mtdCriarBancoDadosAccess()
        {
            return mtdCriarBancoDadosAccess(prpDataSourceAccess);
        }

        public bool mtdCriarBancoDadosAccess(string BancoDados)
        {
            bool saida = false;

            System.Exception ex = new System.Exception("Já existe um banco de dados (arquivo) com esse nome.");

            try
            {
                prpDataSourceAccess = BancoDados;
                mtdDefinirStringConexaoAccess();
                mtdFecharConexao();
                if (!System.IO.File.Exists(BancoDados))
                {
                    ADOX.Catalog objCatalogo = new ADOX.Catalog();
                    objCatalogo.Create(mtdDefinirStringConexaoAccess(prpConexao, true));
                    saida = true;
                }
                else
                {
                    setExcecao = ex.Message;
                    saida = false;
                }
            }
            catch (Exception exception)
            {
                setExcecao = exception.Message;
                saida = false;

            }

            return saida;
        }

        public bool mtdDeletarBancoDadosAccess()
        {
            return mtdDeletarBancoDadosAccess(prpDataSourceAccess);
        }

        public bool mtdDeletarBancoDadosAccess(string BancoDados)
        {
            bool saida = true;

            System.Exception ex = new System.Exception("Não há banco de dados (arquivo) a ser deletado.");

            try
            {
                prpDataSourceAccess = BancoDados;
                mtdDefinirStringConexaoAccess();
                mtdFecharConexao();
                if (System.IO.File.Exists(BancoDados))
                {
                    System.IO.File.Delete(BancoDados);
                    saida = true;
                }
                else
                {
                    setExcecao = ex.Message;
                    saida = false;
                }
            }
            catch (Exception exception)
            {
                setExcecao = exception.Message;
                saida = false;
            }

            return saida;
        }
    }
}