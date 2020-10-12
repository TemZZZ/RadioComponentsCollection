﻿using System.Collections.Generic;
using System.Linq;
using Model;
using Model.Serializers;
using Newtonsoft.Json;

namespace MVVM.VMs
{
    /// <summary>
    /// Класс модели представления окна загрузки новых радиокомпонентов из
    /// файла.
    /// </summary>
    internal sealed class LoadingRadiocomponentsWindowVM
        : ActionWindowVMBase<LoadOption>
    {
        #region -- Private fields --

        private IList<RadiocomponentBase> _radiocomponents;
        private RelayCommand _openLoadingFromFileDialogCommand;

        #endregion

        #region -- Constructors --

        /// <summary>
        /// Создает экземпляр модели представления загрузки радиокомпонентов
        /// из файла.
        /// </summary>
        /// <param name="radiocomponents">Коллекция, в которую добавляются
        /// загруженные из файла радиокомпоненты.</param>
        public LoadingRadiocomponentsWindowVM(
            IList<RadiocomponentBase> radiocomponents)
        {
            _radiocomponents = radiocomponents;
        }

        #endregion

        /// <inheritdoc/>
        protected override IDictionary<LoadOption, string>
            GetOptionToDescriptionDictionary()
        {
            return RadiocomponentsReaderWriter
                .LoadOptionToDescriptionDictionary;
        }

        /// <inheritdoc/>
        public override string WindowTitle
            => "Загрузить радиокомпоненты из файла";

        /// <inheritdoc/>
        public override string ActionName => "Загрузить";

        /// <summary>
        /// Открывает диалоговое окно открытия файла, содержащего
        /// радиокомпоненты для загрузки.
        /// </summary>
        public override RelayCommand ActionCommand
            => _openLoadingFromFileDialogCommand
               ?? (_openLoadingFromFileDialogCommand = new RelayCommand(
                   obj =>
                   {
                       var openFileDialog = new DefaultDialogService();
                       if (!openFileDialog.OpenFileDialog(
                           RadiocomponentsReaderWriter.DefaultExtension,
                           RadiocomponentsReaderWriter.DefaultFilesFilter))
                       {
                           return;
                       }
                       if (openFileDialog.FilePath == null)
                       {
                           return;
                       }

                       var serializer = new CustomJsonSerializer
                       {
                           SerializationBinder
                               = new ChildrenTypesSerializationBinder(
                                   typeof(RadiocomponentBase))
                       };
                       var textFileReader = new TextFilesReaderWriter(
                           serializer);
                       var radiocomponentsReader
                           = new RadiocomponentsReaderWriter(textFileReader);
                       
                       var option = GetOptionToDescriptionDictionary().Keys
                           .ElementAt((int)SelectedOptionIndex);

                       try
                       {
                           if (radiocomponentsReader.LoadFromFile(option,
                               openFileDialog.FilePath, _radiocomponents,
                               openFileDialog.ShowMessage))
                           {
                               openFileDialog.ShowMessage(
                                   "Радиокомпоненты успешно загружены.");
                           }
                       }
                       catch (JsonReaderException)
                       {

                       }
                   },
                   obj => SelectedOptionIndex != null));
    }
}