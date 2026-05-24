using System;
using System.Collections.Generic;
using System.Text;

namespace WebServiceInspecaoCSNet40
{
    public partial class clsConexaoBancoDados
    {
        // Constantes de instancia do SQLServerCE

        public const string cntStringConexaoSQLServerCEOleDb = @"Provider={0}; Data Source={1}; SSCE:Database Password={2}; SSCE:Temp File Directory={3}; SSCE:Temp File Max Size={4}; SSCE:Encrypt Database={5}; SSCE:Max Buffer Size={6}; SSCE:Max Database Size={7};";
        public const string cntStringConexaoSQLServerCENativa = @"Data Source={0}; Password={1}; File Mode={2}; Temp File Max Size={3}; Encrypt Database={4}; Max Buffer Size={5}; Max Database Size={6}; Persist Security Info={7};";

        public const string cntExemploStringConexaoSQLServerCEOleDb = @"Provider=Microsoft.SQLSERVER.CE.OLEDB.3.5; Data Source=myPath\myData.sdf; SSCE:Database Password=myPassword; SSCE:Temp File Directory=\myTempDir\; SSCE:Temp File Max Size=256; SSCE:Encrypt Database=True; SSCE:Max Buffer Size=1024; SSCE:Max Database Size=256;";
        public const string cntExemploStringConexaoSQLServerCENativa = @"Data Source=MyData.sdf; Password=myPassword; File Mode=shared read; Temp File Max Size=256; Encrypt Database=True; Max Buffer Size=1024; Max Database Size=256; Persist Security Info=False;";

        // Variaveis somente leitura de instancia do SQLServerCE

        private readonly string[] cntProviderSQLServerCE = { "Provider", "SQLServerCEProv" };
        private readonly string[] cntDataSourceSQLServerCE = { "Data Source", string.Empty };
        private readonly string[] cntPasswordSQLServerCE = { "Password", string.Empty };
        private readonly string[] cntFileModeSQLServerCE = { "File Mode", string.Empty };
        private readonly string[] cntTempFileMaxSizeSQLServerCE = { "Temp File Max Size", "256" };
        private readonly string[] cntEncryptDatabaseSQLServerCE = { "Encrypt Database", "True" };
        private readonly string[] cntMaxBufferSizeSQLServerCE = { "Max Buffer Size", "1024" };
        private readonly string[] cntMaxDatabaseSizeSQLServerCE = { "Max Database Size", "256" };
        private readonly string[] cntPersistSecurityInfoSQLServerCE = { "Persist Security Inf", "False" };

        // Variaveis de instancia do SQLServerCE

        private string[] strProviderSQLServerCE;
        private string[] strDataSourceSQLServerCE;
        private string[] strPasswordSQLServerCE;
        private string[] strFileModeSQLServerCE;
        private string[] strTempFileMaxSizeSQLServerCE;
        private string[] strEncryptDatabaseSQLServerCE;
        private string[] strMaxBufferSizeSQLServerCE;
        private string[] strMaxDatabaseSizeSQLServerCE;
        private string[] strPersistSecurityInfoSQLServerCE;

        private string[] vetProviderSQLServerCE = { "Provider" };
        private string[] vetDataSourceSQLServerCE = { "DataSource", "Data Source" };
        private string[] vetPasswordSQLServerCE = { "Password", "SSCE:DatabasePassword", "SSCE:Database Password" };
        private string[] vetFileModeSQLServerCE = { "FileMode", "File Mode" };
        private string[] vetTempFileMaxSizeSQLServerCE = { "TempFileMaxSize", "Temp File Max Size", "SSCE:TempFileMaxSize", "SSCE:Temp File Max Size" };
        private string[] vetEncryptDatabaseSQLServerCE = { "EncryptDatabase", "Encrypt Database", "SSCE:EncryptDatabase", "SSCE:Encrypt Database" };
        private string[] vetMaxBufferSizeSQLServerCE = { "MaxBufferSize", "Max Buffer Size", "SSCE:MaxBufferSize", "SSCE:Max Buffer Size" };
        private string[] vetMaxDatabaseSizeSQLServerCE = { "MaxDatabaseSize", "Max Database Size", "SSCE:MaxDatabaseSize", "SSCE:Max Database Size" };
        private string[] vetPersistSecurityInfoSQLServerCE = { "PersistSecurityInf", "Persist Security Inf" };

        // Variaveis que determinam se a conexao incorporara o banco de dados. Isso facilita na criacao, alteracao ou delecao do banco de dados.

        // Propriedades de instancia do SQLServerCE

        private bool blnPermitirBancoDadosSQLServerCE = true;

        public bool prpPermitirBancoDadosSQLServerCE
        {
            get
            {
                return blnPermitirBancoDadosSQLServerCE;
            }
            set
            {
                blnPermitirBancoDadosSQLServerCE = value;
            }
        }

        // Propriedades de instancia do SQLServerCE

        public string prpProviderSQLServerCE
        {
            get
            {
                if (strProviderSQLServerCE == null)
                {
                    strProviderSQLServerCE = new string[2] { cntProviderSQLServerCE[0], cntProviderSQLServerCE[1] };
                }
                return strProviderSQLServerCE[1];
            }
            set
            {
                if (strProviderSQLServerCE == null)
                {
                    strProviderSQLServerCE = new string[2] { cntProviderSQLServerCE[0], cntProviderSQLServerCE[1] };
                }
                strProviderSQLServerCE[1] = value;
                mtdReDefinirConexaoString(strProviderSQLServerCE);
            }
        }

        public string prpDataSourceSQLServerCE
        {
            get
            {
                if (strDataSourceSQLServerCE == null)
                {
                    strDataSourceSQLServerCE = new string[2] { cntDataSourceSQLServerCE[0], cntDataSourceSQLServerCE[1] };
                }
                return strDataSourceSQLServerCE[1];
            }
            set
            {
                if (strDataSourceSQLServerCE == null)
                {
                    strDataSourceSQLServerCE = new string[2] { cntDataSourceSQLServerCE[0], cntDataSourceSQLServerCE[1] };
                }
                strDataSourceSQLServerCE[1] = value;
                mtdReDefinirConexaoString(strDataSourceSQLServerCE);
            }
        }

        public string prpPasswordSQLServerCE
        {
            get
            {
                if (strPasswordSQLServerCE == null)
                {
                    strPasswordSQLServerCE = new string[2] { cntPasswordSQLServerCE[0], cntPasswordSQLServerCE[1] };
                }
                return strPasswordSQLServerCE[1];
            }
            set
            {
                if (strPasswordSQLServerCE == null)
                {
                    strPasswordSQLServerCE = new string[2] { cntPasswordSQLServerCE[0], cntPasswordSQLServerCE[1] };
                }
                strPasswordSQLServerCE[1] = value;
                mtdReDefinirConexaoString(strPasswordSQLServerCE);
            }
        }

        public string prpFileModeSQLServerCE
        {
            get
            {
                if (strFileModeSQLServerCE == null)
                {
                    strFileModeSQLServerCE = new string[2] { cntFileModeSQLServerCE[0], cntFileModeSQLServerCE[1] };
                }
                return strFileModeSQLServerCE[1];
            }
            set
            {
                if (strFileModeSQLServerCE == null)
                {
                    strFileModeSQLServerCE = new string[2] { cntFileModeSQLServerCE[0], cntFileModeSQLServerCE[1] };
                }
                strFileModeSQLServerCE[1] = value;
                mtdReDefinirConexaoString(strFileModeSQLServerCE);
            }
        }

        public string prpTempFileMaxSizeSQLServerCE
        {
            get
            {
                if (strTempFileMaxSizeSQLServerCE == null)
                {
                    strTempFileMaxSizeSQLServerCE = new string[2] { cntTempFileMaxSizeSQLServerCE[0], cntTempFileMaxSizeSQLServerCE[1] };
                }
                return strTempFileMaxSizeSQLServerCE[1];
            }
            set
            {
                if (strTempFileMaxSizeSQLServerCE == null)
                {
                    strTempFileMaxSizeSQLServerCE = new string[2] { cntTempFileMaxSizeSQLServerCE[0], cntTempFileMaxSizeSQLServerCE[1] };
                }
                strTempFileMaxSizeSQLServerCE[1] = value;
                mtdReDefinirConexaoString(strTempFileMaxSizeSQLServerCE);
            }
        }

        public string prpEncryptDatabaseSQLServerCE
        {
            get
            {
                if (strEncryptDatabaseSQLServerCE == null)
                {
                    strEncryptDatabaseSQLServerCE = new string[2] { cntEncryptDatabaseSQLServerCE[0], cntEncryptDatabaseSQLServerCE[1] };
                }
                return strEncryptDatabaseSQLServerCE[1];
            }
            set
            {
                if (strEncryptDatabaseSQLServerCE == null)
                {
                    strEncryptDatabaseSQLServerCE = new string[2] { cntEncryptDatabaseSQLServerCE[0], cntEncryptDatabaseSQLServerCE[1] };
                }
                strEncryptDatabaseSQLServerCE[1] = value;
                mtdReDefinirConexaoString(strEncryptDatabaseSQLServerCE);
            }
        }

        public string prpMaxBufferSizeSQLServerCE
        {
            get
            {
                if (strMaxBufferSizeSQLServerCE == null)
                {
                    strMaxBufferSizeSQLServerCE = new string[2] { cntEncryptDatabaseSQLServerCE[0], cntEncryptDatabaseSQLServerCE[1] };
                }
                return strMaxDatabaseSizeSQLServerCE[1];
            }
            set
            {
                if (strMaxBufferSizeSQLServerCE == null)
                {
                    strMaxBufferSizeSQLServerCE = new string[2] { cntEncryptDatabaseSQLServerCE[0], cntEncryptDatabaseSQLServerCE[1] };
                }
                strMaxDatabaseSizeSQLServerCE[1] = value;
                mtdReDefinirConexaoString(strMaxDatabaseSizeSQLServerCE);
            }
        }

        public string prpMaxDatabaseSizeSQLServerCE
        {
            get
            {
                if (strMaxDatabaseSizeSQLServerCE == null)
                {
                    strMaxDatabaseSizeSQLServerCE = new string[2] { cntEncryptDatabaseSQLServerCE[0], cntEncryptDatabaseSQLServerCE[1] };
                }
                return strMaxDatabaseSizeSQLServerCE[1];
            }
            set
            {
                if (strMaxDatabaseSizeSQLServerCE == null)
                {
                    strMaxDatabaseSizeSQLServerCE = new string[2] { cntEncryptDatabaseSQLServerCE[0], cntEncryptDatabaseSQLServerCE[1] };
                }
                strMaxDatabaseSizeSQLServerCE[1] = value;
                mtdReDefinirConexaoString(strMaxDatabaseSizeSQLServerCE);
            }
        }

        public string prpPersistSecurityInfoSQLServerCE
        {
            get
            {
                if (strPersistSecurityInfoSQLServerCE == null)
                {
                    strPersistSecurityInfoSQLServerCE = new string[2] { cntEncryptDatabaseSQLServerCE[0], cntEncryptDatabaseSQLServerCE[1] };
                }
                return strPersistSecurityInfoSQLServerCE[1];
            }
            set
            {
                if (strPersistSecurityInfoSQLServerCE == null)
                {
                    strPersistSecurityInfoSQLServerCE = new string[2] { cntEncryptDatabaseSQLServerCE[0], cntEncryptDatabaseSQLServerCE[1] };
                }
                strPersistSecurityInfoSQLServerCE[1] = value;
                mtdReDefinirConexaoString(strPersistSecurityInfoSQLServerCE);
            }
        }

        // Metodos de instancia do SQLServerCE

        public string[] mtdValidarConexaoProvedorSQLServerCE(string Conexao)
        {
            strProviderSQLServerCE = mtdValidarConexao(Conexao, vetProviderSQLServerCE);
            return strProviderSQLServerCE;
        }

        public string[] mtdValidarConexaoOrigemDadosSQLServerCE(string Conexao)
        {
            strDataSourceSQLServerCE = mtdValidarConexao(Conexao, vetDataSourceSQLServerCE);
            return strDataSourceSQLServerCE;
        }
        public string[] mtdValidarConexaoSenhaSQLServerCE(string Conexao)
        {
            strPasswordSQLServerCE = mtdValidarConexao(Conexao, vetPasswordSQLServerCE);
            return strPasswordSQLServerCE;
        }
        public string[] mtdValidarConexaoFileModeSQLServerCE(string Conexao)
        {
            strFileModeSQLServerCE = mtdValidarConexao(Conexao, vetFileModeSQLServerCE);
            return strFileModeSQLServerCE;
        }
        public string[] mtdValidarConexaoTempFileMaxSizeSQLServerCE(string Conexao)
        {
            strTempFileMaxSizeSQLServerCE = mtdValidarConexao(Conexao, vetTempFileMaxSizeSQLServerCE);
            return strTempFileMaxSizeSQLServerCE;
        }
        public string[] mtdValidarConexaoEncryptDatabaseSQLServerCE(string Conexao)
        {
            strEncryptDatabaseSQLServerCE = mtdValidarConexao(Conexao, vetEncryptDatabaseSQLServerCE);
            return strEncryptDatabaseSQLServerCE;
        }
        public string[] mtdValidarConexaoMaxBufferSizeSQLServerCE(string Conexao)
        {
            strMaxBufferSizeSQLServerCE = mtdValidarConexao(Conexao, vetMaxBufferSizeSQLServerCE);
            return strMaxBufferSizeSQLServerCE;
        }
        public string[] mtdValidarConexaoMaxDatabaseSizeSQLServerCE(string Conexao)
        {
            strMaxDatabaseSizeSQLServerCE = mtdValidarConexao(Conexao, vetMaxDatabaseSizeSQLServerCE);
            return strMaxDatabaseSizeSQLServerCE;
        }
        public string[] mtdValidarConexaoPersistSecurityInfoSQLServerCE(string Conexao)
        {
            strPersistSecurityInfoSQLServerCE = mtdValidarConexao(Conexao, vetPersistSecurityInfoSQLServerCE);
            return strPersistSecurityInfoSQLServerCE;
        }

        public string mtdValidarConexaoSQLServerCE(string Conexao)
        {
            string saida = string.Empty;

            prpTipoConexao = TipoConexao.Indisponivel;
            //if (strProviderSQLServerCE == null || strProviderSQLServerCE[1] == cntProviderSQLServerCE[1])
            //{
            mtdValidarConexaoProvedorSQLServerCE(Conexao);
            //}
            if (strProviderSQLServerCE != null)
            {
                prpTipoConexao = TipoConexao.ConexaoSQLServerCEOleDb;
            }
            //if (strDataSourceSQLServerCE == null || strDataSourceSQLServerCE[1] == cntDataSourceSQLServerCE[1])
            //{
            mtdValidarConexaoOrigemDadosSQLServerCE(Conexao);
            //}
            if (strProviderSQLServerCE == null && strDataSourceSQLServerCE != null)
            {
                prpTipoConexao = TipoConexao.ConexaoSQLServerCENativa;
            }
            //if (strPasswordSQLServerCE == null || strPasswordSQLServerCE[1] == cntPasswordSQLServerCE[1])
            //{
            mtdValidarConexaoSenhaSQLServerCE(Conexao);
            //}
            //if (strFileModeSQLServerCE == null || strFileModeSQLServerCE[1] == cntFileModeSQLServerCE[1])
            //{
            mtdValidarConexaoFileModeSQLServerCE(Conexao);
            //}
            //if (strTempFileMaxSizeSQLServerCE == null || strTempFileMaxSizeSQLServerCE[1] == cntTempFileMaxSizeSQLServerCE[1])
            //{
            mtdValidarConexaoTempFileMaxSizeSQLServerCE(Conexao);
            //}
            //if (strEncryptDatabaseSQLServerCE == null || strEncryptDatabaseSQLServerCE[1] == cntEncryptDatabaseSQLServerCE[1])
            //{
            mtdValidarConexaoEncryptDatabaseSQLServerCE(Conexao);
            //}
            //if (strMaxBufferSizeSQLServerCE == null || strMaxBufferSizeSQLServerCE[1] == cntMaxBufferSizeSQLServerCE[1])
            //{
            mtdValidarConexaoMaxBufferSizeSQLServerCE(Conexao);
            //}
            //if (strMaxDatabaseSizeSQLServerCE == null || strMaxDatabaseSizeSQLServerCE[1] == cntMaxDatabaseSizeSQLServerCE[1])
            //{
            mtdValidarConexaoMaxDatabaseSizeSQLServerCE(Conexao);
            //}
            //if (strPersistSecurityInfoSQLServerCE == null || strPersistSecurityInfoSQLServerCE[1] == cntPersistSecurityInfoSQLServerCE[1])
            //{
            mtdValidarConexaoPersistSecurityInfoSQLServerCE(Conexao);
            //}

            if (strProviderSQLServerCE != null)
            {
                saida += string.Format("{0}={1}; ", strProviderSQLServerCE[0], strProviderSQLServerCE[1]);
            }
            if (strDataSourceSQLServerCE != null && blnPermitirBancoDadosSQLServerCE)
            {
                saida += string.Format("{0}={1}; ", strDataSourceSQLServerCE[0], strDataSourceSQLServerCE[1]);
            }
            if (strPasswordSQLServerCE != null)
            {
                saida += string.Format("{0}={1}; ", strPasswordSQLServerCE[0], strPasswordSQLServerCE[1]);
            }
            if (strFileModeSQLServerCE != null)
            {
                saida += string.Format("{0}={1}; ", strFileModeSQLServerCE[0], strFileModeSQLServerCE[1]);
            }
            if (strTempFileMaxSizeSQLServerCE != null)
            {
                saida += string.Format("{0}={1}; ", strTempFileMaxSizeSQLServerCE[0], strTempFileMaxSizeSQLServerCE[1]);
            }
            if (strEncryptDatabaseSQLServerCE != null)
            {
                saida += string.Format("{0}={1}; ", strEncryptDatabaseSQLServerCE[0], strEncryptDatabaseSQLServerCE[1]);
            }
            if (strMaxBufferSizeSQLServerCE != null)
            {
                saida += string.Format("{0}={1}; ", strMaxBufferSizeSQLServerCE[0], strMaxBufferSizeSQLServerCE[1]);
            }
            if (strMaxDatabaseSizeSQLServerCE != null)
            {
                saida += string.Format("{0}={1};", strMaxDatabaseSizeSQLServerCE[0], strMaxDatabaseSizeSQLServerCE[1]);
            }
            if (strPersistSecurityInfoSQLServerCE != null)
            {
                saida += string.Format("{0}={1};", strPersistSecurityInfoSQLServerCE[0], strPersistSecurityInfoSQLServerCE[1]);
            }
            return saida;
        }

