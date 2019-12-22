using System;
using WriteFibonacciRange;
using Xunit;

namespace WriteFibonacciRangeTests
{
    public class FibonacciRangeTests
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(3, 2)]
        [InlineData(7, 13)]
        [InlineData(11, 89)]
        [InlineData(43, 433494437)]
        [InlineData(45, 1134903170)]
        public void IndexatorTestWithCorrectInput(int iteration, int expected)
        {
            FibonacciSequence range = new FibonacciSequence();
            int actual;

            actual = range[iteration];

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-3)]
        [InlineData(-13)]
        [InlineData(-901)]
        [InlineData(48)]
        [InlineData(70)]
        public void IndexatorThrowExeptionTest(int iteration)
        {
            FibonacciSequence range = new FibonacciSequence();
            int actual;

            Assert.Throws<IndexOutOfRangeException>(() => actual = range[iteration]);
        }
    }
}
