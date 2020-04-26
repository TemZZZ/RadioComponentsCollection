namespace PassiveComponents
{
	public class Resistor : ComponentBase
	{
		public Resistor() { Value = 0; }
		public Resistor(double value) { Value = value; }

		protected override double CalcImpedance(double freq)
		{
			return Value;
		}

		public double GetImpedance()
		{
			return Value;
		}

		public override string ToString()
		{
			return $"Resistance = {Value} ohms";
		}
	}
}