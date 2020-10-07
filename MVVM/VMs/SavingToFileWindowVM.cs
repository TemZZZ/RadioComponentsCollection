using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using Model.Serializers;

namespace MVVM.VMs
{
    /// <summary>
    /// Класс модели представления окна сохранения радиокомпонентов из файла.
    /// </summary>
    internal sealed class SavingToFileWindowVM
        : ActionWindowVMBase<RadiocomponentsSaveOption>
    {
        #region -- Private fields --

        private const string _defaultExtension = "cmp";
        private const string _filter
            = "Файлы радиокомпонентов (*.cmp)|*.cmp|Все файлы (*.*)|*.*";

        /// <summary>
        /// Опции сохранения радиокомпонентов в файл с описаниями.
        /// </summary>
        private readonly Dictionary<RadiocomponentsSaveOption, string>
            _saveOptionToOptionDescriptionMap
                = new Dictionary<RadiocomponentsSaveOption, string>
                {
                    [RadiocomponentsSaveOption.SaveAll]
                        = "Сохранить все радиокомпоненты",
                    [RadiocomponentsSaveOption.SaveSelected]
                        = "Сохранить только выделенные радиокомпоненты"
                };

        private IEnumerable<RadiocomponentVM>
            _radiocomponents;
        private IEnumerable<RadiocomponentVM>
            _selectedRadiocomponents;

        private RelayCommand _openLoadFromFileDialogCommand;

        #endregion

        #region -- Auxiliary private methods --

        /// <summary>
        /// Возвращает список сохраняемых радиокомпонентов.
        /// </summary>
        /// <param name="printableRadiocomponents">Адаптированные
        /// удобочитаемые радиокомпоненты.</param>
        /// <returns>Список сохраняемых радиокомпонентов.</returns>
        private List<RadiocomponentBase> GetWritingRadiocomponents(
            IEnumerable<RadiocomponentVM>
                printableRadiocomponents)
        {
            if (printableRadiocomponents == null)
            {
                throw new ArgumentNullException(
                    nameof(printableRadiocomponents));
            }

            var writingRadiocomponents = new List<RadiocomponentBase>();
            foreach (var printableRadiocomponent in printableRadiocomponents)
            {
                var radicomponent = printableRadiocomponent.Radiocomponent;
                writingRadiocomponents.Add(radicomponent);
            }
            return writingRadiocomponents;
        }

        #endregion

        #region -- Constructors --

        /// <summary>
        /// Создает экземпляр модели представления сохранения
        /// радиокомпонентов в файл.
        /// </summary>
        /// <param name="radiocomponents">Коллекция всех радиокомпонентов.
        /// </param>
        /// <param name="selectedRadiocomponents">Коллекция выделенных
        /// радиокомпонентов.</param>
        public SavingToFileWindowVM(
            IEnumerable<RadiocomponentVM>
                radiocomponents,
            IEnumerable<RadiocomponentVM>
                selectedRadiocomponents)
        {
            _radiocomponents = radiocomponents;
            _selectedRadiocomponents = selectedRadiocomponents;
        }

        #endregion

        /// <inheritdoc/>
        protected override IDictionary<RadiocomponentsSaveOption, string>
            GetOptionToDescriptionMap()
        {
            return _saveOptionToOptionDescriptionMap;
        }

        /// <inheritdoc/>
        public override string WindowTitle
            => "Сохранить радиокомпоненты в файл";

        /// <inheritdoc/>
        public override string ActionName => "Сохранить";

        /// <summary>
        /// Открывает диалоговое окно сохранения файла радиокомпонентов.
        /// </summary>
        public override RelayCommand ActionCommand
            => _openLoadFromFileDialogCommand
               ?? (_openLoadFromFileDialogCommand = new RelayCommand(
                   obj =>
                   {
                       var option = _saveOptionToOptionDescriptionMap.Keys
                           .ElementAt((int)SelectedOptionIndex);
                       var writingRadiocomponents
                           = new List<RadiocomponentBase>();
                       switch (option)
                       {
                           case RadiocomponentsSaveOption.SaveAll:
                               writingRadiocomponents
                                   = GetWritingRadiocomponents(
                                       _radiocomponents);
                               break;
                           case RadiocomponentsSaveOption.SaveSelected:
                               writingRadiocomponents
                                   = GetWritingRadiocomponents(
                                       _selectedRadiocomponents);
                               break;
                       }

                       var saveFileDialog = new DefaultDialogService();
                       if (writingRadiocomponents.Count == 0)
                       {
                           saveFileDialog.ShowMessage(
                               "Не выделено ни одного радиокомпонента для " +
                               "сохранения.");
                           return;
                       }

                       if (!saveFileDialog.SaveFileDialog(_defaultExtension,
                           _filter))
                       {
                           return;
                       }

                       if (saveFileDialog.FilePath != null)
                       {
                           var serializer = new CustomJsonSerializer
                           {
                               SerializationBinder
                                   = new ChildrenTypesSerializationBinder(
                                       typeof(RadiocomponentBase))
                           };

                           var fileWriter = new TextFilesReaderWriter(
                               serializer);
                           fileWriter.SerializeAndWriteToFile(
                               writingRadiocomponents,
                               saveFileDialog.FilePath,
                               saveFileDialog.ShowMessage);
                       }
                   },
                   obj => SelectedOptionIndex != null));
    }
}
