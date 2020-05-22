using System;
using Model;


namespace View
{
	/// <summary>
	/// Класс данных события создания нового радиокомпонента
	/// </summary>
	public class RadioComponentCreatedEventArgs : EventArgs
    {
        /// <summary>
        /// Создает объект класса
        /// <see cref="RadioComponentCreatedEventArgs"/>
        /// </summary>
        /// <param name="radioComponent">
        /// Созданный объект радиокомпонента</param>
        public RadioComponentCreatedEventArgs(
            RadioComponentBase radioComponent)
        {
            RadioComponent = radioComponent;
        }

        /// <summary>
        /// Объект радиокомпонента
        /// </summary>
        public RadioComponentBase RadioComponent { get; }
    }
}
