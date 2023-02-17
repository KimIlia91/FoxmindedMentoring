namespace CalculatorImplementation
{
    internal class CalculatorDisplay : Calculator
    {
        private readonly Func<string> _inputProvider;
        private readonly Action<string> _outputProvider;
        private string _seachPath;

        public CalculatorDisplay(Func<string> inputProvider, Action<string> outputProvider)
        {
            _inputProvider = inputProvider;
            _outputProvider = outputProvider;
        }

        public void AskSourceForCalculate()
        {
            string userInput;
            do
            {
                _outputProvider("Choose a source for the calculator:\n\"c\" - from console;\n\"f\" - from file;\n\"e\" - to exit.");
                userInput = _inputProvider() ?? string.Empty;
                Console.Clear();
                if (userInput == "c")
                {
                    GetConsoleCalculation();
                    continue;
                }
                if (userInput == "f")
                {
                    SetFilePath();
                    continue;
                }
                if (userInput != "e")
                    _outputProvider("Sorry! I don't uderstand you.");
            }
            while (userInput != "e");
            _outputProvider("Have a nice day!");
        }

        private void GetConsoleCalculation()
        {
            _outputProvider("Enter expression: ");
            var userExpression = _inputProvider() ?? string.Empty;
            try
            {
                _outputProvider($"{userExpression} = {Calculate(userExpression)}");
            }
            catch (Exception ex)
            {
                _outputProvider(ex.Message);
            }
        }

        private void SetFilePath()
        {
            _outputProvider("Specify file location: ");
            var userInputPath = _inputProvider() ?? string.Empty;
            if (!File.Exists(userInputPath))
            {
                _outputProvider($"The file does not exist at the specified path: {userInputPath}");
                return;
            }
            _seachPath = userInputPath;
            GetFileCalculation();
        }

        private void GetFileCalculation()
        {
            var linesCalculate = File.ReadAllLines(_seachPath);
            var resultFile = new List<string>();
            foreach (var line in linesCalculate)
            {
                try
                {
                    resultFile.Add($"{line} = {Calculate(line)}");
                }
                catch (Exception ex)
                {
                    resultFile.Add($"{line} = {ex.Message}");
                }
            }
            File.WriteAllLines(@"C:\Users\User\Documents\FoxmindedWorks\Task_5\CalculatorImplementation\CalculatorImplementation\resultExpression.txt", resultFile);
            _outputProvider("Calculation done!");
        }
    }
}
