using System.Numerics;


namespace Model
{
	namespace PassiveComponents
	{
		/// <summary>
		/// Класс резистора
		/// </summary>
		public class Resistor : RadiocomponentBase
		{
			/// <summary>
			/// Создает экземпляр класса <see cref="Resistor"/>
			/// </summary>
			public Resistor() : base(0) { }

			/// <summary>
			/// Создает экземпляр класса <see cref="Resistor"/>
			/// </summary>
			/// <param name="value">Значение сопротивления в омах</param>
			public Resistor(double value) : base(value) { }

			/// <inheritdoc/>
			protected override Complex CalcImpedance(double frequency)
			{
				const double zeroImaginaryPart = 0;
				return new Complex(Value, zeroImaginaryPart);
			}

			/// <inheritdoc/>
			public override string Unit => "Ом";
			/// <inheritdoc/>
			public override string Type => "Резистор";
			/// <inheritdoc/>
			public override string Quantity => "Сопротивление";
		}
	}
}
