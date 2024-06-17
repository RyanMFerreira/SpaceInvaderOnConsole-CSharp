namespace SoundsNamespace
{
    internal class Sounds
    {
        public static void MenuMoveSound()
        {
            Console.Beep(800, 50);
        }

        public static void SelectSound()
        {
            Console.Beep(600, 200);
        }

        public static void ShootSound()
        {
            Console.Beep(1200, 30);
        }

        public static void EnemyDeathSound()
        {
            Console.Beep(400, 25);
            Console.Beep(300, 25);
            Console.Beep(200, 25);
        }

        public static void Writing()
        {
            Console.Beep(555, 25);
        }

        public static void EndWriting()
        {
            Console.Beep(1600, 35);
        }
    }
}