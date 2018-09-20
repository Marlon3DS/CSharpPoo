using System;
using System.Collections.Generic;
 
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
            listaProduto.Sort();
        }

        static void ListarProdutos()
        {
            Console.Clear();
            Console.WriteLine("LISTAGEM DE PRODUTOS");
            foreach (Produto produto in listaProduto)
            {
                Console.WriteLine(produto.ToString());
            }
        }

        static void CadastrarProduto()
        {
            Console.Clear();
            Console.WriteLine("Digite os dados do Produto");
            Console.Write("Código: ");
            int codigo = int.Parse(Console.ReadLine());
            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();
            Console.Write("Preço: ");
            double preco = double.Parse(Console.ReadLine());
            listaProduto.Add(new Produto(codigo, descricao, preco));
            listaProduto.Sort();
        }

        static Produto LocalizarProduto(int codigo)
        {
            Produto produto = listaProduto.Find(x => x.Codigo == codigo);
            if (produto != null)
            {
                return produto;
            }
            throw new ModelException("Produto não encontrado!");
        }

        static Pedido LocalizarPedido(int codigo)
        {
            Pedido pedido = listaPedidos.Find(x => x.Codigo == codigo);
            if (pedido != null)
            {
                return pedido;
            }
            throw new ModelException("Pedido não encontrado!");
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
                Produto produto = LocalizarProduto(codigoProduto);
                Console.Write("Quantidade: ");
                int quantidade = int.Parse(Console.ReadLine());
                Console.Write("Porcentagem de desconto: ");
                double porcentagemDesconto = double.Parse(Console.ReadLine());
                listaItemPedidos.Add(new ItemPedido(quantidade, porcentagemDesconto, produto));
            }
            listaPedidos.Add(new Pedido(codigo, data, listaItemPedidos));
        }

        static void MostrarPedido()
        {
            Console.Clear();
            Console.Write("Digite o Código do pedido: ");
            int codigo = int.Parse(Console.ReadLine());
            Pedido pedido = LocalizarPedido(codigo);
            string saida = string.Format("\nPedido {0}, data: {1}\nItens:\n", pedido.Codigo, pedido.Data);

            foreach (ItemPedido item in pedido.Pedidos)
            {
                saida += "\t" + item.ToString();
            }
            saida += string.Format("Total do pedido: {0:C}", pedido.ValorTotal());
            Console.WriteLine(saida);
        }
    }
}
