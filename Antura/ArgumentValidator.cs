namespace Antura
{
    using System;

    public static class ArgumentValidator
    {
        public static string? ValidateFilePath(string[] args)
        {
            string filePath;
            switch (args.Length)
            {
                case > 1:
                    Console.WriteLine("Please provide only one file path as command-line argument.");
                    return null;
                case 1:
                    filePath = args[0];
                    break;
                default:
                    Console.WriteLine("Please provide a file path as a command-line argument.");
                    return null;
            }

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Could not find the file {filePath}");
                return null;
            }

            return filePath;
        }
    }
}
