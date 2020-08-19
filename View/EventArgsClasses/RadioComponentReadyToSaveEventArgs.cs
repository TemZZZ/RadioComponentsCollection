using System;


namespace View
{
	/// <summary>
	/// Параметр сохранения радиокомпонентов
	/// </summary>
	public enum RadiocomponentSaveOption
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
		/// <param name="radiocomponentSaveOption">
		/// Параметр сохранения радиокомпонентов</param>
		public RadiocomponentReadyToSaveEventArgs(
			RadiocomponentSaveOption radiocomponentSaveOption)
		{
			RadiocomponentSaveOption = radiocomponentSaveOption;
		}

		/// <summary>
		/// Позволяет получить параметр сохранения радиокомпонентов
		/// </summary>
		public RadiocomponentSaveOption RadiocomponentSaveOption { get; }
	}
}
