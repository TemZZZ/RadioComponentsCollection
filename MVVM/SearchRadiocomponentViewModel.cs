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
        private IEnumerable<RadiocomponentToPrintableRadiocomponentAdapter>
            _radiocomponents;

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
            IEnumerable<RadiocomponentToPrintableRadiocomponentAdapter>
                radiocomponents)
        {
            _availableRadiocomponentTypes = availableRadiocomponentTypes;
            _radiocomponents = radiocomponents;
        }

        #endregion
    }
}
