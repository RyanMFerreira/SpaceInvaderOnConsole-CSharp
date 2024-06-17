using GameRendering;

namespace DialoguesNamespace
{
    internal class Dialogues
    {
        public static void CallDialogueScene()
        {
            string D_Year = "\n Ano: 2387";
            string D_Location = "\n\n Localização: Sistema Solar";

            string D_Introduction = "\n\n Uma frota alienígena avança impiedosamente\n" +
                                    " em direção à Terra. Como piloto da última nave\n" +
                                    " de defesa, sua missão é deter esta invasão e \n" +
                                    " proteger nosso planeta a todo custo.";

            string Start = "\n\n [ Pressione Enter para continuar. ]";

            Console.Clear();

            for (int i = 0; i < D_Year.Length; i++)
            {
                Console.Write(D_Year[i]);
                Thread.Sleep(60);
            }

            for (int i = 0; i < D_Location.Length; i++)
            {
                Console.Write(D_Location[i]);
                Thread.Sleep(60);
            }

            for (int i = 0; i < D_Introduction.Length; i++)
            {
                Console.Write(D_Introduction[i]);
                Thread.Sleep(60);
            }

            for (int i = 0; i < Start.Length; i++)
            {
                Console.Write(Start[i]);
                Thread.Sleep(60);
            }

            while (true)
            {
                ConsoleKeyInfo KeyPressed = Console.ReadKey(true);
                if (KeyPressed.Key == ConsoleKey.Enter)
                {
                    Menu.GameGuide();
                    break;
                }
            }
        }
    }
}