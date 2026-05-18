// See https://aka.ms/new-console-template for more information
namespace prjRedeNeuralCSCoreNet
{
    class Program
    {
        private static clsRedeNeural objRedeNeural = new clsRedeNeural();

        public static void mtdPadrao()
        {
            int opcao = 0;

            do
            {
                // system("cls || clear");
                System.Console.Write("Menu Rede Neural - Escolha uma opcao\n");
                System.Console.Write("0. Treinar a Rede Neural\n");
                System.Console.Write("1. Executar a Rede Neural\n");
                System.Console.Write("2. Sair.\n");

                opcao = int.Parse(System.Console.ReadLine().Replace(".", ","));
                // system("cls || clear");

                switch (opcao)
                {
                    case 0:
                        System.Console.Write("Digite o numero de neuronios da Rede Neural:\n");
                        objRedeNeural.numEscondida = int.Parse(System.Console.ReadLine().Replace(".", ","));
                        System.Console.Write("Digite o numero de iteracoes da Rede Neural:\n");
                        objRedeNeural.numIteracoes = int.Parse(System.Console.ReadLine().Replace(".", ","));
                        System.Console.Write("Digite o erro limite: \n");
                        objRedeNeural.erroLimite = Double.Parse(System.Console.ReadLine().Replace(".", ","));
                        // printf("Escolha o tipo de Saida: \n");
                        // scanf("%d", &TipoSaida);
                        // printf("Escolha o tipo de Erro: \n");
                        // scanf("%lf", &TipoErro);
                        // printf("Escolha o tipo de DeltaS: \n");
                        // scanf("%lf", &TipoDeltaS);

                        objRedeNeural.tempoInicial = DateTime.Now;
                        if (objRedeNeural.mtdTreinarRedeNeural() == 1)
                        {
                            System.Console.Write("Rede treinada com sucesso.\n");
                        }
                        else
                        {
                            System.Console.Write("Ocorreram erros.\n");
                        }
                        objRedeNeural.tempoFinal = DateTime.Now;
                        System.Console.Write("Tempo decorrido para o treinamento da Rede Neural: " + ((TimeSpan)(objRedeNeural.tempoFinal - objRedeNeural.tempoInicial)).TotalSeconds + " [s].\n");

                        objRedeNeural.mtdEscreverNumeroNeuronios();

                        objRedeNeural.primeiraExecucao = 0;

                        break;
                    case 1:
                        objRedeNeural.mtdObterNumeroNeuronios();
                        if (objRedeNeural.numEscondida <= 0 && objRedeNeural.primeiraExecucao == 1)
                        {
                            System.Console.Write("Digite o numero de neuronios da Rede Neural:\n");
                            objRedeNeural.numEscondida = int.Parse(System.Console.ReadLine().Replace(".", ","));
                            objRedeNeural.mtdEscreverNumeroNeuronios();
                        }
                        objRedeNeural.numIteracoes = 1;
                        // printf("Escolha o tipo de Saida: \n");
                        // scanf("%d", &TipoSaida);
                        // printf("Escolha o tipo de Erro: \n");
                        // scanf("%lf", &TipoErro);
                        // printf("Escolha o tipo de DeltaS: \n");
                        // scanf("%lf", &TipoDeltaS);

                        objRedeNeural.tempoInicial = DateTime.Now;
                        if (objRedeNeural.mtdExecutarRedeNeural() == 1)
                        {
                            System.Console.Write("Rede executada com sucesso.\n");
                        }
                        else
                        {
                            System.Console.Write("Ocorreram erros.\n");
                        }
                        objRedeNeural.tempoFinal = DateTime.Now;
                        System.Console.Write("Tempo decorrido para a execucao da Rede Neural: " + ((TimeSpan)(objRedeNeural.tempoFinal - objRedeNeural.tempoInicial)).TotalSeconds + " [s].\n");

                        objRedeNeural.primeiraExecucao = 0;

                        break;
                    case 2:
                        objRedeNeural.mtdSair();

                        break;
                    default:
                        System.Console.Write("Digite uma opcao valida.\n");

                        break;
                }

                objRedeNeural.mtdPausar();
            }
            while (opcao != 2);
        }

        static void Main(string[] args)
        {
            switch (args.Length)
            {
                case 2:
                    if (int.Parse(args[1]) <= 0)
                    {
                        objRedeNeural.mtdObterNumeroNeuronios();
                    }
                    else
                    {
                        objRedeNeural.numEscondida = int.Parse(args[1].Replace(".", ","));
                    }
                    objRedeNeural.mtdExecucaoRedeNeural(objRedeNeural.numEscondida, 1);
                    objRedeNeural.mtdEscreverNumeroNeuronios();

                    break;
                case 4:
                    objRedeNeural.mtdTreinamentoRedeNeural(int.Parse(args[1].Replace(".", ",")), int.Parse(args[2].Replace(".", ",")), Double.Parse(args[3].Replace(".", ",")));
                    objRedeNeural.mtdEscreverNumeroNeuronios();

                    break;
                default:
                    mtdPadrao();

                    break;
            }
        }
    }
}