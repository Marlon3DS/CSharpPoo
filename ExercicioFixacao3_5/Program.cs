using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioFixacao3_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cursoA = lerAlunos('A');
            int[] cursoB = lerAlunos('B');
            int[] cursoC = lerAlunos('C');
            Array[] cursos = { cursoA, cursoB, cursoC};
            HashSet<int> listaHash = new HashSet<int>();
            for (int i = 0; i < 3; i++)
            {
                foreach (int id in cursos[i])
                {
                    listaHash.Add(id);
                }
            }
            Console.WriteLine("Total de alunos: {0}", listaHash.Count);
            Console.ReadKey();
        }

        static int[] lerAlunos(char curso)
        {
            int qtdAlunos = 0;
            Console.Write("Quantos alunos possui o curso {0}? ", curso);
            qtdAlunos = int.Parse(Console.ReadLine());
            int[] idAlunos = new int[qtdAlunos];
            Console.WriteLine("Digite os códigos dos alunos do curso {0}:", curso);
            for (int i = 0; i < qtdAlunos; i++)
            {
                idAlunos[i] = int.Parse(Console.ReadLine());
            }
            return idAlunos;
        }
    }
}
