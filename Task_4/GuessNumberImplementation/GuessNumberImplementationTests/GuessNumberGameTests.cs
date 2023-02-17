using GuessNumberImplementation;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace GuessNumberImplementationTests
{
    [TestClass]
    public class GuessNumberGameTests
    {
        private int WinnerNumber = 25;

        [TestMethod]
        public void SeachGuessNumber_InputNumberIsLess_ReturnNumberIsGreater()
        {
            //arrange
            var game = new GuessNumberGame { GuessNumber = WinnerNumber };
            var excpected = GuessNumberStatus.NumberIsGreater;
            var userInput = "20";

            // act
            var actual = game.SeachGuessNumber(userInput);

            //assert
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void SeachGuessNumber_InputNumberIsGreater_ReturnNumberIsLess()
        {
            //arrange
            var game = new GuessNumberGame { GuessNumber = WinnerNumber };
            var excpected = GuessNumberStatus.NumberIsLess;
            var userInput = "30";

            // act
            var actual = game.SeachGuessNumber(userInput);

            //assert
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void SeachGuessNumber_InputNumberCorrect_ReturnNumberCorrect()
        {
            //arrange
            var game = new GuessNumberGame { GuessNumber = WinnerNumber };
            var excpected = GuessNumberStatus.CorrectNumber;
            var userInput = "25";

            // act
            var actual = game.SeachGuessNumber(userInput);

            //assert
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void SeachGuessNumber_InputLetters_ReturnNotANumber()
        {
            //arrange
            var game = new GuessNumberGame { GuessNumber = WinnerNumber };
            var excpected = GuessNumberStatus.NotANumber;
            var userInput = "sdfsdf";

            // act
            var actual = game.SeachGuessNumber(userInput);

            //assert
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void SeachGuessNumber_MoreThanHundred_ReturnNonValidNumber()
        {
            //arrange
            var game = new GuessNumberGame { GuessNumber = WinnerNumber };
            var excpected = GuessNumberStatus.NonValidNumber;
            var userInput = "150";

            // act
            var actual = game.SeachGuessNumber(userInput);

            //assert
            Assert.AreEqual(excpected, actual);
        }

        public void SeachGuessNumber_LessThanZero_ReturnNonValidNumber()
        {
            //arrange
            var game = new GuessNumberGame { GuessNumber = WinnerNumber };
            var excpected = GuessNumberStatus.NonValidNumber;
            var userInput = "-5";

            // act
            var actual = game.SeachGuessNumber(userInput);

            //assert
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void SeachGuessNumber_CheckNull_ReturnNotANumber()
        {
            //arrange
            var game = new GuessNumberGame { GuessNumber = WinnerNumber };
            var excpected = GuessNumberStatus.NotANumber;
            string userInput = null;

            // act
            var actual = game.SeachGuessNumber(userInput);

            //assert
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void SeachGuessNumber_CheckEmpty_ReturnNotANumber()
        {
            //arrange
            var game = new GuessNumberGame { GuessNumber = WinnerNumber };
            var excpected = GuessNumberStatus.NotANumber;
            var userInput = "";

            // act
            var actual = game.SeachGuessNumber(userInput);

            //assert
            Assert.AreEqual(excpected, actual);
        }
    }
}