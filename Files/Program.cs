namespace Files
{
    using System;
    using System.IO;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            Random random = new Random();
            int[] numbers = Enumerable.Range(1, 100).Select(_ => random.Next(1, 1000)).ToArray();

            using (var primeFile = new FileStream("primes.txt", FileMode.Create))
            using (var fibonacciFile = new FileStream("fibonacci.txt", FileMode.Create))
            using (var primeWriter = new StreamWriter(primeFile))
            using (var fibonacciWriter = new StreamWriter(fibonacciFile))
            {
                foreach (int num in numbers)
                {
                    if (IsPrime(num)) primeWriter.WriteLine(num);
                    if (IsFibonacci(num)) fibonacciWriter.WriteLine(num);
                }
            }

            Console.WriteLine($"Всего чисел: {numbers.Length}");
            Console.WriteLine($"Простых чисел записано в файл primes.txt.");
            Console.WriteLine($"Чисел Фибоначчи записано в файл fibonacci.txt.");
        }

        static bool IsPrime(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
                if (n % i == 0) return false;
            return true;
        }

        static bool IsFibonacci(int n)
        {
            bool IsPerfectSquare(int x) => Math.Sqrt(x) % 1 == 0;
            return IsPerfectSquare(5 * n * n + 4) || IsPerfectSquare(5 * n * n - 4);
        }
    }

}
