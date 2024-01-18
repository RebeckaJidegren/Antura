namespace Antura
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var filePath = ArgumentValidator.ValidateFilePath(args);
            if (filePath == null) return;

            var processedFile = FileProcessor.ProcessFile(filePath);
            if (processedFile is null) return;

            Console.WriteLine($"Found the word {processedFile.FileName} {processedFile.NumberOfOccurrences} times.");
        }
    }
}