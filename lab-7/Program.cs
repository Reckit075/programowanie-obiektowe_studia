using System;

namespace lab_7
{

    delegate double Operator(double a, double b);
    class Program
    {

        public static double Addition(double x, double y)
        {
            return x + y;
        }
        public static double Multiplication(double x, double y)
        {
            return x * y;
        }

        public static void PrintIntArray(int[] arr, Func<int, string> formatter)
        {
            foreach (var item in arr)
            {
                Console.WriteLine(formatter.Invoke(item));
            }
        }

        static void Main(string[] args)
        {
            Operator operation = Addition;
            double result = operation.Invoke(4,6);
            Console.WriteLine(result);

            operation = Multiplication;
            result = operation.Invoke(2, 3);
            Console.WriteLine(result);

            Func<double, double, double> AnotherTypeOfDelegate = Multiplication;
            AnotherTypeOfDelegate = Addition;

            Func<int, string> Formatter = delegate (int number)
            {
                return string.Format("#{0:x}", number);
            };
            Console.WriteLine(Formatter.Invoke(34));

            Predicate<string> OnlyThreeChars = delegate (string s)
            {
                return s.Length == 3;
            };

            Func<int, int, int, bool> InRange = delegate (int value, int main, int max)
            {
                return value > int.MinValue && value < max;
            };

            Action<string> Print = delegate (string s)
            {
                Console.WriteLine(s);
            };

            Operator AddLambda = (a, b) => a + b;

            PrintIntArray(new int[] { 1, 5, 58 }, Formatter);

        }
    }
}
