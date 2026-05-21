using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebServiceCSNet40
{

    public partial class frmConsultarTabelaDados : System.Web.UI.Page
    {
        private clsManipuladorTexto objManipuladorTexto = new clsManipuladorTexto();

        public static int intProgresso = 0;
        public static string strNomeProcesso = string.Empty;
        public static string strNomeProcessoRelatorio = string.Empty;
        public static string strNomeProcessoSapR3 = string.Empty;

        private string strTabelasAuxiliaresFiltroImportacaoPrincipal = "tblTabelasAuxiliaresFiltroImportacao";
        private string strTabelaAuxiliaresTermoResponsabilidadeGeralPrincipal = "tblTabelasAuxiliaresTermoResponsabilidadeGeral";

        private string strColunaTermoResponsabilidadeGeralPrincipal = "TermoResponsabilidadeGeral".ToUpper();
        private string strColunaFiltroImportacaoPrincipal = "FiltroImportacao".ToUpper();


        protected internal frmConsultarTabelaDados()
        {
            AppDomain.CurrentDomain.SetData("SQLServerCompactEditionUnderWebHosting", true);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    lblUsuario.Text = login.NomeUsuario;

                    hlkPerfil.Text = Default.strStatusUsuario;

                    lblSaudacao.Text = Default.mtdSaudacao();

                    strTabelaSelecionada = strTabelaAuxiliaresTermoResponsabilidadeGeralPrincipal;

                    mtdCarregarGvw1("Principal", strTabelaSelecionada);

                    dplSelecionarBancoDados.Items.Add("Principal");
                    dplSelecionarBancoDados.Items.Add("Coletor");

                    mtdPreencherDpl(String.Format("SELECT TOP 1 * FROM {0}", strTabelaSelecionada), ref dplConsultarCampo);

                    dplConsultarTotalParcial.Items.Add("Campo Inteiro");
                    dplConsultarTotalParcial.Items.Add("Qualquer Parte do Campo");
                    dplConsultarTotalParcial.Text = dplConsultarTotalParcial.Items[1].ToString();

                    dplConsultarTabelaRelatorio.Enabled = false;

                    btnConsultar.Focus();
                }
            }
            catch
            {
            }
        }

        [System.Web.Services.WebMethod]
        public static object[] ExecuteCommand(string commandName, string targetMethod, object data)
        {
            try
            {
                object[] result = new object[2];
                result[0] = Command.Create(commandName).Execute(data);
                result[1] = targetMethod;
                return result;
            }
            catch (Exception ex)
            {
                // TODO: add logging functionality 
                throw;
            }
        }

        private clsRegistroWindows objRegistroWindows = new clsRegistroWindows();

        private string mtdIdentificarTipoPrincipal(string Tipo)
        {
            string strTipo = string.Empty;
            switch (Tipo)
            {
                case "System.String":
                    strTipo = "TEXT";
                    break;
                case "System.Int16":
                case "System.Int32":
                case "System.Int64":
                case "System.Double":
                    strTipo = "INTEGER";
                    break;
            }

            return strTipo;
        }

        private string mtdIdentificarTamanhoTipo(string Tipo)
        {
            string strTamanho = string.Empty;
            switch (Tipo)
            {
                case "System.String":
                    strTamanho = "255";
                    break;
                case "System.Int16":
                case "System.Int32":
                case "System.Int64":
                case "System.Double":
                    strTamanho = string.Empty;
                    break;
            }

            return strTamanho;
        }

        private string mtdObterFormatoTipo(string Tipo)
        {
            string strFormato = string.Empty;
            switch (Tipo)
            {
                case "System.String":
                    strFormato = "'{0}'";
                    break;
                case "System.Int16":
                case "System.Int32":
                case "System.Int64":
                case "System.Double":
                    strFormato = "{0}";
                    break;
            }

            return strFormato;
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            if (!mnu1.Items[7].Selected)
            {
                mtdCarregarGvw1
                     (
                     dplSelecionarBancoDados.Text,
                     strTabelaSelecionada,
                     dplConsultarCampo.Text,
                     string.Format
                     (
                     "'{0}'",
                     string.Format
                     (
                     (
                     dplConsultarTotalParcial.SelectedIndex == 0
                     ?
                     "{0}"
                     :
                     "%{0}%"
                     ),
                     txtConsultarCampo.Text
                     )
                     ),
                     dplConsultarCampo.Text,
                     true
                     );
            }
            else
            {
                int NumeroLinhas = 0;
                string Campo = dplConsultarCampo.Text;
                string CampoContador = "Contador";
                string NomeTabela = strTabelaSelecionada;
                string Selecao = string.Format("{0} LIKE {1}", dplConsultarCampo.Text,
                    string.Format
                     (
                     "'{0}'",
                     (
                     string.Format
                     (
                     (
                     dplConsultarTotalParcial.SelectedIndex == 0
                     ?
                     "{0}"
                     :
                     "%{0}%"
                     ),
                     txtConsultarCampo.Text
                     )
                     )
                     )
                     );
                string CampoOrdenador = dplConsultarCampo.Text;
                bool Crescente = true;

                string SQL =
                    string.Format
                    (
                    "SELECT DISTINCT {0}{1}, COUNT({1}) AS {2} FROM {3} GROUP BY {1} HAVING {4} ORDER BY {5}{6};",
                    NumeroLinhas != 0 ? dplSelecionarBancoDados.SelectedItem.Text == "Coletor" ? string.Format("TOP ({0}) ", NumeroLinhas) : string.Format("TOP {0} ", NumeroLinhas) : string.Empty,
                    Campo,
                    CampoContador,
                    NomeTabela,
                    Selecao,
                    CampoOrdenador,
                    Crescente ? string.Empty : " DESC"
                    );

                mtdCarregarGvw1SQL(dplSelecionarBancoDados.Text, SQL);
            }
        }

        private void mtdCarregarGvw1(string BancoDados, string Tabela)
        {
            try
            {
                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
                string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
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
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        private void mtdCarregarGvw1(string BancoDados, string Tabela, string ColunaSelecionadora, object DadoSelecionador, string ColunaOrdenadora, bool Crescente)
        {
            try
            {
                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
                string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
                clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

                objImplementacaoBancoDados.mtdSelecionarDados
                    (
                    "*",
                    Tabela,
                    ColunaSelecionadora,
                    "LIKE",
                    DadoSelecionador,
                    ColunaOrdenadora,
                    Crescente
                    );

                objImplementacaoBancoDados.mtdAdaptadorDados();

                gvw1.DataSource = objImplementacaoBancoDados.prpAjustadorDados;
                gvw1.DataBind();

                objImplementacaoBancoDados.Dispose();
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdCarregarGvw1: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        private void mtdCarregarGvw1SQL(string BancoDados, string SQL)
        {
            try
            {
                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
                string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
                clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

                objImplementacaoBancoDados.mtdAbrirConexao();
                objImplementacaoBancoDados.mtdExecutarComando(SQL);

                objImplementacaoBancoDados.mtdAdaptadorDados();

                gvw1.DataSource = objImplementacaoBancoDados.prpAjustadorDados;
                gvw1.DataBind();

                objImplementacaoBancoDados.Dispose();
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdCarregarGvw1: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        private void mtdAlterarDados(string Tabela)
        {
            try
            {
                string BancoDados = "Principal";

                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
                string strConexao = WebServiceCSNet40.Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
                clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

                objImplementacaoBancoDados.mtdSelecionarDados("*", Tabela);
                objImplementacaoBancoDados.mtdDefinirLeitorDados();

                object[][] dados = new object[2][];

                dados[0] = objImplementacaoBancoDados.mtdObterCabecalhoColunas();

                dados[1] = new object[1] { gvw1.Rows[gvw1.SelectedRow.DataItemIndex].Cells[1].Text };

                objImplementacaoBancoDados.mtdAtualizarDados
                    (
                    Tabela,
                    txt1.Text,
                    dados[0][0].ToString(),
                    "LIKE",
                    dados[1][0]
                    );

                objImplementacaoBancoDados.Dispose();

                mtdCarregarGvw1(BancoDados, Tabela);
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdAlterarDados: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);                 // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        private void mtdInserirDados(string Tabela)
        {
            try
            {
                string BancoDados = "Principal";

                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
                string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
                clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

                objImplementacaoBancoDados.mtdSelecionarDados("*", Tabela);
                objImplementacaoBancoDados.mtdDefinirLeitorDados();

                object[][] dados = new object[2][];

                dados[0] = objImplementacaoBancoDados.mtdObterCabecalhoColunas();
                dados[1] = new object[1] { string.Format("'{0}'", txt1.Text) };

                objImplementacaoBancoDados.mtdInserirDados(Tabela, dados);

                objImplementacaoBancoDados.Dispose();

                mtdCarregarGvw1(BancoDados, Tabela);
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdInserirDados: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        private void mtdDeletarDados(string Tabela)
        {
            try
            {
                string BancoDados = "Principal";

                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
                string strConexao = WebServiceCSNet40.Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
                clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

                objImplementacaoBancoDados.mtdSelecionarDados("*", Tabela);
                objImplementacaoBancoDados.mtdDefinirLeitorDados();

                object[][] dados = new object[2][];

                dados[0] = objImplementacaoBancoDados.mtdObterCabecalhoColunas();

                dados[1] = new object[1] { gvw1.Rows[gvw1.SelectedRow.DataItemIndex].Cells[1].Text };

                objImplementacaoBancoDados.mtdDeletarDadosParametroComandoOleDb
                    (
                    Tabela,
                    dados[0][0].ToString(),
                    "LIKE",
                    dados[1][0]
                    );

                objImplementacaoBancoDados.Dispose();

                mtdCarregarGvw1(BancoDados, Tabela);
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdDeletarDados: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            if (strTabelaSelecionada == strTabelasAuxiliaresFiltroImportacaoPrincipal)
            {
                mtdAlterarDados(strTabelaSelecionada);
            }
            if (strTabelaSelecionada == strTabelaAuxiliaresTermoResponsabilidadeGeralPrincipal)
            {
                mtdAlterarDados(strTabelaSelecionada);
            }
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            if (strTabelaSelecionada == strTabelasAuxiliaresFiltroImportacaoPrincipal)
            {
                mtdInserirDados(strTabelaSelecionada);
            }
            if (strTabelaSelecionada == strTabelaAuxiliaresTermoResponsabilidadeGeralPrincipal)
            {
                mtdInserirDados(strTabelaSelecionada);
            }
        }

        protected void btnDeletar_Click(object sender, EventArgs e)
        {
            if (strTabelaSelecionada == strTabelasAuxiliaresFiltroImportacaoPrincipal)
            {
                mtdDeletarDados(strTabelaSelecionada);
            }
            if (strTabelaSelecionada == strTabelaAuxiliaresTermoResponsabilidadeGeralPrincipal)
            {
                mtdDeletarDados(strTabelaSelecionada);
            }
        }

        private static string strTabelaSelecionada = string.Empty;
        private static string strColunaSelecionada = string.Empty;
        private static object objDadoSelecionado = null;

        protected void mnu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            if (mnu1.Items[0].Text == mnu1.SelectedItem.Text)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (mnu1.Items[1].Text == mnu1.SelectedItem.Text)
            {
                string strTabelaAuxiliaresFiltroImportacaoPrincipal = "tblTabelasAuxiliaresFiltroImportacao";

                strTabelaSelecionada = strTabelaAuxiliaresFiltroImportacaoPrincipal;
            }
            if (mnu1.Items[2].Text == mnu1.SelectedItem.Text)
            {
                string strTabelaAuxiliaresTermoResponsabilidadeGeralPrincipal = "tblTabelasAuxiliaresTermoResponsabilidadeGeral";

                strTabelaSelecionada = strTabelaAuxiliaresTermoResponsabilidadeGeralPrincipal;
            }
            if (mnu1.Items[3].Text == mnu1.SelectedItem.Text)
            {
                strTabelaSelecionada = Default.strTabelaBensEletronorte;
            }
            if (mnu1.Items[4].Text == mnu1.SelectedItem.Text)
            {
                strTabelaSelecionada = Default.strTabelaEmpregados;
            }
            if (mnu1.Items[5].Text == mnu1.SelectedItem.Text)
            {
                strTabelaSelecionada = Default.strTabelaCentroCusto;
            }
            if (mnu1.Items[6].Text == mnu1.SelectedItem.Text)
            {
                strTabelaSelecionada = Default.strTabelaInventarioBens;
            }

            dplConsultarTabelaRelatorio.Enabled = false;

            if (mnu1.Items[7].Text == mnu1.SelectedItem.Text)
            {
                dplConsultarTabelaRelatorio.Enabled = true;

                mtdCarregarDblConsultarTabelaRelatorio();
            }

            switch (dplSelecionarBancoDados.Text)
            {
                case "Principal":
                    mtdPreencherDpl
                        (
                        string.Format("SELECT TOP 1 * FROM {0}", strTabelaSelecionada),
                        ref dplConsultarCampo
                        );
                    break;
                case "Coletor":
                    mtdPreencherDpl
                        (
                        string.Format("SELECT TOP (1) * FROM {0}", strTabelaSelecionada),
                        ref dplConsultarCampo
                        );
                    break;
            }
        }

        private void mtdPreencherDpl(string strSQL, ref System.Web.UI.WebControls.DropDownList dpl)
        {
            try
            {
                string BancoDados = string.Empty;

                if
                    (
                    mnu1.SelectedValue != "Voltar"
                    &
                    mnu1.SelectedValue != "Filtro Importacao Bens"
                    &
                    mnu1.SelectedValue != "Termo de Responsabilidade Geral"
                    )
                {
                    switch (dplSelecionarBancoDados.Text)
                    {
                        case "Principal":
                            BancoDados = "Principal";
                            break;
                        case "Coletor":
                            BancoDados = "Coletor";
                            break;
                    }
                }
                else
                {
                    BancoDados = "Principal";
                }

                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
                string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
                clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

                objImplementacaoBancoDados.mtdAbrirConexao(strConexao);
                objImplementacaoBancoDados.mtdExecutarComando(strSQL);
                int numMaxRegistro = objImplementacaoBancoDados.mtdNumeroLinhas() - 1;
                objImplementacaoBancoDados.mtdDefinirLeitorDados();
                objImplementacaoBancoDados.mtdProximoRegistro();
                //objBancoDadosPrincipal.mtdAdaptadorDados()
                // cria tres itens e tres conjuntos de subitems para cada item
                dpl.Items.Clear();
                //for (int contador = 0; contador <= dpl.Items.Count - 1; contador += 1)
                //{
                //    dpl.Items.RemoveAt(0);
                //}
                int numColuna = objImplementacaoBancoDados.mtdNumeroColunas() - 1;

                dpl.Items.Add(string.Empty);

                for (int contador = 0; contador <= numColuna; contador += 1)
                {
                    dpl.Items.Add(objImplementacaoBancoDados.mtdObterCabecalhoColunas(contador));
                }

                dpl.Text = dpl.Items[0].Value;
                objImplementacaoBancoDados.Dispose();
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdPreencherDpl: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        private string mtdIdentificarTipoCADU(string Tipo)
        {
            string strTipo = string.Empty;
            switch (Tipo)
            {
                case "System.String":
                    strTipo = "VARCHAR";
                    break;
                case "System.Int16":
                case "System.Int32":
                case "System.Int64":
                case "System.Double":
                    strTipo = "INTEGER";
                    break;
            }
            return strTipo;
        }

        private string mtdIdentificarTipoColetor(string Tipo)
        {
            string strTipo = string.Empty;
            switch (Tipo)
            {
                case "System.String":
                    strTipo = "NVARCHAR";
                    break;
                case "System.Int16":
                case "System.Int32":
                case "System.Int64":
                case "System.Double":
                    strTipo = "INTEGER";
                    break;
            }
            return strTipo;
        }

        public static int mtdProgresso(int NumeroParcial, int NumeroTotal)
        {
            int Progresso = (int)(((double)NumeroParcial * 100) / (double)(NumeroTotal));

            Progresso = Progresso >= 0 ? Progresso : 0;
            Progresso = Progresso < 100 ? Progresso : 99;

            return Progresso;
        }

        private void mtdCarregarDblConsultarTabelaRelatorio()
        {
            dplConsultarTabelaRelatorio.Items.Clear();
            dplConsultarTabelaRelatorio.Items.Add(string.Empty);
            dplConsultarTabelaRelatorio.Items.Add(Default.strTabelaInventarioBens.Replace("tbl", string.Empty));
            dplConsultarTabelaRelatorio.Items.Add(Default.strTabelaBensEletronorte.Replace("tbl", string.Empty));
            dplConsultarTabelaRelatorio.Items.Add(Default.strTabelaEmpregados.Replace("tbl", string.Empty));
            dplConsultarTabelaRelatorio.Items.Add(Default.strTabelaCentroCusto.Replace("tbl", string.Empty));
            dplConsultarTabelaRelatorio.SelectedIndex = 0;
        }

        protected void dplConsultarTabelaRelatorio_TextChanged(object sender, EventArgs e)
        {

            strTabelaSelecionada = string.Format("tbl{0}", dplConsultarTabelaRelatorio.Text);

            mtdPreencherDpl
                (
                string.Format("SELECT TOP 1 * FROM {0}", strTabelaSelecionada),
                ref dplConsultarCampo
                );
        }

        public static int intGvw1LinhaSelecionada = 0;

        public static object[] objDados = null;

        protected void gvw1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                intGvw1LinhaSelecionada = gvw1.SelectedIndex;

                strColunaSelecionada = gvw1.Columns[1].ToString();
                objDadoSelecionado = gvw1.Rows[gvw1.SelectedRow.DataItemIndex].Cells[0].Text;

                objDados = mtdObterDadosTabelas(strTabelaSelecionada, strColunaSelecionada, objDadoSelecionado);
            }
            catch (System.Exception ex)
            {
                string strExcecao = "gvw1_SelectedIndexChanged: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);

                lblInformacao.Text = "Houve erro ao selecionar o item.";
            }
        }

        private object[] mtdObterDadosTabelas(string Tabela, string Campo, object Dado)
        {
            string BancoDados = "Principal";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexao = WebServiceCSNet40.Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

            objImplementacaoBancoDados.mtdSelecionarDados("*", Tabela, Campo, "LIKE", Dado);

            objImplementacaoBancoDados.mtdDefinirLeitorDados();

            objImplementacaoBancoDados.mtdProximoRegistro();

            return objImplementacaoBancoDados.mtdObterValorRegistro();
        }
    }
}