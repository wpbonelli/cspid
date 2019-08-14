using Xunit;
using FluentAssertions;

namespace CSpid.Tests
{
    public class InclusiveRangeTest
    {
        [Theory]
        [InlineData(0, 1, 1)]
        [InlineData(0, 1, 0)]
        [InlineData(0, 2, 1)]
        public void ContainsValue_WhenDoes_ReturnsTrue(int minimum, int maximum, int value)
        {
            new Range<double>(minimum, maximum).Contains(value).Should().BeTrue();
        }

        [Theory]
        [InlineData(0, 1, 2)]
        [InlineData(0, 1, -1)]
        public void ContainsValue_WhenDoesNot_ReturnsFalse(int minimum, int maximum, int value)
        {
            new Range<double>(minimum, maximum).Contains(value).Should().BeFalse();
        }

        [Theory]
        [InlineData(0, 1, -999, 0)]
        [InlineData(-1000, 1, -1000, 1)]
        public void ContainsRange_WhenDoes_ReturnsTrue(int minimum, int maximum, int otherMinimum, int otherMaximum)
        {
            new Range<double>(minimum, maximum).Contains(new Range<double>(otherMinimum, otherMaximum)).Should().BeTrue();
        }

        [Theory]
        [InlineData(-999, 0, -1000, 1)]
        [InlineData(-1000, 1, -1000, 2)]
        public void ContainsRange_WhenDoesNot_ReturnsFalse(int minimum, int maximum, int otherMinimum, int otherMaximum)
        {
            new Range<double>(minimum, maximum).Contains(new Range<double>(otherMinimum, otherMaximum)).Should().BeFalse();
        }

        [Theory]
        [InlineData(-999, 0, -1000, 1)]
        [InlineData(-1000, 1, -1000, 1)]
        public void IsContainedByRange_WhenIs_ReturnsTrue(int minimum, int maximum, int otherMinimum, int otherMaximum)
        {
            new Range<double>(minimum, maximum).IsContainedBy(new Range<double>(otherMinimum, otherMaximum)).Should().BeTrue();
        }

        [Theory]
        [InlineData(-1000, 1, -999, 0)]
        [InlineData(-1000, 2, -1000, 1)]
        public void IsContainedByRange_WhenIsNot_ReturnsFalse(int minimum, int maximum, int otherMinimum, int otherMaximum)
        {
            new Range<double>(minimum, maximum).IsContainedBy(new Range<double>(otherMinimum, otherMaximum)).Should().BeFalse();
        }
    }
}
