namespace Antura
{
    public class ProcessedFile(string fileName, int numberOfOccurences)
    {
        public string FileName { get; set; } = fileName;
        public int NumberOfOccurrences { get; set; } = numberOfOccurences;
    }
}
