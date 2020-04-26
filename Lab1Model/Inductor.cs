using System;


namespace Lab1Model
{
	namespace PassiveComponents
	{
		/// <summary>
		/// Класс катушки индуктивности
		/// </summary>
		public class Inductor : ComponentBase
		{
			public Inductor() : base(0) { }
			public Inductor(double value) : base(value) { }

			protected override double CalcImpedance(double freq)
			{
				return 2 * Math.PI * freq * Value;
			}

			/// <summary>
			/// Возвращает строковое представление объекта
			/// </summary>
			/// <returns>Строка вида "Inductance = {L} henries"</returns>
			public override string ToString()
			{
				return $"Inductance = {Value} henries";
			}
		}
	}
}
