namespace Antura
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public static class FileProcessor
    {
        public static ProcessedFile? ProcessFile(string filePath)
        {
            int numberOfOccurences;
            string fileName;

            try
            {
                fileName = Path.GetFileNameWithoutExtension(filePath);
                if (fileName is null) return null;

                var lines = File.ReadAllLines(filePath);
                var allWords = new List<string>();

                foreach (var line in lines)
                {
                    var words = Regex.Split(line, @"\W+");
                    allWords.AddRange(words);
                }

                numberOfOccurences = allWords.Where(x => x.Equals(fileName, StringComparison.OrdinalIgnoreCase)).Count();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }

            return new ProcessedFile(fileName, numberOfOccurences);
        }
    }
}
