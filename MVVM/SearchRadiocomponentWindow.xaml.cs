﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MVVM
{
    //TODO: когда текстбоксы пустые, они выделяются красной рамкой, даже если текстбокс отключен/заблокирован. Может убрать красную рамку для отключенного текстбокса?
    /// <summary>
    /// Interaction logic for SearchRadiocomponentWindow.xaml
    /// </summary>
    public partial class SearchRadiocomponentWindow : Window
    {
        public SearchRadiocomponentWindow()
        {
            InitializeComponent();
        }
    }
}
