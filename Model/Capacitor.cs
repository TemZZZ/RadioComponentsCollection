using System;
using System.Numerics;


namespace Model
{
	namespace PassiveComponents
	{
		/// <summary>
		/// Класс конденсатора
		/// </summary>
		public class Capacitor : RadioComponentBase
		{
			/// <summary>
			/// Создает экземпляр класса <see cref="Capacitor"/>
			/// </summary>
			public Capacitor() : base(0) { }

			/// <summary>
			/// Создает экземпляр класса <see cref="Capacitor"/>
			/// </summary>
			/// <param name="value">Значение емкости в фарадах</param>
			public Capacitor(double value) : base(value) { }

			/// <inheritdoc/>
			protected override Complex CalcImpedance(double freq)
			{
				const double zeroRealPart = 0;

				if (freq == 0)
				{
					return new Complex(zeroRealPart,
						double.NegativeInfinity);
				}

				return new Complex(zeroRealPart,
					-1 / (2 * Math.PI * freq * Value));
			}

			/// <inheritdoc/>
			public override string Unit { get => "Ф"; }
			/// <inheritdoc/>
			public override string Type { get => "Конденсатор"; }
			/// <inheritdoc/>
			public override string Quantity { get => "Емкость"; }
		}
	}
}
