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
using Microsoft.Data.Sqlite;

namespace Kursavik.ViewModels
{
    class ItemViewModel : INotifyPropertyChanged
    {
        private ItemView window;
        private Items selectedItems;
        public ObservableCollection<Items> ItemsList { get; set; }
        public Items SelectedItems
        {
            get { return selectedItems; }
            set
            {
                selectedItems = value;
                OnPropertyChanged("SelectedItems");
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
                      Items item = new Items();
                      item.Name = window.Name.Text;
                      item.Count = int.Parse(window.Count.Text);
                      item.Description = window.Description.Text;
                      item.Insert();
                      ItemsList.Add(item);
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
                      Items item = obj as Items;
                      if (item == null) return;
                      item.Delete(item.Id);
                      ItemsList.Remove(item);
                  }));
            }
        }
        private RelayCommand updateCommand;
        public RelayCommand UpdateCommand
        {
            get
            {
                return updateCommand ??
                  (updateCommand = new RelayCommand(obj =>
                  {
                      Items item = obj as Items;
                      item.Name = window.Name.Text;
                      item.Count = int.Parse(window.Count.Text);
                      item.Description = window.Description.Text;
                      item.Update(item.Id);

                  }));
            }
        }



        public ItemViewModel(ItemView window)
        {
            this.window = window;
            ItemsList = new ObservableCollection<Items>();
            using (var connection = new SqliteConnection("Data Source=Firma.db"))
            {
                connection.Open();
                SqliteCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Items";
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read())
                        {
                            Items item = new Items();
                            item.Id = reader.GetInt32(0);
                            item.Name = reader.GetString(1);
                            if (reader["description"] != DBNull.Value) item.Description = reader.GetString(2);
                            item.Count = reader.GetInt32(3);

                            ItemsList.Add(item);
                        }
                    }
                }
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