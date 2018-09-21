using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using ExercicioProposto1.Dominio;


namespace ExercicioProposto1
{
    class Tela
    {
        public static void carregarMenu()
        {
            Console.Clear();
            Console.WriteLine("1 – Listar artistas ordenadamente");
            Console.WriteLine("2 – Cadastrar artista");
            Console.WriteLine("3 – Cadastrar filme");
            Console.WriteLine("4 – Mostrar dados de um filme");
            Console.WriteLine("5 – Sair");
            Console.Write("> ");
        }

        public static void carregarMetodo(string opcaoMenu)
        {
            Type tipoTela = typeof(Tela);
            tipoTela.InvokeMember(opcaoMenu, BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Static, null, tipoTela, null);
        }

        private static void ListarArtistas()
        {
            Console.Clear();
            Console.WriteLine("LISTAGEM DE ARTISTAS:");
            foreach (Artista artista in Program.lstArtistas)
            {
                Console.WriteLine(artista.ToString());
            }
            Console.ReadKey();
        }

        private static void CadastrarArtista()
        {
            int pos = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Digite os dados do artista:");
                Console.Write("Código: ");
                try
                {
                    int codigo = ConverterInt(Console.ReadLine());
                    pos = Program.lstArtistas.FindIndex(x => x.codigo == codigo);
                    if (pos == -1)
                    {
                        Console.Write("Nome: ");
                        string nome = Console.ReadLine();
                        Console.Write("Valor do Cachê: ");
                        double cache = double.Parse(Console.ReadLine());
                        Program.lstArtistas.Add(new Artista(codigo, nome, cache));
                        Program.lstArtistas.Sort();
                    }
                    else
                    {
                        Console.WriteLine("Código de Artista Duplicado!");
                        Console.ReadKey();
                    }
                }
                catch (ModelException mde)
                {
                    Console.WriteLine(mde.Message);
                    Console.ReadKey();
                }
            } while(pos != -1);
        }

        private static void CadastrarFilme()
        {
            int pos = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Digite os dados do filme:");
                Console.Write("Código: ");
                try
                {
                    int codigo = ConverterInt(Console.ReadLine());
                    pos = Program.lstArtistas.FindIndex(x => x.codigo == codigo);
                    if (pos == -1)
                    {
                        Console.Write("Titulo: ");
                        string titulo = Console.ReadLine();
                        Console.Write("Ano: ");
                        int ano = int.Parse(Console.ReadLine());
                        Console.Write("Quantas participações tem o filme? ");
                        int numeroParticipantes = int.Parse(Console.ReadLine());
                        Filme filme = new Filme(codigo, titulo, ano);
                        for (int i = 1; i <= numeroParticipantes; i++)
                        {
                            Console.WriteLine("Digite os dados da {0}ª participação:", i);
                            Console.Write("Artista (Código): ");
                            int codigoArtista = ConverterInt(Console.ReadLine());
                            Artista artista = Program.lstArtistas.Find(x => x.codigo == codigoArtista);
                            if (artista != null)
                            {
                                Console.Write("Desconto: ");
                                int desconto = int.Parse(Console.ReadLine());
                                filme.participacoes.Add(new Participacao(desconto, artista, filme));
                            }
                            else
                            {
                                Console.WriteLine("Erro! Artista não localizado.");
                                i--;
                                Console.ReadKey();
                            }
                        }
                        Program.lstFilmes.Add(filme);
                    }
                    else
                    {
                        Console.WriteLine("Código de Filme Duplicado!");
                        Console.ReadKey();
                    }
                }
                catch (ModelException mde)
                {
                    Console.WriteLine(mde.Message);
                    Console.ReadKey();
                }
            } while (pos != -1);
        }

        private static void MostrarDados()
        {
            bool filmeExist = false;
            do
            {
                Console.Clear();
                Console.Write("Digite o código do filme:");
                try
                {
                    int codigo = ConverterInt(Console.ReadLine());
                    Filme filme = Program.lstFilmes.Find(x => x.codigo == codigo);
                    if (filme != null)
                    {
                        Console.WriteLine(filme.ToString());
                        filmeExist = true;
                    }
                    else
                    {
                        Console.WriteLine("Erro! Filme não localizado.");
                    }
                    Console.ReadKey();
                }
                catch (ModelException mde)
                {
                    Console.WriteLine(mde.Message);
                    Console.ReadKey();
                }
            } while (!filmeExist);
        }

        public enum OpcoesMenu
        {
            ListarArtistas = 1,
            CadastrarArtista = 2,
            CadastrarFilme = 3,
            MostrarDados = 4
        }

        public static int ConverterInt(string valor)
        {
            int retorno = 0;
            int.TryParse(valor, out retorno);
            if (retorno != 0)
            {
                return retorno;
            }
            else
            {
                throw new ModelException("Valor inválido! Digite apenas Numeros");
            }
        }
    }
}
