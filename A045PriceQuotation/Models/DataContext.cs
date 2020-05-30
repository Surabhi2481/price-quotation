using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace A045PriceQuotation.Models
{
    public class DataContext : DbContext
    {
        public DbSet<mainClass> mainClasss { get; set; }

        /*internal void SaveChanges()
        {
            throw new NotImplementedException();
        }*/

        public DataContext() : base("name = DbContextConn")
        {

        }

        public DbSet<user> users { get; set; }

        public DbSet<product> products { get; set; }

        public DbSet<pquotation> pquotations { get; set; }

        public DbSet<bill> bills { get; set; }

       // public DbSet<account> accounts { get; set; }

        public DbSet<categoryProduct> categoryProducts { get; set; }

        public DbSet<account> accounts { get; set; }

    }

}