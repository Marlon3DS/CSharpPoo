using System;

namespace ExercicioFixacao3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Conta conta = CriarConta();
            double valor;
            ExibirConta(conta, Conta.Estado.criada);
            Console.Write("Digite um valor para depósito: ");
            valor = double.Parse(Console.ReadLine());
            conta.Deposito(valor);
            ExibirConta(conta, Conta.Estado.atualizada);
            Console.Write("Digite um valor para saque: ");
            conta.Saque (double.Parse(Console.ReadLine()));
            ExibirConta(conta, Conta.Estado.atualizada);
        }

        static Conta CriarConta()
        {
            Conta conta;
            Console.Write("Digite o número da conta: ");
            int numeroConta = int.Parse(Console.ReadLine());
            Console.Write("Digite o nome do titular da conta: ");
            string nomeConta = Console.ReadLine();
            Console.Write("Haverá depósito inicial(s / n)? ");
            string opcao = Console.ReadLine();
            if (opcao == "s" || opcao == "S")
            {
                Console.Write("Digite o valor do depósito inicial: ");
                double valorInicial = double.Parse(Console.ReadLine());
                conta = new Conta(numeroConta, nomeConta, valorInicial);
            }
            else
            {
                conta = new Conta(numeroConta, nomeConta);
            }
            Console.Clear();
            return conta;
        }
    
        static void ExibirConta(Conta conta, Conta.Estado estado)
        {
            Console.WriteLine(conta.ToString(estado));
            Console.ReadKey();
            Console.Clear();
        }
    }
}
