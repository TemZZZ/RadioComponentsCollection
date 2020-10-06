using System;
using System.Collections.Generic;
using System.IO;
using Model.Serializers;

namespace Model
{
	/// <summary>
	/// Класс, содержащий методы записи объектов в файлы, а также чтения
	/// объектов из файлов.
	/// </summary>
	public class FilesReaderWriter
	{
		#region -- Private fields --

        private readonly ISerializer _serializer;

		/// <summary>
        /// Возможные в процессе доступа к файлам типы исключений и
        /// соответствующие им сообщения.
        /// </summary>
        private readonly Dictionary<Type, string>
            _streamExceptionTypeToMessageDictionary = new Dictionary<Type, string>
            {
                [typeof(ArgumentNullException)]
                    = "Имя файла не может быть пустым.",

                [typeof(DirectoryNotFoundException)]
                    = "Не удается найти часть файла или каталога.",

                [typeof(PathTooLongException)]
                    = "Слишком длинный путь к файлу или его имя.",

                [typeof(UnauthorizedAccessException)]
                    = "Доступ к файлу запрещен. Возможно, у Вас не " +
                      "достаточно прав для доступа к файлу.",

                [typeof(FileNotFoundException)] = "Файл не найден.",

                [typeof(IOException)]
                    = "Доступ к файлу запрещен. Возможно, он используется " +
                      "другим процессом."
            };

		#endregion

        #region -- Constructors --

		/// <summary>
		/// Создает объект класса чтения-записи объектов из/в файлы.
		/// </summary>
		/// <param name="serializer">Экземпляр сериализатора.</param>
        public FilesReaderWriter(ISerializer serializer)
        {
            _serializer = serializer;
        }

        #endregion

		#region -- Auxiliary private methods --

		/// <summary>
		/// Создает или перезаписывает файл по указанному пути.
		/// </summary>
		/// <param name="fileName">Путь к файлу.</param>
		/// <param name="errorMessager">Делегат для передачи сообщений об
		/// ошибках.</param>
		/// <returns>Объект <see cref="FileStream"/> или null.</returns>
		private FileStream GetFileStream(string fileName,
            Action<string> errorMessager = null)
        {
            return ExceptionHandler.CallFunction(File.Create, fileName,
                _streamExceptionTypeToMessageDictionary, errorMessager);
        }

        /// <summary>
        /// Создает или перезаписывает текстовый файл по указанному пути.
        /// </summary>
        /// <param name="fileName">Путь к файлу.</param>
        /// <param name="errorMessager">Делегат для передачи сообщений об
        /// ошибках.</param>
        /// <returns>Объект <see cref="StreamWriter"/> или null.</returns>
        private StreamWriter GetStreamWriter(string fileName,
            Action<string> errorMessager = null)
        {
            return ExceptionHandler.CallFunction(File.CreateText, fileName,
                _streamExceptionTypeToMessageDictionary, errorMessager);
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="StreamReader"/>
        /// для указанного имени файла.
        /// </summary>
        /// <param name="fileName">Путь к файлу.</param>
        /// <param name="errorMessager">Делегат для передачи сообщений об
        /// ошибках.</param>
        /// <returns>Объект <see cref="StreamReader"/> или null.</returns>
        private StreamReader GetStreamReader(string fileName,
            Action<string> errorMessager = null)
        {
            Func<string, StreamReader> CreateStreamReader =
                _fileName => new StreamReader(_fileName);
            return ExceptionHandler.CallFunction(CreateStreamReader,
                fileName, _streamExceptionTypeToMessageDictionary,
                errorMessager);
        }

		#endregion

		#region -- Public methods --

		/// <summary>
		/// Сериализует объект и записывает в файл.
		/// </summary>
		/// <typeparam name="T">Класс, поддерживающий сериализацию.
		/// </typeparam>
		/// <param name="serializableObject">Сериализуемый объект.</param>
		/// <param name="fileName">Путь к файлу.</param>
		/// <param name="errorMessager">Делегат для передачи сообщений об
		/// ошибках.</param>
		public void SerializeAndWriteToFile<T>(T serializableObject,
			string fileName, Action<string> errorMessager = null)
		{
			var file = GetStreamWriter(fileName, errorMessager);
			if (file is null)
			{
				return;
			}

			using (file)
			{
				try
                {
					_serializer.Serialize(file, serializableObject);
				}
				catch (InvalidOperationException)
				{
					string serializationErrorText =
						"Невозможно сериализовать объект " +
						$"{serializableObject}";
					errorMessager?.Invoke(serializationErrorText);
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
			var file = GetStreamReader(fileName, errorMessager);
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
					string deserializationErrorText =
						$"Невозможно десериализовать файл {fileName} " +
						$"в объект типа {typeof(T)}";
					errorMessager?.Invoke(deserializationErrorText);
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
