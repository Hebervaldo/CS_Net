using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebServiceCSNet40
{
    public partial class login : System.Web.UI.Page
    {
        protected static void _login()
        {
            Default._Default();

            //Default.mtdIniciarCriacaoTabelas();
        }

        protected login()
        {
            _login();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    mtdTestarBancoTabela();

                    //System.Web.Security.FormsAuthentication.SignOut();

                    //Efetua o logout, desconectando o usuário.

                    lblSaudacao.Text = Default.mtdSaudacao();

                    mtdObterIp();

                    mtdObterCanaisAbertos();

                    WebServicoBancoDados.mtdFecharTodosCanais_();

                    txtUsuario.Focus();
                }
            }
            catch
            {
            }
        }

        public static System.Web.Security.FormsAuthenticationTicket objFormsAuthenticationTicket = null;

        public static string NomeUsuario = string.Empty;

        private string strUsuario = string.Empty;
        private string strSenha = string.Empty;

        private int intTempoExpiracacao = 30;

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            strUsuario = txtUsuario.Text;
            strSenha = txtSenha.Text;
            bool blnIsPersistent = false;

            if (mtdValidacaoUsuario(strUsuario, strSenha))
            {
                NomeUsuario = Default.strNomeUsuario != null
                    ?
                    Default.strNomeUsuario != string.Empty
                    ?
                    Default.strNomeUsuario
                    :
                    Default.strStatusUsuario
                    :
                    Default.strStatusUsuario;

                objFormsAuthenticationTicket =
                    new System.Web.Security.FormsAuthenticationTicket
                        (
                        1,
                        NomeUsuario,
                        DateTime.Now,
                        DateTime.Now.AddMinutes(intTempoExpiracacao),
                        false,
                        Default.strStatusUsuario,
                        System.Web.Security.FormsAuthentication.FormsCookiePath
                        );
                Response.Cookies.Add
                    (
                    new HttpCookie
                        (
                        System.Web.Security.FormsAuthentication.FormsCookieName,
                        System.Web.Security.FormsAuthentication.Encrypt(objFormsAuthenticationTicket)
                        )
                    );
                Response.Redirect
                    (
                    System.Web.Security.FormsAuthentication.GetRedirectUrl
                    (
                        NomeUsuario,
                        blnIsPersistent
                        )
                    );

                Response.Redirect("~/Default.aspx");
            }
            else
            {
                lblInformacao.Text = "Verifique se o nome de usuário ou a senha foram digitados corretamente.";
            }
        }

        private clsCriptografia objCriptografia = new clsCriptografia();
        private clsRegistroWindows objRegistroWindows = new clsRegistroWindows();

        public struct sttEstruturaConta
        {
            public string Usuario;
            public string Status;
            public string Senha_Criptografada;
            public string Chave;

            public sttEstruturaConta(string Usuario, string Status, string Senha_Criptografada, string Chave)
            {
                this.Usuario = Usuario;
                this.Status = Status;
                this.Senha_Criptografada = Senha_Criptografada;
                this.Chave = Chave;
            }
        }

        private bool mtdValidacaoUsuario(string strNomeUsuario, string strSenha)
        {
            bool blnOutPut = false;

            string BancoDadosPrincipal = "Principal";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacionalPrincipal = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexaoPrincipal = Default.mtdDefinirStringConexao(BancoDadosPrincipal, ref TipoSistemaGerenciadorBancoDadosRelacionalPrincipal);
            clsImplementacaoBancoDados objBancoDadosPrincipal = new clsImplementacaoBancoDados(strConexaoPrincipal, TipoSistemaGerenciadorBancoDadosRelacionalPrincipal);

            objBancoDadosPrincipal.mtdDefinirStringConexaoAccess();

            if (!strNomeUsuario.Equals(string.Empty))
            {
                if (!strSenha.Equals(string.Empty))
                {
                    bool blnValidar = true;

                    blnValidar &= objBancoDadosPrincipal.mtdSelecionarDadosParametroComandoOleDb
                           (
                           0,
                           "*",
                           frmCadastroUsuario.strTabelaCadastroUsuario,
                           "Usuario",
                           "LIKE",
                           string.Format("{0}", strNomeUsuario)
                           );

                    blnValidar &= objBancoDadosPrincipal.mtdDefinirLeitorDados();
                    blnValidar &= objBancoDadosPrincipal.mtdProximoRegistro();

                    if (blnValidar)
                    {
                        sttEstruturaConta objEstruturaConta = new sttEstruturaConta
                            (
                            objBancoDadosPrincipal.mtdObterValorRegistro(1).ToString(),
                            objBancoDadosPrincipal.mtdObterValorRegistro(2).ToString(),
                            objBancoDadosPrincipal.mtdObterValorRegistro(3).ToString(),
                            objBancoDadosPrincipal.mtdObterValorRegistro(4).ToString()
                            );

                        if
                            (
                            strNomeUsuario == objEstruturaConta.Usuario
                            &
                            strSenha == objCriptografia.mtdDesCriptografar
                            (
                            objEstruturaConta.Senha_Criptografada,
                            objEstruturaConta.Chave,
                            Encryption.Symmetric.Provider.Rijndael
                            )
                            )
                        {
                            string[] vetColuntblEmpregados = null;

                            blnValidar &= objBancoDadosPrincipal.mtdSelecionarDadosParametroComandoOleDb
                             (
                             0,
                             "*",
                             Default.strTabelaEmpregados,
                             Default.vetCamposTabelaEmpregados[Default.intColunaTabelaEmpregadosMatricula],
                             "LIKE",
                             string.Format("{0}", strNomeUsuario)
                             );

                            blnValidar &= objBancoDadosPrincipal.mtdDefinirLeitorDados();
                            blnValidar &= objBancoDadosPrincipal.mtdProximoRegistro();

                            if (blnValidar)
                            {
                                vetColuntblEmpregados = new string[objBancoDadosPrincipal.mtdNumeroColunas() + 1];
                                int intNumeroColuna = objBancoDadosPrincipal.mtdNumeroColunas();
                                vetColuntblEmpregados = new string[intNumeroColuna];
                                try
                                {
                                    for (int i = 0; i <= intNumeroColuna - 1; i++)
                                    {
                                        vetColuntblEmpregados[i] = objBancoDadosPrincipal.mtdObterValorRegistro(i).ToString();
                                    }

                                    Default.strNomeUsuario = vetColuntblEmpregados[0];
                                    Default.strContaUsuario = vetColuntblEmpregados[1];
                                    Default.strStatusUsuario = objEstruturaConta.Status;
                                }
                                catch (Exception ex)
                                {
                                    Default.strNomeUsuario = objEstruturaConta.Usuario;
                                    Default.strContaUsuario = objEstruturaConta.Usuario;
                                    Default.strStatusUsuario = objEstruturaConta.Status;

                                    lblInformacao.Text = "Houve algum erro.";
                                }
                            }
                            else
                            {
                                try
                                {
                                    Default.strNomeUsuario = objEstruturaConta.Usuario;
                                    Default.strContaUsuario = objEstruturaConta.Usuario;
                                    Default.strStatusUsuario = objEstruturaConta.Status;
                                }
                                catch (Exception ex)
                                {
                                    lblInformacao.Text = "Houve algum erro.";
                                }
                            }

                            blnOutPut = true;
                        }
                        else
                        {
                            blnOutPut = false;

                            lblInformacao.Text = "Não foi possível logar no sistema, verifique o estado das teclas Caps Lock e Num Lock.";
                        }
                    }
                    else
                    {
                        blnOutPut = false;

                        lblInformacao.Text = "Não foi possível logar no sistema.";
                    }
                }
                else
                {
                    blnOutPut = false;

                    lblInformacao.Text = "Digite uma senha.";
                }
            }
            else
            {
                blnOutPut = false;

                lblInformacao.Text = "Digite o nome de um usuário.";
            }

            objBancoDadosPrincipal.Dispose();

            return blnOutPut;
        }

        protected void btnTornarSistemaFuncional_Click(object sender, EventArgs e)
        {
            Default.mtdResetarConfiguracoes();

            Response.Redirect("~/login.aspx");
        }

        private static object LockTestarConexaoAbertaBancoDados = new object();

        public static bool mtdTestarConexaoAbertaBancoDados(string BancoDados)
        {
            lock (LockTestarConexaoAbertaBancoDados)
            {
                bool blnRetorno = false;

                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
                string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
                clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

                blnRetorno = objImplementacaoBancoDados.mtdAbrirConexao();

                objImplementacaoBancoDados.Dispose();

                return blnRetorno;
            }
        }

        private static object LockTestarExecucaoComandoBancoDados = new object();

        public static bool mtdTestarExecucaoComandoBancoDados(string BancoDados, string Tabela)
        {
            lock (LockTestarExecucaoComandoBancoDados)
            {
                bool blnRetorno = false;

                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
                string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
                clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

                blnRetorno = objImplementacaoBancoDados.mtdAbrirConexao();
                blnRetorno = blnRetorno && objImplementacaoBancoDados.mtdExecutarComando(string.Format("SELECT * FROM {0};", Tabela));

                objImplementacaoBancoDados.Dispose();

                return blnRetorno;
            }
        }

        public void mtdTestarBancoTabela()
        {
            lblTestarConexaoAbertaBancoDados.Text = mtdTestarConexaoAbertaBancoDados("Principal") ? "Conexão com o banco de dados principal bem sucedida." : "Não foi possível conectar com o banco de dados principal.";
            lblTestarExecucaoComandoBancoDados.Text = mtdTestarExecucaoComandoBancoDados("Principal", Default.strTabelaInventarioBens) ? "Acesso à tabela de inventário de bens bem sucedida." : "Não foi possível acessar à tabela de inventário de bens.";
        }

        int numTick = 0;

        public void mtdObterIp()
        {
            lblIpLocal.Text = string.Format("{0}: {1}", "Ip Local", mtdObterIpLocal());
            //lblIpInternet.Text = string.Format("{0}: {1}", "Ip Local: ", mtdObterIpInternet());
        }

        private static object LockObterIpLocal = new object();

        public static string mtdObterIpLocal()
        {
            lock (LockObterIpLocal)
            {
                string retorno = string.Empty;

                String strHostName = string.Empty;
                /* First get the host name of local machine.*/
                strHostName = System.Net.Dns.GetHostName();
                Console.WriteLine("Local Machine's Host Name: " + strHostName);

                /* Then using host name, get the IP address list..*/
                System.Net.IPHostEntry ipEntry = System.Net.Dns.GetHostByName(strHostName);
                System.Net.IPAddress[] addr = ipEntry.AddressList;
                for (int i = 0; i < addr.Length; i++)
                {
                    if (i != addr.Length - 1)
                    {
                        retorno += string.Format("{0} - {1}; ", i, addr[i].ToString());
                    }
                    else
                    {
                        retorno += string.Format("{0} - {1}.", i, addr[i].ToString());
                    }
                }

                return retorno;
            }
        }

        private static object LockObterIpInternet = new object();

        public static string mtdObterIpInternet()
        {
            lock (LockObterIpInternet)
            {
                String direction = "";
                System.Net.WebRequest request = System.Net.WebRequest.Create("http://checkip.dyndns.org/");
                using (System.Net.WebResponse response = request.GetResponse())
                using (System.IO.StreamReader stream = new System.IO.StreamReader(response.GetResponseStream()))
                {
                    direction = stream.ReadToEnd();
                }

                //Search for the ip in the html
                int first = direction.IndexOf("Address: ") + 9;
                int last = direction.LastIndexOf("</body>");
                direction = direction.Substring(first, last - first);

                return direction;
            }
        }

        private static object LockObterListaCanaisAbertos = new object();

        public static List<int> lstCanalAberto = new List<int> { };

        public static void mtdObterListaCanaisAbertos()
        {
            lock (LockObterListaCanaisAbertos)
            {
                lstCanalAberto.Clear();

                for (int contador = WebServicoBancoDados.blnCanalAberto.GetLowerBound(0); contador <= WebServicoBancoDados.blnCanalAberto.GetUpperBound(0); contador++)
                {
                    if (WebServicoBancoDados.blnCanalAberto[contador])
                    {
                        lstCanalAberto.Add(contador);
                    }
                }
            }
        }

        public void mtdObterCanaisAbertos()
        {
            mtdObterListaCanaisAbertos();

            lblCanalAberto.Text = "Canais Abertos: ";

            for (int contador = 0; contador <= lstCanalAberto.Count - 1; contador++)
            {
                if (contador != lstCanalAberto.Count - 1)
                {
                    lblCanalAberto.Text += string.Format("{0}, ", lstCanalAberto[contador]);
                }
                else
                {
                    lblCanalAberto.Text += string.Format("{0}.", lstCanalAberto[contador]);
                }
            }
        }

        protected void tmr1_Tick(object sender, EventArgs e)
        {
            if (numTick <= 1)
            {
                mtdTestarBancoTabela();

                numTick++;
            }
            else
            {
                numTick = 0;
            }

            mtdObterIp();

            mtdObterCanaisAbertos();
        }

        protected void btnPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Todos/WebServicoBancoDados.asmx");
        }
    }
}