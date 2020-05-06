using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Lab1Model;


namespace Lab1View
{
    public partial class MainForm : Form
    {
        const string doublePattern =
            @"^[-+]?([0-9]+[\.\,]?[0-9]*([eE]?[-+]?[0-9]*))?$";

        const string positiveDoublePattern =
            @"^([0-9]+[\.\,]?[0-9]*([eE]?[-+]?[0-9]*))?$";

        /// <summary>
        /// Список радиокомпонентов
        /// </summary>
        private List<ComponentBase> radioComponents;

        AddRadioComponentForm addRadioComponentForm;

        public MainForm()
        {
            InitializeComponent();

            addRadioComponentForm = new AddRadioComponentForm();
        }

        private void AddRadioComponentButton_Click(
            object sender, EventArgs e)
        {
            addRadioComponentForm.ShowDialog();
        }
    }
}
