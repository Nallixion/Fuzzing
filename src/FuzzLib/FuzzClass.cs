namespace FuzzLib;

public class FuzzClass
{
    public void FuzzMe(string input) 
    { 
        try { 
            // Convert input to integer 
            int number = int.Parse(input); 
            Console.WriteLine("Parsed number: " + number); 
            
            // Perform some arithmetic operations 
            int result = number * 2; 
            Console.WriteLine("Result after multiplication: " + result); 
            
            result = number / 2; 
            Console.WriteLine("Result after division: " + result); 
            
            result = number + 100; 
            Console.WriteLine("Result after addition: " + result); 
            
            result = number - 50; Console.WriteLine("Result after subtraction: " + result); 
            } 
        catch (FormatException) { 
            Console.WriteLine("Input is not a valid integer."); 
        } 
        catch (DivideByZeroException) { 
            Console.WriteLine("Division by zero occurred."); 
        } 
        catch (Exception ex) { 
            Console.WriteLine("An unexpected error occurred: " + ex.Message);
        }
    }
}
