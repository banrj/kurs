using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Data.Sqlite;


namespace Kursavik.Models
{
    class Items : INotifyPropertyChanged
    {
        private int id;
        private string name;
        private string? description = " ";
        private int count;
     

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

      

        public string Description
        {
            get { return description; }
            set
            {

                description = value.ToString();
                OnPropertyChanged("Description");
            }
        }
        public int Count
        {
            get { return count; }
            set
            {
                count = value;
                OnPropertyChanged("Count");
            }
        }
      

        public void Insert()
        {
            using (var connection = new SqliteConnection("Data Source=Firma.db"))
            {
                connection.Open();

                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = $"INSERT INTO Items (name, description, count) VALUES ('{Name}','{Description}','{Count}')";
                command.ExecuteNonQuery();
            }
        }
        public void Delete(int id)
        {
            using (var connection = new SqliteConnection("Data Source=Firma.db"))
            {
                connection.Open();

                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = $"Delete from Items where ID={id}";
                command.ExecuteNonQuery();
            }
        }
        public void Update(int id)
        {
            using (var connection = new SqliteConnection("Data Source=Firma.db"))
            {
                connection.Open();

                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = $"UPDATE Items SET name='{Name}', count='{Count}',description='{Description}' where ID={id}";
                command.ExecuteNonQuery();
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
