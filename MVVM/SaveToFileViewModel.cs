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

        public string WindowTitle => "Сохранить радиокомпоненты в файл";

        public List<(string, string)> Options
            => _saveOptionToOptionDescriptionMap.Values
                .Select(optionDescription
                    => ((string, string))(optionDescription, null)).ToList();

        public uint? SelectedOptionIndex { get; set; }

        public string ActionName => "Сохранить";
        public RelayCommand ActionCommand { get; }
    }
}
