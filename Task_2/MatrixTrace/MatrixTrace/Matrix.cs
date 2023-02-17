using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTrace
{
    public class Matrix
    {
        private int[,] _matrix;
        private uint _rows;
        private uint _columns;

        public Matrix(uint rows, uint columns)
        {
            _rows = rows;
            _columns = columns;
            _matrix = new int[_rows, _columns];
            Random random = new Random();
            for (int i = 0; i < _rows; ++i)
                for (int j = 0; j < _columns; ++j)
                    _matrix[i, j] = random.Next(0, 101);
        }
        
        public string PrintMatrix()
        {
            string printResult = null;
            if (_rows == 0 || _columns == 0) 
                return printResult;
            for (int i = 0; i < _rows; ++i)
            {
                printResult += "|| ";
                for (int j = 0; j < _columns; ++j)
                    printResult += i == j ? "<" + _matrix[i, j].ToString().PadLeft(3) + ">" : _matrix[i, j].ToString().PadLeft(4) + " ";
                printResult += " ||" + Environment.NewLine;
            }
            return printResult;
        }

        public int GetMatrixTrace()
        {
            int matrixTrace = 0;
            for (int i = 0; i < _rows && i < _columns; ++i)
                        matrixTrace += _matrix[i, i];
            return matrixTrace;
        }
    }
}
