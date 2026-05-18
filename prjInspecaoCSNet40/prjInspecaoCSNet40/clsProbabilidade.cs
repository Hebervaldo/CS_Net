using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prjInspecaoCSNet40
{
    class clsProbabilidade
    {
        public clsProbabilidade()
        {
        }

        ~clsProbabilidade()
        {
        }

        public double mtdFatorial(int n)
        {
            double Resultado = 0;

            Resultado = -1;

            if (n <= 170)
            {
                Resultado = 1;

                if (n > 0)
                {
                    Resultado = n;
                    Resultado = Resultado * mtdFatorial(n - 1);
                }
            }

            return Resultado;
        }

        public double mtdArranjo(int n, int k)
        {
            double Resultado = 0;

            Resultado = -1;

            if ((n >= k) & (k >= 0))
            {
                Resultado = (mtdFatorial(n)) / (mtdFatorial(n - k));
            }

            return Resultado;
        }

        public double mtdCombinacao(int n, int k)
        {
            double Resultado = 0;

            Resultado = -1;

            if ((n >= k) & (k >= 0))
            {
                Resultado = (mtdArranjo(n, k)) / (mtdFatorial(k));
            }

            return Resultado;
        }

        public double mtdPermutacao(int n)
        {
            return mtdArranjo(n, n);
        }
    }
}
