using System;


namespace PassiveComponents
{
	public class Resistor : Component
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


	public class Inductor : Component
	{
		public Inductor() { Value = 0; }
		public Inductor(double value) { Value = value; }

		protected override double CalcImpedance(double freq)
		{
			return 2 * Math.PI * freq * Value;
		}

		public override string ToString()
		{
			return $"Inductance = {Value} henries";
		}
	}


	public class Capacitor : Component
	{
		public Capacitor() { Value = 0; }
		public Capacitor(double value) { Value = value; }

		protected override double CalcImpedance(double freq)
		{
			if (freq == 0)
			{
				return Double.NegativeInfinity;
			}

			return -1 / (2 * Math.PI * freq * Value);
		}

		public override string ToString()
		{
			return $"Capacitance = {Value} farads";
		}
	}
}
