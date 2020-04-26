using System;


namespace Lab1Model
{
	namespace PassiveComponents
	{
		public class Capacitor : ComponentBase
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
}
