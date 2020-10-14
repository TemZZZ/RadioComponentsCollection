using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace MVVM.VMs
{
    /// <summary>
    /// Коллекция вьюмоделей, синхронизированная с коллекцией моделей.
    /// </summary>
    /// <typeparam name="TViewModel">Тип вьюмоделей.</typeparam>
    /// <typeparam name="TModel">Тип моделей.</typeparam>
    public class SyncObservableViewModelCollection<TViewModel, TModel>
        : ReadOnlyObservableCollection<TViewModel>
    {
        private readonly Func<TModel, TViewModel> _viewModelCreatorFunc;

        /// <summary>
        /// Создает синхронизированную с коллекцией моделей коллекцию
        /// вьюмоделей.
        /// </summary>
        /// <param name="models">Коллекция моделей.</param>
        /// <param name="viewModelCreatorFunc">Функция, создающая вьюмодель
        /// для модели.</param>
        public SyncObservableViewModelCollection(
            ObservableCollection<TModel> models,
            Func<TModel, TViewModel> viewModelCreatorFunc)
            : base(new ObservableCollection<TViewModel>())
        {
            models = models ?? throw new ArgumentNullException(
                nameof(models));
            _viewModelCreatorFunc = viewModelCreatorFunc
                                    ?? throw new ArgumentNullException(
                                        nameof(viewModelCreatorFunc));

            foreach (var model in models)
            {
                Items.Add(_viewModelCreatorFunc(model));
            }

            models.CollectionChanged += OnModelsCollectionChanged;
        }

        /// <summary>
        /// Обработчик изменений, произошедших в коллекции моделей. На каждое
        /// изменение в коллекции моделей происходит аналогичное изменение в
        /// коллекции вьюмоделей.
        /// </summary>
        private void OnModelsCollectionChanged(object sender,
            NotifyCollectionChangedEventArgs e)
        {
            void InternalAdd()
            {
                Items.Insert(e.NewStartingIndex,
                    _viewModelCreatorFunc((TModel)e.NewItems[0]));
            }

            void InternalRemove()
            {
                Items.RemoveAt(e.OldStartingIndex);
            }

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    InternalAdd();
                    break;

                case NotifyCollectionChangedAction.Remove:
                    InternalRemove();
                    break;

                case NotifyCollectionChangedAction.Replace:
                case NotifyCollectionChangedAction.Move:
                    InternalRemove();
                    InternalAdd();
                    break;

                case NotifyCollectionChangedAction.Reset:
                    Items.Clear();
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
