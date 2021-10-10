using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.Bank
{
    class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public Conta(TipoConta tipoConta, double Saldo, double Credito, string Nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = Saldo;
            this.Credito = Credito;
            this.Nome = Nome;
        }

        public bool Sacar(double valorSaque)
        {
            if(this.Saldo - valorSaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo Insuficiente!");
                return false;
            }
            this.Saldo -= valorSaque;
            Console.WriteLine($"Saldo atual da conta é {this.Saldo}");
            return true;
        }

        public bool Depositar(double valorDeposito)
        {
            if(valorDeposito > 0)
            {
                this.Saldo += valorDeposito;
                Console.WriteLine($"Seu saldo atual é {this.Saldo}");
                return true;
            }
            Console.WriteLine("Valor informado é invalido!");
            return false;
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if(this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta: " + this.TipoConta + " | ";
            retorno += "Nome: " + this.Nome + " | ";
            retorno += "Saldo: " + this.Saldo + " | ";
            if (this.Saldo < 0)
                retorno += "Credito: " + (this.Credito + this.Saldo);
            else
                retorno += "Credito: " + this.Credito;

            return retorno;
        }
    }
}
