using System;
using System.Collections.Generic;
using Model.PassiveComponents;


namespace Model
{
	/// <summary>
	/// Класс фабрики радиокомпонентов
	/// </summary>
	public static class RadioComponentFactory
	{
		/// <summary>
		/// Словарь соответствий типа <see cref="Type"/> радиокомпонента и
		/// элемента из перечисления <see cref="RadioComponentType"/>
		/// </summary>
		private static readonly Dictionary<Type, RadioComponentType>
			_typeToRadioComponentTypeMap
			= new Dictionary<Type, RadioComponentType>
			{
				[typeof(Resistor)] = RadioComponentType.Resistor,
				[typeof(Inductor)] = RadioComponentType.Inductor,
				[typeof(Capacitor)] = RadioComponentType.Capacitor,
			};

		/// <summary>
		/// Возвращает словарь пар значений
		/// "тип радиокомпонента-радиокомпонент"
		/// </summary>
		/// <param name="radioComponentValue">Значение физической величины
		/// радиокомпонента</param>
		/// <returns>Словарь пар значений
		/// "тип радиокомпонента-радиокомпонент"
		/// </returns>
		private static Dictionary<RadioComponentType, RadiocomponentBase>
				GetTypeToRadioComponentMap(double radioComponentValue)
		{
			return new Dictionary<RadioComponentType, RadiocomponentBase>
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
		/// <see cref="RadiocomponentBase"/></returns>
		/// <exception cref="KeyNotFoundException"/>
		public static RadiocomponentBase CreateRadioComponent(
			RadioComponentType radioComponentType,
			double radioComponentValue)
		{
			return GetTypeToRadioComponentMap(radioComponentValue)
				[radioComponentType];
		}

		/// <summary>
		/// Возвращает тип <see cref="RadioComponentType"/> переданного
		/// радиокомпонента
		/// </summary>
		/// <param name="radiocomponent">Радиокомпонент</param>
		/// <returns>Тип радиокомпонента</returns>
		public static RadioComponentType GetRadioComponentType(
			IRadiocomponent radiocomponent)
		{
			return _typeToRadioComponentTypeMap[radiocomponent.GetType()];
		}

		/// <summary>
		/// Возвращает случайно сгенерированный радиокомпонент
		/// </summary>
		/// <returns></returns>
		public static RadiocomponentBase CreateRandomRadioComponent()
		{
			var typeToDivisorMap
				= new List<(RadioComponentType type, double divisor)>
			{
				(RadioComponentType.Resistor, 1e6),
				(RadioComponentType.Inductor, 1e12),
				(RadioComponentType.Capacitor, 1e15),
			};

			var randomIntGenerator = new Random();
			int randomInt = randomIntGenerator.Next(typeToDivisorMap.Count);
			var (type, divisor) = typeToDivisorMap[randomInt];

			return CreateRadioComponent(type,
				randomIntGenerator.Next() / divisor);
		}
	}
}
