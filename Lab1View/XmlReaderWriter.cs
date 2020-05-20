using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;


namespace Lab1View
{
	/// <summary>
	/// Класс, содержащий методы сериализации объектов и записи XML файлы,
	/// а также чтения XML файлов и десериализации объектов
	/// </summary>
	public class XmlReaderWriter
	{
		private Dictionary<Type, string> StreamExceptionTypeToMessageMap
		{ get; } = new Dictionary<Type, string>
		{
			{typeof(ArgumentNullException),
				"Имя файла не может быть пустым."},
			{typeof(DirectoryNotFoundException),
				"Не удается найти часть файла или каталога."},
			{typeof(PathTooLongException),
				"Слишком длинный путь к файлу или его имя."},
			{typeof(UnauthorizedAccessException),
				"Доступ к файлу запрещен."},
			{typeof(FileNotFoundException), "Файл не найден."},
		};

		/// <summary>
		/// Сериализует объект и записывает в XML файл
		/// </summary>
		/// <typeparam name="T">Класс, поддерживающий XML сериализацию
		/// </typeparam>
		/// <param name="serializableObject">Сериализуемый объект</param>
		/// <param name="fileName">Путь к файлу</param>
		/// <param name="errorMessager">Делегат для передачи
		/// сообщений об ошибках</param>
		public void SerializeAndWriteXml<T>(T serializableObject,
			string fileName, Action<string> errorMessager = null)
		{
			var file = GetFileStream(fileName, errorMessager);
			if (file is null)
				return;

			using (file)
			{
				try
				{
					var serializer = new XmlSerializer(
						serializableObject.GetType());
					serializer.Serialize(file, serializableObject);
				}
				catch (InvalidOperationException)
				{
					string serializationErrorText =
						$"Невозможно сериализовать объект " +
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
		/// Создает или перезаписывает файл в указанном пути
		/// </summary>
		/// <param name="fileName">Путь к файлу</param>
		/// <param name="errorMessager">Делегат для передачи
		/// сообщений об ошибках</param>
		/// <returns>Объект <see cref="FileStream"/> или null</returns>
		private FileStream GetFileStream(
			string fileName, Action<string> errorMessager = null)
		{
			return ExceptionHandler.CallFunction(File.Create, fileName,
				StreamExceptionTypeToMessageMap, errorMessager);
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="StreamReader"/>
		/// для указанного имени файла
		/// </summary>
		/// <param name="fileName">Путь к файлу</param>
		/// <param name="errorMessager">Делегат для передачи
		/// сообщений об ошибках</param>
		/// <returns>Объект <see cref="StreamReader"/> или null</returns>
		private StreamReader GetStreamReader(string fileName,
			Action<string> errorMessager = null)
		{
			Func<string, StreamReader> CreateStreamReader =
				_fileName => new StreamReader(_fileName);
			return ExceptionHandler.CallFunction(CreateStreamReader,
				fileName, StreamExceptionTypeToMessageMap, errorMessager);
		}

		/// <summary>
		/// Считывает XML файл и десериализует объект
		/// </summary>
		/// <typeparam name="T">Класс, поддерживающий XML сериализацию
		/// </typeparam>
		/// <param name="fileName">Путь к файлу</param>
		/// <param name="errorMessager">Делегат для передачи
		/// сообщений об ошибках</param>
		/// <returns>Объект класса T или null</returns>
		public T ReadXmlAndDeserialize<T>(string fileName,
			Action<string> errorMessager = null)
		{
			var file = GetStreamReader(fileName, errorMessager);
			if (file is null)
				return default;

			using (file)
			{
				try
				{
					var deserializer = new XmlSerializer(typeof(T));
					return (T)deserializer.Deserialize(file);
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
	}
}
