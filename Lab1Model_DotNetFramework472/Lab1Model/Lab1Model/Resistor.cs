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
			/// Создается экземпляр класса <see cref="Resistor"/>
			/// </summary>
			public Resistor() : base(0) { }

			/// <summary>
			/// Создается экземпляр класса <see cref="Resistor"/>
			/// </summary>
			/// <param name="value">Значение сопротивления в омах</param>
			public Resistor(double value) : base(value) { }

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

			/// <summary>
			/// Возвращает строковое представление объекта
			/// </summary>
			public override string ToString()
			{
				return $"Тип: {Type}; {Quantity} = {Value} {Unit}";
			}

			private const string resistanceUnit = "Ом";
			private const string resistorType = "Резистор";
			private const string resistorQuantity = "Сопротивление";
			public override string Unit { get => resistanceUnit; }
			public override string Type { get => resistorType; }
			public override string Quantity { get => resistorQuantity; }
		}
	}
}
