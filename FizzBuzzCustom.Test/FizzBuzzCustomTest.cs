using FizzBuzzCustom.Model;
using System;
using System.Collections.Generic;
using Xunit;

namespace FizzBuzzCustom.Test
{
    /// <summary>
    /// Custom Fizz Buzz Unit Tests
    /// </summary>
    public class FizzBuzzCustomTest
    {
        private enum FizzBuzz_Type
        {
            Basic,
            Custom
        };

        private ICustomFizzBuzz _fizzBuzz_Custom;

        private void SetFizzBuzzCustomObject(FizzBuzz_Type type)
        {
            if (type == FizzBuzz_Type.Basic)
            {
                _fizzBuzz_Custom = new CustomFizzBuzz();
            }
            else
            {
                _fizzBuzz_Custom = new CustomFizzBuzz(new List<DivisorAndToken>() {
                                                        new DivisorAndToken(4, "Mario"),
                                                        new DivisorAndToken(13, "Luigi" ),
                                                        new DivisorAndToken(9, "Peach")});
            }
        }

        /// <summary>
        /// Basic Fizz Buzz Test(s)
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="result"></param>
        [Theory]
        [InlineData(1, "1")]
        [InlineData(3, "Fizz")]
        [InlineData(5, "Buzz")]
        [InlineData(15, "FizzBuzz")]
        public void Basic_FizzBuzz_Test(int dividend, string result)
        {
            SetFizzBuzzCustomObject(FizzBuzz_Type.Basic);

            string response = _fizzBuzz_Custom.Process(dividend);

            Assert.Equal(response, result);
        }

        /// <summary>
        /// Custom Divisor Token Test(s)
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="result"></param>
        [Theory]
        [InlineData(52, "MarioLuigi")]
        [InlineData(36, "MarioPeach")]
        [InlineData(468, "MarioLuigiPeach")]
        [InlineData(2, "2")]
        [InlineData(4, "Mario")]
        [InlineData(13, "Luigi")]
        [InlineData(9, "Peach")]
        public void Custom_FizzBuzz_Test(int dividend, string result)
        {
            SetFizzBuzzCustomObject(FizzBuzz_Type.Custom);

            Assert.Equal(_fizzBuzz_Custom.Process(dividend), result);
        }


        /// <summary>
        /// Check to ensure that a 0 divisor or a null token cannot be set as a token or a divisor
        /// </summary>
        /// <param name="divisor"></param>
        /// <param name="token"></param>
        [Theory]
        [InlineData(0, "Fizz")]
        [InlineData(3, null)]
        public void Invalid_Divisor_Or_Token_Check(int divisor, string token)
        {
            Assert.Throws<InvalidProgramException>(() => new DivisorAndToken(divisor, token));
        }

        /// <summary>
        /// Ensure when setting the custom list of divisors and tokens that a null value is handled
        /// </summary>
        [Fact]
        public void Invalid_FizzBuzzCustom_Token_And_Divisors_List()
        {
            Assert.Throws<InvalidProgramException>(() => _fizzBuzz_Custom = new CustomFizzBuzz(null));
        }

    }
}
