using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> ListContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            
            while(opcaoUsuario != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario(); 
            }
            
            Console.WriteLine("Obrigado por utilizar nossos serviços!");
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir uma nova conta");
       
            Console.WriteLine("Digite 1 para Pessoa Fisica e 2 para Pessoa Juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o crédito disponível: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(
                (TipoConta) entradaTipoConta,
                entradaSaldo,
                entradaCredito,
                entradaNome
                );
            ListContas.Add(novaConta);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar Contas");

            if(ListContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }

            for(int i = 0; i < ListContas.Count; i++)
            {
                Conta conta = ListContas[i];
                Console.Write($"{i} - ");
                Console.WriteLine(conta);
            }
        }

        public static void Transferir()
        {
            int indiceContaSacar = -1;
            while (indiceContaSacar >= ListContas.Count && indiceContaSacar == -1)
            {
                Console.Write("Digite o numero da sua conta: ");
                indiceContaSacar = int.Parse(Console.ReadLine());
            }

            int indiceContaDeposito = -1;
            while (indiceContaDeposito >= ListContas.Count && indiceContaDeposito == -1 && (indiceContaDeposito != indiceContaSacar))
            {
                Console.Write("Digite o numero da conta a Transferir o valor: ");
                indiceContaDeposito = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Informe o valor que deseja Transferir: ");
            double entradaTransferir = double.Parse(Console.ReadLine());

            ListContas[indiceContaSacar].Transferir(entradaTransferir, ListContas[indiceContaDeposito]);
        }

        private static void Sacar()
        {
            int indiceConta = -1;
            while (indiceConta >= ListContas.Count && indiceConta == -1)
            {
                Console.Write("Digite o numero da conta: ");
                indiceConta = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Informe o valor que deseja sacar: ");
            double entradaSacar = double.Parse(Console.ReadLine());

            ListContas[indiceConta].Sacar(entradaSacar);
        }

        private static void Depositar()
        {
            int indiceConta = -1;
            while (indiceConta >= ListContas.Count && indiceConta == -1)
            {
                Console.Write("Digite o numero da conta: ");
                indiceConta = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Informe o valor que deseja depositar: ");
            double entradaDeposito = double.Parse(Console.ReadLine());

            ListContas[indiceConta].Depositar(entradaDeposito);
        }
    }
}
