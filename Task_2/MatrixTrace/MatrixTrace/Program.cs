namespace MatrixTrace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Введите количество строк в матрице: ");
                var rows = Console.ReadLine();
                Console.Write("\nВведите количество столбцов в матрице: ");
                var columns = Console.ReadLine();

                if (uint.TryParse(rows, out uint rowsParse) && uint.TryParse(columns, out uint columnsParse))
                {
                    Matrix matrix = new Matrix(rowsParse, columnsParse);
                    Console.WriteLine("\nМатрица с выделенной \"<>\" главной диагональю: \n\n{0}", matrix.PrintMatrix());
                    Console.WriteLine("След матрицы составляет: {0}\n", matrix.GetMatrixTrace());
                }
                else
                    Console.WriteLine("\nВведите положительное число для строк и столбцов!\n");

                Console.Write("Нажмите \"Enter\" для продолжения!");
                Console.ReadLine();
                Console.Clear();
            }
            
        }
    }
}