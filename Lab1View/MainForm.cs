#define TEST

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

using RegexTextBoxLib;


namespace Lab1View
{
    public partial class MainForm : Form
    {
        const string doublePattern =
            @"^[-+]?[0-9]*[\.\,]?[0-9]*([eE]?[-+]?[0-9]*)?$";

        const string positiveDoublePattern =
            @"^[0-9]*[\.\,]?[0-9]*([eE]?[-+]?[0-9]*)?$";

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Список радиокомпонентов
        /// </summary>
        private List<ComponentBase> radioComponents;

        private Regex positiveDoubleRegex =
            new Regex(positiveDoublePattern);


        private void MainForm_Load(object sender, EventArgs e)
        {
#if TEST
            var regexTextBox = new RegexTextBox(
                positiveDoubleRegex);

            regexTextBox.Location = new Point(418, 347);
            this.Controls.Add(regexTextBox);
#endif
        }
    }
}
