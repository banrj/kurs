﻿using Kurs.Model;
using Kursavik.Views;
using Microsoft.Data.Sqlite;
using Microsoft.Win32;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Media.Imaging;


namespace Kurs.ViewModels
{
    class ProductsViewModel : INotifyPropertyChanged
    {
        private ProductView window;
        private Product selectedProduct;
        private string ImageFileName { get; set; }
        public ObservableCollection<Product> ProductsList { get; set; }
        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                OnPropertyChanged("SelectedProduct");
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
                      Product product = new Product();
                      product.Name = window.Name.Text;
                      product.Price = int.Parse(window.Price.Text);
                      product.Count = int.Parse(window.Count.Text);
                      product.Last_batch = window.LastBatch.Text;
                      product.Foto = Convert.ToBase64String(File.ReadAllBytes(ImageFileName));
                      product.Insert();
                      ProductsList.Add(product);
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
                      Product product = obj as Product;
                      if (product == null) return;
                      product.Delete(product.ID);
                      ProductsList.Remove(product);
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
                      Product product = obj as Product;
                      product.Name = window.Name.Text;
                      product.Price = int.Parse(window.Price.Text);
                      product.Count = int.Parse(window.Count.Text);
                      product.Last_batch = window.LastBatch.Text;
                      if (ImageFileName!= null) product.Foto = Convert.ToBase64String(File.ReadAllBytes(ImageFileName));
                      product.Update(product.ID);
                  }));
            }
        }

        private RelayCommand loadCommand;
        public RelayCommand LoadCommand
        {
            get
            {
                return loadCommand ??
                  (loadCommand = new RelayCommand(obj =>
                  {
                      OpenFileDialog ofd = new OpenFileDialog();
                      ofd.Filter = "*.jpg|*.jpg|*.bmp|*.bmp|*.png|*.png";
                      if (ofd.ShowDialog() == true)
                      {
                          BitmapImage myBitmapImage = new BitmapImage();
                          ImageFileName = ofd.FileName;
                          myBitmapImage.BeginInit();
                          myBitmapImage.UriSource = new Uri(ofd.FileName);
                          myBitmapImage.DecodePixelWidth = 200;
                          myBitmapImage.EndInit();
                          window.ImageProduct.Source = myBitmapImage;

                      }
                  }));
            }
        }


        public ProductsViewModel(ProductView window)
        {
            this.window = window;
            ProductsList = new ObservableCollection<Product>();
            using (var connection = new SqliteConnection("Data Source=Firma.db"))
            {
                connection.Open();
                SqliteCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Product";
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read())
                        {
                            Product product = new Product();
                            product.ID = reader.GetInt32(0);
                            product.Last_batch = reader.GetString(1);
                            product.Price = reader.GetInt32(2);
                            product.Count = reader.GetInt32(3);
                            product.Name = reader.GetString(4);
                            product.Foto = reader.GetString(5)??"";
                            ProductsList.Add(product);
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
