﻿using System;
using System.Numerics;

namespace Model
{
    /// <summary>
    /// Класс конденсатора.
    /// </summary>
    public class Capacitor : RadiocomponentBase
    {
        private const double _defaultValue = 0;

        /// <summary>
        /// Создает экземпляр класса <see cref="Capacitor"/>.
        /// </summary>
        public Capacitor() : base(_defaultValue) { }

        /// <summary>
        /// Создает экземпляр класса <see cref="Capacitor"/>.
        /// </summary>
        /// <param name="value">Значение емкости в фарадах.</param>
        public Capacitor(double value) : base(value) { }

        /// <inheritdoc/>
        protected override Complex CalculateAndGetImpedance(double frequency)
        {
            if ((frequency == 0) || (Value == 0))
            {
                return new Complex(0, double.NegativeInfinity);
            }

            return new Complex(0, -1 / (2 * Math.PI * (frequency * Value)));
        }

        /// <inheritdoc/>
        public override RadiocomponentType Type
            => RadiocomponentType.Capacitor;

        /// <inheritdoc/>
        public override RadiocomponentQuantity Quantity
            => RadiocomponentQuantity.Capacitance;

        /// <inheritdoc/>
        public override RadiocomponentUnit Unit => RadiocomponentUnit.Farad;
    }
}
