using System;
using System.IO;
using System.Linq;
using static System.Math;

namespace DT_Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] data = File.ReadAllLines("C:/Users/Yulia/source/repos/DT_Lab1/DT_Lab1/Input.txt");
            double[][] matrix = new double[data.Length][];

            for (int i = 0; i < data.Length; i++)
            {
                matrix[i] = data[i].Split(default(string[]), StringSplitOptions.RemoveEmptyEntries).Select(x => double.Parse(x)).ToArray<double>();
            }

            Console.WriteLine("\tInput data:");
            for (int i = 0; i<matrix.Length; i++)
            {
                for (int j=0; j<matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j] + "\t");
                }
                Console.WriteLine();
            }

            //Task 1.1
            //Критерій Вальда
            double[] R1 = new double[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                R1[i] = matrix[i].Min();
            }
            double res1 = R1.Max();
            Console.WriteLine("\nВальда: \t" + res1);

            //Task1.2
            //Критерій Гурвіца
            double[] R2 = new double[data.Length];
            double k = 0.4;
            for (int i = 0; i < data.Length; i++)
            {
                R2[i] = matrix[i].Min()*k + (1-k)*matrix[i].Max();
                Console.WriteLine(R2[i]);
            }
            double res2 = R2.Max();
            Console.WriteLine("Гурвiца:\t" + res2);

            //Task1.3
            //Оцінка Лапласа
            double[] R3 = new double[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                R3[i] = matrix[i].Average();
            }
            double res3 = R3.Max();
            Console.WriteLine("Лапласа:\t" + res3);

            //Task 2
            //Байеса-Лапласа
            double[] p = new double[] {0.55, 0.3, 0.15 };
            double[] R4 = new double[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                R4[i] = matrix[i].Sum()*p[i];
            }
            double res4 = R4.Max();

            Console.Write("Експертнi оцiнки для Байеса-Лапласа:\t");
            for (int i =0; i<3; i++)
            {
                Console.Write("[" + p[i] + "], ");
            }
            Console.WriteLine("\nБайеса-Лапласа:\t" + res4);
        }
    }
}
