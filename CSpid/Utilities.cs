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

        internal static double ClampToMaxStep(this double current, double previous, double maxStep)
        {
            if (maxStep <= 0)
                throw new ArgumentOutOfRangeException($"Expected {nameof(maxStep)} to be greater than 0");

            if (current - previous > maxStep) return previous + maxStep;
            if (previous - current > maxStep) return previous - maxStep;
            return current;
        }
    }
}
