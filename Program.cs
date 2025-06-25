// See https://aka.ms/new-console-template for more information
using System.Globalization;

string name = "Mihai";
int age = 22;
/*Console.WriteLine($"Hello, {name}. You are {age} years old.");
Console.WriteLine($"{{Your age is {age} years old.}}");
Console.WriteLine("Hello, my name is {0} and I am {1} years old.", name, age);
double price = 1023.456;
CultureInfo culture = new CultureInfo("en-ES");
Console.WriteLine($"The price is {1234.012.ToString("N2", culture)}");
Console.WriteLine(price.ToString("E2"));
Console.WriteLine(price.ToString("F2"));
Console.WriteLine(price.ToString("G2"));
Console.WriteLine(price.ToString("N2"));
Console.WriteLine(price.ToString("P3"));
Console.WriteLine(price.ToString("R"));

int integerNumber = 123456;
string binary = Convert.ToString(integerNumber, 2);
Console.WriteLine(binary);
Console.WriteLine(integerNumber.ToString("00,000,000.00"));
*/


int error = 334;
string VarType = "stalled";
Console.Write("Error {0}: ", error);
Console.WriteLine($"Variable 'VarType' is of '{VarType}' type and must be 'ready', 'busy', or 'error', ");


int error_1 = 222;
string user = "unknown";
Console.Write($"Error {error_1}: ");
Console.WriteLine("Variable 'user' is of '{0}' type and must be 'admin', 'operator' or 'viewer'.", user);


int error_2 = 4473;
string var = "dangerous";
Console.Write($"Error {error_2}: ");
Console.WriteLine($"Variable 'var' is of '{var}' type and must be 'normal', 'debug', 'safe'.");
