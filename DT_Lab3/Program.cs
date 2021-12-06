using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using static System.Math;

namespace DT_Lab3
{
    class Program
    {
        struct Candidate
        {
            public double i;
            public string name;
        }
        List<Candidate> list = new List<Candidate>();
        static void Main(string[] args)
        {
            string[] data = File.ReadAllLines("C:/Users/Yulia/source/repos/DT_Lab1/DT_Lab3/Input.txt");
            double[][] matrix = new double[data.Length][];

            for (int i = 0; i < data.Length; i++)
            {
                matrix[i] = data[i].Split(default(string[]), StringSplitOptions.RemoveEmptyEntries).Select(x => double.Parse(x)).ToArray<double>();
            }

            Console.WriteLine("\tInput data");
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j] + "\t");
                }
                Console.WriteLine();
            }

            //Task2
            //Метод Борда
            double[] results = new double[3];
            for (int i = 0; i < matrix.Length; i++)
            {
                results[0] += matrix[i][0] * matrix[i][1];
                results[1] += matrix[i][0] * matrix[i][2];
                results[2] += matrix[i][0] * matrix[i][3];
            }
            Console.WriteLine("\nМетод Борда");
            Console.WriteLine("A\tB\tC");
            for (int i = 0; i < results.Length; i++)
            {
                Console.Write(results[i] + " \t");
            }
            if (results.Max() == results[0])
            {
                Console.WriteLine("\nПеремiг кандидат A");
            }
            else if (results.Max() == results[1])
            {
                Console.WriteLine("\nПеремiг кандидат B");
            }
            else
            {
                Console.WriteLine("\nПеремiг кандидат C");
            }


            //Task 2
            //Метод Кондорсе
            Console.WriteLine("\nМетод Кондорсе");
            string[] fC = firstCheck(matrix);       //порівняння кандидатів А та В
            string[] sC = secondCheck(matrix);      //порівняння кандидатів А та С
            string[] tC = thirdCheck(matrix);       //порівняння кандидатів В та С

            Console.WriteLine("Мiж кандидатами А та В кращий результат має " + fC[1] + " - " + fC[0]);
            Console.WriteLine("Мiж кандидатами A та C кращий результат має " + sC[1] + " - " + sC[0]);
            Console.WriteLine("Мiж кандидатами B та C кращий результат має " + tC[1] + " - " + tC[0]);
        }

        static string[] firstCheck(double[][] matrix)
        {
            double A = 0, B = 0;
            string[] res = new string[2];
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i][1] > matrix[i][2])
                {
                    A += matrix[i][0];
                }
                else
                {
                    B += matrix[i][0];
                }
            }
            if (A > B)
            {
                res[0] = (A).ToString();
                res[1] = "A";
            }
            else {
                res[0] = (B).ToString();
                res[1] = "B";
            }
            return res;
        }
        static string[] secondCheck(double[][] matrix)
        {
            double A = 0, C = 0;
            string[] res = new string[2];
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i][1] > matrix[i][3])
                {
                    A += matrix[i][0];
                }
                else
                {
                    C += matrix[i][0];
                }
            }
            if (A>C)
            { 
                res[0] = (A).ToString();
                res[1] = "A";
            }
            else
            {
                res[0] = (C).ToString();
                res[1] = "C";
            }
            return res;
        }
        static string[] thirdCheck(double[][] matrix)
        {
            double B = 0, C = 0;
            string[] res = new string[2];
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i][2] > matrix[i][3])
                {
                    B += matrix[i][0];
                }
                else
                {
                    C += matrix[i][0];
                }
            }
            if (B > C)
            {
                res[0] = (B).ToString();
                res[1] = "B";
            }
            else
            {
                res[0] = (C).ToString();
                res[1] = "C";
            }
            return res;
        }
    }
}
