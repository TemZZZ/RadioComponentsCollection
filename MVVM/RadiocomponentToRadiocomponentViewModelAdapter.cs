using System.ComponentModel;
using Model;

namespace MVVM
{
    /// <summary>
    /// Класс адаптера радиокомпонента к его удобочитаемому представлению.
    /// </summary>
    public class RadiocomponentToRadiocomponentViewModelAdapter
        : IRadiocomponentViewModel
    {
        /// <summary>
        /// Создает объект адаптера радиокомпонента к его удобочитаемому
        /// представлению.
        /// </summary>
        /// <param name="radiocomponent">Адаптируемый радиокомпонент.</param>
        public RadiocomponentToRadiocomponentViewModelAdapter(
            RadiocomponentBase radiocomponent)
        {
            Radiocomponent = radiocomponent;
        }

        /// <inheritdoc/>
        [Description("Тип")]
        public string Type
            => RadiocomponentService.ToString(Radiocomponent.Type);

        /// <inheritdoc/>
        [Description("Физическая величина")]
        public string Quantity
            => RadiocomponentService.ToString(Radiocomponent.Quantity);

        /// <inheritdoc/>
        [Description("Значение")]
        public double Value
        {
            get => Radiocomponent.Value;
            set => Radiocomponent.Value = value;
        }

        /// <inheritdoc/>
        [Description("Единица измерения")]
        public string Unit
            => RadiocomponentService.ToString(Radiocomponent.Unit);

        /// <summary>
        /// Позволяет получить неадаптированный радиокомпонент.
        /// </summary>
        [Browsable(false)]
        public RadiocomponentBase Radiocomponent { get; }
    }
}
