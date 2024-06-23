using DialoguesNamespace;
using GameRendering;

class Menu
{
    static void Main()
    {
        int SelectedOption = 0;

        while (true)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("" +
                " ======================================\n" +
                " |         < Space Invaders >         |\n" +
                " ======================================\n\n" +
                " Menu:");

            Console.WriteLine(SelectedOption == 0 ? " -> Iniciar" : "    Iniciar");
            Console.WriteLine(SelectedOption == 1 ? " -> Opções " : "    Opções ");
            Console.WriteLine(SelectedOption == 2 ? " -> Fechar " : "    Fechar ");

            Console.WriteLine("\n <   Utilize as setas para navegar.   >\n\n" +
                " @ Ryan Ferreira\n\n v.0.2");

            ConsoleKeyInfo KeyPressed = Console.ReadKey(true);

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
                    Dialogues.CallDialogueScene();
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

            ConsoleKeyInfo KeyPressed = Console.ReadKey(true);

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

    public static void GameGuide()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine(" ======================================\n" +
                " |          < Guia Rápido: >          |\n" +
                " ======================================\n\n" +
                " Controles:\n\n Setas direcionais:\n" +
                "   ^      - Mover para cima\n" +
                " < - >    - Mover para os lados\n" +
                "   v      - Mover para baixo\n\n" +
                " [Espaço] - Disparar\n\n" +
                " Objetivo:\n" +
                "  - Sobreviva o maior tempo possível\n" +
                "    destruindo as naves inimigas.\n\n" +
                "  - Caso 10 inimigos fujam,\n" +
                "    o jogo será encerrado\n\n" +
                " Pressione ENTER para começar.");

            ConsoleKeyInfo KeyPressed = Console.ReadKey(true);
            if (KeyPressed.Key == ConsoleKey.Enter)
            {
                Game.Start();
                break;
            }
        }
    }

    public static void CheckMenu(bool GameOver, bool Win, int EscapedEnemies)
    {
        Console.Clear();

        if (GameOver)
        {
            string GameOverReason;

            if (EscapedEnemies >= 10)
            {
                GameOverReason = "Você deixou 10 inimigos escaparem...";
            }
            else
            {
                GameOverReason = "Suas vidas acabaram...";
            }

            Console.WriteLine($"\n   ======================================\n" +
                              $"   |          < Fim de Jogo >           |\n" +
                              $"   ======================================\n\n" +
                              $"   {GameOverReason}\n\n" +
                              $"   [    ENTER para tentar novamente.    ]\n\n" +
                              $"   [      Q para retornar ao menu.      ]");

            while (true)
            {
                ConsoleKeyInfo PressedKey = Console.ReadKey(true);

                if (PressedKey.Key == ConsoleKey.Enter)
                {
                    Game.Start();
                    break;
                }
                else if (PressedKey.Key == ConsoleKey.Q)
                {
                    Main();
                    break;
                }
            }
        }
        else if (Win)
        {
            Console.WriteLine("   ...\n\n");

            while (true)
            {
                ConsoleKeyInfo PressedKey = Console.ReadKey(true);

                if (PressedKey.Key == ConsoleKey.Enter)
                {
                    Main();
                }
            }
        }
    }
}