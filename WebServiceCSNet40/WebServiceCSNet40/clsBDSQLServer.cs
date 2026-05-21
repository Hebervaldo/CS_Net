using System;
using System.Collections.Generic;
using System.Text;

namespace WebServiceCSNet40
{
    public partial class clsConexaoBancoDados
    {
        // Constantes de instancia do SQLServer

        public const string cntStringConexaoSQLServerOdbc_SegurancaPadrao = "Driver={SQL Server}; Server={0}; DataBase={1}; Uid={2}; Pwd={3}; Trusted Connection={4}; Persist Security Info={5}; Connect Timeout={6};";
        public const string cntStringConexaoSQLServerOdbc_SegurancaConfianca = "Driver={SQL Server}; Server={0}; DataBase={1}; Trusted Connection={2}; Persist Security Info={3}; Connect Timeout={4};";
        public const string cntStringConexaoSQLServerOleDb_SegurancaPadrao = "Provider=SQLOLEDB; Data Source={0}; DataBase={1}; UserId={2}; Password={3}; Integrated Security={4}; Persist Security Info={5}; Connect Timeout={6};";
        public const string cntStringConexaoSQLServerOleDb_SegurancaConfianca = "Provider=SQLOLEDB; Data Source={0}; DataBase={1}; Integrated Security={2}; Persist Security Info={3}; Connect Timeout={4};";
        public const string cntStringConexaoSQLServerNativa_SegurancaPadrao = "Server={0}; DataBase={1}; User ID={2}; Password={3}; Integrated Security={4}; Persist Security Info={5}; Connect Timeout={6};";
        public const string cntStringConexaoSQLServerNativa_SegurancaConfianca = "Server={0}; DataBase={1}; Integrated Security={2}; Persist Security Info={3}; Connect Timeout={4};";

        // Variaveis somente leitura de instancia do SQLSever

        private readonly string[] cntDriverSQLServer = { "Driver", "{SQL Server}" };
        private readonly string[] cntProviderSQLServer = { "Provider", "SQLOLEDB" };
        private readonly string[] cntServerSQLServer = { "Server", string.Empty };
        private readonly string[] cntDataBaseSQLServer = { "DataBase", string.Empty };
        private readonly string[] cntUserIdSQLServer = { "User ID", string.Empty };
        private readonly string[] cntPasswordSQLServer = { "Password", string.Empty };
        private readonly string[] cntIntegratedSecuritySQLServer = { "Integrated Security", "False" };
        private readonly string[] cntPersistSecurityInfoSQLServer = { "Persist Security Info", "False" };
        private readonly string[] cntConnectTimeoutSQLServer = { "Connect Timeout", "15" };

        // Variaveis de instancia do SQLServer

        private string[] strDriverSQLServer;
        private string[] strProviderSQLServer;
        private string[] strServerSQLServer;
        private string[] strDataBaseSQLServer;
        private string[] strUserIdSQLServer;
        private string[] strPasswordSQLServer;
        private string[] strIntegratedSecuritySQLServer;
        private string[] strPersistSecurityInfoSQLServer;
        private string[] strConnectTimeoutSQLServer;

        // Variaveis de instancia do SQLServer

        private string[] vetDriverSQLServer = { "Driver" };
        private string[] vetProviderSQLServer = { "Provider" };
        private string[] vetServerSQLServer = { "Addr", "Address", "DataSource", "Data Source", "NetworkAddress", "Network Address", "Server" };
        private string[] vetDataBaseSQLServer = { "DataBase", "Data Base", "InitialCatalog", "Initial Catalog" };
        private string[] vetUserIdSQLServer = { "UserId", "User Id", "Uid" };
        private string[] vetPasswordSQLServer = { "Password", "Pwd" };
        private string[] vetIntegratedSecuritySQLServer = { "IntegratedSecurity", "Integrated Security", "TrustedConnection", "Trusted Connection" };
        private string[] vetPersistSecurityInfoSQLServer = { "PersistSecurityInfo", "Persist Security Info" };
        private string[] vetConnectTimeoutSQLServer = { "ConnectTimeout", "Connect Timeout" };

        // Variaveis que determinam se a conexao incorporara o banco de dados. Isso facilita na criacao, alteracao ou delecao do banco de dados.

        private bool blnPermitirBancoDadosSQLServer = true;

        public bool prpPermitirBancoDadosSQLServer
        {
            get
            {
                return blnPermitirBancoDadosSQLServer;
            }
            set
            {
                blnPermitirBancoDadosSQLServer = value;
            }
        }

        // Propriedades de instancia do SQLServer

        public string prpDriverSQLServer
        {
            get
            {
                if (strDriverSQLServer == null)
                {
                    strDriverSQLServer = new string[2] { cntDriverSQLServer[0], cntDriverSQLServer[1] };
                }
                return strDriverSQLServer[1];
            }
            set
            {
                if (strDriverSQLServer == null)
                {
                    strDriverSQLServer = new string[2] { cntDriverSQLServer[0], cntDriverSQLServer[1] };
                }
                strDriverSQLServer[1] = value;
                mtdReDefinirConexaoString(strDriverSQLServer);
            }
        }

        public string prpProviderSQLServer
        {
            get
            {
                if (strProviderSQLServer == null)
                {
                    strProviderSQLServer = new string[2] { cntProviderSQLServer[0], cntProviderSQLServer[1] };
                }
                return strProviderSQLServer[1];
            }
            set
            {
                if (strProviderSQLServer == null)
                {
                    strProviderSQLServer = new string[2] { cntProviderSQLServer[0], cntProviderSQLServer[1] };
                }
                strProviderSQLServer[1] = value;
                mtdReDefinirConexaoString(strProviderSQLServer);
            }
        }

        public string prpServerSQLServer
        {
            get
            {
                if (strServerSQLServer == null)
                {
                    strServerSQLServer = new string[2] { cntServerSQLServer[0], cntServerSQLServer[1] };
                }
                return strServerSQLServer[1];
            }
            set
            {
                if (strServerSQLServer == null)
                {
                    strServerSQLServer = new string[2] { cntServerSQLServer[0], cntServerSQLServer[1] };
                }
                strServerSQLServer[1] = value;
                mtdReDefinirConexaoString(strProviderSQLServer);
            }
        }

        public string prpDataBaseSQLServer
        {
            get
            {
                if (strDataBaseSQLServer == null)
                {
                    strDataBaseSQLServer = new string[2] { cntDataBaseSQLServer[0], cntDataBaseSQLServer[1] };
                }
                return strDataBaseSQLServer[1];
            }
            set
            {
                if (strDataBaseSQLServer == null)
                {
                    strDataBaseSQLServer = new string[2] { cntDataBaseSQLServer[0], cntDataBaseSQLServer[1] };
                }
                strDataBaseSQLServer[1] = value;
                mtdReDefinirConexaoString(strDataBaseSQLServer);
            }
        }

        public string prpUserIdSQLServer
        {
            get
            {
                if (strUserIdSQLServer == null)
                {
                    strUserIdSQLServer = new string[2] { cntUserIdSQLServer[0], cntUserIdSQLServer[1] };
                }
                return strUserIdSQLServer[1];
            }
            set
            {
                if (strUserIdSQLServer == null)
                {
                    strUserIdSQLServer = new string[2] { cntUserIdSQLServer[0], cntUserIdSQLServer[1] };
                }
                strUserIdSQLServer[1] = value;
                mtdReDefinirConexaoString(strUserIdSQLServer);
            }
        }

        public string prpPasswordSQLServer
        {
            get
            {
                if (strPasswordSQLServer == null)
                {
                    strPasswordSQLServer = new string[2] { cntPasswordSQLServer[0], cntPasswordSQLServer[1] };
                }
                return strPasswordSQLServer[1];
            }
            set
            {
                if (strPasswordSQLServer == null)
                {
                    strPasswordSQLServer = new string[2] { cntPasswordSQLServer[0], cntPasswordSQLServer[1] };
                }
                strPasswordSQLServer[1] = value;
                mtdReDefinirConexaoString(strPasswordSQLServer);
            }
        }

        public string prpIntegratedSecuritySQLServer
        {
            get
            {
                if (strIntegratedSecuritySQLServer == null)
                {
                    strIntegratedSecuritySQLServer = new string[2] { cntIntegratedSecuritySQLServer[0], cntIntegratedSecuritySQLServer[1] };
                }
                return strIntegratedSecuritySQLServer[1];
            }
            set
            {
                if (strIntegratedSecuritySQLServer == null)
                {
                    strIntegratedSecuritySQLServer = new string[2] { cntIntegratedSecuritySQLServer[0], cntIntegratedSecuritySQLServer[1] };
                }
                strIntegratedSecuritySQLServer[1] = value;
                mtdReDefinirConexaoString(strIntegratedSecuritySQLServer);
            }
        }

        public string prpPersistSecurityInfoSQLServer
        {
            get
            {
                if (strPersistSecurityInfoSQLServer == null)
                {
                    strPersistSecurityInfoSQLServer = new string[2] { cntPersistSecurityInfoSQLServer[0], cntPersistSecurityInfoSQLServer[1] };
                }
                return strPersistSecurityInfoSQLServer[1];
            }
            set
            {
                if (strPersistSecurityInfoSQLServer == null)
                {
                    strPersistSecurityInfoSQLServer = new string[2] { cntPersistSecurityInfoSQLServer[0], cntPersistSecurityInfoSQLServer[1] };
                }
                strPersistSecurityInfoSQLServer[1] = value;
                mtdReDefinirConexaoString(strPersistSecurityInfoSQLServer);
            }
        }

        public string prpConnectTimeoutSQLServer
        {
            get
            {
                if (strConnectTimeoutSQLServer == null)
                {
                    strConnectTimeoutSQLServer = new string[2] { cntConnectTimeoutSQLServer[0], cntConnectTimeoutSQLServer[1] };
                }
                return strConnectTimeoutSQLServer[1];
            }
            set
            {
                if (strConnectTimeoutSQLServer == null)
                {
                    strConnectTimeoutSQLServer = new string[2] { cntConnectTimeoutSQLServer[0], cntConnectTimeoutSQLServer[1] };
                }
                strConnectTimeoutSQLServer[1] = value;
                mtdReDefinirConexaoString(strConnectTimeoutSQLServer);
            }
        }

        // Metodos de instancia do SQLServer

