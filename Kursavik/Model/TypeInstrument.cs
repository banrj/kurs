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
    public class TypeInstrument : INotifyPropertyChanged
    {
        [Key]
        public int ID { get; set; }

        private string? name;
        public string Name
        {
            get { return name!; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private string? description;
        public string Description
        {
            get { return description!; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }

        private int count_used;
        public int Count_used
        {
            get { return count_used; }
            set
            {
                count_used = value;
                OnPropertyChanged("Count_used");
            }
        }

        private int count_stored;
        public int Count_stored
        {
            get { return count_stored; }
            set
            {
                count_stored = value;
                OnPropertyChanged("Count_stored");
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
