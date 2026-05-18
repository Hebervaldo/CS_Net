using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prjInspecaoCSNet35
{
    class clsEstatistica
    {
        public clsEstatistica()
        {
        }

        ~clsEstatistica()
        {
        }

        public double mtdRetornarMinimoValorVetor(double[] Vetor)
        {
            int contador = 0;
            double minValor = double.MaxValue;

            for (contador = 0; contador <= Vetor.Length - 1; contador++)
            {
                if (Vetor[contador] < minValor)
                {
                    minValor = Vetor[contador];
                }
            }

            return minValor;
        }

        public double mtdRetornarMinimoValorLista(List<double> Lista)
        {
            int contador = 0;
            double minValor = double.MaxValue;

            for (contador = 0; contador <= Lista.Count - 1; contador++)
            {
                if (Lista[contador] < minValor)
                {
                    minValor = Lista[contador];
                }
            }

            return minValor;
        }

        public double mtdRetornarMaximoValorVetor(double[] Vetor, int nVetor)
        {
            int contador = 0;
            double maxValor = double.MinValue;

            for (contador = 0; contador <= nVetor - 1; contador++)
            {
                if (Vetor[contador] > maxValor)
                {
                    maxValor = Vetor[contador];
                }
            }

            return maxValor;
        }

        public double mtdRetornarMaximoValorLista(List<double> Lista)
        {
            int contador = 0;
            double maxValor = double.MinValue;

            for (contador = 0; contador <= Lista.Count - 1; contador++)
            {
                if (Lista[contador] > maxValor)
                {
                    maxValor = Lista[contador];
                }
            }

            return maxValor;
        }

        public double mtdRetornarSomaValorVetor(double[] Vetor, int nVetor)
        {
            int contador = 0;
            double Soma = 0;

            for (contador = 0; contador <= nVetor - 1; contador++)
            {
                Soma += (Vetor[contador]);
            }

            return Soma;
        }

        public double mtdRetornarSomaValorLista(List<double> Lista)
        {
            int contador = 0;
            double Soma = 0;

            for (contador = 0; contador <= Lista.Count - 1; contador++)
            {
                Soma += (Lista[contador]);
            }

            return Soma;
        }

        public double mtdRetornarMediaValorVetor(double[] Vetor)
        {
            int contador = 0;
            double Media = 0;
            double Soma = 0;

            for (contador = 0; contador <= Vetor.Length - 1; contador++)
            {
                Soma += (Vetor[contador]);
            }

            Media = Soma / Vetor.Length;

            return Media;
        }

        public double mtdRetornarMediaValorLista(List<double> Lista)
        {
            int contador = 0;
            double Media = 0;
            double Soma = 0;

            for (contador = 0; contador <= Lista.Count - 1; contador++)
            {
                Soma += (Lista[contador]);
            }

            Media = Soma / Lista.Count;

            return Media;
        }

        public double mtdRetornarVarianciaValorVetor(double[] Vetor, int opcao)
        {
            int contador = 0;
            double Media = 0;
            double Variancia = 0;

            Media = mtdRetornarMediaValorVetor(Vetor);

            for (contador = 0; contador <= Vetor.Length - 1; contador++)
            {
                switch (opcao)
                {
                    case 0:
                        Variancia += Math.Pow((Vetor[contador]) - Media, 2) / (Vetor.Length);
                        break;
                    case 1:
                        Variancia += Math.Pow((Vetor[contador]) - Media, 2) / (Vetor.Length - 1);
                        break;
                    case 2:
                        Variancia += Math.Pow((Vetor[contador]) - Media, 2) / (Vetor.Length * (Vetor.Length - 1));
                        break;
                }
            }

            return Variancia;
        }

        public double mtdRetornarVarianciaValorLista(List<double> Lista, int opcao)
        {
            int contador = 0;
            double Media = 0;
            double Variancia = 0;

            Media = mtdRetornarMediaValorLista(Lista);

            for (contador = 0; contador <= Lista.Count - 1; contador++)
            {
                switch (opcao)
                {
                    case 0:
                        Variancia += Math.Pow((Lista[contador]) - Media, 2) / (Lista.Count);
                        break;
                    case 1:
                        Variancia += Math.Pow((Lista[contador]) - Media, 2) / (Lista.Count - 1);
                        break;
                    case 2:
                        Variancia += Math.Pow((Lista[contador]) - Media, 2) / (Lista.Count * (Lista.Count - 1));
                        break;
                }
            }

            return Variancia;
        }

        public double mtdRetornarDesvioPadraoValorVetor(double[] Vetor, int opcao)
        {
            int contador = 0;
            double DesvioPadrao = 0;
            double Variancia = 0;

            Variancia = (mtdRetornarVarianciaValorVetor(Vetor, opcao));

            DesvioPadrao = Math.Sqrt(Variancia);

            return DesvioPadrao;
        }

        public double mtdRetornarDesvioPadraoValorLista(List<double> Lista, int opcao)
        {
            int contador = 0;
            double DesvioPadrao = 0;
            double Variancia = 0;

            Variancia = (mtdRetornarVarianciaValorLista(Lista, opcao));

            DesvioPadrao = Math.Sqrt(Variancia);

            return DesvioPadrao;
        }
    }
}