        public string[] mtdValidarConexaoDispositivoSQLServer(string Conexao)
        {
            strDriverSQLServer = mtdValidarConexao(Conexao, vetDriverSQLServer);
            return strDriverSQLServer;
        }

        public string[] mtdValidarConexaoProvedorSQLServer(string Conexao)
        {
            strProviderSQLServer = mtdValidarConexao(Conexao, vetProviderSQLServer);
            return strProviderSQLServer;
        }

        public string[] mtdValidarConexaoServidorSQLServer(string Conexao)
        {
            strServerSQLServer = mtdValidarConexao(Conexao, vetServerSQLServer);
            return strServerSQLServer;
        }

        public string[] mtdValidarConexaoBaseDadosSQLServer(string Conexao)
        {
            strDataBaseSQLServer = mtdValidarConexao(Conexao, vetDataBaseSQLServer);
            return strDataBaseSQLServer;
        }

        public string[] mtdValidarConexaoUsuarioSQLServer(string Conexao)
        {
            strUserIdSQLServer = mtdValidarConexao(Conexao, vetUserIdSQLServer);
            return strUserIdSQLServer;
        }

        public string[] mtdValidarConexaoSenhaSQLServer(string Conexao)
        {
            strPasswordSQLServer = mtdValidarConexao(Conexao, vetPasswordSQLServer);
            return strPasswordSQLServer;
        }

        public string[] mtdValidarConexaoSegurancaIntegradaSQLServer(string Conexao)
        {
            strIntegratedSecuritySQLServer = mtdValidarConexao(Conexao, vetIntegratedSecuritySQLServer);
            return strIntegratedSecuritySQLServer;
        }

        public string[] mtdValidarConexaoPersistenciaSegurancaSQLServer(string Conexao)
        {
            strPersistSecurityInfoSQLServer = mtdValidarConexao(Conexao, vetPersistSecurityInfoSQLServer);
            return strPersistSecurityInfoSQLServer;
        }

        public string[] mtdValidarConexaoTempoSaidaSQLServer(string Conexao)
        {
            strConnectTimeoutSQLServer = mtdValidarConexao(Conexao, vetConnectTimeoutSQLServer);
            return strConnectTimeoutSQLServer;
        }

        public string mtdValidarConexaoSQLServer(string Conexao)
        {
            string saida = string.Empty;

            prpTipoConexao = TipoConexao.Indisponivel;
            //if (strDriverSQLServer == null || strDriverSQLServer[1] == cntDriverSQLServer[1])
            //{
            mtdValidarConexaoDispositivoSQLServer(Conexao);
            //}
            if (strDriverSQLServer != null)
            {
                prpTipoConexao = TipoConexao.ConexaoSQLServerOdbc;
            }
            //if (strProviderSQLServer == null || strProviderSQLServer[1] == cntProviderSQLServer[1])
            //{
            mtdValidarConexaoProvedorSQLServer(Conexao);
            //}
            if (strProviderSQLServer != null)
            {
                prpTipoConexao = TipoConexao.ConexaoSQLServerOleDb;
            }
            //if (strServerSQLServer == null || strServerSQLServer[1] == cntServerSQLServer[1])
            //{
            mtdValidarConexaoServidorSQLServer(Conexao);
            //}
            //if (strDriverSQLServer == null && strServerSQLServer != null)
            //{
            prpTipoConexao = TipoConexao.ConexaoSQLServerNativa;
            //}
            //if (strDataBaseSQLServer == null || strDataBaseSQLServer[1] == cntDataBaseSQLServer[1])
            //{
            mtdValidarConexaoBaseDadosSQLServer(Conexao);
            //}
            //if (strUserIdSQLServer == null || strUserIdSQLServer[1] == cntUserIdSQLServer[1])
            //{
            mtdValidarConexaoUsuarioSQLServer(Conexao);
            //}
            //if (strPasswordSQLServer == null || strPasswordSQLServer[1] == cntPasswordSQLServer[1])
            //{
            mtdValidarConexaoSenhaSQLServer(Conexao);
            //}
            //if (strIntegratedSecuritySQLServer == null || strIntegratedSecuritySQLServer[1] == cntIntegratedSecuritySQLServer[1])
            //{
            mtdValidarConexaoSegurancaIntegradaSQLServer(Conexao);
            //}
            //if (strPersistSecurityInfoSQLServer == null || strPersistSecurityInfoSQLServer[1] == cntPersistSecurityInfoSQLServer[1])
            //{
            mtdValidarConexaoPersistenciaSegurancaSQLServer(Conexao);
            //}
            //if (strConnectTimeoutSQLServer == null || strConnectTimeoutSQLServer[1] == cntConnectTimeoutSQLServer[1])
            //{
            mtdValidarConexaoTempoSaidaSQLServer(Conexao);
            //}

            if (strDriverSQLServer != null)
            {
                saida += string.Format("{0}={1}; ", strDriverSQLServer[0], strDriverSQLServer[1]);
            }
            if (strProviderSQLServer != null)
            {
                saida += string.Format("{0}={1}; ", strProviderSQLServer[0], strProviderSQLServer[1]);
            }
            if (strServerSQLServer != null)
            {
                saida += string.Format("{0}={1}; ", strServerSQLServer[0], strServerSQLServer[1]);
            }
            if (strDataBaseSQLServer != null && blnPermitirBancoDadosSQLServer)
            {
                saida += string.Format("{0}={1}; ", strDataBaseSQLServer[0], strDataBaseSQLServer[1]);
            }
            if (strUserIdSQLServer != null)
            {
                saida += string.Format("{0}={1}; ", strUserIdSQLServer[0], strUserIdSQLServer[1]);
            }
            if (strPasswordSQLServer != null)
            {
                saida += string.Format("{0}={1}; ", strPasswordSQLServer[0], strPasswordSQLServer[1]);
            }
            if (strIntegratedSecuritySQLServer != null)
            {
                saida += string.Format("{0}={1}; ", strIntegratedSecuritySQLServer[0], strIntegratedSecuritySQLServer[1]);
            }
            if (strPersistSecurityInfoSQLServer != null)
            {
                saida += string.Format("{0}={1}; ", strPersistSecurityInfoSQLServer[0], strPersistSecurityInfoSQLServer[1]);
            }
            if (strConnectTimeoutSQLServer != null)
            {
                saida += string.Format("{0}={1};", strConnectTimeoutSQLServer[0], strConnectTimeoutSQLServer[1]);
            }
            return saida;
        }

        public string mtdDefinirStringConexaoSQLServer()
        {
            return mtdDefinirStringConexaoSQLServer(prpConexao, true);
        }

        public string mtdDefinirStringConexaoSQLServer(bool PermitirBancoDados)
        {
            return mtdDefinirStringConexaoSQLServer(prpConexao, PermitirBancoDados);
        }

        public string mtdDefinirStringConexaoSQLServer(string Conexao)
        {
            return mtdDefinirStringConexaoSQLServer(Conexao, true);
        }

        public string mtdDefinirStringConexaoSQLServer(string Conexao, bool PermitirBancoDados)
        {
            blnPermitirBancoDadosSQLServer = PermitirBancoDados;
            mtdValidarConexaoSQLServer(Conexao);
            return mtdDefinirStringConexaoSQLServer(prpTipoConexao,
                prpServerSQLServer,
                prpDataBaseSQLServer,
                prpUserIdSQLServer,
                prpPasswordSQLServer,
                prpIntegratedSecuritySQLServer,
                prpPersistSecurityInfoSQLServer,
                prpConnectTimeoutSQLServer);
        }

        public string mtdDefinirStringConexaoSQLServer(TipoConexao TipoConexao, string Server)
        {
            return mtdDefinirStringConexaoSQLServer(TipoConexao, Server, cntDataBaseSQLServer[1], cntUserIdSQLServer[1], cntPasswordSQLServer[1], "True",
                cntPersistSecurityInfoSQLServer[1], cntConnectTimeoutSQLServer[1]);
        }

        public string mtdDefinirStringConexaoSQLServer(TipoConexao TipoConexao, string Server, string DataBase)
        {
            return mtdDefinirStringConexaoSQLServer(TipoConexao, Server, DataBase, cntUserIdSQLServer[1], cntPasswordSQLServer[1], "True", cntPersistSecurityInfoSQLServer[1],
                cntConnectTimeoutSQLServer[1]);
        }

        public string mtdDefinirStringConexaoSQLServer(TipoConexao TipoConexao, string Server, string DataBase, bool PersistSecurityInfo, int ConnectTimeout)
        {
            return mtdDefinirStringConexaoSQLServer(TipoConexao, Server, DataBase, cntUserIdSQLServer[1], cntPasswordSQLServer[1], "True", PersistSecurityInfo.ToString(),
                ConnectTimeout.ToString());
        }

        public string mtdDefinirStringConexaoSQLServer(TipoConexao TipoConexao, string Server, string DataBase, string UserId, string Password)
        {
            return mtdDefinirStringConexaoSQLServer(TipoConexao, Server, DataBase, UserId, Password, cntIntegratedSecuritySQLServer[1], cntPersistSecurityInfoSQLServer[1],
                cntConnectTimeoutSQLServer[1]);
        }

        public string mtdDefinirStringConexaoSQLServer(TipoConexao TipoConexao, string Server, string DataBase, string UserId, string Password, bool PersistSecurityInfo)
        {
            return mtdDefinirStringConexaoSQLServer(TipoConexao, Server, DataBase, UserId, Password, cntIntegratedSecuritySQLServer[1], PersistSecurityInfo.ToString(),
                cntConnectTimeoutSQLServer[1]);
        }

        public string mtdDefinirStringConexaoSQLServer(TipoConexao TipoConexao, string Server, string DataBase, string UserId, string Password, int ConnectTimeout)
        {
            return mtdDefinirStringConexaoSQLServer(TipoConexao, Server, DataBase, UserId, Password, cntIntegratedSecuritySQLServer[1], cntPersistSecurityInfoSQLServer[1],
                ConnectTimeout.ToString());
        }

        public string mtdDefinirStringConexaoSQLServer(TipoConexao TipoConexao, string Server, string DataBase, string UserId, string Password, bool PersistSecurityInfo, int ConnectTimeout)
        {
            return mtdDefinirStringConexaoSQLServer(TipoConexao, Server, DataBase, UserId, Password, cntIntegratedSecuritySQLServer[1], PersistSecurityInfo.ToString(),
                ConnectTimeout.ToString());
        }

