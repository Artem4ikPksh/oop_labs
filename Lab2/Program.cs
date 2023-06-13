using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masives_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 4;
            ;
            Random r = new Random();
            int[,] mas = {
                { 1, 2, 3, 4 },
                { 5, 6, 0, 8 },
                { 9, 1, 11, 12 },
                { 13, 14, 15, 18 }
            };
            Console.Write("Матриця :\n");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {

                    Console.Write(mas[i, j] + "\t");
                }
                Console.WriteLine();
            }



            int rowCount = mas.GetLength(0);
            int columnCount = mas.GetLength(1);

            int count = 0; // Лічильник кількості рядків, що утворюють арифметичну прогресію

            // Перевіряємо кожен рядок матриці
            for (int i = 0; i < rowCount; i++)
            {
                // Пеевіряємо, чи рядок утворює арифметичну прогресію
                if (IsProgression(mas, i, columnCount))
                {
                    count++;
                }
            }

            Console.WriteLine("\n Кiлькiсть рядкiв, елементи яких утворюють арифметичну прогресiю = " + count);

            Console.ReadLine();
        }
        static bool IsProgression(int[,] matrix, int row, int columnCount)
        {

            int firstElement = matrix[row, 0];
      
            int difference = matrix[row, 1] - firstElement;
            
            for (int j = 2; j < columnCount; j++)
            {
                
                if (matrix[row, j] - matrix[row, j - 1] != difference)
                {
                    return false;
                }
            }
         
            return true;
        }
    }
}
