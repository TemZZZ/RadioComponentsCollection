using System;
using System.Collections.Generic;
using System.Linq;
using Model;

namespace View
{
	/// <summary>
	/// Класс с методами расширения для фильтрации радиокомпонентов
	/// </summary>
	public static class WhereExtension
	{
		/// <summary>
		/// Функция "меньше, чем"
		/// </summary>
		public static Func<double, double, bool> LessThan
			= (param, otherParam) => param < otherParam;
		/// <summary>
		/// Функция "больше, чем"
		/// </summary>
		public static Func<double, double, bool> MoreThan
			= (param, otherParam) => param > otherParam;
		/// <summary>
		/// Функция "равно"
		/// </summary>
		public static Func<double, double, bool> Equal
			= (param, otherParam) => param == otherParam;

		/// <summary>
		/// Фильтрует проиндексированные радиокомпоненты по типу
		/// </summary>
		/// <param name="indexToRadiocomponentMap">Перечислитель
		/// пар "индекс-радиокомпонент"</param>
		/// <param name="radiocomponentType">Тип радиокомпонента</param>
		/// <returns>Отфильтрованный перечислитель
		/// пар "индекс-радиокомпонент"</returns>
		public static IEnumerable<KeyValuePair<int, RadiocomponentBase_>>
			GetFilteredByTypeIndexToRadiocomponentMap(
				this IEnumerable<KeyValuePair<int, RadiocomponentBase_>>
					indexToRadiocomponentMap,
				RadiocomponentType_ radiocomponentType)
		{
			return indexToRadiocomponentMap.Where(indexToRadiocomponent
				=> indexToRadiocomponent.Value.Type == radiocomponentType);
		}

		/// <summary>
		/// Фильтрует проиндексированные радиокомпоненты по значению
		/// </summary>
		/// <param name="indexToRadiocomponentMap">Перечислитель
		/// пар "индекс-радиокомпонент"</param>
		/// <param name="filterTurnedOn">Включен фильтр или нет</param>
		/// <param name="comparator">Функция сравнения</param>
		/// <param name="threshold">Пороговое значение
		/// для функции сравнения</param>
		/// <returns>Отфильтрованный перечислитель
		/// пар "индекс-радиокомпонент"</returns>
		public static IEnumerable<KeyValuePair<int, RadiocomponentBase_>>
			GetFilteredByValueIndexToRadiocomponentMap(
				this IEnumerable<KeyValuePair<int, RadiocomponentBase_>>
					indexToRadiocomponentMap,
				bool filterTurnedOn, Func<double, double, bool> comparator,
				double threshold)
		{
			if ((indexToRadiocomponentMap is null) || (!filterTurnedOn))
			{
				return Enumerable
					.Empty<KeyValuePair<int, RadiocomponentBase_>>();
			}

			return indexToRadiocomponentMap.Where(indexToRadiocomponent
				=> comparator(indexToRadiocomponent.Value.Value, threshold));
		}

		/// <summary>
		/// Возвращает перечислитель проиндексированных радиокомпонентов
		/// </summary>
		/// <param name="radiocomponents">Список радиокомпонентов</param>
		/// <returns>Перечислитель пар "индекс-радиокомпонент"</returns>
		public static IEnumerable<KeyValuePair<int, RadiocomponentBase_>>
			ToIndexToRadiocomponentMap(
				this SortableBindingList<RadiocomponentBase_> radiocomponents)
		{
			return radiocomponents.ToDictionary(
				radiocomponent => radiocomponents.IndexOf(radiocomponent),
				radiocomponent => radiocomponent);
		}

		/// <summary>
		/// Возвращает индексы перечислителя
		/// проиндексированных радиокомпонентов
		/// </summary>
		/// <param name="indexToRadiocomponentMap">Перечислитель пар
		/// "индекс-радиокомпонент"</param>
		/// <returns>Массив целых чисел</returns>
		public static int[] GetIndices(
			this IEnumerable<KeyValuePair<int, RadiocomponentBase_>>
				indexToRadiocomponentMap)
		{
			return indexToRadiocomponentMap.Select(
				indexedRadiocomponent => indexedRadiocomponent.Key)
				.ToArray();
		}
	}
}
