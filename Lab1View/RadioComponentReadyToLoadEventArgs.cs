using System;


namespace Lab1View
{
	/// <summary>
	/// Параметр загрузки радиокомпонентов
	/// </summary>
	public enum RadioComponentLoadOption
	{
		AddToEnd,
		ReplaceAll
	}

	/// <summary>
	/// Класс данных события подтверждения выбора
	/// параметра загрузки радиокомпонента
	/// </summary>
	public class RadioComponentReadyToLoadEventArgs : EventArgs
	{
		/// <summary>
		/// Создает объект класса
		/// <see cref="RadioComponentReadyToLoadEventArgs"/>
		/// </summary>
		/// <param name="radioComponentLoadOption">
		/// Параметр сохранения радиокомпонентов</param>
		public RadioComponentReadyToLoadEventArgs(
			RadioComponentLoadOption radioComponentLoadOption)
		{
			RadioComponentLoadOption = radioComponentLoadOption;
		}

		/// <summary>
		/// Позволяет получить параметр загрузки радиокомпонентов
		/// </summary>
		public RadioComponentLoadOption RadioComponentLoadOption { get; }
	}
}
