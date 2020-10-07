using System.Collections.Generic;
using System.Linq;
using Model;
using Model.Serializers;

namespace MVVM.VMs
{
    /// <summary>
    /// Класс модели представления окна загрузки новых радиокомпонентов из
    /// файла.
    /// </summary>
    internal sealed class LoadingFromFileWindowVM
        : ActionWindowVMBase<RadiocomponentsLoadOption>
    {
        #region -- Private fields --

        private const string _defaultExtension = "cmp";
        private const string _filter
            = "Файлы радиокомпонентов (*.cmp)|*.cmp|Все файлы (*.*)|*.*";

        /// <summary>
        /// Опции загрузки радиокомпонентов из файла с описаниями.
        /// </summary>
        private readonly Dictionary<RadiocomponentsLoadOption, string>
            _loadOptionToDescriptionMap
                = new Dictionary<RadiocomponentsLoadOption, string>
                {
                    [RadiocomponentsLoadOption.AddToEnd]
                        = "Добавить в конец таблицы",
                    [RadiocomponentsLoadOption.ReplaceAll]
                        = "Заменить все радиокомпоненты в таблице новыми"
                };

        private ICollection<RadiocomponentVM> _radiocomponentVMs;
        private RelayCommand _openLoadFromFileDialogCommand;

        #endregion

        #region -- Auxiliary private methods --

        /// <summary>
        /// Возвращает коллекцию вьюмоделей радиокомпонентов.
        /// </summary>
        /// <param name="radiocomponents">Исходные радиокомпоненты.</param>
        /// <returns>Вьюмодели радиокомпонентов.</returns>
        private IEnumerable<RadiocomponentVM> ToRadiocomponentVMs(
            IEnumerable<RadiocomponentBase> radiocomponents)
        {
            return radiocomponents.Select(radiocomponent
                => new RadiocomponentVM(radiocomponent)).ToList();
        }

        /// <summary>
        /// Возвращает коллекцию радиокомпонентов, полученную из вьюмоделей
        /// радиокомпонентов.
        /// </summary>
        /// <param name="radiocomponentVms"></param>
        /// <returns></returns>
        private List<RadiocomponentBase> GetRadiocomponents(
            IEnumerable<RadiocomponentVM> radiocomponentVms)
        {
            return radiocomponentVms.Select(radiocomponentVM
                => radiocomponentVM.Radiocomponent).ToList();
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

        #endregion

        #region -- Constructors --

        /// <summary>
        /// Создает экземпляр модели представления загрузки радиокомпонентов
        /// из файла.
        /// </summary>
        /// <param name="radiocomponentVMs">Коллекция, в которую добавляются
        /// вьюмодели загруженных из файла радиокомпонентов.</param>
        public LoadingFromFileWindowVM(ICollection<RadiocomponentVM>
            radiocomponentVMs)
        {
            _radiocomponentVMs = radiocomponentVMs;
        }

        #endregion

        /// <inheritdoc/>
        protected override IDictionary<RadiocomponentsLoadOption, string>
            GetOptionToDescriptionMap()
        {
            return _loadOptionToDescriptionMap;
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
            => _openLoadFromFileDialogCommand
               ?? (_openLoadFromFileDialogCommand = new RelayCommand(
                   obj =>
                   {
                       var openFileDialog = new DefaultDialogService();
                       if (!openFileDialog.OpenFileDialog(_defaultExtension,
                           _filter))
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
                       var fileReader = new TextFilesReaderWriter(
                           serializer);
                       var radiocomponentsLoader
                           = new RadiocomponentsReaderWriter(fileReader);

                       var radiocomponents = GetRadiocomponents(
                           _radiocomponentVMs);
                       var option = _loadOptionToDescriptionMap.Keys
                           .ElementAt((int)SelectedOptionIndex);

                       if (radiocomponentsLoader.LoadFromFile(option,
                           openFileDialog.FilePath, radiocomponents,
                           openFileDialog.ShowMessage))
                       {
                           _radiocomponentVMs.Clear();
                           AddItems(_radiocomponentVMs, ToRadiocomponentVMs(
                               radiocomponents));
                           
                           openFileDialog.ShowMessage(
                               "Радиокомпоненты успешно загружены.");
                       }
                   },
                   obj => SelectedOptionIndex != null));
    }
}
