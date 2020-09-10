namespace Model
{
    /// <summary>
    /// Класс адаптера радиокомпонента к его удобочитаемому представлению.
    /// </summary>
    public class RadiocomponentToPrintableRadiocomponentAdapter
        : IPrintableRadiocomponent
    {
        private RadiocomponentBase _radiocomponent;

        /// <summary>
        /// Создает объект адаптера радиокомпонента к его удобочитаемому
        /// представлению.
        /// </summary>
        /// <param name="radiocomponent">Адаптируемый радиокомпонент.</param>
        public RadiocomponentToPrintableRadiocomponentAdapter(
            RadiocomponentBase radiocomponent)
        {
            _radiocomponent = radiocomponent;
        }

        /// <inheritdoc/>
        public string Type
            => RadiocomponentService.ToString(_radiocomponent.Type);

        /// <inheritdoc/>
        public string Quantity
            => RadiocomponentService.ToString(_radiocomponent.Quantity);

        /// <inheritdoc/>
        public double Value
        {
            get => _radiocomponent.Value;
            set => _radiocomponent.Value = value;
        }

        /// <inheritdoc/>
        public string Unit
            => RadiocomponentService.ToString(_radiocomponent.Unit);

        /// <inheritdoc/>
        public RadiocomponentBase GetRadiocomponent()
        {
            return _radiocomponent;
        }
    }
}
