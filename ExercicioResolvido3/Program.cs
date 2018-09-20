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
        private static List<ItemPedido> listaItemPedidos = new List<ItemPedido>();
        private static List<Pedido> listaPedidos = new List<Pedido>();

        static void Main(string[] args)
        {
            CarregarProdutos();
            Menu();
        }

        static void Menu()
        {
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
                        CadastrarPedido();
                        break;
                    case 4:
                        MostrarPedido();
                        break;
                    case 5:
                        Console.Write("Até mais!");
                        break;
                    default:
                        Console.Write("Opção inválida! Escolha entre 1 e 5");
                        break;
                }
                Console.ReadKey();
            } while (opcao != 5);
        }

        static void CarregarProdutos()
        {
            listaProduto.Add(new Produto(1001, "Cadeira simples", 500.00));
            listaProduto.Add(new Produto(1002, "Cadeira acolchoada", 900.00));
            listaProduto.Add(new Produto(1003, "Sofá de três lugares", 2000.00));
            listaProduto.Add(new Produto(1004, "Mesa retangular", 1500.00));
            listaProduto.Add(new Produto(1005, "Mesa retangular", 2000.00));
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

        static void CadastrarPedido()
        {
            Console.Clear();
            Console.WriteLine("Digite os dados do pedido:");
            Console.Write("Código: ");
            int codigo = int.Parse(Console.ReadLine());
            Console.Write("Dia: ");
            int dia = int.Parse(Console.ReadLine());
            Console.Write("Mês: ");
            int mes = int.Parse(Console.ReadLine());
            Console.Write("Ano: ");
            int ano = int.Parse(Console.ReadLine());
            DateTime data = Convert.ToDateTime(String.Format(dia + "/" + mes + "/" + ano));
            Console.Write("Quantos itens tem o pedido ? ");
            int opcao = int.Parse(Console.ReadLine());
            for (int i = 0; i < opcao; i++)
            {
                Console.WriteLine("Digite os dados do {0}º item:", i+1);
                Console.Write("Produto (Código): ");
                int codigoProduto = int.Parse(Console.ReadLine());
                Produto produto = LocalizaProduto(codigoProduto);
                Console.Write("Quantidade: ");
                int quantidade = int.Parse(Console.ReadLine());
                Console.Write("Porcentagem de desconto: ");
                double porcentagemDesconto = double.Parse(Console.ReadLine());
                listaItemPedidos.Add(new ItemPedido(quantidade, porcentagemDesconto, produto));
            }
            listaPedidos.Add(new Pedido(codigo, data, listaItemPedidos));
        }

        static Produto LocalizaProduto(int codigoProduto)
        {
            foreach (Produto item in listaProduto)
            {
                if(item.Codigo == codigoProduto)
                {
                    return item;
                }
            }
            return null;
        }

        static void MostrarPedido()
        {
            Console.Clear();
            Console.Write("Digite o Código do pedido: ");
            int codigo = int.Parse(Console.ReadLine());
            Pedido pedido = LocalizaPedido(codigo);
            Console.WriteLine("\nPedido {0}, data: {1}\nItens:\n", pedido.Codigo, pedido.Data);
            foreach (ItemPedido item in pedido.Pedidos)
            {
                Console.Write("{0}, Preço: {1}, Qte: {2}, Desconto: {3}, ",
                    item._Produto.Descricao, item._Produto.Preco, item.Quantidade, item.PorcentagemDesconto);
                Console.Write("Subtotal: {0}\n", item.SubTotal());
            }
            Console.WriteLine("Total do pedido: {0}", pedido.ValorTotal());
        }

        static Pedido LocalizaPedido(int codigoPedido)
        {
            foreach (Pedido item in listaPedidos)
            {
                if (item.Codigo == codigoPedido)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
