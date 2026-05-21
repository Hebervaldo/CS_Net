using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebServiceCSNet40
{
    public partial class frmCadastroUsuario : System.Web.UI.Page
    {
        public static string strTabelaCadastroUsuario = "tblUsuarios";

        private clsCriptografia objCriptografia = new clsCriptografia();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    lblUsuario.Text = login.NomeUsuario;

                    hlkPerfil.Text = WebServiceCSNet40.Default.strStatusUsuario;

                    lblSaudacao.Text = WebServiceCSNet40.Default.mtdSaudacao();

                    txtUsuarioCadastro.Text = string.Empty;
                    dplStatusUsuarioCadastro.Text = string.Empty;
                    txtChaveCadastro.Text = string.Empty;
                    txtSenhaCadastro.Text = string.Empty;

                    dplStatusUsuarioCadastro.Items.Add("Administrador");
                    dplStatusUsuarioCadastro.Items.Add("Usuario");
                    dplStatusUsuarioCadastro.Text = dplStatusUsuarioCadastro.Items[0].ToString();

                    mtdCarregarGvw1();

                    txtChaveCadastro.Text = "Chave_Padrao";
                }
            }
            catch (System.Exception ex)
            {
                string strExcecao = "Page_Load: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao); 
                WebServiceCSNet40.Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", WebServiceCSNet40.Default.DiretorioArmazenamentoCompleto), strExcecao);
            }
        }

        protected void mnu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            if (mnu1.Items[0].Text == mnu1.SelectedItem.Text)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (mnu1.Items[1].Text == mnu1.SelectedItem.Text)
            {
                Response.Redirect("~/frmImportacaoExportacaoDados.aspx");
            }
            if (mnu1.Items[2].Text == mnu1.SelectedItem.Text)
            {
                Response.Redirect("~/Todos/WebServicoBancoDados.asmx");
            }
        }

        private void mtdCarregarGvw1()
        {
            mtdCarregarGvw1(strTabelaCadastroUsuario);
        }

        private void mtdCarregarGvw1(string Tabela)
        {
            try
            {
                string BancoDados = "Principal";

                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
                string strConexao = WebServiceCSNet40.Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
                clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

                objImplementacaoBancoDados.mtdSelecionarDados("*", Tabela);

                objImplementacaoBancoDados.mtdAdaptadorDados();

                gvw1.DataSource = objImplementacaoBancoDados.prpAjustadorDados;
                gvw1.DataBind();

                objImplementacaoBancoDados.Dispose();
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdCarregarGvw1: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao); 
                WebServiceCSNet40.Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", WebServiceCSNet40.Default.DiretorioArmazenamentoCompleto), strExcecao);
            }
        }

        private static int intGvw1LinhaSelecionada = 0;
        private static int intContadorCadastro = 0;

        private static object[] objDados = null;

        protected void gvw1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                intGvw1LinhaSelecionada = gvw1.SelectedIndex;
                intContadorCadastro = System.Convert.ToInt32(gvw1.SelectedRow.Cells[1].Text);

                objDados = mtdObterDadosTabelas("Contador", string.Format("'{0}'", intContadorCadastro));

                txtUsuarioCadastro.Text = objDados[1].ToString();
                dplStatusUsuarioCadastro.Text = objDados[2].ToString();
                txtSenhaCriptografadaCadastro.Text = objDados[3].ToString();
                txtChaveCadastro.Text = objDados[4].ToString();

                txtSenhaCadastro.Text = objCriptografia.mtdDesCriptografar
                           (
                           objDados[3].ToString(),
                           objDados[4].ToString(),
                           Encryption.Symmetric.Provider.Rijndael
                           );
            }
            catch (System.Exception ex)
            {
                string strExcecao = "gvw1_SelectedIndexChanged: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao); 
                WebServiceCSNet40.Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", WebServiceCSNet40.Default.DiretorioArmazenamentoCompleto), strExcecao);

                intContadorCadastro = 0;

                txtUsuarioCadastro.Text = string.Empty;
                dplStatusUsuarioCadastro.Text = dplStatusUsuarioCadastro.Items[0].ToString();
                txtSenhaCriptografadaCadastro.Text = string.Empty;
                txtChaveCadastro.Text = string.Empty;

                txtSenhaCadastro.Text = string.Empty;

                lblInformacao.Text = "Houve erro ao selecionar o item.";
            }
        }

        private object[] mtdObterDadosTabelas(string Campo, string Dado)
        {
            string BancoDados = "Principal";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexao = WebServiceCSNet40.Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

            objImplementacaoBancoDados.mtdSelecionarDados("*", strTabelaCadastroUsuario, Campo, "LIKE", Dado);

            objImplementacaoBancoDados.mtdDefinirLeitorDados();

            objImplementacaoBancoDados.mtdProximoRegistro();

            return objImplementacaoBancoDados.mtdObterValorRegistro();
        }

        protected void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string BancoDados = "Principal";

                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
                string strConexao = WebServiceCSNet40.Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
                clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

                objImplementacaoBancoDados.mtdSelecionarDados("*", strTabelaCadastroUsuario);

                objImplementacaoBancoDados.mtdDefinirLeitorDados();

                object[][] dados = new object[2][];

                dados[0] = objImplementacaoBancoDados.mtdObterCabecalhoColunas();

                dados[1] = new object[] 
                {
                    intContadorCadastro.ToString(),
                    txtUsuarioCadastro.Text,
                    dplStatusUsuarioCadastro.Text,
                    objCriptografia.mtdCriptografar(txtSenhaCadastro.Text, txtChaveCadastro.Text, Encryption.Symmetric.Provider.Rijndael),
                    txtChaveCadastro.Text
                };

                objImplementacaoBancoDados.mtdAtualizarDadosParametroComandoOleDb
                    (
                    strTabelaCadastroUsuario,
                    dados,
                    "Contador",
                    "LIKE",
                     intContadorCadastro,
                    clsImplementacaoBancoDados.enmModoParametroComando.Valor
                    );

                objImplementacaoBancoDados.Dispose();

                mtdCarregarGvw1();
            }
            catch (System.Exception ex)
            {
                string strExcecao = "btnAtualizar_Click: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao); 
                WebServiceCSNet40.Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", WebServiceCSNet40.Default.DiretorioArmazenamentoCompleto), strExcecao);
            }
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                string BancoDados = "Principal";

                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
                string strConexao = WebServiceCSNet40.Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
                clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

                objImplementacaoBancoDados.mtdSelecionarDados("*", strTabelaCadastroUsuario, "Contador", false);

                objImplementacaoBancoDados.mtdDefinirLeitorDados();

                object[][] dados = new object[2][];

                dados[0] = objImplementacaoBancoDados.mtdObterCabecalhoColunas();

                objImplementacaoBancoDados.mtdProximoRegistro();

                try
                {
                    intContadorCadastro = System.Convert.ToInt32(objImplementacaoBancoDados.mtdObterValorRegistro(0)) + 1;
                }
                catch (Exception ex)
                {
                    intContadorCadastro = 0;

                    string strExcecao = "btnInserir_Click: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao); 
                    WebServiceCSNet40.Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", WebServiceCSNet40.Default.DiretorioArmazenamentoCompleto), strExcecao);
                }

                dados[1] = new object[] 
                {
                    intContadorCadastro.ToString(),
                    txtUsuarioCadastro.Text,
                    dplStatusUsuarioCadastro.Text,
                    objCriptografia.mtdCriptografar(txtSenhaCadastro.Text, txtChaveCadastro.Text, Encryption.Symmetric.Provider.Rijndael),
                    txtChaveCadastro.Text
                };

                objImplementacaoBancoDados.mtdInserirDadosParametroComandoOleDb
                    (
                    strTabelaCadastroUsuario,
                    dados,
                    clsImplementacaoBancoDados.enmModoParametroComando.Valor
                    );

                objImplementacaoBancoDados.Dispose();

                mtdCarregarGvw1();
            }
            catch (System.Exception ex)
            {
                string strExcecao = "btnInserir_Click: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao); 
                WebServiceCSNet40.Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", WebServiceCSNet40.Default.DiretorioArmazenamentoCompleto), strExcecao);
            }
        }

        protected void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                string BancoDados = "Principal";

                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
                string strConexao = WebServiceCSNet40.Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
                clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

                objImplementacaoBancoDados.mtdDeletarDadosParametroComandoOleDb
                    (
                    strTabelaCadastroUsuario,
                    "Contador",
                    "LIKE",
                    intContadorCadastro
                    );

                objImplementacaoBancoDados.Dispose();

                mtdCarregarGvw1();
            }
            catch (System.Exception ex)
            {
                string strExcecao = "btnDeletar_Click: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao); 
                WebServiceCSNet40.Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", WebServiceCSNet40.Default.DiretorioArmazenamentoCompleto), strExcecao);
            }

            Response.Redirect("~/frmCadastroUsuario.aspx");
        }
    }
}