        public string mtdDefinirStringConexaoSQLServer(TipoConexao TipoConexao, string Server, string DataBase, string UserId, string Password, string IntegratedSecurity, string PersistSecurityInfo, string ConnectTimeout)
        {
            bool blnTipoIntegratedSecurity = false;
            bool blnPersistSecurityInfo = false;

            switch (IntegratedSecurity.ToLower())
            {
                case "false":
                    blnTipoIntegratedSecurity = false;
                    break;
                case "no":
                    blnTipoIntegratedSecurity = false;
                    break;
                case "sspi":
                    blnTipoIntegratedSecurity = true;
                    break;
                case "true":
                    blnTipoIntegratedSecurity = true;
                    break;
                case "yes":
                    blnTipoIntegratedSecurity = true;
                    break;
            }
            switch (PersistSecurityInfo.ToLower())
            {
                case "false":
                    blnPersistSecurityInfo = false;
                    break;
                case "no":
                    blnPersistSecurityInfo = false;
                    break;
                case "true":
                    blnPersistSecurityInfo = true;
                    break;
                case "yes":
                    blnPersistSecurityInfo = true;
                    break;
            }
            return mtdDefinirStringConexaoSQLServer(TipoConexao,
                Server != string.Empty ? Server : cntServerSQLServer[1],
                DataBase != string.Empty ? DataBase : cntDataBaseSQLServer[1],
                UserId != string.Empty ? UserId : cntUserIdSQLServer[1],
                Password != string.Empty ? Password : cntPasswordSQLServer[1],
                blnTipoIntegratedSecurity,
                blnPersistSecurityInfo,
                System.Convert.ToInt32(ConnectTimeout != string.Empty ? ConnectTimeout : cntConnectTimeoutSQLServer[1]));
        }

        public string mtdDefinirStringConexaoSQLServer(TipoConexao TipoConexao, string Server, string DataBase, string UserId, string Password, bool IntegratedSecurity, bool PersistSecurityInfo, int ConnectTimeout)
        {
            string saida = string.Empty;
            switch (TipoConexao)
            {
                case TipoConexao.ConexaoSQLServerOdbc:
                    if (DataBase != string.Empty)
                    {
                        DataBase = string.Format("DataBase={0}; ", DataBase);
                    }
                    if (IntegratedSecurity)
                    {
                        saida = string.Format(cntStringConexaoSQLServerOdbc_SegurancaConfianca.Replace(string.Format("Driver={0}; ", cntDriverSQLServer[1]), string.Empty).Replace("DataBase={1}; ", "{1}"), Server, DataBase, IntegratedSecurity, PersistSecurityInfo, ConnectTimeout);
                    }
                    else
                    {
                        saida = string.Format(cntStringConexaoSQLServerOdbc_SegurancaPadrao.Replace(string.Format("Driver={0}; ", cntDriverSQLServer[1]), string.Empty).Replace("DataBase={1}; ", "{1}"), Server, DataBase, UserId, Password, IntegratedSecurity, PersistSecurityInfo, ConnectTimeout);
                    }
                    saida = string.Format("{0}={1}; ", strDriverSQLServer[0], strDriverSQLServer[1]) + saida;
                    saida = mtdEliminarAtribudoIndisponivelStringConexao(saida);
                    prpTipoSistemaGerenciadorBancoDadosRelacional = TipoSistemaGerenciadorBancoDadosRelacional.Odbc;
                    break;
                case TipoConexao.ConexaoSQLServerOleDb:
                    if (DataBase != string.Empty)
                    {
                        DataBase = string.Format("DataBase={0}; ", DataBase);
                    }
                    if (IntegratedSecurity)
                    {
                        saida = string.Format(cntStringConexaoSQLServerOleDb_SegurancaConfianca.Replace(string.Format("Provider={0}; ", cntProviderSQLServer[1]), string.Empty).Replace("DataBase={1}; ", "{1}"), Server, DataBase, IntegratedSecurity, PersistSecurityInfo, ConnectTimeout);
                    }
                    else
                    {
                        saida = string.Format(cntStringConexaoSQLServerOleDb_SegurancaPadrao.Replace(string.Format("Provider={0}; ", cntProviderSQLServer[1]), string.Empty).Replace("DataBase={1}; ", "{1}"), Server, DataBase, UserId, Password, IntegratedSecurity, PersistSecurityInfo, ConnectTimeout);
                    }
                    saida = string.Format("{0}={1}; ", strProviderSQLServer[0], strProviderSQLServer[1]) + saida;
                    saida = mtdEliminarAtribudoIndisponivelStringConexao(saida);
                    prpTipoSistemaGerenciadorBancoDadosRelacional = TipoSistemaGerenciadorBancoDadosRelacional.OleDb;
                    break;
                case TipoConexao.ConexaoSQLServerNativa:
                    if (DataBase != string.Empty)
                    {
                        DataBase = string.Format("DataBase={0}; ", DataBase);
                    }
                    if (IntegratedSecurity)
                    {
                        saida = string.Format(cntStringConexaoSQLServerNativa_SegurancaConfianca.Replace("DataBase={1}; ", "{1}"), Server, DataBase, IntegratedSecurity, PersistSecurityInfo, ConnectTimeout);
                    }
                    else
                    {
                        saida = string.Format(cntStringConexaoSQLServerNativa_SegurancaPadrao.Replace("DataBase={1}; ", "{1}"), Server, DataBase, UserId, Password, IntegratedSecurity, PersistSecurityInfo, ConnectTimeout);
                    }
                    saida = mtdEliminarAtribudoIndisponivelStringConexao(saida);
                    prpTipoSistemaGerenciadorBancoDadosRelacional = TipoSistemaGerenciadorBancoDadosRelacional.SQLServer;
                    break;
                case TipoConexao.Indisponivel:
                    saida = TipoConexao.Indisponivel.ToString();
                    prpTipoSistemaGerenciadorBancoDadosRelacional = TipoSistemaGerenciadorBancoDadosRelacional.Indisponivel;
                    break;
            }
            prpConexao = mtdValidarConexaoSQLServer(saida);
            return prpConexao.Trim();
        }
    }

    public partial class clsBancoDados
    {
        // Variaveis do SQLServer
        private System.Data.SqlClient.SqlConnection objConexaoSQLServer = new System.Data.SqlClient.SqlConnection();
        private System.Data.SqlClient.SqlCommand objComandoSQLServer = new System.Data.SqlClient.SqlCommand();
        private System.Data.SqlClient.SqlDataAdapter objAdaptadorDadosSQLServer = new System.Data.SqlClient.SqlDataAdapter();
        private System.Data.SqlClient.SqlDataReader objLeitorDadosSQLServer;

        // Propriedades do SQLServer

        public System.Data.SqlClient.SqlConnection prpConexaoSQLServer
        {
            get
            {
                return objConexaoSQLServer;
            }
            set
            {
                objConexaoSQLServer = value;
            }
        }

        public System.Data.SqlClient.SqlCommand prpComandoSQLServer
        {
            get
            {
                return objComandoSQLServer;
            }
            set
            {
                objComandoSQLServer = value;
            }
        }

        public System.Data.SqlClient.SqlDataAdapter prpAdaptadorDadosSQLServer
        {
            get
            {
                return objAdaptadorDadosSQLServer;
            }
            set
            {
                objAdaptadorDadosSQLServer = value;
            }
        }

        public System.Data.SqlClient.SqlDataReader prpLeitorDadosSQLServer
        {
            get
            {
                return objLeitorDadosSQLServer;
            }
            set
            {
                objLeitorDadosSQLServer = value;
            }
        }

        public void mtdExecutarParametroComandoSQLServer
            (
            string NomeParametro,
            object Valor
            )
        {
            System.Data.SqlClient.SqlParameter objParametroSQLServer =
                new System.Data.SqlClient.SqlParameter
                    (
                    NomeParametro,
                    Valor
                    );
            prpComandoSQLServer.Parameters.Add(objParametroSQLServer);
        }

        public void mtdExecutarParametroComandoSQLServer
           (
           string NomeParametro,
           System.Data.SqlDbType TipoSqlDb,
           object Valor
           )
        {
            System.Data.SqlClient.SqlParameter objParametroSQLServer =
              new System.Data.SqlClient.SqlParameter
                  (
                  NomeParametro,
                  TipoSqlDb
                  );
            objParametroSQLServer.Value = Valor;
            prpComandoSQLServer.Parameters.Add(objParametroSQLServer);
        }

        public void mtdExecutarParametroComandoSQLServer
           (
           string NomeParametro,
           System.Data.SqlDbType TipoSqlDb,
           object Valor,
           int Tamanho
           )
        {
            System.Data.SqlClient.SqlParameter objParametroSQLServer =
              new System.Data.SqlClient.SqlParameter
                  (
                  NomeParametro,
                  TipoSqlDb,
                  Tamanho
                  );
            objParametroSQLServer.Value = Valor;
            prpComandoSQLServer.Parameters.Add(objParametroSQLServer);
        }

        public void mtdExecutarParametroComandoSQLServer
            (
            string NomeParametro,
            System.Data.SqlDbType TipoSqlDb,
            object Valor,
            int Tamanho,
            string ColunaOrigem
            )
        {
            System.Data.SqlClient.SqlParameter objParametroSQLServer =
                new System.Data.SqlClient.SqlParameter
                    (
                    NomeParametro,
                    TipoSqlDb,
                    Tamanho,
                    ColunaOrigem
                    );
            objParametroSQLServer.Value = Valor;
            prpComandoSQLServer.Parameters.Add(objParametroSQLServer);
        }

        public void mtdExecutarParametroComandoSQLServer
            (
            System.Data.DataRowVersion OrigemVersao,
            string NomeParametro,
            System.Data.SqlDbType TipoSqlDb,
            System.Data.ParameterDirection DirecaoParametro,
            string OrigemColuna,
            object Valor,
            int Tamanho
            )
        {
            System.Data.SqlClient.SqlParameter objParametroSQLServer =
                new System.Data.SqlClient.SqlParameter
                    (
                    NomeParametro,
                    TipoSqlDb,
                    Tamanho,
                    OrigemColuna
                    );
            objParametroSQLServer.SourceVersion = OrigemVersao;
            objParametroSQLServer.Direction = DirecaoParametro;
            objParametroSQLServer.Value = Valor;
            prpComandoSQLServer.Parameters.Add(objParametroSQLServer);
        }
    }

