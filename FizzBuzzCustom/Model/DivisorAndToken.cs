using System;

namespace FizzBuzzCustom.Model
{
    public class DivisorAndToken
    {
        public DivisorAndToken(int divisor, string token)
        {
            if (divisor == 0 || token == null)
                throw new InvalidProgramException("Invalid Divisor and//or Token Provided");

            Divisor = divisor;
            Token = token;
        }

        public int Divisor { get; private set; }

        public string Token { get; private set; }

    }
}
