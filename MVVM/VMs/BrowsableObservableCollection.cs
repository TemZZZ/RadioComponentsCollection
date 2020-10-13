using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MVVM.VMs
{
    /// <summary>
    /// Класс коллекции с возможностью привязки к ней, а также с возможностью
    /// скрывать видимость публичных свойств, например, в DataGrid с помощью
    /// атрибута <see cref="BrowsableAttribute"/>.
    /// </summary>
    /// <typeparam name="T">Тип элементов коллекции.</typeparam>
    public class BrowsableObservableCollection<T>
        : ObservableCollection<T>, ITypedList
    {
        /// <summary>
        /// Массив элементов типа <see cref="Attribute"/>, используемых в
        /// качестве фильтров элементов коллекции.
        /// </summary>
        private readonly Attribute[] _propertyFilter =
        {
            BrowsableAttribute.Yes
        };

        /// <inheritdoc/>
        public string GetListName(PropertyDescriptor[] listAccessors)
        {
            return null;
        }

        /// <inheritdoc/>
        public PropertyDescriptorCollection GetItemProperties(
            PropertyDescriptor[] listAccessors)
        {
            return TypeDescriptor.GetProperties(typeof(T), _propertyFilter);
        }
    }
}
