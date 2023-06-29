using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kurs.Model
{
    public class Instruments: INotifyPropertyChanged
    {
        [Key]
        public int ID { get; set; }

        private string? receipt_date;
        public string Receipt_date
        {
            get { return receipt_date!; }
            set
            {
                receipt_date = value;
                OnPropertyChanged("Receipt_date");
            }
        }

        private int operation_id;
        public int Operation_id
        {
            get { return operation_id; }
            set
            {
                operation_id = value;
                OnPropertyChanged("Operation_id");
            }
        }

        private int type;
        public int Type
        {
            get { return type; }
            set
            {
                type = value;
                OnPropertyChanged("Type");
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
