using System.Collections.Generic;
using System.Linq;
using System;

namespace CaixaEletronico
{
    public class CaixaEletronicoManager
    {
        const int MAX = 100000;
        static int[] W = new[] { 2, 5, 10, 20, 50, 100 };
        //static int[] W = new[] { 100, 50, 20, 10, 5, 2 };

        static int[] K = new int[MAX + 1];

        static CaixaEletronicoManager()
        {
            K[0] = 0;

            for (int i = 1; i <= MAX; i++) K[i] = -1;

            for (var i = 0; i < W.Length; i++)
                for (var j = W[i]; j <= MAX; j++)
                    if (K[j - W[i]] >= 0)
                        K[j] = i;
        }

        public int[] Sacar(int valor)
        {
            return Enumerate(valor).ToArray();
        }

        IEnumerable<int> Enumerate(int valor)
        {
            while (valor > 0)
            {
                if (K[valor] == -1) throw new InvalidOperationException();
                var moeda = W[K[valor]];
                yield return moeda;
                valor -= moeda;
            }
        }
    }
}
