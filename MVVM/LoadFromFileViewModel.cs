using System.Collections.Generic;
using System.Linq;
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

        public string WindowTitle => "Загрузить радиокомпоненты из файла";

        public List<(string, string)> Options
            => _loadOptionToOptionDescriptionMap.Values
                .Select(optionDescription
                    => ((string, string))(optionDescription, null)).ToList();

        public string ActionName => "Загрузить";
        public RelayCommand ActionCommand { get; }
    }
}
