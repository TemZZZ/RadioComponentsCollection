using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace MVVM
{
    /// <summary>
    /// Класс элемента управления содержимым, представляющий таблицу
    /// <see cref="DataGrid"/>, но имеющий возможность привязки к выделенным
    /// элементам, чего нет в обычном <see cref="DataGrid"/>.
    /// </summary>
    public class CustomDataGrid : DataGrid
    {
        #region -- Dependency properties --

        /// <summary>
        /// Свойство зависимости, к которому можно привязаться,
        /// представляющее выделенные элементы таблицы.
        /// </summary>
        public static readonly DependencyProperty
            BindableSelectedItemsProperty;

        #endregion

        #region -- Constructors --

        /// <summary>
        /// Регистрирует свойства зависимостей.
        /// </summary>
        static CustomDataGrid()
        {
            BindableSelectedItemsProperty = DependencyProperty.Register(
                nameof(BindableSelectedItems), typeof(IList),
                typeof(CustomDataGrid), new PropertyMetadata(null));
        }

        /// <summary>
        /// Создает экземпляр класса <see cref="CustomDataGrid"/>.
        /// </summary>
        public CustomDataGrid()
        {
            SelectionChanged += OnCustomDataGridSelectionChanged;

            // Принудительно выделяет первый элемент таблицы при первом
            // добавлении новых элементов. Без этой строки привязанное к
            // BindableSelectedItems свойство вьюмодели будет null, если
            // пользователь еще ни разу не выделил ни одной строки, вместо
            // пустой коллекции объектов.
            SelectedIndex = 0;
        }

        #endregion

        #region -- Public properties --

        /// <summary>
        /// Позволяет получить или задать выделенные элементы таблицы.
        /// </summary>
        public IList BindableSelectedItems
        {
            get => (IList)GetValue(BindableSelectedItemsProperty);
            set => SetValue(BindableSelectedItemsProperty, value);
        }

        #endregion

        #region -- Auxiliary private methods --

        /// <summary>
        /// Позволяет получить или задать выделенные элементы таблицы.
        /// </summary>
        /// <summary>
        /// Срабатывает при изменении выделения таблицы. Присваивает свойству
        /// <see cref="BindableSelectedItems"/> выделенные элементы.
        /// </summary>
        private void OnCustomDataGridSelectionChanged(object sender,
            SelectionChangedEventArgs e)
        {
            BindableSelectedItems = SelectedItems;
        }

        #endregion
    }
}
