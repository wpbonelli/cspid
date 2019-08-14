# CSPID

CSPID (pronounced "speedy") is a C# PID (proportional-integral-derivative) controller targeting .NET Standard 2.0. You can find it on Nuget.org [here](https://www.nuget.org/packages/CSPID/).

## Usage

```csharp
var controller = new Controller(
    minimumError: -5,
    maximumError: 5,
    minimumControl: 0,
    maximumControl: 10,
    maximumStep: 1)
{
    ProportionalGain = 1,
    IntegralGain = 1,
    DerivativeGain = 1
};

var controlValue = controller.Next(error: 0.5, elapsed: 0.5);
```
