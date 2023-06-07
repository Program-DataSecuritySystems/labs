using Arithmetic;
using Generator;

//------------------lab 4.1

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
Console.WriteLine();

//------------------lab 4.2

var primeGenerator = new PrimeGenerator();
var generationResult = primeGenerator.GeneratePrime(6);
var approvementResult = primeGenerator.ApproveByFermatLittleTheorem(generationResult);
var answer = approvementResult ? "Yes" : "No";
Console.WriteLine($"Example of generated number: {generationResult}");
Console.WriteLine($"Approved? - {answer}");
generationResult = primeGenerator.GeneratePrime(7);
approvementResult = primeGenerator.ApproveByFermatLittleTheorem(generationResult);
answer = approvementResult ? "Yes" : "No";
Console.WriteLine($"Example of generated number: {generationResult}");
Console.WriteLine($"Approved? - {answer}");