    public partial class clsImplementacaoBancoDados
    {
        // SQLServer

        public enum OpcaoAlterarBancoDadosSQLServer
        {
            AUTHORIZATION_ON,
            MODIFY_FILE_LOGICAL,
            MODIFY_FILE_PHYSICAL,
            MODIFY_NAME
        }

        public bool mtdAlterarBancoDadosSQLServer(OpcaoAlterarBancoDadosSQLServer OpcaoAlterarBancoDadosSQLServer, string NovoAtributo)
        {
            return mtdAlterarBancoDadosSQLServer(prpDataBaseSQLServer, OpcaoAlterarBancoDadosSQLServer, NovoAtributo);
        }

        public bool mtdAlterarBancoDadosSQLServer(OpcaoAlterarBancoDadosSQLServer OpcaoAlterarBancoDadosSQLServer, string AntigoAtributo, string NovoAtributo)
        {
            return mtdAlterarBancoDadosSQLServer(prpDataBaseSQLServer, OpcaoAlterarBancoDadosSQLServer, AntigoAtributo, NovoAtributo);
        }

        public bool mtdAlterarBancoDadosSQLServer(OpcaoAlterarBancoDadosSQLServer OpcaoAlterarBancoDadosSQLServer, string EnderecoBancoDados,
            string AntigoAtributo, string NovoAtributo)
        {
            return mtdAlterarBancoDadosSQLServer(prpDataBaseSQLServer, OpcaoAlterarBancoDadosSQLServer, EnderecoBancoDados, AntigoAtributo, NovoAtributo);
        }

        public bool mtdAlterarBancoDadosSQLServer(string BancoDados, OpcaoAlterarBancoDadosSQLServer OpcaoAlterarBancoDadosSQLServer, string NovoAtributo)
        {
            bool saida = true;

            prpDataBaseSQLServer = BancoDados;
            mtdDefinirStringConexaoSQLServer();
            if (mtdAbrirConexao(mtdDefinirStringConexaoSQLServer(prpConexao, false), prpTipoSistemaGerenciadorBancoDadosRelacional))
            {
                mtdFecharConexao();
            }
            if (OpcaoAlterarBancoDadosSQLServer == OpcaoAlterarBancoDadosSQLServer.MODIFY_FILE_LOGICAL ||
                OpcaoAlterarBancoDadosSQLServer == OpcaoAlterarBancoDadosSQLServer.MODIFY_FILE_PHYSICAL ||
                OpcaoAlterarBancoDadosSQLServer == OpcaoAlterarBancoDadosSQLServer.MODIFY_NAME)
            {
                prpDataBaseSQLServer = NovoAtributo;
                mtdDefinirStringConexaoSQLServer();
                if (mtdAbrirConexao(mtdDefinirStringConexaoSQLServer(prpConexao, false), prpTipoSistemaGerenciadorBancoDadosRelacional))
                {
                    mtdFecharConexao();
                }
            }
            saida &= mtdAbrirConexao();
            //mtdExecutarComando(string.Format(@"ALTER DATABASE {0} SET OFFLINE", Nome));
            switch (OpcaoAlterarBancoDadosSQLServer)
            {
                case OpcaoAlterarBancoDadosSQLServer.AUTHORIZATION_ON:
                    saida &= mtdExecutarComando(string.Format(@"ALTER {1} DATABASE::{0} TO {2}", BancoDados, OpcaoAlterarBancoDadosSQLServer.ToString().Replace('_', ' '),
                                   NovoAtributo));
                    break;
                case OpcaoAlterarBancoDadosSQLServer.MODIFY_NAME:
                    saida &= mtdExecutarComando(string.Format(@"ALTER DATABASE {0} {1} = {2}", BancoDados, OpcaoAlterarBancoDadosSQLServer.ToString().Replace('_', ' '),
                            NovoAtributo));
                    break;
            }
            //mtdExecutarComando(string.Format(@"ALTER DATABASE {0} SET ONLINE", Nome));
            mtdFecharConexao();

            return saida;
        }

        public bool mtdAlterarBancoDadosSQLServer(string BancoDados, OpcaoAlterarBancoDadosSQLServer OpcaoAlterarBancoDadosSQLServer, string AntigoAtributo,
            string NovoAtributo)
        {
            bool saida = true;

            prpDataBaseSQLServer = BancoDados;
            mtdDefinirStringConexaoSQLServer();
            if (mtdAbrirConexao(mtdDefinirStringConexaoSQLServer(prpConexao, false), prpTipoSistemaGerenciadorBancoDadosRelacional))
            {
                mtdFecharConexao();
            }
            if (OpcaoAlterarBancoDadosSQLServer == OpcaoAlterarBancoDadosSQLServer.MODIFY_FILE_LOGICAL ||
                OpcaoAlterarBancoDadosSQLServer == OpcaoAlterarBancoDadosSQLServer.MODIFY_FILE_PHYSICAL ||
                OpcaoAlterarBancoDadosSQLServer == OpcaoAlterarBancoDadosSQLServer.MODIFY_NAME)
            {
                prpDataBaseSQLServer = NovoAtributo;
                mtdDefinirStringConexaoSQLServer();
                if (mtdAbrirConexao(mtdDefinirStringConexaoSQLServer(prpConexao, false), prpTipoSistemaGerenciadorBancoDadosRelacional))
                {
                    mtdFecharConexao();
                }
            }
            saida &= mtdAbrirConexao();
            //mtdExecutarComando(string.Format(@"ALTER DATABASE {0} SET OFFLINE", Nome));
            switch (OpcaoAlterarBancoDadosSQLServer)
            {
                case OpcaoAlterarBancoDadosSQLServer.AUTHORIZATION_ON:
                    saida &= mtdAlterarBancoDadosSQLServer(BancoDados, OpcaoAlterarBancoDadosSQLServer, NovoAtributo);
                    break;
                case OpcaoAlterarBancoDadosSQLServer.MODIFY_NAME:
                    saida &= mtdAlterarBancoDadosSQLServer(BancoDados, OpcaoAlterarBancoDadosSQLServer, NovoAtributo);
                    break;
                case OpcaoAlterarBancoDadosSQLServer.MODIFY_FILE_LOGICAL:
                    saida &= mtdExecutarComando(string.Format(@"ALTER DATABASE {0} {1} (NAME = {2}, NEWNAME = {3})", BancoDados,
                        OpcaoAlterarBancoDadosSQLServer.ToString().Replace("_LOGICAL", string.Empty).Replace('_', ' '), AntigoAtributo, NovoAtributo));
                    saida &= mtdExecutarComando(string.Format(@"ALTER DATABASE {0} {1} (NAME = {2}_log, NEWNAME = {3}_log)", BancoDados,
                        OpcaoAlterarBancoDadosSQLServer.ToString().Replace("_LOGICAL", string.Empty).Replace('_', ' '), AntigoAtributo, NovoAtributo));
                    break;
            }
            //mtdExecutarComando(string.Format(@"ALTER DATABASE {0} SET ONLINE", Nome));
            mtdFecharConexao();

            return saida;
        }

        public bool mtdAlterarBancoDadosSQLServer(string BancoDados, OpcaoAlterarBancoDadosSQLServer OpcaoAlterarBancoDadosSQLServer,
            string EnderecoBancoDados, string AntigoAtributo, string NovoAtributo)
        {
            bool saida = true;

            Exception ex = new Exception();
            int intContador = 0;
            int intNumeroTentativa = 10;
            prpDataBaseSQLServer = BancoDados;
            mtdDefinirStringConexaoSQLServer();
            if (mtdAbrirConexao(mtdDefinirStringConexaoSQLServer(prpConexao, false), prpTipoSistemaGerenciadorBancoDadosRelacional))
            {
                mtdFecharConexao();
            }
            if (OpcaoAlterarBancoDadosSQLServer == OpcaoAlterarBancoDadosSQLServer.MODIFY_FILE_LOGICAL ||
                OpcaoAlterarBancoDadosSQLServer == OpcaoAlterarBancoDadosSQLServer.MODIFY_FILE_PHYSICAL ||
                OpcaoAlterarBancoDadosSQLServer == OpcaoAlterarBancoDadosSQLServer.MODIFY_NAME)
            {
                prpDataBaseSQLServer = NovoAtributo;
                mtdDefinirStringConexaoSQLServer();
                if (mtdAbrirConexao(mtdDefinirStringConexaoSQLServer(prpConexao, false), prpTipoSistemaGerenciadorBancoDadosRelacional))
                {
                    mtdFecharConexao();
                }
            }
            saida &= mtdAbrirConexao();
            //mtdExecutarComando(string.Format(@"ALTER DATABASE {0} SET OFFLINE", Nome));
            switch (OpcaoAlterarBancoDadosSQLServer)
            {
                case OpcaoAlterarBancoDadosSQLServer.AUTHORIZATION_ON:
                    saida &= mtdAlterarBancoDadosSQLServer(BancoDados, OpcaoAlterarBancoDadosSQLServer, NovoAtributo);
                    break;
                case OpcaoAlterarBancoDadosSQLServer.MODIFY_NAME:
                    saida &= mtdAlterarBancoDadosSQLServer(BancoDados, OpcaoAlterarBancoDadosSQLServer, NovoAtributo);
                    break;
                case OpcaoAlterarBancoDadosSQLServer.MODIFY_FILE_LOGICAL:
                    saida &= mtdAlterarBancoDadosSQLServer(BancoDados, OpcaoAlterarBancoDadosSQLServer, AntigoAtributo, NovoAtributo);
                    break;
                case OpcaoAlterarBancoDadosSQLServer.MODIFY_FILE_PHYSICAL:
                    saida &= mtdExecutarComando(string.Format(@"ALTER DATABASE {0} {1} (NAME = {2}, FILENAME = '{3}.mdf')", BancoDados, OpcaoAlterarBancoDadosSQLServer.ToString().Replace("_PHYSICAL", string.Empty).Replace('_', ' '), AntigoAtributo, EnderecoBancoDados + NovoAtributo));
                    saida &= mtdExecutarComando(string.Format(@"ALTER DATABASE {0} {1} (NAME = {2}_log, FILENAME = '{3}_log.ldf')", BancoDados, OpcaoAlterarBancoDadosSQLServer.ToString().Replace("_PHYSICAL", string.Empty).Replace('_', ' '), AntigoAtributo, EnderecoBancoDados + NovoAtributo));
                    while (ex.Message == "The process cannot access the file because it is being used by another process" && intContador <= intNumeroTentativa)
                    {
                        System.IO.File.Move(EnderecoBancoDados + AntigoAtributo + ".mdf", EnderecoBancoDados + NovoAtributo + ".mdf");
                        System.IO.File.Move(EnderecoBancoDados + AntigoAtributo + "_log.ldf", EnderecoBancoDados + NovoAtributo + "_log.ldf");
                        intContador++;
                        saida &= true;
                    }
                    if (intContador == intNumeroTentativa)
                    {
                        saida = false;
                    }
                    break;
            }
            //mtdExecutarComando(string.Format(@"ALTER DATABASE {0} SET ONLINE", Nome));
            mtdFecharConexao();

            return saida;
        }

