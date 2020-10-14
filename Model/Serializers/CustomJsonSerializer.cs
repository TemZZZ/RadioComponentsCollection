using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Model.Serializers
{
    /// <summary>
    /// Класс JSON-сериализатора.
    /// </summary>
    public class CustomJsonSerializer : ISerializer
    {
        private readonly JsonSerializer _serializer;

        /// <summary>
        /// Создает экземпляр JSON-сериализатора.
        /// </summary>
        public CustomJsonSerializer()
        {
            _serializer = new JsonSerializer
            {
                TypeNameHandling = TypeNameHandling.Objects
            };
        }

        /// <summary>
        /// Позволяет задать или получить связыватель типов сериализуемых
        /// объектов. Используется сериализатором для добавления в JSON
        /// объект информации о типе исходных сериализуемых (целевых
        /// десериализуемых) объектов.
        /// </summary>
        public ISerializationBinder SerializationBinder
        {
            get => _serializer.SerializationBinder;
            set => _serializer.SerializationBinder = value;
        }

        /// <inheritdoc/>
        public void Serialize(TextWriter stream, object serializingObject)
        {
            _serializer.Serialize(stream, serializingObject);
        }

        /// <inheritdoc/>
        public object Deserialize(TextReader stream, Type targetType)
        {
            return _serializer.Deserialize(stream, targetType);
        }
    }
}
