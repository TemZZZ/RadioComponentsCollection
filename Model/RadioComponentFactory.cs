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
		/// Перечислитель пар "тип радиокомпонента-радиокомпонент"
		/// </summary>
		/// <param name="radioComponentValue">Значение физической величины
		/// радиокомпонента</param>
		/// <returns>Пара значений "тип радиокомпонента-радиокомпонент"
		/// </returns>
		private IEnumerable<(RadioComponentType radioComponentType,
			RadioComponentBase radioComponent)>
				TypeToRadioComponentMap(double radioComponentValue)
		{
			yield return (RadioComponentType.Resistor,
				new Resistor(radioComponentValue));
			yield return (RadioComponentType.Inductor,
				new Inductor(radioComponentValue));
			yield return (RadioComponentType.Capacitor,
				new Capacitor(radioComponentValue));
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
		public RadioComponentBase CreateRadioComponent(
			RadioComponentType radioComponentType,
			double radioComponentValue)
		{
			foreach (var (type, radioComponent)
				in TypeToRadioComponentMap(radioComponentValue))
			{
				if (radioComponentType == type)
				{
					return radioComponent;
				}
			}

			return null;
		}
	}
}