        public bool mtdCriarBancoDadosSQLServer()
        {
            return mtdCriarBancoDadosSQLServer(prpDataBaseSQLServer);
        }

        public bool mtdCriarBancoDadosSQLServer(string Endereco, string TamanhoArquivo, string TamanhoMaximoArquivo, string TamanhoExpansivelArquivo, string TamanhoLog, string TamanhoMaximoLog, string TamanhoExpansivelLog)
        {
            return mtdCriarBancoDadosSQLServer(prpDataBaseSQLServer, Endereco, TamanhoArquivo, TamanhoMaximoArquivo, TamanhoExpansivelArquivo, TamanhoLog, TamanhoMaximoLog, TamanhoExpansivelLog);
        }

        public bool mtdCriarBancoDadosSQLServer(string BancoDados)
        {
            bool saida = true;

            prpDataBaseSQLServer = BancoDados;
            mtdDefinirStringConexaoSQLServer();
            mtdFecharConexao();
            saida &= mtdAbrirConexao(mtdDefinirStringConexaoSQLServer(prpConexao, false), prpTipoSistemaGerenciadorBancoDadosRelacional);
            saida &= mtdExecutarComando(string.Format(@"CREATE DATABASE {0};", BancoDados));
            mtdDefinirStringConexaoSQLServer(prpConexao, true);
            mtdFecharConexao();

            return saida;
        }

        public bool mtdCriarBancoDadosSQLServer(string BancoDados, string Endereco, string TamanhoArquivo, string TamanhoMaximoArquivo, string TamanhoExpansivelArquivo, string TamanhoLog, string TamanhoMaximoLog, string TamanhoExpansivelLog)
        {
            bool saida = true;

            prpDataBaseSQLServer = BancoDados;
            mtdDefinirStringConexaoSQLServer();
            mtdFecharConexao();
            saida &= mtdAbrirConexao(mtdDefinirStringConexaoSQLServer(prpConexao, false), prpTipoSistemaGerenciadorBancoDadosRelacional);
            // objBancoDados.prpComando = @"CREATE DATABASE dbTeste ON PRIMARY (NAME=Teste, FILENAME = 'C:\Program Files (x86)\Microsoft SQL Server\MSSQL.1\MSSQL\Data\dbTeste.mdf', SIZE=4, MAXSIZE=10, FILEGROWTH=10%) LOG ON (NAME=Teste_log, FILENAME='C:\Program Files (x86)\Microsoft SQL Server\MSSQL.1\MSSQL\Data\dbTeste_log.ldf', SIZE=3, MAXSIZE=20,FILEGROWTH=1);";
            saida &= mtdExecutarComando(string.Format(@"CREATE DATABASE {0} ON (NAME = {0}, FILENAME = '{1}{0}.mdf', SIZE = {2}, MAXSIZE = {3}, FILEGROWTH = {4}) LOG ON (NAME={0}_log, FILENAME='{1}{0}.ldf', SIZE={5}, MAXSIZE={6}, FILEGROWTH={7});", BancoDados, Endereco, TamanhoArquivo, TamanhoMaximoArquivo, TamanhoExpansivelArquivo, TamanhoLog, TamanhoMaximoLog, TamanhoExpansivelLog));
            mtdDefinirStringConexaoSQLServer(prpConexao, true);
            mtdFecharConexao();

            return saida;
        }

        public bool mtdDeletarBancoDadosSQLServer()
        {
            return mtdDeletarBancoDadosSQLServer(prpDataBaseSQLServer);
        }

        public bool mtdDeletarBancoDadosSQLServer(string BancoDados)
        {
            bool saida = true;

            prpDataBaseSQLServer = BancoDados;
            mtdDefinirStringConexaoSQLServer();
            if (mtdAbrirConexao(mtdDefinirStringConexaoSQLServer(prpConexao, false), prpTipoSistemaGerenciadorBancoDadosRelacional))
            {
                mtdFecharConexao();
            }
            saida &= mtdAbrirConexao();
            saida &= mtdExecutarComando(string.Format(@"DROP DATABASE {0};", BancoDados));
            mtdFecharConexao();

            return saida;
        }

