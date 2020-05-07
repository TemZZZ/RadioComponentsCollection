using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Lab1Model;


namespace Lab1View
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Список радиокомпонентов
        /// </summary>
        private List<RadioComponentBase> radioComponents;

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
