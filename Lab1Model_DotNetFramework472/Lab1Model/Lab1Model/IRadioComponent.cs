using System.Numerics;


namespace Lab1Model
{
    /// <summary>
    /// Представляет интерфейс радиокомпонента
    /// </summary>
    public interface IRadioComponent
    {
        /// <summary>
        /// Позволяет получить или присвоить значение физической величины радиокомпонента
        /// </summary>
        double Value { get; set; }

        /// <summary>
        /// Единица измерения физической величины радиокомпонента
        /// </summary>
        string Unit { get; }

        /// <summary>
        /// Тип компонента
        /// </summary>
        string Type { get; }

        /// <summary>
        /// Возвращает частотнозависимый комплексный импеданс радиокомпонента
        /// </summary>
        /// <param name="freq">Частота в герцах</param>
        /// <returns>Комплексный импеданс в омах</returns>
        Complex GetImpedance(double freq);
    }
}
