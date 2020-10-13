using System;
using System.Collections.Generic;

namespace Model
{
	/// <summary>
	/// Класс обработки исключений при вызове функций.
	/// </summary>
	public static class ExceptionHandler
	{
		/// <summary>
		/// Вызывает функцию и обрабатывает возможные исключения.
		/// </summary>
		/// <typeparam name="T">Тип входного параметра.</typeparam>
		/// <typeparam name="TResult">Возвращаемый тип.</typeparam>
		/// <param name="function">Функция.</param>
		/// <param name="parameter">Входной параметр функции.</param>
		/// <param name="exceptionTypeToErrorMessageKeyValuePairs">
		/// Перечислитель пар "тип исключения-сообщение при исключении".
		/// </param>
		/// <param name="errorMessager">Делегат для вывода сообщений при
		/// возникновении исключения.</param>
		/// <returns>Объект типа TResult или default(TResult).</returns>
		public static TResult CallFunction<T, TResult>(
			Func<T, TResult> function, T parameter,
			IEnumerable<KeyValuePair<Type, string>>
				exceptionTypeToErrorMessageKeyValuePairs,
			Action<string> errorMessager = null)
		{
			try
			{
				return function(parameter);
			}
			catch (Exception e)
			{
				foreach (var exceptionTypeToErrorMessage in
					exceptionTypeToErrorMessageKeyValuePairs)
				{
					if (exceptionTypeToErrorMessage.Key != e.GetType())
						continue;

					errorMessager?.Invoke(exceptionTypeToErrorMessage.Value);
					return default;
				}
				throw;
			}
		}
	}
}
