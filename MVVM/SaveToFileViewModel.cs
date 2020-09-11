﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Model;
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

        private IEnumerable<IPrintableRadiocomponent> _radiocomponents;
        private IList _selectedRadiocomponents;

        private uint? _selectedOptionIndex;
        private RelayCommand _openLoadFromFileDialogCommand;

        /// <summary>
        /// Возвращает список сохраняемых радиокомпонентов.
        /// </summary>
        /// <param name="printableRadiocomponents">Адаптированные
        /// удобочитаемые радиокомпоненты.</param>
        /// <returns>Список сохраняемых радиокомпонентов.</returns>
        private List<RadiocomponentBase> GetWritingRadiocomponents(
            IEnumerable printableRadiocomponents)
        {
            var writingRadiocomponents = new List<RadiocomponentBase>();
            foreach (var radiocomponentAsObject in printableRadiocomponents)
            {
                var printableRadiocomponent
                    = (IPrintableRadiocomponent)radiocomponentAsObject;
                var radicomponent
                    = printableRadiocomponent.GetRadiocomponent();
                writingRadiocomponents.Add(radicomponent);
            }
            return writingRadiocomponents;
        }

        public SaveToFileViewModel(
            IEnumerable<IPrintableRadiocomponent> radiocomponents,
            IList selectedRadiocomponents)
        {
            _radiocomponents = radiocomponents;
            _selectedRadiocomponents = selectedRadiocomponents;
        }

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
                       IDIalogService saveFileDialog
                           = new DefaultDialogService();

                       var option = _saveOptionToOptionDescriptionMap
                           .Keys.ElementAt((int)SelectedOptionIndex);
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

                       if (writingRadiocomponents.Count == 0)
                       {
                           saveFileDialog.ShowMessage(
                               "Не выделено ни одного радиокомпонента для " +
                               "сохранения.");
                           return;
                       }

                       if (!saveFileDialog.SaveFileDialog())
                       {
                           return;
                       }

                       if (saveFileDialog.FilePath != null)
                       {
                           var xmlWriter = new XmlReaderWriter();
                           xmlWriter.SerializeAndWriteXml(
                               writingRadiocomponents,
                               saveFileDialog.FilePath);
                       }
                   }, obj => SelectedOptionIndex != null));
    }
}
