using System;
using System.Windows.Forms;
using System.Threading;

namespace Solucoes_Rede_Neural_CSNet
{
    public partial class frmRedeNeural : Form
    {
        // Variável de Instância
        private clsEnderecoAplicativo objEnderecoAplicativo = new clsEnderecoAplicativo();
        public string varEnderecoAplicativo;
        // Variáveis de classe
        // Para usá-las, não precisa ser instancido nenhum objeto.
        public static string ENDERECOARQUIVOENTRADASTREINAMENTO;
        public static string ENDERECOARQUIVOTARGET;
        public static string ENDERECOARQUIVOPESOS;
        public static string ENDERECOARQUIVOERRO;
        public static string ENDERECOARQUIVORESULTADOS;
        public static int NumeroEntrada, NumeroPadroes, NumeroPadroesConferencia, NumeroSaida, NumeroEscondida, NumeroIteracoes;
        public static Thread Th1, Th2;
        private static int linhamatriz = 1001;
        // Variáveis de instância
        // Para usá-las, precisa ser instancido pelo menos um objeto.
        public string[,] matriz = new string[linhamatriz, 10001];
        private int c = 0, l = 0, maxc = 0;
        public static DataGridView dtgv;
        delegate void SetTextCallback(string text);
        delegate void SetText2Callback(string text);
        delegate void SetValueCallback(int value);
        private System.ComponentModel.BackgroundWorker backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
        private clsArquivoTXT objArquivoTXT = new clsArquivoTXT();
        private clsManipuladorTexto objManipuladorTexto = new clsManipuladorTexto();
        private double epocaporcent = 0, erro, erro_max = 0.004;
        private string tipoerro = string.Empty, tiposaida = string.Empty, tipodelta = String.Empty,
        tipoprioridade = string.Empty, tipotarefa = string.Empty;
        private string resultado = string.Empty, strerro, strpesos;
        private DateTime tempoinicio, tempoexecucao;
        private string oldtxt1text = string.Empty;

        public frmRedeNeural()
        {
            InitializeComponent();
        }

        private void frmRedeNeural_Load(object sender, EventArgs e)
        {
            this.backgroundWorker1.RunWorkerAsync();
            IniciarThreadProgresso();
            cmb1.Items.Add("Sigmoidal SAIDAs");
            cmb1.Items.Add("Linear SAIDAs");
            cmb1.Text = cmb1.Items[0].ToString();
            cmb2.Items.Add("SSE");
            cmb2.Items.Add("Erro de Entropia Cruzada");
            cmb2.Text = cmb2.Items[0].ToString();
            cmb3.Items.Add("Sigmoidal SAIDAs, SSE");
            cmb3.Items.Add("Sigmoidal SAIDAs, Cross-Entropy Erro");
            cmb3.Text = cmb3.Items[0].ToString();
            cmb4.Items.Add("Baixa");
            cmb4.Items.Add("Abaixo do Normal");
            cmb4.Items.Add("Normal");
            cmb4.Items.Add("Acima do Normal");
            cmb4.Items.Add("Alta");
            cmb4.Text = cmb4.Items[2].ToString();
            cmb5.Items.Add("Aprendizagem");
            cmb5.Items.Add("Verificação");
            cmb5.Text = cmb5.Items[0].ToString();
            tiposaida = cmb1.Text;
            tipoerro = cmb2.Text;
            tipodelta = cmb3.Text;
            tipoprioridade = cmb4.Text;
            tipotarefa = cmb5.Text;
            txt1.Text = "1000";
            oldtxt1text = txt1.Text;
            mtdAtributos();
            varEnderecoAplicativo = objEnderecoAplicativo.Endereco();
            ENDERECOARQUIVOENTRADASTREINAMENTO = varEnderecoAplicativo + "Rede Neural\\entradas.dat";
            ENDERECOARQUIVOTARGET = varEnderecoAplicativo + "Rede Neural\\target.dat";
            ENDERECOARQUIVOPESOS = varEnderecoAplicativo + "Rede Neural\\pesos.dat";
            ENDERECOARQUIVOERRO = varEnderecoAplicativo + "Rede Neural\\erro.dat";
            ENDERECOARQUIVORESULTADOS = varEnderecoAplicativo + "Rede Neural\\resultados.dat";
            dtgv = new DataGridView();
        }

