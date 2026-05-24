using System;

namespace Solucoes_Rede_Neural_CSNet
{
    public class clsRedeNeural
    {
        // Variáveis de classe.
        private static Random objRandom = new Random();
        // Variáveis de instância.
        private int NumEntrada, NumPadroes, NumSaida, NumEscondida, NumIteracoes;
        private int i, j, k                    , p, np, op, epoca;
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
            tipoerro, tipodelta, ref resultado, ref strerro, ref strpesos, ref epocaporcent, ref tempoexecucao);
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
            return mtdRotina(entrada, target, ref W12, ref W23, NumeroEscondida, NumeroIteracoes, ref erro, erromax,
            tiposaida, tipoerro, tipodelta, ref resultado, ref strerro, ref strpesos, ref epocaporcent, ref tempoexecucao);
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
            }
            return dblMaximoValor;
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