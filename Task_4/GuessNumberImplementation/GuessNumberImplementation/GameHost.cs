using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GuessNumberImplementation
{
    public class GameHost : GuessNumberGame
    {
        private readonly Func<string> _inputProvider;
        private readonly Action<string> _outputProvider;

        private bool HasTries { get; set; }

        private uint Tries { get; set; }

        public GameHost(Func<string> inputProvider, Action<string> outputProvider)
        {
            _inputProvider = inputProvider;
            _outputProvider = outputProvider;
        }
        
        public void AskToPlay()
        {
            _outputProvider("Do you want to play?\nPress \"y\" to start.\nPress \"n\" to exit.");
            var answerUser = _inputProvider() ?? string.Empty;
            ActionOnRequest(answerUser);
            Console.Clear();
        }

        public void AskTries()
        {
            _outputProvider("Enter number of tries: ");
            var userInput = _inputProvider() ?? string.Empty;
            if (uint.TryParse(userInput, out uint numberTries))
            {
                Tries = numberTries;
                HasTries = true;
                return;
            }
            _outputProvider("Invalid number! Enter an positive integer.");
            AskTries();
        }

        public void AskNumber()
        {
            do
            {
                _outputProvider($"Guess the number from 0 to 100. Number of attempts {Tries}!\nEnter number: ");
                var numberInput = SeachGuessNumber(_inputProvider() ?? string.Empty);
                if (GuessNumberStatus.CorrectNumber == numberInput)
                {
                    _outputProvider("Congratulations! You won.");
                    return;
                }
                if (GuessNumberStatus.NotANumber == numberInput)
                {
                    _outputProvider("Invalid input! Enter an positive integer.");
                    AskNumber();
                }
                if (GuessNumberStatus.NonValidNumber == numberInput)
                {
                    _outputProvider("Invalid number! Enter an integer from 0 to 100.");
                    AskNumber();
                }
                if (GuessNumberStatus.NumberIsGreater == numberInput)
                    _outputProvider("The guess number is greater!");
                if (GuessNumberStatus.NumberIsLess == numberInput)
                    _outputProvider("The guess number is less!");
                CounterTries();
            } while (HasTries);
            _outputProvider($"Sorry! You lose. Number of attempts {Tries - 1}!");
        }

        private void ActionOnRequest(string answerUser)
        {
            if (answerUser == "y")
                return;
            if (answerUser == "n")
                Environment.Exit(0);
            _outputProvider("Sorry! I'don't understand you.");
            AskToPlay();
        }

        private void CounterTries()
        {
            if (Tries == 0)
                return;
            if (Tries > 1)
            {
                Tries--;
                return;
            }
            HasTries = false;
        }
    }
}
 