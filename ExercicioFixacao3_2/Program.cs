using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioFixacao3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Quarto[] quartos = InicializarQuartos(10);

            Console.Write("Quantos aluguéis serão registrados? ");
            int alugueis = int.Parse(Console.ReadLine());

            Console.Clear();

            RegistrarQuarto(alugueis, quartos);

            Console.Clear();

            string saida = QuartosOcupados(quartos);

            Console.Write(saida);
            Console.ReadKey();
        }

        public static Quarto[] RegistrarQuarto(int alugueis, Quarto[] quartos)
        {
            for (int i = 0; i < alugueis; i++)
            {
                int numeroQuarto;
                string nome, email;

                Console.WriteLine("Dados do {0}º quarto:", i + 1);

                Console.Write("Nome: ");
                nome = Console.ReadLine();

                Console.Write("Email: ");
                email = Console.ReadLine();

                Console.WriteLine(QuartosVagos(quartos));

                Console.Write("Quarto: ");
                numeroQuarto = int.Parse(Console.ReadLine());

                quartos[numeroQuarto].Alugar(nome, email, numeroQuarto);

                Console.Clear();
            }
            return quartos;
        }

        public static string QuartosOcupados(Quarto[] quartos)
        {
            Console.WriteLine("Quartos ocupados:");
            string saida = "";
            foreach (Quarto quarto in quartos)
            {
                if (quarto.Ocupacao == true)
                {
                    saida += quarto.ToString();
                }
            }
            return saida;
        }

        public static string QuartosVagos(Quarto[] quartos)
        {
            string saida = "Quartos Vagos: ";
            for (int i = 0; i < quartos.Length; i++)
            {
                if (quartos[i].Ocupacao == false)
                {
                    saida += i + " | ";
                }
            }
            return saida;
        }

        public static Quarto[] InicializarQuartos(int i)
        {
            Quarto[] quartos = new Quarto[i];
            while (i > 0)
            {
                quartos[i-1] = new Quarto();
                i--;
            }
            return quartos;
        }
    }
}
