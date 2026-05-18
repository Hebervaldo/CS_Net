using System;
//using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace prjColetorDadosCSNet35
{
    public partial class frmMonitorCarregamentoDados : Form
    {
        private System.Threading.Thread ThDownloadTabelaApoio;
        private System.Threading.Thread ThDownloadTabelaInventarioBensPrincipal;
        private System.Threading.Thread ThUploadTabelaInventarioBensPrincipal;
        private delegate void SetValueCallbackDownloadTabelaApoio(int ProgressoDownloadTabelaApoio, long IteracoesDownloadTabelaApoio);
        private delegate void SetValueCallbackDownloadTabelaInventarioBensPrincipal(int ProgressoDownloadTabelaInventarioBensPrincipal, long IteracoesDownloadTabelaInventarioBensPrincipal);
        private delegate void SetValueCallbackUploadTabelaInventarioBensPrincipal(int ProgressoUploadTabelaInventarioBensPrincipal, long IteracoesUploadTabelaInventarioBensPrincipal);
        private delegate void SetValueCallbackIntermediarioUploadTabelaInventarioBensPrincipal(int ObterLinhaTabelaInventarioBens, int ObterLinhaTotalTabelaInventarioBens);

        private int intNumeroIdentificacao = -1;
        private string strNumeroIdentificacao = "N/D";

        public WebService.WebServicoBancoDados wb = new WebService.WebServicoBancoDados();

        public frmMonitorCarregamentoDados()
        {
            InitializeComponent();
        }

        private void frmMonitorCarregamentoDados_Load(object sender, EventArgs e)
        {
            mtdEnderecoWebService();
            mtdObterIp();
            mtdObterNumeroIdentificacao();

            if (cmbTabelaApoioApresentacao.Items.Count == 0)
            {
                mtdCarregarCmbTabelaApoioApresentacao();
            }

            mtdchkIgnorarCodigoEspalhamentoTabela();
            mtdForcarUploadDownloadTabela();
            mtdIteracoesContinuas();
            mtdForcarDesligamento();

            mtdCarregarCmbPrioridadeDownloadTabelaInventarioBensPrincipal();
            mtdCarregarCmbPrioridadeUploadTabelaInventario();
            mtdCarregarCmbPrioridadeDownloadTabelaApoio();

            try
            {
                if (cmbTabelaInventarioBensUpload.Items.Count == 0)
                {
                    Program.objPrincipal.mtdCarregarCmb
                        (
                            ref cmbTabelaInventarioBensUpload,
                            String.Format("SELECT TOP (0) * FROM {0}", frmPrincipal.strTabelaInventarioBens)
                        );

                    cmbTabelaInventarioBensUpload.SelectedIndex = frmPrincipal.intColunaTabelaInventarioBensIdentificacao_Inventario;
                }
            }
            catch (System.Exception ex)
            {
                string strExcecao = "frmMonitorCarregamentoDados_Load: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }

            mtdComandoCarregarLsv1();
            mtdSetarTbc1();

            mtdPrioridadeDownloadTabelaApoio();
            mtdPrioridadeDownloadTabelaInventarioBens();
            mtdPrioridadeUploadTabelaInventarioBens();

            if (btnDownloadTabelaApoio.ForeColor == Color.Green)
            {
                blnSucessoDownloadTabelaApoio = true;
                mtdIniciarThreadDownloadTabelaApoio();
            }
            else
            {
                blnSucessoDownloadTabelaApoio = false;
                mtdAbortarThreadDownloadTabelaApoio(true);
            }

            if (btnDownloadTabelaInventarioBens.ForeColor == Color.Green)
            {
                blnSucessoDownloadTabelaInventarioBensPrincipal = true;
                mtdIniciarThreadDownloadTabelaInventarioBensPrincipal();
            }
            else
            {
                blnSucessoDownloadTabelaInventarioBensPrincipal = false;
                mtdAbortarThreadDownloadTabelaInventarioBensPrincipal(true);
            }

            if (btnUploadTabelaInventarioBens.ForeColor == Color.Green)
            {
                blnSucessoUploadTabelaInventarioBensPrincipal = true;
                mtdIniciarThreadUploadTabelaInventarioBensPrincipal();
            }
            else
            {
                blnSucessoUploadTabelaInventarioBensPrincipal = false;
                mtdAbortarThreadUploadTabelaInventarioBensPrincipal(true);
            }

            mtdProgressoDownloadTabelaApoio(0, lngIteracoesDownloadTabelaApoio);
            mtdProgressoDownloadTabelaInventarioBensPrincipal(0, lngIteracoesDownloadTabelaInventarioBensPrincipal);
            mtdProgressoUploadTabelaInventarioBensPrincipal(0, lngIteracoesUploadTabelaInventarioBensPrincipal);

            //txtRegistroIteracaoDownloadTabelaApoio.Text = Convert.ToString(intPassoMaximoValido);
            //txtRegistroIteracaoDownloadTabelaInventarioBens.Text = Convert.ToString(intPassoMaximoValido);
            //txtRegistroIteracaoUploadTabelaInventarioBens.Text = Convert.ToString(intPassoMaximoValido);

            mtdIniciarThreadNotificacao();

            mtdRegistroIteracaoDownloadTabelaApoio();
            mtdRegistroIteracaoDownloadTabelaInventarioBens();
            mtdRegistroIteracaoUploadTabelaInventarioBens();
            mtdGerarPassoAutomatico();
        }

        private void mtdDownloadTabelaApoio()
        {
            if (txtIP.Text != "0 - 127.0.0.1.")
            {
                clsVerificarConexao objVerificarConexao = new clsVerificarConexao();
                string[] strEnderecoServidor = txtEnderecoWebService.Text.Split('/');
                string strEnderecoRede = string.Format("{0}", strEnderecoServidor[2]);

                if (objVerificarConexao.mtdChecarRede(strEnderecoRede))
                {
                    mtdAbortarThreadTemporizadorForcarDesligamento();

                    uint uintIntervaloBackup = frmPrincipal.uintIntervaloBackup;

                    lngIteracoesDownloadTabelaApoio = 0;

                    try
                    {
                        if (Program.objPrincipal.chkModoOtimizadoCadastro != null)
                        {
                            Program.objPrincipal.chkModoOtimizadoCadastro.Checked = false;
                        }
                    }
                    catch (System.Exception ex)
                    {
                        string strExcecao = "btnDownloadTabelaApoio_Click: " + ex.Message;
                        System.Diagnostics.Debug.WriteLine(strExcecao);
                        //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                    }

                    if (btnDownloadTabelaApoio.ForeColor == Color.Maroon)
                    {
                        //mtdObterNumeroIdentificacao(false);
                        mtdIniciarThreadManterCanalAberto();

                        frmPrincipal.uintIntervaloBackup = 0;
                        cmbPrioridadeDownloadTabelaApoio.Enabled = false;
                        mtdIniciarThreadDownloadTabelaApoio();
                    }
                    else
                    {
                        mtdAbortarThreadManterCanalAberto();

                        frmPrincipal.uintIntervaloBackup = uintIntervaloBackup;
                        cmbPrioridadeDownloadTabelaApoio.Enabled = true;
                        mtdAbortarThreadDownloadTabelaApoio(true);
                        mtdIniciarThreadForcarParada("DownloadBensEletronorte");
                        mtdIniciarThreadForcarParada("DownloadEmpregados");
                        mtdIniciarThreadForcarParada("DownloadCentroCusto");
                    }
                }
                else
                {
                    System.Windows.Forms.DialogResult msb = System.Windows.Forms.MessageBox.Show
                        (
                         "O servidor parece não está disponível.",
                         "Aviso!",
                         System.Windows.Forms.MessageBoxButtons.OK,
                         System.Windows.Forms.MessageBoxIcon.Exclamation,
                         System.Windows.Forms.MessageBoxDefaultButton.Button1
                         );
                }
            }
            else
            {
                System.Windows.Forms.DialogResult msb = System.Windows.Forms.MessageBox.Show
                    (
                     "O coletor parece não está conectado a alguma rede.",
                     "Aviso!",
                     System.Windows.Forms.MessageBoxButtons.OK,
                     System.Windows.Forms.MessageBoxIcon.Exclamation,
                     System.Windows.Forms.MessageBoxDefaultButton.Button1
                     );
            }
        }

        private void btnDownloadTabelaApoio_Click(object sender, EventArgs e)
        {
            mtdDownloadTabelaApoio();
        }

        private void mtdDownloadTabelaInventarioBens()
        {
            if (txtIP.Text != "0 - 127.0.0.1.")
            {
                clsVerificarConexao objVerificarConexao = new clsVerificarConexao();
                string[] strEnderecoServidor = txtEnderecoWebService.Text.Split('/');
                string strEnderecoRede = string.Format("{0}", strEnderecoServidor[2]);

                if (objVerificarConexao.mtdChecarRede(strEnderecoRede))
                {
                    mtdAbortarThreadTemporizadorForcarDesligamento();

                    uint uintIntervaloBackup = frmPrincipal.uintIntervaloBackup;

                    lngIteracoesDownloadTabelaInventarioBensPrincipal = 0;

                    try
                    {
                        if (Program.objPrincipal.chkModoOtimizadoCadastro != null)
                        {
                            Program.objPrincipal.chkModoOtimizadoCadastro.Checked = false;
                        }
                    }
                    catch (System.Exception ex)
                    {
                        string strExcecao = "btnDownloadTabelaInventarioBens_Click: " + ex.Message;
                        System.Diagnostics.Debug.WriteLine(strExcecao);
                        //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                    }

                    if (btnDownloadTabelaInventarioBens.ForeColor == Color.Maroon)
                    {
                        //mtdObterNumeroIdentificacao(false);
                        mtdIniciarThreadManterCanalAberto();

                        frmPrincipal.uintIntervaloBackup = 0;
                        cmbPrioridadeDownloadTabelaInventarioBens.Enabled = false;
                        blnThreadAtivadaDownloadTabelaInventarioBensPrincipal = true;
                        mtdIniciarThreadDownloadTabelaInventarioBensPrincipal();
                    }
                    else
                    {
                        mtdAbortarThreadManterCanalAberto();

                        frmPrincipal.uintIntervaloBackup = uintIntervaloBackup;
                        cmbPrioridadeDownloadTabelaInventarioBens.Enabled = true;
                        blnThreadAtivadaDownloadTabelaInventarioBensPrincipal = false;
                        mtdAbortarThreadDownloadTabelaInventarioBensPrincipal(true);
                        mtdIniciarThreadForcarParada("DownloadInventarioBens");
                    }
                }
                else
                {
                    System.Windows.Forms.DialogResult msb = System.Windows.Forms.MessageBox.Show
                        (
                         "O servidor parece não está disponível.",
                         "Aviso!",
                         System.Windows.Forms.MessageBoxButtons.OK,
                         System.Windows.Forms.MessageBoxIcon.Exclamation,
                         System.Windows.Forms.MessageBoxDefaultButton.Button1
                         );
                }
            }
            else
            {
                System.Windows.Forms.DialogResult msb = System.Windows.Forms.MessageBox.Show
                    (
                     "O coletor parece não está conectado a alguma rede.",
                     "Aviso!",
                     System.Windows.Forms.MessageBoxButtons.OK,
                     System.Windows.Forms.MessageBoxIcon.Exclamation,
                     System.Windows.Forms.MessageBoxDefaultButton.Button1
                     );
            }
        }

        private void btnDownloadTabelaInventarioBens_Click(object sender, EventArgs e)
        {
            mtdDownloadTabelaInventarioBens();
        }

        private void mtdUploadTabelaInventarioBensPrincipal_()
        {
            if (txtIP.Text != "0 - 127.0.0.1.")
            {
                clsVerificarConexao objVerificarConexao = new clsVerificarConexao();
                string[] strEnderecoServidor = txtEnderecoWebService.Text.Split('/');
                string strEnderecoRede = string.Format("{0}", strEnderecoServidor[2]);

                if (objVerificarConexao.mtdChecarRede(strEnderecoRede))
                {
                    mtdAbortarThreadTemporizadorForcarDesligamento();

                    uint uintIntervaloBackup = frmPrincipal.uintIntervaloBackup;

                    lngIteracoesUploadTabelaInventarioBensPrincipal = 0;

                    try
                    {
                        if (Program.objPrincipal.chkModoOtimizadoCadastro != null)
                        {
                            Program.objPrincipal.chkModoOtimizadoCadastro.Checked = false;
                        }
                    }
                    catch (System.Exception ex)
                    {
                        string strExcecao = "btnUploadTabelaInventarioBensPrincipal_Click: " + ex.Message;
                        System.Diagnostics.Debug.WriteLine(strExcecao);
                        //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                    }

                    if (btnUploadTabelaInventarioBens.ForeColor == Color.Maroon)
                    {
                        //mtdObterNumeroIdentificacao(false);
                        mtdIniciarThreadManterCanalAberto();

                        mtdIniciarThreadResetarContadorLinhaAcumuladoTotalTabelaInventarioBens();

                        frmPrincipal.uintIntervaloBackup = 0;
                        cmbPrioridadeUploadTabelaInventarioBens.Enabled = false;
                        blnSucessoUploadTabelaInventarioBensPrincipal = true;
                        mtdIniciarThreadUploadTabelaInventarioBensPrincipal();
                    }
                    else
                    {
                        mtdAbortarThreadManterCanalAberto();

                        frmPrincipal.uintIntervaloBackup = uintIntervaloBackup;
                        cmbPrioridadeUploadTabelaInventarioBens.Enabled = true;
                        blnSucessoUploadTabelaInventarioBensPrincipal = false;
                        mtdAbortarThreadUploadTabelaInventarioBensPrincipal(true);
                        mtdIniciarThreadForcarParada("UploadInventarioBens");
                    }
                }
                else
                {
                    System.Windows.Forms.DialogResult msb = System.Windows.Forms.MessageBox.Show
                        (
                         "O servidor parece não está disponível.",
                         "Aviso!",
                         System.Windows.Forms.MessageBoxButtons.OK,
                         System.Windows.Forms.MessageBoxIcon.Exclamation,
                         System.Windows.Forms.MessageBoxDefaultButton.Button1
                         );
                }
            }
            else
            {
                System.Windows.Forms.DialogResult msb = System.Windows.Forms.MessageBox.Show
                    (
                     "O coletor parece não está conectado a alguma rede.",
                     "Aviso!",
                     System.Windows.Forms.MessageBoxButtons.OK,
                     System.Windows.Forms.MessageBoxIcon.Exclamation,
                     System.Windows.Forms.MessageBoxDefaultButton.Button1
                     );
            }
        }

        private void btnUploadTabelaInventarioBensPrincipal_Click(object sender, EventArgs e)
        {
            mtdUploadTabelaInventarioBensPrincipal_();
        }

        private void mtdProgressoDownloadTabelaApoio(int ProgressoDownloadTabelaApoio, long IteracoesDownloadTabelaApoio)
        {
            if (this.InvokeRequired)
            {
                SetValueCallbackDownloadTabelaApoio f = new SetValueCallbackDownloadTabelaApoio(this.SetValueDownloadTabelaApoio);
                this.Invoke(f, new object[] { (ProgressoDownloadTabelaApoio), (IteracoesDownloadTabelaApoio) });
            }
            else
            {
                //txtRegistroIteracaoDownloadTabelaApoio.Text = Convert.ToString(intPassoDownloadTabelaApoio);

                if (blnProgressoCalcularCodigoEspalhamento)
                {
                    blnSucessoDownloadTabelaApoio = false;

                    this.prgDownloadTabelaApoio.Value = Convert.ToInt32(intProgressoCalcularCodigoEspalhamento);
                    lblProgressoDownloadTabelaApoio.Text = string.Format
                        (
                        "Progresso: {0}% - Hash Code",
                        intProgressoCalcularCodigoEspalhamento
                        );
                }
                else
                {
                    if (ProgressoDownloadTabelaApoio >= 0 & ProgressoDownloadTabelaApoio <= 100)
                    {
                        this.prgDownloadTabelaApoio.Value = Convert.ToInt32(ProgressoDownloadTabelaApoio);
                        lblProgressoDownloadTabelaApoio.Text = string.Format
                            (
                            "Progresso: {0}% - Iterações: {1}",
                            ProgressoDownloadTabelaApoio,
                            IteracoesDownloadTabelaApoio
                            );
                    }
                }

                if (blnThreadAtivadaDownloadTabelaApoio)
                {
                    btnDownloadTabelaApoio.ForeColor = System.Drawing.Color.Green;
                    cmbPrioridadeDownloadTabelaApoio.Enabled = false;
                }
                else
                {
                    btnDownloadTabelaApoio.ForeColor = System.Drawing.Color.Maroon;
                    cmbPrioridadeDownloadTabelaApoio.Enabled = true;
                }

                if (blnSucessoDownloadTabelaApoio)
                {
                    lblProgressoDownloadTabelaApoio.ForeColor = System.Drawing.Color.Green;

                    btnDownloadTabelaApoio.Text = string.Format
                        (
                        "&Download - Restam: {1:0} min.",
                        btnDownloadTabelaApoio.Text,
                        dblTempoRestanteMilisegundosDownloadTabelaApoio / (60 * 1000)
                        );
                }
                else
                {
                    lblProgressoDownloadTabelaApoio.ForeColor = System.Drawing.Color.Maroon;

                    btnDownloadTabelaApoio.Text = "&Download";
                }

                if (ThDownloadTabelaApoio != null)
                {
                    //if (ThDownloadTabelaApoio.ThreadState == System.Threading.ThreadState.Running)
                    //{
                    try
                    {
                        ThDownloadTabelaApoio.Priority = Program.objPrincipal.mtdConverterPrioridadeThread(cmbPrioridadeDownloadTabelaApoio.Text);
                    }
                    catch (System.Exception ex)
                    {
                        string strExcecao = "mtdProgressoDownloadTabelaApoio: " + ex.Message;
                        System.Diagnostics.Debug.WriteLine(strExcecao);
                        //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                    }
                    //}
                }
            }
        }

        private void mtdProgressoDownloadTabelaInventarioBensPrincipal(int ProgressoDownloadTabelaInventarioBensPrincipal, long IteracoesDownloadTabelaInventarioBensPrincipal)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    SetValueCallbackDownloadTabelaInventarioBensPrincipal f = new SetValueCallbackDownloadTabelaInventarioBensPrincipal(this.SetValueDownloadTabelaInventarioBensPrincipal);
                    this.Invoke(f, new object[] { (ProgressoDownloadTabelaInventarioBensPrincipal), (IteracoesDownloadTabelaInventarioBensPrincipal) });
                }
                else
                {
                    //txtRegistroIteracaoDownloadTabelaInventarioBens.Text = Convert.ToString(intPassoDownloadTabelaInventarioBensPrincipal);

                    if (ProgressoDownloadTabelaInventarioBensPrincipal >= 0 & ProgressoDownloadTabelaInventarioBensPrincipal <= 100)
                    {
                        this.prgDownloadTabelaInventarioBens.Value = Convert.ToInt32(ProgressoDownloadTabelaInventarioBensPrincipal);
                        lblProgressoDownloadTabelaInventarioBens.Text = string.Format
                            (
                            "Progresso: {0}% - Iterações: {1}",
                            ProgressoDownloadTabelaInventarioBensPrincipal,
                            IteracoesDownloadTabelaInventarioBensPrincipal
                            );
                    }

                    if (blnThreadAtivadaDownloadTabelaInventarioBensPrincipal)
                    {
                        btnDownloadTabelaInventarioBens.ForeColor = System.Drawing.Color.Green;
                        cmbPrioridadeDownloadTabelaInventarioBens.Enabled = false;
                    }
                    else
                    {
                        btnDownloadTabelaInventarioBens.ForeColor = System.Drawing.Color.Maroon;
                        cmbPrioridadeDownloadTabelaInventarioBens.Enabled = true;
                    }

                    if (blnSucessoDownloadTabelaInventarioBensPrincipal)
                    {
                        lblProgressoDownloadTabelaInventarioBens.ForeColor = System.Drawing.Color.Green;

                        btnDownloadTabelaInventarioBens.Text = string.Format
                            (
                            "&Download - Restam: {1:0} min.",
                            btnDownloadTabelaInventarioBens.Text,
                            dblTempoRestanteMilisegundosDownloadTabelaInventarioBensPrincipal / (60 * 1000)
                            );
                    }
                    else
                    {
                        lblProgressoDownloadTabelaInventarioBens.ForeColor = System.Drawing.Color.Maroon;

                        btnDownloadTabelaInventarioBens.Text = "&Download";
                    }
                }

                if (ThDownloadTabelaInventarioBensPrincipal != null)
                {
                    //if (ThDownloadTabelaInventarioBensPrincipal.ThreadState == System.Threading.ThreadState.Running)
                    //{
                    try
                    {
                        ThDownloadTabelaInventarioBensPrincipal.Priority = Program.objPrincipal.mtdConverterPrioridadeThread(cmbPrioridadeDownloadTabelaInventarioBens.Text);
                    }
                    catch (System.Exception ex)
                    {
                        string strExcecao = "mtdProgressoDownloadTabelaInventarioBensPrincipal: " + ex.Message;
                        System.Diagnostics.Debug.WriteLine(strExcecao);
                        //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                    }
                    //}
                }
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdProgressoDownloadTabelaInventarioBensPrincipal: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void mtdProgressoUploadTabelaInventarioBensPrincipal(int ProgressoUploadTabelaInventarioBensPrincipal, long IteracoesUploadTabelaInventarioBensPrincipal)
        {
            if (this.InvokeRequired)
            {
                SetValueCallbackUploadTabelaInventarioBensPrincipal f = new SetValueCallbackUploadTabelaInventarioBensPrincipal(this.SetValueUploadTabelaInventarioBensPrincipal);
                this.Invoke(f, new object[] { (ProgressoUploadTabelaInventarioBensPrincipal), (IteracoesUploadTabelaInventarioBensPrincipal) });
            }
            else
            {
                //txtRegistroIteracaoUploadTabelaInventarioBens.Text = Convert.ToString(intPassoUploadTabelaInventarioBensPrincipal);

                if (ProgressoUploadTabelaInventarioBensPrincipal >= 0 & ProgressoUploadTabelaInventarioBensPrincipal <= 100)
                {
                    this.prgUploadTabelaInventarioBens.Value = Convert.ToInt32(ProgressoUploadTabelaInventarioBensPrincipal);
                    lblProgressoUploadTabelaInventarioBens.Text = string.Format
                        (
                        "Pr.: {0}% - Iter.: {1} - Seg.: {2}/{3}.",
                        ProgressoUploadTabelaInventarioBensPrincipal,
                        IteracoesUploadTabelaInventarioBensPrincipal,
                        lngSegmentoUploadTabelaInventarioBensPrincipal,
                        lngMaxSegmentoUploadTabelaInventarioBensPrincipal - 1
                        );
                }

                if (blnThreadAtivadaUploadTabelaInventarioBensPrincipal)
                {
                    btnUploadTabelaInventarioBens.ForeColor = System.Drawing.Color.Green;
                    cmbPrioridadeUploadTabelaInventarioBens.Enabled = false;
                }
                else
                {
                    btnUploadTabelaInventarioBens.ForeColor = System.Drawing.Color.Maroon;
                    cmbPrioridadeUploadTabelaInventarioBens.Enabled = true;
                }

                if (blnSucessoUploadTabelaInventarioBensPrincipal)
                {
                    lblProgressoUploadTabelaInventarioBens.ForeColor = System.Drawing.Color.Green;

                    btnUploadTabelaInventarioBens.Text = string.Format
                        (
                        "&Upload - Restam: {1:0} min.",
                        btnUploadTabelaInventarioBens.Text,
                        dblTempoRestanteMilisegundosUploadTabelaInventarioBensPrincipal / (60 * 1000)
                        );
                }
                else
                {
                    lblProgressoUploadTabelaInventarioBens.ForeColor = System.Drawing.Color.Maroon;

                    btnUploadTabelaInventarioBens.Text = "&Upload";
                }

                if (ThUploadTabelaInventarioBensPrincipal != null)
                {
                    //if (ThUploadTabelaInventarioBensPrincipal.ThreadState == System.Threading.ThreadState.Running)
                    //{
                    try
                    {
                        ThUploadTabelaInventarioBensPrincipal.Priority = Program.objPrincipal.mtdConverterPrioridadeThread(cmbPrioridadeUploadTabelaInventarioBens.Text);
                    }
                    catch (System.Exception ex)
                    {
                        string strExcecao = "mtdProgressoUploadTabelaInventarioBensPrincipal: " + ex.Message;
                        System.Diagnostics.Debug.WriteLine(strExcecao);
                        //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                    }
                    //}
                }
            }
        }

        private void mtdProgressoIntermediarioUploadTabelaInventarioBensPrincipal(int ObterLinhaTabelaInventarioBens, int ObterLinhaTotalTabelaInventarioBens)
        {
            if (this.InvokeRequired)
            {
                SetValueCallbackIntermediarioUploadTabelaInventarioBensPrincipal f = new SetValueCallbackIntermediarioUploadTabelaInventarioBensPrincipal(this.SetValueIntermediarioUploadTabelaInventarioBensPrincipal);
                this.Invoke(f, new object[] { (ObterLinhaTabelaInventarioBens), (ObterLinhaTotalTabelaInventarioBens) });
            }
            else
            {
                int intProgressoIntermediarioUploadTabelaInventarioBensPrincipal = System.Convert.ToInt32(ObterLinhaTotalTabelaInventarioBens != 0 ? ((100 * ObterLinhaTabelaInventarioBens) / ObterLinhaTotalTabelaInventarioBens) : 0);

                if (intProgressoIntermediarioUploadTabelaInventarioBensPrincipal >= 0 & intProgressoIntermediarioUploadTabelaInventarioBensPrincipal <= 100)
                {
                    this.prgIntermediarioUploadTabelaInventarioBens.Value = Convert.ToInt32(intProgressoIntermediarioUploadTabelaInventarioBensPrincipal);
                    this.lblIntermediarioUploadTabelaInventarioBens.Text = string.Format
                        (
                        "N.: {0} - T.: {1} - P.: {2}% - Ac.: {3} - Is.: {4} - At.: {5} - In.: {6} - S.: {7}.",
                        intObterLinhaTabelaInventarioBens,
                        intObterLinhaTotalTabelaInventarioBens,
                        intProgressoIntermediarioUploadTabelaInventarioBensPrincipal,
                        intObterLinhaAcumuladoTotalTabelaInventarioBens,
                        intObterNumeroItensInseridos,
                        intObterNumeroItensAtualizados,
                        intObterNumeroItensInalterados,
                        intObterNumeroItensInseridos + intObterNumeroItensAtualizados + intObterNumeroItensInalterados
                        );
                }
            }
        }

        private int intPassoDownloadTabelaApoio = 10;
        private int intPassoDownloadTabelaInventarioBensPrincipal = 10;
        private int intPassoUploadTabelaInventarioBensPrincipal = 10;

        private int intPassoMaximoValido = 10;
        private int intPassoMinimoInvalido = 100;

        private void mtdGerarPasso(ref int Passo, bool PassoValido)
        {
            if (Passo < 1)
            {
                Passo = 1;
            }

            if (PassoValido)
            {
                if (blnGerarPassoAutomatico)
                {
                    Passo = Passo * 3;
                }
                intPassoMaximoValido = Passo;
            }
            else
            {
                Passo = Passo / 2;
                if (Passo < 1)
                {
                    Passo = 1;
                }
                intPassoMinimoInvalido = Passo;
            }

            objRegistroWindows.mtdSalvarDadosRegistro
            (
            Microsoft.Win32.Registry.CurrentUser,
            "Software",
            "Eletronorte",
            "ColetorDados",
            "RegistroIteracaoDownloadTabelaApoio",
            intPassoDownloadTabelaApoio.ToString(),
            Microsoft.Win32.RegistryValueKind.String
            );

            objRegistroWindows.mtdSalvarDadosRegistro
            (
            Microsoft.Win32.Registry.CurrentUser,
            "Software",
            "Eletronorte",
            "ColetorDados",
            "RegistroIteracaoDownloadTabelaInventarioBens",
            intPassoDownloadTabelaInventarioBensPrincipal.ToString(),
            Microsoft.Win32.RegistryValueKind.String
            );

            objRegistroWindows.mtdSalvarDadosRegistro
            (
            Microsoft.Win32.Registry.CurrentUser,
            "Software",
            "Eletronorte",
            "ColetorDados",
            "RegistroIteracaoUploadTabelaInventarioBens",
            intPassoUploadTabelaInventarioBensPrincipal.ToString(),
            Microsoft.Win32.RegistryValueKind.String
            );
        }

        private static object Locktmr1_Tick = new object();

        private void tmr1_Tick(object sender, EventArgs e)
        {
            lock (Locktmr1_Tick)
            {
                mtdProgressoDownloadTabelaApoio(intProgressoDownloadTabelaApoio, lngIteracoesDownloadTabelaApoio);
                mtdProgressoDownloadTabelaInventarioBensPrincipal(intProgressoDownloadTabelaInventarioBensPrincipal, lngIteracoesDownloadTabelaInventarioBensPrincipal);
                mtdProgressoUploadTabelaInventarioBensPrincipal(intProgressoUploadTabelaInventarioBensPrincipal, lngIteracoesUploadTabelaInventarioBensPrincipal);
                mtdProgressoIntermediarioUploadTabelaInventarioBensPrincipal(intObterLinhaTabelaInventarioBens, intObterLinhaTotalTabelaInventarioBens);

                //if (blnEnderecoWebService_TextChanged & blnEnderecoWebService_LostFocus)
                //{
                //    blnEnderecoWebService_TextChanged = false;
                //    blnEnderecoWebService_LostFocus = false;
                //}

                if (blnEnderecoWebService_LostFocus)
                {
                    blnEnderecoWebService_LostFocus = false;
                }

                if (!this.InvokeRequired)
                {
                    mtdPreencherVetorLsv1ContarTotalBens();

                    txtNumeroIdentificacao.Text = strNumeroIdentificacao;
                    mtdObterIp();

                    //mtdIniciarThreadManterCanalAberto();

                    if (blnThreadAtivadaDownloadTabelaApoio)
                    {
                        cmbTabelaApoioApresentacao.Enabled = false;
                        cmbTabelaApoioApresentacao.SelectedIndex = intContadorTabelaApoioApresentacao;
                    }
                    else
                    {
                        cmbTabelaApoioApresentacao.Enabled = true;
                    }

                    lblIntermediarioUploadTabelaInventarioBensCampo.Text = CampoSelecionador;
                    lblIntermediarioUploadTabelaInventarioBensDado.Text = DadoSelecionador.Replace("%", string.Empty);
                }
            }
            System.Threading.Thread.Sleep(1);
        }

        private void mtdManterCanalAberto()
        {
            if (intNumeroIdentificacao >= 0)
            {
                try
                {
                    wb.mtdManterCanalAberto(intNumeroIdentificacao);
                }
                catch (System.Exception ex)
                {
                    string strExcecao = "mtdManterCanalAberto: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                    //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                }
            }
            else
            {
                mtdObterNumeroIdentificacao(true);
            }
        }

        private string strForcarParada = string.Empty;

        private void mtdForcarParada()
        {
            try
            {
                switch (strForcarParada)
                {
                    case "DownloadBensEletronorte":
                        wb.mtdForcarParadagetTabelaBensEletronorteMobile(intNumeroIdentificacao);
                        break;
                    case "DownloadEmpregados":
                        wb.mtdForcarParadagetTabelaEmpregadosMobile(intNumeroIdentificacao);
                        break;
                    case "DownloadCentroCusto":
                        wb.mtdForcarParadagetTabelaCentroCustoMobile(intNumeroIdentificacao);
                        break;
                    case "DownloadInventarioBens":
                        wb.mtdForcarParadagetTabelaInventarioBensMobile(intNumeroIdentificacao);
                        break;
                    case "UploadInventarioBens":
                        wb.mtdForcarParadasetTabelaInventarioBens(intNumeroIdentificacao);
                        break;
                }
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdForcarParada: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void mtdResetarContadorLinhaAcumuladoTotalTabelaInventarioBens()
        {
            try
            {
                wb.mtdResetarContadorLinhaAcumuladoTotalTabelaInventarioBens(intNumeroIdentificacao);
                wb.Abort();
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdResetarContadorLinhaAcumuladoTotalTabelaInventarioBens: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        public void mtdEnderecoWebService()
        {
            mtdEnderecoWebService(false);
        }

        public void mtdEnderecoWebService(bool PermitirMultiThread)
        {
            string strEnderecoWebService = string.Empty;
            try
            {
                if (PermitirMultiThread)
                {
                    strEnderecoWebService = objRegistroWindows.mtdObterDadosRegistro
                        (
                        Microsoft.Win32.Registry.CurrentUser,
                        "Software",
                        "Eletronorte",
                        "ColetorDados",
                        "EnderecoWebService"
                        ).ToString();
                    wb.Url = strEnderecoWebService;

                }
                else
                {
                    txtEnderecoWebService.Text = objRegistroWindows.mtdObterDadosRegistro
                       (
                       Microsoft.Win32.Registry.CurrentUser,
                       "Software",
                       "Eletronorte",
                       "ColetorDados",
                       "EnderecoWebService"
                       ).ToString();
                    wb.Url = txtEnderecoWebService.Text;
                }
            }
            catch (System.Exception ex)
            {
                if (PermitirMultiThread)
                {
                    objRegistroWindows.mtdSalvarDadosRegistro
                        (
                        Microsoft.Win32.Registry.CurrentUser,
                        "Software",
                        "Eletronorte",
                        "ColetorDados",
                        "EnderecoWebService",
                        strEnderecoWebService,
                        Microsoft.Win32.RegistryValueKind.String
                        );
                    strEnderecoWebService = wb.Url;
                }
                else
                {
                    objRegistroWindows.mtdSalvarDadosRegistro
                        (
                        Microsoft.Win32.Registry.CurrentUser,
                        "Software",
                        "Eletronorte",
                        "ColetorDados",
                        "EnderecoWebService",
                        txtEnderecoWebService.Text,
                        Microsoft.Win32.RegistryValueKind.String
                        );
                    txtEnderecoWebService.Text = wb.Url;
                }
                string strExcecao = "mtdAtualizarOtimizado: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        public void mtdObterNumeroIdentificacao()
        {
            mtdObterNumeroIdentificacao(true, -1);
        }

        public void mtdObterNumeroIdentificacao(bool VerificarCondicao)
        {
            mtdObterNumeroIdentificacao(VerificarCondicao, -1);
        }

        public void mtdObterNumeroIdentificacao(int TempoSaida)
        {
            mtdObterNumeroIdentificacao(true, TempoSaida);
        }

        private void mtdObterNumeroIdentificacao(bool VerificarCondicao, int TempoSaida)
        {
            try
            {
                if (!VerificarCondicao | intNumeroIdentificacao == -1)
                {
                    intNumeroIdentificacao = wb.mtdGerarNumeroIdentificacao();
                    strNumeroIdentificacao = intNumeroIdentificacao.ToString();

                    wb.Timeout = TempoSaida;

                    wb.Abort();
                }
            }
            catch (System.Exception ex)
            {
                intNumeroIdentificacao = -1;
                strNumeroIdentificacao = "N/D";

                string strExcecao = "mtdObterNumeroIdentificacao: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        public void mtdObterIp()
        {
            txtIP.Text = strIP;
        }

        //private bool blnEnderecoWebService_TextChanged = false;

        private bool blnEnderecoWebService_LostFocus = false;

        private clsRegistroWindows objRegistroWindows = new clsRegistroWindows();

        private void txtEnderecoWebService_LostFocus(object sender, EventArgs e)
        {
            try
            {
                objRegistroWindows.mtdSalvarDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "ColetorDados",
                    "EnderecoWebService",
                    txtEnderecoWebService.Text,
                    Microsoft.Win32.RegistryValueKind.String
                    );
                wb.Url = txtEnderecoWebService.Text;
            }
            catch (System.Exception ex)
            {
                string strExcecao = "txtEnderecoWebService_TextChanged: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }

            mtdObterNumeroIdentificacao(true);

            blnEnderecoWebService_LostFocus = true;
        }

        private string mtdDefinirStringConexao(string BancoDados, ref clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional)
        {
            string strStringConexao = string.Empty;

            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados();

            switch (BancoDados)
            {
                case "Coletor":
                    TipoSistemaGerenciadorBancoDadosRelacional = clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE;

                    strStringConexao = objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                            (
                            clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                            frmPrincipal.strBaseDadosColetor,
                            frmPrincipal.strSenhaColetor
                            );
                    break;
            }

            objImplementacaoBancoDados.Dispose();

            return strStringConexao;
        }

        private int mtdObterNumeroLinhas(string BancoDados, string Tabela, string CampoSelecionador, object Dado)
        {
            int saida = 0;

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexao = mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

            switch (BancoDados)
            {
                case "Coletor":
                    objImplementacaoBancoDados.mtdSelecionarDadosParametroComandoSQLServerCE(0, "*", Tabela, CampoSelecionador, "LIKE", Dado);
                    break;
            }
            saida = objImplementacaoBancoDados.mtdNumeroLinhas();

            objImplementacaoBancoDados.Dispose();

            return saida;
        }

        private bool mtdVerificarExistenciaRegistro(string BancoDados, string Tabela, string CampoSelecionador, object Dado)
        {
            bool saida = false;

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexao = mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

            switch (BancoDados)
            {
                case "Coletor":
                    objImplementacaoBancoDados.mtdSelecionarDadosParametroComandoSQLServerCE(1, "*", Tabela, CampoSelecionador, "LIKE", Dado);
                    break;
            }

            objImplementacaoBancoDados.mtdDefinirLeitorDados();
            saida = objImplementacaoBancoDados.mtdProximoRegistro();

            objImplementacaoBancoDados.Dispose();

            return saida;
        }

        private bool mtdVerificarDataMaisAtualAjustadorDadosInventarioBensTabelaInventarioBens
            (
            System.Data.DataSet AjustadorDados,
            int linha,
            int coluna,
            string BancoDados,
            string CampoSelecionador,
            object Dado
            )
        {
            bool saida = false;

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexao = mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

            switch (BancoDados)
            {
                case "Coletor":
                    objImplementacaoBancoDados.mtdSelecionarDadosParametroComandoSQLServerCE(0, "*", frmPrincipal.strTabelaInventarioBens, CampoSelecionador, "LIKE", Dado);
                    break;
            }

            objImplementacaoBancoDados.mtdDefinirLeitorDados();
            objImplementacaoBancoDados.mtdProximoRegistro();

            if
                (
                System.Convert.ToDateTime(AjustadorDados.Tables[0].Rows[linha][coluna]).Ticks
                >
                System.Convert.ToDateTime(objImplementacaoBancoDados.mtdObterValorRegistro(coluna)).Ticks
                )
            {
                saida = true;
            }
            else
            {
                saida = false;
            }

            objImplementacaoBancoDados.Dispose();

            return saida;
        }

        private object objLockCalcularCodigoEspalhamento = new object();

        private bool blnProgressoCalcularCodigoEspalhamento = false;
        private int intProgressoCalcularCodigoEspalhamento = 0;

        public long mtdCalcularCodigoEspalhamento(string BancoDados, string Tabela, string[] Campos, string CampoSelecionador, object Dado)
        {
            lock (objLockCalcularCodigoEspalhamento)
            {
                long saida = 0;

                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
                string strConexao = mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
                clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

                switch (BancoDados)
                {
                    case "Coletor":
                        objImplementacaoBancoDados.mtdSelecionarDadosParametroComandoSQLServerCE(0, Campos, Tabela, CampoSelecionador, "LIKE", Dado);
                        break;
                }

                int numLinhas = objImplementacaoBancoDados.mtdNumeroLinhas();
                objImplementacaoBancoDados.mtdDefinirLeitorDados();
                int numColunas = objImplementacaoBancoDados.mtdNumeroColunas();

                int linha = 0;

                blnProgressoCalcularCodigoEspalhamento = false;
                intProgressoCalcularCodigoEspalhamento = 0;

                while (objImplementacaoBancoDados.mtdProximoRegistro())
                {
                    System.Threading.Thread.Sleep(1);

                    for (int coluna = 0; coluna <= numColunas - 1; coluna++)
                    {
                        System.Threading.Thread.Sleep(1);

                        saida = saida ^ mtdObterCodigoEspalhamento(objImplementacaoBancoDados.mtdObterValorRegistro(coluna).ToString());
                    }

                    linha++;
                    blnProgressoCalcularCodigoEspalhamento = true;
                    intProgressoCalcularCodigoEspalhamento = (int)(((double)linha * 100) / (double)numLinhas);
                }

                objImplementacaoBancoDados.Dispose();

                blnProgressoCalcularCodigoEspalhamento = false;
                intProgressoCalcularCodigoEspalhamento = 100;

                return saida;
            }
        }

        private bool blnProgressoCalcularCodigoEspalhamentoTabelaInventarioBens = false;
        private int intProgressoCalcularCodigoEspalhamentoTabelaInventarioBens = 0;

        public long mtdCalcularCodigoEspalhamentoTabelaInventarioBens(string BancoDados, string CampoSelecionador, object Dado)
        {
            lock (objLockCalcularCodigoEspalhamento)
            {
                long saida = 0;
                string Tabela = frmPrincipal.strTabelaInventarioBens;

                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
                string strConexao = mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
                clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

                switch (BancoDados)
                {
                    //case "Principal":
                    //    objImplementacaoBancoDados.mtdSelecionarDadosParametroComandoOleDb(0, "*", Tabela, CampoSelecionador, "LIKE", Dado);
                    //    break;
                    case "Coletor":
                        objImplementacaoBancoDados.mtdSelecionarDadosParametroComandoSQLServerCE(0, "*", Tabela, CampoSelecionador, "LIKE", Dado);
                        break;
                }

                int numLinhas = objImplementacaoBancoDados.mtdNumeroLinhas();
                objImplementacaoBancoDados.mtdDefinirLeitorDados();
                int numColunas = objImplementacaoBancoDados.mtdNumeroColunas();

                int linha = 0;

                blnProgressoCalcularCodigoEspalhamentoTabelaInventarioBens = false;
                intProgressoCalcularCodigoEspalhamentoTabelaInventarioBens = 0;

                while (objImplementacaoBancoDados.mtdProximoRegistro())
                {
                    System.Threading.Thread.Sleep(1);

                    for (int coluna = 1; coluna <= numColunas - 1; coluna++)
                    {
                        System.Threading.Thread.Sleep(1);

                        switch (coluna)
                        {
                            case 1:
                                saida = saida ^ mtdObterCodigoEspalhamento
                                    (
                                    System.Convert.ToString
                                    (
                                    System.Convert.ToDateTime
                                    (
                                    objImplementacaoBancoDados.mtdObterValorRegistro(coluna)
                                    ).Ticks
                                    )
                                    );
                                break;
                            case 15:
                                saida = saida ^ mtdObterCodigoEspalhamento(string.Empty);
                                break;
                            default:
                                saida = saida ^ mtdObterCodigoEspalhamento(objImplementacaoBancoDados.mtdObterValorRegistro(coluna).ToString());
                                break;
                        }
                    }

                    linha++;
                    blnProgressoCalcularCodigoEspalhamentoTabelaInventarioBens = true;
                    intProgressoCalcularCodigoEspalhamentoTabelaInventarioBens = (int)(((double)linha * 100) / (double)numLinhas);
                }

                blnProgressoCalcularCodigoEspalhamentoTabelaInventarioBens = false;
                intProgressoCalcularCodigoEspalhamentoTabelaInventarioBens = 100;

                objImplementacaoBancoDados.Dispose();

                return saida;
            }
        }

        private bool blnProgressoCalcularCodigoEspalhamentoAjustadorDados = false;
        private int intProgressoCalcularCodigoEspalhamentoAjustadorDados = 0;

        public long mtdCalcularCodigoEspalhamentoAjustadorDados(System.Data.DataSet AjustadorDados)
        {
            lock (objLockCalcularCodigoEspalhamento)
            {
                long saida = 0;

                int numLinhas = AjustadorDados.Tables[0].Rows.Count;

                blnProgressoCalcularCodigoEspalhamentoAjustadorDados = false;
                intProgressoCalcularCodigoEspalhamentoAjustadorDados = 0;

                for (int linha = 1; linha <= numLinhas - 1; linha++)
                {
                    System.Threading.Thread.Sleep(1);

                    saida = saida ^ mtdCalcularCodigoEspalhamentoAjustadorDadosTabelaInventarioBensLinha(AjustadorDados, linha);


                    linha++;
                    blnProgressoCalcularCodigoEspalhamentoAjustadorDados = true;
                    intProgressoCalcularCodigoEspalhamentoAjustadorDados = (int)(((double)linha * 100) / (double)numLinhas);
                }

                blnProgressoCalcularCodigoEspalhamentoAjustadorDados = false;
                intProgressoCalcularCodigoEspalhamentoAjustadorDados = 100;

                return saida;
            }
        }

        public long mtdCalcularCodigoEspalhamentoAjustadorDadosLinha(System.Data.DataSet AjustadorDados, int linha)
        {
            lock (objLockCalcularCodigoEspalhamento)
            {
                long saida = 0;

                int numColunas = AjustadorDados.Tables[0].Columns.Count;

                for (int coluna = 0; coluna <= numColunas - 1; coluna++)
                {
                    System.Threading.Thread.Sleep(1);

                    saida = saida ^ mtdObterCodigoEspalhamento(AjustadorDados.Tables[0].Rows[linha][coluna].ToString());
                }

                return saida;
            }
        }

        public long mtdCalcularCodigoEspalhamentoAjustadorDadosTabelaInventarioBensLinha(System.Data.DataSet AjustadorDados, int linha)
        {
            lock (objLockCalcularCodigoEspalhamento)
            {
                long saida = 0;

                int numColunas = AjustadorDados.Tables[0].Columns.Count;

                for (int coluna = 1; coluna <= numColunas - 1; coluna++)
                {
                    System.Threading.Thread.Sleep(1);

                    switch (coluna)
                    {
                        case 1:
                            saida = saida ^ mtdObterCodigoEspalhamento
                                (
                                System.Convert.ToString
                                (
                                System.Convert.ToDateTime
                                (
                                AjustadorDados.Tables[0].Rows[linha][coluna]
                                ).Ticks
                                )
                                );
                            break;
                        case 15:
                            saida = saida ^ mtdObterCodigoEspalhamento(string.Empty);
                            break;
                        default:
                            saida = saida ^ mtdObterCodigoEspalhamento(AjustadorDados.Tables[0].Rows[linha][coluna].ToString());
                            break;
                    }
                }

                return saida;
            }
        }

        private long mtdObterCodigoEspalhamento(string Dado)
        {
            lock (objLockCalcularCodigoEspalhamento)
            {
                long saida = 0;

                System.Security.Cryptography.HashAlgorithm algorithm = System.Security.Cryptography.SHA1.Create();
                Byte[] vetData = System.Text.Encoding.Unicode.GetBytes(Dado);
                Byte[] vetDataHash = algorithm.ComputeHash(vetData);
                saida = BitConverter.ToInt64(vetDataHash, 0);

                return saida;
            }
        }

        public ulong mtdGerarProximoNumeroCodigo(string BancoDados, string Tabela, string Campo)
        {
            int intNumeroControle = 1000000;

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexao = mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

            System.DateTime dtAtual = System.DateTime.Today;
            objImplementacaoBancoDados.mtdSelecionarDados
                (
                Campo,
                Tabela,
                Campo,
                false
                );

            objImplementacaoBancoDados.mtdDefinirLeitorDados();
            ulong ulngNumeroInventario = 0;
            ulong ulngMaximoNumeroInventario = 0;
            if ((objImplementacaoBancoDados.mtdProximoRegistro()))
            {
                int Coluna = objImplementacaoBancoDados.mtdObterNumeroColuna(Campo);
                string strValorRegistro = objImplementacaoBancoDados.mtdObterValorRegistro(Coluna).ToString();
                if (strValorRegistro != string.Empty)
                {
                    ulngMaximoNumeroInventario = Convert.ToUInt64(strValorRegistro);
                    if
                        (
                        !(ulngMaximoNumeroInventario > Convert.ToUInt64(dtAtual.Year * intNumeroControle)
                        &&
                        ulngMaximoNumeroInventario < Convert.ToUInt64(dtAtual.AddYears(1).Year * intNumeroControle))
                        )
                    {
                        objImplementacaoBancoDados.mtdExecutarComando
                            (
                            string.Format
                            (
                            "SELECT {0} FROM {1} WHERE  {0} > {2} AND {0} < {3} ORDER BY {0} DESC;",
                            Campo,
                            Tabela,
                            dtAtual.Year * intNumeroControle,
                            (dtAtual.Year + 1) * intNumeroControle));
                        objImplementacaoBancoDados.mtdDefinirLeitorDados();
                        if
                            (
                            objImplementacaoBancoDados.mtdProximoRegistro()
                            )
                        {
                            strValorRegistro = objImplementacaoBancoDados.mtdObterValorRegistro(Coluna).ToString();
                            ulngMaximoNumeroInventario = Convert.ToUInt64(strValorRegistro);
                        }
                        else
                        {
                            ulngMaximoNumeroInventario = Convert.ToUInt64(dtAtual.Year * intNumeroControle);
                        }
                    }
                    ulngNumeroInventario = Convert.ToUInt64(ulngMaximoNumeroInventario + 1);
                }
                else
                {
                    ulngNumeroInventario = Convert.ToUInt64((dtAtual.Year * intNumeroControle) + 1);
                }
            }
            else
            {
                ulngNumeroInventario = Convert.ToUInt64((dtAtual.Year * intNumeroControle) + 1);
            }
            objImplementacaoBancoDados.Dispose();

            return ulngNumeroInventario;
        }

        private void txtRegistroIteracaoDownloadTabelaApoio_LostFocus(object sender, EventArgs e)
        {
            objRegistroWindows.mtdSalvarDadosRegistro
            (
            Microsoft.Win32.Registry.CurrentUser,
            "Software",
            "Eletronorte",
            "ColetorDados",
            "RegistroIteracaoDownloadTabelaApoio",
            txtRegistroIteracaoDownloadTabelaApoio.Text,
            Microsoft.Win32.RegistryValueKind.String
            );

            try
            {
                intPassoDownloadTabelaApoio = Convert.ToInt32(txtRegistroIteracaoDownloadTabelaApoio.Text);
            }
            catch (System.Exception ex)
            {
                txtRegistroIteracaoDownloadTabelaApoio.Text = intPassoMaximoValido.ToString();

                objRegistroWindows.mtdSalvarDadosRegistro
                (
                Microsoft.Win32.Registry.CurrentUser,
                "Software",
                "Eletronorte",
                "ColetorDados",
                "RegistroIteracaoDownloadTabelaApoio",
                txtRegistroIteracaoDownloadTabelaApoio.Text,
                Microsoft.Win32.RegistryValueKind.String
                );

                string strExcecao = "txtRegistroIteracaoDownloadTabelaApoio_TextChanged: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void txtRegistroIteracaoDownloadTabelaInventarioBens_LostFocus(object sender, EventArgs e)
        {
            objRegistroWindows.mtdSalvarDadosRegistro
            (
            Microsoft.Win32.Registry.CurrentUser,
            "Software",
            "Eletronorte",
            "ColetorDados",
            "RegistroIteracaoDownloadTabelaInventarioBens",
            txtRegistroIteracaoDownloadTabelaInventarioBens.Text,
            Microsoft.Win32.RegistryValueKind.String
            );

            try
            {
                intPassoDownloadTabelaInventarioBensPrincipal = Convert.ToInt32(txtRegistroIteracaoDownloadTabelaInventarioBens.Text);
            }
            catch (System.Exception ex)
            {
                txtRegistroIteracaoDownloadTabelaInventarioBens.Text = intPassoMaximoValido.ToString();

                objRegistroWindows.mtdSalvarDadosRegistro
                (
                Microsoft.Win32.Registry.CurrentUser,
                "Software",
                "Eletronorte",
                "ColetorDados",
                "RegistroIteracaoDownloadTabelaInventarioBens",
                txtRegistroIteracaoDownloadTabelaInventarioBens.Text,
                Microsoft.Win32.RegistryValueKind.String
                );

                string strExcecao = "txtRegistroIteracaoDownloadTabelaInventarioBens_TextChanged: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void txtRegistroIteracaoUploadTabelaInventarioBens_LostFocus(object sender, EventArgs e)
        {
            objRegistroWindows.mtdSalvarDadosRegistro
            (
            Microsoft.Win32.Registry.CurrentUser,
            "Software",
            "Eletronorte",
            "ColetorDados",
            "RegistroIteracaoUploadTabelaInventarioBens",
            txtRegistroIteracaoUploadTabelaInventarioBens.Text,
            Microsoft.Win32.RegistryValueKind.String
            );

            try
            {
                intPassoUploadTabelaInventarioBensPrincipal = Convert.ToInt32(txtRegistroIteracaoUploadTabelaInventarioBens.Text);
            }
            catch (System.Exception ex)
            {
                txtRegistroIteracaoUploadTabelaInventarioBens.Text = intPassoMaximoValido.ToString();

                objRegistroWindows.mtdSalvarDadosRegistro
                (
                Microsoft.Win32.Registry.CurrentUser,
                "Software",
                "Eletronorte",
                "ColetorDados",
                "RegistroIteracaoUploadTabelaInventarioBens",
                txtRegistroIteracaoUploadTabelaInventarioBens.Text,
                Microsoft.Win32.RegistryValueKind.String
                );

                string strExcecao = "txtRegistroIteracaoUploadTabelaInventarioBens_TextChanged: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void frmMonitorCarregamentoDados_Closing(object sender, CancelEventArgs e)
        {
            mtdAbortarThreadDownloadTabelaApoio(true);
            mtdAbortarThreadDownloadTabelaInventarioBensPrincipal(true);
            mtdAbortarThreadUploadTabelaInventarioBensPrincipal(true);
            mtdAbortarThreadThMonitorarWebService();

            wb.Dispose();
        }

        private void mtdAvancarDownloadTabelaApoio()
        {
            switch (intContadorTabelaApoioApresentacao)
            {
                case 0:
                    intContadorTabelaApoioApresentacao += 1;
                    break;
                case 1:
                    intContadorTabelaApoioApresentacao += 1;
                    break;
                case 2:
                    intContadorTabelaApoioApresentacao = 0;
                    break;
            }

            intControleContadorTabelaApoioApresentacao = intContadorTabelaApoioApresentacao;
            cmbTabelaApoioApresentacao.SelectedIndex = intControleContadorTabelaApoioApresentacao;
        }

        private void btnAvancarDownloadTabelaApoio_Click(object sender, EventArgs e)
        {
            mtdAvancarDownloadTabelaApoio();
        }

        private bool blnIgnorarCodigoEspalhamentoTabela = false;

        private void chkIgnorarCodigoEspalhamentoTabela_Click(object sender, EventArgs e)
        {
            blnIgnorarCodigoEspalhamentoTabela = chkIgnorarCodigoEspalhamentoTabela.Checked;

            objRegistroWindows.mtdSalvarDadosRegistro
            (
            Microsoft.Win32.Registry.CurrentUser,
            "Software",
            "Eletronorte",
            "ColetorDados",
            "IgnorarCodigoEspalhamentoTabela",
            blnIgnorarCodigoEspalhamentoTabela.ToString(),
            Microsoft.Win32.RegistryValueKind.String
            );
        }

        private void mtdchkIgnorarCodigoEspalhamentoTabela()
        {
            try
            {
                blnIgnorarCodigoEspalhamentoTabela = bool.Parse
                 (
                 objRegistroWindows.mtdObterDadosRegistro
                 (
                 Microsoft.Win32.Registry.CurrentUser,
                 "Software",
                 "Eletronorte",
                 "ColetorDados",
                 "IgnorarCodigoEspalhamentoTabela"
                 ).ToString());

                chkIgnorarCodigoEspalhamentoTabela.Checked = blnIgnorarCodigoEspalhamentoTabela;
            }
            catch (System.Exception ex)
            {
                blnIgnorarCodigoEspalhamentoTabela = false;
                chkIgnorarCodigoEspalhamentoTabela.Checked = blnIgnorarCodigoEspalhamentoTabela;
                objRegistroWindows.mtdSalvarDadosRegistro
                (
                Microsoft.Win32.Registry.CurrentUser,
                "Software",
                "Eletronorte",
                "ColetorDados",
                "IgnorarCodigoEspalhamentoTabela",
                blnIgnorarCodigoEspalhamentoTabela.ToString(),
                Microsoft.Win32.RegistryValueKind.String
                );

                string strExcecao = "mtdchkIgnorarCodigoEspalhamentoTabela: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private bool blnForcarUploadDownloadTabela = false;

        private void chkForcarUploadDownloadTabela_Click(object sender, EventArgs e)
        {
            blnForcarUploadDownloadTabela = chkForcarUploadDownloadTabela.Checked;

            objRegistroWindows.mtdSalvarDadosRegistro
            (
            Microsoft.Win32.Registry.CurrentUser,
            "Software",
            "Eletronorte",
            "ColetorDados",
            "ForcarUploadDownloadTabela",
            blnForcarUploadDownloadTabela.ToString(),
            Microsoft.Win32.RegistryValueKind.String
            );
        }

        private void mtdForcarUploadDownloadTabela()
        {
            try
            {
                blnForcarUploadDownloadTabela = bool.Parse
                (
                objRegistroWindows.mtdObterDadosRegistro
                (
                Microsoft.Win32.Registry.CurrentUser,
                "Software",
                "Eletronorte",
                "ColetorDados",
                "ForcarUploadDownloadTabela"
                ).ToString());

                chkForcarUploadDownloadTabela.Checked = blnForcarUploadDownloadTabela;
            }
            catch (System.Exception ex)
            {
                blnForcarUploadDownloadTabela = false;
                chkForcarUploadDownloadTabela.Checked = blnForcarUploadDownloadTabela;
                objRegistroWindows.mtdSalvarDadosRegistro
                (
                Microsoft.Win32.Registry.CurrentUser,
                "Software",
                "Eletronorte",
                "ColetorDados",
                "ForcarUploadDownloadTabela",
                blnForcarUploadDownloadTabela.ToString(),
                Microsoft.Win32.RegistryValueKind.String
                );

                string strExcecao = "mtdForcarUploadDownloadTabela: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private bool blnIteracoesContinuas = false;

        private void chkIteracoesContinuas_Click(object sender, EventArgs e)
        {
            blnIteracoesContinuas = chkIteracoesContinuas.Checked;

            objRegistroWindows.mtdSalvarDadosRegistro
            (
            Microsoft.Win32.Registry.CurrentUser,
            "Software",
            "Eletronorte",
            "ColetorDados",
            "IteracoesContinuas",
            blnIteracoesContinuas.ToString(),
            Microsoft.Win32.RegistryValueKind.String
            );
        }

        private void mtdIteracoesContinuas()
        {
            try
            {
                blnIteracoesContinuas = bool.Parse
                (
                objRegistroWindows.mtdObterDadosRegistro
                (
                Microsoft.Win32.Registry.CurrentUser,
                "Software",
                "Eletronorte",
                "ColetorDados",
                "IteracoesContinuas"
                ).ToString());

                chkIteracoesContinuas.Checked = blnIteracoesContinuas;
            }
            catch (System.Exception ex)
            {
                blnIteracoesContinuas = false;
                chkIteracoesContinuas.Checked = blnIteracoesContinuas;
                objRegistroWindows.mtdSalvarDadosRegistro
                (
                Microsoft.Win32.Registry.CurrentUser,
                "Software",
                "Eletronorte",
                "ColetorDados",
                "IteracoesContinuas",
                blnIteracoesContinuas.ToString(),
                Microsoft.Win32.RegistryValueKind.String
                );

                string strExcecao = "mtdIteracoesContinuas: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private bool blnForcarDesligamento = false;

        private void chkForcarDesligamento_Click(object sender, EventArgs e)
        {
            blnForcarDesligamento = chkForcarDesligamento.Checked;

            objRegistroWindows.mtdSalvarDadosRegistro
            (
            Microsoft.Win32.Registry.CurrentUser,
            "Software",
            "Eletronorte",
            "ColetorDados",
            "ForcarDesligamento",
            blnForcarDesligamento.ToString(),
            Microsoft.Win32.RegistryValueKind.String
            );
        }

        private void mtdForcarDesligamento()
        {
            mtdAbortarThreadTemporizadorForcarDesligamento();

            try
            {
                blnForcarDesligamento = bool.Parse
                (
                objRegistroWindows.mtdObterDadosRegistro
                (
                Microsoft.Win32.Registry.CurrentUser,
                "Software",
                "Eletronorte",
                "ColetorDados",
                "ForcarDesligamento"
                ).ToString());

                chkForcarDesligamento.Checked = blnForcarDesligamento;
            }
            catch (System.Exception ex)
            {
                blnForcarDesligamento = false;
                chkForcarDesligamento.Checked = blnForcarDesligamento;
                objRegistroWindows.mtdSalvarDadosRegistro
                (
                Microsoft.Win32.Registry.CurrentUser,
                "Software",
                "Eletronorte",
                "ColetorDados",
                "ForcarDesligamento",
                blnForcarDesligamento.ToString(),
                Microsoft.Win32.RegistryValueKind.String
                );

                string strExcecao = "mtdForcarDesligamento: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void mtdCarregarCmbPrioridadeDownloadTabelaInventarioBensPrincipal()
        {
            cmbPrioridadeDownloadTabelaInventarioBens.Items.Clear();
            cmbPrioridadeDownloadTabelaInventarioBens.Items.Add(System.Threading.ThreadPriority.Lowest);
            cmbPrioridadeDownloadTabelaInventarioBens.Items.Add(System.Threading.ThreadPriority.BelowNormal);
            cmbPrioridadeDownloadTabelaInventarioBens.Items.Add(System.Threading.ThreadPriority.Normal);
            cmbPrioridadeDownloadTabelaInventarioBens.Items.Add(System.Threading.ThreadPriority.AboveNormal);
            cmbPrioridadeDownloadTabelaInventarioBens.Items.Add(System.Threading.ThreadPriority.Highest);
            cmbPrioridadeDownloadTabelaInventarioBens.SelectedIndex = 2;
        }

        private void mtdCarregarCmbPrioridadeUploadTabelaInventario()
        {
            cmbPrioridadeUploadTabelaInventarioBens.Items.Clear();
            cmbPrioridadeUploadTabelaInventarioBens.Items.Add(System.Threading.ThreadPriority.Lowest);
            cmbPrioridadeUploadTabelaInventarioBens.Items.Add(System.Threading.ThreadPriority.BelowNormal);
            cmbPrioridadeUploadTabelaInventarioBens.Items.Add(System.Threading.ThreadPriority.Normal);
            cmbPrioridadeUploadTabelaInventarioBens.Items.Add(System.Threading.ThreadPriority.AboveNormal);
            cmbPrioridadeUploadTabelaInventarioBens.Items.Add(System.Threading.ThreadPriority.Highest);
            cmbPrioridadeUploadTabelaInventarioBens.SelectedIndex = 2;
        }

        private void mtdCarregarCmbPrioridadeDownloadTabelaApoio()
        {
            cmbPrioridadeDownloadTabelaApoio.Items.Clear();
            cmbPrioridadeDownloadTabelaApoio.Items.Add(System.Threading.ThreadPriority.Lowest);
            cmbPrioridadeDownloadTabelaApoio.Items.Add(System.Threading.ThreadPriority.BelowNormal);
            cmbPrioridadeDownloadTabelaApoio.Items.Add(System.Threading.ThreadPriority.Normal);
            cmbPrioridadeDownloadTabelaApoio.Items.Add(System.Threading.ThreadPriority.AboveNormal);
            cmbPrioridadeDownloadTabelaApoio.Items.Add(System.Threading.ThreadPriority.Highest);
            cmbPrioridadeDownloadTabelaApoio.SelectedIndex = 2;
        }

        private void cmbPrioridadeDownloadTabelaInventarioBens_TextChanged(object sender, EventArgs e)
        {
            objRegistroWindows.mtdSalvarDadosRegistro
            (
            Microsoft.Win32.Registry.CurrentUser,
            "Software",
            "Eletronorte",
            "ColetorDados",
            "PrioridadeDownloadTabelaInventarioBens",
            cmbPrioridadeDownloadTabelaInventarioBens.Text,
            Microsoft.Win32.RegistryValueKind.String
            );
        }

        private void cmbPrioridadeUploadTabelaInventarioBens_TextChanged(object sender, EventArgs e)
        {
            objRegistroWindows.mtdSalvarDadosRegistro
            (
            Microsoft.Win32.Registry.CurrentUser,
            "Software",
            "Eletronorte",
            "ColetorDados",
            "PrioridadeUploadTabelaInventario",
            cmbPrioridadeUploadTabelaInventarioBens.Text,
            Microsoft.Win32.RegistryValueKind.String
            );
        }

        private void cmbPrioridadeDownloadTabelaApoio_TextChanged(object sender, EventArgs e)
        {
            objRegistroWindows.mtdSalvarDadosRegistro
            (
            Microsoft.Win32.Registry.CurrentUser,
            "Software",
            "Eletronorte",
            "ColetorDados",
            "PrioridadeDownloadTabelaApoio",
            cmbPrioridadeDownloadTabelaApoio.Text,
            Microsoft.Win32.RegistryValueKind.String
            );
        }

        private void mtdPrioridadeDownloadTabelaInventarioBens()
        {
            try
            {
                cmbPrioridadeDownloadTabelaInventarioBens.Text = objRegistroWindows.mtdObterDadosRegistro
                (
                Microsoft.Win32.Registry.CurrentUser,
                "Software",
                "Eletronorte",
                "ColetorDados",
                "PrioridadeDownloadTabelaInventarioBens"
                ).ToString();

                if (cmbPrioridadeDownloadTabelaInventarioBens.Text.Equals(string.Empty))
                {
                    cmbPrioridadeDownloadTabelaInventarioBens.Text = cmbPrioridadeDownloadTabelaInventarioBens.Items[2].ToString();
                    objRegistroWindows.mtdSalvarDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "ColetorDados",
                    "PrioridadeDownloadTabelaInventarioBens",
                    cmbPrioridadeDownloadTabelaInventarioBens.Text,
                    Microsoft.Win32.RegistryValueKind.String
                    );
                }
            }
            catch (System.Exception ex)
            {
                cmbPrioridadeDownloadTabelaInventarioBens.Text = cmbPrioridadeDownloadTabelaInventarioBens.Items[2].ToString();
                objRegistroWindows.mtdSalvarDadosRegistro
                (
                Microsoft.Win32.Registry.CurrentUser,
                "Software",
                "Eletronorte",
                "ColetorDados",
                "PrioridadeDownloadTabelaInventarioBensFotografia",
                cmbPrioridadeDownloadTabelaInventarioBens.Text,
                Microsoft.Win32.RegistryValueKind.String
                );
                string strExcecao = "mtdPrioridadeDownloadTabelaInventarioBens: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void mtdPrioridadeUploadTabelaInventarioBens()
        {
            try
            {
                cmbPrioridadeUploadTabelaInventarioBens.Text = objRegistroWindows.mtdObterDadosRegistro
                (
                Microsoft.Win32.Registry.CurrentUser,
                "Software",
                "Eletronorte",
                "ColetorDados",
                "PrioridadeUploadTabelaInventarioBens"
                ).ToString();

                if (cmbPrioridadeUploadTabelaInventarioBens.Text.Equals(string.Empty))
                {
                    cmbPrioridadeUploadTabelaInventarioBens.Text = cmbPrioridadeUploadTabelaInventarioBens.Items[2].ToString();
                    objRegistroWindows.mtdSalvarDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "ColetorDados",
                    "PrioridadeUploadTabelaInventarioBens",
                    cmbPrioridadeUploadTabelaInventarioBens.Text,
                    Microsoft.Win32.RegistryValueKind.String
                    );
                }
            }
            catch (System.Exception ex)
            {
                cmbPrioridadeUploadTabelaInventarioBens.Text = cmbPrioridadeUploadTabelaInventarioBens.Items[2].ToString();
                objRegistroWindows.mtdSalvarDadosRegistro
                (
                Microsoft.Win32.Registry.CurrentUser,
                "Software",
                "Eletronorte",
                "ColetorDados",
                "PrioridadeUploadTabelaInventarioBensFotografia",
                cmbPrioridadeUploadTabelaInventarioBens.Text,
                Microsoft.Win32.RegistryValueKind.String
                );
                string strExcecao = "mtdPrioridadeUploadTabelaInventarioBens: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void mtdPrioridadeDownloadTabelaApoio()
        {
            try
            {
                cmbPrioridadeDownloadTabelaApoio.Text = objRegistroWindows.mtdObterDadosRegistro
                (
                Microsoft.Win32.Registry.CurrentUser,
                "Software",
                "Eletronorte",
                "ColetorDados",
                "PrioridadeDownloadTabelaApoio"
                ).ToString();

                if (cmbPrioridadeDownloadTabelaApoio.Text.Equals(string.Empty))
                {
                    cmbPrioridadeDownloadTabelaApoio.Text = cmbPrioridadeDownloadTabelaApoio.Items[2].ToString();
                    objRegistroWindows.mtdSalvarDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "ColetorDados",
                    "PrioridadeDownloadTabelaApoio",
                    cmbPrioridadeDownloadTabelaApoio.Text,
                    Microsoft.Win32.RegistryValueKind.String
                    );
                }
            }
            catch (System.Exception ex)
            {
                cmbPrioridadeDownloadTabelaApoio.Text = cmbPrioridadeDownloadTabelaApoio.Items[2].ToString();
                objRegistroWindows.mtdSalvarDadosRegistro
                (
                Microsoft.Win32.Registry.CurrentUser,
                "Software",
                "Eletronorte",
                "ColetorDados",
                "PrioridadeDownloadTabelaApoioFotografia",
                cmbPrioridadeDownloadTabelaApoio.Text,
                Microsoft.Win32.RegistryValueKind.String
                );
                string strExcecao = "mtdPrioridadeDownloadTabelaApoio: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void frmMonitorCarregamentoDados_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Up
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Down
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                // Left
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                // Right
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                // Enter
            }
            if (e.KeyValue == 211)
            {
                switch (tbc1.SelectedIndex)
                {
                    case 0:
                        btnDownloadTabelaInventarioBens.Focus();
                        break;
                    case 1:
                        btnDownloadTabelaApoio.Focus();
                        break;
                    case 2:
                        txtEnderecoWebService.Focus();
                        break;
                }
            }
            if (e.KeyValue == 212)
            {
                tbc1.Focus();
            }
        }

        protected internal void mtdSelecionarFormularioPadraoInventario()
        {
            mtdSelecionarFormularioPadraoInventario(true);
        }

        protected internal void mtdSelecionarFormularioPadraoInventario(bool MostrarFormularioPrincipal)
        {
            try
            {
                //cmbPrioridadeDownloadTabelaApoio.Text = "Lowest";
                //cmbPrioridadeDownloadTabelaInventarioBens.Text = "Lowest";
                //cmbPrioridadeUploadTabelaInventarioBens.Text = "Lowest";

                if (ThDownloadTabelaApoio != null)
                {
                    ThDownloadTabelaApoio.Priority = Program.objPrincipal.mtdConverterPrioridadeThread(cmbPrioridadeDownloadTabelaApoio.Text);
                }
                if (ThDownloadTabelaInventarioBensPrincipal != null)
                {
                    ThDownloadTabelaInventarioBensPrincipal.Priority = Program.objPrincipal.mtdConverterPrioridadeThread(cmbPrioridadeDownloadTabelaInventarioBens.Text);
                }
                if (ThUploadTabelaInventarioBensPrincipal != null)
                {
                    ThUploadTabelaInventarioBensPrincipal.Priority = Program.objPrincipal.mtdConverterPrioridadeThread(cmbPrioridadeUploadTabelaInventarioBens.Text);
                }
                if (MostrarFormularioPrincipal)
                {
                    Program.objPrincipal.Show();
                }
            }
            catch
            {
            }
        }

        ~frmMonitorCarregamentoDados()
        {
            Dispose(false);
        }

        private void txtRegistroIteracaoDownloadTabelaApoio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!frmPrincipal.objManipuladorTexto.mtdPermitirDigitarSoNumero(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtRegistroIteracaoDownloadTabelaInventarioBens_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!frmPrincipal.objManipuladorTexto.mtdPermitirDigitarSoNumero(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtRegistroIteracaoUploadTabelaInventarioBens_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!frmPrincipal.objManipuladorTexto.mtdPermitirDigitarSoNumero(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        public DataTable dt = new DataTable();

        private void mtdPreencherDt
        (
            uint NumeroLinhas,
            string[] Campos,
            string NomeTabela,
            string CampoAgrupador,
            string CampoSelecionador,
            string Operacao,
            string Dado,
            string CampoOrdenador,
            bool Crescente
        )
        {
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                (
                clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                );

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                (
                clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                frmPrincipal.strBaseDadosColetor,
                frmPrincipal.strSenhaColetor
                );

            Cursor.Current = Cursors.WaitCursor; // set the wait cursor
            //Do some work

            try
            {
                objImplementacaoBancoDados.mtdSelecionarDados
                    (
                    true,
                    true,
                    Program.objPrincipal.mtdVetorLinhaCampos(Campos),
                    NomeTabela,
                    CampoSelecionador,
                    Operacao,
                    Dado,
                    CampoAgrupador,
                    CampoOrdenador,
                    Crescente
                    );

                objImplementacaoBancoDados.mtdDefinirLeitorDados();
                objImplementacaoBancoDados.mtdProximoRegistro();

                dt = new DataTable();
                DataRow dr;

                dr = dt.NewRow();

                object[][] vetColunaTipo = objImplementacaoBancoDados.mtdObterCabecalhoTipoRegistro();

                for (int coluna = vetColunaTipo[0].GetLowerBound(0); coluna <= vetColunaTipo[0].GetUpperBound(0); coluna++)
                {
                    if ((vetColunaTipo[1][coluna]).ToString() != "System.DBNull")
                    {
                        dt.Columns.Add
                            (
                            vetColunaTipo[0][coluna].ToString(),
                            (System.Type)
                            vetColunaTipo[1][coluna]
                            );
                    }
                    else
                    {
                        dt.Columns.Add
                            (
                            vetColunaTipo[0][coluna].ToString(),
                            System.Type.GetType("System.Object")
                            );
                    }

                    dr[coluna] = objImplementacaoBancoDados.mtdObterValorRegistro(coluna);
                }

                dt.Rows.Add(dr);

                while (objImplementacaoBancoDados.mtdProximoRegistro())
                {
                    dr = dt.NewRow();
                    for (int coluna = 0; coluna <= frmPrincipal.intCamposTabelaInventarioBens - 1; coluna++)
                    {
                        dr[coluna] = objImplementacaoBancoDados.mtdObterValorRegistro(coluna);
                    }
                    dt.Rows.Add(dr);
                }
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdPreencherDt: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }

            Cursor.Current = Cursors.Default; //restore the old cursor

            objImplementacaoBancoDados.Dispose();
        }

        private void mtdPreencherDt
        (
            uint NumeroLinhas,
            string Campo,
            string NomeTabela,
            string CampoAgrupador,
            string CampoSelecionador,
            string Operacao,
            string Dado,
            string CampoOrdenador,
            bool Crescente
        )
        {
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                (
                clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                );

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                (
                clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                frmPrincipal.strBaseDadosColetor,
                frmPrincipal.strSenhaColetor
                );

            Cursor.Current = Cursors.WaitCursor; // set the wait cursor
            //Do some work

            try
            {
                objImplementacaoBancoDados.mtdAbrirConexao();
                objImplementacaoBancoDados.mtdExecutarComando
                    (
                    string.Format
                    (
                    "SELECT DISTINCT {0}{1} FROM {2} GROUP BY {3} HAVING {4} {5} {6} ORDER BY {7}{8};",
                    NumeroLinhas != 0 ? string.Format("TOP ({0}) ", NumeroLinhas) : string.Empty,
                    string.Format("{0}, Count({0}) AS Contador", Campo),
                    NomeTabela,
                    CampoAgrupador,
                    CampoSelecionador,
                    Operacao,
                    Dado,
                    CampoOrdenador,
                    Crescente ? string.Empty : " DESC"
                    )
                    );

                objImplementacaoBancoDados.mtdDefinirLeitorDados();
                objImplementacaoBancoDados.mtdProximoRegistro();

                dt = new DataTable();
                DataRow dr;

                dr = dt.NewRow();

                object[][] vetColunaTipo = objImplementacaoBancoDados.mtdObterCabecalhoTipoRegistro();

                for (int coluna = vetColunaTipo[0].GetLowerBound(0); coluna <= vetColunaTipo[0].GetUpperBound(0); coluna++)
                {
                    if ((vetColunaTipo[1][coluna]).ToString() != "System.DBNull")
                    {
                        dt.Columns.Add
                            (
                            vetColunaTipo[0][coluna].ToString(),
                            (System.Type)
                            vetColunaTipo[1][coluna]
                            );
                    }
                    else
                    {
                        dt.Columns.Add
                            (
                            vetColunaTipo[0][coluna].ToString(),
                            System.Type.GetType("System.Object")
                            );
                    }

                    dr[coluna] = objImplementacaoBancoDados.mtdObterValorRegistro(coluna);
                }

                dt.Rows.Add(dr);

                while (objImplementacaoBancoDados.mtdProximoRegistro())
                {
                    dr = dt.NewRow();
                    for (int coluna = vetColunaTipo[0].GetLowerBound(0); coluna <= vetColunaTipo[0].GetUpperBound(0); coluna++)
                    {
                        dr[coluna] = objImplementacaoBancoDados.mtdObterValorRegistro(coluna);
                    }
                    dt.Rows.Add(dr);
                }
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdPreencherDt: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }

            Cursor.Current = Cursors.Default; //restore the old cursor

            objImplementacaoBancoDados.Dispose();
        }

        private void mtdPreencherDt
        (
            int NumeroLinhas,
            string[] Campos,
            string NomeTabela,
            string CampoAgrupador,
            string Selecao,
            string Dado,
            string CampoOrdenador,
            bool Crescente
        )
        {
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                (
                clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                );

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                (
                clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                frmPrincipal.strBaseDadosColetor,
                frmPrincipal.strSenhaColetor
                );

            Cursor.Current = Cursors.WaitCursor; // set the wait cursor
            //Do some work

            try
            {
                objImplementacaoBancoDados.mtdAbrirConexao();
                objImplementacaoBancoDados.mtdExecutarComando
                    (
                    string.Format
                    (
                    "SELECT {0}{1} FROM {2} GROUP BY {3} HAVING {4} ORDER BY {5}{6};",
                    NumeroLinhas != 0 ? string.Format("TOP ({0}) ", NumeroLinhas) : string.Empty,
                    Program.objPrincipal.mtdVetorLinhaCampos(Campos),
                    NomeTabela,
                    CampoAgrupador,
                    Selecao,
                    CampoOrdenador,
                    Crescente ? string.Empty : " DESC"
                    )
                    );

                objImplementacaoBancoDados.mtdDefinirLeitorDados();
                objImplementacaoBancoDados.mtdProximoRegistro();

                dt = new DataTable();
                DataRow dr;

                dr = dt.NewRow();

                object[][] vetColunaTipo = objImplementacaoBancoDados.mtdObterCabecalhoTipoRegistro();

                for (int coluna = vetColunaTipo[0].GetLowerBound(0); coluna <= vetColunaTipo[0].GetUpperBound(0); coluna++)
                {
                    if ((vetColunaTipo[1][coluna]).ToString() != "System.DBNull")
                    {
                        dt.Columns.Add
                            (
                            vetColunaTipo[0][coluna].ToString(),
                            (System.Type)
                            vetColunaTipo[1][coluna]
                            );
                    }
                    else
                    {
                        dt.Columns.Add
                            (
                            vetColunaTipo[0][coluna].ToString(),
                            System.Type.GetType("System.Object")
                            );
                    }

                    dr[coluna] = objImplementacaoBancoDados.mtdObterValorRegistro(coluna);
                }

                dt.Rows.Add(dr);

                while (objImplementacaoBancoDados.mtdProximoRegistro())
                {
                    dr = dt.NewRow();
                    for (int coluna = vetColunaTipo[0].GetLowerBound(0); coluna <= vetColunaTipo[0].GetUpperBound(0); coluna++)
                    {
                        dr[coluna] = objImplementacaoBancoDados.mtdObterValorRegistro(coluna);
                    }
                    dt.Rows.Add(dr);
                }
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdPreencherDt: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }

            Cursor.Current = Cursors.Default; //restore the old cursor

            objImplementacaoBancoDados.Dispose();
        }

        private void mtdInicializaLsv1()
        {
            // exibe detalhes
            lsv1.View = View.Details;
            // exibe as caixas de marcacao (check boxes.)
            lsv1.CheckBoxes = true;
            // permite ao usuário editar o texto
            //lsv1.LabelEdit = true;
            // permite ao usuário rearranjar as colunas
            //lsv1.AllowColumnReorder = true;
            // Selecione o item e subitem quando um seleção for feita
            lsv1.FullRowSelect = true;
            // Exibe as linhas no ListView
            //lsv1.GridLines = true;
        }

        private static string strNumeroInventario = string.Empty;

        private void mtdCarregarLsv1()
        {
            lsv1.Clear();
            lsv1.Columns.Clear();
            lsv1.Items.Clear();

            mtdInicializaLsv1();

            int intColunaSelecionada = -1;
            int intLinhaSelecionada = -1;

            for (int coluna = 0; coluna <= dt.Columns.Count - 1; coluna++)
            {
                lsv1.Columns.Add
                    (
                    dt.Columns[coluna].Caption.ToString(),
                    100,
                    HorizontalAlignment.Left
                    );
                lsv1.Columns[coluna].Width = 200;
            }

            ListViewItem lvi = new ListViewItem();
            ListViewItem.ListViewSubItem lvs = new ListViewItem.ListViewSubItem();

            for (int linha = 0; linha <= dt.Rows.Count - 1; linha++)
            {
                for (int coluna = 0; coluna <= dt.Columns.Count - 1; coluna++)
                {
                    if (coluna == 0)
                    {
                        if (dt.Rows[linha].ItemArray[coluna].ToString() == strNumeroInventario)
                        {
                            intColunaSelecionada = coluna;
                            intLinhaSelecionada = linha;
                        }
                        lvi = new ListViewItem(dt.Rows[linha].ItemArray[coluna].ToString());
                    }
                    else
                    {
                        lvs = new ListViewItem.ListViewSubItem();
                        lvs.Text = dt.Rows[linha].ItemArray[coluna].ToString();
                        lvi.SubItems.Add(lvs);
                    }
                }

                lsv1.Items.Add(lvi);
            }

            //if (intLinhaSelecionada > -1 && intColunaSelecionada > -1)
            //{
            //    lsv1.Items[intLinhaSelecionada].Checked = true;
            //}
        }

        private void cmbTabelaInventarioBensUpload_GotFocus(object sender, EventArgs e)
        {
            try
            {
                if (cmbTabelaInventarioBensUpload.Items.Count == 0)
                {
                    Program.objPrincipal.mtdCarregarCmb
                        (
                            ref cmbTabelaInventarioBensUpload,
                            String.Format("SELECT TOP (0) * FROM {0}", frmPrincipal.strTabelaInventarioBens)
                        );
                }
            }
            catch (System.Exception ex)
            {
                string strExcecao = "cmbTabelaInventarioBensUpload_GotFocus: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void txtTabelaInventarioBensUpload_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)System.Windows.Forms.Keys.Enter)
            {
                mtdComandoCarregarLsv1();
            }
        }

        private void mtdComandoCarregarLsv1()
        {
            if (cmbTabelaInventarioBensUpload.Text != frmPrincipal.vetCamposTabelaInventarioBens[frmPrincipal.intColunaTabelaInventarioBensData_Inventario])
            {
                mtdPreencherDt
                    (
                    0,
                    cmbTabelaInventarioBensUpload.Text,
                    frmPrincipal.strTabelaInventarioBens,
                    cmbTabelaInventarioBensUpload.Text,
                    cmbTabelaInventarioBensUpload.Text,
                    "LIKE",
                    string.Format
                    (
                    "N'%{0}%'",
                    txtTabelaInventarioBensUpload.Text
                    ),
                    cmbTabelaInventarioBensUpload.Text,
                    false
                    );
            }
            else
            {
                mtdPreencherDt
                    (
                    0,
                    frmPrincipal.vetCamposTabelaInventarioBens,
                    frmPrincipal.strTabelaInventarioBens,
                    cmbTabelaInventarioBensUpload.Text,
                    Program.objPrincipal.mtdConsultarData_Inventario(cmbTabelaInventarioBensUpload.Text, txtTabelaInventarioBensUpload.Text),
                    txtTabelaInventarioBensUpload.Text,
                    cmbTabelaInventarioBensUpload.Text,
                    cmbTabelaInventarioBensUpload.Text,
                    false
                    );
            }

            mtdCarregarLsv1();
        }

        private int numTotalIteracoes = 0;
        private int numTotalBens = 0;

        private object objLockPreencherVetorLsv1ContarTotalBens = new object();

        private void mtdPreencherVetorLsv1ContarTotalBens()
        {
            lock (objLockPreencherVetorLsv1ContarTotalBens)
            {
                try
                {
                    intlsv = lsv1.Items.Count;
                    blnvetlsv = new bool[intlsv];
                    strvetlsv = new string[intlsv];
                    strvetlsvsi = new string[intlsv];

                    numTotalIteracoes = 0;
                    numTotalBens = 0;

                    for (int contador = 0; contador <= intlsv - 1; contador++)
                    {
                        blnvetlsv[contador] = lsv1.Items[contador].Checked;
                        strvetlsv[contador] = lsv1.Items[contador].Text;
                        strvetlsvsi[contador] = lsv1.Items[contador].SubItems[1].Text;

                        if (blnvetlsv[contador])
                        {
                            numTotalBens += System.Convert.ToInt32(strvetlsvsi[contador]);
                            numTotalIteracoes += 1;
                        }
                    }

                    CampoSelecionador = cmbTabelaInventarioBensUpload.Text;

                    lblMostrarTotalInventarioBensUpload.Text = System.Convert.ToString(numTotalBens);
                    lblMostrarIteracoesInventarioBensUpload.Text = System.Convert.ToString(numTotalIteracoes);
                }
                catch (System.Exception ex)
                {
                    string strExcecao = "mtdPreencherVetorLsv1ContarTotalBens: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                    //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                }
            }
        }

        bool blnChecarItens = true;

        private void mtdChecarItens()
        {
            if (blnChecarItens)
            {
                for (int contador = 0; contador <= lsv1.Items.Count - 1; contador++)
                {
                    lsv1.Items[contador].Checked = true;
                }
                blnChecarItens = false;
            }
            else
            {
                for (int contador = 0; contador <= lsv1.Items.Count - 1; contador++)
                {
                    lsv1.Items[contador].Checked = false;
                }
                blnChecarItens = true;
            }
        }

        private void lsv1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            mtdChecarItens();
        }

        private void btnCarregarListaTabelaInventarioBensUpload_Click(object sender, EventArgs e)
        {
            mtdComandoCarregarLsv1();
        }

        private void mni1_Click(object sender, EventArgs e)
        {
            mtdSelecionarFormularioPadraoInventario();
        }

        private void mni2_Click(object sender, EventArgs e)
        {
            switch (mni2.Text)
            {
                case "Carreg. Lista":
                    mtdComandoCarregarLsv1();
                    break;
                case "Próx. Número":
                    mtdObterNumeroIdentificacao(false);
                    break;
                case "Download":
                    switch (tbc1.SelectedIndex)
                    {
                        case 1:
                            mtdDownloadTabelaInventarioBens();
                            break;
                        case 4:
                            mtdDownloadTabelaApoio();
                            break;
                    }
                    break;
                case "Upload":
                    switch (tbc1.SelectedIndex)
                    {
                        case 2:
                            mtdUploadTabelaInventarioBensPrincipal_();
                            break;
                    }
                    break;
            }
        }

        private void mtdSetarTbc1()
        {
            switch (tbc1.SelectedIndex)
            {
                case 0:
                    mni1.Text = "Form. Padrão";
                    mni2.Text = "Próx. Número";
                    break;
                case 1:
                    mni1.Text = "Form. Padrão";
                    mni2.Text = "Download";
                    break;
                case 2:
                    mni1.Text = "Form. Padrão";
                    mni2.Text = "Upload";
                    break;
                case 3:
                    mni1.Text = "Form. Padrão";
                    mni2.Text = "Carreg. Lista";
                    break;
                case 4:
                    mni1.Text = "Form. Padrão";
                    mni2.Text = "Download";
                    break;
            }
        }

        private void tbc1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mtdSetarTbc1();
        }

        private void mtdCarregarCmbTabelaApoioApresentacao()
        {
            cmbTabelaApoioApresentacao.Items.Clear();
            cmbTabelaApoioApresentacao.Items.Add(frmPrincipal.strTabelaBensEletronorte.Replace("tbl", string.Empty));
            cmbTabelaApoioApresentacao.Items.Add(frmPrincipal.strTabelaEmpregados.Replace("tbl", string.Empty));
            cmbTabelaApoioApresentacao.Items.Add(frmPrincipal.strTabelaCentroCusto.Replace("tbl", string.Empty));

            cmbTabelaApoioApresentacao.SelectedIndex = 0;
        }

        private void cmbTabelaApoioApresentacao_GotFocus(object sender, EventArgs e)
        {
            if (cmbTabelaApoioApresentacao.Items.Count == 0)
            {
                mtdCarregarCmbTabelaApoioApresentacao();
            }
        }

        private void cmbTabelaApoioApresentacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            intContadorTabelaApoioApresentacao = cmbTabelaApoioApresentacao.SelectedIndex;
        }

        private int intControleContadorTabelaApoioApresentacao = 0;

        private void cmbTabelaApoioApresentacao_LostFocus(object sender, EventArgs e)
        {
            intControleContadorTabelaApoioApresentacao = intContadorTabelaApoioApresentacao;
        }

        private void btnMarcarDesmarcarTodos_Click(object sender, EventArgs e)
        {
            try
            {
                mtdChecarItens();
            }
            catch (System.Exception ex)
            {
                string strExcecao = "btnMarcarDesmarcarTodos_Click: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void mtdRegistroIteracaoDownloadTabelaApoio()
        {
            try
            {
                string tmpRegistroIteracaoDownloadTabelaApoio = objRegistroWindows.mtdObterDadosRegistro
                         (
                         Microsoft.Win32.Registry.CurrentUser,
                         "Software",
                         "Eletronorte",
                         "ColetorDados",
                         "RegistroIteracaoDownloadTabelaApoio"
                         ).ToString();

                if (!tmpRegistroIteracaoDownloadTabelaApoio.Equals(string.Empty))
                {
                    intPassoDownloadTabelaApoio = int.Parse(tmpRegistroIteracaoDownloadTabelaApoio);
                }
                txtRegistroIteracaoDownloadTabelaApoio.Text = intPassoDownloadTabelaApoio.ToString();
            }
            catch (System.Exception ex)
            {
                txtRegistroIteracaoDownloadTabelaApoio.Text = intPassoMaximoValido.ToString();
                objRegistroWindows.mtdSalvarDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "ColetorDados",
                    "RegistroIteracaoDownloadTabelaApoio",
                    txtRegistroIteracaoDownloadTabelaApoio.Text,
                    Microsoft.Win32.RegistryValueKind.String
                    );
                string strExcecao = "mtdRegistroIteracaoDownloadTabelaApoio: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void mtdRegistroIteracaoDownloadTabelaInventarioBens()
        {
            try
            {
                string tmpRegistroIteracaoDownloadTabelaInventarioBens = objRegistroWindows.mtdObterDadosRegistro
                         (
                         Microsoft.Win32.Registry.CurrentUser,
                         "Software",
                         "Eletronorte",
                         "ColetorDados",
                         "RegistroIteracaoDownloadTabelaInventarioBens"
                         ).ToString();

                if (!tmpRegistroIteracaoDownloadTabelaInventarioBens.Equals(string.Empty))
                {
                    intPassoDownloadTabelaInventarioBensPrincipal = int.Parse(tmpRegistroIteracaoDownloadTabelaInventarioBens);
                }
                txtRegistroIteracaoDownloadTabelaInventarioBens.Text = intPassoDownloadTabelaInventarioBensPrincipal.ToString();
            }
            catch (System.Exception ex)
            {
                txtRegistroIteracaoDownloadTabelaInventarioBens.Text = intPassoMaximoValido.ToString();
                objRegistroWindows.mtdSalvarDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "ColetorDados",
                    "RegistroIteracaoDownloadTabelaInventarioBens",
                    txtRegistroIteracaoDownloadTabelaInventarioBens.Text,
                    Microsoft.Win32.RegistryValueKind.String
                    );
                string strExcecao = "mtdRegistroIteracaoDownloadTabelaInventarioBens: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void mtdRegistroIteracaoUploadTabelaInventarioBens()
        {
            try
            {
                string tmpRegistroIteracaoUploadTabelaInventarioBens = objRegistroWindows.mtdObterDadosRegistro
                         (
                         Microsoft.Win32.Registry.CurrentUser,
                         "Software",
                         "Eletronorte",
                         "ColetorDados",
                         "RegistroIteracaoUploadTabelaInventarioBens"
                         ).ToString();

                if (!tmpRegistroIteracaoUploadTabelaInventarioBens.Equals(string.Empty))
                {
                    intPassoUploadTabelaInventarioBensPrincipal = int.Parse(tmpRegistroIteracaoUploadTabelaInventarioBens);
                }
                txtRegistroIteracaoUploadTabelaInventarioBens.Text = intPassoUploadTabelaInventarioBensPrincipal.ToString();
            }
            catch (System.Exception ex)
            {
                txtRegistroIteracaoUploadTabelaInventarioBens.Text = intPassoMaximoValido.ToString();
                objRegistroWindows.mtdSalvarDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "ColetorDados",
                    "RegistroIteracaoUploadTabelaInventarioBens",
                    txtRegistroIteracaoUploadTabelaInventarioBens.Text,
                    Microsoft.Win32.RegistryValueKind.String
                    );
                string strExcecao = "mtdRegistroIteracaoUploadTabelaInventarioBens: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        bool blnGerarPassoAutomatico = false;

        private void mtdGerarPassoAutomatico()
        {
            try
            {
                blnGerarPassoAutomatico = bool.Parse
                    (
                    objRegistroWindows.mtdObterDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "ColetorDados",
                    "GerarPassoAutomatico"
                    ).ToString()
                    );

                chkGerarPassoAutomatico.Checked = blnGerarPassoAutomatico;
            }
            catch (System.Exception ex)
            {
                blnGerarPassoAutomatico = false;
                chkGerarPassoAutomatico.Checked = blnGerarPassoAutomatico;
                objRegistroWindows.mtdSalvarDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "ColetorDados",
                    "GerarPassoAutomatico",
                    chkGerarPassoAutomatico.Checked.ToString(),
                    Microsoft.Win32.RegistryValueKind.String
                    );
                string strExcecao = "mtdGerarPassoAutomatico: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
            finally
            {
            }
        }

        private void chkGerarPassoAutomatico_CheckStateChanged(object sender, EventArgs e)
        {
            objRegistroWindows.mtdSalvarDadosRegistro
            (
            Microsoft.Win32.Registry.CurrentUser,
            "Software",
            "Eletronorte",
            "ColetorDados",
            "GerarPassoAutomatico",
            chkGerarPassoAutomatico.Checked.ToString(),
            Microsoft.Win32.RegistryValueKind.String
            );

            blnGerarPassoAutomatico = chkGerarPassoAutomatico.Checked;
        }
    }
}