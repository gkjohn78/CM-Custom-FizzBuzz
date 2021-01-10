using FizzBuzzCustom;
using FizzBuzzCustom.Model;
using System;
using System.Collections.Generic;

namespace FizzBuzz
{
    class Program
    {
        private static readonly List<DivisorAndToken> CustomDivisorsAndTokens = new List<DivisorAndToken>() {
                new DivisorAndToken(3, "Fizz"),
                new DivisorAndToken(5, "Buzz"),
                new DivisorAndToken(38, "Bazz")
        };

        static void Main(string[] args)
        {
            ICustomFizzBuzz fb = new CustomFizzBuzz(CustomDivisorsAndTokens);

            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine(fb.Process(i));
            }
            Console.ReadLine();
        }
    }
}
