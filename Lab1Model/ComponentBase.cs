using System;


namespace Lab1Model
{
    /// <summary>
    /// Абстрактный класс радиокомпонента.
    /// Его наследуют все производные классы радиокомпонентов
    /// </summary>
    public abstract class ComponentBase : IComponent
    {
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
                // Если значение частоты больше или равно нулю,
                // то присвоить _value новое значение частоты,
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
        public double GetImpedance(double freq)
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
        protected abstract double CalcImpedance(double freq);
    }
}
