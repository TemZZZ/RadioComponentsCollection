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
			/// <summary>
			/// Создается экземпляр класса <see cref="Inductor"></see>
			/// </summary>
			public Inductor() : base(0) { }

			/// <summary>
			/// Создается экземпляр класса <see cref="Inductor"></see>
			/// </summary>
			/// <param name="value">Значение индуктивности в генри</param>
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
