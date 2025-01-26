namespace FuzzLib {
    public interface IArithmeticOperations {
        int Add(int value);
        void AssignValue(int value);
        int CheckedSubtract(int value);
        void Decrement();
        int Divide(int value);
        int GetValue();
        void SetValue(int value);
        void Increment();
        int Modulo(int value);
        int Multiply(int value);
        int Subtract(int value);
    }
}