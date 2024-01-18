namespace Antura.Tests
{
    using System;
    using System.IO;
    using Xunit;

    public class FileProcessorTests
    {
        [Fact]
        public void ProcessFile_ValidFilePath_ReturnsProcessedFile()
        {
            // Arrange
            var filePath = "validFilePath.txt";
            var content = "This is a test file with valid content and 3 occurrences of the filename validFilePath validFilePath validFilePath.";
            File.WriteAllText(filePath, content);

            // Act
            var result = FileProcessor.ProcessFile(filePath);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("validFilePath", result.FileName, ignoreCase: true);
            Assert.Equal(3, result.NumberOfOccurrences);

            // Clean up
            File.Delete(filePath);
        }

        [Fact]
        public void ProcessFile_InvalidFilePath_ReturnsNull()
        {
            // Arrange
            var filePath = "invalidFilePath.txt";

            // Act
            var result = FileProcessor.ProcessFile(filePath);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void ProcessFile_FileWithNoOccurrences_ReturnsProcessedFileWithZeroOccurrences()
        {
            // Arrange
            var filePath = "fileWithNoOccurrences.txt";
            var content = "This is a test file with no occurrences.";
            File.WriteAllText(filePath, content);

            // Act
            var result = FileProcessor.ProcessFile(filePath);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("fileWithNoOccurrences", result.FileName, ignoreCase: true);
            Assert.Equal(0, result.NumberOfOccurrences);

            // Clean up
            File.Delete(filePath);
        }

        [Fact]
        public void ProcessFile_ReadAllLinesException_ReturnsNull()
        {
            // Arrange
            var longFilePath = new string('a', 260); // A file path longer than the allowed limit

            // Act
            var result = FileProcessor.ProcessFile(longFilePath);

            // Assert
            Assert.Null(result);
        }
    }
}
