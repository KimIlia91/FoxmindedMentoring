namespace CalculatorImplementation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var calculatorDisplay = new CalculatorDisplay(Console.ReadLine,Console.WriteLine);
            calculatorDisplay.AskSourceForCalculate();
        }
    }
}