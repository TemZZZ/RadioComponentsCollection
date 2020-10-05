using System;
using System.IO;

namespace Model
{
    /// <summary>
    /// Интерфейс сериализатора.
    /// </summary>
    public interface ISerializer
    {
        /// <summary>
        /// Сериализует объект и передает его в поток вывода.
        /// </summary>
        /// <param name="stream">Поток вывода.</param>
        /// <param name="serializingObject">Сериализуемый объект.</param>
        void Serialize(TextWriter stream, object serializingObject);

        /// <summary>
        /// Десериализует объект, полученный из потока ввода.
        /// </summary>
        /// <param name="stream">Поток ввода.</param>
        /// <param name="targetType">Тип десериализованного объекта.</param>
        object Deserialize(TextReader stream, Type targetType);
    }
}
