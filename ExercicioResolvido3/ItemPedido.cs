namespace ExercicioResolvido3
{
    class ItemPedido
    {
        public int Quantidade { get; set; }
        public double PorcentagemDesconto { get; set; }
        public Produto _Produto { get; set; }

        public ItemPedido(int quantidade, double porcentagemDesconto, Produto produto)
        {
            Quantidade = quantidade;
            PorcentagemDesconto = porcentagemDesconto;
            _Produto = produto;
        }

        public double SubTotal()
        {
            double desconto = _Produto.Preco * (PorcentagemDesconto / 100);
            double resultado = (_Produto.Preco - desconto) * Quantidade;
            return resultado;
        }

        public override string ToString()
        {
            double sub = SubTotal();
            string saida = "";
            saida += string.Format("{0}, Preço: {1:C}, Qte: {2}, Desconto: {3}%, Subtotal: {4:C}\n",
                    _Produto.Descricao, _Produto.Preco, Quantidade, PorcentagemDesconto, sub);
            return saida;
        }
    }
}
