// See https://aka.ms/new-console-template for more information
int error = 0;
string captureType = "capt";
Console.WriteLine($"Error {error}");
Console.WriteLine($"Variable 'captureType' is {captureType} and should be of type capstv, captfail or captnote");

int state = 0;
string deviceState = "waitting";
Console.WriteLine($"State {state}");
Console.WriteLine($"Variable 'deviceState' is {deviceState} and should be of type ready, busy or error");


int user = 0;
string userRole= "user";
Console.WriteLine($"User {user}");
Console.WriteLine($"Variable 'userRole' is {userRole} and should be of type admin, operator or viwer");

int test = 0;
string testMode = "testing";
Console.WriteLine($"Test {test}");
Console.WriteLine($"Variable 'testMode' is {testMode} and should be of type normal, debug or safe");

