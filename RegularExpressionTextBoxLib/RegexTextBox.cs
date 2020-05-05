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

        public string Pattern { get; set; }

        public RegexTextBox()
        {
            InitializeComponent();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
        }
    }
}
