using System;

namespace Calculator
{
    public enum Operacao
    {
        Soma = 1,
        Subtracao,
        Multiplicacao,
        Divisao,
        Sair
    }

    class Program
    {
        static void Main(string[] args)
        {
            Operacao escolha;

            do
            {
                escolha = Menu();
                MenuEscolha(escolha);

            } while (escolha != Operacao.Sair);
        }

        static Operacao Menu()
        {
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("1 - Soma");
            Console.WriteLine("2 - Subtração");
            Console.WriteLine("3 - Multiplicação");
            Console.WriteLine("4 - Divisão");
            Console.WriteLine("5 - Sair");

            if (Enum.TryParse(Console.ReadLine(), out Operacao escolha) && Enum.IsDefined(typeof(Operacao), escolha))
            {
                return escolha;
            }
            else
            {
                Console.WriteLine("Opção inválida");
                return Menu();
            }
        }

        static void MenuEscolha(Operacao escolha)
        {
            switch (escolha)
            {
                case Operacao.Soma:
                    RealizarOperacao("Soma", (a, b) => a + b);
                    break;
                case Operacao.Subtracao:
                    RealizarOperacao("Subtração", (a, b) => a - b);
                    break;
                case Operacao.Multiplicacao:
                    RealizarOperacao("Multiplicação", (a, b) => a * b);
                    break;
                case Operacao.Divisao:
                    RealizarOperacao("Divisão", (a, b) => a / b);
                    break;
                case Operacao.Sair :
                    Console.WriteLine("Saindo...");
                    break;
            }
        }

        static void RealizarOperacao(string nomeOperacao, Func<double, double, double> operacao)
        {
            Console.WriteLine($"Você escolheu {nomeOperacao}");
            double a = ObterNumero("Digite o primeiro número: ");
            double b = ObterNumero("Digite o segundo número: ");

            try
            {
                double resultado = operacao(a, b);
                Console.WriteLine($"O resultado é {resultado}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao realizar a operação: {ex.Message}");
            }
        }

        static double ObterNumero(string mensagem)
        {
            double numero;
            Console.WriteLine(mensagem);

            while (!double.TryParse(Console.ReadLine(), out numero))
            {
                Console.WriteLine("Número inválido. Tente novamente.");
            }

            return numero;
        }
    }
}
