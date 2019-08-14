# CSPID

CSPID (pronounced "speedy") is a C# PID (proportional-integral-derivative) controller targeting .NET Standard 2.0.

## Usage

```csharp
var controller = new Controller(
    errorMinimum: -5,
    errorMaximum: 5,
    controlMinimum: 0,
    controlMaximum: 10,
    maximumStep: 1)
{
    ProportionalGain = 1,
    IntegralGain = 1,
    DerivativeGain = 1
};

var controlValue = controller.Next(error: 0.5, elapsed: 0.5);
```
