using System;

namespace ExercicioResolvido3
{
    class Produto: IComparable
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

        public int CompareTo(object obj)
        {
            Produto produto = (Produto)obj;
            int resultado = Descricao.CompareTo(produto.Descricao);
            if(resultado != 0)
            {
                return resultado;
            }
            return -Preco.CompareTo(produto.Preco);
        }
    }
}
