using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjRedeNeuralCSCoreNet
{
    internal class clsRedeNeural
    {
        private int modEpocaDisplay = 1;
        public DateTime tempoInicial;
        private DateTime tempoIntermediario;
        public DateTime tempoFinal;
        private int TipoSaida = 0;
        private int TipoErro = 0;
        private int TipoDeltaS = 0;
        private int i = 0;
        private int j = 0;
        private int k = 0;
        private int p = 0;
        private int np = 0;
        private int op = 0;
        private int epoca = 0;
        private int numPadroes = 0;
        private int numEntrada = 0;
        public int numEscondida = 0;
        private int numSaida = 0;
        public int numIteracoes = 100;
        private int minimoValorEntrada = 0;
        private int maximoValorEntrada = 0;
        private int minimoValorAlvo = 0;
        private int maximoValorAlvo = 0;

        // int ranpad[NUMEROPADROES+1];
        private int[] ranpad;
        // double entrada[NUMEROPADROES+1][NUMEROENTRADAS+1];
        private double[][] entrada;
        // double target[NUMEROPADROES+1][NUMEROSAIDAS+1];
        private double[][] target;
        // double SomaEscondida[NUMEROPADROES+1][NUMEROESCONDIDA+1];
        private double[][] SomaEscondida;
        // double W12[NUMEROENTRADAS+1][NUMEROESCONDIDA+1];
        private double[][] W12;
        // double Escondida[NUMEROPADROES+1][NUMEROESCONDIDA+1];
        private double[][] Escondida;
        // double SomaSaida[NUMEROPADROES+1][NUMEROSAIDAS+1]; 
        private double[][] SomaSaida;
        // double W23[NUMEROESCONDIDA+1][NUMEROSAIDAS+1]; 
        private double[][] W23;
        // double SAIDA[NUMEROPADROES+1][NUMEROSAIDAS+1];
        private double[][] Saida;
        // double DeltaS[NUMEROSAIDAS+1];
        private double[] DeltaS;
        // double somaDWS[NUMEROESCONDIDA+1];
        private double[] somaDWS;
        // double DeltaE[NUMEROESCONDIDA+1];
        private double[] DeltaE;
        // double DeltaW12[NUMEROENTRADAS+1][NUMEROESCONDIDA+1];
        private double[][] DeltaW12;
        // double DeltaW23[NUMEROESCONDIDA+1][NUMEROSAIDAS+1];
        private double[][] DeltaW23;

        private double Erro = 0;
        private double eta = 0.05;
        private double alpha = 0;
        private double wmax = 1;
        public double erroLimite = 0.0001;
        public int primeiraExecucao = 1;

        private Random objRandom = new Random();

        public clsRedeNeural()
        {
        }

        protected void finalize()
        {

        }

        private double rando()
        {
            return objRandom.NextDouble();
        }

        public class sttGerarArquivoMatriz
        {
            public static int coluna = 0;
            public static int linha = 0;
            public static int comprimento = 0;
            public static int minimoValor = 0;
            public static int maximoValor = 0;
        }

        public int[] mtdCriarVetorDinamicoInteger(int Comprimento)
        {
            int[] Vetor = new int[Comprimento];

            return Vetor;
        }

        public int[][] mtdCriarMatrizDinamicaInteger(int Linha, int Coluna)
        {
            int[][] Matriz = new int[Linha][];

            for (int i = 0; i < Linha; i++)
            {
                Matriz[i] = new int[Coluna];
            }

            return Matriz;
        }

        public double[] mtdCriarVetorDinamicoDouble(int Comprimento)
        {
            double[] Vetor = new double[Comprimento];

            return Vetor;
        }

        public double[][] mtdCriarMatrizDinamicaDouble(int Linha, int Coluna)
        {
            double[][] Matriz = new double[Linha][];

            for (int i = 0; i < Linha; i++)
            {
                Matriz[i] = new double[Coluna];
            }

            return Matriz;
        }

        public void mtdObterVetorDinamicoInteger(int[] Vetor, int Comprimento)
        {
            for (int i = 0; i < Comprimento; i++)
            {
                System.Console.Write("Vetor[" + i + "]: " + Vetor[i]);
            }
        }

        public void mtdObterMatrizDinamicaInteger(int[][] Matriz, int Linha, int Coluna)
        {
            for (int i = 0; i < Linha; i++)
            {
                for (int j = 0; j < Coluna; j++)
                {
                    System.Console.Write("Matriz[" + i + "][" + j + "]: " + Matriz[i][j]);
                }
            }
        }

        public void mtdObterVetorDinamicoDouble(double[] Vetor, int Comprimento)
        {
            for (int i = 0; i < Comprimento; i++)
            {
                System.Console.Write("Vetor[" + i + "]: " + Vetor[i]);
            }
        }

        public void mtdObterMatrizDinamicaDouble(double[][] Matriz, int Linha, int Coluna)
        {
            for (int i = 0; i < Linha; i++)
            {
                for (int j = 0; j < Coluna; j++)
                {
                    System.Console.Write("Matriz[" + i + "][" + j + "]: " + Matriz[i][j]);
                }
            }
        }

        public int[] mtdPreencherVetorDinamicoInteger(int Comprimento, int Conteudo)
        {
            int[] Vetor = new int[Comprimento];

            for (int i = 0; i < Comprimento; i++)
            {
                Vetor[i] = Conteudo;
            }

            return Vetor;
        }

        public int[][] mtdPreencherMatrizDinamicaInteger(int Linha, int Coluna, int Conteudo)
        {
            int[][] Matriz = new int[Linha][];

            for (int i = 0; i < Linha; i++)
            {
                for (int j = 0; j < Coluna; j++)
                {
                    Matriz[i][j] = Conteudo;
                }
            }

            return Matriz;
        }

        public double[] mtdPreencherVetorDinamicoDouble(int Comprimento, double Conteudo)
        {
            double[] Vetor = new double[Comprimento];

            for (int i = 0; i < Comprimento; i++)
            {
                Vetor[i] = Conteudo;
            }

            return Vetor;
        }

        public double[][] mtdPreencherMatrizDinamicaDouble(int Linha, int Coluna, double Conteudo)
        {
            double[][] Matriz = new double[Linha][];

            for (int i = 0; i < Linha; i++)
            {
                Matriz[i] = new double[Coluna];

                for (int j = 0; j < Coluna; j++)
                {
                    Matriz[i][j] = Conteudo;
                }
            }

            return Matriz;
        }

        public double[][] mtdGerarArquivoMatriz(String Arquivo, int coluna, int linha, int comprimento, int minimoValor, int maximoValor)
        {
            StringBuilder numero = new StringBuilder();
            int i = 0;
            int j = 0;
            int enterRepetido = 1;
            int espacoRepetido = 1;
            int pontoRepetido = 0;
            int sinalRepetido = 0;
            int ultimaEntrada = 0;
            int maxcoluna = 0;
            int contador = 0;
            int numeroEspaco = 0;
            int chr = 0;
            double[] vetnum = new double[100000];
            double[][] Matriz;

            System.IO.StreamReader sr = new System.IO.StreamReader(Arquivo);

            (coluna) = 0;
            (linha) = 0;

            while (chr > -1)
            {
                if (((chr == '-' | chr == '+' | chr == '.' | chr == ',') & (pontoRepetido == 0 | sinalRepetido == 0)) | (chr >= '0' & chr <= '9'))
                {
                    if (chr == ',')
                    {
                        chr = '.';
                    }
                    numero.Append((char)chr);
                    if ((numero.ToString() != "-" & numero.ToString() != "+") & (numero.ToString() != "." & numero.ToString() != ","))
                    {
                        vetnum[numeroEspaco] = Double.Parse(numero.ToString());
                    }
                    enterRepetido = 0;
                    espacoRepetido = 0;
                    if (chr == '-' | chr == '+')
                    {
                        sinalRepetido++;
                    }
                    if (chr == '.' | chr == ',')
                    {
                        pontoRepetido++;
                    }
                    ultimaEntrada = 1;
                }

                else
                {
                    if (!(chr == '-' | chr == '+' | chr == '.' | chr == ','))
                    {
                        contador = 0;

                        if (espacoRepetido == 0)
                        {
                            (coluna)++;
                            numeroEspaco++;
                            numero = new StringBuilder();
                        }
                        espacoRepetido++;

                        if (chr == 10 | chr == 13)
                        {
                            if (enterRepetido == 0)
                            {
                                if (maxcoluna < (coluna))
                                {
                                    maxcoluna = (coluna);
                                }
                                (coluna) = 0;
                                (linha)++;
                                numero = new StringBuilder();
                            }
                            enterRepetido++;
                        }

                        pontoRepetido = 0;
                        sinalRepetido = 0;
                    }
                    else
                    {
                        enterRepetido = 0;
                        espacoRepetido = 0;
                        pontoRepetido++;
                        sinalRepetido++;
                    }
                    ultimaEntrada = 0;
                }

                chr = sr.Read();
            }

            numeroEspaco++;
            (linha)++;
            (coluna) = maxcoluna;
            (comprimento) = numeroEspaco;

            if (ultimaEntrada == 0)
            {
                (linha)--;
            }

            (minimoValor) = (int)vetnum[0];
            (maximoValor) = (int)vetnum[0];

            for (i = 0; i < (comprimento); i++)
            {
                if ((minimoValor) >= (int)vetnum[i])
                {
                    (minimoValor) = (int)vetnum[i];
                }
                if ((maximoValor) <= (int)vetnum[i])
                {
                    (maximoValor) = (int)vetnum[i];
                }
            }

            // mtdCriarMatrizDinamicaDouble(Matriz, (*linha + 1), (*coluna + 1));
            Matriz = new double[(linha + 1)][];

            for (i = 0; i < (linha + 1); i++)
            {
                Matriz[i] = new double[(coluna + 1)];
            }

            // mtdPreencherMatrizDinamicaDouble(Matriz, (*linha + 1), (*coluna + 1), ((vetnum[(int)(((i - 1) * (*coluna)) + (j - 1))]) - (*minimoValor)) / ((*maximoValor) - (*minimoValor)));
            for (i = 1; i < (linha + 1); i++)
            {
                for (j = 1; j < (coluna + 1); j++)
                {
                    Matriz[i][j] = ((vetnum[(int)(((i - 1) * (coluna)) + (j - 1))]) - (minimoValor)) / ((maximoValor) - (minimoValor));
                }
            }

            sttGerarArquivoMatriz.coluna = coluna;
            sttGerarArquivoMatriz.linha = linha;
            sttGerarArquivoMatriz.comprimento = comprimento;
            sttGerarArquivoMatriz.minimoValor = minimoValor;
            sttGerarArquivoMatriz.maximoValor = maximoValor;

            sr.Close();

            return Matriz;
        }

        public void mtdGerarVetorMatriz()
        {
            // int ranpad[NUMEROPADROES+1];
            ranpad = mtdCriarVetorDinamicoInteger(numPadroes + 1);

            // double SomaEscondida[NUMEROPADROES+1][NUMEROESCONDIDA+1];
            SomaEscondida = mtdCriarMatrizDinamicaDouble(numPadroes + 1, numEscondida + 1);

            // double W12[NUMEROENTRADAS+1][NUMEROESCONDIDA+1];
            W12 = mtdCriarMatrizDinamicaDouble(numEntrada + 1, numEscondida + 1);

            // double Escondida[NUMEROPADROES+1][NUMEROESCONDIDA+1];
            Escondida = mtdCriarMatrizDinamicaDouble(numPadroes + 1, numEscondida + 1);

            // double SomaSaida[NUMEROPADROES+1][NUMEROSAIDAS+1]; 
            SomaSaida = mtdCriarMatrizDinamicaDouble(numPadroes + 1, numSaida + 1);

            // double W23[NUMEROESCONDIDA+1][NUMEROSAIDAS+1]; 
            W23 = mtdCriarMatrizDinamicaDouble(numEscondida + 1, numSaida + 1);

            // double Saida[NUMEROPADROES+1][NUMEROSAIDAS+1];
            Saida = mtdCriarMatrizDinamicaDouble(numPadroes + 1, numSaida + 1);

            // double DeltaS[NUMEROSAIDAS+1];
            DeltaS = mtdCriarVetorDinamicoDouble(numSaida + 1);

            // double somaDWS[NUMEROESCONDIDA+1];
            somaDWS = mtdCriarVetorDinamicoDouble(numEscondida + 1);

            // double DeltaE[NUMEROESCONDIDA+1];
            DeltaE = mtdCriarVetorDinamicoDouble(numEscondida + 1);

            // double DeltaW12[NUMEROENTRADAS+1][NUMEROESCONDIDA+1];
            DeltaW12 = mtdCriarMatrizDinamicaDouble(numEntrada + 1, numEscondida + 1);

            // double DeltaW23[NUMEROESCONDIDA+1][NUMEROSAIDAS+1];
            DeltaW23 = mtdCriarMatrizDinamicaDouble(numEscondida + 1, numSaida + 1);
        }

        public void mtdFinalizarVetorMatriz()
        {
            // int ranpad[NUMEROPADROES+1];
            ranpad = null;

            // double entrada[NUMEROPADROES+1][NUMEROENTRADAS+1];
            entrada = null;

            // double target[NUMEROPADROES+1][NUMEROSAIDAS+1];
            target = null;

            // double SomaEscondida[NUMEROPADROES+1][NUMEROESCONDIDA+1];
            SomaEscondida = null;

            // double W12[NUMEROENTRADAS+1][NUMEROESCONDIDA+1];
            W12 = null;

            // double Escondida[NUMEROPADROES+1][NUMEROESCONDIDA+1];
            Escondida = null;

            // double SomaSaida[NUMEROPADROES+1][NUMEROSAIDAS+1]; 
            SomaSaida = null;

            // double W23[NUMEROESCONDIDA+1][NUMEROSAIDAS+1]; 
            W23 = null;

            // double SAIDA[NUMEROPADROES+1][NUMEROSAIDAS+1];
            Saida = null;

            // double DeltaS[NUMEROSAIDAS+1];
            DeltaS = null;

            // double somaDWS[NUMEROESCONDIDA+1];
            somaDWS = null;

            // double DeltaE[NUMEROESCONDIDA+1];
            DeltaE = null;

            // double DeltaW12[NUMEROENTRADAS+1][NUMEROESCONDIDA+1];
            DeltaW12 = null;

            // double DeltaW23[NUMEROESCONDIDA+1][NUMEROSAIDAS+1];
            DeltaW23 = null;
        }

        public void mtdObterEntradasTreinamento()
        {
            int coluna = 0;
            int linha = 0;
            int comprimento = 0;
            // double entrada[NUMEROPADROES+1][NUMEROENTRADAS+1];
            entrada = mtdGerarArquivoMatriz("entradastreinamento.dat", coluna, linha, comprimento, minimoValorEntrada, maximoValorEntrada);
            numEntrada = sttGerarArquivoMatriz.coluna;
            numPadroes = sttGerarArquivoMatriz.linha;
            minimoValorEntrada = sttGerarArquivoMatriz.minimoValor;
            maximoValorEntrada = sttGerarArquivoMatriz.maximoValor;
        }

        public void mtdObterEntradasExecucao()
        {
            int coluna = 0;
            int linha = 0;
            int comprimento = 0;
            // double entrada[NUMEROPADROES+1][NUMEROENTRADAS+1];
            entrada = mtdGerarArquivoMatriz("entradasteste.dat", coluna, linha, comprimento, minimoValorEntrada, maximoValorEntrada);
            numEntrada = sttGerarArquivoMatriz.coluna;
            numPadroes = sttGerarArquivoMatriz.linha;
            minimoValorEntrada = sttGerarArquivoMatriz.minimoValor;
            maximoValorEntrada = sttGerarArquivoMatriz.maximoValor;
        }

        public void mtdObterAlvosTreinamento()
        {

            int coluna = 0;
            int linha = 0;
            int comprimento = 0;
            // double target[NUMEROPADROES+1][NUMEROSAIDAS+1];
            target = mtdGerarArquivoMatriz("target.dat", coluna, linha, comprimento, minimoValorAlvo, maximoValorAlvo);
            numSaida = sttGerarArquivoMatriz.coluna;
            numPadroes = sttGerarArquivoMatriz.linha;
            minimoValorAlvo = sttGerarArquivoMatriz.minimoValor;
            maximoValorAlvo = sttGerarArquivoMatriz.maximoValor;

            mtdEscreverNumeroColunasAlvos();
        }

        public void mtdZerarAlvosExecucao(int linha)
        {
            mtdObterNumeroColunasAlvos();

            int coluna = numSaida;

            // double target[NUMEROPADROES+1][NUMEROSAIDAS+1];
            target = mtdCriarMatrizDinamicaDouble(linha + 1, coluna + 1);

            target = mtdPreencherMatrizDinamicaDouble(linha + 1, coluna + 1, 0.0);
        }

        public void mtdExportarPesos()
        {
            int m, n;
            // cfPtr = fopen("pesos.dat", "w");
            System.IO.StreamWriter sw = new System.IO.StreamWriter("pesos.dat", false);

            for (n = 0; n < (numEscondida + 1); n++)
            {
                for (m = 0; m < (numEntrada + 1); m++)
                {
                    sw.Write(W12[m][n] + ((m < numEntrada) ? "\t" : ""));
                }

                sw.Write("\n");
            }

            for (n = 0; n < (numSaida + 1); n++)
            {
                for (m = 0; m < (numEscondida + 1); m++)
                {
                    sw.Write(W23[m][n] + ((m < numEscondida) ? "\t" : ""));
                }

                if (n < numSaida)
                {
                    sw.Write("\n");
                }
            }

            sw.Close();
        }

        public void mtdIniciarPesos()
        {

            int m, n;

            String Retorno = "";

            String strLinha = "";
            String[]
            vetLinha;

            System.IO.StreamReader sr = new System.IO.StreamReader("pesos.dat");

            for (n = 0; n < (numEscondida + 1); n++)
            {
                strLinha = sr.ReadLine();
                vetLinha = strLinha.Split("\t");

                for (m = 0; m < (numEntrada + 1); m++)
                {
                    W12[m][n] = Double.Parse(vetLinha[m]);
                }
            }

            for (n = 0; n < (numSaida + 1); n++)
            {
                strLinha = sr.ReadLine();
                vetLinha = strLinha.Split("\t");

                for (m = 0; m < (numEscondida + 1); m++)
                {
                    W23[m][n] = Double.Parse(vetLinha[m]);
                }
            }

            sr.Close();
        }

        public void mtdDefinirModEpocaDisplay()
        {
            if (numIteracoes >= 100)
            {
                modEpocaDisplay = (int)(numIteracoes / 100);
            }
            else
            {
                modEpocaDisplay = 1;
            }
        }

        public String mtdObterNumeroArquivo(String EnderecoArquivo)
        {
            String Retorno = "";

            System.IO.StreamReader sr = new System.IO.StreamReader(EnderecoArquivo);

            int intCharUnicode = sr.Read();
            char chrCharUnicode = (char)intCharUnicode;
            StringBuilder strNumero = new StringBuilder();

            while (intCharUnicode > -1)
            {
                if ("-+0123456789.,ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".Contains((chrCharUnicode)))
                {
                    strNumero.Append(chrCharUnicode);
                    Retorno = strNumero.ToString();
                }

                intCharUnicode = sr.Read();
                if (intCharUnicode > -1)
                {
                    chrCharUnicode = (char)intCharUnicode;
                }
            }

            sr.Close();

            return Retorno;
        }

        public void mtdObterErroTreinamento()
        {
            Erro = Double.Parse(mtdObterNumeroArquivo("errotreinamento.dat"));
        }

        public void mtdEscreverErroTreinamento()
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter("errotreinamento.dat", false);

            sw.Write(Convert.ToString(Erro));
            sw.Close();
        }

        public void mtdObterNumeroNeuronios()
        {
            numEscondida = int.Parse(mtdObterNumeroArquivo("numeroneuronios.dat"));
        }

        public void mtdEscreverNumeroNeuronios()
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter("numeroneuronios.dat", false);

            sw.Write(Convert.ToString(numEscondida));
            sw.Close();
        }

        public void mtdObterNumeroColunasAlvos()
        {
            if (numSaida <= 0)

            {
                mtdObterAlvosTreinamento();

                mtdEscreverNumeroColunasAlvos();
            }
            else

            {
                numSaida = int.Parse(mtdObterNumeroArquivo("numerocolunasalvos.dat"));
            }
        }

        void mtdEscreverNumeroColunasAlvos()
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter("numerocolunasalvos.dat", false);

            sw.Write(Convert.ToString(numSaida));
            sw.Close();
        }

        void mtdEscreverSaida(int TipoResultado)
        {
            String strEnderecoArquivo = "";

            if (TipoResultado == 0)

            {
                strEnderecoArquivo = "resultadostreinamento.dat";
            }
            else if (TipoResultado == 1)

            {
                strEnderecoArquivo = "resultadosteste.dat";
            }

            System.IO.StreamWriter sw = new System.IO.StreamWriter(strEnderecoArquivo, false);

            tempoIntermediario = DateTime.Now;
            // fprintf(cfPtr, "NETWORK DATA - Epoca %d - Neuronios %d - Iteracoes %d - Erro %lf - Tempo Execucao %.0lf [s].\n\nPat:\t", epoca, numEscondida, numIteracoes, Erro, difftime(tempoIntermediario, tempoInicial)); // Mostra as SAIDAs
            sw.Write("NETWORK DATA - Epoca " + epoca + " - Neuronios " + numEscondida + " - Erro " + Erro + " - Tempo Execucao " + ((TimeSpan)(tempoIntermediario - tempoInicial)).TotalSeconds + " [s].\n\nPat:\t");

            for (i = 1; i < (numEntrada + 1); i++)
            {
                sw.Write("Entrada " + i + "\t");
            }

            for (k = 1; k < (numSaida + 1); k++)
            {
                sw.Write("Alvo " + k + "\tSaida " + k + "\t");
            }

            for (p = 1; p < (numPadroes + 1); p++)
            {
                sw.Write("\n" + p + "\t");

                for (i = 1; i < (numEntrada + 1); i++)
                {
                    sw.Write((entrada[p][i] * (maximoValorEntrada - minimoValorEntrada) + (minimoValorEntrada)) + "\t");
                }

                for (k = 1; k < (numSaida + 1); k++)
                {
                    sw.Write((target[p][k] * (maximoValorEntrada - minimoValorEntrada) + (minimoValorEntrada)) + "\t" + (Saida[p][k] * (maximoValorAlvo - minimoValorAlvo) + (minimoValorAlvo)) + "\t");
                }
            }

            tempoIntermediario = DateTime.Now;
            // fprintf(stdout, "NETWORK DATA - Epoca %d - Neuronios %d - Iteracoes %d - Erro %lf - Tempo Execucao %.0lf [s].\n\nPat:\t", epoca, numEscondida, numIteracoes, Erro, difftime(tempoIntermediario, tempoInicial)); // Mostra as SAIDAs
            System.Console.Write("NETWORK DATA - Epoca " + epoca + " - Neuronios " + numEscondida + " - Erro " + Erro + " - Tempo Execucao " + ((TimeSpan)(tempoIntermediario - tempoInicial)).TotalSeconds + " [s].\n\nPat:\t");

            for (i = 1; i < (numEntrada + 1); i++)
            {
                System.Console.Write("Entrada " + i + "\t");
            }

            for (k = 1; k < (numSaida + 1); k++)
            {
                System.Console.Write("Alvo " + k + "\tSaida " + k + "\t");
            }

            for (p = 1; p < (numPadroes + 1); p++)
            {
                System.Console.Write("\n" + p + "\t");
                for (i = 1; i < (numEntrada + 1); i++)
                {
                    System.Console.Write((entrada[p][i] * (maximoValorEntrada - minimoValorEntrada) + (minimoValorEntrada)) + "\t");
                }
                for (k = 1; k < (numSaida + 1); k++)
                {
                    System.Console.Write((target[p][k] * (maximoValorEntrada - minimoValorEntrada) + (minimoValorEntrada)) + "\t" + (Saida[p][k] * (maximoValorAlvo - minimoValorAlvo) + (minimoValorAlvo)) + "\t");
                }
            }

            System.Console.Write("\n\n");

            sw.Close();

            // mtdPausar();
        }

        public int mtdTreinarRedeNeural()
        {
            int retorno = 0;

            System.IO.StreamWriter sw = new System.IO.StreamWriter("erro_TreinamentoRedeNeural.dat", false);

            mtdDefinirModEpocaDisplay();
            mtdObterEntradasTreinamento();
            mtdObterAlvosTreinamento();
            mtdGerarVetorMatriz();

            for (j = 1; j < (numEscondida + 1); j++)
            {
                // Inicializa W12 e DeltaW12
                for (i = 0; i < (numEntrada + 1); i++)
                {
                    DeltaW12[i][j] = 0.0;
                    W12[i][j] = 2.0 * (rando() - 0.5) * wmax;
                }
            }
            for (k = 1; k < (numSaida + 1); k++)
            {
                // Inicializa W23 e DeltaW23
                for (j = 0; j < (numEscondida + 1); j++)
                {
                    DeltaW23[j][k] = 0.0;
                    W23[j][k] = 2.0 * (rando() - 0.5) * wmax;
                }
            }

            for (epoca = 1; numIteracoes > 0 ? epoca < (numIteracoes + 1) : true; epoca++)
            {
                // Faz a iteracao da atualizacao dos pesos
                for (p = 1; p < (numPadroes + 1); p++)
                {
                    // Randomiza a ordem dos individuos
                    ranpad[p] = p;
                }

                for (p = 1; p < (numPadroes + 1); p++)
                {
                    np = (int)(p + rando() * (numPadroes - p + 0));
                    op = ranpad[p];
                    ranpad[p] = ranpad[np];
                    ranpad[np] = op;
                }
                Erro = 0.0;

                for (np = 1; np < (numPadroes + 1); np++)
                {
                    // Repete para todos os padroes de treinamento
                    p = ranpad[np];

                    for (j = 1; j < (numEscondida + 1); j++)
                    {
                        // Computa as ativacoes da unidade escondida
                        SomaEscondida[p][j] = W12[0][j];
                        for (i = 1; i < (numEntrada + 1); i++)
                        {
                            SomaEscondida[p][j] += entrada[p][i] * W12[i][j];
                        }
                        Escondida[p][j] = 1.0 / (1.0 + Math.Exp(-SomaEscondida[p][j]));
                    }

                    for (k = 1; k < (numSaida + 1); k++)
                    {
                        // Computa as unidades de ativacao da saida e erros
                        SomaSaida[p][k] = W23[0][k];
                        for (j = 1; j < (numEscondida + 1); j++)
                        {
                            SomaSaida[p][k] += Escondida[p][j] * W23[j][k];
                        }

                        switch (TipoSaida)
                        {
                            case 0:
                                Saida[p][k] = 1.0 / (1.0 + Math.Exp(-SomaSaida[p][k])); // Sigmoidal SAIDAs

                                break;
                            case 1:
                                Saida[p][k] = SomaSaida[p][k]; // Linear SAIDAs

                                break;
                        }

                        switch (TipoErro)
                        {
                            case 0:
                                Erro += 0.5 * (target[p][k] - Saida[p][k]) * (target[p][k] - Saida[p][k]); // SSE

                                break;
                            case 1:
                                Erro -= (target[p][k] * Math.Log(Saida[p][k]) + (1.0 - target[p][k]) * Math.Log(1.0 - Saida[p][k])); // Erro de Entropia Cruzada

                                break;
                        }

                        switch (TipoDeltaS)
                        {
                            case 0:
                                DeltaS[k] = (target[p][k] - Saida[p][k]) * Saida[p][k] * (1.0 - Saida[p][k]); // Sigmoidal SAIDAs, SSE */

                                break;
                            case 1:
                                DeltaS[k] = target[p][k] - Saida[p][k]; // Sigmoidal SAIDAs, Cross-Entropy Erro

                                break;
                            case 2:
                                DeltaS[k] = target[p][k] - Saida[p][k]; // Linear SAIDAs, SSE

                                break;
                        }
                    }

                    for (j = 1; j < (numEscondida + 1); j++)
                    {
                        // Retropropagacao de erros para a camada escondida
                        somaDWS[j] = 0.0;
                        for (k = 1; k < (numSaida + 1); k++)
                        {
                            somaDWS[j] += W23[j][k] * DeltaS[k];
                        }
                        DeltaE[j] = somaDWS[j] * Escondida[p][j] * (1.0 - Escondida[p][j]);
                    }

                    for (j = 1; j < (numEscondida + 1); j++)
                    {
                        // Atualiza pesos w12
                        DeltaW12[0][j] = eta * DeltaE[j] + alpha * DeltaW12[0][j];
                        W12[0][j] += DeltaW12[0][j];
                        for (i = 1; i < (numEntrada + 1); i++)
                        {
                            DeltaW12[i][j] = eta * entrada[p][i] * DeltaE[j] + alpha * DeltaW12[i][j];
                            W12[i][j] += DeltaW12[i][j];
                        }
                    }

                    for (k = 1; k < (numSaida + 1); k++)
                    {
                        // Atualiza pesos W23
                        DeltaW23[0][k] = eta * DeltaS[k] + alpha * DeltaW23[0][k];
                        W23[0][k] += DeltaW23[0][k];
                        for (j = 1; j < (numEscondida + 1); j++)
                        {
                            DeltaW23[j][k] = eta * Escondida[p][j] * DeltaS[k] + alpha * DeltaW23[j][k];
                            W23[j][k] += DeltaW23[j][k];
                        }
                    }
                }

                if (epoca % modEpocaDisplay == 0 || epoca == numIteracoes)
                {
                    tempoIntermediario = DateTime.Now;
                    // fprintf(cfPtr, "NETWORK DATA - Epoca %d - Neuronios %d - Iteracoes %d - Erro %lf - Tempo Execucao %.0lf [s].\n", epoca, numEscondida, numIteracoes, Erro, difftime(tempoIntermediario, tempoInicial)); // Mostra as SAIDAs
                    sw.Write("NETWORK DATA - Epoca " + epoca + " - Neuronios " + numEscondida + " - Iteracoes " + numIteracoes + " - Erro " + Erro + " - Tempo Execucao " + ((TimeSpan)(tempoIntermediario - tempoInicial)).TotalSeconds + " [s].\n"); // Mostra as SAIDAs
                    System.Console.Write("NETWORK DATA - Epoca " + epoca + " - Neuronios " + numEscondida + " - Iteracoes " + numIteracoes + " - Erro " + Erro + " - Tempo Execucao " + ((TimeSpan)(tempoIntermediario - tempoInicial)).TotalSeconds + " [s].\n"); // Mostra as SAIDAs
                }

                if (Erro < erroLimite)
                {
                    break; // Para o aprendizado quando o erro convergir para o valor descrito
                }
            }

            sw.Close();

            mtdExportarPesos();
            mtdEscreverErroTreinamento();
            mtdEscreverSaida(0);
            mtdFinalizarVetorMatriz();
            retorno = 1;

            return retorno;
        }

        public int mtdExecutarRedeNeural()
        {
            int retorno = 0;

            System.IO.StreamWriter sw = new System.IO.StreamWriter("erro_ExecucaoRedeNeural.dat", false);

            mtdDefinirModEpocaDisplay();
            mtdObterEntradasExecucao();
            mtdZerarAlvosExecucao(numPadroes);
            mtdGerarVetorMatriz();
            mtdIniciarPesos();

            for (epoca = 1; numIteracoes > 0 ? epoca < (numIteracoes + 1) : true; epoca++)
            {
                // Faz a iteracao da atualizacao dos pesos
                for (p = 1; p < (numPadroes + 1); p++)
                {
                    // Randomiza a ordem dos individuos
                    ranpad[p] = p;
                }
                for (p = 1; p < (numPadroes + 1); p++)
                {
                    np = (int)(p + rando() * (numPadroes - p + 0));
                    op = ranpad[p];
                    ranpad[p] = ranpad[np];
                    ranpad[np] = op;
                }
                Erro = 0.0;
                for (np = 1; np < (numPadroes + 1); np++)
                {
                    // Repete para todos os padroes de treinamento
                    p = ranpad[np];
                    for (j = 1; j < (numEscondida + 1); j++)
                    {
                        // Computa as ativacoes da unidade escondida
                        SomaEscondida[p][j] = W12[0][j];
                        for (i = 1; i < (numEntrada + 1); i++)
                        {
                            SomaEscondida[p][j] += entrada[p][i] * W12[i][j];
                        }
                        Escondida[p][j] = 1.0 / (1.0 + Math.Exp(-SomaEscondida[p][j]));
                    }
                    for (k = 1; k < (numSaida + 1); k++)
                    {
                        // Computa as unidades de ativacao da saida e erros
                        SomaSaida[p][k] = W23[0][k];
                        for (j = 1; j < (numEscondida + 1); j++)
                        {
                            SomaSaida[p][k] += Escondida[p][j] * W23[j][k];
                        }

                        switch (TipoSaida)
                        {
                            case 0:
                                Saida[p][k] = 1.0 / (1.0 + Math.Exp(-SomaSaida[p][k])); // Sigmoidal SAIDAs

                                break;
                            case 1:
                                Saida[p][k] = SomaSaida[p][k]; // Linear SAIDAs

                                break;
                        }

                        switch (TipoErro)
                        {
                            case 0:
                                Erro += 0.5 * (target[p][k] - Saida[p][k]) * (target[p][k] - Saida[p][k]); // SSE

                                break;
                            case 1:
                                Erro -= (target[p][k] * Math.Log(Saida[p][k]) + (1.0 - target[p][k]) * Math.Log(1.0 - Saida[p][k])); // Erro de Entropia Cruzada

                                break;
                        }

                        switch (TipoDeltaS)
                        {
                            case 0:
                                DeltaS[k] = (target[p][k] - Saida[p][k]) * Saida[p][k] * (1.0 - Saida[p][k]); // Sigmoidal SAIDAs, SSE */

                                break;
                            case 1:
                                DeltaS[k] = target[p][k] - Saida[p][k]; // Sigmoidal SAIDAs, Cross-Entropy Erro

                                break;
                            case 2:
                                DeltaS[k] = target[p][k] - Saida[p][k]; // Linear SAIDAs, SSE

                                break;
                        }
                    }
                    for (j = 1; j < (numEscondida + 1); j++)
                    {
                        // Retropropagacao de erros para a camada escondida
                        somaDWS[j] = 0.0;
                        for (k = 1; k < (numSaida + 1); k++)
                        {
                            somaDWS[j] += W23[j][k] * DeltaS[k];
                        }
                        DeltaE[j] = somaDWS[j] * Escondida[p][j] * (1.0 - Escondida[p][j]);
                    }
                    for (j = 1; j < (numEscondida + 1); j++)
                    {
                        // Atualiza pesos w12
                        DeltaW12[0][j] = eta * DeltaE[j] + alpha * DeltaW12[0][j];
                        W12[0][j] += DeltaW12[0][j];
                        for (i = 1; i < (numEntrada + 1); i++)
                        {
                            DeltaW12[i][j] = eta * entrada[p][i] * DeltaE[j] + alpha * DeltaW12[i][j];
                            W12[i][j] += DeltaW12[i][j];
                        }
                    }
                    for (k = 1; k < (numSaida + 1); k++)
                    {
                        // Atualiza pesos W23
                        DeltaW23[0][k] = eta * DeltaS[k] + alpha * DeltaW23[0][k];
                        W23[0][k] += DeltaW23[0][k];
                        for (j = 1; j < (numEscondida + 1); j++)
                        {
                            DeltaW23[j][k] = eta * Escondida[p][j] * DeltaS[k] + alpha * DeltaW23[j][k];
                            W23[j][k] += DeltaW23[j][k];
                        }
                    }
                }

                if (epoca % modEpocaDisplay == 0 || epoca == numIteracoes)
                {
                    tempoIntermediario = DateTime.Now;
                    sw.Write("NETWORK DATA - Epoca " + epoca + " - Neuronios " + numEscondida + " - Iteracoes " + numIteracoes + " - Erro " + Erro + " - Tempo Execucao " + ((TimeSpan)(tempoIntermediario - tempoInicial)).TotalSeconds + " [s].\n"); // Mostra as SAIDAs
                    System.Console.Write("NETWORK DATA - Epoca " + epoca + " - Neuronios " + numEscondida + " - Iteracoes " + numIteracoes + " - Erro " + Erro + " - Tempo Execucao " + ((TimeSpan)(tempoIntermediario - tempoInicial)).TotalSeconds + " [s].\n"); // Mostra as SAIDAs
                }
            }

            sw.Close();

            mtdObterErroTreinamento();
            mtdEscreverSaida(1);
            mtdFinalizarVetorMatriz();
            retorno = 1;

            return retorno;
        }

        public void mtdPausar()
        {
        }

        public void mtdSair()
        {
        }

        public void mtdTreinamentoRedeNeural(int Escondida, int Iteracoes, double ErroLimite)
        {
            tempoInicial = DateTime.Now;
            numEscondida = Escondida;
            numIteracoes = Iteracoes;
            erroLimite = ErroLimite;

            if (mtdTreinarRedeNeural() == 1)
            {
                System.Console.Write("Rede treinada com sucesso.\n");
            }
            else

            {
                System.Console.Write("Ocorreram erros.\n");
            }
            tempoFinal = DateTime.Now;
            System.Console.Write("Tempo decorrido para o treinamento da Rede Neural: " + ((TimeSpan)(tempoFinal - tempoInicial)).TotalSeconds + " [s].\n");

            // mtdPausar();
        }

        public void mtdExecucaoRedeNeural(int Escondida, int Iteracoes)
        {
            tempoInicial = DateTime.Now;
            numEscondida = Escondida;
            numIteracoes = Iteracoes;

            if (mtdExecutarRedeNeural() == 1)
            {
                System.Console.Write("Rede executada com sucesso.\n");
            }
            else

            {
                System.Console.Write("Ocorreram erros.\n");
            }
            tempoFinal = DateTime.Now;
            System.Console.Write("Tempo decorrido para a execucao da Rede Neural: " + ((TimeSpan)(tempoFinal - tempoInicial)).TotalSeconds + " [s].\n");

            // mtdPausar();
        }
    }
}