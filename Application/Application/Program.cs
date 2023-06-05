using Arithmetic;

var op = new Operations();

string a = "548568575695458455874";
string b = "2584584582425845";
string p = "585555565";

Console.WriteLine($"a: {a}");
Console.WriteLine($"b: {b}");
Console.WriteLine();
Console.WriteLine($"a + b = {op.StringAddtion(a, b)}");
Console.WriteLine($"a * b = {op.Multiply(a, b)}");
Console.WriteLine($"a ^ 2 = {op.SquareElevation(a)}");
Console.WriteLine($"a mod p = {op.Modulo(a, p)}");
Console.WriteLine($"a ^ b mod p = {op.ModPowerStrings(a, b, p)}");



