using System;
using System.Numerics;


namespace Lab1Model
{
    /// <summary>
    /// Абстрактный класс радиокомпонента.
    /// Его наследуют все производные классы радиокомпонентов
    /// </summary>
    public abstract class RadioComponentBase : IRadioComponent
    {
        /// <summary>
        /// Создается экземпляр класса <see cref="RadioComponentBase"/>
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
        /// Позволяет получить или присвоить значение физической величины радиокомпонента
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Выбрасывается при попытке присвоения отрицательного
        /// значения физической величины</exception>
        public double Value
        {
            get
            {
                return _value;
            }

            set
            {
                // Если значение физической величины больше или равно нулю,
                // то присвоить _value новое значение физической величины,
                // иначе бросить исключение ArgumentOutOfRangeException

                if (value >= 0)
                {
                    _value = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Value must not be less than zero");
                }
            }
        }

        /// <summary>
        /// Возвращает частотнозависимый комплексный импеданс радиокомпонента
        /// </summary>
        /// <param name="freq">Частота в герцах</param>
        /// <returns>Комплексный импеданс в омах</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Выбрасывается при попытке передачи отрицательного
        /// значения частоты</exception>
        public Complex GetImpedance(double freq)
        {
            // Если значение частоты меньше нуля,
            // то бросить исключение ArgumentOutOfRangeException

            if (freq < 0)
            {
                throw new ArgumentOutOfRangeException("Frequency must not be less than zero");
            }

            return CalcImpedance(freq);
        }

        /// <summary>
        /// Вычисляет частотнозависимый комплексный импеданс и возвращает значение
        /// </summary>
        /// <param name="freq">Частота в герцах</param>
        /// <returns>Комплексный импеданс в омах</returns>
        protected abstract Complex CalcImpedance(double freq);

        public abstract string Unit { get; }
        public abstract string Type { get; }
        public abstract string Quantity { get; }
    }
}
