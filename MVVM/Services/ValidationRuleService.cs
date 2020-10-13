using System.Windows.Data;

namespace MVVM.Services
{
    public static class ValidationRuleService
    {
        /// <summary>
        /// Возвращает значение, подлежащее валидации. Возвращает исходный
        /// входной параметр, если он не является объектом типа
        /// <see cref="BindingExpression"/>, или вытаскивает значение
        /// привязанного свойства, если входной параметр является экземпляром
        /// типа <see cref="BindingExpression"/>.
        /// </summary>
        /// <param name="value">Исходное значение, подлежащее валидации.
        /// </param>
        /// <returns>Значение типа <see cref="object"/>, подлежащее
        /// валидации.</returns>
        public static object GetValidatingValue(object value)
        {
            if (value == null)
            {
                return null;
            }

            if (!(value is BindingExpression))
            {
                return value;
            }

            return GetBoundPropertyValue((BindingExpression)value);
        }

        /// <summary>
        /// Вытаскивает значение привязанного свойства, указанного в
        /// экземпляре типа <see cref="BindingExpression"/>.
        /// </summary>
        /// <param name="bindingExpression">Объект, содержащий информацию о
        /// привязке.</param>
        /// <returns>Значение типа <see cref="object"/>, подлежащее
        /// валидации.</returns>
        public static object GetBoundPropertyValue(
            BindingExpression bindingExpression)
        {
            var bindingSource = bindingExpression?.ResolvedSource;
            var bindingSourcePropertyName = bindingExpression?
                .ResolvedSourcePropertyName;
            var bindingSourceProperty = bindingSource?.GetType().GetProperty(
                bindingSourcePropertyName);

            return (bindingSourceProperty == null)
                ? null
                : bindingSourceProperty.GetValue(bindingSource);
        }
    }
}
