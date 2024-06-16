namespace SpaceInvaderOnConsole_CSharp
{
    internal class Game
    {
        public static void Start()
        {
            int MapWeight = 49;
            int MapHeight = 25;

            int ShipPosition_X;
            int ShipPosition_Y;
            ShipPosition_X = MapWeight / 2;
            ShipPosition_Y = MapHeight - 2;

            int Score = 0;
            int RemainingAttempts = 0;

            int TotalLives = 5;
            int RemainingLives = TotalLives;

            string HPBar = "";

            bool GameOver = false;
            bool Win = false;

            while (true)
            {
                if (RemainingLives > 0)
                {
                    HPBar = "[" + new String('=', RemainingLives * 4) + new String(' ', (TotalLives - RemainingLives) * 4) + "]";
                }
                else
                {
                    HPBar = "[ Game Over ]";
                }

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo KeyPressed = Console.ReadKey();

                    if (KeyPressed.Key == ConsoleKey.UpArrow && ShipPosition_Y > 1)
                    {
                        ShipPosition_Y -= 1;
                    }
                    else if (KeyPressed.Key == ConsoleKey.DownArrow && ShipPosition_Y < (MapHeight - 1))
                    {
                        ShipPosition_Y += 1;
                    }
                    else if (KeyPressed.Key == ConsoleKey.LeftArrow && ShipPosition_X > 1)
                    {
                        ShipPosition_X -= 1;
                    }
                    else if (KeyPressed.Key == ConsoleKey.RightArrow && ShipPosition_X < (MapWeight - 2))
                    {
                        ShipPosition_X += 1;
                    }
                    else if (KeyPressed.Key == ConsoleKey.Spacebar)
                    {

                    }
                    else if (KeyPressed.Key == ConsoleKey.P)
                    {
                        RemainingLives -= 1;
                    }
                }

                Console.Clear();

                string SceneRendering = "";

                for (int Y = 0; Y <= MapHeight; Y++)
                {
                    for (int X = 0; X < MapWeight; X++)
                    {
                        if (X == 0 || X == MapWeight - 1)
                        {
                            SceneRendering += "|";
                        }
                        else if (Y == 0 || Y == MapHeight)
                        {
                            SceneRendering += "=";
                        }
                        else if (ShipPosition_X == X && ShipPosition_Y == Y)
                        {
                            SceneRendering += "W";
                        }
                        else
                        {
                            SceneRendering += " ";
                        }
                    }

                    SceneRendering += "\n";
                }

                Console.WriteLine($"< Pontuação: {Score.ToString("0000")} | Tentativas restantes: {RemainingAttempts.ToString("0000")} >\n" +
                    $"< Vida atual: {HPBar} | {RemainingLives.ToString("000")}/{TotalLives.ToString("000")} >\n");

                Console.WriteLine(SceneRendering);

                Console.WriteLine($"Debug:\nPos_X = {ShipPosition_X}. Pos_Y = {ShipPosition_Y}. H = {MapHeight}. W = {MapWeight}\n" +
                    $"Game Over: {GameOver}");

                if (RemainingLives <= 0)
                {
                    GameOver = true;

                    if (GameOver)
                    {
                        Menu.CheckMenu(GameOver, Win);
                        break;
                    }
                }
                else if (Score == 15)
                {
                    Menu.CheckMenu(GameOver, Win);
                    break;
                }

                Thread.Sleep(50);
            }
        }
    }
}