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
        private string _oldText;
        private string _pattern;
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
            if (_regex is null) { base.OnTextChanged(e); }
        }

        protected override void OnLostFocus(EventArgs e)
        {
            if (_regex is null) { base.OnLostFocus(e); }
        }
    }
}
