using System;
using System.Collections.Generic;
using System.Text;

namespace WebServiceInspecaoCSNet40
{
    public partial class clsConexaoBancoDados
    {

        // Constantes de instancia do MySQL

        public const string cntStringConexaoMySQLOdbc = @"Driver={0}; Server={1}; Port={2}; charset={3}; Database={4}; User={5}; Password={6}; sslca{7}; sslcert={8}; sslkey={9}; sslverify={10}; Socket={11}; Option={12};";
        public const string cntStringConexaoMySQLOleDb = @"Provider={0}; Data Source={1}; User Id={2}; Password={3};";
        public const string cntStringConexaoMySQLNativa = @"Server={0}; Port={1}; Database={2}; Uid={3}; Pwd={4}; Encrypt={5}; Connection Timeout={6}; Ignore Prepare={7}; Protocol={8}; CharSet={9}; Shared Memory Name={10};";

        public const string cntExemploStringConexaoMySQLOdbc = @"Driver={MySQL ODBC 3.51 Driver}; Server=localhost; Port=3306; Database=myDataBase; charset=UTF8; User=myUsername; Password=myPassword; sslca=c:\\cacert.pem; sslcert=c:\\client-cert.pem; sslkey=c:\\client-key.pem; sslverify=1; Socket=MySQL; Option=3;";
        public const string cntExemploStringConexaoMySQLOleDb = @"Provider=MySQLProv; Data Source=mydb; User Id=myUsername; Password=myPassword;";
        public const string cntExemploStringConexaoMySQLNativa = @"Server=myServerAddress; Port=1234; Database=myDataBase; Uid=myUsername; Pwd=myPassword; Encrypt=true; Connection Timeout=5; Ignore Prepare=true; Protocol=socket; CharSet=UTF8; Shared Memory Name=MYSQL;";

        // Variaveis somente leitura de instancia do MySQL

        private readonly string[] cntDriverMySQL = { "DRIVER", "{MySQL ODBC 3.51Driver}" };
        private readonly string[] cntProviderMySQL = { "Provider", "MySQLProv" };
        private readonly string[] cntServerMySQL = { "Server", string.Empty };
        private readonly string[] cntPortMySQL = { "Port", "3306" };
        private readonly string[] cntDataBaseMySQL = { "DataBase", string.Empty };
        private readonly string[] cntCharsetMySQL = { "charset", string.Empty };
        private readonly string[] cntUserIdMySQL = { "User Id", string.Empty };
        private readonly string[] cntPasswordMySQL = { "Password", string.Empty };
        private readonly string[] cntsslcaMySQL = { "sslca", string.Empty };
        private readonly string[] cntsslcertMySQL = { "sslcert", string.Empty };
        private readonly string[] cntsslkeyMySQL = { "sslkey", string.Empty };
        private readonly string[] cntsslverifyMySQL = { "sslverify", "1" };
        private readonly string[] cntSocketMySQL = { "Socket", string.Empty };
        private readonly string[] cntOptionMySQL = { "Option", "3" };
        private readonly string[] cntEncryptMySQL = { "Encrypt", "False" };
        private readonly string[] cntConnectionTimeoutMySQL = { "Connection Timeout", "5" };
        private readonly string[] cntIgnorePrepareMySQL = { "Ignore Prepare", "False" };
        private readonly string[] cntProtocolMySQL = { "Protocol", string.Empty };
        private readonly string[] cntSharedMemoryNameMySQL = { "Shared Memory Name", string.Empty };

        // Variaveis de instancia do MySQL

        private string[] strDriverMySQL;
        private string[] strProviderMySQL;
        private string[] strServerMySQL;
        private string[] strPortMySQL;
        private string[] strDataBaseMySQL;
        private string[] strCharsetMySQL;
        private string[] strUserIdMySQL;
        private string[] strPasswordMySQL;
        private string[] strsslcaMySQL;
        private string[] strsslcertMySQL;
        private string[] strsslkeyMySQL;
        private string[] strsslverifyMySQL;
        private string[] strSocketMySQL;
        private string[] strOptionMySQL;
        private string[] strEncryptMySQL;
        private string[] strConnectionTimeoutMySQL;
        private string[] strIgnorePrepareMySQL;
        private string[] strProtocolMySQL;
        private string[] strSharedMemoryNameMySQL;

        private string[] vetDriverMySQL = { "Driver" };
        private string[] vetProviderMySQL = { "Provider" };
        private string[] vetServerMySQL = { "DataSource", "Data Source", "Server" };
        private string[] vetPortMySQL = { "Port" };
        private string[] vetDataBaseMySQL = { "DataBase", "Data Base", "InitialCatalog", "Initial Catalog" };
        private string[] vetCharsetMySQL = { "Charset" };
        private string[] vetUserIdMySQL = { "User", "UserId", "User Id", "UID" };
        private string[] vetPasswordMySQL = { "Password", "Pwd" };
        private string[] vetsslcaMySQL = { "sslca" };
        private string[] vetsslcertMySQL = { "sslcert" };
        private string[] vetsslkeyMySQL = { "sslkey" };
        private string[] vetsslverifyMySQL = { "sslverify" };
        private string[] vetSocketMySQL = { "Socket" };
        private string[] vetOptionMySQL = { "Option" };
        private string[] vetEncryptMySQL = { "Encrypt" };
        private string[] vetConnectionTimeoutMySQL = { "ConnectionTimeout", "Connection Timeout" };
        private string[] vetIgnorePrepareMySQL = { "IgnorePrepare", "Ignore Prepare" };
        private string[] vetProtocolMySQL = { "Protocol" };
        private string[] vetSharedMemoryNameMySQL = { "SharedMemoryName", "Shared Memory Name" };

        // Variaveis que determinam se a conexao incorporara o banco de dados. Isso facilita na criacao, alteracao ou delecao do banco de dados.

        private bool blnPermitirBancoDadosMySQL = true;

        public bool prpPermitirBancoDadosMySQL
        {
            get
            {
                return blnPermitirBancoDadosMySQL;
            }
            set
            {
                blnPermitirBancoDadosMySQL = value;
            }
        }

        // Propriedades de instancia do MySQL

        public string prpDriverMySQL
        {
            get
            {
                if (strDriverMySQL == null)
                {
                    strDriverMySQL = new string[2] { cntDriverMySQL[0], cntDriverMySQL[1] };
                }
                return strDriverMySQL[1];
            }
            set
            {
                if (strDriverMySQL == null)
                {
                    strDriverMySQL = new string[2] { cntDriverMySQL[0], cntDriverMySQL[1] };
                }
                strDriverMySQL[1] = value;
                mtdReDefinirConexaoString(strDriverMySQL);
            }
        }

        public string prpProviderMySQL
        {
            get
            {
                if (strProviderMySQL == null)
                {
                    strProviderMySQL = new string[2] { cntProviderMySQL[0], cntProviderMySQL[1] };
                }
                return strProviderMySQL[1];
            }
            set
            {
                if (strProviderMySQL == null)
                {
                    strProviderMySQL = new string[2] { cntProviderMySQL[0], cntProviderMySQL[1] };
                }
                strProviderMySQL[1] = value;
                mtdReDefinirConexaoString(strProviderMySQL);
            }
        }

        public string prpServerMySQL
        {
            get
            {
                if (strServerMySQL == null)
                {
                    strServerMySQL = new string[2] { cntServerMySQL[0], cntServerMySQL[1] };
                }
                return strServerMySQL[1];
            }
            set
            {
                if (strServerMySQL == null)
                {
                    strServerMySQL = new string[2] { cntServerMySQL[0], cntServerMySQL[1] };
                }
                strServerMySQL[1] = value;
                mtdReDefinirConexaoString(strServerMySQL);
            }
        }

        public string prpPortMySQL
        {
            get
            {
                if (strPortMySQL == null)
                {
                    strPortMySQL = new string[2] { cntPortMySQL[0], cntPortMySQL[1] };
                }
                return strPortMySQL[1];
            }
            set
            {
                if (strPortMySQL == null)
                {
                    strPortMySQL = new string[2] { cntPortMySQL[0], cntPortMySQL[1] };
                }
                strPortMySQL[1] = value;
                mtdReDefinirConexaoString(strPortMySQL);
            }
        }

        public string prpDataBaseMySQL
        {
            get
            {
                if (strDataBaseMySQL == null)
                {
                    strDataBaseMySQL = new string[2] { cntDataBaseMySQL[0], cntDataBaseMySQL[1] };
                }
                return strDataBaseMySQL[1];
            }
            set
            {
                if (strDataBaseMySQL == null)
                {
                    strDataBaseMySQL = new string[2] { cntDataBaseMySQL[0], cntDataBaseMySQL[1] };
                }
                strDataBaseMySQL[1] = value;
                mtdReDefinirConexaoString(strDataBaseMySQL);
            }
        }

        public string prpCharsetMySQL
        {
            get
            {
                if (strCharsetMySQL == null)
                {
                    strCharsetMySQL = new string[2] { cntCharsetMySQL[0], cntCharsetMySQL[1] };
                }
                return strCharsetMySQL[1];
            }
            set
            {
                if (strCharsetMySQL == null)
                {
                    strCharsetMySQL = new string[2] { cntCharsetMySQL[0], cntCharsetMySQL[1] };
                }
                strCharsetMySQL[1] = value;
                mtdReDefinirConexaoString(strCharsetMySQL);
            }
        }

        public string prpUserIdMySQL
        {
            get
            {
                if (strUserIdMySQL == null)
                {
                    strUserIdMySQL = new string[2] { cntUserIdMySQL[0], cntUserIdMySQL[1] };
                }
                return strUserIdMySQL[1];
            }
            set
            {
                if (strUserIdMySQL == null)
                {
                    strUserIdMySQL = new string[2] { cntUserIdMySQL[0], cntUserIdMySQL[1] };
                }
                strUserIdMySQL[1] = value;
                mtdReDefinirConexaoString(strUserIdMySQL);
            }
        }

        public string prpPasswordMySQL
        {
            get
            {
                if (strPasswordMySQL == null)
                {
                    strPasswordMySQL = new string[2] { cntPasswordMySQL[0], cntPasswordMySQL[1] };
                }
                return strPasswordMySQL[1];
            }
            set
            {
                if (strPasswordMySQL == null)
                {
                    strPasswordMySQL = new string[2] { cntPasswordMySQL[0], cntPasswordMySQL[1] };
                }
                strPasswordMySQL[1] = value;
                mtdReDefinirConexaoString(strPasswordMySQL);
            }
        }

        public string prpsslcaMySQL
        {
            get
            {
                if (strsslcaMySQL == null)
                {
                    strsslcaMySQL = new string[2] { cntsslcaMySQL[0], cntsslcaMySQL[1] };
                }
                return strsslcaMySQL[1];
            }
            set
            {
                if (strsslcaMySQL == null)
                {
                    strsslcaMySQL = new string[2] { cntsslcaMySQL[0], cntsslcaMySQL[1] };
                }
                strsslcaMySQL[1] = value;
                mtdReDefinirConexaoString(strsslcaMySQL);
            }
        }

        public string prpsslcertMySQL
        {
            get
            {
                if (strsslcertMySQL == null)
                {
                    strsslcertMySQL = new string[2] { cntsslcertMySQL[0], cntsslcertMySQL[1] };
                }
                return strsslcertMySQL[1];
            }
            set
            {
                if (strsslcertMySQL == null)
                {
                    strsslcertMySQL = new string[2] { cntsslcertMySQL[0], cntsslcertMySQL[1] };
                }
                strsslcertMySQL[1] = value;
                mtdReDefinirConexaoString(strsslcertMySQL);
            }
        }

        public string prpsslkeyMySQL
        {
            get
            {
                if (strsslkeyMySQL == null)
                {
                    strsslkeyMySQL = new string[2] { cntsslkeyMySQL[0], cntsslkeyMySQL[1] };
                }
                return strsslkeyMySQL[1];
            }
            set
            {
                if (strsslkeyMySQL == null)
                {
                    strsslkeyMySQL = new string[2] { cntsslkeyMySQL[0], cntsslkeyMySQL[1] };
                }
                strsslkeyMySQL[1] = value;
                mtdReDefinirConexaoString(strsslkeyMySQL);
            }
        }

