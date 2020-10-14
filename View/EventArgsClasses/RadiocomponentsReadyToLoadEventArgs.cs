using System;
using Model;
using Model.IO;

namespace View.EventArgsClasses
{
    /// <summary>
	/// Класс данных события подтверждения выбора
	/// параметра загрузки радиокомпонента
	/// </summary>
	public class RadiocomponentsReadyToLoadEventArgs : EventArgs
	{
		/// <summary>
		/// Создает объект класса
		/// <see cref="RadiocomponentsReadyToLoadEventArgs"/>
		/// </summary>
		/// <param name="loadOption">
		/// Параметр сохранения радиокомпонентов</param>
		public RadiocomponentsReadyToLoadEventArgs(
			LoadOption loadOption)
		{
			LoadOption = loadOption;
		}

		/// <summary>
		/// Позволяет получить параметр загрузки радиокомпонентов
		/// </summary>
		public LoadOption LoadOption { get; }
	}
}
