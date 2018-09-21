using System;
using System.Collections.Generic;
using ExercicioProposto1.Dominio;

namespace ExercicioProposto1
{
    class Program
    {
        public static List<Artista> lstArtistas = new List<Artista>();
        public static List<Filme> lstFilmes = new List<Filme>();

        static void Main(string[] args)
        {
            InicializarArtistas();
            InicializarPrograma();
        }

        static void InicializarPrograma()
        {
            int opcao = 0;
            while (opcao != 5)
            {
                Tela.carregarMenu();
                try
                {
                    opcao = Tela.ConverterInt(Console.ReadLine());
                    if (opcao != 0)
                    {
                        if (Enum.IsDefined(typeof(Tela.OpcoesMenu), opcao))
                        {
                            Tela.OpcoesMenu opcoesMenu = (Tela.OpcoesMenu)opcao;
                            Tela.carregarMetodo(opcoesMenu.ToString());
                        }
                        else if (opcao != 5)
                        {
                            Console.WriteLine("Digite somente números entre 1 e 5!");
                            Console.ReadKey();
                        }
                    }
                }
                catch (ModelException mde)
                {
                    Console.WriteLine(mde.Message);
                    Console.ReadKey();
                }
            }
        }

        static void InicializarArtistas()
        {
            lstArtistas.Add(new Artista(101, "Scarlett Johansson", 4000000));
            lstArtistas.Add(new Artista(102, "Chris Evans", 2500000));
            lstArtistas.Add(new Artista(103, "Robert Downey Jr.", 3000000));
            lstArtistas.Add(new Artista(104, "Morgan Freeman", 4000000));
            lstArtistas.Sort();
        }
    }
}
