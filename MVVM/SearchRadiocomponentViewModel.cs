using System.Collections.Generic;
using System.Linq;
using Model;

namespace MVVM
{
    /// <summary>
    /// Класс модели представления поиска радиокомпонентов по коллекции.
    /// </summary>
    internal class SearchRadiocomponentViewModel : ViewModelBase
    {
        #region -- Private fields --

        private Dictionary<string, RadiocomponentType>
            _typeNameToRadiocomponentTypeMap;
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

        /// <summary>
        /// Создает и возвращает словарь, ставящий в соответствие читаемым
        /// именам типов радиокомпонентов сами типы радиокомпонентов.
        /// </summary>
        /// <param name="radiocomponentTypes">Типы радиокомпонентов.</param>
        /// <returns>Словарь, ставящий в соответствие читаемым именам типов
        /// радиокомпонентов сами типы радиокомпонентов.</returns>
        private Dictionary<string, RadiocomponentType>
            GetTypeNameToRadiocomponentTypeMap(
                IEnumerable<RadiocomponentType> radiocomponentTypes)
        {
            return radiocomponentTypes.ToDictionary(
                RadiocomponentService.ToString);
        }

        /// <summary>
        /// Возвращает коллекцию проиндексированных адаптированных
        /// радиокомпонентов заданного типа.
        /// </summary>
        /// <param name="desiredType">Желаемый тип радиокомпонентов.</param>
        /// <param name="indexedRadiocomponents">Исходная коллекция
        /// проиндексированных адаптированных радиокомпонентов.</param>
        /// <returns></returns>
        private IEnumerable<(int, RadiocomponentToPrintableRadiocomponentAdapter)>
            GetFilteredByTypeIndexedRadiocomponents(
                RadiocomponentType desiredType,
                IEnumerable<(int, RadiocomponentToPrintableRadiocomponentAdapter)>
                    indexedRadiocomponents)
        {
            return
                from indexedRadiocomponent in indexedRadiocomponents
                where indexedRadiocomponent.Item2.GetRadiocomponent().Type
                      == desiredType
                select indexedRadiocomponent;
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
            _typeNameToRadiocomponentTypeMap
                = GetTypeNameToRadiocomponentTypeMap(
                    availableRadiocomponentTypes);
            _indexedRadiocomponents = GetIndexedRadiocomponents(
                radiocomponents);
        }

        #endregion
    }
}
