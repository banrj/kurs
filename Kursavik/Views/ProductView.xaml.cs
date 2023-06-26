using Kursavik.ViewModels;
using System;
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

namespace Kursavik.Views
{
    /// <summary>
    /// Логика взаимодействия для ProductView.xaml
    /// </summary>
    public partial class ProductView : Window
    {
        public ProductView()
        {
            InitializeComponent();
            DataContext = new ProductsViewModel(this);
        }

        private void Button_Clear(object sender, RoutedEventArgs e)
        {
            Name.Clear();
            Price.Clear();
            Count.Clear();
            
        }

        private void Show_Items(object sender, RoutedEventArgs e)
        {
            ItemView itemView = new ItemView();
            itemView.Show();
        }
    }
}
