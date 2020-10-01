using System;
using System.Collections.Generic;
using System.Windows;

namespace MVVM
{
    //TODO: понятие Presentation из паттерна MVP, а не MVVM. В MVVM роль P (Presentation) играет VM (ViewModel)
    /// <summary>
    /// Реестр типов моделей представлений (ViewModel) и связанных с ними
    /// типами представлений (View).
    /// </summary>
    public class PresentationRootRegistry
    {
        #region -- Private fields --

        //TODO: Map переименовать в Dictionary
        /// <summary>
        /// Словарь, ставящий в соответствие типу модели представления
        /// зарегистрированный на него тип окна.
        /// </summary>
        private Dictionary<Type, Type> _viewModelTypeToWindowTypeMap
            = new Dictionary<Type, Type>();

        #endregion

        #region -- Auxiliary private methods ---

        /// <summary>
        /// Проверяет, не является ли тип модели представления интерфейсом.
        /// </summary> 
        /// <typeparam name="TViewModel">Тип модели представления. //TODO: какой-то кусок старого комментария с шаблоном
        /// </typeparam> 
        /// <exception cref="ArgumentException"></exception>
        private void CheckViewModelTypeIsNotInterface(Type viewModelType)
        {
            //TODO: метод, выбрасывающий исключение, лучше именовать Assert. А если bool, то Is
            if (viewModelType.IsInterface)
            {
                throw new ArgumentException("ViewModel type cannot be an " +
                                            "interface.");
            }
        }

        #endregion

        #region -- Public methods --

        /// <summary>
        /// Регистрирует тип окна на тип модели представления.
        /// </summary>
        /// <typeparam name="TViewModel">Тип модели представления.
        /// </typeparam>
        /// <typeparam name="TWindow">Тип окна.</typeparam>
        /// <exception cref="InvalidOperationException"></exception>
        public void RegisterWindowType<TViewModel, TWindow>()
            where TViewModel : class
            where TWindow : Window, new()
        {
            var viewModelType = typeof(TViewModel);
            CheckViewModelTypeIsNotInterface(viewModelType);

            if (_viewModelTypeToWindowTypeMap.ContainsKey(viewModelType))
            {
                throw new InvalidOperationException(
                    $"ViewModel type {viewModelType.FullName} is already " +
                    "registered.");
            }
            _viewModelTypeToWindowTypeMap[viewModelType] = typeof(TWindow);
        }

        /// <summary>
        /// Удаляет из реестра тип модели представления и зарегистрированный
        /// на него тип окна (представления).
        /// </summary>
        /// <typeparam name="TViewModel">Тип модели представления.
        /// </typeparam>
        /// <exception cref="InvalidOperationException"></exception>
        public void UnregisterWindowType<TViewModel>()
            where TViewModel : class
        {
            var viewModelType = typeof(TViewModel);
            CheckViewModelTypeIsNotInterface(viewModelType);

            if (!_viewModelTypeToWindowTypeMap.ContainsKey(viewModelType))
            {
                throw new InvalidOperationException(
                    $"ViewModel type {viewModelType.FullName} is not " +
                    "registered.");
            }
            _viewModelTypeToWindowTypeMap.Remove(viewModelType);
        }

        /// <summary>
        /// Создает и возвращает новое окно типа, который зарегистрирован на
        /// тип входного объекта модели представления.
        /// </summary>
        /// <param name="viewModel">Входной объект модели представления.
        /// </param>
        /// <returns>Новое окно с контекстом данных (DataContext).</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public Window CreateWindowWithDataContext(object viewModel)
        {
            if (viewModel == null)
            {
                throw new ArgumentNullException(nameof(viewModel));
            }

            Type windowType = null;
            var viewModelType = viewModel.GetType();
            while (viewModelType != null
                   && (!_viewModelTypeToWindowTypeMap.TryGetValue(
                       viewModelType, out windowType)))
            {
                viewModelType = viewModelType.BaseType;
            }

            if (windowType == null)
            {
                throw new ArgumentNullException(
                    "No registered window type for ViewModel type " +
                    $"{viewModel.GetType().FullName}.");
            }

            var window = (Window)Activator.CreateInstance(windowType);
            window.DataContext = viewModel;
            return window;
        }

        #endregion
    }
}
