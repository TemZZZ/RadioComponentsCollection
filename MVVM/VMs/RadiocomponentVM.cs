using System.ComponentModel;
using Model;

namespace MVVM.VMs
{
    /// <summary>
    /// Класс модели представления радиокомпонента.
    /// </summary>
    public class RadiocomponentVM
    {
        /// <summary>
        /// Создает объект модели представления радиокомпонента.
        /// </summary>
        /// <param name="radiocomponent">Исходный радиокомпонент.</param>
        public RadiocomponentVM(RadiocomponentBase radiocomponent)
        {
            Radiocomponent = radiocomponent;
        }

        /// <summary>
        /// Позволяет получить тип радиокомпонента.
        /// </summary>
        [Description("Тип")]
        public string Type
            => RadiocomponentService.ToString(Radiocomponent.Type);

        /// <summary>
        /// Позволяет получить физическую величину радиокомпонента.
        /// </summary>
        [Description("Физическая величина")]
        public string Quantity
            => RadiocomponentService.ToString(Radiocomponent.Quantity);

        /// <summary>
        /// Позволяет получить или задать значение физической величины
        /// радиокомпонента.
        /// </summary>
        [Description("Значение")]
        public double Value
        {
            get => Radiocomponent.Value;
            set => Radiocomponent.Value = value;
        }

        /// <summary>
        /// Позволяет получить единицу измерения физической величины
        /// радиокомпонента.
        /// </summary>
        [Description("Единица измерения")]
        public string Unit
            => RadiocomponentService.ToString(Radiocomponent.Unit);

        /// <summary>
        /// Позволяет получить исходный радиокомпонент.
        /// </summary>
        [Browsable(false)]
        public RadiocomponentBase Radiocomponent { get; }
    }
}
