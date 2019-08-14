using System;
using System.Linq;
using Xunit;
using FluentAssertions;

namespace CSPID.Tests
{
    public class ControllerTest
    {
        [Fact]
        public void Proportional()
        {
            int setPoint = 5,
                minimumError = -5,
                maximumError = 5,
                minimumControl = 0,
                maximumControl = 10;
            var controlValues = Enumerable.Range(0, 11);
            var controller = new Controller(
                minimumError,
                maximumError,
                minimumControl,
                maximumControl,
                double.MaxValue)
            {
                ProportionalGain = 1,
                IntegralGain = 0,
                DerivativeGain = 0
            };

            var expectedValues = Enumerable
                .Range(minimumControl, maximumControl - minimumControl + 1)
                .Select(Convert.ToDouble)
                .Reverse()
                .ToList();

            var actualValues = Enumerable
                .Range(minimumControl, maximumControl - minimumControl + 1)
                .Select(value => Math.Round(controller.Next(setPoint - value, 1000)))
                .ToList();

            actualValues.Should().BeEquivalentTo(expectedValues);
        }

        [Fact(Skip = "TODO")]
        public void ProportionalIntegral()
        {

        }

        [Fact(Skip = "TODO")]
        public void ProportionalIntegralDerivative()
        {

        }
    }
}
