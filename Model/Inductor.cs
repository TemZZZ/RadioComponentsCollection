﻿using System;
using System.Numerics;


namespace Model
{
	namespace PassiveComponents
	{
		/// <summary>
		/// Класс катушки индуктивности
		/// </summary>
		public class Inductor : RadioComponentBase
		{
			/// <summary>
			/// Создает экземпляр класса <see cref="Inductor"/>
			/// </summary>
			public Inductor() : base(0) { }

			/// <summary>
			/// Создает экземпляр класса <see cref="Inductor"/>
			/// </summary>
			/// <param name="value">Значение индуктивности в генри</param>
			public Inductor(double value) : base(value) { }

			/// <inheritdoc/>
			protected override Complex CalcImpedance(double frequency)
			{
				const double zeroRealPart = 0;

				return new Complex(zeroRealPart,
					2 * Math.PI * (frequency * Value));
			}

			/// <inheritdoc/>
			public override string Unit => "Гн";
			/// <inheritdoc/>
			public override string Type => "Катушка индуктивности";
			/// <inheritdoc/>
			public override string Quantity => "Индуктивность";
		}
	}
}
