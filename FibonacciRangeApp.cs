using System.Collections.Generic;

namespace WriteFibonacciRange
{
    class FibonacciRangeApp
    {
        private readonly FibonacciRange _fibonacciRange = new FibonacciRange();

        public IEnumerable<int> GetRange(int from, int upTo)
        {
            return _fibonacciRange.GetRange(from, upTo);
        }
    }
}
