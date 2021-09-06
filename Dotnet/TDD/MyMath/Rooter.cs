using System;

namespace MyMath
{
    public class Rooter
    {
        public const string InputValueLessThanZeroMessage = "Input is less than zero";

        public Rooter() { }

        public double SquareRoot(double input)
        {
            if (input < 0.0)
            {
                throw new ArgumentOutOfRangeException(nameof(input), InputValueLessThanZeroMessage);
            }
            double result = input;
            double previousResult = -input;
            while (Math.Abs(previousResult - result) > result / 1000)
            {
                previousResult = result;
                result = result - (result * result - input) / (2 * result);
            }
            return result;
        }
    }
}
