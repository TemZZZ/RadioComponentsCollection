using System.Collections.Generic;

namespace MVVM
{
    internal class SaveToFileViewModel : ViewModelBase, IActionViewModel
    {
        public string WindowTitle => "Сохранить радиокомпоненты в файл";
        public List<(string, string)> Options { get; }
        public string ActionName => "Сохранить";
        public RelayCommand ActionCommand { get; }
    }
}
