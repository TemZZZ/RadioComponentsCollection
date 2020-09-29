using System;
using System.Collections.Generic;
using Model.PassiveComponents;
using RandomizersLib;

namespace Model
{
	/// <summary>
	/// Класс фабрики радиокомпонентов
	/// </summary>
	public static class RadiocomponentFactory
	{
		/// <summary>
		/// Словарь соответствий типа <see cref="Type"/> радиокомпонента и
		/// элемента из перечисления <see cref="RadiocomponentType"/>
		/// </summary>
		private static readonly Dictionary<Type, RadiocomponentType>
			_typeToRadiocomponentTypeMap
			= new Dictionary<Type, RadiocomponentType>
			{
				[typeof(Resistor)] = RadiocomponentType.Resistor,
				[typeof(Inductor)] = RadiocomponentType.Inductor,
				[typeof(Capacitor)] = RadiocomponentType.Capacitor,
			};

		/// <summary>
		/// Возвращает словарь пар значений
		/// "тип радиокомпонента-радиокомпонент"
		/// </summary>
		/// <param name="radiocomponentValue">Значение физической величины
		/// радиокомпонента</param>
		/// <returns>Словарь пар значений
		/// "тип радиокомпонента-радиокомпонент"
		/// </returns>
		private static Dictionary<RadiocomponentType, RadiocomponentBase>
				GetTypeToRadiocomponentMap(double radiocomponentValue)
		{
			return new Dictionary<RadiocomponentType, RadiocomponentBase>
			{
				[RadiocomponentType.Resistor]
					= new Resistor(radiocomponentValue),
				[RadiocomponentType.Inductor]
					= new Inductor(radiocomponentValue),
				[RadiocomponentType.Capacitor]
					= new Capacitor(radiocomponentValue)
			};
		}

		/// <summary>
		/// Возвращает радиокомпонент определенного типа с требуемым
		/// значением физической величины
		/// </summary>
		/// <param name="radiocomponentType">Тип радиокомпонента</param>
		/// <param name="radiocomponentValue">Значение физической величины
		/// радиокомпонента</param>
		/// <returns>Объект класса-наследника
		/// <see cref="RadiocomponentBase"/></returns>
		/// <exception cref="KeyNotFoundException"/>
		public static RadiocomponentBase CreateRadiocomponent(
			RadiocomponentType radiocomponentType,
			double radiocomponentValue)
		{
			return GetTypeToRadiocomponentMap(radiocomponentValue)
				[radiocomponentType];
		}

		/// <summary>
		/// Возвращает тип <see cref="RadiocomponentType"/> переданного
		/// радиокомпонента
		/// </summary>
		/// <param name="radiocomponent">Радиокомпонент</param>
		/// <returns>Тип радиокомпонента</returns>
		public static RadiocomponentType GetRadiocomponentType(
			IRadiocomponent radiocomponent)
		{
			return _typeToRadiocomponentTypeMap[radiocomponent.GetType()];
		}

		/// <summary>
		/// Возвращает случайно сгенерированный радиокомпонент
		/// </summary>
		/// <returns></returns>
		public static RadiocomponentBase CreateRandomRadiocomponent()
		{
			var typeToDivisorMap
				= new List<(RadiocomponentType type, double divisor)>
			{
				(RadiocomponentType.Resistor, 1e6),
				(RadiocomponentType.Inductor, 1e12),
				(RadiocomponentType.Capacitor, 1e15),
			};

            var randomIntGenerator = GlobalRandomizer.Instance;
			int randomInt = randomIntGenerator.Next(typeToDivisorMap.Count);
			var (type, divisor) = typeToDivisorMap[randomInt];

			return CreateRadiocomponent(type,
				randomIntGenerator.Next() / divisor);
		}
	}
}
