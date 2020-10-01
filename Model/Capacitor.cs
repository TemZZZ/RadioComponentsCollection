using System;
using System.Numerics;

namespace Model
{
	namespace PassiveComponents
	{
		/// <summary>
		/// Класс конденсатора
		/// </summary>
		public class Capacitor : RadiocomponentBase
		{
			/// <summary>
			/// Создает экземпляр класса <see cref="Capacitor"/>
			/// </summary>
			public Capacitor() : base() { } //TODO: лучше вызов базового конструктора с параметром, куда передавать дефолтное значение - когда родительский класс предоставляет несколько точек создания объектов, в дочерних классах можно ошибиться с нужным конструктором (пропустить нужные проверки)

			/// <summary>
			/// Создает экземпляр класса <see cref="Capacitor"/>
			/// </summary>
			/// <param name="value">Значение емкости в фарадах</param>
			public Capacitor(double value) : base(value) { }

			/// <inheritdoc/>
			protected override Complex CalculateImpedance(double frequency)
			{
                //TODO: сомнительная константа
				const double zeroRealPart = 0;

				if ((frequency == 0) || (Value == 0))
				{
					return new Complex(zeroRealPart,
						double.NegativeInfinity);
				}

				return new Complex(zeroRealPart,
					-1 / (2 * Math.PI * (frequency * Value)));
			}

            /// <inheritdoc/>
            public override RadiocomponentType Type
                => RadiocomponentType.Capacitor;
        }
	}
}
