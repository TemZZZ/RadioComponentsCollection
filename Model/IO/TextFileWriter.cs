using System;
using Model.Serializers;
using Model.Services;

namespace Model.IO
{
	/// <summary>
	/// Класс записи объектов в текстовый файл.
	/// </summary>
    public class TextFileWriter
    {
        private readonly ISerializer _serializer;

        #region -- Constructors --

        /// <summary>
        /// Создает экземпляр класса записи объектов в текстовый файл.
        /// </summary>
        /// <param name="serializer">Экземпляр сериализатора.</param>
        public TextFileWriter(ISerializer serializer)
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

		#endregion
	}
}