        private void recebe_entradas(ref double[,] entrada)
        {
            RotinaLeitura(ENDERECOARQUIVOENTRADASTREINAMENTO); // recebe_entradas 
            for (int coluna = entrada.GetLowerBound(0); coluna < entrada.GetUpperBound(0); coluna += 1)
            {
                for (int linha = entrada.GetLowerBound(1); linha < entrada.GetUpperBound(1); linha += 1)
                {
                    entrada[coluna + 1, linha + 1] = Convert.ToDouble(matriz[linha, coluna]);
                }
            }
        }

        private void recebe_target(ref double[,] target)
        {
            RotinaLeitura(ENDERECOARQUIVOTARGET); // recebe_target 
            for (int coluna = target.GetLowerBound(0); coluna < target.GetUpperBound(0); coluna += 1)
            {
                for (int linha = target.GetLowerBound(1); linha < target.GetUpperBound(1); linha += 1)
                {
                    target[coluna + 1, linha + 1] = Convert.ToDouble(matriz[linha, coluna]);
                }
            }
        }

        private void recebe_pesos(ref double[,] W12, ref double[,] W23)
        {
            int colunacount = 0;
            RotinaLeitura(ENDERECOARQUIVOPESOS);
            // recebe_entradas 
            for (int coluna = W12.GetLowerBound(0); coluna <= W12.GetUpperBound(0); coluna += 1)
            {
                for (int linha = W12.GetLowerBound(1); linha < W12.GetUpperBound(1); linha += 1)
                {
                    W12[coluna, linha + 1] = Convert.ToDouble(matriz[coluna, linha]);
                    colunacount = linha;
                }
            }
            for (int coluna = W23.GetLowerBound(0); coluna <= W23.GetUpperBound(0); coluna += 1)
            {
                for (int linha = W23.GetLowerBound(1); linha < W23.GetUpperBound(1); linha += 1)
                {
                    W23[coluna, linha + 1] = Convert.ToDouble(matriz[coluna, linha + colunacount + 1]);
                }
            }
        }

        private void exporta_pesos(string strpesos)
        {
            objArquivoTXT.mtdCriadorTexto(ENDERECOARQUIVOPESOS, strpesos);
        }

        public void RotinaCadastro(string EnderecoArquivo, ref DataGridView dtgv)
        {
            string saida = string.Empty;
            for (int linha = 0; linha <= dtgv.Rows.Count - 2; linha += 1)
            {
                for (int coluna = 0; coluna <= dtgv.Columns.Count - 1; coluna += 1)
                {
                    saida += dtgv.Rows[linha].Cells[coluna].Value.ToString();
                    if (coluna < dtgv.Columns.Count - 1)
                    {
                        saida += Convert.ToChar(9).ToString();
                    }
                    else
                    {
                        saida = objManipuladorTexto.mtdTiradorCaractereInvalido(saida);
                    }
                }
                saida += Convert.ToChar(13).ToString() + Convert.ToChar(10).ToString();
            }
            saida = saida.Trim();
            objArquivoTXT.mtdCriadorTexto(EnderecoArquivo, saida);
            frmRedeNeural.dtgv = dtgv;
        }

        public void RotinaLeitura(string EnderecoArquivo)
        {
            // Laço com função de atribuir zero para todos os elementos da matriz entrada. 
            for (int linha = matriz.GetLowerBound(0); linha <= matriz.GetUpperBound(0); linha++)
            {
                for (int coluna = matriz.GetLowerBound(1); coluna <= matriz.GetUpperBound(1); coluna++)
                {
                    matriz[linha, coluna] = "0";
                }
            }
            string str = String.Empty;
            try
            {
                str = objArquivoTXT.mtdLeitorTexto(EnderecoArquivo);
            }
            catch
            {
                System.IO.Directory.CreateDirectory(varEnderecoAplicativo + "Rede Neural\\");
                objArquivoTXT.mtdCriadorTexto(EnderecoArquivo, String.Empty);
                str = objArquivoTXT.mtdLeitorTexto(EnderecoArquivo);
            }
            string temporario = string.Empty;
            c = 0;
            l = 0;
            maxc = 0;
            str = objArquivoTXT.mtdLeitorTexto(EnderecoArquivo);
            string texto = string.Empty;
            for (int i = 0; i <= str.Length - 1; i += 1)
            {
                char caractere = Convert.ToChar(str.Substring(i, 1));
                int numcaractere = Convert.ToInt32(caractere);
                switch (numcaractere)
                {
                    case 9:
                        c += 1;
                        maxc = c;
                        texto = string.Empty;
                        break;
                    case 10:
                        break;
                    case 13:
                        c = 0;
                        l += 1;
                        texto = string.Empty;
                        break;
                    case 32:
                        c += 1;
                        maxc = c;
                        texto = string.Empty;
                        break;
                    default:
                        texto += caractere;
                        break;
                }
                matriz[c, l] = texto;
            }
        }

