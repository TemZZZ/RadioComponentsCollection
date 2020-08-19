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
		/// <param name="indexToRadioComponentMap">Перечислитель
		/// пар "индекс-радиокомпонент"</param>
		/// <param name="radioComponentType">Тип радиокомпонента</param>
		/// <returns>Отфильтрованный перечислитель
		/// пар "индекс-радиокомпонент"</returns>
		public static IEnumerable<KeyValuePair<int, RadiocomponentBase>>
			GetFilteredByTypeIndexToRadioComponentMap(
				this IEnumerable<KeyValuePair<int, RadiocomponentBase>>
					indexToRadioComponentMap,
				string radioComponentType)
		{
			return indexToRadioComponentMap.Where(indexToRadioComponent
				=> indexToRadioComponent.Value.Type == radioComponentType);
		}

		/// <summary>
		/// Фильтрует проиндексированные радиокомпоненты по значению
		/// </summary>
		/// <param name="indexToRadioComponentMap">Перечислитель
		/// пар "индекс-радиокомпонент"</param>
		/// <param name="filterTurnedOn">Включен фильтр или нет</param>
		/// <param name="comparator">Функция сравнения</param>
		/// <param name="threshold">Пороговое значение
		/// для функции сравнения</param>
		/// <returns>Отфильтрованный перечислитель
		/// пар "индекс-радиокомпонент"</returns>
		public static IEnumerable<KeyValuePair<int, RadiocomponentBase>>
			GetFilteredByValueIndexToRadioComponentMap(
				this IEnumerable<KeyValuePair<int, RadiocomponentBase>>
					indexToRadioComponentMap,
				bool filterTurnedOn, Func<double, double, bool> comparator,
				double threshold)
		{
			if ((indexToRadioComponentMap is null) || (!filterTurnedOn))
			{
				return Enumerable
					.Empty<KeyValuePair<int, RadiocomponentBase>>();
			}

			return indexToRadioComponentMap.Where(indexToRadioComponent
				=> comparator(indexToRadioComponent.Value.Value, threshold));
		}

		/// <summary>
		/// Возвращает перечислитель проиндексированных радиокомпонентов
		/// </summary>
		/// <param name="radioComponents">Список радиокомпонентов</param>
		/// <returns>Перечислитель пар "индекс-радиокомпонент"</returns>
		public static IEnumerable<KeyValuePair<int, RadiocomponentBase>>
			ToIndexToRadioComponentMap(
				this SortableBindingList<RadiocomponentBase> radioComponents)
		{
			return radioComponents.ToDictionary(
				radioComponent => radioComponents.IndexOf(radioComponent),
				radioComponent => radioComponent);
		}

		/// <summary>
		/// Возвращает индексы перечислителя
		/// проиндексированных радиокомпонентов
		/// </summary>
		/// <param name="indexToRadioComponentMap">Перечислитель пар
		/// "индекс-радиокомпонент"</param>
		/// <returns>Массив целых чисел</returns>
		public static int[] GetIndices(
			this IEnumerable<KeyValuePair<int, RadiocomponentBase>>
				indexToRadioComponentMap)
		{
			return indexToRadioComponentMap.Select(
				indexedRadioComponent => indexedRadioComponent.Key)
				.ToArray();
		}
	}
}
