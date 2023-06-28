using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kurs.Model
{
    public class Operation : INotifyPropertyChanged
    {

        public int ID { get; set; }
        private int Idplan;
        public int IDPlan
        {
            get { return Idplan; }
            set
            {
                Idplan = value;
                OnPropertyChanged("IDPlan");
            }
        }
        private int Idworkshop;
        public int IDWorkshop
        {
            get { return Idworkshop; }
            set
            {
                Idworkshop = value;
                OnPropertyChanged("IDWorkshop");
            }
        }
        private int IdProduct;
        public int IDProduct
        {
            get { return IdProduct; }
            set
            {
                IdProduct = value;
                OnPropertyChanged("IDProduct");
            }
        }
        private int time;
        public int Time
        {
            get { return time; }
            set
            {
                time = value;
                OnPropertyChanged("Time");
            }
        }

        private string? description;
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}