using System.Numerics;


namespace Lab1Model
{
	namespace PassiveComponents
	{
		/// <summary>
		/// Класс резистора
		/// </summary>
		public class Resistor : RadioComponentBase
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
			protected override Complex CalcImpedance(double freq)
			{
				const double zeroImaginaryPart = 0;
				return new Complex(Value, zeroImaginaryPart);
			}

			/// <summary>
			/// Возвращает сопротивление резистора
			/// </summary>
			/// <returns>Сопротивление в омах</returns>
			public double GetImpedance()
			{
				return Value;
			}

			/// <inheritdoc/>
			public override string Unit { get => "Ом"; }
			/// <inheritdoc/>
			public override string Type { get => "Резистор"; }
			/// <inheritdoc/>
			public override string Quantity { get => "Сопротивление"; }
		}
	}
}
