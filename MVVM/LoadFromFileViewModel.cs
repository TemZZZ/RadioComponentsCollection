using System.Collections.Generic;

namespace MVVM
{
    internal class LoadFromFileViewModel : ViewModelBase, IActionViewModel
    {
        public string WindowTitle => "Загрузить радиокомпоненты из файла";
        public List<(string, string)> Options { get; }
        public string ActionName => "Загрузить";
        public RelayCommand ActionCommand { get; }
    }
}
