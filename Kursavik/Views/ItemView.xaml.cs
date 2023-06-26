using Kursavik.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Kursavik.Views
{
    /// <summary>
    /// Логика взаимодействия для ItemView.xaml
    /// </summary>
    public partial class ItemView : Window
    {
        public ItemView()
        {
            InitializeComponent();
            DataContext = new ItemViewModel(this);

        }

        private void Button_Clear(object sender, RoutedEventArgs e)
        {
            Name.Clear();
            Description.Clear();
            Count.Clear();

        }

    }
}
