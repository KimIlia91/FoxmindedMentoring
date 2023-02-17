using MatrixTrace;

namespace MatrixTests
{
    [TestClass]
    public class MatrixMetodsTests
    {
        [TestMethod]
        public void GetMatrixTrace_CheckZero_ReturnZero()
        {
            //arrange
            uint rows = 0;
            uint columns = 0;
            int expected = 0;

            //act
            var actual = new Matrix(rows, columns).GetMatrixTrace();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetMatrixTrace_CheckOnlyColumnsIsZero_ReturnZero()
        {
            //arrange
            uint rows = 5;
            uint columns = 0;
            int expected = 0;

            //act
            var actual = new Matrix(rows, columns).GetMatrixTrace();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetMatrixTrace_CheckIsNotNull_ReturnTrue()
        {
            //arrange
            uint rows = 2;
            uint columns = 1;

            //act
            var actual = new Matrix(rows, columns).GetMatrixTrace();

            //assert
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void GetMatrixTrace_CheckCorrectType_ReturnTypeOfInt()
        {
            //arrange
            uint rows = 2;
            uint columns = 1;

            //act
            var actual = new Matrix(rows, columns).GetMatrixTrace();

            //assert
            Assert.IsInstanceOfType(actual, typeof(int));
        }

        [TestMethod]
        public void PrintMatrix_CheckZero_ReturnNull()
        {
            //arrange
            uint rows = 0;
            uint columns = 0;
            string expected = null;

            //act
            var matrix = new Matrix(rows, columns);
            string actual = matrix.PrintMatrix();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PrintMatrix_CheckOnlyRowsIsZero_ReturnNull()
        {
            //arrange
            uint rows = 2;
            uint columns = 0;
            string expected = null;

            //act
            var matrix = new Matrix(rows, columns);
            string actual = matrix.PrintMatrix();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PrintMatrix_CheckIsNotNull_ReturnTrue()
        {
            //arrange
            uint rows = 5;
            uint columns = 6;

            //act
            var matrix = new Matrix(rows, columns);
            string actual = matrix.PrintMatrix();

            //assert
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void PrintMatrix_CheckCorrectType_ReturnTypeOfString()
        {
            //arrange
            uint rows = 10;
            uint columns = 8;

            //act
            var matrix = new Matrix(rows, columns);
            var actual = matrix.PrintMatrix();

            //assert
            Assert.IsInstanceOfType(actual, typeof(string));
        }
    }
}