using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Kursavik.ViewModels;
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
    /// Логика взаимодействия для InstrumentView.xaml
    /// </summary>
    public partial class InstrumentView : Window
    {
        public InstrumentView()
        {
            InitializeComponent();
            DataContext = new InstrumentViewModel(this);
        }
    }
}
