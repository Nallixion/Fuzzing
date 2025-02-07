// See https://aka.ms/new-console-template for more information
using FuzzLib;

internal class Program {
    private static void Main(string[] args) {
        Console.WriteLine("Hello, World!");

        // Example inputs for fuzz testing 
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        string[] testInputs = { "123.45", "abc", "0", "-456.78", "1.7976931348623157E+308", null };
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        var fuzzClass = new FuzzClass();

        foreach (var input in testInputs) {
            Console.WriteLine("Testing input: " + input);
            fuzzClass.FuzzMe(input);
            Console.WriteLine();
        }
    }
}