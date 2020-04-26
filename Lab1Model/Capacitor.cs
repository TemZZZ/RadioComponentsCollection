using System;


namespace Lab1Model
{
	namespace PassiveComponents
	{
		/// <summary>
		/// Класс конденсатора
		/// </summary>
		public class Capacitor : ComponentBase
		{
			public Capacitor() : base(0) { }
			public Capacitor(double value) : base(value) { }

			protected override double CalcImpedance(double freq)
			{
				if (freq == 0)
				{
					return Double.NegativeInfinity;
				}

				return -1 / (2 * Math.PI * freq * Value);
			}

			/// <summary>
			/// Возвращает строковое представление объекта
			/// </summary>
			/// <returns>Строка вида "Capacitance = {C} farads"</returns>
			public override string ToString()
			{
				return $"Capacitance = {Value} farads";
			}
		}
	}
}
