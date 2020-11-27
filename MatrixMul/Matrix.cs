using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace MatrixMul
{
    public class Matrix: IEnumerable
    {
        public int[,] matrix;
        public int rows { get; set; }
        public int cols { get; set; }

        public Matrix(int rows, int cols)
        {
            matrix = new int[rows, cols];
            this.rows = rows;
            this.cols = cols;
        }

        public void FillMatrix()
        {
            Random rnd = new Random();

            Parallel.For(0, rows, i =>
                {
                    for (int j = 0; j < cols; j++)
                        matrix[i, j] = rnd.Next(1, 100);
                }
            );
        }

        public void ShowMatrix()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j].ToString() + "\t");
                }
                Console.WriteLine("\n");
            }

        }

        public void ShowMatrixParallel()
        {
            Parallel.For(0, rows, i =>
                {
                    for (int j = 0; j < cols; j++)
                    {
                        Console.WriteLine(matrix[i, j]);
                    }
                }
            );

        }

        public IEnumerator GetEnumerator()
        {
            return matrix.GetEnumerator();
        }

    }
}
