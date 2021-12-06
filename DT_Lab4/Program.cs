using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using static System.Math;
namespace DT_Lab4
{
    class Program
    {
        struct Num
        {
            public double n;
            public int i;
        }
        static void Main(string[] args)
        {
            string[] data = File.ReadAllLines("C:/Users/Yulia/source/repos/DT_Lab1/DT_Lab4/Input.txt");
            double[][] matrix = new double[data.Length][];

            for (int i = 0; i < data.Length; i++)
            {
                matrix[i] = data[i].Split(default(string[]), StringSplitOptions.RemoveEmptyEntries).Select(x => double.Parse(x)).ToArray<double>();
            }

            Console.WriteLine("K\tBook1\tBook2\tBook3\tBook4\tBook5");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Console.Write(matrix[i][j] + "\t");
                }
                Console.WriteLine();
            }

            double[][] results = new double[4][];
            double[] sum = new double[5];
            double[] wSum = new double[5];

            for (int i = 1; i < 6; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    sum[i - 1] += matrix[j][i];
                    wSum[i - 1] += matrix[j][i] * matrix[j][0];
                }
                
            }

            Console.WriteLine("\nСума оцiнок:");
            for (int i = 0; i < 5; i++)
            {
                Console.Write(sum[i] + " ");
            }
            Console.WriteLine("\nПорядок за сумою оцiнок:");
            List<Num> list = new List<Num>();
            for (int i = 0; i < 5; i++)
            {
                Num n;
                n.n = sum[i];
                n.i = i+1;
                list.Add(n);
            }
            var sorted = list.OrderByDescending(l => l.n);
            foreach(Num i in sorted)
                Console.Write(i.i +" ");

            Console.WriteLine("\nСума оцiнок з урахуванням ваги:");
            for (int i = 0; i < 5; i++)
            {
                Console.Write(sum[i] + " ");
            }
            Console.WriteLine("\nПорядок з урахуванням ваги:");
            List<Num> list2 = new List<Num>();
            for (int i = 0; i < 5; i++)
            {
                Num n;
                n.n = wSum[i];
                n.i = i + 1;
                list2.Add(n);
            }

            var sorted2 = list2.OrderByDescending(l => l.n);
            foreach (Num i in sorted2)
                Console.Write(i.i + " ");
        }
    }
}
