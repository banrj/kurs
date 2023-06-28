using Kurs.Model;
using System;
using Kursavik.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Data.Entity;

namespace Kursasivik.ViewModels
{
    public class OperationViewModel
    {
        private OperationView window;
        private Operation selectedOperation;
        ModelContext db = new ModelContext();
        public ObservableCollection<Operation> OperationList { get; set; }
        public ObservableCollection<Product> ProductList { get; set; }
       
        public Operation SelectedOperation
        {
            get { return selectedOperation; }
            set
            {
                selectedOperation = value;
                OnPropertyChanged("SelectedOperation");
            }
        }
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      Operation operation = new Operation();
                      operation.plan_id = int.Parse(window.IDPlan.Text);
                      operation.workshop_id = int.Parse(window.IDWorkshop.Text);
                      operation.product_id = (window.IDProduct.SelectedItem as Product).ID;
                      operation.time = int.Parse(window.Time.Text);
                      operation.description = window.Description.Text;
                      db.Operation.Add(operation);
                      db.SaveChanges();
                  }));
            }
        }

        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                  (removeCommand = new RelayCommand(obj =>
                  {
                      Operation operation = obj as Operation;
                      OperationList.Remove(operation);
                      if (operation == null) return;
                      db.Operation.Remove(operation);
                      db.SaveChanges();
                  }));
            }
        }
        public OperationViewModel(OperationView window)
        {
            this.window = window;
            db.Database.EnsureCreated();
            db.Operation.Load();
            db.Product.Load();
            ProductList = db.Product.Local.ToObservableCollection();
            
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
