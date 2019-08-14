using System;

#pragma warning disable RECS0017 // Possible compare of value type with 'null'
namespace CSPID
{
    public struct Range<T> where T : IComparable<T>
    {
        public T Minimum { get; }

        public T Maximum { get; }

        public Range(T minimum, T maximum)
        {
            if (minimum == null)
                throw new ArgumentNullException(nameof(minimum));

            if (maximum == null)
                throw new ArgumentNullException(nameof(minimum));

            if (minimum.CompareTo(maximum) > 0)
                throw new ArgumentException($"Expected {nameof(minimum)} to be less than or equal to {nameof(maximum)}");

            Minimum = minimum;
            Maximum = maximum;
        }

        public bool Contains(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            return Minimum.CompareTo(value) <= 0 && value.CompareTo(Maximum) <= 0;
        }

        public bool Contains(Range<T> range)
        {
            return Contains(range.Minimum) && Contains(range.Maximum);
        }

        public bool IsContainedBy(Range<T> range)
        {
            return range.Contains(Minimum) && range.Contains(Maximum);
        }
    }
}
