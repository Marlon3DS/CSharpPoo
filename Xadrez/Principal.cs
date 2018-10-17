using jogo;
using System;
using tabuleiro;

namespace Xadrez
{
    class Principal
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez partidaDeXadrez = new PartidaDeXadrez();
                while (!partidaDeXadrez.IsTerminada)
                {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partidaDeXadrez._Tabuleiro);

                    Console.Write("Origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();

                    partidaDeXadrez.ExecutaMovimento(origem, destino);
                }
            }
            catch(TabuleiroException tabEx)
            {
                Console.WriteLine(tabEx.Message);
            }
            Console.ReadKey();
        }
    }
}
