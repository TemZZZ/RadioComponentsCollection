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
		/// Хранит значение физической величины радиокомпонента
		/// </summary>
		private double _value;

		/// <summary>
		/// Проверяет именованый параметр вещественного типа на
		/// принадлежность допустимому диапазону и выбрасывает исключение в
		/// случае
		/// </summary>
		/// <param name="parameter"></param>
		/// <param name="parameterName"></param>
		private void CheckNamedDoubleParameter(double parameter,
			string parameterName)
		{
			if (double.IsNaN(parameter))
			{
				throw new ArgumentException(
					$"{parameterName} can't be NaN.");
			}

			if (double.IsPositiveInfinity(parameter))
			{
				throw new ArgumentOutOfRangeException(
					$"{parameterName} must be less than or equal to " +
					$"{double.MaxValue}.");
			}

			if (parameter < 0)
			{
				throw new ArgumentOutOfRangeException(
					$"{parameterName} can't be less than zero.");
			}
		}

		/// <summary>
		/// Создает экземпляр класса <see cref="RadioComponentBase"/>
		/// </summary>
		/// <param name="value">Значение физической величины в СИ</param>
		protected RadioComponentBase(double value)
		{
			Value = value;
		}

		/// <summary>
		/// Позволяет получить или присвоить значение
		/// физической величины радиокомпонента
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">
		/// Выбрасывается при попытке присвоения отрицательного
		/// или бесконечно большого положительного значения физической
		/// величины</exception>
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
				const string valueString = "Value of radiocomponent";
				CheckNamedDoubleParameter(value, valueString);
				_value = value;
			}
		}

		/// <summary>
		/// Возвращает частотнозависимый комплексный
		/// импеданс радиокомпонента
		/// </summary>
		/// <param name="frequency">Частота в герцах</param>
		/// <returns>Комплексный импеданс в омах</returns>
		/// <exception cref="ArgumentOutOfRangeException">
		/// Выбрасывается при попытке передачи отрицательного
		/// или бесконечно большого положительного значения
		/// частоты</exception>
		/// <exception cref="ArgumentException">
		/// Выбрасывается при попытке передачи частоты, равной NaN
		/// </exception>
		public Complex GetImpedance(double frequency)
		{
			const string frequencyString = "Frequency";
			CheckNamedDoubleParameter(frequency, frequencyString);
			return CalcImpedance(frequency);
		}

		/// <summary>
		/// Возвращает строковое представление объекта
		/// </summary>
		public override string ToString()
		{
			return $"Тип: {Type}; {Quantity} = {Value} {Unit}";
		}

		/// <summary>
		/// Вычисляет частотнозависимый комплексный импеданс
		/// и возвращает значение
		/// </summary>
		/// <param name="frequency">Частота в герцах</param>
		/// <returns>Комплексный импеданс в омах</returns>
		protected abstract Complex CalcImpedance(double frequency);

		/// <inheritdoc/>
		public abstract string Unit { get; }
		/// <inheritdoc/>
		public abstract string Type { get; }
		/// <inheritdoc/>
		public abstract string Quantity { get; }
	}
}
