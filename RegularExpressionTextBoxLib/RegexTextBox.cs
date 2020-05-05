using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace RegexTextBoxLib
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

        public string Pattern
        {
            get { return _pattern; }
            set
            {
                _pattern = value;
                CreateRegex(_pattern);
            }
        }

        private void CreateRegex(string pattern)
        {
            _regex = new Regex(pattern);
        }

        public RegexTextBox()
        {
            InitializeComponent();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            if (_regex is null)
            {
                base.OnTextChanged(e);
                return;
            }

            if (!_regex.IsMatch(this.Text))
            {
                this.Text = _oldText;
                this.SelectionStart = this.Text.Length;
            }

            _oldText = this.Text;
        }
    }
}
