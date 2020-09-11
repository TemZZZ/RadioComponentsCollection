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

        private IEnumerable<IPrintableRadiocomponent> _radiocomponents;

        private uint? _selectedOptionIndex;
        private RelayCommand _openLoadFromFileDialogCommand;

        public LoadFromFileViewModel(
            IEnumerable<IPrintableRadiocomponent> radiocomponents)
        {
            _radiocomponents = radiocomponents;
        }

        public string WindowTitle => "Загрузить радиокомпоненты из файла";

        public List<(string, string)> Options
            => _loadOptionToOptionDescriptionMap.Values
                .Select(optionDescription
                    => ((string, string))(optionDescription, null)).ToList();

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
               ?? (_openLoadFromFileDialogCommand
                   = new RelayCommand(obj =>
                   {

                   }, obj => SelectedOptionIndex != null));
    }
}
