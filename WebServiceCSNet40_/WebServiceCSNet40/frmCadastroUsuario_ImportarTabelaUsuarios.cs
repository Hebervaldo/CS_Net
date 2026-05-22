using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceCSNet40
{
    public partial class frmCadastroUsuario
    {
        private System.Threading.Thread ThImportarTabelaUsuarios;

        private string strNomeProcessoImportarTabelaUsuarios = "Importar Tabela de Usuários";

        public void mtdIniciarThreadImportarTabelaUsuarios()
        {
            mtdIniciarThreadImportarTabelaUsuarios(true);
        }

        public void mtdIniciarThreadImportarTabelaUsuarios(bool Iniciar)
        {
            try
            {
                //intProgresso = 0
                //strNomeProcesso = strNomeProcessoImportarTabelaUsuarios
                blnAbortarThreadImportarTabelaUsuarios = !Iniciar;
                blnForcarAbortarThreadImportarTabelaUsuarios = false;
                blnThreadAtivadaImportarTabelaUsuarios = true;
                blnSucessoImportarTabelaUsuarios = false;
                ThImportarTabelaUsuarios = new System.Threading.Thread(new System.Threading.ThreadStart(mtdRotinaThreadImportarTabelaUsuarios));
                ThImportarTabelaUsuarios.IsBackground = true;
                ThImportarTabelaUsuarios.Priority = System.Threading.ThreadPriority.Normal;
                ThImportarTabelaUsuarios.Start();

            }
            catch (Exception ex)
            {
                string strExcecao = "mtdIniciarThreadImportarTabelaUsuarios: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                WebServiceCSNet40.Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", WebServiceCSNet40.Default.DiretorioArmazenamentoCompleto), strExcecao);
            }
        }

        public void mtdReIniciarThreadImportarTabelaUsuarios()
        {
            //intProgresso = 0
            //strNomeProcesso = strNomeProcessoImportarTabelaUsuarios
            blnAbortarThreadImportarTabelaUsuarios = false;
            blnForcarAbortarThreadImportarTabelaUsuarios = false;

            blnThreadAtivadaImportarTabelaUsuarios = true;
            blnSucessoImportarTabelaUsuarios = false;
        }

        private static bool blnForcarAbortarThreadImportarTabelaUsuarios = false;
        private static bool blnAbortarThreadImportarTabelaUsuarios = false;

        private static int intTempoSaidaAbortarThreadImportarTabelaUsuarios = 1000;
        public void mtdAbortarThreadImportarTabelaUsuarios()
        {
            mtdAbortarThreadImportarTabelaUsuarios(false);
        }

        public void mtdAbortarThreadImportarTabelaUsuarios(bool Forcar)
        {
            //intProgresso = 100
            System.Threading.Thread.Sleep(1);
            //intProgresso = 0
            //strNomeProcesso = strNomeProcessoImportarTabelaUsuarios
            blnAbortarThreadImportarTabelaUsuarios = true;
            blnForcarAbortarThreadImportarTabelaUsuarios = Forcar;

            blnThreadAtivadaImportarTabelaUsuarios = false;
            blnSucessoImportarTabelaUsuarios = false;

            try
            {
                ThImportarTabelaUsuarios.Join(intTempoSaidaAbortarThreadImportarTabelaUsuarios);
                ThImportarTabelaUsuarios.Abort();
                ThImportarTabelaUsuarios = null;
            }
            catch (Exception ex)
            {
                string strExcecao = "mtdAbortarThreadImportarTabelaUsuarios: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                WebServiceCSNet40.Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", WebServiceCSNet40.Default.DiretorioArmazenamentoCompleto), strExcecao);
            }
        }

        public void mtdPararThreadImportarTabelaUsuarios()
        {
            //intProgresso = 100
            System.Threading.Thread.Sleep(1);
            //intProgresso = 0
            //strNomeProcesso = strNomeProcessoImportarTabelaUsuarios
            blnAbortarThreadImportarTabelaUsuarios = true;
            blnForcarAbortarThreadImportarTabelaUsuarios = true;

            blnThreadAtivadaImportarTabelaUsuarios = false;
            blnSucessoImportarTabelaUsuarios = false;
        }


        private static object LockerImportarTabelaUsuarios = new object();

        private void mtdRotinaThreadImportarTabelaUsuarios()
        {
            while (true)
            {
                if (!blnAbortarThreadImportarTabelaUsuarios)
                {
                    //System.Threading.Monitor.Enter(LockerImportarTabelaUsuarios);
                    lock (LockerImportarTabelaUsuarios)
                    {
                        try
                        {
                            mtdImportarTabelaUsuarios();
                            mtdAbortarThreadImportarTabelaUsuarios(true);
                        }
                        finally
                        {
                            //System.Threading.Monitor.Exit(LockerImportarTabelaUsuarios);
                        }
                    }
                }

                System.Threading.Thread.Sleep(1);
            }
        }

        internal bool blnThreadAtivadaImportarTabelaUsuarios = false;

        internal bool blnSucessoImportarTabelaUsuarios = false;

        private long lngCodigoImportarTabelaUsuarios = 0;
        protected internal void mtdImportarTabelaUsuarios()
        {
            //mtdDeletarTabelaUsuarios()
            //mtdDeletarDadosTabelaUsuarios()
            mtdCriarTabelaUsuarios();
            mtdInserirDadosTabelaUsuarios();
        }


        private int intcoluna = 0;

        private string[][] campos;
        public void mtdDeletarTabelaUsuarios()
        {
            string BancoDados = "Principal";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexao = WebServiceCSNet40.Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

            objImplementacaoBancoDados.mtdDeletarTabela(strTabelaCadastroUsuario);
            objImplementacaoBancoDados.Dispose();
        }

        public void mtdDeletarDadosTabelaUsuarios()
        {
            string BancoDados = "Principal";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexao = WebServiceCSNet40.Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

            objImplementacaoBancoDados.mtdDeletarDados(strTabelaCadastroUsuario, strTabelaCadastroUsuario, "LIKE", "'%'");
            objImplementacaoBancoDados.Dispose();
        }

        public void mtdCriarTabelaUsuarios()
        {
            string BancoDados = "Principal";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexao = WebServiceCSNet40.Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

            intcoluna = 4;

            campos = new string[intcoluna + 1][];
            campos[0] = new string[4]
            {
            "Contador",
            "INTEGER",
            string.Empty,
            "CONSTRAINT PrimaryKeyContador PRIMARY KEY"
            };
            campos[1] = new string[4] 
            {
            "Usuario",
            "TEXT",
            "255",
            " NOT NULL CONSTRAINT UniqueInventario UNIQUE"
            };
            campos[2] = new string[4] 
            {
            "Status",
            "TEXT",
            "255",
            string.Empty
            };
            campos[3] = new string[4] 
            {
            "Senha_Criptografada",
            "TEXT",
            "255",
            string.Empty
            };
            campos[4] = new string[4]
            {
            "Chave",
            "TEXT",
            "255",
            string.Empty
            };

            objImplementacaoBancoDados.mtdCriarTabela(strTabelaCadastroUsuario, campos);
            objImplementacaoBancoDados.Dispose();
        }

        private int intContador = 0;
        private string strUsuario = "Administrador";
        private string strStatus = "Administrador";
        private string strSenhaDescriptografada = "12345678";
        private string strSenhaCriptografada = string.Empty;

        private string strChave = "Chave_Padrao";

        public void mtdInserirDadosTabelaUsuarios()
        {
            strSenhaCriptografada = objCriptografia.mtdCriptografar(strSenhaDescriptografada, strChave, Encryption.Symmetric.Provider.Rijndael);

            string BancoDados = "Principal";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexao = WebServiceCSNet40.Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

            string[][] dados = new string[2][];
            objImplementacaoBancoDados.mtdAbrirConexao();
            objImplementacaoBancoDados.mtdExecutarComando(string.Format("SELECT * FROM {0};", strTabelaCadastroUsuario));
            objImplementacaoBancoDados.mtdDefinirLeitorDados();
            dados[0] = objImplementacaoBancoDados.mtdObterCabecalhoColunas();
            dados[1] = new string[] 
            {
            string.Format("{0}", intContador),
            string.Format("'{0}'", strUsuario),
            string.Format("'{0}'", strStatus),
            string.Format("'{0}'", strSenhaCriptografada),
            string.Format("'{0}'", strChave)
            };
            objImplementacaoBancoDados.mtdInserirDados(strTabelaCadastroUsuario, dados);

            objImplementacaoBancoDados.Dispose();
        }
    }
}