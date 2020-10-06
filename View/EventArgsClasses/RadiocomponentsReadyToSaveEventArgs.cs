using System;
using Model;

namespace View.EventArgsClasses
{
    /// <summary>
	/// Класс данных события подтверждения выбора
	/// параметра сохранения радиокомпонента
	/// </summary>
	public class RadiocomponentsReadyToSaveEventArgs : EventArgs
	{
		/// <summary>
		/// Создает объект класса
		/// <see cref="RadiocomponentsReadyToSaveEventArgs"/>
		/// </summary>
		/// <param name="radiocomponentsSaveOption">
		/// Параметр сохранения радиокомпонентов</param>
		public RadiocomponentsReadyToSaveEventArgs(
			RadiocomponentsSaveOption radiocomponentsSaveOption)
		{
			RadiocomponentsSaveOption = radiocomponentsSaveOption;
		}

		/// <summary>
		/// Позволяет получить параметр сохранения радиокомпонентов
		/// </summary>
		public RadiocomponentsSaveOption RadiocomponentsSaveOption { get; }
	}
}
