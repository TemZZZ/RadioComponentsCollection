using System;
using Model;

namespace View
{
	/// <summary>
	/// Класс данных события создания нового радиокомпонента
	/// </summary>
	public class RadiocomponentCreatedEventArgs_ : EventArgs
	{
		/// <summary>
		/// Создает объект класса
		/// <see cref="RadiocomponentCreatedEventArgs_"/>
		/// </summary>
		/// <param name="radiocomponent">
		/// Созданный объект радиокомпонента</param>
		public RadiocomponentCreatedEventArgs_(
			RadiocomponentBase_ radiocomponent)
		{
			Radiocomponent = radiocomponent;
		}

		/// <summary>
		/// Объект радиокомпонента
		/// </summary>
		public RadiocomponentBase_ Radiocomponent { get; }
	}
}
