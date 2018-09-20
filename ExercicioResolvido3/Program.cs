using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioResolvido3
{
    class Program
    {
        private static List<Produto> listaProduto = new List<Produto>();
        private static List<Pedido> listaPedidos = new List<Pedido>();

        static void Main(string[] args)
        {
            CarregarProdutos();
            do{ } while (Menu());
        }

        static bool Menu()
        {
            bool retorno = true;
            int opcao = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("1 – Listar produtos ordenadamente\n2 – Cadastrar produto\n3 – Cadastrar pedido\n4 – Mostrar dados de um pedido\n5 – Sair");
                Console.Write("> ");

                int.TryParse(Console.ReadLine(), out opcao);

                switch (opcao)
                {
                    case 1:
                        ListarProdutos();
                        break;
                    case 2:
                        CadastrarProduto();
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        Console.Write("Até mais!");
                        retorno = false;
                        break;
                    default:
                        Console.Write("Opção inválida! Escolha entre 1 e 5");
                        break;
                }
                Console.ReadKey();
            } while (opcao != 5);
            return retorno;
        }

        static void CarregarProdutos()
        {
            listaProduto.Add(new Produto(1001, "Cadeira simples", 500.00));
            listaProduto.Add(new Produto(1002, "Cadeira simples", 900.00));
            listaProduto.Add(new Produto(1003, "Cadeira simples", 2000.00));
            listaProduto.Add(new Produto(1004, "Cadeira simples", 1500.00));
            listaProduto.Add(new Produto(1005, "Cadeira simples", 2000.00));
        }

        static void ListarProdutos()
        {
            Console.Clear();
            Console.WriteLine("LISTAGEM DE PRODUTOS" + Separador());
            foreach (Produto produto in listaProduto)
            {
                Console.WriteLine(produto.ToString());
            }
        }

        static void CadastrarProduto()
        {
            int opcao = 0;
            do
            {
                int codigo = ValidaCodigo();
                Console.Write("Descrição: ");
                string descricao = Console.ReadLine();
                Console.Write("Preço: ");
                double preco = double.Parse(Console.ReadLine());

                listaProduto.Add(new Produto(codigo, descricao, preco));

                Console.Write(Separador() + "Deseja cadastrar um novo Produto?(1 - Sim / 2 - Não)\n> ");
                int.TryParse(Console.ReadLine(), out opcao);
            } while (opcao != 2);
        }

        static int ValidaCodigo()
        {
            int codigo = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Digite os dados do Produto" + Separador());
                Console.Write("Código: ");
                codigo = int.Parse(Console.ReadLine());
                foreach (Produto produto in listaProduto)
                {
                    if(codigo == produto.Codigo)
                    {
                        Console.WriteLine("Código de Produto Duplicado!");
                        Console.ReadKey();
                        codigo = 0;
                    }
                }
            } while (codigo == 0);
            return codigo;
        }

        static string Separador()
        {
            string saida = "\n";
            for (int i = 0; i < 30; i++)
            {
                saida += "-";
            }
            saida += "\n";
            return saida;
        }
    }
}
