namespace tabuleiro
{
    class Peca
    {
        public Cor _Cor { get; protected set; }
        public Tabuleiro _Tabuleiro { get; set; }
        public Posicao _Posicao { get; set; }
        public int QtdeMovimentos { get; protected set; }

        public Peca (Tabuleiro tabuleiro, Cor cor)
        {
            _Cor = cor;
            _Tabuleiro = tabuleiro;
            _Posicao = null;
            QtdeMovimentos = 0;
        }

        public void IncrementarQtdeMovimentos()
        {
            QtdeMovimentos++;
        }
    }
}
