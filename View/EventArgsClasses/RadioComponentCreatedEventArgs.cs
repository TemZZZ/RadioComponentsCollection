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
		/// <param name="radiocomponent">
		/// Созданный объект радиокомпонента</param>
		public RadioComponentCreatedEventArgs(
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
