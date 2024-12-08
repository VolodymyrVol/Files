namespace Task4
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введите путь к файлу: ");
            string filePath = Console.ReadLine();

            string content;
            using (var fileStream = new FileStream(filePath, FileMode.Open))
            using (var reader = new StreamReader(fileStream))
            {
                content = reader.ReadToEnd();
            }

            string reversedContent = new string(content.Reverse().ToArray());

            string newFilePath = Path.GetFileNameWithoutExtension(filePath) + "_reversed" + Path.GetExtension(filePath);
            using (var fileStream = new FileStream(newFilePath, FileMode.Create))
            using (var writer = new StreamWriter(fileStream))
            {
                writer.Write(reversedContent);
            }

            Console.WriteLine($"Файл перевернут и сохранен как {newFilePath}");
        }
    }
}
