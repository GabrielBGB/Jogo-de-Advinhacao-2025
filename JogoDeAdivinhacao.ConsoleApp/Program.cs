using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            MostrarCabecalho("Jogo de Adivinhação");

            int totalDeTentativas = EscolherDificuldade();

            int numeroSecreto = new Random().Next(1, 21);

            Jogar(numeroSecreto, totalDeTentativas);

            Console.Write("Deseja continuar? (S/N): ");
            string opcao = Console.ReadLine().ToUpper();

            if (opcao != "S")
                break;
        }
    }

    #region Métodos Auxiliares

    static void MostrarCabecalho(string titulo)
    {
        Console.Clear();
        Console.WriteLine("----------------------------------------");
        Console.WriteLine(titulo);
        Console.WriteLine("----------------------------------------");
    }

    static void MostrarMensagem(string mensagem)
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine(mensagem);
        Console.WriteLine("----------------------------------------");
    }

    #endregion

    #region Lógica do Jogo

    static void Jogar(int numeroSecreto, int totalDeTentativas)
    {
        for (int tentativa = 1; tentativa <= totalDeTentativas; tentativa++)
        {
            MostrarCabecalho($"Tentativa {tentativa} de {totalDeTentativas}");

            Console.Write("Digite um número entre 1 e 20: ");
            int chute = LerNumero();

            if (chute == numeroSecreto)
            {
                MostrarMensagem("Parabéns! Você acertou!");
                break;
            }

            if (tentativa == totalDeTentativas)
            {
                MostrarMensagem($"Que pena! Você usou todas as tentativas. O número era {numeroSecreto}.");
                break;
            }

            if (chute > numeroSecreto)
                MostrarMensagem("O número digitado é maior que o número secreto.");
            else
                MostrarMensagem("O número digitado é menor que o número secreto.");

            Console.WriteLine("Aperte ENTER para continuar...");
            Console.ReadLine();
        }
    }

    static int LerNumero()
    {
        while (true)
        {
            string entrada = Console.ReadLine();
            if (int.TryParse(entrada, out int numero) && numero >= 1 && numero <= 20)
                return numero;

            Console.Write("Entrada inválida. Digite um número entre 1 e 20: ");
        }
    }

    #endregion

    #region Escolha de Dificuldade

    static int EscolherDificuldade()
    {
        Console.WriteLine("Escolha um nível de dificuldade:");
        Console.WriteLine("1 - Fácil (10 tentativas)");
        Console.WriteLine("2 - Médio (5 tentativas)");
        Console.WriteLine("3 - Difícil (3 tentativas)");
        Console.WriteLine("----------------------------------------");

        Console.Write("Digite sua escolha: ");
        string entrada = Console.ReadLine();

        return entrada switch
        {
            "1" => 10,
            "2" => 5,
            "3" => 3,
            _ => 5 // padrão: médio
        };
    }

    #endregion
}