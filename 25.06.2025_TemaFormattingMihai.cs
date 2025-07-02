// See https://aka.ms/new-console-template for more information
using System.Globalization;

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
