using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json.Serialization;

namespace Model
{
    /// <summary>
    /// Класс-связыватель дочерних типов одного супер-класса с сериализуемыми
    /// объектами.
    /// </summary>
    public class ChildrenTypesSerializationBinder : ISerializationBinder
    {
        private IEnumerable<Type> _childrenTypes;

        /// <summary>
        /// Создает экземпляр класса-связывателя дочерних типов одного
        /// супер-класса с сериализуемыми объектами.
        /// </summary>
        /// <param name="baseType">Супер-класс, дочерние типы которого могут
        /// быть связаны с сериализуемыми объектами.</param>
        public ChildrenTypesSerializationBinder(Type baseType)
        {
            _childrenTypes = Assembly.GetAssembly(baseType).GetTypes()
                .Where(type => type.IsSubclassOf(baseType));
        }

        /// <inheritdoc/>
        public Type BindToType(string assemblyName, string typeName)
        {
            return _childrenTypes.SingleOrDefault(
                type => type.Name == typeName);
        }

        /// <inheritdoc/>
        public void BindToName(Type serializedType, out string assemblyName,
            out string typeName)
        {
            assemblyName = null;
            typeName = serializedType.Name;
        }
    }
}
