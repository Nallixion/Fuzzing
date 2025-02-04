using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WinSharpFuzz.Tests {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello, World!");
            Fuzzer.LibFuzzer.Initialize(() => {
                // Initialize the library here
            });

            Fuzzer.LibFuzzer.Run(bytes => {
                try {
                    int input = BitConverter.ToInt32(bytes.Slice(0, 4));
                    FuzzLib.ArithmeticOperations arithmeticOperations = new FuzzLib.ArithmeticOperations();
                    arithmeticOperations.SetValue(input);
                    // pass input bytes to library functions here
                }
                catch (Exception) {
                    // Catch only exceptions that are meant to be thrown by the library
                }
            });

            Fuzzer.LibFuzzer.Cleanup(() => {
                // Call any cleanup functions on the library here 
            });
        }
    }
}
