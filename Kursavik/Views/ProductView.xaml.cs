using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Kurs.ViewModels;
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

     
        private void Show_Items(object sender, RoutedEventArgs e)
        {
            ItemView itemView = new ItemView();
            itemView.Show();
        }

        private void Show_Operations(object sender, RoutedEventArgs e)
        {
            OperationView operationView = new OperationView();
            operationView.Show();
        }

        private void Show_TypeInstrument(object sender, RoutedEventArgs e)
        {
            InstrumentView instrumentView = new InstrumentView();
            instrumentView.Show();
        }

        private void Show_Instruments(object sender, RoutedEventArgs e)
        {
            InstrumentsView instrumentsView = new InstrumentsView();
            instrumentsView.Show();
        }
    }
}
