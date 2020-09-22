namespace Model
{
    /// <summary>
    /// Интерфейс удобочитаемого представления радиокомпонента.
    /// </summary>
    public interface IRadiocomponentViewModel
    {
        /// <summary>
        /// Позволяет получить тип радиокомпонента.
        /// </summary>
        string Type { get; }

        /// <summary>
        /// Позволяет получить физическую величину радиокомпонента.
        /// </summary>
        string Quantity { get; }

        /// <summary>
        /// Позволяет получить или задать значение физической величины
        /// радиокомпонента.
        /// </summary>
        double Value { get; set; }

        /// <summary>
        /// Позволяет получить единицу измерения физической величины
        /// радиокомпонента.
        /// </summary>
        string Unit { get; }

        /// <summary>
        /// Позволяет получить исходный радиокомпонент.
        /// </summary>
        RadiocomponentBase Radiocomponent { get; }
    }
}
