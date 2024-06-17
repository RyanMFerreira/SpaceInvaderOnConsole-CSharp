using EnemyNamespace;
using ProjectileNamespace;

namespace GameRendering
{
    internal class Game
    {
        public static void Start()
        {
            int MapWeight = 48;
            int MapHeight = 26;

            int ShipPosition_X = MapWeight / 2;
            int ShipPosition_Y = MapHeight - 2;

            int Score = 0;

            int RemainingAttempts = 5;
            double TotalLives = 100;
            double RemainingLives = TotalLives;
            string HPBar = "";

            int MaxEnemies = 6;
            int EnemyMoveCounter = 0;
            int EnemyMoveLimit = 20;
            int EscapedEnemies = 0;

            bool GameOver = false;
            bool Win = false;

            Random RandomPosition = new Random();

            List<Projectile> projectiles = new List<Projectile>();
            List<Enemy> enemies = new List<Enemy>();

            while (true)
            {
                Thread.Sleep(25);

                double LifePercentage = (TotalLives - (RemainingLives)) / (TotalLives / 20);
                int LifePercentInt = (int)LifePercentage;

                if (RemainingLives > 0)
                {
                    HPBar = "[" + new String('=', 20 - LifePercentInt) + new String(' ', LifePercentInt) + "]";
                }

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo KeyPressed = Console.ReadKey(true);

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
                }

                static void SpawnEnemy(Random RandomPosition, int MapHeight, int MapWeight, List<Enemy> enemies)
                {
                    int startX = RandomPosition.Next(1, MapWeight - 2);
                    int startY = RandomPosition.Next(-MapHeight, 1);

                    enemies.Add(new Enemy(startX, startY));
                }

                if (enemies.Count < MaxEnemies)
                {
                    SpawnEnemy(RandomPosition, MapHeight, MapWeight, enemies);
                }

                for (int i = 0; i < enemies.Count; i++)
                {
                    if (enemies[i].Y > MapHeight)
                    {
                        enemies.RemoveAt(i);
                        EscapedEnemies++;
                    }
                    else if (enemies[i].X == ShipPosition_X && enemies[i].Y == ShipPosition_Y)
                    {
                        RemainingLives -= 2.5;
                    }
                }

                EnemyMoveCounter++;
                if (EnemyMoveCounter >= EnemyMoveLimit)
                {
                    foreach (Enemy enemy in enemies)
                    {
                        enemy.MoveForward();
                    }

                    EnemyMoveCounter = 0;
                }

                for (int p = 0; p < projectiles.Count; p++)
                {
                    projectiles[p].UpdatePosition();

                    for (int e = 0; e < enemies.Count; e++)
                    {
                        if (projectiles[p].X == enemies[e].X && projectiles[p].Y == enemies[e].Y)
                        {
                            projectiles.RemoveAt(p);
                            enemies.RemoveAt(e);

                            Score += 1;

                            break;
                        }
                    }

                    if (p < projectiles.Count && projectiles[p].Y < 0)
                    {
                        projectiles.RemoveAt(p);
                    }
                }

                Console.Clear();

                string SceneRendering = "";

                for (int Cord_Y = 0; Cord_Y <= MapHeight; Cord_Y++)
                {
                    for (int Cord_X = 0; Cord_X < MapWeight; Cord_X++)
                    {
                        if (Cord_X == 0 || Cord_X == MapWeight - 1)
                        {
                            SceneRendering += "|";
                        }
                        else if (Cord_Y == 0 || Cord_Y == MapHeight)
                        {
                            SceneRendering += "-";
                        }
                        else if (ShipPosition_X == Cord_X && ShipPosition_Y == Cord_Y)
                        {
                            SceneRendering += "W";
                        }
                        else if (projectiles.Exists(ProjectilePosition => ProjectilePosition.X == Cord_X && ProjectilePosition.Y == Cord_Y))
                        {
                            SceneRendering += "|";
                        }
                        else if (enemies.Exists(EnemyPosition => EnemyPosition.X == Cord_X && EnemyPosition.Y == Cord_Y))
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

                Console.WriteLine(SceneRendering + $"\nInimigos que escaparam: {EscapedEnemies}");

                Console.WriteLine($"\nDebug:\n" +
                    $"Pos_X = {ShipPosition_X}. Pos_Y = {ShipPosition_Y}. H = {MapHeight}. W = {MapWeight}\n" +
                    $"Qnt Projéteis: {projectiles.Count}. Qnt Inimigos: {enemies.Count}");

                if (RemainingLives <= 0 || EscapedEnemies >= 10)
                {
                    RemainingAttempts--;

                    if (RemainingAttempts <= 0)
                    {
                        GameOver = true;
                    }
                }

                if (Win || GameOver)
                {
                    Menu.CheckMenu(GameOver, Win, EscapedEnemies);
                    break;
                }
            }
        }
    }
}