using System.Collections.Generic;
using System.Linq;
using View;

namespace MVVM
{
    internal class SaveToFileViewModel : ViewModelBase, IActionViewModel
    {
        private readonly Dictionary<RadiocomponentsSaveOption, string>
            _saveOptionToOptionDescriptionMap
                = new Dictionary<RadiocomponentsSaveOption, string>
                {
                    [RadiocomponentsSaveOption.SaveAll]
                        = "Сохранить все радиокомпоненты",
                    [RadiocomponentsSaveOption.SaveSelected]
                        = "Сохранить только выделенные радиокомпоненты"
                };

        private uint? _selectedOptionIndex;
        private RelayCommand _openLoadFromFileDialogCommand;

        public string WindowTitle => "Сохранить радиокомпоненты в файл";

        public List<(string, string)> Options
            => _saveOptionToOptionDescriptionMap.Values
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

        public string ActionName => "Сохранить";

        public RelayCommand ActionCommand
            => _openLoadFromFileDialogCommand
               ?? (_openLoadFromFileDialogCommand
                   = new RelayCommand(obj =>
                   {

                   }, obj => SelectedOptionIndex != null));
    }
}
