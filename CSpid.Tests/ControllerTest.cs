using System;
using System.Linq;
using Xunit;
using FluentAssertions;

namespace CSpid.Tests
{
    public class ControllerTest
    {
        [Fact]
        public void Proportional()
        {
            int setPoint = 5,
                errorMinimum = -5,
                errorMaximum = 5,
                controlMinimum = 0,
                controlMaximum = 10;
            var controlValues = Enumerable.Range(0, 11);
            var controller = new Controller(
                errorMinimum,
                errorMaximum,
                controlMinimum,
                controlMaximum,
                double.MaxValue)
            {
                ProportionalGain = 1,
                IntegralGain = 0,
                DerivativeGain = 0
            };

            var expectedValues = Enumerable
                .Range(controlMinimum, controlMaximum - controlMinimum + 1)
                .Select(Convert.ToDouble)
                .Reverse()
                .ToList();

            var actualValues = Enumerable
                .Range(controlMinimum, controlMaximum - controlMinimum + 1)
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
