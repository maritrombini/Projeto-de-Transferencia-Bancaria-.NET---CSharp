using System;
using System.Collections.Generic;
using Bank.Classes;


namespace Bank
{
    class Program
    {



        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
          string opcaoUsuario = ObterOpcaoUsuario();

        

          while (opcaoUsuario.ToUpper() != "X")
          {
              switch (opcaoUsuario)
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
                  case "6":
                    Divida();
                    break;
                  case "C":
                    Console.Clear();
                    break;
                  
                  default:
                    throw new ArgumentOutOfRangeException();
              }

              opcaoUsuario = ObterOpcaoUsuario();
          }
        
        Console.WriteLine("Obrigada por utilizar nossos serviços. ");
        Console.ReadLine();

        }

        private static void Transferir()
        {
          Console.Write("Digite o número da conta de origem: ");
          int indiceContaOrigem = int.Parse(Console.ReadLine());

          Console.Write("Digite o número da conta de destino: ");
          int indiceContaDestino = int.Parse(Console.ReadLine());

          Console.Write("Digite o valor a ser transferido: ");
          double valorTransferencia = double.Parse(Console.ReadLine());

          listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
        }

        private static void Sacar()
        {
          Console.Write("Digite o número da conta: ");
          int indiceConta = int.Parse(Console.ReadLine());

          Console.Write("Digite o valor a ser sacado: ");
          double valorSaque = double.Parse(Console.ReadLine());

          listContas[indiceConta].Sacar(valorSaque);
        }


        private static void Depositar()
        {
          Console.Write("Digite o número da conta: ");
          int indiceConta = int.Parse(Console.ReadLine());

          Console.Write("Digite o valor a ser depositado: ");
          double valorDeposito = double.Parse(Console.ReadLine());

          listContas[indiceConta].Depositar(valorDeposito);
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta ");

            Console.Write("Digite 1 para Conta Física ou 2 para Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta, Saldo: entradaSaldo,
                            Credito: entradaCredito,
                            Nome: entradaNome);                   

            listContas.Add(novaConta);
        }

            private static void ListarContas()
            {
                Console.WriteLine("Listar contas");

                if (listContas.Count == 0)
                {
                  Console.WriteLine("Nenhuma conta cadastrada.");
                  return;
                }
            
                for (int i=0; i < listContas.Count; i++)
                {
                  Conta conta = listContas[i];
                  Console.Write("#{0} - ", i);
                  Console.WriteLine(conta);
                }
            
            }


            private static void Divida()
            {
            

            Console.Write("Digite o valor da dívida: ");
            int entradaDivida = int.Parse(Console.ReadLine());

            Console.Write("Digite o prazo em meses para quitação desejado: ");
            int entradaPrazo = int.Parse (Console.ReadLine());

            // Console.Write("Digite a taxa que será aplicada: ");
            // double entradaTaxa = double.Parse (Console.ReadLine());

            double principal = entradaDivida;

            double taxa = 0.10;//entradaTaxa/100;
            int meses = entradaPrazo;
   
            double juros = (entradaDivida * taxa*meses);
            double montante = principal * (1 + (taxa * meses));  

            
 
            Console.WriteLine("O total de juros a ser pago é: " 
            + juros);
            Console.WriteLine("O montante a ser pago é: " + montante );
            
         Console.ReadLine();
        }

        private static string ObterOpcaoUsuario()
    {
        Console.WriteLine();
        Console.WriteLine("Bank a seu dispor!");
        Console.WriteLine("Informe a opção desejada: ");

        Console.WriteLine("1- Listar Contas");
        Console.WriteLine("2- Inserir Nova Conta");
        Console.WriteLine("3- Transferir");
        Console.WriteLine("4- Sacar");
        Console.WriteLine("5- Depositar");
        Console.WriteLine("6- Dívida"); 
        Console.WriteLine("C- Limpar Tela");
        Console.WriteLine("X- Sair");
        Console.WriteLine();

        string opcaoUsuario = Console.ReadLine().ToUpper();
        Console.WriteLine();
        return opcaoUsuario;
    }
    
        
    }
}   
   
    

