using System.ComponentModel;

namespace Model
{
    /// <summary>
    /// Класс адаптера радиокомпонента к его удобочитаемому представлению.
    /// </summary>
    public class RadiocomponentToRadiocomponentViewModelAdapter
        : IRadiocomponentViewModel
    {
        private RadiocomponentBase _radiocomponent;

        /// <summary>
        /// Создает объект адаптера радиокомпонента к его удобочитаемому
        /// представлению.
        /// </summary>
        /// <param name="radiocomponent">Адаптируемый радиокомпонент.</param>
        public RadiocomponentToRadiocomponentViewModelAdapter(
            RadiocomponentBase radiocomponent)
        {
            _radiocomponent = radiocomponent;
        }

        /// <inheritdoc/>
        [Description("Тип")]
        public string Type
            => RadiocomponentService.ToString(_radiocomponent.Type);

        /// <inheritdoc/>
        [Description("Физическая величина")]
        public string Quantity
            => RadiocomponentService.ToString(_radiocomponent.Quantity);

        /// <inheritdoc/>
        [Description("Значение")]
        public double Value
        {
            get => _radiocomponent.Value;
            set => _radiocomponent.Value = value;
        }

        /// <inheritdoc/>
        [Description("Единица измерения")]
        public string Unit
            => RadiocomponentService.ToString(_radiocomponent.Unit);

        /// <summary>
        /// Позволяет получить неадаптированный радиокомпонент.
        /// </summary>
        [Browsable(false)]
        public RadiocomponentBase Radiocomponent => _radiocomponent;
    }
}
