using System.Collections.Generic;

namespace WriteFibonacciRange
{
    class FibonacciRange
    {
        public List<int> GetRange(int from, int upTo)
        {
            TwoNumber twoPrevious;

            twoPrevious = FindTwoPreviousFibonacci(from);

            int next = twoPrevious.First + twoPrevious.Second;
            int index = 0;
            int buffer = twoPrevious.Second;

            List<int> fibonacciRange = new List<int>();

            if(from == 0)
            {
                fibonacciRange.Add(1);
            }

            while (next < upTo)
            {
                fibonacciRange.Add(next);
                next = buffer + next;
                buffer = fibonacciRange[index];
                index++;
            }

            return fibonacciRange;
        }

        private TwoNumber FindTwoPreviousFibonacci(int number)
        {
            int next = 0;
            int first = 0;
            int second = 1;

            while (first + second <= number)
            {
                next = first + second;
                first = second;
                second = next;
            }

            return new TwoNumber(first, second);
        }

    }
}
