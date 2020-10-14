using System;
using System.Collections.Generic;
using System.Linq;
using Model;

namespace View
{
	/// <summary>
	/// Класс с методами расширения для фильтрации радиокомпонентов.
	/// </summary>
	public static class WhereExtension
	{
		/// <summary>
		/// Функция "меньше, чем".
		/// </summary>
		public static Func<double, double, bool> LessThan
			= (param, otherParam) => param < otherParam;
		/// <summary>
		/// Функция "больше, чем".
		/// </summary>
		public static Func<double, double, bool> MoreThan
			= (param, otherParam) => param > otherParam;
		/// <summary>
		/// Функция "равно".
		/// </summary>
		public static Func<double, double, bool> Equal
			= (param, otherParam) => param == otherParam;

		/// <summary>
		/// Фильтрует проиндексированные радиокомпоненты по типу.
		/// </summary>
		/// <param name="indexedRadiocomponents">Коллекция пар
		/// "индекс-радиокомпонент".</param>
		/// <param name="radiocomponentType">Тип радиокомпонента.</param>
		/// <returns>Отфильтрованная коллекция пар
		/// "индекс-радиокомпонент".</returns>
		public static IEnumerable<KeyValuePair<int, RadiocomponentBase>>
			GetFilteredByTypeIndexedRadiocomponents(
				this IEnumerable<KeyValuePair<int, RadiocomponentBase>>
					indexedRadiocomponents,
				RadiocomponentType radiocomponentType)
		{
			return indexedRadiocomponents.Where(indexToRadiocomponent
				=> indexToRadiocomponent.Value.Type == radiocomponentType);
		}

		/// <summary>
		/// Фильтрует проиндексированные радиокомпоненты по значению.
		/// </summary>
		/// <param name="indexedRadiocomponents">Коллекция пар
		/// "индекс-радиокомпонент".</param>
		/// <param name="filterTurnedOn">Включен фильтр или нет.</param>
		/// <param name="comparator">Функция сравнения.</param>
		/// <param name="threshold">Пороговое значение для функции сравнения.
		/// </param>
		/// <returns>Отфильтрованная коллекция пар "индекс-радиокомпонент".
		/// </returns>
		public static IEnumerable<KeyValuePair<int, RadiocomponentBase>>
			GetFilteredByValueIndexedRadiocomponents(
				this IEnumerable<KeyValuePair<int, RadiocomponentBase>>
					indexedRadiocomponents,
				bool filterTurnedOn, Func<double, double, bool> comparator,
				double threshold)
		{
			if ((indexedRadiocomponents is null) || (!filterTurnedOn))
			{
				return Enumerable
					.Empty<KeyValuePair<int, RadiocomponentBase>>();
			}

			return indexedRadiocomponents.Where(indexToRadiocomponent
				=> comparator(indexToRadiocomponent.Value.Value, threshold));
		}

		/// <summary>
		/// Возвращает проиндексированные радиокомпоненты.
		/// </summary>
		/// <param name="radiocomponents">Список радиокомпонентов.</param>
		/// <returns>Коллекция пар "индекс-радиокомпонент".</returns>
		public static IEnumerable<KeyValuePair<int, RadiocomponentBase>>
			ToIndexedRadiocomponents(
				this SortableBindingList<RadiocomponentBase> radiocomponents)
		{
			return radiocomponents.ToDictionary(
				radiocomponent => radiocomponents.IndexOf(radiocomponent),
				radiocomponent => radiocomponent);
		}

		/// <summary>
		/// Возвращает индексы проиндексированных радиокомпонентов.
		/// </summary>
		/// <param name="indexedRadiocomponents">Коллекция пар
		/// "индекс-радиокомпонент".</param>
		/// <returns>Массив целых чисел.</returns>
		public static int[] GetIndices(
			this IEnumerable<KeyValuePair<int, RadiocomponentBase>>
				indexedRadiocomponents)
		{
			return indexedRadiocomponents.Select(
				indexedRadiocomponent => indexedRadiocomponent.Key)
                .ToArray();
		}
	}
}
