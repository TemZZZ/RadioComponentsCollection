using System.Numerics;

namespace Model
{
    /// <summary>
    /// Класс резистора.
    /// </summary>
    public class Resistor : RadiocomponentBase
    {
        private const double _defaultValue = 0;

        /// <summary>
        /// Создает экземпляр класса <see cref="Resistor"/>.
        /// </summary>
        public Resistor() : base(_defaultValue) { }

        /// <summary>
        /// Создает экземпляр класса <see cref="Resistor"/>.
        /// </summary>
        /// <param name="value">Значение сопротивления в омах.</param>
        public Resistor(double value) : base(value) { }

        /// <inheritdoc/>
        protected override Complex CalculateAndGetImpedance(double frequency)
        {
            return new Complex(Value, 0);
        }

        /// <inheritdoc/>
        public override RadiocomponentType Type
            => RadiocomponentType.Resistor;

        /// <inheritdoc/>
        public override RadiocomponentQuantity Quantity
            => RadiocomponentQuantity.Resistance;

        /// <inheritdoc/>
        public override RadiocomponentUnit Unit => RadiocomponentUnit.Ohm;
    }
}
