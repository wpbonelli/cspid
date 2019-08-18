using System;
using System.Linq;
using Xunit;
using FluentAssertions;

namespace CSPID.Tests
{
    public class PIDControllerTest
    {
        [Fact]
        public void ProportionalControl()
        {
            int setPoint = 5,
                minimumError = -5,
                maximumError = 5,
                minimumControl = 0,
                maximumControl = 10;

            var controller = new PIDController(
                minimumError,
                maximumError,
                minimumControl,
                maximumControl)
            {
                ProportionalGain = 1,
                IntegralGain = 0,
                DerivativeGain = 0
            };

            var seed = Enumerable
                .Range(minimumControl, maximumControl - minimumControl + 1)
                .ToList();

            var expected = seed
                .Select(Convert.ToDouble)
                .Reverse()
                .ToList();

            var actual = seed
                .Select(value => Math.Round(controller.Next(setPoint - value, 1000)))
                .ToList();

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact(Skip = "TODO")]
        public void ProportionalIntegralControl()
        {

        }

        [Fact(Skip = "TODO")]
        public void ProportionalIntegralDerivativeControl()
        {

        }
    }
}
