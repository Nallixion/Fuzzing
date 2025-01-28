using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzLib.Tests {
    public class ArithmeticOperationsTests {
        [Fact]
        public void TestAdd() {
            ArithmeticOperations operations = new ArithmeticOperations(100);
            int result = operations.Add(50);
            Assert.Equal(150, result); // Good practice, but input change may not alter outcome
        }


        [Theory]
        [InlineData(1, 2, -1)]
        [InlineData(-4, -6, 2)]
        [InlineData(-2, 2, -4)]
        [InlineData(int.MinValue, 1, int.MaxValue)]
        public void TheorySubtract(int value1, int value2, int expected) {
            ArithmeticOperations operations = new ArithmeticOperations(value1);
            int result = operations.Subtract(value2);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, 2, -1)]
        [InlineData(-4, -6, 2)]
        [InlineData(-2, 2, -4)]
        [InlineData(1, 0, 1)]
        [InlineData(int.MinValue, 1, int.MaxValue)]
        public void TheoryCheckedSubtract(int value1, int value2, int expected) {
            ArithmeticOperations operations = new ArithmeticOperations(value1);
            int result = operations.CheckedSubtract(value2);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestSubtractUnderflow() {
            ArithmeticOperations operations = new ArithmeticOperations(int.MinValue);
            int result = operations.Subtract(50);
            Assert.Equal(2147483598, result);
        }

        [Fact]
        public void TestCheckedSubtractUnderflow() {
            ArithmeticOperations operations = new ArithmeticOperations(int.MinValue);

            Assert.Throws<OverflowException>(() => operations.CheckedSubtract(50));
        }

        [Fact]
        public void TestMultiply() {
            ArithmeticOperations operations = new ArithmeticOperations(100);
            int result = operations.Multiply(2);
            Assert.Equal(200, result);
        }

        [Fact]
        public void TestDivide() {
            ArithmeticOperations operations = new ArithmeticOperations(100);
            int result = operations.Divide(2);
            Assert.Equal(50, result); // No check for division by zero
        }
        [Fact]
        public void TestModulo() {
            ArithmeticOperations operations = new ArithmeticOperations(100);
            int result = operations.Modulo(3);
            Assert.Equal(1, result);
        }

        [Fact]
        public void TestAssignValue() {
            ArithmeticOperations operations = new ArithmeticOperations(100);
            operations.AssignValue(1000);
            Assert.Equal(1000, operations.GetValue()); // No validation of input value
        }

        [Fact]
        public void TestIncrement() {
            ArithmeticOperations operations = new ArithmeticOperations(int.MaxValue);
            operations.Increment();
            Assert.Equal(int.MinValue, operations.GetValue()); // Overflow not handled
        }

        [Fact]
        public void TestDecrement() {
            ArithmeticOperations operations = new ArithmeticOperations(int.MinValue);
            operations.Decrement();
            Assert.Equal(int.MaxValue, operations.GetValue()); // Underflow not handled
        }
    }
}
