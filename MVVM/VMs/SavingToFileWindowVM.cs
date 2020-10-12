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
        : ActionWindowVMBase<SaveOption>
    {
        #region -- Private fields --

        private const string _defaultExtension = "cmp";
        private const string _filter
            = "Файлы радиокомпонентов (*.cmp)|*.cmp|Все файлы (*.*)|*.*";

        /// <summary>
        /// Опции сохранения радиокомпонентов в файл с описаниями.
        /// </summary>
        private readonly Dictionary<SaveOption, string>
            _savingOptionToDescriptionDictionary
                = new Dictionary<SaveOption, string>
                {
                    [SaveOption.SaveAll]
                        = "Сохранить все радиокомпоненты",
                    [SaveOption.SaveSelected]
                        = "Сохранить только выделенные радиокомпоненты"
                };

        private IList<RadiocomponentBase> _radiocomponents;
        private IList<RadiocomponentBase> _selectedRadiocomponents;

        private RelayCommand _openSavingToFileDialogCommand;

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
            IList<RadiocomponentBase> radiocomponents,
            IList<RadiocomponentBase> selectedRadiocomponents)
        {
            _radiocomponents = radiocomponents;
            _selectedRadiocomponents = selectedRadiocomponents;
        }

        #endregion

        /// <inheritdoc/>
        protected override IDictionary<SaveOption, string>
            GetOptionToDescriptionDictionary()
        {
            return _savingOptionToDescriptionDictionary;
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
            => _openSavingToFileDialogCommand
               ?? (_openSavingToFileDialogCommand = new RelayCommand(
                   obj =>
                   {
                       var option = _savingOptionToDescriptionDictionary.Keys
                           .ElementAt((int)SelectedOptionIndex);

                       var saveFileDialog = new DefaultDialogService();
                       if (option == SaveOption.SaveSelected
                           && !_selectedRadiocomponents.Any())
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
                           var textFileWriter = new TextFilesReaderWriter(
                               serializer);
                           var radiocomponentsWriter
                               = new RadiocomponentsReaderWriter(
                                   textFileWriter);

                           if (radiocomponentsWriter.SaveToFile(option,
                               saveFileDialog.FilePath, _radiocomponents,
                               _selectedRadiocomponents,
                               saveFileDialog.ShowMessage))
                           {
                               saveFileDialog.ShowMessage(
                                   "Радиокомпоненты успешно сохранены.");
                           }
                       }
                   },
                   obj => SelectedOptionIndex != null));
    }
}
