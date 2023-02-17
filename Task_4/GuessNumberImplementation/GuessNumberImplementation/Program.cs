namespace GuessNumberImplementation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var play = new GameHost(Console.ReadLine, Console.WriteLine);
                play.AskToPlay();
                play.AskTries();
                play.AskNumber();
            }
        }
    }
}