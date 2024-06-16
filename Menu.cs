using SpaceInvaderOnConsole_CSharp;
class Menu
{
    static void Main()
    {
        int SelectedOption = 0;

        while (true)
        {
            Console.Clear();


            Console.WriteLine("" +
                " ======================================\n" +
                " |   <Trabalho DS - Space Invaders>   |\n" +
                " ======================================\n\n" +
                " Opções:");

            Console.WriteLine(SelectedOption == 0 ? " -> Iniciar" : "    Iniciar");
            Console.WriteLine(SelectedOption == 1 ? " -> Opções " : "    Opções ");
            Console.WriteLine(SelectedOption == 2 ? " -> Fechar " : "    Fechar ");

            Console.WriteLine("\n <   Utilize as setas para navegar.   >\n\n" +
                " @ Ryan, Murilo Andrade, Arthur Martin,\n" +
                " Bruno e Gustavo.");

            ConsoleKeyInfo KeyPressed = Console.ReadKey();

            if (KeyPressed.Key == ConsoleKey.UpArrow && SelectedOption > 0)
            {
                SelectedOption--;
            }
            else if (KeyPressed.Key == ConsoleKey.DownArrow && SelectedOption < 2)
            {
                SelectedOption++;
            }
            else if (KeyPressed.Key == ConsoleKey.Enter)
            {
                if (SelectedOption == 0)
                {
                    GameGuide();
                    break;
                }
                else if (SelectedOption == 1)
                {
                    Options();
                    break;
                }
                else if (SelectedOption == 2)
                {
                    break;
                }
            }
        }
    }

    static void Options()
    {
        int SelectedOption = 0;

        while (true)
        {
            Console.Clear();

            Console.WriteLine("Não finalizado...");

            Console.WriteLine(SelectedOption == 0 ? " -> Voltar" : "    Voltar");
            Console.WriteLine(SelectedOption == 1 ? " -> Null" : "    Null");

            ConsoleKeyInfo KeyPressed = Console.ReadKey();

            if (KeyPressed.Key == ConsoleKey.UpArrow && SelectedOption > 0)
            {
                SelectedOption--;
            }
            else if (KeyPressed.Key == ConsoleKey.DownArrow && SelectedOption < 1)
            {
                SelectedOption++;
            }
            else if (KeyPressed.Key == ConsoleKey.Enter)
            {
                if (SelectedOption == 0)
                {
                    Main();
                    break;
                }
                else if (SelectedOption == 1)
                {
                }
            }
        }
    }

    static void GameGuide()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine(" ======================================\n" +
                " |             <Tutorial>             |\n" +
                " ======================================\n\n" +
                " Controles:\n\n Setas direcionais:\n" +
                "   ^      - Mover para cima\n" +
                " < - >    - Mover para os lados\n" +
                "   v      - Mover para baixo\n\n" +
                " [Espaço] - Disparar\n\n" +
                " Objetivo:\n - Sobreviva o maior tempo possível\n   destruindo as naves inimigas.\n\n" +
                " Pressione ENTER para começar.");

            ConsoleKeyInfo KeyPressed = Console.ReadKey();
            if (KeyPressed.Key == ConsoleKey.Enter)
            {
                Game.Start();
                break;
            }
        }
    }

    public static void CheckMenu(bool GameOver, bool Win)
    {
        Console.Clear();

        if (GameOver)
        {
            Console.WriteLine("\n   Game Over!\n");
            Console.WriteLine("   Pressione Enter para\n   retornar ao menu...");

            ConsoleKeyInfo teclaPressionada = Console.ReadKey();
            if (teclaPressionada.Key == ConsoleKey.Enter)
            {
                Main();
            }
            else
            {
                CheckMenu(GameOver, Win);
            }
        }
        else if (Win)
        {
            Console.WriteLine("   Parabéns, você venceu!\n\n   Pressione Enter para\n   retornar ao menu...");
            ConsoleKeyInfo teclaPressionada = Console.ReadKey();
            if (teclaPressionada.Key == ConsoleKey.Enter)
            {
                Main();
            }
            else
            {
                CheckMenu(GameOver, Win);
            }
        }
    }
}