using System.Globalization;

namespace ExercicioProposto1.Dominio
{
    class Participacao
    {
        public double desconto { get; set; }
        public Artista artista { get; set; }
        public Filme filme { get; set; }

        public Participacao(double desconto, Artista artista, Filme filme)
        {
            this.desconto = desconto;
            this.artista = artista;
            this.filme = filme;
        }

        public double custo()
        {
            return artista.cache - desconto;
        }

        public override string ToString()
        {
            return string.Format("{0}, Cachê: R{1:C}, Desconto: R{2:C}, Custo: R{3}\n", artista.nome, artista.cache, desconto, custo().ToString("C"));
        }
    }
}
