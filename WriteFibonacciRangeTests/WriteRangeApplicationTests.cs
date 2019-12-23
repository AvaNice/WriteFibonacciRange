using WriteFibonacciRange;
using Xunit;

namespace WriteFibonacciRangeTests
{
    public class WriteRangeApplicationTests
    {
        [Theory]
        [InlineData(0, 9, "1, 1, 2, 3, 5, 8.")]
        [InlineData(2, 8, "3, 5.")]
        [InlineData(10, 150, "13, 21, 34, 55, 89, 144.")]
        [InlineData(300, 1600, "377, 610, 987, 1597.")]
        public void WriteRangeNotEmptyRangeTest(int from, int upTo, string expected)
        {
            string actual = string.Empty;
            IRange range = new FibonacciSequence();
            TestUI userInterface = new TestUI();

            WriteRangeApplication application 
                = new WriteRangeApplication(userInterface, range);

            application.WriteRange(from, upTo);

            actual = userInterface.Output;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 0, TextMessages.EMPTY)]
        [InlineData(2, -2, TextMessages.EMPTY)]
        [InlineData(10, 10, TextMessages.EMPTY)]
        [InlineData(1597, 2584, TextMessages.EMPTY)]
        public void WriteRangeForEmptyRangeTest(int from, int upTo, string expected)
        {
            string actual = string.Empty;
            IRange range = new FibonacciSequence();
            TestUI userInterface = new TestUI();

            WriteRangeApplication application
                = new WriteRangeApplication(userInterface, range);

            application.WriteRange(from, upTo);

            actual = userInterface.Output;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WriteRangeUpToIntMaxValueTest()
        {
            int from = 701408733;
            int upTo = int.MaxValue;
            string expected = "1134903170, 1836311903.";
            string actual = string.Empty;
            IRange range = new FibonacciSequence();
            TestUI userInterface = new TestUI();

            WriteRangeApplication application
                = new WriteRangeApplication(userInterface, range);

            application.WriteRange(from, upTo);

            actual = userInterface.Output;

            Assert.Equal(expected, actual);
        }
    }
}