        public string mtdDefinirStringConexaoSQLServerCE()
        {
            return mtdDefinirStringConexaoSQLServerCE(prpConexao, true);
        }

        public string mtdDefinirStringConexaoSQLServerCE(bool PermitirBancoDados)
        {
            return mtdDefinirStringConexaoSQLServerCE(prpConexao, PermitirBancoDados);
        }

        public string mtdDefinirStringConexaoSQLServerCE(string Conexao)
        {
            return mtdDefinirStringConexaoSQLServerCE(Conexao, true);
        }

        public string mtdDefinirStringConexaoSQLServerCE(string Conexao, bool PermitirBancoDados)
        {
            blnPermitirBancoDadosSQLServerCE = PermitirBancoDados;
            mtdValidarConexaoSQLServerCE(Conexao);
            return mtdDefinirStringConexaoSQLServerCE(prpTipoConexao,
                prpDataSourceSQLServerCE,
                prpPasswordSQLServerCE,
                prpFileModeSQLServerCE,
                prpTempFileMaxSizeSQLServerCE,
                prpEncryptDatabaseSQLServerCE,
                prpMaxBufferSizeSQLServerCE,
                prpMaxDatabaseSizeSQLServerCE,
                prpPersistSecurityInfoSQLServerCE);
        }

        public string mtdDefinirStringConexaoSQLServerCE(TipoConexao TipoConexao, string DataSource)
        {
            return mtdDefinirStringConexaoSQLServerCE(TipoConexao, DataSource, cntPasswordSQLServerCE[1], cntFileModeSQLServerCE[1], cntTempFileMaxSizeSQLServerCE[1], cntEncryptDatabaseSQLServerCE[1],
                cntMaxBufferSizeSQLServerCE[1], cntMaxDatabaseSizeSQLServerCE[1], cntPersistSecurityInfoSQLServerCE[1]);
        }

        public string mtdDefinirStringConexaoSQLServerCE(TipoConexao TipoConexao, string DataSource, string Password)
        {
            return mtdDefinirStringConexaoSQLServerCE(TipoConexao, DataSource, Password, cntFileModeSQLServerCE[1], cntTempFileMaxSizeSQLServerCE[1], cntEncryptDatabaseSQLServerCE[1],
                cntMaxBufferSizeSQLServerCE[1], cntMaxDatabaseSizeSQLServerCE[1], cntPersistSecurityInfoSQLServerCE[1]);
        }

        public string mtdDefinirStringConexaoSQLServerCE(TipoConexao TipoConexao, string DataSource, string Password, string FileMode, string TempFileMaxSize, string EncryptDatabase,
            string MaxBufferSize, string MaxDatabaseSize, string PersistSecurityInfo)
        {
            return mtdDefinirStringConexaoSQLServerCE(TipoConexao,
                DataSource != string.Empty ? DataSource : cntDataSourceSQLServerCE[1],
                Password != string.Empty ? Password : cntPasswordSQLServerCE[1],
                FileMode != string.Empty ? FileMode : cntFileModeSQLServerCE[1],
                System.Convert.ToInt32(TempFileMaxSize != string.Empty ? TempFileMaxSize : cntTempFileMaxSizeSQLServerCE[1]),
                System.Convert.ToBoolean(EncryptDatabase != string.Empty ? EncryptDatabase : cntEncryptDatabaseSQLServerCE[1]),
                System.Convert.ToInt32(MaxBufferSize != string.Empty ? MaxBufferSize : cntMaxBufferSizeSQLServerCE[1]),
                System.Convert.ToInt32(MaxDatabaseSize != string.Empty ? MaxDatabaseSize : cntMaxDatabaseSizeSQLServerCE[1]),
                System.Convert.ToBoolean(PersistSecurityInfo != string.Empty ? PersistSecurityInfo : cntPersistSecurityInfoSQLServerCE[1]));
        }

        public string mtdDefinirStringConexaoSQLServerCE(TipoConexao TipoConexao, string DataSource, string Password, string FileMode, int TempFileMaxSize, bool EncryptDatabase,
            int MaxBufferSize, int MaxDatabaseSize, bool PersistSecurityInfo)
        {
            enuTipoConexao = TipoConexao;

            string saida = string.Empty;
            switch (TipoConexao)
            {
                case TipoConexao.ConexaoSQLServerCEOleDb:
                    if (DataSource != string.Empty)
                    {
                        DataSource = string.Format("DataBase={0};", DataSource);
                    }
                    saida = string.Format(cntStringConexaoSQLServerCEOleDb.Replace(string.Format("Provider={0}; ", cntProviderSQLServerCE[1]), string.Empty).Replace("Data Source={1}; ", "{1}"), Password, FileMode, TempFileMaxSize, EncryptDatabase, MaxBufferSize, MaxDatabaseSize, PersistSecurityInfo);
                    saida = string.Format("{0}={1}; ", strProviderSQLServerCE[0], strProviderSQLServerCE[1]) + saida;
                    saida = mtdEliminarAtribudoIndisponivelStringConexao(saida);
                    prpTipoSistemaGerenciadorBancoDadosRelacional = TipoSistemaGerenciadorBancoDadosRelacional.OleDb;
                    break;
                case TipoConexao.ConexaoSQLServerCENativa:
                    if (DataSource != string.Empty)
                    {
                        DataSource = string.Format("DataBase={0}; ", DataSource);
                    }
                    saida = string.Format(cntStringConexaoSQLServerCENativa.Replace("Database={2}; ", "{2}"),
                             DataSource, Password, FileMode, TempFileMaxSize, EncryptDatabase, MaxBufferSize, MaxDatabaseSize, PersistSecurityInfo);
                    saida = mtdEliminarAtribudoIndisponivelStringConexao(saida);
                    prpTipoSistemaGerenciadorBancoDadosRelacional = TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE;
                    break;
                case TipoConexao.Indisponivel:
                    saida = TipoConexao.Indisponivel.ToString();
                    prpTipoSistemaGerenciadorBancoDadosRelacional = TipoSistemaGerenciadorBancoDadosRelacional.Indisponivel;
                    break;
            }
            prpConexao = mtdValidarConexaoSQLServerCE(saida);
            return prpConexao.Trim();
        }

    }

    public partial class clsInfraestruturaBancoDados
    {
        // Variaveis do SQLServerCE
        protected System.Data.SqlServerCe.SqlCeConnection objConexaoSQLServerCE = new System.Data.SqlServerCe.SqlCeConnection();
        protected System.Data.SqlServerCe.SqlCeCommand objComandoSQLServerCE = new System.Data.SqlServerCe.SqlCeCommand();
        protected System.Data.SqlServerCe.SqlCeDataAdapter objAdaptadorDadosSQLServerCE = new System.Data.SqlServerCe.SqlCeDataAdapter();
        protected System.Data.SqlServerCe.SqlCeDataReader objLeitorDadosSQLServerCE;

        // Propriedades do SQLServerCE

        public System.Data.SqlServerCe.SqlCeConnection prpConexaoSQLServerCE
        {
            get
            {
                return objConexaoSQLServerCE;
            }
            set
            {
                objConexaoSQLServerCE = value;
            }
        }

        public System.Data.SqlServerCe.SqlCeCommand prpComandoSQLServerCE
        {
            get
            {
                return objComandoSQLServerCE;
            }
            set
            {
                objComandoSQLServerCE = value;
            }
        }

        public System.Data.SqlServerCe.SqlCeDataAdapter prpAdaptadorDadosSQLServerCE
        {
            get
            {
                return objAdaptadorDadosSQLServerCE;
            }
            set
            {
                objAdaptadorDadosSQLServerCE = value;
            }
        }

        public System.Data.SqlServerCe.SqlCeDataReader prpLeitorDadosSQLServerCE
        {
            get
            {
                return objLeitorDadosSQLServerCE;
            }
            set
            {
                objLeitorDadosSQLServerCE = value;
            }
        }

        public void mtdExecutarParametroComandoSQLServerCE
            (
            string NomeParametro,
            object Valor
            )
        {
            System.Data.SqlServerCe.SqlCeParameter objParametroSQLServerCE =
                new System.Data.SqlServerCe.SqlCeParameter
                    (
                    NomeParametro,
                    Valor
                    );
            prpComandoSQLServerCE.Parameters.Add(objParametroSQLServerCE);
        }

        public void mtdExecutarParametroComandoSQLServerCE
            (
            string NomeParametro,
            System.Data.SqlDbType TipoSqlDb,
            object Valor
            )
        {
            System.Data.SqlServerCe.SqlCeParameter objParametroSQLServerCE =
                new System.Data.SqlServerCe.SqlCeParameter
                    (
                    NomeParametro,
                    Valor
                    );
            objParametroSQLServerCE.SqlDbType = TipoSqlDb;
            prpComandoSQLServerCE.Parameters.Add(objParametroSQLServerCE);
        }

        public void mtdExecutarParametroComandoSQLServerCE
           (
            string NomeParametro,
            System.Data.SqlDbType TipoSqlDb,
            object Valor,
            int Tamanho
           )
        {
            System.Data.SqlServerCe.SqlCeParameter objParametroSQLServerCE =
              new System.Data.SqlServerCe.SqlCeParameter
                  (
                  NomeParametro,
                  TipoSqlDb,
                  Tamanho
                  );
            objParametroSQLServerCE.Value = Valor;
            prpComandoSQLServerCE.Parameters.Add(objParametroSQLServerCE);
        }

        public void mtdExecutarParametroComandoSQLServerCE
            (
            string NomeParametro,
            System.Data.SqlDbType TipoSqlDb,
            object Valor,
            int Tamanho,
            string ColunaOrigem
            )
        {
            System.Data.SqlServerCe.SqlCeParameter objParametroSQLServerCE =
                new System.Data.SqlServerCe.SqlCeParameter
                    (
                    NomeParametro,
                    TipoSqlDb,
                    Tamanho,
                    ColunaOrigem
                    );
            objParametroSQLServerCE.Value = Valor;
            prpComandoSQLServerCE.Parameters.Add(objParametroSQLServerCE);
        }

