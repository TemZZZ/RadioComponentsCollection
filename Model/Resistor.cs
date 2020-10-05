using System.Numerics;

namespace Model
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
            return new Complex(Value, 0);
        }

        /// <inheritdoc/>
        public override RadiocomponentType Type
            => RadiocomponentType.Resistor;
    }
}
