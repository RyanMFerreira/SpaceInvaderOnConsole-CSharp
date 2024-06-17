namespace DialoguesNamespace
{
    internal class Dialogues
    {
        static void DisplayTextWithDelay(string Text, int DelayTime)
        {
            for (int i = 0; i < Text.Length; i++)
            {
                Console.Write(Text[i]);
                Thread.Sleep(DelayTime);
            }
        }
        public static void CallDialogueScene()
        {
            string D_Year = "\n Ano: 2387";
            string D_Location = "\n\n Localização: Sistema Solar";

            string D_Introduction = "\n\n Uma frota alienígena avança impiedosamente\n" +
                                    " em direção à Terra. Como piloto da última nave\n" +
                                    " de defesa, sua missão é deter esta invasão e \n" +
                                    " proteger nosso planeta a todo custo.";

            string Start = "\n\n [ Pressione Enter para continuar. ]";

            int DelayTime = 70;

            Console.Clear();

            DisplayTextWithDelay(D_Year, DelayTime);
            DisplayTextWithDelay(D_Location, DelayTime);
            DisplayTextWithDelay(D_Introduction, DelayTime);
            DisplayTextWithDelay(Start, DelayTime);

            while (true)
            {
                if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    Menu.GameGuide();
                    break;
                }
            }
        }
    }
}