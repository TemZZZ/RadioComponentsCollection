using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace MVVM
{
    /// <summary>
    /// Коллекция вьюмоделей, синхронизированная с коллекцией моделей.
    /// </summary>
    /// <typeparam name="TViewModel">Тип вьюмоделей.</typeparam>
    /// <typeparam name="TModel">Тип моделей.</typeparam>
    public class ObservableViewModelCollection<TViewModel, TModel>
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
        public ObservableViewModelCollection(
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
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    //add
                    for (int i = 0; i < e.NewItems.Count; ++i)
                    {
                        Items.Insert(e.NewStartingIndex + i,
                            _viewModelCreatorFunc((TModel)e.NewItems[i]));
                    }
                    break;

                case NotifyCollectionChangedAction.Remove:
                    //remove
                    for (int i = 0; i < e.OldItems.Count; ++i)
                    {
                        Items.RemoveAt(e.OldStartingIndex);
                    }
                    break;

                case NotifyCollectionChangedAction.Replace:
                    //remove
                    for (int i = 0; i < e.OldItems.Count; ++i)
                    {
                        Items.RemoveAt(e.OldStartingIndex);
                    }
                    //add
                    for (int i = 0; i < e.NewItems.Count; ++i)
                    {
                        Items.Insert(e.NewStartingIndex + i,
                            _viewModelCreatorFunc((TModel)e.NewItems[i]));
                    }
                    break;

                case NotifyCollectionChangedAction.Move:
                    if (e.OldItems.Count == 1)
                    {
                        //Move(e.OldStartingIndex, e.NewStartingIndex);
                    }
                    else
                    {
                        var items = this.Skip(e.OldStartingIndex)
                            .Take(e.OldItems.Count).ToList();
                        //remove
                        for (int i = 0; i < e.OldItems.Count; i++)
                        {
                            Items.RemoveAt(e.OldStartingIndex);
                        }

                        for (int i = 0; i < items.Count; i++)
                        {
                            Items.Insert(e.NewStartingIndex + i, items[i]);
                        }
                    }
                    break;

                case NotifyCollectionChangedAction.Reset:
                    Items.Clear();
                    foreach (var newItem in e.NewItems)
                    {
                        Items.Add(_viewModelCreatorFunc((TModel)newItem));
                    }
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
