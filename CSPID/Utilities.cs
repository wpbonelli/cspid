using System;

namespace CSPID
{
    internal static class Utilities
    {
        internal static double Scale(this double value, double minimum, double maximum, double targetMinimum, double targetMaximum)
        {
            return value.Scale(new Range<double>(minimum, maximum), new Range<double>(targetMinimum, targetMaximum));
        }

        internal static double Scale(this double value, Range<double> range, Range<double> targetRange)
        {
            if (value < range.Minimum || value > range.Maximum)
                throw new ArgumentOutOfRangeException($"Expected {nameof(value)} to fall within {nameof(range)}");

            return targetRange.Minimum + (value - range.Minimum) / (range.Maximum - range.Minimum) * (targetRange.Maximum - targetRange.Minimum);
        }

        internal static double Clamp(this double value, double minimum, double maximum)
        {
            return value.Clamp(new Range<double>(minimum, maximum));
        }

        internal static double Clamp(this double value, Range<double> range)
        {
            return value < range.Minimum ? range.Minimum : value > range.Maximum ? range.Maximum : value;
        }

        internal static double ClampToMaximumStep(this double current, double previous, double maximumStep)
        {
            if (maximumStep <= 0)
                throw new ArgumentOutOfRangeException($"Expected {nameof(maximumStep)} to be greater than or equal to 0");

            if (current - previous > maximumStep) return previous + maximumStep;
            if (previous - current > maximumStep) return previous - maximumStep;
            return current;
        }
    }
}
