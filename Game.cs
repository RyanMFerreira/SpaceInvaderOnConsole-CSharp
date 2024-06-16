using EnemyNamespace;
using ProjectileNamespace;

namespace SpaceInvadersOnConsole_CSharp
{
    internal class Game
    {
        public static void Start()
        {
            int MapWeight = 48;
            int MapHeight = 28;

            int ShipPosition_X = MapWeight / 2;
            int ShipPosition_Y = MapHeight - 2;

            int Score = 0;

            int RemainingAttempts = 5;
            double TotalLives = 50;
            double RemainingLives = TotalLives;
            string HPBar = "";

            int EnemyMoveCounter = 0;
            int EnemyMoveLimit = 10;

            bool GameOver = false;
            bool Win = false;

            Random RandomPosition = new Random();

            List<Projectile> projectiles = new List<Projectile>();
            List<Enemy> enemies = new List<Enemy>();

            while (true)
            {
                double LifePercentage = (TotalLives - (RemainingLives)) / (TotalLives / 20);
                int lifePercentInt = (int)LifePercentage;

                if (RemainingLives > 0)
                {
                    HPBar = "[" + new String('=', 20 - lifePercentInt) + new String(' ', lifePercentInt) + "]";
                }
                else
                {
                    HPBar = "[  Game Over!  ]";
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
                        projectiles.Add(new Projectile(ShipPosition_X, ShipPosition_Y));
                    }
                    else if (KeyPressed.Key == ConsoleKey.P)
                    {
                        RemainingLives -= 5;
                    }
                }

                static void SpawnEnemy(Random RandomPosition, int MapHeight, int MapWeight, List<Enemy> enemies)
                {
                    int startX = RandomPosition.Next(1, MapWeight - 2);
                    int startY = RandomPosition.Next(1, MapHeight / 7);

                    enemies.Add(new Enemy(startX, startY));
                }

                if (enemies.Count < 6)
                {
                    SpawnEnemy(RandomPosition, MapHeight, MapWeight, enemies);
                }

                for (int i = enemies.Count - 1; i >= 0; i--)
                {
                    if (enemies[i].Y > MapHeight)
                    {
                        enemies.RemoveAt(i);
                    }
                }

                EnemyMoveCounter++;
                if (EnemyMoveCounter >= EnemyMoveLimit)
                {
                    foreach (var enemy in enemies)
                    {
                        enemy.MoveForward();
                    }
                    EnemyMoveCounter = 0;
                }

                for (int i = projectiles.Count - 1; i >= 0; i--)
                {
                    projectiles[i].UpdatePosition();
                    if (projectiles[i].Y < 0)
                    {
                        projectiles.RemoveAt(i);
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
                        else if (projectiles.Exists(p => p.X == X && p.Y == Y))
                        {
                            SceneRendering += "|";
                        }
                        else if (enemies.Exists(e => e.X == X && e.Y == Y))
                        {
                            SceneRendering += "X";
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
                    $"Game Over: {GameOver}\n" +
                    $"Quantidade de projéteis: {projectiles.Count}. Quantidade de inimigos: {enemies.Count}");

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