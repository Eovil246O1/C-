using System;
using System.Numerics;
using static System.Console;
using static System.Math;

namespace NumberToTextConverter
{
    public static class NumberToTextConverter
    {
        public static string ToWords<T>(this T input)
        {
            string number = input.ToString();

            string[] ones = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            string[] tens = { "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
            string[] levels = { "hundereds", "thousands", "millions", "billions", "trillions" };
            string[] specialCases = { "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };

            int i = 0;
            int a = 0;
            string res = "";

            string[] numbers = new string[3];
            string[] chunks = new string[(int)Ceiling((decimal)number.Length / 3)];

            do
            {
                chunks[i] = number.Substring(Max(number.Length - 3, 0), Min(3, number.Length));
                number = number.Substring(0, number.Length - Min(3, number.Length));
                i++;
            }
            while (number.Length >= 3);
            if (number.Length != 0) chunks[i] = number;

            foreach (string chunk in chunks)
            {
                i = 0;
                res = "";
                Array.Clear(numbers);
                foreach (char letter in chunk.Reverse())
                {
                    numbers[i] = letter.ToString();
                    i++;
                }

                if ((numbers.ElementAtOrDefault(2) ?? "0") != "0") res += ones[int.Parse(numbers[2]) - 1] + " " + levels[0] + " ";
                if ((numbers.ElementAtOrDefault(1) ?? "0") != "0") res += tens[int.Parse(numbers[1]) - 1] + " ";
                if (int.Parse(numbers[0]) != 0) res += ones[int.Parse(numbers[0]) - 1] + " ";
                if (a != 0) res += levels[a] + " and ";

                chunks[a] = res;
                a++;
            }

            Array.Reverse(chunks);

            i = 0;
            res = "";
            foreach (string chunk in chunks)
            {
                res += chunks[i];
                i++;
            }

            // Replace special cases
            for (a = 0; a < ones.Length; a++)
            {
                res = res.Replace(tens[0] + " " + ones[a], specialCases[a]);
            }


            for (i = 0; i < levels.Length; i++)
            {
                number = ones[0] + " " + levels[i];
                res = res.Replace(number, number.Remove(number.Length - 1));
            }

            return res;
        }
    }
}