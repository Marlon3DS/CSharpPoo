using System;
using System.Globalization;

namespace ExercicioProposto1.Dominio
{
    class Artista: IComparable
    {
        public int codigo { get; set; }
        public string nome { get; set; }
        public double cache { get; set; }

        public Artista(int codigo, string nome, double cache)
        {
            this.codigo = codigo;
            this.nome = nome;
            this.cache = cache;
        }

        public int CompareTo(object obj)
        {
            Artista artista = (Artista)obj;
            return nome.CompareTo(artista.nome);
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, Cachê: R{2:C}", codigo, nome, cache, CultureInfo.GetCultureInfo("pt-BR"));
        }
    }
}
