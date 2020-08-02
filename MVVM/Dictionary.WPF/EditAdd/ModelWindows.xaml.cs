using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ViewModel.BL;

namespace Dictionary.WPF.EditAdd
{
    /// <summary>
    /// Interaction logic for ModelWindows.xaml
    /// </summary>
    public partial class ModelWindows : Window
    {
        public readonly ModelView ModelView;
        public ModelWindows(ModelView modelView)
        {
            InitializeComponent();
            this.ModelView = modelView;
            this.DataContext = this.ModelView;
        }
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
