﻿using System;

namespace CSPID
{
    public class Controller : IController
    {
        private readonly Range<double> _unitRange = new Range<double>(-1, 1);
        private readonly Range<double> _errorRange;
        private readonly Range<double> _controlRange;

        private readonly object _lock = new object();
        private readonly double _maximumStep;

        private double _integrator;

        private double _previousError;
        private double _previousControl;

        private double _proportionalGain;
        private double _integralGain;
        private double _derivativeGain;

        public double ProportionalGain
        {
            get { return _proportionalGain; }
            set { lock (_lock) _proportionalGain = value; }
        }

        public double IntegralGain
        {
            get { return _integralGain; }
            set { lock (_lock) _integralGain = value; }
        }

        public double DerivativeGain
        {
            get { return _derivativeGain; }
            set { lock (_lock) _derivativeGain = value; }
        }

        public Controller(
            double minimumError,
            double maximumError,
            double minimumControl,
            double maximumControl,
            double maximumStep)
        {
            if (maximumStep < 0)
                throw new ArgumentOutOfRangeException($"Expected {nameof(maximumStep)} to be greater than 0");

            _errorRange = new Range<double>(minimumError, maximumError);
            _controlRange = new Range<double>(minimumControl, maximumControl);
            _maximumStep = maximumStep;
        }

        public double Next(double error, double elapsed)
        {
            double control;

            lock (_lock)
            {
                error = error.Clamp(_errorRange).Scale(_errorRange, _unitRange);

                _integrator += _integralGain * error * elapsed;
                _integrator = _integrator.Clamp(_controlRange);

                control = (_proportionalGain * error + _integrator + _derivativeGain * ((error - _previousError) / elapsed))
                    .Clamp(_unitRange).Scale(_unitRange, _controlRange)
                    .ClampToMaximumStep(_previousControl, _maximumStep);

                _previousControl = control;
                _previousError = error;
            }

            return control;
        }
    }
}
