using System;
using System.Numerics;
using static System.Console;
using NumberToTextConverter;

Random rnd = new Random();
int num = rnd.Next();

WriteLine($"The random number is: {num}");
WriteLine($"It's conversion to word is: {num.ToWords()}");