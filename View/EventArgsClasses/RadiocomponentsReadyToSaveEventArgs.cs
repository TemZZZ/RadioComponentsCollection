using System;

namespace View
{
	/// <summary>
	/// Параметр сохранения радиокомпонентов
	/// </summary>
	public enum RadiocomponentsSaveOption
	{
		SaveAll,
		SaveSelected
	}

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
