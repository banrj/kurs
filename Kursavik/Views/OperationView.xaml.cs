using System;
using Kurs.ViewModels;
using Kursasivik.ViewModels;
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
    /// Логика взаимодействия для OperationView.xaml
    /// </summary>
    public partial class OperationView : Window
    {
        public OperationView()
        {
            InitializeComponent();
            DataContext = new OperationViewModel(this);
        }
    }
}
