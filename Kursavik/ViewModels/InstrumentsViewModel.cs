using Kurs.Model;
using Kursavik.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kursavik.ViewModels
{
    public class InstrumentsViewModel : INotifyPropertyChanged
    {
        private InstrumentsView window;
        private Instruments selectedInstruments;
        ModelContext db = new ModelContext();
        public ObservableCollection<Instruments> InstrumentsList { get; set; }
        public ObservableCollection<TypeInstrument> InstrumentList { get; set; }
        public ObservableCollection<Operation> OperationList { get; set; }

        public Instruments SelectedInstruments
        {
            get { return selectedInstruments; }
            set
            {
                selectedInstruments = value;
                OnPropertyChanged("SelectedInstruments");
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
                      Instruments instruments = new Instruments();
                      instruments.Receipt_date = window.Receipt_date.Text;
                      instruments.Type = (window.Type.SelectedItem as TypeInstrument).ID;
                      instruments.Operation_id = (window.Operation_id.SelectedItem as Operation).ID;

                      db.Instruments.Add(instruments);
                      db.SaveChanges();
                      InstrumentsList.Add(instruments);
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
                      Instruments instruments = obj as Instruments;
                      if (instruments == null) return;
                      db.Instruments.Remove(instruments);
                      db.SaveChanges();
                      InstrumentsList.Remove(instruments);

                  }));
            }
        }
        public InstrumentsViewModel(InstrumentsView window)
        {
            this.window = window;
            db.Database.EnsureCreated();
            db.Instruments.Load();
            db.Operation.Load();
            db.TypeInstrument.Load();
            OperationList = db.Operation.Local.ToObservableCollection();
            InstrumentsList = db.Instruments.Local.ToObservableCollection();
            InstrumentList = db.TypeInstrument.Local.ToObservableCollection();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
