using System;
using System.IO;
using System.Linq;
using static System.Math;

namespace DT_Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] data = File.ReadAllLines("C:/Users/Yulia/source/repos/DT_Lab1/DT_Lab2/Input.txt");
            double[][] matrix = new double[data.Length][];

            for (int i = 0; i < data.Length; i++)
            {
                matrix[i] = data[i].Split(default(string[]), StringSplitOptions.RemoveEmptyEntries).Select(x => double.Parse(x)).ToArray<double>();
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(matrix[i][j] + "\t");
                }
                Console.WriteLine();
            }

            double[] s = new double[8];

            s[0] = (matrix[0][1] * 5 - matrix[0][0]) * matrix[0][2] + (matrix[0][3] * 5 - matrix[0][0]) * matrix[0][4]; //big
            s[1] = (matrix[1][1] * 5 - matrix[1][0]) * matrix[1][2] + (matrix[1][3] * 5 - matrix[1][0]) * matrix[1][4]; //small
            
            s[2] = (matrix[0][1] * 4 - matrix[0][0]) * matrix[2][2] + (matrix[0][3] * 4 - matrix[0][0]) * matrix[2][3]; //income big
            s[3] = (matrix[1][1] * 4 - matrix[1][0]) * matrix[2][2] + (matrix[1][3] * 4 - matrix[1][0]) * matrix[2][3]; //income small


            Console.WriteLine("\nПрибутки, якщо не вiдкладати будiвництво:");
            Console.WriteLine("\tВеликий завод: \t" + s[0] + "тис." + "\n\tМалий завод: \t" + s[1] + "тис.");
            Console.WriteLine("\nПрибутки, якщо вiдкласти будiвництво:");
            Console.WriteLine("\tВеликий завод: \t" + s[2] + "тис." + "\n\tМалий завод: \t" + s[3] + "тис.");

            double res1 = Max(s[0], s[1]);
            double res2 = Max(s[2], s[3]) * matrix[2][0];
            double res = Max(res1, res2);


            if (res == s[0])
            {
                Console.WriteLine("\nКращою стратегiєю буде побудувати великий завод не вiдкладаючи будiвництво.");
            }
            else if (res == s[1])
            {
                Console.WriteLine("\nКращою стратегiєю буде побудувати малий завод не вiдкладаючи будiвництво.");
            }

            else if (s[2] > s[3])
            {
                Console.WriteLine("\nКращою стратегiєю буде вiдкласти будiвництво на рiк та побудувати великий завод.");
            }
            else
            {
                Console.WriteLine("\nКращою стратегiєю буде вiдкласти будiвництво на рiк та побудувати малий завод.");
            }
        }
    }
}