        private bool mtdAtualizarDadosParametroComandoSQLServerValor(string NomeTabela, object[,] Campos_Dados_CampoBase_Operacao_DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 1;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            StringBuilder strTexto = new StringBuilder();
            string[] vetNomeColunas = null;
            object[] vetRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados_CampoBase_Operacao_DadoBase != null)
            {
                if (Campos_Dados_CampoBase_Operacao_DadoBase.GetLength(0) >= intLinhasAdicionais + 1)
                {
                    for (int linha = Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0); linha <= Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(0); linha++)
                    {
                        switch (linha)
                        {
                            case (0):
                                vetNomeColunas = new string[Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) + 1];
                                break;
                            default:
                                strCampoBase = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha, Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 2];
                                strOperacao = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha, Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 1];
                                objDadoBase = Campos_Dados_CampoBase_Operacao_DadoBase[linha, Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1)];
                                vetRegistrosColunas = new object[Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) + 1];
                                break;
                        }

                        strTexto = new StringBuilder();
                        prpComandoSQLServer.Parameters.Clear();

                        for (int coluna = Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(1);
                            coluna <=
                            (
                            (linha == Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0))
                            ?
                            Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1)
                            :
                            Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 3
                            );
                            coluna++)
                        {
                            switch (linha)
                            {
                                case (0):
                                    vetNomeColunas[coluna] = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha, coluna];
                                    break;
                                default:
                                    vetRegistrosColunas[coluna] = (object)Campos_Dados_CampoBase_Operacao_DadoBase[linha, coluna];

                                    mtdExecutarParametroComandoSQLServer
                                        (
                                        vetNomeColunas[coluna],
                                        vetRegistrosColunas[coluna]
                                        );

                                    strTexto.Append
                                        (
                                        string.Format
                                        (
                                        (coluna == Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 3) ?
                                        "{0} = @{1}" :
                                        "{0} = @{1}, ",
                                        vetNomeColunas[coluna],
                                        vetNomeColunas[coluna]
                                        )
                                        );
                                    break;
                            }
                        }
                        if (linha >= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais)
                        {
                            saida &= mtdExecutarComando(
                                string.Format("UPDATE {0} SET {1} WHERE {2} {3} {4};", NomeTabela, strTexto, strCampoBase, strOperacao, objDadoBase));
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        private bool mtdAtualizarDadosParametroComandoSQLServerValorTipo(string NomeTabela, object[,] Campos_Dados_CampoBase_Operacao_DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 2;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            StringBuilder strTexto = new StringBuilder();
            string[] vetNomeColunas = null;
            System.Data.SqlDbType[] vetTipoColunas = null;
            object[] vetRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados_CampoBase_Operacao_DadoBase != null)
            {
                if (Campos_Dados_CampoBase_Operacao_DadoBase.GetLength(0) >= intLinhasAdicionais + 1)
                {
                    for (int linha = Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0); linha <= Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(0); linha++)
                    {
                        switch (linha)
                        {
                            case (0):
                                vetNomeColunas = new string[Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) + 1];
                                break;
                            case (1):
                                vetTipoColunas = new System.Data.SqlDbType[Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) + 1];
                                break;
                            default:
                                strCampoBase = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha, Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 2];
                                strOperacao = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha, Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 1];
                                objDadoBase = Campos_Dados_CampoBase_Operacao_DadoBase[linha, Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1)];
                                vetRegistrosColunas = new object[Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) + 1];
                                break;
                        }

                        strTexto = new StringBuilder();
                        prpComandoSQLServer.Parameters.Clear();

                        for (int coluna = Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(1);
                            coluna <=
                            (
                            (linha == Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0))
                            ?
                            Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1)
                            :
                            Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 3
                            );
                            coluna++)
                        {
                            switch (linha)
                            {
                                case (0):
                                    vetNomeColunas[coluna] = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha, coluna];
                                    break;
                                case (1):
                                    vetTipoColunas[coluna] = (System.Data.SqlDbType)Campos_Dados_CampoBase_Operacao_DadoBase[linha, coluna];
                                    break;
                                default:
                                    vetRegistrosColunas[coluna] = (object)Campos_Dados_CampoBase_Operacao_DadoBase[linha, coluna];

                                    mtdExecutarParametroComandoSQLServer
                                        (
                                        vetNomeColunas[coluna],
                                        vetTipoColunas[coluna],
                                        vetRegistrosColunas[coluna]
                                        );

                                    strTexto.Append
                                        (
                                        string.Format
                                        (
                                        (coluna == Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 3) ?
                                        "{0} = @{1}" :
                                        "{0} = @{1}, ",
                                        vetNomeColunas[coluna],
                                        vetNomeColunas[coluna]
                                        )
                                        );
                                    break;
                            }
                        }
                        if (linha >= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais)
                        {
                            saida &= mtdExecutarComando(
                                string.Format("UPDATE {0} SET {1} WHERE {2} {3} {4};", NomeTabela, strTexto, strCampoBase, strOperacao, objDadoBase));
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        private bool mtdAtualizarDadosParametroComandoSQLServerValorTipoTamanho(string NomeTabela, object[,] Campos_Dados_CampoBase_Operacao_DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 3;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            StringBuilder strTexto = new StringBuilder();
            string[] vetNomeColunas = null;
            System.Data.SqlDbType[] vetTipoColunas = null;
            int[] vetTamanhoColunas = null;
            object[] vetRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados_CampoBase_Operacao_DadoBase != null)
            {
                if (Campos_Dados_CampoBase_Operacao_DadoBase.GetLength(0) >= intLinhasAdicionais + 1)
                {
                    for (int linha = Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0); linha <= Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(0); linha++)
                    {
                        switch (linha)
                        {
                            case (0):
                                vetNomeColunas = new string[Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) + 1];
                                break;
                            case (1):
                                vetTipoColunas = new System.Data.SqlDbType[Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) + 1];
                                break;
                            case (2):
                                vetTamanhoColunas = new int[Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) + 1];
                                break;
                            default:
                                strCampoBase = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha, Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 2];
                                strOperacao = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha, Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 1];
                                objDadoBase = Campos_Dados_CampoBase_Operacao_DadoBase[linha, Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1)];
                                vetRegistrosColunas = new object[Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) + 1];
                                break;
                        }

                        strTexto = new StringBuilder();
                        prpComandoSQLServer.Parameters.Clear();

                        for (int coluna = Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(1);
                            coluna <=
                            (
                            (linha == Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0))
                            ?
                            Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1)
                            :
                            Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 3
                            );
                            coluna++)
                        {
                            switch (linha)
                            {
                                case (0):
                                    vetNomeColunas[coluna] = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha, coluna];
                                    break;
                                case (1):
                                    vetTipoColunas[coluna] = (System.Data.SqlDbType)Campos_Dados_CampoBase_Operacao_DadoBase[linha, coluna];
                                    break;
                                case (2):
                                    vetTamanhoColunas[coluna] = (int)Campos_Dados_CampoBase_Operacao_DadoBase[linha, coluna];
                                    break;
                                default:
                                    vetRegistrosColunas[coluna] = (object)Campos_Dados_CampoBase_Operacao_DadoBase[linha, coluna];

                                    mtdExecutarParametroComandoSQLServer
                                        (
                                        vetNomeColunas[coluna],
                                        vetTipoColunas[coluna],
                                        vetRegistrosColunas[coluna],
                                        vetTamanhoColunas[coluna]
                                        );

                                    strTexto.Append
                                        (
                                        string.Format
                                        (
                                        (coluna == Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 3) ?
                                        "{0} = @{1}" :
                                        "{0} = @{1}, ",
                                        vetNomeColunas[coluna],
                                        vetNomeColunas[coluna]
                                        )
                                        );
                                    break;
                            }
                        }
                        if (linha >= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais)
                        {
                            saida &= mtdExecutarComando(
                                string.Format("UPDATE {0} SET {1} WHERE {2} {3} {4};", NomeTabela, strTexto, strCampoBase, strOperacao, objDadoBase));
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        public bool mtdAtualizarDadosParametroComandoSQLServer(string NomeTabela, object[,] Campos_Dados_CampoBase_Operacao_DadoBase, enmModoParametroComando ModoParametroComando)
        {
            bool saida = false;
            switch (ModoParametroComando)
            {
                case enmModoParametroComando.Valor:
                    mtdAtualizarDadosParametroComandoSQLServerValor(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase);
                    break;
                case enmModoParametroComando.ValorTipo:
                    mtdAtualizarDadosParametroComandoSQLServerValorTipo(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase);
                    break;
                case enmModoParametroComando.ValorTipoTamanho:
                    mtdAtualizarDadosParametroComandoSQLServerValorTipoTamanho(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase);
                    break;
            }
            return saida;
        }

        private bool mtdAtualizarDadosParametroComandoSQLServerValor(string NomeTabela, object[][] Campos_Dados_CampoBase_Operacao_DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 1;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            StringBuilder strTexto = new StringBuilder();
            string[] vetNomeColunas = null;
            object[] vetRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados_CampoBase_Operacao_DadoBase != null)
            {
                if (Campos_Dados_CampoBase_Operacao_DadoBase.GetLength(0) >= intLinhasAdicionais + 1)
                {
                    for (int linha = Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0); linha <= Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(0); linha++)
                    {
                        if (Campos_Dados_CampoBase_Operacao_DadoBase[linha] != null)
                        {
                            switch (linha)
                            {
                                case (0):
                                    vetNomeColunas = new string[Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) + 1];
                                    break;
                                default:
                                    strCampoBase = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) - 2];
                                    strOperacao = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) - 1];
                                    objDadoBase = Campos_Dados_CampoBase_Operacao_DadoBase[linha][Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0)];
                                    vetRegistrosColunas = new object[Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) + 1];
                                    break;
                            }

                            strTexto = new StringBuilder();
                            prpComandoSQLServer.Parameters.Clear();

                            for (int coluna = Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetLowerBound(0);
                                coluna <=
                                (
                                (linha == Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0))
                                ?
                                Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0)
                                :
                                Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) - 3
                                );
                                coluna++)
                            {
                                switch (linha)
                                {
                                    case (0):
                                        vetNomeColunas[coluna] = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];
                                        break;
                                    default:
                                        vetRegistrosColunas[coluna] = (object)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];

                                        mtdExecutarParametroComandoSQLServer
                                            (
                                            vetNomeColunas[coluna],
                                            vetRegistrosColunas[coluna]
                                            );

                                        strTexto.Append
                                            (
                                            string.Format
                                            (
                                            (coluna == Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) - 3) ?
                                            "{0} = @{1}" :
                                            "{0} = @{1}, ",
                                            vetNomeColunas[coluna],
                                            vetNomeColunas[coluna]
                                            )
                                            );
                                        break;
                                }
                            }
                            if (linha >= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais)
                            {
                                saida &= mtdExecutarComando(
                                    string.Format("UPDATE {0} SET {1} WHERE {2} {3} {4};", NomeTabela, strTexto, strCampoBase, strOperacao, objDadoBase));
                            }
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        private bool mtdAtualizarDadosParametroComandoSQLServerValorTipo(string NomeTabela, object[][] Campos_Dados_CampoBase_Operacao_DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 2;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            StringBuilder strTexto = new StringBuilder();
            string[] vetNomeColunas = null;
            System.Data.SqlDbType[] vetTipoColunas = null;
            object[] vetRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados_CampoBase_Operacao_DadoBase != null)
            {
                if (Campos_Dados_CampoBase_Operacao_DadoBase.GetLength(0) >= intLinhasAdicionais + 1)
                {
                    for (int linha = Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0); linha <= Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(0); linha++)
                    {
                        if (Campos_Dados_CampoBase_Operacao_DadoBase[linha] != null)
                        {
                            switch (linha)
                            {
                                case (0):
                                    vetNomeColunas = new string[Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) + 1];
                                    break;
                                case (1):
                                    vetTipoColunas = new System.Data.SqlDbType[Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) + 1];
                                    break;
                                default:
                                    strCampoBase = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) - 2];
                                    strOperacao = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) - 1];
                                    objDadoBase = Campos_Dados_CampoBase_Operacao_DadoBase[linha][Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0)];
                                    vetRegistrosColunas = new object[Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) + 1];
                                    break;
                            }

                            strTexto = new StringBuilder();
                            prpComandoSQLServer.Parameters.Clear();

                            for (int coluna = Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetLowerBound(0);
                                coluna <=
                                (
                                (linha == Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0))
                                ?
                                Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0)
                                :
                                Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) - 3
                                );
                                coluna++)
                            {
                                switch (linha)
                                {
                                    case (0):
                                        vetNomeColunas[coluna] = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];
                                        break;
                                    case (1):
                                        vetTipoColunas[coluna] = (System.Data.SqlDbType)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];
                                        break;
                                    default:
                                        vetRegistrosColunas[coluna] = (object)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];

                                        mtdExecutarParametroComandoSQLServer
                                            (
                                            vetNomeColunas[coluna],
                                            vetTipoColunas[coluna],
                                            vetRegistrosColunas[coluna]
                                            );

                                        strTexto .Append
                                            (
                                            string.Format
                                            (
                                            (coluna == Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) - 3) ?
                                            "{0} = @{1}" :
                                            "{0} = @{1}, ",
                                            vetNomeColunas[coluna],
                                            vetNomeColunas[coluna]
                                            )
                                            );
                                        break;
                                }
                            }
                            if (linha >= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais)
                            {
                                saida &= mtdExecutarComando(
                                    string.Format("UPDATE {0} SET {1} WHERE {2} {3} {4};", NomeTabela, strTexto, strCampoBase, strOperacao, objDadoBase));
                            }
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        private bool mtdAtualizarDadosParametroComandoSQLServerValorTipoTamanho(string NomeTabela, object[][] Campos_Dados_CampoBase_Operacao_DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 3;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            StringBuilder strTexto = new StringBuilder();
            string[] vetNomeColunas = null;
            System.Data.SqlDbType[] vetTipoColunas = null;
            int[] vetTamanhoColunas = null;
            object[] vetRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados_CampoBase_Operacao_DadoBase != null)
            {
                if (Campos_Dados_CampoBase_Operacao_DadoBase.GetLength(0) >= intLinhasAdicionais + 1)
                {
                    for (int linha = Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0); linha <= Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(0); linha++)
                    {
                        if (Campos_Dados_CampoBase_Operacao_DadoBase[linha] != null)
                        {
                            switch (linha)
                            {
                                case (0):
                                    vetNomeColunas = new string[Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) + 1];
                                    break;
                                case (1):
                                    vetTipoColunas = new System.Data.SqlDbType[Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) + 1];
                                    break;
                                case (2):
                                    vetTamanhoColunas = new int[Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) + 1];
                                    break;
                                default:
                                    strCampoBase = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) - 2];
                                    strOperacao = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(0) - 1];
                                    objDadoBase = Campos_Dados_CampoBase_Operacao_DadoBase[linha][Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0)];
                                    vetRegistrosColunas = new object[Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) + 1];
                                    break;
                            }

                            strTexto = new StringBuilder();
                            prpComandoSQLServer.Parameters.Clear();

                            for (int coluna = Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetLowerBound(0);
                                coluna <=
                                (
                                (linha == Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0))
                                ?
                                Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0)
                                :
                                Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) - 3
                                );
                                coluna++)
                            {
                                switch (linha)
                                {
                                    case (0):
                                        vetNomeColunas[coluna] = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];
                                        break;
                                    case (1):
                                        vetTipoColunas[coluna] = (System.Data.SqlDbType)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];
                                        break;
                                    case (2):
                                        vetTamanhoColunas[coluna] = (int)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];
                                        break;
                                    default:
                                        vetRegistrosColunas[coluna] = (object)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];

                                        mtdExecutarParametroComandoSQLServer
                                            (
                                            vetNomeColunas[coluna],
                                            vetTipoColunas[coluna],
                                            vetRegistrosColunas[coluna],
                                            vetTamanhoColunas[coluna]
                                            );

                                        strTexto .Append
                                            (
                                            string.Format
                                            (
                                            (coluna == Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) - 3) ?
                                            "{0} = @{1}" :
                                            "{0} = @{1}, ",
                                            vetNomeColunas[coluna],
                                            vetNomeColunas[coluna]
                                            )
                                            );
                                        break;
                                }
                            }
                            if (linha >= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais)
                            {
                                saida &= mtdExecutarComando(
                                    string.Format("UPDATE {0} SET {1} WHERE {2} {3} {4};", NomeTabela, strTexto, strCampoBase, strOperacao, objDadoBase));
                            }
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        public bool mtdAtualizarDadosParametroComandoSQLServer(string NomeTabela, object[][] Campos_Dados_CampoBase_Operacao_DadoBase, enmModoParametroComando ModoParametroComando)
        {
            bool saida = false;
            switch (ModoParametroComando)
            {
                case enmModoParametroComando.Valor:
                    mtdAtualizarDadosParametroComandoSQLServerValor(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase);
                    break;
                case enmModoParametroComando.ValorTipo:
                    mtdAtualizarDadosParametroComandoSQLServerValorTipo(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase);
                    break;
                case enmModoParametroComando.ValorTipoTamanho:
                    mtdAtualizarDadosParametroComandoSQLServerValorTipoTamanho(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase);
                    break;
            }
            return saida;
        }

        private bool mtdInserirDadosParametroComandoSQLServerValor(string NomeTabela, object[,] Campos_Dados)
        {
            bool saida = true;

            int intLinhasAdicionais = 1;
            StringBuilder strNomeColunas = new StringBuilder();
            StringBuilder objResgistrosColunas = new StringBuilder();
            string[] vetNomeColunas = null;
            object[] vetRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados != null)
            {
                if (Campos_Dados.GetLength(0) >= intLinhasAdicionais + 1)
                {
                    for (int linha = Campos_Dados.GetLowerBound(0); linha <= Campos_Dados.GetUpperBound(0); linha++)
                    {
                        switch (linha)
                        {
                            case (0):
                                vetNomeColunas = new string[Campos_Dados.GetUpperBound(1) + 1];
                                break;
                            default:
                                vetRegistrosColunas = new object[Campos_Dados.GetUpperBound(1) + 1];
                                break;
                        }

                        objResgistrosColunas.Append(string.Empty);
                        prpComandoSQLServer.Parameters.Clear();

                        for (int coluna = Campos_Dados.GetLowerBound(1); coluna <= Campos_Dados.GetUpperBound(1); coluna++)
                        {
                            switch (linha)
                            {
                                case (0):
                                    vetNomeColunas[coluna] = (string)Campos_Dados[linha, coluna];
                                    strNomeColunas.Append
                                        (
                                        string.Format
                                        (
                                        (coluna != Campos_Dados.GetUpperBound(1))
                                        ?
                                        "{0}, "
                                        :
                                        "{0}",
                                        vetNomeColunas[coluna]
                                        )
                                        );
                                    break;
                                default:
                                    vetRegistrosColunas[coluna] = (object)Campos_Dados[linha, coluna];

                                    mtdExecutarParametroComandoSQLServer
                                        (
                                        vetNomeColunas[coluna],
                                        vetRegistrosColunas[coluna]
                                        );

                                    objResgistrosColunas.Append
                                       (
                                       string.Format
                                       (
                                       (coluna != Campos_Dados.GetUpperBound(1))
                                       ?
                                       "@{0}, "
                                       :
                                       "@{0}",
                                       vetNomeColunas[coluna]
                                       )
                                       );
                                    break;
                            }
                        }
                        if (linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais)
                        {
                            saida &= mtdExecutarComando(string.Format("INSERT INTO {0}({1}) VALUES({2});", NomeTabela, strNomeColunas, objResgistrosColunas));
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        private bool mtdInserirDadosParametroComandoSQLServerValorTipo(string NomeTabela, object[,] Campos_Dados)
        {
            bool saida = true;

            int intLinhasAdicionais = 2;
            StringBuilder strNomeColunas = new StringBuilder();
            StringBuilder objResgistrosColunas = new StringBuilder();
            string[] vetNomeColunas = null;
            System.Data.SqlDbType[] vetTipoColunas = null;
            object[] vetRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados != null)
            {
                if (Campos_Dados.GetLength(0) >= intLinhasAdicionais + 1)
                {
                    for (int linha = Campos_Dados.GetLowerBound(0); linha <= Campos_Dados.GetUpperBound(0); linha++)
                    {
                        switch (linha)
                        {
                            case (0):
                                vetNomeColunas = new string[Campos_Dados.GetUpperBound(1) + 1];
                                break;
                            case (1):
                                vetTipoColunas = new System.Data.SqlDbType[Campos_Dados.GetUpperBound(1) + 1];
                                break;
                            default:
                                vetRegistrosColunas = new object[Campos_Dados.GetUpperBound(1) + 1];
                                break;
                        }

                        objResgistrosColunas.Append(string.Empty);
                        prpComandoSQLServer.Parameters.Clear();

                        for (int coluna = Campos_Dados.GetLowerBound(1); coluna <= Campos_Dados.GetUpperBound(1); coluna++)
                        {
                            switch (linha)
                            {
                                case (0):
                                    vetNomeColunas[coluna] = (string)Campos_Dados[linha, coluna];
                                    strNomeColunas.Append
                                        (
                                        string.Format
                                        (
                                        (coluna != Campos_Dados.GetUpperBound(1))
                                        ?
                                        "{0}, "
                                        :
                                        "{0}",
                                        vetNomeColunas[coluna]
                                        )
                                        );
                                    break;
                                case (1):
                                    vetTipoColunas[coluna] = (System.Data.SqlDbType)Campos_Dados[linha, coluna];
                                    break;
                                default:
                                    vetRegistrosColunas[coluna] = (object)Campos_Dados[linha, coluna];

                                    mtdExecutarParametroComandoSQLServer
                                        (
                                        vetNomeColunas[coluna],
                                        vetTipoColunas[coluna],
                                        vetRegistrosColunas[coluna]
                                        );

                                    objResgistrosColunas.Append
                                        (
                                        string.Format
                                        (
                                        (coluna != Campos_Dados.GetUpperBound(1))
                                        ?
                                        "@{0}, "
                                        :
                                        "@{0}",
                                        vetNomeColunas[coluna]
                                        )
                                        );
                                    break;
                            }
                        }
                        if (linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais)
                        {
                            saida &= mtdExecutarComando(string.Format("INSERT INTO {0}({1}) VALUES({2});", NomeTabela, strNomeColunas, objResgistrosColunas));
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        private bool mtdInserirDadosParametroComandoSQLServerValorTipoTamanho(string NomeTabela, object[,] Campos_Dados)
        {
            bool saida = true;

            int intLinhasAdicionais = 3;
            StringBuilder strNomeColunas = new StringBuilder();
            StringBuilder objResgistrosColunas = new StringBuilder();
            string[] vetNomeColunas = null;
            System.Data.SqlDbType[] vetTipoColunas = null;
            int[] vetTamanhoColunas = null;
            object[] vetRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados != null)
            {
                if (Campos_Dados.GetLength(0) >= intLinhasAdicionais + 1)
                {
                    for (int linha = Campos_Dados.GetLowerBound(0); linha <= Campos_Dados.GetUpperBound(0); linha++)
                    {
                        switch (linha)
                        {
                            case (0):
                                vetNomeColunas = new string[Campos_Dados.GetUpperBound(1) + 1];
                                break;
                            case (1):
                                vetTipoColunas = new System.Data.SqlDbType[Campos_Dados.GetUpperBound(1) + 1];
                                break;
                            case (2):
                                vetTamanhoColunas = new int[Campos_Dados.GetUpperBound(1) + 1];
                                break;
                            default:
                                vetRegistrosColunas = new object[Campos_Dados.GetUpperBound(1) + 1];
                                break;
                        }

                        objResgistrosColunas.Append(string.Empty);
                        prpComandoSQLServer.Parameters.Clear();

                        for (int coluna = Campos_Dados.GetLowerBound(1); coluna <= Campos_Dados.GetUpperBound(1); coluna++)
                        {
                            switch (linha)
                            {
                                case (0):
                                    vetNomeColunas[coluna] = (string)Campos_Dados[linha, coluna];
                                    strNomeColunas.Append
                                        (
                                        string.Format
                                        (
                                        (coluna != Campos_Dados.GetUpperBound(1))
                                        ?
                                        "{0}, "
                                        :
                                        "{0}",
                                        vetNomeColunas[coluna]
                                        )
                                        );
                                    break;
                                case (1):
                                    vetTipoColunas[coluna] = (System.Data.SqlDbType)Campos_Dados[linha, coluna];
                                    break;
                                case (2):
                                    vetTamanhoColunas[coluna] = (int)Campos_Dados[linha, coluna];
                                    break;
                                default:
                                    vetRegistrosColunas[coluna] = (object)Campos_Dados[linha, coluna];

                                    mtdExecutarParametroComandoSQLServer
                                        (
                                        vetNomeColunas[coluna],
                                        vetTipoColunas[coluna],
                                        vetRegistrosColunas[coluna],
                                        vetTamanhoColunas[coluna]
                                        );

                                    objResgistrosColunas.Append
                                        (
                                        string.Format
                                        (
                                        (coluna != Campos_Dados.GetUpperBound(1))
                                        ?
                                        "@{0}, "
                                        :
                                        "@{0}",
                                        vetNomeColunas[coluna]
                                        )
                                        );
                                    break;
                            }
                        }
                        if (linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais)
                        {
                            saida &= mtdExecutarComando(string.Format("INSERT INTO {0}({1}) VALUES({2});", NomeTabela, strNomeColunas, objResgistrosColunas));
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        public bool mtdInserirDadosParametroComandoSQLServer(string NomeTabela, object[,] Campos_Dados, enmModoParametroComando ModoParametroComando)
        {
            bool saida = false;
            switch (ModoParametroComando)
            {
                case enmModoParametroComando.Valor:
                    mtdInserirDadosParametroComandoSQLServerValor(NomeTabela, Campos_Dados);
                    break;
                case enmModoParametroComando.ValorTipo:
                    mtdInserirDadosParametroComandoSQLServerValorTipo(NomeTabela, Campos_Dados);
                    break;
                case enmModoParametroComando.ValorTipoTamanho:
                    mtdInserirDadosParametroComandoSQLServerValorTipoTamanho(NomeTabela, Campos_Dados);
                    break;
            }
            return saida;
        }

        private bool mtdInserirDadosParametroComandoSQLServerValor(string NomeTabela, object[][] Campos_Dados)
        {
            bool saida = true;

            int intLinhasAdicionais = 1;
            StringBuilder strNomeColunas = new StringBuilder();
            StringBuilder objResgistrosColunas = new StringBuilder();
            string[] vetNomeColunas = null;
            object[] vetRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados != null)
            {
                if (Campos_Dados.GetLength(0) >= intLinhasAdicionais + 1)
                {
                    for (int linha = Campos_Dados.GetLowerBound(0); linha <= Campos_Dados.GetUpperBound(0); linha++)
                    {
                        if (Campos_Dados[linha] != null)
                        {
                            switch (linha)
                            {
                                case (0):
                                    vetNomeColunas = new string[Campos_Dados[linha].GetUpperBound(0) + 1];
                                    break;
                                default:
                                    vetRegistrosColunas = new object[Campos_Dados[linha].GetUpperBound(0) + 1];
                                    break;
                            }

                            objResgistrosColunas.Append(string.Empty);
                            prpComandoSQLServer.Parameters.Clear();

                            for (int coluna = Campos_Dados[linha].GetLowerBound(0); coluna <= Campos_Dados[linha].GetUpperBound(0); coluna++)
                            {
                                switch (linha)
                                {
                                    case (0):
                                        vetNomeColunas[coluna] = (string)Campos_Dados[linha][coluna];
                                        strNomeColunas.Append
                                            (
                                            string.Format
                                            (
                                            (coluna != Campos_Dados[linha].GetUpperBound(0))
                                            ?
                                            "{0}, "
                                            :
                                            "{0}",
                                            vetNomeColunas[coluna]
                                            )
                                            );
                                        break;
                                    default:
                                        vetRegistrosColunas[coluna] = (object)Campos_Dados[linha][coluna];

                                        mtdExecutarParametroComandoSQLServer
                                            (
                                            vetNomeColunas[coluna],
                                            vetRegistrosColunas[coluna]
                                            );

                                        objResgistrosColunas.Append
                                            (
                                            string.Format
                                            (
                                            (coluna != Campos_Dados[linha].GetUpperBound(0))
                                            ?
                                            "@{0}, "
                                            :
                                            "@{0}",
                                            vetNomeColunas[coluna]
                                            )
                                            );
                                        break;
                                }
                            }
                            if (linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais)
                            {
                                saida &= mtdExecutarComando(string.Format("INSERT INTO {0}({1}) VALUES({2});", NomeTabela, strNomeColunas, objResgistrosColunas));
                            }
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        private bool mtdInserirDadosParametroComandoSQLServerValorTipo(string NomeTabela, object[][] Campos_Dados)
        {
            bool saida = true;

            int intLinhasAdicionais = 2;
            StringBuilder strNomeColunas = new StringBuilder();
            StringBuilder objResgistrosColunas = new StringBuilder();
            string[] vetNomeColunas = null;
            System.Data.SqlDbType[] vetTipoColunas = null;
            object[] vetRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados != null)
            {
                if (Campos_Dados.GetLength(0) >= intLinhasAdicionais + 1)
                {
                    for (int linha = Campos_Dados.GetLowerBound(0); linha <= Campos_Dados.GetUpperBound(0); linha++)
                    {
                        if (Campos_Dados[linha] != null)
                        {
                            switch (linha)
                            {
                                case (0):
                                    vetNomeColunas = new string[Campos_Dados[linha].GetUpperBound(0) + 1];
                                    break;
                                case (1):
                                    vetTipoColunas = new System.Data.SqlDbType[Campos_Dados[linha].GetUpperBound(0) + 1];
                                    break;
                                default:
                                    vetRegistrosColunas = new object[Campos_Dados[linha].GetUpperBound(0) + 1];
                                    break;
                            }

                            objResgistrosColunas.Append(string.Empty);
                            prpComandoSQLServer.Parameters.Clear();

                            for (int coluna = Campos_Dados[linha].GetLowerBound(0); coluna <= Campos_Dados[linha].GetUpperBound(0); coluna++)
                            {
                                switch (linha)
                                {
                                    case (0):
                                        vetNomeColunas[coluna] = (string)Campos_Dados[linha][coluna];
                                        strNomeColunas.Append
                                            (
                                            string.Format
                                            (
                                            (coluna != Campos_Dados[linha].GetUpperBound(0))
                                            ?
                                            "{0}, "
                                            :
                                            "{0}",
                                            vetNomeColunas[coluna]
                                            )
                                            );
                                        break;
                                    case (1):
                                        vetTipoColunas[coluna] = (System.Data.SqlDbType)Campos_Dados[linha][coluna];
                                        break;
                                    default:
                                        vetRegistrosColunas[coluna] = (object)Campos_Dados[linha][coluna];

                                        mtdExecutarParametroComandoSQLServer
                                            (
                                            vetNomeColunas[coluna],
                                            vetTipoColunas[coluna],
                                            vetRegistrosColunas[coluna]
                                            );

                                        objResgistrosColunas.Append
                                            (
                                            string.Format
                                            (
                                            (coluna != Campos_Dados.GetUpperBound(1))
                                            ?
                                            "@{0}, "
                                            :
                                            "@{0}",
                                            vetNomeColunas[coluna]
                                            )
                                            );
                                        break;
                                }
                            }
                            if (linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais)
                            {
                                saida &= mtdExecutarComando(string.Format("INSERT INTO {0}({1}) VALUES({2});", NomeTabela, strNomeColunas, objResgistrosColunas));
                            }
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        private bool mtdInserirDadosParametroComandoSQLServerValorTipoTamanho(string NomeTabela, object[][] Campos_Dados)
        {
            bool saida = true;

            int intLinhasAdicionais = 3;
            StringBuilder strNomeColunas = new StringBuilder();
            StringBuilder objResgistrosColunas = new StringBuilder();
            string[] vetNomeColunas = null;
            System.Data.SqlDbType[] vetTipoColunas = null;
            int[] vetTamanhoColunas = null;
            object[] vetRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados != null)
            {
                if (Campos_Dados.GetLength(0) >= intLinhasAdicionais + 1)
                {
                    for (int linha = Campos_Dados.GetLowerBound(0); linha <= Campos_Dados.GetUpperBound(0); linha++)
                    {
                        if (Campos_Dados[linha] != null)
                        {
                            switch (linha)
                            {
                                case (0):
                                    vetNomeColunas = new string[Campos_Dados[linha].GetUpperBound(0) + 1];
                                    break;
                                case (1):
                                    vetTipoColunas = new System.Data.SqlDbType[Campos_Dados[linha].GetUpperBound(0) + 1];
                                    break;
                                case (2):
                                    vetTamanhoColunas = new int[Campos_Dados[linha].GetUpperBound(0) + 1];
                                    break;
                                default:
                                    vetRegistrosColunas = new object[Campos_Dados[linha].GetUpperBound(0) + 1];
                                    break;
                            }

                            objResgistrosColunas.Append(string.Empty);
                            prpComandoSQLServer.Parameters.Clear();

                            for (int coluna = Campos_Dados[linha].GetLowerBound(0); coluna <= Campos_Dados[linha].GetUpperBound(0); coluna++)
                            {
                                switch (linha)
                                {
                                    case (0):
                                        vetNomeColunas[coluna] = (string)Campos_Dados[linha][coluna];
                                        strNomeColunas.Append
                                            (
                                            string.Format
                                            (
                                            (coluna != Campos_Dados[linha].GetUpperBound(0))
                                            ?
                                            "{0}, "
                                            :
                                            "{0}",
                                            vetNomeColunas[coluna]
                                            )
                                            );
                                        break;
                                    case (1):
                                        vetTipoColunas[coluna] = (System.Data.SqlDbType)Campos_Dados[linha][coluna];
                                        break;
                                    case (2):
                                        vetTamanhoColunas[coluna] = (int)Campos_Dados[linha][coluna];
                                        break;
                                    default:
                                        vetRegistrosColunas[coluna] = (object)Campos_Dados[linha][coluna];

                                        mtdExecutarParametroComandoSQLServer
                                            (
                                            vetNomeColunas[coluna],
                                            vetTipoColunas[coluna],
                                            vetRegistrosColunas[coluna],
                                            vetTamanhoColunas[coluna]
                                            );

                                        objResgistrosColunas.Append
                                            (
                                            string.Format
                                            (
                                            (coluna != Campos_Dados[linha].GetUpperBound(0))
                                            ?
                                            "@{0}, "
                                            :
                                            "@{0}",
                                            vetNomeColunas[coluna]
                                            )
                                            );
                                        break;
                                }
                            }
                            if (linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais)
                            {
                                saida &= mtdExecutarComando(string.Format("INSERT INTO {0}({1}) VALUES({2});", NomeTabela, strNomeColunas, objResgistrosColunas));
                            }
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        public bool mtdInserirDadosParametroComandoSQLServer(string NomeTabela, object[][] Campos_Dados, enmModoParametroComando ModoParametroComando)
        {
            bool saida = false;
            switch (ModoParametroComando)
            {
                case enmModoParametroComando.Valor:
                    mtdInserirDadosParametroComandoSQLServerValor(NomeTabela, Campos_Dados);
                    break;
                case enmModoParametroComando.ValorTipo:
                    mtdInserirDadosParametroComandoSQLServerValorTipo(NomeTabela, Campos_Dados);
                    break;
                case enmModoParametroComando.ValorTipoTamanho:
                    mtdInserirDadosParametroComandoSQLServerValorTipoTamanho(NomeTabela, Campos_Dados);
                    break;
            }
            return saida;
        }

        public bool mtdSelecionarDadosParametroComandoSQLServer(uint NumeroLinhas, string Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado)
        {
            bool saida = true;

            mtdExecutarParametroComandoSQLServer
                (
                CampoSelecionador,
                Dado
                );

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            saida &= mtdExecutarComando
                (
                string.Format
                (
                "SELECT {0}{1} FROM {2} WHERE {3} {4} @{3};",
                NumeroLinhas,
                Campos,
                NomeTabela,
                CampoSelecionador,
                Operacao,
                Dado
                )
                );

            return saida;
        }
    }
}
