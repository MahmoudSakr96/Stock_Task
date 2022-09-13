using Microsoft.EntityFrameworkCore;
using Stocks_Task.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.EF
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public virtual DbSet<Broker> Brokers { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }

        //Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //    modelBuilder.Entity<Order>(entity =>
            //    {
            //        entity.ToTable("Orders");
            //        entity.HasOne(d => d.Person)
            //                    .WithMany(p => p.Orders)
            //                    .HasForeignKey(d => d.PersonID)
            //                    .OnDelete(DeleteBehavior.ClientSetNull)
            //                    .HasConstraintName("FK_Orders_Person");
            //        entity.HasOne(d => d.Broker)
            //                    .WithMany(p => p.Orders)
            //                    .HasForeignKey(d => d.BrokerID)
            //                    .OnDelete(DeleteBehavior.ClientSetNull)
            //                    .HasConstraintName("FK_Orders_Brokers");
            //    });
            //    modelBuilder.Entity<Person>(entity =>
            //    {
            //        entity.ToTable("Persons");
            //        entity.HasOne(d => d.Broker)
            //                    .WithMany(p => p.Persons)
            //                    .HasForeignKey(d => d.BrokerID)
            //                    .OnDelete(DeleteBehavior.ClientSetNull)
            //                    .HasConstraintName("FK_Persons_Borker");

            //    });
            //    modelBuilder.Entity<Broker>().ToTable("Brokers");
            //    modelBuilder.Entity<Stock>().ToTable("Stocks");
        }

    }
}