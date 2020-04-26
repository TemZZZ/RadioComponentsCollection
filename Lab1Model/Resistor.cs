namespace Lab1Model
{
	namespace PassiveComponents
	{
		/// <summary>
		/// Класс резистора
		/// </summary>
		public class Resistor : ComponentBase
		{
			public Resistor() : base(0) { }
			public Resistor(double value) : base(value) { }

			protected override double CalcImpedance(double freq)
			{
				return Value;
			}

			/// <summary>
			/// Возвращает сопротивление резистора
			/// </summary>
			/// <returns>Сопротивление в омах</returns>
			public double GetImpedance()
			{
				return Value;
			}

			/// <summary>
			/// Возвращает строковое представление объекта
			/// </summary>
			/// <returns>Строка вида "Resistance = {R} ohms"</returns>
			public override string ToString()
			{
				return $"Resistance = {Value} ohms";
			}
		}
	}
}
