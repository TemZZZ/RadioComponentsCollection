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
	public abstract class RadiocomponentBase : IRadiocomponent
	{
		/// <summary>
		/// Хранит значение физической величины радиокомпонента
		/// </summary>
		private double _value;

		/// <summary>
		/// Проверяет именованый параметр вещественного типа на
		/// принадлежность допустимому диапазону значений
		/// </summary>
		/// <param name="parameter">Параметр</param>
		/// <param name="parameterName">Имя параметра</param>
		/// <exception cref="ArgumentOutOfRangeException">Выбрасывается при
		/// попытке присвоения отрицательного или бесконечно большого
		/// положительного значения</exception>
		/// <exception cref="ArgumentException"> Выбрасывается при попытке
		/// присвоения NaN</exception>
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
		/// Создает экземпляр класса <see cref="RadiocomponentBase"/>
		/// </summary>
		/// <param name="value">Значение физической величины в СИ</param>
		protected RadiocomponentBase(double value)
		{
			Value = value;
		}

		/// <summary>
		/// Позволяет получить или присвоить значение
		/// физической величины радиокомпонента
		/// </summary>
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
		public abstract RadiocomponentUnit Unit { get; }
		/// <inheritdoc/>
		public abstract string Type { get; }
		/// <inheritdoc/>
		public abstract RadiocomponentQuantity Quantity { get; }
	}
}
