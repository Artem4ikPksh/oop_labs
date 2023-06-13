using System;
using System.Text;
namespace TsMatrix
{
    class TSMatrix
    {
        private int[,] matrix; 
        private int size; 

        // Конструктор без параметрів
        public TSMatrix()
        {
            size = 0;
            matrix = null;
        }

        // Конструктор з параметрами
        public TSMatrix(int n)
        {
            size = n;
            matrix = new int[size, size];
        }

        // Конструктор копіювання
        public TSMatrix(TSMatrix m)
        {
            size = m.size;
            matrix = new int[size, size];
            Array.Copy(m.matrix, matrix, size * size);
        }

       
        public void Input()
        {
            Console.WriteLine("Введіть елементи матриці:");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write($"Елемент [{i}, {j}]: ");
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }
           
          
        }


        
        public void Output()
        {
            Console.WriteLine("Елементи матриці");

            for (int i = 0; i < size; i++)
            {
                
                for (int j = 0; j < size; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public int MaxElement()
        {
            int max = matrix[0, 0];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                    }
                }
            }
            
            return max;

        }
        public int MinElement()
        {
            int min = matrix[0, 0];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                    }
                }
            }
           
            return min;
        }

        public int SumElement()
        {
            int sum = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    sum += matrix[i, j];
                }
            }
            return sum;
        }

        
        public static TSMatrix operator +(TSMatrix m1, TSMatrix m2)
        {
            if (m1.size != m2.size)
            {
                throw new Exception("Розмірності матриць не збігаються");
            }

            TSMatrix result = new TSMatrix(m1.size);
            for (int i = 0; i < result.size; i++)
            {
                for (int j = 0; j < result.size; j++)
                {
                    result.matrix[i, j] = m1.matrix[i, j] + m2.matrix[i, j];
                }
            }
            Console.Write("Матриця суми - ");
            return result;
        }

        public static TSMatrix operator -(TSMatrix m1, TSMatrix m2)
        {
            if (m1.size != m2.size)
                throw new ArgumentException("Розмірності матриць не збігаються");

            TSMatrix result = new TSMatrix(m1.size);

            for (int i = 0; i < result.size; i++)
                for (int j = 0; j < result.size; j++)
                {
                    result.matrix[i, j] = m1.matrix[i, j] - m2.matrix[i, j];
                }
            Console.Write("Матриця різниці - ");
            return result;
        }
        class TMSMatrix : TSMatrix
        {
            public TMSMatrix() : base() { }

            public TMSMatrix(int n) : base(n) { }

            public TMSMatrix(TMSMatrix copy) : base(copy) { }

            public TMSMatrix Transpose()
            {
                TMSMatrix result = new TMSMatrix(size);

                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        result.matrix[i, j] = matrix[j, i];
                    }
                }

                return result;
            }
            public static TMSMatrix operator *(TMSMatrix m1, TMSMatrix m2)
            {
                if (m1.size != m2.size)
                {
                    throw new ArgumentException("Розмірності матриць не збігаються");
                }

                TMSMatrix result = new TMSMatrix(m1.size);
                for (int i = 0; i < m1.size; i++)
                {
                    for (int j = 0; j < m1.size; j++)
                    {
                        int sum = 0;
                        for (int k = 0; k < m1.size; k++)
                        {
                            sum += m1.matrix[i, k] * m2.matrix[k, j];
                        }
                        result.matrix[i, j] = sum;
                        
                    }
                }
                Console.Write("Матриця добутку - ");
                return result;
               
            }
            public static TMSMatrix operator *(TMSMatrix matrix, int num)
            {
                TMSMatrix result = new TMSMatrix(matrix.size);
                for (int i = 0; i < matrix.size; i++)
                {
                    for (int j = 0; j < matrix.size; j++)
                    {
                        result.matrix[i, j] = matrix.matrix[i, j] * num;
                    }
                }
                return result;
            }

            
            public void OutputMultipliedData(int num)
            {
                TMSMatrix multipliedMatrix = this * num;
                Console.WriteLine($"Матриця помножена на  {num}:");
                multipliedMatrix.Output();
            }

        }
        class Program
        {
            static void Main(string[] args)
            {
                Console.OutputEncoding = UTF8Encoding.UTF8;
                Console.Write("Введіть розмірність матриці: ");
                int n = int.Parse(Console.ReadLine());

                TMSMatrix matrix1 = new TMSMatrix(n);
                matrix1.Input();
                matrix1.Output();
                             

                TMSMatrix matrix2 = new TMSMatrix(n);
                matrix2.Input();
                matrix2.Output();

                int maxElement = matrix1.MaxElement();
                Console.WriteLine("Найбільший елемент матриці: "+maxElement);
                int minElement = matrix1.MinElement();
                Console.WriteLine("Найменший елемент матриці: "+minElement);
                int sumElement = matrix1.SumElement();
                Console.WriteLine("Сума елементів матриці: "+sumElement);
                TSMatrix sum = matrix1 + matrix2;
                sum.Output();

                TSMatrix diff = matrix1 - matrix2;
                diff.Output();
               
                TMSMatrix mult = matrix1*matrix2;
                mult.Output();

                
                Console.Write("Транспонована матриця - ");
                matrix1.Transpose().Output();


                matrix1.OutputMultipliedData(3);
                
                Console.ReadKey();
            }
        }
        
        }
    }

