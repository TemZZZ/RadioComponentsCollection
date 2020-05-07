using System;
using System.Numerics;


namespace Lab1Model
{
	namespace PassiveComponents
	{
		/// <summary>
		/// Класс конденсатора
		/// </summary>
		public class Capacitor : ComponentBase
		{
			/// <summary>
			/// Создается экземпляр класса <see cref="Capacitor"/>
			/// </summary>
			public Capacitor() : base(0) { }

			/// <summary>
			/// Создается экземпляр класса <see cref="Capacitor"/>
			/// </summary>
			/// <param name="value">Значение емкости в фарадах</param>
			public Capacitor(double value) : base(value) { }

			protected override Complex CalcImpedance(double freq)
			{
				if (freq == 0)
				{
					return new Complex(0, double.NegativeInfinity);
				}

				return new Complex(0, -1 / (2 * Math.PI * freq * Value));
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
