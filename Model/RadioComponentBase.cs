using System;
using System.Numerics;
using System.Xml.Serialization;
using Model.PassiveComponents;


namespace Model
{
    /// <summary>
    /// Абстрактный класс радиокомпонента.
    /// Его наследуют все производные классы радиокомпонентов
    /// </summary>
    [XmlInclude(typeof(Resistor))]
    [XmlInclude(typeof(Inductor))]
    [XmlInclude(typeof(Capacitor))]
    public abstract class RadioComponentBase : IRadioComponent
    {
        /// <summary>
        /// Создает экземпляр класса <see cref="RadioComponentBase"/>
        /// </summary>
        /// <param name="value">Значение физической величины в СИ</param>
        protected RadioComponentBase(double value)
        {
            Value = value;
        }

        /// <summary>
        /// Хранит значение физической величины радиокомпонента
        /// </summary>
        private double _value;

        /// <summary>
        /// Позволяет получить или присвоить значение
        /// физической величины радиокомпонента
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Выбрасывается при попытке присвоения отрицательного
        /// значения физической величины</exception>
        /// <exception cref="ArgumentException">
        /// Выбрасывается при попытке присвоения NaN</exception>
        public double Value
        {
            get
            {
                return _value;
            }

            set
            {
                if (double.IsNaN(value))
				{
                    throw new ArgumentException("Value of radiocomponent " +
                        "can't be NaN.");
				}

                if (value >= 0)
                {
                    _value = value;
                }    
                else
                {
                    throw new ArgumentOutOfRangeException(
                        "Value must not be less than zero");
                }
            }
        }

        /// <summary>
        /// Возвращает частотнозависимый комплексный
        /// импеданс радиокомпонента
        /// </summary>
        /// <param name="freq">Частота в герцах</param>
        /// <returns>Комплексный импеданс в омах</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Выбрасывается при попытке передачи отрицательного
        /// значения частоты</exception>
        public Complex GetImpedance(double freq)
        {
            if (freq < 0)
            {
                throw new ArgumentOutOfRangeException(
                    "Frequency must not be less than zero");
            }

            return CalcImpedance(freq);
        }

        /// <summary>
        /// Вычисляет частотнозависимый комплексный импеданс
        /// и возвращает значение
        /// </summary>
        /// <param name="freq">Частота в герцах</param>
        /// <returns>Комплексный импеданс в омах</returns>
        protected abstract Complex CalcImpedance(double freq);

        /// <summary>
        /// Возвращает строковое представление объекта
        /// </summary>
        public override string ToString()
        {
            return $"Тип: {Type}; {Quantity} = {Value} {Unit}";
        }

        /// <inheritdoc/>
        public abstract string Unit { get; }
        /// <inheritdoc/>
        public abstract string Type { get; }
        /// <inheritdoc/>
        public abstract string Quantity { get; }
    }
}
