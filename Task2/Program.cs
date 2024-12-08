namespace Task2
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введите путь к файлу: ");
            string filePath = Console.ReadLine();

            Console.Write("Введите слово для поиска: ");
            string searchWord = Console.ReadLine();

            Console.Write("Введите слово для замены: ");
            string replaceWord = Console.ReadLine();

            string content;
            using (var fileStream = new FileStream(filePath, FileMode.Open))
            using (var reader = new StreamReader(fileStream))
            {
                content = reader.ReadToEnd();
            }

            content = content.Replace(searchWord, replaceWord);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            using (var writer = new StreamWriter(fileStream))
            {
                writer.Write(content);
            }

            Console.WriteLine($"Все вхождения '{searchWord}' заменены на '{replaceWord}'.");
        }
    }
}
