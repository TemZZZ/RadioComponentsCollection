using System;

namespace View
{
	/// <summary>
	/// Параметр загрузки радиокомпонентов
	/// </summary>
	public enum RadiocomponentsLoadOption
	{
		AddToEnd,
		ReplaceAll
	}

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
		/// <param name="radiocomponentsLoadOption">
		/// Параметр сохранения радиокомпонентов</param>
		public RadiocomponentsReadyToLoadEventArgs(
			RadiocomponentsLoadOption radiocomponentsLoadOption)
		{
			RadiocomponentsLoadOption = radiocomponentsLoadOption;
		}

		/// <summary>
		/// Позволяет получить параметр загрузки радиокомпонентов
		/// </summary>
		public RadiocomponentsLoadOption RadiocomponentsLoadOption { get; }
	}
}
