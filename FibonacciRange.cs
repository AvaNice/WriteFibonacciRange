using System;

namespace WriteFibonacciRange
{
    public class FibonacciRange : IRange
    {
        private const double SQUARE_ROOT_OF_FIVE = 2.2360679775;

        public int GetIteration(int iteration)
        {
            if(iteration < 0)
            {
                throw new ArgumentException("Iteration can't be negative");
            }

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
