using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.UnitTests
{
	/// <summary>
	/// Набор тестов, общих для классов, производных от
	/// <see cref="RadioComponentBase"/>
	/// </summary>
	/// <typeparam name="T">Класс, производный от
	/// <see cref="RadioComponentBase"/></typeparam>
	[TestFixture]
	public abstract class RadioComponentBaseTests<T>
		where T : RadioComponentBase, new()
	{
		const double MinRadioComponentValue = 0;

		/// <summary>
		/// Когда свойству <see cref="RadioComponentBase.Value"/>
		/// присваивается значение value, то свойство
		/// <see cref="RadioComponentBase.Value"/> должно стать равно value
		/// </summary>
		/// <param name="value">Значение свойства
		/// <see cref="RadioComponentBase.Value"/></param>
		[Test]
		public void ValueProperty_AssignedGoodValues_IsAssigned(double value)
		{
			// Setup
			var expected = value;

			// Act
			var radioComponent = new T
			{
				Value = value
			};
			var actual = radioComponent.Value;

			// Assert
			Assert.AreEqual(expected, actual);
		}
	}
}
