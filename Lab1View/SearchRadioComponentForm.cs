using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1View
{
	public partial class SearchRadioComponentForm : Form
	{
		private const string _allText = "<Все>";
		private const string _resistorText = "Резистор";
		private const string _inductorText = "Катушка индуктивности";
		private const string _capacitorText = "Конденсатор";

		/// <summary>
		/// Источник данных для <see cref="radioComponentTypeComboBox"/>
		/// </summary>
		private string[] _radioComponentTypeComboBoxItems =
		{
			_allText,
			_resistorText,
			_inductorText,
			_capacitorText
		};

		public SearchRadioComponentForm()
		{
			InitializeComponent();

			radioComponentTypeComboBox.DataSource =
				_radioComponentTypeComboBoxItems;
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
