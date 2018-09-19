using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioFixacao3_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string saida = "";
            string[] entrada = Console.ReadLine().Split(' ');
            int M = int.Parse(entrada[0]);
            int N = int.Parse(entrada[1]);
            int[,] matriz = new int[M, N];
            for (int i = 0; i < M; i++)
            {
                string[] linha = Console.ReadLine().Split(' ');
                for (int j = 0; j < N; j++)
                {
                    matriz[i, j] = int.Parse(linha[j]);
                }
            }
            int X = int.Parse(Console.ReadLine());
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (matriz[i,j] == X)
                    {
                        //Esquerda
                        if (j > 0)
                        {
                            saida += "Esquerda: " + matriz[i, j-1] + "\n";
                        }
                        //Acima
                        if (i > 0)
                        {
                            saida += "Acima: " + matriz[i - 1, j] + "\n";
                        }
                        //Direita
                        if (j < N - 1)
                        {
                            saida += "Direita: " + matriz[i, j + 1] + "\n";
                        }
                        //Abaixo
                        if (i < M - 1)
                        {
                            saida += "Abaixo: " + matriz[i + 1, j] + "\n";
                        }
                    }
                }
            }
            Console.WriteLine(saida);
            Console.ReadKey();
        }
    }
}