        public string prpsslverifyMySQL
        {
            get
            {
                if (strsslverifyMySQL == null)
                {
                    strsslverifyMySQL = new string[2] { cntsslverifyMySQL[0], cntsslverifyMySQL[1] };
                }
                return strsslverifyMySQL[1];
            }
            set
            {
                if (strsslverifyMySQL == null)
                {
                    strsslverifyMySQL = new string[2] { cntsslverifyMySQL[0], cntsslverifyMySQL[1] };
                }
                strsslverifyMySQL[1] = value;
                mtdReDefinirConexaoString(strsslverifyMySQL);
            }
        }

        public string prpSocketMySQL
        {
            get
            {
                if (strSocketMySQL == null)
                {
                    strSocketMySQL = new string[2] { cntSocketMySQL[0], cntSocketMySQL[1] };
                }
                return strSocketMySQL[1];
            }
            set
            {
                if (strSocketMySQL == null)
                {
                    strSocketMySQL = new string[2] { cntSocketMySQL[0], cntSocketMySQL[1] };
                }
                strSocketMySQL[1] = value;
                mtdReDefinirConexaoString(strSocketMySQL);
            }
        }

        public string prpOptionMySQL
        {
            get
            {
                if (strOptionMySQL == null)
                {
                    strOptionMySQL = new string[2] { cntOptionMySQL[0], cntOptionMySQL[1] };
                }
                return strOptionMySQL[1];
            }
            set
            {
                if (strOptionMySQL == null)
                {
                    strOptionMySQL = new string[2] { cntOptionMySQL[0], cntOptionMySQL[1] };
                }
                strOptionMySQL[1] = value;
                mtdReDefinirConexaoString(strOptionMySQL);
            }
        }

        public string prpEncryptMySQL
        {
            get
            {
                if (strEncryptMySQL == null)
                {
                    strEncryptMySQL = new string[2] { cntEncryptMySQL[0], cntEncryptMySQL[1] };
                }
                return strEncryptMySQL[1];
            }
            set
            {
                if (strEncryptMySQL == null)
                {
                    strEncryptMySQL = new string[2] { cntEncryptMySQL[0], cntEncryptMySQL[1] };
                }
                strEncryptMySQL[1] = value;
                mtdReDefinirConexaoString(strEncryptMySQL);
            }
        }

        public string prpConnectionTimeoutMySQL
        {
            get
            {
                if (strConnectionTimeoutMySQL == null)
                {
                    strConnectionTimeoutMySQL = new string[2] { cntConnectionTimeoutMySQL[0], cntConnectionTimeoutMySQL[1] };
                }
                return strConnectionTimeoutMySQL[1];
            }
            set
            {
                if (strConnectionTimeoutMySQL == null)
                {
                    strConnectionTimeoutMySQL = new string[2] { cntConnectionTimeoutMySQL[0], cntConnectionTimeoutMySQL[1] };
                }
                strConnectionTimeoutMySQL[1] = value;
                mtdReDefinirConexaoString(strConnectionTimeoutMySQL);
            }
        }

        public string prpIgnorePrepareMySQL
        {
            get
            {
                if (strIgnorePrepareMySQL == null)
                {
                    strIgnorePrepareMySQL = new string[2] { cntIgnorePrepareMySQL[0], cntIgnorePrepareMySQL[1] };
                }
                return strIgnorePrepareMySQL[1];
            }
            set
            {
                if (strIgnorePrepareMySQL == null)
                {
                    strIgnorePrepareMySQL = new string[2] { cntIgnorePrepareMySQL[0], cntIgnorePrepareMySQL[1] };
                }
                strIgnorePrepareMySQL[1] = value;
                mtdReDefinirConexaoString(strIgnorePrepareMySQL);
            }
        }

        public string prpProtocolMySQL
        {
            get
            {
                if (strProtocolMySQL == null)
                {
                    strProtocolMySQL = new string[2] { cntProtocolMySQL[0], cntProtocolMySQL[1] };
                }
                return strProtocolMySQL[1];
            }
            set
            {
                if (strProtocolMySQL == null)
                {
                    strProtocolMySQL = new string[2] { cntProtocolMySQL[0], cntProtocolMySQL[1] };
                }
                strProtocolMySQL[1] = value;
                mtdReDefinirConexaoString(strProtocolMySQL);
            }
        }

        public string prpSharedMemoryNameMySQL
        {
            get
            {
                if (strSharedMemoryNameMySQL == null)
                {
                    strSharedMemoryNameMySQL = new string[2] { cntSharedMemoryNameMySQL[0], cntSharedMemoryNameMySQL[1] };
                }
                return strSharedMemoryNameMySQL[1];
            }
            set
            {
                if (strSharedMemoryNameMySQL == null)
                {
                    strSharedMemoryNameMySQL = new string[2] { cntSharedMemoryNameMySQL[0], cntSharedMemoryNameMySQL[1] };
                }
                strSharedMemoryNameMySQL[1] = value;
                mtdReDefinirConexaoString(strSharedMemoryNameMySQL);
            }
        }

        // Metodos de instancia do MySQL

        public string[] mtdValidarConexaoDispositivoMySQL(string Conexao)
        {
            strDriverMySQL = mtdValidarConexao(Conexao, vetDriverMySQL);
            return strDriverMySQL;
        }

        public string[] mtdValidarConexaoProvedorMySQL(string Conexao)
        {
            strProviderMySQL = mtdValidarConexao(Conexao, vetProviderMySQL);
            return strProviderMySQL;
        }

        public string[] mtdValidarConexaoServidorMySQL(string Conexao)
        {
            strServerMySQL = mtdValidarConexao(Conexao, vetServerMySQL);
            return strServerMySQL;
        }

        public string[] mtdValidarConexaoPortaMySQL(string Conexao)
        {
            strPortMySQL = mtdValidarConexao(Conexao, vetPortMySQL);
            return strPortMySQL;
        }

        public string[] mtdValidarConexaoBaseDadosMySQL(string Conexao)
        {
            strDataBaseMySQL = mtdValidarConexao(Conexao, vetDataBaseMySQL);
            return strDataBaseMySQL;
        }

        public string[] mtdValidarConexaoAjusteCaractereMySQL(string Conexao)
        {
            strCharsetMySQL = mtdValidarConexao(Conexao, vetCharsetMySQL);
            return strCharsetMySQL;
        }

        public string[] mtdValidarConexaoUsuarioMySQL(string Conexao)
        {
            strUserIdMySQL = mtdValidarConexao(Conexao, vetUserIdMySQL);
            strUserIdMySQL[1] = strUserIdMySQL[1].ToLower();
            return strUserIdMySQL;
        }

        public string[] mtdValidarConexaoSenhaMySQL(string Conexao)
        {
            strPasswordMySQL = mtdValidarConexao(Conexao, vetPasswordMySQL);
            return strPasswordMySQL;
        }

        public string[] mtdValidarConexaosslcaMySQL(string Conexao)
        {
            strsslcaMySQL = mtdValidarConexao(Conexao, vetsslcaMySQL);
            return strsslcaMySQL;
        }

        public string[] mtdValidarConexaosslcertMySQL(string Conexao)
        {
            strsslcertMySQL = mtdValidarConexao(Conexao, vetsslcertMySQL);
            return strsslcertMySQL;
        }

        public string[] mtdValidarConexaosslkeyMySQL(string Conexao)
        {
            strsslkeyMySQL = mtdValidarConexao(Conexao, vetsslkeyMySQL);
            return strsslkeyMySQL;
        }

        public string[] mtdValidarConexaosslverifyMySQL(string Conexao)
        {
            strsslverifyMySQL = mtdValidarConexao(Conexao, vetsslverifyMySQL);
            return strsslverifyMySQL;
        }

        public string[] mtdValidarConexaoSocketMySQL(string Conexao)
        {
            strSocketMySQL = mtdValidarConexao(Conexao, vetSocketMySQL);
            return strSocketMySQL;
        }

        public string[] mtdValidarConexaoOpcaoMySQL(string Conexao)
        {
            strOptionMySQL = mtdValidarConexao(Conexao, vetOptionMySQL);
            return strOptionMySQL;
        }

        public string[] mtdValidarConexaoEncriptacaoMySQL(string Conexao)
        {
            strEncryptMySQL = mtdValidarConexao(Conexao, vetEncryptMySQL);
            return strEncryptMySQL;
        }

        public string[] mtdValidarConexaoTempoSaidaMySQL(string Conexao)
        {
            strConnectionTimeoutMySQL = mtdValidarConexao(Conexao, vetConnectionTimeoutMySQL);
            return vetConnectionTimeoutMySQL;
        }

        public string[] mtdValidarConexaoIgnorarPreparoMySQL(string Conexao)
        {
            strIgnorePrepareMySQL = mtdValidarConexao(Conexao, vetIgnorePrepareMySQL);
            return strIgnorePrepareMySQL;
        }

        public string[] mtdValidarConexaoProtocoloMySQL(string Conexao)
        {
            strProtocolMySQL = mtdValidarConexao(Conexao, vetProtocolMySQL);
            return strProtocolMySQL;
        }

        public string[] mtdValidarConexaoNomeMemoriaCompartilhadoMySQL(string Conexao)
        {
            strSharedMemoryNameMySQL = mtdValidarConexao(Conexao, vetSharedMemoryNameMySQL);
            return strSharedMemoryNameMySQL;
        }

