//using Microsoft.AspNetCore.Rewrite.Internal;
using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
//using System.Reactive;

namespace TestPassword
{
    class Program
    {
        static void Main(string[] args)
        {
            //output is the requirement of the program
            int output=-1;
            
            Console.WriteLine("Enter password");
            String s = Convert.ToString((Console.ReadLine()));

            //sameChar is to test if the string has all same characters
            bool sameChar=true;
            for (int i = 1; i < s.Length; i++)
                if (s[i] != s[0])
                    sameChar= false;

            //notRepeat is to test whether the string has non-repeating characters
            //var notRepeat = !s.Where((c, i) => i >= 2 && s[i - 1] == c && s[i-2]==c).Any();
          

           

            var notRepeat = true;
            for (int i = 0; i < s.Length - 3; i++)
                if (s[i] == s[i + 1] && s[i] == s[i + 2] && s[i] == s[i+3])
                    notRepeat = false;

            //Console.WriteLine(s.Any(char.IsUpper));
            //Console.WriteLine(s.Any(char.IsLower));
            //Console.WriteLine(s.Any(char.IsDigit));

            int CounterUpper = 0;
            int CounterLower = 0;
            int CounterDigit = 0;

            byte[] asciiBytes = Encoding.ASCII.GetBytes(s);
            for (int i = 0; i < asciiBytes.Length; i++)
            {
                if (asciiBytes[i] > 64 && asciiBytes[i] < 91)
                    CounterUpper++;
            }

            //digits
            for (int i = 0; i < asciiBytes.Length; i++)
            {
                if (asciiBytes[i] > 48 && asciiBytes[i] < 57)
                    CounterDigit++;
            }

            for (int i = 0; i < asciiBytes.Length; i++)
            {
                if (asciiBytes[i] > 97 && asciiBytes[i] < 122)
                    CounterLower++;
            }

            if (s.Length == 1)
                output = 5;
            else if (s.Length >=6 && s.Length <= 20 && CounterUpper>0 && CounterLower>0 && CounterDigit>0 && notRepeat)
                output = 0;
            else if (s.Length == 2)
                output = 4;
            else if (s.Length == 3)
                if (notRepeat)
                    output = 3;
                else
                    output = 4;
            else if (s.Length == 4)
                if (notRepeat)
                    if (s.Any(char.IsUpper) || s.Any(char.IsLower) || s.Any(char.IsDigit))
                        output = 2;
                    else
                        output = 3;
                else if (!notRepeat)
                    if (s.Any(char.IsUpper) || s.Any(char.IsLower) || s.Any(char.IsDigit))
                        output = 3;
                    else
                        output = 3;
                else if (s.Length == 5)
                    if (notRepeat)
                        if ((s.Any(char.IsUpper) && s.Any(char.IsDigit)) || (s.Any(char.IsDigit) && s.Any(char.IsLower)) || (s.Any(char.IsUpper) && s.Any(char.IsLower)))
                            output = 1;
                        else if (s.Any(char.IsUpper) || s.Any(char.IsLower) || s.Any(char.IsDigit))
                            output = 2;
                        else
                            output = 3;
                    if (!notRepeat)
                        if ((s.Any(char.IsUpper) && s.Any(char.IsDigit)) || (s.Any(char.IsDigit) && s.Any(char.IsLower)) || (s.Any(char.IsUpper) && s.Any(char.IsLower)))
                            output = 1;
                        else if (s.Any(char.IsUpper) || s.Any(char.IsLower) || s.Any(char.IsDigit))
                            output = 2;
                        else
                            output = 3;
                else if (s.Length >= 6 && s.Length <= 11 && sameChar)
                output = 3;
                else if (s.Length >= 12 && s.Length <= 14 && sameChar)
                output = 4;
                else if (s.Length >= 15 && s.Length <= 17 && sameChar)
                output = 5;
                else if (s.Length >= 18 && s.Length <= 20 && sameChar)
                output = 6;
                else if (s.Length == 7)
                    if (s.Any(char.IsUpper) || s.Any(char.IsLower) || s.Any(char.IsDigit))
                    output = 2;
                    else
                    output = 3;
                else if (s.Length > 7 && s.Length < 12)
                output = 3;
                else if (s.Length >= 12 && s.Length < 15)
                output = 4;
                else if (s.Length >= 15 && s.Length < 18)
                output = 5;
                else if (s.Length >= 18 && s.Length < 21)
                output = 6;

            Console.WriteLine(output);
            Console.ReadKey();


        }
    }
}
