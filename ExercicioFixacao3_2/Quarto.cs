using System;

namespace ExercicioFixacao3_2
{
    class Quarto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public int NumeroQuarto { get; set; }
        public bool Ocupacao { get; set; }

        public Quarto()
        {
            Nome = "";
            Email = "";
            NumeroQuarto = 0;
            Ocupacao = false;
        }

        public void Alugar(string nome, string email, int numeroQuarto)
        {
            Nome = nome;
            Email = email;
            NumeroQuarto = numeroQuarto;
            Ocupacao = true;
        }

        public override string ToString()
        {
            return String.Format("{0}: {1}, {2}\n", NumeroQuarto, Nome, Email);
        }
    }
}
