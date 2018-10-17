using System;
using tabuleiro;

namespace jogo
{
    class PartidaDeXadrez
    {
        public Tabuleiro _Tabuleiro { get; private set; }
        private int Turno; 
        private Cor JogadorAtual;
        public bool IsTerminada { get; private set; }

        public PartidaDeXadrez()
        {
            _Tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            ColocarPecas();
            IsTerminada = false;
        }
        
        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca peca = _Tabuleiro.RetirarPeca(origem);
            peca.IncrementarQtdeMovimentos();
            _Tabuleiro.RetirarPeca(destino);
            _Tabuleiro.ColocarPeca(peca, destino);
        }

        private void ColocarPecas()
        {
            _Tabuleiro.ColocarPeca(new Torre(_Tabuleiro, Cor.Preta), new PosicaoXadrez('c', 8).ToPosicao());
            _Tabuleiro.ColocarPeca(new Rei(_Tabuleiro, Cor.Preta), new PosicaoXadrez('d', 8).ToPosicao());
            _Tabuleiro.ColocarPeca(new Torre(_Tabuleiro, Cor.Preta), new PosicaoXadrez('e', 8).ToPosicao());
            _Tabuleiro.ColocarPeca(new Torre(_Tabuleiro, Cor.Preta), new PosicaoXadrez('c', 7).ToPosicao());
            _Tabuleiro.ColocarPeca(new Torre(_Tabuleiro, Cor.Preta), new PosicaoXadrez('d', 7).ToPosicao());
            _Tabuleiro.ColocarPeca(new Torre(_Tabuleiro, Cor.Preta), new PosicaoXadrez('e', 7).ToPosicao());

            _Tabuleiro.ColocarPeca(new Torre(_Tabuleiro, Cor.Branca), new PosicaoXadrez('c', 2).ToPosicao());
            _Tabuleiro.ColocarPeca(new Torre(_Tabuleiro, Cor.Branca), new PosicaoXadrez('d', 2).ToPosicao());
            _Tabuleiro.ColocarPeca(new Torre(_Tabuleiro, Cor.Branca), new PosicaoXadrez('e', 2).ToPosicao());
            _Tabuleiro.ColocarPeca(new Torre(_Tabuleiro, Cor.Branca), new PosicaoXadrez('c', 1).ToPosicao());
            _Tabuleiro.ColocarPeca(new Rei(_Tabuleiro, Cor.Branca), new PosicaoXadrez('d', 1).ToPosicao());
            _Tabuleiro.ColocarPeca(new Torre(_Tabuleiro, Cor.Branca), new PosicaoXadrez('e', 1).ToPosicao());
        }
    }
}
