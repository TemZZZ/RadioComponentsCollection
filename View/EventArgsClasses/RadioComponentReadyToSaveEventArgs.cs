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
	public class RadiocomponentReadyToSaveEventArgs : EventArgs
	{
		/// <summary>
		/// Создает объект класса
		/// <see cref="RadiocomponentReadyToSaveEventArgs"/>
		/// </summary>
		/// <param name="radiocomponentsSaveOption">
		/// Параметр сохранения радиокомпонентов</param>
		public RadiocomponentReadyToSaveEventArgs(
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
