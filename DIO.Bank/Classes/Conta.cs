using System;
using System.Globalization;

namespace DIO.Bank
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public Conta (TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            //Validação de saldo suficiente
            if (this.Saldo - valorSaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo Insuficiente!");
                return false;
            }
            this.Saldo = this.Saldo - valorSaque;

            Console.WriteLine($"Saldo atual da conta de {this.Nome} é {this.Saldo.ToString("F2",CultureInfo.InvariantCulture)}");

            return true;
        }

        public void Depositar (double valorDeposito)
        {
            this.Saldo = this.Saldo + valorDeposito;

            Console.WriteLine($"Saldo atual da conta de {this.Nome} é {this.Saldo.ToString("F2",CultureInfo.InvariantCulture)}");
        }
        
        public void Tranferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }
        public override string ToString()
        {
            //Fiz em um formado diferente de concatenação e adicionei casas decimais e o uso do ponto no lugar da vírgula.
            return $"Tipo conta: {this.TipoConta} \n" +
                   $"Nome: {this.Nome} \n" +
                   $"Saldo: {this.Saldo.ToString("F2", CultureInfo.InvariantCulture)} \n" +
                   $"Credito: {this.Credito.ToString("F2", CultureInfo.InvariantCulture)} \n";
        }
    }
}