        public void mtdExecutarParametroComandoSQLServerCE
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
            System.Data.SqlServerCe.SqlCeParameter objParametroSQLServerCE =
                new System.Data.SqlServerCe.SqlCeParameter
                    (
                    NomeParametro,
                    TipoSqlDb,
                    Tamanho,
                    OrigemColuna
                    );
            objParametroSQLServerCE.SourceVersion = OrigemVersao;
            objParametroSQLServerCE.Direction = DirecaoParametro;
            objParametroSQLServerCE.Value = Valor;
            prpComandoSQLServerCE.Parameters.Add(objParametroSQLServerCE);
        }
    }
    
    public partial class clsImplementacaoBancoDados
    {
        // SQLServerCE

        private string strParametroSQLServerCE = @"@";

        public bool mtdCompactarBancoDadosSQLServerCE()
        {
            return mtdCompactarBancoDadosSQLServerCE(prpDataSourceSQLServerCE);
        }

        public bool mtdCompactarBancoDadosSQLServerCE(string BancoDados)
        {
            bool saida = true;

            System.Exception ex = new System.Exception("Não há banco de dados (arquivo) a ser compactado.");
            System.Data.SqlServerCe.SqlCeEngine objSqlServerCeEngine = default(System.Data.SqlServerCe.SqlCeEngine);

            string[] vetBancoDados = BancoDados.Split('.');
            string NovoBancoDados = string.Format("{0}_compactado_reparado.{1}", vetBancoDados[0], vetBancoDados[1]);

            prpDataSourceSQLServerCE = BancoDados;
            string strConexao = mtdDefinirStringConexaoSQLServerCE();
            mtdFecharConexao();
            try
            {
                if (System.IO.File.Exists(BancoDados))
                {
                    objSqlServerCeEngine = new System.Data.SqlServerCe.SqlCeEngine(strConexao);
                    objSqlServerCeEngine.Compact(null);
                    objSqlServerCeEngine.Compact(strConexao);
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

        public bool mtdEncolherBancoDadosSQLServerCE()
        {
            return mtdEncolherBancoDadosSQLServerCE(prpDataSourceSQLServerCE);
        }

        public bool mtdEncolherBancoDadosSQLServerCE(string BancoDados)
        {
            bool saida = false;

            System.Exception ex = new System.Exception("Não há banco de dados (arquivo) a ser compactado.");
            System.Data.SqlServerCe.SqlCeEngine objSqlServerCeEngine = null;

            string[] vetBancoDados = BancoDados.Split('.');
            string NovoBancoDados = string.Format("{0}_compactado_reparado.{1}", vetBancoDados[0], vetBancoDados[1]);

            prpDataSourceSQLServerCE = BancoDados;
            string strConexao = mtdDefinirStringConexaoSQLServerCE();
            mtdFecharConexao();
            try
            {
                if (!System.IO.File.Exists(NovoBancoDados))
                {
                    objSqlServerCeEngine = new System.Data.SqlServerCe.SqlCeEngine(strConexao);
                    objSqlServerCeEngine.Shrink();
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

        public bool mtdRepararBancoDadosSQLServerCE()
        {
            return mtdRepararBancoDadosSQLServerCE(prpDataSourceSQLServerCE, System.Data.SqlServerCe.RepairOption.RecoverCorruptedRows);
        }

        public bool mtdRepararBancoDadosSQLServerCE(System.Data.SqlServerCe.RepairOption OpcaoReparar)
        {
            return mtdRepararBancoDadosSQLServerCE(prpDataSourceSQLServerCE, OpcaoReparar);
        }

        public bool mtdRepararBancoDadosSQLServerCE(string BancoDados)
        {
            return mtdRepararBancoDadosSQLServerCE(BancoDados, System.Data.SqlServerCe.RepairOption.RecoverCorruptedRows);
        }

        public bool mtdRepararBancoDadosSQLServerCE(string BancoDados, System.Data.SqlServerCe.RepairOption OpcaoReparar)
        {
            bool saida = false;

            System.Exception ex = new System.Exception("Não há banco de dados (arquivo) a ser reparado.");
            System.Data.SqlServerCe.SqlCeEngine objSqlServerCeEngine = null;
            string[] vetBancoDados = BancoDados.Split('.');
            string NovoBancoDados = string.Format("{0}_compactado_reparado.{1}", vetBancoDados[0], vetBancoDados[1]);

            prpDataSourceSQLServerCE = BancoDados;
            string strConexao = mtdDefinirStringConexaoSQLServerCE();
            mtdFecharConexao();
            try
            {
                if (System.IO.File.Exists(BancoDados))
                {
                    objSqlServerCeEngine = new System.Data.SqlServerCe.SqlCeEngine(strConexao);
                    objSqlServerCeEngine.Repair(null, OpcaoReparar);
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

        public bool mtdAlterarBancoDadosSQLServerCE(string NovoBancoDados)
        {
            return mtdAlterarBancoDadosSQLServerCE(prpDataSourceSQLServerCE, NovoBancoDados);
        }

        public bool mtdAlterarBancoDadosSQLServerCE(string BancoDados, string NovoBancoDados)
        {
            bool saida = true;

            System.Exception ex = new System.Exception("Não há banco de dados (arquivo) a ser alterado.");

            try
            {
                prpDataSourceSQLServerCE = BancoDados;
                mtdDefinirStringConexaoSQLServerCE();
                mtdFecharConexao();
                prpDataSourceSQLServerCE = NovoBancoDados;
                mtdDefinirStringConexaoSQLServerCE();
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

        public bool mtdCriarBancoDadosSQLServerCE()
        {
            return mtdCriarBancoDadosSQLServerCE(prpDataSourceSQLServerCE);
        }

        public bool mtdCriarBancoDadosSQLServerCE(string BancoDados)
        {
            bool saida = true;

            System.Exception ex = new System.Exception("Já existe um banco de dados (arquivo) com esse nome.");

            try
            {
                prpDataSourceSQLServerCE = BancoDados;
                mtdDefinirStringConexaoSQLServerCE();
                mtdFecharConexao();
                if (!System.IO.File.Exists(BancoDados))
                {
                    System.Data.SqlServerCe.SqlCeEngine objSqlCeEngine = new System.Data.SqlServerCe.SqlCeEngine(prpConexao);
                    objSqlCeEngine.CreateDatabase();
                    objSqlCeEngine.Dispose();
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

        public bool mtdDeletarBancoDadosSQLServerCE()
        {
            return mtdDeletarBancoDadosSQLServerCE(prpDataSourceSQLServerCE);
        }

        public bool mtdDeletarBancoDadosSQLServerCE(string BancoDados)
        {
            bool saida = true;

            System.Exception ex = new System.Exception("Não há banco de dados (arquivo) a ser deletado.");

            try
            {
                prpDataSourceSQLServerCE = BancoDados;
                mtdDefinirStringConexaoSQLServerCE();
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




        private bool mtdAtualizarDadosParametroComandoSQLServerCEValor(string NomeTabela, object[,] Campos_Dados, string CampoBase, string Operacao, object DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 1;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
            string[] vetNomeColunas = null;
            object[] vetRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados != null)
            {
                if (Campos_Dados.GetLength(0) >= intLinhasAdicionais + 1)
                {
                    strCampoBase = CampoBase;
                    strOperacao = Operacao;
                    objDadoBase = CampoBase;

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

                        strTexto = string.Empty;
                        prpComandoSQLServerCE.Parameters.Clear();

                        for (int coluna = Campos_Dados.GetLowerBound(1);
                            coluna <=
                            (
                            Campos_Dados.GetUpperBound(1)
                            );
                            coluna++)
                        {
                            switch (linha)
                            {
                                case (0):
                                    vetNomeColunas[coluna] = (string)Campos_Dados[linha, coluna];
                                    break;
                                default:
                                    vetRegistrosColunas[coluna] = (object)Campos_Dados[linha, coluna];

                                    mtdExecutarParametroComandoSQLServerCE
                                        (
                                        vetNomeColunas[coluna],
                                        vetRegistrosColunas[coluna]
                                        );

                                    strTexto +=
                                        string.Format
                                        (
                                        (coluna == Campos_Dados.GetUpperBound(1)) ?
                                        @"{0} = {2}{1}" :
                                        @"{0} = {2}{1}, ",
                                        vetNomeColunas[coluna],
                                        vetNomeColunas[coluna],
                                        strParametroSQLServerCE
                                        );
                                    break;
                            }
                        }
                        if (linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais)
                        {
                            mtdExecutarParametroComandoSQLServerCE
                               (
                               string.Format("Alterar_{0}", strCampoBase),
                               objDadoBase
                               );

                            saida &= mtdExecutarComando
                                (
                                string.Format
                                (
                                @"UPDATE {0} SET {1} WHERE {2} {3} {4}Alterar_{2};",
                                NomeTabela,
                                strTexto,
                                strCampoBase,
                                strOperacao,
                                strParametroSQLServerCE
                                )
                                );
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        private bool mtdAtualizarDadosParametroComandoSQLServerCEValorTipo(string NomeTabela, object[,] Campos_Dados, string CampoBase, string Operacao, object DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 2;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
            string[] vetNomeColunas = null;
            System.Data.SqlDbType[] vetTipoColunas = null;
            object[] vetRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados != null)
            {
                if (Campos_Dados.GetLength(0) >= intLinhasAdicionais + 1)
                {
                    strCampoBase = CampoBase;
                    strOperacao = Operacao;
                    objDadoBase = DadoBase;

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

                        strTexto = string.Empty;
                        prpComandoSQLServerCE.Parameters.Clear();

                        for (int coluna = Campos_Dados.GetLowerBound(1);
                            coluna <=
                            (
                            Campos_Dados.GetUpperBound(1)
                            );
                            coluna++)
                        {
                            switch (linha)
                            {
                                case (0):
                                    vetNomeColunas[coluna] = (string)Campos_Dados[linha, coluna];
                                    break;
                                case (1):
                                    if (Campos_Dados[linha, coluna] != null)
                                    {
                                        vetTipoColunas[coluna] = (System.Data.SqlDbType)Campos_Dados[linha, coluna];
                                    }
                                    else
                                    {
                                        vetTipoColunas[coluna] = System.Data.SqlDbType.Variant;
                                    }
                                    break;
                                default:
                                    vetRegistrosColunas[coluna] = (object)Campos_Dados[linha, coluna];

                                    if (Campos_Dados[1, coluna] != null)
                                    {
                                        mtdExecutarParametroComandoSQLServerCE
                                            (
                                            vetNomeColunas[coluna],
                                            vetTipoColunas[coluna],
                                            vetRegistrosColunas[coluna]
                                            );
                                    }
                                    else
                                    {
                                        mtdExecutarParametroComandoSQLServerCE
                                            (
                                            vetNomeColunas[coluna],
                                            vetRegistrosColunas[coluna]
                                            );
                                    }

                                    strTexto +=
                                        string.Format
                                        (
                                        (coluna == Campos_Dados.GetUpperBound(1)) ?
                                        @"{0} = {2}{1}" :
                                        @"{0} = {2}{1}, ",
                                        vetNomeColunas[coluna],
                                        vetNomeColunas[coluna],
                                        strParametroSQLServerCE
                                        );
                                    break;
                            }
                        }
                        if (linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais)
                        {
                            mtdExecutarParametroComandoSQLServerCE
                               (
                               string.Format("Alterar_{0}", strCampoBase),
                               objDadoBase
                               );

                            saida &= mtdExecutarComando
                                (
                                string.Format
                                (
                                @"UPDATE {0} SET {1} WHERE {2} {3} {4}Alterar_{2};",
                                NomeTabela,
                                strTexto,
                                strCampoBase,
                                strOperacao,
                                strParametroSQLServerCE
                                )
                                );
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        private bool mtdAtualizarDadosParametroComandoSQLServerCEValorTipoTamanho(string NomeTabela, object[,] Campos_Dados, string CampoBase, string Operacao, object DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 3;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
            string[] vetNomeColunas = null;
            System.Data.SqlDbType[] vetTipoColunas = null;
            int[] vetTamanhoColunas = null;
            object[] vetRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados != null)
            {
                if (Campos_Dados.GetLength(0) >= intLinhasAdicionais + 1)
                {
                    strCampoBase = CampoBase;
                    strOperacao = Operacao;
                    objDadoBase = DadoBase;

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

                        strTexto = string.Empty;
                        prpComandoSQLServerCE.Parameters.Clear();

                        for (int coluna = Campos_Dados.GetLowerBound(1);
                            coluna <=
                            (
                            Campos_Dados.GetUpperBound(1)
                            );
                            coluna++)
                        {
                            switch (linha)
                            {
                                case (0):
                                    vetNomeColunas[coluna] = (string)Campos_Dados[linha, coluna];
                                    break;
                                case (1):
                                    if (Campos_Dados[linha, coluna] != null)
                                    {
                                        vetTipoColunas[coluna] = (System.Data.SqlDbType)Campos_Dados[linha, coluna];
                                    }
                                    else
                                    {
                                        vetTipoColunas[coluna] = System.Data.SqlDbType.Variant;
                                    }
                                    break;
                                case (2):
                                    if (Campos_Dados[linha, coluna] != null)
                                    {
                                        vetTamanhoColunas[coluna] = (int)Campos_Dados[linha, coluna];
                                    }
                                    else
                                    {
                                        vetTamanhoColunas[coluna] = (int)0;
                                    }
                                    break;
                                default:
                                    vetRegistrosColunas[coluna] = (object)Campos_Dados[linha, coluna];

                                    if (Campos_Dados[1, coluna] != null)
                                    {
                                        if (Campos_Dados[2, coluna] != null)
                                        {
                                            mtdExecutarParametroComandoSQLServerCE
                                                (
                                                vetNomeColunas[coluna],
                                                vetTipoColunas[coluna],
                                                vetRegistrosColunas[coluna],
                                                vetTamanhoColunas[coluna]
                                                );
                                        }
                                        else
                                        {
                                            mtdExecutarParametroComandoSQLServerCE
                                                (
                                                vetNomeColunas[coluna],
                                                vetTipoColunas[coluna],
                                                vetRegistrosColunas[coluna]
                                                );
                                        }
                                    }
                                    else
                                    {
                                        mtdExecutarParametroComandoSQLServerCE
                                            (
                                            vetNomeColunas[coluna],
                                            vetRegistrosColunas[coluna]
                                            );
                                    }

                                    strTexto +=
                                        string.Format
                                        (
                                        (coluna == Campos_Dados.GetUpperBound(1)) ?
                                        @"{0} = {2}{1}" :
                                        "{0} = {2}{1}, ",
                                        vetNomeColunas[coluna],
                                        vetNomeColunas[coluna],
                                        strParametroSQLServerCE
                                        );
                                    break;
                            }
                        }
                        if (linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais)
                        {
                            mtdExecutarParametroComandoSQLServerCE
                               (
                               string.Format("Alterar_{0}", strCampoBase),
                               objDadoBase
                               );

                            saida &= mtdExecutarComando
                                (
                                string.Format
                                (
                                @"UPDATE {0} SET {1} WHERE {2} {3} {4}Alterar_{2};",
                                NomeTabela,
                                strTexto,
                                strCampoBase,
                                strOperacao,
                                strParametroSQLServerCE
                                )
                                );
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        public bool mtdAtualizarDadosParametroComandoSQLServerCE(string NomeTabela, object[,] Campos_Dados, string CampoBase, string Operacao, object DadoBase, enmModoParametroComando ModoParametroComando)
        {
            bool saida = false;
            switch (ModoParametroComando)
            {
                case enmModoParametroComando.Valor:
                    saida = mtdAtualizarDadosParametroComandoSQLServerCEValor(NomeTabela, Campos_Dados, CampoBase, Operacao, DadoBase);
                    break;
                case enmModoParametroComando.ValorTipo:
                    saida = mtdAtualizarDadosParametroComandoSQLServerCEValorTipo(NomeTabela, Campos_Dados, CampoBase, Operacao, DadoBase);
                    break;
                case enmModoParametroComando.ValorTipoTamanho:
                    saida = mtdAtualizarDadosParametroComandoSQLServerCEValorTipoTamanho(NomeTabela, Campos_Dados, CampoBase, Operacao, DadoBase);
                    break;
            }
            return saida;
        }

        private bool mtdAtualizarDadosParametroComandoSQLServerCEValor(string NomeTabela, object[][] Campos_Dados, string CampoBase, string Operacao, object DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 1;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
            string[] vetNomeColunas = null;
            object[] vetRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados != null)
            {
                if (Campos_Dados.GetLength(0) >= intLinhasAdicionais + 1)
                {
                    for (int linha = Campos_Dados.GetLowerBound(0); linha <= Campos_Dados.GetUpperBound(0); linha++)
                    {
                        strCampoBase = CampoBase;
                        strOperacao = Operacao;
                        objDadoBase = DadoBase;

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

                            strTexto = string.Empty;
                            prpComandoSQLServerCE.Parameters.Clear();

                            for (int coluna = Campos_Dados[linha].GetLowerBound(0);
                                coluna <=
                                (
                                Campos_Dados[linha].GetUpperBound(0)
                                );
                                coluna++)
                            {
                                switch (linha)
                                {
                                    case (0):
                                        vetNomeColunas[coluna] = (string)Campos_Dados[linha][coluna];
                                        break;
                                    default:
                                        vetRegistrosColunas[coluna] = (object)Campos_Dados[linha][coluna];

                                        mtdExecutarParametroComandoSQLServerCE
                                            (
                                            vetNomeColunas[coluna],
                                            vetRegistrosColunas[coluna]
                                            );

                                        strTexto +=
                                            string.Format
                                            (
                                            (coluna == Campos_Dados[linha].GetUpperBound(0)) ?
                                            @"{0} = {2}{1}" :
                                            "{0} = {2}{1}, ",
                                            vetNomeColunas[coluna],
                                            vetNomeColunas[coluna],
                                            strParametroSQLServerCE
                                            );
                                        break;
                                }
                            }
                            if (linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais)
                            {
                                mtdExecutarParametroComandoSQLServerCE
                                   (
                                   string.Format("Alterar_{0}", strCampoBase),
                                   objDadoBase
                                   );

                                saida &= mtdExecutarComando
                                    (
                                    string.Format
                                    (
                                    @"UPDATE {0} SET {1} WHERE {2} {3} {4}Alterar_{2};",
                                    NomeTabela,
                                    strTexto,
                                    strCampoBase,
                                    strOperacao,
                                    strParametroSQLServerCE
                                    )
                                    );
                            }
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        private bool mtdAtualizarDadosParametroComandoSQLServerCEValorTipo(string NomeTabela, object[][] Campos_Dados, string CampoBase, string Operacao, object DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 2;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
            string[] vetNomeColunas = null;
            System.Data.SqlDbType[] vetTipoColunas = null;
            object[] vetRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados != null)
            {
                if (Campos_Dados.GetLength(0) >= intLinhasAdicionais + 1)
                {
                    strCampoBase = CampoBase;
                    strOperacao = Operacao;
                    objDadoBase = DadoBase;

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

                            strTexto = string.Empty;
                            prpComandoSQLServerCE.Parameters.Clear();

                            for (int coluna = Campos_Dados[linha].GetLowerBound(0);
                                coluna <=
                                (
                                Campos_Dados[linha].GetUpperBound(0)
                                );
                                coluna++)
                            {
                                switch (linha)
                                {
                                    case (0):
                                        vetNomeColunas[coluna] = (string)Campos_Dados[linha][coluna];
                                        break;
                                    case (1):
                                        if (Campos_Dados[linha][coluna] != null)
                                        {
                                            vetTipoColunas[coluna] = (System.Data.SqlDbType)Campos_Dados[linha][coluna];
                                        }
                                        else
                                        {
                                            vetTipoColunas[coluna] = System.Data.SqlDbType.Variant;
                                        }
                                        break;
                                    default:
                                        vetRegistrosColunas[coluna] = (object)Campos_Dados[linha][coluna];

                                        if (Campos_Dados[1][coluna] != null)
                                        {
                                            mtdExecutarParametroComandoSQLServerCE
                                                (
                                                vetNomeColunas[coluna],
                                                vetTipoColunas[coluna],
                                                vetRegistrosColunas[coluna]
                                                );
                                        }
                                        else
                                        {
                                            mtdExecutarParametroComandoSQLServerCE
                                                (
                                                vetNomeColunas[coluna],
                                                vetRegistrosColunas[coluna]
                                                );
                                        }

                                        strTexto +=
                                            string.Format
                                            (
                                            (coluna == Campos_Dados[linha].GetUpperBound(0)) ?
                                            @"{0} = {2}{1}" :
                                            @"{0} = {2}{1}, ",
                                            vetNomeColunas[coluna],
                                            vetNomeColunas[coluna],
                                            strParametroSQLServerCE
                                            );
                                        break;
                                }
                            }
                            if (linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais)
                            {
                                mtdExecutarParametroComandoSQLServerCE
                                   (
                                   string.Format("Alterar_{0}", strCampoBase),
                                   objDadoBase
                                   );

                                saida &= mtdExecutarComando
                                    (
                                    string.Format
                                    (
                                    "UPDATE {0} SET {1} WHERE {2} {3} {4}Alterar_{2};",
                                    NomeTabela,
                                    strTexto,
                                    strCampoBase,
                                    strOperacao,
                                    strParametroSQLServerCE
                                    )
                                    );
                            }
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        private bool mtdAtualizarDadosParametroComandoSQLServerCEValorTipoTamanho(string NomeTabela, object[][] Campos_Dados, string CampoBase, string Operacao, object DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 3;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
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
                                    strCampoBase = (string)Campos_Dados[linha][Campos_Dados[linha].GetUpperBound(0) - 2];
                                    strOperacao = (string)Campos_Dados[linha][Campos_Dados.GetUpperBound(0) - 1];
                                    objDadoBase = Campos_Dados[linha][Campos_Dados[linha].GetUpperBound(0)];
                                    vetRegistrosColunas = new object[Campos_Dados[linha].GetUpperBound(0) + 1];
                                    break;
                            }

                            strTexto = string.Empty;
                            prpComandoSQLServerCE.Parameters.Clear();

                            for (int coluna = Campos_Dados[linha].GetLowerBound(0);
                                coluna <=
                                (
                                Campos_Dados[linha].GetUpperBound(0)
                                );
                                coluna++)
                            {
                                switch (linha)
                                {
                                    case (0):
                                        vetNomeColunas[coluna] = (string)Campos_Dados[linha][coluna];
                                        break;
                                    case (1):
                                        if (Campos_Dados[linha][coluna] != null)
                                        {
                                            vetTipoColunas[coluna] = (System.Data.SqlDbType)Campos_Dados[linha][coluna];
                                        }
                                        else
                                        {
                                            vetTipoColunas[coluna] = System.Data.SqlDbType.Variant;
                                        }
                                        break;
                                    case (2):
                                        if (Campos_Dados[linha][coluna] != null)
                                        {
                                            vetTamanhoColunas[coluna] = (int)Campos_Dados[linha][coluna];
                                        }
                                        else
                                        {
                                            vetTamanhoColunas[coluna] = (int)0;
                                        }
                                        break;
                                    default:
                                        vetRegistrosColunas[coluna] = (object)Campos_Dados[linha][coluna];

                                        if (Campos_Dados[1][coluna] != null)
                                        {
                                            if (Campos_Dados[2][coluna] != null)
                                            {
                                                mtdExecutarParametroComandoSQLServerCE
                                                    (
                                                    vetNomeColunas[coluna],
                                                    vetTipoColunas[coluna],
                                                    vetRegistrosColunas[coluna],
                                                    vetTamanhoColunas[coluna]
                                                    );
                                            }
                                            else
                                            {
                                                mtdExecutarParametroComandoSQLServerCE
                                                    (
                                                    vetNomeColunas[coluna],
                                                    vetTipoColunas[coluna],
                                                    vetRegistrosColunas[coluna]
                                                    );
                                            }
                                        }
                                        else
                                        {
                                            mtdExecutarParametroComandoSQLServerCE
                                                (
                                                vetNomeColunas[coluna],
                                                vetRegistrosColunas[coluna]
                                                );
                                        }

                                        strTexto +=
                                            string.Format
                                            (
                                            (coluna == Campos_Dados[linha].GetUpperBound(0) - 3) ?
                                            @"{0} = {2}{1}" :
                                            @"{0} = {2}{1}, ",
                                            vetNomeColunas[coluna],
                                            vetNomeColunas[coluna],
                                            strParametroSQLServerCE
                                            );
                                        break;
                                }
                            }
                            if (linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais)
                            {
                                mtdExecutarParametroComandoSQLServerCE
                                    (
                                    string.Format("Alterar_{0}", strCampoBase),
                                    objDadoBase
                                    );

                                saida &= mtdExecutarComando
                                    (
                                    string.Format
                                    (
                                    "UPDATE {0} SET {1} WHERE {2} {3} {4}Alterar_{2};",
                                    NomeTabela,
                                    strTexto,
                                    strCampoBase,
                                    strOperacao,
                                    strParametroSQLServerCE
                                    )
                                    );
                            }
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        public bool mtdAtualizarDadosParametroComandoSQLServerCE(string NomeTabela, object[][] Campos_Dados, string CampoBase, string Operacao, object DadoBase, enmModoParametroComando ModoParametroComando)
        {
            bool saida = false;
            switch (ModoParametroComando)
            {
                case enmModoParametroComando.Valor:
                    saida = mtdAtualizarDadosParametroComandoSQLServerCEValor(NomeTabela, Campos_Dados, CampoBase, Operacao, DadoBase);
                    break;
                case enmModoParametroComando.ValorTipo:
                    saida = mtdAtualizarDadosParametroComandoSQLServerCEValorTipo(NomeTabela, Campos_Dados, CampoBase, Operacao, DadoBase);
                    break;
                case enmModoParametroComando.ValorTipoTamanho:
                    saida = mtdAtualizarDadosParametroComandoSQLServerCEValorTipoTamanho(NomeTabela, Campos_Dados, CampoBase, Operacao, DadoBase);
                    break;
            }
            return saida;
        }



        private bool mtdAtualizarDadosParametroComandoSQLServerCEValor(string NomeTabela, List<List<object>> Campos_Dados, string CampoBase, string Operacao, object DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 1;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
            List<string> lstNomeColunas = null;
            List<object> lstRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados != null)
            {
                if (Campos_Dados.Count >= intLinhasAdicionais + 1)
                {
                    for (int linha = 0; linha <= Campos_Dados.Count - 1; linha++)
                    {
                        strCampoBase = CampoBase;
                        strOperacao = Operacao;
                        objDadoBase = DadoBase;

                        if (Campos_Dados[linha] != null)
                        {
                            switch (linha)
                            {
                                case (0):
                                    lstNomeColunas = new List<string> { };
                                    break;
                                default:
                                    lstRegistrosColunas = new List<object> { };
                                    break;
                            }

                            strTexto = string.Empty;
                            prpComandoSQLServerCE.Parameters.Clear();

                            for (int coluna = 0;
                                coluna <=
                                (
                                Campos_Dados[linha].Count - 1
                                );
                                coluna++)
                            {
                                switch (linha)
                                {
                                    case (0):
                                        //lstNomeColunas[coluna] = (string)Campos_Dados[linha][coluna];
                                        lstNomeColunas.Add((string)Campos_Dados[linha][coluna]);
                                        break;
                                    default:
                                        //lstRegistrosColunas[coluna] = (object)Campos_Dados[linha][coluna];
                                        lstRegistrosColunas.Add((object)Campos_Dados[linha][coluna]);

                                        mtdExecutarParametroComandoSQLServerCE
                                            (
                                            lstNomeColunas[coluna],
                                            lstRegistrosColunas[coluna]
                                            );

                                        strTexto +=
                                            string.Format
                                            (
                                            (coluna == Campos_Dados[linha].Count - 1) ?
                                            @"{0} = {2}{1}" :
                                            @"{0} = {2}{1}, ",
                                            lstNomeColunas[coluna],
                                            lstNomeColunas[coluna],
                                            strParametroSQLServerCE
                                            );
                                        break;
                                }
                            }
                            if (linha >= 0 + intLinhasAdicionais)
                            {
                                mtdExecutarParametroComandoSQLServerCE
                                   (
                                   string.Format("Alterar_{0}", strCampoBase),
                                   objDadoBase
                                   );

                                saida &= mtdExecutarComando
                                    (
                                    string.Format
                                    (
                                    "UPDATE {0} SET {1} WHERE {2} {3} {4}Alterar_{2};",
                                    NomeTabela,
                                    strTexto,
                                    strCampoBase,
                                    strOperacao,
                                    strParametroSQLServerCE
                                    )
                                    );
                            }
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        private bool mtdAtualizarDadosParametroComandoSQLServerCEValorTipo(string NomeTabela, List<List<object>> Campos_Dados, string CampoBase, string Operacao, object DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 2;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
            List<string> lstNomeColunas = null;
            List<System.Data.SqlDbType> lstTipoColunas = null;
            List<object> lstRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados != null)
            {
                if (Campos_Dados.Count >= intLinhasAdicionais + 1)
                {
                    strCampoBase = CampoBase;
                    strOperacao = Operacao;
                    objDadoBase = DadoBase;

                    for (int linha = 0; linha <= Campos_Dados.Count - 1; linha++)
                    {
                        if (Campos_Dados[linha] != null)
                        {
                            switch (linha)
                            {
                                case (0):
                                    lstNomeColunas = new List<string> { };
                                    break;
                                case (1):
                                    lstTipoColunas = new List<System.Data.SqlDbType> { };
                                    break;
                                default:
                                    lstRegistrosColunas = new List<object> { };
                                    break;
                            }

                            strTexto = string.Empty;
                            prpComandoSQLServerCE.Parameters.Clear();

                            for (int coluna = 0;
                                coluna <=
                                (
                                Campos_Dados[linha].Count - 1
                                );
                                coluna++)
                            {
                                switch (linha)
                                {
                                    case (0):
                                        //lstNomeColunas[coluna] = (string)Campos_Dados[linha][coluna];
                                        lstNomeColunas.Add((string)Campos_Dados[linha][coluna]);
                                        break;
                                    case (1):
                                        if (Campos_Dados[linha][coluna] != null)
                                        {
                                            //lstTipoColunas[coluna] = (System.Data.SqlDbType)Campos_Dados[linha][coluna];
                                            lstTipoColunas.Add((System.Data.SqlDbType)Campos_Dados[linha][coluna]);
                                        }
                                        else
                                        {
                                            //lstTipoColunas[coluna] = System.Data.SqlDbType.Variant;
                                            lstTipoColunas.Add(System.Data.SqlDbType.Variant);
                                        }
                                        break;
                                    default:
                                        //lstRegistrosColunas[coluna] = (object)Campos_Dados[linha][coluna];
                                        lstRegistrosColunas.Add((object)Campos_Dados[linha][coluna]);

                                        if (Campos_Dados[1][coluna] != null)
                                        {
                                            mtdExecutarParametroComandoSQLServerCE
                                                (
                                                lstNomeColunas[coluna],
                                                lstTipoColunas[coluna],
                                                lstRegistrosColunas[coluna]
                                                );
                                        }
                                        else
                                        {
                                            mtdExecutarParametroComandoSQLServerCE
                                                (
                                                lstNomeColunas[coluna],
                                                lstRegistrosColunas[coluna]
                                                );
                                        }

                                        strTexto +=
                                            string.Format
                                            (
                                            (coluna == Campos_Dados[linha].Count - 1) ?
                                            @"{0} = {2}{1}" :
                                            @"{0} = {2}{1}, ",
                                            lstNomeColunas[coluna],
                                            lstNomeColunas[coluna],
                                            strParametroSQLServerCE
                                            );
                                        break;
                                }
                            }
                            if (linha >= 0 + intLinhasAdicionais)
                            {
                                mtdExecutarParametroComandoSQLServerCE
                                   (
                                   string.Format("Alterar_{0}", strCampoBase),
                                   objDadoBase
                                   );

                                saida &= mtdExecutarComando
                                    (
                                    string.Format
                                    (
                                    "UPDATE {0} SET {1} WHERE {2} {3} {4}Alterar_{2};",
                                    NomeTabela,
                                    strTexto,
                                    strCampoBase,
                                    strOperacao,
                                    strParametroSQLServerCE
                                    )
                                    );
                            }
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        private bool mtdAtualizarDadosParametroComandoSQLServerCEValorTipoTamanho(string NomeTabela, List<List<object>> Campos_Dados, string CampoBase, string Operacao, object DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 3;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
            List<string> lstNomeColunas = null;
            List<System.Data.SqlDbType> lstTipoColunas = null;
            List<int> lstTamanhoColunas = null;
            List<object> lstRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados != null)
            {
                if (Campos_Dados.Count >= intLinhasAdicionais + 1)
                {
                    for (int linha = 0; linha <= Campos_Dados.Count - 1; linha++)
                    {
                        if (Campos_Dados[linha] != null)
                        {
                            switch (linha)
                            {
                                case (0):
                                    lstNomeColunas = new List<string> { };
                                    break;
                                case (1):
                                    lstTipoColunas = new List<System.Data.SqlDbType> { };
                                    break;
                                case (2):
                                    lstTamanhoColunas = new List<int> { };
                                    break;
                                default:
                                    strCampoBase = (string)Campos_Dados[linha][Campos_Dados[linha].Count - 1 - 2];
                                    strOperacao = (string)Campos_Dados[linha][Campos_Dados.Count - 1 - 1];
                                    objDadoBase = Campos_Dados[linha][Campos_Dados[linha].Count - 1];
                                    lstRegistrosColunas = new List<object>(Campos_Dados[linha].Count - 1 + 1);
                                    break;
                            }

                            strTexto = string.Empty;
                            prpComandoSQLServerCE.Parameters.Clear();

                            for (int coluna = 0;
                                coluna <=
                                (
                                Campos_Dados[linha].Count - 1
                                );
                                coluna++)
                            {
                                switch (linha)
                                {
                                    case (0):
                                        //lstNomeColunas[coluna] = (string)Campos_Dados[linha][coluna];
                                        lstNomeColunas.Add((string)Campos_Dados[linha][coluna]);
                                        break;
                                    case (1):
                                        if (Campos_Dados[linha][coluna] != null)
                                        {
                                            //lstTipoColunas[coluna] = (System.Data.SqlDbType)Campos_Dados[linha][coluna];
                                            lstTipoColunas.Add((System.Data.SqlDbType)Campos_Dados[linha][coluna]);
                                        }
                                        else
                                        {
                                            //lstTipoColunas[coluna] = System.Data.SqlDbType.Variant;
                                            lstTipoColunas.Add(System.Data.SqlDbType.Variant);
                                        }
                                        break;
                                    case (2):
                                        if (Campos_Dados[linha][coluna] != null)
                                        {
                                            //lstTamanhoColunas[coluna] = (int)Campos_Dados[linha][coluna];
                                            lstTamanhoColunas.Add((int)Campos_Dados[linha][coluna]);
                                        }
                                        else
                                        {
                                            //lstTamanhoColunas[coluna] = (int)0;
                                            lstTamanhoColunas.Add((int)0);
                                        }
                                        break;
                                    default:
                                        //lstRegistrosColunas[coluna] = (object)Campos_Dados[linha][coluna];
                                        lstRegistrosColunas.Add((object)Campos_Dados[linha][coluna]);

                                        if (Campos_Dados[1][coluna] != null)
                                        {
                                            if (Campos_Dados[2][coluna] != null)
                                            {
                                                mtdExecutarParametroComandoSQLServerCE
                                                    (
                                                    lstNomeColunas[coluna],
                                                    lstTipoColunas[coluna],
                                                    lstRegistrosColunas[coluna],
                                                    lstTamanhoColunas[coluna]
                                                    );
                                            }
                                            else
                                            {
                                                mtdExecutarParametroComandoSQLServerCE
                                                    (
                                                    lstNomeColunas[coluna],
                                                    lstTipoColunas[coluna],
                                                    lstRegistrosColunas[coluna]
                                                    );
                                            }
                                        }
                                        else
                                        {
                                            mtdExecutarParametroComandoSQLServerCE
                                                (
                                                lstNomeColunas[coluna],
                                                lstRegistrosColunas[coluna]
                                                );
                                        }

                                        strTexto +=
                                            string.Format
                                            (
                                            (coluna == Campos_Dados[linha].Count - 1 - 3) ?
                                            @"{0} = {2}{1}" :
                                            @"{0} = {2}{1}, ",
                                            lstNomeColunas[coluna],
                                            lstNomeColunas[coluna],
                                            strParametroSQLServerCE
                                            );
                                        break;
                                }
                            }
                            if (linha >= Campos_Dados.Count - 1 + intLinhasAdicionais)
                            {
                                mtdExecutarParametroComandoSQLServerCE
                                    (
                                    string.Format("Alterar_{0}", strCampoBase),
                                    objDadoBase
                                    );

                                saida &= mtdExecutarComando
                                    (
                                    string.Format
                                    (
                                    "UPDATE {0} SET {1} WHERE {2} {3} {4}Alterar_{2};",
                                    NomeTabela,
                                    strTexto,
                                    strCampoBase,
                                    strOperacao,
                                    strParametroSQLServerCE
                                    )
                                    );
                            }
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        public bool mtdAtualizarDadosParametroComandoSQLServerCE(string NomeTabela, List<List<object>> Campos_Dados, string CampoBase, string Operacao, object DadoBase, enmModoParametroComando ModoParametroComando)
        {
            bool saida = false;
            switch (ModoParametroComando)
            {
                case enmModoParametroComando.Valor:
                    saida = mtdAtualizarDadosParametroComandoSQLServerCEValor(NomeTabela, Campos_Dados, CampoBase, Operacao, DadoBase);
                    break;
                case enmModoParametroComando.ValorTipo:
                    saida = mtdAtualizarDadosParametroComandoSQLServerCEValorTipo(NomeTabela, Campos_Dados, CampoBase, Operacao, DadoBase);
                    break;
                case enmModoParametroComando.ValorTipoTamanho:
                    saida = mtdAtualizarDadosParametroComandoSQLServerCEValorTipoTamanho(NomeTabela, Campos_Dados, CampoBase, Operacao, DadoBase);
                    break;
            }
            return saida;
        }




        private bool mtdAtualizarDadosParametroComandoSQLServerCEValor(string NomeTabela, object[,] Campos_Dados_CampoBase_Operacao_DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 1;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
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

                        strTexto = string.Empty;
                        prpComandoSQLServerCE.Parameters.Clear();

                        for (int coluna = Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(1);
                            coluna <=
                            (
                            (linha <= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais - 1)
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

                                    mtdExecutarParametroComandoSQLServerCE
                                        (
                                        vetNomeColunas[coluna],
                                        vetRegistrosColunas[coluna]
                                        );

                                    strTexto +=
                                        string.Format
                                        (
                                        (coluna == Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 3) ?
                                        @"{0} = {2}{1}" :
                                        @"{0} = {2}{1}, ",
                                        vetNomeColunas[coluna],
                                        vetNomeColunas[coluna],
                                        strParametroSQLServerCE
                                        );
                                    break;
                            }
                        }
                        if (linha >= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais)
                        {
                            mtdExecutarParametroComandoSQLServerCE
                               (
                               string.Format("Alterar_{0}", strCampoBase),
                               objDadoBase
                               );

                            saida &= mtdExecutarComando
                                (
                                string.Format
                                (
                                "UPDATE {0} SET {1} WHERE {2} {3} {4}Alterar_{2};",
                                NomeTabela,
                                strTexto,
                                strCampoBase,
                                strOperacao,
                                strParametroSQLServerCE
                                )
                                );
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        private bool mtdAtualizarDadosParametroComandoSQLServerCEValorTipo(string NomeTabela, object[,] Campos_Dados_CampoBase_Operacao_DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 2;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
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

                        strTexto = string.Empty;
                        prpComandoSQLServerCE.Parameters.Clear();

                        for (int coluna = Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(1);
                            coluna <=
                            (
                            (linha <= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais - 1)
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
                                    if (Campos_Dados_CampoBase_Operacao_DadoBase[linha, coluna] != null)
                                    {
                                        vetTipoColunas[coluna] = (System.Data.SqlDbType)Campos_Dados_CampoBase_Operacao_DadoBase[linha, coluna];
                                    }
                                    else
                                    {
                                        vetTipoColunas[coluna] = System.Data.SqlDbType.Variant;
                                    }
                                    break;
                                default:
                                    vetRegistrosColunas[coluna] = (object)Campos_Dados_CampoBase_Operacao_DadoBase[linha, coluna];

                                    if (Campos_Dados_CampoBase_Operacao_DadoBase[1, coluna] != null)
                                    {
                                        mtdExecutarParametroComandoSQLServerCE
                                            (
                                            vetNomeColunas[coluna],
                                            vetTipoColunas[coluna],
                                            vetRegistrosColunas[coluna]
                                            );
                                    }
                                    else
                                    {
                                        mtdExecutarParametroComandoSQLServerCE
                                            (
                                            vetNomeColunas[coluna],
                                            vetRegistrosColunas[coluna]
                                            );
                                    }

                                    strTexto +=
                                        string.Format
                                        (
                                        (coluna == Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 3) ?
                                        @"{0} = {2}{1}" :
                                        @"{0} = {2}{1}, ",
                                        vetNomeColunas[coluna],
                                        vetNomeColunas[coluna],
                                        strParametroSQLServerCE
                                        );
                                    break;
                            }
                        }
                        if (linha >= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais)
                        {
                            mtdExecutarParametroComandoSQLServerCE
                               (
                               string.Format("Alterar_{0}", strCampoBase),
                               objDadoBase
                               );

                            saida &= mtdExecutarComando
                                (
                                string.Format
                                (
                                "UPDATE {0} SET {1} WHERE {2} {3} {4}Alterar_{2};",
                                NomeTabela,
                                strTexto,
                                strCampoBase,
                                strOperacao,
                                strParametroSQLServerCE
                                )
                                );
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        private bool mtdAtualizarDadosParametroComandoSQLServerCEValorTipoTamanho(string NomeTabela, object[,] Campos_Dados_CampoBase_Operacao_DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 3;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
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

                        strTexto = string.Empty;
                        prpComandoSQLServerCE.Parameters.Clear();

                        for (int coluna = Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(1);
                            coluna <=
                            (
                            (linha <= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais - 1)
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
                                    if (Campos_Dados_CampoBase_Operacao_DadoBase[linha, coluna] != null)
                                    {
                                        vetTipoColunas[coluna] = (System.Data.SqlDbType)Campos_Dados_CampoBase_Operacao_DadoBase[linha, coluna];
                                    }
                                    else
                                    {
                                        vetTipoColunas[coluna] = System.Data.SqlDbType.Variant;
                                    }
                                    break;
                                case (2):
                                    if (Campos_Dados_CampoBase_Operacao_DadoBase[linha, coluna] != null)
                                    {
                                        vetTamanhoColunas[coluna] = (int)Campos_Dados_CampoBase_Operacao_DadoBase[linha, coluna];
                                    }
                                    else
                                    {
                                        vetTamanhoColunas[coluna] = (int)0;
                                    }
                                    break;
                                default:
                                    vetRegistrosColunas[coluna] = (object)Campos_Dados_CampoBase_Operacao_DadoBase[linha, coluna];

                                    if (Campos_Dados_CampoBase_Operacao_DadoBase[1, coluna] != null)
                                    {
                                        if (Campos_Dados_CampoBase_Operacao_DadoBase[2, coluna] != null)
                                        {
                                            mtdExecutarParametroComandoSQLServerCE
                                                (
                                                vetNomeColunas[coluna],
                                                vetTipoColunas[coluna],
                                                vetRegistrosColunas[coluna],
                                                vetTamanhoColunas[coluna]
                                                );
                                        }
                                        else
                                        {
                                            mtdExecutarParametroComandoSQLServerCE
                                                (
                                                vetNomeColunas[coluna],
                                                vetTipoColunas[coluna],
                                                vetRegistrosColunas[coluna]
                                                );
                                        }
                                    }
                                    else
                                    {
                                        mtdExecutarParametroComandoSQLServerCE
                                            (
                                            vetNomeColunas[coluna],
                                            vetRegistrosColunas[coluna]
                                            );
                                    }

                                    strTexto +=
                                        string.Format
                                        (
                                        (coluna == Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 3) ?
                                        @"{0} = {2}{1}" :
                                        @"{0} = {2}{1}, ",
                                        vetNomeColunas[coluna],
                                        vetNomeColunas[coluna],
                                        strParametroSQLServerCE
                                        );
                                    break;
                            }
                        }
                        if (linha >= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais)
                        {
                            mtdExecutarParametroComandoSQLServerCE
                               (
                               string.Format("Alterar_{0}", strCampoBase),
                               objDadoBase
                               );

                            saida &= mtdExecutarComando
                                (
                                string.Format
                                (
                                "UPDATE {0} SET {1} WHERE {2} {3} {4}Alterar_{2};",
                                NomeTabela,
                                strTexto,
                                strCampoBase,
                                strOperacao,
                                strParametroSQLServerCE
                                )
                                );
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        public bool mtdAtualizarDadosParametroComandoSQLServerCE(string NomeTabela, object[,] Campos_Dados_CampoBase_Operacao_DadoBase, enmModoParametroComando ModoParametroComando)
        {
            bool saida = false;
            switch (ModoParametroComando)
            {
                case enmModoParametroComando.Valor:
                    saida = mtdAtualizarDadosParametroComandoSQLServerCEValor(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase);
                    break;
                case enmModoParametroComando.ValorTipo:
                    saida = mtdAtualizarDadosParametroComandoSQLServerCEValorTipo(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase);
                    break;
                case enmModoParametroComando.ValorTipoTamanho:
                    saida = mtdAtualizarDadosParametroComandoSQLServerCEValorTipoTamanho(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase);
                    break;
            }
            return saida;
        }

        private bool mtdAtualizarDadosParametroComandoSQLServerCEValor(string NomeTabela, object[][] Campos_Dados_CampoBase_Operacao_DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 1;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
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

                            strTexto = string.Empty;
                            prpComandoSQLServerCE.Parameters.Clear();

                            for (int coluna = Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetLowerBound(0);
                                coluna <=
                                (
                                (linha <= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais - 1)
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

                                        mtdExecutarParametroComandoSQLServerCE
                                            (
                                            vetNomeColunas[coluna],
                                            vetRegistrosColunas[coluna]
                                            );

                                        strTexto +=
                                            string.Format
                                            (
                                            (coluna == Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) - 3) ?
                                            @"{0} = {2}{1}" :
                                            @"{0} = {2}{1}, ",
                                            vetNomeColunas[coluna],
                                            vetNomeColunas[coluna]
                                            );
                                        break;
                                }
                            }
                            if (linha >= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais)
                            {
                                mtdExecutarParametroComandoSQLServerCE
                                   (
                                   string.Format("Alterar_{0}", strCampoBase),
                                   objDadoBase
                                   );

                                saida &= mtdExecutarComando
                                    (
                                    string.Format
                                    (
                                    "UPDATE {0} SET {1} WHERE {2} {3} {4}Alterar_{2};",
                                    NomeTabela,
                                    strTexto,
                                    strCampoBase,
                                    strOperacao
                                    )
                                    );
                            }
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        private bool mtdAtualizarDadosParametroComandoSQLServerCEValorTipo(string NomeTabela, object[][] Campos_Dados_CampoBase_Operacao_DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 2;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
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

                            strTexto = string.Empty;
                            prpComandoSQLServerCE.Parameters.Clear();

                            for (int coluna = Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetLowerBound(0);
                                coluna <=
                                (
                                (linha <= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais - 1)
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
                                        if (Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna] != null)
                                        {
                                            vetTipoColunas[coluna] = (System.Data.SqlDbType)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];
                                        }
                                        else
                                        {
                                            vetTipoColunas[coluna] = System.Data.SqlDbType.Variant;
                                        }
                                        break;
                                    default:
                                        vetRegistrosColunas[coluna] = (object)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];

                                        if (Campos_Dados_CampoBase_Operacao_DadoBase[1][coluna] != null)
                                        {
                                            mtdExecutarParametroComandoSQLServerCE
                                                (
                                                vetNomeColunas[coluna],
                                                vetTipoColunas[coluna],
                                                vetRegistrosColunas[coluna]
                                                );
                                        }
                                        else
                                        {
                                            mtdExecutarParametroComandoSQLServerCE
                                                (
                                                vetNomeColunas[coluna],
                                                vetRegistrosColunas[coluna]
                                                );
                                        }

                                        strTexto +=
                                            string.Format
                                            (
                                            (coluna == Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) - 3) ?
                                            @"{0} = {2}{1}" :
                                            @"{0} = {2}{1}, ",
                                            vetNomeColunas[coluna],
                                            vetNomeColunas[coluna],
                                            strParametroSQLServerCE
                                            );
                                        break;
                                }
                            }
                            if (linha >= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais)
                            {
                                mtdExecutarParametroComandoSQLServerCE
                                   (
                                   string.Format("Alterar_{0}", strCampoBase),
                                   objDadoBase
                                   );


                                saida &= mtdExecutarComando
                                    (
                                    string.Format
                                    (
                                    "UPDATE {0} SET {1} WHERE {2} {3} {4}Alterar_{2};",
                                    NomeTabela,
                                    strTexto,
                                    strCampoBase,
                                    strOperacao,
                                    strParametroSQLServerCE
                                    )
                                    );
                            }
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        private bool mtdAtualizarDadosParametroComandoSQLServerCEValorTipoTamanho(string NomeTabela, object[][] Campos_Dados_CampoBase_Operacao_DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 3;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
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

                            strTexto = string.Empty;
                            prpComandoSQLServerCE.Parameters.Clear();

                            for (int coluna = Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetLowerBound(0);
                                coluna <=
                                (
                                (linha <= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais - 1)
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
                                        if (Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna] != null)
                                        {
                                            vetTipoColunas[coluna] = (System.Data.SqlDbType)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];
                                        }
                                        else
                                        {
                                            vetTipoColunas[coluna] = System.Data.SqlDbType.Variant;
                                        }
                                        break;
                                    case (2):
                                        if (Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna] != null)
                                        {
                                            vetTamanhoColunas[coluna] = (int)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];
                                        }
                                        else
                                        {
                                            vetTamanhoColunas[coluna] = (int)0;
                                        }
                                        break;
                                    default:
                                        vetRegistrosColunas[coluna] = (object)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];

                                        if (Campos_Dados_CampoBase_Operacao_DadoBase[1][coluna] != null)
                                        {
                                            if (Campos_Dados_CampoBase_Operacao_DadoBase[2][coluna] != null)
                                            {
                                                mtdExecutarParametroComandoSQLServerCE
                                                    (
                                                    vetNomeColunas[coluna],
                                                    vetTipoColunas[coluna],
                                                    vetRegistrosColunas[coluna],
                                                    vetTamanhoColunas[coluna]
                                                    );
                                            }
                                            else
                                            {
                                                mtdExecutarParametroComandoSQLServerCE
                                                    (
                                                    vetNomeColunas[coluna],
                                                    vetTipoColunas[coluna],
                                                    vetRegistrosColunas[coluna]
                                                    );
                                            }
                                        }
                                        else
                                        {
                                            mtdExecutarParametroComandoSQLServerCE
                                                (
                                                vetNomeColunas[coluna],
                                                vetRegistrosColunas[coluna]
                                                );
                                        }

                                        strTexto +=
                                            string.Format
                                            (
                                            (coluna == Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) - 3) ?
                                            @"{0} = {2}{1}" :
                                            @"{0} = {2}{1}, ",
                                            vetNomeColunas[coluna],
                                            vetNomeColunas[coluna],
                                            strParametroSQLServerCE
                                            );
                                        break;
                                }
                            }
                            if (linha >= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais)
                            {
                                mtdExecutarParametroComandoSQLServerCE
                                    (
                                    string.Format("Alterar_{0}", strCampoBase),
                                    objDadoBase
                                    );

                                saida &= mtdExecutarComando
                                    (
                                    string.Format
                                    (
                                    "UPDATE {0} SET {1} WHERE {2} {3} {4}Alterar_{2};",
                                    NomeTabela,
                                    strTexto,
                                    strCampoBase,
                                    strOperacao,
                                    strParametroSQLServerCE
                                    )
                                    );
                            }
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        public bool mtdAtualizarDadosParametroComandoSQLServerCE(string NomeTabela, object[][] Campos_Dados_CampoBase_Operacao_DadoBase, enmModoParametroComando ModoParametroComando)
        {
            bool saida = false;
            switch (ModoParametroComando)
            {
                case enmModoParametroComando.Valor:
                    saida = mtdAtualizarDadosParametroComandoSQLServerCEValor(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase);
                    break;
                case enmModoParametroComando.ValorTipo:
                    saida = mtdAtualizarDadosParametroComandoSQLServerCEValorTipo(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase);
                    break;
                case enmModoParametroComando.ValorTipoTamanho:
                    saida = mtdAtualizarDadosParametroComandoSQLServerCEValorTipoTamanho(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase);
                    break;
            }
            return saida;
        }




        private bool mtdAtualizarDadosParametroComandoSQLServerCEValor(string NomeTabela, List<List<object>> Campos_Dados_CampoBase_Operacao_DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 1;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
            List<string> lstNomeColunas = null;
            List<object> lstRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados_CampoBase_Operacao_DadoBase != null)
            {
                if (Campos_Dados_CampoBase_Operacao_DadoBase.Count >= intLinhasAdicionais + 1)
                {
                    for (int linha = 0; linha <= Campos_Dados_CampoBase_Operacao_DadoBase.Count - 1; linha++)
                    {
                        if (Campos_Dados_CampoBase_Operacao_DadoBase[linha] != null)
                        {
                            switch (linha)
                            {
                                case (0):
                                    lstNomeColunas = new List<string> { };
                                    break;
                                default:
                                    strCampoBase = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1 - 2];
                                    strOperacao = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1 - 1];
                                    objDadoBase = Campos_Dados_CampoBase_Operacao_DadoBase[linha][Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1];
                                    lstRegistrosColunas = new List<object>(Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1 + 1);
                                    break;
                            }

                            strTexto = string.Empty;
                            prpComandoSQLServerCE.Parameters.Clear();

                            for (int coluna = 0;
                                coluna <=
                                (
                                (linha <= 0 + intLinhasAdicionais - 1)
                                ?
                                Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1
                                :
                                Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1 - 3
                                );
                                coluna++)
                            {
                                switch (linha)
                                {
                                    case (0):
                                        //lstNomeColunas[coluna] = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];
                                        lstNomeColunas.Add((string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna]);
                                        break;
                                    default:
                                        //lstRegistrosColunas[coluna] = (object)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];
                                        lstRegistrosColunas.Add((object)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna]);

                                        mtdExecutarParametroComandoSQLServerCE
                                            (
                                            lstNomeColunas[coluna],
                                            lstRegistrosColunas[coluna]
                                            );

                                        strTexto +=
                                            string.Format
                                            (
                                            (coluna == Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1 - 3) ?
                                            @"{0} = {2}{1}" :
                                            @"{0} = {2}{1}, ",
                                            lstNomeColunas[coluna],
                                            lstNomeColunas[coluna],
                                            strParametroSQLServerCE
                                            );
                                        break;
                                }
                            }
                            if (linha >= 0 + intLinhasAdicionais)
                            {
                                mtdExecutarParametroComandoSQLServerCE
                                   (
                                   string.Format("Alterar_{0}", strCampoBase),
                                   objDadoBase
                                   );

                                saida &= mtdExecutarComando
                                    (
                                    string.Format
                                    (
                                    "UPDATE {0} SET {1} WHERE {2} {3} {4}Alterar_{2};",
                                    NomeTabela,
                                    strTexto,
                                    strCampoBase,
                                    strOperacao,
                                    strParametroSQLServerCE
                                    )
                                    );
                            }
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        private bool mtdAtualizarDadosParametroComandoSQLServerCEValorTipo(string NomeTabela, List<List<object>> Campos_Dados_CampoBase_Operacao_DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 2;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
            List<string> lstNomeColunas = null;
            List<System.Data.SqlDbType> lstTipoColunas = null;
            List<object> lstRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados_CampoBase_Operacao_DadoBase != null)
            {
                if (Campos_Dados_CampoBase_Operacao_DadoBase.Count >= intLinhasAdicionais + 1)
                {
                    for (int linha = 0; linha <= Campos_Dados_CampoBase_Operacao_DadoBase.Count - 1; linha++)
                    {
                        if (Campos_Dados_CampoBase_Operacao_DadoBase[linha] != null)
                        {
                            switch (linha)
                            {
                                case (0):
                                    lstNomeColunas = new List<string> { };
                                    break;
                                case (1):
                                    lstTipoColunas = new List<System.Data.SqlDbType> { };
                                    break;
                                default:
                                    strCampoBase = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1 - 2];
                                    strOperacao = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1 - 1];
                                    objDadoBase = Campos_Dados_CampoBase_Operacao_DadoBase[linha][Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1];
                                    lstRegistrosColunas = new List<object>(Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1 + 1);
                                    break;
                            }

                            strTexto = string.Empty;
                            prpComandoSQLServerCE.Parameters.Clear();

                            for (int coluna = 0;
                                coluna <=
                                (
                                (linha <= 0 + intLinhasAdicionais - 1)
                                ?
                                Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1
                                :
                                Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1 - 3
                                );
                                coluna++)
                            {
                                switch (linha)
                                {
                                    case (0):
                                        //lstNomeColunas[coluna] = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];
                                        lstNomeColunas.Add((string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna]);
                                        break;
                                    case (1):
                                        if (Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna] != null)
                                        {
                                            //lstTipoColunas[coluna] = (System.Data.SqlDbType)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];
                                            lstTipoColunas.Add((System.Data.SqlDbType)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna]);
                                        }
                                        else
                                        {
                                            //lstTipoColunas[coluna] = System.Data.SqlDbType.Variant;
                                            lstTipoColunas.Add(System.Data.SqlDbType.Variant);
                                        }
                                        break;
                                    default:
                                        //lstRegistrosColunas[coluna] = (object)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];
                                        lstRegistrosColunas.Add((object)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna]);

                                        if (Campos_Dados_CampoBase_Operacao_DadoBase[1][coluna] != null)
                                        {
                                            mtdExecutarParametroComandoSQLServerCE
                                                (
                                                lstNomeColunas[coluna],
                                                lstTipoColunas[coluna],
                                                lstRegistrosColunas[coluna]
                                                );
                                        }
                                        else
                                        {
                                            mtdExecutarParametroComandoSQLServerCE
                                                (
                                                lstNomeColunas[coluna],
                                                lstRegistrosColunas[coluna]
                                                );
                                        }

                                        strTexto +=
                                            string.Format
                                            (
                                            (coluna == Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1 - 3) ?
                                            @"{0} = {2}{1}" :
                                            @"{0} = {2}{1}, ",
                                            lstNomeColunas[coluna],
                                            lstNomeColunas[coluna],
                                            strParametroSQLServerCE
                                            );
                                        break;
                                }
                            }
                            if (linha >= 0 + intLinhasAdicionais)
                            {
                                mtdExecutarParametroComandoSQLServerCE
                                   (
                                   string.Format("Alterar_{0}", strCampoBase),
                                   objDadoBase
                                   );


                                saida &= mtdExecutarComando
                                    (
                                    string.Format
                                    (
                                    "UPDATE {0} SET {1} WHERE {2} {3} {4}Alterar_{2};",
                                    NomeTabela,
                                    strTexto,
                                    strCampoBase,
                                    strOperacao,
                                    strParametroSQLServerCE
                                    )
                                    );
                            }
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        private bool mtdAtualizarDadosParametroComandoSQLServerCEValorTipoTamanho(string NomeTabela, List<List<object>> Campos_Dados_CampoBase_Operacao_DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 3;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
            List<string> lstNomeColunas = null;
            List<System.Data.SqlDbType> lstTipoColunas = null;
            List<int> lstTamanhoColunas = null;
            List<object> lstRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados_CampoBase_Operacao_DadoBase != null)
            {
                if (Campos_Dados_CampoBase_Operacao_DadoBase.Count >= intLinhasAdicionais + 1)
                {
                    for (int linha = 0; linha <= Campos_Dados_CampoBase_Operacao_DadoBase.Count - 1; linha++)
                    {
                        if (Campos_Dados_CampoBase_Operacao_DadoBase[linha] != null)
                        {
                            switch (linha)
                            {
                                case (0):
                                    lstNomeColunas = new List<string> { };
                                    break;
                                case (1):
                                    lstTipoColunas = new List<System.Data.SqlDbType> { };
                                    break;
                                case (2):
                                    lstTamanhoColunas = new List<int> { };
                                    break;
                                default:
                                    strCampoBase = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1 - 2];
                                    strOperacao = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][Campos_Dados_CampoBase_Operacao_DadoBase.Count - 1 - 1];
                                    objDadoBase = Campos_Dados_CampoBase_Operacao_DadoBase[linha][Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1];
                                    lstRegistrosColunas = new List<object>(Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1 + 1);
                                    break;
                            }

                            strTexto = string.Empty;
                            prpComandoSQLServerCE.Parameters.Clear();

                            for (int coluna = 0;
                                coluna <=
                                (
                                (linha <= 0 + intLinhasAdicionais - 1)
                                ?
                                Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1
                                :
                                Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1 - 3
                                );
                                coluna++)
                            {
                                switch (linha)
                                {
                                    case (0):
                                        //lstNomeColunas[coluna] = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];
                                        lstNomeColunas.Add((string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna]);
                                        break;
                                    case (1):
                                        if (Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna] != null)
                                        {
                                            //lstTipoColunas[coluna] = (System.Data.SqlDbType)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];
                                            lstTipoColunas.Add((System.Data.SqlDbType)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna]);
                                        }
                                        else
                                        {
                                            //lstTipoColunas[coluna] = System.Data.SqlDbType.Variant;
                                            lstTipoColunas.Add(System.Data.SqlDbType.Variant);
                                        }
                                        break;
                                    case (2):
                                        if (Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna] != null)
                                        {
                                            //lstTamanhoColunas[coluna] = (int)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];
                                            lstTamanhoColunas.Add((int)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna]);
                                        }
                                        else
                                        {
                                            //lstTamanhoColunas[coluna] = (int)0;
                                            lstTamanhoColunas.Add((int)0);
                                        }
                                        break;
                                    default:
                                        //lstRegistrosColunas[coluna] = (object)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];
                                        lstRegistrosColunas.Add((object)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna]);

                                        if (Campos_Dados_CampoBase_Operacao_DadoBase[1][coluna] != null)
                                        {
                                            if (Campos_Dados_CampoBase_Operacao_DadoBase[2][coluna] != null)
                                            {
                                                mtdExecutarParametroComandoSQLServerCE
                                                    (
                                                    lstNomeColunas[coluna],
                                                    lstTipoColunas[coluna],
                                                    lstRegistrosColunas[coluna],
                                                    lstTamanhoColunas[coluna]
                                                    );
                                            }
                                            else
                                            {
                                                mtdExecutarParametroComandoSQLServerCE
                                                    (
                                                    lstNomeColunas[coluna],
                                                    lstTipoColunas[coluna],
                                                    lstRegistrosColunas[coluna]
                                                    );
                                            }
                                        }
                                        else
                                        {
                                            mtdExecutarParametroComandoSQLServerCE
                                                (
                                                lstNomeColunas[coluna],
                                                lstRegistrosColunas[coluna]
                                                );
                                        }

                                        strTexto +=
                                            string.Format
                                            (
                                            (coluna == Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1 - 3) ?
                                            @"{0} = {2}{1}" :
                                            @"{0} = {2}{1}, ",
                                            lstNomeColunas[coluna],
                                            lstNomeColunas[coluna],
                                            strParametroSQLServerCE
                                            );
                                        break;
                                }
                            }
                            if (linha >= 0 + intLinhasAdicionais)
                            {
                                mtdExecutarParametroComandoSQLServerCE
                                    (
                                    string.Format("Alterar_{0}", strCampoBase),
                                    objDadoBase
                                    );

                                saida &= mtdExecutarComando
                                    (
                                    string.Format
                                    (
                                    "UPDATE {0} SET {1} WHERE {2} {3} {4}Alterar_{2};",
                                    NomeTabela,
                                    strTexto,
                                    strCampoBase,
                                    strOperacao,
                                    strParametroSQLServerCE
                                    )
                                    );
                            }
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        public bool mtdAtualizarDadosParametroComandoSQLServerCE(string NomeTabela, List<List<object>> Campos_Dados_CampoBase_Operacao_DadoBase, enmModoParametroComando ModoParametroComando)
        {
            bool saida = false;
            switch (ModoParametroComando)
            {
                case enmModoParametroComando.Valor:
                    saida = mtdAtualizarDadosParametroComandoSQLServerCEValor(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase);
                    break;
                case enmModoParametroComando.ValorTipo:
                    saida = mtdAtualizarDadosParametroComandoSQLServerCEValorTipo(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase);
                    break;
                case enmModoParametroComando.ValorTipoTamanho:
                    saida = mtdAtualizarDadosParametroComandoSQLServerCEValorTipoTamanho(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase);
                    break;
            }
            return saida;
        }




        private bool mtdInserirDadosParametroComandoSQLServerCEValor(string NomeTabela, object[,] Campos_Dados)
        {
            bool saida = true;

            int intLinhasAdicionais = 1;
            string strNomeColunas = string.Empty;
            object objResgistrosColunas = null;
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

                        objResgistrosColunas = null;
                        prpComandoSQLServerCE.Parameters.Clear();

                        for (int coluna = Campos_Dados.GetLowerBound(1); coluna <= Campos_Dados.GetUpperBound(1); coluna++)
                        {
                            switch (linha)
                            {
                                case (0):
                                    vetNomeColunas[coluna] = (string)Campos_Dados[linha, coluna];
                                    strNomeColunas +=
                                        string.Format
                                        (
                                        (coluna != Campos_Dados.GetUpperBound(1))
                                        ?
                                        @"{0}, "
                                        :
                                        @"{0}",
                                        vetNomeColunas[coluna]
                                        );
                                    break;
                                default:
                                    vetRegistrosColunas[coluna] = (object)Campos_Dados[linha, coluna];

                                    mtdExecutarParametroComandoSQLServerCE
                                        (
                                        vetNomeColunas[coluna],
                                        vetRegistrosColunas[coluna]
                                        );

                                    objResgistrosColunas +=
                                       string.Format
                                       (
                                       (coluna != Campos_Dados.GetUpperBound(1))
                                       ?
                                       @"{1}{0}, "
                                       :
                                       @"{1}{0}",
                                       vetNomeColunas[coluna],
                                       strParametroSQLServerCE
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

        private bool mtdInserirDadosParametroComandoSQLServerCEValorTipo(string NomeTabela, object[,] Campos_Dados)
        {
            bool saida = true;

            int intLinhasAdicionais = 2;
            string strNomeColunas = string.Empty;
            object objResgistrosColunas = null;
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

                        objResgistrosColunas = null;
                        prpComandoSQLServerCE.Parameters.Clear();

                        for (int coluna = Campos_Dados.GetLowerBound(1); coluna <= Campos_Dados.GetUpperBound(1); coluna++)
                        {
                            switch (linha)
                            {
                                case (0):
                                    vetNomeColunas[coluna] = (string)Campos_Dados[linha, coluna];
                                    strNomeColunas +=
                                        string.Format
                                        (
                                        (coluna != Campos_Dados.GetUpperBound(1))
                                        ?
                                        @"{0}, "
                                        :
                                        @"{0}",
                                        vetNomeColunas[coluna]
                                        );
                                    break;
                                case (1):
                                    if (Campos_Dados[linha, coluna] != null)
                                    {
                                        vetTipoColunas[coluna] = (System.Data.SqlDbType)Campos_Dados[linha, coluna];
                                    }
                                    else
                                    {
                                        vetTipoColunas[coluna] = System.Data.SqlDbType.Variant;
                                    }
                                    break;
                                default:
                                    vetRegistrosColunas[coluna] = (object)Campos_Dados[linha, coluna];

                                    if (Campos_Dados[1, coluna] != null)
                                    {
                                        mtdExecutarParametroComandoSQLServerCE
                                            (
                                            vetNomeColunas[coluna],
                                            vetTipoColunas[coluna],
                                            vetRegistrosColunas[coluna]
                                            );
                                    }
                                    else
                                    {
                                        mtdExecutarParametroComandoSQLServerCE
                                            (
                                            vetNomeColunas[coluna],
                                            vetRegistrosColunas[coluna]
                                            );
                                    }

                                    objResgistrosColunas +=
                                        string.Format
                                        (
                                        (coluna != Campos_Dados.GetUpperBound(1))
                                        ?
                                        @"{1}{0}, "
                                        :
                                        @"{1}{0}",
                                        vetNomeColunas[coluna],
                                        strParametroSQLServerCE
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

        private bool mtdInserirDadosParametroComandoSQLServerCEValorTipoTamanho(string NomeTabela, object[,] Campos_Dados)
        {
            bool saida = true;

            int intLinhasAdicionais = 3;
            string strNomeColunas = string.Empty;
            object objResgistrosColunas = null;
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

                        objResgistrosColunas = null;
                        prpComandoSQLServerCE.Parameters.Clear();

                        for (int coluna = Campos_Dados.GetLowerBound(1); coluna <= Campos_Dados.GetUpperBound(1); coluna++)
                        {
                            switch (linha)
                            {
                                case (0):
                                    vetNomeColunas[coluna] = (string)Campos_Dados[linha, coluna];
                                    strNomeColunas +=
                                        string.Format
                                        (
                                        (coluna != Campos_Dados.GetUpperBound(1))
                                        ?
                                        @"{0}, "
                                        :
                                        @"{0}",
                                        vetNomeColunas[coluna]
                                        );
                                    break;
                                case (1):
                                    if (Campos_Dados[linha, coluna] != null)
                                    {
                                        vetTipoColunas[coluna] = (System.Data.SqlDbType)Campos_Dados[linha, coluna];
                                    }
                                    else
                                    {
                                        vetTipoColunas[coluna] = System.Data.SqlDbType.Variant;
                                    }
                                    break;
                                case (2):
                                    if (Campos_Dados[linha, coluna] != null)
                                    {
                                        vetTamanhoColunas[coluna] = (int)Campos_Dados[linha, coluna];
                                    }
                                    else
                                    {
                                        vetTamanhoColunas[coluna] = (int)0;
                                    }
                                    break;
                                default:
                                    vetRegistrosColunas[coluna] = (object)Campos_Dados[linha, coluna];

                                    if (Campos_Dados[1, coluna] != null)
                                    {
                                        if (Campos_Dados[2, coluna] != null)
                                        {
                                            mtdExecutarParametroComandoSQLServerCE
                                                (
                                                vetNomeColunas[coluna],
                                                vetTipoColunas[coluna],
                                                vetRegistrosColunas[coluna],
                                                vetTamanhoColunas[coluna]
                                                );
                                        }
                                        else
                                        {
                                            mtdExecutarParametroComandoSQLServerCE
                                                (
                                                vetNomeColunas[coluna],
                                                vetTipoColunas[coluna],
                                                vetRegistrosColunas[coluna]
                                                );
                                        }
                                    }
                                    else
                                    {
                                        mtdExecutarParametroComandoSQLServerCE
                                            (
                                            vetNomeColunas[coluna],
                                            vetRegistrosColunas[coluna]
                                            );
                                    }

                                    objResgistrosColunas +=
                                        string.Format
                                        (
                                        (coluna != Campos_Dados.GetUpperBound(1))
                                        ?
                                        @"{1}{0}, "
                                        :
                                        @"{1}{0}",
                                        vetNomeColunas[coluna]
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

        public bool mtdInserirDadosParametroComandoSQLServerCE(string NomeTabela, object[,] Campos_Dados, enmModoParametroComando ModoParametroComando)
        {
            bool saida = false;
            switch (ModoParametroComando)
            {
                case enmModoParametroComando.Valor:
                    saida = mtdInserirDadosParametroComandoSQLServerCEValor(NomeTabela, Campos_Dados);
                    break;
                case enmModoParametroComando.ValorTipo:
                    saida = mtdInserirDadosParametroComandoSQLServerCEValorTipo(NomeTabela, Campos_Dados);
                    break;
                case enmModoParametroComando.ValorTipoTamanho:
                    saida = mtdInserirDadosParametroComandoSQLServerCEValorTipoTamanho(NomeTabela, Campos_Dados);
                    break;
            }
            return saida;
        }

        private bool mtdInserirDadosParametroComandoSQLServerCEValor(string NomeTabela, object[][] Campos_Dados)
        {
            bool saida = true;

            int intLinhasAdicionais = 1;
            string strNomeColunas = string.Empty;
            object objResgistrosColunas = null;
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

                            objResgistrosColunas = null;
                            prpComandoSQLServerCE.Parameters.Clear();

                            for (int coluna = Campos_Dados[linha].GetLowerBound(0); coluna <= Campos_Dados[linha].GetUpperBound(0); coluna++)
                            {
                                switch (linha)
                                {
                                    case (0):
                                        vetNomeColunas[coluna] = (string)Campos_Dados[linha][coluna];
                                        strNomeColunas +=
                                            string.Format
                                            (
                                            (coluna != Campos_Dados[linha].GetUpperBound(0))
                                            ?
                                            @"{0}, "
                                            :
                                            @"{0}",
                                            vetNomeColunas[coluna]
                                            );
                                        break;
                                    default:
                                        vetRegistrosColunas[coluna] = (object)Campos_Dados[linha][coluna];

                                        mtdExecutarParametroComandoSQLServerCE
                                            (
                                            vetNomeColunas[coluna],
                                            vetRegistrosColunas[coluna]
                                            );

                                        objResgistrosColunas +=
                                            string.Format
                                            (
                                            (coluna != Campos_Dados[linha].GetUpperBound(0))
                                            ?
                                            @"{1}{0}, "
                                            :
                                            @"{1}{0}",
                                            vetNomeColunas[coluna],
                                            strParametroSQLServerCE
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

        private bool mtdInserirDadosParametroComandoSQLServerCEValorTipo(string NomeTabela, object[][] Campos_Dados)
        {
            bool saida = true;

            int intLinhasAdicionais = 2;
            string strNomeColunas = string.Empty;
            object objResgistrosColunas = null;
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

                            objResgistrosColunas = null;
                            prpComandoSQLServerCE.Parameters.Clear();

                            for (int coluna = Campos_Dados[linha].GetLowerBound(0); coluna <= Campos_Dados[linha].GetUpperBound(0); coluna++)
                            {
                                switch (linha)
                                {
                                    case (0):
                                        vetNomeColunas[coluna] = (string)Campos_Dados[linha][coluna];
                                        strNomeColunas +=
                                            string.Format
                                            (
                                            (coluna != Campos_Dados[linha].GetUpperBound(0))
                                            ?
                                            @"{0}, "
                                            :
                                            @"{0}",
                                            vetNomeColunas[coluna]
                                            );
                                        break;
                                    case (1):
                                        if (Campos_Dados[linha][coluna] != null)
                                        {
                                            vetTipoColunas[coluna] = (System.Data.SqlDbType)Campos_Dados[linha][coluna];
                                        }
                                        else
                                        {
                                            vetTipoColunas[coluna] = System.Data.SqlDbType.Variant;
                                        }
                                        break;
                                    default:
                                        vetRegistrosColunas[coluna] = (object)Campos_Dados[linha][coluna];

                                        if (Campos_Dados[1][coluna] != null)
                                        {
                                            mtdExecutarParametroComandoSQLServerCE
                                                (
                                                vetNomeColunas[coluna],
                                                vetTipoColunas[coluna],
                                                vetRegistrosColunas[coluna]
                                                );
                                        }
                                        else
                                        {
                                            mtdExecutarParametroComandoSQLServerCE
                                                (
                                                vetNomeColunas[coluna],
                                                vetRegistrosColunas[coluna]
                                                );
                                        }

                                        objResgistrosColunas +=
                                            string.Format
                                            (
                                            (coluna != Campos_Dados[linha].GetUpperBound(0))
                                            ?
                                            @"{1}{0}, "
                                            :
                                            @"{1}{0}",
                                            vetNomeColunas[coluna],
                                            strParametroSQLServerCE
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

        private bool mtdInserirDadosParametroComandoSQLServerCEValorTipoTamanho(string NomeTabela, object[][] Campos_Dados)
        {
            bool saida = true;

            int intLinhasAdicionais = 3;
            string strNomeColunas = string.Empty;
            object objResgistrosColunas = null;
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

                            objResgistrosColunas = null;
                            prpComandoSQLServerCE.Parameters.Clear();

                            for (int coluna = Campos_Dados[linha].GetLowerBound(0); coluna <= Campos_Dados[linha].GetUpperBound(0); coluna++)
                            {
                                switch (linha)
                                {
                                    case (0):
                                        vetNomeColunas[coluna] = (string)Campos_Dados[linha][coluna];
                                        strNomeColunas +=
                                            string.Format
                                            (
                                            (coluna != Campos_Dados[linha].GetUpperBound(0))
                                            ?
                                            @"{0}, "
                                            :
                                            @"{0}",
                                            vetNomeColunas[coluna]
                                            );
                                        break;
                                    case (1):
                                        if (Campos_Dados[linha][coluna] != null)
                                        {
                                            vetTipoColunas[coluna] = (System.Data.SqlDbType)Campos_Dados[linha][coluna];
                                        }
                                        else
                                        {
                                            vetTipoColunas[coluna] = System.Data.SqlDbType.Variant;
                                        }
                                        break;
                                    case (2):
                                        if (Campos_Dados[linha][coluna] != null)
                                        {
                                            vetTamanhoColunas[coluna] = (int)Campos_Dados[linha][coluna];
                                        }
                                        else
                                        {
                                            vetTamanhoColunas[coluna] = (int)0;
                                        }
                                        break;
                                    default:
                                        vetRegistrosColunas[coluna] = (object)Campos_Dados[linha][coluna];

                                        if (Campos_Dados[1][coluna] != null)
                                        {
                                            if (Campos_Dados[2][coluna] != null)
                                            {
                                                mtdExecutarParametroComandoSQLServerCE
                                                    (
                                                    vetNomeColunas[coluna],
                                                    vetTipoColunas[coluna],
                                                    vetRegistrosColunas[coluna],
                                                    vetTamanhoColunas[coluna]
                                                    );
                                            }
                                            else
                                            {
                                                mtdExecutarParametroComandoSQLServerCE
                                                    (
                                                    vetNomeColunas[coluna],
                                                    vetTipoColunas[coluna],
                                                    vetRegistrosColunas[coluna]
                                                    );
                                            }
                                        }
                                        else
                                        {
                                            mtdExecutarParametroComandoSQLServerCE
                                                (
                                                vetNomeColunas[coluna],
                                                vetRegistrosColunas[coluna]
                                                );
                                        }

                                        objResgistrosColunas +=
                                            string.Format
                                            (
                                            (coluna != Campos_Dados[linha].GetUpperBound(0))
                                            ?
                                            @"{1}{0}, "
                                            :
                                            @"{1}{0}",
                                            vetNomeColunas[coluna],
                                            strParametroSQLServerCE
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

        public bool mtdInserirDadosParametroComandoSQLServerCE(string NomeTabela, object[][] Campos_Dados, enmModoParametroComando ModoParametroComando)
        {
            bool saida = false;
            switch (ModoParametroComando)
            {
                case enmModoParametroComando.Valor:
                    saida = mtdInserirDadosParametroComandoSQLServerCEValor(NomeTabela, Campos_Dados);
                    break;
                case enmModoParametroComando.ValorTipo:
                    saida = mtdInserirDadosParametroComandoSQLServerCEValorTipo(NomeTabela, Campos_Dados);
                    break;
                case enmModoParametroComando.ValorTipoTamanho:
                    saida = mtdInserirDadosParametroComandoSQLServerCEValorTipoTamanho(NomeTabela, Campos_Dados);
                    break;
            }
            return saida;
        }




        private bool mtdInserirDadosParametroComandoSQLServerCEValor(string NomeTabela, List<List<object>> Campos_Dados)
        {
            bool saida = true;

            int intLinhasAdicionais = 1;
            string strNomeColunas = string.Empty;
            object objResgistrosColunas = null;
            List<string> lstNomeColunas = null;
            List<object> lstRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados != null)
            {
                if (Campos_Dados.Count >= intLinhasAdicionais + 1)
                {
                    for (int linha = 0; linha <= Campos_Dados.Count - 1; linha++)
                    {
                        if (Campos_Dados[linha] != null)
                        {
                            switch (linha)
                            {
                                case (0):
                                    lstNomeColunas = new List<string> { };
                                    break;
                                default:
                                    lstRegistrosColunas = new List<object> { };
                                    break;
                            }

                            objResgistrosColunas = null;
                            prpComandoSQLServerCE.Parameters.Clear();

                            for (int coluna = 0; coluna <= Campos_Dados[linha].Count - 1; coluna++)
                            {
                                switch (linha)
                                {
                                    case (0):
                                        //lstNomeColunas[coluna] = (string)Campos_Dados[linha][coluna];
                                        lstNomeColunas.Add((string)Campos_Dados[linha][coluna]);
                                        strNomeColunas +=
                                            string.Format
                                            (
                                            (coluna != Campos_Dados[linha].Count - 1)
                                            ?
                                            @"{0}, "
                                            :
                                            @"{0}",
                                            lstNomeColunas[coluna]
                                            );
                                        break;
                                    default:
                                        //lstRegistrosColunas[coluna] = (object)Campos_Dados[linha][coluna];
                                        lstRegistrosColunas.Add((object)Campos_Dados[linha][coluna]);

                                        mtdExecutarParametroComandoSQLServerCE
                                            (
                                            lstNomeColunas[coluna],
                                            lstRegistrosColunas[coluna]
                                            );

                                        objResgistrosColunas +=
                                            string.Format
                                            (
                                            (coluna != Campos_Dados[linha].Count - 1)
                                            ?
                                            @"{1}{0}, "
                                            :
                                            @"{1}{0}",
                                            lstNomeColunas[coluna],
                                            strParametroSQLServerCE
                                            );
                                        break;
                                }
                            }
                            if (linha >= 0 + intLinhasAdicionais)
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

        private bool mtdInserirDadosParametroComandoSQLServerCEValorTipo(string NomeTabela, List<List<object>> Campos_Dados)
        {
            bool saida = true;

            int intLinhasAdicionais = 2;
            string strNomeColunas = string.Empty;
            object objResgistrosColunas = null;
            List<string> lstNomeColunas = null;
            List<System.Data.SqlDbType> lstTipoColunas = null;
            List<object> lstRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados != null)
            {
                if (Campos_Dados.Count >= intLinhasAdicionais + 1)
                {
                    for (int linha = 0; linha <= Campos_Dados.Count - 1; linha++)
                    {
                        if (Campos_Dados[linha] != null)
                        {
                            switch (linha)
                            {
                                case (0):
                                    lstNomeColunas = new List<string> { };
                                    break;
                                case (1):
                                    lstTipoColunas = new List<System.Data.SqlDbType> { };
                                    break;
                                default:
                                    lstRegistrosColunas = new List<object> { };
                                    break;
                            }

                            objResgistrosColunas = null;
                            prpComandoSQLServerCE.Parameters.Clear();

                            for (int coluna = 0; coluna <= Campos_Dados[linha].Count - 1; coluna++)
                            {
                                switch (linha)
                                {
                                    case (0):
                                        //lstNomeColunas[coluna] = (string)Campos_Dados[linha][coluna];
                                        lstNomeColunas.Add((string)Campos_Dados[linha][coluna]);
                                        strNomeColunas +=
                                            string.Format
                                            (
                                            (coluna != Campos_Dados[linha].Count - 1)
                                            ?
                                            @"{0}, "
                                            :
                                            @"{0}",
                                            lstNomeColunas[coluna]
                                            );
                                        break;
                                    case (1):
                                        if (Campos_Dados[linha][coluna] != null)
                                        {
                                            //lstTipoColunas[coluna] = (System.Data.SqlDbType)Campos_Dados[linha][coluna];
                                            lstTipoColunas.Add((System.Data.SqlDbType)Campos_Dados[linha][coluna]);
                                        }
                                        else
                                        {
                                            //lstTipoColunas[coluna] = System.Data.SqlDbType.Variant;
                                            lstTipoColunas.Add(System.Data.SqlDbType.Variant);
                                        }
                                        break;
                                    default:
                                        //lstRegistrosColunas[coluna] = (object)Campos_Dados[linha][coluna];
                                        lstRegistrosColunas.Add((object)Campos_Dados[linha][coluna]);

                                        if (Campos_Dados[1][coluna] != null)
                                        {
                                            mtdExecutarParametroComandoSQLServerCE
                                                (
                                                lstNomeColunas[coluna],
                                                lstTipoColunas[coluna],
                                                lstRegistrosColunas[coluna]
                                                );
                                        }
                                        else
                                        {
                                            mtdExecutarParametroComandoSQLServerCE
                                                (
                                                lstNomeColunas[coluna],
                                                lstRegistrosColunas[coluna]
                                                );
                                        }

                                        objResgistrosColunas +=
                                            string.Format
                                            (
                                            (coluna != Campos_Dados[linha].Count - 1)
                                            ?
                                            @"{1}{0}, "
                                            :
                                            @"{1}{0}",
                                            lstNomeColunas[coluna],
                                            strParametroSQLServerCE
                                            );
                                        break;
                                }
                            }
                            if (linha >= 0 + intLinhasAdicionais)
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

        private bool mtdInserirDadosParametroComandoSQLServerCEValorTipoTamanho(string NomeTabela, List<List<object>> Campos_Dados)
        {
            bool saida = true;

            int intLinhasAdicionais = 3;
            string strNomeColunas = string.Empty;
            object objResgistrosColunas = null;
            List<string> lstNomeColunas = null;
            List<System.Data.SqlDbType> lstTipoColunas = null;
            List<int> lstTamanhoColunas = null;
            List<object> lstRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados != null)
            {
                if (Campos_Dados.Count >= intLinhasAdicionais + 1)
                {
                    for (int linha = 0; linha <= Campos_Dados.Count - 1; linha++)
                    {
                        if (Campos_Dados[linha] != null)
                        {
                            switch (linha)
                            {
                                case (0):
                                    lstNomeColunas = new List<string> { };
                                    break;
                                case (1):
                                    lstTipoColunas = new List<System.Data.SqlDbType> { };
                                    break;
                                case (2):
                                    lstTamanhoColunas = new List<int> { };
                                    break;
                                default:
                                    lstRegistrosColunas = new List<object> { };
                                    break;
                            }

                            objResgistrosColunas = null;
                            prpComandoSQLServerCE.Parameters.Clear();

                            for (int coluna = 0; coluna <= Campos_Dados[linha].Count - 1; coluna++)
                            {
                                switch (linha)
                                {
                                    case (0):
                                        //lstNomeColunas[coluna] = (string)Campos_Dados[linha][coluna];
                                        lstNomeColunas.Add((string)Campos_Dados[linha][coluna]);
                                        strNomeColunas +=
                                            string.Format
                                            (
                                            (coluna != Campos_Dados[linha].Count - 1)
                                            ?
                                            @"{0}, "
                                            :
                                            @"{0}",
                                            lstNomeColunas[coluna]
                                            );
                                        break;
                                    case (1):
                                        if (Campos_Dados[linha][coluna] != null)
                                        {
                                            //lstTipoColunas[coluna] = (System.Data.SqlDbType)Campos_Dados[linha][coluna];
                                            lstTipoColunas.Add((System.Data.SqlDbType)Campos_Dados[linha][coluna]);
                                        }
                                        else
                                        {
                                            //lstTipoColunas[coluna] = System.Data.SqlDbType.Variant;
                                            lstTipoColunas.Add(System.Data.SqlDbType.Variant);
                                        }
                                        break;
                                    case (2):
                                        if (Campos_Dados[linha][coluna] != null)
                                        {
                                            //lstTamanhoColunas[coluna] = (int)Campos_Dados[linha][coluna];
                                            lstTamanhoColunas.Add((int)Campos_Dados[linha][coluna]);
                                        }
                                        else
                                        {
                                            //lstTamanhoColunas[coluna] = (int)0;
                                            lstTamanhoColunas.Add((int)0);
                                        }
                                        break;
                                    default:
                                        //lstRegistrosColunas[coluna] = (object)Campos_Dados[linha][coluna];
                                        lstRegistrosColunas.Add((object)Campos_Dados[linha][coluna]);

                                        if (Campos_Dados[1][coluna] != null)
                                        {
                                            if (Campos_Dados[2][coluna] != null)
                                            {
                                                mtdExecutarParametroComandoSQLServerCE
                                                    (
                                                    lstNomeColunas[coluna],
                                                    lstTipoColunas[coluna],
                                                    lstRegistrosColunas[coluna],
                                                    lstTamanhoColunas[coluna]
                                                    );
                                            }
                                            else
                                            {
                                                mtdExecutarParametroComandoSQLServerCE
                                                    (
                                                    lstNomeColunas[coluna],
                                                    lstTipoColunas[coluna],
                                                    lstRegistrosColunas[coluna]
                                                    );
                                            }
                                        }
                                        else
                                        {
                                            mtdExecutarParametroComandoSQLServerCE
                                                (
                                                lstNomeColunas[coluna],
                                                lstRegistrosColunas[coluna]
                                                );
                                        }

                                        objResgistrosColunas +=
                                            string.Format
                                            (
                                            (coluna != Campos_Dados[linha].Count - 1)
                                            ?
                                            @"{1}{0}, "
                                            :
                                            @"{1}{0}",
                                            lstNomeColunas[coluna],
                                            strParametroSQLServerCE
                                            );
                                        break;
                                }
                            }
                            if (linha >= 0 + intLinhasAdicionais)
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

        public bool mtdInserirDadosParametroComandoSQLServerCE(string NomeTabela, List<List<object>> Campos_Dados, enmModoParametroComando ModoParametroComando)
        {
            bool saida = false;
            switch (ModoParametroComando)
            {
                case enmModoParametroComando.Valor:
                    saida = mtdInserirDadosParametroComandoSQLServerCEValor(NomeTabela, Campos_Dados);
                    break;
                case enmModoParametroComando.ValorTipo:
                    saida = mtdInserirDadosParametroComandoSQLServerCEValorTipo(NomeTabela, Campos_Dados);
                    break;
                case enmModoParametroComando.ValorTipoTamanho:
                    saida = mtdInserirDadosParametroComandoSQLServerCEValorTipoTamanho(NomeTabela, Campos_Dados);
                    break;
            }
            return saida;
        }





        public bool mtdDeletarDadosParametroComandoSQLServerCE(string NomeTabela, string CampoSelecionador, string Operacao, object Dado)
        {
            bool saida = true;

            mtdExecutarParametroComandoSQLServerCE
                (
                CampoSelecionador,
                Dado
                );

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            saida &= mtdExecutarComando(string.Format("DELETE FROM {0} WHERE {1} {2} {3}{1};", NomeTabela, CampoSelecionador, Operacao, strParametroSQLServerCE));
            mtdFecharConexao();

            return saida;
        }

        public bool mtdSelecionarDadosParametroComandoSQLServerCE(uint NumeroLinhas, string Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado)
        {
            bool saida = true;

            mtdExecutarParametroComandoSQLServerCE
                (
                CampoSelecionador,
                Dado
                );

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            saida &= mtdExecutarComando
                (
                string.Format
                (
                "SELECT {0}{1} FROM {2} WHERE {3} {4} {5}{3};",
                NumeroLinhas != 0 ? string.Format("TOP ({0}) ", NumeroLinhas) : string.Empty,
                Campos,
                NomeTabela,
                CampoSelecionador,
                Operacao,
                Dado,
                strParametroSQLServerCE
                )
                );

            return saida;
        }

        public bool mtdSelecionarDadosParametroComandoSQLServerCE(uint NumeroLinhas, string[] Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado)
        {
            bool saida = true;

            saida &= mtdSelecionarDadosParametroComandoSQLServerCE
                (
                NumeroLinhas,
                mtdVetorLinhaCampos(Campos),
                NomeTabela,
                CampoSelecionador,
                Operacao,
                Dado
                );

            return saida;
        }

        public bool mtdSelecionarDadosParametroComandoSQLServerCE(uint NumeroLinhas, List<string> Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado)
        {
            bool saida = true;

            saida &= mtdSelecionarDadosParametroComandoSQLServerCE
                (
                NumeroLinhas,
                mtdListaLinhaCampos(Campos),
                NomeTabela,
                CampoSelecionador,
                Operacao,
                Dado
                );

            return saida;
        }

        public bool mtdSelecionarDadosParametroComandoSQLServerCE(uint NumeroLinhas, string Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado, string CampoOrdenador, bool Crescente)
        {
            bool saida = true;

            mtdExecutarParametroComandoSQLServerCE
                (
                CampoSelecionador,
                Dado
                );

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            saida &= mtdExecutarComando
                (
                string.Format
                (
                "SELECT {0}{1} FROM {2} WHERE {3} {4} {7}{3} ORDER BY {5}{6};;",
                NumeroLinhas != 0 ? string.Format("TOP ({0}) ", NumeroLinhas) : string.Empty,
                Campos,
                NomeTabela,
                CampoSelecionador,
                Operacao,
                CampoOrdenador,
                Crescente ? string.Empty : " DESC",
                strParametroSQLServerCE
                )
                );

            return saida;
        }

        public bool mtdSelecionarDadosParametroComandoSQLServerCE(uint NumeroLinhas, string[] Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado, string CampoOrdenador, bool Crescente)
        {
            bool saida = true;

            saida &= mtdSelecionarDadosParametroComandoSQLServerCE
                (
                NumeroLinhas,
                mtdVetorLinhaCampos(Campos),
                NomeTabela,
                CampoSelecionador,
                Operacao,
                Dado,
                CampoOrdenador,
                Crescente
                );

            return saida;
        }

        public bool mtdSelecionarDadosParametroComandoSQLServerCE(uint NumeroLinhas, List<string> Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado, string CampoOrdenador, bool Crescente)
        {
            bool saida = true;

            saida &= mtdSelecionarDadosParametroComandoSQLServerCE
                (
                NumeroLinhas,
                mtdListaLinhaCampos(Campos),
                NomeTabela,
                CampoSelecionador,
                Operacao,
                Dado,
                CampoOrdenador,
                Crescente
                );

            return saida;
        }
     }

    public class clsBDSQLServerCE : clsImplementacaoBancoDados, itfImplementacaoBancoDados
    {
        private static object LockBDSQLServerCE = new object();

        public override bool mtdAbrirConexao(string Conexao, TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional)
        {
            lock (LockBDSQLServerCE)
            {
                bool saida = false;
                strExcecao = "mtdAbrirConexao: Nao houve excecao.";
                prpConexao = Conexao;
                //prpTipoSistemaGerenciadorBancoDadosRelacional = base.enuTipoSistemaGerenciadorBancoDadosRelacional;
                try
                {
                    switch (enuTipoSistemaGerenciadorBancoDadosRelacional)
                    {
                        case TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE:
                            objConexaoSQLServerCE.ConnectionString = prpConexao;
                            objConexaoSQLServerCE.Open();
                            if (objConexaoSQLServerCE.State == System.Data.ConnectionState.Open)
                            {
                                saida = true;
                            }
                            break;
                    }
                }
                catch (System.Exception ex)
                {
                    saida = false;
                    strExcecao = "mtdAbrirConexao: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                }
                return saida;
            }
        }

        public override bool mtdFecharConexao()
        {
            lock (LockBDSQLServerCE)
            {
                bool saida = false;
                strExcecao = "mtdFecharConexao: Nao houve excecao.";
                setNumeroLinhas = 0;
                try
                {
                    switch (enuTipoSistemaGerenciadorBancoDadosRelacional)
                    {
                        case TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE:
                            objConexaoSQLServerCE.Close();
                            break;
                    }
                    saida = true;
                }
                catch (System.Exception ex)
                {
                    saida = false;
                    strExcecao = "mtdFecharConexao: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                }
                return saida;
            }
        }

        public override bool mtdExecutarComando(string Comando)
        {
            lock (LockBDSQLServerCE)
            {
                bool saida = false;
                strExcecao = "mtdExecutarComando: Nao houve excecao.";
                try
                {
                    prpComando = Comando;
                    switch (enuTipoSistemaGerenciadorBancoDadosRelacional)
                    {
                        case TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE:
                            objComandoSQLServerCE.CommandType = System.Data.CommandType.Text;
                            objComandoSQLServerCE.CommandText = prpComando;
                            objComandoSQLServerCE.Connection = objConexaoSQLServerCE;
                            mtdFecharLeitorDados();
                            objComandoSQLServerCE.ExecuteNonQuery();
                            break;
                    }
                    saida = true;
                }
                catch (System.Exception ex)
                {
                    saida = false;
                    strExcecao = "mtdExecutarComando: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                }
                return saida;
            }
        }

        public override string[] mtdObterCabecalhoColunasVetor(string Tabela, string Comando, bool Otimizacao)
        {
            lock (LockBDSQLServerCE)
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
                }
                return vetCabecalhos;
            }
        }

        public override List<object> mtdObterCabecalhoColunasLista(string Tabela, string Comando, bool Otimizacao)
        {
            lock (LockBDSQLServerCE)
            {
                strExcecao = "mtdObterCabecalhoColunas: Nao houve excecao.";

                int intNumeroColunas = 0;
                List<object> lstCabecalhos = new List<object>(intNumeroColunas);
                try
                {
                    if (Otimizacao)
                    {
                        prpTabela = Tabela;
                        prpComando = Comando;
                        intNumeroColunas = mtdNumeroColunas();
                        lstCabecalhos = new List<object>() { };
                        for (int contador = 0; contador <= intNumeroColunas - 1; contador++)
                        {
                            lstCabecalhos.Add(null);
                            switch (enuTipoSistemaGerenciadorBancoDadosRelacional)
                            {
                                case TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE:
                                    lstCabecalhos[contador] = objLeitorDadosSQLServerCE.GetName(contador);
                                    break;
                            }
                        }
                    }
                    else
                    {
                        mtdAdaptadorDados();
                        intNumeroColunas = mtdNumeroColunas(false);
                        lstCabecalhos = new List<object>();
                        for (int contador = 0; contador <= intNumeroColunas - 1; contador += 1)
                        {
                            lstCabecalhos.Add(null);
                            lstCabecalhos[contador] = objAjustadorDados.Tables[strTabela].Columns[contador].ColumnName.ToString();
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    strExcecao = "mtdObterCabecalhoColunas: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                }
                return lstCabecalhos;
            }
        }

        public override bool mtdDefinirLeitorDados(System.Data.CommandBehavior ComandoComportamento)
        {
            lock (LockBDSQLServerCE)
            {
                bool saida = false;
                strExcecao = "mtdDefinirLeitorDados: Nao houve excecao.";
                prpComandoComportamento = ComandoComportamento;
                try
                {
                    switch (enuTipoSistemaGerenciadorBancoDadosRelacional)
                    {
                        case TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE:
                            objLeitorDadosSQLServerCE = objComandoSQLServerCE.ExecuteReader(prpComandoComportamento);
                            break;
                    }
                    saida = true;
                }
                catch (System.Exception ex)
                {
                    saida = false;
                    strExcecao = "mtdDefinirLeitorDados: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                }
                intLinha = 0;
                return saida;
            }
        }

        public override object[] mtdObterValorRegistroVetor(string Tabela, string Comando, bool Otimizacao)
        {
            lock (LockBDSQLServerCE)
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
                                case TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE:
                                    vetValores[contador] = objLeitorDadosSQLServerCE[contador];
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
                }
                return vetValores;
            }
        }

        public override List<object> mtdObterValorRegistroLista(string Tabela, string Comando, bool Otimizacao)
        {
            lock (LockBDSQLServerCE)
            {
                strExcecao = "mtdObterValorRegistro: Nao houve excecao.";
                int intNumeroColunas = 0;
                List<object> lstValores = null;
                try
                {
                    if (Otimizacao)
                    {
                        prpTabela = Tabela;
                        prpComando = Comando;
                        intNumeroColunas = mtdNumeroColunas();
                        lstValores = new List<object>(intNumeroColunas);
                        for (int contador = 0; contador <= intNumeroColunas - 1; contador++)
                        {
                            switch (enuTipoSistemaGerenciadorBancoDadosRelacional)
                            {
                                case TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE:
                                    lstValores[contador] = objLeitorDadosSQLServerCE[contador];
                                    break;
                            }
                        }
                    }
                    else
                    {
                        mtdAdaptadorDados();
                        intNumeroColunas = mtdNumeroColunas(false);
                        lstValores = new List<object>(intNumeroColunas);
                        for (int contador = 0; contador <= intNumeroColunas - 1; contador += 1)
                        {
                            lstValores[contador] = objAjustadorDados.Tables[strTabela].Rows[0][contador];
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    strExcecao = "mtdObterValorRegistro: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                }
                return lstValores;
            }
        }

        public override System.Type[] mtdObterTipoRegistroVetor(string Tabela, string Comando, bool Otimizacao)
        {
            lock (LockBDSQLServerCE)
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
                }
                return vetTipos;
            }
        }

        public override List<System.Type> mtdObterTipoRegistroLista(string Tabela, string Comando, bool Otimizacao)
        {
            lock (LockBDSQLServerCE)
            {
                strExcecao = "mtdObterTipoRegistro: Nao houve excecao.";
                int intNumeroColunas = 0;
                List<System.Type> lstTipos = null;
                try
                {
                    if (Otimizacao)
                    {
                        prpTabela = Tabela;
                        prpComando = Comando;
                        intNumeroColunas = mtdNumeroColunas();
                        lstTipos = new List<System.Type>(intNumeroColunas);
                        for (int contador = 0; contador <= intNumeroColunas - 1; contador++)
                        {
                            switch (enuTipoSistemaGerenciadorBancoDadosRelacional)
                            {
                                case TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE:
                                    lstTipos[contador] = objLeitorDadosSQLServerCE.GetValue(contador).GetType();
                                    break;
                            }
                        }
                    }
                    else
                    {
                        mtdAdaptadorDados();
                        intNumeroColunas = mtdNumeroColunas(false);
                        lstTipos = new List<System.Type>(intNumeroColunas);
                        for (int contador = 0; contador <= intNumeroColunas - 1; contador += 1)
                        {
                            lstTipos[contador] = objAjustadorDados.Tables[strTabela].Columns[contador].Caption.GetType();
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    strExcecao = "mtdObterTipoRegistro: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                }
                return lstTipos;
            }
        }

        public override bool mtdFecharLeitorDados()
        {
            lock (LockBDSQLServerCE)
            {
                bool saida = false;
                strExcecao = "mtdFecharLeitorDados: Nao houve excecao.";
                try
                {
                    switch (enuTipoSistemaGerenciadorBancoDadosRelacional)
                    {
                        case TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE:
                            if (!objLeitorDadosSQLServerCE.Equals(null))
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
                    saida = false;
                    strExcecao = "mtdFecharLeitorDados: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                }
                intLinha = 0;
                return saida;
            }
        }

        public override bool mtdAdaptadorDados(string Conexao, string Comando, string Tabela, TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional)
        {
            lock (LockBDSQLServerCE)
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
                    saida = false;
                    strExcecao = "mtdAdaptadorDados: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                }
                return saida;
            }
        }

        public override bool mtdProximoRegistro()
        {
            lock (LockBDSQLServerCE)
            {
                strExcecao = "mtdProximoRegistro: Nao houve excecao.";
                bool saida = false;
                try
                {
                    switch (enuTipoSistemaGerenciadorBancoDadosRelacional)
                    {
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
                }
                return saida;
            }
        }

        public override int mtdNumeroColunas(bool Otimizacao)
        {
            lock (LockBDSQLServerCE)
            {
                strExcecao = "mtdNumeroColunas: Nao houve excecao.";
                int intNumeroColunas = 0;
                try
                {
                    if (Otimizacao)
                    {
                        switch (enuTipoSistemaGerenciadorBancoDadosRelacional)
                        {
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
                }
                return intNumeroColunas;
            }
        }

        public override int mtdNumeroLinhas(bool Otimizacao)
        {
            lock (LockBDSQLServerCE)
            {
                strExcecao = "mtdNumeroLinhas: Nao houve excecao.";
                int intNumeroLinhas = 0;
                try
                {
                    if (Otimizacao)
                    {
                        switch (enuTipoSistemaGerenciadorBancoDadosRelacional)
                        {
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
                }
                return intNumeroLinhas;
            }
        }




        public bool mtdAtualizarDadosParametroComando(string NomeTabela, object[,] Campos_Dados, string CampoBase, string Operacao, object DadoBase, enmModoParametroComando ModoParametroComando)
        {
            return mtdAtualizarDadosParametroComandoSQLServerCE(NomeTabela, Campos_Dados, CampoBase, Operacao, DadoBase, ModoParametroComando);
        }

        public bool mtdAtualizarDadosParametroComando(string NomeTabela, object[][] Campos_Dados, string CampoBase, string Operacao, object DadoBase, enmModoParametroComando ModoParametroComando)
        {
            return mtdAtualizarDadosParametroComandoSQLServerCE(NomeTabela, Campos_Dados, CampoBase, Operacao, DadoBase, ModoParametroComando);
        }

        public bool mtdAtualizarDadosParametroComando(string NomeTabela, List<List<object>> Campos_Dados, string CampoBase, string Operacao, object DadoBase, enmModoParametroComando ModoParametroComando)
        {
            return mtdAtualizarDadosParametroComandoSQLServerCE(NomeTabela, Campos_Dados, CampoBase, Operacao, DadoBase, ModoParametroComando);
        }

        public bool mtdAtualizarDadosParametroComando(string NomeTabela, object[,] Campos_Dados_CampoBase_Operacao_DadoBase, enmModoParametroComando ModoParametroComando)
        {
            return mtdAtualizarDadosParametroComandoSQLServerCE(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase, ModoParametroComando);
        }

        public bool mtdAtualizarDadosParametroComando(string NomeTabela, object[][] Campos_Dados_CampoBase_Operacao_DadoBase, enmModoParametroComando ModoParametroComando)
        {
            return mtdAtualizarDadosParametroComandoSQLServerCE(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase, ModoParametroComando);
        }

        public bool mtdAtualizarDadosParametroComando(string NomeTabela, List<List<object>> Campos_Dados_CampoBase_Operacao_DadoBase, enmModoParametroComando ModoParametroComando)
        {
            return mtdAtualizarDadosParametroComandoSQLServerCE(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase, ModoParametroComando);
        }

        public bool mtdInserirDadosParametroComando(string NomeTabela, object[,] Campos_Dados, enmModoParametroComando ModoParametroComando)
        {
            return mtdInserirDadosParametroComandoSQLServerCE(NomeTabela, Campos_Dados, ModoParametroComando);
        }

        public bool mtdInserirDadosParametroComando(string NomeTabela, object[][] Campos_Dados, enmModoParametroComando ModoParametroComando)
        {
            return mtdInserirDadosParametroComandoSQLServerCE(NomeTabela, Campos_Dados, ModoParametroComando);
        }

        public bool mtdInserirDadosParametroComando(string NomeTabela, List<List<object>> Campos_Dados, enmModoParametroComando ModoParametroComando)
        {
            return mtdInserirDadosParametroComandoSQLServerCE(NomeTabela, Campos_Dados, ModoParametroComando);
        }




        public bool mtdDeletarDadosParametroComando(string NomeTabela, string CampoSelecionador, string Operacao, object Dado)
        {
            return mtdDeletarDadosParametroComandoSQLServerCE(NomeTabela, CampoSelecionador, Operacao, Dado);
        }

        public bool mtdSelecionarDadosParametroComando(uint NumeroLinhas, string Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado)
        {
            return mtdSelecionarDadosParametroComandoSQLServerCE(NumeroLinhas, Campos, NomeTabela, CampoSelecionador, Operacao, Dado);
        }

        public bool mtdSelecionarDadosParametroComando(uint NumeroLinhas, string[] Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado)
        {
            return mtdSelecionarDadosParametroComandoSQLServerCE(NumeroLinhas, Campos, NomeTabela, CampoSelecionador, Operacao, Dado);
        }

        public bool mtdSelecionarDadosParametroComando(uint NumeroLinhas, List<string> Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado)
        {
            return mtdSelecionarDadosParametroComandoSQLServerCE(NumeroLinhas, Campos, NomeTabela, CampoSelecionador, Operacao, Dado);
        }

        public bool mtdSelecionarDadosParametroComando(uint NumeroLinhas, string Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado, string CampoOrdenador, bool Crescente)
        {
            return mtdSelecionarDadosParametroComandoSQLServerCE(NumeroLinhas, Campos, NomeTabela, CampoSelecionador, Operacao, Dado, CampoOrdenador, Crescente);
        }

        public bool mtdSelecionarDadosParametroComando(uint NumeroLinhas, string[] Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado, string CampoOrdenador, bool Crescente)
        {
            return mtdSelecionarDadosParametroComandoSQLServerCE(NumeroLinhas, Campos, NomeTabela, CampoSelecionador, Operacao, Dado, CampoOrdenador, Crescente);
        }

        public bool mtdSelecionarDadosParametroComando(uint NumeroLinhas, List<string> Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado, string CampoOrdenador, bool Crescente)
        {
            return mtdSelecionarDadosParametroComandoSQLServerCE(NumeroLinhas, Campos, NomeTabela, CampoSelecionador, Operacao, Dado, CampoOrdenador, Crescente);
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