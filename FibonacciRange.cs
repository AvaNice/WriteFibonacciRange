using System;
using System.Collections.Generic;

namespace WriteFibonacciRange
{
    class FibonacciRange
    {
        private const double SQUARE_ROOT_OF_FIVE = 2.2360679775;

        public IEnumerable<int> GetRange(int from, int upTo)
        {
            TwoNumber twoPrevious;

            twoPrevious = FindTwoPreviousFibonacci(from);

            int next = twoPrevious.First + twoPrevious.Second;
            int index = 0;
            int buffer = twoPrevious.Second;

            List<int> fibonacciRange = new List<int>();

            if (from == 0)
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

        public int GetFibonacciIteration(int iteration)
        {
            double result;

            result = (Math.Pow((1 + SQUARE_ROOT_OF_FIVE) / 2, iteration)
                - Math.Pow((1 - SQUARE_ROOT_OF_FIVE) / 2, iteration))
                / SQUARE_ROOT_OF_FIVE;

            try
            {
                return Convert.ToInt32(result);
            }
            catch (OverflowException ex)
            {
                return int.MaxValue;
            }
        }

        private TwoNumber FindTwoPreviousFibonacci(int number)
        {
            int next = 0;
            int first = 0;
            int second = 1;
            // 1773314929
            while (first + second > 0 && first + second <= number)
            {
                next = first + second;
                first = second;
                second = next;
            }

            return new TwoNumber(first, second);
        }

    }
}
