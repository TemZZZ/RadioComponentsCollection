using Model.PassiveComponents;
using System.Collections.Generic;


namespace Model
{
	/// <summary>
	/// Класс фабрики радиокомпонентов
	/// </summary>
	public class RadioComponentFactory
	{
		/// <summary>
		/// Возвращает словарь пар значений
		/// "тип радиокомпонента-радиокомпонент"
		/// </summary>
		/// <param name="radioComponentValue">Значение физической величины
		/// радиокомпонента</param>
		/// <returns>Словарь пар значений
		/// "тип радиокомпонента-радиокомпонент"
		/// </returns>
		private Dictionary<RadioComponentType, RadioComponentBase>
				GetTypeToRadioComponentMap(double radioComponentValue)
		{
			return new Dictionary<RadioComponentType, RadioComponentBase>
			{
				[RadioComponentType.Resistor]
					= new Resistor(radioComponentValue),
				[RadioComponentType.Inductor]
					= new Inductor(radioComponentValue),
				[RadioComponentType.Capacitor]
					= new Capacitor(radioComponentValue)
			};
		}

		/// <summary>
		/// Возвращает радиокомпонент определенного типа с требуемым
		/// значением физической величины
		/// </summary>
		/// <param name="radioComponentType">Тип радиокомпонента</param>
		/// <param name="radioComponentValue">Значение физической величины
		/// радиокомпонента</param>
		/// <returns>Объект класса-наследника
		/// <see cref="RadioComponentBase"/></returns>
		/// <exception cref="KeyNotFoundException"/>
		public RadioComponentBase CreateRadioComponent(
			RadioComponentType radioComponentType,
			double radioComponentValue)
		{
			return GetTypeToRadioComponentMap(radioComponentValue)
				[radioComponentType];
		}
	}
}
