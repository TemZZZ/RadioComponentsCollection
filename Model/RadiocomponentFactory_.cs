using System;
using System.Collections.Generic;
using Randomizers;

namespace Model
{
	/// <summary>
	/// Класс фабрики радиокомпонентов
	/// </summary>
	public static class RadiocomponentFactory_
	{
		/// <summary>
		/// Словарь соответствий типа <see cref="Type"/> радиокомпонента и
		/// элемента из перечисления <see cref="RadiocomponentType_"/>
		/// </summary>
		private static readonly Dictionary<Type, RadiocomponentType_>
			_typeToRadiocomponentTypeMap
			= new Dictionary<Type, RadiocomponentType_>
			{
				[typeof(Resistor)] = RadiocomponentType_.Resistor,
				[typeof(Inductor)] = RadiocomponentType_.Inductor,
				[typeof(Capacitor)] = RadiocomponentType_.Capacitor,
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
		private static Dictionary<RadiocomponentType_, RadiocomponentBase_>
				GetTypeToRadiocomponentMap(double radiocomponentValue)
		{
			return new Dictionary<RadiocomponentType_, RadiocomponentBase_>
			{
				[RadiocomponentType_.Resistor]
					= new Resistor(radiocomponentValue),
				[RadiocomponentType_.Inductor]
					= new Inductor(radiocomponentValue),
				[RadiocomponentType_.Capacitor]
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
		/// <see cref="RadiocomponentBase_"/></returns>
		/// <exception cref="KeyNotFoundException"/>
		public static RadiocomponentBase_ CreateRadiocomponent(
			RadiocomponentType_ radiocomponentType,
			double radiocomponentValue)
		{
			return GetTypeToRadiocomponentMap(radiocomponentValue)
				[radiocomponentType];
		}

		/// <summary>
		/// Возвращает тип <see cref="RadiocomponentType_"/> переданного
		/// радиокомпонента
		/// </summary>
		/// <param name="radiocomponent">Радиокомпонент</param>
		/// <returns>Тип радиокомпонента</returns>
		public static RadiocomponentType_ GetRadiocomponentType(
			IRadiocomponent_ radiocomponent)
		{
			return _typeToRadiocomponentTypeMap[radiocomponent.GetType()];
		}

		/// <summary>
		/// Возвращает случайно сгенерированный радиокомпонент
		/// </summary>
		/// <returns></returns>
		public static RadiocomponentBase_ CreateRandomRadiocomponent()
		{
			var typeToDivisorMap
				= new List<(RadiocomponentType_ type, double divisor)>
			{
				(RadiocomponentType_.Resistor, 1e6),
				(RadiocomponentType_.Inductor, 1e12),
				(RadiocomponentType_.Capacitor, 1e15),
			};

            var randomIntGenerator = RandomizersAmbientContext.Instance;
			int randomInt = randomIntGenerator.Next(typeToDivisorMap.Count);
			var (type, divisor) = typeToDivisorMap[randomInt];

			return CreateRadiocomponent(type,
				randomIntGenerator.Next() / divisor);
		}
	}
}
