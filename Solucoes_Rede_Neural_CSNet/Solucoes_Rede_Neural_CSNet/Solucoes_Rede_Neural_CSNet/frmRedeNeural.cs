using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using BibliotecaTemporaria_CSNet;
using BibliotecaRedeNeural;

using System.Data.OleDb;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;


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
        private static int linhamatriz = 1000;
        // Variáveis de instância
        // Para usá-las, precisa ser instancido pelo menos um objeto.
        public string[,] matriz = new string[linhamatriz, 10000];
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
            ENDERECOARQUIVOENTRADASTREINAMENTO = varEnderecoAplicativo + "Rede Neural\\entradastreinamento.dat";
            ENDERECOARQUIVOTARGET = varEnderecoAplicativo + "Rede Neural\\target.dat";
            ENDERECOARQUIVOPESOS = varEnderecoAplicativo + "Rede Neural\\pesos.dat";
            ENDERECOARQUIVOERRO = varEnderecoAplicativo + "Rede Neural\\erro.dat";
            ENDERECOARQUIVORESULTADOS = varEnderecoAplicativo + "Rede Neural\\resultados.dat";
            dtgv = new DataGridView();
        }

        private void recebe_entradas(ref double[,] entrada)
        {
            RotinaLeitura(ENDERECOARQUIVOENTRADASTREINAMENTO);
            // recebe_entradas 
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
            RotinaLeitura(ENDERECOARQUIVOTARGET);
            // recebe_target 
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
        public void PreencherDataGridView(ref DataGridView dtgv, string nomecoluna)
        {
            dtgv.Columns.Clear();
            dtgv.Rows.Clear();
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
            frmVisualizador.tipoformulario = "EntradasTreinamento";
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

        private void btnET_Click(object sender, EventArgs e)
        {
            frmVisualizador objFV = new frmVisualizador();
            //objFV.MdiParent = this;
            objFV.EnderecoArquivo(ENDERECOARQUIVOENTRADASTREINAMENTO);
            frmVisualizador.tipoformulario = "EntradasTreinamento";
            objFV.Show();
        }

        private void btnT_Click(object sender, EventArgs e)
        {
            frmVisualizador objFV = new frmVisualizador();
            //objFV.MdiParent = objPrincipal;
            objFV.EnderecoArquivo(ENDERECOARQUIVOTARGET);
            frmVisualizador.tipoformulario = "Target";
            objFV.Show();
        }

        private void btnP_Click(object sender, EventArgs e)
        {
            frmVisualizador objFV = new frmVisualizador();
            //objFV.MdiParent = objPrincipal;
            objFV.EnderecoArquivo(ENDERECOARQUIVOPESOS);
            frmVisualizador.tipoformulario = "Pesos";
            objFV.Show();
        }

        private void btnE_Click(object sender, EventArgs e)
        {
            frmVisualizador objFV = new frmVisualizador();
            //objFV.MdiParent = objPrincipal;
            objFV.EnderecoArquivo(ENDERECOARQUIVOERRO);
            frmVisualizador.tipoformulario = "Erro";
            objFV.Show();
        }

        private void btnR_Click(object sender, EventArgs e)
        {
            frmVisualizador objFV = new frmVisualizador();
            //objFV.MdiParent = objPrincipal;
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

namespace BibliotecaRedeNeural
{
    public class clsRedeNeural
    {
        // Variáveis de classe.
        private static Random objRandom = new Random();
        // Variáveis de instância.
        private int NumEntrada, NumPadroes, NumSaida, NumEscondida, NumIteracoes;
        private int i, j, k, p, np, op, epoca;
        private double Erro, eta = 0.05, alpha = 0, wmax = 1;
        private double rando = objRandom.NextDouble();
        private string tipoerro = string.Empty, tiposaida = string.Empty, tipodelta = string.Empty, tipoprioridade = string.Empty;
        private int NumPadroesConferencia;
        private string resultado = string.Empty;
        private double dblMaximoValor = 0;
        public string Autor()
        {
            return "Joel Fernado Jardim Martins";
        }
        public string Adaptadopor()
        {
            return "Hebervaldo de Paula Carvalhêdo";
        }
        public string NotadoAutor()
        {
            return "Projeto final de conclusão de curso de Engenharia Elétrica na UNB, que trata sobre redes neurais.";
        }
        public string NotadoAplicativo()
        {
            return "Módulo de Rede Neural feito em C-Sharp.";
        }
        public bool mtdExecutar(ref double[,] entrada, ref double[,] target, int NumeroEscondida, int NumeroIteracoes,
        ref double erro, double erromax, string tiposaida, string tipoerro, string tipodelta, ref string resultado,
        ref string strerro, ref string strpesos, ref double epocaporcent, ref DateTime tempoexecucao, string ModoOperacao)
        {
            this.NumEntrada = entrada.GetUpperBound(1) - entrada.GetLowerBound(1);
            this.NumSaida = target.GetUpperBound(1) - target.GetLowerBound(1);
            this.NumPadroes = entrada.GetUpperBound(0) - entrada.GetLowerBound(0);
            this.NumPadroesConferencia = target.GetUpperBound(0) - target.GetLowerBound(0);
            this.NumEscondida = NumeroEscondida;
            this.NumIteracoes = NumeroIteracoes;
            double[,] W12 = new double[NumEntrada + 1, NumEscondida + 1];
            double[,] W23 = new double[NumEscondida + 1, NumSaida + 1];
            // Os dois laços a seguir geram valores aleatórios para os vetores pesos W12 e W23.
            for (j = 1; j <= NumEscondida; j++)
            {
                for (i = 0; i <= NumEntrada; i++)
                {
                    rando = objRandom.NextDouble();
                    W12[i, j] = 2.0 * (rando - 0.5) * wmax;
                }
            }
            for (k = 1; k <= NumSaida; k++) // inicializa W23 e DeltaW23 
            {
                for (j = 0; j <= NumEscondida; j++)
                {
                    rando = objRandom.NextDouble();
                    W23[j, k] = 2.0 * (rando - 0.5) * wmax;
                }
            }
            return mtdRotina(entrada, target, ref W12, ref W23, NumeroEscondida, NumeroIteracoes, ref erro, erromax, tiposaida,
            tipoerro, tipodelta, ref resultado, ref strerro, ref strpesos, ref epocaporcent, ref  tempoexecucao);
        }
        public bool mtdExecutar(ref double[,] entrada, ref double[,] target, ref double[,] W12, ref double[,] W23,
        int NumeroEscondida, int NumeroIteracoes, ref double erro, double erromax, string tiposaida, string tipoerro,
        string tipodelta, ref string resultado, ref string strerro, ref string strpesos, ref double epocaporcent,
        ref DateTime tempoexecucao, string ModoOperacao)
        {
            this.NumEntrada = entrada.GetUpperBound(1) - entrada.GetLowerBound(1);
            this.NumSaida = target.GetUpperBound(1) - target.GetLowerBound(1);
            this.NumPadroes = entrada.GetUpperBound(0) - entrada.GetLowerBound(0);
            this.NumPadroesConferencia = target.GetUpperBound(0) - target.GetLowerBound(0);
            this.NumEscondida = NumeroEscondida;
            this.NumIteracoes = NumeroIteracoes;
            // Zerar o vetor target para que não haja influência do target no resultado.
            for (int linha = target.GetLowerBound(0); linha <= target.GetUpperBound(0); linha++)
            {
                for (int coluna = target.GetLowerBound(1); coluna <= target.GetUpperBound(1); coluna++)
                {
                    target[linha, coluna] = 0;
                }
            }
            return mtdRotina(entrada, target, ref W12, ref  W23, NumeroEscondida, NumeroIteracoes, ref erro, erromax,
            tiposaida, tipoerro, tipodelta, ref resultado, ref strerro, ref strpesos, ref epocaporcent, ref  tempoexecucao);
        }
        private bool mtdRotina(double[,] entrada, double[,] target, ref double[,] W12, ref double[,] W23,
        int NumeroEscondida, int NumeroIteracoes, ref double erro, double erromax, string tiposaida, string tipoerro,
        string tipodelta, ref string resultado, ref string strerro, ref string strpesos, ref double epocaporcent,
        ref DateTime tempoexecucao)
        {
            bool blnMensagem = false;
            resultado = string.Empty;
            double dblmaxvetvalor;
            int[] ranpad = new int[NumPadroes + 1];
            double[,] SomaEscondida = new double[NumPadroes + 1, NumEscondida + 1];
            double[,] Escondida = new double[NumPadroes + 1, NumEscondida + 1];
            double[,] SomaSaida = new double[NumPadroes + 1, NumSaida + 1];
            double[,] SAIDA = new double[NumPadroes + 1, NumSaida + 1];
            double[] DeltaS = new double[NumSaida + 1];
            double[] somaDWS = new double[NumEscondida + 1];
            double[] DeltaE = new double[NumEscondida + 1];
            double[,] DeltaW12 = new double[NumEntrada + 1, NumEscondida + 1];
            double[,] DeltaW23 = new double[NumEscondida + 1, NumSaida + 1];
            double maxvetentrada = mtdMaximoValor(entrada);
            double maxvettarget = mtdMaximoValor(target);
            int restoepoca = 0;
            int divNumIteracoes = Convert.ToInt32(NumIteracoes / 100);
            if (divNumIteracoes != 0)
            {
                restoepoca = epoca % divNumIteracoes;
            }
            else
            {
                restoepoca = 0;
            }
            if (maxvetentrada > maxvettarget)
            {
                dblmaxvetvalor = maxvetentrada;
            }
            else
            {
                dblmaxvetvalor = maxvettarget;
            }
            mtdNormalizarMatriz(ref entrada, dblmaxvetvalor);
            mtdNormalizarMatriz(ref target, dblmaxvetvalor);
            if (NumPadroes == NumPadroesConferencia)
            {
                for (epoca = 0; epoca < NumIteracoes; epoca++) // faz a iteração da atualização dos pesos
                {
                    for (p = 1; p <= NumPadroes; p++) // randomiza a ordem dos indivíduos
                    {
                        ranpad[p] = p;
                    }
                    for (p = 1; p <= NumPadroes; p++)
                    {
                        rando = objRandom.NextDouble();
                        np = Convert.ToInt32(Math.Truncate(p + rando * (NumPadroes + 1 - p)));
                        op = ranpad[p];
                        ranpad[p] = ranpad[np];
                        ranpad[np] = op;
                    }
                    this.Erro = 0;
                    for (np = 1; np <= NumPadroes; np++) // repete para todos os padrões de treinamento
                    {
                        p = ranpad[np];
                        for (j = 1; j <= NumEscondida; j++) // computa as ativações da unidade escondida
                        {
                            SomaEscondida[p, j] = W12[0, j];
                            for (i = 1; i <= NumEntrada; i++)
                            {
                                SomaEscondida[p, j] += entrada[p, i] * W12[i, j];
                            }
                            Escondida[p, j] = 1 / (1 + Math.Exp(-SomaEscondida[p, j]));
                            // Escondida[p, j] = [Exp[SomaSaida[p, j]] - Exp[-SomaSaida[p, j]]] / [Exp[SomaSaida[p, j]] + Exp[-SomaSaida[p, j]]]
                        }
                        for (k = 1; k <= NumSaida; k++) // computa as unidades de ativação da saída e erros
                        {
                            SomaSaida[p, k] = W23[0, k];
                            for (j = 1; j <= NumEscondida; j++)
                            {
                                SomaSaida[p, k] += Escondida[p, j] * W23[j, k];
                            }
                            if (tiposaida == "Sigmoidal SAIDAs")
                            {
                                SAIDA[p, k] = 1 / (1 + Math.Exp(-SomaSaida[p, k])); // Sigmoidal SAIDAs
                            }
                            else if (tiposaida == "Linear SAIDAs")
                            {
                                SAIDA[p, k] = SomaSaida[p, k]; // Linear SAIDAs
                            }
                            if (tipoerro == "SSE")
                            {
                                this.Erro += 0.5 * Math.Pow((target[p, k] - SAIDA[p, k]), 2);  // SSE 
                            }
                            else if (tipoerro == "Erro de Entropia Cruzada")
                            {
                                this.Erro -= (target[p, k] * Math.Log(SAIDA[p, k]) + (1 - target[p, k]) * Math.Log(1 - SAIDA[p, k])); // Erro de Entropia Cruzada
                            }                            // strtemp  &= "Erro: " & Erro & "." & vbNewLine
                            if (tipodelta == "Sigmoidal SAIDAs, SSE")
                            {
                                DeltaS[k] = (target[p, k] - SAIDA[p, k]) * SAIDA[p, k] * (1 - SAIDA[p, k]); // Sigmoidal SAIDAs, SSE 
                            }
                            else if (tipodelta == "Sigmoidal SAIDAs, Cross-Entropy Erro")
                            {
                                DeltaS[k] = target[p, k] - SAIDA[p, k]; // Sigmoidal SAIDAs, Cross-Entropy Erro 
                            }
                            // DeltaS[[k] = target[p, k] - SAIDA[p, k]] // Linear SAIDAs, SSE
                        }
                        for (j = 1; j <= NumEscondida; j++) // retropropagação de erros para a camada escondida
                        {
                            somaDWS[j] = 0;
                            for (k = 1; k <= NumSaida; k++)
                            {
                                somaDWS[j] += W23[j, k] * DeltaS[k];
                            }
                            DeltaE[j] = somaDWS[j] * Escondida[p, j] * (1 - Escondida[p, j]);
                        }
                        for (j = 1; j <= NumEscondida; j++)
                        { // atualiza pesos w12
                            DeltaW12[0, j] = eta * DeltaE[j] + alpha * DeltaW12[0, j];
                            W12[0, j] += DeltaW12[0, j];
                            for (i = 1; i <= NumEntrada; i++)
                            {
                                DeltaW12[i, j] = eta * entrada[p, i] * DeltaE[j] + alpha * DeltaW12[i, j];
                                W12[i, j] += DeltaW12[i, j];
                            }
                        }
                        for (k = 1; k <= NumSaida; k++) // atualiza pesos W23 
                        {
                            DeltaW23[0, k] = eta * DeltaS[k] + alpha * DeltaW23[0, k];
                            W23[0, k] += DeltaW23[0, k];
                            for (j = 1; j <= NumEscondida; j++)
                            {
                                DeltaW23[j, k] = eta * Escondida[p, j] * DeltaS[k] + alpha * DeltaW23[j, k];
                                W23[j, k] += DeltaW23[j, k];
                            }
                        }
                    }
                    erro = this.Erro;
                    strerro += "epoca" + "\t" + epoca + "\t" + "erro" + "\t" + this.Erro + Convert.ToChar(13).ToString() + Convert.ToChar(10).ToString();
                    epocaporcent = ((double)epoca / NumIteracoes) * 100;
                    tempoexecucao = DateTime.Now;
                    if (this.Erro < erromax) { break; } // pára o aprendizado quando o erro convergir para o valor descrito 
                }
                mtdDesNormalizarMatriz(ref entrada, dblmaxvetvalor);
                mtdDesNormalizarMatriz(ref target, dblmaxvetvalor);
                mtdDesNormalizarMatriz(ref SAIDA, dblmaxvetvalor);
                for (int p = 1; p <= NumPadroes; p++)
                {
                    for (int i = entrada.GetLowerBound(1) + 1; i <= entrada.GetUpperBound(1); i += 1)
                    {
                        resultado += entrada[p, i] + "\t";
                    }
                    for (int i = target.GetLowerBound(1) + 1; i <= target.GetUpperBound(1); i += 1)
                    {
                        resultado += target[p, i] + "\t";
                    }
                    for (int i = target.GetLowerBound(1) + 1; i <= target.GetUpperBound(1); i += 1)
                    {
                        resultado += SAIDA[p, i] + "\t";
                    }
                    resultado += Convert.ToChar(13).ToString() + Convert.ToChar(10).ToString();
                }
                strpesos = mtdPesos(W23, mtdPesos(W12, string.Empty) + Convert.ToChar(13) + Convert.ToChar(10));
                resultado = resultado.Trim();
                strerro = strerro.Trim();
                blnMensagem = true; // "O comprimento do vetor entrada é igual do comprimento do vetor target."
                epocaporcent = 100;
                tempoexecucao = DateTime.Now;
            }
            else
            {
                blnMensagem = false; // "O comprimento do vetor entrada é diferente do comprimento do vetor target."
            }
            return blnMensagem;
        }
        private void mtdNormalizarMatriz(ref double[,] matriz, double maxvalorvetor)
        {
            for (int linha = matriz.GetLowerBound(0); linha <= matriz.GetUpperBound(0); linha++)
            {
                for (int coluna = matriz.GetLowerBound(1); coluna <= matriz.GetUpperBound(1); coluna++)
                {
                    matriz[linha, coluna] /= maxvalorvetor;
                }
            }
        }
        private void mtdDesNormalizarMatriz(ref double[,] matriz, double maxvalorvetor)
        {
            for (int linha = matriz.GetLowerBound(0); linha <= matriz.GetUpperBound(0); linha++)
            {
                for (int coluna = matriz.GetLowerBound(1); coluna <= matriz.GetUpperBound(1); coluna++)
                {
                    matriz[linha, coluna] *= maxvalorvetor;
                }
            }
        }
        private double mtdMaximoValor(double[,] matriz)
        {
            for (int linha = matriz.GetLowerBound(0); linha <= matriz.GetUpperBound(0); linha++)
            {
                for (int coluna = matriz.GetLowerBound(1); coluna <= matriz.GetUpperBound(1); coluna++)
                {
                    if (matriz[linha, coluna] > dblMaximoValor)
                    {
                        dblMaximoValor = matriz[linha, coluna];
                    }
                }
            } return dblMaximoValor;
        }
        private string mtdPesos(double[,] matriz, string TextoAnterior)
        {
            string saida = TextoAnterior;
            for (int linha = matriz.GetLowerBound(1) + 1; linha <= matriz.GetUpperBound(1); linha++) // Esse laço tem diferença no VB.NET, pois o termo final da matriz é menor em um no C-Sharp.
            {
                for (int coluna = matriz.GetLowerBound(0); coluna <= matriz.GetUpperBound(0); coluna++) // Esse laço tem diferença no VB.NET, pois o termo final da matriz é menor em um no C-Sharp.
                {
                    saida += matriz[coluna, linha].ToString();
                    saida += Convert.ToChar(9).ToString();
                }
                saida = saida.Trim();
                saida += Convert.ToChar(13).ToString() + Convert.ToChar(10).ToString(); // Em ASCII o número 13 equivale a mover para a próxima linha em uma string (o mesmo que vbNewLine no VB.Net.
            }
            return saida.Trim();
        }
    }
}

namespace BibliotecaTemporaria_CSNet
{
    public class clsBancoDados : object
    {
        // Variável de classe 
        private static int numInstanciasCriadas = 0;
        // Constantes 
        private const string cntErroMensagem = "Não há Erros.";
        private const string cntErroMensagemDR = "O Leitor de Dados (DataReader-dr) ainda não foi aberto.";
        private const string cntAlertaMensagemDR = "Não há mais registros disponíveis no Leitor de Dados (DataReader-dr).";
        // Variáveis de instância encapsuladas. 
        // Tenha em mente que o escopo private encapsula as variáveis de instância. 
        private OleDbConnection cnn = new OleDbConnection();
        private OleDbCommand cmd = new OleDbCommand();
        private static string strcnn;
        private static string strcmd;
        private OleDbDataAdapter da = new OleDbDataAdapter(strcmd, strcnn);
        private OleDbDataReader dr;
        private DataSet ds = new DataSet();
        private int intcntRegistroDR = 0;
        private int intnumMaxRegistroDR = 0;
        private string strNomeTabela = "Tabela";
        private string exErroMensagem = cntErroMensagem;
        // Os métodos são (Procedimentos ou Rotinas) ou Funções 
        // As propriedades são os métodos get e set usados para definir ou resgatar um valor nas 
        // variáveis de instância. 
        // Ambos (métodos e propriedades) são elementos pertencentes a uma classe. 
        // Método construtor sem argumentos. 
        public clsBancoDados()
        {
            // Apesar de existir o método construtor sem argumentos, ele não inicia nada. 
            numInstanciasCriadas += 1;
        }
        // Método construtor com parâmetros. 
        public clsBancoDados(string strcnn, string strcmd)
        {
            setstrcnn = strcnn;
            setstrcmd = strcmd;
            // Se a conexão estiver aberta use uma instrução SQL para selecionar os registros da tabela tblEmpregados 
            // SELECT campos FROM tabela 
            numInstanciasCriadas += 1;
        }
        // Propriedade estática (compartilhada pela classe entre os objetos) que resgata o valor da variável de classe. 
        public static int getnumInstanciasCriadas
        {
            get { return numInstanciasCriadas; }
        }
        // Propriedade que resgata o valor da string contida na variável de instância strcnn. 
        public string getstrcnn
        {
            // getstrcnn = strcnn 
            get { return strcnn; }
        }
        // Propriedade que define o valor da string contida na variável de instância strcnn. 
        public string setstrcnn
        {
            set { strcnn = value; }
        }
        // O Método a seguir tem por finalidade abrir uma conexão de dados. 
        public bool mtdAbrirConexaoBD()
        {
            try
            {
                cnn.ConnectionString = getstrcnn;
                // Exemplo de string suportada por strcnn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=c:\mdbEletronorteGSD.mdb" 
                cnn.Open();
                // mtdAbrirConexaoBD = True 
                return true;
            }
            catch (Exception ex)
            {
                setErroMensagem = ex.Message;
                // mtdAbrirConexaoBD = False 
                return false;
            }
        }
        // O método a seguir abre a conexão de dados definindo uma conexão de dados pelo seu argumento. 
        public bool mtdAbrirConexaoBD(string strcnn)
        {
            setstrcnn = strcnn;
            return mtdAbrirConexaoBD();
        }
        // Método que fecha a conexão aberta. 
        public bool mtdFecharConexaoBD()
        {
            try
            {
                cnn.Close();
                // mtdFecharConexaoBD = True 
                return true;
            }
            catch (Exception ex)
            {
                setErroMensagem = ex.Message;
                // mtdFecharConexaoBD = False 
                return false;
            }
        }
        // Propriedade que resgata o valor da string contida na variável de instância strcmd. 
        public string getstrcmd
        {
            // getstrcmd = strcmd 
            get { return strcmd; }
        }
        // Propriedade que define o valor da string contida na variável de instância strcmd. 
        public string setstrcmd
        {
            set { strcmd = value; }
        }
        // O Método a seguir tem por finalidade executar o comando sql informado. 
        public bool mtdExecutarComando()
        {
            try
            {
                {
                    cmd.Connection = cnn;
                    // .Connection.ConnectionString = getstrcnn 
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = getstrcmd;
                    // Exemplo de string suportada por strcmd = "Select * from tblEmpregados" 
                    mtdFecharLeitorDados();
                    // O comando ExecuteNonQuery retorna o número de registros criados ou alterados pela string query referida. 
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                setErroMensagem = ex.Message;
                return false;
            }
        }
        // O Método a seguir tem por finalidade executar o comando sql informado com a string definida no argumento. 
        public bool mtdExecutarComando(string strcmd)
        {
            setstrcmd = strcmd;
            return mtdExecutarComando();
        }
        // Propriedade que resgata o valor do dataset contido na variável de instância ds. 
        public DataSet getAjustadorDados
        {
            // getAjustadorDados = ds 
            get { return ds; }
        }
        // Propriedade que define o valor do dataset contido na variável de instância ds. 
        public DataSet setAjustadorDados
        {
            set { ds = value; }
        }
        // Método que resgata o cabeçalho da coluna especificada. 
        public string mtdgetCabecalhoColunas(int numcoluna)
        {
            return ds.Tables[0].Columns[numcoluna].Caption.ToString();
        }
        // Método que resgata os cabelçalhos das colunas do dataset e os retorna por meio da referência de um vetor. 
        public void mtdgetCabecalhoColunas(ref string[] Colunas)
        {
            for (int contador = 0; contador <= ds.Tables[0].Columns.Count - 1; contador++)
            {
                Colunas[contador] = ds.Tables[0].Columns[contador].Caption.ToString();
            }
        }
        // Método que resgata os cabelçalhos das colunas do dataset e os retorna por meio de uma função vetor. 
        public string[] mtdgetCabecalhoColunas()
        {
            int comprimentoColunas = ds.Tables[0].Columns.Count;
            string[] vetColunas = new string[comprimentoColunas];
            for (int contador = 0; contador <= comprimentoColunas - 1; contador++)
            {
                vetColunas[contador] = ds.Tables[0].Columns[contador].Caption.ToString();
            }
            return vetColunas;
        }
        // Método que resgata o valor do datareader contido na variável de instância dr, no entanto 
        // o datareader mantêm-se no mesmo registro. 
        public string mtdgetLeitorDadosEstatico(int numColuna)
        {
            string saida = string.Empty;
            try
            {
                //If Not (dr.Item(numColuna).ToString Is String.Empty) Then 
                if ((!object.ReferenceEquals(dr.GetValue(numColuna).ToString(), string.Empty)))
                {
                    // getLeitorDados = dr 
                    saida = dr.GetValue(numColuna).ToString();
                }
                else
                {
                    saida = cntAlertaMensagemDR;
                }
            }
            catch (Exception ex)
            {
                setErroMensagem = ex.Message;
                saida = cntErroMensagemDR;
            }
            return saida;
        }
        // Método que resgata o valor do datareader contido na variável de instância dr, no entanto 
        // o datareader pula para o próximo registro. 
        public string mtdgetLeitorDadosDinamico(int numColuna)
        {
            string saida = string.Empty;
            if (mtdProximoRegistroDR())
            {
                // getLeitorDados = dr 
                saida = dr.GetValue(numColuna).ToString();
            }
            else
            {
                saida = cntAlertaMensagemDR;
            }
            return saida;
        }
        // O Método a seguir tem por finalidade definir o leitor de dados a partir do comando (cmd.ExecuteReader()). 
        public bool mtdDefinirLeitorDados()
        {
            bool erro = false;
            try
            {
                dr = cmd.ExecuteReader();
                erro = true;
            }
            catch (Exception ex)
            {
                setErroMensagem = ex.Message;
                // mtdLeitorDados = False 
                erro = false;
            }
            return erro;
        }
        // O Método a seguir fecha o Leitor de Dados. 
        public void mtdFecharLeitorDados()
        {
            try
            {
                if (!dr.IsClosed)
                {
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                setErroMensagem = ex.Message;
            }
        }
        // O Método a seguir fecha o Leitor de Dados. 
        public bool mtdVerificarLeitorDados()
        {
            bool erro = false;
            try
            {
                if (dr.IsClosed)
                {
                    erro = true;
                }
                else
                {
                    erro = false;
                }
            }
            catch (Exception ex)
            {
                setErroMensagem = ex.Message;
            }
            return erro;
        }
        // A Propriedade a seguir resgata o Nome da Tabela. 
        public string getNomeTabela
        {
            get { return strNomeTabela; }
        }
        // A Propriedade a seguir define o Nome da Tabela. 
        public string setNomeTabela
        {
            set { strNomeTabela = value; }
        }
        public string getErroMensagem
        {
            get { return exErroMensagem; }
        }

        private string setErroMensagem
        {
            set { exErroMensagem = value; }
        }

        // O Método a seguir tem por finalidade definir (ou redefinir) a conexão e o comando do Adaptador de Dados 
        // que no caso é a variável de instância (da). 
        public bool mtdAdaptadorDados()
        {
            bool erro = false;
            try
            {
                {
                    da.SelectCommand.Connection.ConnectionString = getstrcnn;
                    da.SelectCommand.CommandText = getstrcmd;
                    da.Fill(getAjustadorDados, getNomeTabela);
                }
                // mtdAdaptadorDados = True 
                erro = true;
            }
            catch (Exception ex)
            {
                setErroMensagem = ex.Message;
                // mtdAdaptadorDados = False 
                erro = false;
            }
            return erro;
        }
        // O Método seguinte tem por finalidade ler o próximo registro. 
        public bool mtdProximoRegistroDR()
        {
            bool erro = false;
            try
            {
                if (dr.Read())
                {
                    intcntRegistroDR += 1;
                    erro = true;
                }
                else
                {
                    erro = false;
                }
            }
            catch (Exception ex)
            {
                intcntRegistroDR = -1;
                setErroMensagem = ex.Message;
                erro = false;
            }
            return erro;
        }
        // O método a seguir resgata o número de colunas do Leitor de Dados. 
        public int mtdNumColunaDR()
        {
            int saida = 0;
            try
            {
                saida = dr.FieldCount;
            }
            catch (Exception ex)
            {
                setErroMensagem = ex.Message;
                saida = 0;
            }
            return saida;
        }
        // O Método a seguir encontra e resgata o número máximo de registros presente no Leitor de Dados. 
        public int mtdNumMaxRegistroDR()
        {
            int saida = 0;
            if (!dr.IsClosed)
            {
                mtdFecharLeitorDados();
            }
            mtdDefinirLeitorDados();
            while (mtdProximoRegistroDR())
            {
                intnumMaxRegistroDR = intcntRegistroDR;
                saida = intnumMaxRegistroDR;
            }
            intcntRegistroDR = 0;
            mtdFecharLeitorDados();
            mtdDefinirLeitorDados();
            return saida;
        }
        // A Propriedade a seguir resgata o valor do contador NumeroRegistroDR do Data Read. 
        public int getNumeroRegistroDR
        {
            get { return intcntRegistroDR; }
        }
        ~clsBancoDados()
        {
            // O Método seguinte é o finalizador. 
            numInstanciasCriadas -= 1;
            System.GC.Collect(0);
        }
    }

    public class clsArquivoTXT : object
    {
        // Variável de classe 
        private static int numInstanciasCriadas = 0;

        // Variáveis de Instância 
        private string strEnderecoArquivo;
        private string strTexto;

        // Implementação dos Métodos. 
        // Método Construtor sem argumentos. 
        public clsArquivoTXT()
        {
            numInstanciasCriadas += 1;
        }
        // Propriedade estática (compartilhada pela classe entre os objetos) que resgata o valor da variável de classe. 
        public static int getnumInstanciasCriadas
        {
            get { return numInstanciasCriadas; }
        }
        public string getEnderecoArquivo
        {
            get
            {
                if (!(strEnderecoArquivo == string.Empty))
                {
                    return strEnderecoArquivo;
                }
                else
                {
                    return "Digite um endereço e um nome de arquivo válidos.";
                }
            }
        }
        public string setEnderecoArquivo
        {
            set { strEnderecoArquivo = value; }
        }
        public string getTexto
        {
            get
            {
                if (!(strTexto == string.Empty))
                {
                    return strTexto;
                }
                else
                {
                    return "Não há conteúdo.";
                }
            }
        }
        public string setTexto
        {
            set { strTexto = value; }
        }
        public bool mtdCriadorTexto()
        {
            StreamWriter stwEscritorTexto = File.CreateText(getEnderecoArquivo);
            stwEscritorTexto.WriteLine(getTexto);
            stwEscritorTexto.Close();
            return true;
        }
        public bool mtdCriadorTexto(string Texto)
        {
            setTexto = Texto;
            return mtdCriadorTexto();
        }
        public bool mtdCriadorTexto(string EnderecoArquivo, string Texto)
        {
            setEnderecoArquivo = EnderecoArquivo;
            setTexto = Texto;
            return mtdCriadorTexto();
        }
        public bool mtdAcrescentarTexto()
        {
            string TextoTemporario = string.Empty;
            try
            {
                StreamReader stdLeitorTexto = File.OpenText(getEnderecoArquivo);
                TextoTemporario = stdLeitorTexto.ReadToEnd();
                stdLeitorTexto.Close();
            }
            catch
            {
            }
            finally
            {

                StreamWriter stwEscritorTexto = File.CreateText(getEnderecoArquivo);
                stwEscritorTexto.Write(TextoTemporario + getTexto);
                stwEscritorTexto.Close();
            }
            return true;
        }
        public bool mtdAcrescentarTexto(string Texto)
        {
            setTexto = Texto;
            return mtdAcrescentarTexto();
        }
        public bool mtdAcrescentarTexto(string EnderecoArquivo, string Texto)
        {
            setEnderecoArquivo = EnderecoArquivo;
            setTexto = Texto;
            return mtdAcrescentarTexto();
        }
        public string mtdLeitorTexto()
        {
            StreamReader stdLeitorTexto = File.OpenText(getEnderecoArquivo);
            setTexto = stdLeitorTexto.ReadToEnd();
            stdLeitorTexto.Close();
            return getTexto;
        }
        public string mtdLeitorTexto(string EnderecoArquivo)
        {
            setEnderecoArquivo = EnderecoArquivo;
            return mtdLeitorTexto();
        }
        public bool mtdEscritorBinario()
        {
            BinaryWriter EscritorBinario = new BinaryWriter(File.OpenWrite(getEnderecoArquivo));
            EscritorBinario.Write(getTexto);
            EscritorBinario.Close();
            return true;
        }
        public bool mtdEscritorBinario(string Texto)
        {
            setTexto = Texto;
            return mtdEscritorBinario();
        }
        public bool mtdEscritorBinario(string EnderecoArquivo, string Texto)
        {
            setEnderecoArquivo = EnderecoArquivo;
            setTexto = Texto;
            return true;
        }
        public string mtdLeitorBinario()
        {
            BinaryReader bnrLeitorBinario = new BinaryReader(File.OpenRead(getEnderecoArquivo));
            setTexto = bnrLeitorBinario.ReadString();
            bnrLeitorBinario.Close();
            return getTexto;
        }
        public string mtdLeitorBinario(string EnderecoArquivo)
        {
            setEnderecoArquivo = EnderecoArquivo;
            return mtdLeitorBinario();
        }
        ~clsArquivoTXT()
        {
            // Método Finalizador 
            numInstanciasCriadas -= 1;
            System.GC.Collect(0);
        }
    }

    public class clsManipuladorTexto
    {
        // Variável de classe 
        private static int numInstanciasCriadas = 0;
        // Variáveis de Instância 
        private int intKey;
        private char chrKeyChar;
        private string strTextoOriginal;
        private string strTextoSemEspacoExtra;
        private string strTextoSemCaractereInvalido;
        private string strSemAcentos;
        private string strTudoExecutado;
        // Método construtor sem parâmetros. 
        public clsManipuladorTexto()
        {
            numInstanciasCriadas += 1;
        }
        // Propriedade estática (compartilhada pela classe entre os objetos) que resgata o valor da variável de classe. 
        public static int getnumInstanciasCriadas
        {
            get { return numInstanciasCriadas; }
        }
        public int getKey
        {
            get { return intKey; }
        }
        public int setKey
        {
            set
            {
                chrKeyChar = Convert.ToChar(value);
                intKey = value;
            }
        }
        public char getKeyChar
        {
            get { return chrKeyChar; }
        }
        public char setKeyChar
        {
            set
            {
                intKey = Convert.ToInt32(value);
                chrKeyChar = value;
            }
        }
        public string getTextoOriginal
        {
            get { return strTextoOriginal; }
        }
        public string setTextoOriginal
        {
            set { strTextoOriginal = value; }
        }
        public string getTextoSemEspacoExtra
        {
            get { return strTextoSemEspacoExtra; }
        }
        public string setTextoSemEspacoExtra
        {
            set { strTextoSemEspacoExtra = value; }
        }
        public string getTextoSemCaractereInvalido
        {
            get { return strTextoSemCaractereInvalido; }
        }
        public string setTextoSemCaractereInvalido
        {
            set { strTextoSemCaractereInvalido = value; }
        }
        public string getTextoMaiusculo
        {
            get { return strTextoSemCaractereInvalido; }
        }
        public string setTextoMaiusculo
        {
            set { strTextoSemCaractereInvalido = value; }
        }
        public string getTextoMinusculo
        {
            get { return strTextoSemCaractereInvalido; }
        }
        public string setTextoMinusculo
        {
            set { strTextoSemCaractereInvalido = value; }
        }
        public string getSemAcentos
        {
            get { return strSemAcentos; }
        }
        public string setSemAcentos
        {
            set { strSemAcentos = value; }
        }
        public string getTudoExecutado
        {
            get { return strTudoExecutado; }
        }
        public string setTudoExecutado
        {
            set { strTudoExecutado = value; }
        }
        public string mtdTiradorEspacoExtra()
        {
            bool Verificador = false;
            char chrCarac = '\0';
            int Index = 0;
            string strTextoTemporario = string.Empty;
            if (Index == 0)
            {
                for (int i = 0; i <= getTextoOriginal.Length - 1; i++)
                {
                    chrCarac = Convert.ToChar(getTextoOriginal.Substring(i, 1));
                    Index = Convert.ToInt32(chrCarac);
                    switch (Index)
                    {
                        case 32:
                            if (Verificador == false)
                            {
                                strTextoTemporario += chrCarac;
                                Verificador = true;
                            }

                            break;
                        default:
                            strTextoTemporario += chrCarac;
                            Verificador = false;
                            break;
                    }
                }
            }
            setTextoSemEspacoExtra = strTextoTemporario.Trim();
            return getTextoSemEspacoExtra;
        }
        public string mtdTiradorEspacoExtra(string Texto)
        {
            setTextoOriginal = Texto;
            return mtdTiradorEspacoExtra();
        }
        public string mtdTiradorCaractereInvalido()
        {
            char chrCarac = '\0';
            int Index = 0;
            string strTextoTemporario = string.Empty;
            for (int i = 0; i <= getTextoOriginal.Length - 1; i++)
            {
                chrCarac = Convert.ToChar(getTextoOriginal.Substring(i, 1));
                Index = Convert.ToInt32(chrCarac);
                if (!(Index == 34 | Index == 39 | Index == 45 | Index == 47))
                {
                    strTextoTemporario += chrCarac;
                }
            }
            setTextoSemCaractereInvalido = strTextoTemporario.Trim();
            return getTextoSemCaractereInvalido;
        }
        public string mtdTiradorCaractereInvalido(string Texto)
        {
            setTextoOriginal = Texto;
            return mtdTiradorCaractereInvalido();
        }
        // Essa função devolve os caracteres digatados do texto em maiúsculo. 
        public string mtdMaiusculo()
        {
            setTextoMaiusculo = getTextoOriginal.ToUpper();
            return getTextoMaiusculo;
        }
        public string mtdMaiusculo(string Texto)
        {
            setTextoOriginal = Texto;
            return mtdMaiusculo();
        }
        // Essa função devolve os caracteres digatados do texto em minúsculo. 
        public string mtdMinusculo()
        {
            setTextoMinusculo = getTextoOriginal.ToLower();
            return getTextoMinusculo;
        }
        public string mtdMinusculo(string Texto)
        {
            setTextoOriginal = Texto;
            return mtdMinusculo();
        }
        // Essa função retira todos os acentos gráficos atinentes aos caracteres digitados. 
        public string mtdTiradorAcentos()
        {
            char chrCarac = '\0';
            int Index = 0;
            string strTextoTemporario = string.Empty;
            for (int i = 0; i <= getTextoOriginal.Length - 1; i++)
            {
                chrCarac = Convert.ToChar(getTextoOriginal.Substring(i, 1));
                Index = Convert.ToInt32(chrCarac);
                switch (Index)
                {
                    case 192:
                    case 193:
                    case 194:
                    case 195:
                    case 196:
                    case 197:
                    case 198:
                        strTextoTemporario += "A";
                        break;
                    case 199:
                        strTextoTemporario += "C";
                        break;
                    case 200:
                    case 201:
                    case 202:
                    case 203:
                        strTextoTemporario += "E";
                        break;
                    case 204:
                    case 205:
                    case 206:
                    case 207:
                        strTextoTemporario += "I";
                        break;
                    case 210:
                    case 211:
                    case 212:
                    case 213:
                    case 214:
                        strTextoTemporario += "O";
                        break;
                    case 217:
                    case 218:
                    case 219:
                    case 220:
                        strTextoTemporario += "U";
                        break;
                    case 224:
                    case 225:
                    case 226:
                    case 227:
                    case 228:
                    case 229:
                        strTextoTemporario += "a";
                        break;
                    case 231:
                        strTextoTemporario += "c";
                        break;
                    case 232:
                    case 233:
                    case 234:
                    case 235:
                        strTextoTemporario += "e";
                        break;
                    case 236:
                    case 237:
                    case 238:
                    case 239:
                        strTextoTemporario += "i";
                        break;
                    case 242:
                    case 243:
                    case 244:
                    case 245:
                    case 246:
                        strTextoTemporario += "o";
                        break;
                    case 249:
                    case 250:
                    case 251:
                    case 252:
                        strTextoTemporario += "u";
                        break;
                    default:
                        strTextoTemporario += chrCarac;
                        break;
                }
            }
            setSemAcentos = strTextoTemporario;
            return getSemAcentos;
        }
        public string mtdTiradorAcentos(string Texto)
        {
            setTextoOriginal = Texto;
            return mtdTiradorAcentos();
        }
        // Essa função realiza todas as tarefas das funções anteriores, tornando todo o texto maiúsculo. 
        public string mtdExecutarTudo()
        {
            setTudoExecutado = mtdMaiusculo(mtdTiradorAcentos(mtdTiradorCaractereInvalido(mtdTiradorEspacoExtra(getTextoOriginal))));
            return getTudoExecutado;
        }
        public string mtdExecutarTudo(string Texto)
        {
            setTextoOriginal = Texto;
            return mtdExecutarTudo();
        }
        // Essa função obriga somente digitar textos com números 
        public bool mtdPermitirDigitarSoNumero()
        {
            // Verifica se um caracter é permitido. 
            // Selecione os caracteres que desejar. 
            // Os valores ASC 3, 8, 22, 24 abilitam os comandos Ctrl+C, Backspace, Ctrl+V e Ctrl+X respectivamente. 
            string Numeros = "0123456789" + Convert.ToChar(3) + Convert.ToChar(8) + Convert.ToChar(22) + Convert.ToChar(24);
            return !Numeros.Contains(getKeyChar.ToString());
        }
        public bool mtdPermitirDigitarSoNumero(int Key)
        {
            // Verifica se um caracter é permitido. 
            setKey = Key;
            return mtdPermitirDigitarSoNumero();
        }
        public bool mtdPermitirDigitarSoNumero(char KeyChar)
        {
            // Verifica se um caracter é permitido. 
            setKeyChar = KeyChar;
            return mtdPermitirDigitarSoNumero();
        }
        // Essa função obriga somente digitar textos com caracteres sem acentos gráficos 
        public bool mtdPermitirDigitarSoTexto()
        {
            // Verifica se um caracter é permitido. 
            // Selecione os caracteres que desejar. 
            // Os valores ASC 3, 8, 22, 24 abilitam os comandos Ctrl+C, Backspace, Ctrl+V e Ctrl+X respectivamente. 
            string Texto = " ,.-0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ" + Convert.ToChar(3) + Convert.ToChar(8) + Convert.ToChar(22) + Convert.ToChar(24);
            return !Texto.Contains(getKeyChar.ToString());
        }
        public bool mtdPermitirDigitarSoTexto(int Key)
        {
            // Verifica se um caracter é permitido. 
            setKey = Key;
            return mtdPermitirDigitarSoTexto();
        }
        public bool mtdPermitirDigitarSoTexto(char KeyChar)
        {
            // Verifica se um caracter é permitido. 
            setKeyChar = KeyChar;
            return mtdPermitirDigitarSoTexto();
        }
        // Essa função faz obriga somente digitar textos sem números 
        public bool mtdPermitirDigitarSoNome()
        {
            // Verifica se um caracter é permitido. 
            // Selecione os caracteres que desejar. 
            // Os valores ASC 3, 8, 22, 24 abilitam os comandos Ctrl+C, Backspace, Ctrl+V e Ctrl+X respectivamente. 
            string Texto = " -abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ" + Convert.ToChar(3) + Convert.ToChar(8) + Convert.ToChar(22) + Convert.ToChar(24);
            return !Texto.Contains(getKeyChar.ToString());
        }
        public bool mtdPermitirDigitarSoNome(int Key)
        {
            // Verifica se um caracter é permitido. 
            setKey = Key;
            return mtdPermitirDigitarSoNome();
        }
        public bool mtdPermitirDigitarSoNome(char KeyChar)
        {
            //Verifica se um caracter é permitido. 
            setKeyChar = KeyChar;
            return mtdPermitirDigitarSoNome();
        }
        // Essa função faz obriga somente digitar textos que sejam atinentes a datas 
        public bool mtdPermitirDigitarSoData()
        {
            // Verifica se um caracter é permitido. 
            // Selecione os caracteres que desejar. 
            // Os valores ASC 3, 8, 22, 24 abilitam os comandos Ctrl+C, Backspace, Ctrl+V e Ctrl+X respectivamente. 
            string Numeros = " -abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ" + Convert.ToChar(3) + Convert.ToChar(8) + Convert.ToChar(22) + Convert.ToChar(24);
            return !Numeros.Contains(getKeyChar.ToString());
        }
        public bool mtdPermitirDigitarSoData(int Key)
        {
            //Verifica se um caracter é permitido. 
            setKey = Key;
            return mtdPermitirDigitarSoData();
        }
        public bool mtdPermitirDigitarSoData(char KeyChar)
        {
            //Verifica se um caracter é permitido. 
            setKeyChar = KeyChar;
            return mtdPermitirDigitarSoData();
        }
        ~clsManipuladorTexto()
        {
            // Método Finalizador. 
            numInstanciasCriadas -= 1;
            System.GC.Collect(0);
        }
    }

    // Classe que gera um temporizador simples de ser usado, e razoavelmente preciso. 
    public class clsTemporizador
    {
        // Como pode ser percebido abaixo, essa classe é inerente ao kernel32.dll, portanto, tendo sua portabilidade comprometida. 
        // Variável de classe 
        private static int numInstanciasCriadas = 0;
        // Variável de instância 
        private double intervalo = 0;
        private double tempo = 0;
        private double tempoMax = 0;
        private long contadorInicial = 0;
        private long contador = 0;
        private long difcontador = 0;
        private long frequencia = long.MaxValue;
        // Número máximo que um inteiro longo sinalizado positivo pode suportar (((2^64)/2)-1). 
        private double numLoops = 0;
        private string mensagemErro = "Não houve erros.";
        // Métodos estáticos - Static (CS.Net) ou compartilhados - Shared (VB.Net) 
        [SuppressUnmanagedCodeSecurity()]
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        private static extern bool QueryPerformanceCounter(ref long lpPerformanceCount);
        [SuppressUnmanagedCodeSecurity()]
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        private static extern bool QueryPerformanceFrequency(ref long lpFrequency);
        // Propriedade estática (compartilhada pela classe entre os objetos) que resgata o valor da variável de classe. 
        public static int getnumInstanciasCriadas
        {
            get { return numInstanciasCriadas; }
        }
        // Propriedades que resgatam o valor das variáveis de instância. 
        public double getintervalo
        {
            get { return intervalo; }
        }
        public double gettempo
        {
            get { return tempo; }
        }
        public double prptempoMax
        {
            get { return tempoMax; }
            set
            {
                if ((value > 0))
                {
                    tempoMax = value;
                }
                else
                {
                    tempoMax = 1;
                    mensagemErro = "Ajuste o valor da variável tempoMax para que seja maior do que zero, " + "caso contrário será atribuído o tempo de um segundo a ela.";
                }
            }
        }
        public double getcontadorInicial
        {
            get { return contadorInicial; }
        }
        public double getcontador
        {
            get { return contador; }
        }
        public double getdifcontador
        {
            get { return difcontador; }
        }
        public double getfrequencia
        {
            get { return intervalo; }
        }
        public double getnumLoops
        {
            get { return numLoops; }
        }
        public string getmensagemErro
        {
            get { return mensagemErro; }
        }
        // Métodos que para serem usados, a classe deverá ser instanciada em um objeto. 
        // Métodos construtores sobrecarregados. 
        public clsTemporizador()
        {
            numInstanciasCriadas += 1;
        }
        public clsTemporizador(double tempoMax)
        {
            prptempoMax = tempoMax;
            numInstanciasCriadas += 1;
        }
        // Métodos convencionais. 
        public string mtdInformacao()
        {
            return "O tempo é dado em segundos, e a frequência de operação é dada em hertz.";
        }
        public bool mtdTemporizador()
        {
            bool erro = false;
            tempo = Convert.ToDouble((contador - contadorInicial) / frequencia);
            if (QueryPerformanceCounter(ref contadorInicial) != false)
            {
                // Início do código temporizador. 
                while ((tempo < tempoMax))
                {
                    QueryPerformanceCounter(ref contador);
                    QueryPerformanceFrequency(ref frequencia);
                    intervalo = Convert.ToDouble(1.0 / frequencia);
                    tempo = (contador - contadorInicial) * intervalo;
                }
                mensagemErro = "Não houve erros.";
                erro = true;
            }
            else
            {
                mensagemErro = "Resolução acima do suportado.";
                erro = false;
            }
            return erro;
        }
        public bool mtdTemporizador(double tempoMax)
        {
            prptempoMax = tempoMax;
            return mtdTemporizador();
        }
        public long mtdIniciarContador()
        {
            contadorInicial = 0;
            if ((QueryPerformanceCounter(ref contadorInicial) == false))
            {
                mensagemErro = "Resolução acima do suportado.";
            }
            return contadorInicial;
        }
        public double mtdPassoTempo()
        {
            if ((contadorInicial == -1))
            {
                contadorInicial = mtdIniciarContador();
            }
            tempo = Convert.ToDouble((contador - contadorInicial) / frequencia);
            if ((QueryPerformanceCounter(ref contador) != false))
            {
                // Início do código temporizador. 
                QueryPerformanceCounter(ref contador);
                QueryPerformanceFrequency(ref frequencia);
                intervalo = Convert.ToDouble(1.0 / frequencia);
                tempo = (contador - contadorInicial) * intervalo;
            }
            else
            {
                mensagemErro = "Resolução acima do suportado.";
            }
            return tempo;
        }
        public double mtdPassoTempo(double tempoMax)
        {
            prptempoMax = tempoMax;
            return mtdPassoTempo();
        }
        public override string ToString()
        {
            string saida = "Contador Inicial: " + contadorInicial + "; Contador: " + contador + ";" + "\n" + "Tempo: " + tempo + " (s); Tempo Limite: " + tempoMax + " (s); Frequência: " + frequencia + " (Hz);" + "\\n" + "Intervalo: " + intervalo + " (Hz); Diferença entre os contadores: " + difcontador + ";" + "\n" + "Números de Loops: " + numLoops + "; Número de Instâncias Criadas: " + numInstanciasCriadas + ";" + "\\n" + "Mensagem de Erro: " + mensagemErro;
            return saida;
        }
        ~clsTemporizador()
        {
            // Método finalizador. 
            numInstanciasCriadas -= 1;
            System.GC.Collect(0);
        }
    }

    public class clsEnderecoAplicativo
    {
        // Variável de classe 
        private static int numInstanciasCriadas = 0;
        // Método construtor sem parâmetros da classe, construção essa comum em Java 
        public clsEnderecoAplicativo()
        {
            numInstanciasCriadas += 1;
            Endereco();
        }
        // Propriedade estática (compartilhada pela classe entre os objetos) que resgata o valor da variável de classe. 
        public static int getnumInstanciasCriadas
        {
            get { return numInstanciasCriadas; }
        }
        public string Endereco()
        {
            string varEnderecoAplicativo = string.Empty;
            char chrCaractere = '\0';
            int countBI = 0;
            int countmaxBI = 0;
            for (int i = 0; i <= Assembly.GetExecutingAssembly().Location.Length - 1; i++)
            {
                chrCaractere = Convert.ToChar(Assembly.GetExecutingAssembly().Location.Substring(i, 1));
                if (chrCaractere == '\\')
                {
                    countmaxBI += 1;
                }
            }
            for (int i = 0; i <= Assembly.GetExecutingAssembly().Location.Length - 1; i++)
            {
                chrCaractere = Convert.ToChar(Assembly.GetExecutingAssembly().Location.Substring(i, 1));
                varEnderecoAplicativo += chrCaractere;
                if (chrCaractere == '\\')
                {
                    if (countmaxBI - 1 == countBI)
                    {
                        break; // TODO: might not be correct. Was : Exit For 
                    }
                    countBI += 1;
                }
            }
            return varEnderecoAplicativo;
        }
        ~clsEnderecoAplicativo()
        {
            numInstanciasCriadas -= 1;
            System.GC.Collect(0);
        }
    }
}