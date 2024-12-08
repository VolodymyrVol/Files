namespace Task3
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введите путь к текстовому файлу: ");
            string textFilePath = Console.ReadLine();

            Console.Write("Введите путь к файлу со словами для модерирования: ");
            string moderationWordsPath = Console.ReadLine();

            string[] moderationWords;
            using (var fileStream = new FileStream(moderationWordsPath, FileMode.Open))
            using (var reader = new StreamReader(fileStream))
            {
                moderationWords = reader.ReadToEnd().Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            }

            string content;
            using (var fileStream = new FileStream(textFilePath, FileMode.Open))
            using (var reader = new StreamReader(fileStream))
            {
                content = reader.ReadToEnd();
            }

            foreach (var word in moderationWords)
            {
                string mask = new string('*', word.Length);
                content = content.Replace(word, mask);
            }

            using (var fileStream = new FileStream(textFilePath, FileMode.Create))
            using (var writer = new StreamWriter(fileStream))
            {
                writer.Write(content);
            }

            Console.WriteLine("Модерация завершена.");
        }
    }
}
