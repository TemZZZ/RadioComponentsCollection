﻿//TODO: юзинги внутри неймспейса
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
	[XmlInclude(typeof(Capacitor))] //TODO: плохое решение с xmlInclude - при добавлении новых компонент ты будешь забывать добавить сюда доп.атрибут. Посмотри в сторону сериализации с помощью Newtonsoft json.net - она умеет сериализовывать без доп.атрибутов, надо лишь установить в настройках сохранение типа объекта в файл
	public abstract class RadiocomponentBase : IRadiocomponent
	{
        private const double _defaultValue = 0;
		private double _value;

		/// <summary>
		/// Создает экземпляр класса <see cref="RadiocomponentBase"/>
		/// </summary>
		/// <param name="value">Значение физической величины в СИ</param>
		protected RadiocomponentBase(double value)
		{
			Value = value;
		}

        /// <summary>
        /// Этот конструктор вызывается при создании экземпляров
        /// классов-наследников <see cref="RadiocomponentBase"/>
        /// </summary>
        protected RadiocomponentBase() : this(_defaultValue) { }

		/// <summary>
		/// Позволяет получить или присвоить значение
		/// физической величины радиокомпонента
		/// </summary>
		public double Value
		{
            get => _value;
            set
            {
                const string parameterName
                    = "physical value of radiocomponent";
                RadiocomponentService.ValidatePositiveDouble(
                    value, parameterName);
                _value = value;
            }
		}

		/// <summary>
		/// Возвращает частотнозависимый комплексный
		/// импеданс радиокомпонента
		/// </summary>
		public Complex GetImpedance(double frequency)
		{
            RadiocomponentService.ValidatePositiveDouble(
                frequency, nameof(frequency));
            return CalculateImpedance(frequency);
		}

		/// <summary>
		/// Возвращает строковое представление объекта
		/// </summary>
		public override string ToString()
		{
            return RadiocomponentService.ToString(Type, Value);
		}

        /// <inheritdoc />
        public RadiocomponentQuantity Quantity
            => RadiocomponentService.GetRadiocomponentQuantity(Type);

        /// <inheritdoc />
        public RadiocomponentUnit Unit
            => RadiocomponentService.GetRadiocomponentUnit(Type);

		/// <summary>
		/// Вычисляет частотнозависимый комплексный импеданс
		/// и возвращает значение
		/// </summary>
		/// <param name="frequency">Частота в герцах</param>
		/// <returns>Комплексный импеданс в омах</returns>
		protected abstract Complex CalculateImpedance(double frequency);

		/// <inheritdoc/>
		public abstract RadiocomponentType Type { get; }
	}
}
