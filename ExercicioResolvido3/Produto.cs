using System;

namespace ExercicioResolvido3
{
    class Produto
    {
        public int Codigo { get; private set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }

        public Produto(int codigo, string descricao, double preco)
        {
            Codigo = codigo;
            Descricao = descricao;
            Preco = preco;
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}, {2:C}", Codigo, Descricao, Preco);
        }
    }
}