        private static object thisLock = new object();

        public void PreencherDataGridView(ref DataGridView dtgv, string nomecoluna)
        {

            lock (thisLock)
            {
                try
                {
                    dtgv.Columns.Clear();
                    dtgv.Rows.Clear();
                }
                catch
                {
                }
                for (int contador = 0; contador <= maxc; contador += 1)
                {
                    dtgv.Columns.Add(nomecoluna + String.Format((contador + 1).ToString(), "000"), nomecoluna + String.Format((contador + 1).ToString(), "000"));
                }
                for (int linha = 0; linha < l; linha += 1)
                {
                    dtgv.Rows.Add();
                }
                string output = string.Empty;
                for (int linha = 0; linha < l; linha += 1)
                {
                    for (int coluna = 0; coluna <= maxc; coluna += 1)
                    {
                        dtgv.Rows[linha].Cells[coluna].Value = matriz[coluna, linha];
                    }
                }
                frmRedeNeural.dtgv = dtgv;
            }
        }

        public void RePreencherDataGridView(ref DataGridView dtgv, ref ListView lstv)
        {
            int contador = 0;
            dtgv.Columns.Clear();
            for (contador = 0; contador < lstv.Items.Count; contador += 1)
            {
                dtgv.Columns.Add(lstv.Items[contador].Text.ToString(), lstv.Items[contador].Text.ToString());
            }
        }

        private void RotinaExecutar()
        {
            if (txt1.Text == string.Empty)
            {
                txt1.Text = "1000";
            }
            if (txt2.Text == string.Empty)
            {
                txt2.Text = "0.004";
            }
            if (txt3.Text == string.Empty)
            {
                txt3.Text = "2";
            }
            NumeroIteracoes = Convert.ToInt32(txt1.Text);
            erro_max = Convert.ToDouble(txt2.Text);
            NumeroEscondida = Convert.ToInt32(txt3.Text);
            this.Cursor = Cursors.WaitCursor;
            pgbr1.Value = pgbr1.Minimum;
            tempoinicio = DateTime.Now;
            IniciarThreadExecutar();
            pgbr1.Value = pgbr1.Maximum;
            this.Cursor = Cursors.Default;
        }

        private void IniciarThreadProgresso()
        {
            Th1 = new Thread(new ThreadStart(this.RotinaThreadProgresso));
            Th1.IsBackground = true;
            Th1.Priority = ThreadPriority.Normal;
            Th1.Start();
        }

        private void RotinaThreadProgresso()
        {
            string strtempoestimado = string.Empty;
            try
            {
                do
                {
                    string NewText = epocaporcent + " %";
                    long tempoparcial = (long)tempoexecucao.Subtract(tempoinicio).TotalSeconds;
                    double tempoestimado = ((tempoparcial) / epocaporcent) * 100;
                    if (double.IsNaN(tempoestimado))
                    {
                        strtempoestimado = "não há estimativa";
                    }
                    else
                    {
                        strtempoestimado = Convert.ToString(Math.Round(tempoestimado)) + " (s)";
                    }
                    double LogErro = (double)((erro != 0 ? Math.Log10(erro) : 1));
                    string strFormatoErro = string.Empty;
                    if (LogErro < 0)
                    {
                        strFormatoErro = "0.";
                        for (int contador = 0; contador < (int)Math.Round(Math.Abs(LogErro)) + 1; contador++)
                        {
                            strFormatoErro += "0";
                        }
                    }
                    else
                    {
                        strFormatoErro = "0";
                    }
                    string NewText2 = "Tempo para o cálculo: " + string.Format(tempoparcial.ToString(), "0") + " (s); Tempo estimado: " + strtempoestimado + "; Erro atual: " + erro.ToString(strFormatoErro) + ".";
                    int NewValue = Convert.ToInt32(epocaporcent);
                    if (this.lbl2.InvokeRequired)
                    {
                        SetTextCallback d = new SetTextCallback(this.SetText);
                        SetText2Callback e = new SetText2Callback(this.SetText2);
                        SetValueCallback f = new SetValueCallback(this.SetValue);
                        this.Invoke(d, new object[] { (NewText) });
                        this.Invoke(e, new object[] { (NewText2) });
                        this.Invoke(f, new object[] { (NewValue) });
                    }
                    else
                    {
                        this.lbl2.Text = NewText;
                        this.lbl4.Text = NewText2;
                        if (this.pgbr1.Value < pgbr1.Maximum)
                        {
                            this.pgbr1.Value = Convert.ToInt32(epocaporcent);
                        }
                    }
                    Thread.Sleep(1);
                }
                while (true);
            }
            catch
            {
            }
        }

