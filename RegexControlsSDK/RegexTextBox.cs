using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace RegexControlsSDK
{
	/// <summary>
	/// Представляет элемент управления Windows текстового поля
	/// с проверкой на соответствие введенных данных
	/// регулярному выражению
	/// </summary>
	public partial class RegexTextBox : TextBox
	{
		/// <summary>
		/// Поле служит для хранения последнего
		/// валидного введенного текста
		/// </summary>
		private string _oldText;
		/// <summary>
		/// Шаблон регулярного выражения
		/// </summary>
		private string _pattern;
		/// <summary>
		/// Объект регулярного выражения
		/// </summary>
		private Regex _regex;

		/// <summary>
		/// Шаблон регулярного выражения
		/// </summary>
		public string Pattern
		{
			get => _pattern;
			set
			{
				if (value != null)
				{
					_pattern = value;
					CreateRegex(_pattern);
				}
			}
		}

		/// <summary>
		/// Создает объект <see cref="Regex"/>
		/// </summary>
		/// <param name="pattern">Шаблон регулярного выражения</param>
		private void CreateRegex(string pattern)
		{
			_regex = new Regex(pattern);
		}

		/// <summary>
		/// Создает элемент <see cref="RegexTextBox"/>
		/// </summary>
		public RegexTextBox()
		{
			InitializeComponent();

			TextChanged += OnTextChanged;
		}

		/// <summary>
		/// Не позволяет пользователю ввести значение,
		/// не соответствующее регулярному выражению
		/// <see cref="_regex"/>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnTextChanged(object sender, EventArgs e)
		{
			if (_regex is null)
				return;

			if (!_regex.IsMatch(this.Text))
			{
				this.Text = _oldText;
				this.SelectionStart = this.Text.Length;
			}

			_oldText = this.Text;
		}
	}
}
