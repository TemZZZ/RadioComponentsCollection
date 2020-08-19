using System;


namespace View
{
	/// <summary>
	/// Параметр загрузки радиокомпонентов
	/// </summary>
	public enum RadiocomponentLoadOption
	{
		AddToEnd,
		ReplaceAll
	}

	/// <summary>
	/// Класс данных события подтверждения выбора
	/// параметра загрузки радиокомпонента
	/// </summary>
	public class RadiocomponentReadyToLoadEventArgs : EventArgs
	{
		/// <summary>
		/// Создает объект класса
		/// <see cref="RadiocomponentReadyToLoadEventArgs"/>
		/// </summary>
		/// <param name="radiocomponentLoadOption">
		/// Параметр сохранения радиокомпонентов</param>
		public RadiocomponentReadyToLoadEventArgs(
			RadiocomponentLoadOption radiocomponentLoadOption)
		{
			RadiocomponentLoadOption = radiocomponentLoadOption;
		}

		/// <summary>
		/// Позволяет получить параметр загрузки радиокомпонентов
		/// </summary>
		public RadiocomponentLoadOption RadiocomponentLoadOption { get; }
	}
}
