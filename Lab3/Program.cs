using System;

namespace Interface_3lab
{
    public interface INumOperations
    {
        int GetSumOfDigits(object number);
        int CountZeros(object number);
    }

    public class IntNumberOperations : INumOperations
    {
        public int GetSumOfDigits(object number)
        {
            int num = 0;
            int sum = 0;
            if (number is int)
                num = (int)number;

            string numberString = num.ToString();


            foreach (char digitChar in numberString)
            {
                int digit = int.Parse(digitChar.ToString());
                sum += digit;
            }

            return sum;
        }

        public int CountZeros(object number)
        {
            int count = 0;
            int num = 0;
            if (number is int)
                num = (int)number;

            string numberString = num.ToString();


            foreach (char digitChar in numberString)
            {
                if (digitChar == '0')
                    count++;
            }

            return count;
        }
    }
    public class DoubleNumberOperations : INumOperations
    {
        public int GetSumOfDigits(object number)
        {
            double num = 0;
            int sum = 0;
            if (number is double)
                num = (double)number;

            string numberString = num.ToString();


            foreach (char digitChar in numberString)
            {
                if (digitChar != ',')
                {
                    int digit = int.Parse(digitChar.ToString());
                    sum += digit;
                }
            }

            return sum;
        }

        public int CountZeros(object number)
        {
            int count = 0;
            double num = 0;
            if (number is double)
                num = (double)number;

            string numberString = num.ToString();


            foreach (char digitChar in numberString)
            {
                if (digitChar == '0')
                    count++;
            }

            return count;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            INumOperations integerOperations = new IntNumberOperations();
            int integerNumber = 1234500;
            int integerSum = integerOperations.GetSumOfDigits(integerNumber);
            int integerZeroCount = integerOperations.CountZeros(integerNumber);

            Console.WriteLine(integerNumber);
            Console.WriteLine("Suma: " + integerSum);
            Console.WriteLine("Number of 0: " + integerZeroCount);

            INumOperations realOperations = new DoubleNumberOperations();
            double doubleNumber = 12.30045;
            int realSum = realOperations.GetSumOfDigits(doubleNumber);
            int realZeroCount = realOperations.CountZeros(doubleNumber);

            Console.WriteLine(doubleNumber);
            Console.WriteLine("Suma: " + realSum);
            Console.WriteLine("Number of 0: " + realZeroCount);

            Console.ReadLine();
        }
    }
}
