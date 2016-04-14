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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Domain;

namespace ManagerApp
{
    /// <summary>
    /// Interaction logic for ProductUI.xaml
    /// </summary>
    public partial class ProductUI : UserControl
    {
        public ProductUI()
        {
            InitializeComponent();
            DataContext = new Product();
        }

        public Product SelectedProduct
        {
            get { return DataContext as Product; }  // -> with as -> returns null if DataContext is null
            set { DataContext = value; }
        }
    }
}
