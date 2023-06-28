using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;


namespace Kurs.Model
{
    public class Product : INotifyPropertyChanged
    {
        private int Id;
        private string? name;
        private string? last_batch;
        private int count;
        private int price;
        private string? foto;
        public string Foto
        {
            get { return foto!; }
            set
            {
                foto = value;
                OnPropertyChanged("Foto");
            }
        }

        [Key]
        public int ID 
        {
            get { return Id; }
            set { Id = value; }
        }

        public string Name
        {
            get { return name!; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }    

        public string Last_batch
        {
            get { return last_batch!; }
            set 
            {

                last_batch = value.ToString();
                OnPropertyChanged("Last_Batch");
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
        public int Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        public void Insert()
        {
            using (var connection = new SqliteConnection("Data Source=Firma.db"))
            {
                connection.Open();

                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = $"INSERT INTO Product (name, price,last_batch,count_operation, foto) VALUES ('{Name}', '{Price}','{Last_batch}','{Count}', '{Foto}')";
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
                command.CommandText = $"Delete from Product where ID={id}";
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
                command.CommandText = $"UPDATE Product SET Name='{Name}', Price='{Price}',Last_batch='{Last_batch}'," +
                    $"Count='{Count}, Foto={Foto}' where ID={id}";
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
