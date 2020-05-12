using System;
using System.Numerics;


namespace Lab1Model
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
				if (freq == 0)
				{
					return new Complex(0, double.NegativeInfinity);
				}

				return new Complex(0, -1 / (2 * Math.PI * freq * Value));
			}

			private const string capacitorUnit = "Ф";
			private const string capacitorType = "Конденсатор";
			private const string capacitorQuantity = "Емкость";
			/// <inheritdoc/>
			public override string Unit { get => capacitorUnit; }
			/// <inheritdoc/>
			public override string Type { get => capacitorType; }
			/// <inheritdoc/>
			public override string Quantity { get => capacitorQuantity; }
		}
	}
}
