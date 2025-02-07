using System;
using Xunit;
using FuzzLib;

namespace FuzzLib.Tests
{
    public class StringManipulationTests
    {
        [Fact]
        public void Reverse_InputIsNull_ShouldReturnNull()
        {
            var manipulator = new StringManipulation();
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            var result = manipulator.Reverse(null);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            Assert.Null(result);
        }

        [Fact]
        public void Reverse_InputIsEmpty_ShouldReturnEmpty()
        {
            var manipulator = new StringManipulation();
            var result = manipulator.Reverse(string.Empty);
            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void Reverse_InputIsNotEmpty_ShouldReturnReversedString()
        {
            var manipulator = new StringManipulation();
            var result = manipulator.Reverse("hello");
            Assert.Equal("olleh", result);
        }

        [Fact]
        public void ToUpperCase_ShouldReturnUpperCaseString()
        {
            var manipulator = new StringManipulation();
            var result = manipulator.ToUpperCase("hello");
            Assert.Equal("HELLO", result);
        }

        [Fact]
        public void Concatenate_ShouldReturnConcatenatedString()
        {
            var manipulator = new StringManipulation();
            var result = manipulator.Concatenate("hello", "world");
            Assert.Equal("helloworld", result);
        }

        [Fact]
        public void ContainsSubstring_ShouldReturnTrueIfContains()
        {
            var manipulator = new StringManipulation();
            var result = manipulator.ContainsSubstring("hello world", "world");
            Assert.True(result);
        }

        [Fact]
        public void ContainsSubstring_ShouldReturnFalseIfNotContains()
        {
            var manipulator = new StringManipulation();
            var result = manipulator.ContainsSubstring("hello world", "test");
            Assert.False(result);
        }
    }
}