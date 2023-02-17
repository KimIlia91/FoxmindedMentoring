using CalculatorImplementation;
using System.Linq.Expressions;

namespace CalculatorImplementationTests
{
    [TestClass]
    public class CalculatorTests
    {
        Calculator calculator = new Calculator();

        [TestMethod]
        public void GetCalculated_CheckNull_ReturnNull()
        {
            //arrange
            string expression = null;
            string excpected = null;

            //act
            var actual = calculator.Calculate(expression);

            //assert
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void GetCalculated_CheckStringEmty_ReturnEmtyString()
        {
            //arrange
            string expression = string.Empty;
            string excpected = "";

            //act
            var actual = calculator.Calculate(expression);

            //assert
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void GetCalculated_CheckExpressionWithBrackets_ReturnCorrectResult()
        {
            //arrange
            string expression = "(7 - (1 + 1)) * 3 - (2 + (1 + 1))";
            string excpected = "11";

            //act
            var actual = calculator.Calculate(expression);

            //assert
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void GetCalculated_CheckWithoutBrackets_ReturnCorrectResult()
        {
            //arrange
            string expression = "2+15/3+4*2";
            string excpected = "15";

            //act
            var actual = calculator.Calculate(expression);

            //assert
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void GetCalculated_CheckNegativeNumbers_ReturnNegativeResult()
        {
            //arrange
            string expression = "-6-7-2-3-6";
            string excpected = "-24";

            //act
            var actual = calculator.Calculate(expression);

            //assert
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void GetCalculated_CheckMultiplyNegativeNumbers_ReturnCorrectResult()
        {
            //arrange
            string expression = "-5 * -5";
            string excpected = "25";

            //act
            var actual = calculator.Calculate(expression);

            //assert
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void GetCalculated_CheckDivideNegativeNumbers_ReturnCorrectResult()
        {
            //arrange
            string expression = "-5 / -5";
            string excpected = "1";

            //act
            var actual = calculator.Calculate(expression);

            //assert
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void GetCalculated_CheckSpaceInExpression_ReturnCorrectResult()
        {
            //arrange
            string expression = "-  5 / ( - 5 + 3 ) ";
            string excpected = "2,5";

            //act
            var actual = calculator.Calculate(expression);

            //assert
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void GetCalculated_CheckInvalidFormatEntered_ReturnThrowExceptionWrongExpressionFormat()
        {
            //arrange
            string expression = ")5+5(";
            string excpected = "Wrong expression format.";
            string actual = null;

            //act
            try
            {
                var test = calculator.Calculate(expression);
            }
            catch (Exception ex)
            {
                actual = ex.Message;
            }

            //assert
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void GetCalculated_CheckDivisionByZero_ReturnThrowExceptionCantDivideByZero()
        {
            //arrange
            string expression = "2/0";
            string excpected = "Exception! Divide by zero.";
            string actual = null;

            //act
            try
            {
                var test = calculator.Calculate(expression);
            }
            catch (Exception ex)
            {
                actual = ex.Message;
            }

            //assert
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void GetCalculated_CheckNotExpression_ReturnThrowExceptionWrongInput()
        {
            //arrange
            string expression = "1+a*2";
            string excpected = "Exception! Wrong input.";
            string actual = null;

            //act
            try
            {
                var test = calculator.Calculate(expression);
            }
            catch (Exception ex)
            {
                actual = ex.Message;
            }

            //assert
            Assert.AreEqual(excpected, actual);
        }
    }
}