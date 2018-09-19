using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioFixacao3_4
{
    class Funcionario
    {
        public int CPF { get; private set; }
        public string Nome { get; private set; }
        public double Salario { get; private set; }

        public Funcionario(int cpf, string nome, double salario)
        {
            CPF = cpf;
            Nome = nome;
            Salario = salario;
        }

        public static void AumentarSalario(Funcionario funcionario, float porcentagemAumento)
        {
            funcionario.Salario += funcionario.Salario * (porcentagemAumento / 100);
        }

        public static Funcionario ValidarCpf(Funcionarios funcionarios, int cpf)
        {
            foreach (Funcionario funcionario in funcionarios)
            {
                if (funcionario.CPF == cpf)
                {
                    return funcionario;
                }
            }
            return null;
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}, {2:C}\n", CPF, Nome, Salario);
        }
    }

    class Funcionarios : List<Funcionario>
    {
        public static void Adicionar(Funcionarios funcionarios, Funcionario funcionario)
        {
            if (Funcionario.ValidarCpf(funcionarios, funcionario.CPF) == null)
            {
                funcionarios.Add(funcionario);
            }
            else
            {
                throw new Exception("CPF Duplicado!");
            }
        }
        public static Funcionario Localiza(Funcionarios funcionarios, int cpf)
        {
            foreach (Funcionario funcionario in funcionarios)
            {

            }
            return Funcionario.ValidarCpf(funcionarios, cpf);
        }
    }
}
