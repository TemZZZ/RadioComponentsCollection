using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace View
{
	/// <summary>
	/// Класс универсальной коллекции,
	/// которая поддерживает привязку данных
	/// и возможность сортировки объектов по полям,
	/// например в элементе DataGridView.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class SortableBindingList<T> : BindingList<T>
	{
		/// <inheritdoc/>
		protected override void ApplySortCore(
			PropertyDescriptor prop, ListSortDirection direction)
		{
			var originalList = Items;
			List<T> sortedList;

			if (direction == ListSortDirection.Ascending)
			{
				sortedList = originalList.
					OrderBy(propertyValue => prop.GetValue(propertyValue)).
					ToList();
			}
			else
			{
				sortedList = originalList.
					OrderByDescending(
					properyValue => prop.GetValue(properyValue)).ToList();
			}

			originalList.Clear();

			foreach (var item in sortedList)
			{
				originalList.Add(item);
			}
		}

		/// <inheritdoc/>
		protected override bool SupportsSortingCore => true;
	}
}
