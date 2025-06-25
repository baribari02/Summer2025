
//Exemplu 1
//if (deviceState.Trim().ToLower() == "ready" ||
//    deviceState.Trim().ToLower() == "busy" ||
//    deviceState.Trim().ToLower() == "error")
//{
//    // Device state is valid
//}
//else
//{
//    TheExec.Datalog.WriteComment("Variable 'deviceState' must be 'ready', 'busy' or 'error'");
//    return tlResult_Module.TL_ERROR;
//}

int error = 0;
string deviceState = "disconnected";
Console.WriteLine($"Error {error}");
Console.WriteLine($"Variable 'deviceState' is {deviceState} and should be of type ready, busy or error");

//Exemplu 2
//if (userRole.Trim().ToLower() == "admin" ||
//    userRole.Trim().ToLower() == "operator" ||
//    userRole.Trim().ToLower() == "viewer")
//{
//    // Role is valid
//}
//else
//{
//    TheExec.Datalog.WriteComment("Variable 'userRole' must be 'admin', 'operator' or 'viewer'");
//    return tlResult_Module.TL_ERROR;
//}

int error = 0;
string userRole = "guest";
Console.WriteLine($"Error {error}");
Console.WriteLine($"Variable 'userRole' is {userRole} and should be of type admin, operator or viewer");


//Exemplu 3
//if (testMode.Trim().ToLower() == "normal" ||
//    testMode.Trim().ToLower() == "debug" ||
//    testMode.Trim().ToLower() == "safe")
//{
//    // Do nothing
//}
//else
//{
//    TheExec.Datalog.WriteComment("Variable 'testMode' must be 'normal', 'debug' or 'safe'");
//    return tlResult_Module.TL_ERROR;
//}

int error = 0;
string testMode = "calibration";
Console.WriteLine($"Error {error}");
Console.WriteLine($"Variable 'testMode' is {testMode} and should be of type normal, debug or safe");
