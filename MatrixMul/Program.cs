﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace MatrixMul
{
    class Program
    {
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter 0 for exit");
            Console.WriteLine("Enter -1 to clear console\n\n");
            while (true)
            {
                try
                {

                    Console.Write("Enter rows of 1 matrix: ");
                    int row1 = Convert.ToInt32(Console.ReadLine());

                    if (row1 == 0)
                        break;
                    else if (row1 == -1)
                    {
                        Console.Clear();
                        continue;
                    }

                    Console.Write("Enter columns of 1 matrix: ");
                    int col1 = Convert.ToInt32(Console.ReadLine());

                    if (col1 == 0)
                        break;
                    else if (col1 == -1)
                    {
                        Console.Clear();
                        continue;
                    }

                    Console.Write("Enter rows of 2 matrix: ");
                    int row2 = Convert.ToInt32(Console.ReadLine());

                    if (row2 == 0)
                        break;
                    else if (row2 == -1)
                    {
                        Console.Clear();
                        continue;
                    }

                    Console.Write("Enter columns of 2 matrix: ");
                    int col2 = Convert.ToInt32(Console.ReadLine());

                    if (col2 == 0)
                        break;
                    else if (col2 == -1)
                    {
                        Console.Clear();
                        continue;
                    }


                    Matrix matrix1 = new Matrix(row1, col1);
                    Matrix matrix2 = new Matrix(row2, col2);

                    matrix1.FillMatrix();
                    matrix2.FillMatrix();

                    ShowText("Matrix1", ConsoleColor.Green);

                    // Can be matrix1.ShowMatrixParallel();
                    matrix1.ShowMatrix();

                    Console.WriteLine("\n\n\n");

                    ShowText("Matrix2", ConsoleColor.Green);

                    // Can be matrix2.ShowMatrixParallel();
                    matrix2.ShowMatrix();


                    Matrix result_matrix = MultiplyMatrixParallel(matrix1, matrix2);


                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("\n\n\tResult\n\n");

                    // Can be result_matrix.ShowMatrixParallel();
                    result_matrix.ShowMatrix();

                    Console.ResetColor();

                }
                catch (Exception ex)
                {
                    ShowText(ex.Message, ConsoleColor.Red);
                }
            }

            Console.WriteLine("\n\n\tEXIT\n\n");
            
        }

        static public void ShowText(string text, ConsoleColor color)
        {
            Console.WriteLine();
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        static public Matrix MultiplyMatrixParallel(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.cols != matrix2.rows)
                throw new Exception("Matrix1 columns not equal Matrix2 rows");

            Matrix matrix_res = new Matrix(matrix1.rows, matrix2.cols);

            Parallel.For(0, matrix1.rows, i =>
                {
                    for (int j = 0; j < matrix2.cols; j++)
                        for (int k = 0; k < matrix1.cols; k++)
                            matrix_res.matrix[i, j] += matrix1.matrix[i, k] * matrix2.matrix[k, j];
                }
            );

            return matrix_res;

        }


        static public Matrix MultiplyMatrix(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.cols != matrix2.rows)
                throw new Exception("Matrix1 columns not equal Matrix2 rows");

            Matrix matrix_res = new Matrix(matrix1.rows, matrix2.cols);

            for (int i = 0; i < matrix1.rows; i++)
                for (int j = 0; j < matrix2.cols; j++)
                    for (int k = 0; k < matrix1.cols; k++)
                        matrix_res.matrix[i, j] += matrix1.matrix[i, k] * matrix2.matrix[k, j];

            return matrix_res;

        }

    }
}
