using Kurs.Model;
using Kursavik.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Diagnostics.Metrics;


namespace Kursavik.ViewModels
{
    public class InstrumentViewModel: INotifyPropertyChanged
    {
        private InstrumentView window;
        private TypeInstrument selectedInstrument;
        ModelContext db = new ModelContext();
        public ObservableCollection<TypeInstrument> InstrumentList { get; set; }
       
        public TypeInstrument SelectedInstrument
        {
            get { return selectedInstrument; }
            set
            {
                selectedInstrument = value;
                OnPropertyChanged("SelectedInstrument");
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
                      TypeInstrument instrument = new TypeInstrument();
                      instrument.Name = window.Name.Text;
                      instrument.Description = window.Description.Text;
                      instrument.Count_used = int.Parse(window.Count_used.Text);
                      instrument.Count_stored = int.Parse(window.Count_stored.Text);
                      
                      db.TypeInstrument.Add(instrument);
                      db.SaveChanges();
                      InstrumentList.Add(instrument);
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
                      TypeInstrument instrument = obj as TypeInstrument;
                      if (instrument == null) return;
                      db.TypeInstrument.Remove(instrument);
                      db.SaveChanges();
                      InstrumentList.Remove(instrument);
                  }));
            }
        }
        public InstrumentViewModel(InstrumentView window)
        {
            this.window = window;
            db.Database.EnsureCreated();
            db.TypeInstrument.Load();
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
