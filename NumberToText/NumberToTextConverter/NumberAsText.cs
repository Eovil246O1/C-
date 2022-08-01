using System;
using System.Numerics;
using static System.Console;

namespace Excercise03
{
    public static class Excercise03
    {
        public static string ToWords<T>(this T input)
        {
            string number = input.ToString();

            string[] ones = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            string[] tens = { "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
            string[] levels = { "hundereds", "thousands", "millions", "billions", "trillions" };
            int i = 0;
            int a = 0;
            string res = "";
            string[] numbers = new string[number.Length];
            string[] chunks = new string[(int)Math.Ceiling((decimal)number.Length / 3)];
            string finres = "";

            do
            {
                chunks[i] = number.Substring(0, 3);
                number = number.Substring(3, number.Length - 3);
                i++;
            }
            while (number.Length >= 3);
            if (number.Length != 0) chunks[i] = number;

            foreach (string chunk in chunks)
            {
                i = 0;
                foreach (char letter in chunk.Reverse())
                {
                    if (i <= 2)
                    {
                        numbers[i] = letter.ToString();
                        i++;
                    }
                    // else if (i > 2 & i % 3 == 0)
                    // {
                    //     if (i != 3)
                    //     {
                    //         res = new string(res.Reverse().ToArray());
                    //         finres = finres + res + " " + levels[a] + ", ";
                    //     }
                    //     res = letter.ToString();
                    //     i++;
                    //     a++;
                    // }
                    // else
                    // {
                    //     res = res + letter;
                    //     if (i == number.Length - 1)
                    //     {
                    //         res = new string(res.Reverse().ToArray());
                    //         finres = finres + res + " " + levels[a] + ", ";
                    //     }
                    //     i++;
                    // }
                }
                finres += ones[int.Parse(numbers[2]) - 1] + " " + levels[0] + " " + tens[int.Parse(numbers[1]) - 1] + " " + ones[int.Parse(numbers[0]) - 1] + " and ";
                a++;
            }


            return finres;
        }
    }
}
