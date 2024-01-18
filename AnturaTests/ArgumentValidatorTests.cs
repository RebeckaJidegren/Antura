namespace AnturaTests
{
    using Antura;
    using Xunit;

    public class ArgumentValidatorTests
    {
        [Fact]
        public void ValidateFilePath_WithNoArguments_ShouldReturnNull()
        {
            // Arrange
            string[] args = [];

            // Act
            var result = ArgumentValidator.ValidateFilePath(args);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void ValidateFilePath_WithMultipleArguments_ShouldReturnNull()
        {
            // Arrange
            string[] args = ["path1", "path2"];

            // Act
            var result = ArgumentValidator.ValidateFilePath(args);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void ValidateFilePath_WithNonexistentFile_ShouldReturnNull()
        {
            // Arrange
            string[] args = ["nonexistent_file.txt"];

            // Act
            var result = ArgumentValidator.ValidateFilePath(args);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void ValidateFilePath_WithOneArgumentAndExistingFile_ShouldReturnFilePath()
        {
            // Arrange
            string tempFilePath = Path.GetTempFileName();
            string[] args = [tempFilePath];

            try
            {
                // Act
                var result = ArgumentValidator.ValidateFilePath(args);

                // Assert
                Assert.Equal(tempFilePath, result);
            }
            finally
            {
                File.Delete(tempFilePath);
            }
        }
    }

}