namespace CSPID
{
    public interface IController
    {
        double ProportionalGain { get; set; }

        double IntegralGain { get; set; }

        double DerivativeGain { get; set; }

        double Next(double error, double elapsed);
    }
}
