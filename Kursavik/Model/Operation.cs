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
        [Key]
        public int ID { get; set; }
        private int plan_Id;
        public int plan_id
        {
            get { return plan_Id; }
            set
            {
                plan_Id = value;
                OnPropertyChanged("plan_id");
            }
        }
        private int workshop_Id;
        public int workshop_id
        {
            get { return workshop_Id; }
            set
            {
                workshop_Id = value;
                OnPropertyChanged("workshop_Id");
            }
        }
        private int product_Id;
        public int product_id
        {
            get { return product_Id; }
            set
            {
                product_Id = value;
                OnPropertyChanged("product_id");
            }
        }
        private int Time;
        public int time
        {
            get { return Time; }
            set
            {
                Time = value;
                OnPropertyChanged("time");
            }
        }

        private string? Description;
        public string description
        {
            get { return Description; }
            set
            {
                Description = value;
                OnPropertyChanged("description");
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