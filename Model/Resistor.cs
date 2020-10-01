using System.Numerics;

namespace Model
{
	//TODO: если в интерфейсе есть приставка Radio, то почему пространство имен просто Components
    //TODO: Городить один неймспейс внутри другого не надо. Чтобы разработчик видел вложенность пространств имен, надо делать папку в проекте, и использовать один неймспейс через точку Model.PassiveComponents
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
			public Resistor() : base() { }

			/// <summary>
			/// Создает экземпляр класса <see cref="Resistor"/>
			/// </summary>
			/// <param name="value">Значение сопротивления в омах</param>
			public Resistor(double value) : base(value) { }

			/// <inheritdoc/>
			protected override Complex CalculateImpedance(double frequency)
			{
                //TODO: сомнительная константа. Это не то магическое число, которое требует доп.константы
				const double zeroImaginaryPart = 0;
				return new Complex(Value, zeroImaginaryPart);
			}

            /// <inheritdoc/>
            public override RadiocomponentType Type
                => RadiocomponentType.Resistor;
        }
	}
}
