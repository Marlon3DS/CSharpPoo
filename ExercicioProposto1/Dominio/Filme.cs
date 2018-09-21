using System.Collections.Generic;
using System.Globalization;

namespace ExercicioProposto1.Dominio
{
    class Filme
    {
        public int codigo { get; set; }
        public string titulo { get; set; }
        public int ano { get; set; }
        public List<Participacao> participacoes { get; set; }

        public Filme(int codigo, string titulo, int ano)
        {
            this.codigo = codigo;
            this.titulo = titulo;
            this.ano = ano;
            participacoes = new List<Participacao>();
        }

        public double custoTotal()
        {
            double resultado = 0;
            foreach (Participacao participacao in participacoes)
            {
                resultado += participacao.custo();
            }
            return resultado;
        }

        public override string ToString()
        {
            string saida = string.Format("Filme {0}, Título: {1}, Ano: {2}\nParticipações:\n", codigo, titulo, ano);
            foreach (Participacao participacao in participacoes)
            {
                saida += participacao.ToString();
            }
            saida += "Custo total do filme: R" + custoTotal().ToString("C");
            return saida;
        }
    }
}
