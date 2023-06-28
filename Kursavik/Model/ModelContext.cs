using Kurs.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Kurs.Model
{
    public class ModelContext : DbContext
    {
        public DbSet<Product> Product { get; set; } = null;
        public DbSet<Operation> Operation { get; set; } = null;
        public DbSet<Items> Items { get; set; } = null;
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Firma.db");
        }
    }

}
