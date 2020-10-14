using Randomizers;

namespace Model.UnitTests
{
    /// <summary>
    /// Класс подставного рандомизатора с предсказуемым поведением.
    /// Используется для модульного тестирования.
    /// </summary>
    public class FakeRandomizer : IRandomizer
    {
        private int _randomizerState;
        private const int _randomizerMaxState = 3;
        private const int _bigInteger = (int)1e6;

        /// <summary>
        /// Всегда возвращает фиксированное целое число.
        /// </summary>
        /// <returns>Всегда возвращает фиксированное целое число _bigInteger.
        /// </returns>
        public int Next()
        {
            return _bigInteger;
        }

        /// <summary>
        /// Возвращает целое число _randomizerState. Каждый следующий вызов
        /// увеличивает _randomizerState на единицу, но значение
        /// _randomizerState не может быть больше _randomizerMaxState.
        /// </summary>
        /// <param name="maxValue"></param>
        /// <returns>Фиксированное целое число _randomizerState.</returns>
        public int Next(int maxValue)
        {
            var fakeRandomValue = _randomizerState % _randomizerMaxState;
            _randomizerState++;

            return fakeRandomValue;
        }
    }
}
