public interface IComponent
{
    public double Value { get; set; }

    public double GetImpedance(double freq);
}
