//#define TEST

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using Lab1Model;

using RegularExpressionTextBoxLib;


namespace Lab1View
{
    public partial class MainForm : Form
    {
        const string doubleNumberPattern =
            @"^[-+]?[0-9]*[\.\,]?[0-9]*([eE]?[-+]?[0-9]*)?$";

        const string positiveDoubleNumberPattern =
            @"^[0-9]*[\.\,]?[0-9]*([eE]?[-+]?[0-9]*)?$";

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Список радиокомпонентов
        /// </summary>
        private List<ComponentBase> radioComponents;

        private Regex positiveDoubleNumberRegularExpression =
            new Regex(positiveDoubleNumberPattern);


        private void MainForm_Load(object sender, EventArgs e)
        {
#if TEST
            RegularExpressionTextBox regexTextBox =
                new RegularExpressionTextBox(
                    positiveDoubleNumberRegularExpression);

            regexTextBox.Location = new Point(418, 347);
            this.Controls.Add(regexTextBox);
#endif
        }
    }
}
