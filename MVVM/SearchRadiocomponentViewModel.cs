using System.Collections.Generic;
using Model;

namespace MVVM
{
    /// <summary>
    /// Класс модели представления поиска радиокомпонентов по коллекции.
    /// </summary>
    internal class SearchRadiocomponentViewModel : ViewModelBase
    {
        #region -- Private fields --

        private IEnumerable<RadiocomponentType>
            _availableRadiocomponentTypes;
        private List<(int, RadiocomponentToPrintableRadiocomponentAdapter)>
            _indexedRadiocomponents;

        #endregion

        #region -- Auxiliary private methods --

        /// <summary>
        /// Возвращает проиндексированную коллекцию адаптированных
        /// удобочитаемых компонентов.
        /// </summary>
        /// <param name="radiocomponents">Исходные адаптированные
        /// радиокомпоненты.</param>
        /// <returns>Список пар значений "индекс-адаптированный
        /// радиокомпонент".</returns>
        private List<(int, RadiocomponentToPrintableRadiocomponentAdapter)>
            GetIndexedRadiocomponents(
                IList<RadiocomponentToPrintableRadiocomponentAdapter>
                    radiocomponents)
        {
            var indexedRadiocomponents
                = new List<(int, RadiocomponentToPrintableRadiocomponentAdapter)>();
            for (int i = 0; i < radiocomponents.Count; ++i)
            {
                indexedRadiocomponents.Add((i, radiocomponents[i]));
            }
            return indexedRadiocomponents;
        }

        #endregion

        #region -- Constructors --

        /// <summary>
        /// Создает экземпляр модели представления поиска радиокомпонентов.
        /// </summary>
        /// <param name="availableRadiocomponentTypes">Доступные типы
        /// радиокомпонентов для поиска.</param>
        /// <param name="radiocomponents">Коллекция радиокомпонентов, по
        /// которой производится поиск.</param>
        public SearchRadiocomponentViewModel(
            IEnumerable<RadiocomponentType> availableRadiocomponentTypes,
            IList<RadiocomponentToPrintableRadiocomponentAdapter>
                radiocomponents)
        {
            _availableRadiocomponentTypes = availableRadiocomponentTypes;
            _indexedRadiocomponents = GetIndexedRadiocomponents(
                radiocomponents);
        }

        #endregion
    }
}
