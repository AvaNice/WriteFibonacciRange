using System.Collections.Generic;

namespace WriteFibonacciRange
{
    class FibonacciRangeApp
    {
        private readonly FibonacciRange _fibonacciRange = new FibonacciRange();
        private readonly WriteFibonacciUI _userInterface;

        public FibonacciRangeApp(WriteFibonacciUI userInterface)
        {
            _userInterface = userInterface;
        }

        public IEnumerable<int> GetRange(int from, int upTo)
        {
            return _fibonacciRange.GetRange(from, upTo);
        }

        public void WriteFibonacciNumber(int from, int upTo)
        {
            int fibonacciNumber;

            for (int index = 0; ; index++)
            {
                fibonacciNumber = _fibonacciRange.GetFibonacciIteration(index);

                if (fibonacciNumber > upTo)
                {
                    break;
                }

                if (fibonacciNumber > from)
                {
                    _userInterface.ShowResult(fibonacciNumber.ToString());
                }
            }

        }
    }
}
