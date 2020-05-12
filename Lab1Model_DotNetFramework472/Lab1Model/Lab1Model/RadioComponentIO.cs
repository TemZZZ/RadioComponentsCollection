using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System;

namespace Lab1Model
{
	/// <summary>
	/// Класс, содержащий методы чтения из файлов и записи в файл
	/// объектов <see cref="RadioComponentBase"/>
	/// </summary>
	public static class RadioComponentIO
	{
		/// <summary>
		/// Сохраняет в файл объект <see cref="RadioComponentBase"/>
		/// </summary>
		/// <param name="radioComponent">Объект класса
		/// <see cref="RadioComponentBase"/></param>
		/// <param name="fileName">Путь к файлу</param>
		public static void WriteXml(
			RadioComponentBase radioComponent, string fileName)
		{
			Serialize(radioComponent, fileName);
		}

		/// <summary>
		/// Сохраняет в файл список объектов
		/// <see cref="RadioComponentBase"/>
		/// </summary>
		/// <param name="radioComponents">Список объектов
		/// <see cref="RadioComponentBase"/></param>
		/// <param name="fileName">Путь к файлу</param>
		public static void WriteXml(
			List<RadioComponentBase> radioComponents, string fileName)
		{
			Serialize(radioComponents, fileName);
		}

		/// <summary>
		/// Общий метод для сериализации и записи в файл
		/// </summary>
		/// <param name="serializableObject">Сериализуемый объект</param>
		/// <param name="fileName">Путь к файлу</param>
		private static void Serialize(
			object serializableObject, string fileName)
		{
			var serializer = new XmlSerializer(
				serializableObject.GetType());

			using (var file = File.Create(fileName))
			{
				serializer.Serialize(file, serializableObject);
				file.Close();
			}
		}

		private static FileStream GetFile(
			string fileName, Action<string> messager = null)
		{
			FileStream file = null;
			try
			{
				file = File.Create(fileName);
			}
			catch (UnauthorizedAccessException)
			{
				messager?.Invoke($"Доступ к файлу {fileName}" +
					$"заблокирован. Возможно, он используется " +
					$"другим процессом или у Вас отсутствуют " +
					$"права доступа к этому файлу");
			}
			catch (PathTooLongException)
			{
				messager?.Invoke("Слишком длинное имя файла " +
					"или путь к нему");
			}
			catch (DirectoryNotFoundException)
			{
				messager?.Invoke("Не удалось найти файл {fileName}");
			}
			catch (IOException)
			{
				messager?.Invoke("");
			}
			catch (NotSupportedException)
			{
				messager?.Invoke("");
			}
			return file;
		}
	}
}
