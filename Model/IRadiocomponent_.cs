namespace Model
{
	/// <summary>
	/// Представляет интерфейс радиокомпонента
	/// </summary>
	public interface IRadiocomponent_
	{
        /// <summary>
        /// Позволяет получить или присвоить значение физической величины
        /// раиокомпонента в СИ
        /// </summary>
		double Value { get; set; }

		/// <summary>
		/// Позволяет получить единицу измерения в СИ радиокомпонента
		/// </summary>
		RadiocomponentUnit Unit { get; }

        /// <summary>
		/// Позволяет получить физическую величину радиокомпонента
		/// </summary>
        RadiocomponentQuantity Quantity { get; }
    }
}
