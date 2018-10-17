using jogo;
using System;
using tabuleiro;

namespace Xadrez
{
    class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tabuleiro)
        {
            for (int i = 0; i < tabuleiro.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tabuleiro.Colunas; j++)
                {
                    if (tabuleiro.peca(i, j)!=null)
                    {
                        ImprimirPeca(tabuleiro.peca(i, j));
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.Write("\n");
            }
            Console.WriteLine("  a b c d e f g h\n");
        }

        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }

        public static void ImprimirPeca(Peca peca)
        {
            if (peca._Cor == Cor.Preta)
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
            else
            {
                Console.Write(peca);
            }
        }
    }
}
