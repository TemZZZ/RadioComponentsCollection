using System;
using Model.Serializers;

namespace Model
{
	/// <summary>
	/// Класс, содержащий методы записи объектов в текстовые файлы, а также
	/// чтения объектов из текстовых файлов.
	/// </summary>
	public class TextFilesReaderWriter
	{
        private readonly ISerializer _serializer;

        #region -- Constructors --

		/// <summary>
		/// Создает объект класса чтения-записи объектов из/в файлы.
		/// </summary>
		/// <param name="serializer">Экземпляр сериализатора.</param>
        public TextFilesReaderWriter(ISerializer serializer)
        {
            _serializer = serializer;
        }

        #endregion

		#region -- Public methods --

		/// <summary>
		/// Сериализует объект и записывает в файл.
		/// </summary>
		/// <typeparam name="T">Класс, поддерживающий сериализацию.
		/// </typeparam>
		/// <param name="serializingObject">Сериализуемый объект.</param>
		/// <param name="fileName">Путь к файлу.</param>
		/// <param name="errorMessager">Делегат для передачи сообщений об
		/// ошибках.</param>
		public void SerializeAndWriteToFile<T>(T serializingObject,
			string fileName, Action<string> errorMessager = null)
		{
			var file = TextFileIOService.GetStreamWriter(fileName,
                errorMessager);
			if (file is null)
			{
				return;
			}

			using (file)
			{
				try
                {
					_serializer.Serialize(file, serializingObject);
				}
				catch (InvalidOperationException)
				{
					var serializationErrorMessage
                        = "Невозможно сериализовать объект " +
                          $"{serializingObject}";
					errorMessager?.Invoke(serializationErrorMessage);
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
		}

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
