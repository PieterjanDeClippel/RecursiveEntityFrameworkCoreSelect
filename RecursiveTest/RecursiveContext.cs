using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RecursiveTest.Entities;
using System;

namespace RecursiveTest
{
    public class RecursiveContext : DbContext
    {
        public RecursiveContext()
        {
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var connectionString = "Server=(localdb)\\mssqllocaldb;Database=Recursive;Trusted_Connection=True;ConnectRetryCount=0";
            optionsBuilder.UseSqlServer(connectionString, options => options.MigrationsAssembly("RecursiveTest"));
        }
    }
}
