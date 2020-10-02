namespace Randomizers
{
    /// <summary>
    /// Реализация паттерна Ambient Context (контекст окружения, одна из
    /// вариаций паттерна "Синглтон") для возможности установки нужного
    /// класса рандомизатора.
    /// </summary>
    public class GlobalRandomizer
    {
        /// <summary>
        /// Позволяет получить или задать экземпляр рандомизатора. По
        /// умолчанию возвращает экземпляр класса
        /// <see cref="DefaultRandomizer"/>.
        /// </summary>
        public static IRandomizer Instance { get; set; }
            = new DefaultRandomizer();
    }
}
