using System;
using System.Numerics;

namespace Model
{
    /// <summary>
    /// Класс катушки индуктивности
    /// </summary>
    public class Inductor : RadiocomponentBase
    {
        private const double _defaultValue = 0;

        /// <summary>
        /// Создает экземпляр класса <see cref="Inductor"/>
        /// </summary>
        public Inductor() : base(_defaultValue) { }

        /// <summary>
        /// Создает экземпляр класса <see cref="Inductor"/>
        /// </summary>
        /// <param name="value">Значение индуктивности в генри</param>
        public Inductor(double value) : base(value) { }

        /// <inheritdoc/>
        protected override Complex CalculateAndGetImpedance(double frequency)
        {
            return new Complex(0, 2 * Math.PI * (frequency * Value));
        }

        /// <inheritdoc/>
        public override RadiocomponentType Type
            => RadiocomponentType.Inductor;
    }
}
