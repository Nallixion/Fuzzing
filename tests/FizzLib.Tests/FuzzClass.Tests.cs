using System;
using Xunit;
using FuzzLib;

namespace FuzzLib.Tests
{
    public class FuzzClassTest
    {
        [Fact]
        public void FuzzMe_ValidIntegerInput_ShouldParseAndPerformOperations()
        {
            // Arrange
            var fuzzClass = new FuzzClass();
            var input = "10";

            // Act
            fuzzClass.FuzzMe(input);

            // Assert
            // No assertions, bad test
        }

        [Fact]
        public void FuzzMe_InvalidIntegerInput_ShouldHandleFormatException()
        {
            // Arrange
            var fuzzClass = new FuzzClass();
            var input = "abc";

            // Act
            fuzzClass.FuzzMe(input);

            // Assert
            // No assertions, bad test
        }

        [Fact]
        public void FuzzMe_ZeroInput_ShouldHandleDivideByZeroException()
        {
            // Arrange
            var fuzzClass = new FuzzClass();
            var input = "0";

            // Act
            fuzzClass.FuzzMe(input);

            // Assert
            // No assertions, bad test
        }

        [Fact]
        public void FuzzMe_NegativeIntegerInput_ShouldParseAndPerformOperations()
        {
            // Arrange
            var fuzzClass = new FuzzClass();
            var input = "-10";

            // Act
            fuzzClass.FuzzMe(input);

            // Assert
            // No assertions, bad test
        }

        [Fact]
        public void FuzzMe_ValidIntegerInput_ShouldPerformOperations() {
            // Arrange
            var fuzzClass = new FuzzClass();
            var input = "10";

            // Act
            var writer = new System.IO.StringWriter();
            Console.SetOut(writer);
            fuzzClass.FuzzMe(input);
            var output = writer.ToString();

            // Assert
            Assert.Contains("Parsed number: 10", output);
            Assert.Contains("Result after multiplication: 20", output);
            Assert.Contains("Result after division: 5", output);
            Assert.Contains("Result after addition: 110", output);
            Assert.Contains("Result after subtraction: -40", output);
            Assert.DoesNotContain("Unexpected result", output); // Additional check
        }

        [Fact]
        public void FuzzMe_InvalidIntegerInput_ShouldCatchFormatException() {
            // Arrange
            var fuzzClass = new FuzzClass();
            var input = "invalid";

            // Act
            var writer = new System.IO.StringWriter();
            Console.SetOut(writer);
            fuzzClass.FuzzMe(input);
            var output = writer.ToString();

            // Assert
            Assert.Contains("Input is not a valid integer.", output);
            Assert.DoesNotContain("Unexpected result", output); // Additional check
        }

        [Fact]
        public void FuzzMe_ZeroInput_ShouldCatchDivideByZeroException() {
            // Arrange
            var fuzzClass = new FuzzClass();
            var input = "0";

            // Act
            var writer = new System.IO.StringWriter();
            Console.SetOut(writer);
            fuzzClass.FuzzMe(input);
            var output = writer.ToString();

            // Assert
            Assert.Contains("Parsed number: 0", output);
            Assert.Contains("Result after multiplication: 0", output);
            Assert.Contains("Result after division: 0", output);
            Assert.Contains("Result after addition: 100", output);
            Assert.Contains("Result after subtraction: -50", output);
            Assert.DoesNotContain("Unexpected result", output); // Additional check
        }
    }
}