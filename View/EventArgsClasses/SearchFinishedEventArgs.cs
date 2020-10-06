using System;

namespace View.EventArgsClasses
{
	/// <summary>
	/// Класс данных события завершения поиска
	/// </summary>
	public class SearchFinishedEventArgs : EventArgs
	{
		/// <summary>
		/// Создает объект данных события завершения поиска
		/// </summary>
		/// <param name="foundIndices">Индексы найденных элементов</param>
		public SearchFinishedEventArgs(int[] foundIndices)
		{
			FoundIndices = foundIndices;
		}

		/// <summary>
		/// Индексы элементов, удовлетворяющих условиям поиска
		/// </summary>
		public int[] FoundIndices { get; }
	}
}
