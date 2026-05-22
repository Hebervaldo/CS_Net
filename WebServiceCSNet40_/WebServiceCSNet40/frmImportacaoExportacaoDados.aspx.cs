using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebServiceCSNet40
{
    public class Command
    {
        #region Command functionality

        private string m_CommandName = "";

        public Command(string commandName)
        {
            m_CommandName = commandName;
        }

        public static Command Create(string commandName)
        {
            return new Command(commandName);
        }

        public object Execute(object data)
        {
            object retorno = null;

            Type type = this.GetType();
            System.Reflection.MethodInfo method = type.GetMethod(m_CommandName);
            object[] args = new object[] { data };
            try
            {
                retorno = method.Invoke(this, args);
            }
            catch (Exception ex)
            {
                // TODO: Add logging functionality
                //throw;           

                string strExcecao = "Execute: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }

            return retorno;
        }

        #endregion

        #region Public execution commands

        /// <summary>
        /// Launch the new process with 
        /// name specified in object "data"
        /// </summary>
        /// <param name="data">
        /// Name of a process
        /// </param>
        /// <returns>null</returns>
        public object LaunchNewProcess(object data)
        {
            ProcessStatus newProcess =
                new ProcessStatus
                    (
                    String.Format
                    (
                    "{0}",
                    data
                    )
                    );

            System.Collections.ArrayList allProcesses = ProcessStatuses.Get();

            bool blnAutorizarProcesso = true;
            int intContador = 0;

            try
            {
                foreach (System.Collections.ArrayList item in allProcesses)
                {
                    if (((ProcessStatus)item[intContador]).Name == newProcess.Name)
                    {
                        blnAutorizarProcesso = false;
                    }
                    intContador++;
                }

                if (blnAutorizarProcesso)
                {
                    System.Collections.ArrayList.Synchronized(allProcesses).Add(newProcess);

                    System.Threading.ThreadPool.QueueUserWorkItem(
                        new System.Threading.WaitCallback(ProcessStatuses.StartProcessing),
                        new object[] { newProcess, allProcesses }
                        );
                }
            }
            catch (System.Exception ex)
            {
                string strExcecao = "LaunchNewProcess: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }

            return null;
        }

        /// <summary>
        /// Returns Array of ProcessStatus 
        /// objects to the client script
        /// </summary>
        /// <param name="data">
        /// anything, this data 
        /// is not processed in this method
        /// </param>
        /// <returns>
        /// Array of ProcessStatus objects
        /// </returns>
        public object GetProcessStatuses(object data)
        {
            System.Collections.ArrayList allProcesses = ProcessStatuses.Get();
            lock (allProcesses.SyncRoot)
            {
                return allProcesses.ToArray();
            }
        }

        #endregion
    }

    public class ProcessStatus
    {
        public ProcessStatus(string name)
        {
            m_Name = name;
        }

        private int m_Status = 0;

        public int Status
        {
            get { return m_Status; }
            set { m_Status = value; }
        }

        private string m_Name = "";

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public void IncrementStatus()
        {
            lock (this)
            {
                m_Status++;
            }
        }

        public void IncrementStatus(int Progresso)
        {
            lock (this)
            {
                m_Status = Progresso;
            }
        }
    }

    public class ProcessStatuses
    {
        private const string m_SessionKey = "ProcessStatusesKey";

        public static System.Collections.ArrayList Get()
        {
            if (HttpContext.Current.Session[m_SessionKey] == null)
            {
                HttpContext.Current.Session[m_SessionKey] = new System.Collections.ArrayList();
            }
            return (System.Collections.ArrayList)HttpContext.Current.Session[m_SessionKey];
        }

        public static void StartProcessing(object data)
        {
            ProcessStatus process = (ProcessStatus)((object[])data)[0];
            while (process.Status < 100)
            {
                //process.IncrementStatus();
                process.Name = frmImportacaoExportacaoDados.strNomeProcesso;
                process.IncrementStatus(frmImportacaoExportacaoDados.intProgresso);
                Random rnd = new Random(DateTime.Now.GetHashCode());
                System.Threading.Thread.Sleep(((int)(rnd.NextDouble() * 40) + 10) * 10);
            }
            System.Threading.Thread.Sleep(2000);
            System.Collections.ArrayList.Synchronized((System.Collections.ArrayList)((object[])data)[1]).Remove(process);
        }
    }

    public partial class frmImportacaoExportacaoDados : System.Web.UI.Page
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

        private string strModoCapitalizacao = "Capitalizado";

        private int intNumeroColunasPrincipal = 0;
        private int intNumeroLinhasPrincipal = 0;
        private int intNumeroColunasColetor = 0;
        private int intNumeroLinhasColetor = 0;
        private string[] vetTipoColunasPrincipal;
        private string[] vetTipoColunasColetor;

        private int intNumeroColunasCADU = 0;
        private int intNumeroLinhasCADU = 0;
        private string[] vetTipoColunasCADU = null;

        private int intcolunaTabelaCentroCusto = 0;

        protected internal frmImportacaoExportacaoDados()
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

                    dplSelecionarBancoDados.Items.Add("Principal");
                    dplSelecionarBancoDados.Items.Add("Coletor");

                    dplConsultarCampoExportacaoDadosInventarioBensExcel.Items.Add("Relatório");
                    dplConsultarCampoExportacaoDadosInventarioBensExcel.Items.Add("SapR3");
                    dplConsultarCampoExportacaoDadosInventarioBensExcel.Text = dplConsultarCampoExportacaoDadosInventarioBensExcel.Items[0].ToString();

                    btnIniciarPreparacaoColetorDados.Focus();
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

        //protected void btnConsultar_Click(object sender, EventArgs e)
        //{
        //    if (!mnu1.Items[7].Selected)
        //    {
        //        mtdCarregarGvw1
        //             (
        //             dplSelecionarBancoDados.Text,
        //             strTabelaSelecionada,
        //             dplConsultarCampo.Text,
        //             string.Format
        //             (
        //             "'{0}'",
        //             string.Format
        //             (
        //             (
        //             dplConsultarTotalParcial.SelectedIndex == 0
        //             ?
        //             "{0}"
        //             :
        //             "%{0}%"
        //             ),
        //             txtConsultarCampo.Text
        //             )
        //             ),
        //             dplConsultarCampo.Text,
        //             true
        //             );
        //    }
        //    else
        //    {
        //        int NumeroLinhas = 0;
        //        string Campo = dplConsultarCampo.Text;
        //        string CampoContador = "Contador";
        //        string NomeTabela = strTabelaSelecionada;
        //        string Selecao = string.Format("{0} LIKE {1}", dplConsultarCampo.Text,
        //            string.Format
        //             (
        //             "'{0}'",
        //             (
        //             string.Format
        //             (
        //             (
        //             dplConsultarTotalParcial.SelectedIndex == 0
        //             ?
        //             "{0}"
        //             :
        //             "%{0}%"
        //             ),
        //             txtConsultarCampo.Text
        //             )
        //             )
        //             )
        //             );
        //        string CampoOrdenador = dplConsultarCampo.Text;
        //        bool Crescente = true;

        //        string SQL =
        //            string.Format
        //            (
        //            "SELECT DISTINCT {0}{1}, COUNT({1}) AS {2} FROM {3} GROUP BY {1} HAVING {4} ORDER BY {5}{6};",
        //            NumeroLinhas != 0 ? dplSelecionarBancoDados.SelectedItem.Text == "Coletor" ? string.Format("TOP ({0}) ", NumeroLinhas) : string.Format("TOP {0} ", NumeroLinhas) : string.Empty,
        //            Campo,
        //            CampoContador,
        //            NomeTabela,
        //            Selecao,
        //            CampoOrdenador,
        //            Crescente ? string.Empty : " DESC"
        //            );

        //        mtdCarregarGvw1SQL(dplSelecionarBancoDados.Text, SQL);
        //    }
        //}

        protected void btnIniciarImportacaoDadosBens_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(Default.strArquivoTexto))
            {
                lblAviso.Text = "Processo em execução.";

                try
                {
                    //mtdAbortarThreads();

                    switch (dplSelecionarBancoDados.SelectedItem.Text)
                    {
                        case "Principal":
                            mtdIniciarThreadDownloadTabelaInventarioBensPrincipal();
                            break;
                        case "Coletor":
                            mtdIniciarThreadDownloadTabelaInventarioBensColetor();
                            break;
                    }
                }
                catch (System.Exception ex)
                {
                    string strExcecao = "btnIniciarImportacaoDados_Click: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                    // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
                }
            }
            else
            {
                lblAviso.Text = "Verifique se o endereço e o nome dos arquivos de dados estão corretos";
            }
        }

        protected void btnPararImportacaoDadosBens_Click(object sender, EventArgs e)
        {
            try
            {
                switch (dplSelecionarBancoDados.SelectedItem.Text)
                {
                    case "Principal":
                        mtdAbortarThreadImportarDadosTabelaBensPrincipal(true);
                        break;
                    case "Coletor":
                        mtdAbortarThreadImportarDadosTabelaBensColetor(true);
                        break;
                }
            }
            catch (System.Exception ex)
            {
                string strExcecao = "btnPararImportacaoDados_Click: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        protected void btnIniciarImportacaoDadosEmpregados_Click(object sender, EventArgs e)
        {
            try
            {
                //mtdAbortarThreads();

                switch (dplSelecionarBancoDados.SelectedItem.Text)
                {
                    case "Principal":
                        mtdIniciarThreadDownloadTabelaEmpregadosPrincipal(true);
                        break;
                    case "Coletor":
                        mtdIniciarThreadDownloadTabelaEmpregadosColetor(true);
                        break;
                }
            }
            catch (System.Exception ex)
            {
                string strExcecao = "btnIniciarImportacaoDadosEmpregados_Click: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        protected void btnPararImportacaoDadosEmpregados_Click(object sender, EventArgs e)
        {
            try
            {
                switch (dplSelecionarBancoDados.SelectedItem.Text)
                {
                    case "Principal":
                        mtdAbortarThreadImportarDadosTabelaEmpregadosPrincipal(true);
                        break;
                    case "Coletor":
                        mtdAbortarThreadImportarDadosTabelaEmpregadosColetor(true);
                        break;
                }
            }
            catch (System.Exception ex)
            {
                string strExcecao = "btnPararImportacaoDadosEmpregados_Click: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        protected void btnIniciarImportacaoDadosCentroCusto_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(Default.strArquivoTexto))
            {
                lblAviso.Text = "Processo em execução.";

                try
                {
                    //mtdAbortarThreads();

                    switch (dplSelecionarBancoDados.SelectedItem.Text)
                    {
                        case "Principal":
                            mtdIniciarThreadDownloadTabelaInventarioCentroCustoPrincipal();
                            break;
                        case "Coletor":
                            mtdIniciarThreadDownloadTabelaInventarioCentroCustoColetor();
                            break;
                    }
                }
                catch (System.Exception ex)
                {
                    string strExcecao = "btnIniciarImportacaoDados_Click: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                    // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
                }
            }
            else
            {
                lblAviso.Text = "Verifique se o endereço e o nome dos arquivos de dados estão corretos";
            }
        }

        protected void btnPararImportacaoDadosCentroCusto_Click(object sender, EventArgs e)
        {
            try
            {
                switch (dplSelecionarBancoDados.SelectedItem.Text)
                {
                    case "Principal":
                        mtdAbortarThreadImportarDadosTabelaCentroCustoPrincipal(true);
                        break;
                    case "Coletor":
                        mtdAbortarThreadImportarDadosTabelaCentroCustoColetor(true);
                        break;
                }
            }
            catch (System.Exception ex)
            {
                string strExcecao = "btnPararImportacaoDados_Click: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        protected void btnIniciarExportacaoDadosInventarioBensExcel_Click(object sender, EventArgs e)
        {
            switch (dplConsultarCampoExportacaoDadosInventarioBensExcel.Text)
            {
                case "Relatório":
                    btnIniciarExportacaoDadosInventarioBensExcelRelatorio_Click(sender, e);
                    break;
                case "SapR3":
                    btnIniciarExportacaoDadosInventarioBensExcelSapR3_Click(sender, e);
                    break;
            }
        }

        protected void btnPararExportacaoDadosInventarioBensExcel_Click(object sender, EventArgs e)
        {
            switch (dplConsultarCampoExportacaoDadosInventarioBensExcel.Text)
            {
                case "Relatório":
                    btnPararExportacaoDadosInventarioBensExcelRelatorio_Click(sender, e);
                    break;
                case "SapR3":
                    btnPararExportacaoDadosInventarioBensExcelSapR3_Click(sender, e);
                    break;
            }
        }

        protected void btnIniciarExportacaoDadosInventarioBensExcelRelatorio_Click(object sender, EventArgs e)
        {
            //mtdAbortarThreads();

            blnThreadAtivadaExportarPlanilhaExcelRelatorio = true;
            mtdIniciarThreadExportarPlanilhaExcelRelatorio();
        }

        protected void btnPararExportacaoDadosInventarioBensExcelRelatorio_Click(object sender, EventArgs e)
        {
            blnThreadAtivadaExportarPlanilhaExcelRelatorio = false;
            mtdAbortarThreadExportarPlanilhaExcelRelatorio(true);
        }

        protected void btnIniciarExportacaoDadosInventarioBensExcelSapR3_Click(object sender, EventArgs e)
        {
            //mtdAbortarThreads();

            blnThreadAtivadaExportarPlanilhaExcelSapR3 = true;
            mtdIniciarThreadExportarPlanilhaExcelSapR3();
        }

        protected void btnPararExportacaoDadosInventarioBensExcelSapR3_Click(object sender, EventArgs e)
        {
            blnThreadAtivadaExportarPlanilhaExcelSapR3 = false;
            mtdAbortarThreadExportarPlanilhaExcelSapR3(true);
        }

        //private void mtdCarregarGvw1(string BancoDados, string Tabela)
        //{
        //    try
        //    {
        //        clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
        //        string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
        //        clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

        //        objImplementacaoBancoDados.mtdSelecionarDados("*", Tabela);

        //        objImplementacaoBancoDados.mtdAdaptadorDados();

        //        gvw1.DataSource = objImplementacaoBancoDados.prpAjustadorDados;
        //        gvw1.DataBind();

        //        objImplementacaoBancoDados.Dispose();
        //    }
        //    catch (System.Exception ex)
        //    {
        //        string strExcecao = "mtdCarregarGvw1: " + ex.Message;
        //            System.Diagnostics.Debug.WriteLine(strExcecao); erro;                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
        //    }
        //}

        //private void mtdCarregarGvw1(string BancoDados, string Tabela, string ColunaSelecionadora, object DadoSelecionador, string ColunaOrdenadora, bool Crescente)
        //{
        //    try
        //    {
        //        clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
        //        string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
        //        clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

        //        objImplementacaoBancoDados.mtdSelecionarDados
        //            (
        //            "*",
        //            Tabela,
        //            ColunaSelecionadora,
        //            "LIKE",
        //            DadoSelecionador,
        //            ColunaOrdenadora,
        //            Crescente
        //            );

        //        objImplementacaoBancoDados.mtdAdaptadorDados();

        //        gvw1.DataSource = objImplementacaoBancoDados.prpAjustadorDados;
        //        gvw1.DataBind();

        //        objImplementacaoBancoDados.Dispose();
        //    }
        //    catch (System.Exception ex)
        //    {
        //        string strExcecao = "mtdCarregarGvw1: " + ex.Message;
        //            System.Diagnostics.Debug.WriteLine(strExcecao); erro;                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
        //    }
        //}

        //private void mtdCarregarGvw1SQL(string BancoDados, string SQL)
        //{
        //    try
        //    {
        //        clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
        //        string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
        //        clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

        //        objImplementacaoBancoDados.mtdAbrirConexao();
        //        objImplementacaoBancoDados.mtdExecutarComando(SQL);

        //        objImplementacaoBancoDados.mtdAdaptadorDados();

        //        gvw1.DataSource = objImplementacaoBancoDados.prpAjustadorDados;
        //        gvw1.DataBind();

        //        objImplementacaoBancoDados.Dispose();
        //    }
        //    catch (System.Exception ex)
        //    {
        //        string strExcecao = "mtdCarregarGvw1: " + ex.Message;
        //            System.Diagnostics.Debug.WriteLine(strExcecao); erro;                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
        //    }
        //}

        //private void mtdAlterarDados(string Tabela)
        //{
        //    try
        //    {
        //        string BancoDados = "Principal";

        //        clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
        //        string strConexao = WebServiceCSNet40.Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
        //        clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

        //        objImplementacaoBancoDados.mtdSelecionarDados("*", Tabela);
        //        objImplementacaoBancoDados.mtdDefinirLeitorDados();

        //        object[][] dados = new object[2][];

        //        dados[0] = objImplementacaoBancoDados.mtdObterCabecalhoColunas();

        //        dados[1] = new object[1] { gvw1.Rows[gvw1.SelectedRow.DataItemIndex].Cells[1].Text };

        //        objImplementacaoBancoDados.mtdAtualizarDados
        //            (
        //            Tabela,
        //            txt1.Text,
        //            dados[0][0].ToString(),
        //            "LIKE",
        //            dados[1][0]
        //            );

        //        objImplementacaoBancoDados.Dispose();

        //        mtdCarregarGvw1(BancoDados, Tabela);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        string strExcecao = "mtdAlterarDados: " + ex.Message;
        //            System.Diagnostics.Debug.WriteLine(strExcecao); erro;                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
        //    }
        //}

        //private void mtdInserirDados(string Tabela)
        //{
        //    try
        //    {
        //        string BancoDados = "Principal";

        //        clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
        //        string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
        //        clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

        //        objImplementacaoBancoDados.mtdSelecionarDados("*", Tabela);
        //        objImplementacaoBancoDados.mtdDefinirLeitorDados();

        //        object[][] dados = new object[2][];

        //        dados[0] = objImplementacaoBancoDados.mtdObterCabecalhoColunas();
        //        dados[1] = new object[1] { string.Format("'{0}'", txt1.Text) };

        //        objImplementacaoBancoDados.mtdInserirDados(Tabela, dados);

        //        objImplementacaoBancoDados.Dispose();

        //        mtdCarregarGvw1(BancoDados, Tabela);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        string strExcecao = "mtdInserirDados: " + ex.Message;
        //            System.Diagnostics.Debug.WriteLine(strExcecao); erro;                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
        //    }
        //}

        //private void mtdDeletarDados(string Tabela)
        //{
        //    try
        //    {
        //        string BancoDados = "Principal";

        //        clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
        //        string strConexao = WebServiceCSNet40.Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
        //        clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

        //        objImplementacaoBancoDados.mtdSelecionarDados("*", Tabela);
        //        objImplementacaoBancoDados.mtdDefinirLeitorDados();

        //        object[][] dados = new object[2][];

        //        dados[0] = objImplementacaoBancoDados.mtdObterCabecalhoColunas();

        //        dados[1] = new object[1] { gvw1.Rows[gvw1.SelectedRow.DataItemIndex].Cells[1].Text };

        //        objImplementacaoBancoDados.mtdDeletarDadosParametroComandoOleDb
        //            (
        //            Tabela,
        //            dados[0][0].ToString(),
        //            "LIKE",
        //            dados[1][0]
        //            );

        //        objImplementacaoBancoDados.Dispose();

        //        mtdCarregarGvw1(BancoDados, Tabela);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        string strExcecao = "mtdDeletarDados: " + ex.Message;
        //            System.Diagnostics.Debug.WriteLine(strExcecao); erro;                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
        //    }
        //}

        private static string strTabelaSelecionada = string.Empty;
        private static string strColunaSelecionada = string.Empty;
        private static object objDadoSelecionado = null;

        protected void mnu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            if (mnu1.Items[0].Text == mnu1.SelectedItem.Text)
            {
                Response.Redirect("~/Default.aspx");
            }
            //if (mnu1.Items[1].Text == mnu1.SelectedItem.Text)
            //{
            //    string strTabelaAuxiliaresFiltroImportacaoPrincipal = "tblTabelasAuxiliaresFiltroImportacao";

            //    strTabelaSelecionada = strTabelaAuxiliaresFiltroImportacaoPrincipal;
            //}
            //if (mnu1.Items[2].Text == mnu1.SelectedItem.Text)
            //{
            //    string strTabelaAuxiliaresTermoResponsabilidadeGeralPrincipal = "tblTabelasAuxiliaresTermoResponsabilidadeGeral";

            //    strTabelaSelecionada = strTabelaAuxiliaresTermoResponsabilidadeGeralPrincipal;
            //}
            //if (mnu1.Items[3].Text == mnu1.SelectedItem.Text)
            //{
            //    strTabelaSelecionada = Default.strTabelaBensEletronorte;
            //}
            //if (mnu1.Items[4].Text == mnu1.SelectedItem.Text)
            //{
            //    strTabelaSelecionada = Default.strTabelaEmpregados;
            //}
            //if (mnu1.Items[5].Text == mnu1.SelectedItem.Text)
            //{
            //    strTabelaSelecionada = Default.strTabelaCentroCusto;
            //}
            //if (mnu1.Items[6].Text == mnu1.SelectedItem.Text)
            //{
            //    strTabelaSelecionada = Default.strTabelaInventarioBens;
            //}

            //dplConsultarTabelaRelatorio.Enabled = false;

            //if (mnu1.Items[7].Text == mnu1.SelectedItem.Text)
            //{
            //    dplConsultarTabelaRelatorio.Enabled = true;

            //    mtdCarregarDblConsultarTabelaRelatorio();
            //}

            //switch (dplSelecionarBancoDados.Text)
            //{
            //    case "Principal":
            //        mtdPreencherDpl
            //            (
            //            string.Format("SELECT TOP 1 * FROM {0}", strTabelaSelecionada),
            //            ref dplConsultarCampo
            //            );
            //        break;
            //    case "Coletor":
            //        mtdPreencherDpl
            //            (
            //            string.Format("SELECT TOP (1) * FROM {0}", strTabelaSelecionada),
            //            ref dplConsultarCampo
            //            );
            //        break;
            //}
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

        protected void btnIniciarTransferenciaDadosInventarioBens_Click(object sender, EventArgs e)
        {
            try
            {
                //mtdAbortarThreads();

                switch (dplSelecionarBancoDados.SelectedItem.Text)
                {
                    case "Principal":
                        blnComandoImplementadoDeletarDadosTabelaInventarioBensPrincipal = rdbPermitirDeletarTabelaInventarioBens.Checked;
                        mtdIniciarThreadTransferirTabelaInventarioBensPrincipal();
                        break;
                    case "Coletor":
                        blnComandoImplementadoDeletarDadosTabelaInventarioBensColetor = rdbPermitirDeletarTabelaInventarioBens.Checked;
                        mtdIniciarThreadTransferirTabelaInventarioBensColetor();
                        break;
                }
            }
            catch (System.Exception ex)
            {
                string strExcecao = "btnIniciarTransferenciaDadosInventarioBens_Click: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        protected void btnPararTransferenciaDadosInventarioBens_Click(object sender, EventArgs e)
        {
            try
            {
                switch (dplSelecionarBancoDados.SelectedItem.Text)
                {
                    case "Principal":
                        mtdAbortarThreadTransferirDadosTabelaInventarioBensPrincipal();
                        break;
                    case "Coletor":
                        mtdAbortarThreadTransferirDadosTabelaInventarioBensColetor();
                        break;
                }
            }
            catch (System.Exception ex)
            {
                string strExcecao = "btnPararTransferenciaDadosInventarioBens_Click: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        public static int mtdProgresso(int NumeroParcial, int NumeroTotal)
        {
            int Progresso = (int)(((double)NumeroParcial * 100) / (double)(NumeroTotal));

            Progresso = Progresso >= 0 ? Progresso : 0;
            Progresso = Progresso < 100 ? Progresso : 99;

            return Progresso;
        }

        private void mtdFinalizarAbortoThread()
        {
            blnAbortarThreadExportarPlanilhaExcelRelatorio = false;
            blnForcarAbortarThreadExportarPlanilhaExcelRelatorio = false;

            blnAbortarThreadExportarPlanilhaExcelSapR3 = false;
            blnForcarAbortarThreadExportarPlanilhaExcelSapR3 = false;

            blnAbortarThreadPreparacaoColetorDados = false;
            blnForcarAbortarThreadPreparacaoColetorDados = false;

            blnAbortarThreadImportarDadosTabelaBensPrincipal = false;
            blnForcarAbortarThreadImportarDadosTabelaBensPrincipal = false;

            blnAbortarThreadImportarDadosTabelaCentroCustoPrincipal = false;
            blnForcarAbortarThreadImportarDadosTabelaCentroCustoPrincipal = false;

            blnAbortarThreadImportarDadosTabelaEmpregadosPrincipal = false;
            blnForcarAbortarThreadImportarDadosTabelaEmpregadosPrincipal = false;

            blnAbortarThreadTransferirDadosTabelaInventarioBensPrincipal = false;
            blnForcarAbortarThreadTransferirDadosTabelaInventarioBensPrincipal = false;

            blnAbortarThreadImportarDadosTabelaBensColetor = false;
            blnForcarAbortarThreadImportarDadosTabelaBensColetor = false;

            blnAbortarThreadImportarDadosTabelaCentroCustoColetor = false;
            blnForcarAbortarThreadImportarDadosTabelaCentroCustoColetor = false;

            blnAbortarThreadImportarDadosTabelaEmpregadosColetor = false;
            blnForcarAbortarThreadImportarDadosTabelaEmpregadosColetor = false;

            blnAbortarThreadTransferirDadosTabelaInventarioBensColetor = false;
            blnForcarAbortarThreadTransferirDadosTabelaInventarioBensColetor = false;
        }

        private void mtdFinalizarAbortoThreadsPreparacaoPrincipal()
        {
            blnAbortarThreadPreparacaoPrincipal = false;
            blnForcarAbortarThreadPreparacaoPrincipal = false;

            blnAbortarThreadImportarDadosTabelaBensColetor = false;
            blnForcarAbortarThreadImportarDadosTabelaBensColetor = false;

            blnAbortarThreadImportarDadosTabelaCentroCustoColetor = false;
            blnForcarAbortarThreadImportarDadosTabelaCentroCustoColetor = false;

            blnAbortarThreadImportarDadosTabelaEmpregadosColetor = false;
            blnForcarAbortarThreadImportarDadosTabelaEmpregadosColetor = false;

            blnAbortarThreadTransferirDadosTabelaInventarioBensColetor = false;
            blnForcarAbortarThreadTransferirDadosTabelaInventarioBensColetor = false;
        }

        private void mtdFinalizarAbortoThreadsPreparacaoColetorDados()
        {
            blnAbortarThreadPreparacaoColetorDados = false;
            blnForcarAbortarThreadPreparacaoColetorDados = false;

            blnAbortarThreadImportarDadosTabelaBensColetor = false;
            blnForcarAbortarThreadImportarDadosTabelaBensColetor = false;

            blnAbortarThreadImportarDadosTabelaCentroCustoColetor = false;
            blnForcarAbortarThreadImportarDadosTabelaCentroCustoColetor = false;

            blnAbortarThreadImportarDadosTabelaEmpregadosColetor = false;
            blnForcarAbortarThreadImportarDadosTabelaEmpregadosColetor = false;

            blnAbortarThreadTransferirDadosTabelaInventarioBensColetor = false;
            blnForcarAbortarThreadTransferirDadosTabelaInventarioBensColetor = false;
        }

        private void mtdAbortarThreads()
        {
            mtdAbortarThreadExportarPlanilhaExcelRelatorio(true);
            mtdAbortarThreadExportarPlanilhaExcelSapR3(true);
            mtdAbortarThreadPreparacaoColetorDados(true);
            mtdAbortarThreadImportarDadosTabelaBensPrincipal(true);
            mtdAbortarThreadImportarDadosTabelaBensColetor(true);
            mtdAbortarThreadImportarDadosTabelaCentroCustoPrincipal(true);
            mtdAbortarThreadImportarDadosTabelaCentroCustoColetor(true);
            mtdAbortarThreadImportarDadosTabelaEmpregadosPrincipal(true);
            mtdAbortarThreadImportarDadosTabelaEmpregadosColetor(true);
            mtdAbortarThreadTransferirDadosTabelaInventarioBensPrincipal(true);
            mtdAbortarThreadTransferirDadosTabelaInventarioBensColetor(true);
        }

        protected void btnIniciarPreparacaoColetorDados_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(Default.strArquivoTexto))
            {
                lblAviso.Text = "Processo em execução.";

                try
                {
                    //mtdAbortarThreads();

                    mtdFinalizarAbortoThreadsPreparacaoColetorDados();

                    mtdIniciarThreadPreparacaoColetorDados(true);
                }
                catch (System.Exception ex)
                {
                    string strExcecao = "btnIniciarPreparacaoColetorDados_Click: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                    // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
                }
            }
            else
            {
                lblAviso.Text = "Verifique se o endereço e o nome dos arquivos de dados estão corretos";
            }
        }

        protected void btnPararPreparacaoColetorDados_Click(object sender, EventArgs e)
        {
            try
            {
                mtdAbortarThreadPreparacaoColetorDados(true);
            }
            catch (System.Exception ex)
            {
                string strExcecao = "btnPararPreparacaoColetorDados_Click: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        protected void btnIniciarPreparacaoPrincipal_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(Default.strArquivoTexto))
            {
                lblAviso.Text = "Processo em execução.";

                try
                {
                    //mtdAbortarThreads();

                    mtdFinalizarAbortoThreadsPreparacaoPrincipal();

                    mtdIniciarThreadPreparacaoPrincipal(true);
                }
                catch (System.Exception ex)
                {
                    string strExcecao = "btnIniciarPreparacaoPrincipal_Click: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                    // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
                }
            }
            else
            {
                lblAviso.Text = "Verifique se o endereço e o nome dos arquivos de dados estão corretos";
            }
        }

        protected void btnPararPreparacaoPrincipal_Click(object sender, EventArgs e)
        {
            try
            {
                mtdAbortarThreadPreparacaoPrincipal(true);
            }
            catch (System.Exception ex)
            {
                string strExcecao = "btnPararPreparacaoPrincipal_Click: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }


        protected void btnForcarAbortoTodosProcessos_Click(object sender, EventArgs e)
        {
            mtdAbortarThreads();
        }

        //private void mtdCarregarDblConsultarTabelaRelatorio()
        //{
        //    dplConsultarTabelaRelatorio.Items.Clear();
        //    dplConsultarTabelaRelatorio.Items.Add(string.Empty);
        //    dplConsultarTabelaRelatorio.Items.Add(Default.strTabelaInventarioBens.Replace("tbl", string.Empty));
        //    dplConsultarTabelaRelatorio.Items.Add(Default.strTabelaBensEletronorte.Replace("tbl", string.Empty));
        //    dplConsultarTabelaRelatorio.Items.Add(Default.strTabelaEmpregados.Replace("tbl", string.Empty));
        //    dplConsultarTabelaRelatorio.Items.Add(Default.strTabelaCentroCusto.Replace("tbl", string.Empty));
        //    dplConsultarTabelaRelatorio.SelectedIndex = 0;
        //}

        //protected void dplConsultarTabelaRelatorio_TextChanged(object sender, EventArgs e)
        //{

        //    strTabelaSelecionada = string.Format("tbl{0}", dplConsultarTabelaRelatorio.Text);

        //    mtdPreencherDpl
        //        (
        //        string.Format("SELECT TOP 1 * FROM {0}", strTabelaSelecionada),
        //        ref dplConsultarCampo
        //        );
        //}

        public static int intGvw1LinhaSelecionada = 0;

        public static object[] objDados = null;

        //protected void gvw1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        intGvw1LinhaSelecionada = gvw1.SelectedIndex;

        //        strColunaSelecionada = gvw1.Columns[1].ToString();
        //        objDadoSelecionado = gvw1.Rows[gvw1.SelectedRow.DataItemIndex].Cells[0].Text;

        //        objDados = mtdObterDadosTabelas(strTabelaSelecionada, strColunaSelecionada, objDadoSelecionado);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        string strExcecao = "gvw1_SelectedIndexChanged: " + ex.Message;
        //            System.Diagnostics.Debug.WriteLine(strExcecao); erro;                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);

        //        lblInformacao.Text = "Houve erro ao selecionar o item.";
        //    }
        //}

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

        protected void btnFazerDownloadArquivos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/frmDownloadArquivos.aspx");
        }
    }
}