using System.Numerics;
using Model.Services;

namespace Model
{
	/// <summary>
	/// Абстрактный класс радиокомпонента. Его наследуют все производные
	/// классы радиокомпонентов.
	/// </summary>
	public abstract class RadiocomponentBase : IRadiocomponent
	{
		private double _value;

		/// <summary>
		/// Создает экземпляр класса <see cref="RadiocomponentBase"/>.
		/// </summary>
		/// <param name="value">Значение физической величины в СИ.</param>
		protected RadiocomponentBase(double value)
		{
			Value = value;
		}

        /// <summary>
        /// Вычисляет частотнозависимый комплексный импеданс и возвращает
        /// значение импеданса.
        /// </summary>
        /// <param name="frequency">Частота в герцах.</param>
        /// <returns>Комплексный импеданс в омах.</returns>
        protected abstract Complex CalculateAndGetImpedance(
            double frequency);

        #region -- Public properties --

        /// <inheritdoc/>
        public abstract RadiocomponentType Type { get; }

        /// <inheritdoc/>
        public abstract RadiocomponentQuantity Quantity { get; }

        /// <summary>
        /// Позволяет получить или присвоить значение физической величины
        /// радиокомпонента.
        /// </summary>
        public double Value
        {
            get => _value;
            set
            {
                const string parameterName
                    = "Physical value of radiocomponent";
                RadiocomponentService.ValidatePositiveDouble(value,
                    parameterName);
                _value = value;
            }
        }

        /// <inheritdoc/>
        public abstract RadiocomponentUnit Unit { get; }

		#endregion

		#region -- Public methods --

		/// <summary>
        /// Возвращает частотнозависимый комплексный импеданс
        /// радиокомпонента.
        /// </summary>
        public Complex GetImpedance(double frequency)
        {
            RadiocomponentService.ValidatePositiveDouble(frequency,
                nameof(frequency));
            return CalculateAndGetImpedance(frequency);
        }

        /// <summary>
        /// Возвращает строковое представление радиокомпонента.
        /// </summary>
        public override string ToString()
        {
            return RadiocomponentService.ToString(Type, Value);
        }

		#endregion
	}
}
