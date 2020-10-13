using System;
using Model.Serializers;
using Model.Services;

namespace Model
{
	/// <summary>
	/// Класс чтения объектов из текстовых файлов.
	/// </summary>
	public class TextFileReader
    {
        private readonly ISerializer _serializer;

        #region -- Constructors --

        /// <summary>
        /// Создает экземпляр класса чтения объектов из текстового файла.
        /// </summary>
        /// <param name="serializer">Экземпляр сериализатора.</param>
        public TextFileReader(ISerializer serializer)
        {
            _serializer = serializer;
        }

		#endregion

		#region -- Public methods --

		/// <summary>
		/// Считывает файл и десериализует объект.
		/// </summary>
		/// <typeparam name="T">Класс, поддерживающий сериализацию.
		/// </typeparam>
		/// <param name="fileName">Путь к файлу.</param>
		/// <param name="errorMessager">Делегат для передачи сообщений об
		/// ошибках.</param>
		/// <returns>Объект класса T или null.</returns>
		public T ReadFileAndDeserialize<T>(string fileName,
			Action<string> errorMessager = null)
		{
			var file = TextFileIOService.GetStreamReader(fileName,
				errorMessager);
			if (file is null)
			{
				return default;
			}

			using (file)
			{
				try
				{
					return (T)_serializer.Deserialize(file, typeof(T));
				}
				catch (InvalidOperationException)
				{
					var deserializationErrorMessage
						= $"Невозможно десериализовать файл {fileName} в " +
						  $"объект типа {typeof(T)}";
					errorMessager?.Invoke(deserializationErrorMessage);
					if (errorMessager == null)
					{
						throw;
					}
				}
				catch (Exception e)
				{
					errorMessager?.Invoke(e.Message);
					throw;
				}
			}
			return default;
		}

		#endregion
	}
}
