using System.Numerics;


namespace Lab1Model
{
    /// <summary>
    /// Представляет интерфейс радиокомпонента
    /// </summary>
    public interface IComponent
    {
        /// <summary>
        /// Позволяет получить или присвоить значение физической величины радиокомпонента
        /// </summary>
        double Value { get; set; }

        /// <summary>
        /// Возвращает частотнозависимый комплексный импеданс радиокомпонента
        /// </summary>
        /// <param name="freq">Частота в герцах</param>
        /// <returns>Комплексный импеданс в омах</returns>
        Complex GetImpedance(double freq);
    }
}
