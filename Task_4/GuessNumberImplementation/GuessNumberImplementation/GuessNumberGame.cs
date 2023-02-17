using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumberImplementation
{
    public class GuessNumberGame
    {
        public int GuessNumber { private get; set; }

        public GuessNumberGame()
        {
            GuessNumber = new Random().Next(0, 101);
        }

        public GuessNumberStatus SeachGuessNumber(string userInput)
        {
            if (!int.TryParse(userInput, out int numberParsed))
                return GuessNumberStatus.NotANumber;
            if (numberParsed > 100 || numberParsed < 0)
                return GuessNumberStatus.NonValidNumber;
            if (numberParsed == GuessNumber)
                return GuessNumberStatus.CorrectNumber;
            if (numberParsed > GuessNumber)
                return GuessNumberStatus.NumberIsLess;
            return GuessNumberStatus.NumberIsGreater;
        }
    }
}
