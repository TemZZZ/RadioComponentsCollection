using System;


namespace Lab1Model
{
	namespace PassiveComponents
	{
		public class Inductor : ComponentBase
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
	}
}
