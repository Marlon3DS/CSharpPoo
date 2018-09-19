
using System.Globalization;

namespace ExercicioFixacao3_1
{
    class Conta
    {
        public int Numero { get; private set; }
        public string Nome { get; set; }
        public double Saldo { get; private set; }
        public Conta(int _numero, string _nome, double _valorInicial)
        {
            Numero = _numero;
            Nome = _nome;
            Saldo = _valorInicial;
        }
        public Conta(int _numero, string _nome)
        {
            Numero = _numero;
            Nome = _nome;
            Saldo = 0;
        }
        public void Deposito(double valor)
        {
            Saldo += valor;
        }
        public void Saque(double valor)
        {
            Saldo -= (valor + 5);
        }
        public string ToString(Estado estado)
        {
            return string.Format(CultureInfo.GetCultureInfo("pt-BR"), "Conta {0}\nConta {1}, Titular: {2}, Saldo: {3:C}", estado, Numero, Nome, Saldo);
        }
        public enum Estado
        {
            criada,
            atualizada
        }
    }
}
