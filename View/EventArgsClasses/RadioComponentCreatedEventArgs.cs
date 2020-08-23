using System;
using Model;

namespace View
{
	/// <summary>
	/// Класс данных события создания нового радиокомпонента
	/// </summary>
	public class RadiocomponentCreatedEventArgs : EventArgs
	{
		/// <summary>
		/// Создает объект класса
		/// <see cref="RadiocomponentCreatedEventArgs"/>
		/// </summary>
		/// <param name="radiocomponent">
		/// Созданный объект радиокомпонента</param>
		public RadiocomponentCreatedEventArgs(
			RadiocomponentBase radiocomponent)
		{
			Radiocomponent = radiocomponent;
		}

		/// <summary>
		/// Объект радиокомпонента
		/// </summary>
		public RadiocomponentBase Radiocomponent { get; }
	}
}
