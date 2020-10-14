using System;
using System.Collections.Generic;
using Model.Services;
using Randomizers;

namespace Model
{
	/// <summary>
	/// Класс фабрики радиокомпонентов.
	/// </summary>
	public static class RadiocomponentFactory
	{
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
            var encapsulatedType = RadiocomponentService.GetEncapsulatedType(
                radiocomponentType);
            return (RadiocomponentBase)Activator.CreateInstance(
                encapsulatedType, radiocomponentValue);
		}

		/// <summary>
		/// Возвращает случайно сгенерированный радиокомпонент.
		/// </summary>
		/// <returns>Объект радиокомпонента.</returns>
		public static RadiocomponentBase GetRandomRadiocomponent()
        {
            var randomIntGenerator = RandomizersAmbientContext.Instance;
			var randomInt = randomIntGenerator.Next(RadiocomponentService
                .RadiocomponentTypeToMultiplierTuplesForRandom.Count);
			var (type, multiplier) = RadiocomponentService
                .RadiocomponentTypeToMultiplierTuplesForRandom[randomInt];

			return GetRadiocomponent(type,
				randomIntGenerator.Next() * multiplier);
		}
	}
}
