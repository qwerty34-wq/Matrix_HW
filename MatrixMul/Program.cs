using System;

namespace MatrixMul
{
    class Program
    {
        Random rnd = new Random();

        static void Main(string[] args)
        {
            
            while(true)
            {
                Console.WriteLine("Enter rows of 1 matrix: ");
                int row1 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter columns of 1 matrix: ");
                int col1 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter rows of 2 matrix: ");
                int row2 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter columns of 2 matrix: ");
                int col2 = Convert.ToInt32(Console.ReadLine());


                int[,] matrix1 = new int[row1, col1];
                int[,] matrix2 = new int[row2, col2];




            }

        }

        private void FillMatrix()
        {

        }

    }
}
