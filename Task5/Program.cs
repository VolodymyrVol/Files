namespace Task5
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введите путь к файлу: ");
            string filePath = Console.ReadLine();

            int[] numbers;
            using (var fileStream = new FileStream(filePath, FileMode.Open))
            using (var reader = new StreamReader(fileStream))
            {
                numbers = reader.ReadToEnd().Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                                          .Select(int.Parse)
                                          .ToArray();
            }

            using (var positiveFile = new FileStream("positive_numbers.txt", FileMode.Create))
            using (var negativeFile = new FileStream("negative_numbers.txt", FileMode.Create))
            using (var twoDigitFile = new FileStream("two_digit_numbers.txt", FileMode.Create))
            using (var fiveDigitFile = new FileStream("five_digit_numbers.txt", FileMode.Create))
            using (var positiveWriter = new StreamWriter(positiveFile))
            using (var negativeWriter = new StreamWriter(negativeFile))
            using (var twoDigitWriter = new StreamWriter(twoDigitFile))
            using (var fiveDigitWriter = new StreamWriter(fiveDigitFile))
            {
                foreach (int num in numbers)
                {
                    if (num > 0) positiveWriter.WriteLine(num);
                    if (num < 0) negativeWriter.WriteLine(num);
                    if (Math.Abs(num).ToString().Length == 2) twoDigitWriter.WriteLine(num);
                    if (Math.Abs(num).ToString().Length == 5) fiveDigitWriter.WriteLine(num);
                }
            }

            Console.WriteLine($"Положительных чисел: {numbers.Count(n => n > 0)}");
            Console.WriteLine($"Отрицательных чисел: {numbers.Count(n => n < 0)}");
            Console.WriteLine($"Двузначных чисел: {numbers.Count(n => Math.Abs(n).ToString().Length == 2)}");
            Console.WriteLine($"Пятизначных чисел: {numbers.Count(n => Math.Abs(n).ToString().Length == 5)}");
        }
    }
}
