using System.Numerics;


namespace Model
{
	/// <summary>
	/// Представляет интерфейс радиокомпонента
	/// </summary>
	public interface IRadiocomponent
	{
		/// <summary>
		/// Позволяет получить или присвоить значение физической
		/// величины радиокомпонента
		/// </summary>
		double Value { get; set; }

		/// <summary>
		/// Позволяет получить единицу измерения в СИ радиокомпонента
		/// </summary>
		RadiocomponentUnit Unit { get; }

		/// <summary>
		/// Тип радиокомпонента
		/// </summary>
		string Type { get; }

		/// <summary>
		/// Позволяет получить физическую величину радиокомпонента
		/// </summary>
		RadiocomponentQuantity Quantity { get; }

		/// <summary>
		/// Возвращает частотнозависимый комплексный импеданс радиокомпонента
		/// </summary>
		/// <param name="frequency">Частота в герцах</param>
		/// <returns>Комплексный импеданс в омах</returns>
		Complex GetImpedance(double frequency);
	}
}
