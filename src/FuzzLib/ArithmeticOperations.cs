using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzLib {
    public class ArithmeticOperations {
        private int number;

        public ArithmeticOperations(int initialNumber) {
            number = initialNumber;
        }

        public int Add(int value) {
            // Error: No check if value is too large (may cause overflow)
            return number + value;
        }

        public int Subtract(int value) {
            // Error: No check if value is too large (may cause underflow)
            return number - value;
        }

        public int CheckedSubtract(int value) {
            // Error: No check if value is too large (may cause underflow)
            return checked(number - value);
        }

        public int Multiply(int value) {
            // Error: No check for multiplication overflow
            return number * value;
        }

        public int Divide(int value) {
            // Error: No check for division by zero
            return number / value;
        }
        public int Modulo(int value) {
            // Error: No check for modulo by zero
            return number % value;
        }

        public void AssignValue(int value) {
            // No validation of input value
            number = value;
        }

        public int GetValue() {
            return number;
        }

        public void Increment() {
            // Error: No check if increment causes overflow
            number++;
        }

        public void Decrement() {
            // Error: No check if decrement causes underflow
            number--;
        }
    }
}