        public string mtdValidarConexaoMySQL(string Conexao)
        {
            string saida = string.Empty;

            prpTipoConexao = TipoConexao.Indisponivel;
            //if (strDriverMySQL == null || strDriverMySQL[1] == cntDriverMySQL[1])
            //{
            mtdValidarConexaoDispositivoMySQL(Conexao);
            //}
            if (strProviderMySQL == null && strDriverMySQL != null)
            {
                prpTipoConexao = TipoConexao.ConexaoMySQLOdbc;
            }
            //if (strProviderMySQL == null || strProviderMySQL[1] == cntProviderMySQL[1])
            //{
            mtdValidarConexaoProvedorMySQL(Conexao);
            //}
            if (strProviderMySQL != null && strDriverMySQL == null)
            {
                prpTipoConexao = TipoConexao.ConexaoMySQLOleDb;
            }
            //if (strServerMySQL == null || strServerMySQL[1] == cntServerMySQL[1])
            //{
            mtdValidarConexaoServidorMySQL(Conexao);
            //}
            if (strProviderMySQL == null && strDriverMySQL == null && strServerMySQL != null)
            {
                prpTipoConexao = TipoConexao.ConexaoMySQLNativa;
            }
            //if (strPortMySQL == null || strPortMySQL[1] == cntPortMySQL[1])
            //{
            mtdValidarConexaoPortaMySQL(Conexao);
            //}
            //if (strDataBaseMySQL == null || strDataBaseMySQL[1] == cntDataBaseMySQL[1])
            //{
            mtdValidarConexaoBaseDadosMySQL(Conexao);
            //}
            //if (strCharsetMySQL == null || strCharsetMySQL[1] == cntCharsetMySQL[1])
            //{
            mtdValidarConexaoAjusteCaractereMySQL(Conexao);
            //}
            //if (strUserIdMySQL == null || strUserIdMySQL[1] == cntUserIdMySQL[1])
            //{
            mtdValidarConexaoUsuarioMySQL(Conexao);
            //}
            //if (strPasswordMySQL == null || strPasswordMySQL[1] == cntPasswordMySQL[1])
            //{
            mtdValidarConexaoSenhaMySQL(Conexao);
            //}
            //if (strsslcaMySQL == null || strsslcaMySQL[1] == cntsslcaMySQL[1])
            //{
            mtdValidarConexaosslcaMySQL(Conexao);
            //}
            //if (strsslcertMySQL == null || strsslcertMySQL[1] == cntsslcertMySQL[1])
            //{
            mtdValidarConexaosslcertMySQL(Conexao);
            //}
            //if (strsslkeyMySQL == null || strsslkeyMySQL[1] == cntsslkeyMySQL[1])
            //{
            mtdValidarConexaosslkeyMySQL(Conexao);
            //}
            //if (strsslverifyMySQL == null || strsslverifyMySQL[1] == cntsslverifyMySQL[1])
            //{
            mtdValidarConexaosslverifyMySQL(Conexao);
            //}
            //if (strSocketMySQL == null || strSocketMySQL[1] == cntSocketMySQL[1])
            //{
            mtdValidarConexaoSocketMySQL(Conexao);
            //}
            //if (strOptionMySQL == null || strOptionMySQL[1] == cntOptionMySQL[1])
            //{
            mtdValidarConexaoOpcaoMySQL(Conexao);
            //}
            //if (strEncryptMySQL == null || strEncryptMySQL[1] == cntEncryptMySQL[1])
            //{
            mtdValidarConexaoEncriptacaoMySQL(Conexao);
            //}
            //if (strConnectionTimeoutMySQL == null || strConnectionTimeoutMySQL[1] == cntConnectionTimeoutMySQL[1])
            //{
            mtdValidarConexaoTempoSaidaMySQL(Conexao);
            //}
            //if (strIgnorePrepareMySQL == null || strIgnorePrepareMySQL[1] == cntIgnorePrepareMySQL[1])
            //{
            mtdValidarConexaoIgnorarPreparoMySQL(Conexao);
            //}
            //if (strProtocolMySQL == null || strProtocolMySQL[1] == cntProtocolMySQL[1])
            //{
            mtdValidarConexaoProtocoloMySQL(Conexao);
            //}
            //if (strSharedMemoryNameMySQL == null || strSharedMemoryNameMySQL[1] == cntSharedMemoryNameMySQL[1])
            //{
            mtdValidarConexaoNomeMemoriaCompartilhadoMySQL(Conexao);
            //}

            if (strDriverMySQL != null)
            {
                saida += string.Format("{0}={1}; ", strDriverMySQL[0], strDriverMySQL[1]);
            }
            if (strProviderMySQL != null)
            {
                saida += string.Format("{0}={1}; ", strProviderMySQL[0], strProviderMySQL[1]);
            }
            if (strServerMySQL != null)
            {
                saida += string.Format("{0}={1}; ", strServerMySQL[0], strServerMySQL[1]);
            }
            if (strPortMySQL != null)
            {
                saida += string.Format("{0}={1}; ", strPortMySQL[0], strPortMySQL[1]);
            }
            if (strDataBaseMySQL != null && blnPermitirBancoDadosMySQL)
            {
                saida += string.Format("{0}={1}; ", strDataBaseMySQL[0], strDataBaseMySQL[1]);
            }
            if (strCharsetMySQL != null)
            {
                saida += string.Format("{0}={1}; ", strCharsetMySQL[0], strCharsetMySQL[1]);
            }
            if (strUserIdMySQL != null)
            {
                saida += string.Format("{0}={1}; ", strUserIdMySQL[0], strUserIdMySQL[1]);
            }
            if (strPasswordMySQL != null)
            {
                saida += string.Format("{0}={1}; ", strPasswordMySQL[0], strPasswordMySQL[1]);
            }
            if (strsslcaMySQL != null)
            {
                saida += string.Format("{0}={1};", strsslcaMySQL[0], strsslcaMySQL[1]);
            }
            if (strsslcertMySQL != null)
            {
                saida += string.Format("{0}={1};", strsslcertMySQL[0], strsslcertMySQL[1]);
            }
            if (strsslkeyMySQL != null)
            {
                saida += string.Format("{0}={1};", strsslkeyMySQL[0], strsslkeyMySQL[1]);
            }
            if (strsslverifyMySQL != null)
            {
                saida += string.Format("{0}={1};", strsslverifyMySQL[0], strsslverifyMySQL[1]);
            }
            if (strSocketMySQL != null)
            {
                saida += string.Format("{0}={1};", strSocketMySQL[0], strSocketMySQL[1]);
            }
            if (strOptionMySQL != null)
            {
                saida += string.Format("{0}={1};", strOptionMySQL[0], strOptionMySQL[1]);
            }
            if (strEncryptMySQL != null)
            {
                saida += string.Format("{0}={1};", strEncryptMySQL[0], strEncryptMySQL[1]);
            }
            if (strConnectionTimeoutMySQL != null)
            {
                saida += string.Format("{0}={1};", strConnectionTimeoutMySQL[0], strConnectionTimeoutMySQL[1]);
            }
            if (strIgnorePrepareMySQL != null)
            {
                saida += string.Format("{0}={1};", strIgnorePrepareMySQL[0], strIgnorePrepareMySQL[1]);
            }
            if (strProtocolMySQL != null)
            {
                saida += string.Format("{0}={1};", strProtocolMySQL[0], strProtocolMySQL[1]);
            }
            if (strSharedMemoryNameMySQL != null)
            {
                saida += string.Format("{0}={1};", strSharedMemoryNameMySQL[0], strSharedMemoryNameMySQL[1]);
            }
            return saida;
        }

        public string mtdDefinirStringConexaoMySQL()
        {
            return mtdDefinirStringConexaoMySQL(prpConexao, true);
        }

        public string mtdDefinirStringConexaoMySQL(bool PermitirBancoDados)
        {
            return mtdDefinirStringConexaoMySQL(prpConexao, PermitirBancoDados);
        }

        public string mtdDefinirStringConexaoMySQL(string Conexao)
        {
            return mtdDefinirStringConexaoMySQL(Conexao, true);
        }

        public string mtdDefinirStringConexaoMySQL(string Conexao, bool PermitirBancoDados)
        {
            blnPermitirBancoDadosMySQL = PermitirBancoDados;
            mtdValidarConexaoMySQL(Conexao);
            return mtdDefinirStringConexaoMySQL(prpTipoConexao,
                prpServerMySQL,
                prpPortMySQL,
                prpDataBaseMySQL,
                prpCharsetMySQL,
                prpUserIdMySQL,
                prpPasswordMySQL,
                prpsslcaMySQL,
                prpsslcertMySQL,
                prpsslkeyMySQL,
                prpsslverifyMySQL,
                prpSocketMySQL,
                prpOptionMySQL,
                prpEncryptMySQL,
                prpConnectionTimeoutMySQL,
                prpIgnorePrepareMySQL,
                prpProtocolMySQL,
                prpSharedMemoryNameMySQL);
        }

        public string mtdDefinirStringConexaoMySQL(TipoConexao TipoConexao, string Server, string DataBase, string UserId, string Password)
        {
            return mtdDefinirStringConexaoMySQL(TipoConexao, Server, cntPortMySQL[1], DataBase, cntCharsetMySQL[1], UserId, Password, cntsslcaMySQL[1], cntsslcertMySQL[1], cntsslkeyMySQL[1], cntsslverifyMySQL[1], cntSocketMySQL[1], cntOptionMySQL[1], cntEncryptMySQL[1], cntConnectionTimeoutMySQL[1], cntIgnorePrepareMySQL[1], cntProtocolMySQL[1], cntSharedMemoryNameMySQL[1]);
        }

        public string mtdDefinirStringConexaoMySQL(TipoConexao TipoConexao, string Server, string Port, string DataBase, string UserId, string Password)
        {
            return mtdDefinirStringConexaoMySQL(TipoConexao, Server, Port, DataBase, cntCharsetMySQL[1], UserId, Password, cntsslcaMySQL[1], cntsslcertMySQL[1], cntsslkeyMySQL[1], cntsslverifyMySQL[1], cntSocketMySQL[1], cntOptionMySQL[1], cntEncryptMySQL[1], cntConnectionTimeoutMySQL[1], cntIgnorePrepareMySQL[1], cntProtocolMySQL[1], cntSharedMemoryNameMySQL[1]);
        }

        public string mtdDefinirStringConexaoMySQL(TipoConexao TipoConexao, string Server, string Port, string DataBase, string Charset, string UserId, string Password, string sslca,
            string sslcert, string sslkey, string sslverify, string Socket, string Option, string Encrypt, string ConnectionTimeout, string IgnorePrepare, string Protocol, string SharedMemoryName)
        {
            return mtdDefinirStringConexaoMySQL(TipoConexao,
                Server != string.Empty ? Server : cntServerMySQL[1],
                System.Convert.ToInt32(Port != string.Empty ? Port : cntPortMySQL[1]),
                DataBase != string.Empty ? DataBase : cntDataBaseMySQL[1],
                Charset != string.Empty ? Charset : cntCharsetMySQL[1],
                UserId != string.Empty ? UserId : cntUserIdMySQL[1],
                Password != string.Empty ? Password : cntPasswordMySQL[1],
                sslca != string.Empty ? sslca : cntsslcaMySQL[1],
                sslcert != string.Empty ? sslcert : cntsslcertMySQL[1],
                sslkey != string.Empty ? sslkey : cntsslkeyMySQL[1],
                System.Convert.ToInt32(sslverify != string.Empty ? sslverify : cntsslverifyMySQL[1]),
                Socket != string.Empty ? Socket : cntSocketMySQL[1],
                System.Convert.ToInt32(Option != string.Empty ? Option : cntOptionMySQL[1]),
                System.Convert.ToBoolean(Encrypt != string.Empty ? Encrypt : cntEncryptMySQL[1]),
                System.Convert.ToInt32(ConnectionTimeout != string.Empty ? ConnectionTimeout : cntConnectionTimeoutMySQL[1]),
                System.Convert.ToBoolean(IgnorePrepare != string.Empty ? IgnorePrepare : cntIgnorePrepareMySQL[1]),
                Protocol != string.Empty ? Protocol : cntProtocolMySQL[1],
                SharedMemoryName != string.Empty ? SharedMemoryName : cntSharedMemoryNameMySQL[1]);
        }

        public string mtdDefinirStringConexaoMySQL(TipoConexao TipoConexao, string Server, int Port, string DataBase, string Charset, string UserId, string Password, string sslca,
            string sslcert, string sslkey, int sslverify, string Socket, int Option, bool Encrypt, int ConnectionTimeout, bool IgnorePrepare, string Protocol, string SharedMemoryName)
        {
            enuTipoConexao = TipoConexao;

            string saida = string.Empty;
            switch (TipoConexao)
            {
                case TipoConexao.ConexaoMySQLOdbc:
                    if (DataBase != string.Empty)
                    {
                        DataBase = string.Format("DataBase={0}; ", DataBase);
                    }
                    saida = string.Format(cntStringConexaoMySQLOdbc.Replace(string.Format("Driver={0}; ", cntDriverMySQL), string.Empty), Server, Port, DataBase, Charset, UserId, Password, sslca, sslcert, sslkey, sslverify, Option);
                    saida = string.Format("{0}={1}; ", strDriverMySQL[0], strDriverMySQL[1]) + saida;
                    saida = mtdEliminarAtribudoIndisponivelStringConexao(saida);
                    prpTipoSistemaGerenciadorBancoDadosRelacional = TipoSistemaGerenciadorBancoDadosRelacional.Odbc;
                    break;
                case TipoConexao.ConexaoMySQLOleDb:
                    if (DataBase != string.Empty)
                    {
                        DataBase = string.Format("DataBase={0};", DataBase);
                    }
                    saida = string.Format(cntStringConexaoMySQLOleDb.Replace(string.Format("Provider={0}; ", cntProviderMySQL[1]), string.Empty).Replace("Data Source={1}; ", "{1}"), DataBase, UserId, Password);
                    saida = string.Format("{0}={1}; ", strProviderMySQL[0], strProviderMySQL[1]) + saida;
                    saida = mtdEliminarAtribudoIndisponivelStringConexao(saida);
                    prpTipoSistemaGerenciadorBancoDadosRelacional = TipoSistemaGerenciadorBancoDadosRelacional.OleDb;
                    break;
                case TipoConexao.ConexaoMySQLNativa:
                    if (DataBase != string.Empty)
                    {
                        DataBase = string.Format("DataBase={0}; ", DataBase);
                    }
                    saida = string.Format(cntStringConexaoMySQLNativa.Replace("Database={2}; ", "{2}"),
                             Server, Port, DataBase, UserId, Password, Encrypt, ConnectionTimeout, IgnorePrepare, Protocol, Charset, SharedMemoryName);
                    saida = mtdEliminarAtribudoIndisponivelStringConexao(saida);
                    prpTipoSistemaGerenciadorBancoDadosRelacional = TipoSistemaGerenciadorBancoDadosRelacional.MySQL;
                    break;
                case TipoConexao.Indisponivel:
                    saida = TipoConexao.Indisponivel.ToString();
                    prpTipoSistemaGerenciadorBancoDadosRelacional = TipoSistemaGerenciadorBancoDadosRelacional.Indisponivel;
                    break;
            }
            prpConexao = mtdValidarConexaoMySQL(saida);
            return prpConexao.Trim();
        }
    }

    public partial class clsInfraestruturaBancoDados
    {
        // Variaveis do MySQL
        protected MySql.Data.MySqlClient.MySqlConnection objConexaoMySQL = new MySql.Data.MySqlClient.MySqlConnection();
        protected MySql.Data.MySqlClient.MySqlCommand objComandoMySQL = new MySql.Data.MySqlClient.MySqlCommand();
        protected MySql.Data.MySqlClient.MySqlDataAdapter objAdaptadorDadosMySQL = new MySql.Data.MySqlClient.MySqlDataAdapter();
        protected MySql.Data.MySqlClient.MySqlDataReader objLeitorDadosMySQL;

