using System;
using System.Numerics;


namespace Lab1Model
{
	namespace PassiveComponents
	{
		/// <summary>
		/// Класс катушки индуктивности
		/// </summary>
		public class Inductor : RadioComponentBase
		{
			/// <summary>
			/// Создает экземпляр класса <see cref="Inductor"/>
			/// </summary>
			public Inductor() : base(0) { }

			/// <summary>
			/// Создает экземпляр класса <see cref="Inductor"/>
			/// </summary>
			/// <param name="value">Значение индуктивности в генри</param>
			public Inductor(double value) : base(value) { }

			/// <inheritdoc/>
			protected override Complex CalcImpedance(double freq)
			{
				return new Complex(0, 2 * Math.PI * freq * Value);
			}

			private const string inductorUnit = "Гн";
			private const string inductorType = "Катушка индуктивности";
			private const string inductorQuantity = "Индуктивность";
			/// <inheritdoc/>
			public override string Unit { get => inductorUnit; }
			/// <inheritdoc/>
			public override string Type { get => inductorType; }
			/// <inheritdoc/>
			public override string Quantity { get => inductorQuantity; }
		}
	}
}
