using System.Collections.Generic;
using System.Linq;
using Model;
using View;

namespace MVVM
{
    internal class LoadFromFileViewModel : ViewModelBase, IActionViewModel
    {
        private readonly Dictionary<RadiocomponentsLoadOption, string>
            _loadOptionToOptionDescriptionMap
                = new Dictionary<RadiocomponentsLoadOption, string>
                {
                    [RadiocomponentsLoadOption.AddToEnd]
                        = "Добавить в конец таблицы",
                    [RadiocomponentsLoadOption.ReplaceAll]
                        = "Заменить все радиокомпоненты в таблице новыми"
                };

        private ICollection<RadiocomponentToPrintableRadiocomponentAdapter>
            _radiocomponents;
        private uint? _selectedOptionIndex;
        private RelayCommand _openLoadFromFileDialogCommand;

        /// <summary>
        /// Возвращает коллекцию адаптированных удобочитаемых
        /// радиокомпонентов.
        /// </summary>
        /// <param name="radiocomponents">Исходные радиокомпоненты.</param>
        /// <returns>Адаптированные удобочитаемые радиокомпоненты.</returns>
        private IEnumerable<RadiocomponentToPrintableRadiocomponentAdapter>
            ToPrintableRadiocomponents(
                IEnumerable<RadiocomponentBase> radiocomponents)
        {
            return radiocomponents.Select(radiocomponent
                => new RadiocomponentToPrintableRadiocomponentAdapter(
                    radiocomponent)).ToList();
        }

        /// <summary>
        /// Добавляет элементы в исходную коллекцию.
        /// </summary>
        /// <typeparam name="T">Тип элементов коллекций.</typeparam>
        /// <param name="sourceCollection">Исходная коллекция.</param>
        /// <param name="additionalCollection">Добавляемые элементы.</param>
        private void AddItems<T>(ICollection<T> sourceCollection,
            IEnumerable<T> additionalCollection)
        {
            foreach (var additionItem in additionalCollection)
            {
                sourceCollection.Add(additionItem);
            }
        }

        public LoadFromFileViewModel(
            ICollection<RadiocomponentToPrintableRadiocomponentAdapter>
                radiocomponents)
        {
            _radiocomponents = radiocomponents;
        }

        public string WindowTitle => "Загрузить радиокомпоненты из файла";

        public List<(string, string)> Options
            => _loadOptionToOptionDescriptionMap.Values.Select(
                optionDescription => ((string, string))(
                    optionDescription, null)).ToList();

        public uint? SelectedOptionIndex
        {
            get => _selectedOptionIndex;
            set
            {
                _selectedOptionIndex = value;
                RaisePropertyChanged();
            }
        }

        public string ActionName => "Загрузить";

        public RelayCommand ActionCommand
            => _openLoadFromFileDialogCommand
               ?? (_openLoadFromFileDialogCommand = new RelayCommand(
                   obj =>
                   {
                       var openFileDialog = new DefaultDialogService();
                       if (!openFileDialog.OpenFileDialog())
                       {
                           return;
                       }
                       if (openFileDialog.FilePath == null)
                       {
                           return;
                       }

                       var xmlReader = new XmlReaderWriter();
                       var newRadiocomponents = xmlReader
                           .ReadXmlAndDeserialize<List<RadiocomponentBase>>(
                               openFileDialog.FilePath);

                       var option = _loadOptionToOptionDescriptionMap.Keys
                           .ElementAt((int)SelectedOptionIndex);
                       switch (option)
                       {
                           case RadiocomponentsLoadOption.ReplaceAll:
                               _radiocomponents.Clear();
                               break;
                           case RadiocomponentsLoadOption.AddToEnd:
                               break;
                        }

                       AddItems(_radiocomponents,
                           ToPrintableRadiocomponents(newRadiocomponents));
                   },
                   obj => SelectedOptionIndex != null));
    }
}
