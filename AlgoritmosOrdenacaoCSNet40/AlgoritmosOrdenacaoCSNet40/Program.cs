using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmosOrdenacaoCSNet40
{
    class Program
    {
        private const int tamanhoVetor = 100000;
        //private static System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
        private static StopWatch stopWatch = new StopWatch();
        private static int[] vetor = new int[tamanhoVetor];
        private static int[] vetorDadosInicial = new int[tamanhoVetor];

        private static string enderecoArquivo = string.Empty;
        private static string nomeArquivo = string.Empty;

        static void Main(string[] args)
        {
            StopWatch stopWatch = new StopWatch();

            // stopWatch.Reset();
            stopWatch.Start();

            mtdVetorDadosAleatorios();

            Console.WriteLine("Metodo: {0}", "Insertion Sort");
            Console.WriteLine(string.Format("Tempo: {0}", mtdOpcaoInsertionSort()));

            Console.WriteLine("Metodo: {0}", "Shell Sort");
            Console.WriteLine(string.Format("Tempo: {0}", mtdOpcaoShellSort()));

            Console.WriteLine("Metodo: {0}", "Selection Sort");
            Console.WriteLine(string.Format("Tempo: {0}", mtdOpcaoSelectionSort()));

            Console.WriteLine("Metodo: {0}", "Heap Sort");
            Console.WriteLine(string.Format("Tempo: {0}", mtdOpcaoHeapSort()));

            Console.WriteLine("Metodo: {0}", "Bubble Sort");
            Console.WriteLine(string.Format("Tempo: {0}", mtdOpcaoBubbleSort()));

            Console.WriteLine("Metodo: {0}", "Cocktail Sort");
            Console.WriteLine(string.Format("Tempo: {0}", mtdOpcaoCocktailSort()));

            Console.WriteLine("Metodo: {0}", "Comb Sort");
            Console.WriteLine(string.Format("Tempo: {0}", mtdOpcaoCombSort()));

            Console.WriteLine("Metodo: {0}", "Gnome Sort");
            Console.WriteLine(string.Format("Tempo: {0}", mtdOpcaoGnomeSort()));

            Console.WriteLine("Metodo: {0}", "Odd-Even Sort");
            Console.WriteLine(string.Format("Tempo: {0}", mtdOpcaoOddEvenSort()));

            Console.WriteLine("Metodo: {0}", "Quick Sort");
            Console.WriteLine(string.Format("Tempo: {0}", mtdOpcaoQuickSort()));

            stopWatch.Stop();
            Console.WriteLine(string.Format("Tempo Total: {0}", stopWatch.ElapsedMiliSegundos()));

            Console.ReadKey();
        }

        private static double mtdOpcaoInsertionSort()
        {
            mtdCopiarVetorDados(vetorDadosInicial);

            // stopWatch.Reset();
            stopWatch.Start();
            int[] novoVetor = Ordenacoes.insertionSort(vetor);
            stopWatch.Stop();

            // nomeArquivo = "InsertionSort_D.txt";
            // mtdGerarArquivoTexto(enderecoArquivo, nomeArquivo, mtdConverteVetor(vetorDadosInicial));
            // nomeArquivo = "InsertionSort_O.txt";
            // mtdGerarArquivoTexto(enderecoArquivo, nomeArquivo, mtdConverteVetor(novoVetor));

            return stopWatch.ElapsedMiliSegundos();
        }

        private static double mtdOpcaoShellSort()
        {
            mtdCopiarVetorDados(vetorDadosInicial);

            // stopWatch.Reset();
            stopWatch.Start();
            int[] novoVetor = Ordenacoes.shellSort(vetor);
            stopWatch.Stop();

            // nomeArquivo = "ShellSort_D.txt";
            // mtdGerarArquivoTexto(enderecoArquivo, nomeArquivo, mtdConverteVetor(vetorDadosInicial));
            // nomeArquivo = "ShellSort_O.txt";
            // mtdGerarArquivoTexto(enderecoArquivo, nomeArquivo, mtdConverteVetor(novoVetor));

            return stopWatch.ElapsedMiliSegundos();
        }

        private static double mtdOpcaoSelectionSort()
        {
            mtdCopiarVetorDados(vetorDadosInicial);

            // stopWatch.Reset();
            stopWatch.Start();
            int[] novoVetor = Ordenacoes.selectionSort(vetor);
            stopWatch.Stop();

            // nomeArquivo = "SelectionSort_D.txt";
            // mtdGerarArquivoTexto(enderecoArquivo, nomeArquivo, mtdConverteVetor(vetorDadosInicial));
            // nomeArquivo = "SelectionSort_O.txt";
            // mtdGerarArquivoTexto(enderecoArquivo, nomeArquivo, mtdConverteVetor(novoVetor));

            return stopWatch.ElapsedMiliSegundos();
        }

        private static double mtdOpcaoHeapSort()
        {
            mtdCopiarVetorDados(vetorDadosInicial);

            // stopWatch.Reset();
            stopWatch.Start();
            int[] novoVetor = Ordenacoes.heapSort(vetor);
            stopWatch.Stop();

            // nomeArquivo = "HeapSort_D.txt";
            // mtdGerarArquivoTexto(enderecoArquivo, nomeArquivo, mtdConverteVetor(vetorDadosInicial));
            // nomeArquivo = "HeapSort_O.txt";
            // mtdGerarArquivoTexto(enderecoArquivo, nomeArquivo, mtdConverteVetor(novoVetor));

            return stopWatch.ElapsedMiliSegundos();
        }

        private static double mtdOpcaoBubbleSort()
        {
            mtdCopiarVetorDados(vetorDadosInicial);

            // stopWatch.Reset();
            stopWatch.Start();
            int[] novoVetor = Ordenacoes.bubbleSort(vetor);
            stopWatch.Stop();

            // nomeArquivo = "BubbleSort_D.txt";
            // mtdGerarArquivoTexto(enderecoArquivo, nomeArquivo, mtdConverteVetor(vetorDadosInicial));
            // nomeArquivo = "BubbleSort_O.txt";
            // mtdGerarArquivoTexto(enderecoArquivo, nomeArquivo, mtdConverteVetor(novoVetor));

            return stopWatch.ElapsedMiliSegundos();
        }

        private static double mtdOpcaoCocktailSort()
        {
            mtdCopiarVetorDados(vetorDadosInicial);

            // stopWatch.Reset();
            stopWatch.Start();
            int[] novoVetor = Ordenacoes.cocktailSort(vetor);
            stopWatch.Stop();

            // nomeArquivo = "CocktailSort_D.txt";
            // mtdGerarArquivoTexto(enderecoArquivo, nomeArquivo, mtdConverteVetor(vetorDadosInicial));
            // nomeArquivo = "CocktailSort_O.txt";
            // mtdGerarArquivoTexto(enderecoArquivo, nomeArquivo, mtdConverteVetor(novoVetor));

            return stopWatch.ElapsedMiliSegundos();
        }

        private static double mtdOpcaoCombSort()
        {
            mtdCopiarVetorDados(vetorDadosInicial);

            // stopWatch.Reset();
            stopWatch.Start();
            int[] novoVetor = Ordenacoes.combSort(vetor);
            stopWatch.Stop();

            // nomeArquivo = "CombSort_D.txt";
            // mtdGerarArquivoTexto(enderecoArquivo, nomeArquivo, mtdConverteVetor(vetorDadosInicial));
            // nomeArquivo = "CombSort_O.txt";
            // mtdGerarArquivoTexto(enderecoArquivo, nomeArquivo, mtdConverteVetor(novoVetor));

            return stopWatch.ElapsedMiliSegundos();
        }

        private static double mtdOpcaoGnomeSort()
        {
            mtdCopiarVetorDados(vetorDadosInicial);

            // stopWatch.Reset();
            stopWatch.Start();
            int[] novoVetor = Ordenacoes.gnomeSort(vetor);
            stopWatch.Stop();

            // nomeArquivo = "GnomeSort_D.txt";
            // mtdGerarArquivoTexto(enderecoArquivo, nomeArquivo, mtdConverteVetor(vetorDadosInicial));
            // nomeArquivo = "GnomeSort_O.txt";
            // mtdGerarArquivoTexto(enderecoArquivo, nomeArquivo, mtdConverteVetor(novoVetor));

            return stopWatch.ElapsedMiliSegundos();
        }

        private static double mtdOpcaoOddEvenSort()
        {
            mtdCopiarVetorDados(vetorDadosInicial);

            // stopWatch.Reset();
            stopWatch.Start();
            int[] novoVetor = Ordenacoes.oddEvenSort(vetor);
            stopWatch.Stop();

            // nomeArquivo = "OddEvenSort_D.txt";
            // mtdGerarArquivoTexto(enderecoArquivo, nomeArquivo, mtdConverteVetor(vetorDadosInicial));
            // nomeArquivo = "OddEvenSort_O.txt";
            // mtdGerarArquivoTexto(enderecoArquivo, nomeArquivo, mtdConverteVetor(novoVetor));

            return stopWatch.ElapsedMiliSegundos();
        }

        private static double mtdOpcaoQuickSort()
        {
            mtdCopiarVetorDados(vetorDadosInicial);

            // stopWatch.Reset();
            stopWatch.Start();
            int[] novoVetor = Ordenacoes.quickSort(vetor);
            stopWatch.Stop();

            // nomeArquivo = "QuickSortt_D.txt";
            // mtdGerarArquivoTexto(enderecoArquivo, nomeArquivo, mtdConverteVetor(vetorDadosInicial));
            // nomeArquivo = "QuickSort_O.txt";
            // mtdGerarArquivoTexto(enderecoArquivo, nomeArquivo, mtdConverteVetor(novoVetor));

            return stopWatch.ElapsedMiliSegundos();
        }

        private static string mtdConverteVetor(int[] vetor)
        {
            string virgula = string.Empty;
            string valores = string.Empty;
            for (int i = 0; i < vetor.Length; i++)
            {
                valores += virgula + vetor[i];
                virgula = ", ";
            }

            return valores;
        }

        private static bool mtdGerarArquivoTexto(string EnderecoArquivo, string NomeArquivo, string ConteudoArquivo)
        {
            bool retorno = false;
            System.Exception exception = new System.Exception();

            try
            {
                // Write out to text file
                System.IO.StreamWriter writer = System.IO.File.CreateText(string.Format(@"{0}{1}", EnderecoArquivo, NomeArquivo));
                writer.WriteLine(ConteudoArquivo);
                writer.Close();

                // Write out to binary file
                //System.IO.BinaryWriter binWriter = new System.IO.BinaryWriter(System.IO.File.OpenWrite(string.Format(@"{0}{1}", EnderecoArquivo, NomeArquivo)));
                //binWriter.Write(ConteudoArquivo);
                //binWriter.Close();

                retorno = true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                retorno = false;
            }

            return retorno;
        }

        private static void mtdVetorDadosAleatorios()
        {
            System.Random rnd = new System.Random();

            //vetorDados = new int[tamanhoVetor];

            for (int contador = 0; contador <= vetorDadosInicial.Length - 1; contador++)
            {
                vetorDadosInicial[contador] = rnd.Next();
            }
        }

        private static void mtdCopiarVetorDados(int[] vetorDadosInicial)
        {
            StopWatch stopWatch = new StopWatch();

            // stopWatch.Reset();
            stopWatch.Start();

            //vetorDadosFinal = new int[vetorDadosInicial.Length];

            for (int contador = 0; contador <= vetorDadosInicial.Length - 1; contador++)
            {
                vetor[contador] = vetorDadosInicial[contador];
            }

            stopWatch.Stop();
            Console.WriteLine(string.Format("Tempo de copia: {0}", stopWatch.ElapsedMiliSegundos()));
        }
    }
}