        // Propriedades do MySQL

        public MySql.Data.MySqlClient.MySqlConnection prpConexaoMySQL
        {
            get
            {
                return objConexaoMySQL;
            }
            set
            {
                objConexaoMySQL = value;
            }
        }

        public MySql.Data.MySqlClient.MySqlCommand prpComandoMySQL
        {
            get
            {
                return objComandoMySQL;
            }
            set
            {
                objComandoMySQL = value;
            }
        }

        public MySql.Data.MySqlClient.MySqlDataAdapter prpAdaptadorDadosMySQL
        {
            get
            {
                return objAdaptadorDadosMySQL;
            }
            set
            {
                objAdaptadorDadosMySQL = value;
            }
        }

        public MySql.Data.MySqlClient.MySqlDataReader prpLeitorDadosMySQL
        {
            get
            {
                return objLeitorDadosMySQL;
            }
            set
            {
                objLeitorDadosMySQL = value;
            }
        }

        public void mtdExecutarParametroComandoMySQL
            (
            string NomeParametro,
            object Valor
            )
        {
            MySql.Data.MySqlClient.MySqlParameter objParametroMySQL =
                 new MySql.Data.MySqlClient.MySqlParameter
                     (
                     NomeParametro,
                     Valor
                     );
            prpComandoMySQL.Parameters.Add(objParametroMySQL);
        }

        public void mtdExecutarParametroComandoMySQL
           (
           string NomeParametro,
           MySql.Data.MySqlClient.MySqlDbType TipoSqlDb,
           object Valor
           )
        {
            MySql.Data.MySqlClient.MySqlParameter objParametroMySQL =
              new MySql.Data.MySqlClient.MySqlParameter
                  (
                  NomeParametro,
                  TipoSqlDb
                  );
            objParametroMySQL.Value = Valor;
            prpComandoMySQL.Parameters.Add(objParametroMySQL);
        }

        public void mtdExecutarParametroComandoMySQL
           (
           string NomeParametro,
           MySql.Data.MySqlClient.MySqlDbType TipoSqlDb,
           object Valor,
           int Tamanho
           )
        {
            MySql.Data.MySqlClient.MySqlParameter objParametroMySQL =
              new MySql.Data.MySqlClient.MySqlParameter
                  (
                  NomeParametro,
                  TipoSqlDb,
                  Tamanho
                  );
            objParametroMySQL.Value = Valor;
            prpComandoMySQL.Parameters.Add(objParametroMySQL);
        }

        public void mtdExecutarParametroComandoMySQL
            (
            string NomeParametro,
            MySql.Data.MySqlClient.MySqlDbType TipoSqlDb,
            object Valor,
            int Tamanho,
            string ColunaOrigem
            )
        {
            MySql.Data.MySqlClient.MySqlParameter objParametroMySQL =
                new MySql.Data.MySqlClient.MySqlParameter
                    (
                    NomeParametro,
                    TipoSqlDb,
                    Tamanho,
                    ColunaOrigem
                    );
            objParametroMySQL.Value = Valor;
            prpComandoMySQL.Parameters.Add(objParametroMySQL);
        }

        public void mtdExecutarParametroComandoMySQL
            (
            System.Data.DataRowVersion OrigemVersao,
            string NomeParametro,
            MySql.Data.MySqlClient.MySqlDbType TipoSqlDb,
            System.Data.ParameterDirection DirecaoParametro,
            string OrigemColuna,
            object Valor,
            int Tamanho
            )
        {
            MySql.Data.MySqlClient.MySqlParameter objParametroMySQL =
                new MySql.Data.MySqlClient.MySqlParameter
                    (
                    NomeParametro,
                    TipoSqlDb,
                    Tamanho,
                    OrigemColuna
                    );
            objParametroMySQL.SourceVersion = OrigemVersao;
            objParametroMySQL.Direction = DirecaoParametro;
            objParametroMySQL.Value = Valor;
            prpComandoMySQL.Parameters.Add(objParametroMySQL);
        }
    }

    public partial class clsImplementacaoBancoDados
    {
        // MySQL

        private string strParametroMySQL = @"@";

        public bool mtdCriarBancoDadosMySQL()
        {
            return mtdCriarBancoDadosMySQL(prpDataBaseMySQL);
        }

        public bool mtdCriarBancoDadosMySQL(string BancoDados)
        {
            bool saida = true;

            prpDataBaseMySQL = BancoDados;
            mtdDefinirStringConexaoMySQL();
            mtdFecharConexao();
            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            saida &= mtdExecutarComando(string.Format(@"CREATE DATABASE IF NOT EXISTS `{0}`;", BancoDados));
            mtdDefinirStringConexaoMySQL(prpConexao, true);
            mtdFecharConexao();

            return saida;
        }

        public bool mtdDeletarBancoDadosMySQL()
        {
            return mtdDeletarBancoDadosMySQL(prpDataBaseMySQL);
        }

        public bool mtdDeletarBancoDadosMySQL(string BancoDados)
        {
            bool saida = true;

            prpDataBaseMySQL = BancoDados;
            mtdDefinirStringConexaoMySQL();
            if (mtdAbrirConexao(mtdDefinirStringConexaoMySQL(prpConexao, false), prpTipoSistemaGerenciadorBancoDadosRelacional))
            {
                mtdFecharConexao();
            }
            saida &= mtdAbrirConexao();
            saida &= mtdExecutarComando(string.Format(@"DROP DATABASE IF EXISTS `{0}`;", BancoDados));
            mtdFecharConexao();

            return saida;
        }




        private bool mtdAtualizarDadosParametroComandoMySQLValor(string NomeTabela, object[,] Campos_Dados, string CampoBase, string Operacao, object DadoBase)
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
                        prpComandoMySQL.Parameters.Clear();

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

