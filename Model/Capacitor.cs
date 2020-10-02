using System;
using System.Numerics;

namespace Model
{
    /// <summary>
    /// Класс конденсатора
    /// </summary>
    public class Capacitor : RadiocomponentBase
    {
        /// <summary>
        /// Создает экземпляр класса <see cref="Capacitor"/>
        /// </summary>
        public Capacitor() : base() { }

        /// <summary>
        /// Создает экземпляр класса <see cref="Capacitor"/>
        /// </summary>
        /// <param name="value">Значение емкости в фарадах</param>
        public Capacitor(double value) : base(value) { }

        /// <inheritdoc/>
        protected override Complex CalculateImpedance(double frequency)
        {
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