        private void SetText(string text)
        {
            this.lbl2.Text = text;
        }

        private void SetText2(string text)
        {
            this.lbl4.Text = text;
        }

        private void SetValue(int value)
        {
            this.pgbr1.Value = value;
        }

        private void IniciarThreadExecutar()
        {
            Th2 = new Thread(new ThreadStart(this.RotinaThreadExecutar));
            Th2.IsBackground = true;
            switch (tipoprioridade)
            {
                case "Baixa":
                    Th2.Priority = ThreadPriority.Lowest;
                    break;
                case "Abaixo do Normal":
                    Th2.Priority = ThreadPriority.BelowNormal;
                    break;
                case "Normal":
                    Th2.Priority = ThreadPriority.Normal;
                    break;
                case "Acima do Normal":
                    Th2.Priority = ThreadPriority.AboveNormal;
                    break;
                case "Alta":
                    Th2.Priority = ThreadPriority.Highest;
                    break;
            }
            Th2.Start();
        }

        private void RotinaThreadExecutar()
        {
            clsRedeNeural objRedeNeural = new clsRedeNeural();
            // Definição do Módulo Rede Neural 
            frmVisualizador objFV = new frmVisualizador();
            objFV.EnderecoArquivo(ENDERECOARQUIVOENTRADASTREINAMENTO);
            frmVisualizador.tipoformulario = "Entradas";
            objFV.mtdLer(dtgv);
            objFV.mtdCadastrar(dtgv);
            objFV.EnderecoArquivo(ENDERECOARQUIVOTARGET);
            frmVisualizador.tipoformulario = "Target";
            objFV.mtdLer(dtgv);
            objFV.mtdCadastrar(dtgv);
            objFV.Close();
            double[,] entrada = new double[NumeroPadroes + 1, NumeroEntrada + 1];
            double[,] target = new double[NumeroPadroesConferencia + 1, NumeroSaida + 1];
            double[,] W12 = new double[NumeroEntrada + 1, NumeroEscondida + 1];
            double[,] W23 = new double[NumeroEscondida + 1, NumeroSaida + 1];
            recebe_entradas(ref entrada);
            recebe_target(ref target);
            switch (tipotarefa)
            {
                case "Aprendizagem":
                    if (objRedeNeural.mtdExecutar(ref entrada, ref target, NumeroEscondida, NumeroIteracoes, ref erro, erro_max, tiposaida, tipoerro, tipodelta, ref resultado, ref strerro,
                   ref strpesos, ref epocaporcent, ref tempoexecucao, tipotarefa))
                    {
                        objArquivoTXT.mtdCriadorTexto(ENDERECOARQUIVOERRO, strerro);
                        objArquivoTXT.mtdCriadorTexto(ENDERECOARQUIVORESULTADOS, resultado);
                        exporta_pesos(strpesos);
                        MessageBox.Show("A tarefa foi concluída.", "Aviso!", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("O comprimento do vetor entrada é diferente do comprimento do vetor target, corrija-os.", "Aviso!", MessageBoxButtons.OK);
                    }
                    break;
                case "Verificação":
                    recebe_pesos(ref W12, ref W23);
                    if (objRedeNeural.mtdExecutar(ref entrada, ref  target, ref W12, ref W23, NumeroEscondida, NumeroIteracoes, ref erro, erro_max, tiposaida, tipoerro, tipodelta,
                    ref resultado, ref strerro, ref strpesos, ref  epocaporcent, ref tempoexecucao, tipotarefa))
                    {
                        objArquivoTXT.mtdCriadorTexto(ENDERECOARQUIVOERRO, strerro);
                        objArquivoTXT.mtdCriadorTexto(ENDERECOARQUIVORESULTADOS, resultado);
                        MessageBox.Show("A tarefa foi concluída.", "Aviso!", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("O comprimento do vetor entrada é diferente do comprimento do vetor target, corrija-os.", "Aviso!", MessageBoxButtons.OK);
                    }
                    break;
            }
        }

        private void mtdAtributos()
        {
            tslbl2.Text = Convert.ToString(this.Location.X);
            tslbl4.Text = Convert.ToString(this.Location.Y);
            tslbl6.Text = Convert.ToString(this.Width);
            tslbl8.Text = Convert.ToString(this.Height);
        }

        private void btnExecutar_Click(object sender, EventArgs e)
        {
            RotinaExecutar();
        }

        private void btnAbortar_Click(object sender, EventArgs e)
        {
            try
            {
                Th2.GetApartmentState();
                if (MessageBox.Show("Você deseja realmente abortar a operação?", "Aviso!", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    Th2.Abort();
                    MessageBox.Show("A operação foi abortada!", "Aviso!", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("A operação ainda continua em execução.", "Aviso!", MessageBoxButtons.OK);
                }
            }
            finally
            {
                MessageBox.Show("Não foi iniciada nenhuma operação.", "Aviso!", MessageBoxButtons.OK);

            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnE_Click(object sender, EventArgs e)
        {
            frmVisualizador objFV = new frmVisualizador();
            objFV.MdiParent = Program.objPrincipal;
            objFV.EnderecoArquivo(ENDERECOARQUIVOENTRADASTREINAMENTO);
            frmVisualizador.tipoformulario = "Entradas";
            objFV.Show();
        }

        private void btnT_Click(object sender, EventArgs e)
        {
            frmVisualizador objFV = new frmVisualizador();
            objFV.MdiParent = Program.objPrincipal;
            objFV.EnderecoArquivo(ENDERECOARQUIVOTARGET);
            frmVisualizador.tipoformulario = "Target";
            objFV.Show();
        }

        private void btnP_Click(object sender, EventArgs e)
        {
            frmVisualizador objFV = new frmVisualizador();
            objFV.MdiParent = Program.objPrincipal;
            objFV.EnderecoArquivo(ENDERECOARQUIVOPESOS);
            frmVisualizador.tipoformulario = "Pesos";
            objFV.Show();
        }

        private void btnEr_Click(object sender, EventArgs e)
        {
            frmVisualizador objFV = new frmVisualizador();
            objFV.MdiParent = Program.objPrincipal;
            objFV.EnderecoArquivo(ENDERECOARQUIVOERRO);
            frmVisualizador.tipoformulario = "Erro";
            objFV.Show();
        }

        private void btnR_Click(object sender, EventArgs e)
        {
            frmVisualizador objFV = new frmVisualizador();
            objFV.MdiParent = Program.objPrincipal;
            objFV.EnderecoArquivo(ENDERECOARQUIVORESULTADOS);
            frmVisualizador.tipoformulario = "Resultado";
            objFV.Show();
        }

        private void cmb1_SelectedValueChanged(object sender, EventArgs e)
        {
            tiposaida = cmb1.Text;
        }

        private void cmb2_SelectedValueChanged(object sender, EventArgs e)
        {
            tipoerro = cmb2.Text;
        }

        private void cmb3_SelectedValueChanged(object sender, EventArgs e)
        {
            tipodelta = cmb3.Text;
        }

        private void cmb4_SelectedValueChanged(object sender, EventArgs e)
        {
            tipoprioridade = cmb4.Text;
        }

        private void cmb5_SelectedValueChanged(object sender, EventArgs e)
        {
            tipotarefa = cmb5.Text;
            if (tipotarefa == "Aprendizagem")
            {
                txt1.Enabled = true;
                txt1.Text = oldtxt1text;
            }
            else if (tipotarefa == "Verificação")
            {
                txt1.Enabled = false;
                oldtxt1text = txt1.Text;
                txt1.Text = Convert.ToString(2);
            }
        }
    }
}