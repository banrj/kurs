﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;


namespace Kursavik.Models
{
    class Product : INotifyPropertyChanged
    {
        private int id;
        private string name;
        private string lastBatch;
        private int count;
        private int price;
        //private byte[] image;

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

        //public byte[] Image

        //{

        // get { return image; }
        // set
        //  {
        // image = value;
        //OnPropertyChanged("Image");
        //}
    

    public string LastBatch
        {
            get { return lastBatch; }
            set 
            { 
            
                lastBatch = value.ToString();
                OnPropertyChanged("LastBatch");
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
                command.CommandText = $"INSERT INTO Product (name, price,last_batch,count_operation) VALUES ('{Name}', '{Price}','{LastBatch}','{Count}')";
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
                command.CommandText = $"UPDATE Product SET name='{Name}', price='{Price}',last_batch='{LastBatch}'," +
                    $"count_operation='{Count}' where ID={id}";
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