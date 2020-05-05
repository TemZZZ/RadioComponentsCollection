using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        const string defaultText = "0";

        private readonly Regex _regularExpression;
        private string _oldText = defaultText;

        public RegexTextBox() : this(string.Empty) { }

        public RegexTextBox(string pattern)
        {
            if (string.IsNullOrEmpty(pattern))
            {
                _regularExpression = new Regex(pattern);
            }

            this.Initialize();
        }

        public RegexTextBox(Regex regularExpression)
        {
            _regularExpression = regularExpression;

            this.Initialize();
        }

        private void Initialize()
        {
            this.Text = defaultText;

            InitializeComponent();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            if (_regularExpression is null)
            {
                base.OnTextChanged(e);

                return;
            }

            if (!_regularExpression.IsMatch(this.Text))
            {
                this.Text = _oldText;
                this.SelectionStart = this.Text.Length;

                return;
            }

            _oldText = this.Text;
        }

        protected override void OnLostFocus(EventArgs e)
        {
            double _value;

            try
            {
                _value = Convert.ToDouble(this.Text);
            }
            catch (FormatException)
            {
                this.Text = defaultText;
            }
        }
    }
}
