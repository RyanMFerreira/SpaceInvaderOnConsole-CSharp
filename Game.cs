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

            double TotalLives = 100;
            double RemainingLives = TotalLives;
            string HPBar = "";
            int HPBarLength = 20;

            int MaxEnemies = 10;
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

                double LifePercentage = (TotalLives - (RemainingLives)) / (TotalLives / HPBarLength);
                int LifePercentInt = (int)LifePercentage;

                if (RemainingLives > 0)
                {
                    HPBar = "[" + new String('=', HPBarLength - LifePercentInt) + new String(' ', LifePercentInt) + "]";
                }

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo KeyPressed = Console.ReadKey(true);

                    if (KeyPressed.Key == ConsoleKey.UpArrow && ShipPosition_Y > 1)
                    {
                        ShipPosition_Y--;
                    }
                    else if (KeyPressed.Key == ConsoleKey.DownArrow && ShipPosition_Y < (MapHeight - 1))
                    {
                        ShipPosition_Y++;
                    }
                    else if (KeyPressed.Key == ConsoleKey.LeftArrow && ShipPosition_X > 1)
                    {
                        ShipPosition_X--;
                    }
                    else if (KeyPressed.Key == ConsoleKey.RightArrow && ShipPosition_X < (MapWeight - 2))
                    {
                        ShipPosition_X++;
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
                        enemies.Remove(enemies[i]);
                        RemainingLives -= 25;
                    }
                }

                EnemyMoveCounter++;
                if (EnemyMoveCounter >= EnemyMoveLimit)
                {
                    for (int i = 0; i < enemies.Count; i++)
                    {
                        enemies[i].MoveForward();
                    }

                    EnemyMoveCounter = 0;
                }

                for (int P_Count = 0; P_Count < projectiles.Count; P_Count++)
                {
                    projectiles[P_Count].UpdatePosition();

                    for (int E_Count = 0; E_Count < enemies.Count; E_Count++)
                    {
                        if (projectiles[P_Count].X == enemies[E_Count].X && projectiles[P_Count].Y == enemies[E_Count].Y)
                        {
                            projectiles.RemoveAt(P_Count);
                            enemies.RemoveAt(E_Count);

                            Score += 1;

                            break;
                        }
                    }

                    if (P_Count < projectiles.Count && projectiles[P_Count].Y < 0)
                    {
                        projectiles.RemoveAt(P_Count);
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
                        else
                        {
                            bool Projectile_View = false;
                            bool Enemy_View = false;

                            for (int i = 0; i < enemies.Count; i++)
                            {
                                if (enemies[i].X == Cord_X && enemies[i].Y == Cord_Y)
                                {
                                    Enemy_View = true;
                                    break;
                                }
                            }
                            for (int i = 0; i < projectiles.Count; i++)
                            {
                                if (projectiles[i].X == Cord_X && projectiles[i].Y == Cord_Y)
                                {
                                    Projectile_View = true;
                                    break;
                                }
                            }

                            if (Enemy_View)
                            {
                                SceneRendering += "X";
                            }
                            else if (Projectile_View)
                            {
                                SceneRendering += "|";
                            }
                            else
                            {
                                SceneRendering += " ";
                            }
                        }
                    }

                    SceneRendering += "\n";
                }

                Console.WriteLine($"< Pontuação: {Score.ToString("00000")}. Inimigos que escaparam: {EscapedEnemies.ToString("00")} >\n" +
                                  $"< Vida atual: {HPBar} | {RemainingLives.ToString("000")}/{TotalLives} >\n");

                Console.WriteLine(SceneRendering);

                Console.WriteLine($"Debug Menu:\n" +
                    $"Pos_X = {ShipPosition_X}. Pos_Y = {ShipPosition_Y}. H = {MapHeight}. W = {MapWeight}\n" +
                    $"Qnt Projéteis: {projectiles.Count}. Qnt Inimigos: {enemies.Count}. ");

                if (RemainingLives <= 0 || EscapedEnemies >= 10)
                {
                    GameOver = true;
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