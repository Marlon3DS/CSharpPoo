using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioFixacao3_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Funcionarios funcionarios = LerFuncionarios();
            RealizarAumento(funcionarios);
            string saida = "\nListagem atualizada de funcionários:\n";
            foreach (Funcionario funcionario in funcionarios)
            {
                saida += funcionario.ToString();
            }
            Console.Write(saida);
            Console.ReadKey();
                
        }

        static Funcionarios LerFuncionarios()
        {
            Funcionarios funcionarios = new Funcionarios();
            int cpf;
            string nome;
            double salario;

            Console.Write("Quantos funcionários serão cadastrados? ");
            int i = 1,
                N = int.Parse(Console.ReadLine());
            while (N > 0)
            {
                Console.WriteLine("\nDados do {0}° funcionário: ", i);

                Console.Write("CPF: ");
                cpf = int.Parse(Console.ReadLine());
                Console.Write("Nome: ");
                nome = Console.ReadLine();
                Console.Write("Salario: ");
                salario = double.Parse(Console.ReadLine());

                try
                {
                    Funcionario funcionario = new Funcionario(cpf, nome, salario);
                    Funcionarios.Adicionar(funcionarios, funcionario);
                    N--;
                    i++;
                }
                catch (Exception ex)
                { Console.WriteLine(ex.Message); }
            }

            return funcionarios;
        }

        static void RealizarAumento(Funcionarios funcionarios)
        {
            do
            {
                Console.Clear();
                Console.Write("Digite o CPF do funcionário que terá aumento: ");
                int cpf = int.Parse(Console.ReadLine());
                Funcionario funcionario = Funcionario.ValidarCpf(funcionarios, cpf);
                if (funcionario != null)
                {
                    Console.Write("Digite a porcentagem de aumento: ");
                    float porcentagemAumento = float.Parse(Console.ReadLine()); ;
                    Funcionario.AumentarSalario(funcionario, porcentagemAumento);
                    break;
                }
                else
                {
                    Console.Write("CPF INEXISTENTE");
                    Console.ReadKey();
                }
            } while (true);
        }
    }
}
