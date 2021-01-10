using FizzBuzzCustom.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace FizzBuzzCustom
{
    /* 
    * 1. Pipeline the old implementation that froze
    * 2. Unit Testing and make sure that the 3 and 5 cases always works
    * 3. Make it so that developers can pass in own number of word pairs
    * 4. Extra Credit: Create a build script to publish for release
    */

    public class CustomFizzBuzz : ICustomFizzBuzz
    {
        private List<DivisorAndToken> DivisorAndTokenList { get; set; }

        public CustomFizzBuzz()
        {
            DivisorAndTokenList = new List<DivisorAndToken>
            {
                new DivisorAndToken(3, "Fizz"),
                new DivisorAndToken(5, "Buzz")
            };
        }

        public CustomFizzBuzz(List<DivisorAndToken> divisorAndTokenList)
        {
            DivisorAndTokenList = divisorAndTokenList ?? throw new InvalidProgramException("Invalid Divisors and Token Collection Provided");
        }

        public string Process(int dividend)
        {
            StringBuilder response = new StringBuilder();

            foreach (var divisorAndToken in DivisorAndTokenList)
            {
                if (dividend % divisorAndToken.Divisor == 0)
                    response.Append(divisorAndToken.Token);
            }

            if (!string.IsNullOrEmpty(response.ToString()))
                return response.ToString();

            return dividend.ToString(CultureInfo.InvariantCulture);
        }
    }
}
