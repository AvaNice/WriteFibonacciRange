using System;

namespace WriteFibonacciRange
{
    public class FibonacciSequence : IRange
    {
        private const double SQUARE_ROOT_OF_FIVE = 2.2360679775;
        private const int LAST_INT_FIBONACCI_NUMBER = 47;

        public int Length { get; } = LAST_INT_FIBONACCI_NUMBER;

        public int this[int index]
        {
            get 
            {
                if (index < 0 || index > LAST_INT_FIBONACCI_NUMBER)
                {
                    throw new IndexOutOfRangeException();
                }

                return GetIteration(index); 
            }
        }

        private int GetIteration(int iteration)
        {
            double result;

            result = (Math.Pow((1 + SQUARE_ROOT_OF_FIVE) / 2, iteration)
                - Math.Pow((1 - SQUARE_ROOT_OF_FIVE) / 2, iteration))
                / SQUARE_ROOT_OF_FIVE;

            if (result > Convert.ToDouble(int.MaxValue))
            {
                return int.MaxValue;
            }

            return Convert.ToInt32(result);
        }
    }
}
