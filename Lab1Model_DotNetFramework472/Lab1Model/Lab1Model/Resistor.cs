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
				return new Complex(Value, 0);
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
