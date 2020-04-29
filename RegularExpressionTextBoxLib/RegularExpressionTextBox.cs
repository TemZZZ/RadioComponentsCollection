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


namespace RegularExpressionTextBoxLib
{
    /// <summary>
    /// Представляет элемент управления Windows текстового поля
    /// с проверкой на соответствие введенных данных
    /// регулярному выражению
    /// </summary>
    public partial class RegularExpressionTextBox: TextBox
    {
        /// <summary>
        /// Регулярное выражение для проверки введенных данных
        /// </summary>
        public Regex RegularExpression { get; set; }
        public RegularExpressionTextBox()
        {
            InitializeComponent();
        }
    }
}
