﻿using System.Collections.Generic;
using Randomizers;

namespace Model
{
	/// <summary>
	/// Класс фабрики радиокомпонентов.
	/// </summary>
	public static class RadiocomponentFactory
	{
		/// <summary>
		/// Список пар "тип радиокомпонента-множитель". Множители
		/// используются при генерации случайных значений физических величин
		/// радиокомпонентов.
        /// </summary>
        private static readonly List<(RadiocomponentType, double)>
            _typeToMultiplierTuples = new List<(RadiocomponentType, double)>
            {
                (RadiocomponentType.Resistor, 1e-6),
                (RadiocomponentType.Inductor, 1e-12),
                (RadiocomponentType.Capacitor, 1e-15)
            };

		/// <summary>
		/// Возвращает словарь пар значений
		/// "тип радиокомпонента-радиокомпонент".
		/// </summary>
		/// <param name="radiocomponentValue">Значение физической величины
		/// радиокомпонента.</param>
		/// <returns>Словарь пар значений
		/// "тип радиокомпонента-радиокомпонент".
		/// </returns>
		private static Dictionary<RadiocomponentType, RadiocomponentBase>
            GetTypeToRadiocomponentDictionary(double radiocomponentValue)
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
		/// значением физической величины.
		/// </summary>
		/// <param name="radiocomponentType">Тип радиокомпонента.</param>
		/// <param name="radiocomponentValue">Значение физической величины
		/// радиокомпонента.</param>
		/// <returns>Объект класса-наследника
		/// <see cref="RadiocomponentBase"/>.</returns>
		/// <exception cref="KeyNotFoundException"/>
		public static RadiocomponentBase GetRadiocomponent(
			RadiocomponentType radiocomponentType,
			double radiocomponentValue)
		{
			return GetTypeToRadiocomponentDictionary(radiocomponentValue)
				[radiocomponentType];
		}

		/// <summary>
		/// Возвращает случайно сгенерированный радиокомпонент.
		/// </summary>
		/// <returns>Объект радиокомпонента.</returns>
		public static RadiocomponentBase GetRandomRadiocomponent()
        {
            var randomIntGenerator = RandomizersAmbientContext.Instance;
			var randomInt = randomIntGenerator.Next(
                _typeToMultiplierTuples.Count);
			var (type, multiplier) = _typeToMultiplierTuples[randomInt];

			return GetRadiocomponent(type,
				randomIntGenerator.Next() * multiplier);
		}
	}
}
