using System;

namespace RandomizersLib
{
    /// <summary>
    /// Класс стандартного рандомизатора, реализованного на базе класса
    /// Random.
    /// </summary>
    public class DefaultRandomizer : IRandomizer
    {
        private readonly Random _random = new Random();

        /// <inheritdoc/>
        public int Next()
        {
            return _random.Next();
        }

        /// <inheritdoc/>
        public int Next(int maxValue)
        {
            return _random.Next(maxValue);
        }
    }
}