                                    mtdExecutarParametroComandoMySQL
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
                                        strParametroMySQL
                                        );
                                    break;
                            }
                        }
                        if (linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais)
                        {
                            mtdExecutarParametroComandoMySQL
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
                                strParametroMySQL
                                )
                                );
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        private bool mtdAtualizarDadosParametroComandoMySQLValorTipo(string NomeTabela, object[,] Campos_Dados, string CampoBase, string Operacao, object DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 2;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
            string[] vetNomeColunas = null;
            MySql.Data.MySqlClient.MySqlDbType[] vetTipoColunas = null;
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
                                vetTipoColunas = new MySql.Data.MySqlClient.MySqlDbType[Campos_Dados.GetUpperBound(1) + 1];
                                break;
                            default:
                                vetRegistrosColunas = new object[Campos_Dados.GetUpperBound(1) + 1];
                                break;
                        }

                        strTexto = string.Empty;
                        prpComandoMySQL.Parameters.Clear();

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
                                        vetTipoColunas[coluna] = (MySql.Data.MySqlClient.MySqlDbType)Campos_Dados[linha, coluna];
                                    }
                                    else
                                    {
                                        vetTipoColunas[coluna] = MySql.Data.MySqlClient.MySqlDbType.Binary;
                                    }
                                    break;
                                default:
                                    vetRegistrosColunas[coluna] = (object)Campos_Dados[linha, coluna];

                                    if (Campos_Dados[1, coluna] != null)
                                    {
                                        mtdExecutarParametroComandoMySQL
                                            (
                                            vetNomeColunas[coluna],
                                            vetTipoColunas[coluna],
                                            vetRegistrosColunas[coluna]
                                            );
                                    }
                                    else
                                    {
                                        mtdExecutarParametroComandoMySQL
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
                                        strParametroMySQL
                                        );
                                    break;
                            }
                        }
                        if (linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais)
                        {
                            mtdExecutarParametroComandoMySQL
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
                                strParametroMySQL
                                )
                                );
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        private bool mtdAtualizarDadosParametroComandoMySQLValorTipoTamanho(string NomeTabela, object[,] Campos_Dados, string CampoBase, string Operacao, object DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 3;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
            string[] vetNomeColunas = null;
            MySql.Data.MySqlClient.MySqlDbType[] vetTipoColunas = null;
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
                                vetTipoColunas = new MySql.Data.MySqlClient.MySqlDbType[Campos_Dados.GetUpperBound(1) + 1];
                                break;
                            case (2):
                                vetTamanhoColunas = new int[Campos_Dados.GetUpperBound(1) + 1];
                                break;
                            default:
                                vetRegistrosColunas = new object[Campos_Dados.GetUpperBound(1) + 1];
                                break;
                        }

                        strTexto = string.Empty;
                        prpComandoMySQL.Parameters.Clear();

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
                                        vetTipoColunas[coluna] = (MySql.Data.MySqlClient.MySqlDbType)Campos_Dados[linha, coluna];
                                    }
                                    else
                                    {
                                        vetTipoColunas[coluna] = MySql.Data.MySqlClient.MySqlDbType.Binary;
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
                                            mtdExecutarParametroComandoMySQL
                                                (
                                                vetNomeColunas[coluna],
                                                vetTipoColunas[coluna],
                                                vetRegistrosColunas[coluna],
                                                vetTamanhoColunas[coluna]
                                                );
                                        }
                                        else
                                        {
                                            mtdExecutarParametroComandoMySQL
                                                (
                                                vetNomeColunas[coluna],
                                                vetTipoColunas[coluna],
                                                vetRegistrosColunas[coluna]
                                                );
                                        }
                                    }
                                    else
                                    {
                                        mtdExecutarParametroComandoMySQL
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
                                        strParametroMySQL
                                        );
                                    break;
                            }
                        }
                        if (linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais)
                        {
                            mtdExecutarParametroComandoMySQL
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
                                strParametroMySQL
                                )
                                );
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        public bool mtdAtualizarDadosParametroComandoMySQL(string NomeTabela, object[,] Campos_Dados, string CampoBase, string Operacao, object DadoBase, enmModoParametroComando ModoParametroComando)
        {
            bool saida = false;
            switch (ModoParametroComando)
            {
                case enmModoParametroComando.Valor:
                    saida = mtdAtualizarDadosParametroComandoMySQLValor(NomeTabela, Campos_Dados, CampoBase, Operacao, DadoBase);
                    break;
                case enmModoParametroComando.ValorTipo:
                    saida = mtdAtualizarDadosParametroComandoMySQLValorTipo(NomeTabela, Campos_Dados, CampoBase, Operacao, DadoBase);
                    break;
                case enmModoParametroComando.ValorTipoTamanho:
                    saida = mtdAtualizarDadosParametroComandoMySQLValorTipoTamanho(NomeTabela, Campos_Dados, CampoBase, Operacao, DadoBase);
                    break;
            }
            return saida;
        }

        private bool mtdAtualizarDadosParametroComandoMySQLValor(string NomeTabela, object[][] Campos_Dados, string CampoBase, string Operacao, object DadoBase)
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
                            prpComandoMySQL.Parameters.Clear();

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

                                        mtdExecutarParametroComandoMySQL
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
                                            strParametroMySQL
                                            );
                                        break;
                                }
                            }
                            if (linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais)
                            {
                                mtdExecutarParametroComandoMySQL
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
                                    strParametroMySQL
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

        private bool mtdAtualizarDadosParametroComandoMySQLValorTipo(string NomeTabela, object[][] Campos_Dados, string CampoBase, string Operacao, object DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 2;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
            string[] vetNomeColunas = null;
            MySql.Data.MySqlClient.MySqlDbType[] vetTipoColunas = null;
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
                                    vetTipoColunas = new MySql.Data.MySqlClient.MySqlDbType[Campos_Dados[linha].GetUpperBound(0) + 1];
                                    break;
                                default:
                                    vetRegistrosColunas = new object[Campos_Dados[linha].GetUpperBound(0) + 1];
                                    break;
                            }

                            strTexto = string.Empty;
                            prpComandoMySQL.Parameters.Clear();

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
                                            vetTipoColunas[coluna] = (MySql.Data.MySqlClient.MySqlDbType)Campos_Dados[linha][coluna];
                                        }
                                        else
                                        {
                                            vetTipoColunas[coluna] = MySql.Data.MySqlClient.MySqlDbType.Binary;
                                        }
                                        break;
                                    default:
                                        vetRegistrosColunas[coluna] = (object)Campos_Dados[linha][coluna];

                                        if (Campos_Dados[1][coluna] != null)
                                        {
                                            mtdExecutarParametroComandoMySQL
                                                (
                                                vetNomeColunas[coluna],
                                                vetTipoColunas[coluna],
                                                vetRegistrosColunas[coluna]
                                                );
                                        }
                                        else
                                        {
                                            mtdExecutarParametroComandoMySQL
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
                                            strParametroMySQL
                                            );
                                        break;
                                }
                            }
                            if (linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais)
                            {
                                mtdExecutarParametroComandoMySQL
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
                                    strParametroMySQL
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

        private bool mtdAtualizarDadosParametroComandoMySQLValorTipoTamanho(string NomeTabela, object[][] Campos_Dados, string CampoBase, string Operacao, object DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 3;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
            string[] vetNomeColunas = null;
            MySql.Data.MySqlClient.MySqlDbType[] vetTipoColunas = null;
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
                                    vetTipoColunas = new MySql.Data.MySqlClient.MySqlDbType[Campos_Dados[linha].GetUpperBound(0) + 1];
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
                            prpComandoMySQL.Parameters.Clear();

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
                                            vetTipoColunas[coluna] = (MySql.Data.MySqlClient.MySqlDbType)Campos_Dados[linha][coluna];
                                        }
                                        else
                                        {
                                            vetTipoColunas[coluna] = MySql.Data.MySqlClient.MySqlDbType.Binary;
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
                                                mtdExecutarParametroComandoMySQL
                                                    (
                                                    vetNomeColunas[coluna],
                                                    vetTipoColunas[coluna],
                                                    vetRegistrosColunas[coluna],
                                                    vetTamanhoColunas[coluna]
                                                    );
                                            }
                                            else
                                            {
                                                mtdExecutarParametroComandoMySQL
                                                    (
                                                    vetNomeColunas[coluna],
                                                    vetTipoColunas[coluna],
                                                    vetRegistrosColunas[coluna]
                                                    );
                                            }
                                        }
                                        else
                                        {
                                            mtdExecutarParametroComandoMySQL
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
                                            strParametroMySQL
                                            );
                                        break;
                                }
                            }
                            if (linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais)
                            {
                                mtdExecutarParametroComandoMySQL
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
                                    strParametroMySQL
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

        public bool mtdAtualizarDadosParametroComandoMySQL(string NomeTabela, object[][] Campos_Dados, string CampoBase, string Operacao, object DadoBase, enmModoParametroComando ModoParametroComando)
        {
            bool saida = false;
            switch (ModoParametroComando)
            {
                case enmModoParametroComando.Valor:
                    saida = mtdAtualizarDadosParametroComandoMySQLValor(NomeTabela, Campos_Dados, CampoBase, Operacao, DadoBase);
                    break;
                case enmModoParametroComando.ValorTipo:
                    saida = mtdAtualizarDadosParametroComandoMySQLValorTipo(NomeTabela, Campos_Dados, CampoBase, Operacao, DadoBase);
                    break;
                case enmModoParametroComando.ValorTipoTamanho:
                    saida = mtdAtualizarDadosParametroComandoMySQLValorTipoTamanho(NomeTabela, Campos_Dados, CampoBase, Operacao, DadoBase);
                    break;
            }
            return saida;
        }



        private bool mtdAtualizarDadosParametroComandoMySQLValor(string NomeTabela, List<List<object>> Campos_Dados, string CampoBase, string Operacao, object DadoBase)
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
                            prpComandoMySQL.Parameters.Clear();

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

                                        mtdExecutarParametroComandoMySQL
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
                                            strParametroMySQL
                                            );
                                        break;
                                }
                            }
                            if (linha >= 0 + intLinhasAdicionais)
                            {
                                mtdExecutarParametroComandoMySQL
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
                                    strParametroMySQL
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

        private bool mtdAtualizarDadosParametroComandoMySQLValorTipo(string NomeTabela, List<List<object>> Campos_Dados, string CampoBase, string Operacao, object DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 2;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
            List<string> lstNomeColunas = null;
            List<MySql.Data.MySqlClient.MySqlDbType> lstTipoColunas = null;
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
                                    lstTipoColunas = new List<MySql.Data.MySqlClient.MySqlDbType> { };
                                    break;
                                default:
                                    lstRegistrosColunas = new List<object> { };
                                    break;
                            }

                            strTexto = string.Empty;
                            prpComandoMySQL.Parameters.Clear();

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
                                            //lstTipoColunas[coluna] = (MySql.Data.MySqlClient.MySqlDbType)Campos_Dados[linha][coluna];
                                            lstTipoColunas.Add((MySql.Data.MySqlClient.MySqlDbType)Campos_Dados[linha][coluna]);
                                        }
                                        else
                                        {
                                            //lstTipoColunas[coluna] = MySql.Data.MySqlClient.MySqlDbType.Variant;
                                            lstTipoColunas.Add(MySql.Data.MySqlClient.MySqlDbType.Binary);
                                        }
                                        break;
                                    default:
                                        //lstRegistrosColunas[coluna] = (object)Campos_Dados[linha][coluna];
                                        lstRegistrosColunas.Add((object)Campos_Dados[linha][coluna]);

                                        if (Campos_Dados[1][coluna] != null)
                                        {
                                            mtdExecutarParametroComandoMySQL
                                                (
                                                lstNomeColunas[coluna],
                                                lstTipoColunas[coluna],
                                                lstRegistrosColunas[coluna]
                                                );
                                        }
                                        else
                                        {
                                            mtdExecutarParametroComandoMySQL
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
                                            strParametroMySQL
                                            );
                                        break;
                                }
                            }
                            if (linha >= 0 + intLinhasAdicionais)
                            {
                                mtdExecutarParametroComandoMySQL
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
                                    strParametroMySQL
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

        private bool mtdAtualizarDadosParametroComandoMySQLValorTipoTamanho(string NomeTabela, List<List<object>> Campos_Dados, string CampoBase, string Operacao, object DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 3;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
            List<string> lstNomeColunas = null;
            List<MySql.Data.MySqlClient.MySqlDbType> lstTipoColunas = null;
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
                                    lstTipoColunas = new List<MySql.Data.MySqlClient.MySqlDbType> { };
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
                            prpComandoMySQL.Parameters.Clear();

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
                                            //lstTipoColunas[coluna] = (MySql.Data.MySqlClient.MySqlDbType)Campos_Dados[linha][coluna];
                                            lstTipoColunas.Add((MySql.Data.MySqlClient.MySqlDbType)Campos_Dados[linha][coluna]);
                                        }
                                        else
                                        {
                                            //lstTipoColunas[coluna] = MySql.Data.MySqlClient.MySqlDbType.Variant;
                                            lstTipoColunas.Add(MySql.Data.MySqlClient.MySqlDbType.Binary);
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
                                                mtdExecutarParametroComandoMySQL
                                                    (
                                                    lstNomeColunas[coluna],
                                                    lstTipoColunas[coluna],
                                                    lstRegistrosColunas[coluna],
                                                    lstTamanhoColunas[coluna]
                                                    );
                                            }
                                            else
                                            {
                                                mtdExecutarParametroComandoMySQL
                                                    (
                                                    lstNomeColunas[coluna],
                                                    lstTipoColunas[coluna],
                                                    lstRegistrosColunas[coluna]
                                                    );
                                            }
                                        }
                                        else
                                        {
                                            mtdExecutarParametroComandoMySQL
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
                                            strParametroMySQL
                                            );
                                        break;
                                }
                            }
                            if (linha >= Campos_Dados.Count - 1 + intLinhasAdicionais)
                            {
                                mtdExecutarParametroComandoMySQL
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
                                    strParametroMySQL
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

        public bool mtdAtualizarDadosParametroComandoMySQL(string NomeTabela, List<List<object>> Campos_Dados, string CampoBase, string Operacao, object DadoBase, enmModoParametroComando ModoParametroComando)
        {
            bool saida = false;
            switch (ModoParametroComando)
            {
                case enmModoParametroComando.Valor:
                    saida = mtdAtualizarDadosParametroComandoMySQLValor(NomeTabela, Campos_Dados, CampoBase, Operacao, DadoBase);
                    break;
                case enmModoParametroComando.ValorTipo:
                    saida = mtdAtualizarDadosParametroComandoMySQLValorTipo(NomeTabela, Campos_Dados, CampoBase, Operacao, DadoBase);
                    break;
                case enmModoParametroComando.ValorTipoTamanho:
                    saida = mtdAtualizarDadosParametroComandoMySQLValorTipoTamanho(NomeTabela, Campos_Dados, CampoBase, Operacao, DadoBase);
                    break;
            }
            return saida;
        }




        private bool mtdAtualizarDadosParametroComandoMySQLValor(string NomeTabela, object[,] Campos_Dados_CampoBase_Operacao_DadoBase)
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
                        prpComandoMySQL.Parameters.Clear();

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

                                    mtdExecutarParametroComandoMySQL
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
                                        strParametroMySQL
                                        );
                                    break;
                            }
                        }
                        if (linha >= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais)
                        {
                            mtdExecutarParametroComandoMySQL
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
                                strParametroMySQL
                                )
                                );
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        private bool mtdAtualizarDadosParametroComandoMySQLValorTipo(string NomeTabela, object[,] Campos_Dados_CampoBase_Operacao_DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 2;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
            string[] vetNomeColunas = null;
            MySql.Data.MySqlClient.MySqlDbType[] vetTipoColunas = null;
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
                                vetTipoColunas = new MySql.Data.MySqlClient.MySqlDbType[Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) + 1];
                                break;
                            default:
                                strCampoBase = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha, Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 2];
                                strOperacao = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha, Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 1];
                                objDadoBase = Campos_Dados_CampoBase_Operacao_DadoBase[linha, Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1)];
                                vetRegistrosColunas = new object[Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) + 1];
                                break;
                        }

                        strTexto = string.Empty;
                        prpComandoMySQL.Parameters.Clear();

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
                                        vetTipoColunas[coluna] = (MySql.Data.MySqlClient.MySqlDbType)Campos_Dados_CampoBase_Operacao_DadoBase[linha, coluna];
                                    }
                                    else
                                    {
                                        vetTipoColunas[coluna] = MySql.Data.MySqlClient.MySqlDbType.Binary;
                                    }
                                    break;
                                default:
                                    vetRegistrosColunas[coluna] = (object)Campos_Dados_CampoBase_Operacao_DadoBase[linha, coluna];

                                    if (Campos_Dados_CampoBase_Operacao_DadoBase[1, coluna] != null)
                                    {
                                        mtdExecutarParametroComandoMySQL
                                            (
                                            vetNomeColunas[coluna],
                                            vetTipoColunas[coluna],
                                            vetRegistrosColunas[coluna]
                                            );
                                    }
                                    else
                                    {
                                        mtdExecutarParametroComandoMySQL
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
                                        strParametroMySQL
                                        );
                                    break;
                            }
                        }
                        if (linha >= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais)
                        {
                            mtdExecutarParametroComandoMySQL
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
                                strParametroMySQL
                                )
                                );
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        private bool mtdAtualizarDadosParametroComandoMySQLValorTipoTamanho(string NomeTabela, object[,] Campos_Dados_CampoBase_Operacao_DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 3;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
            string[] vetNomeColunas = null;
            MySql.Data.MySqlClient.MySqlDbType[] vetTipoColunas = null;
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
                                vetTipoColunas = new MySql.Data.MySqlClient.MySqlDbType[Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) + 1];
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
                        prpComandoMySQL.Parameters.Clear();

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
                                        vetTipoColunas[coluna] = (MySql.Data.MySqlClient.MySqlDbType)Campos_Dados_CampoBase_Operacao_DadoBase[linha, coluna];
                                    }
                                    else
                                    {
                                        vetTipoColunas[coluna] = MySql.Data.MySqlClient.MySqlDbType.Binary;
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
                                            mtdExecutarParametroComandoMySQL
                                                (
                                                vetNomeColunas[coluna],
                                                vetTipoColunas[coluna],
                                                vetRegistrosColunas[coluna],
                                                vetTamanhoColunas[coluna]
                                                );
                                        }
                                        else
                                        {
                                            mtdExecutarParametroComandoMySQL
                                                (
                                                vetNomeColunas[coluna],
                                                vetTipoColunas[coluna],
                                                vetRegistrosColunas[coluna]
                                                );
                                        }
                                    }
                                    else
                                    {
                                        mtdExecutarParametroComandoMySQL
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
                                        strParametroMySQL
                                        );
                                    break;
                            }
                        }
                        if (linha >= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais)
                        {
                            mtdExecutarParametroComandoMySQL
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
                                strParametroMySQL
                                )
                                );
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        public bool mtdAtualizarDadosParametroComandoMySQL(string NomeTabela, object[,] Campos_Dados_CampoBase_Operacao_DadoBase, enmModoParametroComando ModoParametroComando)
        {
            bool saida = false;
            switch (ModoParametroComando)
            {
                case enmModoParametroComando.Valor:
                    saida = mtdAtualizarDadosParametroComandoMySQLValor(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase);
                    break;
                case enmModoParametroComando.ValorTipo:
                    saida = mtdAtualizarDadosParametroComandoMySQLValorTipo(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase);
                    break;
                case enmModoParametroComando.ValorTipoTamanho:
                    saida = mtdAtualizarDadosParametroComandoMySQLValorTipoTamanho(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase);
                    break;
            }
            return saida;
        }

        private bool mtdAtualizarDadosParametroComandoMySQLValor(string NomeTabela, object[][] Campos_Dados_CampoBase_Operacao_DadoBase)
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
                            prpComandoMySQL.Parameters.Clear();

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

                                        mtdExecutarParametroComandoMySQL
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
                                mtdExecutarParametroComandoMySQL
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

        private bool mtdAtualizarDadosParametroComandoMySQLValorTipo(string NomeTabela, object[][] Campos_Dados_CampoBase_Operacao_DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 2;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
            string[] vetNomeColunas = null;
            MySql.Data.MySqlClient.MySqlDbType[] vetTipoColunas = null;
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
                                    vetTipoColunas = new MySql.Data.MySqlClient.MySqlDbType[Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) + 1];
                                    break;
                                default:
                                    strCampoBase = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) - 2];
                                    strOperacao = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) - 1];
                                    objDadoBase = Campos_Dados_CampoBase_Operacao_DadoBase[linha][Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0)];
                                    vetRegistrosColunas = new object[Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) + 1];
                                    break;
                            }

                            strTexto = string.Empty;
                            prpComandoMySQL.Parameters.Clear();

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
                                            vetTipoColunas[coluna] = (MySql.Data.MySqlClient.MySqlDbType)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];
                                        }
                                        else
                                        {
                                            vetTipoColunas[coluna] = MySql.Data.MySqlClient.MySqlDbType.Binary;
                                        }
                                        break;
                                    default:
                                        vetRegistrosColunas[coluna] = (object)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];

                                        if (Campos_Dados_CampoBase_Operacao_DadoBase[1][coluna] != null)
                                        {
                                            mtdExecutarParametroComandoMySQL
                                                (
                                                vetNomeColunas[coluna],
                                                vetTipoColunas[coluna],
                                                vetRegistrosColunas[coluna]
                                                );
                                        }
                                        else
                                        {
                                            mtdExecutarParametroComandoMySQL
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
                                            strParametroMySQL
                                            );
                                        break;
                                }
                            }
                            if (linha >= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais)
                            {
                                mtdExecutarParametroComandoMySQL
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
                                    strParametroMySQL
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

        private bool mtdAtualizarDadosParametroComandoMySQLValorTipoTamanho(string NomeTabela, object[][] Campos_Dados_CampoBase_Operacao_DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 3;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
            string[] vetNomeColunas = null;
            MySql.Data.MySqlClient.MySqlDbType[] vetTipoColunas = null;
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
                                    vetTipoColunas = new MySql.Data.MySqlClient.MySqlDbType[Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) + 1];
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
                            prpComandoMySQL.Parameters.Clear();

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
                                            vetTipoColunas[coluna] = (MySql.Data.MySqlClient.MySqlDbType)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];
                                        }
                                        else
                                        {
                                            vetTipoColunas[coluna] = MySql.Data.MySqlClient.MySqlDbType.Binary;
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
                                                mtdExecutarParametroComandoMySQL
                                                    (
                                                    vetNomeColunas[coluna],
                                                    vetTipoColunas[coluna],
                                                    vetRegistrosColunas[coluna],
                                                    vetTamanhoColunas[coluna]
                                                    );
                                            }
                                            else
                                            {
                                                mtdExecutarParametroComandoMySQL
                                                    (
                                                    vetNomeColunas[coluna],
                                                    vetTipoColunas[coluna],
                                                    vetRegistrosColunas[coluna]
                                                    );
                                            }
                                        }
                                        else
                                        {
                                            mtdExecutarParametroComandoMySQL
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
                                            strParametroMySQL
                                            );
                                        break;
                                }
                            }
                            if (linha >= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais)
                            {
                                mtdExecutarParametroComandoMySQL
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
                                    strParametroMySQL
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

        public bool mtdAtualizarDadosParametroComandoMySQL(string NomeTabela, object[][] Campos_Dados_CampoBase_Operacao_DadoBase, enmModoParametroComando ModoParametroComando)
        {
            bool saida = false;
            switch (ModoParametroComando)
            {
                case enmModoParametroComando.Valor:
                    saida = mtdAtualizarDadosParametroComandoMySQLValor(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase);
                    break;
                case enmModoParametroComando.ValorTipo:
                    saida = mtdAtualizarDadosParametroComandoMySQLValorTipo(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase);
                    break;
                case enmModoParametroComando.ValorTipoTamanho:
                    saida = mtdAtualizarDadosParametroComandoMySQLValorTipoTamanho(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase);
                    break;
            }
            return saida;
        }

        private bool mtdAtualizarDadosParametroComandoMySQLValor(string NomeTabela, List<List<object>> Campos_Dados_CampoBase_Operacao_DadoBase)
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
                            prpComandoMySQL.Parameters.Clear();

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

                                        mtdExecutarParametroComandoMySQL
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
                                            strParametroMySQL
                                            );
                                        break;
                                }
                            }
                            if (linha >= 0 + intLinhasAdicionais)
                            {
                                mtdExecutarParametroComandoMySQL
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
                                    strParametroMySQL
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

        private bool mtdAtualizarDadosParametroComandoMySQLValorTipo(string NomeTabela, List<List<object>> Campos_Dados_CampoBase_Operacao_DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 2;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
            List<string> lstNomeColunas = null;
            List<MySql.Data.MySqlClient.MySqlDbType> lstTipoColunas = null;
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
                                    lstTipoColunas = new List<MySql.Data.MySqlClient.MySqlDbType> { };
                                    break;
                                default:
                                    strCampoBase = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1 - 2];
                                    strOperacao = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1 - 1];
                                    objDadoBase = Campos_Dados_CampoBase_Operacao_DadoBase[linha][Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1];
                                    lstRegistrosColunas = new List<object>(Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1 + 1);
                                    break;
                            }

                            strTexto = string.Empty;
                            prpComandoMySQL.Parameters.Clear();

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
                                            //lstTipoColunas[coluna] = (MySql.Data.MySqlClient.MySqlDbType)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];
                                            lstTipoColunas.Add((MySql.Data.MySqlClient.MySqlDbType)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna]);
                                        }
                                        else
                                        {
                                            //lstTipoColunas[coluna] = MySql.Data.MySqlClient.MySqlDbType.Variant;
                                            lstTipoColunas.Add(MySql.Data.MySqlClient.MySqlDbType.Binary);
                                        }
                                        break;
                                    default:
                                        //lstRegistrosColunas[coluna] = (object)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];
                                        lstRegistrosColunas.Add((object)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna]);

                                        if (Campos_Dados_CampoBase_Operacao_DadoBase[1][coluna] != null)
                                        {
                                            mtdExecutarParametroComandoMySQL
                                                (
                                                lstNomeColunas[coluna],
                                                lstTipoColunas[coluna],
                                                lstRegistrosColunas[coluna]
                                                );
                                        }
                                        else
                                        {
                                            mtdExecutarParametroComandoMySQL
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
                                            strParametroMySQL
                                            );
                                        break;
                                }
                            }
                            if (linha >= 0 + intLinhasAdicionais)
                            {
                                mtdExecutarParametroComandoMySQL
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
                                    strParametroMySQL
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

        private bool mtdAtualizarDadosParametroComandoMySQLValorTipoTamanho(string NomeTabela, List<List<object>> Campos_Dados_CampoBase_Operacao_DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 3;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
            List<string> lstNomeColunas = null;
            List<MySql.Data.MySqlClient.MySqlDbType> lstTipoColunas = null;
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
                                    lstTipoColunas = new List<MySql.Data.MySqlClient.MySqlDbType> { };
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
                            prpComandoMySQL.Parameters.Clear();

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
                                            //lstTipoColunas[coluna] = (MySql.Data.MySqlClient.MySqlDbType)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];
                                            lstTipoColunas.Add((MySql.Data.MySqlClient.MySqlDbType)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna]);
                                        }
                                        else
                                        {
                                            //lstTipoColunas[coluna] = MySql.Data.MySqlClient.MySqlDbType.Binary;
                                            lstTipoColunas.Add(MySql.Data.MySqlClient.MySqlDbType.Binary);
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
                                                mtdExecutarParametroComandoMySQL
                                                    (
                                                    lstNomeColunas[coluna],
                                                    lstTipoColunas[coluna],
                                                    lstRegistrosColunas[coluna],
                                                    lstTamanhoColunas[coluna]
                                                    );
                                            }
                                            else
                                            {
                                                mtdExecutarParametroComandoMySQL
                                                    (
                                                    lstNomeColunas[coluna],
                                                    lstTipoColunas[coluna],
                                                    lstRegistrosColunas[coluna]
                                                    );
                                            }
                                        }
                                        else
                                        {
                                            mtdExecutarParametroComandoMySQL
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
                                            strParametroMySQL
                                            );
                                        break;
                                }
                            }
                            if (linha >= 0 + intLinhasAdicionais)
                            {
                                mtdExecutarParametroComandoMySQL
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
                                    strParametroMySQL
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

        public bool mtdAtualizarDadosParametroComandoMySQL(string NomeTabela, List<List<object>> Campos_Dados_CampoBase_Operacao_DadoBase, enmModoParametroComando ModoParametroComando)
        {
            bool saida = false;
            switch (ModoParametroComando)
            {
                case enmModoParametroComando.Valor:
                    saida = mtdAtualizarDadosParametroComandoMySQLValor(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase);
                    break;
                case enmModoParametroComando.ValorTipo:
                    saida = mtdAtualizarDadosParametroComandoMySQLValorTipo(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase);
                    break;
                case enmModoParametroComando.ValorTipoTamanho:
                    saida = mtdAtualizarDadosParametroComandoMySQLValorTipoTamanho(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase);
                    break;
            }
            return saida;
        }




        private bool mtdInserirDadosParametroComandoMySQLValor(string NomeTabela, object[,] Campos_Dados)
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
                        prpComandoMySQL.Parameters.Clear();

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

                                    mtdExecutarParametroComandoMySQL
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
                                       strParametroMySQL
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

        private bool mtdInserirDadosParametroComandoMySQLValorTipo(string NomeTabela, object[,] Campos_Dados)
        {
            bool saida = true;

            int intLinhasAdicionais = 2;
            string strNomeColunas = string.Empty;
            object objResgistrosColunas = null;
            string[] vetNomeColunas = null;
            MySql.Data.MySqlClient.MySqlDbType[] vetTipoColunas = null;
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
                                vetTipoColunas = new MySql.Data.MySqlClient.MySqlDbType[Campos_Dados.GetUpperBound(1) + 1];
                                break;
                            default:
                                vetRegistrosColunas = new object[Campos_Dados.GetUpperBound(1) + 1];
                                break;
                        }

                        objResgistrosColunas = null;
                        prpComandoMySQL.Parameters.Clear();

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
                                        vetTipoColunas[coluna] = (MySql.Data.MySqlClient.MySqlDbType)Campos_Dados[linha, coluna];
                                    }
                                    else
                                    {
                                        vetTipoColunas[coluna] = MySql.Data.MySqlClient.MySqlDbType.Binary;
                                    }
                                    break;
                                default:
                                    vetRegistrosColunas[coluna] = (object)Campos_Dados[linha, coluna];

                                    if (Campos_Dados[1, coluna] != null)
                                    {
                                        mtdExecutarParametroComandoMySQL
                                            (
                                            vetNomeColunas[coluna],
                                            vetTipoColunas[coluna],
                                            vetRegistrosColunas[coluna]
                                            );
                                    }
                                    else
                                    {
                                        mtdExecutarParametroComandoMySQL
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
                                        strParametroMySQL
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

        private bool mtdInserirDadosParametroComandoMySQLValorTipoTamanho(string NomeTabela, object[,] Campos_Dados)
        {
            bool saida = true;

            int intLinhasAdicionais = 3;
            string strNomeColunas = string.Empty;
            object objResgistrosColunas = null;
            string[] vetNomeColunas = null;
            MySql.Data.MySqlClient.MySqlDbType[] vetTipoColunas = null;
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
                                vetTipoColunas = new MySql.Data.MySqlClient.MySqlDbType[Campos_Dados.GetUpperBound(1) + 1];
                                break;
                            case (2):
                                vetTamanhoColunas = new int[Campos_Dados.GetUpperBound(1) + 1];
                                break;
                            default:
                                vetRegistrosColunas = new object[Campos_Dados.GetUpperBound(1) + 1];
                                break;
                        }

                        objResgistrosColunas = null;
                        prpComandoMySQL.Parameters.Clear();

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
                                        vetTipoColunas[coluna] = (MySql.Data.MySqlClient.MySqlDbType)Campos_Dados[linha, coluna];
                                    }
                                    else
                                    {
                                        vetTipoColunas[coluna] = MySql.Data.MySqlClient.MySqlDbType.Binary;
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
                                            mtdExecutarParametroComandoMySQL
                                                (
                                                vetNomeColunas[coluna],
                                                vetTipoColunas[coluna],
                                                vetRegistrosColunas[coluna],
                                                vetTamanhoColunas[coluna]
                                                );
                                        }
                                        else
                                        {
                                            mtdExecutarParametroComandoMySQL
                                                (
                                                vetNomeColunas[coluna],
                                                vetTipoColunas[coluna],
                                                vetRegistrosColunas[coluna]
                                                );
                                        }
                                    }
                                    else
                                    {
                                        mtdExecutarParametroComandoMySQL
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

        public bool mtdInserirDadosParametroComandoMySQL(string NomeTabela, object[,] Campos_Dados, enmModoParametroComando ModoParametroComando)
        {
            bool saida = false;
            switch (ModoParametroComando)
            {
                case enmModoParametroComando.Valor:
                    saida = mtdInserirDadosParametroComandoMySQLValor(NomeTabela, Campos_Dados);
                    break;
                case enmModoParametroComando.ValorTipo:
                    saida = mtdInserirDadosParametroComandoMySQLValorTipo(NomeTabela, Campos_Dados);
                    break;
                case enmModoParametroComando.ValorTipoTamanho:
                    saida = mtdInserirDadosParametroComandoMySQLValorTipoTamanho(NomeTabela, Campos_Dados);
                    break;
            }
            return saida;
        }

        private bool mtdInserirDadosParametroComandoMySQLValor(string NomeTabela, object[][] Campos_Dados)
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
                            prpComandoMySQL.Parameters.Clear();

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

                                        mtdExecutarParametroComandoMySQL
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
                                            strParametroMySQL
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

        private bool mtdInserirDadosParametroComandoMySQLValorTipo(string NomeTabela, object[][] Campos_Dados)
        {
            bool saida = true;

            int intLinhasAdicionais = 2;
            string strNomeColunas = string.Empty;
            object objResgistrosColunas = null;
            string[] vetNomeColunas = null;
            MySql.Data.MySqlClient.MySqlDbType[] vetTipoColunas = null;
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
                                    vetTipoColunas = new MySql.Data.MySqlClient.MySqlDbType[Campos_Dados[linha].GetUpperBound(0) + 1];
                                    break;
                                default:
                                    vetRegistrosColunas = new object[Campos_Dados[linha].GetUpperBound(0) + 1];
                                    break;
                            }

                            objResgistrosColunas = null;
                            prpComandoMySQL.Parameters.Clear();

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
                                            vetTipoColunas[coluna] = (MySql.Data.MySqlClient.MySqlDbType)Campos_Dados[linha][coluna];
                                        }
                                        else
                                        {
                                            vetTipoColunas[coluna] = MySql.Data.MySqlClient.MySqlDbType.Binary;
                                        }
                                        break;
                                    default:
                                        vetRegistrosColunas[coluna] = (object)Campos_Dados[linha][coluna];

                                        if (Campos_Dados[1][coluna] != null)
                                        {
                                            mtdExecutarParametroComandoMySQL
                                                (
                                                vetNomeColunas[coluna],
                                                vetTipoColunas[coluna],
                                                vetRegistrosColunas[coluna]
                                                );
                                        }
                                        else
                                        {
                                            mtdExecutarParametroComandoMySQL
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
                                            strParametroMySQL
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

        private bool mtdInserirDadosParametroComandoMySQLValorTipoTamanho(string NomeTabela, object[][] Campos_Dados)
        {
            bool saida = true;

            int intLinhasAdicionais = 3;
            string strNomeColunas = string.Empty;
            object objResgistrosColunas = null;
            string[] vetNomeColunas = null;
            MySql.Data.MySqlClient.MySqlDbType[] vetTipoColunas = null;
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
                                    vetTipoColunas = new MySql.Data.MySqlClient.MySqlDbType[Campos_Dados[linha].GetUpperBound(0) + 1];
                                    break;
                                case (2):
                                    vetTamanhoColunas = new int[Campos_Dados[linha].GetUpperBound(0) + 1];
                                    break;
                                default:
                                    vetRegistrosColunas = new object[Campos_Dados[linha].GetUpperBound(0) + 1];
                                    break;
                            }

                            objResgistrosColunas = null;
                            prpComandoMySQL.Parameters.Clear();

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
                                            vetTipoColunas[coluna] = (MySql.Data.MySqlClient.MySqlDbType)Campos_Dados[linha][coluna];
                                        }
                                        else
                                        {
                                            vetTipoColunas[coluna] = MySql.Data.MySqlClient.MySqlDbType.Binary;
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
                                                mtdExecutarParametroComandoMySQL
                                                    (
                                                    vetNomeColunas[coluna],
                                                    vetTipoColunas[coluna],
                                                    vetRegistrosColunas[coluna],
                                                    vetTamanhoColunas[coluna]
                                                    );
                                            }
                                            else
                                            {
                                                mtdExecutarParametroComandoMySQL
                                                    (
                                                    vetNomeColunas[coluna],
                                                    vetTipoColunas[coluna],
                                                    vetRegistrosColunas[coluna]
                                                    );
                                            }
                                        }
                                        else
                                        {
                                            mtdExecutarParametroComandoMySQL
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
                                            strParametroMySQL
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

        public bool mtdInserirDadosParametroComandoMySQL(string NomeTabela, object[][] Campos_Dados, enmModoParametroComando ModoParametroComando)
        {
            bool saida = false;
            switch (ModoParametroComando)
            {
                case enmModoParametroComando.Valor:
                    saida = mtdInserirDadosParametroComandoMySQLValor(NomeTabela, Campos_Dados);
                    break;
                case enmModoParametroComando.ValorTipo:
                    saida = mtdInserirDadosParametroComandoMySQLValorTipo(NomeTabela, Campos_Dados);
                    break;
                case enmModoParametroComando.ValorTipoTamanho:
                    saida = mtdInserirDadosParametroComandoMySQLValorTipoTamanho(NomeTabela, Campos_Dados);
                    break;
            }
            return saida;
        }




        private bool mtdInserirDadosParametroComandoMySQLValor(string NomeTabela, List<List<object>> Campos_Dados)
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
                            prpComandoMySQL.Parameters.Clear();

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

                                        mtdExecutarParametroComandoMySQL
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
                                            strParametroMySQL
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

        private bool mtdInserirDadosParametroComandoMySQLValorTipo(string NomeTabela, List<List<object>> Campos_Dados)
        {
            bool saida = true;

            int intLinhasAdicionais = 2;
            string strNomeColunas = string.Empty;
            object objResgistrosColunas = null;
            List<string> lstNomeColunas = null;
            List<MySql.Data.MySqlClient.MySqlDbType> lstTipoColunas = null;
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
                                    lstTipoColunas = new List<MySql.Data.MySqlClient.MySqlDbType> { };
                                    break;
                                default:
                                    lstRegistrosColunas = new List<object> { };
                                    break;
                            }

                            objResgistrosColunas = null;
                            prpComandoMySQL.Parameters.Clear();

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
                                            //lstTipoColunas[coluna] = (MySql.Data.MySqlClient.MySqlDbType)Campos_Dados[linha][coluna];
                                            lstTipoColunas.Add((MySql.Data.MySqlClient.MySqlDbType)Campos_Dados[linha][coluna]);
                                        }
                                        else
                                        {
                                            //lstTipoColunas[coluna] = MySql.Data.MySqlClient.MySqlDbType.Variant;
                                            lstTipoColunas.Add(MySql.Data.MySqlClient.MySqlDbType.Binary);
                                        }
                                        break;
                                    default:
                                        //lstRegistrosColunas[coluna] = (object)Campos_Dados[linha][coluna];
                                        lstRegistrosColunas.Add((object)Campos_Dados[linha][coluna]);

                                        if (Campos_Dados[1][coluna] != null)
                                        {
                                            mtdExecutarParametroComandoMySQL
                                                (
                                                lstNomeColunas[coluna],
                                                lstTipoColunas[coluna],
                                                lstRegistrosColunas[coluna]
                                                );
                                        }
                                        else
                                        {
                                            mtdExecutarParametroComandoMySQL
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
                                            strParametroMySQL
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

        private bool mtdInserirDadosParametroComandoMySQLValorTipoTamanho(string NomeTabela, List<List<object>> Campos_Dados)
        {
            bool saida = true;

            int intLinhasAdicionais = 3;
            string strNomeColunas = string.Empty;
            object objResgistrosColunas = null;
            List<string> lstNomeColunas = null;
            List<MySql.Data.MySqlClient.MySqlDbType> lstTipoColunas = null;
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
                                    lstTipoColunas = new List<MySql.Data.MySqlClient.MySqlDbType> { };
                                    break;
                                case (2):
                                    lstTamanhoColunas = new List<int> { };
                                    break;
                                default:
                                    lstRegistrosColunas = new List<object> { };
                                    break;
                            }

                            objResgistrosColunas = null;
                            prpComandoMySQL.Parameters.Clear();

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
                                            //lstTipoColunas[coluna] = (MySql.Data.MySqlClient.MySqlDbType)Campos_Dados[linha][coluna];
                                            lstTipoColunas.Add((MySql.Data.MySqlClient.MySqlDbType)Campos_Dados[linha][coluna]);
                                        }
                                        else
                                        {
                                            //lstTipoColunas[coluna] = MySql.Data.MySqlClient.MySqlDbType.Variant;
                                            lstTipoColunas.Add(MySql.Data.MySqlClient.MySqlDbType.Binary);
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
                                                mtdExecutarParametroComandoMySQL
                                                    (
                                                    lstNomeColunas[coluna],
                                                    lstTipoColunas[coluna],
                                                    lstRegistrosColunas[coluna],
                                                    lstTamanhoColunas[coluna]
                                                    );
                                            }
                                            else
                                            {
                                                mtdExecutarParametroComandoMySQL
                                                    (
                                                    lstNomeColunas[coluna],
                                                    lstTipoColunas[coluna],
                                                    lstRegistrosColunas[coluna]
                                                    );
                                            }
                                        }
                                        else
                                        {
                                            mtdExecutarParametroComandoMySQL
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
                                            strParametroMySQL
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

        public bool mtdInserirDadosParametroComandoMySQL(string NomeTabela, List<List<object>> Campos_Dados, enmModoParametroComando ModoParametroComando)
        {
            bool saida = false;
            switch (ModoParametroComando)
            {
                case enmModoParametroComando.Valor:
                    saida = mtdInserirDadosParametroComandoMySQLValor(NomeTabela, Campos_Dados);
                    break;
                case enmModoParametroComando.ValorTipo:
                    saida = mtdInserirDadosParametroComandoMySQLValorTipo(NomeTabela, Campos_Dados);
                    break;
                case enmModoParametroComando.ValorTipoTamanho:
                    saida = mtdInserirDadosParametroComandoMySQLValorTipoTamanho(NomeTabela, Campos_Dados);
                    break;
            }
            return saida;
        }

        public bool mtdDeletarDadosParametroComandoMySQL(string NomeTabela, string CampoSelecionador, string Operacao, object Dado)
        {
            bool saida = true;

            mtdExecutarParametroComandoMySQL
                (
                CampoSelecionador,
                Dado
                );

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            saida &= mtdExecutarComando(string.Format("DELETE FROM {0} WHERE {1} {2} {3}{1};", NomeTabela, CampoSelecionador, Operacao, strParametroMySQL));
            mtdFecharConexao();

            return saida;
        }

        public bool mtdSelecionarDadosParametroComandoMySQL(uint NumeroLinhas, string Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado)
        {
            bool saida = true;

            mtdExecutarParametroComandoMySQL
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
                strParametroMySQL
                )
                );

            return saida;
        }

        public bool mtdSelecionarDadosParametroComandoMySQL(uint NumeroLinhas, string[] Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado)
        {
            bool saida = true;

            saida &= mtdSelecionarDadosParametroComandoMySQL
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

        public bool mtdSelecionarDadosParametroComandoMySQL(uint NumeroLinhas, List<string> Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado)
        {
            bool saida = true;

            saida &= mtdSelecionarDadosParametroComandoMySQL
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

        public bool mtdSelecionarDadosParametroComandoMySQL(uint NumeroLinhas, string Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado, string CampoOrdenador, bool Crescente)
        {
            bool saida = true;

            mtdExecutarParametroComandoMySQL
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
                strParametroMySQL
                )
                );

            return saida;
        }

        public bool mtdSelecionarDadosParametroComandoMySQL(uint NumeroLinhas, string[] Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado, string CampoOrdenador, bool Crescente)
        {
            bool saida = true;

            saida &= mtdSelecionarDadosParametroComandoMySQL
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

        public bool mtdSelecionarDadosParametroComandoMySQL(uint NumeroLinhas, List<string> Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado, string CampoOrdenador, bool Crescente)
        {
            bool saida = true;

            saida &= mtdSelecionarDadosParametroComandoMySQL
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

    public class clsBDMySQL : clsImplementacaoBancoDados, itfImplementacaoBancoDados
    {
        private static object LockBDMySQL = new object();

        public override bool mtdAbrirConexao(string Conexao, TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional)
        {
            lock (LockBDMySQL)
            {
                bool saida = false;
                strExcecao = "mtdAbrirConexao: Nao houve excecao.";
                prpConexao = Conexao;
                //prpTipoSistemaGerenciadorBancoDadosRelacional = base.enuTipoSistemaGerenciadorBancoDadosRelacional;
                try
                {
                    switch (enuTipoSistemaGerenciadorBancoDadosRelacional)
                    {
                        case TipoSistemaGerenciadorBancoDadosRelacional.MySQL:
                            objConexaoMySQL.ConnectionString = prpConexao;
                            objConexaoMySQL.Open();
                            if (objConexaoMySQL.State == System.Data.ConnectionState.Open)
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
            lock (LockBDMySQL)
            {
                bool saida = false;
                strExcecao = "mtdFecharConexao: Nao houve excecao.";
                setNumeroLinhas = 0;
                try
                {
                    switch (enuTipoSistemaGerenciadorBancoDadosRelacional)
                    {
                        case TipoSistemaGerenciadorBancoDadosRelacional.MySQL:
                            objConexaoMySQL.Close();
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
            lock (LockBDMySQL)
            {
                bool saida = false;
                strExcecao = "mtdExecutarComando: Nao houve excecao.";
                try
                {
                    prpComando = Comando;
                    switch (enuTipoSistemaGerenciadorBancoDadosRelacional)
                    {
                        case TipoSistemaGerenciadorBancoDadosRelacional.MySQL:
                            objComandoMySQL.CommandType = System.Data.CommandType.Text;
                            objComandoMySQL.CommandText = prpComando;
                            objComandoMySQL.Connection = objConexaoMySQL;
                            mtdFecharLeitorDados();
                            objComandoMySQL.ExecuteNonQuery();
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
            lock (LockBDMySQL)
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
                                case TipoSistemaGerenciadorBancoDadosRelacional.MySQL:
                                    vetCabecalhos[contador] = objLeitorDadosMySQL.GetName(contador);
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
            lock (LockBDMySQL)
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
                                case TipoSistemaGerenciadorBancoDadosRelacional.MySQL:
                                    lstCabecalhos[contador] = objLeitorDadosMySQL.GetName(contador);
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
            lock (LockBDMySQL)
            {
                bool saida = false;
                strExcecao = "mtdDefinirLeitorDados: Nao houve excecao.";
                prpComandoComportamento = ComandoComportamento;
                try
                {
                    switch (enuTipoSistemaGerenciadorBancoDadosRelacional)
                    {
                        case TipoSistemaGerenciadorBancoDadosRelacional.MySQL:
                            objLeitorDadosMySQL = objComandoMySQL.ExecuteReader(prpComandoComportamento);
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
            lock (LockBDMySQL)
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
                                case TipoSistemaGerenciadorBancoDadosRelacional.MySQL:
                                    vetValores[contador] = objLeitorDadosMySQL[contador];
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
            lock (LockBDMySQL)
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
                                case TipoSistemaGerenciadorBancoDadosRelacional.MySQL:
                                    lstValores[contador] = objLeitorDadosMySQL[contador];
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
            lock (LockBDMySQL)
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
                                case TipoSistemaGerenciadorBancoDadosRelacional.MySQL:
                                    vetTipos[contador] = objLeitorDadosMySQL.GetValue(contador).GetType();
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
            lock (LockBDMySQL)
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
                                case TipoSistemaGerenciadorBancoDadosRelacional.MySQL:
                                    lstTipos[contador] = objLeitorDadosMySQL.GetValue(contador).GetType();
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
            lock (LockBDMySQL)
            {
                bool saida = false;
                strExcecao = "mtdFecharLeitorDados: Nao houve excecao.";
                try
                {
                    switch (enuTipoSistemaGerenciadorBancoDadosRelacional)
                    {
                        case TipoSistemaGerenciadorBancoDadosRelacional.MySQL:
                            if (!objLeitorDadosMySQL.Equals(null))
                            {
                                if (!objLeitorDadosMySQL.IsClosed)
                                {
                                    objLeitorDadosMySQL.Close();
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
            lock (LockBDMySQL)
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
                        case TipoSistemaGerenciadorBancoDadosRelacional.MySQL:
                            objAdaptadorDadosMySQL = new MySql.Data.MySqlClient.MySqlDataAdapter(prpComando, prpConexao);
                            objAdaptadorDadosMySQL.Fill(prpAjustadorDados, Tabela);
                            objAdaptadorDadosMySQL.Fill(prpTabelaDados);
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
            lock (LockBDMySQL)
            {
                strExcecao = "mtdProximoRegistro: Nao houve excecao.";
                bool saida = false;
                try
                {
                    switch (enuTipoSistemaGerenciadorBancoDadosRelacional)
                    {
                        case TipoSistemaGerenciadorBancoDadosRelacional.MySQL:
                            saida = objLeitorDadosMySQL.Read();
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
            lock (LockBDMySQL)
            {
                strExcecao = "mtdNumeroColunas: Nao houve excecao.";
                int intNumeroColunas = 0;
                try
                {
                    if (Otimizacao)
                    {
                        switch (enuTipoSistemaGerenciadorBancoDadosRelacional)
                        {
                            case TipoSistemaGerenciadorBancoDadosRelacional.MySQL:
                                intNumeroColunas = objLeitorDadosMySQL.FieldCount;
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
            lock (LockBDMySQL)
            {
                strExcecao = "mtdNumeroLinhas: Nao houve excecao.";
                int intNumeroLinhas = 0;
                try
                {
                    if (Otimizacao)
                    {
                        switch (enuTipoSistemaGerenciadorBancoDadosRelacional)
                        {
                            case TipoSistemaGerenciadorBancoDadosRelacional.MySQL:
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
            return mtdAtualizarDadosParametroComandoMySQL(NomeTabela, Campos_Dados, CampoBase, Operacao, DadoBase, ModoParametroComando);
        }

        public bool mtdAtualizarDadosParametroComando(string NomeTabela, object[][] Campos_Dados, string CampoBase, string Operacao, object DadoBase, enmModoParametroComando ModoParametroComando)
        {
            return mtdAtualizarDadosParametroComandoMySQL(NomeTabela, Campos_Dados, CampoBase, Operacao, DadoBase, ModoParametroComando);
        }

        public bool mtdAtualizarDadosParametroComando(string NomeTabela, List<List<object>> Campos_Dados, string CampoBase, string Operacao, object DadoBase, enmModoParametroComando ModoParametroComando)
        {
            return mtdAtualizarDadosParametroComandoMySQL(NomeTabela, Campos_Dados, CampoBase, Operacao, DadoBase, ModoParametroComando);
        }

        public bool mtdAtualizarDadosParametroComando(string NomeTabela, object[,] Campos_Dados_CampoBase_Operacao_DadoBase, enmModoParametroComando ModoParametroComando)
        {
            return mtdAtualizarDadosParametroComandoMySQL(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase, ModoParametroComando);
        }

        public bool mtdAtualizarDadosParametroComando(string NomeTabela, object[][] Campos_Dados_CampoBase_Operacao_DadoBase, enmModoParametroComando ModoParametroComando)
        {
            return mtdAtualizarDadosParametroComandoMySQL(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase, ModoParametroComando);
        }

        public bool mtdAtualizarDadosParametroComando(string NomeTabela, List<List<object>> Campos_Dados_CampoBase_Operacao_DadoBase, enmModoParametroComando ModoParametroComando)
        {
            return mtdAtualizarDadosParametroComandoMySQL(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase, ModoParametroComando);
        }

        public bool mtdInserirDadosParametroComando(string NomeTabela, object[,] Campos_Dados, enmModoParametroComando ModoParametroComando)
        {
            return mtdInserirDadosParametroComandoMySQL(NomeTabela, Campos_Dados, ModoParametroComando);
        }

        public bool mtdInserirDadosParametroComando(string NomeTabela, object[][] Campos_Dados, enmModoParametroComando ModoParametroComando)
        {
            return mtdInserirDadosParametroComandoMySQL(NomeTabela, Campos_Dados, ModoParametroComando);
        }

        public bool mtdInserirDadosParametroComando(string NomeTabela, List<List<object>> Campos_Dados, enmModoParametroComando ModoParametroComando)
        {
            return mtdInserirDadosParametroComandoMySQL(NomeTabela, Campos_Dados, ModoParametroComando);
        }




        public bool mtdDeletarDadosParametroComando(string NomeTabela, string CampoSelecionador, string Operacao, object Dado)
        {
            return mtdDeletarDadosParametroComandoMySQL(NomeTabela, CampoSelecionador, Operacao, Dado);
        }

        public bool mtdSelecionarDadosParametroComando(uint NumeroLinhas, string Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado)
        {
            return mtdSelecionarDadosParametroComandoMySQL(NumeroLinhas, Campos, NomeTabela, CampoSelecionador, Operacao, Dado);
        }

        public bool mtdSelecionarDadosParametroComando(uint NumeroLinhas, string[] Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado)
        {
            return mtdSelecionarDadosParametroComandoMySQL(NumeroLinhas, Campos, NomeTabela, CampoSelecionador, Operacao, Dado);
        }

        public bool mtdSelecionarDadosParametroComando(uint NumeroLinhas, List<string> Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado)
        {
            return mtdSelecionarDadosParametroComandoMySQL(NumeroLinhas, Campos, NomeTabela, CampoSelecionador, Operacao, Dado);
        }

        public bool mtdSelecionarDadosParametroComando(uint NumeroLinhas, string Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado, string CampoOrdenador, bool Crescente)
        {
            return mtdSelecionarDadosParametroComandoMySQL(NumeroLinhas, Campos, NomeTabela, CampoSelecionador, Operacao, Dado, CampoOrdenador, Crescente);
        }

        public bool mtdSelecionarDadosParametroComando(uint NumeroLinhas, string[] Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado, string CampoOrdenador, bool Crescente)
        {
            return mtdSelecionarDadosParametroComandoMySQL(NumeroLinhas, Campos, NomeTabela, CampoSelecionador, Operacao, Dado, CampoOrdenador, Crescente);
        }

        public bool mtdSelecionarDadosParametroComando(uint NumeroLinhas, List<string> Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado, string CampoOrdenador, bool Crescente)
        {
            return mtdSelecionarDadosParametroComandoMySQL(NumeroLinhas, Campos, NomeTabela, CampoSelecionador, Operacao, Dado, CampoOrdenador, Crescente);
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