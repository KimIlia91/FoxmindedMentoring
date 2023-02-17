using MaximumSumOfElements;

namespace MaximumSumOfElementsTests
{
    [TestClass]
    public class RowSeachTests
    {
        [TestMethod]
        public void BrokenRows_CheckNumberAndLettersAndSymbols_ReturnBrokenRows()
        {
            //arrange
            string path = @"C:\Users\User\Documents\FoxmindedWorks\Task_3\MaximalSumOfElements\MaximalSumOfElementsTests\UnitTest_1.txt";
            var excpected = 1;
            var excpected_1 = 3;
            var excpected_2 = 4;

            //act
            var rs = new RowSeach(path);
            var actual = rs.BrokenRows[0];
            var actual_1 = rs.BrokenRows[1];
            var actual_2 = rs.BrokenRows[2];

            //assert
            Assert.AreEqual(excpected, actual);
            Assert.AreEqual(excpected_1, actual_1);
            Assert.AreEqual(excpected_2, actual_2);
        }

        [TestMethod]
        public void BrokenRows_CheckEmtyLines_ReturnBrokenRows()
        {
            //arrange
            string path = @"C:\Users\User\Documents\FoxmindedWorks\Task_3\MaximalSumOfElements\MaximalSumOfElementsTests\UnitTest_2.txt";
            var excpected_1 = 1;
            var excpected_2 = 2;
            var excpected_3 = 3;

            //act
            var rs = new RowSeach(path);
            var actual_1 = rs.BrokenRows[0];
            var actual_2 = rs.BrokenRows[1];
            var actual_3 = rs.BrokenRows[2];

            //assert
            Assert.AreEqual(excpected_1, actual_1);
            Assert.AreEqual(excpected_2, actual_2);
            Assert.AreEqual(excpected_3, actual_3);
        }

        [TestMethod]
        public void BrokenRows_CheckWrongPath_ReturnListNull()
        {
            //arrange
            string path = @"C:\user\program\test.txt";
            var excpected = 0;
            foreach (var exc in new List<int>())
                excpected = exc;

            //act
            var rs = new RowSeach(path);
            var actual = 0;
            foreach (var exc in rs.BrokenRows)
                actual = exc;

            //assert
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void BrokenRows_CheckAllBrokenRows_ReturnBrokenRows()
        {
            //arrange
            string path = @"C:\Users\User\Documents\FoxmindedWorks\Task_3\MaximalSumOfElements\MaximalSumOfElementsTests\UnitTest_4.txt";
            int excpected = 15;

            //act
            var rs = new RowSeach(path);
            int actual = 0;
            foreach (var s in rs.BrokenRows)
                actual += s;

            //assert
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void BrokenRows_CheckAllMaxRows_ReturnZero()
        {
            //arrange
            string path = @"C:\Users\User\Documents\FoxmindedWorks\Task_3\MaximalSumOfElements\MaximalSumOfElementsTests\UnitTest_5.txt";
            int excpected = 0;

            //act
            var rs = new RowSeach(path);
            int actual = 0;
            foreach (var s in rs.BrokenRows)
                actual += s;

            //assert
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void MaxRow_CheckWrongPath_ReturnZero()
        {
            //arrange
            string path = @"C:\Users\User\Documents\test.text";
            var excpected = 0;
            foreach (var exc in new List<int>())
                excpected = exc;

            //act
            var rs = new RowSeach(path);
            var actual = 0;
            foreach (var exc in rs.MaxRow)
                actual = exc;

            //assert
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void MaxRow_CheckNumberAndLetters_ReturnRowMaximumSum()
        {
            //arrange
            string path = @"C:\Users\User\Documents\FoxmindedWorks\Task_3\MaximalSumOfElements\MaximalSumOfElementsTests\UnitTest_1.txt";
            int excpected = 5;

            //act
            var rs = new RowSeach(path);
            int actual = 0;
            foreach (var s in rs.MaxRow)
                    actual = s;

            //assert
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void MaxRow_CheckEmtyLines_ReturnRowMaximumSum()
        {
            //arrange
            string path = @"C:\Users\User\Documents\FoxmindedWorks\Task_3\MaximalSumOfElements\MaximalSumOfElementsTests\UnitTest_2.txt";
            int excpected = 4;

            //act
            var rs = new RowSeach(path);
            int actual = 0;
            foreach (var s in rs.MaxRow)
                actual = s;

            //assert
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void MaxRow_CheckAllNegativeNumbers_ReturnRowMaximumSum()
        {
            //arrange
            string path = @"C:\Users\User\Documents\FoxmindedWorks\Task_3\MaximalSumOfElements\MaximalSumOfElementsTests\UnitTest_3.txt";
            int excpected = 9; // sum of maxSumRows

            //act
            var rs = new RowSeach(path);
            int actual = 0;
            foreach (var s in rs.MaxRow)
                actual += s;

            //assert
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void MaxRow_CheckAllBrokenRows_ReturnZero()
        {
            //arrange
            string path = @"C:\Users\User\Documents\FoxmindedWorks\Task_3\MaximalSumOfElements\MaximalSumOfElementsTests\UnitTest_4.txt";
            int excpected = 0; 

            //act
            var rs = new RowSeach(path);
            int actual = 0;
            foreach (var s in rs.MaxRow)
                actual += s;

            //assert
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void MaxRow_CheckAllMaxRows_ReturnMaxRows()
        {
            //arrange
            string path = @"C:\Users\User\Documents\FoxmindedWorks\Task_3\MaximalSumOfElements\MaximalSumOfElementsTests\UnitTest_5.txt";
            int excpected = 15; // sum of MaxRows

            //act
            var rs = new RowSeach(path);
            int actual = 0;
            foreach (var s in rs.MaxRow)
                actual += s;

            //assert
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void MaxSum_CheckAllBrokenRows_ReturnNull()
        {
            //arrange
            string path = @"C:\Users\User\Documents\FoxmindedWorks\Task_3\MaximalSumOfElements\MaximalSumOfElementsTests\UnitTest_4.txt";
            double? excpected = null;

            //act
            var rs = new RowSeach(path);
            double? actual = rs.MaxSum;

            //assert
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void MaxSum_CheckAllRowsAreEqual_ReturnMaxSum()
        {
            //arrange
            string path = @"C:\Users\User\Documents\FoxmindedWorks\Task_3\MaximalSumOfElements\MaximalSumOfElementsTests\UnitTest_5.txt";
            double excpected = 1.1;
            //act
            var rs = new RowSeach(path);
            double? actual = Math.Round((double)rs.MaxSum, 1);

            //assert
            Assert.AreEqual(excpected, actual);
        }
    }
}